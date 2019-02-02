#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/01/2005
' Data ultima modifica: 05/09/2018
' Descrizione:          File contenente procedure varie.
' Note:
' ATTENZIONENE! QUESTO FILE CONTIENE PROCEDURE VARIE CONDIVISE DA TUTTI I PROGETTI.
' LE MODIFICHE APPORTATE AL CODICE POSSONO DANNEGGIARE IL FUNZIONAMENTO DI ALTRI PROGRAMMI.
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

#Region "Importazioni"

Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports Microsoft.Win32
Imports System.Reflection.Assembly

#End Region

Module Procedure

#Region "Dichiarazioni"

   Private DatiConfig As AppConfig
   Private CFormatta As New ClsFormatta
   Private CRandom As New Random
   Private err As New Varie.Errore

#End Region

#Region "Database"

   Public Sub ApriDb()
      'Try
      '   If Cn.State = ConnectionState.Open Then Cn.Close()
      '   Cn.ConnectionString = ConnString
      '   Cn.Open()
      'Catch ex As Exception
      '   CGestioneErrori.MemoErrore(ex)
      'End Try
   End Sub

   Public Function CreaConnString(ByVal Percorso As String) As String
      ' Crea la stringa di connessione per il database.
      Return "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & Percorso
   End Function

   Public Function VerificaReteDb(ByVal Percorso As String) As String
      Try
         ' Verifica se l'applicazione è in rete.
         If Percorso = "" Then
            Return "ARCHIVIO: Nessuno"

         ElseIf Mid(Percorso, 1, 2) = "\\" Then
            Return "ARCHIVIO SU MACCHINA IN RETE: "

         Else
            Return "ARCHIVIO SU MACCHINA LOCALE: "
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Function

   Public Function VerificaEsistenzaDb(ByVal Percorso As String) As Boolean
      Try
         ' Se la stringa del database e vuota prende quella della cartella locale
         Dim FileDB As File

         If FileDB.Exists(Percorso) = False Then
            If Percorso = "" Then
               NomeDB = ""
            End If
         Else
            ' Nome dell'archivio in uso senza percorso.
            NomeDB = Dir(Percorso)
         End If

         ' Controlla se l'archivio è in rete.
         ModApp = VerificaReteDb(Percorso)

         Return FileDB.Exists(Percorso)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   ' Procedura comune a tutti i vecchi progetti.
   Public Function ImpostaArchivio() As Boolean
      '    Try
      '        Dim Val As Boolean

      '        ' Controlla se è stato aperto un archivio.
      '        If VerificaEsistenzaDb(PercorsoDB) = True Then

      '            ' Crea la stringa di connessaione per il database.
      '            ConnString = CreaConnString(PercorsoDB)

      '            ' Visualizza il nome dell'archivio nella barra di stato.
      '            VisNomeDb(g_frmMain.sbrMain, 0, ModApp, NomeDB, PercorsoDB)

      '            Return True
      '        Else
      '            Return False
      '        End If

      '    Catch ex As Exception
      '        ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '        err.GestisciErrore(ex.StackTrace, ex.Message)
      '    End Try
   End Function

   ' Nuova procedura per Hospitality.
   Public Function ImpostaArchivio(ByVal eui_cmd As Elegant.Ui.Button) As Boolean
        Try
            Dim Val As Boolean

            ' Controlla se è stato aperto un archivio.
            If VerificaEsistenzaDb(PercorsoDB) = True Then

            ' Crea la stringa di connessaione per il database.
            ConnString = CreaConnString(PercorsoDB)

            ' Visualizza il nome dell'archivio nella barra di stato.
            VisNomeDb(eui_cmd, 0, ModApp, NomeDB, PercorsoDB)

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)
        End Try
    End Function

   Public Function ImpostaArchivioClienti() As Boolean
      Try
         Dim Val As Boolean

         ' Controlla se è stato aperto un archivio.
         If VerificaEsistenzaDb(PercorsoDBClienti) = True Then

            ' Crea la stringa di connessaione per il database.
            ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

    ' Procedura comune a tutti i vecchi progetti.
    Public Sub VisNomeDb(ByVal sbr As StatusBar, ByVal Index As Integer, ByVal Modalità As String, ByVal Nome As String, ByVal Percorso As String)
        Try
            ' Imposta il nome dell'archivio aperto sulla barra di stato.
            sbr.Panels(Index).Text = Modalità & Nome
            sbr.Panels(Index).ToolTipText = Percorso

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Public Sub VisNomeDb(ByVal eui_cmd As Elegant.Ui.Button, ByVal Index As Integer, ByVal Modalità As String, ByVal Nome As String, ByVal Percorso As String)
        Try
            ' Imposta il nome dell'archivio aperto sulla barra di stato.
            eui_cmd.Text = Modalità & Nome
            eui_cmd.ScreenTip.Text = Percorso

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)
        End Try
    End Sub

   Public Sub AggiornaTabella(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      ' Dichiara un oggetto transazione.
      Dim tr As OleDbTransaction
      Dim sql As String
      Dim cmd As New OleDbCommand(sql, cn)
      Dim ds As New DataSet
      ' Numero di record.
      Dim numRecord As Integer

      Try
         Dim dt As DataTable = ds.Tables.Add(tabella)

         If cmb.Text.Trim = "" Then
            cmb.Text = " "
         End If

         cn.Open()

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Descrizione = '{1}'", tabella, FormattaApici(cmb.Text))
         numRecord = CInt(cmd.ExecuteScalar())

         If numRecord = 0 Then
            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (Descrizione) VALUES('{1}')", tabella, FormattaApici(cmb.Text))

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)
            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()

            ' Conferma transazione.
            tr.Commit()
         End If

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AggiornaTabellaCategorie(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      ' Dichiara un oggetto transazione.
      Dim tr As OleDbTransaction
      Dim sql As String
      Dim cmd As New OleDbCommand(sql, cn)
      Dim ds As New DataSet
      ' Numero di record.
      Dim numRecord As Integer

      Try
         Dim dt As DataTable = ds.Tables.Add(tabella)

         If cmb.Text.Trim = "" Then
            cmb.Text = " "
         End If

         cn.Open()

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Descrizione = '{1}'", tabella, FormattaApici(cmb.Text))
         numRecord = CInt(cmd.ExecuteScalar())

         If numRecord = 0 Then
            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (Descrizione, Colore, Icona) VALUES('{1}', {2}, '{3}')", tabella, FormattaApici(cmb.Text), Convert.ToString(Color.LemonChiffon.ToArgb), "")

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)
            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()

            ' Conferma transazione.
            tr.Commit()
         End If

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaLista(ByVal cmb As Object, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb.Items.clear()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaLista(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaLista(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
            cmb1.Items.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaTaglie(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(InserisciZero(dr.Item("Id")) & " - " & dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaColori(ByVal chkl As CheckedListBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            chkl.Items.Add(InserisciZero(dr.Item("Id")) & " - " & dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   ' DA_FARE_B: Non dovrebbe essere utilizzata. Verificare!
   Public Sub CaricaListaClienti(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal tabella As String, ByVal cmb0 As Boolean)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Cognome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Cognome") & " " & dr.Item("Nome"))
            cmb1.Items.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaClienti(ByVal cmb1 As Object, ByVal cmb2 As Object, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Cognome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb1.Items.Clear()
         cmb2.Items.Clear()

         Do While dr.Read
            cmb1.Items.Add(dr.Item("Cognome"))
            cmb2.Items.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaClienti(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal cmb2 As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Cognome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb.Items.Clear()
         cmb1.Items.Clear()
         cmb2.Items.Clear()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Cognome"))
            cmb1.Items.Add(dr.Item("Nome"))
            cmb2.Items.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaFornitori(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY RagSociale ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("RagSociale"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaArticoli(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
            cmb1.Items.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaCamerieri(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Nome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Nome"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaRisorse(ByVal lstBox As ListBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            lstBox.Items.Add(String.Format(dr.Item("Descrizione")).ToUpper)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaPiatti(ByVal lstBox As ListBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            lstBox.Items.Add(String.Format(dr.Item("Descrizione")).ToUpper)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaProdotti(ByVal lstBox As ListBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            lstBox.Items.Add(String.Format(dr.Item("Descrizione")).ToUpper)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaCategorie(ByVal lstBox As ListBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY IdOrd ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            lstBox.Items.Add(String.Format(dr.Item("Descrizione")).ToUpper)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaReparti(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb.Items.Add("<Nessuno>")

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaMsgReparti(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb.Items.Add(VAL_NESSUNO)

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaCamere(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Disponibile = 'Sì' ORDER BY Numero ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb.Items.Add(VALORE_NESSUNA)

         Do While dr.Read
            cmb.Items.Add(dr.Item("Numero"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function LeggiDescrizioneCamera(ByVal numero As String, ByVal tabella As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Numero = '" & numero & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Descrizione").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiListinoCamera(ByVal numero As String, ByVal tabella As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Numero = '" & numero & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Listino").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiProvinciaComune(ByVal comune As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Comuni WHERE Descrizione = '" & comune & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Provincia").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiProvinciaCAP(ByVal comune As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM CAP WHERE Descrizione = '" & comune & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Provincia").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiCapCAP(ByVal comune As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM CAP WHERE Descrizione = '" & comune & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Cap").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiRegioneCAP(ByVal comune As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM CAP WHERE Descrizione = '" & comune & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Regione").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub CreaTabellaReport(ByVal stringaSql As String)
      'Dim sql As String

      'Try
      '   ' Apre la connessione.
      '   cn.Open()

      '   ' Avvia una transazione.
      '   tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
      '   ' Crea la stringa di eliminazione.
      '   sql = String.Format(stringaSql)

      '   ' Crea il comando per la connessione corrente.
      '   Dim cmdInsert As New OleDbCommand(sql, cn, tr)
      '   ' Esegue il comando.
      '   Dim Record As Integer = cmdInsert.ExecuteNonQuery()

      '   ' Conferma transazione.
      '   tr.Commit()

      'Catch ex As Exception
      '   ' Annulla transazione.
      '   tr.Rollback()

      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   ' Chiude la connessione.
      '   cn.Close()

      'End Try
   End Sub

   Private Sub EliminaTabellaReport(ByVal nomeTabella As String)
      '   Dim sql As String

      '   Try
      '      ' Apre la connessione.
      '      cn.Open()

      '      ' Avvia una transazione.
      '      tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
      '      ' Crea la stringa di eliminazione.
      '      sql = String.Format("DROP TABLE {0}", nomeTabella)

      '      ' Crea il comando per la connessione corrente.
      '      Dim cmdInsert As New OleDbCommand(sql, cn, tr)
      '      ' Esegue il comando.
      '      Dim Record As Integer = cmdInsert.ExecuteNonQuery()

      '      ' Conferma transazione.
      '      tr.Commit()

      '   Catch ex As Exception
      '      ' Annulla transazione.
      '      tr.Rollback()

      '      ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '      err.GestisciErrore(ex.StackTrace, ex.Message)

      '   Finally
      '      ' Chiude la connessione.
      '      cn.Close()

      '   End Try
   End Sub

   Public Function VerificaNumRecord(ByVal val As Integer) As Boolean
      Try
         If val >= NUM_ELEMENTI_DEMO Then
            MsgBox("Versione dimostrativa! Non è possibile inserire ulteriori dati.", MsgBoxStyle.Exclamation, NOME_PRODOTTO)
            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function VerificaNumRecord(ByVal val As Integer, ByVal recMax As Integer) As Boolean
      Try
         If val >= recMax Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function LeggiNumRecord(ByVal tabella As String, ByVal cn As OleDbConnection, ByVal cmd As OleDbCommand) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRec = Convert.ToInt32(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function SommaValoriColonna(ByVal tabella As String, ByVal campo As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Dim totale As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         ' Ottiene la somma dei valori della colonna.
         Dim cmd As New OleDbCommand("SELECT SUM(" & campo & ") FROM " & tabella, cn)

         If IsDBNull(cmd.ExecuteScalar()) = False Then
            totale = Convert.ToInt32(cmd.ExecuteScalar())
         Else
            totale = 0
         End If

         Return totale

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function VerificaEsistenzaAzienda(ByVal tabella As String, ByVal val As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim ConnectionStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & Application.StartupPath & PERCORSO_AZIENDE_DB
      Dim cn As New OleDbConnection(ConnectionStr)
      Dim sql As String = String.Format("SELECT * FROM {0}", tabella)
      Dim i As Integer

      Try
         ' Apre la connessione.
         cn.Open()

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If dr.Item("PercorsoDB") = val Then
               Return True
            End If
            i = i + 1
         Loop

         Return False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Sub SalvaRifAzienda(ByVal tabella As String, ByVal ragSoc As String, ByVal descr As String, ByVal percDb As String)
      Dim RifAzienda As New SelAziende(Application.StartupPath & PERCORSO_AZIENDE_DB)

      RifAzienda.RagSociale = ragSoc
      RifAzienda.Descrizione = descr
      RifAzienda.PercorsoDB = percDb

      RifAzienda.InserisciDati(tabella)
   End Sub

   Public Function VerificaEsistenzaValore(ByVal tabella As String, ByVal cn As OleDbConnection, ByVal cmd As OleDbCommand, _
                                           ByVal campo As String, ByVal val As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE " & campo & " = " & "'" & FormattaApici(val) & "'", tabella)
         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Function BlobToFile(ByVal dr As IDataReader, ByVal fieldIndex As Integer, ByVal filename As String) As Byte()
      '---------------------------------------------------------------------------
      '' carica l'immagine.
      'Dim cn As New OleDbConnection(ConnString)
      'cn.Open()
      'Dim cmd As New OleDbCommand(String.Format("SELECT * FROM {0} WHERE id = 14", NOME_TABELLA), cn)
      'Dim dr As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
      'dr.Read()

      'AAzienda.Immagine = BlobToFile(dr, 17, tempFile)

      'dr.Close()
      'cn.Close()
      'picFoto.Image = Image.FromFile(tempFile)
      'Image.FromFile(tempFile).Dispose()
      '---------------------------------------------------------------------------------

      Const CHUNK_SIZE As Integer = 200
      Dim buffer(CHUNK_SIZE - 1) As Byte
      Dim stream As System.IO.FileStream

      Dim index As Long = 0
      Try
         stream = New System.IO.FileStream(filename, FileMode.OpenOrCreate)
         Do
            ' Get the next chunk, exit if no more bytes.
            Dim length As Integer = CInt(dr.GetBytes(fieldIndex, index, buffer, 0, CHUNK_SIZE))
            If length = 0 Then Exit Do
            ' Write to file and increment index in field data.
            stream.Write(buffer, 0, length)
            index += length
         Loop

         Return buffer

      Catch ex As InvalidCastException
         Exit Function

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         stream.Close()
      End Try
   End Function

   Public Function CreaStream(ByVal percorsoFile As String) As Byte()
      Dim stream As System.IO.FileStream

      Try
         stream = New System.IO.FileStream(percorsoFile, IO.FileMode.Open)
         Dim buffer(CInt(stream.Length) - 1) As Byte
         stream.Read(buffer, 0, buffer.Length - 1)

         Return buffer

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         stream.Close()
      End Try
   End Function

   Public Function SommaColonnaDouble(ByVal DGrid As DataGrid, ByVal colonna As Integer, ByVal numRighe As Integer) As Double
      Try
         Dim i As Integer = 0
         Dim val As Double
         Dim totVal As Double

         For i = 0 To numRighe - 1
            val = CDbl(DGrid.Item(i, colonna))
            totVal = totVal + val
         Next

         Return totVal

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      End Try
   End Function

   Public Function SommaColonna(ByVal DGrid As DataGrid, ByVal colonna As Integer, ByVal numRighe As Integer) As Decimal
      Try
         Dim i As Integer = 0
         Dim val As Decimal
         Dim totVal As Decimal

         For i = 0 To numRighe - 1
            If IsNumeric(DGrid.Item(i, colonna)) = True Then
               val = CDec(DGrid.Item(i, colonna))
               totVal = totVal + val
            End If
         Next

         Return totVal

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function SommaColonna(ByVal lst As ListView, ByVal colonna As Integer) As Double
      Try
         Dim val As Double
         Dim totVal As Double

         Dim i As Integer = 0
         For i = 0 To lst.Items.Count - 1
            If IsNumeric(lst.Items(i).SubItems(colonna).Text) = True Then
               val = Convert.ToDouble(lst.Items(i).SubItems(colonna).Text)
               totVal = totVal + val
            End If
         Next

         Return totVal

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0
      End Try
   End Function

   Public Function LeggiUltimoRecord(ByVal tabella As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim closeOnExit As Boolean
      Dim id As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         Dim cmd As New OleDbCommand("SELECT MAX(Id) FROM " & tabella, cn)

         If IsDBNull(cmd.ExecuteScalar()) = False Then
            id = Convert.ToInt32(cmd.ExecuteScalar())
         Else
            id = 0
         End If

         Return id

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function LeggiUltimoRecord(ByVal tabella As String, ByVal campo As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim closeOnExit As Boolean
      Dim id As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         Dim cmd As New OleDbCommand("SELECT MAX(" & campo & ") FROM " & tabella, cn)

         If IsDBNull(cmd.ExecuteScalar()) = False Then
            id = Convert.ToInt32(cmd.ExecuteScalar())
         Else
            id = 0
         End If

         Return id

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function CompattaDb(ByVal PercorsoFileOrigine As String, ByVal PercorsoFileDestinazione As String) As Boolean
      Try
         'Al momento non è possibile compattare o riparare un database costruito con Access né tramite ADO.NET, né tramite ADO. 
         'Pertanto è necessario sfruttare lo strato di interoperabilità offerto da .NET e referenziare il 
         'componente COM denominato Microsoft Jet and Replication Objects (JRO) distribuito a partire da MDAC 2.1

         Dim J As New JRO.JetEngine

         J.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PercorsoFileOrigine, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PercorsoFileDestinazione & ";Jet OLEDB:Engine Type=5")

         'Il metodo CompactDatabase riceve la stringa di connessione del database da compattare e la stringa di un 
         'database da creare come copia compattata dell’originale. 
         'Il parametro Jet OLEDB:Engine Type individua la versione dell’ "Engine" di Access con cui è stato concepito 
         'il file originale pertanto è necessario assegnarli 4 se è stato creato con Access 97 
         'o 5 se è stato creato con Access 2000.

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

         'If err.Number = 13 Or err.Number = 53 Or err.Number = 5 Or err.Number = 76 Then
         '   CompattaDb = False
         '   Exit Try
         'Else
         '   CompattaDb = False
         '   Exit Try
         'End If
      End Try
   End Function

   Public Function ModificaStatoPren(ByVal tabella As String, ByVal codice As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Stato = @Stato, NumeroCamera = @NumeroCamera WHERE Id = {1}", tabella, codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@StatoDoc", VALORE_ANNULLATA)
         cmdUpdate.Parameters.AddWithValue("@NumeroCamera", VALORE_NESSUNA)

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

   Public Function ImportaDatiFile_CSV() As Boolean
      Try
         ' Importa i dati di un file in formato CSV o TXT con separatore ; in una tabella Access.

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim tr As OleDbTransaction
         Dim sql As String

         Dim rigaFile As String
         Dim campiFile As String()

         ' Crea o apre il file.
         FileOpen(1, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\listacomuni.txt", OpenMode.Input)

         ' Apre la connessione.
         cn.Open()

         Dim i As Integer = 0
         Do While Not EOF(1)
            Input(1, rigaFile)
            campiFile = rigaFile.Split(";")

            ' Salta la prima riga per l'intestazione dei campi.
            If i > 0 Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("INSERT INTO {0} (CodiceIstat, Comune, Provincia, Regione, PrefissoTel, Cap, CodiceFisco) " &
                                             "VALUES(@Campo1, @Campo2, @Campo3, @Campo4, @Campo5, @Campo6, @Campo7)", "CAP")

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@Campo1", campiFile(0))
               cmdInsert.Parameters.AddWithValue("@Campo2", campiFile(1))
               cmdInsert.Parameters.AddWithValue("@Campo3", campiFile(2))
               cmdInsert.Parameters.AddWithValue("@Campo4", campiFile(3))
               cmdInsert.Parameters.AddWithValue("@Campo5", campiFile(4))
               cmdInsert.Parameters.AddWithValue("@Campo6", campiFile(5))
               cmdInsert.Parameters.AddWithValue("@Campo7", campiFile(6))

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()

               ' Conferma transazione.
               tr.Commit()
            End If

            i += 1
         Loop

         ' Chiude la connessione.
         cn.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         FileClose(1)

      End Try
   End Function

#End Region

#Region "File e Directory"

   Sub CopiaDirectory(ByVal Origine As String, ByVal Destinazione As String)
      ' Utilizzare questo codice nelle procedure di chiamata CopiaDirectory per creare uno stato di avanzamento.
      'Conto i files nella directory origine per visualizzare lo stato di avanzamento
      'Dim dDir1 As New DirectoryInfo(DirectoryOrigine)
      'TotFiles = dDir1.GetFiles("*.*", SearchOption.AllDirectories).Length
      'ProgFiles = 0

      Try
         Dim ProgFiles, TotFiles As Integer
         Dim CartellaCorrente As DirectoryInfo = New DirectoryInfo(Origine)
         Dim Archivo As FileInfo
         Dim Cartella As DirectoryInfo

         For Each Archivo In CartellaCorrente.GetFiles()
            If Not Directory.Exists(Destinazione) Then Directory.CreateDirectory(Destinazione)

            Archivo.CopyTo(Path.Combine(Destinazione, Archivo.Name))
            ProgFiles += 1

            Application.DoEvents()
            Application.DoEvents()
         Next

         For Each Cartella In CartellaCorrente.GetDirectories()
            Dim subDirectory As String = Path.Combine(Destinazione, Cartella.Name)
            Directory.CreateDirectory(subDirectory)
            CopiaDirectory(Cartella.FullName, subDirectory)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function RestituisciPercorsoDirectory(ByVal percorso As String) As String
      Try
         Dim nomeFile As String = Dir(percorso)
         Dim soloPercorso As String = percorso.Remove(percorso.Length - nomeFile.Length, nomeFile.Length)

         Return soloPercorso

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return ""
      End Try
   End Function

   Public Function RestituisciPercorsoDirectory(ByVal percorso As String, ByVal nomeFile As String) As String
      Try
         Dim soloPercorso As String = percorso.Remove(percorso.Length - nomeFile.Length, nomeFile.Length)

         Return soloPercorso

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return ""
      End Try
   End Function

#End Region

#Region "Data/Ora "

   Public Function FormattaData(ByVal val As Date, ByVal formatoItal As Boolean) As String
      Try
         Dim dataFormat As New Globalization.DateTimeFormatInfo
         Dim separatore As String = dataFormat.DateSeparator

         Const Zero As String = "0"
         Const LunghezzaStringa As Integer = 1
         Dim Giorno As String
         Dim Mese As String
         Dim Anno As String

         Giorno = val.Day
         Mese = val.Month
         Anno = val.Year

         If Len(Giorno) = LunghezzaStringa Then
            Giorno = Zero & Giorno
         End If

         If Len(Mese) = LunghezzaStringa Then
            Mese = Zero & Mese
         End If

         If formatoItal = True Then
            ' Formato Italiano.
            Return Giorno & separatore & Mese & separatore & Anno
         Else
            ' Formato inglese.
            Return Mese & separatore & Giorno & separatore & Anno
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaDataBackup() As String
      Try
         Const Zero As String = "0"
         Const LunghezzaStringa As Integer = 1
         Dim Giorno As String = Now.Day
         Dim Mese As String = Now.Month
         Dim Anno As String = Now.Year

         If Len(Giorno) = LunghezzaStringa Then
            Giorno = Zero & Giorno
         End If

         If Len(Mese) = LunghezzaStringa Then
            Mese = Zero & Mese
         End If

         ' Formato Italiano.
         Return Giorno & "-" & Mese & "-" & Anno

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaDataOra(ByVal val As Date, ByVal formatoItal As Boolean) As String
      Try
         Dim dataFormat As New Globalization.DateTimeFormatInfo
         Dim sepData As String = dataFormat.DateSeparator
         Dim sepOra As String = dataFormat.TimeSeparator

         Const Zero As String = "0"
         Const LunghezzaStringa As Integer = 1
         Dim Giorno As String
         Dim Mese As String
         Dim Anno As String

         Giorno = val.Day
         Mese = val.Month
         Anno = val.Year

         If Len(Giorno) = LunghezzaStringa Then
            Giorno = Zero & Giorno
         End If

         If Len(Mese) = LunghezzaStringa Then
            Mese = Zero & Mese
         End If

         If formatoItal = True Then
            ' Formato Italiano.
            Return Giorno & sepData & Mese & sepData & Anno & " " & val.Hour & sepOra & val.Minute & sepOra & val.Second
         Else
            ' Formato inglese.
            Return Mese & sepData & Giorno & sepData & Anno & " " & val.Hour & sepOra & val.Minute & sepOra & val.Second
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaOra(ByVal ora As String) As Date
      Try
         ' Vecchio codice: dava errore!
         ' Convert.ToDateTime(Today.ToString & " " & ora)

         Return Convert.ToDateTime(ora)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function RimuoviSecondi(ByVal ora As String) As String
      Try
         Return ora.Remove(5, 3)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function VerificaDataDemo(ByVal fileDataDemo As String) As Boolean
      Const NUM_GIORNI_VALUTAZIONE As Short = 30
      Dim DataInst As Date
      Dim diffGiorni As TimeSpan
      Dim Giorni As String
      Dim i As Integer
      Dim Percorso As String
      Dim File As String
      Dim Stringa As String

      Dim systemDirectory As String = Application.StartupPath

      Try
         If systemDirectory <> "" Then
            File = Dir(systemDirectory & fileDataDemo, vbNormal)
            If File = "" Then
               FileOpen(1, systemDirectory & fileDataDemo, OpenMode.Append)
               PrintLine(1, Today)
               FileClose(1)

               DataInst = Today
            Else
               FileOpen(1, systemDirectory & fileDataDemo, OpenMode.Input)
               Do While Not EOF(1)
                  Input(1, Stringa)
               Loop
               FileClose(1)
               DataInst = CDate(Stringa)
            End If
         End If

         DataInst = DataInst.AddDays(NUM_GIORNI_VALUTAZIONE)

         If DataInst <= Today Then
            MessageBox.Show("Versione dimostrativa! Tempo di valutazione terminato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            giorniVerDemo = "0"

            Return False
         Else
            diffGiorni = DataInst.Subtract(Today)
            MessageBox.Show("Versione dimostrativa! Tempo di valutazione " & diffGiorni.Days.ToString & " giorni.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            giorniVerDemo = diffGiorni.Days.ToString

            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function VerificaDataDemo() As Boolean
      Const NUM_GIORNI_VALUTAZIONE As Short = 30
      Dim DataInst As Date
      Dim diffGiorni As TimeSpan

      Try
         Dim regSoftware As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
         Dim regAzienda As RegistryKey = regSoftware.CreateSubKey("MSVersionX")
         Dim regProdotto As RegistryKey = regAzienda.CreateSubKey(REG_CARTELLA_DEMO)
         Dim regVersioneFile As String = FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductVersion

         If regProdotto.GetValue(regVersioneFile) = "" Then
            regProdotto.SetValue(regVersioneFile, Today)
            DataInst = Today
         Else
            DataInst = regProdotto.GetValue(regVersioneFile)
         End If

         regSoftware.Close()
         regAzienda.Close()
         regProdotto.Close()

         DataInst = DataInst.AddDays(NUM_GIORNI_VALUTAZIONE)

         If DataInst <= Today Then
            MsgBox("Versione dimostrativa! Tempo di valutazione terminato.", vbOKOnly + vbExclamation, NOME_PRODOTTO)
            Return False
         Else
            diffGiorni = DataInst.Subtract(Today)
            MsgBox("Versione dimostrativa! Tempo di valutazione " & diffGiorni.Days.ToString & " giorni.", vbOKOnly + vbExclamation, NOME_PRODOTTO)
            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function ConvertiGiornoSettimana(ByVal numGiorno As Integer) As String
      Try
         Dim nomeGiorno As String

         Select Case numGiorno
            Case 0
               nomeGiorno = "Domenica"
            Case 1
               nomeGiorno = "Lunedì"
            Case 2
               nomeGiorno = "Martedì"
            Case 3
               nomeGiorno = "Mercoledì"
            Case 4
               nomeGiorno = "Giovedì"
            Case 5
               nomeGiorno = "Venerdì"
            Case 6
               nomeGiorno = "Sabato"
         End Select

         Return nomeGiorno

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaOreMinuti(ByVal oraEstesa As String) As String
      ' Elimina i seconti da una variabile ti tipo ora.
      ' Restituisce Ore e Minuti.
      If oraEstesa.Length > 5 Then
         Return oraEstesa.Remove(5, oraEstesa.Length - 5)
      Else
         Return oraEstesa
      End If
   End Function

   Public Function FormattaMinuti(ByVal minuti As String) As String
      ' Aggiunge uno zero davanti ai minuti in caso di singola cifra.
      If minuti.Length = 1 Then
         Return "0" & minuti
      Else
         Return minuti
      End If
   End Function

   Public Function CalcolaNumGiorni(ByVal dataInizio As Date, ByVal dataFine As Date) As String
      Try
         Dim numGiorni As TimeSpan = (dataFine - dataInizio)

         Return numGiorni.Days.ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      End Try

   End Function

   Public Function ConvertiOra(ByVal ora As String) As Double
      Try
         Select Case ora
            Case "6:00"
               Return 6

            Case "6:30"
               Return 6.5

            Case "6:45"
               Return 6

            Case "7:00"
               Return 7

            Case "7:15"
               Return 7

            Case "7:30"
               Return 7.5

            Case "7:45"
               Return 7

            Case "8:00"
               Return 8

            Case "8:15"
               Return 8

            Case "8:30"
               Return 8.5

            Case "8:45"
               Return 8

            Case "9:00"
               Return 9

            Case "9:15"
               Return 9

            Case "9:30"
               Return 9.5

            Case "9:45"
               Return 9

            Case "10:00"
               Return 10

            Case "10:15"
               Return 10

            Case "10:30"
               Return 10.5

            Case "10:45"
               Return 10

            Case "11:00"
               Return 11

            Case "11:15"
               Return 11

            Case "11:30"
               Return 11.5

            Case "11:45"
               Return 11

            Case "12:00"
               Return 12

            Case "12:15"
               Return 12

            Case "12:30"
               Return 12.5

            Case "12:45"
               Return 12

            Case "13:00"
               Return 13

            Case "13:15"
               Return 13

            Case "13:30"
               Return 13.5

            Case "13:45"
               Return 13

            Case "14:00"
               Return 14

            Case "14:15"
               Return 14

            Case "14:30"
               Return 14.5

            Case "14:45"
               Return 14

            Case "15:00"
               Return 15

            Case "15:15"
               Return 15

            Case "15:30"
               Return 15.5

            Case "15:45"
               Return 15

            Case "16:00"
               Return 16

            Case "16:15"
               Return 16

            Case "16:30"
               Return 16.5

            Case "16:45"
               Return 16

            Case "17:00"
               Return 17

            Case "17:15"
               Return 17

            Case "17:30"
               Return 17.5

            Case "17:45"
               Return 17

            Case "18:00"
               Return 18

            Case "18:15"
               Return 18

            Case "18:30"
               Return 18.5

            Case "18:45"
               Return 18

            Case "19:00"
               Return 19

            Case "19:15"
               Return 19

            Case "19:30"
               Return 19.5

            Case "19:45"
               Return 19

            Case "20:00"
               Return 20

            Case "20:15"
               Return 20

            Case "20:30"
               Return 20.5

            Case "20:45"
               Return 20

            Case "21:00"
               Return 21

            Case "21:15"
               Return 21

            Case "21:30"
               Return 21.5

            Case "21:45"
               Return 21

            Case "22:00"
               Return 22

            Case "22:15"
               Return 22

            Case "22:30"
               Return 22.5

            Case "22:45"
               Return 22

            Case "23:00"
               Return 23

            Case "23:15"
               Return 23

            Case "23:30"
               Return 23.5

            Case "23:45"
               Return 23

            Case "0:00"
               Return 24

            Case "0:15"
               Return 24

            Case "0:30"
               Return 24.5

            Case "0:45"
               Return 24

            Case Else
               Return 0

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Function


#End Region

#Region "Stringhe"

   Public Function FormattaApici(ByVal val As String) As String
      Try
         If val <> Nothing Then
            Dim stringa As String = val.Replace("'", "''")

            Return stringa

         ElseIf val = "" Then
            Return ""

         Else
            Return Nothing

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function SostituisciCaratteri(ByVal val As String) As String
      Try
         If val <> Nothing Then
            ' Formatta apici.
            Dim stringa As String = val.Replace("'", "''")

            ' Elimina i caratteri non supportati in SQLite.
            stringa = stringa.Replace("â", "a")
            stringa = stringa.Replace("á", "a")
            stringa = stringa.Replace("ä", "a")
            stringa = stringa.Replace("à", "a")
            stringa = stringa.Replace("Â", "A")
            stringa = stringa.Replace("Á", "A")
            stringa = stringa.Replace("Ä", "A")
            stringa = stringa.Replace("À", "A")

            stringa = stringa.Replace("è", "e")
            stringa = stringa.Replace("é", "e")
            stringa = stringa.Replace("ê", "e")
            stringa = stringa.Replace("ë", "e")
            stringa = stringa.Replace("È", "E")
            stringa = stringa.Replace("É", "E")
            stringa = stringa.Replace("Ê", "E")
            stringa = stringa.Replace("Ë", "E")

            stringa = stringa.Replace("î", "i")
            stringa = stringa.Replace("ï", "i")
            stringa = stringa.Replace("ì", "i")
            stringa = stringa.Replace("í", "i")
            stringa = stringa.Replace("Î", "I")
            stringa = stringa.Replace("Ï", "I")
            stringa = stringa.Replace("Ì", "I")
            stringa = stringa.Replace("Í", "I")

            stringa = stringa.Replace("ô", "o")
            stringa = stringa.Replace("ö", "o")
            stringa = stringa.Replace("ò", "o")
            stringa = stringa.Replace("ó", "o")
            stringa = stringa.Replace("Ô", "O")
            stringa = stringa.Replace("Ö", "O")
            stringa = stringa.Replace("Ò", "O")
            stringa = stringa.Replace("Ó", "O")

            stringa = stringa.Replace("û", "u")
            stringa = stringa.Replace("ü", "u")
            stringa = stringa.Replace("ù", "u")
            stringa = stringa.Replace("ú", "u")
            stringa = stringa.Replace("Û", "U")
            stringa = stringa.Replace("Ü", "U")
            stringa = stringa.Replace("Ù", "U")
            stringa = stringa.Replace("Ú", "U")

            stringa = stringa.Replace("ç", "c")
            stringa = stringa.Replace("Ç", "C")

            stringa = stringa.Replace("ñ", "n")
            stringa = stringa.Replace("Ñ", "N")

            stringa = stringa.Replace("°", "")
            stringa = stringa.Replace("€", "E")

            Return stringa

         Else
            Return String.Empty

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function InserisciZero(ByVal val As String) As String
      Try
         If val <> Nothing Then
            Select Case val.Length
               Case 1
                  val = val.Insert(0, "0000")
               Case 2
                  val = val.Insert(0, "000")
               Case 3
                  val = val.Insert(0, "00")
               Case 4
                  val = val.Insert(0, "0")
               Case Is > 4
                  Exit Function
            End Select

            Return val

         ElseIf val = String.Empty Then
            Return String.Empty

         Else
            Return Nothing
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function RimuoviZero(ByVal val As String) As String
      Const LUNGHEZZA_STRINGA As Integer = 5

      Try
         If val <> Nothing Then
            Select Case val.Length
               Case 1
                  val = val.Remove(0, LUNGHEZZA_STRINGA - val.Length)
               Case 2
                  val = val.Remove(0, LUNGHEZZA_STRINGA - val.Length)
               Case 3
                  val = val.Remove(0, LUNGHEZZA_STRINGA - val.Length)
               Case 4
                  val = val.Remove(0, LUNGHEZZA_STRINGA - val.Length)
               Case Is > 4
                  Exit Function
            End Select

            Return val

         ElseIf val = "" Then
            Return ""

         Else
            Return Nothing
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function RimuoviVirgola(ByVal val As String) As String
      Try
         If val <> Nothing Then
            Dim index As Integer = val.LastIndexOf(",")

            Dim valReturn As String = val.Remove(index, 1)

            Return valReturn

         ElseIf val = "" Then
            Return ""
         Else
            Return Nothing
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function SostituisciVirgola(ByVal val As String) As String
      Try
         If val <> Nothing Then
            ' Rimuovo il segno percentuale.
            If val.Substring(val.Length - 1, 1) = "%" Then
               val = val.Remove(val.Length - 1, 1)
            End If

            ' Sostituisco la virgola con il punto.
            Dim valReturn As String = val.Replace(",", ".")

            Return valReturn

         ElseIf val = "" Then
            Return ""
         Else
            Return Nothing
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function CodAttivazioneInserisciTrattini(ByVal val As String) As String
      Try
         Dim codiceTrattini As String = val.Substring(0, 5) & "-" & val.Substring(5, 5) & "-" & val.Substring(10, 5) & "-" &
                                        val.Substring(15, 5) & "-" & val.Substring(20, 5)

         Return codiceTrattini

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

#End Region

#Region "Operazioni sui controlli"

   Public Function CentraControllo(ByVal ctrlNome As Object, ByVal ctrlContenitore As Object) As Point
      Try
         ' Calcola il centro del controllo da posizionare.
         Dim posX As Integer = Convert.ToInt32(ctrlNome.Width / 2)
         Dim posY As Integer = Convert.ToInt32(ctrlNome.Height / 2)

         ' Calcola il centro del controllo contenitore.
         ' Sottrae la meta del controllo da centrare dal controllo contenitore.
         ' Centra il controllo.
         ctrlNome.Location = New Point(CInt(ctrlContenitore.Width / 2) - posX, CInt(ctrlContenitore.Height / 2) - posY)

         Return ctrlNome.Location

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub MuoviControllo(ByVal ctr As Button, ByVal ctrContenitore As Panel, ByVal nome As String, ByVal eventArg As System.Windows.Forms.MouseEventArgs,
                             ByVal cursorOffset As Point, ByVal frm As Form)
      ' Procedura per lo spostamento di un controllo con il mouse.
      Try
         ' Cambia cursore.
         Cursor.Current = Cursors.SizeAll

         ' Verifica che sia premuto il tasto sinistro del mouse.
         If eventArg.Button = Windows.Forms.MouseButtons.Left Then

            ' Limita lo spostamento del puntatore del mouse all'interno del controllo contenitore.
            Cursor.Clip = ctrContenitore.RectangleToScreen(ctrContenitore.ClientRectangle)

            ' Posizione del cursore rispetto al form.
            Dim newLocation As Point = frm.PointToClient(Cursor.Position)

            ' Coordinate dell'angolo superiore sinistro.
            newLocation.Offset(-cursorOffset.X, -cursorOffset.Y)

            ' Muove il controllo selezionato.
            ctr.Location = New Point(newLocation.X, newLocation.Y)

            ' Visualizza le cordinate all'interno del controllo.
            ctr.Text = nome & vbCrLf & _
                       "X: " & CStr(ctr.Location.X) & vbCrLf & _
                       "Y: " & CStr(ctr.Location.Y)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function CalcolaDimensioneCtrl(ByVal numCtrl As Integer, ByVal dimMax As Integer, ByVal dimSpazio As Integer) As Integer
      Try
         Dim numSpazi As Integer = numCtrl - 1
         Dim spazioUtile As Integer = dimMax - (dimSpazio * numSpazi)
         Dim dimControllo As Integer = (spazioUtile / numCtrl)

         Return dimControllo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function CalcolaPosizioneCtrl(ByVal numCtrl As Integer, ByVal dimSpazio As Integer, ByVal larghezza As Integer) As Integer
      Try
         If numCtrl = 1 Then
            Return dimSpazio

         ElseIf numCtrl > 1 Then
            Return (larghezza * (numCtrl - 1)) + (dimSpazio * numCtrl)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

#End Region

#Region "Calcoli numerici"

   Public Function CalcolaPercentuale(ByVal valNum As Double, ByVal valPerc As Double) As Double
      Try
         Return valNum * valPerc / 100

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function CalcolaPercentuale(ByVal valNum As Decimal, ByVal valPerc As Decimal) As Decimal
      Try
         Return valNum * valPerc / 100

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function CalcolaImponibileIva(ByVal aliquotaIva As String, ByVal valImporto As Double) As Double
      Try
         Dim valImponibile As Double
         Dim valCoefficiente As Double

         Select Case aliquotaIva
            Case "22", "22,00"
               valCoefficiente = 1.22

            Case "10", "10,00"
               valCoefficiente = 1.1

            Case "4", "4,00"
               valCoefficiente = 1.04

            Case Else
               valCoefficiente = 0.0

         End Select

         If valCoefficiente <> 0.0 Then
            valImponibile = (valImporto / valCoefficiente)
         Else
            valImponibile = 0.0
         End If

         Return valImponibile

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0.0
      End Try
   End Function

   Public Function IncrementaId(ByVal ultimoId As String) As Integer
      Dim nuovoId As Integer = Convert.ToInt32(ultimoId) + 1

      Return nuovoId
   End Function

#End Region

#Region "Stampanti "

   Public Sub CaricaListaStampanti(ByVal cmb As ComboBox)
      ' Carica la lista con i nomi delle stampanti installate sul computer.
      Try
         Dim stampantiInstallate As String

         cmb.Items.Add("<Nessuna>")

         Dim i As Integer
         For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            stampantiInstallate = PrinterSettings.InstalledPrinters.Item(i)
            cmb.Items.Add(stampantiInstallate)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaNomeStampante(ByVal indice As Integer) As String
      Try
         Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

         If val(1) <> "<Nessuna>" Then
            Return val(1)
         Else
            Return String.Empty
         End If

      Catch ex As NullReferenceException
         MessageBox.Show("Non è possibile effettuare l'operazione! Verificare nei percorsi di stampa della finestra Opzioni che siano impostate le stampanti.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Exit Function

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function ImpostaNomeDoc(ByVal indice As Integer) As String
      Try
         Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

         If val(2) <> String.Empty Then
            Return val(2)
         Else
            Return String.Empty
         End If

      Catch ex As NullReferenceException
         MessageBox.Show("Non è possibile effettuare l'operazione! Verificare nei percorsi di stampa della finestra Opzioni che siano impostati i reports.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Exit Function

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

#End Region

#Region "Custom KUBE II"

   Public Function StampaComandaKUBEII(ByVal sql As String, ByVal nomeDoc As String, ByVal nomeTavolo As String, _
                                       ByVal nomeCameriereDoc As String, ByVal nomeStampante As String) As Boolean
      Dim i As Integer
      Dim File As String
      Dim Stringa As String
      Dim datiStringa(4) As String
      Dim totComande As Integer

      Dim Kube As New OposPOSPrinter_1_9_Lib.OPOSPOSPrinter

      Dim reportDirectory As String = Application.StartupPath & nomeDoc

      Try
         If reportDirectory <> "" Then
            File = Dir(reportDirectory, vbNormal)
            If File <> "" Then
               FileOpen(1, reportDirectory, OpenMode.Input)

               Do While Not EOF(1)
                  Input(1, Stringa)

                  Dim nomeComando As String() = Stringa.Split(";")

                  Dim y As Integer = 0
                  Dim s As String
                  For Each s In nomeComando
                     datiStringa(y) = s
                     y += 1
                  Next s

                  Select Case datiStringa(0)
                     Case "DeviceName"
                        If datiStringa(1) <> "" Then
                           Dim result As Integer
                           Kube.Open(datiStringa(1))
                        Else
                           MessageBox.Show("Stampante Custom Kube II non trovata.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                     Case "ClaimDevice"
                        If IsNumeric(datiStringa(1)) = True Then
                           Dim val As Integer = Convert.ToInt32(datiStringa(1))
                           Kube.ClaimDevice(val)
                        Else
                           Kube.ClaimDevice(100)
                        End If

                     Case "DeviceEnabled"
                        If datiStringa(1) <> "" Then
                           Dim val As Boolean = Convert.ToBoolean(datiStringa(1))
                           Kube.DeviceEnabled = val
                        Else
                           Kube.DeviceEnabled = True
                        End If

                     Case "PrintBitmap"
                        Const PTR_BM_ASIS As Integer = -11

                        Dim station As Integer
                        If IsNumeric(datiStringa(1)) = True Then
                           station = Convert.ToInt32(datiStringa(1))
                        Else
                           station = 2
                        End If

                        Dim strPosizione As String
                        If datiStringa(2) <> "" Then
                           strPosizione = datiStringa(2)
                        Else
                           strPosizione = -2
                        End If

                        Dim strBmp As String
                        If datiStringa(3) <> "" Then
                           strBmp = datiStringa(3)
                        Else
                           strBmp = ""
                        End If

                        Kube.PrintBitmap(station, Application.StartupPath & "\" & strBmp, PTR_BM_ASIS, Convert.ToInt32(strPosizione))

                     Case "PrintNormal"
                        Dim station As Integer
                        If IsNumeric(datiStringa(1)) = True Then
                           station = Convert.ToInt32(datiStringa(1))
                        Else
                           station = 2
                        End If
                        Dim strTab As String
                        If datiStringa(2) <> "" Then
                           strTab = Strings.Chr(27) & datiStringa(2) & " "
                        Else
                           strTab = ""
                        End If

                        Dim strCampo As String = datiStringa(3)
                        Select Case strCampo

                           Case "Azienda" ' AZIENDA
                              ' Dichiara un oggetto connessione.
                              Dim cn As New OleDbConnection(ConnString)
                              cn.Open()
                              Dim cmd As New OleDbCommand("SELECT * FROM Azienda", cn)
                              Dim dr As OleDbDataReader = cmd.ExecuteReader()
                              Do While dr.Read()
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & Convert.ToString(dr.Item("RagSoc")).ToUpper)
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & Convert.ToString(dr.Item("Indirizzo")).ToUpper)
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & dr.Item("Cap") & " " & Convert.ToString(dr.Item("Città")).ToUpper & " " & Convert.ToString(dr.Item("Prov")).ToUpper)
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & " P.IVA: " & dr.Item("Iva"))
                              Loop
                              cn.Close()

                           Case "Reparto" ' REPARTO
                              ' Dichiara un oggetto connessione.
                              Dim cn As New OleDbConnection(ConnString)
                              cn.Open()
                              Dim cmd As New OleDbCommand(sql, cn)
                              Dim dr As OleDbDataReader = cmd.ExecuteReader()
                              Do While dr.Read()
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & dr.Item("Reparto"))
                                 Exit Do
                              Loop
                              cn.Close()

                           Case "DataOra" ' DATA/ORA
                              Kube.PrintNormal(station, strTab & Strings.StrDup(3, " ") & "Data: " & Today.Date & Strings.StrDup(6, " ") & "Ora: " & DateTime.Now.ToShortTimeString)

                           Case "Tavolo" ' TAVOLO
                              Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & "TAVOLO: " & nomeTavolo)

                           Case "Cameriere" ' CAMERIERE
                              Kube.PrintNormal(station, strTab & Strings.StrDup(5, " ") & "Cameriere: " & nomeCameriereDoc)

                           Case "Coperti" ' COPERTI
                              Kube.PrintNormal(station, strTab & Strings.StrDup(5, " ") & "Coperti:   " & NumCopertiRistorante)

                           Case "RigheComanda" ' RIGHE COMANDA
                              ' Dichiara un oggetto connessione.
                              Dim cn As New OleDbConnection(ConnString)
                              cn.Open()
                              Dim cmd As New OleDbCommand(sql, cn)
                              Dim dr As OleDbDataReader = cmd.ExecuteReader()
                              Do While dr.Read()
                                 Kube.PrintNormal(station, strTab & Strings.StrDup(5, " ") & dr.Item("Quantità") & " " & Convert.ToString(dr.Item("Descrizione")).ToUpper)
                                 Dim quantità As Integer = Convert.ToInt32(dr.Item("Quantità"))
                                 totComande = totComande + quantità
                              Loop
                              cn.Close()

                           Case "TotComande" ' TOTALE COMANDE
                              Kube.PrintNormal(station, strTab & Strings.StrDup(3, " ") & "TOTALE COMANDE: " & totComande.ToString)

                           Case "Linea" ' LINEA
                              Kube.PrintNormal(station, strTab & Strings.StrDup(3, " ") & Strings.StrDup(35, "-"))

                           Case "Spazio" ' SPAZIO
                              Kube.PrintNormal(station, " ")

                           Case Else ' TESTO
                              Kube.PrintNormal(station, strTab & datiStringa(3))

                        End Select

                     Case "PrintImmediate"

                     Case "MarkFeed"
                        If IsNumeric(datiStringa(1)) = True Then
                           Dim type As Integer = Convert.ToInt32(datiStringa(1))
                           Kube.MarkFeed(type)
                        Else
                           Kube.MarkFeed(1)
                        End If

                     Case "CutPaper"
                        If IsNumeric(datiStringa(1)) = True Then
                           Dim percentage As Integer = Convert.ToInt32(datiStringa(1))
                           Kube.CutPaper(percentage)
                        End If

                     Case "Close"
                        Kube.Close()
                  End Select
               Loop
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         FileClose(1)

      End Try
   End Function

   Public Function StampaProformaKUBEII(ByVal sql As String, ByVal nomeDoc As String, ByVal numDoc As String, _
                                      ByVal nomeTavolo As String, ByVal nomeCameriereDoc As String, ByVal nomeStampante As String) As Boolean
      Dim i As Integer
      Dim File As String
      Dim Stringa As String
      Dim datiStringa(4) As String
      Dim totComande As Integer

        Dim Kube As New OposPOSPrinter_1_9_Lib.OPOSPOSPrinter

        Dim reportDirectory As String = Application.StartupPath & nomeDoc

      Try
         If reportDirectory <> "" Then
            File = Dir(reportDirectory, vbNormal)
            If File <> "" Then
               FileOpen(1, reportDirectory, OpenMode.Input)

               Do While Not EOF(1)
                  Input(1, Stringa)

                  Dim nomeComando As String() = Stringa.Split(";")

                  Dim y As Integer = 0
                  Dim s As String
                  For Each s In nomeComando
                     datiStringa(y) = s
                     y += 1
                  Next s

                  Select Case datiStringa(0)
                     Case "DeviceName"
                        If datiStringa(1) <> "" Then
                           Kube.Open(datiStringa(1))
                        Else
                           MessageBox.Show("Stampante Custom Kube II non trovata.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                     Case "ClaimDevice"
                        If IsNumeric(datiStringa(1)) = True Then
                           Dim val As Integer = Convert.ToInt32(datiStringa(1))
                           Kube.ClaimDevice(val)
                        Else
                           Kube.ClaimDevice(100)
                        End If

                     Case "DeviceEnabled"
                        If datiStringa(1) <> "" Then
                           Dim val As Boolean = Convert.ToBoolean(datiStringa(1))
                           Kube.DeviceEnabled = val
                        Else
                           Kube.DeviceEnabled = True
                        End If

                     Case "PrintBitmap"
                        Const PTR_BM_ASIS As Integer = -11

                        Dim station As Integer
                        If IsNumeric(datiStringa(1)) = True Then
                           station = Convert.ToInt32(datiStringa(1))
                        Else
                           station = 2
                        End If

                        Dim strPosizione As String
                        If datiStringa(2) <> "" Then
                           strPosizione = datiStringa(2)
                        Else
                           strPosizione = -2
                        End If

                        Dim strBmp As String
                        If datiStringa(3) <> "" Then
                           strBmp = datiStringa(3)
                        Else
                           strBmp = ""
                        End If

                        Kube.PrintBitmap(station, Application.StartupPath & "\" & strBmp, PTR_BM_ASIS, Convert.ToInt32(strPosizione))

                     Case "PrintNormal"
                        Dim station As Integer
                        If IsNumeric(datiStringa(1)) = True Then
                           station = Convert.ToInt32(datiStringa(1))
                        Else
                           station = 2
                        End If
                        Dim strTab As String
                        If datiStringa(2) <> "" Then
                           strTab = Strings.Chr(27) & datiStringa(2) & " "
                        Else
                           strTab = ""
                        End If

                        Dim strCampo As String = datiStringa(3)
                        Select Case strCampo

                           Case "Azienda" ' AZIENDA
                              ' Dichiara un oggetto connessione.
                              Dim cn As New OleDbConnection(ConnString)
                              cn.Open()
                              Dim cmd As New OleDbCommand("SELECT * FROM Azienda", cn)
                              Dim dr As OleDbDataReader = cmd.ExecuteReader()
                              Do While dr.Read()
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & Convert.ToString(dr.Item("RagSoc")).ToUpper)
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & Convert.ToString(dr.Item("Indirizzo")).ToUpper)
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & dr.Item("Cap") & " " & Convert.ToString(dr.Item("Città")).ToUpper & " " & Convert.ToString(dr.Item("Prov")).ToUpper)
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & " P.IVA: " & dr.Item("Iva"))
                              Loop
                              cn.Close()

                           Case "Proforma" ' PROFORMA
                              ' Dichiara un oggetto connessione.
                              Dim cn As New OleDbConnection(ConnString)
                              cn.Open()
                              Dim cmd As New OleDbCommand("SELECT * FROM Documenti WHERE Id = " & numDoc, cn)
                              Dim dr As OleDbDataReader = cmd.ExecuteReader()
                              Do While dr.Read()
                                 Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & "PROFORMA N. " & dr.Item("NumDoc"))
                              Loop
                              cn.Close()

                           Case "DataOra" ' DATA/ORA
                              Kube.PrintNormal(station, Strings.Chr(27) + "|cA" & strTab & "Data: " & Today.Date & Strings.StrDup(8, " ") & "Ora: " & DateTime.Now.ToShortTimeString)

                           Case "Tavolo" ' TAVOLO
                              Kube.PrintNormal(station, strTab & Strings.StrDup(1, " ") & "Tavolo: " & nomeTavolo)

                           Case "Cameriere" ' CAMERIERE
                              Kube.PrintNormal(station, strTab & Strings.StrDup(1, " ") & "Cameriere: " & nomeCameriereDoc)

                           Case "Coperti" ' COPERTI
                              Kube.PrintNormal(station, strTab & Strings.StrDup(1, " ") & "Coperti:   " & g_frmVCTavoli.lblCoperti.Text)

                           Case "RigheRicevuta" ' RIGHE RICEVUTA
                              Kube.PrintNormal(station, strTab & " QTA' DESCRIZIONE                  TOTALE")

                              Kube.PrintNormal(station, strTab & " " & Strings.StrDup(40, "-"))

                              ' Dichiara un oggetto connessione.
                              Dim cn As New OleDbConnection(ConnString)
                              cn.Open()
                              Dim cmd As New OleDbCommand(sql, cn)
                              Dim dr As OleDbDataReader = cmd.ExecuteReader()
                              Do While dr.Read()
                                 Dim quantità As String = dr.Item("Quantità")
                                 If quantità.Length = 1 Then
                                    quantità = " " & quantità
                                 End If
                                 Dim stringaRighe As String = quantità & "   " & dr.Item("Descrizione")
                                 Dim ImportoNetto As String = CFormatta.FormattaNumeroDouble(dr.Item("ImportoNetto")).PadLeft(40 - stringaRighe.Length, " ")
                                 stringaRighe = stringaRighe & ImportoNetto

                                 Kube.PrintNormal(station, strTab & " " & stringaRighe.ToUpper)
                              Loop
                              cn.Close()

                           Case "TotDocumento" ' TOTALE DOCUMENTO
                              ' Dichiara un oggetto connessione.
                              Dim cn As New OleDbConnection(ConnString)
                              cn.Open()
                              Dim cmd As New OleDbCommand("SELECT * FROM Documenti WHERE Id = " & numDoc, cn)
                              Dim dr As OleDbDataReader = cmd.ExecuteReader()
                              Do While dr.Read()
                                 Dim stringaTotDoc As String = "TOTALE EURO:"
                                 Dim totDoc As String = CFormatta.FormattaNumeroDouble(dr.Item("TotDoc")).PadLeft(40 - stringaTotDoc.Length, " ")
                                 stringaTotDoc = stringaTotDoc & totDoc

                                 Kube.PrintNormal(station, strTab & stringaTotDoc)
                              Loop
                              cn.Close()

                           Case "Linea" ' LINEA
                              Kube.PrintNormal(station, strTab & Strings.StrDup(40, "-"))

                           Case "Spazio" ' SPAZIO
                              Kube.PrintNormal(station, " ")

                           Case Else ' TESTO
                              Kube.PrintNormal(station, strTab & datiStringa(3))

                        End Select

                     Case "PrintImmediate"

                     Case "MarkFeed"
                        If IsNumeric(datiStringa(1)) = True Then
                           Dim type As Integer = Convert.ToInt32(datiStringa(1))
                           Kube.MarkFeed(type)
                        Else
                           Kube.MarkFeed(1)
                        End If

                     Case "CutPaper"
                        If IsNumeric(datiStringa(1)) = True Then
                           Dim percentage As Integer = Convert.ToInt32(datiStringa(1))
                           Kube.CutPaper(percentage)
                        End If

                     Case "Close"
                        Kube.Close()
                  End Select
               Loop
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         FileClose(1)

      End Try
   End Function

   ' NON UTILIZZATA.
   Public Function StampaRicevutaFatturaKUBEII(ByVal nomeDoc As String, ByVal numDoc As String, ByVal nomeStampante As String) As Boolean
      'Dim i As Integer
      'Dim File As String
      'Dim Stringa As String
      'Dim datiStringa(4) As String
      'Dim totComande As Integer

      'Dim reportDirectory As String = Application.StartupPath & nomeDoc

      'Try
      '   If reportDirectory <> "" Then
      '      File = Dir(reportDirectory, vbNormal)
      '      If File <> "" Then
      '         FileOpen(1, reportDirectory, OpenMode.Input)

      '         Do While Not EOF(1)
      '            Input(1, Stringa)

      '            Dim nomeComando As String() = Stringa.Split(";")

      '            Dim y As Integer = 0
      '            Dim s As String
      '            For Each s In nomeComando
      '               datiStringa(y) = s
      '               y += 1
      '            Next s

      '            Select Case datiStringa(0)
      '               Case "DeviceName"
      '                  If datiStringa(1) <> "" Then
      '                     g_frmMain.Kube.Open(datiStringa(1))
      '                  Else
      '                     MessageBox.Show("Stampante Custom Kube II non trovata.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      '                  End If

      '               Case "ClaimDevice"
      '                  If IsNumeric(datiStringa(1)) = True Then
      '                     Dim val As Integer = Convert.ToInt32(datiStringa(1))
      '                     g_frmMain.Kube.ClaimDevice(val)
      '                  Else
      '                     g_frmMain.Kube.ClaimDevice(100)
      '                  End If

      '               Case "DeviceEnabled"
      '                  If datiStringa(1) <> "" Then
      '                     Dim val As Boolean = Convert.ToBoolean(datiStringa(1))
      '                     g_frmMain.Kube.DeviceEnabled = val
      '                  Else
      '                     g_frmMain.Kube.DeviceEnabled = True
      '                  End If

      '               Case "PrintBitmap"
      '                  Const PTR_BM_ASIS As Integer = -11

      '                  Dim station As Integer
      '                  If IsNumeric(datiStringa(1)) = True Then
      '                     station = Convert.ToInt32(datiStringa(1))
      '                  Else
      '                     station = 2
      '                  End If

      '                  Dim strPosizione As String
      '                  If datiStringa(2) <> "" Then
      '                     strPosizione = datiStringa(2)
      '                  Else
      '                     strPosizione = -2
      '                  End If

      '                  Dim strBmp As String
      '                  If datiStringa(3) <> "" Then
      '                     strBmp = datiStringa(3)
      '                  Else
      '                     strBmp = ""
      '                  End If

      '                  g_frmMain.Kube.PrintBitmap(station, Application.StartupPath & "\" & strBmp, PTR_BM_ASIS, Convert.ToInt32(strPosizione))

      '               Case "PrintNormal"
      '                  Dim station As Integer
      '                  If IsNumeric(datiStringa(1)) = True Then
      '                     station = Convert.ToInt32(datiStringa(1))
      '                  Else
      '                     station = 2
      '                  End If
      '                  Dim strTab As String
      '                  If datiStringa(2) <> "" Then
      '                     strTab = Strings.Chr(27) & datiStringa(2) & " "
      '                  Else
      '                     strTab = ""
      '                  End If

      '                  Dim strCampo As String = datiStringa(3)
      '                  Select Case strCampo
      '                     Case "Report" ' REPORTS.RPT
      '                        Dim nomeDocRep As String = "\Reports\" & strTab.Remove(0, 1)
      '                        ' Esegue la stampa.
      '                        g_frmContoPos.StampaDocumento(nomeDocRep, numDoc, nomeStampante)

      '                     Case "Linea" ' LINEA
      '                        g_frmMain.Kube.PrintNormal(station, strTab & Strings.StrDup(40, "-"))

      '                     Case "Spazio" ' SPAZIO
      '                        g_frmMain.Kube.PrintNormal(station, " ")

      '                     Case Else ' TESTO
      '                        g_frmMain.Kube.PrintNormal(station, strTab & datiStringa(3))

      '                  End Select

      '               Case "MarkFeed"
      '                  If IsNumeric(datiStringa(1)) = True Then
      '                     Dim type As Integer = Convert.ToInt32(datiStringa(1))
      '                     g_frmMain.Kube.MarkFeed(type)
      '                  Else
      '                     g_frmMain.Kube.MarkFeed(1)
      '                  End If

      '               Case "CutPaper"
      '                  If IsNumeric(datiStringa(1)) = True Then
      '                     Dim percentage As Integer = Convert.ToInt32(datiStringa(1))
      '                     g_frmMain.Kube.CutPaper(percentage)
      '                  End If

      '               Case "Close"
      '                  g_frmMain.Kube.Close()
      '            End Select
      '         Loop
      '      End If
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   FileClose(1)

      'End Try
   End Function

#End Region

#Region "Pen Drive Recovery"

   Public Sub PenDriveRecovery(ByVal cartellaDestinazione As String, ByVal percorsoRecoveryConfig As String, ByVal dataRecoveryConfig As String,
                               ByVal attivaRecoveryConfig As String, ByVal nomeFileExe As String, ByVal nomeFileMsi As String, ByVal nomeFileRecovery As String)
      Try
         Dim DatiConfig As New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim percorsoPenDrive As String = DatiConfig.GetValue(percorsoRecoveryConfig)
         Dim DirectoryOrigine As String = Application.StartupPath
         Dim DirectoryDestinazione As String = percorsoPenDrive & cartellaDestinazione

         If DatiConfig.GetValue(attivaRecoveryConfig) = True Then
            If Directory.Exists(percorsoPenDrive) = False Then
               Exit Sub
            Else
               ' Copia tutti i file e le directory.
               My.Computer.FileSystem.CopyDirectory(DirectoryOrigine, DirectoryDestinazione, True)

               ' Elimina il file .exe del programma.
               If File.Exists(DirectoryDestinazione & "\" & nomeFileExe) = True Then
                  My.Computer.FileSystem.DeleteFile(DirectoryDestinazione & "\" & nomeFileExe)
               End If

               ' Copia il file del pacchetto di installazione per la creazione dei collegamenti.
               If File.Exists(Application.StartupPath & "\Recovery\" & nomeFileMsi) = True Then
                  My.Computer.FileSystem.CopyFile(Application.StartupPath & "\Recovery\" & nomeFileMsi, percorsoPenDrive & "\Hospitality Solution Recovery\" & nomeFileMsi, True)
               End If

               ' Copia il file .EXE l'esecuzione del recupero dei file.
               If File.Exists(Application.StartupPath & "\Recovery\" & nomeFileRecovery) = True Then
                  My.Computer.FileSystem.CopyFile(Application.StartupPath & "\Recovery\" & nomeFileRecovery, percorsoPenDrive & "\Hospitality Solution Recovery\" & nomeFileRecovery, True)
               End If

               DatiConfig.SetValue(dataRecoveryConfig, Today.ToLongDateString)

            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Offusca Password"

   Public Function LeggiPwd(ByVal pwd As String) As String
      Try
         Dim caratteri As String
         Dim i As Integer = 0
         Dim y As Integer = 1

         Dim lunghezzaPwd As Integer = (pwd.Length - 150)

         For i = 0 To lunghezzaPwd - 1
            caratteri = caratteri & pwd.Substring(i + y, 1)
            y += 1
         Next

         Return caratteri

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function OffuscaPwd(ByVal pwd As String) As String
      Try
         Const stringaCaratteri As String = "ABCDEFGHIJKLMNOPQRSTUVWXJZabcdefghijklmnopqrstuvwxjz0123456789"
         Dim caratteri As String
         Dim i As Integer = 0
         Dim y As Integer = 1

         For i = 1 To 150
            caratteri = caratteri & GeneraCarattere(stringaCaratteri)
         Next

         For i = 0 To pwd.Length - 1
            caratteri = caratteri.Insert(i + y, pwd.Substring(i, 1))
            y += 1
         Next

         Return caratteri

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function GeneraCarattere(ByVal setCaratteri As String) As String
      Try
         Dim startPos As Integer = CRandom.Next(1, setCaratteri.Length)
         Dim val As String = setCaratteri.Substring(startPos - 1, 1)

         Return val

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function


#End Region

#Region "Fatturazione Elettronica "

   Public Function FormattaProvincia(ByVal provincia As String)
      Try
         Select Case provincia.ToUpper
            Case "AG"
               Return "AG Agrigento"
            Case "AL"
               Return "AL Alessandria"
            Case "AN"
               Return "AN Ancona"
            Case "AO"
               Return "AO Aosta"
            Case "AR"
               Return "AR Arezzo"
            Case "AP"
               Return "AP Ascoli Piceno"
            Case "AT"
               Return "AT Asti"
            Case "AV"
               Return "AV Avellino"
            Case "BA"
               Return "BA Bari"
            Case "BT"
               Return "BT Barletta - Andria - Trani"
            Case "BL"
               Return "BL Belluno"
            Case "BN"
               Return "BN Benevento"
            Case "BG"
               Return "BG Bergamo"
            Case "BI"
               Return "BI Biella"
            Case "BO"
               Return "BO Bologna"
            Case "BZ"
               Return "BZ Bolzano"
            Case "BS"
               Return "BS Brescia"
            Case "BR"
               Return "BR Brindisi"
            Case "CA"
               Return "CA Cagliari"
            Case "CL"
               Return "CL Caltanissetta"
            Case "CB"
               Return "CB Campobasso"
            Case "CI"
               Return "CI Carbonia - Iglesias"
            Case "CE"
               Return "CE Caserta"
            Case "CT"
               Return "CT Catania"
            Case "CZ"
               Return "CZ Catanzaro"
            Case "CH"
               Return "CH Chieti"
            Case "CO"
               Return "CO Como"
            Case "CS"
               Return "CS Cosenza"
            Case "CR"
               Return "CR Cremona"
            Case "KR"
               Return "KR Crotone"
            Case "CN"
               Return "CN Cuneo"
            Case "EN"
               Return "EN Enna"
            Case "FM"
               Return "FM Fermo"
            Case "FE"
               Return "FE Ferrara"
            Case "FI"
               Return "FI Firenze"
            Case "FU"
               Return "FU Fiume"
            Case "FG"
               Return "FG Foggia"
            Case "FC"
               Return "FC Forlì - Cesena"
            Case "FR"
               Return "FR Frosinone"
            Case "GE"
               Return "GE Genova"
            Case "GO"
               Return "GO Gorizia"
            Case "GR"
               Return "GR Grosseto"
            Case "IM"
               Return "IM Imperia"
            Case "IS"
               Return "IS Isernia"
            Case "AQ"
               Return "AQ L'Aquila"
            Case "SP"
               Return "SP La Spezia"
            Case "LT"
               Return "LT Latina"
            Case "LE"
               Return "LE Lecce"
            Case "LC"
               Return "LC Lecco"
            Case "LI"
               Return "LI Livorno"
            Case "LO"
               Return "LO Lodi"
            Case "LB"
               Return "LB Lubiana"
            Case "LU"
               Return "LU Lucca"
            Case "MC"
               Return "MC Macerata"
            Case "MN"
               Return "MN Mantova"
            Case "MS"
               Return "MS Massa - Carrara"
            Case "MT"
               Return "MT Matera"
            Case "VS"
               Return "VS Medio Campidano"
            Case "ME"
               Return "ME Messina"
            Case "MI"
               Return "MI Milano"
            Case "MO"
               Return "MO Modena"
            Case "MB"
               Return "MB Monza e Brianza"
            Case "NA"
               Return "NA Napoli"
            Case "NO"
               Return "NO Novara"
            Case "NU"
               Return "NU Nuoro"
            Case "OG"
               Return "OG Ogliastra"
            Case "OT"
               Return "OT Olbia - Tempio"
            Case "OR"
               Return "OR Oristano"
            Case "PD"
               Return "PD Padova"
            Case "PA"
               Return "PA Palermo"
            Case "PR"
               Return "PR Parma"
            Case "PV"
               Return "PV Pavia"
            Case "PG"
               Return "PG Perugia"
            Case "PU"
               Return "PU Pesaro e Urbino"
            Case "PE"
               Return "PE Pescara"
            Case "PC"
               Return "PC Piacenza"
            Case "PI"
               Return "PI Pisa"
            Case ""
               Return "PT Pistoia"
            Case "PL"
               Return "PL Pola"
            Case "PN"
               Return "PN Pordenone"
            Case "PZ"
               Return "PZ Potenza"
            Case "PO"
               Return "PO Prato"
            Case "RG"
               Return "RG Ragusa"
            Case "RA"
               Return "RA Ravenna"
            Case "RC"
               Return "RC Reggio di Calabria"
            Case "RE"
               Return "RE Reggio nell'Emilia"
            Case "RI"
               Return "RI Rieti"
            Case "RN"
               Return "RN Rimini"
            Case "RM"
               Return "RM Roma"
            Case "RO"
               Return "RO Rovigo"
            Case "SA"
               Return "SA Salerno"
            Case "SS"
               Return "SS Sassari"
            Case "SV"
               Return "SV Savona"
            Case "SI"
               Return "SI Siena"
            Case "SR"
               Return "SR Siracusa"
            Case "SO"
               Return "SO Sondrio"
            Case "SU"
               Return "SU Sud Sardegna"
            Case "TA"
               Return "TA Taranto"
            Case "TE"
               Return "TE Teramo"
            Case "TR"
               Return "TR Terni"
            Case "TO"
               Return "TO Torino"
            Case "TP"
               Return "TP Trapani"
            Case "TN"
               Return "TN Trento"
            Case "TV"
               Return "TV Treviso"
            Case "TS"
               Return "TS Trieste"
            Case "UD"
               Return "UD Udine"
            Case "VA"
               Return "VA Varese"
            Case "VE"
               Return "VE Venezia"
            Case "VB"
               Return "VB Verbano - Cusio - Ossola"
            Case "VC"
               Return "VC Vercelli"
            Case "VR"
               Return "VR Verona"
            Case "VV"
               Return "VV Vibo Valentia"
            Case "VI"
               Return "VI Vicenza"
            Case "VT"
               Return "VT Viterbo"
            Case "ZA"
               Return "ZA Zara"
            Case Else
               Return String.Empty
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function FormattaStato(ByVal stato As String)
      Try
         Select Case stato.ToUpper
            Case "Andorra".ToUpper
               Return "AD Andorra"
            Case "Emirati Arabi Uniti".ToUpper
               Return "AE Emirati Arabi Uniti"
            Case "Afghanistan".ToUpper
               Return "AF Afghanistan"
            Case "Antigua e Barbuda".ToUpper
               Return "AG Antigua e Barbuda"
            Case "Anguilla".ToUpper
               Return "AI Anguilla"
            Case "Albania".ToUpper
               Return "AL Albania"
            Case "Armenia".ToUpper
               Return "AM Armenia"
            Case "Angola".ToUpper
               Return "AO Angola"
            Case "Antartide".ToUpper
               Return "AQ Antartide"
            Case "Argentina".ToUpper
               Return "AR Argentina"
            Case "Samoa Americane".ToUpper
               Return "AS Samoa Americane"
            Case "Austria".ToUpper
               Return "AT Austria"
            Case "Australia".ToUpper
               Return "AU Australia"
            Case "Aruba".ToUpper
               Return "AW Aruba"
            Case "Isole Åland".ToUpper
               Return "AX Isole Åland"
            Case "Azerbaigian".ToUpper
               Return "AZ Azerbaigian"
            Case "Bosnia ed Erzegovina".ToUpper
               Return "BA Bosnia ed Erzegovina"
            Case "Barbados".ToUpper
               Return "BB Barbados"
            Case "Bangladesh".ToUpper
               Return "BD Bangladesh"
            Case "Belgio".ToUpper
               Return "BE Belgio"
            Case "Burkina Faso".ToUpper
               Return "BF Burkina Faso"
            Case "Bulgaria".ToUpper
               Return "BG Bulgaria"
            Case "Bahrein".ToUpper
               Return " BH Bahrein"
            Case "Burundi".ToUpper
               Return "BI Burundi"
            Case "Benin".ToUpper
               Return "BJ Benin"
            Case "Saint - Barthélemy".ToUpper
               Return "BL Saint - Barthélemy"
            Case "Bermuda".ToUpper
               Return "BM Bermuda"
            Case "Brunei".ToUpper
               Return "BN Brunei"
            Case "Bolivia".ToUpper
               Return "BO Bolivia"
            Case "Isole BES".ToUpper
               Return "BQ Isole BES"
            Case "Brasile".ToUpper
               Return "BR Brasile"
            Case "Bahamas".ToUpper
               Return "BS Bahamas"
            Case "Bhutan".ToUpper
               Return "BT Bhutan"
            Case "Isola Bouvet".ToUpper
               Return "BV Isola Bouvet"
            Case "Botswana".ToUpper
               Return "BW Botswana"
            Case "Bielorussia".ToUpper
               Return "BY Bielorussia"
            Case "Belize".ToUpper
               Return "BZ Belize"
            Case "Canada".ToUpper
               Return "CA Canada"
            Case "Isole Cocos e Keeling".ToUpper
               Return "CC Isole Cocos e Keeling"
            Case "Repubblica Democratica del Congo".ToUpper
               Return "CD Repubblica Democratica del Congo"
            Case "Repubblica Centrafricana".ToUpper
               Return "CF Repubblica Centrafricana"
            Case "Repubblica del Congo".ToUpper
               Return "CG Repubblica del Congo"
            Case "Svizzera".ToUpper
               Return "CH Svizzera"
            Case "Costa d'Avorio".ToUpper
               Return "CI Costa d'Avorio"
            Case "Isole Cook".ToUpper
               Return "CK Isole Cook"
            Case "Cile".ToUpper
               Return "CL Cile"
            Case "Camerun".ToUpper
               Return "CM Camerun"
            Case "Cina".ToUpper
               Return "CN Cina"
            Case "Colombia".ToUpper
               Return "CO Colombia"
            Case "Costa Rica".ToUpper
               Return "CR Costa Rica"
            Case "Cuba".ToUpper
               Return "CU Cuba"
            Case "Capo Verde".ToUpper
               Return "CV Capo Verde"
            Case "Curaçao".ToUpper
               Return "CW Curaçao"
            Case "Isola del Natale".ToUpper
               Return "CX Isola del Natale"
            Case "Cipro".ToUpper
               Return "CY Cipro"
            Case "Repubblica Ceca".ToUpper
               Return "CZ Repubblica Ceca"
            Case "Germania".ToUpper
               Return "DE Germania"
            Case "Gibuti".ToUpper
               Return "DJ Gibuti"
            Case "Danimarca".ToUpper
               Return "DK Danimarca"
            Case "Dominica".ToUpper
               Return "DM Dominica"
            Case "Repubblica Dominicana".ToUpper
               Return "Do Repubblica Dominicana"
            Case "Algeria".ToUpper
               Return "DZ Algeria"
            Case "Ecuador".ToUpper
               Return "EC Ecuador"
            Case "Estonia".ToUpper
               Return "EE Estonia"
            Case "Egitto".ToUpper
               Return "EG Egitto"
            Case "Sahara Occidentale".ToUpper
               Return "EH Sahara Occidentale"
            Case "Eritrea".ToUpper
               Return "ER Eritrea"
            Case "Spagna".ToUpper
               Return "ES Spagna"
            Case "Etiopia".ToUpper
               Return "ET Etiopia"
            Case "Finlandia".ToUpper
               Return "FI Finlandia"
            Case "Figi".ToUpper
               Return "FJ Figi"
            Case "Isole Falkland".ToUpper
               Return "FK Isole Falkland"
            Case "Stati Federati di Micronesia".ToUpper
               Return "FM Stati Federati di Micronesia"
            Case "Isole Fær Øer".ToUpper
               Return "FO Isole Fær Øer"
            Case "Francia".ToUpper
               Return "FR Francia"
            Case "Gabon".ToUpper
               Return "GA Gabon"
            Case "Regno Unito".ToUpper
               Return "GB Regno Unito"
            Case "Grenada".ToUpper
               Return "GD Grenada"
            Case "Georgia".ToUpper
               Return "GE Georgia"
            Case "Guyana francese".ToUpper
               Return "GF Guyana francese"
            Case "Guernsey".ToUpper
               Return "GG Guernsey"
            Case "Ghana".ToUpper
               Return "GH Ghana"
            Case "Gibilterra".ToUpper
               Return "GI Gibilterra"
            Case "Groenlandia".ToUpper
               Return "GL Groenlandia"
            Case "Gambia".ToUpper
               Return "GM Gambia"
            Case "Guinea".ToUpper
               Return "GN Guinea"
            Case "Guadalupa".ToUpper
               Return "GP Guadalupa"
            Case "Guinea Equatoriale".ToUpper
               Return "GQ Guinea Equatoriale"
            Case "Grecia".ToUpper
               Return "GR Grecia"
            Case "Georgia del Sud e isole Sandwich meridionali".ToUpper
               Return "GS Georgia del Sud e isole Sandwich meridionali"
            Case "Guatemala".ToUpper
               Return "GT Guatemala"
            Case "Guam".ToUpper
               Return "GU Guam"
            Case "Guinea - Bissau".ToUpper
               Return "GW Guinea - Bissau"
            Case "Guyana".ToUpper
               Return "GY Guyana"
            Case "Hong Kong".ToUpper
               Return "HK Hong Kong"
            Case "Isole Heard e McDonald".ToUpper
               Return "HM Isole Heard e McDonald"
            Case "Honduras".ToUpper
               Return "HN Honduras"
            Case "Croazia".ToUpper
               Return "HR Croazia"
            Case "Haiti".ToUpper
               Return "HT Haiti"
            Case "Ungheria".ToUpper
               Return "HU Ungheria"
            Case "Indonesia".ToUpper
               Return "ID Indonesia"
            Case "Irlanda".ToUpper
               Return "IE Irlanda"
            Case "Israele".ToUpper
               Return "IL Israele"
            Case "Isola di Man".ToUpper
               Return "IM Isola di Man"
            Case "India".ToUpper
               Return "IN India"
            Case "Territori Britannici dell'Oceano Indiano".ToUpper
               Return "IO Territori Britannici dell'Oceano Indiano"
            Case "Iraq".ToUpper
               Return "IQ Iraq"
            Case "Iran".ToUpper
               Return "IR Iran"
            Case "Islanda".ToUpper
               Return "Is Islanda"
            Case "Italia".ToUpper
               Return "IT Italia"
            Case "Jersey".ToUpper
               Return "JE Jersey"
            Case "Giamaica".ToUpper
               Return "JM Giamaica"
            Case "Giordania".ToUpper
               Return "JO Giordania"
            Case "Giappone".ToUpper
               Return "JP Giappone"
            Case "Kenya".ToUpper
               Return "KE Kenya"
            Case "Cambogia".ToUpper
               Return "KH Cambogia"
            Case "Kiribati".ToUpper
               Return "KI Kiribati"
            Case "Comore".ToUpper
               Return "KM Comore"
            Case "Saint Kitts e Nevis".ToUpper
               Return "KN Saint Kitts e Nevis"
            Case "Corea del Nord".ToUpper
               Return "KP Corea del Nord"
            Case "Corea del Sud".ToUpper
               Return "KR Corea del Sud"
            Case "Kuwait".ToUpper
               Return "KW Kuwait"
            Case "Isole Cayman".ToUpper
               Return "KY Isole Cayman"
            Case "Kazakistan".ToUpper
               Return "KZ Kazakistan"
            Case "Laos".ToUpper
               Return "LA Laos"
            Case "Libano".ToUpper
               Return "LB Libano"
            Case "Santa Lucia".ToUpper
               Return "LC Santa Lucia"
            Case "Liechtenstein".ToUpper
               Return "LI Liechtenstein"
            Case "Sri Lanka".ToUpper
               Return "LK Sri Lanka"
            Case "Liberia".ToUpper
               Return "LR Liberia"
            Case "Lesotho".ToUpper
               Return "LS Lesotho"
            Case "Lituania".ToUpper
               Return "LT Lituania"
            Case "Lussemburgo".ToUpper
               Return "LU Lussemburgo"
            Case "Lettonia".ToUpper
               Return "LV Lettonia"
            Case "Libia".ToUpper
               Return "LY Libia"
            Case "Marocco".ToUpper
               Return "MA Marocco"
            Case "Monaco".ToUpper
               Return "MC Monaco"
            Case "Moldavia".ToUpper
               Return "MD Moldavia"
            Case "Montenegro".ToUpper
               Return "Me Montenegro"
            Case "Saint - Martin".ToUpper
               Return "MF Saint - Martin"
            Case "Madagascar".ToUpper
               Return "MG Madagascar"
            Case "Isole Marshall".ToUpper
               Return "MH Isole Marshall"
            Case "Macedonia".ToUpper
               Return "MK Macedonia"
            Case "Mali".ToUpper
               Return "ML Mali"
            Case "Birmania".ToUpper
               Return "MM Birmania"
            Case "Mongolia".ToUpper
               Return "MN Mongolia"
            Case "Macao".ToUpper
               Return "MO Macao"
            Case "Isole Marianne Settentrionali".ToUpper
               Return "MP Isole Marianne Settentrionali"
            Case "Martinica".ToUpper
               Return "MQ Martinica"
            Case "Mauritania".ToUpper
               Return "MR Mauritania"
            Case "Montserrat".ToUpper
               Return "MS Montserrat"
            Case "Malta".ToUpper
               Return "MT Malta"
            Case "Mauritius".ToUpper
               Return "MU Mauritius"
            Case "Maldive".ToUpper
               Return "MV Maldive"
            Case "Malawi".ToUpper
               Return "MW Malawi"
            Case "Messico".ToUpper
               Return "MX Messico"
            Case "Malaysia".ToUpper
               Return "My Malaysia"
            Case "Mozambico".ToUpper
               Return "MZ Mozambico"
            Case "Namibia".ToUpper
               Return "NA Namibia"
            Case "Nuova Caledonia".ToUpper
               Return "NC Nuova Caledonia"
            Case "Niger".ToUpper
               Return "NE Niger"
            Case "Isola Norfolk".ToUpper
               Return "NF Isola Norfolk"
            Case "Nigeria".ToUpper
               Return "NG Nigeria"
            Case "Nicaragua".ToUpper
               Return "NI Nicaragua"
            Case "Paesi Bassi".ToUpper
               Return "NL Paesi Bassi"
            Case "Norvegia".ToUpper
               Return "NO Norvegia"
            Case "Nepal".ToUpper
               Return "NP Nepal"
            Case "Nauru".ToUpper
               Return "NR Nauru"
            Case "Niue".ToUpper
               Return "NU Niue"
            Case "Nuova Zelanda".ToUpper
               Return "NZ Nuova Zelanda"
            Case "Oman".ToUpper
               Return "OM Oman"
            Case "Panama".ToUpper
               Return "PA Panama"
            Case "Perù".ToUpper
               Return "PE Perù"
            Case "Polinesia Francese".ToUpper
               Return "PF Polinesia Francese"
            Case "Papua Nuova Guinea".ToUpper
               Return "PG Papua Nuova Guinea"
            Case "Filippine".ToUpper
               Return "PH Filippine"
            Case "Pakistan".ToUpper
               Return "PK Pakistan"
            Case "Polonia".ToUpper
               Return "PL Polonia"
            Case "Saint - Pierre e Miquelon".ToUpper
               Return "PM Saint - Pierre e Miquelon"
            Case "Isole Pitcairn".ToUpper
               Return "PN Isole Pitcairn"
            Case "Porto Rico".ToUpper
               Return "PR Porto Rico"
            Case "Stato di Palestina".ToUpper
               Return "PS stato di Palestina"
            Case "Portogallo".ToUpper
               Return "PT Portogallo"
            Case "Palau".ToUpper
               Return "PW Palau"
            Case "Paraguay".ToUpper
               Return "PY Paraguay"
            Case "Qatar".ToUpper
               Return "QA Qatar"
            Case "Riunione".ToUpper
               Return "RE Riunione"
            Case "Romania".ToUpper
               Return "RO Romania"
            Case "Serbia".ToUpper
               Return "RS Serbia"
            Case "Russia".ToUpper
               Return "RU Russia"
            Case "Ruanda".ToUpper
               Return "RW Ruanda"
            Case "Arabia Saudita".ToUpper
               Return "SA Arabia Saudita"
            Case "Isole Salomone".ToUpper
               Return "SB Isole Salomone"
            Case "Seychelles".ToUpper
               Return "SC Seychelles"
            Case "Sudan".ToUpper
               Return "SD Sudan"
            Case "Svezia".ToUpper
               Return "SE Svezia"
            Case "Singapore".ToUpper
               Return "SG Singapore"
            Case "Sant'Elena, Isola di Ascensione e Tristan da Cunha".ToUpper
               Return "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha"
            Case "Slovenia".ToUpper
               Return "SI Slovenia"
            Case "Svalbard e Jan Mayen".ToUpper
               Return "SJ Svalbard e Jan Mayen"
            Case "Slovacchia".ToUpper
               Return "SK Slovacchia"
            Case "Sierra Leone".ToUpper
               Return "SL Sierra Leone"
            Case "San Marino".ToUpper
               Return "SM San Marino"
            Case "Senegal".ToUpper
               Return "SN Senegal"
            Case "Somalia".ToUpper
               Return "SO Somalia"
            Case "Suriname".ToUpper
               Return "SR Suriname"
            Case "Sudan del Sud".ToUpper
               Return "SS Sudan del Sud"
            Case "São Tomé e Príncipe".ToUpper
               Return "ST São Tomé e Príncipe"
            Case "El Salvador".ToUpper
               Return "SV El Salvador"
            Case "Sint Maarten".ToUpper
               Return "SX Sint Maarten"
            Case "Siria".ToUpper
               Return "SY Siria"
            Case "Swaziland".ToUpper
               Return "SZ Swaziland"
            Case "Isole Turks e Caicos".ToUpper
               Return "TC Isole Turks e Caicos"
            Case "Ciad".ToUpper
               Return "TD Ciad"
            Case "Territori Francesi del Sud".ToUpper
               Return "TF Territori Francesi del Sud"
            Case "Togo".ToUpper
               Return "TG Togo"
            Case "Thailandia".ToUpper
               Return "TH Thailandia"
            Case "Tagikistan".ToUpper
               Return "TJ Tagikistan"
            Case "Tokelau".ToUpper
               Return "TK Tokelau"
            Case "Timor Est".ToUpper
               Return "TL Timor Est"
            Case "Turkmenistan".ToUpper
               Return "TM Turkmenistan"
            Case "Tunisia".ToUpper
               Return "TN Tunisia"
            Case "Tonga".ToUpper
               Return "TO Tonga"
            Case "Turchia".ToUpper
               Return "TR Turchia"
            Case "Trinidad e Tobago".ToUpper
               Return "TT Trinidad e Tobago"
            Case "Tuvalu".ToUpper
               Return "TV Tuvalu"
            Case "Repubblica di Cina".ToUpper
               Return "TW Repubblica di Cina"
            Case "Tanzania".ToUpper
               Return "TZ Tanzania"
            Case "Ucraina".ToUpper
               Return "UA Ucraina"
            Case "Uganda".ToUpper
               Return "UG Uganda"
            Case "Isole minori esterne degli Stati Uniti".ToUpper
               Return "UM Isole minori esterne degli Stati Uniti"
            Case "Stati Uniti d'America".ToUpper
               Return "US Stati Uniti d'America"
            Case "Uruguay".ToUpper
               Return "UY Uruguay"
            Case "Uzbekistan".ToUpper
               Return "UZ Uzbekistan"
            Case "Città del Vaticano".ToUpper
               Return "VA Città del Vaticano"
            Case "Saint Vincent e Grenadine".ToUpper
               Return "VC Saint Vincent e Grenadine"
            Case "Venezuela".ToUpper
               Return "VE Venezuela"
            Case "Isole Vergini britanniche".ToUpper
               Return "VG Isole Vergini britanniche"
            Case "Isole Vergini americane".ToUpper
               Return "VI Isole Vergini americane"
            Case "Vietnam".ToUpper
               Return "VN Vietnam"
            Case "Vanuatu".ToUpper
               Return "VU Vanuatu"
            Case "Wallis e Futuna".ToUpper
               Return "WF Wallis e Futuna"
            Case "Samoa".ToUpper
               Return "WS Samoa"
            Case "Yemen".ToUpper
               Return "YE Yemen"
            Case "Mayotte".ToUpper
               Return "YT Mayotte"
            Case "Sudafrica".ToUpper
               Return "ZA Sudafrica"
            Case "Zambia".ToUpper
               Return "ZM Zambia"
            Case "Zimbabwe".ToUpper
               Return "ZW Zimbabwe"
            Case Else
               Return String.Empty
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

#End Region


#Region "Varie"

   Public Function InserisciChiaveAccesso() As Boolean
      'Try
      '   ' Nella versione dimostrativa chiede l'inserimento di una chiave di accesso.
      '   Dim KeyAccess As String
      '   DatiConfig = New AppConfig
      '   DatiConfig.ConfigType = ConfigFileType.AppConfig
      '   KeyAccess = DatiConfig.GetValue("KeyAccess")

      '   If KeyAccess.ToUpper = "" Then
      '      Dim frm As New CodAccesso
      '      If frm.ShowDialog = DialogResult.OK Then
      '         Return True
      '      Else
      '         Return False
      '      End If
      '   ElseIf KeyAccess.ToUpper <> CHIAVE_ACCESSO Then
      '      Dim frm As New CodAccesso
      '      If frm.ShowDialog() = DialogResult.OK Then
      '         Return True
      '      Else
      '         Return False
      '      End If
      '   End If

      '   Return True

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)
      'End Try
   End Function

   Public Function InserisciChiaveAttivazione() As Boolean
      Try
         ' Nella versione dimostrativa chiede l'inserimento di una chiave di accesso.
         Dim KeyAccess As String
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         KeyAccess = DatiConfig.GetValue("KeyAccess")

         If KeyAccess.ToUpper = "" Then
            Dim frm As New CodAccesso
            If frm.ShowDialog = DialogResult.OK Then
               Dim risposta As DialogResult
               risposta = MessageBox.Show("La licenza per questa versione del software è stata attivata con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
               Return True
            Else
               Return False
            End If
         ElseIf KeyAccess.ToUpper <> GeneraChiaveLicenza() Then
            Dim frm As New CodAccesso
            If frm.ShowDialog() = DialogResult.OK Then
               Dim risposta As DialogResult
               risposta = MessageBox.Show("La licenza per questa versione del software è stata attivata con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
               Return True
            Else
               Return False
            End If
         End If

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function VisIntestazione(ByVal Val1 As String, ByVal Val2 As String, ByVal Val3 As String) As String
      ' Visualizza nell'intestazione della finestra
      ' il codice e la ragione sociale.
      Try
         If Val2 = "" And Val3 = "" Then
            VisIntestazione = Val1
         ElseIf Val1 = "" And Val2 <> "" Then
            VisIntestazione = Val2 & " " & Val3
         Else
            VisIntestazione = Val1 & " - " & Val2 & " " & Val3
         End If

         If VisIntestazione = " -  " Then
            VisIntestazione = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Sub ConvalidaCampi(ByVal s As String, ByVal oggetto As Object, ByVal errProvider As ErrorProvider)
      Try
         Const TEXT_INFO = "Inserire solo valori numerici da 0 a 9."

         If s = "" Then
            errProvider.SetError(oggetto, "")
         ElseIf IsNumeric(s) = False Then
            errProvider.SetError(oggetto, TEXT_INFO)
         Else
            If s.IndexOfAny("+-", 1) <> -1 Then
               errProvider.SetError(oggetto, TEXT_INFO)
            Else
               errProvider.SetError(oggetto, "")
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub VisNomeAzienda(ByVal frm As Form, ByVal nome As String)
      ' Visualizza il nome dell'azienda nella barra del titolo dell'applicazione.
      frm.Text = NOME_PRODOTTO & " - " & nome.ToUpper
   End Sub

   Public Function AssegnaColore(ByVal Val As String, ByVal tabella As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & Val & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         dr.Read()
         Return dr.Item("Colore")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub ApriRegistroErrori(ByVal frmHandle As IntPtr)
      Const NOME_APP As String = "NOTEPAD.EXE"
      Dim Percorso As String
      Dim Proc As New Process

      Try
         ' Percorso del file.
         Percorso = Application.StartupPath & PERCORSO_ERRORI

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NOME_APP
         Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = frmHandle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ApriExplorer(ByVal frmHandle As IntPtr)
      Const NOME_APP As String = "EXPLORER.EXE"
      Dim Percorso As String
      Dim Proc As New Process

      Try
         ' Percorso del file.
         Percorso = Application.StartupPath & "\Database"

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NOME_APP
         Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = frmHandle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub SpostaElememtoSu(ByVal lstBox As ListBox)
      Try
         Dim NomeElemento As String
         Dim IndiceElemento As Integer
         Dim ElementoIncrementato As Integer

         ' Sposta verso l'alto l'elemento selezionato.
         NomeElemento = lstBox.Text
         IndiceElemento = lstBox.SelectedIndex

         If IndiceElemento = -1 Then
            Exit Sub
         ElseIf IndiceElemento = 0 Then
            Exit Sub
         Else
            ElementoIncrementato = IndiceElemento - 1
            lstBox.Items.RemoveAt(IndiceElemento)
            lstBox.Items.Insert(ElementoIncrementato, NomeElemento)
            lstBox.SelectedIndex = ElementoIncrementato
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub SpostaElememtoGiù(ByVal lstBox As ListBox)
      Try
         Dim NomeElemento As String
         Dim IndiceElemento As Integer
         Dim NumElementi As Integer
         Dim ElementoIncrementato As Integer

         ' Sposta verso il basso l'elemento selezionato.
         NomeElemento = lstBox.Text
         IndiceElemento = lstBox.SelectedIndex
         NumElementi = lstBox.Items.Count - 1

         If IndiceElemento = -1 Then
            Exit Sub
         ElseIf IndiceElemento = NumElementi Then
            Exit Sub
         Else
            ElementoIncrementato = IndiceElemento + 1
            lstBox.Items.RemoveAt(IndiceElemento)
            lstBox.Items.Insert(ElementoIncrementato, NomeElemento)
            lstBox.SelectedIndex = ElementoIncrementato
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Function ConfrontaColore(ByVal coloreA As Color, ByVal coloreB As Color, ByVal coloreC As Color) As Boolean
      Try
         Dim colore1 As String = Convert.ToString(coloreA.ToArgb)
         Dim colore2 As String = Convert.ToString(coloreB.ToArgb)
            Dim colore3 As String = Convert.ToString(coloreC.ToArgb)

            If (colore1 = colore2) Or (colore1 = colore3) Then
                Return True
            Else
                Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function VerificaEsistenzaModulo(ByVal nome As String) As String
        Dim codiceModulo As String = String.Empty

        Try
         If File.Exists(Application.StartupPath & "\" & nome) = True Then

            FileOpen(1, Application.StartupPath & "\" & nome, OpenMode.Input)

            Do While Not EOF(1)
               Input(1, codiceModulo)
            Loop

            FileClose(1)

            Return codiceModulo

         Else
            ' Se non installato...
            Return ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function CalcolaValore(ByVal valore As Decimal, ByVal giacenza As Decimal) As String
      Try
            Return (valore * giacenza).ToString

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

            Return VALORE_ZERO

        End Try
   End Function

   Public Sub ApriSitoInternet(ByVal indirizzo As String)
      Try
         If indirizzo = String.Empty Then
            MessageBox.Show("Il campo 'Internet' è vuoto! Si consiglia di inserire un indirizzo di sito Internet valido e riprovare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            Dim Web As New Varie.WebSolution
            Web.ConnettiInternet(indirizzo)

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Public Sub EsportaEmail(ByVal mittente As String, ByVal destinatario As String, ByVal oggetto As String, ByVal allegato As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim Web As New Varie.WebSolution
         Dim allegati As String() = {allegato}

         Web.createEmail(Application.StartupPath & "\Documenti\" & "Email.eml", mittente, destinatario, oggetto, allegato)
         Process.Start(Application.StartupPath & "\Documenti\" & "Email.eml")

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Public Sub InviaEmail(ByVal mittente As String, ByVal destinatario As String, ByVal oggetto As String, ByVal messaggio As String, ByVal allegato As String)
      Try
         If destinatario = String.Empty Then
            MessageBox.Show("Il campo 'E-mail' è vuoto! Si consiglia di inserire un indirizzo di posta elettronica valido e riprovare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Apre la finestra Invio e-mail per un nuovo messaggio.
            Dim frmEmail As New InvioEmail(mittente, destinatario, oggetto, String.Empty, allegato, String.Empty, String.Empty, String.Empty, String.Empty)

            frmEmail.Tag = String.Empty
            frmEmail.ShowDialog()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Public Sub ApriFileGuida(ByVal percorsoFile As String)
      Try
         Dim fileGuida As File

         If fileGuida.Exists(percorsoFile) = False Then
            ' Se il progetto non include un file della Guida, visualizza un messaggio per l'utente
            MsgBox("Il file della Guida non è disponibile.", MsgBoxStyle.Information, NOME_PRODOTTO)

            Exit Sub
         Else

            Dim Proc As New Process

            ' Avvia l'applicazione.
            Proc.StartInfo.FileName = percorsoFile
            Proc.StartInfo.ErrorDialog = True
            'Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
            Proc.StartInfo.UseShellExecute = True
            Proc.Start()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AvviaTastieraVirtuale(ByVal hndl As System.IntPtr)
      Try
         Const NOME_APP_WIN_XP_7 As String = "Osk.exe"
         Const NOME_APP_WIN_8 As String = "C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe"
         Dim Percorso As String
         Dim Proc As New Process

         If File.Exists(NOME_APP_WIN_8) = True Then
            Percorso = NOME_APP_WIN_8

         ElseIf File.Exists(Environment.SystemDirectory & "\" & NOME_APP_WIN_XP_7) = True Then
            Percorso = NOME_APP_WIN_XP_7

         Else
            MessageBox.Show("La tastiera virtuale non è presente nel sistema in uso.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
         End If

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = Percorso
         'Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = hndl
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AvviaWinBloccoNote(ByVal hndl As System.IntPtr)
      Dim Percorso As String
      Dim PercorsoApp As String
      Dim NomeApp As String = "NOTEPAD.EXE"
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         'Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = hndl
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AvviaWinBloccoNote(ByVal hndl As System.IntPtr, ByVal percorsoFile As String)
      Dim Percorso As String
      Dim PercorsoApp As String
      Dim NomeApp As String = "NOTEPAD.EXE"
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         Proc.StartInfo.Arguments = percorsoFile
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = hndl
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AvviaWinCalc(ByVal hndl As System.IntPtr)
      Dim Percorso As String
      Dim PercorsoApp As String
      Dim NomeApp As String = "CALC.EXE"
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         'Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = hndl
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AvviaEsploraFile(ByVal hndl As System.IntPtr, ByVal percorso As String)
      Dim PercorsoApp As String
      Dim NomeApp As String = "EXPLORER.EXE"
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         Proc.StartInfo.Arguments = percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = hndl
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AvviaApplicazione(ByVal hndl As System.IntPtr, ByVal NomeApp As String, ByVal percorso As String)
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         'Proc.StartInfo.Arguments = percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = hndl
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AvviaLicenzaRtf(ByVal hndl As System.IntPtr, ByVal percorso As String)
      Dim PercorsoApp As String
      Dim NomeApp As String = ""
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = percorso
         Proc.StartInfo.Arguments = ""
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = hndl
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ImpostaIcona(ByVal frm As Form)
      Try
         Dim myIco As System.Drawing.Icon

         Select Case NOME_PRODOTTO

            Case NOME_PRODOTTO_HOSPITALITY, NOME_PRODOTTO_HOSPITALITY_SUITE
               myIco = My.Resources.Hospitality_Ico

            Case NOME_PRODOTTO_HOTEL
               myIco = My.Resources.Hospitality_Ico

            Case NOME_PRODOTTO_BAR
               myIco = My.Resources.bar_Ico

            Case NOME_PRODOTTO_CHEF
               myIco = My.Resources.chef_Ico

            Case NOME_PRODOTTO_SPORTING
               myIco = My.Resources.sport_Ico

         End Select

         frm.Icon = myIco

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub ImpostaIcona(ByVal img As PictureBox)
      Try
         Dim myImage As System.Drawing.Bitmap

         Select Case NOME_PRODOTTO

            Case NOME_PRODOTTO_HOSPITALITY, NOME_PRODOTTO_HOSPITALITY_SUITE
               myImage = My.Resources.Hospitality_Ico.ToBitmap

            Case NOME_PRODOTTO_HOTEL
               myImage = My.Resources.Hospitality_Ico.ToBitmap

            Case NOME_PRODOTTO_BAR
               myImage = My.Resources.bar_Ico.ToBitmap

            Case NOME_PRODOTTO_CHEF
               myImage = My.Resources.chef_Ico.ToBitmap

            Case NOME_PRODOTTO_SPORTING
               myImage = My.Resources.sport_Ico.ToBitmap

         End Select

         img.Image = myImage

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub ImpostaImmagine(ByVal img As PictureBox)
      Try
         Dim myImage As System.Drawing.Bitmap

         Select Case NOME_PRODOTTO

            Case NOME_PRODOTTO_HOSPITALITY, NOME_PRODOTTO_HOSPITALITY_SUITE
               myImage = My.Resources.Splash_screen_ombra_hospitality

            Case NOME_PRODOTTO_HOTEL
               myImage = My.Resources.Splash_screen_ombra_hospitality

            Case NOME_PRODOTTO_BAR
               myImage = My.Resources.Splash_screen_ombra_bar

            Case NOME_PRODOTTO_CHEF
               myImage = My.Resources.Splash_screen_ombra_chef

            Case NOME_PRODOTTO_SPORTING
               myImage = My.Resources.Splash_screen_ombra_sporting

         End Select

         img.Image = myImage

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub RiproduciEffettoSonoro(ByVal beep As UnmanagedMemoryStream, ByVal riproduci As Boolean)
      Try
         If riproduci = True Then
            Dim effettoSonoro As Boolean = True

            If effettoSonoro = True Then
               Dim player As New Media.SoundPlayer(beep)
               player.Play()
            Else
               Exit Sub
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiAliquotaIva(ByVal reparto As String) As String
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Aliquote IVA per i reparti.
         Dim aliquotaIva As String

         Select Case reparto
            Case "Reparto 1"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva1")

            Case "Reparto 2"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva2")

            Case "Reparto 3"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva3")

            Case "Reparto 4"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva4")

            Case Else
               aliquotaIva = "0"

         End Select

         Return aliquotaIva

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return AliquotaIvaRistorante

      End Try
   End Function

   Public Function VerificaAliquotaIva(ByVal valIva As String) As String
      Try
         Select Case valIva
            Case LeggiAliquotaIva("Reparto 1")
               Return "Reparto 1"

            Case LeggiAliquotaIva("Reparto 2")
               Return "Reparto 2"

            Case LeggiAliquotaIva("Reparto 3")
               Return "Reparto 3"

            Case LeggiAliquotaIva("Reparto 4")
               Return "Reparto 4"

            Case Else
               Return String.Empty

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

#End Region

End Module
