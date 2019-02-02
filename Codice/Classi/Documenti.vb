Imports System.Data.OleDb

Public Class Documenti

   Public Codice As String
   Public Numero As Integer
   Public Anno As String
   Public Data As Date
   Public Ora As String
   Public Tipo As String
   Public Stato As String
   Public Causale As String
   Public IdCliente As String
   Public Cliente As String
   Public Indirizzo As String
   Public Cap As String
   Public Città As String
   Public Provincia As String
   Public PIva As String
   Public CodFiscale As String
   Public CodAzienda As String
   Public ImpLordoRep1 As String
   Public ImpLordoRep2 As String
   Public ImpLordoRep3 As String
   Public ImpLordoRep4 As String
   Public AliquotaIvaRep1 As String
   Public AliquotaIvaRep2 As String
   Public AliquotaIvaRep3 As String
   Public AliquotaIvaRep4 As String
   Public ImpostaRep1 As String
   Public ImpostaRep2 As String
   Public ImpostaRep3 As String
   Public ImpostaRep4 As String
   Public Coperto As String
   Public Sconto As String
   Public TipoSconto As String
   Public Servizio As String
   Public TipoServizio As String
   Public Contanti As String
   Public Carte As String
   Public BuoniPasto As String
   Public BuoniPastoIncassare As String
   Public TotDoc As String
   Public TipoPagamento As String
   Public Sospeso As String
   Public SospesoIncassare As String
   Public Tavolo As String
   Public Cameriere As String
   Public Imponibile As String
   Public Iva As String
   Public Imposta As String
   Public Chiuso As String
   Public NumeroDoc_PA As String
   Public CodiceCUP_PA As String
   Public CodiceCIG_PA As String
   Public CodiceCommConv_PA As String
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
            Me.Codice = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumDoc")) = False Then
            Me.Numero = Convert.ToInt32(ds.Tables(tabella).Rows(0)("NumDoc"))
         Else
            Me.Numero = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AnnoDoc")) = False Then
            Me.Anno = ds.Tables(tabella).Rows(0)("AnnoDoc").ToString
         Else
            Me.Anno = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataDoc")) = False Then
            Me.Data = Convert.ToDateTime(ds.Tables(tabella).Rows(0)("DataDoc"))
         Else
            Me.Data = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraDoc")) = False Then
            Me.Ora = ds.Tables(tabella).Rows(0)("OraDoc").ToString
         Else
            Me.Ora = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoDoc")) = False Then
            Me.Tipo = ds.Tables(tabella).Rows(0)("TipoDoc").ToString
         Else
            Me.Tipo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("StatoDoc")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("StatoDoc").ToString
         Else
            Me.Stato = "Bozza"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CausaleDoc")) = False Then
            Me.Causale = ds.Tables(tabella).Rows(0)("CausaleDoc").ToString
         Else
            Me.Causale = "Vendita"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCliente")) = False Then
            Me.IdCliente = ds.Tables(tabella).Rows(0)("IdCliente").ToString
         Else
            Me.IdCliente = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cliente")) = False Then
            Me.Cliente = ds.Tables(tabella).Rows(0)("Cliente").ToString
         Else
            Me.Cliente = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo")) = False Then
            Me.Indirizzo = ds.Tables(tabella).Rows(0)("Indirizzo").ToString
         Else
            Me.Indirizzo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cap")) = False Then
            Me.Cap = ds.Tables(tabella).Rows(0)("Cap").ToString
         Else
            Me.Cap = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Città")) = False Then
            Me.Città = ds.Tables(tabella).Rows(0)("Città").ToString
         Else
            Me.Città = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Provincia")) = False Then
            Me.Provincia = ds.Tables(tabella).Rows(0)("Provincia").ToString
         Else
            Me.Provincia = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PIva")) = False Then
            Me.PIva = ds.Tables(tabella).Rows(0)("PIva").ToString
         Else
            Me.PIva = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodFiscale")) = False Then
            Me.CodFiscale = ds.Tables(tabella).Rows(0)("CodFiscale").ToString
         Else
            Me.CodFiscale = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpLordoRep1")) = False Then
            Me.ImpLordoRep1 = ds.Tables(tabella).Rows(0)("ImpLordoRep1").ToString
         Else
            Me.ImpLordoRep1 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpLordoRep2")) = False Then
            Me.ImpLordoRep2 = ds.Tables(tabella).Rows(0)("ImpLordoRep2").ToString
         Else
            Me.ImpLordoRep2 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpLordoRep3")) = False Then
            Me.ImpLordoRep3 = ds.Tables(tabella).Rows(0)("ImpLordoRep3").ToString
         Else
            Me.ImpLordoRep3 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpLordoRep4")) = False Then
            Me.ImpLordoRep4 = ds.Tables(tabella).Rows(0)("ImpLordoRep4").ToString
         Else
            Me.ImpLordoRep4 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AliquotaIvaRep1")) = False Then
            Me.AliquotaIvaRep1 = ds.Tables(tabella).Rows(0)("AliquotaIvaRep1").ToString
         Else
            Me.AliquotaIvaRep1 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AliquotaIvaRep2")) = False Then
            Me.AliquotaIvaRep2 = ds.Tables(tabella).Rows(0)("AliquotaIvaRep2").ToString
         Else
            Me.AliquotaIvaRep2 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AliquotaIvaRep3")) = False Then
            Me.AliquotaIvaRep3 = ds.Tables(tabella).Rows(0)("AliquotaIvaRep3").ToString
         Else
            Me.AliquotaIvaRep3 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AliquotaIvaRep4")) = False Then
            Me.AliquotaIvaRep4 = ds.Tables(tabella).Rows(0)("AliquotaIvaRep4").ToString
         Else
            Me.AliquotaIvaRep4 = VALORE_ZERO
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpostaRep1")) = False Then
            Me.ImpostaRep1 = ds.Tables(tabella).Rows(0)("ImpostaRep1").ToString
         Else
            Me.ImpostaRep1 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpostaRep2")) = False Then
            Me.ImpostaRep2 = ds.Tables(tabella).Rows(0)("ImpostaRep2").ToString
         Else
            Me.ImpostaRep2 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpostaRep3")) = False Then
            Me.ImpostaRep3 = ds.Tables(tabella).Rows(0)("ImpostaRep3").ToString
         Else
            Me.ImpostaRep3 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImpostaRep4")) = False Then
            Me.ImpostaRep4 = ds.Tables(tabella).Rows(0)("ImpostaRep4").ToString
         Else
            Me.ImpostaRep4 = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodAzienda")) = False Then
            Me.CodAzienda = ds.Tables(tabella).Rows(0)("CodAzienda").ToString
         Else
            Me.CodAzienda = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Coperto")) = False Then
            Me.Coperto = ds.Tables(tabella).Rows(0)("Coperto").ToString
         Else
            Me.Coperto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
            Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto").ToString
         Else
            Me.Sconto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoSconto")) = False Then
            Me.TipoSconto = ds.Tables(tabella).Rows(0)("TipoSconto").ToString
         Else
            Me.TipoSconto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Servizio")) = False Then
            Me.Servizio = ds.Tables(tabella).Rows(0)("Servizio").ToString
         Else
            Me.Servizio = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoServizio")) = False Then
            Me.TipoServizio = ds.Tables(tabella).Rows(0)("TipoServizio").ToString
         Else
            Me.TipoServizio = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Contanti")) = False Then
            Me.Contanti = ds.Tables(tabella).Rows(0)("Contanti").ToString
         Else
            Me.Contanti = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Carte")) = False Then
            Me.Carte = ds.Tables(tabella).Rows(0)("Carte").ToString
         Else
            Me.Carte = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("BuoniPasto")) = False Then
            Me.BuoniPasto = ds.Tables(tabella).Rows(0)("BuoniPasto").ToString
         Else
            Me.BuoniPasto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("BuoniPastoIncassare")) = False Then
            Me.BuoniPastoIncassare = ds.Tables(tabella).Rows(0)("BuoniPastoIncassare").ToString
         Else
            Me.BuoniPastoIncassare = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TotDoc")) = False Then
            Me.TotDoc = ds.Tables(tabella).Rows(0)("TotDoc").ToString
         Else
            Me.TotDoc = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoPagamento")) = False Then
            Me.TipoPagamento = ds.Tables(tabella).Rows(0)("TipoPagamento").ToString
         Else
            Me.TipoPagamento = String.Empty
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("Tavolo")) = False Then
            Me.Tavolo = ds.Tables(tabella).Rows(0)("Tavolo").ToString
         Else
            Me.Tavolo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sospeso")) = False Then
            Me.Sospeso = ds.Tables(tabella).Rows(0)("Sospeso").ToString
         Else
            Me.Sospeso = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("SospesoIncassare")) = False Then
            Me.SospesoIncassare = ds.Tables(tabella).Rows(0)("SospesoIncassare").ToString
         Else
            Me.SospesoIncassare = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cameriere")) = False Then
            Me.Cameriere = ds.Tables(tabella).Rows(0)("Cameriere").ToString
         Else
            Me.Cameriere = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Imponibile")) = False Then
            Me.Imponibile = ds.Tables(tabella).Rows(0)("Imponibile").ToString
         Else
            Me.Imponibile = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Iva")) = False Then
            Me.Iva = ds.Tables(tabella).Rows(0)("Iva").ToString
         Else
            Me.Iva = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Imposta")) = False Then
            Me.Imposta = ds.Tables(tabella).Rows(0)("Imposta").ToString
         Else
            Me.Imposta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Chiuso")) = False Then
            Me.Chiuso = ds.Tables(tabella).Rows(0)("Chiuso").ToString
         Else
            Me.Chiuso = "No"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroDoc_PA")) = False Then
            Me.NumeroDoc_PA = ds.Tables(tabella).Rows(0)("NumeroDoc_PA").ToString
         Else
            Me.NumeroDoc_PA = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodiceCUP_PA")) = False Then
            Me.CodiceCUP_PA = ds.Tables(tabella).Rows(0)("CodiceCUP_PA").ToString
         Else
            Me.CodiceCUP_PA = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodiceCIG_PA")) = False Then
            Me.CodiceCIG_PA = ds.Tables(tabella).Rows(0)("CodiceCIG_PA").ToString
         Else
            Me.CodiceCIG_PA = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodiceCommConv_PA")) = False Then
            Me.CodiceCommConv_PA = ds.Tables(tabella).Rows(0)("CodiceCommConv_PA").ToString
         Else
            Me.CodiceCommConv_PA = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
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
         sql = String.Format("INSERT INTO {0} (NumDoc, AnnoDoc, DataDoc, OraDoc, TipoDoc, StatoDoc, CausaleDoc, IdCliente, Cliente, Indirizzo, " &
                                              "Cap, Città, Provincia, Piva, CodFiscale, CodAzienda, Coperto, Sconto, TipoSconto, Servizio, TipoServizio, Contanti, Carte, BuoniPasto, BuoniPastoIncassare, " &
                                              "ImpLordoRep1, ImpLordoRep2, ImpLordoRep3, ImpLordoRep4, " &
                                              "AliquotaIvaRep1, AliquotaIvaRep2, AliquotaIvaRep3, AliquotaIvaRep4, ImpostaRep1, ImpostaRep2, ImpostaRep3, ImpostaRep4, " &
                                              "TipoPagamento, Tavolo, TotDoc, Sospeso, SospesoIncassare, Cameriere, Imponibile, Iva, Imposta, Chiuso, NumeroDoc_PA, CodiceCUP_PA, CodiceCIG_PA, CodiceCommConv_PA, [Note]) " &
                                       "VALUES(@Numero, @AnnoDoc, @Data, @Ora, @Tipo, @StatoDoc, @CausaleDoc, @IdCliente, @Cliente, @Indirizzo, " &
                                              "@Cap, @Città, @Provincia, @PIva, @CodFiscale, @CodAzienda, @Coperto, @Sconto, @TipoSconto, @Servizio, @TipoServizio, @Contanti, @Carte, @BuoniPasto, @BuoniPastoIncassare, " &
                                              "@ImpLordoRep1, @ImpLordoRep2, @ImpLordoRep3, @ImpLordoRep4, " &
                                              "@AliquotaIvaRep1, @AliquotaIvaRep2, @AliquotaIvaRep3, @AliquotaIvaRep4, @ImpostaRep1, @ImpostaRep2, @ImpostaRep3, @ImpostaRep4, " &
                                              "@TipoPagamento, @Tavolo, @TotDoc, @Sospeso, @SospesoIncassare, @Cameriere, @Imponibile, @Iva, @Imposta, @Chiuso, @NumeroDoc_PA, @CodiceCUP_PA, @CodiceCIG_PA, @CodiceCommConv_PA, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdInsert.Parameters.AddWithValue("@AnnoDoc", Me.Anno)
         cmdInsert.Parameters.AddWithValue("@Data", Me.Data)
         cmdInsert.Parameters.AddWithValue("@Ora", Me.Ora)
         cmdInsert.Parameters.AddWithValue("@Tipo", Me.Tipo)
         cmdInsert.Parameters.AddWithValue("@StatoDoc", Me.Stato)
         cmdInsert.Parameters.AddWithValue("@CausaleDoc", Me.Causale)
         cmdInsert.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdInsert.Parameters.AddWithValue("@Cliente", Me.Cliente)
         cmdInsert.Parameters.AddWithValue("@Indirizzo", Me.Indirizzo)
         cmdInsert.Parameters.AddWithValue("@Cap", Me.Cap)
         cmdInsert.Parameters.AddWithValue("@Città", Me.Città)
         cmdInsert.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdInsert.Parameters.AddWithValue("@PIva", Me.PIva)
         cmdInsert.Parameters.AddWithValue("@CodFiscale", Me.CodFiscale)
         cmdInsert.Parameters.AddWithValue("@CodAzienda", Me.CodAzienda)
         cmdInsert.Parameters.AddWithValue("@Coperto", Me.Coperto)
         cmdInsert.Parameters.AddWithValue("@Sconto", Me.Sconto)
         cmdInsert.Parameters.AddWithValue("@TipoSconto", Me.TipoSconto)
         cmdInsert.Parameters.AddWithValue("@Servizio", Me.Servizio)
         cmdInsert.Parameters.AddWithValue("@TipoServizio", Me.TipoServizio)
         cmdInsert.Parameters.AddWithValue("@Contanti", Me.Contanti)
         cmdInsert.Parameters.AddWithValue("@Carte", Me.Carte)
         cmdInsert.Parameters.AddWithValue("@BuoniPasto", Me.BuoniPasto)
         cmdInsert.Parameters.AddWithValue("@BuoniPastoIncassare", Me.BuoniPastoIncassare)
         cmdInsert.Parameters.AddWithValue("@ImpLordoRep1", Me.ImpLordoRep1)
         cmdInsert.Parameters.AddWithValue("@ImpLordoRep2", Me.ImpLordoRep2)
         cmdInsert.Parameters.AddWithValue("@ImpLordoRep3", Me.ImpLordoRep3)
         cmdInsert.Parameters.AddWithValue("@ImpLordoRep4", Me.ImpLordoRep4)
         cmdInsert.Parameters.AddWithValue("@AliquotaIvaRep1", Me.AliquotaIvaRep1)
         cmdInsert.Parameters.AddWithValue("@AliquotaIvaRep2", Me.AliquotaIvaRep2)
         cmdInsert.Parameters.AddWithValue("@AliquotaIvaRep3", Me.AliquotaIvaRep3)
         cmdInsert.Parameters.AddWithValue("@AliquotaIvaRep4", Me.AliquotaIvaRep4)
         cmdInsert.Parameters.AddWithValue("@ImpostaRep1", Me.ImpostaRep1)
         cmdInsert.Parameters.AddWithValue("@ImpostaRep2", Me.ImpostaRep2)
         cmdInsert.Parameters.AddWithValue("@ImpostaRep3", Me.ImpostaRep3)
         cmdInsert.Parameters.AddWithValue("@ImpostaRep4", Me.ImpostaRep4)
         cmdInsert.Parameters.AddWithValue("@TipoPagamento", Me.TipoPagamento)
         cmdInsert.Parameters.AddWithValue("@Tavolo", Me.Tavolo)
         cmdInsert.Parameters.AddWithValue("@TotDoc", Me.TotDoc)
         cmdInsert.Parameters.AddWithValue("@Sospeso", Me.Sospeso)
         cmdInsert.Parameters.AddWithValue("@SospesoIncassare", Me.SospesoIncassare)
         cmdInsert.Parameters.AddWithValue("@Cameriere", Me.Cameriere)
         cmdInsert.Parameters.AddWithValue("@Imponibile", Me.Imponibile)
         cmdInsert.Parameters.AddWithValue("@Iva", Me.Iva)
         cmdInsert.Parameters.AddWithValue("@Imposta", Me.Imposta)
         cmdInsert.Parameters.AddWithValue("@Chiuso", Me.Chiuso)
         cmdInsert.Parameters.AddWithValue("@NumeroDoc_PA", Me.NumeroDoc_PA)
         cmdInsert.Parameters.AddWithValue("@CodiceCUP_PA", Me.CodiceCUP_PA)
         cmdInsert.Parameters.AddWithValue("@CodiceCIG_PA", Me.CodiceCIG_PA)
         cmdInsert.Parameters.AddWithValue("@CodiceCommConv_PA", Me.CodiceCommConv_PA)
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

   Public Function EliminaDati(ByVal tabella As String, ByVal numDoc As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.

         sql = String.Format("DELETE FROM {0} WHERE NumDoc = {1}", tabella, numDoc)

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
                             "SET NumDoc = @Numero, " &
                             "AnnoDoc = @AnnoDoc, " &
                             "DataDoc = @Data, " &
                             "OraDoc = @Ora, " &
                             "TipoDoc = @Tipo, " &
                             "StatoDoc = @StatoDoc, " &
                             "CausaleDoc = @CausaleDoc, " &
                             "IdCliente = @IdCliente, " &
                             "Cliente = @Cliente, " &
                             "Indirizzo = @Indirizzo, " &
                             "Cap = @Cap, " &
                             "Città = @Città, " &
                             "Provincia = @Provincia, " &
                             "Piva = @PIva, " &
                             "CodFiscale = @CodFiscale, " &
                             "CodAzienda = @CodAzienda, " &
                             "ImpLordoRep1 = @ImpLordoRep1, " &
                             "ImpLordoRep2 = @ImpLordoRep2, " &
                             "ImpLordoRep3 = @ImpLordoRep3, " &
                             "ImpLordoRep4 = @ImpLordoRep4, " &
                             "AliquotaIvaRep1 = @AliquotaIvaRep1, " &
                             "AliquotaIvaRep2 = @AliquotaIvaRep2, " &
                             "AliquotaIvaRep3 = @AliquotaIvaRep3, " &
                             "AliquotaIvaRep4 = @AliquotaIvaRep4, " &
                             "ImpostaRep1 = @ImpostaRep1, " &
                             "ImpostaRep2 = @ImpostaRep2, " &
                             "ImpostaRep3 = @ImpostaRep3, " &
                             "ImpostaRep4 = @ImpostaRep4, " &
                             "Coperto = @Coperto, " &
                             "Sconto = @Sconto, " &
                             "TipoSconto = @TipoSconto, " &
                             "Servizio = @Servizio, " &
                             "TipoServizio = @TipoServizio, " &
                             "Contanti = @Contanti, " &
                             "Carte = @Carte, " &
                             "BuoniPasto = @BuoniPasto, " &
                             "BuoniPastoIncassare = @BuoniPastoIncassare, " &
                             "TipoPagamento = @TipoPagamento, " &
                             "Tavolo = @Tavolo, " &
                             "TotDoc = @TotDoc, " &
                             "Sospeso = @Sospeso, " &
                             "SospesoIncassare = @SospesoIncassare, " &
                             "Cameriere = @Cameriere, " &
                             "Imponibile = @Imponibile, " &
                             "Iva = @Iva, " &
                             "Imposta = @Imposta, " &
                             "Chiuso = @Chiuso, " &
                             "NumeroDoc_PA = @NumeroDoc_PA, " &
                             "CodiceCUP_PA = @CodiceCUP_PA, " &
                             "CodiceCIG_PA = @CodiceCIG_PA, " &
                             "CodiceCommConv_PA = @CodiceCommConv_PA, " &
                             "[Note] = @Note " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdUpdate.Parameters.AddWithValue("@AnnoDoc", Me.Anno)
         cmdUpdate.Parameters.AddWithValue("@Data", Me.Data)
         cmdUpdate.Parameters.AddWithValue("@Ora", Me.Ora)
         cmdUpdate.Parameters.AddWithValue("@Tipo", Me.Tipo)
         cmdUpdate.Parameters.AddWithValue("@StatoDoc", Me.Stato)
         cmdUpdate.Parameters.AddWithValue("@CausaleDoc", Me.Causale)
         cmdUpdate.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdUpdate.Parameters.AddWithValue("@Cliente", Me.Cliente)
         cmdUpdate.Parameters.AddWithValue("@Indirizzo", Me.Indirizzo)
         cmdUpdate.Parameters.AddWithValue("@Cap", Me.Cap)
         cmdUpdate.Parameters.AddWithValue("@Città", Me.Città)
         cmdUpdate.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdUpdate.Parameters.AddWithValue("@PIva", Me.PIva)
         cmdUpdate.Parameters.AddWithValue("@CodFiscale", Me.CodFiscale)
         cmdUpdate.Parameters.AddWithValue("@CodAzienda", Me.CodAzienda)
         cmdUpdate.Parameters.AddWithValue("@ImpLordoRep1", Me.ImpLordoRep1)
         cmdUpdate.Parameters.AddWithValue("@ImpLordoRep2", Me.ImpLordoRep2)
         cmdUpdate.Parameters.AddWithValue("@ImpLordoRep3", Me.ImpLordoRep3)
         cmdUpdate.Parameters.AddWithValue("@ImpLordoRep4", Me.ImpLordoRep4)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIvaRep1", Me.AliquotaIvaRep1)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIvaRep2", Me.AliquotaIvaRep2)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIvaRep3", Me.AliquotaIvaRep3)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIvaRep4", Me.AliquotaIvaRep4)
         cmdUpdate.Parameters.AddWithValue("@ImpostaRep1", Me.ImpostaRep1)
         cmdUpdate.Parameters.AddWithValue("@ImpostaRep2", Me.ImpostaRep2)
         cmdUpdate.Parameters.AddWithValue("@ImpostaRep3", Me.ImpostaRep3)
         cmdUpdate.Parameters.AddWithValue("@ImpostaRep4", Me.ImpostaRep4)
         cmdUpdate.Parameters.AddWithValue("@Coperto", Me.Coperto)
         cmdUpdate.Parameters.AddWithValue("@Sconto", Me.Sconto)
         cmdUpdate.Parameters.AddWithValue("@TipoSconto", Me.TipoSconto)
         cmdUpdate.Parameters.AddWithValue("@Servizio", Me.Servizio)
         cmdUpdate.Parameters.AddWithValue("@TipoServizio", Me.TipoServizio)
         cmdUpdate.Parameters.AddWithValue("@Contanti", Me.Contanti)
         cmdUpdate.Parameters.AddWithValue("@Carte", Me.Carte)
         cmdUpdate.Parameters.AddWithValue("@BuoniPasto", Me.BuoniPasto)
         cmdUpdate.Parameters.AddWithValue("@BuoniPastoIncassare", Me.BuoniPastoIncassare)
         cmdUpdate.Parameters.AddWithValue("@TipoPagamento", Me.TipoPagamento)
         cmdUpdate.Parameters.AddWithValue("@Tavolo", Me.Tavolo)
         cmdUpdate.Parameters.AddWithValue("@TotDoc", Me.TotDoc)
         cmdUpdate.Parameters.AddWithValue("@Sospeso", Me.Sospeso)
         cmdUpdate.Parameters.AddWithValue("@SospesoIncassare", Me.SospesoIncassare)
         cmdUpdate.Parameters.AddWithValue("@Cameriere", Me.Cameriere)
         cmdUpdate.Parameters.AddWithValue("@Imponibile", Me.Imponibile)
         cmdUpdate.Parameters.AddWithValue("@Iva", Me.Iva)
         cmdUpdate.Parameters.AddWithValue("@Imposta", Me.Imposta)
         cmdUpdate.Parameters.AddWithValue("@Chiuso", Me.Chiuso)
         cmdUpdate.Parameters.AddWithValue("@NumeroDoc_PA", Me.NumeroDoc_PA)
         cmdUpdate.Parameters.AddWithValue("@CodiceCUP_PA", Me.CodiceCUP_PA)
         cmdUpdate.Parameters.AddWithValue("@CodiceCIG_PA", Me.CodiceCIG_PA)
         cmdUpdate.Parameters.AddWithValue("@CodiceCommConv_PA", Me.CodiceCommConv_PA)
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
