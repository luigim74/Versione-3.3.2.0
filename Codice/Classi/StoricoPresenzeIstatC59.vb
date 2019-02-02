#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       15/09/2018
' Data ultima modifica: 15/09/2018
' Descrizione:          Classe Storico delle presenze per la creazione del Modello Istat C/59.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Imports System.Data.OleDb

Public Class StoricoPresenzeIstatC59
   Public Codice As Integer
   Public Numero As Integer
   Public Giorno As String
   Public Mese As String
   Public Anno As String
   Public Comune As String
   Public TipoEsercizio As String
   Public Denominazione As String
   Public NumeroStelle As String
   Public ClientiGiornoPrec As Integer
   Public ClientiArrivati As Integer
   Public ClientiPartiti As Integer
   Public TotaleClienti As Integer
   Public ClientiPresentiNotte As Integer

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
            Me.Codice = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Id"))
         Else
            Me.Codice = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Numero"))
         Else
            Me.Numero = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Giorno")) = False Then
            Me.Giorno = ds.Tables(tabella).Rows(0)("Giorno").ToString
         Else
            Me.Giorno = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Mese")) = False Then
            Me.Mese = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Mese"))
         Else
            Me.Mese = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Anno")) = False Then
            Me.Anno = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Anno"))
         Else
            Me.Anno = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Comune")) = False Then
            Me.Comune = ds.Tables(tabella).Rows(0)("Comune").ToString
         Else
            Me.Comune = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoEsercizio")) = False Then
            Me.TipoEsercizio = Convert.ToInt32(ds.Tables(tabella).Rows(0)("TipoEsercizio"))
         Else
            Me.TipoEsercizio = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Denominazione")) = False Then
            Me.Denominazione = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Denominazione"))
         Else
            Me.Denominazione = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroStelle")) = False Then
            Me.NumeroStelle = Convert.ToInt32(ds.Tables(tabella).Rows(0)("NumeroStelle"))
         Else
            Me.NumeroStelle = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ClientiGiornoPrec")) = False Then
            Me.ClientiGiornoPrec = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ClientiGiornoPrec"))
         Else
            Me.ClientiGiornoPrec = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ClientiArrivati")) = False Then
            Me.ClientiArrivati = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ClientiArrivati"))
         Else
            Me.ClientiArrivati = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ClientiPartiti")) = False Then
            Me.ClientiPartiti = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ClientiPartiti"))
         Else
            Me.ClientiPartiti = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TotaleClienti")) = False Then
            Me.TotaleClienti = Convert.ToInt32(ds.Tables(tabella).Rows(0)("TotaleClienti"))
         Else
            Me.TotaleClienti = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ClientiPresentiNotte")) = False Then
            Me.ClientiPresentiNotte = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ClientiPresentiNotte"))
         Else
            Me.ClientiPresentiNotte = 0
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
         sql = String.Format("INSERT INTO {0} (Numero, Giorno, Mese, Anno, Comune, TipoEsercizio, Denominazione, NumeroStelle, ClientiGiornoPrec, ClientiArrivati, ClientiPartiti, TotaleClienti, ClientiPresentiNotte) " &
                                       "VALUES(@Numero, @Giorno, @Mese, @Anno, @Comune, @TipoEsercizio, @Denominazione, @NumeroStelle, @ClientiGiornoPrec, @ClientiArrivati, @ClientiPartiti, @TotaleClienti, @ClientiPresentiNotte)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdInsert.Parameters.AddWithValue("@Giorno", Me.Giorno)
         cmdInsert.Parameters.AddWithValue("@Mese", Me.Mese)
         cmdInsert.Parameters.AddWithValue("@Anno", Me.Anno)
         cmdInsert.Parameters.AddWithValue("@Comune", Me.Comune)
         cmdInsert.Parameters.AddWithValue("@TipoEsercizio", Me.TipoEsercizio)
         cmdInsert.Parameters.AddWithValue("@Denominazione", Me.Denominazione)
         cmdInsert.Parameters.AddWithValue("@NumeroStelle", Me.NumeroStelle)
         cmdInsert.Parameters.AddWithValue("@ClientiGiornoPrec", Me.ClientiGiornoPrec)
         cmdInsert.Parameters.AddWithValue("@ClientiArrivati", Me.ClientiArrivati)
         cmdInsert.Parameters.AddWithValue("@ClientiPartiti", Me.ClientiPartiti)
         cmdInsert.Parameters.AddWithValue("@TotaleClienti", Me.TotaleClienti)
         cmdInsert.Parameters.AddWithValue("@ClientiPresentiNotte", Me.ClientiPresentiNotte)

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
                             "SET Numero = @Numero, " &
                             "Giorno = @Giorno, " &
                             "Mese = @Mese, " &
                             "Anno = @Anno, " &
                             "Comune = @Comune, " &
                             "TipoEsercizio = @TipoEsercizio, " &
                             "Denominazione = @Denominazione, " &
                             "NumeroStelle = @NumeroStelle, " &
                             "ClientiGiornoPrec = @ClientiGiornoPrec, " &
                             "ClientiArrivati = @ClientiArrivati, " &
                             "ClientiPartiti = @ClientiPartiti, " &
                             "TotaleClienti = @TotaleClienti, " &
                             "ClientiPresentiNotte = @ClientiPresentiNotte " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdUpdate.Parameters.AddWithValue("@Giorno", Me.Giorno)
         cmdUpdate.Parameters.AddWithValue("@Mese", Me.Mese)
         cmdUpdate.Parameters.AddWithValue("@Anno", Me.Anno)
         cmdUpdate.Parameters.AddWithValue("@Comune", Me.Comune)
         cmdUpdate.Parameters.AddWithValue("@TipoEsercizio", Me.TipoEsercizio)
         cmdUpdate.Parameters.AddWithValue("@Denominazione", Me.Denominazione)
         cmdUpdate.Parameters.AddWithValue("@NumeroStelle", Me.NumeroStelle)
         cmdUpdate.Parameters.AddWithValue("@ClientiGiornoPrec", Me.ClientiGiornoPrec)
         cmdUpdate.Parameters.AddWithValue("@ClientiArrivati", Me.ClientiArrivati)
         cmdUpdate.Parameters.AddWithValue("@ClientiPartiti", Me.ClientiPartiti)
         cmdUpdate.Parameters.AddWithValue("@TotaleClienti", Me.TotaleClienti)
         cmdUpdate.Parameters.AddWithValue("@ClientiPresentiNotte", Me.ClientiPresentiNotte)

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

   Public Function EliminaDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0}", tabella)

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
