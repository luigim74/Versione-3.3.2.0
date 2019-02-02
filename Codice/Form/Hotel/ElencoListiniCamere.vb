Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoListiniCamere
   Inherits System.Windows.Forms.Form

   Public Const TAB_LISTINI As String = "ListiniCamere"

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
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents lblAlta As System.Windows.Forms.Label
   Friend WithEvents lblMedia As System.Windows.Forms.Label
   Friend WithEvents lblBassa As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label

   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_LISTINI)

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
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoListiniCamere))
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.lblAlta = New System.Windows.Forms.Label()
      Me.lblMedia = New System.Windows.Forms.Label()
      Me.lblBassa = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.Panel3.SuspendLayout()
      Me.SuspendLayout()
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
      Me.DataGrid1.Location = New System.Drawing.Point(0, 32)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(788, 367)
      Me.DataGrid1.TabIndex = 1
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.CampoRicerca)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.TestoRicerca)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(788, 32)
      Me.Panel1.TabIndex = 2
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(646, 8)
      Me.CampoRicerca.Name = "CampoRicerca"
      Me.CampoRicerca.Size = New System.Drawing.Size(136, 21)
      Me.CampoRicerca.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(555, 8)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 15)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "Ricerca per:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(2, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(110, 15)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Testo di ricerca:"
      '
      'TestoRicerca
      '
      Me.TestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TestoRicerca.Location = New System.Drawing.Point(120, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(427, 20)
      Me.TestoRicerca.TabIndex = 0
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.Gray
      Me.Panel3.Controls.Add(Me.lblAlta)
      Me.Panel3.Controls.Add(Me.lblMedia)
      Me.Panel3.Controls.Add(Me.lblBassa)
      Me.Panel3.Controls.Add(Me.Label3)
      Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel3.Location = New System.Drawing.Point(0, 400)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(788, 19)
      Me.Panel3.TabIndex = 12
      '
      'lblAlta
      '
      Me.lblAlta.BackColor = System.Drawing.Color.LightSalmon
      Me.lblAlta.Location = New System.Drawing.Point(576, 0)
      Me.lblAlta.Name = "lblAlta"
      Me.lblAlta.Size = New System.Drawing.Size(192, 19)
      Me.lblAlta.TabIndex = 3
      Me.lblAlta.Text = "Alta stagione"
      Me.lblAlta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblMedia
      '
      Me.lblMedia.BackColor = System.Drawing.Color.Khaki
      Me.lblMedia.Location = New System.Drawing.Point(384, 0)
      Me.lblMedia.Name = "lblMedia"
      Me.lblMedia.Size = New System.Drawing.Size(192, 19)
      Me.lblMedia.TabIndex = 2
      Me.lblMedia.Text = "Media stagione"
      Me.lblMedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblBassa
      '
      Me.lblBassa.BackColor = System.Drawing.Color.LightGreen
      Me.lblBassa.ForeColor = System.Drawing.Color.Black
      Me.lblBassa.ImageAlign = System.Drawing.ContentAlignment.TopRight
      Me.lblBassa.Location = New System.Drawing.Point(188, 0)
      Me.lblBassa.Name = "lblBassa"
      Me.lblBassa.Size = New System.Drawing.Size(196, 19)
      Me.lblBassa.TabIndex = 1
      Me.lblBassa.Text = "Bassa stagione"
      Me.lblBassa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Gray
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.SystemColors.Window
      Me.Label3.Location = New System.Drawing.Point(0, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(192, 19)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Legenda:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ElencoListiniCamere
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(788, 419)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoListiniCamere"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Listini camere"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel3.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("WSListiniCamere") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSListiniCamere") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AListiniCamere") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AListiniCamere"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LListiniCamere") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LListiniCamere"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("ListiniCamereX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("ListiniCamereX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("ListiniCamereY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("ListiniCamereY")))
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

         DatiConfig.SetValue("WSListiniCamere", Me.WindowState)
         DatiConfig.SetValue("ListiniCamereX", Me.Location.X)
         DatiConfig.SetValue("ListiniCamereY", Me.Location.Y)
         DatiConfig.SetValue("AListiniCamere", Me.Height)
         DatiConfig.SetValue("LListiniCamere", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' DA_FARE_B: Da sviluppare!
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

         ' Abilita/disabilita i pulsanti.
         'Primo.Enabled = (n > 1)
         'Precedente.Enabled = (n > 1)
         'Successivo.Enabled = (n < numPagine)
         'Ultimo.Enabled = (n < numPagine)

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

         Dim Descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare il listino """ & Descrizione & """?" &
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
            LeggiNumPagine(TAB_LISTINI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            ' Filtra i dati in base al testo digitato.
            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)

         End If

         ' DA_FARE_B: Da sviluppare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

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
         g_frmMain.eui_Strumenti_Duplica.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
         g_frmMain.eui_Strumenti_Esporta.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         g_frmMain.eui_Strumenti_Modifica.Enabled = True
         g_frmMain.eui_Strumenti_Elimina.Enabled = True
         g_frmMain.eui_Strumenti_Duplica.Enabled = True
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
         g_frmMain.eui_Strumenti_Esporta.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      'If ImpostaFunzioniOperatore(Finestra.Listini) = True Then
      ImpostaComandi()
      'End If
   End Sub

   Private Sub ApriDati(ByVal nomeFrm As String, ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_LISTINI)) = True Then
                  Exit Sub
               End If
            End If
         End If

         Dim frm As Form
         frm = New frmListiniCamere
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & " - " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " - " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 23))
         Else
            DataGrid1.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n° totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim decrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         decrizioneStyle.MappingName = "Descrizione"
         decrizioneStyle.HeaderText = "Descrizione"
         decrizioneStyle.Width = 120
         decrizioneStyle.NullText = ""
         decrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(decrizioneStyle)

         ' Solo Pernottamento - Bassa stagione
         Dim soloPernottamentoBassaStyle As New ColonnaColorata(DataGrid1, Color.LightGreen, Color.Black)
         soloPernottamentoBassaStyle.MappingName = "SoloPernottamento_Bassa"
         soloPernottamentoBassaStyle.HeaderText = "Solo Pern."
         soloPernottamentoBassaStyle.Width = 70
         soloPernottamentoBassaStyle.NullText = ""
         soloPernottamentoBassaStyle.Format = "##,##0.00"
         soloPernottamentoBassaStyle.Alignment = HorizontalAlignment.Right
         soloPernottamentoBassaStyle.TextBox.BackColor = Color.LightGreen
         gridStyle.GridColumnStyles.Add(soloPernottamentoBassaStyle)
         ' Bed & Breakfast - Bassa stagione
         Dim bbBassaStyle As New ColonnaColorata(DataGrid1, Color.LightGreen, Color.Black)
         bbBassaStyle.MappingName = "BB_Bassa"
         bbBassaStyle.HeaderText = "B&B"
         bbBassaStyle.Width = 70
         bbBassaStyle.NullText = ""
         bbBassaStyle.Format = "##,##0.00"
         bbBassaStyle.Alignment = HorizontalAlignment.Right
         bbBassaStyle.TextBox.BackColor = Color.LightGreen
         gridStyle.GridColumnStyles.Add(bbBassaStyle)
         ' Mezza Pensione - Bassa stagione
         Dim mezzaPensioneBassaStyle As New ColonnaColorata(DataGrid1, Color.LightGreen, Color.Black)
         mezzaPensioneBassaStyle.MappingName = "MezzaPensione_Bassa"
         mezzaPensioneBassaStyle.HeaderText = "Mezza P."
         mezzaPensioneBassaStyle.Width = 70
         mezzaPensioneBassaStyle.NullText = ""
         mezzaPensioneBassaStyle.Format = "##,##0.00"
         mezzaPensioneBassaStyle.Alignment = HorizontalAlignment.Right
         mezzaPensioneBassaStyle.TextBox.BackColor = Color.LightGreen
         gridStyle.GridColumnStyles.Add(mezzaPensioneBassaStyle)
         ' Pensione Completa - Bassa stagione
         Dim pensioneCompletaBassaStyle As New ColonnaColorata(DataGrid1, Color.LightGreen, Color.Black)
         pensioneCompletaBassaStyle.MappingName = "PensioneCompleta_Bassa"
         pensioneCompletaBassaStyle.HeaderText = "P. Completa"
         pensioneCompletaBassaStyle.Width = 70
         pensioneCompletaBassaStyle.NullText = ""
         pensioneCompletaBassaStyle.Format = "##,##0.00"
         pensioneCompletaBassaStyle.Alignment = HorizontalAlignment.Right
         pensioneCompletaBassaStyle.TextBox.BackColor = Color.LightGreen
         gridStyle.GridColumnStyles.Add(pensioneCompletaBassaStyle)
         ' Sconto Neonato - Bassa stagione
         Dim scontoNeonatoBassaStyle As New ColonnaColorata(DataGrid1, Color.LightGreen, Color.Black)
         scontoNeonatoBassaStyle.MappingName = "ScontoNeonato_Bassa"
         scontoNeonatoBassaStyle.HeaderText = "Sc. N.%"
         scontoNeonatoBassaStyle.Width = 70
         scontoNeonatoBassaStyle.NullText = ""
         scontoNeonatoBassaStyle.Format = "##,##0.00"
         scontoNeonatoBassaStyle.Alignment = HorizontalAlignment.Right
         scontoNeonatoBassaStyle.TextBox.BackColor = Color.LightGreen
         gridStyle.GridColumnStyles.Add(scontoNeonatoBassaStyle)
         ' Sconto Neonato - Bassa stagione
         Dim scontoBambinoBassaStyle As New ColonnaColorata(DataGrid1, Color.LightGreen, Color.Black)
         scontoBambinoBassaStyle.MappingName = "ScontoBambino_Bassa"
         scontoBambinoBassaStyle.HeaderText = "Sc. B.%"
         scontoBambinoBassaStyle.Width = 70
         scontoBambinoBassaStyle.NullText = ""
         scontoBambinoBassaStyle.Format = "##,##0.00"
         scontoBambinoBassaStyle.Alignment = HorizontalAlignment.Right
         scontoBambinoBassaStyle.TextBox.BackColor = Color.LightGreen
         gridStyle.GridColumnStyles.Add(scontoBambinoBassaStyle)
         ' Sconto Ragazzo - Bassa stagione
         Dim scontoRagazzoBassaStyle As New ColonnaColorata(DataGrid1, Color.LightGreen, Color.Black)
         scontoRagazzoBassaStyle.MappingName = "ScontoRagazzo_Bassa"
         scontoRagazzoBassaStyle.HeaderText = "Sc. R.%"
         scontoRagazzoBassaStyle.Width = 70
         scontoRagazzoBassaStyle.NullText = ""
         scontoRagazzoBassaStyle.Format = "##,##0.00"
         scontoRagazzoBassaStyle.Alignment = HorizontalAlignment.Right
         scontoRagazzoBassaStyle.TextBox.BackColor = Color.LightGreen
         gridStyle.GridColumnStyles.Add(scontoRagazzoBassaStyle)

         ' Solo Pernottamento - Media stagione
         Dim soloPernottamentoMediaStyle As New ColonnaColorata(DataGrid1, Color.Khaki, Color.Black)
         soloPernottamentoMediaStyle.MappingName = "SoloPernottamento_Media"
         soloPernottamentoMediaStyle.HeaderText = "Solo Pern."
         soloPernottamentoMediaStyle.Width = 70
         soloPernottamentoMediaStyle.NullText = ""
         soloPernottamentoMediaStyle.Format = "##,##0.00"
         soloPernottamentoMediaStyle.Alignment = HorizontalAlignment.Right
         soloPernottamentoMediaStyle.TextBox.BackColor = Color.Khaki
         gridStyle.GridColumnStyles.Add(soloPernottamentoMediaStyle)
         ' Bed & Breakfast - Media stagione
         Dim bbMediaStyle As New ColonnaColorata(DataGrid1, Color.Khaki, Color.Black)
         bbMediaStyle.MappingName = "BB_Media"
         bbMediaStyle.HeaderText = "B&B"
         bbMediaStyle.Width = 70
         bbMediaStyle.NullText = ""
         bbMediaStyle.Format = "##,##0.00"
         bbMediaStyle.Alignment = HorizontalAlignment.Right
         bbMediaStyle.TextBox.BackColor = Color.Khaki
         gridStyle.GridColumnStyles.Add(bbMediaStyle)
         ' Mezza Pensione - Media stagione
         Dim mezzaPensioneMediaStyle As New ColonnaColorata(DataGrid1, Color.Khaki, Color.Black)
         mezzaPensioneMediaStyle.MappingName = "MezzaPensione_Media"
         mezzaPensioneMediaStyle.HeaderText = "Mezza P."
         mezzaPensioneMediaStyle.Width = 70
         mezzaPensioneMediaStyle.NullText = ""
         mezzaPensioneMediaStyle.Format = "##,##0.00"
         mezzaPensioneMediaStyle.Alignment = HorizontalAlignment.Right
         mezzaPensioneMediaStyle.TextBox.BackColor = Color.Khaki
         gridStyle.GridColumnStyles.Add(mezzaPensioneMediaStyle)
         ' Pensione Completa - Media stagione
         Dim pensioneCompletaMediaStyle As New ColonnaColorata(DataGrid1, Color.Khaki, Color.Black)
         pensioneCompletaMediaStyle.MappingName = "PensioneCompleta_Media"
         pensioneCompletaMediaStyle.HeaderText = "P. Completa"
         pensioneCompletaMediaStyle.Width = 70
         pensioneCompletaMediaStyle.NullText = ""
         pensioneCompletaMediaStyle.Format = "##,##0.00"
         pensioneCompletaMediaStyle.Alignment = HorizontalAlignment.Right
         pensioneCompletaMediaStyle.TextBox.BackColor = Color.Khaki
         gridStyle.GridColumnStyles.Add(pensioneCompletaMediaStyle)
         ' Sconto Neonato - Media stagione
         Dim scontoNeonatoMediaStyle As New ColonnaColorata(DataGrid1, Color.Khaki, Color.Black)
         scontoNeonatoMediaStyle.MappingName = "ScontoNeonato_Media"
         scontoNeonatoMediaStyle.HeaderText = "Sc. N. %"
         scontoNeonatoMediaStyle.Width = 70
         scontoNeonatoMediaStyle.NullText = ""
         scontoNeonatoMediaStyle.Format = "##,##0.00"
         scontoNeonatoMediaStyle.Alignment = HorizontalAlignment.Right
         scontoNeonatoMediaStyle.TextBox.BackColor = Color.Khaki
         gridStyle.GridColumnStyles.Add(scontoNeonatoMediaStyle)
         ' Sconto Neonato - Media stagione
         Dim scontoBambinoMediaStyle As New ColonnaColorata(DataGrid1, Color.Khaki, Color.Black)
         scontoBambinoMediaStyle.MappingName = "ScontoBambino_Media"
         scontoBambinoMediaStyle.HeaderText = "Sc. B. %"
         scontoBambinoMediaStyle.Width = 70
         scontoBambinoMediaStyle.NullText = ""
         scontoBambinoMediaStyle.Format = "##,##0.00"
         scontoBambinoMediaStyle.Alignment = HorizontalAlignment.Right
         scontoBambinoMediaStyle.TextBox.BackColor = Color.Khaki
         gridStyle.GridColumnStyles.Add(scontoBambinoMediaStyle)
         ' Sconto Ragazzo - Media stagione
         Dim scontoRagazzoMediaStyle As New ColonnaColorata(DataGrid1, Color.Khaki, Color.Black)
         scontoRagazzoMediaStyle.MappingName = "ScontoRagazzo_Media"
         scontoRagazzoMediaStyle.HeaderText = "Sc. R. %"
         scontoRagazzoMediaStyle.Width = 70
         scontoRagazzoMediaStyle.NullText = ""
         scontoRagazzoMediaStyle.Format = "##,##0.00"
         scontoRagazzoMediaStyle.Alignment = HorizontalAlignment.Right
         scontoRagazzoMediaStyle.TextBox.BackColor = Color.Khaki
         gridStyle.GridColumnStyles.Add(scontoRagazzoMediaStyle)

         ' Solo Pernottamento - Alta stagione
         Dim soloPernottamentoAltaStyle As New ColonnaColorata(DataGrid1, Color.LightCoral, Color.Black)
         soloPernottamentoAltaStyle.MappingName = "SoloPernottamento_Alta"
         soloPernottamentoAltaStyle.HeaderText = "Solo Pern."
         soloPernottamentoAltaStyle.Width = 70
         soloPernottamentoAltaStyle.NullText = ""
         soloPernottamentoAltaStyle.Format = "##,##0.00"
         soloPernottamentoAltaStyle.Alignment = HorizontalAlignment.Right
         soloPernottamentoAltaStyle.TextBox.BackColor = Color.LightCoral
         gridStyle.GridColumnStyles.Add(soloPernottamentoAltaStyle)
         ' Bed & Breakfast - Alta stagione
         Dim bbAltaStyle As New ColonnaColorata(DataGrid1, Color.LightCoral, Color.Black)
         bbAltaStyle.MappingName = "BB_Alta"
         bbAltaStyle.HeaderText = "B&B"
         bbAltaStyle.Width = 70
         bbAltaStyle.NullText = ""
         bbAltaStyle.Format = "##,##0.00"
         bbAltaStyle.Alignment = HorizontalAlignment.Right
         bbAltaStyle.TextBox.BackColor = Color.LightCoral
         gridStyle.GridColumnStyles.Add(bbAltaStyle)
         ' Mezza Pensione - Alta stagione
         Dim mezzaPensioneAltaStyle As New ColonnaColorata(DataGrid1, Color.LightCoral, Color.Black)
         mezzaPensioneAltaStyle.MappingName = "MezzaPensione_Alta"
         mezzaPensioneAltaStyle.HeaderText = "Mezza P."
         mezzaPensioneAltaStyle.Width = 70
         mezzaPensioneAltaStyle.NullText = ""
         mezzaPensioneAltaStyle.Format = "##,##0.00"
         mezzaPensioneAltaStyle.Alignment = HorizontalAlignment.Right
         mezzaPensioneAltaStyle.TextBox.BackColor = Color.LightCoral
         gridStyle.GridColumnStyles.Add(mezzaPensioneAltaStyle)
         ' Pensione Completa - Alta stagione
         Dim pensioneCompletaAltaStyle As New ColonnaColorata(DataGrid1, Color.LightCoral, Color.Black)
         pensioneCompletaAltaStyle.MappingName = "PensioneCompleta_Alta"
         pensioneCompletaAltaStyle.HeaderText = "P. Completa"
         pensioneCompletaAltaStyle.Width = 70
         pensioneCompletaAltaStyle.NullText = ""
         pensioneCompletaAltaStyle.Format = "##,##0.00"
         pensioneCompletaAltaStyle.Alignment = HorizontalAlignment.Right
         pensioneCompletaAltaStyle.TextBox.BackColor = Color.LightCoral
         gridStyle.GridColumnStyles.Add(pensioneCompletaAltaStyle)
         ' Sconto Neonato - Alta stagione
         Dim scontoNeonatoAltaStyle As New ColonnaColorata(DataGrid1, Color.LightCoral, Color.Black)
         scontoNeonatoAltaStyle.MappingName = "ScontoNeonato_Alta"
         scontoNeonatoAltaStyle.HeaderText = "Sc. N. &"
         scontoNeonatoAltaStyle.Width = 70
         scontoNeonatoAltaStyle.NullText = ""
         scontoNeonatoAltaStyle.Format = "##,##0.00"
         scontoNeonatoAltaStyle.Alignment = HorizontalAlignment.Right
         scontoNeonatoAltaStyle.TextBox.BackColor = Color.LightCoral
         gridStyle.GridColumnStyles.Add(scontoNeonatoAltaStyle)
         ' Sconto Neonato - Alta stagione
         Dim scontoBambinoAltaStyle As New ColonnaColorata(DataGrid1, Color.LightCoral, Color.Black)
         scontoBambinoAltaStyle.MappingName = "ScontoBambino_Alta"
         scontoBambinoAltaStyle.HeaderText = "Sc. B. %"
         scontoBambinoAltaStyle.Width = 70
         scontoBambinoAltaStyle.NullText = ""
         scontoBambinoAltaStyle.Format = "##,##0.00"
         scontoBambinoAltaStyle.Alignment = HorizontalAlignment.Right
         scontoBambinoAltaStyle.TextBox.BackColor = Color.LightCoral
         gridStyle.GridColumnStyles.Add(scontoBambinoAltaStyle)
         ' Sconto Ragazzo - Alta stagione
         Dim scontoRagazzoAltaStyle As New ColonnaColorata(DataGrid1, Color.LightCoral, Color.Black)
         scontoRagazzoAltaStyle.MappingName = "ScontoRagazzo_Alta"
         scontoRagazzoAltaStyle.HeaderText = "Sc. R. %"
         scontoRagazzoAltaStyle.Width = 70
         scontoRagazzoAltaStyle.NullText = ""
         scontoRagazzoAltaStyle.Format = "##,##0.00"
         scontoRagazzoAltaStyle.Alignment = HorizontalAlignment.Right
         scontoRagazzoAltaStyle.TextBox.BackColor = Color.LightCoral
         gridStyle.GridColumnStyles.Add(scontoRagazzoAltaStyle)

         ' Tipologia
         Dim tipologiaStyle As New DataGridTextBoxColumn
         tipologiaStyle.MappingName = "TipologiaListino"
         tipologiaStyle.HeaderText = "Tipologia"
         tipologiaStyle.Width = 100
         tipologiaStyle.NullText = ""
         tipologiaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipologiaStyle)

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
            Case "Tipologia"
               campoRicerca = "TipologiaListino"

            Case "Solo pernottamento - B.S."
               campoRicerca = "SoloPernottamento_Bassa"
            Case "B&B - B.S."
               campoRicerca = "BB_Bassa"
            Case "Mezza pensione - B.S."
               campoRicerca = "MezzaPensione_Bassa"
            Case "Pensione completa - B.S."
               campoRicerca = "PensioneCompleta_Bassa"
            Case "Sconto neonato - B.S."
               campoRicerca = "ScontoNeonato_Bassa"
            Case "Sconto bambino - B.S."
               campoRicerca = "ScontoBambino_Bassa"
            Case "Sconto ragazzo - B.S."
               campoRicerca = "ScontoRagazzo_Bassa"

            Case "Solo pernottamento - M.S."
               campoRicerca = "SoloPernottamento_Media"
            Case "B&B - M.S."
               campoRicerca = "BB_Media"
            Case "Mezza pensione - M.S."
               campoRicerca = "MezzaPensione_Media"
            Case "Pensione completa - M.S."
               campoRicerca = "PensioneCompleta_Media"
            Case "Sconto neonato - M.S."
               campoRicerca = "ScontoNeonato_Media"
            Case "Sconto bambino - M.S."
               campoRicerca = "ScontoBambino_Media"
            Case "Sconto ragazzo - M.S."
               campoRicerca = "ScontoRagazzo_Media"

            Case "Solo pernottamento - A.S."
               campoRicerca = "SoloPernottamento_Alta"
            Case "B&B - A.S."
               campoRicerca = "BB_Alta"
            Case "Mezza pensione - A.S."
               campoRicerca = "MezzaPensione_Alta"
            Case "Pensione completa - A.S."
               campoRicerca = "PensioneCompleta_Alta"
            Case "Sconto neonato - A.S."
               campoRicerca = "ScontoNeonato_Alta"
            Case "Sconto bambino - A.S."
               campoRicerca = "ScontoBambino_Alta"
            Case "Sconto ragazzo - A.S."
               campoRicerca = "ScontoRagazzo_Alta"

         End Select

         If testoRicerca <> "" Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_LISTINI, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_LISTINI, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id ASC", DIM_PAGINA_GRANDE, TAB_LISTINI)
            repSql = String.Format("SELECT * FROM {0} ORDER BY Id ASC", TAB_LISTINI)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_LISTINI, sql)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaCampiRic()
      Try
         CampoRicerca.Items.Add("Codice")
         CampoRicerca.Items.Add("Descrizione")

         CampoRicerca.Items.Add("Solo pernottamento - B.S.")
         CampoRicerca.Items.Add("B&B - B.S.")
         CampoRicerca.Items.Add("Mezza pensione - B.S.")
         CampoRicerca.Items.Add("Pensione completa - B.S.")
         CampoRicerca.Items.Add("Sconto neonato - B.S.")
         CampoRicerca.Items.Add("Sconto bambino - B.S.")
         CampoRicerca.Items.Add("Sconto ragazzo - B.S.")

         CampoRicerca.Items.Add("Solo pernottamento - M.S.")
         CampoRicerca.Items.Add("B&B - M.S.")
         CampoRicerca.Items.Add("Mezza pensione - M.S.")
         CampoRicerca.Items.Add("Pensione completa - M.S.")
         CampoRicerca.Items.Add("Sconto neonato - M.S.")
         CampoRicerca.Items.Add("Sconto bambino - M.S.")
         CampoRicerca.Items.Add("Sconto ragazzo - M.S.")

         CampoRicerca.Items.Add("Solo pernottamento - A.S.")
         CampoRicerca.Items.Add("B&B - A.S.")
         CampoRicerca.Items.Add("Mezza pensione - A.S.")
         CampoRicerca.Items.Add("Pensione completa - A.S.")
         CampoRicerca.Items.Add("Sconto neonato - A.S.")
         CampoRicerca.Items.Add("Sconto bambino - A.S.")
         CampoRicerca.Items.Add("Sconto ragazzo - A.S.")

         CampoRicerca.Items.Add("Tipologia")

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
         Dim frm As New RepListiniCamere(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ElencoListiniCamere_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
#Region "Strumenti di Modifica - (Condivisa) "
      ' Visualizza i comandi Strumenti di modifica sul Ribbon.
      g_frmMain.rtgStrumentiModifica.Visible = True

#Region "Modifica - (Condivisa) "
      ' TabPage.
      g_frmMain.eui_StrumentiModifica.Visible = True

      ' Dati.
      g_frmMain.eui_Strumenti_Nuovo.Visible = True
      g_frmMain.eui_Strumenti_Modifica.Visible = True
      g_frmMain.eui_Strumenti_Duplica.Visible = True
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
      g_frmMain.eui_StrumentiPeriodo.Visible = False

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

   Private Sub ElencoListiniCamere_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Strumenti di Modifica - (Condivisa) "
      g_frmMain.rtgStrumentiModifica.Visible = False

#End Region

   End Sub

   Private Sub ElencoListiniCamere_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmListiniCamere)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmListiniCamere.Dispose()
         g_frmListiniCamere = Nothing

         ' DA_FARE_B: Da sviluppare!
         ' Registra loperazione effettuata dall'operatore identificato.
         ' g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ListiniCamere_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_LISTINI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 0

         ' Filtra i dati in base al testo digitato.
         FiltraDati(TestoRicerca.Text, CampoRicerca.Text)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE)

         ' DA_FARE_B: Da sviluppare!
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

   ' DA_FARE_A: Da sviluppare!
   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
      Select Case e.Button.Tag
         Case "Stampa"
            ' DA_FARE_B: Da sviluppare!
            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

            'StampaDocumento(PERCORSO_REP_DOC, TAB_LISTINI, repSql)

         Case "Anteprima"
            ' DA_FARE_B: Da sviluppare!
            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

            'g_frmMain.ApriReports(repSql, TAB_LISTINI, PERCORSO_REP_DOC)

      End Select
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
      Modifica()

      ' DA_FARE_B: Da sviluppare!
      'If Modifica.Enabled = True Then
      '   ' Registra loperazione efettuata dall'operatore identificato.
      '   registraModifica()

      '   ' Apre la finestra Cliente per la modifica dei dati.
      '   ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      'End If
   End Sub

   Public Sub Nuovo()
      ' Apre la finestra per l'inserimento di nuovi dati.
      ApriDati(Me.Name, "")

      '' Se nella tabella non ci sono record disattiva i pulsanti.
      ConvalidaDati()

      ' DA_FARE_B: Da sviluppare!
      ' Registra loperazione effettuata dall'operatore identificato.
      'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

   End Sub

   Public Sub Modifica()
      ' Apre la finestra Cliente per la modifica dei dati.
      ApriDati(Me.Name, CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

      ' DA_FARE_B: Da sviluppare!
      ' Registra loperazione effettuata dall'operatore identificato.
      'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

   End Sub

   Public Sub DuplicaDati()
      Try
         Dim Risposta As Short
         Dim Descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_LISTINI)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera duplicare il listino """ & Descrizione & """?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            Dim AListinoCamera As New ListinoCamera

            With AListinoCamera
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_LISTINI, CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Descrizione = .Descrizione & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_LISTINI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati è avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' DA_FARE_B: Da sviluppare!
            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
