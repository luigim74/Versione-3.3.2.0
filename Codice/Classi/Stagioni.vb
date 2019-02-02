Imports System.Data.OleDb

Public Class Stagioni

   Public Codice As String

   Public DataInizio1_Bassa As String
   Public DataFine1_Bassa As String
   Public DataInizio2_Bassa As String
   Public DataFine2_Bassa As String
   Public DataInizio3_Bassa As String
   Public DataFine3_Bassa As String

   Public DataInizio1_Media As String
   Public DataFine1_Media As String
   Public DataInizio2_Media As String
   Public DataFine2_Media As String
   Public DataInizio3_Media As String
   Public DataFine3_Media As String

   Public DataInizio1_Alta As String
   Public DataFine1_Alta As String
   Public DataInizio2_Alta As String
   Public DataFine2_Alta As String
   Public DataInizio3_Alta As String
   Public DataFine3_Alta As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore

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
            Me.Codice = ""
         End If

         ' Bassa Stagione.
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio1_Bassa")) = False Then
            Me.DataInizio1_Bassa = ds.Tables(tabella).Rows(0)("DataInizio1_Bassa").ToString
         Else
            Me.DataInizio1_Bassa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine1_Bassa")) = False Then
            Me.DataFine1_Bassa = ds.Tables(tabella).Rows(0)("DataFine1_Bassa").ToString
         Else
            Me.DataFine1_Bassa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio2_Bassa")) = False Then
            Me.DataInizio2_Bassa = ds.Tables(tabella).Rows(0)("DataInizio2_Bassa").ToString
         Else
            Me.DataInizio2_Bassa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine2_Bassa")) = False Then
            Me.DataFine2_Bassa = ds.Tables(tabella).Rows(0)("DataFine2_Bassa").ToString
         Else
            Me.DataFine2_Bassa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio3_Bassa")) = False Then
            Me.DataInizio3_Bassa = ds.Tables(tabella).Rows(0)("DataInizio3_Bassa").ToString
         Else
            Me.DataInizio3_Bassa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine3_Bassa")) = False Then
            Me.DataFine3_Bassa = ds.Tables(tabella).Rows(0)("DataFine3_Bassa").ToString
         Else
            Me.DataFine3_Bassa = ""
         End If

         ' Media Stagione.
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio1_Media")) = False Then
            Me.DataInizio1_Media = ds.Tables(tabella).Rows(0)("DataInizio1_Media").ToString
         Else
            Me.DataInizio1_Media = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine1_Media")) = False Then
            Me.DataFine1_Media = ds.Tables(tabella).Rows(0)("DataFine1_Media").ToString
         Else
            Me.DataFine1_Media = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio2_Media")) = False Then
            Me.DataInizio2_Media = ds.Tables(tabella).Rows(0)("DataInizio2_Media").ToString
         Else
            Me.DataInizio2_Media = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine2_Media")) = False Then
            Me.DataFine2_Media = ds.Tables(tabella).Rows(0)("DataFine2_Media").ToString
         Else
            Me.DataFine2_Media = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio3_Media")) = False Then
            Me.DataInizio3_Media = ds.Tables(tabella).Rows(0)("DataInizio3_Media").ToString
         Else
            Me.DataInizio3_Media = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine3_Media")) = False Then
            Me.DataFine3_Media = ds.Tables(tabella).Rows(0)("DataFine3_Media").ToString
         Else
            Me.DataFine3_Media = ""
         End If

         ' Alta Stagione.
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio1_Alta")) = False Then
            Me.DataInizio1_Alta = ds.Tables(tabella).Rows(0)("DataInizio1_Alta").ToString
         Else
            Me.DataInizio1_Alta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine1_Alta")) = False Then
            Me.DataFine1_Alta = ds.Tables(tabella).Rows(0)("DataFine1_Alta").ToString
         Else
            Me.DataFine1_Alta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio2_Alta")) = False Then
            Me.DataInizio2_Alta = ds.Tables(tabella).Rows(0)("DataInizio2_Alta").ToString
         Else
            Me.DataInizio2_Alta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine2_Alta")) = False Then
            Me.DataFine2_Alta = ds.Tables(tabella).Rows(0)("DataFine2_Alta").ToString
         Else
            Me.DataFine2_Alta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInizio3_Alta")) = False Then
            Me.DataInizio3_Alta = ds.Tables(tabella).Rows(0)("DataInizio3_Alta").ToString
         Else
            Me.DataInizio3_Alta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataFine3_Alta")) = False Then
            Me.DataFine3_Alta = ds.Tables(tabella).Rows(0)("DataFine3_Alta").ToString
         Else
            Me.DataFine3_Alta = ""
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
         sql = String.Format("UPDATE {0} " & _
                             "SET DataInizio1_Bassa = @DataInizio1_Bassa, " & _
                             "DataFine1_Bassa = @DataFine1_Bassa, " & _
                             "DataInizio2_Bassa = @DataInizio2_Bassa, " & _
                             "DataFine2_Bassa = @DataFine2_Bassa, " & _
                             "DataInizio3_Bassa = @DataInizio3_Bassa, " & _
                             "DataFine3_Bassa = @DataFine3_Bassa, " & _
                             "DataInizio1_Media = @DataInizio1_Media, " & _
                             "DataFine1_Media = @DataFine1_Media, " & _
                             "DataInizio2_Media = @DataInizio2_Media, " & _
                             "DataFine2_Media = @DataFine2_Media, " & _
                             "DataInizio3_Media = @DataInizio3_Media, " & _
                             "DataFine3_Media = @DataFine3_Media, " & _
                             "DataInizio1_Alta = @DataInizio1_Alta, " & _
                             "DataFine1_Alta = @DataFine1_Alta, " & _
                             "DataInizio2_Alta = @DataInizio2_Alta, " & _
                             "DataFine2_Alta = @DataFine2_Alta, " & _
                             "DataInizio3_Alta = @DataInizio3_Alta, " & _
                             "DataFine3_Alta = @DataFine3_Alta " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@DataInizio1_Bassa", Me.DataInizio1_Bassa)
         cmdUpdate.Parameters.AddWithValue("@DataFine1_Bassa", Me.DataFine1_Bassa)
         cmdUpdate.Parameters.AddWithValue("@DataInizio2_Bassa", Me.DataInizio2_Bassa)
         cmdUpdate.Parameters.AddWithValue("@DataFine2_Bassa", Me.DataFine2_Bassa)
         cmdUpdate.Parameters.AddWithValue("@DataInizio3_Bassa", Me.DataInizio3_Bassa)
         cmdUpdate.Parameters.AddWithValue("@DataFine3_Bassa", Me.DataFine3_Bassa)

         cmdUpdate.Parameters.AddWithValue("@DataInizio1_Media", Me.DataInizio1_Media)
         cmdUpdate.Parameters.AddWithValue("@DataFine1_Media", Me.DataFine1_Media)
         cmdUpdate.Parameters.AddWithValue("@DataInizio2_Media", Me.DataInizio2_Media)
         cmdUpdate.Parameters.AddWithValue("@DataFine2_Media", Me.DataFine2_Media)
         cmdUpdate.Parameters.AddWithValue("@DataInizio3_Media", Me.DataInizio3_Media)
         cmdUpdate.Parameters.AddWithValue("@DataFine3_Media", Me.DataFine3_Media)

         cmdUpdate.Parameters.AddWithValue("@DataInizio1_Alta", Me.DataInizio1_Alta)
         cmdUpdate.Parameters.AddWithValue("@DataFine1_Alta", Me.DataFine1_Alta)
         cmdUpdate.Parameters.AddWithValue("@DataInizio2_Alta", Me.DataInizio2_Alta)
         cmdUpdate.Parameters.AddWithValue("@DataFine2_Alta", Me.DataFine2_Alta)
         cmdUpdate.Parameters.AddWithValue("@DataInizio3_Alta", Me.DataInizio3_Alta)
         cmdUpdate.Parameters.AddWithValue("@DataFine3_Alta", Me.DataFine3_Alta)

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
