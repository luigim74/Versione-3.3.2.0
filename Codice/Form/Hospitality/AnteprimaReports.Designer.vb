<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnteprimaReports
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
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.HospitalityDataSet = New Hospitality_Solution.HospitalityDataSet()
      Me.DettagliDocBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DettagliDocTableAdapter = New Hospitality_Solution.HospitalityDataSetTableAdapters.DettagliDocTableAdapter()
      Me.AziendaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.AziendaTableAdapter = New Hospitality_Solution.HospitalityDataSetTableAdapters.AziendaTableAdapter()
      Me.DocumentiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DocumentiTableAdapter = New Hospitality_Solution.HospitalityDataSetTableAdapters.DocumentiTableAdapter()
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DettagliDocBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DocumentiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.Form = Me
      '
      'HospitalityDataSet
      '
      Me.HospitalityDataSet.DataSetName = "HospitalityDataSet"
      Me.HospitalityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'DettagliDocBindingSource
      '
      Me.DettagliDocBindingSource.DataMember = "DettagliDoc"
      Me.DettagliDocBindingSource.DataSource = Me.HospitalityDataSet
      '
      'DettagliDocTableAdapter
      '
      Me.DettagliDocTableAdapter.ClearBeforeFill = True
      '
      'AziendaBindingSource
      '
      Me.AziendaBindingSource.DataMember = "Azienda"
      Me.AziendaBindingSource.DataSource = Me.HospitalityDataSet
      '
      'AziendaTableAdapter
      '
      Me.AziendaTableAdapter.ClearBeforeFill = True
      '
      'DocumentiBindingSource
      '
      Me.DocumentiBindingSource.DataMember = "Documenti"
      Me.DocumentiBindingSource.DataSource = Me.HospitalityDataSet
      '
      'DocumentiTableAdapter
      '
      Me.DocumentiTableAdapter.ClearBeforeFill = True
      '
      'AnteprimaReports
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(583, 330)
      Me.Name = "AnteprimaReports"
      Me.Text = "AnteprimaReports"
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DettagliDocBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DocumentiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents DettagliDocBindingSource As BindingSource
   Friend WithEvents HospitalityDataSet As Hospitality_Solution.HospitalityDataSet
   Friend WithEvents AziendaBindingSource As BindingSource
   Friend WithEvents DocumentiBindingSource As BindingSource
   Friend WithEvents DettagliDocTableAdapter As Hospitality_Solution.HospitalityDataSetTableAdapters.DettagliDocTableAdapter
   Friend WithEvents AziendaTableAdapter As Hospitality_Solution.HospitalityDataSetTableAdapters.AziendaTableAdapter
   Friend WithEvents DocumentiTableAdapter As Hospitality_Solution.HospitalityDataSetTableAdapters.DocumentiTableAdapter
End Class
