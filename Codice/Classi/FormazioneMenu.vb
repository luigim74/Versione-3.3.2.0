#Region " DATI FILE.VB "
' ******************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       24/10/2020
' Data ultima modifica: 31/10/2020
' Descrizione:          Classe per la gestione dei dati del Modulo Formazione Menu
' Note:
' 
' Elenco Attivita:
'
' ******************************************************************************************
#End Region

Public Class FormazioneMenu

   Public Codice As String
   Public Titolo As String
   Public Sottotitolo As String
   Public Note As String
   Public Immagine As String
   Public Documento As String
   Public ImmagineQR As String
   Public Modello As String
   Public Listino As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction

   Public Sub LeggiDati(ByVal tabella As String)
      ' Dichiara un oggetto DataAdapter.
      Dim da As OleDbDataAdapter
      ' Dichiara un oggetto DataSet
      Dim ds As DataSet
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea la stringa.
         sql = String.Format("SELECT * FROM {0}", tabella)

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Titolo")) = False Then
            Me.Titolo = ds.Tables(tabella).Rows(0)("Titolo").ToString
         Else
            Me.Titolo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sottotitolo")) = False Then
            Me.Sottotitolo = ds.Tables(tabella).Rows(0)("Sottotitolo")
         Else
            Me.Sottotitolo = String.Empty
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Documento")) = False Then
            Me.Documento = ds.Tables(tabella).Rows(0)("Documento").ToString
         Else
            Me.Documento = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImmagineQR")) = False Then
            Me.ImmagineQR = ds.Tables(tabella).Rows(0)("ImmagineQR").ToString
         Else
            Me.ImmagineQR = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Modello")) = False Then
            Me.Modello = ds.Tables(tabella).Rows(0)("Modello")
         Else
            Me.Modello = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino")) = False Then
            Me.Listino = ds.Tables(tabella).Rows(0)("Listino")
         Else
            Me.Listino = String.Empty
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

   Public Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Titolo = @Titolo, " &
                             "Sottotitolo = @Sottotitolo, " &
                             "[Note] = @Note, " &
                             "[Immagine] = @Immagine, " &
                             "[Documento] = @Documento, " &
                             "[ImmagineQR] = @ImmagineQR, " &
                             "[Modello] = @Modello, " &
                             "Listino = @Listino " &
                             "WHERE Id = {1}",
                             tabella,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Titolo", Me.Titolo)
         cmdUpdate.Parameters.AddWithValue("@Sottotitolo", Me.Sottotitolo)
         cmdUpdate.Parameters.AddWithValue("@Note", Me.Note)
         cmdUpdate.Parameters.AddWithValue("@Immagine", Me.Immagine)
         cmdUpdate.Parameters.AddWithValue("@Documento", Me.Documento)
         cmdUpdate.Parameters.AddWithValue("@ImmagineQR", Me.ImmagineQR)
         cmdUpdate.Parameters.AddWithValue("@Modello", Me.Modello)
         cmdUpdate.Parameters.AddWithValue("@Listino", Me.Listino)

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
