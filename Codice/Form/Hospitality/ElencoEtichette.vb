Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoEtichette
   Inherits System.Windows.Forms.Form

   Const TAB_ETICHETTE_INDIRIZZI As String = "EtichetteIndirizzi"
   Const TAB_ETICHETTE_ARTICOLI As String = "EtichetteArticoli"
   Const TAB_ETICHETTE_INDIRIZZI_REP As String = "EtichetteIndirizziRep"
   Const TAB_ETICHETTE_ARTICOLI_REP As String = "EtichetteArticoliRep"
   Const TITOLO_FINESTRA As String = "Elenco Etichette"

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
   Dim dtIndirizzi As DataTable
   Dim dtArticoli As DataTable
   Dim sql As String
   Dim repSql As String

   Dim loadEseguito As Boolean = False

   Private DatiConfig As AppConfig
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private CFormatta As New ClsFormatta

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dtIndirizzi = ds.Tables.Add(TAB_ETICHETTE_INDIRIZZI)
      dtArticoli = ds.Tables.Add(TAB_ETICHETTE_ARTICOLI)

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

   'NOTA: la procedura che segue Ë richiesta da Progettazione Windows Form.
   'PuÚ essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Modifica As System.Windows.Forms.ToolBarButton
   Friend WithEvents Elimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents Stampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents Anteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents Primo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Precedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents Successivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Ultimo As System.Windows.Forms.ToolBarButton
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Aggiorna As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents Sep13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Inserisci As System.Windows.Forms.ToolBarButton
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Public WithEvents dgIndirizzi As System.Windows.Forms.DataGrid
   Public WithEvents dgArticoli As System.Windows.Forms.DataGrid
   Friend WithEvents tbcElenco As System.Windows.Forms.TabControl
   Friend WithEvents tbpIndirizzi As System.Windows.Forms.TabPage
   Friend WithEvents tbpArticoli As System.Windows.Forms.TabPage
   Friend WithEvents Nuovo As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoEtichette))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Nuovo = New System.Windows.Forms.ToolBarButton()
      Me.Modifica = New System.Windows.Forms.ToolBarButton()
      Me.Elimina = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
      Me.Primo = New System.Windows.Forms.ToolBarButton()
      Me.Precedente = New System.Windows.Forms.ToolBarButton()
      Me.Successivo = New System.Windows.Forms.ToolBarButton()
      Me.Ultimo = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
      Me.Aggiorna = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
      Me.Anteprima = New System.Windows.Forms.ToolBarButton()
      Me.Stampa = New System.Windows.Forms.ToolBarButton()
      Me.Sep13 = New System.Windows.Forms.ToolBarButton()
      Me.Inserisci = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.tbcElenco = New System.Windows.Forms.TabControl()
      Me.tbpIndirizzi = New System.Windows.Forms.TabPage()
      Me.dgIndirizzi = New System.Windows.Forms.DataGrid()
      Me.tbpArticoli = New System.Windows.Forms.TabPage()
      Me.dgArticoli = New System.Windows.Forms.DataGrid()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.tbcElenco.SuspendLayout()
      Me.tbpIndirizzi.SuspendLayout()
      CType(Me.dgIndirizzi, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpArticoli.SuspendLayout()
      CType(Me.dgArticoli, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Nuovo, Me.Modifica, Me.Elimina, Me.ToolBarButton4, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.ToolBarButton7, Me.Aggiorna, Me.ToolBarButton1, Me.Anteprima, Me.Stampa, Me.Sep13, Me.Inserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(622, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'Nuovo
      '
      Me.Nuovo.ImageIndex = 0
      Me.Nuovo.Name = "Nuovo"
      Me.Nuovo.Tag = "Nuovo"
      Me.Nuovo.Text = "Nuovo"
      Me.Nuovo.ToolTipText = "Nuovo"
      '
      'Modifica
      '
      Me.Modifica.ImageIndex = 1
      Me.Modifica.Name = "Modifica"
      Me.Modifica.Tag = "Modifica"
      Me.Modifica.Text = "Apri"
      Me.Modifica.ToolTipText = "Apri"
      '
      'Elimina
      '
      Me.Elimina.ImageIndex = 2
      Me.Elimina.Name = "Elimina"
      Me.Elimina.Tag = "Elimina"
      Me.Elimina.Text = "Elimina"
      Me.Elimina.ToolTipText = "Elimina"
      '
      'ToolBarButton4
      '
      Me.ToolBarButton4.Name = "ToolBarButton4"
      Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Primo
      '
      Me.Primo.ImageIndex = 3
      Me.Primo.Name = "Primo"
      Me.Primo.Tag = "Primo"
      Me.Primo.ToolTipText = "Prima pagina"
      Me.Primo.Visible = False
      '
      'Precedente
      '
      Me.Precedente.ImageIndex = 4
      Me.Precedente.Name = "Precedente"
      Me.Precedente.Tag = "Precedente"
      Me.Precedente.ToolTipText = "Pagina precedente "
      Me.Precedente.Visible = False
      '
      'Successivo
      '
      Me.Successivo.ImageIndex = 5
      Me.Successivo.Name = "Successivo"
      Me.Successivo.Tag = "Successivo"
      Me.Successivo.ToolTipText = "Pagina successiva"
      Me.Successivo.Visible = False
      '
      'Ultimo
      '
      Me.Ultimo.ImageIndex = 6
      Me.Ultimo.Name = "Ultimo"
      Me.Ultimo.Tag = "Ultimo"
      Me.Ultimo.ToolTipText = "Ultima pagina"
      Me.Ultimo.Visible = False
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.ToolBarButton7.Visible = False
      '
      'Aggiorna
      '
      Me.Aggiorna.ImageIndex = 7
      Me.Aggiorna.Name = "Aggiorna"
      Me.Aggiorna.Tag = "Aggiorna"
      Me.Aggiorna.ToolTipText = "Aggiorna"
      '
      'ToolBarButton1
      '
      Me.ToolBarButton1.Name = "ToolBarButton1"
      Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Anteprima
      '
      Me.Anteprima.ImageIndex = 8
      Me.Anteprima.Name = "Anteprima"
      Me.Anteprima.Tag = "Anteprima"
      Me.Anteprima.ToolTipText = "Anteprima di stampa"
      '
      'Stampa
      '
      Me.Stampa.ImageIndex = 9
      Me.Stampa.Name = "Stampa"
      Me.Stampa.Tag = "Stampa"
      Me.Stampa.ToolTipText = "Stampa"
      '
      'Sep13
      '
      Me.Sep13.Name = "Sep13"
      Me.Sep13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.Sep13.Visible = False
      '
      'Inserisci
      '
      Me.Inserisci.Name = "Inserisci"
      Me.Inserisci.Tag = ""
      Me.Inserisci.Visible = False
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
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.CampoRicerca)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.TestoRicerca)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(622, 38)
      Me.Panel1.TabIndex = 0
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(480, 8)
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
      Me.Label2.Location = New System.Drawing.Point(391, 8)
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
      Me.TestoRicerca.Location = New System.Drawing.Point(112, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(268, 20)
      Me.TestoRicerca.TabIndex = 0
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Risorse.rpt"
      '
      'tbcElenco
      '
      Me.tbcElenco.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcElenco.Controls.Add(Me.tbpIndirizzi)
      Me.tbcElenco.Controls.Add(Me.tbpArticoli)
      Me.tbcElenco.Location = New System.Drawing.Point(3, 66)
      Me.tbcElenco.Name = "tbcElenco"
      Me.tbcElenco.SelectedIndex = 0
      Me.tbcElenco.Size = New System.Drawing.Size(618, 300)
      Me.tbcElenco.TabIndex = 3
      '
      'tbpIndirizzi
      '
      Me.tbpIndirizzi.Controls.Add(Me.dgIndirizzi)
      Me.tbpIndirizzi.Location = New System.Drawing.Point(4, 22)
      Me.tbpIndirizzi.Name = "tbpIndirizzi"
      Me.tbpIndirizzi.Size = New System.Drawing.Size(610, 274)
      Me.tbpIndirizzi.TabIndex = 0
      Me.tbpIndirizzi.Text = "Etichette Indirizzi"
      '
      'dgIndirizzi
      '
      Me.dgIndirizzi.BackgroundColor = System.Drawing.Color.White
      Me.dgIndirizzi.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgIndirizzi.CaptionBackColor = System.Drawing.Color.Gray
      Me.dgIndirizzi.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgIndirizzi.CaptionForeColor = System.Drawing.Color.White
      Me.dgIndirizzi.DataMember = ""
      Me.dgIndirizzi.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgIndirizzi.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dgIndirizzi.Location = New System.Drawing.Point(0, 0)
      Me.dgIndirizzi.Name = "dgIndirizzi"
      Me.dgIndirizzi.ReadOnly = True
      Me.dgIndirizzi.Size = New System.Drawing.Size(610, 274)
      Me.dgIndirizzi.TabIndex = 2
      '
      'tbpArticoli
      '
      Me.tbpArticoli.Controls.Add(Me.dgArticoli)
      Me.tbpArticoli.Location = New System.Drawing.Point(4, 22)
      Me.tbpArticoli.Name = "tbpArticoli"
      Me.tbpArticoli.Size = New System.Drawing.Size(602, 266)
      Me.tbpArticoli.TabIndex = 1
      Me.tbpArticoli.Text = "Etichette Codice a barre Articoli"
      '
      'dgArticoli
      '
      Me.dgArticoli.BackgroundColor = System.Drawing.Color.White
      Me.dgArticoli.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgArticoli.CaptionBackColor = System.Drawing.Color.Gray
      Me.dgArticoli.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgArticoli.CaptionForeColor = System.Drawing.Color.White
      Me.dgArticoli.DataMember = ""
      Me.dgArticoli.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgArticoli.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dgArticoli.Location = New System.Drawing.Point(0, 0)
      Me.dgArticoli.Name = "dgArticoli"
      Me.dgArticoli.ReadOnly = True
      Me.dgArticoli.Size = New System.Drawing.Size(602, 266)
      Me.dgArticoli.TabIndex = 3
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ElencoEtichette
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(622, 367)
      Me.Controls.Add(Me.tbcElenco)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoEtichette"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Etichette"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.tbcElenco.ResumeLayout(False)
      Me.tbpIndirizzi.ResumeLayout(False)
      CType(Me.dgIndirizzi, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpArticoli.ResumeLayout(False)
      CType(Me.dgArticoli, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("WSEtichette") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSEtichette") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AEtichette") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AEtichette"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LEtichette") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LEtichette"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("EtichetteX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("EtichetteX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("EtichetteY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("EtichetteY")))
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

         DatiConfig.SetValue("WSEtichette", Me.WindowState)
         DatiConfig.SetValue("EtichetteX", Me.Location.X)
         DatiConfig.SetValue("EtichetteY", Me.Location.Y)
         DatiConfig.SetValue("AEtichette", Me.Height)
         DatiConfig.SetValue("LEtichette", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.CodiciBarre
               If operatore.StruCodiciBarre = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

         End Select

         Return Nuovo.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   Public Sub registraModifica()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String

         If tbcElenco.SelectedIndex = 0 Then
            Dim Nome As String = dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 3)
            Dim Cognome As String = dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 2)
            strDescrizione = "(" & Cognome & " " & Nome & ")"

         ElseIf tbcElenco.SelectedIndex = 1 Then
            Dim Codice As String = dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 1)
            Dim Descrizione As String = dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 2)
            strDescrizione = "(" & Codice & " - " & Descrizione & ")"

         End If

         g_frmMain.RegistraOperazione(TipoOperazione.Modifica, strDescrizione, MODULO_STRUMENTI_ETICHETTE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub LeggiDatiIndirizzi(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         dgIndirizzi.DataSource = dtIndirizzi

         ' Visualizza la prima pagina di dati.
         VisualizzaPaginaIndirizzi(1, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub LeggiDatiArticoli(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         dgArticoli.DataSource = dtArticoli

         ' Visualizza la prima pagina di dati.
         VisualizzaPaginaArticoli(1, sql)

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

         ' Chiude la connessione se Ë da chiudere.
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

   Public Sub VisualizzaPaginaIndirizzi(ByVal n As Integer, ByVal sql As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sql, cn)

         ' Pulisce la tabella da precedenti dati.
         dtIndirizzi.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dtIndirizzi)

         ' Salva il numero di pagina corrente.
         pagCorrente = n

         ' Abilita/disabilita i pulsanti.
         Primo.Enabled = (n > 1)
         Precedente.Enabled = (n > 1)
         Successivo.Enabled = (n < numPagine)
         Ultimo.Enabled = (n < numPagine)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub VisualizzaPaginaArticoli(ByVal n As Integer, ByVal sql As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sql, cn)

         ' Pulisce la tabella da precedenti dati.
         dtArticoli.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dtArticoli)

         ' Salva il numero di pagina corrente.
         pagCorrente = n

         ' Abilita/disabilita i pulsanti.
         Primo.Enabled = (n > 1)
         Precedente.Enabled = (n > 1)
         Successivo.Enabled = (n < numPagine)
         Ultimo.Enabled = (n < numPagine)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub EliminaDatiIndirizzi(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Nome As String = dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 3)
         Dim Cognome As String = dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 2)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare l'etichetta """ & Cognome & " " & Nome & """?" & _
                              vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Nome & " " & Cognome & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_STRUMENTI_ETICHETTE)

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
         AggiornaDatiIndirizzi()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub EliminaDatiArticoli(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Codice As String = dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 1)
         Dim Descrizione As String = dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 2)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare l'etichetta """ & Codice & " - " & Descrizione & """?" & _
                           vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Codice & " - " & Descrizione & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_STRUMENTI_ETICHETTE)

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
         AggiornaDatiArticoli()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub AggiornaDatiIndirizzi()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            dgIndirizzi.DataSource = dtIndirizzi

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_ETICHETTE_INDIRIZZI)

            ' Collega la tabella clienti al controllo griglia dati.
            dgIndirizzi.DataSource = dtIndirizzi

            ' Visualizza la prima pagina di dati.
            VisualizzaPaginaIndirizzi(pagCorrente, sql)

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiArticoli()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            dgArticoli.DataSource = dtArticoli

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_ETICHETTE_ARTICOLI)

            ' Collega la tabella clienti al controllo griglia dati.
            dgArticoli.DataSource = dtArticoli

            ' Visualizza la prima pagina di dati.
            VisualizzaPaginaArticoli(pagCorrente, sql)

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         Modifica.Enabled = False
         Elimina.Enabled = False
         Primo.Enabled = False
         Precedente.Enabled = False
         Successivo.Enabled = False
         Ultimo.Enabled = False
         Aggiorna.Enabled = False
      Else
         ' Disattiva i pulsanti appropriati.
         Modifica.Enabled = True
         Elimina.Enabled = True
         Aggiorna.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.CodiciBarre) = True Then
         ImpostaComandi()
      End If
   End Sub

   Private Sub ApriDatiIndirizzi(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se Ë un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_ETICHETTE_INDIRIZZI)) = True Then
                  Exit Sub
               End If
            End If
         End If

         Dim frm As New IndirizziEtichette
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ApriDatiArticoli(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se Ë un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_ETICHETTE_ARTICOLI)) = True Then
                  Exit Sub
               End If
            End If
         End If

         Dim frm As New EtichetteArticoli
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If tbcElenco.SelectedIndex = 0 Then
            If numRecord <> 0 Then
               dgIndirizzi.CaptionText = Strings.UCase(dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 2) & " " & _
                                                     dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 3)) & " - " & _
                                                     "(Inizia la stampa dall'etichetta n∞: " & _
                                                     dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 11) & ")"
            Else
               dgIndirizzi.CaptionText = ""
            End If

         ElseIf tbcElenco.SelectedIndex = 1 Then
            If numRecord <> 0 Then
               dgArticoli.CaptionText = Strings.UCase(dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 1) & " " & _
                                                     dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 2)) & " - " & _
                                                     "(Inizia la stampa dall'etichetta n∞: " & _
                                                     dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 7) & ")"
            Else
               dgArticoli.CaptionText = ""
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n∞ totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonneIndirizzi(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice - non visibile
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 0
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)

         ' Titolo
         Dim titoloStyle As New ColonnaColorata(dgIndirizzi, Color.FromArgb(COLORE_ROSA), Color.Black)
         titoloStyle.MappingName = "Titolo"
         titoloStyle.HeaderText = "Titolo"
         titoloStyle.Width = 75
         titoloStyle.NullText = ""
         titoloStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(titoloStyle)
         ' Cognome
         Dim cognomeStyle As New ColonnaColorata(dgIndirizzi, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         cognomeStyle.MappingName = "Cognome"
         cognomeStyle.HeaderText = "Cognome"
         cognomeStyle.Width = 100
         cognomeStyle.NullText = ""
         cognomeStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(cognomeStyle)
         ' Nome
         Dim nomeStyle As New ColonnaColorata(dgIndirizzi, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         nomeStyle.MappingName = "Nome"
         nomeStyle.HeaderText = "Nome"
         nomeStyle.Width = 100
         nomeStyle.NullText = ""
         nomeStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(nomeStyle)
         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridTextBoxColumn
         Indirizzo1Style.MappingName = "Indirizzo"
         Indirizzo1Style.HeaderText = "Indirizzo"
         Indirizzo1Style.Width = 150
         Indirizzo1Style.NullText = ""
         Indirizzo1Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(Indirizzo1Style)
         ' Cap
         Dim capStyle As New DataGridTextBoxColumn
         capStyle.MappingName = "Cap"
         capStyle.HeaderText = "C.A.P."
         capStyle.Width = 60
         capStyle.NullText = ""
         capStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(capStyle)
         ' Citt‡
         Dim citt‡Style As New DataGridTextBoxColumn
         citt‡Style.MappingName = "Citt‡"
         citt‡Style.HeaderText = "Citt‡"
         citt‡Style.Width = 150
         citt‡Style.NullText = ""
         citt‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(citt‡Style)
         ' Provincia
         Dim provStyle As New DataGridTextBoxColumn
         provStyle.MappingName = "Provincia"
         provStyle.HeaderText = "Provincia"
         provStyle.Width = 60
         provStyle.NullText = ""
         provStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(provStyle)
         ' Quantit‡
         Dim qt‡Style As New ColonnaColorata(dgIndirizzi, Color.White, Color.Red)
         qt‡Style.MappingName = "Quantit‡"
         qt‡Style.HeaderText = "Numero etichette"
         qt‡Style.Width = 100
         qt‡Style.NullText = ""
         qt‡Style.Alignment = HorizontalAlignment.Right
         qt‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(qt‡Style)
         ' Formato
         Dim formatoStyle As New DataGridTextBoxColumn
         formatoStyle.MappingName = "Formato"
         formatoStyle.HeaderText = "Formato"
         formatoStyle.Width = 300
         formatoStyle.NullText = ""
         formatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(formatoStyle)
         ' Percorso report
         Dim percorsoStyle As New DataGridTextBoxColumn
         percorsoStyle.MappingName = "Percorso"
         percorsoStyle.HeaderText = "Percorso"
         percorsoStyle.Width = 0
         percorsoStyle.NullText = ""
         percorsoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(percorsoStyle)
         ' Posizione di stampa
         Dim posStampaStyle As New DataGridTextBoxColumn
         posStampaStyle.MappingName = "PosStampa"
         posStampaStyle.HeaderText = "PosStampa"
         posStampaStyle.Width = 0
         posStampaStyle.NullText = ""
         posStampaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(posStampaStyle)

         dgIndirizzi.TableStyles.Clear()
         dgIndirizzi.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneArticoli(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella
         ' Id - non visibile
         Dim idStyle As New DataGridTextBoxColumn
         idStyle.MappingName = "Id"
         idStyle.HeaderText = ""
         idStyle.Width = 0
         idStyle.NullText = ""
         idStyle.Alignment = HorizontalAlignment.Right
         idStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idStyle)
         ' Codice
         Dim codiceStyle As New ColonnaColorata(dgArticoli, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Codice"
         codiceStyle.HeaderText = "Codice Articolo"
         codiceStyle.Width = 100
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(dgArticoli, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 250
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Codice a barre
         Dim barcodStyle As New DataGridTextBoxColumn
         barcodStyle.MappingName = "CodBarre"
         barcodStyle.HeaderText = "Codice a barre"
         barcodStyle.Width = 100
         barcodStyle.NullText = ""
         barcodStyle.Alignment = HorizontalAlignment.Right
         barcodStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(barcodStyle)
         ' Quantit‡
         Dim Qt‡Style As New ColonnaColorata(dgArticoli, Color.White, Color.Red)
         Qt‡Style.MappingName = "Quantit‡"
         Qt‡Style.HeaderText = "Numero etichette"
         Qt‡Style.Width = 100
         Qt‡Style.NullText = ""
         Qt‡Style.Alignment = HorizontalAlignment.Right
         Qt‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(Qt‡Style)
         ' Formato
         Dim formatoStyle As New DataGridTextBoxColumn
         formatoStyle.MappingName = "Formato"
         formatoStyle.HeaderText = "Formato"
         formatoStyle.Width = 300
         formatoStyle.NullText = ""
         formatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(formatoStyle)
         ' Percorso report
         Dim percorsoStyle As New DataGridTextBoxColumn
         percorsoStyle.MappingName = "Percorso"
         percorsoStyle.HeaderText = "Percorso"
         percorsoStyle.Width = 0
         percorsoStyle.NullText = ""
         percorsoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(percorsoStyle)
         ' Posizione di stampa
         Dim posStampaStyle As New DataGridTextBoxColumn
         posStampaStyle.MappingName = "PosStampa"
         posStampaStyle.HeaderText = "PosStampa"
         posStampaStyle.Width = 0
         posStampaStyle.NullText = ""
         posStampaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(posStampaStyle)

         dgArticoli.TableStyles.Clear()
         dgArticoli.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
      Try
         Dim sql As String

         testoRicerca = FormattaApici(testoRicerca)

         If tbcElenco.SelectedIndex = 0 Then
            Select Case campoRicerca
               Case "C.A.P."
                  campoRicerca = "Cap"
               Case "Numero etichette"
                  campoRicerca = "Quantit‡"
            End Select

            If testoRicerca <> "" Then
               ' Crea la stringa sql.
               sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ETICHETTE_INDIRIZZI, campoRicerca, campoRicerca)
               repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ETICHETTE_INDIRIZZI, campoRicerca, campoRicerca)

               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDatiIndirizzi("(" & sql & ")", sql)
            Else
               sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id ASC", DIM_PAGINA_GRANDE, TAB_ETICHETTE_INDIRIZZI)
               repSql = String.Format("SELECT * FROM {0} ORDER BY Id ASC", TAB_ETICHETTE_INDIRIZZI)

               'repSql = String.Format("SELECT TOP {0} * INTO RepClienti FROM {1} ORDER BY Id ASC", dimPagina, NomeTabella)

               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDatiIndirizzi(TAB_ETICHETTE_INDIRIZZI, sql)
            End If

         ElseIf tbcElenco.SelectedIndex = 1 Then
            Select Case campoRicerca
               Case "Codice articolo"
                  campoRicerca = "Codice"
               Case "Codice a barre"
                  campoRicerca = "CodBarre"
               Case "Numero etichette"
                  campoRicerca = "Quantit‡"
            End Select

            If testoRicerca <> "" Then
               ' Crea la stringa sql.
               sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ETICHETTE_ARTICOLI, campoRicerca, campoRicerca)
               repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ETICHETTE_ARTICOLI, campoRicerca, campoRicerca)

               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDatiArticoli("(" & sql & ")", sql)
            Else
               sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id ASC", DIM_PAGINA_GRANDE, TAB_ETICHETTE_ARTICOLI)
               repSql = String.Format("SELECT * FROM {0} ORDER BY Id ASC", TAB_ETICHETTE_ARTICOLI)

               'repSql = String.Format("SELECT TOP {0} * INTO RepClienti FROM {1} ORDER BY Id ASC", dimPagina, NomeTabella)

               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDatiArticoli(TAB_ETICHETTE_ARTICOLI, sql)
            End If
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaCampiRicIndirizzi()
      Try
         CampoRicerca.Items.Clear()
         CampoRicerca.Items.Add("Titolo")
         CampoRicerca.Items.Add("Cognome")
         CampoRicerca.Items.Add("Nome")
         CampoRicerca.Items.Add("Indirizzo")
         CampoRicerca.Items.Add("C.A.P.")
         CampoRicerca.Items.Add("Citt‡")
         CampoRicerca.Items.Add("Provincia")
         CampoRicerca.Items.Add("Numero etichette")
         CampoRicerca.Items.Add("Formato")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub CaricaCampiRicArticoli()
      Try
         CampoRicerca.Items.Clear()
         CampoRicerca.Items.Add("Codice articolo")
         CampoRicerca.Items.Add("Descrizione")
         CampoRicerca.Items.Add("Codice a barre")
         CampoRicerca.Items.Add("Numero etichette")
         CampoRicerca.Items.Add("Formato")

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

   Private Sub DuplicaEtichetteInd()
      Dim CEtichetteInd As New EtichetteInd
      Dim posizioneStampa As Short

      Try
         With CEtichetteInd
            ' Crea delle righe vuote.
            .Titolo = " "
            .Cognome = " "
            .Nome = " "
            .Indirizzo = " "
            .Cap = " "
            .Citt‡ = " "
            .Provincia = " "
            .Quantit‡ = 1
            .Formato = FormattaApici(dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 9))
            .Percorso = FormattaApici(dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 10))

            If IsNumeric(dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 11)) = True Then
               .PosStampa = dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 11)
            Else
               .PosStampa = 1
            End If

            If .PosStampa > 1 Then
               posizioneStampa = .PosStampa - 1

               Dim i As Integer
               For i = 1 To posizioneStampa
                  .InserisciDati(TAB_ETICHETTE_INDIRIZZI_REP)
               Next i
            End If

            .LeggiDati(TAB_ETICHETTE_INDIRIZZI, dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 0))

            Dim j As Integer
            For j = 1 To .Quantit‡
               .InserisciDati(TAB_ETICHETTE_INDIRIZZI_REP)
            Next j
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub DuplicaEtichetteArt()
      Dim CEtichetteArt As New EtichetteArt
      Dim posizioneStampa As Short

      Try
         With CEtichetteArt
            ' Crea delle righe vuote.
            .Codice = " "
            .CodBarre = " "
            .CodBarreTipo = " "
            .CodBarrePercorsoImg = " "
            Dim b() As Byte = {&H0, &H12, &H34, &H56, &HAA, &H55, &HFF}
            .CodBarreImg = b
            .Descrizione = " "
            .Prezzo = " "
            .Data = Nothing
            .Quantit‡ = 1
            .Formato = FormattaApici(dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 5))
            .Percorso = FormattaApici(dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 6))

            If IsNumeric(dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 7)) = True Then
               .PosStampa = dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 7)
            Else
               .PosStampa = 1
            End If

            If .PosStampa > 1 Then
               posizioneStampa = .PosStampa - 1

               Dim i As Integer
               For i = 1 To posizioneStampa
                  .InserisciDati(TAB_ETICHETTE_ARTICOLI_REP)
               Next i
            End If

            .LeggiDati(TAB_ETICHETTE_ARTICOLI, dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 0))

            Dim j As Integer
            For j = 1 To .Quantit‡
               .InserisciDati(TAB_ETICHETTE_ARTICOLI_REP)
            Next j
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub EliminaEtichette(ByVal tabella As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         'sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)
         sql = String.Format("DELETE FROM {0}", tabella)

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

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try

         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
            Dim cn As New OleDbConnection(ConnString)

            cn.Open()

            Dim oleAdapter As New OleDbDataAdapter

            oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

            Dim ds As New Dataset1

            ds.Clear()

            oleAdapter.Fill(ds, tabella)

            Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            rep.Load(Application.StartupPath & nomeDoc)

            rep.SetDataSource(ds)

            rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True, _
                               PrintDialog1.PrinterSettings.FromPage, _
                               PrintDialog1.PrinterSettings.ToPage)

            cn.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ElencoEtichette_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub ElencoEtichette_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmEtichette)

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Distrugge l'oggetto e libera le risorse.
         g_frmEtichette.Dispose()
         g_frmEtichette = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_STRUMENTI_ETICHETTE, MODULO_STRUMENTI_ETICHETTE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoEtichette_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' *** ARTICOLI ***
         ' Crea le colonne della griglia dati.
         CreaColonneArticoli(TAB_ETICHETTE_ARTICOLI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRicArticoli()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", DIM_PAGINA_GRANDE, TAB_ETICHETTE_ARTICOLI)
         LeggiDatiArticoli(TAB_ETICHETTE_ARTICOLI, sql)

         ' *** INDIRIZZI ***
         ' Crea le colonne della griglia dati.
         CreaColonneIndirizzi(TAB_ETICHETTE_INDIRIZZI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRicIndirizzi()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", DIM_PAGINA_GRANDE, TAB_ETICHETTE_INDIRIZZI)
         LeggiDatiIndirizzi(TAB_ETICHETTE_INDIRIZZI, sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         loadEseguito = True

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_ETICHETTE, MODULO_STRUMENTI_ETICHETTE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Nuovo"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_STRUMENTI_ETICHETTE, MODULO_STRUMENTI_ETICHETTE)

            If tbcElenco.SelectedIndex = 0 Then
               ' Apre la finestra per l'inserimento di nuovi dati.
               ApriDatiIndirizzi("")

            ElseIf tbcElenco.SelectedIndex = 1 Then
               ' Apre la finestra per l'inserimento di nuovi dati.
               ApriDatiArticoli("")
            End If

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

         Case "Modifica"
            registraModifica()

            If tbcElenco.SelectedIndex = 0 Then
               ' Apre la finestra per l'inserimento di nuovi dati.
               ApriDatiIndirizzi(CStr(dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 0)))

            ElseIf tbcElenco.SelectedIndex = 1 Then
               ' Apre la finestra per l'inserimento di nuovi dati.
               ApriDatiArticoli(CStr(dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 0)))
            End If

         Case "Elimina"
            If tbcElenco.SelectedIndex = 0 Then
               ' Elimina il valore selezionato.
               EliminaDatiIndirizzi(TAB_ETICHETTE_INDIRIZZI, dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 0))

            ElseIf tbcElenco.SelectedIndex = 1 Then
               ' Elimina il valore selezionato.
               EliminaDatiArticoli(TAB_ETICHETTE_ARTICOLI, dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 0))
            End If

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_STRUMENTI_ETICHETTE, MODULO_STRUMENTI_ETICHETTE)

            If tbcElenco.SelectedIndex = 0 Then
               EliminaEtichette(TAB_ETICHETTE_INDIRIZZI_REP)
               DuplicaEtichetteInd()
               StampaDocumento(dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 10), TAB_ETICHETTE_INDIRIZZI_REP, "SELECT * FROM " & " " & TAB_ETICHETTE_INDIRIZZI_REP)
            ElseIf tbcElenco.SelectedIndex = 1 Then

            End If

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_STRUMENTI_ETICHETTE, MODULO_STRUMENTI_ETICHETTE)

            If tbcElenco.SelectedIndex = 0 Then
               EliminaEtichette(TAB_ETICHETTE_INDIRIZZI_REP)
               DuplicaEtichetteInd()
               g_frmMain.ApriReports("SELECT * FROM " & " " & TAB_ETICHETTE_INDIRIZZI_REP, TAB_ETICHETTE_INDIRIZZI_REP, dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 10))

            ElseIf tbcElenco.SelectedIndex = 1 Then
               EliminaEtichette(TAB_ETICHETTE_ARTICOLI_REP)
               DuplicaEtichetteArt()
               g_frmMain.ApriReports("SELECT * FROM " & " " & TAB_ETICHETTE_ARTICOLI_REP, TAB_ETICHETTE_ARTICOLI_REP, dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 6))
            End If

         Case "Primo"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, TAB_ETICHETTE)

            '' Visualizza la prima pagina di dati.
            'VisualizzaPagina(1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Precedente"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} ORDER BY Id DESC) ORDER BY Id", TAB_ETICHETTE, dimPagina, TAB_ETICHETTE, dt.Rows(0)("Id"))

            '' Visualizza la pagina di dati precedente.
            'VisualizzaPagina(pagCorrente - 1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Successivo"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} ORDER BY Id", dimPagina, TAB_ETICHETTE, dt.Rows(dt.Rows.Count - 1)("Id"))

            '' Visualizza la pagina di dati successiva.
            'VisualizzaPagina(pagCorrente + 1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Ultimo"
            'Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            '' Crea la stringa sql.
            'sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} ORDER BY Id DESC) ORDER BY Id", TAB_ETICHETTE, num, TAB_ETICHETTE)

            '' Visualizza l'ultima pagina di dati.
            'VisualizzaPagina(numPagine, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_STRUMENTI_ETICHETTE, MODULO_STRUMENTI_ETICHETTE)

            If tbcElenco.SelectedIndex = 0 Then
               ' Aggiorna la griglia dati.
               AggiornaDatiIndirizzi()

            ElseIf tbcElenco.SelectedIndex = 1 Then
               ' Aggiorna la griglia dati.
               AggiornaDatiArticoli()
            End If

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

      End Select
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampoRicerca.SelectedIndexChanged
      If loadEseguito = False Then
         Exit Sub
      End If

      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub tbcElenco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcElenco.SelectedIndexChanged
      If loadEseguito = False Then
         Exit Sub
      End If

      If tbcElenco.SelectedIndex = 0 Then
         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRicIndirizzi()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", DIM_PAGINA_GRANDE, TAB_ETICHETTE_INDIRIZZI)
         LeggiDatiIndirizzi(TAB_ETICHETTE_INDIRIZZI, sql)

      ElseIf tbcElenco.SelectedIndex = 1 Then
         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRicArticoli()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", DIM_PAGINA_GRANDE, TAB_ETICHETTE_ARTICOLI)
         LeggiDatiArticoli(TAB_ETICHETTE_ARTICOLI, sql)
      End If

      ' Se nella tabella non ci sono record disattiva i pulsanti.
      ConvalidaDati()

      ' Aggiorna l'intestazione della griglia dati.
      AggIntGriglia()

      ' Aggiorna il titolo della finestra.
      AggTitoloFinestra(TITOLO_FINESTRA)
   End Sub

   Private Sub dgArticoli_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgArticoli.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub dgIndirizzi_CurrentCellChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgIndirizzi.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub dgIndirizzi_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgIndirizzi.DoubleClick
      If Modifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         registraModifica()

         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDatiIndirizzi(CStr(dgIndirizzi.Item(dgIndirizzi.CurrentCell.RowNumber, 0)))
      End If
   End Sub

   Private Sub dgArticoli_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgArticoli.DoubleClick
      If Modifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         registraModifica()

         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDatiArticoli(CStr(dgArticoli.Item(dgArticoli.CurrentCell.RowNumber, 0)))
      End If
   End Sub
End Class
