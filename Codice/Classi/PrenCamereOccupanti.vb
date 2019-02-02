#Region " DATI FILE.VB "
' ****************************************************************************************
' Nome Classe:          PrenCamereOccupanti
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/08/2018
' Data ultima modifica: 24/08/2018
' Descrizione:          Classe per la gestione dei dati della Tabella PrenCamereOccupanti.
' Note:
'
' Elenco Attivita:
'
' *****************************************************************************************
#End Region

Imports System.Data.OleDb

Public Class PrenCamereOccupanti

   Public Codice As Integer
   Public RifPren As Integer
   Public CodiceCliente As String
   Public TipoAlloggiato As String
   Public Cognome As String
   Public Nome As String
   Public Sesso As String
   Public DataNascita As String
   Public LuogoNascita As String
   Public ProvNascita As String
   Public StatoNascita As String
   Public Cittadinanza As String
   Public DataArrivo As String
   Public Permanenza As Integer

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
   Private CFormatta As New ClsFormatta

   Public Function LeggiDati(ByVal tabella As String, ByVal id As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Id.
            If IsDBNull(dr.Item("Id")) = False Then
               Me.Codice = Convert.ToInt32(dr.Item("Id"))
            Else
               Me.Codice = 0
            End If
            ' IdRisorsa
            If IsDBNull(dr.Item("RifPren")) = False Then
               Me.RifPren = Convert.ToInt32(dr.Item("RifPren"))
            Else
               Me.RifPren = 0
            End If
            ' Codice Cliente
            If IsDBNull(dr.Item("CodiceCliente")) = False Then
               Me.CodiceCliente = dr.Item("CodiceCliente")
            Else
               Me.CodiceCliente = String.Empty
            End If
            ' Tipo Alloggiato.
            If IsDBNull(dr.Item("TipoAlloggiato")) = False Then
               Me.TipoAlloggiato = dr.Item("TipoAlloggiato").ToString
            Else
               Me.TipoAlloggiato = String.Empty
            End If
            ' Cognome.
            If IsDBNull(dr.Item("Cognome")) = False Then
               Me.Cognome = dr.Item("Cognome").ToString
            Else
               Me.Cognome = String.Empty
            End If
            ' Nome.
            If IsDBNull(dr.Item("Nome")) = False Then
               Me.Nome = dr.Item("Nome").ToString
            Else
               Me.Nome = String.Empty
            End If
            ' Sesso.
            If IsDBNull(dr.Item("Sesso")) = False Then
               Me.Sesso = dr.Item("Sesso").ToString
            Else
               Me.Sesso = String.Empty
            End If
            ' Data di nascita.
            If IsDBNull(dr.Item("DataNascita")) = False Then
               Me.DataNascita = dr.Item("DataNascita").ToString
            Else
               Me.DataNascita = String.Empty
            End If
            ' LuogoNascita.
            If IsDBNull(dr.Item("LuogoNascita")) = False Then
               Me.LuogoNascita = dr.Item("LuogoNascita").ToString
            Else
               Me.LuogoNascita = String.Empty
            End If
            ' ProvNascita.
            If IsDBNull(dr.Item("ProvNascita")) = False Then
               Me.ProvNascita = dr.Item("ProvNascita").ToString
            Else
               Me.ProvNascita = String.Empty
            End If
            ' StatoNascita..
            If IsDBNull(dr.Item("StatoNascita")) = False Then
               Me.StatoNascita = dr.Item("StatoNascita").ToString
            Else
               Me.StatoNascita = String.Empty
            End If
            ' Nazionalità.
            If IsDBNull(dr.Item("Cittadinanza")) = False Then
               Me.Cittadinanza = dr.Item("Cittadinanza").ToString
            Else
               Me.Cittadinanza = String.Empty
            End If
            ' DataArrivo.
            If IsDBNull(dr.Item("DataArrivo")) = False Then
               Me.DataArrivo = dr.Item("DataArrivo").ToString
            Else
               Me.DataArrivo = String.Empty
            End If
            ' Permanenza.
            If IsDBNull(dr.Item("Permanenza")) = False Then
               Me.Permanenza = dr.Item("Permanenza").ToString
            Else
               Me.Permanenza = 0
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

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal codPren As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer = 0

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifPren = " & codPren, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Indice.
            lst.Items.Add(i)

            ' Cognome.
            If IsDBNull(dr.Item("Cognome")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Cognome").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Nome.
            If IsDBNull(dr.Item("Nome")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Nome").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Sesso.
            If IsDBNull(dr.Item("Sesso")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Sesso").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' DataNascita.
            If IsDBNull(dr.Item("DataNascita")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("DataNascita").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' LuogoNascita.
            If IsDBNull(dr.Item("LuogoNascita")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("LuogoNascita").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' ProvNascita.
            If IsDBNull(dr.Item("ProvNascita")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("ProvNascita").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' StatoNascita.
            If IsDBNull(dr.Item("StatoNascita")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("StatoNascita").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Permanenza.
            If IsDBNull(dr.Item("Permanenza")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Permanenza").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Tipo Alloggiato.
            If IsDBNull(dr.Item("TipoAlloggiato")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("TipoAlloggiato").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Codice Cliente.
            If IsDBNull(dr.Item("CodiceCliente")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("CodiceCliente").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Cittadinanza.
            If IsDBNull(dr.Item("Cittadinanza")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Cittadinanza").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' DataArrivo.
            If IsDBNull(dr.Item("DataArrivo")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("DataArrivo").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If

            i = i + 1

            Caricati = True
         Loop

         Return Caricati

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

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
         sql = String.Format("INSERT INTO {0} (RifPren, CodiceCliente, TipoAlloggiato, Cognome, Nome, Sesso, DataNascita, LuogoNascita, ProvNascita, StatoNascita, Cittadinanza, DataArrivo, Permanenza) " &
                                       "VALUES(@RifPren, @CodiceCliente, @TipoAlloggiato, @Cognome, @Nome, @Sesso, @DataNascita, @LuogoNascita, @ProvNascita, @StatoNascita, @Cittadinanza, @DataArrivo, @Permanenza)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdInsert.Parameters.AddWithValue("@CodiceCliente", Me.CodiceCliente)
         cmdInsert.Parameters.AddWithValue("@TipoAlloggiato", Me.TipoAlloggiato)
         cmdInsert.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdInsert.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdInsert.Parameters.AddWithValue("@Sesso", Me.Sesso)
         cmdInsert.Parameters.AddWithValue("@DataNascita", Me.DataNascita)
         cmdInsert.Parameters.AddWithValue("@LuogoNascita", Me.LuogoNascita)
         cmdInsert.Parameters.AddWithValue("@ProvNascita", Me.ProvNascita)
         cmdInsert.Parameters.AddWithValue("@StatoNascita", Me.StatoNascita)
         cmdInsert.Parameters.AddWithValue("@Cittadinanza", Me.Cittadinanza)
         cmdInsert.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdInsert.Parameters.AddWithValue("@Permanenza", Me.Permanenza)

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

   Public Function ModificaDati(ByVal tabella As String, ByVal codPren As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET RifPren = @RifPren, " &
                             "CodiceCliente = @CodiceCliente, " &
                             "TipoAlloggiato = @TipoAlloggiato, " &
                             "Cognome = @Cognome, " &
                             "Nome = @Nome, " &
                             "Sesso = @Sesso, " &
                             "DataNascita = @DataNascita, " &
                             "LuogoNascita = @LuogoNascita, " &
                             "ProvNascita = @ProvNascita, " &
                             "StatoNascita = @StatoNascita, " &
                             "Cittadinanza = @Cittadinanza, " &
                             "DataArrivo = @DataArrivo, " &
                             "Permanenza = @Permanenza " &
                             "WHERE RifPren = {1}",
                             tabella,
                             codPren)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdUpdate.Parameters.AddWithValue("@CodiceCliente", Me.CodiceCliente)
         cmdUpdate.Parameters.AddWithValue("@TipoAlloggiato", Me.TipoAlloggiato)
         cmdUpdate.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdUpdate.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdUpdate.Parameters.AddWithValue("@Sesso", Me.Sesso)
         cmdUpdate.Parameters.AddWithValue("@DataNascita", Me.DataNascita)
         cmdUpdate.Parameters.AddWithValue("@LuogoNascita", Me.LuogoNascita)
         cmdUpdate.Parameters.AddWithValue("@ProvNascita", Me.ProvNascita)
         cmdUpdate.Parameters.AddWithValue("@StatoNascita", Me.StatoNascita)
         cmdUpdate.Parameters.AddWithValue("@Cittadinanza", Me.Cittadinanza)
         cmdUpdate.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdUpdate.Parameters.AddWithValue("@Permanenza", Me.Permanenza)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE RifPren = {1}", tabella, Id)

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
