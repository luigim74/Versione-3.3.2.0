Imports System.Data.OleDb

Public Class Piatti

   Public Codice As String
   Public CodBarre As String
   Public Descrizione As String
   Public DescrizionePos As String
   Public Ingredienti As String
   Public Categoria As String
   Public Variazione As String
   Public EscludiMenu As String
   Public Qt‡Venduta As String
   Public ValVenduto As String
   Public Listino1 As String
   Public Listino2 As String
   Public Listino3 As String
   Public Listino4 As String
   Public AliquotaIva As String
   Public Note As String
   Public ColoreStile As Integer
   Public ColoreSfondo As Integer
   Public ColoreTesto As Integer
   Public AltezzaTasto As Integer
   Public LarghezzaTasto As Integer
   Public NumTastiRiga As Integer
   Public OrdineTasto As Integer
   Public Icona As String
   Public Immagine As String

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
            Me.Codice = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodBarre")) = False Then
            Me.CodBarre = ds.Tables(tabella).Rows(0)("CodBarre").ToString
         Else
            Me.CodBarre = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione").ToString
         Else
            Me.Descrizione = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizionePos")) = False Then
            Me.DescrizionePos = ds.Tables(tabella).Rows(0)("DescrizionePos").ToString
         Else
            Me.DescrizionePos = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Ingredienti")) = False Then
            Me.Ingredienti = ds.Tables(tabella).Rows(0)("Ingredienti").ToString
         Else
            Me.Ingredienti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Categoria")) = False Then
            Me.Categoria = ds.Tables(tabella).Rows(0)("Categoria").ToString
         Else
            Me.Categoria = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Variazione")) = False Then
            Me.Variazione = ds.Tables(tabella).Rows(0)("Variazione").ToString
         Else
            Me.Variazione = "No"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("EscludiMenu")) = False Then
            Me.EscludiMenu = ds.Tables(tabella).Rows(0)("EscludiMenu").ToString
         Else
            Me.EscludiMenu = "No"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Qt‡Venduta")) = False Then
            Me.Qt‡Venduta = ds.Tables(tabella).Rows(0)("Qt‡Venduta").ToString
         Else
            Me.Qt‡Venduta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValVenduto")) = False Then
            Me.ValVenduto = ds.Tables(tabella).Rows(0)("ValVenduto").ToString
         Else
            Me.ValVenduto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino1")) = False Then
            Me.Listino1 = ds.Tables(tabella).Rows(0)("Listino1").ToString
         Else
            Me.Listino1 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino2")) = False Then
            Me.Listino2 = ds.Tables(tabella).Rows(0)("Listino2").ToString
         Else
            Me.Listino2 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino3")) = False Then
            Me.Listino3 = ds.Tables(tabella).Rows(0)("Listino3").ToString
         Else
            Me.Listino3 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino4")) = False Then
            Me.Listino4 = ds.Tables(tabella).Rows(0)("Listino4").ToString
         Else
            Me.Listino4 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AliquotaIva")) = False Then
            Me.AliquotaIva = ds.Tables(tabella).Rows(0)("AliquotaIva").ToString
         Else
            Me.AliquotaIva = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
         Else
            Me.Note = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ColoreSfondo")) = False Then
            Me.ColoreSfondo = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ColoreSfondo"))
         Else
            Me.ColoreSfondo = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ColoreTesto")) = False Then
            Me.ColoreTesto = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ColoreTesto"))
         Else
            Me.ColoreTesto = 0
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
            Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine").ToString
         Else
            Me.Immagine = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Icona")) = False Then
            Me.Icona = ds.Tables(tabella).Rows(0)("Icona").ToString
         Else
            Me.Icona = String.Empty
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
         sql = String.Format("INSERT INTO {0} (CodBarre, Descrizione, DescrizionePos, Categoria, Variazione, Qt‡Venduta, ValVenduto, " &
                                              "Listino1, Listino2, Listino3, Listino4, AliquotaIva, Immagine, [Note], Ingredienti, EscludiMenu, Icona, " &
                                              "ColoreStile, ColoreSfondo, ColoreTesto, AltezzaTasto, LarghezzaTasto, NumTastiRiga, OrdineTasto) " &
                                       "VALUES(@CodBarre, @Descrizione, @DescrizionePos, @Categoria, @Variazione, @Qt‡Venduta, @ValVenduto, " &
                                              "@Listino1, @Listino2, @Listino3, @Listino4, @AliquotaIva, @Immagine, @Note, @Ingredienti, @EscludiMenu, @Icona, " &
                                              "@ColoreStile, @ColoreSfondo, @ColoreTesto, @AltezzaTasto, @LarghezzaTasto, @NumTastiRiga, @OrdineTasto)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@CodBarre", Me.CodBarre)
         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@DescrizionePos", Me.DescrizionePos)
         cmdInsert.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdInsert.Parameters.AddWithValue("@Variazione", Me.Variazione)
         cmdInsert.Parameters.AddWithValue("@Qt‡Venduta", Me.Qt‡Venduta)
         cmdInsert.Parameters.AddWithValue("@ValVenduto", Me.ValVenduto)
         cmdInsert.Parameters.AddWithValue("@Listino1", Me.Listino1)
         cmdInsert.Parameters.AddWithValue("@Listino2", Me.Listino2)
         cmdInsert.Parameters.AddWithValue("@Listino3", Me.Listino3)
         cmdInsert.Parameters.AddWithValue("@Listino4", Me.Listino4)
         cmdInsert.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
         cmdInsert.Parameters.AddWithValue("@Immagine", Me.Immagine)
         cmdInsert.Parameters.AddWithValue("@Note", Me.Note)
         cmdInsert.Parameters.AddWithValue("@Ingredienti", Me.Ingredienti)
         cmdInsert.Parameters.AddWithValue("@EscludiMenu", Me.EscludiMenu)
         cmdInsert.Parameters.AddWithValue("@Icona", Me.Icona)
         cmdInsert.Parameters.AddWithValue("@ColoreStile", Me.ColoreStile)
         cmdInsert.Parameters.AddWithValue("@ColoreSfondo", Me.ColoreSfondo)
         cmdInsert.Parameters.AddWithValue("@ColoreTesto", Me.ColoreTesto)
         cmdInsert.Parameters.AddWithValue("@AltezzaTasto", Me.AltezzaTasto)
         cmdInsert.Parameters.AddWithValue("@LarghezzaTasto", Me.LarghezzaTasto)
         cmdInsert.Parameters.AddWithValue("@NumTastiRiga", Me.NumTastiRiga)
         cmdInsert.Parameters.AddWithValue("@OrdineTasto", Me.OrdineTasto)

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
                             "Set CodBarre = @CodBarre, " &
                             "Descrizione = @Descrizione, " &
                             "DescrizionePos = @DescrizionePos, " &
                             "Categoria = @Categoria, " &
                             "Variazione = @Variazione, " &
                             "Qt‡Venduta = @Qt‡Venduta, " &
                             "ValVenduto = @ValVenduto, " &
                             "Listino1 = @Listino1, " &
                             "Listino2 = @Listino2, " &
                             "Listino3 = @Listino3, " &
                             "Listino4 = @Listino4, " &
                             "AliquotaIva = @AliquotaIva, " &
                             "Immagine = @Immagine, " &
                             "Ingredienti = @Ingredienti, " &
                             "EscludiMenu = @EscludiMenu, " &
                             "Icona = @Icona, " &
                             "[Note] = @Note, " &
                             "ColoreStile = @ColoreStile, " &
                             "ColoreSfondo = @ColoreSfondo, " &
                             "ColoreTesto = @ColoreTesto, " &
                             "AltezzaTasto = @AltezzaTasto, " &
                             "LarghezzaTasto = @LarghezzaTasto, " &
                             "NumTastiRiga = @NumTastiRiga, " &
                             "OrdineTasto = @OrdineTasto " &
                             "WHERE Id = {1}",
                             tabella,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@CodBarre", Me.CodBarre)
         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@DescrizionePos", Me.DescrizionePos)
         cmdUpdate.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdUpdate.Parameters.AddWithValue("@Variazione", Me.Variazione)
         cmdUpdate.Parameters.AddWithValue("@Qt‡Venduta", Me.Qt‡Venduta)
         cmdUpdate.Parameters.AddWithValue("@ValVenduto", Me.ValVenduto)
         cmdUpdate.Parameters.AddWithValue("@Listino1", Me.Listino1)
         cmdUpdate.Parameters.AddWithValue("@Listino2", Me.Listino2)
         cmdUpdate.Parameters.AddWithValue("@Listino3", Me.Listino3)
         cmdUpdate.Parameters.AddWithValue("@Listino4", Me.Listino4)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
         cmdUpdate.Parameters.AddWithValue("@Immagine", Me.Immagine)
         cmdUpdate.Parameters.AddWithValue("@Ingredienti", Me.Ingredienti)
         cmdUpdate.Parameters.AddWithValue("@EscludiMenu", Me.EscludiMenu)
         cmdUpdate.Parameters.AddWithValue("@Icona", Me.Icona)
         cmdUpdate.Parameters.AddWithValue("@Note", Me.Note)
         cmdUpdate.Parameters.AddWithValue("@ColoreStile", Me.ColoreStile)
         cmdUpdate.Parameters.AddWithValue("@ColoreSfondo", Me.ColoreSfondo)
         cmdUpdate.Parameters.AddWithValue("@ColoreTesto", Me.ColoreTesto)
         cmdUpdate.Parameters.AddWithValue("@AltezzaTasto", Me.AltezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@LarghezzaTasto", Me.LarghezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@NumTastiRiga", Me.NumTastiRiga)
         cmdUpdate.Parameters.AddWithValue("@OrdineTasto", Me.OrdineTasto)

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
   Public Function ModificaDati(ByVal coloreStile As Integer, ByVal coloreSfondo As Integer, ByVal coloreTesto As Integer, ByVal altezzaTasto As Integer, ByVal larghezzaTasto As Integer, ByVal numTastiRiga As Integer, ByVal immagine As String, ByVal descrizionePos As String, ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET ColoreStile = @ColoreStile, " &
                             "ColoreSfondo = @ColoreSfondo, " &
                             "ColoreTesto = @ColoreTesto, " &
                             "AltezzaTasto = @AltezzaTasto, " &
                             "LarghezzaTasto = @LarghezzaTasto, " &
                             "NumTastiRiga = @NumTastiRiga, " &
                             "Icona = @Icona " &
                             "WHERE DescrizionePos = '{1}'",
                             tabella,
                             descrizionePos)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@ColoreStile", coloreStile)
         cmdUpdate.Parameters.AddWithValue("@ColoreSfondo", coloreSfondo)
         cmdUpdate.Parameters.AddWithValue("@ColoreTesto", coloreTesto)
         cmdUpdate.Parameters.AddWithValue("@AltezzaTasto", altezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@LarghezzaTasto", larghezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@NumTastiRiga", numTastiRiga)
         cmdUpdate.Parameters.AddWithValue("@Icona", immagine)

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
   Public Function ModificaOrdineTasto(ByVal ordine As Integer, ByVal descrizionePos As String, ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET OrdineTasto = @OrdineTasto " &
                             "WHERE DescrizionePos = '{1}'",
                             tabella,
                             descrizionePos)

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
