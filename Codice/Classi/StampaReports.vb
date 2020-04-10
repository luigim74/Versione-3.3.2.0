#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       31/03/2020
' Data ultima modifica: 02/04/2020
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
   Private formatoPaginaDevice As String

   Public Sub New(ByVal dataSet As DataSet, ByVal stampante As String, ByVal numCopie As Short, ByVal formatoPagina As String)
      Try
         datiDataSet = dataSet
         nomeStampante = stampante
         numCopieStampa = numCopie
         formatoPaginaDevice = formatoPagina

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' Routine da fornire al render di report, al fine di salvare un'immagine per ogni pagina del rapporto.
   Private Function CreaStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
      Try
         Dim stream As Stream = New MemoryStream ' FileStream(Application.StartupPath & "\Reports\ReportTemp.emf", FileMode.Create)
         m_streams.Add(stream)

         Return stream

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   ' Esporta il rapporto indicato come file .EMF (Enhanced Metafile).
   Private Sub Esporta(ByVal report As LocalReport)
      Try
         Dim deviceInfo As String

         Select Case formatoPaginaDevice
            Case FORMATO_REPORT_A4
               deviceInfo = "<DeviceInfo>" &
                         "<OutputFormat>EMF</OutputFormat>" &
                         "<PageWidth>8.5in</PageWidth>" &
                         "<PageHeight>11in</PageHeight>" &
                         "<MarginTop>0.20in</MarginTop>" &
                         "<MarginLeft>0.20in</MarginLeft>" &
                         "<MarginRight>0.20in</MarginRight>" &
                         "<MarginBottom>0.20in</MarginBottom>" &
                         "</DeviceInfo>"

            Case FORMATO_REPORT_80mm
               deviceInfo = "<DeviceInfo>" &
                         "<OutputFormat>EMF</OutputFormat>" &
                         "<PageWidth>3.14in</PageWidth>" &
                         "<PageHeight>15in</PageHeight>" &
                         "<MarginTop>0in</MarginTop>" &
                         "<MarginLeft>0in</MarginLeft>" &
                         "<MarginRight>0in</MarginRight>" &
                         "<MarginBottom>0in</MarginBottom>" &
                         "</DeviceInfo>"
      End Select

      Dim warnings As Warning()
      m_streams = New List(Of Stream)()
      report.Render("Image", deviceInfo, AddressOf CreaStream, warnings)
      For Each stream As Stream In m_streams
         stream.Position = 0
      Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' Gestore per PrintPageEvents
   Private Sub StampaPagina(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
      Try
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

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Stampa()
      Try
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
            AddHandler printDoc.PrintPage, AddressOf StampaPagina
            m_currentPageIndex = 0
            printDoc.Print()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' Crea un rapporto locale, carica i dati, esporta il rapporto In un file .emf e lo stampa.
   Public Sub Avvia(ByVal nomeReport As String)
      Try
         Dim report As New LocalReport()
         report.ReportPath = nomeReport

         report.DataSources.Clear()

         ' Aggiunge le tabelle al datasource.
         Dim i As Integer
         For i = 0 To datiDataSet.Tables.Count - 1
            report.DataSources.Add(New ReportDataSource(datiDataSet.DataSetName, datiDataSet.Tables(i)))
         Next

         ' Indica se è possibile includere immagini esterne.
         report.EnableExternalImages = True
         report.Refresh()

         Esporta(report)

         Stampa()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      Try
         If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
               stream.Close()
            Next
            m_streams = Nothing
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
