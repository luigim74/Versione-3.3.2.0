Imports System.Data.OleDb

Public Class Allegati

   Public Codice As Integer
   Public Documento As String
   Public Data As String
   Public Ora As String
   Public Note As String
   Public Percorso As String
   Public Estensione As String
   Public IdCliente As Integer

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal codCliente As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer
         Dim Estensione As String

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdCliente = " & codCliente & " ORDER BY Documento ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            lst.Items.Add(dr.Item("Documento"))
            lst.Items(i).SubItems.Add(dr.Item("Data"))
            lst.Items(i).SubItems.Add(dr.Item("Ora"))
            lst.Items(i).SubItems.Add(dr.Item("Note"))
            lst.Items(i).SubItems.Add(dr.Item("Percorso"))
            lst.Items(i).SubItems.Add(dr.Item("Id"))
            Estensione = dr.Item("Estensione")

            Select Case Estensione.ToUpper
               Case ".DOC", ".DOCX", ".RTF"
                  ' Word
                  lst.Items(i).StateImageIndex = 1

               Case ".XLS", ".XLSX"
                  ' Excel
                  lst.Items(i).StateImageIndex = 2

               Case ".MDB"
                  ' Access
                  lst.Items(i).StateImageIndex = 3

               Case ".PPT"
                  ' Power Point
                  lst.Items(i).StateImageIndex = 4

               Case ".TXT"
                  ' Blocco note.
                  lst.Items(i).StateImageIndex = 5

               Case ".PDF"
                  ' Acrobat Reader
                  lst.Items(i).StateImageIndex = 6

               Case ".HTM", ".HTML"
                  ' Internet Explorer
                  lst.Items(i).StateImageIndex = 7

               Case ".PNG", ".JPEG", ".JPG", ".BMP", ".GIF"
                  ' Altre estensioni.
                  lst.Items(i).StateImageIndex = 8

               Case Else
                  ' Altre estensioni.
                  lst.Items(i).StateImageIndex = 8
            End Select

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
         sql = String.Format("INSERT INTO {0} (Documento, Data, Ora, [Note], [Percorso], IdCliente, Estensione) " & _
                                              "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}')", tabella, _
                                              Me.Documento, _
                                              Me.Data, _
                                              Me.Ora, _
                                              Me.Note, _
                                              Me.Percorso, _
                                              Me.IdCliente, _
                                              Me.Estensione)


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

   Public Function ModificaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET Documento = '{1}', " & _
                             "Data = '{2}', " & _
                             "Ora = '{3}', " & _
                             "[Note] = '{4}', " & _
                             "[Percorso] = '{5}', " & _
                             "IdCliente = {6}, " & _
                             "Estensione = '{7}' " & _
                             "WHERE Id = {8}", _
                             tabella, _
                             Me.Documento, _
                             Me.Data, _
                             Me.Ora, _
                             Me.Note, _
                             Me.Percorso, _
                             Me.IdCliente, _
                             Me.Estensione, _
                             Id)

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
