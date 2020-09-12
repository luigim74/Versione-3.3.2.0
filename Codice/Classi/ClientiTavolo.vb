#Region " DATI FILE.VB "

' **************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       27/08/2020
' Data ultima modifica: 27/08/2020
' Descrizione:          Classe per la gestione dei dati con il database.
' Note:
'
' Elenco Attivita:
'
' **************************************************************************************

#End Region

Imports System.Data.OleDb

Public Class ClientiTavolo

   Public IdTavolo As Integer
   Public IdCliente As Integer
   Public Nome As String
   Public Gruppo As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
   Private CFormatta As New ClsFormatta

   Public Function LeggiDati(ByVal tabella As String, ByVal idTavolo As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdTavolo = " & idTavolo, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' IdTavolo
            If IsDBNull(dr.Item("IdTavolo")) = False Then
               Me.IdTavolo = Convert.ToInt32(dr.Item("IdTavolo"))
            Else
               Me.IdTavolo = idTavolo
            End If
            ' IdCameriere.
            If IsDBNull(dr.Item("IdCliente")) = False Then
               Me.IdCliente = dr.Item("IdCliente").ToString
            Else
               Me.IdCliente = 0
            End If
            ' Nome Cliente.
            If IsDBNull(dr.Item("Nome")) = False Then
               Me.Nome = dr.Item("Nome").ToString
            Else
               Me.Nome = String.Empty
            End If
            ' Gruppo.
            If IsDBNull(dr.Item("Gruppo")) = False Then
               Me.Gruppo = dr.Item("Gruppo")
            Else
               Me.Gruppo = CAMERIERE_ALTRI
            End If
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal idTavolo As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdTavolo = " & idTavolo, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Nome.
            If IsDBNull(dr.Item("Nome")) = False Then
               lst.Items.Add(dr.Item("Nome").ToString)
            Else
               lst.Items.Add(String.Empty)
            End If
            ' IdTavolo.
            If IsDBNull(dr.Item("IdTavolo")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("IdTavolo").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' IdCliente.
            If IsDBNull(dr.Item("IdCliente")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("IdCliente").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Id.
            lst.Items(i).SubItems.Add(dr.Item("Id").ToString)

            ' Stabilisce il gruppo di appartenenza. (Predefinito - Altri)
            If IsDBNull(dr.Item("Gruppo")) = False Then
               lst.Items(lst.Items.Count - 1).Group = lst.Groups.Item(dr.Item("Gruppo"))
            Else
               lst.Items(i).SubItems.Add(CAMERIERE_ALTRI)
            End If

            ' Contatore.
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
         sql = String.Format("INSERT INTO {0} (IdTavolo, IdCliente, Nome, Gruppo) " &
                                       "VALUES(@IdTavolo, @IdCliente, @Nome, @Gruppo)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@IdTavolo", Me.IdTavolo)
         cmdInsert.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdInsert.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdInsert.Parameters.AddWithValue("@Gruppo", Me.Gruppo)

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

   Public Function ModificaDati(ByVal tabella As String, ByVal idTavolo As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET IdTavolo = @IdTavolo, " &
                             "IdCliente = @IdCliente, " &
                             "Nome = @Nome, " &
                             "Gruppo = @Gruppo " &
                             "WHERE IdTavolo = {1}",
                             tabella,
                             idTavolo)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@IdTavolo", Me.IdTavolo)
         cmdUpdate.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdUpdate.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdUpdate.Parameters.AddWithValue("@Gruppo", Me.Gruppo)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal IdTavolo As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE IdTavolo = {1}", tabella, IdTavolo)

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

   Public Function LeggiNumRecord(ByVal tabella As String, ByVal IdTavolo As Integer) As Integer
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM " & tabella & " WHERE IdTavolo = " & IdTavolo, cn)

         Return CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se è da chiudere.
         If closeOnExit Then cn.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function


End Class
