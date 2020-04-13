<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepPrenCamere
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
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.PrenCamereDataSet = New PrenCamereDataSet()
      Me.PrenCamereBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.PrenCamereTableAdapter = New PrenCamereDataSetTableAdapters.PrenCamereTableAdapter()
      CType(Me.PrenCamereDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PrenCamereBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "PrenCamereDataSet"
      ReportDataSource1.Value = Me.PrenCamereBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.PrenCamere.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(832, 482)
      Me.ReportViewer1.TabIndex = 0
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'PrenCamereDataSet
      '
      Me.PrenCamereDataSet.DataSetName = "PrenCamereDataSet"
      Me.PrenCamereDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'PrenCamereBindingSource
      '
      Me.PrenCamereBindingSource.DataMember = "PrenCamere"
      Me.PrenCamereBindingSource.DataSource = Me.PrenCamereDataSet
      '
      'PrenCamereTableAdapter
      '
      Me.PrenCamereTableAdapter.ClearBeforeFill = True
      '
      'RepPrenCamere
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(832, 482)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepPrenCamere"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.PrenCamereDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PrenCamereBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents PrenCamereBindingSource As BindingSource
   Friend WithEvents PrenCamereDataSet As PrenCamereDataSet
   Friend WithEvents PrenCamereTableAdapter As PrenCamereDataSetTableAdapters.PrenCamereTableAdapter
End Class
