<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RepIstat
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
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.IstatDataSet = New IstatDataSet()
      Me.StoricoPresenzeIstatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.StoricoPresenzeIstatTableAdapter = New IstatDataSetTableAdapters.StoricoPresenzeIstatTableAdapter()
      Me.StoricoPresenzeIstatC59BindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.StoricoPresenzeIstatC59TableAdapter = New IstatDataSetTableAdapters.StoricoPresenzeIstatC59TableAdapter()
      CType(Me.IstatDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.StoricoPresenzeIstatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.StoricoPresenzeIstatC59BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
      ReportDataSource1.Name = "StoricoPresenzeIstat"
      ReportDataSource1.Value = Me.StoricoPresenzeIstatBindingSource
      ReportDataSource2.Name = "StoricoPresenzeIstatC59"
      ReportDataSource2.Value = Me.StoricoPresenzeIstatC59BindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.ModelloIstatC59 A4.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.Size = New System.Drawing.Size(840, 490)
      Me.ReportViewer1.TabIndex = 1
      '
      'IstatDataSet
      '
      Me.IstatDataSet.DataSetName = "IstatDataSet"
      Me.IstatDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'StoricoPresenzeIstatBindingSource
      '
      Me.StoricoPresenzeIstatBindingSource.DataMember = "StoricoPresenzeIstat"
      Me.StoricoPresenzeIstatBindingSource.DataSource = Me.IstatDataSet
      '
      'StoricoPresenzeIstatTableAdapter
      '
      Me.StoricoPresenzeIstatTableAdapter.ClearBeforeFill = True
      '
      'StoricoPresenzeIstatC59BindingSource
      '
      Me.StoricoPresenzeIstatC59BindingSource.DataMember = "StoricoPresenzeIstatC59"
      Me.StoricoPresenzeIstatC59BindingSource.DataSource = Me.IstatDataSet
      '
      'StoricoPresenzeIstatC59TableAdapter
      '
      Me.StoricoPresenzeIstatC59TableAdapter.ClearBeforeFill = True
      '
      'RepIstat
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(840, 490)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepIstat"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.IstatDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.StoricoPresenzeIstatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.StoricoPresenzeIstatC59BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents StoricoPresenzeIstatBindingSource As BindingSource
   Friend WithEvents IstatDataSet As IstatDataSet
   Friend WithEvents StoricoPresenzeIstatC59BindingSource As BindingSource
   Friend WithEvents StoricoPresenzeIstatTableAdapter As IstatDataSetTableAdapters.StoricoPresenzeIstatTableAdapter
   Friend WithEvents StoricoPresenzeIstatC59TableAdapter As IstatDataSetTableAdapters.StoricoPresenzeIstatC59TableAdapter
End Class
