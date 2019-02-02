Public Class frmPassword
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal val As Boolean)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      ImpostaPwd = val
   End Sub

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If Disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(Disposing)
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents cmdOK As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Public WithEvents label As System.Windows.Forms.Label
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents txtVerifica As System.Windows.Forms.TextBox
   Friend WithEvents txtPassword As System.Windows.Forms.TextBox
   Public WithEvents lblVerifica As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPassword))
      Me.cmdOK = New System.Windows.Forms.Button
      Me.cmdAnnulla = New System.Windows.Forms.Button
      Me.label = New System.Windows.Forms.Label
      Me.txtVerifica = New System.Windows.Forms.TextBox
      Me.txtPassword = New System.Windows.Forms.TextBox
      Me.lblVerifica = New System.Windows.Forms.Label
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.SuspendLayout()
      '
      'cmdOK
      '
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(128, 112)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.TabIndex = 2
      Me.cmdOK.Text = "&OK"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(208, 112)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.TabIndex = 3
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.SystemColors.Control
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.SystemColors.Desktop
      Me.label.Location = New System.Drawing.Point(80, 16)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(110, 16)
      Me.label.TabIndex = 182
      Me.label.Text = "Digitare la password:"
      '
      'txtVerifica
      '
      Me.txtVerifica.Location = New System.Drawing.Point(80, 80)
      Me.txtVerifica.Name = "txtVerifica"
      Me.txtVerifica.PasswordChar = Microsoft.VisualBasic.ChrW(42)
      Me.txtVerifica.Size = New System.Drawing.Size(208, 20)
      Me.txtVerifica.TabIndex = 1
      Me.txtVerifica.Text = ""
      '
      'txtPassword
      '
      Me.txtPassword.Location = New System.Drawing.Point(80, 32)
      Me.txtPassword.Name = "txtPassword"
      Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
      Me.txtPassword.Size = New System.Drawing.Size(208, 20)
      Me.txtPassword.TabIndex = 0
      Me.txtPassword.Text = ""
      '
      'lblVerifica
      '
      Me.lblVerifica.AutoSize = True
      Me.lblVerifica.BackColor = System.Drawing.SystemColors.Control
      Me.lblVerifica.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblVerifica.ForeColor = System.Drawing.SystemColors.Desktop
      Me.lblVerifica.Location = New System.Drawing.Point(80, 64)
      Me.lblVerifica.Name = "lblVerifica"
      Me.lblVerifica.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblVerifica.Size = New System.Drawing.Size(192, 16)
      Me.lblVerifica.TabIndex = 181
      Me.lblVerifica.Text = "Digitare la password per confermarla:"
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
      Me.PictureBox1.TabIndex = 183
      Me.PictureBox1.TabStop = False
      '
      'frmPassword
      '
      Me.AcceptButton = Me.cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(306, 152)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.label)
      Me.Controls.Add(Me.txtVerifica)
      Me.Controls.Add(Me.txtPassword)
      Me.Controls.Add(Me.lblVerifica)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPassword"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Imposta password"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private DatiConfig As AppConfig
   Private Pwd As String
   Private ImpostaPwd As Boolean

   Private Sub LeggiDatiConfig()
      Try
         Pwd = DatiConfig.GetValue("Pwd")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try
         DatiConfig.SetValue("Pwd", Pwd)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         LeggiDatiConfig()

         If Pwd <> "" Then
            If ImpostaPwd = False Then
               Me.Text = "Digitare la password"
            Else
               Me.Text = "Annulla password"
            End If
            lblVerifica.Visible = False
            txtVerifica.Visible = False
            cmdOK.Location = New Point(cmdOK.Location.X, 64)
            cmdAnnulla.Location = New Point(cmdAnnulla.Location.X, 64)
            Me.Size = New Size(Me.Width, 132)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
      Try
         ' Se si vuole impostare la password.
         If ImpostaPwd = True Then

            ' Se la password non esiste.
            If Pwd = "" Then

               ' Verifica che le caselle di testo contengano un valore.
               If txtPassword.Text = "" Then
                  MsgBox("Digitare una password.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
                  Exit Sub
               End If

               If txtVerifica.Text = "" Then
                  MsgBox("Digitare la password per confermarla.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
                  Exit Sub
               End If

               ' Se le due caselle di testo contengono lo stesso valore.
               If txtPassword.Text = txtVerifica.Text Then
                  ' Viene salvata la password.
                  Pwd = txtPassword.Text
                  g_frmMain.mnuArchiviProteggi.Text = "&Annulla password"
               Else
                  ' Visualizza un messaggio informativo.
                  MsgBox("Verificare la nuova password digitandola di nuovo nella casella di conferma e scegliendo OK.", _
                          MsgBoxStyle.OKOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
                  txtVerifica.Focus()
                  Exit Sub
               End If

            Else

               ' Se la password esiste.
               If txtPassword.Text = Pwd Then
                  ' Viene camcellata.
                  Pwd = ""
                  g_frmMain.mnuArchiviProteggi.Text = "&Imposta password"
               Else
                  ' Visualizza un messaggio informativo.
                  MsgBox("La password digitata non è valida.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
                  txtPassword.Focus()
                  Exit Sub
               End If

            End If

         Else

            ' Se si vuole verificare la password per aprire il programma.
            If txtPassword.Text = Pwd Then
               Me.DialogResult = DialogResult.OK
            Else
               ' Visualizza un messaggio informativo.
               MsgBox("La password digitata non è valida.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
               txtPassword.Focus()
               Me.DialogResult = DialogResult.None
               Exit Sub
            End If

         End If

         ' Salva la password.
         SalvaDatiConfig()

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class
