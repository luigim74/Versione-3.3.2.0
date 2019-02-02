Imports System.Data.OleDb

Public Class Cameriere
   Inherits Anagrafiche.Persona

   Public Mastro As String
   Public TipoCliente As String
   Public Mercato As String
   Public Canale As String
   Public NoteVideo As String
   Public NoteStampa As String
   Public Privacy As String
   Public InsPS As String
   Public NumComp As String
   Public Strutture As String
   Public CostoOra As String

   Private m_ConnString As String

   Public Property ConnString()
      Get
         Return m_ConnString
      End Get

      Set(ByVal Value)
         m_ConnString = Value
      End Set
   End Property

   Public Sub New(ByVal val As String)
      ' Imposta la stringa di connessione del database.
      Me.ConnString = val
   End Sub

   Private tr As OleDbTransaction

   Public Overridable Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(Me.ConnString)
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Mastro")) = False Then
            Me.Mastro = ds.Tables(tabella).Rows(0)("Mastro")
         Else
            Me.Mastro = ""
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sesso")) = False Then
            Me.Sesso = ds.Tables(tabella).Rows(0)("Sesso")
         Else
            Me.Sesso = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodFisc")) = False Then
            Me.CodFisc = ds.Tables(tabella).Rows(0)("CodFisc")
         Else
            Me.CodFisc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PIva")) = False Then
            Me.PIva = ds.Tables(tabella).Rows(0)("PIva")
         Else
            Me.PIva = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo")) = False Then
            Me.Indirizzo1 = ds.Tables(tabella).Rows(0)("Indirizzo")
         Else
            Me.Indirizzo1 = ""
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Regione")) = False Then
            Me.Regione = ds.Tables(tabella).Rows(0)("Regione")
         Else
            Me.Regione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nazione")) = False Then
            Me.Nazione = ds.Tables(tabella).Rows(0)("Nazione")
         Else
            Me.Nazione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataNascita")) = False Then
            Me.DataNascita = ds.Tables(tabella).Rows(0)("DataNascita")
         Else
            Me.DataNascita = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("LuogoNascita")) = False Then
            Me.LuogoNascita = ds.Tables(tabella).Rows(0)("LuogoNascita")
         Else
            Me.LuogoNascita = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ProvNascita")) = False Then
            Me.ProvNascita = ds.Tables(tabella).Rows(0)("ProvNascita")
         Else
            Me.ProvNascita = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NazioneNascita")) = False Then
            Me.NazioneNascita = ds.Tables(tabella).Rows(0)("NazioneNascita")
         Else
            Me.NazioneNascita = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoDoc")) = False Then
            Me.TipoDoc = ds.Tables(tabella).Rows(0)("TipoDoc")
         Else
            Me.TipoDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataRilascioDoc")) = False Then
            Me.DataRilascioDoc = ds.Tables(tabella).Rows(0)("DataRilascioDoc")
         Else
            Me.DataRilascioDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroDoc")) = False Then
            Me.NumeroDoc = ds.Tables(tabella).Rows(0)("NumeroDoc")
         Else
            Me.NumeroDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("RilasciatoDa")) = False Then
            Me.RilasciatoDa = ds.Tables(tabella).Rows(0)("RilasciatoDa")
         Else
            Me.RilasciatoDa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoCliente")) = False Then
            Me.TipoCliente = ds.Tables(tabella).Rows(0)("TipoCliente")
         Else
            Me.TipoCliente = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Intestatario")) = False Then
            Me.Intestatario = ds.Tables(tabella).Rows(0)("Intestatario")
         Else
            Me.Intestatario = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoPagamento")) = False Then
            Me.TipoPagamento = ds.Tables(tabella).Rows(0)("TipoPagamento")
         Else
            Me.TipoPagamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumCarta")) = False Then
            Me.NumCarta = ds.Tables(tabella).Rows(0)("NumCarta")
         Else
            Me.NumCarta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScadenzaCarta")) = False Then
            Me.ScadenzaCarta = ds.Tables(tabella).Rows(0)("ScadenzaCarta")
         Else
            Me.ScadenzaCarta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TitolareCarta")) = False Then
            Me.TitolareCarta = ds.Tables(tabella).Rows(0)("TitolareCarta")
         Else
            Me.TitolareCarta = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Targa")) = False Then
            Me.Targa = ds.Tables(tabella).Rows(0)("Targa")
         Else
            Me.Targa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Disabile")) = False Then
            Me.Disabile = ds.Tables(tabella).Rows(0)("Disabile")
         Else
            Me.Disabile = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("InvioCorrisp")) = False Then
            Me.InvioCorrisp = ds.Tables(tabella).Rows(0)("InvioCorrisp")
         Else
            Me.InvioCorrisp = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TelCasa")) = False Then
            Me.TelCasa = ds.Tables(tabella).Rows(0)("TelCasa")
         Else
            Me.TelCasa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TelUfficio")) = False Then
            Me.TelUfficio = ds.Tables(tabella).Rows(0)("TelUfficio")
         Else
            Me.TelUfficio = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cell")) = False Then
            Me.Cell = ds.Tables(tabella).Rows(0)("Cell")
         Else
            Me.Cell = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Fax")) = False Then
            Me.Fax = ds.Tables(tabella).Rows(0)("Fax")
         Else
            Me.Fax = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Email")) = False Then
            Me.Email = ds.Tables(tabella).Rows(0)("Email")
         Else
            Me.Email = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Internet")) = False Then
            Me.Internet = ds.Tables(tabella).Rows(0)("Internet")
         Else
            Me.Internet = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Strutture")) = False Then
            Me.Strutture = ds.Tables(tabella).Rows(0)("Strutture")
         Else
            Me.Strutture = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
            Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine")
         Else
            Me.Immagine = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note")
         Else
            Me.Note = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Mercato")) = False Then
            Me.Mercato = ds.Tables(tabella).Rows(0)("Mercato")
         Else
            Me.Mercato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Canale")) = False Then
            Me.Canale = ds.Tables(tabella).Rows(0)("Canale")
         Else
            Me.Canale = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Lingua")) = False Then
            Me.Lingua = ds.Tables(tabella).Rows(0)("Lingua")
         Else
            Me.Lingua = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Professione")) = False Then
            Me.Professione = ds.Tables(tabella).Rows(0)("Professione")
         Else
            Me.Professione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NoteVideo")) = False Then
            Me.NoteVideo = ds.Tables(tabella).Rows(0)("NoteVideo")
         Else
            Me.NoteVideo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NoteStampa")) = False Then
            Me.NoteStampa = ds.Tables(tabella).Rows(0)("NoteStampa")
         Else
            Me.NoteStampa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Privacy")) = False Then
            Me.Privacy = ds.Tables(tabella).Rows(0)("Privacy")
         Else
            Me.Privacy = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("InsPS")) = False Then
            Me.InsPS = ds.Tables(tabella).Rows(0)("InsPS")
         Else
            Me.InsPS = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumComp")) = False Then
            Me.NumComp = ds.Tables(tabella).Rows(0)("NumComp")
         Else
            Me.NumComp = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoOra")) = False Then
            Me.CostoOra = ds.Tables(tabella).Rows(0)("CostoOra")
         Else
            Me.CostoOra = ""
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

   Public Overridable Function InserisciDati(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(Me.ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Nome, Cap, Cell, Città, CodFisc, Cognome, DataNascita, DataRilascioDoc, " & _
                                              "Disabile, Email, Fax, Indirizzo, InvioCorrisp, LuogoNascita, Nazione, " & _
                                              "NazioneNascita, NumCarta, NumeroDoc, PIva, Provincia, ProvNascita, " & _
                                              "Regione, RilasciatoDa, ScadenzaCarta, Sesso, Strutture, Targa, TelCasa, " & _
                                              "TelUfficio, TipoCliente, TipoDoc, TipoPagamento, TitolareCarta, Titolo, " & _
                                              "[Note], Immagine, Internet, Mastro, Intestatario, CartaCredito, " & _
                                              "Mercato, Canale, Lingua, Professione, [NoteVideo], [NoteStampa], Privacy, InsPS, NumComp, CostoOra) " & _
                                       "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " & _
                                              "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', " & _
                                              "'{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', " & _
                                              "'{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', " & _
                                              "'{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}')", _
                                              tabella, _
                                              Me.Nome, _
                                              Me.Cap, _
                                              Me.Cell, _
                                              Me.Città, _
                                              Me.CodFisc, _
                                              Me.Cognome, _
                                              Me.DataNascita, _
                                              Me.DataRilascioDoc, _
                                              Me.Disabile, _
                                              Me.Email, _
                                              Me.Fax, _
                                              Me.Indirizzo1, _
                                              Me.InvioCorrisp, _
                                              Me.LuogoNascita, _
                                              Me.Nazione, _
                                              Me.NazioneNascita, _
                                              Me.NumCarta, _
                                              Me.NumeroDoc, _
                                              Me.PIva, _
                                              Me.Provincia, _
                                              Me.ProvNascita, _
                                              Me.Regione, _
                                              Me.RilasciatoDa, _
                                              Me.ScadenzaCarta, _
                                              Me.Sesso, _
                                              Me.Strutture, _
                                              Me.Targa, _
                                              Me.TelCasa, _
                                              Me.TelUfficio, _
                                              Me.TipoCliente, _
                                              Me.TipoDoc, _
                                              Me.TipoPagamento, _
                                              Me.TitolareCarta, _
                                              Me.Titolo, _
                                              Me.Note, _
                                              Me.Immagine, _
                                              Me.Internet, _
                                              Me.Mastro, _
                                              Me.Intestatario, _
                                              Me.CartaCredito, _
                                              Me.Mercato, _
                                              Me.Canale, _
                                              Me.Lingua, _
                                              Me.Professione, _
                                              Me.NoteVideo, _
                                              Me.NoteStampa, _
                                              Me.Privacy, _
                                              Me.InsPS, _
                                              Me.NumComp, _
                                              Me.CostoOra)

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

   Public Overridable Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(Me.ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET Nome = '{1}', " & _
                             "Cap = '{2}', " & _
                             "Cell = '{3}', " & _
                             "Città = '{4}', " & _
                             "CodFisc = '{5}', " & _
                             "Cognome = '{6}', " & _
                             "DataNascita = '{7}', " & _
                             "DataRilascioDoc = '{8}', " & _
                             "Disabile = '{9}', " & _
                             "Email = '{10}', " & _
                             "Fax = '{11}', " & _
                             "Indirizzo = '{12}', " & _
                             "InvioCorrisp = '{13}', " & _
                             "LuogoNascita = '{14}', " & _
                             "Nazione = '{15}', " & _
                             "NazioneNascita = '{16}', " & _
                             "NumCarta = '{17}', " & _
                             "NumeroDoc = '{18}', " & _
                             "PIva = '{19}', " & _
                             "Provincia = '{20}', " & _
                             "ProvNascita = '{21}', " & _
                             "Regione = '{22}', " & _
                             "RilasciatoDa = '{23}', " & _
                             "ScadenzaCarta = '{24}', " & _
                             "Sesso = '{25}', " & _
                             "Strutture = '{26}', " & _
                             "Targa = '{27}', " & _
                             "TelCasa = '{28}', " & _
                             "TelUfficio = '{29}', " & _
                             "TipoCliente = '{30}', " & _
                             "TipoDoc = '{31}', " & _
                             "TipoPagamento = '{32}', " & _
                             "TitolareCarta = '{33}', " & _
                             "Titolo = '{34}', " & _
                             "[Note] = '{35}', " & _
                             "Immagine = '{36}', " & _
                             "Internet = '{37}', " & _
                             "Mastro = '{38}', " & _
                             "Intestatario = '{39}', " & _
                             "CartaCredito = '{40}', " & _
                             "Mercato = '{41}', " & _
                             "Canale = '{42}', " & _
                             "Lingua = '{43}', " & _
                             "Professione = '{44}', " & _
                             "[NoteVideo] = '{45}', " & _
                             "[NoteStampa] = '{46}', " & _
                             "Privacy = '{47}', " & _
                             "InsPS = '{48}', " & _
                             "NumComp = '{49}', " & _
                             "CostoOra = '{50}' " & _
                             "WHERE Id = {51}", _
                              tabella, _
                              Me.Nome, _
                              Me.Cap, _
                              Me.Cell, _
                              Me.Città, _
                              Me.CodFisc, _
                              Me.Cognome, _
                              Me.DataNascita, _
                              Me.DataRilascioDoc, _
                              Me.Disabile, _
                              Me.Email, _
                              Me.Fax, _
                              Me.Indirizzo1, _
                              Me.InvioCorrisp, _
                              Me.LuogoNascita, _
                              Me.Nazione, _
                              Me.NazioneNascita, _
                              Me.NumCarta, _
                              Me.NumeroDoc, _
                              Me.PIva, _
                              Me.Provincia, _
                              Me.ProvNascita, _
                              Me.Regione, _
                              Me.RilasciatoDa, _
                              Me.ScadenzaCarta, _
                              Me.Sesso, _
                              Me.Strutture, _
                              Me.Targa, _
                              Me.TelCasa, _
                              Me.TelUfficio, _
                              Me.TipoCliente, _
                              Me.TipoDoc, _
                              Me.TipoPagamento, _
                              Me.TitolareCarta, _
                              Me.Titolo, _
                              Me.Note, _
                              Me.Immagine, _
                              Me.Internet, _
                              Me.Mastro, _
                              Me.Intestatario, _
                              Me.CartaCredito, _
                              Me.Mercato, _
                              Me.Canale, _
                              Me.Lingua, _
                              Me.Professione, _
                              Me.NoteVideo, _
                              Me.NoteStampa, _
                              Me.Privacy, _
                              Me.InsPS, _
                              Me.NumComp, _
                              Me.CostoOra, _
                              codice)

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

