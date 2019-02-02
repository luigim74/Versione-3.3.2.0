<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepListiniCamere
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
      Me.HospitalityDataSet = New HospitalityDataSet()
      Me.ListiniCamereBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ListiniCamereTableAdapter = New HospitalityDataSetTableAdapters.ListiniCamereTableAdapter()
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ListiniCamereBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
      ReportDataSource1.Name = "ListiniCamere"
      ReportDataSource1.Value = Me.ListiniCamereBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.ListiniCamere.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.Size = New System.Drawing.Size(816, 466)
      Me.ReportViewer1.TabIndex = 1
      '
      'HospitalityDataSet
      '
      Me.HospitalityDataSet.DataSetName = "HospitalityDataSet"
      Me.HospitalityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'ListiniCamereBindingSource
      '
      Me.ListiniCamereBindingSource.DataMember = "ListiniCamere"
      Me.ListiniCamereBindingSource.DataSource = Me.HospitalityDataSet
      '
      'ListiniCamereTableAdapter
      '
      Me.ListiniCamereTableAdapter.ClearBeforeFill = True
      '
      'RepListiniCamere
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(816, 466)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepListiniCamere"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ListiniCamereBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents ListiniCamereBindingSource As BindingSource
   Friend WithEvents HospitalityDataSet As HospitalityDataSet
   Friend WithEvents ListiniCamereTableAdapter As HospitalityDataSetTableAdapters.ListiniCamereTableAdapter
End Class
