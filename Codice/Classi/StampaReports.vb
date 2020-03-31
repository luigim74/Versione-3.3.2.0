#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       31/03/2020
' Data ultima modifica: 31/03/2020
' Descrizione:          Classe per la stampa diretta di documenti in Report Viewer senza anteprima.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class StampaReports
   Implements IDisposable
   Private m_currentPageIndex As Integer
   Private m_streams As IList(Of Stream)
   Private datiDataSet As DataSet
   Private nomeStampante As String
   Private numCopieStampa As Short

   Public Sub New(ByVal dataSet As DataSet, ByVal stampante As String, ByVal numCopie As Short)
      datiDataSet = dataSet
      nomeStampante = stampante
      numCopieStampa = numCopie
   End Sub

   Private Function LoadSalesData() As DataTable
      ' Crea un nuovo DataSet e legge il file di dati di vendita da data.xml nella prima DataTable.
      'Dim dataSet As New DataSet()
      'DataSet.ReadXml("..\..\data.xml")
      'Return DataSet.Tables(0)
   End Function

   ' Routine da fornire al render di report, al fine di salvare un'immagine per ogni pagina del rapporto.
   Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
      Dim stream As Stream = New MemoryStream 'FileStream(Application.StartupPath & "\Reports\ReportTemp.emf", FileMode.Create)
      m_streams.Add(stream)
      Return stream
   End Function

   ' Esporta il rapporto indicato come file .EMF (Enhanced Metafile).
   Private Sub Export(ByVal report As LocalReport)
      Dim deviceInfo As String = "<DeviceInfo>" &
            "<OutputFormat>EMF</OutputFormat>" &
            "<PageWidth>8.5in</PageWidth>" &
            "<PageHeight>11in</PageHeight>" &
            "<MarginTop>0.25in</MarginTop>" &
            "<MarginLeft>0.25in</MarginLeft>" &
            "<MarginRight>0.25in</MarginRight>" &
            "<MarginBottom>0.25in</MarginBottom>" &
            "</DeviceInfo>"
      Dim warnings As Warning()
      m_streams = New List(Of Stream)()
      report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
      For Each stream As Stream In m_streams
         stream.Position = 0
      Next
   End Sub

   ' Gestore per PrintPageEvents
   Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
      Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

      ' Regola l'area rettangolare con i margini della stampante.
      Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
                                          ev.PageBounds.Width,
                                          ev.PageBounds.Height)

      ' Disegna uno sfondo bianco per il rapporto.
      ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

      ' Disegna il contenuto del rapporto.
      ev.Graphics.DrawImage(pageImage, adjustedRect)

      ' Si prepara per la pagina successiva e verifica di non aver raggiunto la fine.
      m_currentPageIndex += 1
      ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
   End Sub

   Private Sub Print()
      If m_streams Is Nothing OrElse m_streams.Count = 0 Then
         Throw New Exception("Errore: nessun flusso da stampare.")
      End If

      Dim printDoc As New PrintDocument()

      ' Imposta il nome della stampante.
      If nomeStampante <> String.Empty Then
         printDoc.PrinterSettings.PrinterName = nomeStampante
      End If

      ' Imposta il numero di copie del documento da stampare.
      printDoc.PrinterSettings.Copies = numCopieStampa

      If Not printDoc.PrinterSettings.IsValid Then
         Throw New Exception("Errore: impossibile trovare la stampante predefinita.")
      Else
         AddHandler printDoc.PrintPage, AddressOf PrintPage
         m_currentPageIndex = 0
         printDoc.Print()
      End If
   End Sub

   ' Crea un rapporto locale, carica i dati, esporta il rapporto In un file .emf e lo stampa.
   Public Sub Run(ByVal nomeReport As String)
      Dim report As New LocalReport()
      report.ReportPath = nomeReport
      'report.DataSources.Add(New ReportDataSource("Sales", LoadSalesData()))

      report.DataSources.Add(New ReportDataSource(datiDataSet.ToString, datiDataSet.Tables(0)))

      report.EnableExternalImages = True

      report.Refresh()

      Export(report)
      Print()
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      If m_streams IsNot Nothing Then
         For Each stream As Stream In m_streams
            stream.Close()
         Next
         m_streams = Nothing
      End If
   End Sub

End Class
