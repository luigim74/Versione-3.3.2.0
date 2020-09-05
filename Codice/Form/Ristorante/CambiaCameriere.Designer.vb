<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiaCameriere
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Predefinito", System.Windows.Forms.HorizontalAlignment.Center)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Altri", System.Windows.Forms.HorizontalAlignment.Center)
        Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.eui_cmdAnnulla = New Elegant.Ui.Button()
        Me.eui_cmdOk = New Elegant.Ui.Button()
        Me.eui_cmbCameriere = New Elegant.Ui.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvwCamerieri = New System.Windows.Forms.ListView()
        Me.clnNome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnSpettanza = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnIdTavolo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnIdCameriere = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnCalcoloSpettanzaManuale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clnId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.eui_cmdInserisci = New Elegant.Ui.Button()
        Me.eui_cmdElimina = New Elegant.Ui.Button()
        Me.eui_cmdSpettanza = New Elegant.Ui.Button()
        Me.eui_cmdPredefinito = New Elegant.Ui.Button()
        Me.eui_ckdSpettanzaManuale = New Elegant.Ui.CheckBox()
        Me.SuspendLayout()
        '
        'formFrameSkinner
        '
        Me.formFrameSkinner.AllowGlass = False
        Me.formFrameSkinner.Form = Me
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
        Me.Label1.Size = New System.Drawing.Size(257, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SELEZIONA CAMERIERE:"
        '
        'eui_cmdAnnulla
        '
        Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdAnnulla.Id = "37f77d75-8567-42d2-b542-c7affc7e1a25"
        Me.eui_cmdAnnulla.Location = New System.Drawing.Point(485, 405)
        Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
        Me.eui_cmdAnnulla.Size = New System.Drawing.Size(117, 53)
        Me.eui_cmdAnnulla.TabIndex = 7
        Me.eui_cmdAnnulla.Text = "&Annulla"
        '
        'eui_cmdOk
        '
        Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdOk.Id = "5a4c2111-8642-4848-a1dd-6db422328151"
        Me.eui_cmdOk.Location = New System.Drawing.Point(485, 343)
        Me.eui_cmdOk.Name = "eui_cmdOk"
        Me.eui_cmdOk.Size = New System.Drawing.Size(117, 53)
        Me.eui_cmdOk.TabIndex = 6
        Me.eui_cmdOk.Text = "&OK"
        '
        'eui_cmbCameriere
        '
        Me.eui_cmbCameriere.Editable = False
        Me.eui_cmbCameriere.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmbCameriere.FormattingEnabled = False
        Me.eui_cmbCameriere.Id = "87de2a67-0fad-4679-8460-fa7d3d6c9d83"
        Me.eui_cmbCameriere.Location = New System.Drawing.Point(16, 37)
        Me.eui_cmbCameriere.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.eui_cmbCameriere.Name = "eui_cmbCameriere"
        Me.eui_cmbCameriere.Size = New System.Drawing.Size(463, 41)
        Me.eui_cmbCameriere.TabIndex = 0
        Me.eui_cmbCameriere.TextEditorWidth = 444
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(248, 24)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "CAMERIERI AL TAVOLO:"
        '
        'lvwCamerieri
        '
        Me.lvwCamerieri.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnNome, Me.clnSpettanza, Me.clnIdTavolo, Me.clnIdCameriere, Me.clnCalcoloSpettanzaManuale, Me.clnId})
        Me.lvwCamerieri.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwCamerieri.FullRowSelect = True
        ListViewGroup1.Header = "Predefinito"
        ListViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center
        ListViewGroup1.Name = "Predefinito"
        ListViewGroup2.Header = "Altri"
        ListViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center
        ListViewGroup2.Name = "Altri"
        Me.lvwCamerieri.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        Me.lvwCamerieri.HideSelection = False
        Me.lvwCamerieri.Location = New System.Drawing.Point(11, 119)
        Me.lvwCamerieri.Name = "lvwCamerieri"
        Me.lvwCamerieri.Size = New System.Drawing.Size(468, 340)
        Me.lvwCamerieri.TabIndex = 2
        Me.lvwCamerieri.UseCompatibleStateImageBehavior = False
        Me.lvwCamerieri.View = System.Windows.Forms.View.Details
        '
        'clnNome
        '
        Me.clnNome.Text = "Nome"
        Me.clnNome.Width = 280
        '
        'clnSpettanza
        '
        Me.clnSpettanza.Text = "Spettanza"
        Me.clnSpettanza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.clnSpettanza.Width = 150
        '
        'clnIdTavolo
        '
        Me.clnIdTavolo.Width = 0
        '
        'clnIdCameriere
        '
        Me.clnIdCameriere.Width = 0
        '
        'clnCalcoloSpettanzaManuale
        '
        Me.clnCalcoloSpettanzaManuale.Width = 0
        '
        'clnId
        '
        Me.clnId.Width = 0
        '
        'eui_cmdInserisci
        '
        Me.eui_cmdInserisci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdInserisci.Id = "2d6a22ae-8f1f-44ee-82c2-c0a9ec87cb93"
        Me.eui_cmdInserisci.Location = New System.Drawing.Point(485, 36)
        Me.eui_cmdInserisci.Name = "eui_cmdInserisci"
        Me.eui_cmdInserisci.Size = New System.Drawing.Size(117, 41)
        Me.eui_cmdInserisci.TabIndex = 1
        Me.eui_cmdInserisci.Text = "&Inserisci"
        '
        'eui_cmdElimina
        '
        Me.eui_cmdElimina.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdElimina.Id = "737b7a9c-6367-4343-9193-2ea458b8bb40"
        Me.eui_cmdElimina.Location = New System.Drawing.Point(485, 243)
        Me.eui_cmdElimina.Name = "eui_cmdElimina"
        Me.eui_cmdElimina.Size = New System.Drawing.Size(117, 53)
        Me.eui_cmdElimina.TabIndex = 5
        Me.eui_cmdElimina.Text = "&Elimina"
        '
        'eui_cmdSpettanza
        '
        Me.eui_cmdSpettanza.Enabled = False
        Me.eui_cmdSpettanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdSpettanza.Id = "4939cafd-d052-4dc4-ae1e-0b8df6855e09"
        Me.eui_cmdSpettanza.Location = New System.Drawing.Point(485, 181)
        Me.eui_cmdSpettanza.Name = "eui_cmdSpettanza"
        Me.eui_cmdSpettanza.Size = New System.Drawing.Size(117, 53)
        Me.eui_cmdSpettanza.TabIndex = 4
        Me.eui_cmdSpettanza.Text = "&Spettanza"
        '
        'eui_cmdPredefinito
        '
        Me.eui_cmdPredefinito.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_cmdPredefinito.Id = "6bbaa9b9-b03e-4620-b170-2965adebb030"
        Me.eui_cmdPredefinito.Location = New System.Drawing.Point(485, 119)
        Me.eui_cmdPredefinito.Name = "eui_cmdPredefinito"
        Me.eui_cmdPredefinito.Size = New System.Drawing.Size(117, 53)
        Me.eui_cmdPredefinito.TabIndex = 3
        Me.eui_cmdPredefinito.Text = "&Predefinito"
        '
        'eui_ckdSpettanzaManuale
        '
        Me.eui_ckdSpettanzaManuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_ckdSpettanzaManuale.Id = "0f7abb2e-2b95-4258-abc6-92d553f59147"
        Me.eui_ckdSpettanzaManuale.Location = New System.Drawing.Point(11, 462)
        Me.eui_ckdSpettanzaManuale.Name = "eui_ckdSpettanzaManuale"
        Me.eui_ckdSpettanzaManuale.Size = New System.Drawing.Size(362, 38)
        Me.eui_ckdSpettanzaManuale.TabIndex = 8
        Me.eui_ckdSpettanzaManuale.Text = "Calcolo della spettanza manuale"
        '
        'CambiaCameriere
        '
        Me.AcceptButton = Me.eui_cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.CancelButton = Me.eui_cmdAnnulla
        Me.ClientSize = New System.Drawing.Size(612, 497)
        Me.Controls.Add(Me.eui_ckdSpettanzaManuale)
        Me.Controls.Add(Me.eui_cmdPredefinito)
        Me.Controls.Add(Me.eui_cmdSpettanza)
        Me.Controls.Add(Me.eui_cmdElimina)
        Me.Controls.Add(Me.eui_cmdInserisci)
        Me.Controls.Add(Me.lvwCamerieri)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.eui_cmbCameriere)
        Me.Controls.Add(Me.eui_cmdAnnulla)
        Me.Controls.Add(Me.eui_cmdOk)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CambiaCameriere"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambia cameriere"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents Label1 As Label
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Friend WithEvents eui_cmbCameriere As Elegant.Ui.ComboBox
    Public WithEvents Label2 As Label
    Friend WithEvents lvwCamerieri As ListView
    Friend WithEvents clnNome As ColumnHeader
    Friend WithEvents clnSpettanza As ColumnHeader
    Friend WithEvents eui_cmdSpettanza As Elegant.Ui.Button
    Friend WithEvents eui_cmdElimina As Elegant.Ui.Button
    Friend WithEvents eui_cmdInserisci As Elegant.Ui.Button
    Friend WithEvents eui_cmdPredefinito As Elegant.Ui.Button
    Friend WithEvents eui_ckdSpettanzaManuale As Elegant.Ui.CheckBox
    Friend WithEvents clnIdTavolo As ColumnHeader
    Friend WithEvents clnIdCameriere As ColumnHeader
    Friend WithEvents clnCalcoloSpettanzaManuale As ColumnHeader
    Friend WithEvents clnId As ColumnHeader
End Class
