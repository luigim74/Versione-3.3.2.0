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
      Me.AziendaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.HospitalityDataSet1 = New HospitalityDataSet1()
      Me.SchedinePSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ComponentiSchedinePSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.AziendaTableAdapter = New HospitalityDataSet1TableAdapters.AziendaTableAdapter()
      Me.SchedinePSTableAdapter = New HospitalityDataSet1TableAdapters.SchedinePSTableAdapter()
      Me.ComponentiSchedinePSTableAdapter = New HospitalityDataSet1TableAdapters.ComponentiSchedinePSTableAdapter()
      Me.ClientiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ClientiTableAdapter = New HospitalityDataSet1TableAdapters.ClientiTableAdapter()
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.HospitalityDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.SchedinePSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ComponentiSchedinePSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ClientiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'AziendaBindingSource
      '
      Me.AziendaBindingSource.DataMember = "Azienda"
      Me.AziendaBindingSource.DataSource = Me.HospitalityDataSet1
      '
      'HospitalityDataSet1
      '
      Me.HospitalityDataSet1.DataSetName = "HospitalityDataSet1"
      Me.HospitalityDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'SchedinePSBindingSource
      '
      Me.SchedinePSBindingSource.DataMember = "SchedinePS"
      Me.SchedinePSBindingSource.DataSource = Me.HospitalityDataSet1
      '
      'ComponentiSchedinePSBindingSource
      '
      Me.ComponentiSchedinePSBindingSource.DataMember = "ComponentiSchedinePS"
      Me.ComponentiSchedinePSBindingSource.DataSource = Me.HospitalityDataSet1
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
      ReportDataSource2.Name = "SchedinePS"
      ReportDataSource2.Value = Me.SchedinePSBindingSource
      ReportDataSource3.Name = "ComponentiSchedinePS"
      ReportDataSource3.Value = Me.ComponentiSchedinePSBindingSource
      ReportDataSource4.Name = "Clienti"
      ReportDataSource4.Value = Me.ClientiBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.SchedinaPS A4.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.Size = New System.Drawing.Size(880, 530)
      Me.ReportViewer1.TabIndex = 1
      '
      'AziendaTableAdapter
      '
      Me.AziendaTableAdapter.ClearBeforeFill = True
      '
      'SchedinePSTableAdapter
      '
      Me.SchedinePSTableAdapter.ClearBeforeFill = True
      '
      'ComponentiSchedinePSTableAdapter
      '
      Me.ComponentiSchedinePSTableAdapter.ClearBeforeFill = True
      '
      'ClientiBindingSource
      '
      Me.ClientiBindingSource.DataMember = "Clienti"
      Me.ClientiBindingSource.DataSource = Me.HospitalityDataSet1
      '
      'ClientiTableAdapter
      '
      Me.ClientiTableAdapter.ClearBeforeFill = True
      '
      'RepSchedinaPS
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(880, 530)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepSchedinaPS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.HospitalityDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.SchedinePSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ComponentiSchedinePSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ClientiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents AziendaBindingSource As BindingSource
   Friend WithEvents HospitalityDataSet1 As HospitalityDataSet1
   Friend WithEvents SchedinePSBindingSource As BindingSource
   Friend WithEvents ComponentiSchedinePSBindingSource As BindingSource
   Friend WithEvents AziendaTableAdapter As HospitalityDataSet1TableAdapters.AziendaTableAdapter
   Friend WithEvents SchedinePSTableAdapter As HospitalityDataSet1TableAdapters.SchedinePSTableAdapter
   Friend WithEvents ComponentiSchedinePSTableAdapter As HospitalityDataSet1TableAdapters.ComponentiSchedinePSTableAdapter
   Friend WithEvents ClientiBindingSource As BindingSource
   Friend WithEvents ClientiTableAdapter As HospitalityDataSet1TableAdapters.ClientiTableAdapter
End Class
