<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RepSchedinaPS
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
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.SchedinaPSDataSet = New SchedinaPSDataSet()
      Me.AziendaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.AziendaTableAdapter = New SchedinaPSDataSetTableAdapters.AziendaTableAdapter()
      Me.ComponentiSchedinePSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ComponentiSchedinePSTableAdapter = New SchedinaPSDataSetTableAdapters.ComponentiSchedinePSTableAdapter()
      Me.SchedinePSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.SchedinePSTableAdapter = New SchedinaPSDataSetTableAdapters.SchedinePSTableAdapter()
      Me.ClientiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ClientiTableAdapter = New SchedinaPSDataSetTableAdapters.ClientiTableAdapter()
      CType(Me.SchedinaPSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ComponentiSchedinePSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.SchedinePSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
      ReportDataSource1.Name = "Azienda"
      ReportDataSource1.Value = Me.AziendaBindingSource
      ReportDataSource2.Name = "ComponentiSchedinePS"
      ReportDataSource2.Value = Me.ComponentiSchedinePSBindingSource
      ReportDataSource3.Name = "SchedinePS"
      ReportDataSource3.Value = Me.SchedinePSBindingSource
      ReportDataSource4.Name = "Clienti"
      ReportDataSource4.Value = Me.ClientiBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.SchedinaPS A4.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(920, 570)
      Me.ReportViewer1.TabIndex = 1
      '
      'SchedinaPSDataSet
      '
      Me.SchedinaPSDataSet.DataSetName = "SchedinaPSDataSet"
      Me.SchedinaPSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'AziendaBindingSource
      '
      Me.AziendaBindingSource.DataMember = "Azienda"
      Me.AziendaBindingSource.DataSource = Me.SchedinaPSDataSet
      '
      'AziendaTableAdapter
      '
      Me.AziendaTableAdapter.ClearBeforeFill = True
      '
      'ComponentiSchedinePSBindingSource
      '
      Me.ComponentiSchedinePSBindingSource.DataMember = "ComponentiSchedinePS"
      Me.ComponentiSchedinePSBindingSource.DataSource = Me.SchedinaPSDataSet
      '
      'ComponentiSchedinePSTableAdapter
      '
      Me.ComponentiSchedinePSTableAdapter.ClearBeforeFill = True
      '
      'SchedinePSBindingSource
      '
      Me.SchedinePSBindingSource.DataMember = "SchedinePS"
      Me.SchedinePSBindingSource.DataSource = Me.SchedinaPSDataSet
      '
      'SchedinePSTableAdapter
      '
      Me.SchedinePSTableAdapter.ClearBeforeFill = True
      '
      'ClientiBindingSource
      '
      Me.ClientiBindingSource.DataMember = "Clienti"
      Me.ClientiBindingSource.DataSource = Me.SchedinaPSDataSet
      '
      'ClientiTableAdapter
      '
      Me.ClientiTableAdapter.ClearBeforeFill = True
      '
      'RepSchedinaPS
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(920, 570)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepSchedinaPS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.SchedinaPSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ComponentiSchedinePSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.SchedinePSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ClientiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents AziendaBindingSource As BindingSource
   Friend WithEvents SchedinaPSDataSet As SchedinaPSDataSet
   Friend WithEvents ComponentiSchedinePSBindingSource As BindingSource
   Friend WithEvents SchedinePSBindingSource As BindingSource
   Friend WithEvents ClientiBindingSource As BindingSource
   Friend WithEvents AziendaTableAdapter As SchedinaPSDataSetTableAdapters.AziendaTableAdapter
   Friend WithEvents ComponentiSchedinePSTableAdapter As SchedinaPSDataSetTableAdapters.ComponentiSchedinePSTableAdapter
   Friend WithEvents SchedinePSTableAdapter As SchedinaPSDataSetTableAdapters.SchedinePSTableAdapter
   Friend WithEvents ClientiTableAdapter As SchedinaPSDataSetTableAdapters.ClientiTableAdapter
End Class
