#Region " DATI FILE.VB "

' ******************************************************************
' Nome form:            ElencoSchedinePS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       05/08/2018
' Data ultima modifica: 22/08/2018
' Descrizione:          Elenco Schedine di pubblica sicurezza.
' Note:

' Elenco Attivita: 

' ******************************************************************

#End Region

Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Data.OleDb

Public Class ElencoSchedinePS
   Inherits System.Windows.Forms.Form

   Public Const TAB_SCHEDINE As String = "SchedinePS"
   Public Const TAB_COMPONENTI As String = "ComponentiSchedinePS"
   Public Const TAB_NAZIONI As String = "Nazioni"
   Public Const TAB_COMUNI As String = "Comuni"
   Public Const TAB_DOCUMENTI As String = "DocIdentità"
   Public Const TAB_AZIENDA As String = "Azienda"
   Public Const TAB_CLIENTI As String = "Clienti"

   Public Const COLONNA_ID_DOC As Short = 0
   Public Const COLONNA_NUMERO_SCHEDINA As Short = 1
   Public Const COLONNA_NUM_CAMERA As Short = 2
   Public Const COLONNA_COGNOME As Short = 3
   Public Const COLONNA_NOME As Short = 4
   Public Const COLONNA_TIPO_CLIENTE As Short = 5
   Public Const COLONNA_NUMERO_PREN As Short = 6
   Public Const COLONNA_DATA_ARRIVO As Short = 7
   Public Const COLONNA_DATA_PARTENZA As Short = 8
   Public Const COLONNA_STATO As Short = 9
   Public Const COLONNA_DATA_STAMPA As Short = 10
   Public Const COLONNA_ID_CLIENTE As Short = 11

   Const TESTO_FILTRO_PERIODO As String = "Dal... Al..."

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   ' Numero di record.
   Dim numRecord As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim sql As String
   Public repSql As String

   Private DatiConfig As AppConfig
   Private CFormatta As New ClsFormatta
   Friend WithEvents SaveFileDialog1 As SaveFileDialog
   Dim filtroDati As String

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_SCHEDINE)

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
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents lblCampo As System.Windows.Forms.Label
   Friend WithEvents lblTesto As System.Windows.Forms.Label
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoSchedinePS))
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.lblCampo = New System.Windows.Forms.Label()
      Me.lblTesto = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'DataGrid1
      '
      Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 60)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(604, 276)
      Me.DataGrid1.TabIndex = 0
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.TestoRicerca)
      Me.Panel1.Controls.Add(Me.CampoRicerca)
      Me.Panel1.Controls.Add(Me.lblCampo)
      Me.Panel1.Controls.Add(Me.lblTesto)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(604, 60)
      Me.Panel1.TabIndex = 0
      '
      'TestoRicerca
      '
      Me.TestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TestoRicerca.Location = New System.Drawing.Point(16, 32)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(334, 20)
      Me.TestoRicerca.TabIndex = 7
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(358, 32)
      Me.CampoRicerca.Name = "CampoRicerca"
      Me.CampoRicerca.Size = New System.Drawing.Size(232, 21)
      Me.CampoRicerca.TabIndex = 8
      '
      'lblCampo
      '
      Me.lblCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCampo.AutoSize = True
      Me.lblCampo.BackColor = System.Drawing.Color.Transparent
      Me.lblCampo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCampo.ForeColor = System.Drawing.Color.White
      Me.lblCampo.Location = New System.Drawing.Point(358, 16)
      Me.lblCampo.Name = "lblCampo"
      Me.lblCampo.Size = New System.Drawing.Size(85, 15)
      Me.lblCampo.TabIndex = 8
      Me.lblCampo.Text = "Ricerca per:"
      '
      'lblTesto
      '
      Me.lblTesto.AutoSize = True
      Me.lblTesto.BackColor = System.Drawing.Color.Transparent
      Me.lblTesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTesto.ForeColor = System.Drawing.Color.White
      Me.lblTesto.Location = New System.Drawing.Point(16, 16)
      Me.lblTesto.Name = "lblTesto"
      Me.lblTesto.Size = New System.Drawing.Size(110, 15)
      Me.lblTesto.TabIndex = 6
      Me.lblTesto.Text = "Testo di ricerca:"
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Risorse.rpt"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ElencoSchedinePS
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(604, 337)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoSchedinePS"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco prenotazioni camere"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("FiltroPeriodoSchedine") <> "" Then
            filtroDati = DatiConfig.GetValue("FiltroPeriodoSchedine")
         Else
            filtroDati = "Tutti"
         End If

         If DatiConfig.GetValue("WSSchedine") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSSchedine") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("ASchedine") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("ASchedine"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LSchedine") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LSchedine"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("SchedineX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("SchedineX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("SchedineY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("SchedineY")))
            End If

            Exit Sub
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

         DatiConfig.SetValue("FiltroPeriodoSchedine", filtroDati)
         DatiConfig.SetValue("WSSchedine", Me.WindowState)
         DatiConfig.SetValue("SchedineX", Me.Location.X)
         DatiConfig.SetValue("SchedineY", Me.Location.Y)
         DatiConfig.SetValue("ASchedine", Me.Height)
         DatiConfig.SetValue("LSchedine", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' DA_FARE_B: Modificare!
   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      'Try
      '   Select Case wnd
      '      Case Finestra.Documenti
      '         If operatore.ContDoc = VALORE_LETTURA Then
      '            tbrAnnulla.Enabled = False
      '            tbrSospeso.Enabled = False
      '            tbrPassaSospeso.Enabled = False
      '            tbrAnnullaSospeso.Enabled = False
      '            tbrBuoni.Enabled = False
      '            tbrModifica.Enabled = False
      '            tbrAggiorna.Enabled = False
      '         Else
      '            tbrAnnulla.Enabled = True
      '            tbrSospeso.Enabled = True
      '            tbrPassaSospeso.Enabled = True
      '            tbrAnnullaSospeso.Enabled = True
      '            tbrBuoni.Enabled = True
      '            tbrModifica.Enabled = True
      '            tbrAggiorna.Enabled = True
      '         End If

      '   End Select

      '   Return tbrModifica.Enabled

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      '   Return True
      'End Try
   End Function

   Public Sub LeggiDati(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(1, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub LeggiNumPagine(ByVal tabella As String)
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se è da chiudere.
         If closeOnExit Then cn.Close()

         If TestoRicerca.Text <> "" Then
            numPagine = 1
         Else
            ' Ottiene il numero di pagine.
            numPagine = (numRecord + DIM_PAGINA_GRANDE - 1) \ DIM_PAGINA_GRANDE 'dimPagina
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub VisualizzaPagina(ByVal n As Integer, ByVal sql As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sql, cn)

         ' Pulisce la tabella da precedenti dati.
         dt.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dt)

         ' Salva il numero di pagina corrente.
         pagCorrente = n

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_SCHEDINA)
         Dim Cognome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_COGNOME)
         Dim Nome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NOME)
         Dim descrizione As String

         If Nome = String.Empty Then
            descrizione = "'" & Cognome & "' numero " & Numero
         Else
            descrizione = "'" & Cognome & " " & Nome & "' numero " & Numero
         End If

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare la schedina P.S. del Cliente " & descrizione & "?" & vbCrLf & vbCrLf &
                            "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            ' Elimina i dati degli Occupanti per la prenotazione.
            '-------------------------------------------------------------------------------
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM ComponentiSchedinePS WHERE RifPren = {0}", id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
            '-------------------------------------------------------------------------------

            ' Conferma la transazione.
            tr.Commit()

            ' DA_FARE_B: Modificare!
            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Elimina, Descrizione, MODULO_GESTIONE_PLANNING_RISORSE)
         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         ' Aggiorna la griglia dati.
         AggiornaDati()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_SCHEDINE)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            Select Case filtroDati
               Case "Tutti"
                  ' Filtra i dati in base al testo digitato.
                  FiltraDati(TestoRicerca.Text, CampoRicerca.Text)

               Case "Mese"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiMese()

               Case "Anno"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiAnno()

               Case "Periodo"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiPeriodo()

            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiTutte()
      Try
         ' Rimuove i dati di un'eventuale ricerca.
         TestoRicerca.Text = String.Empty

         ' Crea la stringa di selezione dei dati.
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Numero DESC", DIM_PAGINA_GRANDE, TAB_SCHEDINE)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_SCHEDINE_PS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiMese()
      Try
         ' Rimuove i dati di un'eventuale ricerca.
         TestoRicerca.Text = String.Empty

         ' Crea la stringa di selezione dei dati.
         Dim anno As Integer = Now.Year
         Dim mese As Integer = Now.Month
         Dim inizioMese As String = CFormatta.FormattaData("01/" & mese & "/" & anno)
         Dim ultimoGiornoMese As String = DateTime.DaysInMonth(anno, mese)
         Dim fineMese As String = CFormatta.FormattaData(ultimoGiornoMese & "/" & mese & "/" & anno)

         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataArrivo BETWEEN #{2}# AND #{3}# ORDER BY Numero DESC", DIM_PAGINA_GRANDE, TAB_SCHEDINE, inizioMese, fineMese)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_SCHEDINE_PS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiAnno()
      Try
         ' Rimuove i dati di un'eventuale ricerca.
         TestoRicerca.Text = String.Empty

         ' Crea la stringa di selezione dei dati.
         Dim Anno As String = Year(Now)
         Dim inizioAnno As String = CFormatta.FormattaData("01/01/" & Anno)
         Dim ultimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
         Dim fineAnno As String = CFormatta.FormattaData(ultimoGiornoAnno & "/12/" & Anno)

         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataArrivo BETWEEN #{2}# AND #{3}# ORDER BY Numero DESC", DIM_PAGINA_GRANDE, TAB_SCHEDINE, inizioAnno, fineAnno)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_SCHEDINE_PS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiPeriodo()
      Try
         ' Rimuove i dati di un'eventuale ricerca.
         TestoRicerca.Text = String.Empty

         Dim frmFiltroPerido As New FiltroPeriodo()
         If frmFiltroPerido.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Crea la stringa di selezione dei dati.
            Dim dataDal As String = CFormatta.FormattaData(frmFiltroPerido.eui_dtpDataDal.Value.GetValueOrDefault.ToShortDateString)
            Dim dataAl As String = CFormatta.FormattaData(frmFiltroPerido.eui_dtpDataAl.Value.GetValueOrDefault.ToShortDateString)
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataArrivo BETWEEN #{2}# AND #{3}# ORDER BY Numero DESC", DIM_PAGINA_GRANDE, TAB_SCHEDINE, dataDal, dataAl)
            repSql = sql
            LeggiDati("(" & sql & ")", sql)

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

            ' Aggiorna l 'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_SCHEDINE_PS)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.

         ' Strumenti di Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = False
         g_frmMain.eui_Strumenti_Elimina.Enabled = False
         g_frmMain.eui_Strumenti_Duplica.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
         g_frmMain.eui_Strumenti_Esporta.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False

         ' Documenti.

         ' Stampa.
         g_frmMain.eui_Strumenti_Documenti_Proforma.Enabled = False
         g_frmMain.eui_Strumenti_Documenti_Ricevuta.Enabled = False
         g_frmMain.eui_Strumenti_Documenti_Fattura.Enabled = False
         g_frmMain.eui_Strumenti_Documenti_Stampa_Schedina.Enabled = False

         ' Documento.
         g_frmMain.eui_Strumenti_Documenti_Invia.Enabled = False
         g_frmMain.eui_Strumenti_Documenti_Esporta.Enabled = False

      Else
         ' Attiva i pulsanti appropriati.

         ' Strumenti di Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = True
         g_frmMain.eui_Strumenti_Elimina.Enabled = True
         g_frmMain.eui_Strumenti_Duplica.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
         g_frmMain.eui_Strumenti_Esporta.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True

         ' Documenti.

         ' Stampa.
         g_frmMain.eui_Strumenti_Documenti_Proforma.Enabled = True
         g_frmMain.eui_Strumenti_Documenti_Ricevuta.Enabled = True
         g_frmMain.eui_Strumenti_Documenti_Fattura.Enabled = True
         g_frmMain.eui_Strumenti_Documenti_Stampa_Schedina.Enabled = True

         ' Documento.
         g_frmMain.eui_Strumenti_Documenti_Invia.Enabled = True
         g_frmMain.eui_Strumenti_Documenti_Esporta.Enabled = True

      End If
   End Sub

   ' DA_FARE_B: Modificare!
   Public Sub ConvalidaDati()
      'If ImpostaFunzioniOperatore(Finestra.Documenti) = True Then
      ImpostaComandi()
      'End If
   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_SCHEDINE)) = True Then
                  Exit Sub
               End If
            End If
         End If

         g_frmSchedinaPS = New frmSchedinaPS
         g_frmSchedinaPS.Tag = val
         g_frmSchedinaPS.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase("Schedina N. " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " - " &
                                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) & " " &
                                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4))
         Else
            DataGrid1.CaptionText = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      Try
         ' Imposta il titolo della tabella.
         Me.Text = titolo & " (n° totale: " & numRecord & ")"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' 0 - Id.
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' 1 - Numero schedina.
         Dim numeroStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Blue)
         numeroStyle.MappingName = "Numero"
         numeroStyle.HeaderText = "Numero"
         numeroStyle.Width = 70
         numeroStyle.NullText = ""
         numeroStyle.Alignment = HorizontalAlignment.Right
         numeroStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(numeroStyle)
         ' 2 - Numero camera.
         Dim numCameraStyle As New DataGridTextBoxColumn
         numCameraStyle.MappingName = "NumCamera"
         numCameraStyle.HeaderText = "Camera"
         numCameraStyle.Width = 60
         numCameraStyle.NullText = ""
         numCameraStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(numCameraStyle)
         ' 3 - Ragione Sociale / Cognome.
         Dim intestatarioStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         intestatarioStyle.MappingName = "Cognome"
         intestatarioStyle.HeaderText = "Cognome"
         intestatarioStyle.Width = 150
         intestatarioStyle.NullText = ""
         intestatarioStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(intestatarioStyle)
         ' 4 - Nome.
         Dim nomeStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         nomeStyle.MappingName = "Nome"
         nomeStyle.HeaderText = "Nome"
         nomeStyle.Width = 100
         nomeStyle.NullText = ""
         nomeStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(nomeStyle)
         ' 5 - Tipologia Cliente.
         Dim tipologiaStyle As New DataGridTextBoxColumn
         tipologiaStyle.MappingName = "TipologiaCliente"
         tipologiaStyle.HeaderText = "Tipologia cliente"
         tipologiaStyle.Width = 100
         tipologiaStyle.NullText = ""
         tipologiaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipologiaStyle)
         ' 6 - Numero prenotazione.
         Dim numeroPrenStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         numeroPrenStyle.MappingName = "NumPren"
         numeroPrenStyle.HeaderText = "Numero Pren."
         numeroPrenStyle.Width = 80
         numeroPrenStyle.NullText = ""
         numeroPrenStyle.Alignment = HorizontalAlignment.Right
         numeroPrenStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(numeroPrenStyle)
         ' 7 - Data arrivo
         Dim dataArrivoStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         dataArrivoStyle.MappingName = "DataArrivo"
         dataArrivoStyle.HeaderText = "Data di arrivo"
         dataArrivoStyle.Width = 90
         dataArrivoStyle.NullText = ""
         dataArrivoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataArrivoStyle)
         ' 8 - Data partenza
         Dim dataPartenzaStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Green)
         dataPartenzaStyle.MappingName = "DataPartenza"
         dataPartenzaStyle.HeaderText = "Data di partenza"
         dataPartenzaStyle.Width = 90
         dataPartenzaStyle.NullText = ""
         dataPartenzaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataPartenzaStyle)
         ' 9 - Stato.
         Dim statoStyle As New DataGridTextBoxColumn
         statoStyle.MappingName = "Stato"
         statoStyle.HeaderText = "Stato"
         statoStyle.Width = 100
         statoStyle.NullText = ""
         statoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(statoStyle)
         ' 10 - Data Stampa.
         Dim dataStampaStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         dataStampaStyle.MappingName = "DataStampa"
         dataStampaStyle.HeaderText = "Data di stampa"
         dataStampaStyle.Width = 90
         dataStampaStyle.NullText = ""
         dataStampaStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(dataStampaStyle)
         ' 11 - Id Cliente.
         Dim idClienteStyle As New DataGridTextBoxColumn
         idClienteStyle.MappingName = "IdCliente"
         idClienteStyle.HeaderText = "Codice Cliente"
         idClienteStyle.Width = 0
         idClienteStyle.NullText = ""
         idClienteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idClienteStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
      Try
         Dim sql As String

         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Codice"
               campoRicerca = "Id"
            Case "Numero schedina"
               campoRicerca = "Numero"
            Case "Camera"
               campoRicerca = "NumCamera"
            Case "Tipologia"
               campoRicerca = "TipologiaCliente"
            Case "Numero prenotazione"
               campoRicerca = "NumPren"
            Case "Data di arrivo"
               campoRicerca = "DataArrivo"
            Case "Data di partenza"
               campoRicerca = "DataPartenza"
            Case "Data di stampa"
               campoRicerca = "DataStampa"
         End Select

         If testoRicerca <> "" Then
            ' Rimuove eventuali filtri impostati.
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_SCHEDINE, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_SCHEDINE, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            ' Rimuove eventuali filtri impostati.
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO

            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Numero DESC", DIM_PAGINA_GRANDE, TAB_SCHEDINE)
            repSql = String.Format("SELECT * FROM {0} ORDER BY Numero DESC", TAB_SCHEDINE)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_SCHEDINE, sql)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_SCHEDINE_PS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaCampiRic()
      Try
         CampoRicerca.Items.Add("Codice")
         CampoRicerca.Items.Add("Numero schedina")
         CampoRicerca.Items.Add("Camera")
         CampoRicerca.Items.Add("Cognome")
         CampoRicerca.Items.Add("Nome")
         CampoRicerca.Items.Add("Tipologia cliente")
         CampoRicerca.Items.Add("Numero prenotazione")
         CampoRicerca.Items.Add("Data di arrivo")
         CampoRicerca.Items.Add("Data di partenza")
         CampoRicerca.Items.Add("Stato")
         CampoRicerca.Items.Add("Data di stampa")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Function LeggiNumRecord(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function LeggiNumRecord(ByVal tabella As String, ByVal id As String) As Integer
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE RifPren = {1}", tabella, id)
         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Sub AnteprimaDiStampa(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New HospitalityDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepSchedinePS(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaSchedina(ByVal nomeDoc As String)
      Try
         ' Ottiene l'Id del documento.
         Dim idDocumento As String
         idDocumento = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC).ToString

         Dim idCliente As String
         idCliente = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_CLIENTE).ToString

         ' Stampare il documento...
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella SchedinePS.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_SCHEDINE & " WHERE Id = " & idDocumento, cn)
         Dim ds As New HospitalityDataSet1
         ds.Clear()
         oleAdapter.Fill(ds, TAB_SCHEDINE)

         ' Tabella ComponentiSchedinePS.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_COMPONENTI & " WHERE RifPren = " & idDocumento, cn)
         oleAdapter1.Fill(ds, TAB_COMPONENTI)

         ' Tabella Azienda.
         Dim oleAdapter2 As New OleDbDataAdapter
         oleAdapter2.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_AZIENDA, cn)
         oleAdapter2.Fill(ds, TAB_AZIENDA)

         ' Tabella Clienti.
         Dim oleAdapter3 As New OleDbDataAdapter
         oleAdapter3.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_CLIENTI & " WHERE Id = " & idCliente, cn)
         oleAdapter3.Fill(ds, TAB_CLIENTI)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepSchedinaPS(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try

   End Sub


   Private Sub ElencoSchedinePS_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

#Region "Strumenti di Modifica - (Condivisa) "
      ' Visualizza i comandi Strumenti di modifica sul Ribbon.
      g_frmMain.rtgStrumentiModifica.Visible = True

#Region "Modifica - (Condivisa) "
      ' TabPage.
      g_frmMain.eui_StrumentiModifica.Visible = True

      ' Dati.
      g_frmMain.eui_Strumenti_Nuovo.Visible = True
      g_frmMain.eui_Strumenti_Modifica.Visible = True
      g_frmMain.eui_Strumenti_Duplica.Visible = False
      g_frmMain.eui_Strumenti_Elimina.Visible = True
      g_frmMain.eui_Strumenti_Annulla.Visible = False
      g_frmMain.eui_Strumenti_Aggiorna.Visible = True

      ' Esporta.
      g_frmMain.eui_Strumenti_Esporta.Visible = True
      g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
      g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
      g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

      ' Stampa.
      g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
      g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
      ' TabPage.
      g_frmMain.eui_StrumentiPeriodo.Visible = True

      ' Periodo.
      g_frmMain.eui_Strumenti_Periodo_Tutte.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Anno.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Mese.Visible = True
      g_frmMain.eui_Strumenti_Periodo_DalAl.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Sep1.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Arrivo.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Partenza.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Sep2.Visible = False
      g_frmMain.eui_Strumenti_Periodo_NonAssegnate.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Terminate.Visible = False

      ' Visualizza.
      g_frmMain.eui_Strumenti_Visualizza_Presenze.Visible = False
      g_frmMain.eui_rib_Visualizza.Visible = False

#End Region

#Region "Documenti "
      ' TabPage.
      g_frmMain.eui_StrumentiDocumenti.Visible = True

      ' Stampa.
      g_frmMain.eui_Strumenti_Documenti_Proforma.Visible = False
      g_frmMain.eui_Strumenti_Documenti_Sep.Visible = False
      g_frmMain.eui_Strumenti_Documenti_Ricevuta.Visible = False
      g_frmMain.eui_Strumenti_Documenti_Fattura.Visible = False
      g_frmMain.eui_Strumenti_Documenti_Stampa_Schedina.Visible = True

      ' Documento.
      g_frmMain.eui_Strumenti_Documenti_Schedina.Visible = False
      g_frmMain.eui_Strumenti_Documenti_IstatC59.Visible = False
      g_frmMain.eui_Strumenti_Documenti_Sep1.Visible = False
      g_frmMain.eui_Strumenti_Documenti_Invia.Visible = False
      g_frmMain.eui_Strumenti_Documenti_Esporta.Visible = True
      g_frmMain.eui_cmdEsportaPdf.Enabled = False
      g_frmMain.eui_cmdEsportaHtml.Enabled = False
      g_frmMain.eui_cmdEsportaTxt.Visible = True

#End Region

#Region "Sospesi / Buoni pasto "
      ' TabPage.
      g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

      ' Serve ad attivare/disattivare i vari comandi in base ai dati visualizzati.
      AggiornaDati()

#End Region

   End Sub

   Private Sub ElencoSchedinePS_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
#Region "Strumenti di Modifica - (Condivisa) "
      ' Visualizza i comandi Strumenti di modifica sul Ribbon.
      g_frmMain.rtgStrumentiModifica.Visible = False

#End Region

   End Sub

   Private Sub ElencoSchedinePS_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmSchedinePS)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmSchedinePS.Dispose()
         g_frmSchedinePS = Nothing

         ' DA_FARE_B: Modificare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoSchedinePS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_SCHEDINE)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 0

         ' Filtra i dati in base al testo digitato.
         FiltraDati(TestoRicerca.Text, CampoRicerca.Text)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_SCHEDINE_PS)

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' DA_FARE_B: Modificare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      Try
         ' Visualizza un'intestazione per la griglia dati.
         AggIntGriglia()

         ' Verifica se la schedina è già stata inviata.
         If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_SCHEDINA).ToString = "0" Or DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_STATO).ToString = VALORE_INVIATA Then
            g_frmMain.eui_cmdEsportaTxtSelezione.Enabled = False
         Else
            g_frmMain.eui_cmdEsportaTxtSelezione.Enabled = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   ' DA_FARE_B: Modificare!
   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick

      'If Modifica.Enabled = True Then
      '   ' Registra loperazione efettuata dall'operatore identificato.
      '   registraModifica()

      ' Apre la finestra per la modifica dei dati.
      Modifica()
      'End If
   End Sub

   Public Sub Nuovo()
      Try
         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati(String.Empty)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' DA_FARE_B: Modificare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub Modifica()
      Try
         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

         ' DA_FARE_B: Modificare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiValoriSchedina(ByVal id As String) As String
      Try
         ' TOTALE CARATTERI DATI ALLOGGIATO PER RIGA: 168 + 2 CON CR+LF TRANNE PER ULTIMA RIGA.

         Dim CSchedina As New SchedinaPS
         Dim rigaFileSchedina As String
         Dim spazi As Integer

         With CSchedina
            ' Visualizza i dati nei rispettivi campi.
            .LeggiDati(TAB_SCHEDINE, id)

            ' Tipo alloggiato - 2c.
            Dim tipoAlloggiato As String
            Select Case .TipologiaCliente
               Case "Ospite Singolo"
                  tipoAlloggiato = "16"

               Case "Capo Famiglia"
                  tipoAlloggiato = "17"

               Case "Capo Gruppo"
                  tipoAlloggiato = "18"
            End Select

            ' Data arrivo - 10c.
            Dim dataArrivo As String
            dataArrivo = Convert.ToDateTime(.DataArrivo).ToShortDateString

            ' Giorni di permanenza - 2c.
            Dim permanenza As String
            Dim lunghezzaPermanenza As Integer = 2
            spazi = (lunghezzaPermanenza - .Permanenza.ToString.Length)
            permanenza = .Permanenza.ToString & Space(spazi)

            ' Cognome - 50c.
            Dim cognome As String
            Dim lunghezzaCognome As Integer = 50
            spazi = (lunghezzaCognome - .Cognome.ToString.Length)
            cognome = .Cognome.ToString & Space(spazi)

            ' Nome - 30c.
            Dim nome As String
            Dim lunghezzaNome As Integer = 30
            spazi = (lunghezzaNome - .Nome.ToString.Length)
            nome = .Nome.ToString & Space(spazi)

            ' Sesso - 1c.
            Dim sesso As String
            Select Case .Sesso
               Case "M"
                  sesso = "1"

               Case "F"
                  sesso = "2"
            End Select

            ' Data nascita - 10c.
            Dim dataNascita As String
            If IsDate(.DataNascita) = True Then
               dataNascita = Convert.ToDateTime(.DataNascita).ToShortDateString
            End If

            ' Comune nascita - 9c.
            Dim comuneNascita As String
            If .LuogoNascita.ToString <> String.Empty Then
               comuneNascita = LeggiCodice(.LuogoNascita.ToString, TAB_COMUNI)
            End If

            ' Provincia nascita - 2c.
            Dim provNascita As String
            If .ProvNascita.ToString <> String.Empty Then
               provNascita = .ProvNascita.ToString
            End If

            ' Stato nascita - 9c.
            Dim nazioneNascita As String
            If .NazioneNascita.ToString <> String.Empty Then
               nazioneNascita = LeggiCodice(FormattaApici(.NazioneNascita.ToString), TAB_NAZIONI)
            End If

            If .NazioneNascita <> "ITALIA" Then
               comuneNascita = Space(9)
               provNascita = Space(2)
            End If

            ' Cittadinanza - 9c.
            Dim cittadinanza As String
            If .Cittadinanza.ToString <> String.Empty Then
               cittadinanza = LeggiCodice(FormattaApici(.Cittadinanza.ToString), TAB_NAZIONI)
            End If

            ' Tipo documento - 5c.
            Dim tipoDoc As String
            If .TipoDoc.ToString <> String.Empty Then
               tipoDoc = LeggiCodice(FormattaApici(.TipoDoc.ToString), TAB_DOCUMENTI)
            Else
               tipoDoc = Space(5)
            End If

            ' Numero documento - 20c.
            Dim numeroDoc As String
            Dim lunghezzaNumeroDoc As Integer = 20
            spazi = (lunghezzaNumeroDoc - .NumeroDoc.ToString.Length)
            If .NumeroDoc.ToString <> String.Empty Then
               numeroDoc = .NumeroDoc.ToString & Space(spazi)
            Else
               numeroDoc = Space(20)
            End If

            ' Comune rilascio documento - 9c.
            Dim comuneRilascioDoc As String
            If .ComuneRilascioDoc.ToString <> String.Empty Then
               comuneRilascioDoc = LeggiCodice(FormattaApici(.ComuneRilascioDoc.ToString), TAB_COMUNI)
            Else
               comuneRilascioDoc = Space(9)
            End If

            ' Stato rilascio documento - 9c.
            Dim nazioneRilascioDoc As String
            If .NazioneRilascioDoc.ToString <> String.Empty Then
               nazioneRilascioDoc = LeggiCodice(FormattaApici(.NazioneRilascioDoc.ToString), TAB_NAZIONI)
            Else
               nazioneRilascioDoc = Space(9)
            End If

            ' Luogo rilascio documento. - 9c
            Dim luogoRilascioDoc As String

            Select Case .NazioneRilascioDoc
               Case "ITALIA"
                  luogoRilascioDoc = comuneRilascioDoc

               Case Else
                  luogoRilascioDoc = nazioneRilascioDoc
            End Select

            ' Crea la stringa con tutti i valori.
            rigaFileSchedina = (tipoAlloggiato & dataArrivo & permanenza & cognome & nome & sesso & dataNascita & comuneNascita &
                                provNascita & nazioneNascita & cittadinanza & tipoDoc & numeroDoc & luogoRilascioDoc)

         End With

         Return rigaFileSchedina

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiValoriComponente(ByVal id As String) As String
      Try
         ' TOTALE CARATTERI DATI ALLOGGIATO PER RIGA: 168 + 2 CON CR+LF TRANNE PER ULTIMA RIGA.

         Dim CSchedinaComponenti As New PrenCamereOccupanti
         Dim rigaFileSchedina As String
         Dim spazi As Integer

         With CSchedinaComponenti
            ' Visualizza i dati nei rispettivi campi.
            .LeggiDati(TAB_COMPONENTI, id)

            ' Tipo alloggiato - 2c.
            Dim tipoAlloggiato As String
            Select Case .TipoAlloggiato
               Case "Familiare"
                  tipoAlloggiato = "19"

               Case "Membro Gruppo"
                  tipoAlloggiato = "20"
            End Select

            ' Data arrivo - 10c.
            Dim dataArrivo As String
            dataArrivo = Convert.ToDateTime(.DataArrivo).ToShortDateString

            ' Giorni di permanenza - 2c.
            Dim permanenza As String
            Dim lunghezzaPermanenza As Integer = 2
            spazi = (lunghezzaPermanenza - .Permanenza.ToString.Length)
            permanenza = .Permanenza.ToString & Space(spazi)

            ' Cognome - 50c.
            Dim cognome As String
            Dim lunghezzaCognome As Integer = 50
            spazi = (lunghezzaCognome - .Cognome.ToString.Length)
            cognome = .Cognome.ToString & Space(spazi)

            ' Nome - 30c.
            Dim nome As String
            Dim lunghezzaNome As Integer = 30
            spazi = (lunghezzaNome - .Nome.ToString.Length)
            nome = .Nome.ToString & Space(spazi)

            ' Sesso - 1c.
            Dim sesso As String
            Select Case .Sesso
               Case "M"
                  sesso = "1"

               Case "F"
                  sesso = "2"
            End Select

            ' Data nascita - 10c.
            Dim dataNascita As String
            If IsDate(.DataNascita) = True Then
               dataNascita = Convert.ToDateTime(.DataNascita).ToShortDateString
            End If

            ' Comune nascita - 9c.
            Dim comuneNascita As String
            If .LuogoNascita.ToString <> String.Empty Then
               comuneNascita = LeggiCodice(.LuogoNascita.ToString, TAB_COMUNI)
            End If

            ' Provincia nascita - 2c.
            Dim provNascita As String
            If .ProvNascita.ToString <> String.Empty Then
               provNascita = .ProvNascita.ToString
            End If

            ' Stato nascita - 9c.
            Dim nazioneNascita As String
            If .StatoNascita.ToString <> String.Empty Then
               nazioneNascita = LeggiCodice(FormattaApici(.StatoNascita.ToString), TAB_NAZIONI)
            End If

            If .StatoNascita <> "ITALIA" Then
               comuneNascita = Space(9)
               provNascita = Space(2)
            End If

            ' Cittadinanza - 9c.
            Dim cittadinanza As String
            If .Cittadinanza.ToString <> String.Empty Then
               cittadinanza = LeggiCodice(FormattaApici(.Cittadinanza.ToString), TAB_NAZIONI)
            End If

            ' Tipo documento - 5c.
            Dim tipoDoc As String
            tipoDoc = Space(5)

            ' Numero documento - 20c.
            Dim numeroDoc As String
            numeroDoc = Space(20)

            ' Comune rilascio documento - 9c.
            Dim comuneRilascioDoc As String
            comuneRilascioDoc = Space(9)

            'Crea la stringa con tutti i valori.
            rigaFileSchedina = (tipoAlloggiato & dataArrivo & permanenza & cognome & nome & sesso & dataNascita & comuneNascita &
                                provNascita & nazioneNascita & cittadinanza & tipoDoc & numeroDoc & comuneRilascioDoc)

         End With

         Return rigaFileSchedina

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function GeneraFileTxtAlloggiatiWeb(ByVal id As String) As Boolean
      Try
         ' Genera il file di testo richiesto dal portale AlloggiatiWeb della Polizia di Stato. (alloggiatiweb.poliziadistato.it)

         Dim rigaFileSchedina As String
         Dim numComponenti As Integer = LeggiNumRecord(TAB_COMPONENTI, id)
         Dim spazi As Integer

         ' Schedina Capo Famiglia o Campo Gruppo.

         rigaFileSchedina = LeggiValoriSchedina(id)

         If numComponenti > 0 Then
            ' Scrive nel file la riga contenente i dati della schedina con CR + LF.
            PrintLine(1, rigaFileSchedina)
         Else
            ' Scrive nel file la riga contenente i dati della schedina senza CR + LF.
            Print(1, rigaFileSchedina)
         End If

         ' Schedine Famigliari o Membri Gruppo.

         If cn.State = ConnectionState.Closed Then
            ' Apre la connessione.
            cn.Open()
         End If

         Dim cmd As New OleDbCommand("SELECT * FROM ComponentiSchedinePS WHERE RifPren = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim i As Integer
         Do While dr.Read()
            i += 1

            rigaFileSchedina = LeggiValoriComponente(dr.Item("Id").ToString)

            If i = numComponenti Then
               ' Scrive nel file la riga contenente i dati della schedina senza CR + LF.
               Print(1, rigaFileSchedina)
            Else
               ' Scrive nel file la riga contenente i dati della schedina con CR + LF.
               PrintLine(1, rigaFileSchedina)
            End If
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function LeggiCodice(ByVal valDescrizione As String, ByVal tabella As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & valDescrizione & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Codice").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub ModificaStatoSchedina(ByVal tabella As String, ByVal codice As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String

      Try
         If cn.State = ConnectionState.Closed Then
            ' Apre la connessione.
            cn.Open()
         End If

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Stato = @Stato WHERE Id = {1}", tabella, codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Stato", VALORE_INVIATA)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try

   End Sub

   Public Function SalvaFileTxtAlloggiatiWeb(ByVal flagTutte As Boolean) As Boolean
      Try
         Dim fileGenerato As Boolean

         ' Impostazioni per la finestra di dialogo.
         SaveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

         SaveFileDialog1.Filter = "File di testo|*.Txt"

         SaveFileDialog1.FilterIndex = 1

         SaveFileDialog1.FileName = "Schedine_" & Today.Day & Today.Month & Today.Year & ".txt"

         ' Apre la finestra di dialogo per salvare il file delle schedine.
         If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Crea il file per la scrittura.
            FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)

            If flagTutte = True Then
               ' Elabora tutte le schedine che hanno un numero e non sono ancora state inviate.

               If cn.State = ConnectionState.Closed Then
                  ' Apre la connessione.
                  cn.Open()
               End If

               Dim cmd As New OleDbCommand("SELECT * FROM SchedinePS WHERE Numero <> 0 AND Stato <> 'Inviata'", cn)
               Dim dr As OleDbDataReader = cmd.ExecuteReader()
               Dim listaIdSchedne As New Collection

               Do While dr.Read()
                  listaIdSchedne.Add(dr.Item("Id"))
               Loop

               ' Chiude la connessione.
               cn.Close()

               Dim i As Integer
               For i = 1 To listaIdSchedne.Count

                  ' Ritorno a capo CR+LF.
                  If i <> 1 Then
                     PrintLine(1)
                  End If

                  ' Se il file è stato creato correttamente modifica lo stato della schedina in Inviata.
                  If GeneraFileTxtAlloggiatiWeb(listaIdSchedne(i).ToString) = True Then
                     ModificaStatoSchedina(TAB_SCHEDINE, listaIdSchedne(i).ToString)
                  End If

                  fileGenerato = True
               Next
            Else
               ' Elabora solo la schedina selezionata nell'elenco.
               Dim idSchedina As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0).ToString

               ' Se il file è stato creato correttamente modifica lo stato della schedina in Inviata.
               If GeneraFileTxtAlloggiatiWeb(idSchedina) = True Then
                  ModificaStatoSchedina(TAB_SCHEDINE, idSchedina)

                  fileGenerato = True
               End If
            End If

            ' Chiude il file.
            FileClose(1)

            If fileGenerato = True Then
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.Default

               ' Aggiorna i dati dell'elenco.
               AggiornaDati()

               ' Chiede se aprire il file.
               Dim risposta As Short = MessageBox.Show("Il file è stato creato con successo! Si desidera aprire il documento?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

               If risposta = vbYes Then
                  AvviaWinBloccoNote(Me.Handle, SaveFileDialog1.FileName)
               End If
            Else
               MessageBox.Show("Il file non è stato creato! Non ci sono schedine da eleaborare", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Function

End Class
