Imports System.Data.SQLite

Public Class CategoriePiattiSQLite

   Public Codice As String
   Public Descrizione As String
   Public Colore As String

   Dim connStrSQLite As String

   Public Sub New()
      ' Crea la stringa di connessione.
      connStrSQLite = "Data Source=" & Application.StartupPath & NOME_PERCORSO_FILE_ANAG_ANDROID
   End Sub

   Public Function CreaTabella(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cnSQLite As New SQLiteConnection(connStrSQLite)
      Dim tr As SQLiteTransaction
      Dim sql As String

      Try
         ' Apre la connessione.
         cnSQLite.Open()

         ' Avvia una transazione.
         tr = cnSQLite.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa per la creazione della tabella.
         sql = String.Format("CREATE TABLE {0} (" &
                             "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " &
                             "Codice VARCHAR(10) NULL, " &
                             "Descrizione VARCHAR(50) NULL, " &
                             "Colore VARCHAR(50) NULL" &
                             ")", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdCreaTabella As New SQLiteCommand(sql, cnSQLite, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdCreaTabella.ExecuteNonQuery()

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
         cnSQLite.Close()

      End Try
   End Function

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cnSQLite As New SQLiteConnection(connStrSQLite)
      Dim tr As SQLiteTransaction
      Dim sql As String

      Try
         ' Apre la connessione.
         cnSQLite.Open()

         ' Avvia una transazione.
         tr = cnSQLite.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di inserimento dati.
         sql = String.Format("INSERT INTO {0} (Codice, Descrizione, Colore) " & _
                                       "VALUES('{1}', '{2}', '{3}')", tabella,
                                       Me.Codice,
                                       Me.Descrizione,
                                       Me.Colore)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New SQLiteCommand(sql, cnSQLite, tr)

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
         cnSQLite.Close()

      End Try
   End Function

   Public Sub CancellaCampi()
      Try
         ' Pulisce tutti i campi da eventuali dati.
         With Me
            .Codice = String.Empty
            .Descrizione = String.Empty
            .Colore = String.Empty
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
