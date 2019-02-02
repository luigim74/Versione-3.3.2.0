Public Class ConvalidaKeyPress
   Private err As New Varie.Errore

   Public Function DigitaSoloNumeri(ByVal carattere As String) As Boolean
      ' Accetta solo numeri o punteggiatura
      Try
         If Not (Char.IsDigit(carattere)) Then
            If Not Char.IsControl(carattere) Then
               Return True
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function DigitaSoloNumeriPuntegg(ByVal carattere As String) As Boolean
      ' Accetta solo numeri o punteggiatura
      Try
         If Not (Char.IsDigit(carattere)) Then
            If Not Char.IsPunctuation(carattere) Then
               If Not Char.IsControl(carattere) Then
                  Return True
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function DigitaSoloDate(ByVal carattere As String) As Boolean
      ' Accetta solo numeri o /
      Try
         If Not (Char.IsDigit(carattere)) Then
            If carattere <> "/" Then
               If Not Char.IsControl(carattere) Then
                  Return True
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function DigitaSoloOre(ByVal carattere As String) As Boolean
      ' Accetta solo numeri o .
      Try
         If Not (Char.IsDigit(carattere)) Then
            If carattere <> "." Then
               If Not Char.IsControl(carattere) Then
                  Return True
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Function KeyReturn(ByVal carattere As String) As Boolean
      ' Verifica se è stato premuto il tasto INVIO.
      Try
         If Asc(carattere) = Keys.Return Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function
End Class
