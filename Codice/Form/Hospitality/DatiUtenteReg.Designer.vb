<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatiUtenteReg
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatiUtenteReg))
      Me.txtDati = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.eui_cmdChiudi = New Elegant.Ui.Button()
      Me.eui_cmdCopia = New Elegant.Ui.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.SuspendLayout()
      '
      'txtDati
      '
      Me.txtDati.Location = New System.Drawing.Point(16, 112)
      Me.txtDati.Multiline = True
      Me.txtDati.Name = "txtDati"
      Me.txtDati.ReadOnly = True
      Me.txtDati.Size = New System.Drawing.Size(672, 248)
      Me.txtDati.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(672, 88)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = resources.GetString("Label1.Text")
      '
      'eui_cmdChiudi
      '
      Me.eui_cmdChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdChiudi.Id = "61587055-035a-4f91-878c-5f280b2528ad"
      Me.eui_cmdChiudi.Location = New System.Drawing.Point(592, 376)
      Me.eui_cmdChiudi.Name = "eui_cmdChiudi"
      Me.eui_cmdChiudi.Size = New System.Drawing.Size(88, 28)
      Me.eui_cmdChiudi.TabIndex = 2
      Me.eui_cmdChiudi.Text = "&Chiudi"
      '
      'eui_cmdCopia
      '
      Me.eui_cmdCopia.Id = "c9ecc775-9647-4487-b063-bec3291a19a8"
      Me.eui_cmdCopia.Location = New System.Drawing.Point(496, 376)
      Me.eui_cmdCopia.Name = "eui_cmdCopia"
      Me.eui_cmdCopia.Size = New System.Drawing.Size(88, 28)
      Me.eui_cmdCopia.TabIndex = 1
      Me.eui_cmdCopia.Text = "&Copia"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'DatiUtenteReg
      '
      Me.AcceptButton = Me.eui_cmdCopia
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdChiudi
      Me.ClientSize = New System.Drawing.Size(703, 417)
      Me.Controls.Add(Me.eui_cmdCopia)
      Me.Controls.Add(Me.eui_cmdChiudi)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtDati)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DatiUtenteReg"
      Me.ShowIcon = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Dati di registrazione per la richiesta di attivazione del software"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtDati As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents eui_cmdChiudi As Elegant.Ui.Button
   Friend WithEvents eui_cmdCopia As Elegant.Ui.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
End Class
