<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepPrenTavoli
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
      Me.PrenTavoliDataSet = New PrenTavoliDataSet()
      Me.PrenotazioniBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.PrenotazioniTableAdapter = New PrenTavoliDataSetTableAdapters.PrenotazioniTableAdapter()
      CType(Me.PrenTavoliDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PrenotazioniBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
      ReportDataSource1.Name = "PrenTavoliDataSet"
      ReportDataSource1.Value = Me.PrenotazioniBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.PrenTavoli.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(816, 466)
      Me.ReportViewer1.TabIndex = 1
      '
      'PrenTavoliDataSet
      '
      Me.PrenTavoliDataSet.DataSetName = "PrenTavoliDataSet"
      Me.PrenTavoliDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'PrenotazioniBindingSource
      '
      Me.PrenotazioniBindingSource.DataMember = "Prenotazioni"
      Me.PrenotazioniBindingSource.DataSource = Me.PrenTavoliDataSet
      '
      'PrenotazioniTableAdapter
      '
      Me.PrenotazioniTableAdapter.ClearBeforeFill = True
      '
      'RepPrenTavoli
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(816, 466)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepPrenTavoli"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.PrenTavoliDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PrenotazioniBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents PrenotazioniBindingSource As BindingSource
   Friend WithEvents PrenTavoliDataSet As PrenTavoliDataSet
   Friend WithEvents PrenotazioniTableAdapter As PrenTavoliDataSetTableAdapters.PrenotazioniTableAdapter
End Class
