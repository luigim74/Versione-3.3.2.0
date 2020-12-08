<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepMenu
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
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me.FormazioneMenuBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.MenuDataSet = New MenuDataSet()
      Me.PiattiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.FormazioneMenuTableAdapter = New MenuDataSetTableAdapters.FormazioneMenuTableAdapter()
      Me.PiattiTableAdapter = New MenuDataSetTableAdapters.PiattiTableAdapter()
      CType(Me.FormazioneMenuBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.MenuDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PiattiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'FormazioneMenuBindingSource
      '
      Me.FormazioneMenuBindingSource.DataMember = "FormazioneMenu"
      Me.FormazioneMenuBindingSource.DataSource = Me.MenuDataSet
      '
      'MenuDataSet
      '
      Me.MenuDataSet.DataSetName = "MenuDataSet"
      Me.MenuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'PiattiBindingSource
      '
      Me.PiattiBindingSource.DataMember = "Piatti"
      Me.PiattiBindingSource.DataSource = Me.MenuDataSet
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.Form = Me
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "MenuDataSet"
      ReportDataSource1.Value = Me.FormazioneMenuBindingSource
      ReportDataSource2.Name = "PiattiDataSet"
      ReportDataSource2.Value = Me.PiattiBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.Menu_Standard_A4.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.ServerReport.BearerToken = Nothing
      Me.ReportViewer1.Size = New System.Drawing.Size(670, 365)
      Me.ReportViewer1.TabIndex = 1
      '
      'FormazioneMenuTableAdapter
      '
      Me.FormazioneMenuTableAdapter.ClearBeforeFill = True
      '
      'PiattiTableAdapter
      '
      Me.PiattiTableAdapter.ClearBeforeFill = True
      '
      'RepMenu
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(670, 365)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "RepMenu"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anteprima di stampa"
      CType(Me.FormazioneMenuBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.MenuDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PiattiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FormazioneMenuBindingSource As BindingSource
   Friend WithEvents MenuDataSet As MenuDataSet
   Friend WithEvents PiattiBindingSource As BindingSource
   Friend WithEvents FormazioneMenuTableAdapter As MenuDataSetTableAdapters.FormazioneMenuTableAdapter
   Friend WithEvents PiattiTableAdapter As MenuDataSetTableAdapters.PiattiTableAdapter
End Class
