Public Class CambiaCameriere
   Private selCameriere As String
   Public Sub New(ByVal cameriere As String)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      selCameriere = cameriere

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
   End Sub

   Public Sub CaricaListaCamerieri(ByVal cmb As Elegant.Ui.ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Nome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Nome"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CambiaCameriere_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      CaricaListaCamerieri(eui_cmbCameriere, "Camerieri")
      eui_cmbCameriere.SelectedItem = selCameriere
   End Sub

   Private Sub Eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub Eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Me.DialogResult = DialogResult.OK
      Me.Hide()
   End Sub
End Class