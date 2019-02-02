
Public Class CodAccesso
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

   End Sub

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents txtChiave1 As System.Windows.Forms.TextBox
   Friend WithEvents txtChiave2 As System.Windows.Forms.TextBox
   Friend WithEvents txtChiave3 As System.Windows.Forms.TextBox
   Friend WithEvents txtChiave4 As System.Windows.Forms.TextBox
   Friend WithEvents txtChiave5 As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOK As Elegant.Ui.Button
   Friend WithEvents eui_cmdRichiesta As Elegant.Ui.Button
   Friend WithEvents Label7 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodAccesso))
      Me.txtChiave1 = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.PictureBox1 = New System.Windows.Forms.PictureBox()
      Me.txtChiave2 = New System.Windows.Forms.TextBox()
      Me.txtChiave3 = New System.Windows.Forms.TextBox()
      Me.txtChiave4 = New System.Windows.Forms.TextBox()
      Me.txtChiave5 = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdRichiesta = New Elegant.Ui.Button()
      Me.eui_cmdOK = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtChiave1
      '
      Me.txtChiave1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtChiave1.Location = New System.Drawing.Point(80, 160)
      Me.txtChiave1.MaxLength = 5
      Me.txtChiave1.Name = "txtChiave1"
      Me.txtChiave1.Size = New System.Drawing.Size(64, 20)
      Me.txtChiave1.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(80, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(226, 16)
      Me.Label1.TabIndex = 11
      Me.Label1.Text = "Digitare la chiave di attivazione"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(80, 143)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(108, 13)
      Me.Label2.TabIndex = 9
      Me.Label2.Text = "Chiave di attivazione:"
      '
      'LinkLabel1
      '
      Me.LinkLabel1.AutoSize = True
      Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LinkLabel1.Location = New System.Drawing.Point(80, 94)
      Me.LinkLabel1.Name = "LinkLabel1"
      Me.LinkLabel1.Size = New System.Drawing.Size(182, 20)
      Me.LinkLabel1.TabIndex = 8
      Me.LinkLabel1.TabStop = True
      Me.LinkLabel1.Text = "www.montanasoftware.it"
      '
      'Label3
      '
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(80, 48)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(344, 36)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "Inserire la chiave di attivazione del software o del modulo selezionato per attiv" &
    "are le funzionalità desiderate. "
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(31, 16)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox1.TabIndex = 184
      Me.PictureBox1.TabStop = False
      '
      'txtChiave2
      '
      Me.txtChiave2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtChiave2.Location = New System.Drawing.Point(152, 160)
      Me.txtChiave2.MaxLength = 5
      Me.txtChiave2.Name = "txtChiave2"
      Me.txtChiave2.Size = New System.Drawing.Size(64, 20)
      Me.txtChiave2.TabIndex = 1
      '
      'txtChiave3
      '
      Me.txtChiave3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtChiave3.Location = New System.Drawing.Point(224, 160)
      Me.txtChiave3.MaxLength = 5
      Me.txtChiave3.Name = "txtChiave3"
      Me.txtChiave3.Size = New System.Drawing.Size(64, 20)
      Me.txtChiave3.TabIndex = 2
      '
      'txtChiave4
      '
      Me.txtChiave4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtChiave4.Location = New System.Drawing.Point(296, 160)
      Me.txtChiave4.MaxLength = 5
      Me.txtChiave4.Name = "txtChiave4"
      Me.txtChiave4.Size = New System.Drawing.Size(64, 20)
      Me.txtChiave4.TabIndex = 3
      '
      'txtChiave5
      '
      Me.txtChiave5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtChiave5.Location = New System.Drawing.Point(368, 160)
      Me.txtChiave5.MaxLength = 5
      Me.txtChiave5.Name = "txtChiave5"
      Me.txtChiave5.Size = New System.Drawing.Size(64, 20)
      Me.txtChiave5.TabIndex = 4
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label4.Location = New System.Drawing.Point(144, 161)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(8, 16)
      Me.Label4.TabIndex = 1
      Me.Label4.Text = "-"
      '
      'Label5
      '
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label5.Location = New System.Drawing.Point(216, 161)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(8, 16)
      Me.Label5.TabIndex = 2
      Me.Label5.Text = "-"
      '
      'Label6
      '
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label6.Location = New System.Drawing.Point(288, 161)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(8, 16)
      Me.Label6.TabIndex = 3
      Me.Label6.Text = "-"
      '
      'Label7
      '
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label7.Location = New System.Drawing.Point(360, 161)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(8, 16)
      Me.Label7.TabIndex = 4
      Me.Label7.Text = "-"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdRichiesta
      '
      Me.eui_cmdRichiesta.Id = "3d475f17-0fcf-4d48-9243-89c35a9d21bf"
      Me.eui_cmdRichiesta.KeyTip = "R"
      Me.eui_cmdRichiesta.Location = New System.Drawing.Point(80, 200)
      Me.eui_cmdRichiesta.Name = "eui_cmdRichiesta"
      Me.eui_cmdRichiesta.ScreenTip.Caption = "Richiesta di attivazione"
      Me.eui_cmdRichiesta.ScreenTip.Text = "Apre il modulo per l'inserimento dei dati di registrazione dell'azienda e la rich" &
    "iesta del codice di attivazione del software"
      Me.eui_cmdRichiesta.Size = New System.Drawing.Size(136, 28)
      Me.eui_cmdRichiesta.TabIndex = 5
      Me.eui_cmdRichiesta.Text = "&Richiesta di attivazione"
      '
      'eui_cmdOK
      '
      Me.eui_cmdOK.Enabled = False
      Me.eui_cmdOK.Id = "a42a4328-fe79-4318-99a5-31ae4e7a2e04"
      Me.eui_cmdOK.KeyTip = "O"
      Me.eui_cmdOK.Location = New System.Drawing.Point(264, 200)
      Me.eui_cmdOK.Name = "eui_cmdOK"
      Me.eui_cmdOK.ScreenTip.Caption = "OK"
      Me.eui_cmdOK.ScreenTip.Text = "Conferma l'operazione  e chiude la finestra"
      Me.eui_cmdOK.Size = New System.Drawing.Size(80, 28)
      Me.eui_cmdOK.TabIndex = 6
      Me.eui_cmdOK.Text = "&OK"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "af215b9a-512b-4f8f-826a-e621e026b3ab"
      Me.eui_cmdAnnulla.KeyTip = "A"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(352, 200)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.ScreenTip.Caption = "Annulla"
      Me.eui_cmdAnnulla.ScreenTip.Text = "Annulla l'operazione e chiude la finestra"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(80, 28)
      Me.eui_cmdAnnulla.TabIndex = 7
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'CodAccesso
      '
      Me.AcceptButton = Me.eui_cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(445, 237)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOK)
      Me.Controls.Add(Me.eui_cmdRichiesta)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtChiave5)
      Me.Controls.Add(Me.txtChiave4)
      Me.Controls.Add(Me.txtChiave3)
      Me.Controls.Add(Me.txtChiave2)
      Me.Controls.Add(Me.LinkLabel1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtChiave1)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.Label3)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CodAccesso"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Chiave di attivazione licenza"
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   ' Codice di accesso per attivare il software.
   Private chiaveAttivazione As String
   Private nomeChiaveConfig As String

   Private Sub VerificaChiave()
      Try
         ' Ver. completa.
         If UCase(txtChiave1.Text.ToUpper & txtChiave2.Text.ToUpper & txtChiave3.Text.ToUpper & _
                  txtChiave4.Text.ToUpper & txtChiave5.Text.ToUpper) = chiaveAttivazione Then
            eui_cmdOK.Enabled = True
            Exit Sub
         Else
            eui_cmdOK.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdOK.Click
      Try
         g_frmMain.AttivaProdotto(chiaveAttivazione, txtChiave1.Text.ToUpper, txtChiave2.Text.ToUpper, txtChiave3.Text.ToUpper,
                                  txtChiave4.Text.ToUpper, txtChiave5.Text.ToUpper, nomeChiaveConfig)

         Me.DialogResult = DialogResult.OK

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdAnnulla.Click
      Try
         Me.DialogResult = DialogResult.Cancel
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub CodAccesso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      Me.Text = NOME_PRODOTTO & " - " & Me.Text

      Select Case Me.Tag.ToString.ToUpper
         Case Modulo.NOME_HOSPITALITY
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY)
            nomeChiaveConfig = Modulo.NOME_HOSPITALITY_CONFIG

         Case Modulo.NOME_BAR
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR)
            nomeChiaveConfig = Modulo.NOME_BAR_CONFIG

         Case Modulo.NOME_CHEF
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE)
            nomeChiaveConfig = Modulo.NOME_CHEF_CONFIG

         Case Modulo.NOME_SPORTING
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO)
            nomeChiaveConfig = Modulo.NOME_SPORTING_CONFIG

         Case Modulo.NOME_HOTEL
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOTEL)
            nomeChiaveConfig = Modulo.NOME_HOTEL_CONFIG

         Case Modulo.NOME_PALMARI
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PALMARI)
            nomeChiaveConfig = Modulo.NOME_PALMARI_CONFIG

         Case Modulo.NOME_PREN_ONLINE
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PREN_ONLINE)
            nomeChiaveConfig = Modulo.NOME_PREN_ONLINE_CONFIG

         Case Modulo.NOME_MAGAZZINO
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_MAGAZZINO)
            nomeChiaveConfig = Modulo.NOME_MAGAZZINO_CONFIG

         Case Modulo.NOME_ETICHETTE
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_ETICHETTE)
            nomeChiaveConfig = Modulo.NOME_ETICHETTE_CONFIG

         Case Modulo.NOME_PENDRIVE_RECOVERY
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY)
            nomeChiaveConfig = Modulo.NOME_PENDRIVE_RECOVERY_CONFIG

         Case Modulo.NOME_PENDRIVE_PORTABLE
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE)
            nomeChiaveConfig = Modulo.NOME_PENDRIVE_PORTABLE_CONFIG

         Case Modulo.NOME_REG_CASSA
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_REG_CASSA)
            nomeChiaveConfig = Modulo.NOME_REG_CASSA_CONFIG

         Case Modulo.NOME_FATT_ELETTRONICA
            chiaveAttivazione = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_FATT_ELETTRONICA)
            nomeChiaveConfig = Modulo.NOME_FATT_ELETTRONICA_CONFIG

      End Select

      txtChiave1.Focus()

   End Sub

   Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim Web As New Varie.WebSolution
         Web.ConnettiInternet(MS_WEB)

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtChiave1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChiave1.TextChanged
      VerificaChiave()
   End Sub

   Private Sub txtChiave2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChiave2.TextChanged
      VerificaChiave()
   End Sub

   Private Sub txtChiave3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChiave3.TextChanged
      VerificaChiave()
   End Sub

   Private Sub txtChiave4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChiave4.TextChanged
      VerificaChiave()
   End Sub

   Private Sub txtChiave5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChiave5.TextChanged
      VerificaChiave()
   End Sub

   Private Sub eui_cmdRichiesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdRichiesta.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim frm As Form = New frmModuloReg
         frm.Tag = chiaveAttivazione & "-" & Me.Tag.ToString

         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("La richiesta è stata inviata con successo! Riceverà il codice di attivazione all'indirizzo e-mail specificato." & vbNewLine & _
                            "La ringraziamo per aver scelto il nostro prodotto software " & NOME_PRODOTTO & ".", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub
End Class
