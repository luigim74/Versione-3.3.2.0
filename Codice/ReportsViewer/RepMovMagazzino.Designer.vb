<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepMovMagazzino
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
      Me.components = New System.ComponentModel.Container()
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.MovMagazzinoDataSet = New MovMagazzinoDataSet()
      Me.MovMagazzinoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.MovMagazzinoTableAdapter = New MovMagazzinoDataSetTableAdapters.MovMagazzinoTableAdapter()
      CType(Me.MovMagazzinoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.MovMagazzinoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "MovMagazzinoDataSet"
      ReportDataSource1.Value = Me.MovMagazzinoBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.MovMagazzino.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(816, 466)
      Me.ReportViewer1.TabIndex = 1
      '
      'MovMagazzinoDataSet
      '
      Me.MovMagazzinoDataSet.DataSetName = "MovMagazzinoDataSet"
      Me.MovMagazzinoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'MovMagazzinoBindingSource
      '
      Me.MovMagazzinoBindingSource.DataMember = "MovMagazzino"
      Me.MovMagazzinoBindingSource.DataSource = Me.MovMagazzinoDataSet
      '
      'MovMagazzinoTableAdapter
      '
      Me.MovMagazzinoTableAdapter.ClearBeforeFill = True
      '
      'RepMovMagazzino
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(816, 466)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepMovMagazzino"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.MovMagazzinoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.MovMagazzinoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents MovMagazzinoBindingSource As BindingSource
   Friend WithEvents MovMagazzinoDataSet As MovMagazzinoDataSet
   Friend WithEvents MovMagazzinoTableAdapter As MovMagazzinoDataSetTableAdapters.MovMagazzinoTableAdapter
End Class
