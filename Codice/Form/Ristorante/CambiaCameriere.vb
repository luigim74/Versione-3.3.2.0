Imports Hospitality_Solution.PiattiDataSetTableAdapters

Public Class CambiaCameriere
   Private CFormatta As New ClsFormatta
   Private selCameriere As String
   Private idTavolo As Integer

   Public Sub New(ByVal cameriere As String, ByVal tavolo As Integer)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      selCameriere = cameriere
      idTavolo = tavolo

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

   Public Function LeggiIdCameriere(ByVal nome As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Camerieri  WHERE Nome = '" & nome & "'", cn)
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

   Private Sub AggiornaSpettanzaCamerieri()
      Try
         ' Aggiorna i valori delle spettanza in base al numero dei camerieri.
         If eui_ckdSpettanzaManuale.Checked = False Then
            Dim j As Integer
            For j = 0 To lvwCamerieri.Items.Count - 1
               lvwCamerieri.Items(j).SubItems(1).Text = CalcolaSpettanzaCamerieri(idTavolo, lvwCamerieri.Items.Count)
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CambiaCameriere_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.Text = "Cambia " & DenominazioneCamerieri
      lblNomeTavolo.Text = "CAMERIERI AL TAVOLO: " & g_frmVCTavoli.lblTavolo.Text

      CaricaListaCamerieri(eui_cmbCameriere, "Camerieri")
      eui_cmbCameriere.SelectedItem = selCameriere
      Me.Tag = selCameriere

      Dim Camerieri As New CamerieriTavolo

      If Camerieri.LeggiDati(lvwCamerieri, "CamerieriTavolo", idTavolo) = False Then
         ' Nome cameriere.
         lvwCamerieri.Items.Add(selCameriere)
         ' Spettanza.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(CalcolaSpettanzaCamerieri(idTavolo, lvwCamerieri.Items.Count))
         ' IdTavolo.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(idTavolo)
         ' IdCameriere.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(LeggiIdCameriere(eui_cmbCameriere.SelectedItem))
         ' Calcolo spettanza.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(eui_ckdSpettanzaManuale.Checked.ToString)

         ' Stabilisce il gruppo di appartenenza.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).Group = lvwCamerieri.Groups.Item(CAMERIERE_PREDEFINITO)
      End If

      eui_ckdSpettanzaManuale.Checked = Convert.ToBoolean(lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems(4).Text)
      eui_cmdSpettanza.Enabled = eui_ckdSpettanzaManuale.Checked

      If eui_ckdSpettanzaManuale.Checked = False Then
         Dim i As Integer
         For i = 0 To lvwCamerieri.Items.Count - 1
            lvwCamerieri.Items(i).SubItems(1).Text = CalcolaSpettanzaCamerieri(idTavolo, lvwCamerieri.Items.Count)
         Next
      End If

   End Sub

   Private Sub Eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub Eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         Dim Camerieri As New CamerieriTavolo

         If Camerieri.EliminaDati("CamerieriTavolo", idTavolo) = True Then

            Dim i As Integer
            For i = 0 To lvwCamerieri.Items.Count - 1
               Camerieri.Nome = lvwCamerieri.Items(i).Text
               Camerieri.Spettanza = lvwCamerieri.Items(i).SubItems(1).Text
               Camerieri.IdTavolo = lvwCamerieri.Items(i).SubItems(2).Text
               Camerieri.IdCameriere = lvwCamerieri.Items(i).SubItems(3).Text
               Camerieri.CalcoloManualeSpettanza = lvwCamerieri.Items(i).SubItems(4).Text
               Camerieri.Gruppo = lvwCamerieri.Items(i).Group.ToString

               Camerieri.InserisciDati("CamerieriTavolo")
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
         For i = 0 To lvwCamerieri.Items.Count - 1
            If lvwCamerieri.Items(i).Text = eui_cmbCameriere.Text Then
               MessageBox.Show("Il cameriere selezionato è già stato inserito.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         Next

         ' Nome cameriere.
         lvwCamerieri.Items.Add(eui_cmbCameriere.SelectedItem).ForeColor = Color.Red
         ' Spettanza.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(VALORE_ZERO)
         ' IdTavolo.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(idTavolo)
         ' IdCameriere.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(LeggiIdCameriere(eui_cmbCameriere.SelectedItem))
         ' Calcolo spettanza.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).SubItems.Add(eui_ckdSpettanzaManuale.Checked.ToString)

         ' Stabilisce il gruppo di appartenenza.
         lvwCamerieri.Items(lvwCamerieri.Items.Count - 1).Group = lvwCamerieri.Groups.Item(CAMERIERE_ALTRI)

         ' Aggiorna i valori delle spettanza in base al numero dei camerieri.
         AggiornaSpettanzaCamerieri()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdElimina_Click(sender As Object, e As EventArgs) Handles eui_cmdElimina.Click
      Try
         lvwCamerieri.Focus()

         If lvwCamerieri.Items(lvwCamerieri.FocusedItem.Index).Group.Name = CAMERIERE_PREDEFINITO Then
            MessageBox.Show("Il cameriere predefinito non può essere eliminato!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            lvwCamerieri.Items.Remove(lvwCamerieri.FocusedItem)

            ' Aggiorna i valori delle spettanza in base al numero dei camerieri.
            AggiornaSpettanzaCamerieri()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdPredefinito_Click(sender As Object, e As EventArgs) Handles eui_cmdPredefinito.Click
      Try
         lvwCamerieri.Focus()

         Dim i As Integer
         For i = 0 To lvwCamerieri.Items.Count - 1
            lvwCamerieri.Items(i).Group = lvwCamerieri.Groups.Item(CAMERIERE_ALTRI)
         Next

         lvwCamerieri.Items(lvwCamerieri.FocusedItem.Index).Group = lvwCamerieri.Groups.Item(CAMERIERE_PREDEFINITO)

         Me.Tag = lvwCamerieri.FocusedItem.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSpettanza_Click(sender As Object, e As EventArgs) Handles eui_cmdSpettanza.Click
      Try
         lvwCamerieri.Focus()

         Dim frm As New ModificaSpettanzaPOS(lvwCamerieri.Items(lvwCamerieri.FocusedItem.Index).Text, lvwCamerieri.Items(lvwCamerieri.FocusedItem.Index).SubItems(1).Text)

         If frm.ShowDialog() = MsgBoxResult.Ok Then
            lvwCamerieri.Items(lvwCamerieri.FocusedItem.Index).SubItems(1).Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(frm.Tag))

            frm.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ckdSpettanzaManuale_CheckedChanged(sender As Object, e As EventArgs) Handles eui_ckdSpettanzaManuale.CheckedChanged
      Try
         ' Aggiorna i valori delle spettanza in base al numero dei camerieri.
         AggiornaSpettanzaCamerieri()

         eui_cmdSpettanza.Enabled = eui_ckdSpettanzaManuale.Checked

         Dim i As Integer
         For i = 0 To lvwCamerieri.Items.Count - 1
            lvwCamerieri.Items(i).SubItems(4).Text = eui_ckdSpettanzaManuale.Checked.ToString
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class