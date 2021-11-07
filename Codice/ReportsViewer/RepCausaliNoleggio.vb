#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       07/11/2021
' Data ultima modifica: 07/11/2021
' Descrizione:          Report di stampa con ReportsViewer.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Public Class RepCausaliNoleggio
   Dim nomeStampante As String
   Dim nomeReport As String

   Public Sub New(ByVal ds As CausaliNoleggioDataSet, ByVal nomeDoc As String, ByVal percorsoNomeStampante As String)
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

         Me.CausaliNoleggioBindingSource.DataMember = "CausaliNoleggio"
         Me.CausaliNoleggioBindingSource.DataSource = ds

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RepCausaliNoleggio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica i dati delle rispettive tabelle.
         Me.CausaliNoleggioTableAdapter.Fill(Me.CausaliNoleggioDataSet.CausaliNoleggio)

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