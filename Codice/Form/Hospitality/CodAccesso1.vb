
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
   Friend WithEvents cmdOK As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents txtChiaveAccesso As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CodAccesso))
      Me.cmdOK = New System.Windows.Forms.Button
      Me.cmdAnnulla = New System.Windows.Forms.Button
      Me.txtChiaveAccesso = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
      Me.Label3 = New System.Windows.Forms.Label
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.SuspendLayout()
      '
      'cmdOK
      '
      Me.cmdOK.Enabled = False
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(184, 192)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.TabIndex = 1
      Me.cmdOK.Text = "&OK"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(264, 192)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.TabIndex = 2
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'txtChiaveAccesso
      '
      Me.txtChiaveAccesso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtChiaveAccesso.Location = New System.Drawing.Point(80, 152)
      Me.txtChiaveAccesso.Name = "txtChiaveAccesso"
      Me.txtChiaveAccesso.Size = New System.Drawing.Size(264, 20)
      Me.txtChiaveAccesso.TabIndex = 0
      Me.txtChiaveAccesso.Text = ""
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label1.Location = New System.Drawing.Point(80, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(182, 18)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Digitare la chiave di accesso"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label2.Location = New System.Drawing.Point(80, 136)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(99, 16)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "Chiave di accesso:"
      '
      'LinkLabel1
      '
      Me.LinkLabel1.AutoSize = True
      Me.LinkLabel1.Location = New System.Drawing.Point(80, 104)
      Me.LinkLabel1.Name = "LinkLabel1"
      Me.LinkLabel1.Size = New System.Drawing.Size(128, 16)
      Me.LinkLabel1.TabIndex = 3
      Me.LinkLabel1.TabStop = True
      Me.LinkLabel1.Text = "www.montanasoftware.it"
      '
      'Label3
      '
      Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label3.Location = New System.Drawing.Point(80, 48)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(272, 56)
      Me.Label3.TabIndex = 5
      Me.Label3.Text = "E' necessario digitare la chiave di accesso. In caso contrario non sarà possibile" & _
      " utilizzare l'applicazione. Se sei un nuovo utente, richiedi la chiave di access" & _
      "o compilando con i tuoi dati la scheda che trovi sul sito:"
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
      Me.PictureBox1.TabIndex = 184
      Me.PictureBox1.TabStop = False
      '
      'CodAccesso
      '
      Me.AcceptButton = Me.cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(368, 230)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.LinkLabel1)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtChiaveAccesso)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CodAccesso"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Chiave di Accesso"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private DatiConfig As AppConfig
   Public OK As Boolean

   Private Sub CodAccesso_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         If OK = False Then
            Application.Exit()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
      Try
         Dim KeyAccess As String = txtChiaveAccesso.Text.ToUpper
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         DatiConfig.SetValue("KeyAccess", KeyAccess)

         OK = True

         Me.DialogResult = DialogResult.OK

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtChiaveAccesso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChiaveAccesso.TextChanged
      Try
         If UCase(txtChiaveAccesso.Text.ToUpper) = CHIAVE_ACCESSO Then
            cmdOK.Enabled = True
         Else
            cmdOK.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      Try
         Me.DialogResult = DialogResult.None
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub CodAccesso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Me.Text = NOME_PRODOTTO & " - " & Me.Text
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
End Class
