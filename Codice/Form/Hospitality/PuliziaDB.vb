#Region " DATI FILE.VB "
' ******************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/01/2005
' Data ultima modifica: 04/07/2020
' Descrizione:          Finestra per la pulizia delle tabelle dati.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class PuliziaDB
   Inherits System.Windows.Forms.Form

   Const NUMERO_TABELLE As Integer = 63
   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim sql As String

   Dim nomiTabelle(NUMERO_TABELLE) As String
   Dim etichetteTabelle(NUMERO_TABELLE) As String
   Friend WithEvents eui_cmdEsci As Elegant.Ui.Button
   Friend WithEvents eui_cmdEsegui As Elegant.Ui.Button
   Friend WithEvents eui_cmdSeleziona As Elegant.Ui.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

   End Sub

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cklbTabelle As System.Windows.Forms.CheckedListBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PuliziaDB))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cklbTabelle = New System.Windows.Forms.CheckedListBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdSeleziona = New Elegant.Ui.Button()
      Me.eui_cmdEsegui = New Elegant.Ui.Button()
      Me.eui_cmdEsci = New Elegant.Ui.Button()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
      Me.ImageList1.Images.SetKeyName(2, "")
      Me.ImageList1.Images.SetKeyName(3, "")
      Me.ImageList1.Images.SetKeyName(4, "")
      Me.ImageList1.Images.SetKeyName(5, "")
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Gray
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(0, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(386, 22)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = " ELENCO TABELLE DEL DATABASE:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cklbTabelle
      '
      Me.cklbTabelle.Location = New System.Drawing.Point(8, 32)
      Me.cklbTabelle.Name = "cklbTabelle"
      Me.cklbTabelle.Size = New System.Drawing.Size(272, 304)
      Me.cklbTabelle.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 344)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(272, 40)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "Selezionare le Tabelle su cui si desidera effettuare la pulizia. Tutti i dati del" &
    "le tabelle selezionate verranno cancellati."
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdSeleziona
      '
      Me.eui_cmdSeleziona.Id = "d2dea16b-f130-42f6-b010-bc2008503d34"
      Me.eui_cmdSeleziona.Location = New System.Drawing.Point(288, 32)
      Me.eui_cmdSeleziona.Name = "eui_cmdSeleziona"
      Me.eui_cmdSeleziona.Size = New System.Drawing.Size(92, 30)
      Me.eui_cmdSeleziona.TabIndex = 13
      Me.eui_cmdSeleziona.Text = "&Seleziona tutto"
      '
      'eui_cmdEsegui
      '
      Me.eui_cmdEsegui.Id = "c4cb4a65-4765-41f5-a2e4-a3c46e3a06e0"
      Me.eui_cmdEsegui.Location = New System.Drawing.Point(288, 73)
      Me.eui_cmdEsegui.Name = "eui_cmdEsegui"
      Me.eui_cmdEsegui.Size = New System.Drawing.Size(92, 30)
      Me.eui_cmdEsegui.TabIndex = 14
      Me.eui_cmdEsegui.Text = "Esegui p&ulizia"
      '
      'eui_cmdEsci
      '
      Me.eui_cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdEsci.Id = "487a9853-f3ac-469b-9bca-cc120c34a7e3"
      Me.eui_cmdEsci.Location = New System.Drawing.Point(288, 310)
      Me.eui_cmdEsci.Name = "eui_cmdEsci"
      Me.eui_cmdEsci.Size = New System.Drawing.Size(92, 26)
      Me.eui_cmdEsci.TabIndex = 15
      Me.eui_cmdEsci.Text = "&Esci"
      '
      'PuliziaDB
      '
      Me.AcceptButton = Me.eui_cmdEsegui
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdEsci
      Me.ClientSize = New System.Drawing.Size(386, 387)
      Me.Controls.Add(Me.eui_cmdEsci)
      Me.Controls.Add(Me.eui_cmdEsegui)
      Me.Controls.Add(Me.eui_cmdSeleziona)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cklbTabelle)
      Me.Controls.Add(Me.Label3)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PuliziaDB"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Pulizia archivi"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Public Sub CaricaListaTabelle(ByVal lstBox As ListBox)
      Try
         Dim i As Integer
         For i = 0 To NUMERO_TABELLE
            lstBox.Items.Add(etichetteTabelle(i))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub EliminaDatiTabelle(ByVal nomeTabella As String)
      Try
         ' Apre la connessione.
         cn.Open()
         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0}", nomeTabella)
         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()
         ' Conferma la transazione.
         tr.Commit()

         Select Case nomeTabella
            Case "Acquisti"
               ' DETTAGLI_ACQUISTI.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "DettagliAcquisti")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "Aziende"
               ' AZIENDE_ALLEGATI.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "Aziende_Allegati")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

               ' BUONI_PASTO.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "BuoniPasto")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete2 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record2 As Integer = cmdDelete2.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

               ' BUONI_PASTO_FATT.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "BuoniPastoFatt")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete3 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record3 As Integer = cmdDelete3.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "Camerieri"
               ' CAMERIERI_ALLEGATI.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "Ca_Allegati")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "Clienti"
               ' CLIENTI_ALLEGATI.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "Cli_Allegati")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "Documenti"
               ' DETTAGLI_DOC.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "DettagliDoc")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "EtichetteArticoli"
               ' ETICHETTE_ARTICOLI_REP.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "EtichetteArticoliRep")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "EtichetteIndirizzi"
               ' ETICHETTE_INDIRIZZI_REP.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "EtichetteIndirizziRep")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "Fornitori"
               ' FORN_ALLEGATI.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "Forn_Allegati")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "Piatti"
               ' INGREDIENTI.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "Ingredienti")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "PrenCamere"
               ' PrenCamereAddebiti.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "PrenCamereAddebiti")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

               ' PrenCamereAllegati.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "PrenCamereAllegati")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete2 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record2 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

               ' PrenCamereOccupanti.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "PrenCamereOccupanti")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete3 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record3 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "PrenRisorse"
               ' PrenCamereAddebiti.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "PrenRisorseConto")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            Case "Tavoli"
               ' Comande.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0}", "Comande")
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Private Sub PuliziaDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Nome delle Tabelle visualizzate nella lista.

         etichetteTabelle(0) = "Accessori e Servizi"
         etichetteTabelle(1) = "Acquisti"
         etichetteTabelle(2) = "Agenzie turistiche"
         etichetteTabelle(3) = "Articoli"
         etichetteTabelle(4) = "Attività"
         etichetteTabelle(5) = "Aziende"
         etichetteTabelle(6) = "Camere"
         etichetteTabelle(7) = "Camerieri"
         etichetteTabelle(8) = "Canali di vendita"
         etichetteTabelle(9) = "Caratteristiche Risorse"
         etichetteTabelle(10) = "Categorie Clienti"
         etichetteTabelle(11) = "Categorie Merceologiche"
         etichetteTabelle(12) = "Categorie Piatti"
         etichetteTabelle(13) = "Causali Documento"
         etichetteTabelle(14) = "Clienti"
         etichetteTabelle(15) = "Conti Tavoli"
         etichetteTabelle(16) = "Corrispettivi"
         etichetteTabelle(17) = "Documenti di identità"
         etichetteTabelle(18) = "Documenti"
         etichetteTabelle(19) = "E-mail"
         etichetteTabelle(20) = "Etichette Articoli"
         etichetteTabelle(21) = "Etichette Indirizzi"
         etichetteTabelle(22) = "Fornitori"
         etichetteTabelle(23) = "Gruppi Operatori"
         etichetteTabelle(24) = "Gruppi Ospiti"
         etichetteTabelle(25) = "Listini Camere"
         etichetteTabelle(26) = "Magazzini"
         etichetteTabelle(27) = "Messaggi inviati ai reparti"
         etichetteTabelle(28) = "Messaggi Reparti"
         etichetteTabelle(29) = "Modalità di pagamento"
         etichetteTabelle(30) = "Movimenti di Magazzino"
         etichetteTabelle(31) = "Nazioni"
         etichetteTabelle(32) = "Registro Operazioni"
         etichetteTabelle(33) = "Piatti"
         etichetteTabelle(34) = "Piatti esauriti"
         etichetteTabelle(35) = "Posizioni camere"
         etichetteTabelle(36) = "Prenotazione camere"
         etichetteTabelle(37) = "Prenotazioni Tavoli"
         etichetteTabelle(38) = "Prenotazioni Sale"
         etichetteTabelle(39) = "Prenotazione risorse sportive"
         etichetteTabelle(40) = "Prima Nota"
         etichetteTabelle(41) = "Qualifiche"
         etichetteTabelle(42) = "Reparti"
         etichetteTabelle(43) = "Risorse sportive"
         etichetteTabelle(44) = "Sale"
         etichetteTabelle(45) = "Scaffali"
         etichetteTabelle(46) = "Schedine pubblica sicurezza"
         etichetteTabelle(47) = "Sconti e maggiorazioni"
         etichetteTabelle(48) = "Stagioni"
         etichetteTabelle(49) = "Statistiche di vendita Bar / Ristorante"
         etichetteTabelle(50) = "Statistiche di vendita risorse sportive"
         etichetteTabelle(51) = "Statistiche di gioco risorse sportive"
         etichetteTabelle(52) = "Stato prenotazioni"
         etichetteTabelle(53) = "Stato prenotazioni risorse sportive"
         etichetteTabelle(54) = "Storico presenze camere"
         etichetteTabelle(55) = "Storico presenze Istat"
         etichetteTabelle(56) = "Storico presenze Istat C59"
         etichetteTabelle(57) = "Tavoli"
         etichetteTabelle(58) = "Tipo Documenti"
         etichetteTabelle(59) = "Tipologie risorse sportive"
         etichetteTabelle(60) = "Tipologie camere"
         etichetteTabelle(61) = "Ubicazioni"
         etichetteTabelle(62) = "Ubicazioni camere"
         etichetteTabelle(63) = "Unità di misura"

         ' Nome delle Tabelle del database.
         nomiTabelle(0) = "AccessoriServizi"
         nomiTabelle(1) = "Acquisti"
         nomiTabelle(2) = "Agenzie"
         nomiTabelle(3) = "Articoli"
         nomiTabelle(4) = "Attività"
         nomiTabelle(5) = "Aziende"
         nomiTabelle(6) = "Camere"
         nomiTabelle(7) = "Camerieri"
         nomiTabelle(8) = "CanaliVendita"
         nomiTabelle(9) = "CaratteristicheRisorse"
         nomiTabelle(10) = "CategorieClienti"
         nomiTabelle(11) = "CategorieMerce"
         nomiTabelle(12) = "CategoriePiatti"
         nomiTabelle(13) = "CausaliDocumento"
         nomiTabelle(14) = "Clienti"
         nomiTabelle(15) = "ContiTavoli"
         nomiTabelle(16) = "Corrispettivi"
         nomiTabelle(17) = "DocIdentità"
         nomiTabelle(18) = "Documenti"
         nomiTabelle(19) = "Email"
         nomiTabelle(20) = "EtichetteArticoli"
         nomiTabelle(21) = "EtichetteIndirizzi"
         nomiTabelle(22) = "Fornitori"
         nomiTabelle(23) = "Gruppi"
         nomiTabelle(24) = "GruppiOspiti"
         nomiTabelle(25) = "ListiniCamere"
         nomiTabelle(26) = "Magazzini"
         nomiTabelle(27) = "Messaggi"
         nomiTabelle(28) = "MessaggiReparti"
         nomiTabelle(29) = "ModPagamento"
         nomiTabelle(30) = "MovMagazzino"
         nomiTabelle(31) = "Nazioni"
         nomiTabelle(32) = "Operazioni"
         nomiTabelle(33) = "Piatti"
         nomiTabelle(34) = "PiattiEsauriti"
         nomiTabelle(35) = "PosizioniCamere"
         nomiTabelle(36) = "PrenCamere"
         nomiTabelle(37) = "Prenotazioni"
         nomiTabelle(38) = "PrenSale"
         nomiTabelle(39) = "PrenRisorse"
         nomiTabelle(40) = "PrimaNota"
         nomiTabelle(41) = "Qualifiche"
         nomiTabelle(42) = "Reparti"
         nomiTabelle(43) = "Risorse"
         nomiTabelle(44) = "Sale"
         nomiTabelle(45) = "Scaffali"
         nomiTabelle(46) = "SchedinePS"
         nomiTabelle(47) = "ScontiMaggiorazioni"
         nomiTabelle(48) = "Stagioni"
         nomiTabelle(49) = "Statistiche"
         nomiTabelle(50) = "StatisticheRisorse"
         nomiTabelle(51) = "StatisticheGioco"
         nomiTabelle(52) = "StatoPren"
         nomiTabelle(53) = "StatoPrenotazione"
         nomiTabelle(54) = "StoricoPresenzeCamere"
         nomiTabelle(55) = "StoricoPresenzeIstat"
         nomiTabelle(56) = "StoricoPresenzeIstatC59"
         nomiTabelle(57) = "Tavoli"
         nomiTabelle(58) = "TipoDoc"
         nomiTabelle(59) = "Tipologie"
         nomiTabelle(60) = "TipologieCamere"
         nomiTabelle(61) = "Ubicazioni"
         nomiTabelle(62) = "UbicazioniCamere"
         nomiTabelle(63) = "UnitàMisura"

         ' Carica la lista delle Tabelle.
         CaricaListaTabelle(cklbTabelle)

         ' Seleziona il primo elemento della lista.
         If cklbTabelle.Items.Count <> 0 Then
            cklbTabelle.SelectedIndex = 0
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_ARCHIVI_PULIZIA, MODULO_ARCHIVI_PULIZIA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub PercorsoDB_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_ARCHIVI_PULIZIA, MODULO_ARCHIVI_PULIZIA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdSeleziona_Click(sender As Object, e As EventArgs) Handles eui_cmdSeleziona.Click
      Try
         Dim i As Integer
         For i = 0 To cklbTabelle.Items.Count - 1
            cklbTabelle.SetItemChecked(i, True)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdEsegui_Click(sender As Object, e As EventArgs) Handles eui_cmdEsegui.Click
      Try
         Dim tabSel As Boolean = False
         Dim j As Integer
         For j = 0 To NUMERO_TABELLE
            If cklbTabelle.GetItemChecked(j) = True Then
               tabSel = True
               Exit For
            End If
         Next

         If tabSel = False Then
            MessageBox.Show("Nessuna Tabella selezionata! ", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         Dim risposta As DialogResult
         risposta = MessageBox.Show("Sicuro di volere eliminare i dati delle Tabelle selezionate?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = DialogResult.Yes Then
            Dim i As Integer
            For i = 0 To NUMERO_TABELLE
               If cklbTabelle.GetItemChecked(i) = True Then
                  ' Modifica il cursore del mouse.
                  Cursor.Current = Cursors.AppStarting

                  EliminaDatiTabelle(nomiTabelle(i))

                  ' Modifica il cursore del mouse.
                  Cursor.Current = Cursors.Default
               End If
            Next

            MessageBox.Show("Pulizia delle Tabelle eseguita con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Pulizia, String.Empty, MODULO_ARCHIVI_PULIZIA)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         ' Annulla la transazione.
         tr.Rollback()

         ' Chiude la connessione.
         cn.Close()
      End Try

   End Sub

   Private Sub eui_cmdEsci_Click(sender As Object, e As EventArgs) Handles eui_cmdEsci.Click
      Me.Close()
   End Sub
End Class
