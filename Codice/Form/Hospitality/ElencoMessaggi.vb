Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoMessaggi
   Inherits System.Windows.Forms.Form

   Const TAB_MESSAGGI As String = "Messaggi"
   Const TAB_MSG_REPARTI As String = "MessaggiReparti"

   Dim percorsoRep As String = PERCORSO_REP_COMANDA_REPARTI

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   Dim numRecord As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim sql As String

   Private DatiConfig As AppConfig
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private CFormatta As New ClsFormatta

   Private Enum percorsiStampa As Short
      Reparto = 0
      Stampante = 1
      Report = 2
   End Enum

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_MESSAGGI)

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
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents tbReparto1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto2 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto3 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto5 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto6 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto7 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto8 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto9 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbReparto10 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbRicevute As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbFatture As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbProforma As System.Windows.Forms.ToolBarButton
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmdInvia As System.Windows.Forms.Button
   Friend WithEvents tbSep1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents cmbMsg As System.Windows.Forms.ComboBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoMessaggi))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbReparto1 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto2 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto3 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto4 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto5 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto6 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto7 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto8 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto9 = New System.Windows.Forms.ToolBarButton()
      Me.tbReparto10 = New System.Windows.Forms.ToolBarButton()
      Me.tbSep1 = New System.Windows.Forms.ToolBarButton()
      Me.tbRicevute = New System.Windows.Forms.ToolBarButton()
      Me.tbFatture = New System.Windows.Forms.ToolBarButton()
      Me.tbProforma = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.cmbMsg = New System.Windows.Forms.ComboBox()
      Me.cmdInvia = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbReparto1, Me.tbReparto2, Me.tbReparto3, Me.tbReparto4, Me.tbReparto5, Me.tbReparto6, Me.tbReparto7, Me.tbReparto8, Me.tbReparto9, Me.tbReparto10, Me.tbSep1, Me.tbRicevute, Me.tbFatture, Me.tbProforma})
      Me.ToolBar1.ButtonSize = New System.Drawing.Size(70, 36)
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(752, 40)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.Wrappable = False
      '
      'tbReparto1
      '
      Me.tbReparto1.ImageIndex = 9
      Me.tbReparto1.Name = "tbReparto1"
      Me.tbReparto1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto1.Tag = "Reparto1"
      Me.tbReparto1.Text = "Reparto 1"
      Me.tbReparto1.Visible = False
      '
      'tbReparto2
      '
      Me.tbReparto2.ImageIndex = 9
      Me.tbReparto2.Name = "tbReparto2"
      Me.tbReparto2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto2.Tag = "Reparto2"
      Me.tbReparto2.Text = "Reparto 2"
      Me.tbReparto2.Visible = False
      '
      'tbReparto3
      '
      Me.tbReparto3.ImageIndex = 9
      Me.tbReparto3.Name = "tbReparto3"
      Me.tbReparto3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto3.Tag = "Reparto3"
      Me.tbReparto3.Text = "Reparto 3"
      Me.tbReparto3.Visible = False
      '
      'tbReparto4
      '
      Me.tbReparto4.ImageIndex = 9
      Me.tbReparto4.Name = "tbReparto4"
      Me.tbReparto4.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto4.Tag = "Reparto4"
      Me.tbReparto4.Text = "Reparto 4"
      Me.tbReparto4.Visible = False
      '
      'tbReparto5
      '
      Me.tbReparto5.ImageIndex = 9
      Me.tbReparto5.Name = "tbReparto5"
      Me.tbReparto5.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto5.Tag = "Reparto5"
      Me.tbReparto5.Text = "Reparto 5"
      Me.tbReparto5.Visible = False
      '
      'tbReparto6
      '
      Me.tbReparto6.ImageIndex = 9
      Me.tbReparto6.Name = "tbReparto6"
      Me.tbReparto6.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto6.Tag = "Reparto6"
      Me.tbReparto6.Text = "Reparto 6"
      Me.tbReparto6.Visible = False
      '
      'tbReparto7
      '
      Me.tbReparto7.ImageIndex = 9
      Me.tbReparto7.Name = "tbReparto7"
      Me.tbReparto7.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto7.Tag = "Reparto7"
      Me.tbReparto7.Text = "Reparto 7"
      Me.tbReparto7.Visible = False
      '
      'tbReparto8
      '
      Me.tbReparto8.ImageIndex = 9
      Me.tbReparto8.Name = "tbReparto8"
      Me.tbReparto8.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto8.Tag = "Reparto8"
      Me.tbReparto8.Text = "Reparto 8"
      Me.tbReparto8.Visible = False
      '
      'tbReparto9
      '
      Me.tbReparto9.ImageIndex = 9
      Me.tbReparto9.Name = "tbReparto9"
      Me.tbReparto9.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto9.Tag = "Reparto9"
      Me.tbReparto9.Text = "Reparto 9"
      Me.tbReparto9.Visible = False
      '
      'tbReparto10
      '
      Me.tbReparto10.ImageIndex = 9
      Me.tbReparto10.Name = "tbReparto10"
      Me.tbReparto10.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbReparto10.Tag = "Reparto10"
      Me.tbReparto10.Text = "Reparto 10"
      Me.tbReparto10.Visible = False
      '
      'tbSep1
      '
      Me.tbSep1.Name = "tbSep1"
      Me.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbRicevute
      '
      Me.tbRicevute.ImageIndex = 9
      Me.tbRicevute.Name = "tbRicevute"
      Me.tbRicevute.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbRicevute.Tag = "Ricevute"
      Me.tbRicevute.Text = "Ricevute"
      Me.tbRicevute.ToolTipText = "Invia i messaggi al reparto Ricevute"
      '
      'tbFatture
      '
      Me.tbFatture.ImageIndex = 9
      Me.tbFatture.Name = "tbFatture"
      Me.tbFatture.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbFatture.Tag = "Fatture"
      Me.tbFatture.Text = "Fatture"
      Me.tbFatture.ToolTipText = "Invia i messaggi al reparto Fatture"
      '
      'tbProforma
      '
      Me.tbProforma.ImageIndex = 9
      Me.tbProforma.Name = "tbProforma"
      Me.tbProforma.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbProforma.Tag = "Proforma"
      Me.tbProforma.Text = "Proforma"
      Me.tbProforma.ToolTipText = "Invia i messaggi al reparto Proforma"
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
      Me.ImageList1.Images.SetKeyName(6, "")
      Me.ImageList1.Images.SetKeyName(7, "")
      Me.ImageList1.Images.SetKeyName(8, "")
      Me.ImageList1.Images.SetKeyName(9, "")
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
      Me.DataGrid1.CaptionText = "Messaggi inviati"
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 40)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(752, 230)
      Me.DataGrid1.TabIndex = 1
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Risorse.rpt"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.cmbMsg)
      Me.Panel2.Controls.Add(Me.cmdInvia)
      Me.Panel2.Controls.Add(Me.Label1)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 270)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(752, 56)
      Me.Panel2.TabIndex = 0
      '
      'cmbMsg
      '
      Me.cmbMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbMsg.Location = New System.Drawing.Point(96, 16)
      Me.cmbMsg.Name = "cmbMsg"
      Me.cmbMsg.Size = New System.Drawing.Size(544, 21)
      Me.cmbMsg.TabIndex = 0
      '
      'cmdInvia
      '
      Me.cmdInvia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdInvia.BackColor = System.Drawing.SystemColors.Control
      Me.cmdInvia.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdInvia.Location = New System.Drawing.Point(648, 14)
      Me.cmdInvia.Name = "cmdInvia"
      Me.cmdInvia.Size = New System.Drawing.Size(88, 24)
      Me.cmdInvia.TabIndex = 1
      Me.cmdInvia.Text = "&Invia"
      Me.cmdInvia.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(81, 15)
      Me.Label1.TabIndex = 237
      Me.Label1.Text = "Messaggio:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ElencoMessaggi
      '
      Me.AcceptButton = Me.cmdInvia
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(752, 326)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoMessaggi"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Messaggi ai reparti"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("WSMessaggi") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSMessaggi") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AMessaggi") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AMessaggi"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LMessaggi") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LMessaggi"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("MessaggiX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("MessaggiX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("MessaggiY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("MessaggiY")))
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

         DatiConfig.SetValue("WSMessaggi", Me.WindowState)
         DatiConfig.SetValue("MessaggiX", Me.Location.X)
         DatiConfig.SetValue("MessaggiY", Me.Location.Y)
         DatiConfig.SetValue("AMessaggi", Me.Height)
         DatiConfig.SetValue("LMessaggi", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaFunzioniOperatore(ByVal wnd As String)
      Try
         Select Case wnd
            Case Finestra.MsgReparti
               If operatore.StruMsg = VALORE_LETTURA Then
                  cmdInvia.Enabled = False
               Else
                  cmdInvia.Enabled = True
               End If
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

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

         ' Ottiene il numero di pagine.
         numPagine = (numRecord + DIM_PAGINA_GRANDE - 1) \ DIM_PAGINA_GRANDE 'dimPagina

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

   Public Sub AggiornaDati()
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(TAB_MESSAGGI)

         ' Collega la tabella clienti al controllo griglia dati.
         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(pagCorrente, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Data
         Dim dataStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(-4884), Color.Black)
         dataStyle.MappingName = "Data"
         dataStyle.HeaderText = "Data/Ora"
         dataStyle.Width = 120
         dataStyle.NullText = ""
         dataStyle.TextBox.BackColor = Color.FromArgb(-4884)
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Reparto
         Dim repartoStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(-1376257), Color.Black)
         repartoStyle.MappingName = "Reparto"
         repartoStyle.HeaderText = "Reparto"
         repartoStyle.Width = 120
         repartoStyle.NullText = ""
         repartoStyle.TextBox.BackColor = Color.FromArgb(-1376257)
         gridStyle.GridColumnStyles.Add(repartoStyle)
         ' Tavolo
         Dim tavoloStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         tavoloStyle.MappingName = "DescrizioneRisorsa"
         tavoloStyle.HeaderText = "Tavolo"
         tavoloStyle.Width = 80
         tavoloStyle.NullText = ""
         tavoloStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tavoloStyle)
         ' Messaggio
         Dim messaggioStyle As New DataGridTextBoxColumn
         messaggioStyle.MappingName = "Messaggio"
         messaggioStyle.HeaderText = "Messaggio"
         messaggioStyle.Width = 500
         messaggioStyle.NullText = ""
         messaggioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(messaggioStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

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

   Public Sub LeggiDatiReparti()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Reparti", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()


         Dim i As Integer
         Do While dr.Read
            ToolBar1.Buttons(i).Visible = True
            ToolBar1.Buttons(i).Text = dr.Item("Descrizione")
            ToolBar1.Buttons(i).ToolTipText = "Invia i messaggi al reparto " & dr.Item("Descrizione")
            i += 1
         Loop

         If i = 0 Then
            tbRicevute.Pushed = True
         Else
            ToolBar1.Buttons(0).Pushed = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function SalvaDati(ByVal tabella As String, ByVal reparto As String, ByVal messaggio As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Data, Reparto, IdRisorsa, DescrizioneRisorsa, Messaggio, Inviato) " & _
                                       "VALUES(@Data, @Reparto, @IdRisorsa, @DescrizioneRisorsa, @Messaggio, @Inviato)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", Now.ToShortDateString & " " & Now.ToShortTimeString)
         cmdInsert.Parameters.Add("@Reparto", reparto)
         cmdInsert.Parameters.Add("@IdRisorsa", "")
         cmdInsert.Parameters.Add("@DescrizioneRisorsa", "")
         cmdInsert.Parameters.Add("@Messaggio", messaggio)
         cmdInsert.Parameters.Add("@Inviato", "No")

         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Sub EliminaDati(ByVal tabella As String)
      Try
         Dim sql As String

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} ", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Function ModificaStatoMessaggi(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Inviato = @Inviato", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Inviato", "Sì")

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Private Function LeggiPercorsiDoc(ByVal indice As Integer, ByVal valPos As Short) As String
      Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

      If val(valPos) <> "Nessuna" Then
         Return val(valPos)
      Else
         Return String.Empty
      End If
   End Function

   Private Function LeggiPercorsiComanda(ByVal indice As Integer, ByVal valPos As Short) As String
      Dim val() As String = PercorsiStampantiComande(indice).Split(";")

      If val(valPos) <> String.Empty Then
         Return val(valPos)
      Else
         Return String.Empty
      End If
   End Function

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal idMsg As Integer, ByVal nomeStampante As String, ByVal tabella As String)
      Try
         'If PrintDialog1.ShowDialog() = DialogResult.OK Then

         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter

         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & idMsg, cn)

         Dim ds As New Dataset1

         ds.Clear()

         oleAdapter.Fill(ds, tabella)

         Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         rep.Load(Application.StartupPath & nomeDoc)

         rep.SetDataSource(ds)

         If nomeStampante <> String.Empty And nomeStampante <> "Nessuna" Then
            rep.PrintOptions.PrinterName = nomeStampante
         End If

         rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True, _
                            PrintDialog1.PrinterSettings.FromPage, _
                            PrintDialog1.PrinterSettings.ToPage)

         'End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ElencoMessaggi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ImpostaFunzioniOperatore(Finestra.MsgReparti)

         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         LeggiDatiReparti()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_MESSAGGI)

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", DIM_PAGINA_GRANDE, TAB_MESSAGGI)
         LeggiDati(TAB_MESSAGGI, sql)

         ' Carica l'elenco dei messaggi per i reparti.
         CaricaListaMsgReparti(cmbMsg, TAB_MSG_REPARTI)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_MSG_REPARTI, MODULO_STRUMENTI_MSG_REPARTI)

         cmbMsg.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ElencoMessaggi_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         If LeggiNumRecord(TAB_MESSAGGI) > 0 Then
            Dim risposta As DialogResult
            risposta = MessageBox.Show("Si desidera mantenere i messaggi per una consultazione futura?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If risposta = DialogResult.No Then
               EliminaDati(TAB_MESSAGGI)
            End If
         End If

         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmMessaggi)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmMessaggi.Dispose()
         g_frmMessaggi = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_STRUMENTI_MSG_REPARTI, MODULO_STRUMENTI_MSG_REPARTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdInvia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvia.Click
      Const indiceTb As Short = 11

      Dim i As Integer
      For i = 0 To ToolBar1.Buttons.Count - 1
         If ToolBar1.Buttons(i).Pushed = True Then

            SalvaDati(TAB_MESSAGGI, ToolBar1.Buttons(i).Text, cmbMsg.Text)

            If i < indiceTb Then
               Dim j As Integer
               For j = 0 To 9
                  If ToolBar1.Buttons(i).Text = LeggiPercorsiComanda(j, percorsiStampa.Reparto) Then
                     Exit For
                  End If
               Next

               If LeggiPercorsiComanda(j, percorsiStampa.Stampante) <> String.Empty And _
                  LeggiPercorsiComanda(j, percorsiStampa.Stampante) <> "Nessuna" Then
                  ' Esegue la stampa.
                  StampaDocumento(PERCORSO_REP_MESSAGGI, LeggiUltimoRecord(TAB_MESSAGGI), LeggiPercorsiComanda(j, percorsiStampa.Stampante), TAB_MESSAGGI)
               End If

            Else
               ' Esegue la stampa.
               StampaDocumento(PERCORSO_REP_MESSAGGI, LeggiUltimoRecord(TAB_MESSAGGI), LeggiPercorsiDoc(i - indiceTb, percorsiStampa.Stampante), TAB_MESSAGGI)
            End If
         End If
      Next

      AggiornaDati()
      ModificaStatoMessaggi(TAB_MESSAGGI)

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.InviaMsg, "(" & cmbMsg.Text & ")", MODULO_STRUMENTI_MSG_REPARTI)

      cmbMsg.Text = String.Empty
      cmbMsg.Focus()
   End Sub

End Class
