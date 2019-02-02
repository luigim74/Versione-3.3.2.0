Public Class ListaDocumenti
   Const NOME_TABELLA As String = "Documenti"
   Const TABELLA_DETTAGLI_DOC As String = "DettagliDoc"
   Const TIPO_DOC_PF As String = "Proforma"
   Const TIPO_DOC_CO As String = "Conto"

   Dim CFormatta As New ClsFormatta
   Dim DatiConfig As AppConfig
   Dim cliente As String

   Public Sub New(ByVal intestatario As String)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      cliente = intestatario

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub ListaDocumenti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      If CaricaLista(NOME_TABELLA) = True Then
         Exit Sub
      End If
   End Sub

   Private Sub eui_cmdImporta_Click(sender As Object, e As EventArgs) Handles eui_cmdImporta.Click
      Try
         Dim id As Integer = Convert.ToInt32(lvwDocumenti.Items(lvwDocumenti.FocusedItem.Index).SubItems.Item(7).Text)

         g_frmDocumento.dgvDettagli.Focus()

         InserisciElementi(TABELLA_DETTAGLI_DOC, id)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Me.Close()

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub lvwDocumenti_DoubleClick(sender As Object, e As EventArgs) Handles lvwDocumenti.DoubleClick
      eui_cmdImporta.PerformClick()
   End Sub

   Public Function CaricaLista(ByVal tabella As String) As Boolean
      Dim caricata As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String
      Dim strDescrizione As String

      Try
         cn.Open()

         ' Filtra i documenti in base al cliente.
         If cliente <> String.Empty And cliente <> " " Then
            sql = "SELECT * FROM " & tabella & " WHERE Cliente = '" & cliente & "' AND TipoDoc IN ('" & TIPO_DOC_CO & "', '" & TIPO_DOC_PF & "') ORDER BY Id ASC"
         Else
            sql = "SELECT * FROM " & tabella & " WHERE TipoDoc = '" & TIPO_DOC_CO & "' OR TipoDoc = '" & TIPO_DOC_PF & "' ORDER BY Id ASC"
         End If

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Numero.
            If IsDBNull(dr.Item("NumDoc")) = False Then
               lvwDocumenti.Items.Add(dr.Item("NumDoc"))
            Else
               lvwDocumenti.Items.Add(String.Empty)
            End If

            ' Data.
            If IsDBNull(dr.Item("DataDoc")) = False Then
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(dr.Item("DataDoc"))
            Else
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Ora.
            If IsDBNull(dr.Item("OraDoc")) = False Then
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(dr.Item("OraDoc"))
            Else
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Documento.
            If IsDBNull(dr.Item("TipoDoc")) = False Then
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(dr.Item("TipoDoc"))
            Else
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Cliente.
            If IsDBNull(dr.Item("Cliente")) = False Then
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(dr.Item("Cliente"))
            Else
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Stato.
            If IsDBNull(dr.Item("StatoDoc")) = False Then
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(dr.Item("StatoDoc"))
            Else
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Totale.
            If IsDBNull(dr.Item("TotDoc")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("TotDoc")))
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(val)
            Else
               lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Codice.
            lvwDocumenti.Items(lvwDocumenti.Items.Count - 1).SubItems.Add(dr.Item("Id"))
            'lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

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

   Public Sub InserisciElementi(ByVal tabella As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String

      Dim tipoDoc As String = lvwDocumenti.Items(lvwDocumenti.FocusedItem.Index).SubItems.Item(3).Text
      Dim numDoc As String = lvwDocumenti.Items(lvwDocumenti.FocusedItem.Index).Text
      Dim dataDoc As String = lvwDocumenti.Items(lvwDocumenti.FocusedItem.Index).SubItems.Item(1).Text
      Dim descrizione As String = "Rif. documento (" & tipoDoc & " N. " & numDoc & " del " & dataDoc & ")"

      Try
         g_frmDocumento.dgvDettagli.Focus()
         g_frmDocumento.dgvDettagli.Rows.Add()
         g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Selected = True
         g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Cells.Item(0).Selected = True

         ' Codice.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnCodice.Name).Value = String.Empty

         ' Descrizione.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnDescrizione.Name).Value = descrizione

         ' Unità di misura.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnUm.Name).Value = String.Empty

         ' Quantità.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnQta.Name).Value = VALORE_ZERO

         ' Prezzo.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = VALORE_ZERO

         ' Sconto %.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnSconto.Name).Value = VALORE_ZERO

         ' Importo.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnImporto.Name).Value = VALORE_ZERO

         ' Aliquota Iva.
         g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = 0

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifDoc = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            g_frmDocumento.dgvDettagli.Focus()
            g_frmDocumento.dgvDettagli.Rows.Add()
            g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Selected = True
            g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Cells.Item(0).Selected = True

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
            If IsDBNull(dr.Item("Quantità")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnQta.Name).Value = dr.Item("Quantità")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnQta.Name).Value = String.Empty
            End If

            ' Prezzo.
            If IsDBNull(dr.Item("ValoreUnitario")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("ValoreUnitario")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = VALORE_ZERO
            End If

            ' Sconto %.
            If IsDBNull(dr.Item("Sconto")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnSconto.Name).Value = dr.Item("Sconto")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnSconto.Name).Value = VALORE_ZERO
            End If

            ' Importo.
            If IsDBNull(dr.Item("ImportoNetto")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnImporto.Name).Value = dr.Item("ImportoNetto")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnImporto.Name).Value = VALORE_ZERO
            End If

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = dr.Item("AliquotaIva")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = VALORE_ZERO
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            'strDescrizione = "(" & dr.Item("Descrizione") & ")"

         Loop

         ' Modifica lo stato del documento.
         g_frmDocumento.ModificaStatoDocumento(NOME_TABELLA, id, g_frmDocumento.STATO_DOC_IMPORTATO)

         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub


End Class