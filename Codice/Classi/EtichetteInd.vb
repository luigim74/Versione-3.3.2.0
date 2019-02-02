Imports System.Data.OleDb

Public Class EtichetteInd
   Public Id As String
   Public Cognome As String
   Public Nome As String
   Public Titolo As String
   Public Indirizzo As String
   Public Cap As String
   Public Città As String
   Public Provincia As String
   Public Quantità As Integer
   Public Formato As String
   Public Percorso As String
   Public PosStampa As Short

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cognome")) = False Then
            Me.Cognome = ds.Tables(tabella).Rows(0)("Cognome")
         Else
            Me.Cognome = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nome")) = False Then
            Me.Nome = ds.Tables(tabella).Rows(0)("Nome")
         Else
            Me.Nome = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Titolo")) = False Then
            Me.Titolo = ds.Tables(tabella).Rows(0)("Titolo")
         Else
            Me.Titolo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo")) = False Then
            Me.Indirizzo = ds.Tables(tabella).Rows(0)("Indirizzo")
         Else
            Me.Indirizzo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cap")) = False Then
            Me.Cap = ds.Tables(tabella).Rows(0)("Cap")
         Else
            Me.Cap = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Città")) = False Then
            Me.Città = ds.Tables(tabella).Rows(0)("Città")
         Else
            Me.Città = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Provincia")) = False Then
            Me.Provincia = ds.Tables(tabella).Rows(0)("Provincia")
         Else
            Me.Provincia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Quantità")) = False Then
            Me.Quantità = ds.Tables(tabella).Rows(0)("Quantità")
         Else
            Me.Quantità = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Formato")) = False Then
            Me.Formato = ds.Tables(tabella).Rows(0)("Formato")
         Else
            Me.Formato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Percorso")) = False Then
            Me.Percorso = ds.Tables(tabella).Rows(0)("Percorso")
         Else
            Me.Percorso = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PosStampa")) = False Then
            Me.PosStampa = ds.Tables(tabella).Rows(0)("PosStampa")
         Else
            Me.PosStampa = 1
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
         sql = String.Format("INSERT INTO {0} (Cognome, Nome, Titolo, Indirizzo, Cap, Città, Provincia, Quantità, Formato, Percorso, PosStampa) " & _
                                       "VALUES(@Cognome, @Nome, @Titolo, @Indirizzo, @Cap, @Città, @Provincia, @Quantità, @Formato, @Percorso, @PosStampa)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Cognome", Me.Cognome)
         cmdInsert.Parameters.Add("@Nome", Me.Nome)
         cmdInsert.Parameters.Add("@Titolo", Me.Titolo)
         cmdInsert.Parameters.Add("@Indirizzo", Me.Indirizzo)
         cmdInsert.Parameters.Add("@Cap", Me.Cap)
         cmdInsert.Parameters.Add("@Città", Me.Città)
         cmdInsert.Parameters.Add("@Provincia", Me.Provincia)
         cmdInsert.Parameters.Add("@Quantità", Me.Quantità)
         cmdInsert.Parameters.Add("@Formato", Me.Formato)
         cmdInsert.Parameters.Add("@Percorso", Me.Percorso)
         cmdInsert.Parameters.Add("@PosStampa", Me.PosStampa)

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
                             "SET Cognome = @Cognome, " & _
                             "Nome = @Nome, " & _
                             "Titolo = @Titolo, " & _
                             "Indirizzo = @Indirizzo, " & _
                             "Cap = @Cap, " & _
                             "Città = @Città, " & _
                             "Provincia = @Provincia, " & _
                             "Quantità = @Quantità, " & _
                             "Formato = @Formato, " & _
                             "Percorso = @Percorso, " & _
                             "PosStampa = @PosStampa " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Cognome", Me.Cognome)
         cmdUpdate.Parameters.Add("@Nome", Me.Nome)
         cmdUpdate.Parameters.Add("@Titolo", Me.Titolo)
         cmdUpdate.Parameters.Add("@Indirizzo", Me.Indirizzo)
         cmdUpdate.Parameters.Add("@Cap", Me.Cap)
         cmdUpdate.Parameters.Add("@Città", Me.Città)
         cmdUpdate.Parameters.Add("@Provincia", Me.Provincia)
         cmdUpdate.Parameters.Add("@Quantità", Me.Quantità)
         cmdUpdate.Parameters.Add("@Formato", Me.Formato)
         cmdUpdate.Parameters.Add("@Percorso", Me.Percorso)
         cmdUpdate.Parameters.Add("@PosStampa", Me.PosStampa)

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
