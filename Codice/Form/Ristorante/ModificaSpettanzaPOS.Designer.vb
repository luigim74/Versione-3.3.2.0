<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificaSpettanzaPOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificaSpettanzaPOS))
        Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
        Me.eui_cmdAnnulla = New Elegant.Ui.Button()
        Me.eui_cmdOk = New Elegant.Ui.Button()
        Me.eui_txtSpettanza = New Elegant.Ui.TextBox()
        Me.eui_cmdTastiera = New Elegant.Ui.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'formFrameSkinner
        '
        Me.formFrameSkinner.Form = Me
        '
        'eui_cmdAnnulla
        '
        Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdAnnulla.Id = "0dbff142-69f4-4a22-aa9f-e8f0da3d33ee"
        Me.eui_cmdAnnulla.Location = New System.Drawing.Point(248, 102)
        Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
        Me.eui_cmdAnnulla.Size = New System.Drawing.Size(117, 53)
        Me.eui_cmdAnnulla.TabIndex = 3
        Me.eui_cmdAnnulla.Text = "&Annulla"
        '
        'eui_cmdOk
        '
        Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdOk.Id = "f84627ce-4244-4744-a597-c8ed9fce463c"
        Me.eui_cmdOk.Location = New System.Drawing.Point(122, 102)
        Me.eui_cmdOk.Name = "eui_cmdOk"
        Me.eui_cmdOk.Size = New System.Drawing.Size(117, 53)
        Me.eui_cmdOk.TabIndex = 2
        Me.eui_cmdOk.Text = "&OK"
        '
        'eui_txtSpettanza
        '
        Me.eui_txtSpettanza.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_txtSpettanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_txtSpettanza.Id = "6b687c66-7ede-469c-8482-0a2f5f19e3d2"
        Me.eui_txtSpettanza.Location = New System.Drawing.Point(16, 33)
        Me.eui_txtSpettanza.Name = "eui_txtSpettanza"
        Me.eui_txtSpettanza.Size = New System.Drawing.Size(349, 41)
        Me.eui_txtSpettanza.TabIndex = 0
        Me.eui_txtSpettanza.Text = "0,00"
        Me.eui_txtSpettanza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.eui_txtSpettanza.TextEditorWidth = 343
        '
        'eui_cmdTastiera
        '
        Me.eui_cmdTastiera.Id = "496087b8-18ef-400f-89a2-9ca0517c16d8"
        Me.eui_cmdTastiera.Location = New System.Drawing.Point(16, 102)
        Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
        Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
        Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
        Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
        Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
        Me.eui_cmdTastiera.TabIndex = 1
        Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
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
        Me.Label1.Size = New System.Drawing.Size(138, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SPETTANZA:"
        '
        'ModificaSpettanzaPOS
        '
        Me.AcceptButton = Me.eui_cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.CancelButton = Me.eui_cmdAnnulla
        Me.ClientSize = New System.Drawing.Size(384, 170)
        Me.Controls.Add(Me.eui_txtSpettanza)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.eui_cmdTastiera)
        Me.Controls.Add(Me.eui_cmdAnnulla)
        Me.Controls.Add(Me.eui_cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ModificaSpettanzaPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modifica spettanza"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
    Friend WithEvents eui_cmdOk As Elegant.Ui.Button
    Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
    Friend WithEvents eui_txtSpettanza As Elegant.Ui.TextBox
    Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
    Public WithEvents Label1 As Label
End Class
