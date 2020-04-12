<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RepClienti
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
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.ClientiDataSet = New ClientiDataSet()
      Me.ClientiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ClientiTableAdapter = New ClientiDataSetTableAdapters.ClientiTableAdapter()
      CType(Me.ClientiDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ClientiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
      ReportDataSource1.Name = "ClientiDataSet"
      ReportDataSource1.Value = Me.ClientiBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.Clienti.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(864, 514)
      Me.ReportViewer1.TabIndex = 1
      '
      'ClientiDataSet
      '
      Me.ClientiDataSet.DataSetName = "ClientiDataSet"
      Me.ClientiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'ClientiBindingSource
      '
      Me.ClientiBindingSource.DataMember = "Clienti"
      Me.ClientiBindingSource.DataSource = Me.ClientiDataSet
      '
      'ClientiTableAdapter
      '
      Me.ClientiTableAdapter.ClearBeforeFill = True
      '
      'RepClienti
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(864, 514)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepClienti"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.ClientiDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ClientiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents ClientiBindingSource As BindingSource
   Friend WithEvents ClientiDataSet As ClientiDataSet
   Friend WithEvents ClientiTableAdapter As ClientiDataSetTableAdapters.ClientiTableAdapter
End Class
