<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepScontiMaggiorazioni
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
        Me.ScontiMaggiorazioniBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ScontiMaggiorazioniDataSet = New Hospitality_Solution.ScontiMaggiorazioniDataSet()
        Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ScontiMaggiorazioniTableAdapter = New Hospitality_Solution.ScontiMaggiorazioniDataSetTableAdapters.ScontiMaggiorazioniTableAdapter()
        CType(Me.ScontiMaggiorazioniBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScontiMaggiorazioniDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ScontiMaggiorazioniBindingSource
        '
        Me.ScontiMaggiorazioniBindingSource.DataMember = "ScontiMaggiorazioni"
        Me.ScontiMaggiorazioniBindingSource.DataSource = Me.ScontiMaggiorazioniDataSet
        '
        'ScontiMaggiorazioniDataSet
        '
        Me.ScontiMaggiorazioniDataSet.DataSetName = "ScontiMaggiorazioniDataSet"
        Me.ScontiMaggiorazioniDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'formFrameSkinner
        '
        Me.formFrameSkinner.AllowGlass = False
        Me.formFrameSkinner.Form = Me
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ScontiMaggiorazioniDataSet"
        ReportDataSource1.Value = Me.ScontiMaggiorazioniBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.ScontiMaggiorazioni.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(726, 274)
        Me.ReportViewer1.TabIndex = 1
        '
        'ScontiMaggiorazioniTableAdapter
        '
        Me.ScontiMaggiorazioniTableAdapter.ClearBeforeFill = True
        '
        'RepScontiMaggiorazioni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 274)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "RepScontiMaggiorazioni"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anteprima di stampa"
        CType(Me.ScontiMaggiorazioniBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScontiMaggiorazioniDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ScontiMaggiorazioniBindingSource As BindingSource
   Friend WithEvents ScontiMaggiorazioniDataSet As ScontiMaggiorazioniDataSet
   Friend WithEvents ScontiMaggiorazioniTableAdapter As ScontiMaggiorazioniDataSetTableAdapters.ScontiMaggiorazioniTableAdapter
End Class
