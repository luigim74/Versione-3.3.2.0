<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RepCamere
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
      Me.CamereBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.HospitalityDataSet = New HospitalityDataSet()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.CamereTableAdapter = New HospitalityDataSetTableAdapters.CamereTableAdapter()
      CType(Me.CamereBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'CamereBindingSource
      '
      Me.CamereBindingSource.DataMember = "Camere"
      Me.CamereBindingSource.DataSource = Me.HospitalityDataSet
      '
      'HospitalityDataSet
      '
      Me.HospitalityDataSet.DataSetName = "HospitalityDataSet"
      Me.HospitalityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "Camere"
      ReportDataSource1.Value = Me.CamereBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.Camere.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.Size = New System.Drawing.Size(788, 413)
      Me.ReportViewer1.TabIndex = 1
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'CamereTableAdapter
      '
      Me.CamereTableAdapter.ClearBeforeFill = True
      '
      'RepCamere
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(788, 413)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepCamere"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.CamereBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents HospitalityDataSet As HospitalityDataSet
   Friend WithEvents CamereBindingSource As BindingSource
   Friend WithEvents CamereTableAdapter As HospitalityDataSetTableAdapters.CamereTableAdapter
End Class
