Imports System.Data.OleDb

Public Class StatGioco

   Public IdCliente As String
   Public IdPartita As String
   Public Codice As String
   Public Data As String
   Public Minuti As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore

   Public Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
      '' Dichiara un oggetto DataAdapter.
      'Dim da As OleDbDataAdapter
      '' Dichiara un oggetto DataSet
      'Dim ds As DataSet
      'Dim sql As String

      'Try
      '   ' Apre la connessione.
      '   cn.Open()

      '   ' Crea la stringa.
      '   sql = String.Format("SELECT * FROM {0} WHERE Id = {1}", tabella, codice)

      '   ' Dichiara un oggetto DataAdapter.
      '   da = New OleDbDataAdapter(sql, cn)

      '   ' Dichiara un oggetto DataSet
      '   ds = New DataSet

      '   ' Riempe il DataSet con i dati della tabella.
      '   da.Fill(ds, tabella)

      '   ' Assegna i valori dei campi del DataSet ai campi della classe.
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Id")) = False Then
      '      Me.Codice = ds.Tables(tabella).Rows(0)("Id")
      '   Else
      '      Me.Codice = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
      '      Me.Numero = ds.Tables(tabella).Rows(0)("Numero")
      '   Else
      '      Me.Numero = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
      '      Me.Data = ds.Tables(tabella).Rows(0)("Data")
      '   Else
      '      Me.Data = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("IdRisorsa")) = False Then
      '      Me.IdRisorsa = ds.Tables(tabella).Rows(0)("IdRisorsa")
      '   Else
      '      Me.IdRisorsa = 0
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("IndiceRisorsa")) = False Then
      '      Me.IndiceRisorsa = ds.Tables(tabella).Rows(0)("IndiceRisorsa")
      '   Else
      '      Me.IndiceRisorsa = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizioneRisorsa")) = False Then
      '      Me.DescrizioneRisorsa = ds.Tables(tabella).Rows(0)("DescrizioneRisorsa")
      '   Else
      '      Me.DescrizioneRisorsa = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("CordY")) = False Then
      '      Me.CordY = ds.Tables(tabella).Rows(0)("CordY")
      '   Else
      '      Me.CordY = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Intestatario")) = False Then
      '      Me.Intestatario = ds.Tables(tabella).Rows(0)("Intestatario")
      '   Else
      '      Me.Intestatario = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Componente1")) = False Then
      '      Me.Componente1 = ds.Tables(tabella).Rows(0)("Componente1")
      '   Else
      '      Me.Componente1 = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Componente2")) = False Then
      '      Me.Componente2 = ds.Tables(tabella).Rows(0)("Componente2")
      '   Else
      '      Me.Componente2 = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Componente3")) = False Then
      '      Me.Componente3 = ds.Tables(tabella).Rows(0)("Componente3")
      '   Else
      '      Me.Componente3 = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
      '      Me.Stato = ds.Tables(tabella).Rows(0)("Stato")
      '   Else
      '      Me.Stato = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("OraInizio")) = False Then
      '      Me.OraInizio = ds.Tables(tabella).Rows(0)("OraInizio")
      '   Else
      '      Me.OraInizio = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("OraFine")) = False Then
      '      Me.OraFine = ds.Tables(tabella).Rows(0)("OraFine")
      '   Else
      '      Me.OraFine = ""
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
      '      Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
      '   Else
      '      Me.Colore = 0
      '   End If
      '   If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
      '      Me.Note = ds.Tables(tabella).Rows(0)("Note")
      '   Else
      '      Me.Note = ""
      '   End If
      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   da.Dispose()
      '   ds.Dispose()
      '   ' Chiude la connessione.
      '   cn.Close()
      'End Try
   End Sub

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (IdCliente, IdPartita, Data, " & _
                                              "Codice, Minuti) " & _
                                       "VALUES('{1}', '{2}', '{3}', '{4}', '{5}')", _
                                                tabella, _
                                                Me.IdCliente, _
                                                Me.IdPartita, _
                                                Me.Data, _
                                                Me.Codice, _
                                                Me.Minuti)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)
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

   Public Function EliminaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.

         sql = String.Format("DELETE FROM Statistiche WHERE Codice = '{0}'", codice)

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
         sql = String.Format("UPDATE {0} " & _
                             "SET Data = '{1}' " & _
                             "WHERE Codice = '{2}'", _
                              tabella, _
                              Me.Data, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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
