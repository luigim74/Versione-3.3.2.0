Imports System.IO
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Xml
Imports System.Data.OleDb
Imports System.Reflection.Assembly

Namespace Varie

   Public Class Errore
      ' Classe per la gestione degli errori.

      Private DatiConfig As AppConfig

      Public Sub GestisciErrore(ByVal nomeProc As String, ByVal messaggio As String)
         ' Crea o apre il file e registra i dati dell'errore.
         FileOpen(1, Application.StartupPath & "\Dati\Registro degli errori.log", OpenMode.Append)
         WriteLine(1, "*** " & Today & " - " & TimeOfDay & " ***")
         WriteLine(1, "- DESCRIZIONE ERRORE: " & messaggio)
         WriteLine(1, "- NOME PROCEDURA: " & nomeProc)
         WriteLine(1, Chr(13) + Chr(10))

         ' Chiude il file.
         FileClose(1)

         ' Visualizza un messaggio di errore.
         Dim risposta As String
         risposta = MessageBox.Show(messaggio & vbNewLine & vbNewLine & _
                         " Si desidera trasmettere l'errore alla Montana Software per una richiesta di assistenza? " & vbNewLine & vbNewLine & _
                         "L'errore verrà trasmesso tramite e-mail e analizzato per capire la natura del problema. Eventualmente è possibile contattare il supporto tecnico all'indirizzo: " & _
                         "assistenza@montanasoftware.it.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

         If risposta = DialogResult.Yes Then
            InviaDatiErrore(nomeProc, messaggio)
         End If

      End Sub

      Public Sub InviaDatiErrore(ByVal nomeProc As String, ByVal msgErrore As String)
         Try
            If WebCommunication.VerificaConnessione = True Then

               DatiConfig = New AppConfig
               DatiConfig.ConfigType = ConfigFileType.AppConfig

               Dim nomeMailServer As String = NOME_MAIL_SERVER_SMTP
               Dim eMailDestinatario As String = "assistenza@montanasoftware.it"

               Dim eMailMittente As String = DatiConfig.GetValue("Email")
               If eMailMittente.IsInterned("@") = "" Or eMailMittente = String.Empty Then
                  eMailMittente = EMAIL_DATI_LICENZA_A
               End If

               Dim hospitality As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY)
               Dim bar As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR)
               Dim ristorante As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE)
               Dim centroSportivo As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO)
               Dim hotel As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOTEL)
               Dim palmari As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PALMARI)
               Dim magazzino As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_MAGAZZINO)
               Dim etichette As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_ETICHETTE)
               Dim penDrivePortable As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE)
               Dim penDriveRecovery As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY)

               Dim oggetto As String = "HOSPITALITY SOLUTION 3 - Richiesta di assistenza (" & msgErrore & ")"

               Dim corpoMessaggio As String = "DATI UTENTE: " & vbNewLine & vbNewLine &
                                              "RAGIONE SOCIALE: " & DatiConfig.GetValue("RagioneSociale") & vbNewLine &
                                              "NOME E COGNOME: " & DatiConfig.GetValue("Nome") & vbNewLine &
                                              "VIA E NUMERO: " & DatiConfig.GetValue("Via") & vbNewLine &
                                              "CITTA': " & DatiConfig.GetValue("Città") & vbNewLine &
                                              "CAP: " & DatiConfig.GetValue("Cap") & vbNewLine &
                                              "PROVINCIA: " & DatiConfig.GetValue("Provincia") & vbNewLine &
                                              "TELEFONO: " & DatiConfig.GetValue("Telefono") & vbNewLine &
                                              "FAX: " & DatiConfig.GetValue("Fax") & vbNewLine &
                                              "E-MAIL: " & DatiConfig.GetValue("Email") & vbNewLine &
                                              "PARTITA IVA: " & DatiConfig.GetValue("Piva") & vbNewLine & vbNewLine &
                                              "DATI RIVENDITORE: " & vbNewLine & vbNewLine &
                                              "RAGIONE SOCIALE: " & DatiConfig.GetValue("RagioneSocialeRiv") & vbNewLine &
                                              "NOME E COGNOME: " & DatiConfig.GetValue("NomeRiv") & vbNewLine &
                                              "TELEFONO: " & DatiConfig.GetValue("TelefonoRiv") & vbNewLine &
                                              "E-MAIL: " & DatiConfig.GetValue("EmailRiv") & vbNewLine &
                                              "PARTITA IVA: " & DatiConfig.GetValue("PivaRiv") & vbNewLine & vbNewLine &
                                              "NUMERO DI SERIE: " & NUMERO_SERIE & vbNewLine &
                                              "VERSIONE PRODOTTO: " & FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductVersion & vbNewLine & vbNewLine &
                                              "MODULI ATTIVI: " & vbNewLine &
                                              "MODULO HOSPITALITY: " & DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG) & vbNewLine &
                                              "MODULO BAR: " & DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG) & vbNewLine &
                                              "MODULO RISTORANTE: " & DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) & vbNewLine &
                                              "MODULO CENTRO SPORTIVO: " & DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG) & vbNewLine &
                                              "MODULO HOTEL: " & DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG) & vbNewLine &
                                              "MODULO PALMARI: " & DatiConfig.GetValue(Modulo.NOME_PALMARI_CONFIG) & vbNewLine &
                                              "MODULO MAGAZZINO: " & DatiConfig.GetValue(Modulo.NOME_MAGAZZINO_CONFIG) & vbNewLine &
                                              "MODULO ETICHETTE: " & DatiConfig.GetValue(Modulo.NOME_ETICHETTE_CONFIG) & vbNewLine &
                                              "MODULO PENDRIVE PORTABLE: " & DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) & vbNewLine &
                                              "MODULO PENDRIVE RECOVERY: " & DatiConfig.GetValue(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG) & vbNewLine & vbNewLine &
                                              "DATA ERRORE: " & Now.ToString & vbNewLine &
                                              "DESCRIZIONE ERRORE: " & msgErrore & vbNewLine &
                                              "NOME PROCEDURA: " & nomeProc

               '"CODICI DI ATTIVAZIONE: " & vbNewLine & _
               '"CHIAVE MODULO HOSPITALITY: " & hospitality & vbNewLine & _
               '"CHIAVE MODULO BAR: " & bar & vbNewLine & _
               '"CHIAVE MODULO RISTORANTE: " & ristorante & vbNewLine & _
               '"CHIAVE MODULO CENTRO SPORTIVO: " & centroSportivo & vbNewLine & _
               '"CHIAVE MODULO HOTEL: " & hotel & vbNewLine & _
               '"CHIAVE MODULO PALMARI: " & palmari & vbNewLine & _
               '"CHIAVE MODULO MAGAZZINO: " & magazzino & vbNewLine & _
               '"CHIAVE MODULO ETICHETTE: " & etichette & vbNewLine & _
               '"CHIAVE MODULO PENDRIVE PORTABLE: " & penDrivePortable & vbNewLine & _
               '"CHIAVE MODULO PENDRIVE RECOVERY: " & penDriveRecovery & vbNewLine & vbNewLine & _

               Dim messaggio As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(eMailMittente, eMailDestinatario)
               messaggio.Subject = oggetto
               messaggio.Body = corpoMessaggio

               Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(nomeMailServer, 25)

               smtp.Credentials = New System.Net.NetworkCredential(USER_NAME_MAIL_SERVER_SMTP, PWD_MAIL_SERVER_SMTP)

               smtp.Send(messaggio)

               MessageBox.Show("L'errore è stato inviato con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
               MessageBox.Show("Non è stata trovata una connessione ad Internet! L'errore non può essere inviato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

         Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

         End Try
      End Sub

   End Class

   Public Class AppConfigFile

      Public Function Leggi(ByVal chiave As String)

         Dim Val As System.Collections.Specialized.NameValueCollection
         Val = Configuration.ConfigurationSettings.AppSettings()

         Return Val.Item(chiave)

      End Function

      Public Sub Scrivi(ByVal nomeFile As String, ByVal chiave As String, ByVal valore As String)

         Dim xmldoc As New XmlDocument
         xmldoc.Load(nomeFile)

         Dim xmlEl1 As XmlElement = xmldoc.CreateElement("appSettings")
         xmldoc.DocumentElement.AppendChild(xmlEl1)

         Dim xmlEl As XmlElement = xmldoc.CreateElement("add")
         xmlEl1.AppendChild(xmlEl)

         xmlEl.SetAttribute("key", chiave)
         xmlEl.SetAttribute("value", valore)

         xmldoc.Save(nomeFile)

      End Sub

   End Class

   Public Class WebSolution
      ' Utilizza libreria esterna SHDocVw della Microsoft completamente libera.
      Public Sub ConnettiInternet(ByVal Indirizzo As String)

         Dim Explorer As SHDocVw.InternetExplorer

         Explorer = New SHDocVw.InternetExplorer
         Explorer.Visible = True
         Explorer.Navigate(Indirizzo)

      End Sub

      ' Caricare "Imports System.Diagnostics" usa una classe contenuta nel fram...1.1
      Public Sub ConnettiInternet2(ByVal Indirizzo As String)

         Dim Processo As Process = New Process
         Processo.Start(Indirizzo)

      End Sub

      '1 modo email.
      Dim myAdd(-1) As String

      Private Sub appendBase64File(ByRef fileStream As System.IO.StreamWriter, ByVal fullPathFileToAdd As String, ByVal fileToAdd As String)
         Dim Fs As FileStream = New FileStream(fullPathFileToAdd, FileMode.Open, FileAccess.Read, FileShare.None)

         fileStream.WriteLine("Content-Type: application/octet-stream;")
         fileStream.WriteLine("	Name = """ + fileToAdd + """")
         fileStream.WriteLine("Content-Transfer-Encoding: base64")
         fileStream.WriteLine("Content-Disposition: attachment;")
         fileStream.WriteLine("	filename= """ + fileToAdd + """")
         fileStream.WriteLine("")
         Dim byArray() As Byte
         ReDim byArray(CInt(Fs.Length))
         Fs.Read(byArray, 0, CInt(Fs.Length))
         fileStream.WriteLine(System.Convert.ToBase64String(byArray))
         fileStream.WriteLine("")
         Fs.Close()
      End Sub

      Public Function createEmail(ByVal fileName As String, ByVal mailFrom As String, ByVal mailTo As String, ByVal mailSubject As String, ByVal mailText As String) As Boolean
         Try
            Dim Fs As FileStream = New FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)
            Dim SwFromFile As StreamWriter = New StreamWriter(Fs)
            SwFromFile.WriteLine("From: <" + mailFrom + ">")
            SwFromFile.WriteLine("To: <" + mailTo + ">")
            SwFromFile.WriteLine("Subject: " + mailSubject)
            SwFromFile.WriteLine("Date: " + Now.ToShortDateString.ToString)
            SwFromFile.WriteLine("MIME-Version: 1.0")
            SwFromFile.WriteLine("Content-Type: multipart/mixed;")
            SwFromFile.WriteLine("	boundary=""----=_NextPart_000_000D_01C2A06C.7F8E75B0""")
            SwFromFile.WriteLine("X-Priority: 3")
            SwFromFile.WriteLine("X-MSMail-Priority: Normal")
            SwFromFile.WriteLine("X-Unsent: 1")
            SwFromFile.WriteLine("X-MimeOLE: Produced By WillyxMimeTest willyx@libero.it V0")
            SwFromFile.WriteLine("")
            SwFromFile.WriteLine("This is a multi-part message in MIME format.")
            SwFromFile.WriteLine("")
            SwFromFile.WriteLine("------=_NextPart_000_000D_01C2A06C.7F8E75B0")
            SwFromFile.WriteLine("Content-Type: text/plain;")
            SwFromFile.WriteLine("	charset=""iso-8859-1""")
            SwFromFile.WriteLine("Content-Transfer-Encoding: 7bit")
            SwFromFile.WriteLine("")
            SwFromFile.WriteLine(mailText)
            SwFromFile.WriteLine("")
            SwFromFile.WriteLine("------=_NextPart_000_000D_01C2A06C.7F8E75B0--")
            SwFromFile.Flush()
            SwFromFile.Close()
            Fs.Close()
         Catch e As System.SystemException
            MsgBox(e.ToString, MsgBoxStyle.Exclamation, Application.ProductName)
            Return False
         End Try
         Return True
      End Function

      Public Function createEmail(ByVal fileName As String, ByVal mailFrom As String, ByVal mailTo As String, ByVal mailSubject As String, ByVal mailText As String, ByVal mailAttach As String()) As Boolean
         Try
            Dim Fs As FileStream = New FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)

            Dim SwFromFile As StreamWriter = New StreamWriter(Fs)
            SwFromFile.WriteLine("From: <" + mailFrom + ">")
            SwFromFile.WriteLine("To: <" + mailTo + ">")
            SwFromFile.WriteLine("Subject: " + mailSubject)
            SwFromFile.WriteLine("Date: " + Now.ToShortDateString.ToString)
            SwFromFile.WriteLine("MIME-Version: 1.0")
            SwFromFile.WriteLine("Content-Type: multipart/mixed;")
            SwFromFile.WriteLine("	boundary=""----=_NextPart_000_000D_01C2A06C.7F8E75B0""")
            SwFromFile.WriteLine("X-Priority: 3")
            SwFromFile.WriteLine("X-MSMail-Priority: Normal")
            SwFromFile.WriteLine("X-Unsent: 1")
            SwFromFile.WriteLine("X-MimeOLE: Produced By WillyxMimeTest willyx@libero.it V0")
            SwFromFile.WriteLine("")
            SwFromFile.WriteLine("This is a multi-part message in MIME format.")
            SwFromFile.WriteLine("")
            SwFromFile.WriteLine("------=_NextPart_000_000D_01C2A06C.7F8E75B0")
            SwFromFile.WriteLine("Content-Type: text/plain;")
            SwFromFile.WriteLine("	charset=""iso-8859-1""")
            SwFromFile.WriteLine("Content-Transfer-Encoding: 7bit")
            SwFromFile.WriteLine("")
            SwFromFile.WriteLine(mailText)
            SwFromFile.WriteLine("")

            Dim i As Integer
            For i = 0 To mailAttach.Length - 1
               SwFromFile.WriteLine("------=_NextPart_000_000D_01C2A06C.7F8E75B0")
               appendBase64File(SwFromFile, mailAttach(i), mailAttach(i))
            Next

            SwFromFile.WriteLine("------=_NextPart_000_000D_01C2A06C.7F8E75B0--")
            SwFromFile.Flush()
            SwFromFile.Close()
            Fs.Close()
         Catch e As System.SystemException
            MsgBox(e.ToString, MsgBoxStyle.Exclamation, Application.ProductName)
            Return False
         End Try
         Return True
      End Function

      '2 modo email.
      Public attachfile As Boolean

      Public Sub send_via_0(ByVal subject As String, ByVal toe As String, ByVal body As String, ByVal from As String, ByVal attachment As String)
         Dim Appl As Object
         Dim out As Object
         Dim att As Object
         Try
            Appl = CreateObject("Outlook.Application")
            out = Appl.CreateItem(0)
            'att = Appl.createitem(2)
            With out
               .Subject = subject
               .To = toe
               .Body = body
               '==============================================
               'to use html in the email instead of plain text
               'use .HTMLBody instead of .body
               '==============================================
               If attachment <> "" Then
                  .Attachments.add(attachment)
               End If
               .Send()
            End With
         Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)
         End Try
      End Sub

   End Class

   'Public Class Allegati

   '   Public Codice As Integer
   '   Public Documento As String
   '   Public Data As String
   '   Public Ora As String
   '   Public Note As String
   '   Public Percorso As String
   '   Public Estensione As String
   '   Public IdCliente As Integer

   '   ' Dichiara un oggetto connessione.
   '   Private cn As OleDbConnection
   '   Private tr As OleDbTransaction
   '   ' Gestione degli errori.
   '   Private err As New Errore

   '   Public Sub New(ByVal connStr As String)
   '      Dim cn = New OleDbConnection(connStr)

   '   End Sub

   '   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal codCliente As Integer) As Boolean
   '      ' Dichiara un oggetto connessione.
   '      'Dim cn As New OleDbConnection(ConnString)
   '      Dim Caricati As Boolean = False

   '      Try
   '         cn.Open()

   '         Dim i As Integer
   '         Dim Estensione As String

   '         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdCliente = " & codCliente & " ORDER BY Documento ASC", cn)
   '         Dim dr As OleDbDataReader = cmd.ExecuteReader()

   '         lst.Items.Clear()

   '         Do While dr.Read()
   '            lst.Items.Add(dr.Item("Documento"))
   '            lst.Items(i).SubItems.Add(dr.Item("Data"))
   '            lst.Items(i).SubItems.Add(dr.Item("Ora"))
   '            lst.Items(i).SubItems.Add(dr.Item("Note"))
   '            lst.Items(i).SubItems.Add(dr.Item("Percorso"))
   '            lst.Items(i).SubItems.Add(dr.Item("Id"))
   '            Estensione = dr.Item("Estensione")

   '            Select Case Estensione.ToUpper
   '               Case ".DOC", ".RTF"
   '                  ' Word
   '                  lst.Items(i).StateImageIndex = 1

   '               Case ".XLS"
   '                  ' Excel
   '                  lst.Items(i).StateImageIndex = 2

   '               Case ".MDB"
   '                  ' Access
   '                  lst.Items(i).StateImageIndex = 3

   '               Case ".PPT"
   '                  ' Power Point
   '                  lst.Items(i).StateImageIndex = 4

   '               Case ".TXT"
   '                  ' Blocco note.
   '                  lst.Items(i).StateImageIndex = 5

   '               Case ".PDF"
   '                  ' Acrobat Reader
   '                  lst.Items(i).StateImageIndex = 6

   '               Case ".HTM"
   '                  ' Internet Explorer
   '                  lst.Items(i).StateImageIndex = 7

   '               Case Else
   '                  ' Altre estensioni.
   '                  lst.Items(i).StateImageIndex = 8
   '            End Select

   '            i = i + 1

   '            Caricati = True
   '         Loop

   '         Return Caricati

   '      Catch ex As Exception
   '         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
   '         err.GestisciErrore(ex.StackTrace, ex.Message)

   '      Finally
   '         cn.Close()

   '      End Try
   '   End Function

   '   Public Function InserisciDati(ByVal tabella As String) As Boolean
   '      Dim sql As String

   '      Try
   '         ' Apre la connessione.
   '         cn.Open()

   '         ' Avvia una transazione.
   '         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
   '         ' Crea la stringa di eliminazione.
   '         sql = String.Format("INSERT INTO {0} (Documento, Data, Ora, [Note], [Percorso], IdCliente, Estensione) " & _
   '                                              "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}')", tabella, _
   '                                              Me.Documento, _
   '                                              Me.Data, _
   '                                              Me.Ora, _
   '                                              Me.Note, _
   '                                              Me.Percorso, _
   '                                              Me.IdCliente, _
   '                                              Me.Estensione)


   '         ' Crea il comando per la connessione corrente.
   '         Dim cmdInsert As New OleDbCommand(sql, cn, tr)
   '         ' Esegue il comando.
   '         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

   '         ' Conferma transazione.
   '         tr.Commit()

   '         Return True

   '      Catch ex As Exception
   '         ' Annulla transazione.
   '         tr.Rollback()

   '         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
   '         err.GestisciErrore(ex.StackTrace, ex.Message)

   '         Return False

   '      Finally
   '         ' Chiude la connessione.
   '         cn.Close()

   '      End Try
   '   End Function

   '   Public Function ModificaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
   '      Dim sql As String

   '      Try
   '         ' Apre la connessione.
   '         cn.Open()

   '         ' Avvia una transazione.
   '         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

   '         ' Crea la stringa di eliminazione.
   '         sql = String.Format("UPDATE {0} " & _
   '                             "SET Documento = '{1}', " & _
   '                             "Data = '{2}', " & _
   '                             "Ora = '{3}', " & _
   '                             "[Note] = '{4}', " & _
   '                             "[Percorso] = '{5}', " & _
   '                             "IdCliente = {6}, " & _
   '                             "Estensione = '{7}' " & _
   '                             "WHERE Id = {8}", _
   '                             tabella, _
   '                             Me.Documento, _
   '                             Me.Data, _
   '                             Me.Ora, _
   '                             Me.Note, _
   '                             Me.Percorso, _
   '                             Me.IdCliente, _
   '                             Me.Estensione, _
   '                             Id)

   '         ' Crea il comando per la connessione corrente.
   '         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
   '         ' Esegue il comando.
   '         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

   '         ' Conferma transazione.
   '         tr.Commit()

   '         Return True

   '      Catch ex As Exception
   '         ' Annulla transazione.
   '         tr.Rollback()

   '         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
   '         err.GestisciErrore(ex.StackTrace, ex.Message)

   '         Return False

   '      Finally
   '         ' Chiude la connessione.
   '         cn.Close()
   '      End Try
   '   End Function


   'End Class

End Namespace