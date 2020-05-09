<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpostaTimerTavolo
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla mediante l'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpostaTimerTavolo))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmbMinuti = New Elegant.Ui.ComboBox()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.eui_cmdPiù = New Elegant.Ui.Button()
      Me.eui_cmdMeno = New Elegant.Ui.Button()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmbMinuti
      '
      Me.eui_cmbMinuti.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmbMinuti.FormattingEnabled = False
      Me.eui_cmbMinuti.Id = "f9914c09-f437-433a-94fa-7685b22345b9"
      Me.eui_cmbMinuti.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60"})
      Me.eui_cmbMinuti.Location = New System.Drawing.Point(16, 37)
      Me.eui_cmbMinuti.Name = "eui_cmbMinuti"
      Me.eui_cmbMinuti.Size = New System.Drawing.Size(211, 41)
      Me.eui_cmbMinuti.TabIndex = 0
      Me.eui_cmbMinuti.TextEditorWidth = 192
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "a9d5cc3e-bd84-4357-9a36-8aca34ba269a"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(273, 107)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 5
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "b254b682-2ad1-411d-91bb-cb1a7787ef2d"
      Me.eui_cmdOk.Location = New System.Drawing.Point(135, 107)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 4
      Me.eui_cmdOk.Text = "&OK"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(12, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(85, 24)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "MINUTI:"
      '
      'eui_cmdPiù
      '
      Me.eui_cmdPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdPiù.Id = "2841924c-cd6f-4b84-bf23-dd1bb7db67fd"
      Me.eui_cmdPiù.Location = New System.Drawing.Point(326, 37)
      Me.eui_cmdPiù.Name = "eui_cmdPiù"
      Me.eui_cmdPiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdPiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdPiù.Size = New System.Drawing.Size(75, 41)
      Me.eui_cmdPiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdPiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdPiù.TabIndex = 2
      '
      'eui_cmdMeno
      '
      Me.eui_cmdMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdMeno.Id = "bed4e6be-1643-4f56-88bb-dbf12977913d"
      Me.eui_cmdMeno.Location = New System.Drawing.Point(242, 37)
      Me.eui_cmdMeno.Name = "eui_cmdMeno"
      Me.eui_cmdMeno.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdMeno.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdMeno.Size = New System.Drawing.Size(75, 41)
      Me.eui_cmdMeno.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdMeno.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdMeno.TabIndex = 1
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "d7bec36f-69f6-456f-b43e-d9ba7343c3bf"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(16, 107)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 3
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'ImpostaTimerTavolo
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(417, 176)
      Me.Controls.Add(Me.eui_cmdPiù)
      Me.Controls.Add(Me.eui_cmdMeno)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_cmbMinuti)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ImpostaTimerTavolo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Imposta Timer"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmbMinuti As Elegant.Ui.ComboBox
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Public WithEvents Label1 As Label
   Friend WithEvents eui_cmdPiù As Elegant.Ui.Button
   Friend WithEvents eui_cmdMeno As Elegant.Ui.Button
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
End Class
