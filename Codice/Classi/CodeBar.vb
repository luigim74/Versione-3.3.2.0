Public Class CodeBar
   Private err As New Varie.Errore

#Region "EAN 8 - CODICE NUMERICO"

   ' La funzione della codifica EAN e` rappresentare il codice numerico di ogni articolo soggetto alle specifiche EAN (European Article Number)
   ' in un formato leggibile automaticamente in entrambe le direzioni. Il codice EAN e` interamente compatibile con il codice UPC 
   ' (Universal Product Code). Gli elementi possono assumere 4 diversi spessori, multipli interi del modulo. Ogni cifra e` codificata con 7 moduli.
   ' Il carattere di controllo centrale e` composto da 5 moduli; quello di start/stop da 3 moduli. 
   ' I simboli EAN sono disposti "simmetricamente" attorno ad un carattere centrale di controllo, 
   ' e delimitati agli estremi da caratteri laterali di controllo (start/stop). 
   '
   ' - Codice numerico 
   ' - Codice continuo 
   ' - Codice self-checking 
   ' - Lunghezza = 8

   Function EAN8(ByVal Ctrl As TextBox, ByVal objPicBox As PictureBox, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer) As Boolean
      Try
         'Declarations
         Dim check_digit As Integer, i As Integer
         Dim mod_width As Single
         Dim barcode As String
         Dim Chr As Char
         Dim sequence As String
         Dim cod As String
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("Arial", 10, FontStyle.Regular)
         Dim sfondoImg As New Bitmap(objPicBox.Width, objPicBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
         Dim gr As Graphics = Graphics.FromImage(sfondoImg)
         gr.FillRectangle(New System.Drawing.SolidBrush(Color.White), New Rectangle(0, 0, objPicBox.Width, objPicBox.Height))

         Dim EAN_A_cod(9) As String
         EAN_A_cod(0) = "0001101"
         EAN_A_cod(1) = "0011001"
         EAN_A_cod(2) = "0010011"
         EAN_A_cod(3) = "0111101"
         EAN_A_cod(4) = "0100011"
         EAN_A_cod(5) = "0110001"
         EAN_A_cod(6) = "0101111"
         EAN_A_cod(7) = "0111011"
         EAN_A_cod(8) = "0110111"
         EAN_A_cod(9) = "0001011"

         Dim EAN_C_cod(9) As String
         EAN_C_cod(0) = "1110010"
         EAN_C_cod(1) = "1100110"
         EAN_C_cod(2) = "1101100"
         EAN_C_cod(3) = "1000010"
         EAN_C_cod(4) = "1011100"
         EAN_C_cod(5) = "1001110"
         EAN_C_cod(6) = "1010000"
         EAN_C_cod(7) = "1000100"
         EAN_C_cod(8) = "1001000"
         EAN_C_cod(9) = "1110100"

         barcode = Ctrl.Text

         'Controllo correttezza codice e calcolo check_digit
         If Not IsNumeric(barcode) Then
            Return False
         End If

         If Len(barcode) <> 8 Then
            Return False
         End If

         check_digit = 0
         For i = 7 To 1 Step -2
            Chr = Mid(barcode, i, 1)
            If Chr < "0" Or Chr > "9" Then Exit Function
            check_digit = check_digit + 3 * Val(Chr)
         Next i
         For i = 6 To 2 Step -2
            Chr = Mid(barcode, i, 1)
            If Chr < "0" Or Chr > "9" Then Exit Function
            check_digit = check_digit + Val(Chr)
         Next i
         check_digit = 10 - check_digit Mod 10
         If check_digit = 10 Then check_digit = 0
         barcode = Left(barcode, 7) & Trim(Str(check_digit))

         'Debug.Print(check_digit)

         'Generazione della stringa immagine della codifica

         cod = "1010000000"
         For i = 8 To 5 Step -1
            Chr = Mid(barcode, i, 1)
            cod = EAN_C_cod(Val(Chr)) & cod
         Next i
         cod = "01010" & cod
         For i = 4 To 1 Step -1
            Chr = Mid(barcode, i, 1)
            cod = EAN_A_cod(Val(Chr)) & cod
         Next i
         cod = "0000000101" & cod

         'Determinazione della larghezza del modulo

         mod_width = mx / Len(cod$)

         'Stampa della codifica

         Dim Clr As Color
         Dim StartPoint As Integer = sx
         For i = 1 To Len(cod)
            Select Case Mid(cod, i, 1)
               Case "0"
                  Clr = Color.White
               Case "1"
                  Clr = Color.Black
            End Select

            gr.FillRectangle(New System.Drawing.SolidBrush(Clr), StartPoint, sy, mod_width, my - 15)
            StartPoint = StartPoint + mod_width
         Next i

         strFormat.Alignment = StringAlignment.Center
         strFormat.FormatFlags = StringFormatFlags.NoWrap
         gr.DrawString(Ctrl.Text, FontForText, New System.Drawing.SolidBrush(objPicBox.ForeColor), CSng((StartPoint - mod_width) / 2), CSng(70 - FontForText.Height), strFormat)
         objPicBox.Image = sfondoImg

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
         Return False
      End Try
   End Function

#End Region

#Region "EAN 13 - CODICE NUMERICO"

   ' La funzione della codifica EAN e` rappresentare il codice numerico di ogni articolo soggetto alle specifiche EAN (European Article Number)
   ' in un formato leggibile automaticamente in entrambe le direzioni. Il codice EAN e` interamente compatibile con il codice UPC 
   ' (Universal Product Code). Gli elementi possono assumere 4 diversi spessori, multipli interi del modulo. Ogni cifra e` codificata con 7 moduli.
   ' Il carattere di controllo centrale e` composto da 5 moduli; quello di start/stop da 3 moduli. 
   ' I simboli EAN sono disposti "simmetricamente" attorno ad un carattere centrale di controllo, 
   ' e delimitati agli estremi da caratteri laterali di controllo (start/stop). 
   '
   ' - Codice numerico 
   ' - Codice continuo 
   ' - Codice self-checking 
   ' - Lunghezza = 13

   Function EAN13(ByVal Ctrl As TextBox, ByVal objPicBox As PictureBox, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer) As Boolean
      Try
         'Declarations
         Dim check_digit As Integer, i As Integer
         Dim mod_width As Single
         Dim barcode As String
         Dim Chr As Char
         Dim sequence As String
         Dim cod As String
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("Arial", 10, FontStyle.Regular)
         Dim sfondoImg As New Bitmap(objPicBox.Width, objPicBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
         Dim gr As Graphics = Graphics.FromImage(sfondoImg)
         gr.FillRectangle(New System.Drawing.SolidBrush(Color.White), New Rectangle(0, 0, objPicBox.Width, objPicBox.Height))

         Dim EAN_sequence(9) As String
         EAN_sequence(0) = "AAAAAA"
         EAN_sequence(1) = "AABABB"
         EAN_sequence(2) = "AABBAB"
         EAN_sequence(3) = "AABBBA"
         EAN_sequence(4) = "ABAABB"
         EAN_sequence(5) = "ABBAAB"
         EAN_sequence(6) = "ABBBAA"
         EAN_sequence(7) = "ABABAB"
         EAN_sequence(8) = "ABABBA"
         EAN_sequence(9) = "ABBABA"

         Dim EAN_A_cod(9) As String
         EAN_A_cod(0) = "0001101"
         EAN_A_cod(1) = "0011001"
         EAN_A_cod(2) = "0010011"
         EAN_A_cod(3) = "0111101"
         EAN_A_cod(4) = "0100011"
         EAN_A_cod(5) = "0110001"
         EAN_A_cod(6) = "0101111"
         EAN_A_cod(7) = "0111011"
         EAN_A_cod(8) = "0110111"
         EAN_A_cod(9) = "0001011"

         Dim EAN_B_cod(9) As String
         EAN_B_cod(0) = "0100111"
         EAN_B_cod(1) = "0110011"
         EAN_B_cod(2) = "0011011"
         EAN_B_cod(3) = "0100001"
         EAN_B_cod(4) = "0011101"
         EAN_B_cod(5) = "0111001"
         EAN_B_cod(6) = "0000101"
         EAN_B_cod(7) = "0010001"
         EAN_B_cod(8) = "0001001"
         EAN_B_cod(9) = "0010111"

         Dim EAN_C_cod(9) As String
         EAN_C_cod(0) = "1110010"
         EAN_C_cod(1) = "1100110"
         EAN_C_cod(2) = "1101100"
         EAN_C_cod(3) = "1000010"
         EAN_C_cod(4) = "1011100"
         EAN_C_cod(5) = "1001110"
         EAN_C_cod(6) = "1010000"
         EAN_C_cod(7) = "1000100"
         EAN_C_cod(8) = "1001000"
         EAN_C_cod(9) = "1110100"

         barcode = Ctrl.Text

         'Controllo correttezza codice e calcolo check_digit
         If Not IsNumeric(barcode) Then
            Return False
         End If

         If Len(barcode) <> 13 Then
            Return False
         End If

         check_digit = 0
         For i = 12 To 2 Step -2
            Chr = Mid(barcode, i, 1)
            If Chr < "0" Or Chr > "9" Then Exit Function
            check_digit = check_digit + 3 * Val(Chr)
         Next i
         For i = 11 To 1 Step -2
            Chr = Mid(barcode, i, 1)
            If Chr < "0" Or Chr > "9" Then Exit Function
            check_digit = check_digit + Val(Chr)
         Next i
         check_digit = 10 - check_digit Mod 10
         If check_digit = 10 Then check_digit = 0
         sequence = EAN_sequence(Val(Left(barcode, 1)))
         barcode = Mid(barcode, 2, 11) & Trim(Str(check_digit))

         'Debug.Print(check_digit)

         'Generazione della stringa immagine della codifica
         cod = "1010000000"
         For i = 12 To 7 Step -1
            Chr = Mid(barcode, i, 1)
            cod = EAN_C_cod(Val(Chr)) & cod
         Next i
         cod = "01010" & cod
         For i = 6 To 1 Step -1
            Chr = Mid(barcode, i, 1)
            Select Case Mid(sequence, i, 1)
               Case "A"
                  cod = EAN_A_cod(Val(Chr)) & cod
               Case "B"
                  cod = EAN_B_cod(Val(Chr)) & cod
            End Select
         Next i
         cod = "00000000000101" & cod

         'Determinazione della larghezza del modulo

         mod_width = mx / Len(cod)

         'Stampa della codifica
         Dim Clr As Color
         Dim StartPoint As Integer = sx
         For i = 1 To Len(cod)
            Select Case Mid(cod, i, 1)
               Case "0"
                  Clr = Color.White
               Case "1"
                  Clr = Color.Black
            End Select

            gr.FillRectangle(New System.Drawing.SolidBrush(Clr), StartPoint, sy, mod_width, my - 15)
            StartPoint = StartPoint + mod_width
         Next i

         strFormat.Alignment = StringAlignment.Center
         strFormat.FormatFlags = StringFormatFlags.NoWrap
         gr.DrawString(Ctrl.Text, FontForText, New System.Drawing.SolidBrush(objPicBox.ForeColor), CSng((StartPoint - mod_width) / 2), CSng(70 - FontForText.Height), strFormat)
         objPicBox.Image = sfondoImg

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
         Return False
      End Try
   End Function

#End Region

#Region "CODE 39 - CODICE ALFANUMERICO CON CARATTERI SPECIALI"

   ' Il codice 39 e` stato sviluppato nel 1974, per applicazioni richiedenti un codice alfanumerico. 
   ' E` un codice interessante sotto molti aspetti. Anche utilizzatori di dati numerici possono trovare vantaggiosa la possibilita` 
   ' di codificare caratteri alfabetici e speciali. Il codice 39 ha avuto una forte espansione negli enti pubblici, nell'industria e nel commercio.
   ' Tra i codici industriali e` il piu`diffuso. Il codice 39 risponde alle norme MIL-STD-1189 e ANSI MH 10.8M-1983. 
   ' Permette la codifica di 43 caratteri, ognuno dei quali e` rappresentato da 9 elementi, 5 barre e 4 spazi; 3 elementi sono larghi e 6 stretti. 
   ' La dimensione del simbolo dipende dallo spessore del modulo e dal rapporto di stampa. L'altezza delle barre dipende dal campo applicativo.
   '
   ' - Codice alfanumerico con caratteri speciali 
   ' - Codice discreto 
   ' - Codice self-checking 
   ' - Lunghezza = VARIABILE

   Function CODE39(ByVal Ctrl As TextBox, ByVal objPicBox As PictureBox, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer) As Boolean
      Try

         'Declarations
         Dim check_digit As Integer, i As Integer
         Dim mod_width As Single
         Dim barcode As String
         Dim length As Integer
         Dim code As String
         Dim Chr As Char
         Dim maschera As String
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("Arial", 10, FontStyle.Regular)
         Dim sfondoImg As New Bitmap(objPicBox.Width, objPicBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
         Dim gr As Graphics = Graphics.FromImage(sfondoImg)
         gr.FillRectangle(New System.Drawing.SolidBrush(Color.White), New Rectangle(0, 0, objPicBox.Width, objPicBox.Height))

         Dim code_39(44) As String
         code_39(1) = "1100100001"
         code_39(2) = "2001100001"
         code_39(3) = "3101100000"
         code_39(4) = "4000110001"
         code_39(5) = "5100110000"
         code_39(6) = "6001110000"
         code_39(7) = "7000100101"
         code_39(8) = "8100100100"
         code_39(9) = "9001100100"
         code_39(10) = "0000110100"
         code_39(11) = "A100001001"
         code_39(12) = "B001001001"
         code_39(13) = "C101001000"
         code_39(14) = "D000011001"
         code_39(15) = "E100011000"
         code_39(16) = "F001011000"
         code_39(17) = "G000001101"
         code_39(18) = "H100001100"
         code_39(19) = "I001001100"
         code_39(20) = "J000011100"
         code_39(21) = "K100000011"
         code_39(22) = "L001000011"
         code_39(23) = "M101000010"
         code_39(24) = "N000010011"
         code_39(25) = "O100010010"
         code_39(26) = "P001010010"
         code_39(27) = "Q000000111"
         code_39(28) = "R100000110"
         code_39(29) = "S001000110"
         code_39(30) = "T000010110"
         code_39(31) = "U110000001"
         code_39(32) = "V011000001"
         code_39(33) = "W111000000"
         code_39(34) = "X010010001"
         code_39(35) = "Y110010000"
         code_39(36) = "Z011010000"
         code_39(37) = "-010000101"
         code_39(38) = ".110000100"
         code_39(39) = " 011000100"
         code_39(40) = "*010010100"
         code_39(41) = "$010101000"
         code_39(42) = "/010100010"
         code_39(43) = "+010001010"
         code_39(44) = "%000101010"

         Dim Val39(43) As String
         Val39(0) = "0"
         Val39(1) = "1"
         Val39(2) = "2"
         Val39(3) = "3"
         Val39(4) = "4"
         Val39(5) = "5"
         Val39(6) = "6"
         Val39(7) = "7"
         Val39(8) = "8"
         Val39(9) = "9"
         Val39(10) = "A"
         Val39(11) = "B"
         Val39(12) = "C"
         Val39(13) = "D"
         Val39(14) = "E"
         Val39(15) = "F"
         Val39(16) = "G"
         Val39(17) = "H"
         Val39(18) = "I"
         Val39(19) = "J"
         Val39(20) = "K"
         Val39(21) = "L"
         Val39(22) = "M"
         Val39(23) = "N"
         Val39(24) = "O"
         Val39(25) = "P"
         Val39(26) = "Q"
         Val39(27) = "R"
         Val39(28) = "S"
         Val39(29) = "T"
         Val39(30) = "U"
         Val39(31) = "V"
         Val39(32) = "W"
         Val39(33) = "X"
         Val39(34) = "Y"
         Val39(35) = "Z"
         Val39(36) = "-"
         Val39(37) = "."
         Val39(38) = " "
         Val39(39) = "$"
         Val39(40) = "/"
         Val39(41) = "+"
         Val39(42) = "%"

         barcode = Ctrl.Text

         'Controllo correttezza codice e calcolo check_digit
         length = Len(barcode)
         If length = 0 Then
            Return False
         End If

         'Calcolo check digit
         check_digit = 0
         For i = 1 To length
            Chr = Mid$(barcode, i, 1)
            Dim j As Short
            For j = 0 To 42
               If Val39(j) = Chr Then Exit For
            Next j
            If j = 43 Then Exit Function
            check_digit = check_digit + j
         Next i
         check_digit = check_digit Mod 43
         barcode = barcode & Val39(check_digit)
         length = length + 1

         barcode = "*" & barcode & "*"
         length = Len(barcode)

         'Generazione della stringa immagine della codifica

         Dim cod As String = ""
         For i = 1 To length
            Dim carattere As String = Mid$(barcode, i, 1)
            Dim k As Short
            For k = 1 To 44
               If Left$(code_39(k), 1) = carattere Then
                  maschera = Right$(code_39(k), 9)
               End If
            Next k
            Dim j As Short
            For j = 1 To 9
               If j Mod 2 <> 0 Then
                  Chr = "1"
               Else
                  Chr = "0"
               End If
               Select Case Mid(maschera, j, 1)
                  Case "0"
                     cod = cod & Chr
                  Case "1"
                     cod = cod & Chr & Chr & Chr
               End Select
            Next j
            cod = cod & "0"
         Next i

         'Determinazione della larghezza del modulo

         mod_width = mx / Len(cod)

         'Stampa della codifica
         Dim Clr As Color
         Dim StartPoint As Integer = sx
         For i = 1 To Len(cod)
            Select Case Mid(cod, i, 1)
               Case "0"
                  Clr = Color.White
               Case "1"
                  Clr = Color.Black
            End Select

            gr.FillRectangle(New System.Drawing.SolidBrush(Clr), StartPoint, sy, mod_width, my - 15)
            StartPoint = StartPoint + mod_width
         Next i

         strFormat.Alignment = StringAlignment.Center
         strFormat.FormatFlags = StringFormatFlags.NoWrap
         gr.DrawString(Ctrl.Text, FontForText, New System.Drawing.SolidBrush(objPicBox.ForeColor), CSng((StartPoint - mod_width) / 2), CSng(70 - FontForText.Height), strFormat)

         objPicBox.Image = sfondoImg

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
         Return False
      End Try
   End Function

#End Region

#Region "CODE 32 FARMACEUTICO - CODICE ALFANUMERICO"

   ' E' adottato dal Ministero della Sanita' italiano per la codifica dei prodotti farmaceutici.
   ' Il codice delle specialita' medicinali ad uso umano e' composto da sette cifre, che identificano il tipo di confezione 
   ' per ciascuna specialita' medicinale, precedute dalla cifra zero e seguite da un carattere di controllo. 
   ' Le nove cifre complessive vengono poi rappresentate in base 32 con sei caratteri alfanumerici, utilizzando ( con la codifica del codice 39 )
   ' le 10 cifre decimali ed i caratteri dell'alfabeto anglosassone, con l'esclusione di A, E, I, O.
   '
   ' - Codice alfanumerico 
   ' - Codice continuo 
   ' - Codice self-checking 
   ' - Lunghezza = 10

   Function CODE32(ByVal Ctrl As TextBox, ByVal objPicBox As PictureBox, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer) As Boolean
      Try
         'Declarations
         Dim check_digit As Integer
         Dim mod_width As Single
         Dim barcode As String
         Dim valore As Double
         Dim barcodenum As Double
         Dim cod As String
         Dim carattere As String
         Dim maschera As String
         Dim Chr As Char
         Dim i As Integer
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("OCR A Extended", 10, FontStyle.Regular)
         Dim sfondoImg As New Bitmap(objPicBox.Width, objPicBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
         Dim gr As Graphics = Graphics.FromImage(sfondoImg)
         gr.FillRectangle(New System.Drawing.SolidBrush(Color.White), New Rectangle(0, 0, objPicBox.Width, objPicBox.Height))

         Dim Code_32(31) As String
         Code_32(0) = "0"
         Code_32(1) = "1"
         Code_32(2) = "2"
         Code_32(3) = "3"
         Code_32(4) = "4"
         Code_32(5) = "5"
         Code_32(6) = "6"
         Code_32(7) = "7"
         Code_32(8) = "8"
         Code_32(9) = "9"
         Code_32(10) = "B"
         Code_32(11) = "C"
         Code_32(12) = "D"
         Code_32(13) = "F"
         Code_32(14) = "G"
         Code_32(15) = "H"
         Code_32(16) = "J"
         Code_32(17) = "K"
         Code_32(18) = "L"
         Code_32(19) = "M"
         Code_32(20) = "N"
         Code_32(21) = "P"
         Code_32(22) = "Q"
         Code_32(23) = "R"
         Code_32(24) = "S"
         Code_32(25) = "T"
         Code_32(26) = "U"
         Code_32(27) = "V"
         Code_32(28) = "W"
         Code_32(29) = "X"
         Code_32(30) = "Y"
         Code_32(31) = "Z"

         Dim code39(44) As String
         code39(1) = "1100100001"
         code39(2) = "2001100001"
         code39(3) = "3101100000"
         code39(4) = "4000110001"
         code39(5) = "5100110000"
         code39(6) = "6001110000"
         code39(7) = "7000100101"
         code39(8) = "8100100100"
         code39(9) = "9001100100"
         code39(10) = "0000110100"
         code39(11) = "A100001001"
         code39(12) = "B001001001"
         code39(13) = "C101001000"
         code39(14) = "D000011001"
         code39(15) = "E100011000"
         code39(16) = "F001011000"
         code39(17) = "G000001101"
         code39(18) = "H100001100"
         code39(19) = "I001001100"
         code39(20) = "J000011100"
         code39(21) = "K100000011"
         code39(22) = "L001000011"
         code39(23) = "M101000010"
         code39(24) = "N000010011"
         code39(25) = "O100010010"
         code39(26) = "P001010010"
         code39(27) = "Q000000111"
         code39(28) = "R100000110"
         code39(29) = "S001000110"
         code39(30) = "T000010110"
         code39(31) = "U110000001"
         code39(32) = "V011000001"
         code39(33) = "W111000000"
         code39(34) = "X010010001"
         code39(35) = "Y110010000"
         code39(36) = "Z011010000"
         code39(37) = "-010000101"
         code39(38) = ".110000100"
         code39(39) = " 011000100"
         code39(40) = "*010010100"
         code39(41) = "$010101000"
         code39(42) = "/010100010"
         code39(43) = "+010001010"
         code39(44) = "%000101010"

         Dim Val39(43) As String
         Val39(0) = "0"
         Val39(1) = "1"
         Val39(2) = "2"
         Val39(3) = "3"
         Val39(4) = "4"
         Val39(5) = "5"
         Val39(6) = "6"
         Val39(7) = "7"
         Val39(8) = "8"
         Val39(9) = "9"
         Val39(10) = "A"
         Val39(11) = "B"
         Val39(12) = "C"
         Val39(13) = "D"
         Val39(14) = "E"
         Val39(15) = "F"
         Val39(16) = "G"
         Val39(17) = "H"
         Val39(18) = "I"
         Val39(19) = "J"
         Val39(20) = "K"
         Val39(21) = "L"
         Val39(22) = "M"
         Val39(23) = "N"
         Val39(24) = "O"
         Val39(25) = "P"
         Val39(26) = "Q"
         Val39(27) = "R"
         Val39(28) = "S"
         Val39(29) = "T"
         Val39(30) = "U"
         Val39(31) = "V"
         Val39(32) = "W"
         Val39(33) = "X"
         Val39(34) = "Y"
         Val39(35) = "Z"
         Val39(36) = "-"
         Val39(37) = "."
         Val39(38) = " "
         Val39(39) = "$"
         Val39(40) = "/"
         Val39(41) = "+"
         Val39(42) = "%"

         barcode = Ctrl.Text

         'Controllo correttezza codice
         'If Not IsNumeric(barcode) Then Exit Sub
         If Len(barcode) = 0 Then
            Return False
         End If

         Do Until Len(barcode) >= 8
            barcode = "0" & barcode
         Loop

         barcode = Left(barcode, 8)

         'Calcolo check_digit numerico
         check_digit = 0
         For i = 2 To 8 Step 2
            valore = Val(Mid(barcode, i, 1)) * 2
            check_digit = check_digit + (valore Mod 10) + Int(valore / 10)
         Next i
         For i = 1 To 7 Step 2
            check_digit = check_digit + Val(Mid(barcode, i, 1))
         Next i
         check_digit = check_digit Mod 10
         barcode = barcode & Trim$(Str$(check_digit))

         'Conversione in base 32
         Dim cifre(6)
         barcodenum = Val(barcode)
         For i = 5 To 0 Step -1
            cifre(6 - i) = Int(barcodenum / 32 ^ i)
            barcodenum = barcodenum - cifre(6 - i) * 32 ^ i
         Next i

         barcode = ""
         For i = 1 To 6
            barcode = barcode & Code_32(cifre(i))
         Next i

         'Generazione della stringa immagine della codifica

         barcode = "*" & barcode & "*"
         Dim length As Integer = Len(barcode)
         cod = ""
         For i = 1 To length
            carattere = Mid(barcode, i, 1)
            Dim k As Integer
            For k = 1 To 44
               If Left$(code39(k), 1) = carattere Then maschera = Right(code39(k), 9)
            Next k
            Dim j As Integer
            For j = 1 To 9
               If j Mod 2 <> 0 Then
                  Chr = "1"
               Else
                  Chr = "0"
               End If
               Select Case Mid(maschera, j, 1)
                  Case "0"
                     cod = cod & Chr
                  Case "1"
                     cod = cod & Chr & Chr & Chr
               End Select
            Next j
            cod = cod & "0"
         Next i

         'Determinazione della larghezza del modulo

         mod_width = mx / Len(cod$)

         'Stampa della codifica

         Dim Clr As Color
         Dim StartPoint As Integer = sx
         For i = 1 To Len(cod)
            Select Case Mid(cod, i, 1)
               Case "0"
                  Clr = Color.White
               Case "1"
                  Clr = Color.Black
            End Select

            gr.FillRectangle(New System.Drawing.SolidBrush(Clr), StartPoint, sy, mod_width, my - 15)
            StartPoint = StartPoint + mod_width
         Next i

         strFormat.Alignment = StringAlignment.Center
         strFormat.FormatFlags = StringFormatFlags.NoWrap
         gr.DrawString(Ctrl.Text, FontForText, New System.Drawing.SolidBrush(objPicBox.ForeColor), CSng((StartPoint - mod_width) / 2), CSng(70 - FontForText.Height), strFormat)
         objPicBox.Image = sfondoImg

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
         Return False
      End Try
   End Function

#End Region

#Region "CODE 128 - CODICE ALFANUMERICO CON CARATTERI SPECIALI"

   ' Il nome Codice 128 deriva dal fatto di potere codificare 128 caratteri ASCII, oltre a quattro caratteri funzionali. 
   ' Consente inoltre di rappresentare i dati numerici in una forma compatta a doppia densita'. 
   ' Ogni carattere e' costituito da 11 moduli, distribuiti in tre barre e tre spazi (escluso carattere di Stop). 
   ' Inoltre le barre all'interno di uno stesso carattere sono sempre formate da un numero totale pari di moduli ( parita' pari ); 
   ' di conseguenza gli spazi occupano un numero dispari di moduli. 
   ' Gli elementi (barre e spazi) hanno uno spessore multiplo intero (da 1 a 4) del modulo. 
   ' I simboli in codice 128 hanno due autocontrolli che minimizzano la probabilita' di errore in lettura: 
   ' il self - checking dei caratteri (sulla parita') ed un check digit modulo 103.
   '
   ' - Codice alfanumerico con caratteri speciali 
   ' - Codice continuo 
   ' - Codice self-checking 
   ' - Lunghezza = VARIABILE

   Function CODE128(ByVal Ctrl As TextBox, ByVal objPicBox As PictureBox, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer) As Boolean
      Try
         'Declarations
         Dim check_digit As Integer, i As Integer
         Dim mod_width As Single
         Dim bar_width As Single
         Dim barcode As String
         Dim length As Integer
         Dim code As String
         Dim image As String
         Dim image2 As String
         Dim numerici As Integer
         Dim carattere As String
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("Arial", 10, FontStyle.Regular)
         Dim sfondoImg As New Bitmap(objPicBox.Width, objPicBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
         Dim gr As Graphics = Graphics.FromImage(sfondoImg)
         gr.FillRectangle(New System.Drawing.SolidBrush(Color.White), New Rectangle(0, 0, objPicBox.Width, objPicBox.Height))

         barcode = Ctrl.Text

         length = Len(barcode)
         If length = 0 Then
            Return False
         End If

         'Determinazione dei caratteri CODE

         image = ""
         For i = 1 To length
            If Mid(barcode, i, 1) >= "0" And Mid(barcode, i, 1) <= "9" Then
               image = image & "N"
            Else
               image = image & "A"
            End If
         Next i

         numerici = 0
         For i = 1 To Len(image)
            If Mid$(image, i, 1) = "N" Then
               numerici = numerici + 1
            Else
               If numerici < 4 Then
                  Dim lettereA As String
                  Dim z As Short
                  For z = 1 To numerici
                     lettereA = lettereA & "A"
                  Next
                  image = Left(image, i - 1 - numerici) & lettereA & Right(image, Len(image) - i + 1)
                  numerici = 0
               Else
                  If numerici Mod 2 <> 0 Then
                     image = Left(image, i - 2) & "A" & Right(image, Len(image) - i + 1)
                     numerici = 0
                  End If
               End If
            End If
         Next i
         If numerici < 4 Then
            Dim lettereA As String
            Dim z As Short
            For z = 1 To numerici
               lettereA = lettereA & "A"
            Next
            image = Left(image, i - 1 - numerici) & lettereA & Right(image, Len(image) - i + 1)
            numerici = 0
         Else
            If numerici Mod 2 <> 0 Then
               image = Left(image, i - 2) & "A" & Right(image, Len(image) - i + 1)
               numerici = 0
            End If
         End If

         'L'immagine è corretta: calcolo il check_digit
         Dim check As Integer
         If Left(image, 1) = "A" Then
            code = "A"
            check = 104
         Else
            code = "N"
            check = 105
         End If

         Dim peso As Integer = 1
         numerici = 0
         For i = 1 To length
            If Mid(image, i, 1) = "A" Then
               numerici = 0
               Dim valore As Integer
               Select Case Mid(barcode, i, 1)
                  Case " "
                     valore = 0
                  Case "!"
                     valore = 1
                  Case Chr(34)
                     valore = 2
                  Case "#"
                     valore = 3
                  Case "$"
                     valore = 4
                  Case "%"
                     valore = 5
                  Case "&"
                     valore = 6
                  Case "'"
                     valore = 7
                  Case "("
                     valore = 8
                  Case ")"
                     valore = 9
                  Case "*"
                     valore = 10
                  Case "+"
                     valore = 11
                  Case ","
                     valore = 12
                  Case "-"
                     valore = 13
                  Case "."
                     valore = 14
                  Case "/"
                     valore = 15
                  Case "0"
                     valore = 16
                  Case "1"
                     valore = 17
                  Case "2"
                     valore = 18
                  Case "3"
                     valore = 19
                  Case "4"
                     valore = 20
                  Case "5"
                     valore = 21
                  Case "6"
                     valore = 22
                  Case "7"
                     valore = 23
                  Case "8"
                     valore = 24
                  Case "9"
                     valore = 25
                  Case ":"
                     valore = 26
                  Case ";"
                     valore = 27
                  Case "<"
                     valore = 28
                  Case "="
                     valore = 29
                  Case ">"
                     valore = 30
                  Case "?"
                     valore = 31
                  Case "@"
                     valore = 32
                  Case "A"
                     valore = 33
                  Case "B"
                     valore = 34
                  Case "C"
                     valore = 35
                  Case "D"
                     valore = 36
                  Case "E"
                     valore = 37
                  Case "F"
                     valore = 38
                  Case "G"
                     valore = 39
                  Case "H"
                     valore = 40
                  Case "I"
                     valore = 41
                  Case "J"
                     valore = 42
                  Case "K"
                     valore = 43
                  Case "L"
                     valore = 44
                  Case "M"
                     valore = 45
                  Case "N"
                     valore = 46
                  Case "O"
                     valore = 47
                  Case "P"
                     valore = 48
                  Case "Q"
                     valore = 49
                  Case "R"
                     valore = 50
                  Case "S"
                     valore = 51
                  Case "T"
                     valore = 52
                  Case "U"
                     valore = 53
                  Case "V"
                     valore = 54
                  Case "W"
                     valore = 55
                  Case "X"
                     valore = 56
                  Case "Y"
                     valore = 57
                  Case "Z"
                     valore = 58
                  Case "["
                     valore = 59
                  Case "\"
                     valore = 60
                  Case "]"
                     valore = 61
                  Case "^"
                     valore = 62
                  Case "_"
                     valore = 63
                  Case "`"
                     valore = 64
                  Case "a"
                     valore = 65
                  Case "b"
                     valore = 66
                  Case "c"
                     valore = 67
                  Case "d"
                     valore = 68
                  Case "e"
                     valore = 69
                  Case "f"
                     valore = 70
                  Case "g"
                     valore = 71
                  Case "h"
                     valore = 72
                  Case "i"
                     valore = 73
                  Case "j"
                     valore = 74
                  Case "k"
                     valore = 75
                  Case "l"
                     valore = 76
                  Case "m"
                     valore = 77
                  Case "n"
                     valore = 78
                  Case "o"
                     valore = 79
                  Case "p"
                     valore = 80
                  Case "q"
                     valore = 81
                  Case "r"
                     valore = 82
                  Case "s"
                     valore = 83
                  Case "t"
                     valore = 84
                  Case "u"
                     valore = 85
                  Case "v"
                     valore = 86
                  Case "w"
                     valore = 87
                  Case "x"
                     valore = 88
                  Case "y"
                     valore = 89
                  Case "z"
                     valore = 90
                  Case "{"
                     valore = 91
                  Case "|"
                     valore = 92
                  Case "}"
                     valore = 93
                  Case "~"
                     valore = 94
               End Select
               If code = "N" Then
                  check = check + 100 * peso
                  peso = peso + 1
                  code = "A"
               End If
               check = check + valore * peso
               peso = peso + 1
            End If

            If Mid(image, i, 1) = "N" Then
               numerici = numerici + 1
               If numerici Mod 2 = 0 Then
                  If code = "A" Then
                     check = check + 99 * peso
                     peso = peso + 1
                     code = "N"
                  End If
                  Dim cifra As Double = Val(Mid$(barcode, i - 1, 2))
                  check = check + cifra * peso
                  peso = peso + 1
               End If
            End If
         Next i

         check = check Mod 103

         If Left(image, 1) = "A" Then
            code = "A"
            image2 = "211214"
         Else
            code = "N"
            image2 = "211232"
         End If

         numerici = 0
         For i = 1 To length
            If Mid(image, i, 1) = "A" Then
               numerici = 0
               Select Case Mid(barcode, i, 1)
                  Case " "
                     carattere = "212222"
                  Case "!"
                     carattere = "222122"
                  Case Chr(34)
                     carattere = "222221"
                  Case "#"
                     carattere = "121223"
                  Case "$"
                     carattere = "121322"
                  Case "%"
                     carattere = "131222"
                  Case "&"
                     carattere = "122213"
                  Case "'"
                     carattere = "122312"
                  Case "("
                     carattere = "132212"
                  Case ")"
                     carattere = "221213"
                  Case "*"
                     carattere = "221312"
                  Case "+"
                     carattere = "231212"
                  Case ","
                     carattere = "112232"
                  Case "-"
                     carattere = "122132"
                  Case "."
                     carattere = "122231"
                  Case "/"
                     carattere = "113222"
                  Case "0"
                     carattere = "123122"
                  Case "1"
                     carattere = "123221"
                  Case "2"
                     carattere = "223211"
                  Case "3"
                     carattere = "221132"
                  Case "4"
                     carattere = "221231"
                  Case "5"
                     carattere = "213212"
                  Case "6"
                     carattere = "223112"
                  Case "7"
                     carattere = "312131"
                  Case "8"
                     carattere = "311222"
                  Case "9"
                     carattere = "321122"
                  Case ":"
                     carattere = "321221"
                  Case ";"
                     carattere = "312212"
                  Case "<"
                     carattere = "322112"
                  Case "="
                     carattere = "322211"
                  Case ">"
                     carattere = "212123"
                  Case "?"
                     carattere = "212321"
                  Case "@"
                     carattere = "232121"
                  Case "A"
                     carattere = "111323"
                  Case "B"
                     carattere = "131123"
                  Case "C"
                     carattere = "131321"
                  Case "D"
                     carattere = "112313"
                  Case "E"
                     carattere = "132113"
                  Case "F"
                     carattere = "132311"
                  Case "G"
                     carattere = "211313"
                  Case "H"
                     carattere = "231113"
                  Case "I"
                     carattere = "231311"
                  Case "J"
                     carattere = "112133"
                  Case "K"
                     carattere = "112331"
                  Case "L"
                     carattere = "132131"
                  Case "M"
                     carattere = "113123"
                  Case "N"
                     carattere = "113321"
                  Case "O"
                     carattere = "133121"
                  Case "P"
                     carattere = "313121"
                  Case "Q"
                     carattere = "211331"
                  Case "R"
                     carattere = "231131"
                  Case "S"
                     carattere = "213113"
                  Case "T"
                     carattere = "213311"
                  Case "U"
                     carattere = "213131"
                  Case "V"
                     carattere = "311123"
                  Case "W"
                     carattere = "311321"
                  Case "X"
                     carattere = "331121"
                  Case "Y"
                     carattere = "312113"
                  Case "Z"
                     carattere = "312311"
                  Case "["
                     carattere = "332111"
                  Case "\"
                     carattere = "314111"
                  Case "]"
                     carattere = "221411"
                  Case "^"
                     carattere = "431111"
                  Case "_"
                     carattere = "111224"
                  Case "`"
                     carattere = "111422"
                  Case "a"
                     carattere = "121124"
                  Case "b"
                     carattere = "121421"
                  Case "c"
                     carattere = "141122"
                  Case "d"
                     carattere = "141221"
                  Case "e"
                     carattere = "112214"
                  Case "f"
                     carattere = "112412"
                  Case "g"
                     carattere = "122114"
                  Case "h"
                     carattere = "122411"
                  Case "i"
                     carattere = "142112"
                  Case "j"
                     carattere = "142211"
                  Case "k"
                     carattere = "241211"
                  Case "l"
                     carattere = "221114"
                  Case "m"
                     carattere = "413111"
                  Case "n"
                     carattere = "241112"
                  Case "o"
                     carattere = "134111"
                  Case "p"
                     carattere = "111242"
                  Case "q"
                     carattere = "121142"
                  Case "r"
                     carattere = "121241"
                  Case "s"
                     carattere = "114212"
                  Case "t"
                     carattere = "124112"
                  Case "u"
                     carattere = "124211"
                  Case "v"
                     carattere = "411212"
                  Case "w"
                     carattere = "421112"
                  Case "x"
                     carattere = "421211"
                  Case "y"
                     carattere = "212141"
                  Case "z"
                     carattere = "214121"
                  Case "{"
                     carattere = "412121"
                  Case "|"
                     carattere = "111143"
                  Case "}"
                     carattere = "111341"
                  Case "~"
                     carattere = "131141"
               End Select
               If code = "N" Then
                  image2 = image2 & "114131"
                  code = "A"
               End If
               image2 = image2 & carattere
            End If

            If Mid(image, i, 1) = "N" Then
               numerici = numerici + 1
               If numerici Mod 2 = 0 Then
                  Dim cifra As Double = Val(Mid(barcode, i - 1, 2))
                  Select Case cifra
                     Case 0
                        carattere = "212222"
                     Case 1
                        carattere = "222122"
                     Case 2
                        carattere = "222221"
                     Case 3
                        carattere = "121223"
                     Case 4
                        carattere = "121322"
                     Case 5
                        carattere = "131222"
                     Case 6
                        carattere = "122213"
                     Case 7
                        carattere = "122312"
                     Case 8
                        carattere = "132212"
                     Case 9
                        carattere = "221213"
                     Case 10
                        carattere = "221312"
                     Case 11
                        carattere = "231212"
                     Case 12
                        carattere = "112232"
                     Case 13
                        carattere = "122132"
                     Case 14
                        carattere = "122231"
                     Case 15
                        carattere = "113222"
                     Case 16
                        carattere = "123122"
                     Case 17
                        carattere = "123221"
                     Case 18
                        carattere = "223211"
                     Case 19
                        carattere = "221132"
                     Case 20
                        carattere = "221231"
                     Case 21
                        carattere = "213212"
                     Case 22
                        carattere = "323112"
                     Case 23
                        carattere = "312131"
                     Case 24
                        carattere = "311222"
                     Case 25
                        carattere = "321122"
                     Case 26
                        carattere = "321221"
                     Case 27
                        carattere = "312212"
                     Case 28
                        carattere = "322112"
                     Case 29
                        carattere = "322211"
                     Case 30
                        carattere = "212123"
                     Case 31
                        carattere = "212321"
                     Case 32
                        carattere = "232121"
                     Case 33
                        carattere = "111323"
                     Case 34
                        carattere = "131123"
                     Case 35
                        carattere = "131321"
                     Case 36
                        carattere = "112313"
                     Case 37
                        carattere = "132113"
                     Case 38
                        carattere = "132311"
                     Case 39
                        carattere = "211313"
                     Case 40
                        carattere = "231113"
                     Case 41
                        carattere = "231311"
                     Case 42
                        carattere = "112133"
                     Case 43
                        carattere = "112331"
                     Case 44
                        carattere = "132131"
                     Case 45
                        carattere = "113123"
                     Case 46
                        carattere = "113321"
                     Case 47
                        carattere = "133121"
                     Case 48
                        carattere = "313121"
                     Case 49
                        carattere = "211331"
                     Case 50
                        carattere = "231131"
                     Case 51
                        carattere = "213113"
                     Case 52
                        carattere = "213311"
                     Case 53
                        carattere = "213131"
                     Case 54
                        carattere = "311123"
                     Case 55
                        carattere = "311321"
                     Case 56
                        carattere = "331121"
                     Case 57
                        carattere = "312113"
                     Case 58
                        carattere = "312311"
                     Case 59
                        carattere = "332111"
                     Case 60
                        carattere = "314111"
                     Case 61
                        carattere = "221411"
                     Case 62
                        carattere = "431111"
                     Case 63
                        carattere = "111224"
                     Case 64
                        carattere = "111422"
                     Case 65
                        carattere = "121124"
                     Case 66
                        carattere = "121421"
                     Case 67
                        carattere = "141122"
                     Case 68
                        carattere = "141221"
                     Case 69
                        carattere = "112214"
                     Case 70
                        carattere = "112412"
                     Case 71
                        carattere = "122114"
                     Case 72
                        carattere = "122411"
                     Case 73
                        carattere = "142112"
                     Case 74
                        carattere = "142211"
                     Case 75
                        carattere = "241211"
                     Case 76
                        carattere = "221114"
                     Case 77
                        carattere = "413111"
                     Case 78
                        carattere = "241112"
                     Case 79
                        carattere = "134111"
                     Case 80
                        carattere = "111242"
                     Case 81
                        carattere = "121142"
                     Case 82
                        carattere = "121241"
                     Case 83
                        carattere = "114212"
                     Case 84
                        carattere = "124112"
                     Case 85
                        carattere = "124211"
                     Case 86
                        carattere = "411212"
                     Case 87
                        carattere = "421112"
                     Case 88
                        carattere = "421211"
                     Case 89
                        carattere = "212141"
                     Case 90
                        carattere = "214121"
                     Case 91
                        carattere = "412121"
                     Case 92
                        carattere = "111143"
                     Case 93
                        carattere = "111341"
                     Case 94
                        carattere = "131141"
                     Case 95
                        carattere = "114113"
                     Case 96
                        carattere = "114311"
                     Case 97
                        carattere = "411113"
                     Case 98
                        carattere = "411311"
                     Case 99
                        carattere = "113141"
                  End Select
                  If code = "A" Then
                     image2 = image2 & "113141"
                     code = "N"
                  End If
                  image2 = image2 & carattere
               End If
            End If
         Next i

         'inserisco il check digit e lo stop
         Select Case Val(check)
            Case 0
               carattere = "212222"
            Case 1
               carattere = "222122"
            Case 2
               carattere = "222221"
            Case 3
               carattere = "121223"
            Case 4
               carattere = "121322"
            Case 5
               carattere = "131222"
            Case 6
               carattere = "122213"
            Case 7
               carattere = "122312"
            Case 8
               carattere = "132212"
            Case 9
               carattere = "221213"
            Case 10
               carattere = "221312"
            Case 11
               carattere = "231212"
            Case 12
               carattere = "112232"
            Case 13
               carattere = "122132"
            Case 14
               carattere = "122231"
            Case 15
               carattere = "113222"
            Case 16
               carattere = "123122"
            Case 17
               carattere = "123221"
            Case 18
               carattere = "223211"
            Case 19
               carattere = "221132"
            Case 20
               carattere = "221231"
            Case 21
               carattere = "213212"
            Case 22
               carattere = "323112"
            Case 23
               carattere = "312131"
            Case 24
               carattere = "311222"
            Case 25
               carattere = "321122"
            Case 26
               carattere = "321221"
            Case 27
               carattere = "312212"
            Case 28
               carattere = "322112"
            Case 29
               carattere = "322211"
            Case 30
               carattere = "212123"
            Case 31
               carattere = "212321"
            Case 32
               carattere = "232121"
            Case 33
               carattere = "111323"
            Case 34
               carattere = "131123"
            Case 35
               carattere = "131321"
            Case 36
               carattere = "112313"
            Case 37
               carattere = "132113"
            Case 38
               carattere = "132311"
            Case 39
               carattere = "211313"
            Case 40
               carattere = "231113"
            Case 41
               carattere = "231311"
            Case 42
               carattere = "112133"
            Case 43
               carattere = "112331"
            Case 44
               carattere = "132131"
            Case 45
               carattere = "113123"
            Case 46
               carattere = "113321"
            Case 47
               carattere = "133121"
            Case 48
               carattere = "313121"
            Case 49
               carattere = "211331"
            Case 50
               carattere = "231131"
            Case 51
               carattere = "213113"
            Case 52
               carattere = "213311"
            Case 53
               carattere = "213131"
            Case 54
               carattere = "311123"
            Case 55
               carattere = "311321"
            Case 56
               carattere = "331121"
            Case 57
               carattere = "312113"
            Case 58
               carattere = "312311"
            Case 59
               carattere = "332111"
            Case 60
               carattere = "314111"
            Case 61
               carattere = "221411"
            Case 62
               carattere = "431111"
            Case 63
               carattere = "111224"
            Case 64
               carattere = "111422"
            Case 65
               carattere = "121124"
            Case 66
               carattere = "121421"
            Case 67
               carattere = "141122"
            Case 68
               carattere = "141221"
            Case 69
               carattere = "112214"
            Case 70
               carattere = "112412"
            Case 71
               carattere = "122114"
            Case 72
               carattere = "122411"
            Case 73
               carattere = "142112"
            Case 74
               carattere = "142211"
            Case 75
               carattere = "241211"
            Case 76
               carattere = "221114"
            Case 77
               carattere = "413111"
            Case 78
               carattere = "241112"
            Case 79
               carattere = "134111"
            Case 80
               carattere = "111242"
            Case 81
               carattere = "121142"
            Case 82
               carattere = "121241"
            Case 83
               carattere = "114212"
            Case 84
               carattere = "124112"
            Case 85
               carattere = "124211"
            Case 86
               carattere = "411212"
            Case 87
               carattere = "421112"
            Case 88
               carattere = "421211"
            Case 89
               carattere = "212141"
            Case 90
               carattere = "214121"
            Case 91
               carattere = "412121"
            Case 92
               carattere = "111143"
            Case 93
               carattere = "111341"
            Case 94
               carattere = "131141"
            Case 95
               carattere = "114113"
            Case 96
               carattere = "114311"
            Case 97
               carattere = "411113"
            Case 98
               carattere = "411311"
            Case 99
               carattere = "113141"
            Case 100
               carattere = "114131"
            Case 101
               carattere = "311141"
            Case 102
               carattere = "411131"
         End Select

         image2 = image2 & carattere & "2331112"

         'Determinazione della larghezza del modulo

         mod_width = mx / (Int(Len(image2) / 6) * 11 + 2)

         'Stampa della codifica

         Dim Clr As Color
         Dim StartPoint As Integer = sx
         For i = 1 To Len(image2)
            bar_width = mod_width * Val(Mid$(image2, i, 1))

            Select Case i Mod 2
               Case 0
                  Clr = Color.White
               Case "1"
                  Clr = Color.Black
            End Select

            gr.FillRectangle(New System.Drawing.SolidBrush(Clr), StartPoint, sy, bar_width, my - 15)
            StartPoint = StartPoint + bar_width
         Next i

         strFormat.Alignment = StringAlignment.Center
         strFormat.FormatFlags = StringFormatFlags.NoWrap
         gr.DrawString(Ctrl.Text, FontForText, New System.Drawing.SolidBrush(objPicBox.ForeColor), CSng((StartPoint - bar_width) / 2), CSng(70 - FontForText.Height), strFormat)
         objPicBox.Image = sfondoImg

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
         Return False
      End Try
   End Function

#End Region

#Region "BCD Matrix - CODICE NUMERICO "

   ' Il codice BCD Matrix e' una variante del codice 2/5 3 barre matrix, in cui la codifica delle cifre decimali non prevede il bit di parita'. 
   ' Ogni cifra e' quindi codificata con quattro elementi, due barre e due spazi. Gli elementi, barre e spazi, possono essere sia larghi che stretti. 
   ' Non e' self-checking, poiche' le codifiche delle cifre non hanno lo stesso numero di elementi stretti e larghi. 
   ' Ogni carattere termina con uno spazio. Il rapporto di stampa standard e' 3:1, ma puo' varaiare da 2:1 a 3:1.
   ' - Codice numerico 
   ' - Codice continuo 
   ' - Lunghezza = VARIABILE

   Function BCDMatrix(ByVal Ctrl As TextBox, ByVal objPicBox As PictureBox, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer) As Boolean
      Try
         Dim check_digit As Integer
         Dim mod_width As Single
         Dim barcode As String
         Dim length As Integer
         Dim carattere As String
         Dim cod As String
         Dim i As Integer
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("Arial", 10, FontStyle.Regular)
         Dim sfondoImg As New Bitmap(objPicBox.Width, objPicBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
         Dim gr As Graphics = Graphics.FromImage(sfondoImg)
         gr.FillRectangle(New System.Drawing.SolidBrush(Color.White), New Rectangle(0, 0, objPicBox.Width, objPicBox.Height))

         Dim BCD_Matrix(9) As String
         BCD_Matrix(0) = "0011"
         BCD_Matrix(1) = "1000"
         BCD_Matrix(2) = "0100"
         BCD_Matrix(3) = "1100"
         BCD_Matrix(4) = "0010"
         BCD_Matrix(5) = "1010"
         BCD_Matrix(6) = "0110"
         BCD_Matrix(7) = "0001"
         BCD_Matrix(8) = "1001"
         BCD_Matrix(9) = "0101"

         barcode = Ctrl.Text

         'Controllo correttezza codice e calcolo check_digit
         If Not IsNumeric(barcode) Then
            Return False
         End If

         length = Len(barcode)
         If length = 0 Then
            Return False
         End If

         'Calcolo check digit
         check_digit = 0
         For i = length To 1 Step -2
            carattere = Mid(barcode, i, 1)
            If carattere < "0" Or carattere > "9" Then Exit Function
            check_digit = check_digit + 3 * Val(carattere)
         Next i
         For i = length - 1 To 1 Step -2
            carattere = Mid(barcode, i, 1)
            If carattere < "0" Or carattere > "9" Then Exit Function
            check_digit = check_digit + Val(carattere)
         Next i
         check_digit = 10 - check_digit Mod 10
         If check_digit = 10 Then check_digit = 0
         barcode = barcode & Trim(Str(check_digit))
         length = length + 1

         'Generazione della stringa immagine della codifica
         Dim nuovoCarattere As String
         Dim Coppie As Integer = length / 2
         cod = "00000000001011100010"
         For i = 1 To length
            nuovoCarattere = Mid(barcode, i, 1)
            Dim j As Integer
            For j = 1 To 4
               If j Mod 2 <> 0 Then
                  carattere = "1"
               Else
                  carattere = "0"
               End If
               Select Case Mid(BCD_Matrix(Val(nuovoCarattere)), j, 1)
                  Case "0"
                     cod = cod$ & carattere
                  Case "1"
                     cod = cod & carattere & carattere & carattere
               End Select
            Next j
         Next i
         cod = cod & "1011100010000000000"

         'Determinazione della larghezza del modulo

         mod_width = mx / Len(cod$)

         'Stampa della codifica

         Dim Clr As Color
         Dim StartPoint As Integer = sx
         For i = 1 To Len(cod$)
            Select Case Mid$(cod$, i, 1)
               Case "0"
                  Clr = Color.White
               Case "1"
                  Clr = Color.Black
            End Select

            gr.FillRectangle(New System.Drawing.SolidBrush(Clr), StartPoint, sy, mod_width, my - 15)
            StartPoint = StartPoint + mod_width
         Next i

         strFormat.Alignment = StringAlignment.Center
         strFormat.FormatFlags = StringFormatFlags.NoWrap
         gr.DrawString(Ctrl.Text, FontForText, New System.Drawing.SolidBrush(objPicBox.ForeColor), CSng((StartPoint - mod_width) / 2), CSng(70 - FontForText.Height), strFormat)
         objPicBox.Image = sfondoImg

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
         Return False
      End Try
   End Function

#End Region

#Region "2 DI 5 Interleaved (ITF) - CODICE NUMERICO"

   ' E' stato sviluppato nel 1972 dalla Computer Identics, e risponde alle norme USA ANSI MH 10.8-1983. 
   ' Un'altra denominazione di questo codice e' "ITF" ( Iterleaved Two of Five ). E' un codice numerico continuo. 
   ' Ha la stessa codifica del codice 2/5 a 5 barre, con la notevole differenza che le cifre sono rappresentate alternativamente da barre e spazi.
   ' - Codice numerico 
   ' - Codice continuo 
   ' - Codice self-checking 
   ' - Lunghezza = VARIABILE

   Function INTERLEAVED(ByVal Ctrl As TextBox, ByVal objPicBox As PictureBox, ByVal sx As Integer, ByVal sy As Integer, ByVal mx As Integer, ByVal my As Integer) As Boolean
      Try
         Dim check_digit As Integer
         Dim mod_width As Single
         Dim barcode As String
         Dim length As Integer
         Dim carattere As Char
         Dim cod As String
         Dim i As Integer
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("Arial", 10, FontStyle.Regular)
         Dim sfondoImg As New Bitmap(objPicBox.Width, objPicBox.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
         Dim gr As Graphics = Graphics.FromImage(sfondoImg)
         gr.FillRectangle(New System.Drawing.SolidBrush(Color.White), New Rectangle(0, 0, objPicBox.Width, objPicBox.Height))

         Dim ToF_Interleaved(9) As String
         ToF_Interleaved(0) = "00110"
         ToF_Interleaved(1) = "10001"
         ToF_Interleaved(2) = "01001"
         ToF_Interleaved(3) = "11000"
         ToF_Interleaved(4) = "00101"
         ToF_Interleaved(5) = "10100"
         ToF_Interleaved(6) = "01100"
         ToF_Interleaved(7) = "00011"
         ToF_Interleaved(8) = "10010"
         ToF_Interleaved(9) = "01010"

         barcode = Ctrl.Text

         'Controllo correttezza codice e calcolo check_digit
         If Not IsNumeric(barcode) Then
            Return False
         End If
         length = Len(barcode)

         If length = 0 Then
            Return False
         End If

         If length Mod 2 = 0 Then
            barcode = Left(barcode, length - 1)
            length = length - 1
         End If

         'Calcolo check digit
         check_digit = 0
         For i = length To 1 Step -2
            carattere = Mid(barcode, i, 1)
            If carattere < "0" Or carattere > "9" Then Exit Function
            check_digit = check_digit + 3 * Val(carattere)
         Next i
         For i = length - 1 To 2 Step -2
            carattere = Mid(barcode, i, 1)
            If carattere < "0" Or carattere > "9" Then Exit Function
            check_digit = check_digit + Val(carattere)
         Next i
         check_digit = 10 - check_digit Mod 10
         If check_digit = 10 Then check_digit = 0
         barcode = barcode & Trim(Str(check_digit))
         length = length + 1

         'Generazione della stringa immagine della codifica

         Dim Coppie As Integer = length / 2
         cod = "00000000001010"
         For i = 1 To Coppie
            Dim Sinistra As String = Mid(barcode, 2 * (i - 1) + 1, 1)
            Dim Destra As String = Mid(barcode, 2 * i, 1)
            Dim j As Integer
            For j = 1 To 5
               Select Case Mid(ToF_Interleaved(Val(Sinistra)), j, 1)
                  Case "0"
                     cod = cod & "1"
                  Case "1"
                     cod = cod & "111"
               End Select
               Select Case Mid(ToF_Interleaved(Val(Destra)), j, 1)
                  Case "0"
                     cod = cod & "0"
                  Case "1"
                     cod = cod & "000"
               End Select
            Next j
         Next i
         cod = cod & "111010000000000"

         'Determinazione della larghezza del modulo

         mod_width = mx / Len(cod$)

         'Stampa della codifica

         Dim Clr As Color
         Dim StartPoint As Integer = sx
         For i = 1 To Len(cod)
            Select Case Mid(cod, i, 1)
               Case "0"
                  Clr = Color.White
               Case "1"
                  Clr = Color.Black
            End Select

            gr.FillRectangle(New System.Drawing.SolidBrush(Clr), StartPoint, sy, mod_width, my - 15)
            StartPoint = StartPoint + mod_width
         Next i

         strFormat.Alignment = StringAlignment.Center
         strFormat.FormatFlags = StringFormatFlags.NoWrap
         gr.DrawString(Ctrl.Text, FontForText, New System.Drawing.SolidBrush(objPicBox.ForeColor), CSng((StartPoint - mod_width) / 2), CSng(70 - FontForText.Height), strFormat)
         objPicBox.Image = sfondoImg

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
         Return False
      End Try
   End Function

#End Region

End Class
