Imports System.Data.OleDb

Public Class Articoli
   Public Id As Integer
   Public Codice As String
   Public CodBarre As String
   Public Descrizione As String
   Public Fornitore As String
   Public Unit‡Misura As String
   Public Categoria As String
   Public Magazzino As String
   Public Ubicazione As String
   Public Scaffale As String
   Public PrezzoAcquisto As String
   Public Giacenza As Double
   Public Carico As Double
   Public Scarico As Double
   Public ScortaMin As Double
   Public SituazioneScorta As Double
   Public ValCarico As Double
   Public ValScarico As Double
   Public ValAttuale As Double
   Public ProduttoreVino As String
   Public RegioneVino As String
   Public ZonaVino As String
   Public AnnoVino As String
   Public FormatoVino As String
   Public ScansiaVino As String
   Public Note As String
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
            Me.Id = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Id = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Codice")) = False Then
            Me.Codice = ds.Tables(tabella).Rows(0)("Codice").ToString
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Fornitore")) = False Then
            Me.Fornitore = ds.Tables(tabella).Rows(0)("Fornitore").ToString
         Else
            Me.Fornitore = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Unit‡Misura")) = False Then
            Me.Unit‡Misura = ds.Tables(tabella).Rows(0)("Unit‡Misura").ToString
         Else
            Me.Unit‡Misura = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Categoria")) = False Then
            Me.Categoria = ds.Tables(tabella).Rows(0)("Categoria").ToString
         Else
            Me.Categoria = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Magazzino")) = False Then
            Me.Magazzino = ds.Tables(tabella).Rows(0)("Magazzino").ToString
         Else
            Me.Magazzino = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Ubicazione")) = False Then
            Me.Ubicazione = ds.Tables(tabella).Rows(0)("Ubicazione").ToString
         Else
            Me.Ubicazione = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Scaffale")) = False Then
            Me.Scaffale = ds.Tables(tabella).Rows(0)("Scaffale").ToString
         Else
            Me.Scaffale = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PrezzoAcquisto")) = False Then
            Me.PrezzoAcquisto = ds.Tables(tabella).Rows(0)("PrezzoAcquisto").ToString
         Else
            Me.PrezzoAcquisto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Giacenza")) = False Then
            Me.Giacenza = ds.Tables(tabella).Rows(0)("Giacenza")
         Else
            Me.Giacenza = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Carico")) = False Then
            Me.Carico = ds.Tables(tabella).Rows(0)("Carico")
         Else
            Me.Carico = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Scarico")) = False Then
            Me.Scarico = ds.Tables(tabella).Rows(0)("Scarico")
         Else
            Me.Scarico = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScortaMin")) = False Then
            Me.ScortaMin = ds.Tables(tabella).Rows(0)("ScortaMin")
         Else
            Me.ScortaMin = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("SituazioneScorta")) = False Then
            Me.SituazioneScorta = ds.Tables(tabella).Rows(0)("SituazioneScorta")
         Else
            Me.SituazioneScorta = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValCarico")) = False Then
            Me.ValCarico = ds.Tables(tabella).Rows(0)("ValCarico")
         Else
            Me.ValCarico = 0 'VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValScarico")) = False Then
            Me.ValScarico = ds.Tables(tabella).Rows(0)("ValScarico")
         Else
            Me.ValScarico = 0 'VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValAttuale")) = False Then
            Me.ValAttuale = ds.Tables(tabella).Rows(0)("ValAttuale")
         Else
            Me.ValAttuale = 0 'VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ProduttoreVino")) = False Then
            Me.ProduttoreVino = ds.Tables(tabella).Rows(0)("ProduttoreVino").ToString
         Else
            Me.ProduttoreVino = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("RegioneVino")) = False Then
            Me.RegioneVino = ds.Tables(tabella).Rows(0)("RegioneVino").ToString
         Else
            Me.RegioneVino = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ZonaVino")) = False Then
            Me.ZonaVino = ds.Tables(tabella).Rows(0)("ZonaVino").ToString
         Else
            Me.ZonaVino = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnnoVino")) = False Then
            Me.AnnoVino = ds.Tables(tabella).Rows(0)("AnnoVino").ToString
         Else
            Me.AnnoVino = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("FormatoVino")) = False Then
            Me.FormatoVino = ds.Tables(tabella).Rows(0)("FormatoVino").ToString
         Else
            Me.FormatoVino = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScansiaVino")) = False Then
            Me.ScansiaVino = ds.Tables(tabella).Rows(0)("ScansiaVino").ToString
         Else
            Me.ScansiaVino = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
         Else
            Me.Note = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
            Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine").ToString
         Else
            Me.Immagine = String.Empty
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
         sql = String.Format("INSERT INTO {0} (Codice, CodBarre, Descrizione, Fornitore, Unit‡Misura, " & _
                                              "Categoria, Magazzino, Ubicazione, Scaffale, PrezzoAcquisto, " & _
                                              "Giacenza, Carico, Scarico, ScortaMin, SituazioneScorta, ValCarico, ValScarico, " & _
                                              "ValAttuale, ProduttoreVino, RegioneVino, ZonaVino, AnnoVino, " & _
                                              "FormatoVino, ScansiaVino, Immagine, [Note]) " & _
                                       "VALUES(@Codice, @CodBarre, @Descrizione, @Fornitore, @Unit‡Misura, " & _
                                              "@Categoria, @Magazzino, @Ubicazione, @Scaffale, @PrezzoAcquisto, " & _
                                              "@Giacenza, @Carico, @Scarico, @ScortaMin, @SituazioneScorta, @ValCarico, @ValScarico, " & _
                                              "@ValAttuale, @ProduttoreVino, @RegioneVino, @ZonaVino, @AnnoVino, " & _
                                              "@FormatoVino, @ScansiaVino, @Immagine, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Codice", Me.Codice)
         cmdInsert.Parameters.AddWithValue("@CodBarre", Me.CodBarre)
         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@Fornitore", Me.Fornitore)
         cmdInsert.Parameters.AddWithValue("@Unit‡Misura", Me.Unit‡Misura)
         cmdInsert.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdInsert.Parameters.AddWithValue("@Magazzino", Me.Magazzino)
         cmdInsert.Parameters.AddWithValue("@Ubicazione", Me.Ubicazione)
         cmdInsert.Parameters.AddWithValue("@Scaffale", Me.Scaffale)
         cmdInsert.Parameters.AddWithValue("@PrezzoAcquisto", Me.PrezzoAcquisto)
         cmdInsert.Parameters.AddWithValue("@Giacenza", Me.Giacenza)
         cmdInsert.Parameters.AddWithValue("@Carico", Me.Carico)
         cmdInsert.Parameters.AddWithValue("@Scarico", Me.Scarico)
         cmdInsert.Parameters.AddWithValue("@ScortaMin", Me.ScortaMin)
         cmdInsert.Parameters.AddWithValue("@SituazioneScorta", Me.SituazioneScorta)
         cmdInsert.Parameters.AddWithValue("@ValCarico", Me.ValCarico)
         cmdInsert.Parameters.AddWithValue("@ValScarico", Me.ValScarico)
         cmdInsert.Parameters.AddWithValue("@ValAttuale", Me.ValAttuale)
         cmdInsert.Parameters.AddWithValue("@ProduttoreVino", Me.ProduttoreVino)
         cmdInsert.Parameters.AddWithValue("@RegioneVino", Me.RegioneVino)
         cmdInsert.Parameters.AddWithValue("@ZonaVino", Me.ZonaVino)
         cmdInsert.Parameters.AddWithValue("@AnnoVino", Me.AnnoVino)
         cmdInsert.Parameters.AddWithValue("@FormatoVino", Me.FormatoVino)
         cmdInsert.Parameters.AddWithValue("@ScasiaVino", Me.ScansiaVino)
         cmdInsert.Parameters.AddWithValue("@Immagine", Me.Immagine)
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
                             "SET Codice = @Codice, " & _
                             "CodBarre = @CodBarre, " & _
                             "Descrizione = @Descrizione, " & _
                             "Fornitore = @Fornitore, " & _
                             "Unit‡Misura = @Unit‡Misura, " & _
                             "Categoria = @Categoria, " & _
                             "Magazzino = @Magazzino, " & _
                             "Ubicazione = @Ubicazione, " & _
                             "Scaffale = @Scaffale, " & _
                             "PrezzoAcquisto = @PrezzoAcquisto, " & _
                             "Giacenza = @Giacenza, " & _
                             "Carico = @Carico, " & _
                             "Scarico = @Scarico, " & _
                             "ScortaMin = @ScortaMin, " & _
                             "SituazioneScorta = @SituazioneScorta, " & _
                             "ValCarico = @ValCarico, " & _
                             "ValScarico = @ValScarico, " & _
                             "ValAttuale = @ValAttuale, " & _
                             "ProduttoreVino = @ProduttoreVino, " & _
                             "RegioneVino = @RegioneVino, " & _
                             "ZonaVino = @ZonaVino, " & _
                             "AnnoVino = @AnnoVino, " & _
                             "FormatoVino = @FormatoVino, " & _
                             "ScansiaVino = @ScansiaVino, " & _
                             "Immagine = @Immagine, " & _
                             "[Note] = @Note " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Codice", Me.Codice)
         cmdUpdate.Parameters.AddWithValue("@CodBarre", Me.CodBarre)
         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@Fornitore", Me.Fornitore)
         cmdUpdate.Parameters.AddWithValue("@Unit‡Misura", Me.Unit‡Misura)
         cmdUpdate.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdUpdate.Parameters.AddWithValue("@Magazzino", Me.Magazzino)
         cmdUpdate.Parameters.AddWithValue("@Ubicazione", Me.Ubicazione)
         cmdUpdate.Parameters.AddWithValue("@Scaffale", Me.Scaffale)
         cmdUpdate.Parameters.AddWithValue("@PrezzoAcquisto", Me.PrezzoAcquisto)
         cmdUpdate.Parameters.AddWithValue("@Giacenza", Me.Giacenza)
         cmdUpdate.Parameters.AddWithValue("@Carico", Me.Carico)
         cmdUpdate.Parameters.AddWithValue("@Scarico", Me.Scarico)
         cmdUpdate.Parameters.AddWithValue("@ScortaMin", Me.ScortaMin)
         cmdUpdate.Parameters.AddWithValue("@SituazioneScorta", Me.SituazioneScorta)
         cmdUpdate.Parameters.AddWithValue("@ValCarico", Me.ValCarico)
         cmdUpdate.Parameters.AddWithValue("@ValScarico", Me.ValScarico)
         cmdUpdate.Parameters.AddWithValue("@ValAttuale", Me.ValAttuale)
         cmdUpdate.Parameters.AddWithValue("@ProduttoreVino", Me.ProduttoreVino)
         cmdUpdate.Parameters.AddWithValue("@RegioneVino", Me.RegioneVino)
         cmdUpdate.Parameters.AddWithValue("@ZonaVino", Me.ZonaVino)
         cmdUpdate.Parameters.AddWithValue("@AnnoVino", Me.AnnoVino)
         cmdUpdate.Parameters.AddWithValue("@FormatoVino", Me.FormatoVino)
         cmdUpdate.Parameters.AddWithValue("@ScansiaVino", Me.ScansiaVino)
         cmdUpdate.Parameters.AddWithValue("@Immagine", Me.Immagine)
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
End Class
