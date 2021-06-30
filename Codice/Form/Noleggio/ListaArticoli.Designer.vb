<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaArticoli
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaArticoli))
        Me.lvwArticoli = New System.Windows.Forms.ListView()
        Me.clnCodice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnDescrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnGiacenza = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnQuantità = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnCostoUnitario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnCostoTotale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.eui_cmdAnnulla = New Elegant.Ui.Button()
        Me.eui_cmdInserisci = New Elegant.Ui.Button()
        Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.eui_cmbCategoriaArticoli = New Elegant.Ui.ComboBox()
        Me.eui_cmdPiùQuantità = New Elegant.Ui.Button()
        Me.eui_cmdMenoQuantità = New Elegant.Ui.Button()
        Me.SuspendLayout()
        '
        'lvwArticoli
        '
        Me.lvwArticoli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnCodice, Me.clnDescrizione, Me.clnUM, Me.clnGiacenza, Me.clnQuantità, Me.clnCostoUnitario, Me.clnCostoTotale, Me.clnCategoria, Me.clnId})
        Me.lvwArticoli.FullRowSelect = True
        Me.lvwArticoli.HideSelection = False
        Me.lvwArticoli.Location = New System.Drawing.Point(0, 23)
        Me.lvwArticoli.MultiSelect = False
        Me.lvwArticoli.Name = "lvwArticoli"
        Me.lvwArticoli.ShowGroups = False
        Me.lvwArticoli.Size = New System.Drawing.Size(814, 449)
        Me.lvwArticoli.StateImageList = Me.ImageList1
        Me.lvwArticoli.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.lvwArticoli, "Fare doppio click sulla voce selezionata per effettuare l'inserimento.")
        Me.lvwArticoli.UseCompatibleStateImageBehavior = False
        Me.lvwArticoli.View = System.Windows.Forms.View.Details
        '
        'clnCodice
        '
        Me.clnCodice.Text = "Codice"
        Me.clnCodice.Width = 100
        '
        'clnDescrizione
        '
        Me.clnDescrizione.Text = "Descrizione"
        Me.clnDescrizione.Width = 300
        '
        'clnUM
        '
        Me.clnUM.Text = "U.M."
        Me.clnUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clnUM.Width = 70
        '
        'clnGiacenza
        '
        Me.clnGiacenza.Text = "Giacenza"
        Me.clnGiacenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.clnGiacenza.Width = 70
        '
        'clnQuantità
        '
        Me.clnQuantità.Text = "Quantità"
        Me.clnQuantità.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'clnCostoUnitario
        '
        Me.clnCostoUnitario.Text = "Costo unitario"
        Me.clnCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.clnCostoUnitario.Width = 90
        '
        'clnCostoTotale
        '
        Me.clnCostoTotale.Text = "Costo totale"
        Me.clnCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.clnCostoTotale.Width = 90
        '
        'clnCategoria
        '
        Me.clnCategoria.Text = "Categoria"
        Me.clnCategoria.Width = 0
        '
        'clnId
        '
        Me.clnId.Text = "Id"
        Me.clnId.Width = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "id_insert_shapes_large.png")
        '
        'eui_cmdAnnulla
        '
        Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.eui_cmdAnnulla.Id = "6c7b8cef-aa2c-46aa-b84a-4a2d9a2bb695"
        Me.eui_cmdAnnulla.Location = New System.Drawing.Point(715, 475)
        Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
        Me.eui_cmdAnnulla.Size = New System.Drawing.Size(92, 32)
        Me.eui_cmdAnnulla.TabIndex = 5
        Me.eui_cmdAnnulla.Text = "&Annulla"
        '
        'eui_cmdInserisci
        '
        Me.eui_cmdInserisci.Id = "19e47cc5-7221-4050-b4aa-0c2c8fce14c0"
        Me.eui_cmdInserisci.Location = New System.Drawing.Point(619, 475)
        Me.eui_cmdInserisci.Name = "eui_cmdInserisci"
        Me.eui_cmdInserisci.Size = New System.Drawing.Size(92, 32)
        Me.eui_cmdInserisci.TabIndex = 4
        Me.eui_cmdInserisci.Text = "&Inserisci"
        '
        'formFrameSkinner
        '
        Me.formFrameSkinner.AllowGlass = False
        Me.formFrameSkinner.Form = Me
        '
        'eui_cmbCategoriaArticoli
        '
        Me.eui_cmbCategoriaArticoli.Editable = False
        Me.eui_cmbCategoriaArticoli.FormattingEnabled = False
        Me.eui_cmbCategoriaArticoli.Id = "a92485b4-2aec-4867-b262-0c4b2c094bae"
        Me.eui_cmbCategoriaArticoli.Location = New System.Drawing.Point(1, 1)
        Me.eui_cmbCategoriaArticoli.Name = "eui_cmbCategoriaArticoli"
        Me.eui_cmbCategoriaArticoli.Size = New System.Drawing.Size(813, 21)
        Me.eui_cmbCategoriaArticoli.TabIndex = 0
        Me.eui_cmbCategoriaArticoli.TextEditorWidth = 794
        '
        'eui_cmdPiùQuantità
        '
        Me.eui_cmdPiùQuantità.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdPiùQuantità.Id = "c3208c2e-8df8-4add-a696-7fe81a1a22cb"
        Me.eui_cmdPiùQuantità.Location = New System.Drawing.Point(9, 475)
        Me.eui_cmdPiùQuantità.Name = "eui_cmdPiùQuantità"
        Me.eui_cmdPiùQuantità.ScreenTip.Text = "Aumenta la quantità dell'elemento selezionato nella lista."
        Me.eui_cmdPiùQuantità.Size = New System.Drawing.Size(51, 32)
        Me.eui_cmdPiùQuantità.TabIndex = 2
        Me.eui_cmdPiùQuantità.Text = "+"
        '
        'eui_cmdMenoQuantità
        '
        Me.eui_cmdMenoQuantità.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdMenoQuantità.Id = "fe395f53-5afa-4f37-ab65-23af8684d106"
        Me.eui_cmdMenoQuantità.Location = New System.Drawing.Point(63, 475)
        Me.eui_cmdMenoQuantità.Name = "eui_cmdMenoQuantità"
        Me.eui_cmdMenoQuantità.ScreenTip.Text = "Diminuisce la quantità dell'elemento selezionato nella lista."
        Me.eui_cmdMenoQuantità.Size = New System.Drawing.Size(51, 32)
        Me.eui_cmdMenoQuantità.TabIndex = 3
        Me.eui_cmdMenoQuantità.Text = "-"
        '
        'ListaArticoli
        '
        Me.AcceptButton = Me.eui_cmdInserisci
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.CancelButton = Me.eui_cmdAnnulla
        Me.ClientSize = New System.Drawing.Size(816, 512)
        Me.Controls.Add(Me.eui_cmdMenoQuantità)
        Me.Controls.Add(Me.eui_cmdPiùQuantità)
        Me.Controls.Add(Me.eui_cmbCategoriaArticoli)
        Me.Controls.Add(Me.eui_cmdInserisci)
        Me.Controls.Add(Me.eui_cmdAnnulla)
        Me.Controls.Add(Me.lvwArticoli)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListaArticoli"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleziona Articolo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwArticoli As System.Windows.Forms.ListView
   Friend WithEvents clnDescrizione As System.Windows.Forms.ColumnHeader
   Friend WithEvents clnUM As System.Windows.Forms.ColumnHeader
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisci As Elegant.Ui.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents clnCodice As System.Windows.Forms.ColumnHeader
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents clnGiacenza As ColumnHeader
    Friend WithEvents clnCostoUnitario As ColumnHeader
    Friend WithEvents clnCategoria As ColumnHeader
    Friend WithEvents eui_cmbCategoriaArticoli As Elegant.Ui.ComboBox
    Friend WithEvents clnQuantità As ColumnHeader
    Friend WithEvents clnCostoTotale As ColumnHeader
    Friend WithEvents eui_cmdMenoQuantità As Elegant.Ui.Button
    Friend WithEvents eui_cmdPiùQuantità As Elegant.Ui.Button
    Friend WithEvents clnId As ColumnHeader
    Friend WithEvents ImageList1 As ImageList
End Class
