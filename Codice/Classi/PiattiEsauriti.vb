Imports System.Data.OleDb

Public Class PiattiEsauriti

   Public IdPiatto As Integer
   Public Descrizione As String
   Public Categoria As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
   Private CFormatta As New ClsFormatta

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Indice
            lst.Items.Add(dr.Item(i))
            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Descrizione"))
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Categoria"))
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Id Piatto.
            If IsDBNull(dr.Item("IdPiatto")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("IdPiatto"))
            Else
               lst.Items(i).SubItems.Add("")
            End If

            'lst.Items(i).SubItems.Add(dr.Item("Id"))

            i = i + 1

            Caricati = True
         Loop

         Return Caricati

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (IdPiatto, Descrizione, Categoria) " & _
                                       "VALUES(@IdPiatto, @Descrizione, @Categoria)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@IdPiatto", Me.IdPiatto)
         cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.Add("@CategoriaPiatto", Me.Categoria)

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

   Public Function ModificaDati(ByVal tabella As String, ByVal codPiatto As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET IdPiatto = @IdPiatto, " & _
                             "Descrizione = @Descrizione, " & _
                             "Categoria = @Categoria " & _
                             "WHERE IdPiatto = {1}", _
                             tabella, _
                             codPiatto)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@IdPiatto", Me.IdPiatto)
         cmdUpdate.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.Add("@CategoriaPiatto", Me.Categoria)

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
