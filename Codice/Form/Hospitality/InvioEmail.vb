#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            InvioEmail
' Autore:               Luigi Montana, Montana Software
' Data creazione:       22/07/2018
' Data ultima modifica: 29/07/2018
' Descrizione:          Finestra per l'invio delle E-mail.
'
' ******************************************************************
#End Region

Imports System.IO

Public Class InvioEmail

   Const NOME_TABELLA As String = "Email"
   Const TITOLO_FINESTRA = "Invio E-mail"

   Public IEmail As New Email

   Dim eMail_Mittente As String
   Dim eMail_Destinatario As String
   Dim eMail_Oggetto As String
   Dim eMail_Messaggio As String
   Dim eMail_Allegati As String

   Dim eMail_IdCliente As String
   Dim eMail_Nome As String
   Dim eMail_Cognome As String
   Dim eMail_Categoria As String

   Public Sub New(ByVal mittente As String, ByVal destinatario As String, ByVal oggetto As String, ByVal messaggio As String, ByVal allegati As String,
                  ByVal idCliente As String, ByVal nome As String, ByVal cognome As String, ByVal categoria As String)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      eMail_Mittente = mittente
      eMail_Destinatario = destinatario
      eMail_Oggetto = oggetto
      eMail_Messaggio = messaggio
      eMail_Allegati = allegati

      eMail_IdCliente = idCliente
      eMail_Nome = nome
      eMail_Cognome = cognome
      eMail_Categoria = categoria

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Function SalvaDati() As Boolean
      Try
         With IEmail

            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Mittente = eui_txtMittente.Text
            .Destinatario = eui_txtDestinatario.Text
            .Oggetto = eui_txtOggetto.Text
            .Messaggio = eui_txtMessaggio.Text
            .Allegati = eui_txtAllegati.Text
            .Cognome = eui_txtCognome.Text
            .Nome = eui_txtNome.Text
            .DataInvio = eui_txtDataInvio.Text
            .OraInvio = eui_txtOraInvio.Text
            .IdCliente = eui_txtIdCliente.Text
            .Stato = eui_txtStato.Text
            .Categoria = eui_txtCategoria.Text

            ' Assegna un colore per la categoria.
            Select Case .Categoria
               Case CATEGORIA_PREN_CAMERE
                  .Colore = Convert.ToInt32(Color.Brown.ToArgb)

               Case CATEGORIA_ARCHIVI

               Case Else
                  .Colore = Convert.ToInt32(Color.White.ToArgb)

            End Select

            '  Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> String.Empty Then
               Return .ModificaDati(NOME_TABELLA, Me.Tag)
            Else
               Return .InserisciDati(NOME_TABELLA)
            End If

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function InviaEmail(ByVal eMailMittente As String, ByVal eMailDestinatario As String, ByVal eMailOggetto As String, ByVal eMailMessaggio As String, ByVal eMailAllegati As String) As Boolean
      Try
         If WebCommunication.VerificaConnessione = True Then

            Dim nomeMailServer As String = NOME_MAIL_SERVER_SMTP

            If eMailMittente = String.Empty Then
               MessageBox.Show("E' necessario specificare un'indirizzo e-mail per il mittente!" & vbNewLine &
                               "Verificare nell'anagrafica 'Dati generali Azienda' la presenza di un'indirizzo e-mail valido.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               eui_txtMittente.Focus()
               Return False
            End If

            If eMailDestinatario = String.Empty Then
               MessageBox.Show("E' necessario specificare un'indirizzo e-mail per il destinatario!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               eui_txtDestinatario.Focus()
               Return False
            End If

            If eMailOggetto = String.Empty Then
               MessageBox.Show("E' necessario specificare l'oggetto del messaggio!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               eui_txtOggetto.Focus()
               Return False
            End If

            Dim messaggio As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(eMailMittente, eMailDestinatario)
            messaggio.Subject = eMailOggetto
            messaggio.Body = eMailMessaggio

            Dim nomeFile As String() = eMailAllegati.Split(";")
            Dim Data(nomeFile.Length - 1) As System.Net.Mail.Attachment

            Dim i As Integer
            For i = 0 To nomeFile.Length - 1
               Data(i) = New System.Net.Mail.Attachment(nomeFile(i), System.Net.Mime.MediaTypeNames.Application.Octet)
               Dim disposition As System.Net.Mime.ContentDisposition = Data(i).ContentDisposition
               disposition.CreationDate = System.IO.File.GetCreationTime(nomeFile(i))
               disposition.ModificationDate = System.IO.File.GetLastWriteTime(nomeFile(i))
               disposition.ReadDate = System.IO.File.GetLastAccessTime(nomeFile(i))
               messaggio.Attachments.Add(Data(i))
            Next

            Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(nomeMailServer, 25)

            smtp.Credentials = New System.Net.NetworkCredential(USER_NAME_MAIL_SERVER_SMTP, PWD_MAIL_SERVER_SMTP)

            smtp.Send(messaggio)

            Return True
         End If

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Sub ModificaStatoEmail(ByVal tabella As String, ByVal codice As String, ByVal data As String, ByVal ora As String, ByVal stato As String)
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET DataInvio = @DataInvio, " &
                             "OraInvio = @OraInvio, " &
                             "Stato = @Stato " &
                             "WHERE Id = {1}",
                             tabella,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@DataInvio", data)
         cmdUpdate.Parameters.AddWithValue("@OraInvio", ora)
         cmdUpdate.Parameters.AddWithValue("@Stato", stato)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Private Sub InserisciAllegati(ByVal allegati As String)
      Try
         ' Imposta la finesta di dialogo.
         OpenFileDialog1.Filter = "Tutti i file |*.*"
         OpenFileDialog1.FilterIndex = 1
         OpenFileDialog1.FileName = String.Empty

         ' Salva il percorso del file selezionato.
         If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            ' Inserisce il nome del file nella lista degli allegati.
            If allegati = String.Empty Then
               eui_txtAllegati.Text = OpenFileDialog1.FileName
            Else
               eui_txtAllegati.Text = allegati & ";" & OpenFileDialog1.FileName
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InvioEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         If Me.Tag <> String.Empty Then
            With IEmail
               ' Comando Modifica.

               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati ai rispettivi controlli.
               eui_txtMittente.Text = .Mittente
               eui_txtDestinatario.Text = .Destinatario
               eui_txtOggetto.Text = .Oggetto
               eui_txtMessaggio.Text = .Messaggio
               eui_txtAllegati.Text = .Allegati
               eui_txtCognome.Text = .Cognome
               eui_txtNome.Text = .Nome
               eui_txtDataInvio.Text = .DataInvio
               eui_txtOraInvio.Text = .OraInvio
               eui_txtIdCliente.Text = .IdCliente
               eui_txtStato.Text = .Stato
               eui_txtCategoria.Text = .Categoria

               ' Messaggio barra di stato.
               If .DataInvio <> String.Empty Then
                  eui_Informazioni.Text = "Inviato il " & .DataInvio & " alle ore " & .OraInvio & "."
               Else
                  eui_Informazioni.Text = "Da inviare."
               End If

               ' Assegna il titolo alla finestra.
               Me.Text = TITOLO_FINESTRA & " - Modifica messaggio"

            End With
         Else
            ' Comando Nuovo.

            ' Assegna i dati ai rispettivi controlli.
            eui_txtMittente.Text = eMail_Mittente
            eui_txtDestinatario.Text = eMail_Destinatario
            eui_txtOggetto.Text = eMail_Oggetto
            eui_txtMessaggio.Text = eMail_Messaggio
            eui_txtAllegati.Text = eMail_Allegati
            eui_txtCognome.Text = eMail_Cognome
            eui_txtNome.Text = eMail_Nome
            eui_txtIdCliente.Text = eMail_IdCliente
            eui_txtDataInvio.Text = String.Empty
            eui_txtOraInvio.Text = String.Empty
            eui_txtStato.Text = "Bozza"
            eui_txtCategoria.Text = eMail_Categoria

            ' Messaggio barra di stato.
            eui_Informazioni.Text = "Bozza."

            ' Assegna il titolo alla finestra.
            Me.Text = TITOLO_FINESTRA & " - Nuovo messaggio"

         End If

         ' Imposta lo stato attivo.
         eui_txtDestinatario.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub eui_cmdInvia_Click(sender As Object, e As EventArgs) Handles eui_cmdInvia.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Salva i dati nel database.
         If SalvaDati() = True Then

            ' Invia l'e-mail.
            If InviaEmail(eui_txtMittente.Text, eui_txtDestinatario.Text, eui_txtOggetto.Text, eui_txtMessaggio.Text, eui_txtAllegati.Text) = True Then

               ' Se è una nuova e-mail.
               If Me.Tag = String.Empty Then
                  Me.Tag = LeggiUltimoRecord(NOME_TABELLA)
               End If

               ' Modifica lo stato dell'e-mail in Inviata.
               ModificaStatoEmail(NOME_TABELLA, Me.Tag, Now.ToShortDateString, Now.ToShortTimeString, "Inviata")

               If IsNothing(g_frmEmail) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmEmail.AggiornaDati()
               End If

               ' Chiude la finestra.
               Me.Close()
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub eui_cmdSalva_Click(sender As Object, e As EventArgs) Handles eui_cmdSalva.Click
      Try
         ' Verifica la presenza di un Mittente.
         If eui_txtMittente.Text = String.Empty Then
            MessageBox.Show("E' necessario specificare un'indirizzo e-mail per il mittente!" & vbNewLine &
                            "Verificare nell'anagrafica 'Dati generali Azienda' la presenza di un'indirizzo e-mail valido.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_txtMittente.Focus()
            Exit Sub
         End If

         ' Verifica la presenza di un Destinatario.
         If eui_txtDestinatario.Text = String.Empty Then
            MessageBox.Show("E' necessario specificare un'indirizzo e-mail per il destinatario!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_txtDestinatario.Focus()
            Exit Sub
         End If

         ' Verifica la presenza di un Oggetto.
         If eui_txtOggetto.Text = String.Empty Then
            MessageBox.Show("E' necessario specificare l'oggetto del messaggio!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_txtOggetto.Focus()
            Exit Sub
         End If

         ' Salva i dati nel database.
         If SalvaDati() = True Then

            If IsNothing(g_frmEmail) = False Then
               ' Aggiorna la griglia dati.
               g_frmEmail.AggiornaDati()
            End If

            ' Chiude la finestra.
            Me.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Try
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAllegaFile_Click(sender As Object, e As EventArgs) Handles eui_cmdAllegaFile.Click
      Try
         ' Allega un file al messaggio.
         InserisciAllegati(eui_txtAllegati.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class