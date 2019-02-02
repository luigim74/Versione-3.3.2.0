Imports System.Data.OleDb

Public Class Gruppi

   Public Id As Integer
   Public NomeGruppo As String
   Public Amministratore As String
   Public AnagAziende As String
   Public AnagCamerieri As String
   Public AnagCatPiatti As String
   Public AnagClienti As String
   Public AnagDatiAzienda As String
   Public AnagFornitori As String
   Public AnagPiatti As String
   Public AnagSale As String
   Public AnagTavoli As String
   Public AnagRisorse As String
   Public AnagAccessoriServizi As String
   Public ArchiviBackup As String
   Public ArchiviCompatta As String
   Public ArchiviPulizia As String
   Public TabAttività As String
   Public TabCatClienti As String
   Public TabCatMerce As String
   Public TabFormeCortesia As String
   Public TabMagazzini As String
   Public TabMsg As String
   Public TabNazioni As String
   Public TabPagamenti As String
   Public TabPiani As String
   Public TabReparti As String
   Public TabScaffali As String
   Public TabTipoDoc As String
   Public TabUbicazioni As String
   Public TabUM As String
   Public TabTipoRisorse As String
   Public ContChiusura As String
   Public ContCorrispettivi As String
   Public ContDoc As String
   Public ContPrimaNota As String
   Public GestAcquisti As String
   Public GestGruppi As String
   Public GestOperatori As String
   Public GestPrenSale As String
   Public GestPrenTavoli As String
   Public GestPrenRisorse As String
   Public GestPlanningRisorse As String
   Public GestStatRisorse As String
   Public GestPuntoCassa As String
   Public GestStatistiche As String
   Public GestTavoli As String
   Public MagArticoli As String
   Public MagInventario As String
   Public MagScorte As String
   Public MagMov As String
   Public StruDispTavoli As String
   Public StruCap As String
   Public StruMsg As String
   Public StruCodiciBarre As String
   Public StruMenù As String
   Public VisOpzioni As String
   Public VisErrori As String
   Public VisOperazioni As String
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
            Me.Id = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Id = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NomeGruppo")) = False Then
            Me.NomeGruppo = ds.Tables(tabella).Rows(0)("NomeGruppo")
         Else
            Me.NomeGruppo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Amministratore")) = False Then
            Me.Amministratore = ds.Tables(tabella).Rows(0)("Amministratore")
         Else
            Me.Amministratore = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagAziende")) = False Then
            Me.AnagAziende = ds.Tables(tabella).Rows(0)("AnagAziende")
         Else
            Me.AnagAziende = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagCamerieri")) = False Then
            Me.AnagCamerieri = ds.Tables(tabella).Rows(0)("AnagCamerieri")
         Else
            Me.AnagCamerieri = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagCatPiatti")) = False Then
            Me.AnagCatPiatti = ds.Tables(tabella).Rows(0)("AnagCatPiatti")
         Else
            Me.AnagCatPiatti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagClienti")) = False Then
            Me.AnagClienti = ds.Tables(tabella).Rows(0)("AnagClienti")
         Else
            Me.AnagClienti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagDatiAzienda")) = False Then
            Me.AnagDatiAzienda = ds.Tables(tabella).Rows(0)("AnagDatiAzienda")
         Else
            Me.AnagDatiAzienda = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagFornitori")) = False Then
            Me.AnagFornitori = ds.Tables(tabella).Rows(0)("AnagFornitori")
         Else
            Me.AnagFornitori = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagPiatti")) = False Then
            Me.AnagPiatti = ds.Tables(tabella).Rows(0)("AnagPiatti")
         Else
            Me.AnagPiatti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagSale")) = False Then
            Me.AnagSale = ds.Tables(tabella).Rows(0)("AnagSale")
         Else
            Me.AnagSale = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagTavoli")) = False Then
            Me.AnagTavoli = ds.Tables(tabella).Rows(0)("AnagTavoli")
         Else
            Me.AnagTavoli = String.Empty
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagRisorse")) = False Then
            Me.AnagRisorse = ds.Tables(tabella).Rows(0)("AnagRisorse")
         Else
            Me.AnagRisorse = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnagAccessoriServizi")) = False Then
            Me.AnagAccessoriServizi = ds.Tables(tabella).Rows(0)("AnagAccessoriServizi")
         Else
            Me.AnagAccessoriServizi = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ArchiviBackup")) = False Then
            Me.ArchiviBackup = ds.Tables(tabella).Rows(0)("ArchiviBackup")
         Else
            Me.ArchiviBackup = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ArchiviCompatta")) = False Then
            Me.ArchiviCompatta = ds.Tables(tabella).Rows(0)("ArchiviCompatta")
         Else
            Me.ArchiviCompatta = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ArchiviPulizia")) = False Then
            Me.ArchiviPulizia = ds.Tables(tabella).Rows(0)("ArchiviPulizia")
         Else
            Me.ArchiviPulizia = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabAttività")) = False Then
            Me.TabAttività = ds.Tables(tabella).Rows(0)("TabAttività")
         Else
            Me.TabAttività = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabCatClienti")) = False Then
            Me.TabCatClienti = ds.Tables(tabella).Rows(0)("TabCatClienti")
         Else
            Me.TabCatClienti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabCatMerce")) = False Then
            Me.TabCatMerce = ds.Tables(tabella).Rows(0)("TabCatMerce")
         Else
            Me.TabCatMerce = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabFormeCortesia")) = False Then
            Me.TabFormeCortesia = ds.Tables(tabella).Rows(0)("TabFormeCortesia")
         Else
            Me.TabFormeCortesia = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabMagazzini")) = False Then
            Me.TabMagazzini = ds.Tables(tabella).Rows(0)("TabMagazzini")
         Else
            Me.TabMagazzini = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabMsg")) = False Then
            Me.TabMsg = ds.Tables(tabella).Rows(0)("TabMsg")
         Else
            Me.TabMsg = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabNazioni")) = False Then
            Me.TabNazioni = ds.Tables(tabella).Rows(0)("TabNazioni")
         Else
            Me.TabNazioni = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabPagamenti")) = False Then
            Me.TabPagamenti = ds.Tables(tabella).Rows(0)("TabPagamenti")
         Else
            Me.TabPagamenti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabPiani")) = False Then
            Me.TabPiani = ds.Tables(tabella).Rows(0)("TabPiani")
         Else
            Me.TabPiani = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabReparti")) = False Then
            Me.TabReparti = ds.Tables(tabella).Rows(0)("TabReparti")
         Else
            Me.TabReparti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabScaffali")) = False Then
            Me.TabScaffali = ds.Tables(tabella).Rows(0)("TabScaffali")
         Else
            Me.TabScaffali = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabTipoDoc")) = False Then
            Me.TabTipoDoc = ds.Tables(tabella).Rows(0)("TabTipoDoc")
         Else
            Me.TabTipoDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabUbicazioni")) = False Then
            Me.TabUbicazioni = ds.Tables(tabella).Rows(0)("TabUbicazioni")
         Else
            Me.TabUbicazioni = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabUM")) = False Then
            Me.TabUM = ds.Tables(tabella).Rows(0)("TabUM")
         Else
            Me.TabUM = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TabTipoRisorse")) = False Then
            Me.TabTipoRisorse = ds.Tables(tabella).Rows(0)("TabTipoRisorse")
         Else
            Me.TabTipoRisorse = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ContChiusura")) = False Then
            Me.ContChiusura = ds.Tables(tabella).Rows(0)("ContChiusura")
         Else
            Me.ContChiusura = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ContCorrispettivi")) = False Then
            Me.ContCorrispettivi = ds.Tables(tabella).Rows(0)("ContCorrispettivi")
         Else
            Me.ContCorrispettivi = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ContDoc")) = False Then
            Me.ContDoc = ds.Tables(tabella).Rows(0)("ContDoc")
         Else
            Me.ContDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ContPrimaNota")) = False Then
            Me.ContPrimaNota = ds.Tables(tabella).Rows(0)("ContPrimaNota")
         Else
            Me.ContPrimaNota = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestAcquisti")) = False Then
            Me.GestAcquisti = ds.Tables(tabella).Rows(0)("GestAcquisti")
         Else
            Me.GestAcquisti = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestGruppi")) = False Then
            Me.GestGruppi = ds.Tables(tabella).Rows(0)("GestGruppi")
         Else
            Me.GestGruppi = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestOperatori")) = False Then
            Me.GestOperatori = ds.Tables(tabella).Rows(0)("GestOperatori")
         Else
            Me.GestOperatori = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestPrenSale")) = False Then
            Me.GestPrenSale = ds.Tables(tabella).Rows(0)("GestPrenSale")
         Else
            Me.GestPrenSale = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestPrenTavoli")) = False Then
            Me.GestPrenTavoli = ds.Tables(tabella).Rows(0)("GestPrenTavoli")
         Else
            Me.GestPrenTavoli = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestPrenRisorse")) = False Then
            Me.GestPrenRisorse = ds.Tables(tabella).Rows(0)("GestPrenRisorse")
         Else
            Me.GestPrenRisorse = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestPlanningRisorse")) = False Then
            Me.GestPlanningRisorse = ds.Tables(tabella).Rows(0)("GestPlanningRisorse")
         Else
            Me.GestPlanningRisorse = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestStatRisorse")) = False Then
            Me.GestStatRisorse = ds.Tables(tabella).Rows(0)("GestStatRisorse")
         Else
            Me.GestStatRisorse = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestPuntoCassa")) = False Then
            Me.GestPuntoCassa = ds.Tables(tabella).Rows(0)("GestPuntoCassa")
         Else
            Me.GestPuntoCassa = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestStatistiche")) = False Then
            Me.GestStatistiche = ds.Tables(tabella).Rows(0)("GestStatistiche")
         Else
            Me.GestStatistiche = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("GestTavoli")) = False Then
            Me.GestTavoli = ds.Tables(tabella).Rows(0)("GestTavoli")
         Else
            Me.GestTavoli = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("MagArticoli")) = False Then
            Me.MagArticoli = ds.Tables(tabella).Rows(0)("MagArticoli")
         Else
            Me.MagArticoli = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("MagInventario")) = False Then
            Me.MagInventario = ds.Tables(tabella).Rows(0)("MagInventario")
         Else
            Me.MagInventario = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("MagMov")) = False Then
            Me.MagMov = ds.Tables(tabella).Rows(0)("MagMov")
         Else
            Me.MagMov = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("MagScorte")) = False Then
            Me.MagScorte = ds.Tables(tabella).Rows(0)("MagScorte")
         Else
            Me.MagScorte = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("StruCap")) = False Then
            Me.StruCap = ds.Tables(tabella).Rows(0)("StruCap")
         Else
            Me.StruCap = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("StruCodiciBarre")) = False Then
            Me.StruCodiciBarre = ds.Tables(tabella).Rows(0)("StruCodiciBarre")
         Else
            Me.StruCodiciBarre = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("StruDispTavoli")) = False Then
            Me.StruDispTavoli = ds.Tables(tabella).Rows(0)("StruDispTavoli")
         Else
            Me.StruDispTavoli = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("StruMsg")) = False Then
            Me.StruMsg = ds.Tables(tabella).Rows(0)("StruMsg")
         Else
            Me.StruMsg = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("StruMenù")) = False Then
            Me.StruMenù = ds.Tables(tabella).Rows(0)("StruMenù")
         Else
            Me.StruMenù = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("VisOpzioni")) = False Then
            Me.VisOpzioni = ds.Tables(tabella).Rows(0)("VisOpzioni")
         Else
            Me.VisOpzioni = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("VisErrori")) = False Then
            Me.VisErrori = ds.Tables(tabella).Rows(0)("VisErrori")
         Else
            Me.VisErrori = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("VisOperazioni")) = False Then
            Me.VisOperazioni = ds.Tables(tabella).Rows(0)("VisOperazioni")
         Else
            Me.VisOperazioni = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note")
         Else
            Me.Note = String.Empty
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
         sql = String.Format("INSERT INTO {0} (NomeGruppo, Amministratore, AnagAziende, AnagCamerieri, AnagCatPiatti, AnagClienti, AnagDatiAzienda, MagMov, " & _
                                              "AnagFornitori, AnagPiatti, AnagSale, AnagTavoli, AnagRisorse, AnagAccessoriServizi, ArchiviBackup, ArchiviCompatta, ArchiviPulizia, StruDispTavoli, " & _
                                              "TabAttività, TabCatClienti, TabCatMerce, TabFormeCortesia, TabMagazzini, TabMsg, TabNazioni, TabPagamenti, StruMsg, " & _
                                              "TabPiani, TabReparti, TabScaffali, TabTipoDoc, TabUbicazioni, TabUM, TabTipoRisorse, ContChiusura, ContCorrispettivi, StruCodiciBarre, " & _
                                              "ContDoc, ContPrimaNota, GestAcquisti, StruMenù, GestGruppi, GestOperatori, GestPrenSale, GestPrenTavoli, " & _
                                              "GestPrenRisorse, GestPlanningRisorse, GestStatRisorse, GestPuntoCassa, GestStatistiche, GestTavoli, MagArticoli, MagInventario, MagScorte, " & _
                                              "StruCap, VisOpzioni, VisErrori, VisOperazioni, " & _
                                              "[Note]) " & _
                                       "VALUES(@NomeGruppo,@Amministratore, @AnagAziende, @AnagCamerieri, @AnagCatPiatti, @AnagClienti, @AnagDatiAzienda, @MagMov, " & _
                                              "@AnagFornitori, @AnagPiatti, @AnagSale, @AnagTavoli, @AnagRisorse, @AnagAccessoriServizi, @ArchiviBackup, @ArchiviCompatta, @ArchiviPulizia, @StruDispTavoli, " & _
                                              "@TabAttività, @TabCatClienti, @TabCatMerce, @TabFormeCortesia, @TabMagazzini, @TabMsg, @TabNazioni, @TabPagamenti, @StruMsg, " & _
                                              "@TabPiani, @TabReparti, @TabScaffali, @TabTipoDoc, @TabUbicazioni, @TabUM, @TabTipoRisorse, @ContChiusura, @ContCorrispettivi, @StruCodiciBarre, " & _
                                              "@ContDoc, @ContPrimaNota, @GestAcquisti, @StruMenù, @GestGruppi, @GestOperatori, @GestPrenSale, @GestPrenTavoli, " & _
                                              "@GestPrenRisorse, @GestPlanningRisorse, @GestStatRisorse, @GestPuntoCassa, @GestStatistiche, @GestTavoli, @MagArticoli, @MagInventario, @MagScorte, " & _
                                              "@StruCap, @VisOpzioni, @VisErrori, @VisOperazioni, " & _
                                              "@Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@NomeGruppo", Me.NomeGruppo)
         cmdInsert.Parameters.Add("@Amministratore", Me.Amministratore)
         cmdInsert.Parameters.Add("@AnagAziende", Me.AnagAziende)
         cmdInsert.Parameters.Add("@AnagCamerieri", Me.AnagCamerieri)
         cmdInsert.Parameters.Add("@AnagCatPiatti", Me.AnagCatPiatti)
         cmdInsert.Parameters.Add("@AnagClienti", Me.AnagClienti)
         cmdInsert.Parameters.Add("@AnagDatiAzienda", Me.AnagDatiAzienda)
         cmdInsert.Parameters.Add("@MagMov", Me.MagMov) ' Cambiato posizione per possibile Bug.
         cmdInsert.Parameters.Add("@AnagFornitori", Me.AnagFornitori)
         cmdInsert.Parameters.Add("@AnagPiatti", Me.AnagPiatti)
         cmdInsert.Parameters.Add("@AnagSale", Me.AnagSale)
         cmdInsert.Parameters.Add("@AnagTavoli", Me.AnagTavoli)
         cmdInsert.Parameters.Add("@AnagRisorse", Me.AnagRisorse)
         cmdInsert.Parameters.Add("@AnagAccessoriServizi", Me.AnagAccessoriServizi)
         cmdInsert.Parameters.Add("@ArchiviBackup", Me.ArchiviBackup)
         cmdInsert.Parameters.Add("@ArchiviCompatta", Me.ArchiviCompatta)
         cmdInsert.Parameters.Add("@ArchiviPulizia", Me.ArchiviPulizia)
         cmdInsert.Parameters.Add("@StruDispTavoli", Me.StruDispTavoli) ' Cambiato posizione per possibile Bug.
         cmdInsert.Parameters.Add("@TabAttività", Me.TabAttività)
         cmdInsert.Parameters.Add("@TabCatClienti", Me.TabCatClienti)
         cmdInsert.Parameters.Add("@TabCatMerce", Me.TabCatMerce)
         cmdInsert.Parameters.Add("@TabFormeCortesia", Me.TabFormeCortesia)
         cmdInsert.Parameters.Add("@TabMagazzini", Me.TabMagazzini)
         cmdInsert.Parameters.Add("@TabMsg", Me.TabMsg)
         cmdInsert.Parameters.Add("@TabNazioni", Me.TabNazioni)
         cmdInsert.Parameters.Add("@TabPagamenti", Me.TabPagamenti)
         cmdInsert.Parameters.Add("@StruMsg", Me.StruMsg) ' Cambiato posizione per possibile Bug.
         cmdInsert.Parameters.Add("@TabPiani", Me.TabPiani)
         cmdInsert.Parameters.Add("@TabReparti", Me.TabReparti)
         cmdInsert.Parameters.Add("@TabScaffali", Me.TabScaffali)
         cmdInsert.Parameters.Add("@TabTipoDoc", Me.TabTipoDoc)
         cmdInsert.Parameters.Add("@TabUbicazioni", Me.TabUbicazioni)
         cmdInsert.Parameters.Add("@TabUM", Me.TabUM)
         cmdInsert.Parameters.Add("@TabTipoRisorse", Me.TabTipoRisorse)
         cmdInsert.Parameters.Add("@ContChiusura", Me.ContChiusura)
         cmdInsert.Parameters.Add("@ContCorrispettivi", Me.ContCorrispettivi)
         cmdInsert.Parameters.Add("@StruCodiciBarre", Me.StruCodiciBarre) ' Cambiato posizione per possibile Bug.
         cmdInsert.Parameters.Add("@ContDoc", Me.ContDoc)
         cmdInsert.Parameters.Add("@ContPrimaNota", Me.ContPrimaNota)
         cmdInsert.Parameters.Add("@GestAcquisti", Me.GestAcquisti)
         cmdInsert.Parameters.Add("@GestGruppi", Me.GestGruppi)
         cmdInsert.Parameters.Add("@StruMenù", Me.StruMenù)
         cmdInsert.Parameters.Add("@GestOperatori", Me.GestOperatori)
         cmdInsert.Parameters.Add("@GestPrenSale", Me.GestPrenSale)
         cmdInsert.Parameters.Add("@GestPrenTavoli", Me.GestPrenTavoli)
         cmdInsert.Parameters.Add("@GestPrenRisorse", Me.GestPrenSale)
         cmdInsert.Parameters.Add("@GestPlanningRisorse", Me.GestPrenTavoli)
         cmdInsert.Parameters.Add("@GestStatRisorse", Me.GestStatRisorse)
         cmdInsert.Parameters.Add("@GestPuntoCassa", Me.GestPuntoCassa)
         cmdInsert.Parameters.Add("@GestStatistiche", Me.GestStatistiche)
         cmdInsert.Parameters.Add("@GestTavoli", Me.GestTavoli)
         cmdInsert.Parameters.Add("@MagArticoli", Me.MagArticoli)
         cmdInsert.Parameters.Add("@MagInventario", Me.MagInventario)
         cmdInsert.Parameters.Add("@MagScorte", Me.MagScorte)
         cmdInsert.Parameters.Add("@StruCap", Me.StruCap)
         cmdInsert.Parameters.Add("@VisOpzioni", Me.VisOpzioni)
         cmdInsert.Parameters.Add("@VisErrori", Me.VisErrori)
         cmdInsert.Parameters.Add("@VisOperazioni", Me.VisOperazioni)
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
                             "SET NomeGruppo = @NomeGruppo, " & _
                             "Amministratore = @Amministratore, " & _
                             "AnagAziende = @AnagAziende, " & _
                             "AnagCamerieri = @AnagCamerieri, " & _
                             "AnagCatPiatti = @AnagCatPiatti, " & _
                             "AnagClienti = @AnagClienti, " & _
                             "AnagDatiAzienda = @AnagDatiAzienda, " & _
                             "MagMov = @MagMov, " & _
                             "AnagFornitori = @AnagFornitori, " & _
                             "AnagPiatti = @AnagPiatti, " & _
                             "AnagSale = @AnagSale, " & _
                             "AnagTavoli = @AnagTavoli, " & _
                             "AnagRisorse = @AnagRisorse, " & _
                             "AnagAccessoriServizi = @AnagAccessoriServizi, " & _
                             "ArchiviBackup = @ArchiviBackup, " & _
                             "ArchiviCompatta = @ArchiviCompatta, " & _
                             "ArchiviPulizia = @ArchiviPulizia, " & _
                             "StruDispTavoli = @StruDispTavoli, " & _
                             "TabAttività = @TabAttività, " & _
                             "TabCatClienti = @TabCatClienti, " & _
                             "TabCatMerce = @TabCatMerce, " & _
                             "TabFormeCortesia = @TabFormeCortesia, " & _
                             "TabMagazzini = @TabMagazzini, " & _
                             "TabMsg = @TabMsg, " & _
                             "TabNazioni = @TabNazioni, " & _
                             "TabPagamenti = @TabPagamenti, " & _
                             "StruMsg = @StruMsg, " & _
                             "TabPiani = @TabPiani, " & _
                             "TabReparti = @TabReparti, " & _
                             "TabScaffali = @TabScaffali, " & _
                             "TabTipoDoc = @TabTipoDoc, " & _
                             "TabUbicazioni = @TabUbicazioni, " & _
                             "TabUM = @TabUM, " & _
                             "TabTipoRisorse = @TabTipoRisorse, " & _
                             "ContChiusura = @ContChiusura, " & _
                             "ContCorrispettivi = @ContCorrispettivi, " & _
                             "StruCodiciBarre = @StruCodiciBarre, " & _
                             "ContDoc = @ContDoc, " & _
                             "ContPrimaNota = @ContPrimaNota, " & _
                             "GestAcquisti = @GestAcquisti, " & _
                             "StruMenù = @StruMenù, " & _
                             "GestGruppi = @GestGruppi, " & _
                             "GestOperatori = @GestOperatori, " & _
                             "GestPrenSale = @GestPrenSale, " & _
                             "GestPrenTavoli = @GestPrenTavoli, " & _
                             "GestPrenRisorse = @GestPrenRisorse, " & _
                             "GestPlanningRisorse = @GestPlanningRisorse, " & _
                             "GestStatRisorse = @GestStatRisorse, " & _
                             "GestPuntoCassa = @GestPuntoCassa, " & _
                             "GestStatistiche = @GestStatistiche, " & _
                             "GestTavoli = @GestTavoli, " & _
                             "MagArticoli = @MagArticoli, " & _
                             "MagInventario = @MagInventario, " & _
                             "MagScorte = @MagScorte, " & _
                             "StruCap = @StruCap, " & _
                             "VisOpzioni = @VisOpzioni, " & _
                             "VisErrori = @VisErrori, " & _
                             "VisOperazioni = @VisOperazioni, " & _
                             "[Note] = @Note " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@NomeGruppo", Me.NomeGruppo)
         cmdUpdate.Parameters.Add("@Amministratore", Me.Amministratore)
         cmdUpdate.Parameters.Add("@AnagAziende", Me.AnagAziende)
         cmdUpdate.Parameters.Add("@AnagCamerieri", Me.AnagCamerieri)
         cmdUpdate.Parameters.Add("@AnagCatPiatti", Me.AnagCatPiatti)
         cmdUpdate.Parameters.Add("@AnagClienti", Me.AnagClienti)
         cmdUpdate.Parameters.Add("@AnagDatiAzienda", Me.AnagDatiAzienda)
         cmdUpdate.Parameters.Add("@MagMov", Me.MagMov) ' Cambiato posizione per possibile Bug.
         cmdUpdate.Parameters.Add("@AnagFornitori", Me.AnagFornitori)
         cmdUpdate.Parameters.Add("@AnagPiatti", Me.AnagPiatti)
         cmdUpdate.Parameters.Add("@AnagSale", Me.AnagSale)
         cmdUpdate.Parameters.Add("@AnagTavoli", Me.AnagTavoli)
         cmdUpdate.Parameters.Add("@AnagRisorse", Me.AnagRisorse)
         cmdUpdate.Parameters.Add("@AnagAccessoriServizi", Me.AnagAccessoriServizi)
         cmdUpdate.Parameters.Add("@ArchiviBackup", Me.ArchiviBackup)
         cmdUpdate.Parameters.Add("@ArchiviCompatta", Me.ArchiviCompatta)
         cmdUpdate.Parameters.Add("@ArchiviPulizia", Me.ArchiviPulizia)
         cmdUpdate.Parameters.Add("@StruDispTavoli", Me.StruDispTavoli) ' Cambiato posizione per possibile Bug.
         cmdUpdate.Parameters.Add("@TabAttività", Me.TabAttività)
         cmdUpdate.Parameters.Add("@TabCatClienti", Me.TabCatClienti)
         cmdUpdate.Parameters.Add("@TabCatMerce", Me.TabCatMerce)
         cmdUpdate.Parameters.Add("@TabFormeCortesia", Me.TabFormeCortesia)
         cmdUpdate.Parameters.Add("@TabMagazzini", Me.TabMagazzini)
         cmdUpdate.Parameters.Add("@TabMsg", Me.TabMsg)
         cmdUpdate.Parameters.Add("@TabNazioni", Me.TabNazioni)
         cmdUpdate.Parameters.Add("@TabPagamenti", Me.TabPagamenti)
         cmdUpdate.Parameters.Add("@StruMsg", Me.StruMsg) ' Cambiato posizione per possibile Bug.
         cmdUpdate.Parameters.Add("@TabPiani", Me.TabPiani)
         cmdUpdate.Parameters.Add("@TabReparti", Me.TabReparti)
         cmdUpdate.Parameters.Add("@TabScaffali", Me.TabScaffali)
         cmdUpdate.Parameters.Add("@TabTipoDoc", Me.TabTipoDoc)
         cmdUpdate.Parameters.Add("@TabUbicazioni", Me.TabUbicazioni)
         cmdUpdate.Parameters.Add("@TabUM", Me.TabUM)
         cmdUpdate.Parameters.Add("@TabTipoRisorse", Me.TabTipoRisorse)
         cmdUpdate.Parameters.Add("@ContChiusura", Me.ContChiusura)
         cmdUpdate.Parameters.Add("@ContCorrispettivi", Me.ContCorrispettivi)
         cmdUpdate.Parameters.Add("@StruCodiciBarre", Me.StruCodiciBarre) ' Cambiato posizione per possibile Bug.
         cmdUpdate.Parameters.Add("@ContDoc", Me.ContDoc)
         cmdUpdate.Parameters.Add("@ContPrimaNota", Me.ContPrimaNota)
         cmdUpdate.Parameters.Add("@GestAcquisti", Me.GestAcquisti)
         cmdUpdate.Parameters.Add("@GestGruppi", Me.GestGruppi)
         cmdUpdate.Parameters.Add("@StruMenù", Me.StruMenù)
         cmdUpdate.Parameters.Add("@GestOperatori", Me.GestOperatori)
         cmdUpdate.Parameters.Add("@GestPrenSale", Me.GestPrenSale)
         cmdUpdate.Parameters.Add("@GestPrenTavoli", Me.GestPrenTavoli)
         cmdUpdate.Parameters.Add("@GestPrenRisorse", Me.GestPrenRisorse)
         cmdUpdate.Parameters.Add("@GestPlanningRisorse", Me.GestPlanningRisorse)
         cmdUpdate.Parameters.Add("@GestStatRisorse", Me.GestStatRisorse)
         cmdUpdate.Parameters.Add("@GestPuntoCassa", Me.GestPuntoCassa)
         cmdUpdate.Parameters.Add("@GestStatistiche", Me.GestStatistiche)
         cmdUpdate.Parameters.Add("@GestTavoli", Me.GestTavoli)
         cmdUpdate.Parameters.Add("@MagArticoli", Me.MagArticoli)
         cmdUpdate.Parameters.Add("@MagInventario", Me.MagInventario)
         cmdUpdate.Parameters.Add("@MagScorte", Me.MagScorte)
         cmdUpdate.Parameters.Add("@StruCap", Me.StruCap)
         cmdUpdate.Parameters.Add("@VisOpzioni", Me.VisOpzioni)
         cmdUpdate.Parameters.Add("@VisErrori", Me.VisErrori)
         cmdUpdate.Parameters.Add("@VisOperazioni", Me.VisOperazioni)
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
End Class
