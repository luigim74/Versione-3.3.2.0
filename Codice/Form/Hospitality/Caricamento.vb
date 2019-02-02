Public Class frmElaborazione
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
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.SuspendLayout()
      '
      'ProgressBar1
      '
      Me.ProgressBar1.Location = New System.Drawing.Point(8, 8)
      Me.ProgressBar1.Name = "ProgressBar1"
      Me.ProgressBar1.Size = New System.Drawing.Size(168, 16)
      Me.ProgressBar1.TabIndex = 0
      Me.ProgressBar1.Value = 50
      '
      'Timer1
      '
      Me.Timer1.Interval = 1000
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmElaborazione
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(193, 47)
      Me.ControlBox = False
      Me.Controls.Add(Me.ProgressBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "frmElaborazione"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Salvataggio dati in corso..."
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Caricamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ProgressBar1.Minimum = 1
      ProgressBar1.Maximum = 1000
      ProgressBar1.Value = 300
      ProgressBar1.Step = 50

      Timer1.Enabled = True
   End Sub

   Private Sub frmElaborazione_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If ProgressBar1.Value = 300 Then
            ' Salva i dati di configurazione del programma.
            g_frmMain.SalvaDatiConfig()

            ' Salva una copia di backup degli archivi.
            g_frmMain.SalvaCopiaBackup()

            ' Se il modulo Pen Drive Recovery è attivo salva i dati.
            g_frmMain.SalvaDatiPenDriveRecovery()

         End If

         If ProgressBar1.Value = 900 Then
            ' Salva i dati dell'utente e le chiavi di attivazione sul web.
            g_frmMain.InviaDatiLicenza()
         End If

         ProgressBar1.PerformStep()

         If ProgressBar1.Value = ProgressBar1.Maximum Then
            Me.Close()
         End If

      Catch ex As Exception
         ' disattiva il timer.
         Timer1.Enabled = False

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Me.Close()
      End Try
   End Sub
End Class
