
Public Class NoteContiPOS
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdNo As Elegant.Ui.Button
   Friend WithEvents eui_cmdSì As Elegant.Ui.Button
   Public WithEvents Label7 As Label
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Public WithEvents Label6 As Label

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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NoteContiPOS))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdNo = New Elegant.Ui.Button()
      Me.eui_cmdSì = New Elegant.Ui.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdNo
      '
      Me.eui_cmdNo.DialogResult = System.Windows.Forms.DialogResult.No
      Me.eui_cmdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdNo.Id = "c8b736ae-1f3f-4782-9d1c-33a1230933d3"
      Me.eui_cmdNo.Location = New System.Drawing.Point(420, 313)
      Me.eui_cmdNo.Name = "eui_cmdNo"
      Me.eui_cmdNo.Size = New System.Drawing.Size(138, 53)
      Me.eui_cmdNo.TabIndex = 3
      Me.eui_cmdNo.Text = "&No"
      '
      'eui_cmdSì
      '
      Me.eui_cmdSì.DialogResult = System.Windows.Forms.DialogResult.Yes
      Me.eui_cmdSì.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSì.Id = "bb904420-4248-4a43-95cb-8fcda93080d8"
      Me.eui_cmdSì.Location = New System.Drawing.Point(273, 313)
      Me.eui_cmdSì.Name = "eui_cmdSì"
      Me.eui_cmdSì.Size = New System.Drawing.Size(138, 53)
      Me.eui_cmdSì.TabIndex = 2
      Me.eui_cmdSì.Text = "&Sì"
      '
      'Label6
      '
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(6, 9)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(552, 56)
      Me.Label6.TabIndex = 278
      Me.Label6.Text = "Si desidera salvare il Conto per una elaborazione futura? Non verrà stampato ness" &
    "un documento."
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(6, 83)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(74, 24)
      Me.Label7.TabIndex = 281
      Me.Label7.Text = "NOTE:"
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "57e6209c-4998-46b6-a4a0-a223dce1ffaa"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(10, 313)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 1
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_txtNote
      '
      Me.eui_txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtNote.Id = "f5bd6491-98a0-4b3b-a067-bd651effc915"
      Me.eui_txtNote.Location = New System.Drawing.Point(10, 107)
      Me.eui_txtNote.Multiline = True
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.Size = New System.Drawing.Size(548, 196)
      Me.eui_txtNote.TabIndex = 0
      Me.eui_txtNote.TextEditorWidth = 542
      '
      'NoteContiPOS
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdNo
      Me.ClientSize = New System.Drawing.Size(567, 375)
      Me.Controls.Add(Me.eui_txtNote)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.eui_cmdNo)
      Me.Controls.Add(Me.eui_cmdSì)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "NoteContiPOS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "PARCHEGGIA CONTO"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub NoteContiPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         eui_txtNote.Focus()

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

   Private Sub eui_cmdSì_Click(sender As Object, e As EventArgs) Handles eui_cmdSì.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.Tag = eui_txtNote.Text

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdNo_Click(sender As Object, e As EventArgs) Handles eui_cmdNo.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub
End Class
