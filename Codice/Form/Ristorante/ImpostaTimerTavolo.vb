Public Class ImpostaTimerTavolo
   Dim nomeTavolo As String
   Dim valMinutiStandard As Integer
   Private CConvalida As New ConvalidaKeyPress

   Public Sub New(ByVal tavolo As String, ByVal minutiStandard As Integer)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      valMinutiStandard = minutiStandard
      nomeTavolo = tavolo

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub Eui_cmdMeno_Click(sender As Object, e As EventArgs) Handles eui_cmdMeno.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim numMinuti As Integer

         If IsNumeric(eui_cmbMinuti.Text) = True And eui_cmbMinuti.Text <> "0" Then
            numMinuti = Convert.ToInt32(eui_cmbMinuti.Text)
         Else
            eui_cmbMinuti.Text = "1"
            Exit Sub
         End If

         Dim valTemp As Integer = numMinuti
         valTemp = numMinuti - 1

         If valTemp = 0 Then
            eui_cmbMinuti.Text = numMinuti.ToString
         Else
            eui_cmbMinuti.Text = valTemp.ToString
         End If

         eui_cmbMinuti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub Eui_cmdPiù_Click(sender As Object, e As EventArgs) Handles eui_cmdPiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim numMinuti As Integer

         If IsNumeric(eui_cmbMinuti.Text) = True Then
            numMinuti = Convert.ToInt32(eui_cmbMinuti.Text)
         Else
            eui_cmbMinuti.Text = "1"
            Exit Sub
         End If

         Dim valTemp As Integer = numMinuti
         valTemp = numMinuti + 1

         If valTemp = 0 Then
            eui_cmbMinuti.Text = numMinuti.ToString
         Else
            eui_cmbMinuti.Text = valTemp.ToString
         End If

         eui_cmbMinuti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub Eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.DialogResult = DialogResult.OK
         Me.Tag = eui_cmbMinuti.Text
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.DialogResult = DialogResult.Cancel
         Me.Tag = MINUTI_TAVOLO
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub ImpostaTimerTavolo_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         ' Imposta il titolo con il nome del tavolo selezionato.
         Me.Text = "Imposta Timer - " & nomeTavolo

         ' Imposta i minuti standard impostati nella finestra Opzioni.
         eui_cmbMinuti.Text = valMinutiStandard

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmbMinuti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_cmbMinuti.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub
End Class