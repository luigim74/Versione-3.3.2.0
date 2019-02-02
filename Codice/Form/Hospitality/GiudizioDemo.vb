Public Class frmGiudizioDemo

   Private Sub frmGiudizioDemo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta il titolo della finestra in base al prodotto installato.
         Me.Text = NOME_PRODOTTO

         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdEsci_Click(sender As System.Object, e As System.EventArgs) Handles cmdEsci.Click
      Me.Close()
   End Sub

   Private Sub cmdInvia_Click(sender As System.Object, e As System.EventArgs) Handles cmdInvia.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Invia tramite e-mail i dati di giudizio del software.
         g_frmMain.InviaDatiGiudizio(nudVotoSemplicità.Value, nudVotoUtilità.Value, nudVotoGrafica.Value, txtCommento.Text)

         ' Salva un valore nel file di configurazione per sapere se chiedere ancora un giudizio o no.
         g_frmMain.SalvaGiudizioInviatoConfig("Sì")

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class