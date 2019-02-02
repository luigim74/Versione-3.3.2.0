Imports System.Globalization

Public Class ClsFormatta
   Private err As New Varie.Errore
   'Dim nfi As NumberFormatInfo = DirectCast(NumberFormatInfo.CurrentInfo.Clone, NumberFormatInfo)

   Public Function FormattaQuantità(ByVal Numero As Object, ByVal numDecimali As Integer) As String
      Try
         Dim numFormattato As String

         Select Case numDecimali
            Case 1
               numFormattato = String.Format("{0:##,##0.0}", Numero)

            Case 2
               numFormattato = String.Format("{0:##,##0.00}", Numero)

            Case 3
               numFormattato = String.Format("{0:##,##0.000}", Numero)

            Case 4
               numFormattato = String.Format("{0:##,##0.0000}", Numero)

         End Select

         Return numFormattato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      End Try
   End Function

   Public Function FormattaEuro(ByVal Numero As Decimal) As String
      Try
         Return String.Format("{0:##,##0.00}", Numero)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO
      End Try
   End Function

   Public Function FormattaEuro(ByVal Numero As Double) As String
      Try
         Return String.Format("{0:##,##0.00}", Numero)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO
      End Try
   End Function

   Public Function FormattaEuro(ByVal Numero As String) As String
      Try
         Return String.Format("{0:##,##0.00}", Numero)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO
      End Try
   End Function


   Public Function FormattaNumero(ByVal Numero As Integer) As String
      Try
         Return String.Format("{0:##,##0}", Numero)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaNumeroDouble(ByVal Numero As Double) As String
      Try
         Return String.Format("{0:##,##0.00}", Numero)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaNumeroDouble2(ByVal Numero As Double) As String
      Try
         Return String.Format("{0:##,##0.0}", Numero)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaAliquotaIva(ByVal Numero As String) As String
      Try
         Return String.Format("{0:##,##0.00}", Numero)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO
      End Try
   End Function

   Public Function FormattaAliquotaIva(ByVal val As Object) As String
      Try
         Return String.Format("{0:##,##0}", val)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaAliquotaIva(ByVal val As Decimal) As String
      Try
         Return String.Format("{0:##,##0.00}", val)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaImponibileIva(ByVal numero As Double) As Decimal
      Try

         Dim valDecimal As Decimal = Convert.ToDecimal(numero)
         Dim valString As String = String.Format("{0:##,##0.00}", valDecimal)

         Return Convert.ToDecimal(valString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0
      End Try
   End Function

   Public Function FormattaData(ByVal val As Date) As String
      Try
         Dim Giorno As String
         Dim Mese As String
         Dim Anno As String

         Giorno = val.Day
         Mese = val.Month
         Anno = val.Year

         Return Mese & "/" & Giorno & "/" & Anno

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Function

   Public Function FormattaData_IT(ByVal val As Date) As String
      Try
         Dim Giorno As String
         Dim Mese As String
         Dim Anno As String
         Dim data As Date

         Giorno = val.Day
         Mese = val.Month
         Anno = val.Year
         data = Convert.ToDateTime(Giorno & "/" & Mese & "/" & Anno)

         Return data.ToShortDateString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function FormattaNumeroMese(ByVal numeroMese As Integer) As String
      Try
         Select Case numeroMese
            Case 1
               Return "Gennaio"
            Case 2
               Return "Febbraio"
            Case 3
               Return "Marzo"
            Case 4
               Return "Aprile"
            Case 5
               Return "Maggio"
            Case 6
               Return "Giugno"
            Case 7
               Return "Luglio"
            Case 8
               Return "Agosto"
            Case 9
               Return "Settembre"
            Case 10
               Return "Ottobre"
            Case 11
               Return "Novembre"
            Case 12
               Return "Dicembre"
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try
   End Function

   Public Function FormattaNomeMese(ByVal nomeMese As String) As Integer
      Try
         Select Case nomeMese.ToUpper
            Case "GENNAIO"
               Return 1
            Case "FEBBRAIO"
               Return 2
            Case "MARZO"
               Return 3
            Case "APRILE"
               Return 4
            Case "MAGGIO"
               Return 5
            Case "GIUGNO"
               Return 6
            Case "LUGLIO"
               Return 7
            Case "AGOSTO"
               Return 8
            Case "SETTEMBRE"
               Return 9
            Case "OTTOBRE"
               Return 10
            Case "NOVEMBRE"
               Return 11
            Case "DICEMBRE"
               Return 12
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0
      End Try
   End Function


   Public Function FormattaNumeroDocumento(ByVal numeroDoc As Integer, ByVal numZeri As Integer) As String
      Try
         Dim numDocZeri As String
         Dim lenghNumDoc As Integer = numeroDoc.ToString.Length
         Dim numZeriRimanenti As Integer = numZeri - lenghNumDoc

         Dim i As Integer
         For i = 1 To numZeriRimanenti
            numDocZeri = numDocZeri & "0"
         Next

         Return numDocZeri & numeroDoc.ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function


End Class
