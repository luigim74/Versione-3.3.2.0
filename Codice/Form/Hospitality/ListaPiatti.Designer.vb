<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaPiatti
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
      Me.lvwPiatti = New System.Windows.Forms.ListView()
      Me.clnCodice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnDescrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnListino1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnListino2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnListino3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnListino4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdInserisci = New Elegant.Ui.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.eui_dwnListino = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdListino1 = New Elegant.Ui.Button()
      Me.eui_cmdListino2 = New Elegant.Ui.Button()
      Me.eui_cmdListino3 = New Elegant.Ui.Button()
      Me.eui_cmdListino4 = New Elegant.Ui.Button()
      Me.eui_cmbCategoriaPiatti = New Elegant.Ui.ComboBox()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lvwPiatti
      '
      Me.lvwPiatti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnCodice, Me.clnDescrizione, Me.clnListino1, Me.clnListino2, Me.clnListino3, Me.clnListino4, Me.clnCategoria})
      Me.lvwPiatti.FullRowSelect = True
      Me.lvwPiatti.Location = New System.Drawing.Point(0, 23)
      Me.lvwPiatti.MultiSelect = False
      Me.lvwPiatti.Name = "lvwPiatti"
      Me.lvwPiatti.ShowGroups = False
      Me.lvwPiatti.Size = New System.Drawing.Size(722, 449)
      Me.lvwPiatti.TabIndex = 1
      Me.ToolTip1.SetToolTip(Me.lvwPiatti, "Fare doppio click sulla voce selezionata per effettuare l'inserimento.")
      Me.lvwPiatti.UseCompatibleStateImageBehavior = False
      Me.lvwPiatti.View = System.Windows.Forms.View.Details
      '
      'clnCodice
      '
      Me.clnCodice.Text = "Codice"
      '
      'clnDescrizione
      '
      Me.clnDescrizione.Text = "Descrizione"
      Me.clnDescrizione.Width = 300
      '
      'clnListino1
      '
      Me.clnListino1.Text = "Listino 1"
      Me.clnListino1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnListino1.Width = 80
      '
      'clnListino2
      '
      Me.clnListino2.Text = "Listino 2"
      Me.clnListino2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnListino2.Width = 80
      '
      'clnListino3
      '
      Me.clnListino3.Text = "Listino 3"
      Me.clnListino3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnListino3.Width = 80
      '
      'clnListino4
      '
      Me.clnListino4.Text = "Listino 4"
      Me.clnListino4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnListino4.Width = 80
      '
      'clnCategoria
      '
      Me.clnCategoria.Text = "Categoria"
      Me.clnCategoria.Width = 0
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "18f34544-3dbb-4745-85c7-b9b4886ff164"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(625, 475)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdAnnulla.TabIndex = 4
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdInserisci
      '
      Me.eui_cmdInserisci.Id = "5a06a0ca-1d3f-4ba0-a3b6-a9c00d271c54"
      Me.eui_cmdInserisci.Location = New System.Drawing.Point(529, 475)
      Me.eui_cmdInserisci.Name = "eui_cmdInserisci"
      Me.eui_cmdInserisci.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdInserisci.TabIndex = 3
      Me.eui_cmdInserisci.Text = "&Inserisci"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_dwnListino
      '
      Me.eui_dwnListino.Id = "5e64669a-7a94-4a84-8de4-9c3e29903c2d"
      Me.eui_dwnListino.Location = New System.Drawing.Point(9, 475)
      Me.eui_dwnListino.Name = "eui_dwnListino"
      Me.eui_dwnListino.Popup = Me.PopupMenu1
      Me.eui_dwnListino.Size = New System.Drawing.Size(88, 32)
      Me.eui_dwnListino.TabIndex = 2
      Me.eui_dwnListino.Text = "Listino 1"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdListino1, Me.eui_cmdListino2, Me.eui_cmdListino3, Me.eui_cmdListino4})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdListino1
      '
      Me.eui_cmdListino1.Id = "e62e8c41-dadd-44de-ac06-f63cdb80e5e3"
      Me.eui_cmdListino1.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdListino1.Name = "eui_cmdListino1"
      Me.eui_cmdListino1.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino1.TabIndex = 3
      Me.eui_cmdListino1.Text = "Listino 1"
      '
      'eui_cmdListino2
      '
      Me.eui_cmdListino2.Id = "46bbd961-ecc4-49c0-a420-6263c518a594"
      Me.eui_cmdListino2.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdListino2.Name = "eui_cmdListino2"
      Me.eui_cmdListino2.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino2.TabIndex = 4
      Me.eui_cmdListino2.Text = "Listino 2"
      '
      'eui_cmdListino3
      '
      Me.eui_cmdListino3.Id = "f99be207-768b-420f-bd55-d72aa0f3c3c7"
      Me.eui_cmdListino3.Location = New System.Drawing.Point(2, 48)
      Me.eui_cmdListino3.Name = "eui_cmdListino3"
      Me.eui_cmdListino3.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino3.TabIndex = 5
      Me.eui_cmdListino3.Text = "Listino 3"
      '
      'eui_cmdListino4
      '
      Me.eui_cmdListino4.Id = "014798ba-3fae-4cf9-a5da-6c5b61a37acb"
      Me.eui_cmdListino4.Location = New System.Drawing.Point(2, 71)
      Me.eui_cmdListino4.Name = "eui_cmdListino4"
      Me.eui_cmdListino4.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino4.TabIndex = 6
      Me.eui_cmdListino4.Text = "Listino 4"
      '
      'eui_cmbCategoriaPiatti
      '
      Me.eui_cmbCategoriaPiatti.Editable = False
      Me.eui_cmbCategoriaPiatti.FormattingEnabled = False
      Me.eui_cmbCategoriaPiatti.Id = "d3c08594-2644-4e76-836b-41ec7bea407d"
      Me.eui_cmbCategoriaPiatti.Location = New System.Drawing.Point(1, 1)
      Me.eui_cmbCategoriaPiatti.Name = "eui_cmbCategoriaPiatti"
      Me.eui_cmbCategoriaPiatti.Size = New System.Drawing.Size(721, 21)
      Me.eui_cmbCategoriaPiatti.TabIndex = 0
      Me.eui_cmbCategoriaPiatti.TextEditorWidth = 702
      '
      'ListaPiatti
      '
      Me.AcceptButton = Me.eui_cmdInserisci
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(723, 515)
      Me.Controls.Add(Me.eui_cmbCategoriaPiatti)
      Me.Controls.Add(Me.eui_dwnListino)
      Me.Controls.Add(Me.eui_cmdInserisci)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.lvwPiatti)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ListaPiatti"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleziona Piatto"
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lvwPiatti As System.Windows.Forms.ListView
   Friend WithEvents clnDescrizione As System.Windows.Forms.ColumnHeader
   Friend WithEvents clnListino1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisci As Elegant.Ui.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents clnCodice As System.Windows.Forms.ColumnHeader
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents eui_dwnListino As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdListino1 As Elegant.Ui.Button
   Friend WithEvents eui_cmdListino2 As Elegant.Ui.Button
   Friend WithEvents eui_cmdListino3 As Elegant.Ui.Button
   Friend WithEvents eui_cmdListino4 As Elegant.Ui.Button
   Friend WithEvents clnListino2 As ColumnHeader
   Friend WithEvents clnListino3 As ColumnHeader
   Friend WithEvents clnListino4 As ColumnHeader
   Friend WithEvents clnCategoria As ColumnHeader
   Friend WithEvents eui_cmbCategoriaPiatti As Elegant.Ui.ComboBox
End Class
