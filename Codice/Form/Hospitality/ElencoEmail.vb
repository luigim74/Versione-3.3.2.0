#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            ElencoEmail
' Autore:               Luigi Montana, Montana Software
' Data creazione:       22/07/2018
' Data ultima modifica: 29/07/2018
' Descrizione:          Elenco delle E-mail inviate dal programma.
'
' ******************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoEmail
   Inherits System.Windows.Forms.Form

   Public Const TAB_EMAIL As String = "Email"

   Public Const COLONNA_ID As Short = 0
   Public Const COLONNA_DESTINATARIO As Short = 1
   Public Const COLONNA_COGNOME As Short = 2
   Public Const COLONNA_NOME As Short = 3
   Public Const COLONNA_OGGETTO As Short = 4
   Public Const COLONNA_DATA_INVIO As Short = 5
   Public Const COLONNA_ORA_INVIO As Short = 6
   Public Const COLONNA_STATO As Short = 7
   Public Const COLONNA_ALLEGATI As Short = 8
   Public Const COLONNA_CATEGORIA As Short = 9
   Public Const COLONNA_ID_CLIENTE As Short = 11
   Public Const COLONNA_MITTENTE As Short = 12
   Public Const COLONNA_MESSAGGIO As Short = 13

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
   Dim filtroDati As String

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_EMAIL)

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoEmail))
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.lblCampo = New System.Windows.Forms.Label()
      Me.lblTesto = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
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
      Me.DataGrid1.Location = New System.Drawing.Point(0, 63)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(597, 271)
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
      Me.Panel1.Size = New System.Drawing.Size(597, 63)
      Me.Panel1.TabIndex = 0
      '
      'TestoRicerca
      '
      Me.TestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TestoRicerca.Location = New System.Drawing.Point(16, 32)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(327, 20)
      Me.TestoRicerca.TabIndex = 7
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(351, 32)
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
      Me.lblCampo.Location = New System.Drawing.Point(351, 16)
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
      'ElencoEmail
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(597, 335)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoEmail"
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

         If DatiConfig.GetValue("FiltroPeriodoEmail") <> "" Then
            filtroDati = DatiConfig.GetValue("FiltroPeriodoEmail")
         Else
            filtroDati = "Tutti"
         End If

         If DatiConfig.GetValue("WSEmail") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSEmail") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AEmail") <> String.Empty Then
               Me.Height = CInt(DatiConfig.GetValue("AEmail"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LEmail") <> String.Empty Then
               Me.Width = CInt(DatiConfig.GetValue("LEmail"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("EmailX") <> String.Empty Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("EmailX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("EmailY") <> String.Empty Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("EmailY")))
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

         DatiConfig.SetValue("FiltroPeriodoEmail", filtroDati)
         DatiConfig.SetValue("WSEmail", Me.WindowState)
         DatiConfig.SetValue("EmailX", Me.Location.X)
         DatiConfig.SetValue("EmailY", Me.Location.Y)
         DatiConfig.SetValue("AEmail", Me.Height)
         DatiConfig.SetValue("LEmail", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' DA_FARE_B: HOTEL - da modificare!
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

         Dim destinatario As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DESTINATARIO)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare l'e-mail inviata a """ & destinatario & """?" &
                           vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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

            ' Conferma la transazione.
            tr.Commit()

            ' A_TODO: HOTEL - da modificare!
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
         If TestoRicerca.Text <> String.Empty Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_EMAIL)

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
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY DataInvio ASC", DIM_PAGINA_GRANDE, TAB_EMAIL)
         repSql = sql

         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_EMAIL)

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

         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataInvio BETWEEN #{2}# AND #{3}# ORDER BY DataInvio ASC", DIM_PAGINA_GRANDE, TAB_EMAIL, inizioMese, fineMese)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_EMAIL)

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

         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataInvio BETWEEN #{2}# AND #{3}# ORDER BY DataInvio ASC", DIM_PAGINA_GRANDE, TAB_EMAIL, inizioAnno, fineAnno)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_EMAIL)

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
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataInvio BETWEEN #{2}# AND #{3}# ORDER BY DataInvio ASC", DIM_PAGINA_GRANDE, TAB_EMAIL, dataDal, dataAl)
            repSql = sql
            LeggiDati("(" & sql & ")", sql)

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

            ' Aggiorna l 'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_EMAIL)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         g_frmMain.eui_Strumenti_Modifica.Enabled = False
         g_frmMain.eui_Strumenti_Elimina.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
         g_frmMain.eui_Strumenti_Esporta.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         g_frmMain.eui_Strumenti_Modifica.Enabled = True
         g_frmMain.eui_Strumenti_Elimina.Enabled = True
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
         g_frmMain.eui_Strumenti_Esporta.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      ' DA_FARE_B: Modificare!
      'If ImpostaFunzioniOperatore(Finestra.Documenti) = True Then
      ImpostaComandi()
      'End If
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NOME) & " " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_COGNOME) & " - " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DESTINATARIO))
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

         ' 0 - Id 
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = String.Empty
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' 1 - Destinatario
         Dim destinatarioStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         destinatarioStyle.MappingName = "Destinatario"
         destinatarioStyle.HeaderText = "A"
         destinatarioStyle.Width = 200
         destinatarioStyle.NullText = String.Empty
         destinatarioStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(destinatarioStyle)
         ' 2 - Ragione Sociale / Cognome
         Dim cognomeStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         cognomeStyle.MappingName = "Cognome"
         cognomeStyle.HeaderText = "Cognome"
         cognomeStyle.Width = 120
         cognomeStyle.NullText = String.Empty
         cognomeStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(cognomeStyle)
         ' 3 - Nome
         Dim nomeStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         nomeStyle.MappingName = "Nome"
         nomestyle.HeaderText = "Nome"
         nomestyle.Width = 100
         nomestyle.NullText = String.Empty
         nomestyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(nomestyle)
         ' 4 - Oggetto
         Dim oggettoStyle As New DataGridTextBoxColumn
         oggettoStyle.MappingName = "Oggetto"
         oggettoStyle.HeaderText = "Oggetto"
         oggettoStyle.Width = 300
         oggettoStyle.NullText = String.Empty
         oggettoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oggettoStyle)
         ' 5 - Data invio
         Dim dataInvioStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         dataInvioStyle.MappingName = "DataInvio"
         dataInvioStyle.HeaderText = "Data di invio"
         dataInvioStyle.Width = 70
         dataInvioStyle.NullText = String.Empty
         dataInvioStyle.Alignment = HorizontalAlignment.Center
         dataInvioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataInvioStyle)
         ' 6 - Ora invio
         Dim oraInvioStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Green)
         oraInvioStyle.MappingName = "OraInvio"
         oraInvioStyle.HeaderText = "Ora di invio"
         oraInvioStyle.Width = 70
         oraInvioStyle.NullText = String.Empty
         oraInvioStyle.Alignment = HorizontalAlignment.Center
         oraInvioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraInvioStyle)
         ' 7 - Stato
         Dim statoStyle As New DataGridTextBoxColumn
         statoStyle.MappingName = "Stato"
         statoStyle.HeaderText = "Stato"
         statoStyle.Width = 70
         statoStyle.NullText = String.Empty
         statoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(statoStyle)
         ' 8 - Allegati.
         Dim allegatiStyle As New DataGridTextBoxColumn
         allegatiStyle.MappingName = "Allegati"
         allegatiStyle.HeaderText = "Allegati"
         allegatiStyle.Width = 100
         allegatiStyle.NullText = String.Empty
         allegatiStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(allegatiStyle)
         ' 9 - Categoria
         Dim categoriaStyle As New DataGridTextBoxColumn
         categoriaStyle.MappingName = "Categoria"
         categoriaStyle.HeaderText = "Categoria"
         categoriaStyle.Width = 100
         categoriaStyle.NullText = String.Empty
         categoriaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(categoriaStyle)
         ' 10 - Colore.
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "Colore"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 50
         coloreStyle.NullText = String.Empty
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)
         ' 11 - Id Cliente.
         Dim idClienteStyle As New DataGridTextBoxColumn
         idClienteStyle.MappingName = "IdCliente"
         idClienteStyle.HeaderText = "Codice Cliente"
         idClienteStyle.Width = 0
         idClienteStyle.NullText = String.Empty
         idClienteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idClienteStyle)
         ' 12 - Mittente.
         Dim mittenteStyle As New DataGridTextBoxColumn
         mittenteStyle.MappingName = "Mittente"
         mittenteStyle.HeaderText = "Da"
         mittenteStyle.Width = 0
         mittenteStyle.NullText = String.Empty
         mittenteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(mittenteStyle)
         ' 13 - Messaggio.
         Dim messaggioStyle As New DataGridTextBoxColumn
         messaggioStyle.MappingName = "Messaggio"
         messaggioStyle.HeaderText = "Messaggio"
         messaggioStyle.Width = 0
         messaggioStyle.NullText = String.Empty
         messaggioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(messaggioStyle)

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
            Case "A"
               campoRicerca = "Destinatario"
            Case "Data di invio"
               campoRicerca = "DataInvio"
            Case "Ora di invio"
               campoRicerca = "OraInvio"
         End Select

         If testoRicerca <> String.Empty Then
            ' Rimuove eventuali filtri impostati.
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_EMAIL, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_EMAIL, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            ' Rimuove eventuali filtri impostati.
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO

            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY DataInvio ASC", DIM_PAGINA_GRANDE, TAB_EMAIL)
            repSql = String.Format("SELECT * FROM {0} ORDER BY DataInvio ASC", TAB_EMAIL)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_EMAIL, sql)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_EMAIL)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaCampiRic()
      Try
         CampoRicerca.Items.Add("Codice")
         CampoRicerca.Items.Add("A")
         CampoRicerca.Items.Add("Cognome")
         CampoRicerca.Items.Add("Nome")
         CampoRicerca.Items.Add("Oggetto")
         CampoRicerca.Items.Add("Data di invio")
         CampoRicerca.Items.Add("Ora di invio")
         CampoRicerca.Items.Add("Stato")
         CampoRicerca.Items.Add("Categoria")

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
         Dim frm As New RepEmail(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ElencoEmail_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

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
      g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = True
      g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
      g_frmMain.eui_Strumenti_Esporta_EML.Visible = True

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
      g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
      ' TabPage.
      g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

      ' Serve ad attivare/disattivare i vari comandi in base ai dati visualizzati.
      AggiornaDati()

#End Region

   End Sub

   Private Sub ElencoEmail_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Strumenti di Modifica - (Condivisa) "
      ' Visualizza i comandi Strumenti di modifica sul Ribbon.
      g_frmMain.rtgStrumentiModifica.Visible = False

#End Region

   End Sub

   Private Sub ElencoEmail_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmEmail)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmEmail.Dispose()
         g_frmEmail = Nothing

         ' DA_FARE_B: Modificare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_EMAIL)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 0

         ' Filtra i dati in base al testo digitato.
         FiltraDati(TestoRicerca.Text, CampoRicerca.Text)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_EMAIL)

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
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      ' DA_FARE_B: Modificare!
      'If Modifica.Enabled = True Then
      '   ' Registra loperazione efettuata dall'operatore identificato.
      '   registraModifica()

      ' Apre la finestra per la modifica dei dati.
      Modifica()
      'End If
   End Sub

   Public Sub Nuovo()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Apre la finestra Invio e-mail per un nuovo messaggio.
         Dim frmEmail As New InvioEmail(g_frmMain.LeggiEmailMittente, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)

         frmEmail.Tag = String.Empty
         frmEmail.ShowDialog()

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
         'Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Invia un'e-mail al cliente con allegato un documento pdf della prenotazione camera.
         Dim frmEmail As New InvioEmail(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)

         frmEmail.Tag = Convert.ToString(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID))
         frmEmail.ShowDialog()

         ' DA_FARE_B: Terminare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub Esporta()
      Try
         ' Attiva/disattiva il pulsante per esportare il documento in Fattura elettronica.
         If numRecord <> 0 Then

            Dim mittente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_MITTENTE)
            Dim destinatario As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DESTINATARIO)
            Dim oggetto As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_OGGETTO)
            Dim allegati As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ALLEGATI)

            EsportaEmail(mittente, destinatario, oggetto, allegati)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub


End Class
