<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RepAcquisti
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
   'Non modificarla mediante l'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me.AcquistiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DocAcquistoDataSet = New DocAcquistoDataSet()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.AcquistiTableAdapter = New DocAcquistoDataSetTableAdapters.AcquistiTableAdapter()
      CType(Me.AcquistiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DocAcquistoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'AcquistiBindingSource
      '
      Me.AcquistiBindingSource.DataMember = "Acquisti"
      Me.AcquistiBindingSource.DataSource = Me.DocAcquistoDataSet
      '
      'DocAcquistoDataSet
      '
      Me.DocAcquistoDataSet.DataSetName = "DocAcquistoDataSet"
      Me.DocAcquistoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "DocAcquistoDataSet"
      ReportDataSource1.Value = Me.AcquistiBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.Acquisti.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(848, 498)
      Me.ReportViewer1.TabIndex = 1
      '
      'AcquistiTableAdapter
      '
      Me.AcquistiTableAdapter.ClearBeforeFill = True
      '
      'RepAcquisti
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(848, 498)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepAcquisti"
      Me.Text = "Anteprima di stampa"
      CType(Me.AcquistiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DocAcquistoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents AcquistiBindingSource As BindingSource
   Friend WithEvents DocAcquistoDataSet As DocAcquistoDataSet
   Friend WithEvents AcquistiTableAdapter As DocAcquistoDataSetTableAdapters.AcquistiTableAdapter
End Class
