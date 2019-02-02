Public Class ReportsViewer
   Dim nomeStampante As String
   Dim nomeReport As String

   Public Sub New(ByVal ds As DataSet, ByVal nomeDoc As String, ByVal percorsoNomeStampante As String)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

      ' Imposta il nome del report.
      nomeReport = nomeDoc

      ' Imposta il nome della stampante.
      nomeStampante = percorsoNomeStampante

      ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
      ReportViewer1.LocalReport.ReportPath = Application.StartupPath & nomeDoc

      Select Case nomeReport
         Case PERCORSO_REP_ACCESSORI_SERVIZI_A4
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("HospitalityDataSet", "AccessoriServizi"))

            Me.asBindingSource1.DataMember = "AccessoriServizi"
            Me.asBindingSource1.DataSource = ds

         Case Else
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("HospitalityDataSet", "Azienda"))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("HospitalityDataSet", "DettagliDoc"))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("HospitalityDataSet", "Documenti"))

            Me.AziendaBindingSource.DataMember = "Azienda"
            Me.AziendaBindingSource.DataSource = ds
            Me.DettagliDocBindingSource.DataMember = "DettagliDoc"
            Me.DettagliDocBindingSource.DataSource = ds
            Me.DocumentiBindingSource.DataMember = "Documenti"
            Me.DocumentiBindingSource.DataSource = ds

      End Select

   End Sub

   Private Sub ReportsViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         Select Case nomeReport
            Case PERCORSO_REP_ACCESSORI_SERVIZI_A4
               Me.AccessoriServiziTableAdapter1.Fill(Me.Dataset1.AccessoriServizi)

            Case Else
               Me.AziendaTableAdapter1.Fill(Me.Dataset1.Azienda)
               Me.DettagliDocTableAdapter.Fill(Me.HospitalityDataSet.DettagliDoc)
               Me.DocumentiTableAdapter.Fill(Me.HospitalityDataSet.Documenti)

         End Select

         Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
         Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
         Me.ReportViewer1.ZoomPercent = 100

         If nomeStampante <> String.Empty Then
            Me.ReportViewer1.PrinterSettings.PrinterName = nomeStampante
         End If

         Me.ReportViewer1.PrinterSettings.Copies = NumeroCopieStampa

         Me.ReportViewer1.RefreshReport()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class