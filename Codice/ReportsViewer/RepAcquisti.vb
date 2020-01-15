#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       14/01/2020
' Data ultima modifica: 14/01/2020
' Descrizione:          Report di stampa con ReportsViewer.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Public Class RepAcquisti
   Dim nomeStampante As String
   Dim nomeReport As String

   Public Sub New(ByVal ds As DocAcquistoDataSet, ByVal nomeDoc As String, ByVal percorsoNomeStampante As String)
      Try
         ' La chiamata è richiesta dalla finestra di progettazione.
         InitializeComponent()

         ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
         ' Imposta le dimensioni del form.
         FormResize(REPORTS_LARGHEZZA, REPORTS_ALTEZZA)

         ' Imposta il nome del report.
         nomeReport = nomeDoc

         ' Imposta il nome della stampante.
         nomeStampante = percorsoNomeStampante

         Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
         Me.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & nomeDoc

         Me.AcquistiBindingSource.DataMember = "Acquisti"
         Me.AcquistiBindingSource.DataSource = ds

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RepAcquisti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica i dati delle rispettive tabelle.
         Me.AcquistiTableAdapter.Fill(Me.DocAcquistoDataSet.Acquisti)

         ' Impostazioni per l'anteprima di stampa.
         Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
         Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
         Me.ReportViewer1.ZoomPercent = 100

         ' Imposta il nome della stampante.
         If nomeStampante <> String.Empty Then
            Me.ReportViewer1.PrinterSettings.PrinterName = nomeStampante
         End If

         ' Imposta il numero di copie del documento da stampare.
         Me.ReportViewer1.PrinterSettings.Copies = NumeroCopieStampa

         ' Aggiorna il report.
         Me.ReportViewer1.RefreshReport()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
      Me.ReportViewer1.RefreshReport
   End Sub

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      Try
         ' Imposta le dimensioni standard del form.
         Me.Width = larghezza
         Me.Height = altezza

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

End Class