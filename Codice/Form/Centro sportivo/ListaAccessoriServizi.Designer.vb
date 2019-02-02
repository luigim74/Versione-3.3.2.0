<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaAccessoriServizi
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.lvwAccessoriServizi = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdInserisci = New Elegant.Ui.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.SuspendLayout()
      '
      'lvwAccessoriServizi
      '
      Me.lvwAccessoriServizi.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
      Me.lvwAccessoriServizi.FullRowSelect = True
      Me.lvwAccessoriServizi.Location = New System.Drawing.Point(0, 0)
      Me.lvwAccessoriServizi.MultiSelect = False
      Me.lvwAccessoriServizi.Name = "lvwAccessoriServizi"
      Me.lvwAccessoriServizi.ShowGroups = False
      Me.lvwAccessoriServizi.Size = New System.Drawing.Size(410, 433)
      Me.lvwAccessoriServizi.TabIndex = 0
      Me.ToolTip1.SetToolTip(Me.lvwAccessoriServizi, "Fare doppio click sulla voce selezionata per effettuare l'inserimento.")
      Me.lvwAccessoriServizi.UseCompatibleStateImageBehavior = False
      Me.lvwAccessoriServizi.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Codice"
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Descrizione"
      Me.ColumnHeader2.Width = 240
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Importo"
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 80
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "18f34544-3dbb-4745-85c7-b9b4886ff164"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(313, 436)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdAnnulla.TabIndex = 2
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdInserisci
      '
      Me.eui_cmdInserisci.Id = "5a06a0ca-1d3f-4ba0-a3b6-a9c00d271c54"
      Me.eui_cmdInserisci.Location = New System.Drawing.Point(217, 436)
      Me.eui_cmdInserisci.Name = "eui_cmdInserisci"
      Me.eui_cmdInserisci.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdInserisci.TabIndex = 1
      Me.eui_cmdInserisci.Text = "&Inserisci"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ListaAccessoriServizi
      '
      Me.AcceptButton = Me.eui_cmdInserisci
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(410, 477)
      Me.Controls.Add(Me.eui_cmdInserisci)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.lvwAccessoriServizi)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ListaAccessoriServizi"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleziona Accessori"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents lvwAccessoriServizi As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisci As Elegant.Ui.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
