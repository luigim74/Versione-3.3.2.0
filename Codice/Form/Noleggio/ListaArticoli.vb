#Region " DATI FILE.VB "
' **********************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       29/06/2021
' Data ultima modifica: 18/09/2021
' Descrizione:          Anagrafica Noleggi.
' Note:
'
' Elenco Attivita:
'
' ***********************************************************************************************
#End Region

Public Class ListaArticoli

   Const NOME_TABELLA As String = "Articoli"
   Dim CFormatta As New ClsFormatta
   Dim DatiConfig As AppConfig
   Dim CategoriaArticoliNoleggio As String

   Public Sub New(ByVal frmDati As Form)

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Ottiene il nome del form che ha aperto l'elenco.
      Me.Tag = frmDati.Name

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("CategoriaArticoliNoleggio") <> "" Then
            CategoriaArticoliNoleggio = DatiConfig.GetValue("CategoriaArticoliNoleggio")
         Else
            CategoriaArticoliNoleggio = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         DatiConfig.SetValue("CategoriaArticoliNoleggio", CategoriaArticoliNoleggio)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ListaArticoli_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Carica le categorie piatti.
         If CaricaListaCategorie() = True Then

            ' Legge l'ultima Categoria selezionata dal file di configurazione.
            LeggiDatiConfig()

            If CategoriaArticoliNoleggio <> String.Empty Then
               ' Seleziona la categoria salvata.
               eui_cmbCategoriaArticoli.SelectedItem = CategoriaArticoliNoleggio
            Else
               ' Seleziona la prima categoria della lista.
               eui_cmbCategoriaArticoli.SelectedIndex = 0
            End If
         Else
            eui_cmdPiùQuantità.Enabled = False
            eui_cmdMenoQuantità.Enabled = False
            eui_cmdInserisci.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ListaArticoli_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      Try
         ' Salva l'ultima Categoria selezionata nel file di configurazione.
         SalvaDatiConfig()

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
         Dim id As Integer = Convert.ToInt32(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(8).Text)
         Dim valQuantità As Double = Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(4).Text)

         If valQuantità > 0 Then
            Select Case Me.Tag
               Case "frmNoleggi"
                  InserisciElementiNoleggio(NOME_TABELLA, id)
                  g_frmSchedaNoleggi.lstvElencoArticoli.Focus()

               Case "frmCausaliNoleggio"
                  InserisciElementiCausali(NOME_TABELLA, id)
                  g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Focus()

            End Select

            Me.Close()
         Else
            MessageBox.Show("La quantità di articoli che si desidera inserire non è disponibile in magazzino. Per eseguire l'operazione è necessario aumentare la Giacenza.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            lvwArticoli.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lvwArticoli_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwArticoli.DoubleClick
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
         lvwArticoli.Items.Clear()

         Do While dr.Read()
            ' Codice.
            lvwArticoli.Items.Add(dr.Item("Codice"))

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Unità Misura.
            If IsDBNull(dr.Item("UnitàMisura")) = False Then
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(dr.Item("UnitàMisura").ToString)
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Giacenza.
            Dim valGiacenza As Double
            If IsDBNull(dr.Item("Giacenza")) = False Then
               valGiacenza = Convert.ToDouble(dr.Item("Giacenza"))
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(valGiacenza))
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Quantità.
            If valGiacenza > 0 Then
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add("1,00")
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Costo Unitario.
            Dim valPrezzoVendita As Double
            If IsDBNull(dr.Item("PrezzoVendita")) = False Then
               valPrezzoVendita = Convert.ToDouble(dr.Item("PrezzoVendita"))
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(valPrezzoVendita))
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Costo totale.
            If valGiacenza > 0 Then
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(valPrezzoVendita))
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(dr.Item("Categoria"))
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Id.
            If IsDBNull(dr.Item("Id")) = False Then
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(dr.Item("Id").ToString)
            Else
               lvwArticoli.Items(lvwArticoli.Items.Count - 1).SubItems.Add(0.ToString)
            End If

            ' Imposta l'immagine.
            lvwArticoli.Items(lvwArticoli.Items.Count - 1).StateImageIndex = 11

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

         Dim cmd As New OleDbCommand("SELECT * FROM CategorieMerce ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Codice.
            eui_cmbCategoriaArticoli.Items.Add(dr.Item("Descrizione"))

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

   Public Sub InserisciElementiNoleggio(ByVal tabella As String, ByVal id As Integer)
      Try
         ' Codice.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(0).Text)

         ' Descrizione.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(1).Text)

         ' Unità Misura.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(2).Text)

         ' Quantità.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(4).Text)))

         ' Valore Unitario.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(5).Text)))

         ' Importo Netto.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(6).Text)))

         ' TODO_B: Impostare l'aliquota iva inserendo una variabile globale per il settore Noleggio.
         ' Aliquota Iva.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add("22")

         ' Categoria.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(7).Text)

         ' Id.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(8).Text)

         ' RifNoleggio.
         If g_frmSchedaNoleggi.Tag <> String.Empty Then
            g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(g_frmSchedaNoleggi.eui_txtCodice.Text)
         Else
            g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).SubItems.Add(LeggiUltimoRecord(g_frmSchedaNoleggi.TAB_NOLEGGI))
         End If

         ' Imposta l'immagine.
         g_frmSchedaNoleggi.lstvElencoArticoli.Items(g_frmSchedaNoleggi.lstvElencoArticoli.Items.Count - 1).StateImageIndex = 11

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InserisciElementiCausali(ByVal tabella As String, ByVal id As Integer)
      Try
         ' Codice.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(0).Text)

         ' Descrizione.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(1).Text)

         ' Unità Misura.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(2).Text)

         ' Quantità.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(4).Text)))

         ' Valore Unitario.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(5).Text)))

         ' Importo Netto.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(6).Text)))

         ' TODO_B: Impostare l'aliquota iva inserendo una variabile globale per il settore Noleggio.
         ' Aliquota Iva.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add("22")

         ' Categoria.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(7).Text)

         ' Id.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(8).Text)

         ' RifNoleggio.
         If g_frmSchedaCausaliNoleggio.Tag <> String.Empty Then
            g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(g_frmSchedaCausaliNoleggio.eui_txtCodice.Text)
         Else
            g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).SubItems.Add(LeggiUltimoRecord(g_frmSchedaCausaliNoleggio.TAB_CAUSALI_NOLEGGIO))
         End If

         ' Imposta l'immagine.
         g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items(g_frmSchedaCausaliNoleggio.lstvElencoArticoli.Items.Count - 1).StateImageIndex = 11

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmbCategoriaArticoli_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbCategoriaArticoli.SelectedIndexChanged
      Try
         ' Salva la Categoria selezionata.
         CategoriaArticoliNoleggio = eui_cmbCategoriaArticoli.Text

         ' Carica gli Articoli.
         If CaricaLista(NOME_TABELLA, sender.Text) = True Then
            eui_cmdPiùQuantità.Enabled = True
            eui_cmdMenoQuantità.Enabled = True
            eui_cmdInserisci.Enabled = True
         Else
            eui_cmdPiùQuantità.Enabled = False
            eui_cmdMenoQuantità.Enabled = False
            eui_cmdInserisci.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdPiùQuantità_Click(sender As Object, e As EventArgs) Handles eui_cmdPiùQuantità.Click
      Try
         lvwArticoli.Focus()

         ' Incrementa di 1 la quantità.
         Dim valGiacenza As Double = Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(3).Text)
         Dim valQuantità As Double = Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(4).Text)

         If valGiacenza > valQuantità Then

            valQuantità = valQuantità + 1

            lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(4).Text = CFormatta.FormattaNumeroDouble(valQuantità)

            ' Calcola il Costo totale in base alla quantità.
            Dim valCostoUnitario As Double = Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(5).Text)
            Dim valCostoTotale As Double

            valCostoTotale = valCostoUnitario * valQuantità

            lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(6).Text = CFormatta.FormattaNumeroDouble(valCostoTotale)
         Else
            MessageBox.Show("La quantità di articoli che si desidera inserire non è disponibile in magazzino. Per eseguire l'operazione è necessario aumentare la Giacenza.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         lvwArticoli.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdMenoQuantità_Click(sender As Object, e As EventArgs) Handles eui_cmdMenoQuantità.Click
      Try
         lvwArticoli.Focus()

         ' Decrementa di 1 la quantità.
         Dim valQuantità As Double = Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(4).Text)

         If valQuantità > 0 Then

            valQuantità = valQuantità - 1

            lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(4).Text = CFormatta.FormattaNumeroDouble(valQuantità)

            ' Calcola il Costo totale in base alla quantità.
            Dim valCostoUnitario As Double = Convert.ToDouble(lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(5).Text)
            Dim valCostoTotale As Double

            valCostoTotale = valCostoUnitario * valQuantità

            lvwArticoli.Items(lvwArticoli.FocusedItem.Index).SubItems(6).Text = CFormatta.FormattaNumeroDouble(valCostoTotale)
         End If

         lvwArticoli.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

End Class