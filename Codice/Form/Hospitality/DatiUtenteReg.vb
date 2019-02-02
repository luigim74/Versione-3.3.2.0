Public Class DatiUtenteReg

   Private Sub DatiUtenteReg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Try
         txtDati.Text = Me.Tag.ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdCopia_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdCopia.Click
      Try
         Clipboard.SetData(DataFormats.StringFormat, txtDati.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdChiudi_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdChiudi.Click
      Me.Close()
   End Sub
End Class