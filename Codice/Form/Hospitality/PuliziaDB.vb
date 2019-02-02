Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class PuliziaDB
   Inherits System.Windows.Forms.Form

   Const NUMERO_TABELLE As Integer = 32
   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim sql As String

   Dim etichetteTabelle(NUMERO_TABELLE) As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Dim nomiTabelle(NUMERO_TABELLE) As String

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
   Friend WithEvents cmdSeleziona As System.Windows.Forms.Button
   Friend WithEvents cmdEsegui As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PuliziaDB))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cklbTabelle = New System.Windows.Forms.CheckedListBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmdSeleziona = New System.Windows.Forms.Button()
      Me.cmdEsegui = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
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
      Me.Label3.Size = New System.Drawing.Size(385, 22)
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
      'cmdSeleziona
      '
      Me.cmdSeleziona.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdSeleziona.Location = New System.Drawing.Point(288, 40)
      Me.cmdSeleziona.Name = "cmdSeleziona"
      Me.cmdSeleziona.Size = New System.Drawing.Size(88, 24)
      Me.cmdSeleziona.TabIndex = 1
      Me.cmdSeleziona.Text = "&Seleziona tutto"
      '
      'cmdEsegui
      '
      Me.cmdEsegui.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdEsegui.Location = New System.Drawing.Point(288, 80)
      Me.cmdEsegui.Name = "cmdEsegui"
      Me.cmdEsegui.Size = New System.Drawing.Size(88, 24)
      Me.cmdEsegui.TabIndex = 2
      Me.cmdEsegui.Text = "&Esegui"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(288, 112)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(88, 24)
      Me.cmdAnnulla.TabIndex = 3
      Me.cmdAnnulla.Text = "&Esci"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'PuliziaDB
      '
      Me.AcceptButton = Me.cmdEsegui
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(385, 393)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdEsegui)
      Me.Controls.Add(Me.cmdSeleziona)
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
         Select Case nomeTabella
            Case "Acquisti"
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
               ' Chiude la connessione.
               cn.Close()

            Case "Aziende"
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
               ' Chiude la connessione.

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
               ' Chiude la connessione.

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
               ' Chiude la connessione.
               cn.Close()

            Case "Camerieri"
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
               ' Chiude la connessione.
               cn.Close()

            Case "Clienti"
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
               ' Chiude la connessione.
               cn.Close()

            Case "Documenti"
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
               ' Chiude la connessione.
               cn.Close()

            Case "EtichetteArticoli"
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
               ' Chiude la connessione.
               cn.Close()

            Case "EtichetteIndirizzi"
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
               ' Chiude la connessione.
               cn.Close()

            Case "Fornitori"
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
               ' Chiude la connessione.
               cn.Close()

            Case "Piatti"
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
               ' Chiude la connessione.
               cn.Close()

            Case "Tavoli"
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
               ' Chiude la connessione.
               cn.Close()

            Case Else
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
               ' Chiude la connessione.
               cn.Close()
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub PuliziaDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Nome delle Tabelle visualizzate nella lista.
         etichetteTabelle(0) = "Acquisti"
         etichetteTabelle(1) = "Articoli"
         etichetteTabelle(2) = "Attività"
         etichetteTabelle(3) = "Aziende"
         etichetteTabelle(4) = "Camerieri"
         etichetteTabelle(5) = "Categorie Clienti"
         etichetteTabelle(6) = "Categorie Merceologiche"
         etichetteTabelle(7) = "Categorie Piatti"
         etichetteTabelle(8) = "Clienti"
         etichetteTabelle(9) = "Corrispettivi"
         etichetteTabelle(10) = "Documenti"
         etichetteTabelle(11) = "Etichette Articoli"
         etichetteTabelle(12) = "Etichette Indirizzi"
         etichetteTabelle(13) = "Fornitori"
         etichetteTabelle(14) = "Magazzini"
         etichetteTabelle(15) = "Modalità di pagamento"
         etichetteTabelle(16) = "Movimenti di Magazzino"
         etichetteTabelle(17) = "Nazioni"
         etichetteTabelle(18) = "Piatti"
         etichetteTabelle(19) = "Piatti esauriti"
         etichetteTabelle(20) = "Prenotazioni Tavoli"
         etichetteTabelle(21) = "Prenotazioni Sale"
         etichetteTabelle(22) = "Prima Nota"
         etichetteTabelle(23) = "Qualifiche"
         etichetteTabelle(24) = "Reparti"
         etichetteTabelle(25) = "Sale"
         etichetteTabelle(26) = "Scaffali"
         etichetteTabelle(27) = "Statistiche"
         etichetteTabelle(28) = "Tavoli"
         etichetteTabelle(29) = "Tipo Documenti"
         etichetteTabelle(30) = "Ubicazioni"
         etichetteTabelle(31) = "Unità di misura"
         etichetteTabelle(32) = "Registro Operazioni"

         ' Nome delle Tabelle del database.
         nomiTabelle(0) = "Acquisti"
         nomiTabelle(1) = "Articoli"
         nomiTabelle(2) = "Attività"
         nomiTabelle(3) = "Aziende"
         nomiTabelle(4) = "Camerieri"
         nomiTabelle(5) = "CategorieClienti"
         nomiTabelle(6) = "CategorieMerce"
         nomiTabelle(7) = "CategoriePiatti"
         nomiTabelle(8) = "Clienti"
         nomiTabelle(9) = "Corrispettivi"
         nomiTabelle(10) = "Documenti"
         nomiTabelle(11) = "EtichetteArticoli"
         nomiTabelle(12) = "EtichetteIndirizzi"
         nomiTabelle(13) = "Fornitori"
         nomiTabelle(14) = "Magazzini"
         nomiTabelle(15) = "ModPagamento"
         nomiTabelle(16) = "MovMagazzino"
         nomiTabelle(17) = "Nazioni"
         nomiTabelle(18) = "Piatti"
         nomiTabelle(19) = "PiattiEsauriti"
         nomiTabelle(20) = "Prenotazioni"
         nomiTabelle(21) = "PrenSale"
         nomiTabelle(22) = "PrimaNota"
         nomiTabelle(23) = "Qualifiche"
         nomiTabelle(24) = "Reparti"
         nomiTabelle(25) = "Sale"
         nomiTabelle(26) = "Scaffali"
         nomiTabelle(27) = "Statistiche"
         nomiTabelle(28) = "Tavoli"
         nomiTabelle(29) = "TipoDoc"
         nomiTabelle(30) = "Ubicazioni"
         nomiTabelle(31) = "UnitàMisura"
         nomiTabelle(32) = "Operazioni"

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

   Private Sub cmdSeleziona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleziona.Click
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

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub cmdEsegui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsegui.Click
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

End Class
