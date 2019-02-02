<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataModIstatC59
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
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_dtpDataGestione = New Elegant.Ui.DateTimePicker()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.Id = "10aae451-15b3-413e-9224-780895b0e4f7"
      Me.eui_cmdOk.Location = New System.Drawing.Point(18, 38)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(70, 31)
      Me.eui_cmdOk.TabIndex = 1
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "3b29147e-7cf3-4009-b947-7ebc3fdfc268"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(97, 38)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(70, 31)
      Me.eui_cmdAnnulla.TabIndex = 2
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_dtpDataGestione
      '
      Me.eui_dtpDataGestione.Id = "c2601d9d-2dd5-4f69-a5e6-059d2eb1709f"
      Me.eui_dtpDataGestione.Location = New System.Drawing.Point(7, 9)
      Me.eui_dtpDataGestione.Name = "eui_dtpDataGestione"
      Me.eui_dtpDataGestione.Size = New System.Drawing.Size(170, 21)
      Me.eui_dtpDataGestione.TabIndex = 0
      Me.eui_dtpDataGestione.TextEditorWidth = 151
      '
      'DataModIstatC59
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(184, 78)
      Me.ControlBox = False
      Me.Controls.Add(Me.eui_dtpDataGestione)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DataModIstatC59"
      Me.ShowIcon = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Data Modello ISTAT C/59"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_dtpDataGestione As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
End Class
