Imports System.Data.OleDb

Public Class ContiTavoli

   Public Codice As String
   Public CodiceTavolo As String
   Public CodiceCliente As String
   Public CodiceAzienda As String
   Public Intestatario As String
   Public Indirizzo As String
   Public Cap As String
   Public Città As String
   Public Provincia As String
   Public PIva As String
   Public Iva As String
   Public Sconto As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction

   Public Overridable Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdTavolo")) = False Then
            Me.CodiceTavolo = ds.Tables(tabella).Rows(0)("IdTavolo")
         Else
            Me.CodiceTavolo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCliente")) = False Then
            Me.CodiceCliente = ds.Tables(tabella).Rows(0)("IdCliente")
         Else
            Me.CodiceCliente = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdAzienda")) = False Then
            Me.CodiceAzienda = ds.Tables(tabella).Rows(0)("IdAzienda")
         Else
            Me.CodiceAzienda = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Intestatario")) = False Then
            Me.Intestatario = ds.Tables(tabella).Rows(0)("Intestatario")
         Else
            Me.Intestatario = ""
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("PIva")) = False Then
            Me.PIva = ds.Tables(tabella).Rows(0)("PIva")
         Else
            Me.PIva = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Iva")) = False Then
            Me.Iva = ds.Tables(tabella).Rows(0)("Iva")
         Else
            Me.Iva = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
            Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto")
         Else
            Me.Sconto = ""
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
         sql = String.Format("INSERT INTO {0} (IdTavolo, IdCliente, IdAzienda, Intestatario, Indirizzo, Cap, Città, Provincia, Piva, Iva, Sconto) " & _
                              "VALUES(@IdTavolo, @IdCliente, @IdAzienda, @Intestatario, @Indirizzo, @Cap, @Città, @Provincia, @Piva, @Iva, @Sconto)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@IdTavolo", Me.CodiceTavolo)
         cmdInsert.Parameters.Add("@IdCliente", Me.CodiceCliente)
         cmdInsert.Parameters.Add("@IdAzienda", Me.CodiceAzienda)
         cmdInsert.Parameters.Add("@RagSociale", Me.Intestatario)
         cmdInsert.Parameters.Add("@Indirizzo", Me.Indirizzo)
         cmdInsert.Parameters.Add("@Cap", Me.Cap)
         cmdInsert.Parameters.Add("@Città", Me.Città)
         cmdInsert.Parameters.Add("@Provincia", Me.Provincia)
         cmdInsert.Parameters.Add("@Piva", Me.PIva)
         cmdInsert.Parameters.Add("@Iva", Me.Iva)
         cmdInsert.Parameters.Add("@Sconto", Me.Sconto)

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
                             "SET IdTavolo =  @IdTavolo, " &
                             "IdCliente = @IdCliente, " & _
                             "IdAzienda = @IdAzienda, " & _
                             "Intestatario = @Intestatario, " & _
                             "Indirizzo = @Indirizzo, " & _
                             "Cap = @Cap, " & _
                             "Città = @Città, " & _
                             "Provincia = @Provincia, " & _
                             "Piva = @Piva, " & _
                             "Iva = @Iva, " & _
                             "Sconto = @Sconto " & _
                             "WHERE IdTavolo = '{1}'", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@IdTavolo", Me.CodiceTavolo)
         cmdUpdate.Parameters.Add("@IdCliente", Me.CodiceCliente)
         cmdUpdate.Parameters.Add("@IdAzienda", Me.CodiceAzienda)
         cmdUpdate.Parameters.Add("@RagSociale", Me.Intestatario)
         cmdUpdate.Parameters.Add("@Indirizzo", Me.Indirizzo)
         cmdUpdate.Parameters.Add("@Cap", Me.Cap)
         cmdUpdate.Parameters.Add("@Città", Me.Città)
         cmdUpdate.Parameters.Add("@Provincia", Me.Provincia)
         cmdUpdate.Parameters.Add("@Piva", Me.PIva)
         cmdUpdate.Parameters.Add("@Iva", Me.Iva)
         cmdUpdate.Parameters.Add("@Sconto", Me.Sconto)

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

