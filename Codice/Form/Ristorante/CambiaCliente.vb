Public Class CambiaCliente
   Private CFormatta As New ClsFormatta
   Private idCliente As String
   Private selCliente As String
   Private idTavolo As Integer

   Public Sub New(ByVal id As String, ByVal cliente As String, ByVal tavolo As Integer)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      idCliente = id
      selCliente = cliente
      idTavolo = tavolo

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
   End Sub

   Public Sub CaricaListaClienti(ByVal cmb As Elegant.Ui.ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Nome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Nome") & " " & dr.Item("Cognome"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function LeggiIdCliente(ByVal nome As String, ByVal cognome As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Clienti  WHERE Nome = '" & nome & "' AND Cognome = '" & cognome & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim idCameriere As String

         Do While dr.Read
            idCameriere = dr.Item("Id").ToString
         Loop

         Return idCameriere

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub CambiaClienti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lblNomeTavolo.Text = "CLIENTI AL TAVOLO: " & g_frmVCTavoli.lblTavolo.Text

      CaricaListaClienti(eui_cmbCliente, "Clienti")
      eui_cmbCliente.SelectedItem = selCliente
      Me.Tag = idCliente

      Dim Clienti As New ClientiTavolo
      Dim nomeCliente As String() = eui_cmbCliente.SelectedItem.ToString.Split(" ")

      If Clienti.LeggiDati(lvwClienti, "ClientiTavolo", idTavolo) = False Then
         ' Nome cliente.
         lvwClienti.Items.Add(selCliente)
         ' IdTavolo.
         lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(idTavolo)
         ' IdCliente.
         lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(LeggiIdCliente(nomeCliente(0), nomeCliente(1)))

         ' Stabilisce il gruppo di appartenenza.
         lvwClienti.Items(lvwClienti.Items.Count - 1).Group = lvwClienti.Groups.Item(CAMERIERE_PREDEFINITO)
      End If

   End Sub

   Private Sub Eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub Eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         Dim Clienti As New ClientiTavolo

         If Clienti.EliminaDati("ClientiTavolo", idTavolo) = True Then

            Dim i As Integer
            For i = 0 To lvwClienti.Items.Count - 1
               Clienti.Nome = lvwClienti.Items(i).Text
               Clienti.IdTavolo = lvwClienti.Items(i).SubItems(1).Text
               Clienti.IdCliente = lvwClienti.Items(i).SubItems(2).Text
               Clienti.Gruppo = lvwClienti.Items(i).Group.ToString

               Clienti.InserisciDati("ClientiTavolo")
            Next

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Me.DialogResult = DialogResult.OK
         Me.Hide()

      End Try
   End Sub

   Private Sub eui_cmdInserisci_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisci.Click
      Try
         Dim i As Integer
         For i = 0 To lvwClienti.Items.Count - 1
            If lvwClienti.Items(i).Text = eui_cmbCliente.Text Then
               MessageBox.Show("Il cliente selezionato è già stato inserito.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         Next

         Dim nomeCliente As String() = eui_cmbCliente.SelectedItem.ToString.Split(" ")

         ' Nome cliente.
         lvwClienti.Items.Add(eui_cmbCliente.SelectedItem).ForeColor = Color.Red
         ' IdTavolo.
         lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(idTavolo)
         ' IdCliente.
         lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(LeggiIdCliente(nomeCliente(0), nomeCliente(1)))

         ' Stabilisce il gruppo di appartenenza.
         lvwClienti.Items(lvwClienti.Items.Count - 1).Group = lvwClienti.Groups.Item(CAMERIERE_ALTRI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdElimina_Click(sender As Object, e As EventArgs) Handles eui_cmdElimina.Click
      Try
         lvwClienti.Focus()

         If lvwClienti.Items(lvwClienti.FocusedItem.Index).Group.Name = CAMERIERE_PREDEFINITO Then
            MessageBox.Show("Il cliente predefinito non può essere eliminato!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            lvwClienti.Items.Remove(lvwClienti.FocusedItem)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdPredefinito_Click(sender As Object, e As EventArgs) Handles eui_cmdPredefinito.Click
      Try
         lvwClienti.Focus()

         Dim i As Integer
         For i = 0 To lvwClienti.Items.Count - 1
            lvwClienti.Items(i).Group = lvwClienti.Groups.Item(CAMERIERE_ALTRI)
         Next

         lvwClienti.Items(lvwClienti.FocusedItem.Index).Group = lvwClienti.Groups.Item(CAMERIERE_PREDEFINITO)

         'Me.Tag = lvwClienti.FocusedItem.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class