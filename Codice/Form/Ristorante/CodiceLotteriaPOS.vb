Public Class CodiceLotteriaPOS
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
    Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
    Friend WithEvents eui_cmdOk As Elegant.Ui.Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button

#End Region

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
   Friend WithEvents txtCodiceLotteria As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodiceLotteriaPOS))
      Me.txtCodiceLotteria = New System.Windows.Forms.TextBox()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.PictureBox1 = New System.Windows.Forms.PictureBox()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtCodiceLotteria
      '
      Me.txtCodiceLotteria.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodiceLotteria.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.txtCodiceLotteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodiceLotteria.ForeColor = System.Drawing.Color.Black
      Me.txtCodiceLotteria.Location = New System.Drawing.Point(81, 141)
      Me.txtCodiceLotteria.MaxLength = 8
      Me.txtCodiceLotteria.Name = "txtCodiceLotteria"
      Me.txtCodiceLotteria.Size = New System.Drawing.Size(209, 33)
      Me.txtCodiceLotteria.TabIndex = 1
      Me.txtCodiceLotteria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "731a82e5-f70c-4ddf-b28b-f1ffa872b5a8"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(241, 216)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(115, 53)
      Me.eui_cmdAnnulla.TabIndex = 5
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "81a66019-7a4d-49cb-99a0-096b15af1ba0"
      Me.eui_cmdOk.Location = New System.Drawing.Point(117, 216)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(115, 53)
      Me.eui_cmdOk.TabIndex = 4
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "27ea13ed-7109-46ec-b3b4-043242846473"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(9, 216)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(76, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 6
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(-33, -29)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(431, 242)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox1.TabIndex = 278
      Me.PictureBox1.TabStop = False
      '
      'CodiceLotteriaPOS
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(375, 290)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.txtCodiceLotteria)
      Me.Controls.Add(Me.PictureBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CodiceLotteriaPOS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Codice Lotteria"
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub CodiceLotteriaPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Pulisce la variabile globale da eventuali dati.
         CodiceLotteria = String.Empty

         ' Assegna il focus alla casella di testo.
         txtCodiceLotteria.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Codice Lotteria non valido.
         If txtCodiceLotteria.Text = String.Empty Then
            MessageBox.Show("Per confermare l'operazione è necessario inserire un Codice Lotteria valido. Tasto 'Annulla' se non si desidera inserire un Codice.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodiceLotteria.Focus()
            Me.DialogResult = DialogResult.None
         Else
            ' Salva il Codice lotteria in una variabile globale.
            CodiceLotteria = txtCodiceLotteria.Text.ToUpper
            Me.DialogResult = DialogResult.OK
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub txtCodiceLotteria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodiceLotteria.KeyPress
      e.KeyChar = e.KeyChar.ToString.ToUpper()
   End Sub
End Class
