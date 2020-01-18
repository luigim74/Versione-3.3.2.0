<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepPrenSale
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
      Me.PrenSaleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.PrenSaleDataSet = New PrenSaleDataSet()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.PrenSaleTableAdapter = New PrenSaleDataSetTableAdapters.PrenSaleTableAdapter()
      CType(Me.PrenSaleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PrenSaleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'PrenSaleBindingSource
      '
      Me.PrenSaleBindingSource.DataMember = "PrenSale"
      Me.PrenSaleBindingSource.DataSource = Me.PrenSaleDataSet
      '
      'PrenSaleDataSet
      '
      Me.PrenSaleDataSet.DataSetName = "PrenSaleDataSet"
      Me.PrenSaleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "PrenSaleDataSet"
      ReportDataSource1.Value = Me.PrenSaleBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.PrenSale.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(824, 474)
      Me.ReportViewer1.TabIndex = 1
      '
      'PrenSaleTableAdapter
      '
      Me.PrenSaleTableAdapter.ClearBeforeFill = True
      '
      'RepPrenSale
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(824, 474)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepPrenSale"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.PrenSaleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PrenSaleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents PrenSaleBindingSource As BindingSource
   Friend WithEvents PrenSaleDataSet As PrenSaleDataSet
   Friend WithEvents PrenSaleTableAdapter As PrenSaleDataSetTableAdapters.PrenSaleTableAdapter
End Class
