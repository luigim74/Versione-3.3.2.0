Public Class ModificaSpettanzaPOS
   Dim CConvalida As New ConvalidaKeyPress
   Dim nomeCameriere As String
   Dim valSpettanza As String

   Public Sub New(ByVal cameriere As String, ByVal spettanza As String)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
      nomeCameriere = cameriere
      valSpettanza = spettanza

   End Sub

   Private Sub ModificaSpettanzaPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         Me.Text = "Modifica spettanza - (" & nomeCameriere & ")"

         eui_txtSpettanza.Text = valSpettanza

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      If IsNumeric(eui_txtSpettanza.Text) = True Then
         Me.Tag = eui_txtSpettanza.Text
      Else
         Me.Tag = VALORE_ZERO
      End If

      Me.DialogResult = DialogResult.OK
      Me.Hide()
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub eui_txtSpettanza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtSpettanza.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)

   End Sub
End Class