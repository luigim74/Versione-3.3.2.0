#Region " DATI FILE.VB "
' ******************************************************************
' Nome modulo:          GeneraPdf
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/07/2018
' Data ultima modifica: 03/08/2018
' Descrizione:          Form MDI principale.

' ******************************************************************
#End Region

Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Module GeneraPdf

#Region "Esempio "

   ' Dim Documento As New Document(PageSize.A4, 100, 100, 25, 25)
   ' Dim fileStream As New FileStream("E:\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None)
   ' Dim Scrittura As PdfWriter = PdfWriter.GetInstance(Documento, fileStream)
   ' Documento.Open()
   ' 'Logo
   ' Dim logo = iTextSharp.text.Image.GetInstance("E:\LogoAngoloDelComputer.jpg")
   ' logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT
   ' Documento.Add(logo)
   ' Documento.Add(Chunk.NEWLINE)
   ' Documento.Add(Chunk.NEWLINE)
   ' Dim titleFont = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD)
   ' Dim ParTitolo As New Paragraph("Titolo", titleFont)
   ' ParTitolo.Alignment = iTextSharp.text.Element.ALIGN_CENTER
   ' Documento.Add(ParTitolo)
   ' Dim ParTesto As New Paragraph("Testo")
   ' Documento.Add(ParTesto)
   ' Documento.Close()

   Public Sub GeneraFilePDF()
      Dim DEST As String = Application.StartupPath & "\ProvaPDF.pdf"

      ' Crea un documento
      Dim Documento As New Document(PageSize.A4)

      ' Ottengo un istanza dell'oggetto PdfWriter
      PdfWriter.GetInstance(Documento, New FileStream(DEST, FileMode.Create))

      ' Apro il documento
      Documento.Open()

      ' Logo.
      Dim logo = Image.GetInstance(Application.StartupPath & "\Immagini\pizza.jpg")
      logo.Alignment = Image.ALIGN_LEFT
      Documento.Add(logo)
      Documento.Add(Chunk.NEWLINE)
      Documento.Add(Chunk.NEWLINE)

      ' Titolo.
      Dim titoloFont = FontFactory.GetFont("Arial", 20, Font.BOLD)
      Dim ParTitolo As New Paragraph("Hello World!", titoloFont)
      ParTitolo.Alignment = Element.ALIGN_CENTER
      Documento.Add(ParTitolo)
      Documento.Add(Chunk.NEWLINE)

      ' Testo.
      Dim testoFont = FontFactory.GetFont("Arial", 15, Font.NORMAL)
      Dim ParTesto As New Paragraph("Questo è il Testo del documento Pdf.")
      Documento.Add(ParTesto)

      ' Chiudo il documento
      Documento.Close()
   End Sub

#End Region

#Region "Hotel - Prenotazione "

   Public Function GeneraRiepilogoPren_PDF(ByVal percorsoLogo As String, ByVal ragSociale As String, ByVal indirizzo As String, ByVal città As String,
                                           ByVal pIva As String, ByVal telFax As String, ByVal eMail As String, ByVal numPren As String, ByVal titolo As String,
                                           ByVal Cliente As String, ByVal eMailCliente As String, ByVal arrivo As String, ByVal partenza As String, ByVal notti As String,
                                           ByVal adulti As String, ByVal neonati As String, ByVal bambini As String, ByVal ragazzi As String,
                                           ByVal numCamera As String, ByVal tipoCamera As String, ByVal arrangiamento As String,
                                           ByVal importo As String, ByVal acconto As String, ByVal saldo As String, ByVal note As String, ByVal percorsoFilePDF As String) As String
      Try
         Dim SPAZIO As String = Space(20)

         ' Crea un documento
         Dim Documento As New Document(PageSize.A4)

         ' Ottengo un istanza dell'oggetto PdfWriter
         PdfWriter.GetInstance(Documento, New FileStream(percorsoFilePDF, FileMode.Create))

         ' Apro il documento
         Documento.Open()

         ' Logo.
         Dim logo = Image.GetInstance(percorsoLogo)
         logo.Alignment = Image.ALIGN_CENTER
         Documento.Add(logo)
         Documento.Add(Chunk.NEWLINE)

         ' Ragione Sociale.
         Dim ragioneSocialeFont = FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)
         Dim phrRagioneSociale As New Phrase(ragSociale, ragioneSocialeFont)
         Documento.Add(phrRagioneSociale)

         Documento.Add(Chunk.NEWLINE)

         ' Indirizzo.
         Dim viaFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrVia As New Phrase(indirizzo, viaFont)
         Documento.Add(phrVia)

         Documento.Add(Chunk.NEWLINE)

         Dim capFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrCap As New Phrase(città, capFont)
         Documento.Add(phrCap)

         Documento.Add(Chunk.NEWLINE)

         Dim pIvaFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrPIva As New Phrase(pIva, pIvaFont)
         Documento.Add(phrPIva)

         Documento.Add(Chunk.NEWLINE)

         Dim telFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrTel As New Phrase(telFax, telFont)
         Documento.Add(phrTel)

         Documento.Add(Chunk.NEWLINE)

         Dim MailFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLUE)
         Dim phrmail As New Phrase(eMail, MailFont)
         Documento.Add(phrmail)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Titolo.
         Dim titoloFont = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.ORANGE)
         Dim parTitolo As New Paragraph("*** " & titolo & " ***", titoloFont)
         parTitolo.Alignment = Element.ALIGN_CENTER
         Documento.Add(parTitolo)
         Documento.Add(Chunk.NEWLINE)

         ' Dettagli prenotazione.
         Dim dettagliFont = FontFactory.GetFont("Arial", 14, Font.BOLD)
         Dim parDettagli As New Paragraph("LA SUA PRENOTAZIONE", dettagliFont)
         parDettagli.Alignment = Element.ALIGN_LEFT
         Documento.Add(parDettagli)
         Documento.Add(Chunk.NEWLINE)

         ' Numero prenotazione.
         Dim numeroFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrNumero As New Phrase("Numero prenotazione: ", numeroFont)
         Documento.Add(phrNumero)

         Dim valNumeroFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.RED)
         Dim phrValNumero As New Phrase(numPren, valNumeroFont)
         Documento.Add(phrValNumero)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Nome Cliente.
         Dim clienteFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrCliente As New Phrase("Nome del cliente: ", clienteFont)
         Documento.Add(phrCliente)

         Dim valClienteFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValCliente As New Phrase(Cliente, valClienteFont)
         Documento.Add(phrValCliente)

         Documento.Add(Chunk.NEWLINE)

         ' E-mail Cliente.
         Dim emailFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrEmail As New Phrase("Indirizzo e-mail: ", emailFont)
         Documento.Add(phrEmail)

         Dim valEmailFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLUE)
         Dim phrValEmail As New Phrase(eMailCliente, valEmailFont)
         Documento.Add(phrValEmail)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Arrivo.
         Dim arrivoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrArrivo As New Phrase("Arrivo: ", arrivoFont)
         Documento.Add(phrArrivo)

         Dim valArrivoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValArrivo As New Phrase(arrivo & SPAZIO, valArrivoFont)
         Documento.Add(phrValArrivo)

         ' Partenza.
         Dim partenzaFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrPartenza As New Phrase("Partenza: ", partenzaFont)
         Documento.Add(phrPartenza)

         Dim valPartenzaFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValPartenza As New Phrase(partenza & SPAZIO, valPartenzaFont)
         Documento.Add(phrValPartenza)

         ' Numero notti.
         Dim nottiFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrNotti As New Phrase("Notti: ", nottiFont)
         Documento.Add(phrNotti)

         Dim valNottiFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValNotti As New Phrase(notti, valNottiFont)
         Documento.Add(phrValNotti)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Adulti.
         Dim adultiFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrAdulti As New Phrase("Adulti: ", adultiFont)
         Documento.Add(phrAdulti)

         Dim valAdultiFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValAdulti As New Phrase(adulti & SPAZIO, valAdultiFont)
         Documento.Add(phrValAdulti)

         Documento.Add(Chunk.NEWLINE)

         ' Neonati.
         Dim neonatiFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrNeonati As New Phrase("Neonati: ", neonatiFont)
         Documento.Add(phrNeonati)

         Dim valNeonatiFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValNeonati As New Phrase(neonati & SPAZIO, valNeonatiFont)
         Documento.Add(phrValNeonati)

         Documento.Add(Chunk.NEWLINE)

         ' Bambini.
         Dim bambiniFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrBambini As New Phrase("Bambini: ", bambiniFont)
         Documento.Add(phrBambini)

         Dim valBambiniFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValBambini As New Phrase(bambini & SPAZIO, valBambiniFont)
         Documento.Add(phrValBambini)

         Documento.Add(Chunk.NEWLINE)

         ' Ragazzi.
         Dim ragazziFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrRagazzi As New Phrase("Ragazzi: ", ragazziFont)
         Documento.Add(phrRagazzi)

         Dim valRagazziFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValRagazzi As New Phrase(ragazzi, valRagazziFont)
         Documento.Add(phrValRagazzi)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Numero Camera.
         Dim numCameraFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrNumCamera As New Phrase("Numero camera: ", numCameraFont)
         Documento.Add(phrNumCamera)

         Dim valNumCameraFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.RED)
         Dim phrValNumCamera As New Phrase(numCamera & SPAZIO, valNumCameraFont)
         Documento.Add(phrValNumCamera)

         Documento.Add(Chunk.NEWLINE)

         ' Tipologia Camera.
         Dim tipologiaCameraFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrTipologiaCamera As New Phrase("Tipologia: ", tipologiaCameraFont)
         Documento.Add(phrTipologiaCamera)

         Dim valTipologiaCameraFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValTipologiaCamera As New Phrase(tipoCamera, valTipologiaCameraFont)
         Documento.Add(phrValTipologiaCamera)

         Documento.Add(Chunk.NEWLINE)

         ' Arrangiamento Camera.
         Dim arrangiamentoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrArrangiamento As New Phrase("Arrangiamento: ", arrangiamentoFont)
         Documento.Add(phrArrangiamento)

         Dim valArrangiamentoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValArrangiamento As New Phrase(arrangiamento, valArrangiamentoFont)
         Documento.Add(phrValArrangiamento)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Importo totale.
         Dim importoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrImporto As New Phrase("Importo totale: ", importoFont)
         Documento.Add(phrImporto)

         Dim valImportoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValImporto As New Phrase("€ " & importo & SPAZIO, valImportoFont)
         Documento.Add(phrValImporto)

         ' Acconto.
         Dim accontoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrAcconto As New Phrase("Acconto: ", accontoFont)
         Documento.Add(phrAcconto)

         Dim valAccontoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValAcconto As New Phrase("€ " & acconto & SPAZIO, valAccontoFont)
         Documento.Add(phrValAcconto)

         ' Saldo.
         Dim saldoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrSaldo As New Phrase("Saldo: ", saldoFont)
         Documento.Add(phrSaldo)

         Dim valSaldoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.RED)
         Dim phrValSaldo As New Phrase("€ " & saldo, valSaldoFont)
         Documento.Add(phrValSaldo)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Note.
         Dim noteFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrNote As New Phrase("Note: ", noteFont)
         Documento.Add(phrNote)

         Documento.Add(Chunk.NEWLINE)

         Dim valNoteFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValNote As New Phrase(note, valNoteFont)
         Documento.Add(phrValNote)

         ' Chiudo il documento
         Documento.Close()

         If File.Exists(percorsoFilePDF) = True Then
            Return percorsoFilePDF
         Else
            Return String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function GeneraRicevutaCaparraPren_PDF(ByVal percorsoLogo As String, ByVal ragSociale As String, ByVal indirizzo As String, ByVal città As String,
                                                 ByVal pIva As String, ByVal telFax As String, ByVal eMail As String, ByVal numPren As String, ByVal dataPren As String,
                                                 ByVal cliente As String, ByVal arrivo As String, ByVal partenza As String, ByVal acconto As String) As String
      Try
         Dim SPAZIO As String = Space(20)
         Dim percorsoFilePDF As String = Application.StartupPath & "\Documenti\Ricevuta caparra prenotazione_" & numPren & ".pdf"

         ' Crea un documento
         Dim Documento As New Document(PageSize.A4)

         ' Ottengo un istanza dell'oggetto PdfWriter
         PdfWriter.GetInstance(Documento, New FileStream(percorsoFilePDF, FileMode.Create))

         ' Apro il documento
         Documento.Open()

         ' Logo.
         Dim logo = Image.GetInstance(percorsoLogo)
         logo.Alignment = Image.ALIGN_CENTER
         Documento.Add(logo)
         Documento.Add(Chunk.NEWLINE)

         ' Ragione Sociale.
         Dim ragioneSocialeFont = FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)
         Dim phrRagioneSociale As New Phrase(ragSociale, ragioneSocialeFont)
         Documento.Add(phrRagioneSociale)

         Documento.Add(Chunk.NEWLINE)

         ' Indirizzo.
         Dim viaFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrVia As New Phrase(indirizzo, viaFont)
         Documento.Add(phrVia)

         Documento.Add(Chunk.NEWLINE)

         Dim capFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrCap As New Phrase(città, capFont)
         Documento.Add(phrCap)

         Documento.Add(Chunk.NEWLINE)

         Dim pIvaFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrPIva As New Phrase(pIva, pIvaFont)
         Documento.Add(phrPIva)

         Documento.Add(Chunk.NEWLINE)

         Dim telFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrTel As New Phrase(telFax, telFont)
         Documento.Add(phrTel)

         Documento.Add(Chunk.NEWLINE)

         Dim MailFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLUE)
         Dim phrmail As New Phrase(eMail, MailFont)
         Documento.Add(phrmail)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Titolo.
         Dim titoloFont = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.ORANGE)
         Dim parTitolo As New Paragraph("*** Ricevuta per Caparra confirmatoria ***", titoloFont)
         parTitolo.Alignment = Element.ALIGN_CENTER
         Documento.Add(parTitolo)
         Documento.Add(Chunk.NEWLINE)

         ' Nome Cliente.
         Dim clienteFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrCliente As New Phrase("Il/La signor/a ", clienteFont)
         Documento.Add(phrCliente)

         Dim valClienteFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValCliente As New Phrase(cliente, valClienteFont)
         Documento.Add(phrValCliente)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Nome struttura.
         Dim strutturaFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrStruttura As New Phrase("consegna, a titolo di caparra confirmatoria, alla struttura ", strutturaFont)
         Documento.Add(phrStruttura)

         Dim valStrutturaFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValStruttura As New Phrase(ragSociale, valStrutturaFont)
         Documento.Add(phrValStruttura)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Acconto.
         Dim accontoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrAcconto As New Phrase("che riceve e rilascia quietanza, la somma di euro ", accontoFont)
         Documento.Add(phrAcconto)

         Dim valAccontoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValAcconto As New Phrase("€ " & acconto & ", ", valAccontoFont)
         Documento.Add(phrValAcconto)

         ' Numero prenotazione.
         Dim numeroFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrNumero As New Phrase("che verrà imputata alla prestazione dovuta, ovvero alla prenotazione numero ", numeroFont)
         Documento.Add(phrNumero)

         Dim valNumeroFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValNumero As New Phrase(numPren, valNumeroFont)
         Documento.Add(phrValNumero)

         ' Data e ora prenotazione.
         Dim dataFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrData As New Phrase(" del ", dataFont)
         Documento.Add(phrData)

         Dim valDataFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValData As New Phrase(dataPren, valDataFont)
         Documento.Add(phrValData)

         ' Arrivo.
         Dim arrivoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrArrivo As New Phrase(" con data di arrivo ", arrivoFont)
         Documento.Add(phrArrivo)

         Dim valArrivoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValArrivo As New Phrase(arrivo, valArrivoFont)
         Documento.Add(phrValArrivo)

         ' Partenza.
         Dim partenzaFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrPartenza As New Phrase(" e partenza ", partenzaFont)
         Documento.Add(phrPartenza)

         Dim valPartenzaFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValPartenza As New Phrase(partenza & ".", valPartenzaFont)
         Documento.Add(phrValPartenza)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Nome Cliente.
         Dim clienteFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrCliente1 As New Phrase("Nel caso di inadempimento da parte del/la signor/a ", clienteFont1)
         Documento.Add(phrCliente1)

         Dim valClienteFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValCliente1 As New Phrase(cliente & ",", valClienteFont1)
         Documento.Add(phrValCliente1)

         ' Nome struttura.
         Dim strutturaFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrStruttura1 As New Phrase(" la struttura ", strutturaFont1)
         Documento.Add(phrStruttura1)

         Dim valStrutturaFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValStruttura1 As New Phrase(ragSociale & " ha diritto a trattenere la somma ricevuta o a restituirla e ad agire ai sensi dell'art. 1453 del Codice civile.", valStrutturaFont1)
         Documento.Add(phrValStruttura1)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Nome Cliente.
         Dim clienteFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrCliente2 As New Phrase("Nel caso di inadempimento della struttura ", clienteFont2)
         Documento.Add(phrCliente2)

         Dim valClienteFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValCliente2 As New Phrase(ragSociale & ",", valClienteFont2)
         Documento.Add(phrValCliente2)

         ' Nome struttura.
         Dim strutturaFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrStruttura2 As New Phrase(" quest'ultima dovrà restituire al/la signor/a ", strutturaFont2)
         Documento.Add(phrStruttura2)

         Dim valStrutturaFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValStruttura2 As New Phrase(cliente & " il doppio della suddetta somma.", valStrutturaFont2)
         Documento.Add(phrValStruttura2)

         ' Chiudo il documento
         Documento.Close()

         If File.Exists(percorsoFilePDF) = True Then
            Return percorsoFilePDF
         Else
            Return String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function GeneraRicevutaAccontoPren_PDF(ByVal percorsoLogo As String, ByVal ragSociale As String, ByVal indirizzo As String, ByVal città As String,
                                                 ByVal pIva As String, ByVal telFax As String, ByVal eMail As String, ByVal numPren As String, ByVal dataPren As String,
                                                 ByVal cliente As String, ByVal arrivo As String, ByVal partenza As String, ByVal acconto As String) As String
      Try
         Dim SPAZIO As String = Space(20)
         Dim percorsoFilePDF As String = Application.StartupPath & "\Documenti\Ricevuta acconto prenotazione_" & numPren & ".pdf"

         ' Crea un documento
         Dim Documento As New Document(PageSize.A4)

         ' Ottengo un istanza dell'oggetto PdfWriter
         PdfWriter.GetInstance(Documento, New FileStream(percorsoFilePDF, FileMode.Create))

         ' Apro il documento
         Documento.Open()

         ' Logo.
         Dim logo = Image.GetInstance(percorsoLogo)
         logo.Alignment = Image.ALIGN_CENTER
         Documento.Add(logo)
         Documento.Add(Chunk.NEWLINE)

         ' Ragione Sociale.
         Dim ragioneSocialeFont = FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)
         Dim phrRagioneSociale As New Phrase(ragSociale, ragioneSocialeFont)
         Documento.Add(phrRagioneSociale)

         Documento.Add(Chunk.NEWLINE)

         ' Indirizzo.
         Dim viaFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrVia As New Phrase(indirizzo, viaFont)
         Documento.Add(phrVia)

         Documento.Add(Chunk.NEWLINE)

         Dim capFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrCap As New Phrase(città, capFont)
         Documento.Add(phrCap)

         Documento.Add(Chunk.NEWLINE)

         Dim pIvaFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrPIva As New Phrase(pIva, pIvaFont)
         Documento.Add(phrPIva)

         Documento.Add(Chunk.NEWLINE)

         Dim telFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)
         Dim phrTel As New Phrase(telFax, telFont)
         Documento.Add(phrTel)

         Documento.Add(Chunk.NEWLINE)

         Dim MailFont = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLUE)
         Dim phrmail As New Phrase(eMail, MailFont)
         Documento.Add(phrmail)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Titolo.
         Dim titoloFont = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.ORANGE)
         Dim parTitolo As New Paragraph("*** Ricevuta per Acconto prenotazione ***", titoloFont)
         parTitolo.Alignment = Element.ALIGN_CENTER
         Documento.Add(parTitolo)
         Documento.Add(Chunk.NEWLINE)

         ' Nome Cliente.
         Dim clienteFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrCliente As New Phrase("Il/La signor/a ", clienteFont)
         Documento.Add(phrCliente)

         Dim valClienteFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValCliente As New Phrase(cliente, valClienteFont)
         Documento.Add(phrValCliente)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Nome struttura.
         Dim strutturaFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrStruttura As New Phrase("consegna, a titolo di acconto, alla struttura ", strutturaFont)
         Documento.Add(phrStruttura)

         Dim valStrutturaFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValStruttura As New Phrase(ragSociale, valStrutturaFont)
         Documento.Add(phrValStruttura)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Acconto.
         Dim accontoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrAcconto As New Phrase("che riceve e rilascia quietanza, la somma di euro ", accontoFont)
         Documento.Add(phrAcconto)

         Dim valAccontoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValAcconto As New Phrase("€ " & acconto & ", ", valAccontoFont)
         Documento.Add(phrValAcconto)

         ' Numero prenotazione.
         Dim numeroFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrNumero As New Phrase("che verrà imputata alla prestazione dovuta, ovvero alla prenotazione numero ", numeroFont)
         Documento.Add(phrNumero)

         Dim valNumeroFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValNumero As New Phrase(numPren, valNumeroFont)
         Documento.Add(phrValNumero)

         ' Data e ora prenotazione.
         Dim dataFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrData As New Phrase(" del ", dataFont)
         Documento.Add(phrData)

         Dim valDataFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValData As New Phrase(dataPren, valDataFont)
         Documento.Add(phrValData)

         ' Arrivo.
         Dim arrivoFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrArrivo As New Phrase(" con data di arrivo ", arrivoFont)
         Documento.Add(phrArrivo)

         Dim valArrivoFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValArrivo As New Phrase(arrivo, valArrivoFont)
         Documento.Add(phrValArrivo)

         ' Partenza.
         Dim partenzaFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrPartenza As New Phrase(" e partenza ", partenzaFont)
         Documento.Add(phrPartenza)

         Dim valPartenzaFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
         Dim phrValPartenza As New Phrase(partenza & ".", valPartenzaFont)
         Documento.Add(phrValPartenza)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Nome Cliente.
         Dim clienteFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrCliente1 As New Phrase("Nel caso di inadempimento da parte del/la signor/a ", clienteFont1)
         Documento.Add(phrCliente1)

         Dim valClienteFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValCliente1 As New Phrase(cliente & ",", valClienteFont1)
         Documento.Add(phrValCliente1)

         ' Nome struttura.
         Dim strutturaFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrStruttura1 As New Phrase(" la struttura ", strutturaFont1)
         Documento.Add(phrStruttura1)

         Dim valStrutturaFont1 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValStruttura1 As New Phrase(ragSociale & " ha il dovere di restituire la somma ricevuta.", valStrutturaFont1)
         Documento.Add(phrValStruttura1)

         Documento.Add(Chunk.NEWLINE)
         Documento.Add(Chunk.NEWLINE)

         ' Nome Cliente.
         Dim clienteFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrCliente2 As New Phrase("Nel caso di inadempimento della struttura ", clienteFont2)
         Documento.Add(phrCliente2)

         Dim valClienteFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValCliente2 As New Phrase(ragSociale & ",", valClienteFont2)
         Documento.Add(phrValCliente2)

         ' Nome struttura.
         Dim strutturaFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrStruttura2 As New Phrase(" quest'ultima dovrà restituire al/la signor/a ", strutturaFont2)
         Documento.Add(phrStruttura2)

         Dim valStrutturaFont2 = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
         Dim phrValStruttura2 As New Phrase(cliente & " la suddetta somma.", valStrutturaFont2)
         Documento.Add(phrValStruttura2)

         ' Chiudo il documento
         Documento.Close()

         If File.Exists(percorsoFilePDF) = True Then
            Return percorsoFilePDF
         Else
            Return String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

#End Region

End Module
