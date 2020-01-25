<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepInventario
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
      Me.InventarioDataSet = New InventarioDataSet()
      Me.ArticoliBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ArticoliTableAdapter = New InventarioDataSetTableAdapters.ArticoliTableAdapter()
      CType(Me.InventarioDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ArticoliBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
      ReportDataSource1.Name = "InventarioDataSet"
      ReportDataSource1.Value = Me.ArticoliBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.Inventario.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(816, 466)
      Me.ReportViewer1.TabIndex = 1
      '
      'InventarioDataSet
      '
      Me.InventarioDataSet.DataSetName = "InventarioDataSet"
      Me.InventarioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'ArticoliBindingSource
      '
      Me.ArticoliBindingSource.DataMember = "Articoli"
      Me.ArticoliBindingSource.DataSource = Me.InventarioDataSet
      '
      'ArticoliTableAdapter
      '
      Me.ArticoliTableAdapter.ClearBeforeFill = True
      '
      'RepInventario
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(816, 466)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepInventario"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.InventarioDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ArticoliBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents ArticoliBindingSource As BindingSource
   Friend WithEvents InventarioDataSet As InventarioDataSet
   Friend WithEvents ArticoliTableAdapter As InventarioDataSetTableAdapters.ArticoliTableAdapter
End Class
