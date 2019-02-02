Public Class ListaAccessoriServizi

   Const NOME_TABELLA As String = "AccessoriServizi"
   Dim CFormatta As New ClsFormatta
   Dim tipologia As String

   Public Sub New(ByVal tipologiaArt As String)

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

      tipologia = tipologiaArt
   End Sub

   Private Sub ListaAccessoriServizi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Me.Text = "Seleziona " & tipologia

      If CaricaListaAccessoriServizi(NOME_TABELLA, tipologia) = True Then
         Exit Sub
      End If
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_cmdInserisci_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdInserisci.Click
      Try
         Dim id As Integer = Convert.ToInt32(lvwAccessoriServizi.Items(lvwAccessoriServizi.FocusedItem.Index).Text)

         Select Case Me.Tag
            Case "PrenCamera"
               InserisciAccessoriServiziCamera(NOME_TABELLA, tipologia, id)
               g_frmPrenCamera.CalcolaTotaleAddebiti()

            Case "PrenSport"
               InserisciAccessoriServizi(NOME_TABELLA, tipologia, id)
               g_frmDatiPrenRisorse.CalcolaTotaleConto()

            Case "Documento"
               InserisciAccessoriServiziDocumento(NOME_TABELLA, id)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Me.Close()

      End Try
   End Sub

   Private Sub lvwAccessoriServizi_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwAccessoriServizi.DoubleClick
      eui_cmdInserisci.PerformClick()
   End Sub

   Public Function CaricaListaAccessoriServizi(ByVal tabella As String, ByVal tipologia As String) As Boolean
      Dim caricata As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Tipologia = '" & tipologia & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Codice.
            lvwAccessoriServizi.Items.Add(dr.Item("Id"))
            lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).SubItems.Add("")
            End If

            ' Costo.
            If IsDBNull(dr.Item("Costo")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Costo")))
               lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).SubItems.Add(val)
            Else
               lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).SubItems.Add(VALORE_ZERO)
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

   Public Sub InserisciAccessoriServizi(ByVal tabella As String, ByVal tipologia As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String
      Dim QTA As Integer = 1

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()


         Do While dr.Read()

            ' Indice.
            'lvwAccessoriServizi.Items.Add(lvwAccessoriServizi.Items.Count)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               g_frmDatiPrenRisorse.lvwConto.Items.Add(dr.Item("Descrizione"))
            Else
               g_frmDatiPrenRisorse.lvwConto.Items.Add("")
            End If

            ' Stabilisce il gruppo di appartenenza.
            Dim valGruppo As Short
            Select Case tipologia
               Case "Accessorio"
                  valGruppo = 1
               Case "Servizio"
                  valGruppo = 2
               Case "Bar/Ristorante"
                  valGruppo = 3
               Case Else ' Articoli vari
                  valGruppo = 0
            End Select

            ' Assegna il gruppo.
            g_frmDatiPrenRisorse.lvwConto.Items(g_frmDatiPrenRisorse.lvwConto.Items.Count - 1).Group = g_frmDatiPrenRisorse.lvwConto.Groups.Item(valGruppo)
            g_frmDatiPrenRisorse.lvwConto.Items(g_frmDatiPrenRisorse.lvwConto.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

            ' Quantità.
            g_frmDatiPrenRisorse.lvwConto.Items(g_frmDatiPrenRisorse.lvwConto.Items.Count - 1).SubItems.Add(QTA)

            ' Costo.
            If IsDBNull(dr.Item("Costo")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Costo")))
               g_frmDatiPrenRisorse.lvwConto.Items(g_frmDatiPrenRisorse.lvwConto.Items.Count - 1).SubItems.Add(val)
            Else
               g_frmDatiPrenRisorse.lvwConto.Items(g_frmDatiPrenRisorse.lvwConto.Items.Count - 1).SubItems.Add(VALORE_ZERO)
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

   Public Sub InserisciAccessoriServiziCamera(ByVal tabella As String, ByVal tipologia As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String
      Dim QTA As Integer = 1

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()


         Do While dr.Read()

            ' Data.
            g_frmPrenCamera.lvwAddebiti.Items.Add(Today.ToShortDateString)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("")
            End If

            ' Stabilisce il gruppo di appartenenza.
            Dim valGruppo As Short
            Select Case tipologia
               Case "Accessorio"
                  valGruppo = 1
               Case "Servizio"
                  valGruppo = 2
               Case "Bar/Ristorante"
                  valGruppo = 3
               Case Else ' Articoli vari
                  valGruppo = 0
            End Select

            ' Assegna il gruppo.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).Group = g_frmPrenCamera.lvwAddebiti.Groups.Item(valGruppo)
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

            ' Quantità.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(QTA)

            ' Costo.
            If IsDBNull(dr.Item("Costo")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Costo")))
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(val)
            Else
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Codice.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

            ' Indice.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(LeggiAliquotaIva(dr.Item("AliquotaIva")))
            Else
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("0")
            End If

            ' Categoria.
            If tipologia <> String.Empty Then
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(tipologia)
            Else
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)
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

   Public Sub InserisciAccessoriServiziDocumento(ByVal tabella As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String
      Dim QTA As Integer = 1

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
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnUm.Name).Value = String.Empty

            ' Quantità.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnQta.Name).Value = "1,00"

            ' Listino.
            If IsDBNull(dr.Item("Costo")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Costo")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = VALORE_ZERO
            End If

            ' Sconto %.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnSconto.Name).Value = VALORE_ZERO

            ' Importo.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnImporto.Name).Value = g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = LeggiAliquotaIva(dr.Item("AliquotaIva"))
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = "0"
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

End Class