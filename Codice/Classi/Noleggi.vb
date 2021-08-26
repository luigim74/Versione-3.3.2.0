#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            Noleggi
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/03/2021
' Data ultima modifica: 26/08/2021
' Descrizione:          Classe noleggi.
' Note:

' Elenco Attivita:

' ******************************************************************
#End Region

Imports System.Data.OleDb

Public Class Noleggi

   Public Codice As String
   Public IdCliente As String
   Public Cliente As String
   Public Indirizzo As String
   Public Cap As String
   Public Città As String
   Public Provincia As String
   Public PIva As String
   Public CodFiscale As String
   Public CodAzienda As String
   Public IdCausale As String
   Public Causale As String
   Public TipoPeriodo As String
   Public Periodo As String
   Public DataInizio As Date
   Public DataFine As Date
   Public TotaleGiorni As String
   Public CostoGiorno As Double
   Public CostoMora As Double
   Public CostoAssicurazione As Double
   Public Sconto As Double
   Public TipoSconto As String
   Public Totale As Double
   Public TotaleMora As Double
   Public Stato As String
   Public Chiuso As String
   Public CodiceBarre As String
   Public Colore As Integer
   Public Note As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction


   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="tabella"></param>
   ''' <param name="codice"></param>
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodAzienda")) = False Then
            Me.CodAzienda = ds.Tables(tabella).Rows(0)("CodAzienda").ToString
         Else
            Me.CodAzienda = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCausale")) = False Then
            Me.IdCausale = ds.Tables(tabella).Rows(0)("IdCausale").ToString
         Else
            Me.IdCausale = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Causale")) = False Then
            Me.Causale = ds.Tables(tabella).Rows(0)("Causale").ToString
         Else
            Me.Causale = VALORE_NESSUNO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoPeriodo")) = False Then
            Me.TipoPeriodo = ds.Tables(tabella).Rows(0)("TipoPeriodo").ToString
         Else
            Me.TipoPeriodo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Periodo")) = False Then
            Me.Periodo = ds.Tables(tabella).Rows(0)("Periodo").ToString
         Else
            Me.Periodo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio")) = False Then
            Me.DataInizio = Convert.ToDateTime(ds.Tables(tabella).Rows(0)("DataInizio"))
         Else
            Me.DataInizio = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine")) = False Then
            Me.DataFine = Convert.ToDateTime(ds.Tables(tabella).Rows(0)("DataFine"))
         Else
            Me.DataFine = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TotaleGiorni")) = False Then
            Me.TotaleGiorni = ds.Tables(tabella).Rows(0)("TotaleGiorni").ToString
         Else
            Me.TotaleGiorni = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoGiorno")) = False Then
            Me.CostoGiorno = ds.Tables(tabella).Rows(0)("CostoGiorno")
         Else
            Me.CostoGiorno = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoMora")) = False Then
            Me.CostoMora = ds.Tables(tabella).Rows(0)("CostoMora")
         Else
            Me.CostoMora = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoAssicurazione")) = False Then
            Me.CostoAssicurazione = ds.Tables(tabella).Rows(0)("CostoAssicurazione")
         Else
            Me.CostoAssicurazione = 0.0
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
            Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto")
         Else
            Me.Sconto = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoSconto")) = False Then
            Me.TipoSconto = ds.Tables(tabella).Rows(0)("TipoSconto").ToString
         Else
            Me.TipoSconto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Totale")) = False Then
            Me.Totale = ds.Tables(tabella).Rows(0)("Totale").ToString
         Else
            Me.Totale = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TotaleMora")) = False Then
            Me.TotaleMora = ds.Tables(tabella).Rows(0)("TotaleMora").ToString
         Else
            Me.TotaleMora = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato").ToString
         Else
            Me.Stato = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Chiuso")) = False Then
            Me.Chiuso = ds.Tables(tabella).Rows(0)("Chiuso").ToString
         Else
            Me.Chiuso = "No"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodiceBarre")) = False Then
            Me.CodiceBarre = ds.Tables(tabella).Rows(0)("CodiceBarre").ToString
         Else
            Me.CodiceBarre = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = 0
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
         sql = String.Format("INSERT INTO {0} (IdCliente, Cliente, Indirizzo, Cap, Città, Provincia, Piva, CodFiscale, CodAzienda, IdCausale, Causale, TipoPeriodo, Periodo, DataInizio, DataFine, TotaleGiorni, " &
                                              "CostoGiorno, CostoMora, CostoAssicurazione, Sconto, TipoSconto, Totale, TotaleMora, Stato, Chiuso, CodiceBarre, Colore, [Note]) " &
                                       "VALUES(@IdCliente, @Cliente, @Indirizzo, @Cap, @Città, @Provincia, @Piva, @CodFiscale, @CodAzienda, @IdCausale, @Causale, @TipoPeriodo, @Periodo, @DataInizio, @DataFine, @TotaleGiorni, " &
                                              "@CostoGiorno, @CostoMora, @CostoAssicurazione, @Sconto, @TipoSconto, @Totale, @TotaleMora, @Stato, @Chiuso, @CodiceBarre, @Colore, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdInsert.Parameters.AddWithValue("@Cliente", Me.Cliente)
         cmdInsert.Parameters.AddWithValue("@Indirizzo", Me.Indirizzo)
         cmdInsert.Parameters.AddWithValue("@Cap", Me.Cap)
         cmdInsert.Parameters.AddWithValue("@Città", Me.Città)
         cmdInsert.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdInsert.Parameters.AddWithValue("@PIva", Me.PIva)
         cmdInsert.Parameters.AddWithValue("@CodFiscale", Me.CodFiscale)
         cmdInsert.Parameters.AddWithValue("@CodAzienda", Me.CodAzienda)
         cmdInsert.Parameters.AddWithValue("@IdCausale", Me.IdCausale)
         cmdInsert.Parameters.AddWithValue("@Causale", Me.Causale)
         cmdInsert.Parameters.AddWithValue("@TipoPeriodo", Me.TipoPeriodo)
         cmdInsert.Parameters.AddWithValue("@Periodo", Me.Periodo)
         cmdInsert.Parameters.AddWithValue("@DataInizio", Me.DataInizio)
         cmdInsert.Parameters.AddWithValue("@DataFine", Me.DataFine)
         cmdInsert.Parameters.AddWithValue("@TotaleGiorni", Me.TotaleGiorni)
         cmdInsert.Parameters.AddWithValue("@CostoGiorno", Me.CostoGiorno)
         cmdInsert.Parameters.AddWithValue("@CostoMora", Me.CostoMora)
         cmdInsert.Parameters.AddWithValue("@CostoAssicurazione", Me.CostoAssicurazione)
         cmdInsert.Parameters.AddWithValue("@Sconto", Me.Sconto)
         cmdInsert.Parameters.AddWithValue("@TipoSconto", Me.TipoSconto)
         cmdInsert.Parameters.AddWithValue("@Totale", Me.Totale)
         cmdInsert.Parameters.AddWithValue("@TotaleMora", Me.TotaleMora)
         cmdInsert.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdInsert.Parameters.AddWithValue("@Chiuso", Me.Chiuso)
         cmdInsert.Parameters.AddWithValue("@CodiceBarre", Me.CodiceBarre)
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
         sql = String.Format("UPDATE {0} " &
                             "SET IdCliente = @IdCliente, " &
                             "Cliente = @Cliente, " &
                             "Indirizzo = @Indirizzo, " &
                             "Cap = @Cap, " &
                             "Città = @Città, " &
                             "Provincia = @Provincia, " &
                             "Piva = @PIva, " &
                             "CodFiscale = @CodFiscale, " &
                             "CodAzienda = @CodAzienda, " &
                             "IdCausale = @IdCausale, " &
                             "Causale = @Causale, " &
                             "TipoPeriodo = @TipoPeriodo, " &
                             "Periodo = @Periodo, " &
                             "DataInizio = @DataInizio, " &
                             "DataFine = @DataFine, " &
                             "TotaleGiorni = @TotaleGiorni, " &
                             "CostoGiorno = @CostoGiorno, " &
                             "CostoMora = @CostoMora, " &
                             "CostoAssicurazione = @CostoAssicurazione, " &
                             "Sconto = @Sconto, " &
                             "TipoSconto = @TipoSconto, " &
                             "Totale = @Totale, " &
                             "TotaleMora = @TotaleMora, " &
                             "Stato = @Stato, " &
                             "Chiuso = @Chiuso, " &
                             "CodiceBarre = @CodiceBarre, " &
                             "Colore = @Colore, " &
                             "[Note] = @Note " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdUpdate.Parameters.AddWithValue("@Cliente", Me.Cliente)
         cmdUpdate.Parameters.AddWithValue("@Indirizzo", Me.Indirizzo)
         cmdUpdate.Parameters.AddWithValue("@Cap", Me.Cap)
         cmdUpdate.Parameters.AddWithValue("@Città", Me.Città)
         cmdUpdate.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdUpdate.Parameters.AddWithValue("@PIva", Me.PIva)
         cmdUpdate.Parameters.AddWithValue("@CodFiscale", Me.CodFiscale)
         cmdUpdate.Parameters.AddWithValue("@CodAzienda", Me.CodAzienda)
         cmdUpdate.Parameters.AddWithValue("@IdCausale", Me.IdCausale)
         cmdUpdate.Parameters.AddWithValue("@Causale", Me.Causale)
         cmdUpdate.Parameters.AddWithValue("@TipoPeriodo", Me.TipoPeriodo)
         cmdUpdate.Parameters.AddWithValue("@Periodo", Me.Periodo)
         cmdUpdate.Parameters.AddWithValue("@DataInizio", Me.DataInizio)
         cmdUpdate.Parameters.AddWithValue("@DataFine", Me.DataFine)
         cmdUpdate.Parameters.AddWithValue("@TotaleGiorni", Me.TotaleGiorni)
         cmdUpdate.Parameters.AddWithValue("@CostoGiorno", Me.CostoGiorno)
         cmdUpdate.Parameters.AddWithValue("@CostoMora", Me.CostoMora)
         cmdUpdate.Parameters.AddWithValue("@CostoAssicurazione", Me.CostoAssicurazione)
         cmdUpdate.Parameters.AddWithValue("@Sconto", Me.Sconto)
         cmdUpdate.Parameters.AddWithValue("@TipoSconto", Me.TipoSconto)
         cmdUpdate.Parameters.AddWithValue("@Totale", Me.Totale)
         cmdUpdate.Parameters.AddWithValue("@TotaleMora", Me.TotaleMora)
         cmdUpdate.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdUpdate.Parameters.AddWithValue("@Chiuso", Me.Chiuso)
         cmdUpdate.Parameters.AddWithValue("@CodiceBarre", Me.CodiceBarre)
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

   Public Function EliminaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.

         sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, codice)

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

End Class
