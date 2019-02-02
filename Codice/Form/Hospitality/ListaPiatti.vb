Public Class ListaPiatti

   Const NOME_TABELLA As String = "Piatti"
   Dim CFormatta As New ClsFormatta
   Private DatiConfig As AppConfig


   Public Sub New()

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub ListaPiatti_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Try
         ' Carica le categorie piatti.
         If CaricaListaCategorie() = True Then
            eui_cmbCategoriaPiatti.SelectedIndex = 0
         Else
            Exit Sub
         End If

         ' Carica i Piatti.
         If CaricaLista(NOME_TABELLA, eui_cmbCategoriaPiatti.Text) = True Then
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_cmdInserisci_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdInserisci.Click
      Try
         Dim id As Integer = Convert.ToInt32(lvwPiatti.Items(lvwPiatti.FocusedItem.Index).Text)

         g_frmDocumento.dgvDettagli.Focus()

         InserisciElementi(NOME_TABELLA, id)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Me.Close()

      End Try
   End Sub

   Private Sub lvwPiatti_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwPiatti.DoubleClick
      eui_cmdInserisci.PerformClick()
   End Sub

   Public Function CaricaLista(ByVal tabella As String, ByVal categoria As String) As Boolean
      Dim caricata As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Categoria = '" & categoria & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         ' Pulisce la lista.
         lvwPiatti.Items.Clear()

         Do While dr.Read()
            ' Codice.
            lvwPiatti.Items.Add(dr.Item("Id"))
            'lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Listino 1.
            If IsDBNull(dr.Item("Listino1")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Listino1")))
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(val)
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Listino 2.
            If IsDBNull(dr.Item("Listino2")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Listino2")))
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(val)
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Listino 3.
            If IsDBNull(dr.Item("Listino3")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Listino3")))
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(val)
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Listino 4.
            If IsDBNull(dr.Item("Listino4")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Listino4")))
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(val)
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("Categoria"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            'strDescrizione = "(" & dr.Item("Descrizione") & ")"

            caricata = True
         Loop

         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

         Return caricata

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         cn.Close()

      End Try
   End Function

   Public Function CaricaListaCategorie() As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim caricata As Boolean = False

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM CategoriePiatti ORDER BY IdOrd ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Codice.
            eui_cmbCategoriaPiatti.Items.Add(dr.Item("Descrizione"))

            caricata = True
         Loop

         Return caricata

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub InserisciElementi(ByVal tabella As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String
      Dim QTA As String = "1,00"

      Try
         g_frmDocumento.dgvDettagli.Focus()
         g_frmDocumento.dgvDettagli.Rows.Add()
         g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Selected = True
         g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Cells.Item(0).Selected = True

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Codice.
            If IsDBNull(dr.Item("Id")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnCodice.Name).Value = dr.Item("Id")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnCodice.Name).Value = String.Empty
            End If

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnDescrizione.Name).Value = dr.Item("Descrizione")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnDescrizione.Name).Value = String.Empty
            End If

            ' Unità di misura.
            If IsDBNull(dr.Item("UnitàMisura")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnUm.Name).Value = dr.Item("UnitàMisura")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnUm.Name).Value = String.Empty
            End If

            ' Quantità.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnQta.Name).Value = QTA

            ' Listino.
            Select Case eui_dwnListino.Text
               Case "Listino 1"
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino1")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = VALORE_ZERO
                  End If

               Case "Listino 2"
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino2")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = VALORE_ZERO
                  End If

               Case "Listino 3"
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino3")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = VALORE_ZERO
                  End If

               Case "Listino 4"
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino4")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = VALORE_ZERO
                  End If

               Case Else
                  g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino1")

            End Select

            ' Sconto %.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnSconto.Name).Value = VALORE_ZERO

            ' Importo.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnImporto.Name).Value = g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = LeggiAliquotaIva(dr.Item("AliquotaIva"))
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = AliquotaIvaRistorante
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnCategoria.Name).Value = dr.Item("Categoria")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnCategoria.Name).Value = String.Empty
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            'strDescrizione = "(" & dr.Item("Descrizione") & ")"

         Loop

         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub eui_cmdListino1_Click(sender As Object, e As EventArgs) Handles eui_cmdListino1.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino2_Click(sender As Object, e As EventArgs) Handles eui_cmdListino2.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino3_Click(sender As Object, e As EventArgs) Handles eui_cmdListino3.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino4_Click(sender As Object, e As EventArgs) Handles eui_cmdListino4.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmbCategoriaPiatti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbCategoriaPiatti.SelectedIndexChanged
      Try
         ' Carica i Piatti.
         If CaricaLista(NOME_TABELLA, sender.Text) = True Then
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub
End Class