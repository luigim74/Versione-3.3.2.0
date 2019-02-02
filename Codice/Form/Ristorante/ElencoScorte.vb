' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 10/08/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoScorte
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Const TITOLO_FINESTRA As String = "Elenco Articoli e Ingredienti con giacenza negativa o sotto scorta"
   Dim TAB_ARTICOLI = "Articoli"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnStringAnagrafiche)
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
   Dim repSql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   Private DatiConfig As AppConfig

#End Region

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_ARTICOLI)

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
   Friend WithEvents Stampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents Anteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents Primo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Precedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents Successivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Ultimo As System.Windows.Forms.ToolBarButton
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents Aggiorna As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Carico As System.Windows.Forms.ToolBarButton
   Friend WithEvents Scarico As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoScorte))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Carico = New System.Windows.Forms.ToolBarButton()
      Me.Scarico = New System.Windows.Forms.ToolBarButton()
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
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Carico, Me.Scarico, Me.ToolBarButton4, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.ToolBarButton7, Me.Aggiorna, Me.ToolBarButton1, Me.Anteprima, Me.Stampa})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(592, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'Carico
      '
      Me.Carico.ImageIndex = 10
      Me.Carico.Name = "Carico"
      Me.Carico.Tag = "Carico"
      Me.Carico.Text = "Carico"
      Me.Carico.ToolTipText = "Carico"
      '
      'Scarico
      '
      Me.Scarico.ImageIndex = 11
      Me.Scarico.Name = "Scarico"
      Me.Scarico.Tag = "Scarico"
      Me.Scarico.Text = "Scarico"
      Me.Scarico.ToolTipText = "Scarico"
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
      '
      'Precedente
      '
      Me.Precedente.ImageIndex = 4
      Me.Precedente.Name = "Precedente"
      Me.Precedente.Tag = "Precedente"
      Me.Precedente.ToolTipText = "Pagina precedente "
      '
      'Successivo
      '
      Me.Successivo.ImageIndex = 5
      Me.Successivo.Name = "Successivo"
      Me.Successivo.Tag = "Successivo"
      Me.Successivo.ToolTipText = "Pagina successiva"
      '
      'Ultimo
      '
      Me.Ultimo.ImageIndex = 6
      Me.Ultimo.Name = "Ultimo"
      Me.Ultimo.Tag = "Ultimo"
      Me.Ultimo.ToolTipText = "Ultima pagina"
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
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
      Me.ImageList1.Images.SetKeyName(10, "")
      Me.ImageList1.Images.SetKeyName(11, "")
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
      Me.DataGrid1.Location = New System.Drawing.Point(0, 56)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(592, 269)
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
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(592, 30)
      Me.Panel1.TabIndex = 0
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(450, 8)
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
      Me.Label2.Location = New System.Drawing.Point(362, 8)
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
      Me.TestoRicerca.Location = New System.Drawing.Point(118, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(241, 20)
      Me.TestoRicerca.TabIndex = 0
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = ""
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ElencoScorte
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(592, 326)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoScorte"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Scorte"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("WSScorte") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSScorte") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AScorte") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AScorte"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LScorte") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LScorte"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("ScorteX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("ScorteX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("ScorteY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("ScorteY")))
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

         DatiConfig.SetValue("WSScorte", Me.WindowState)
         DatiConfig.SetValue("ScorteX", Me.Location.X)
         DatiConfig.SetValue("ScorteY", Me.Location.Y)
         DatiConfig.SetValue("AScorte", Me.Height)
         DatiConfig.SetValue("LScorte", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Scorte
               If operatore.MagScorte = VALORE_LETTURA Then
                  Carico.Enabled = False
                  Scarico.Enabled = False
               Else
                  Carico.Enabled = True
                  Scarico.Enabled = True
               End If
         End Select

         Return Carico.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

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

   Sub LeggiNumPagine(ByVal tabella As String)
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE SituazioneScorta < 0 OR Giacenza < 0", tabella)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
         If closeOnExit Then cn.Close()

         If TestoRicerca.Text <> "" Then
            numPagine = 1
         Else
            ' Ottiene il numero di pagine.
            numPagine = (numRecord + dimPagina - 1) \ dimPagina
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

   Public Sub AggiornaDati()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_ARTICOLI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(pagCorrente, sql)

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
         Carico.Enabled = False
         Scarico.Enabled = False
         Primo.Enabled = False
         Precedente.Enabled = False
         Successivo.Enabled = False
         Ultimo.Enabled = False
         Aggiorna.Enabled = False
      Else
         ' Disattiva i pulsanti appropriati.
         Carico.Enabled = True
         Scarico.Enabled = True
         Aggiorna.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.Scorte) = True Then
         ImpostaComandi()
      End If
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " & _
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))
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
      Me.Text = titolo & " (n∞ totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonneScorte(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella
         ' Id (non visibile)
         Dim idStyle As New DataGridTextBoxColumn
         idStyle.MappingName = "Id"
         idStyle.HeaderText = "Id"
         idStyle.Width = 0
         idStyle.NullText = ""
         idStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idStyle)
         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Codice"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 70
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 200
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Unit‡ di misura
         Dim umStyle As New DataGridTextBoxColumn
         umStyle.MappingName = "Unit‡Misura"
         umStyle.HeaderText = "U.M."
         umStyle.Width = 50
         umStyle.NullText = ""
         umStyle.Alignment = HorizontalAlignment.Center
         umStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(umStyle)
         ' Giacenza
         Dim giacenzaStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         giacenzaStyle.MappingName = "Giacenza"
         giacenzaStyle.HeaderText = "Giacenza"
         giacenzaStyle.Width = 60
         giacenzaStyle.NullText = ""
         giacenzaStyle.Format = "##,##0.000"
         giacenzaStyle.Alignment = HorizontalAlignment.Right
         giacenzaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(giacenzaStyle)
         ' Caricato
         Dim caricatoStyle As New DataGridTextBoxColumn
         caricatoStyle.MappingName = "Carico"
         caricatoStyle.HeaderText = ""
         caricatoStyle.Width = 0
         caricatoStyle.NullText = ""
         caricatoStyle.Format = "##,##0.000"
         caricatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(caricatoStyle)
         ' Scaricato
         Dim scaricatoStyle As New DataGridTextBoxColumn
         scaricatoStyle.MappingName = "Scarico"
         scaricatoStyle.HeaderText = ""
         scaricatoStyle.Width = 0
         scaricatoStyle.NullText = ""
         scaricatoStyle.Format = "##,##0.000"
         scaricatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(scaricatoStyle)
         ' Prezzo Acquisto
         Dim pAcquistoStyle As New DataGridTextBoxColumn
         pAcquistoStyle.MappingName = "PrezzoAcquisto"
         pAcquistoStyle.HeaderText = ""
         pAcquistoStyle.Width = 0
         pAcquistoStyle.NullText = ""
         pAcquistoStyle.Format = "##,##0.00"
         pAcquistoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(pAcquistoStyle)
         ' Scorta minima
         Dim smStyle As New DataGridTextBoxColumn
         smStyle.MappingName = "ScortaMin"
         smStyle.HeaderText = "Scorta minima"
         smStyle.Width = 90
         smStyle.NullText = ""
         smStyle.Format = "##,##0.000"
         smStyle.Alignment = HorizontalAlignment.Right
         smStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(smStyle)
         ' Situazione scorte
         Dim situazioneStyle As New DataGridTextBoxColumn
         situazioneStyle.MappingName = "SituazioneScorta"
         situazioneStyle.HeaderText = "Situazione"
         situazioneStyle.Width = 70
         situazioneStyle.NullText = ""
         situazioneStyle.Format = "##,##0.000"
         situazioneStyle.Alignment = HorizontalAlignment.Right
         situazioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(situazioneStyle)
         ' Categoria
         Dim categoriaStyle As New DataGridTextBoxColumn
         categoriaStyle.MappingName = "Categoria"
         categoriaStyle.HeaderText = "Categoria"
         categoriaStyle.Width = 100
         categoriaStyle.NullText = ""
         categoriaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(categoriaStyle)
         ' Fornitore
         Dim fornitoreStyle As New DataGridTextBoxColumn
         fornitoreStyle.MappingName = "Fornitore"
         fornitoreStyle.HeaderText = "Fornitore"
         fornitoreStyle.Width = 150
         fornitoreStyle.NullText = ""
         fornitoreStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(fornitoreStyle)
         ' Magazzino
         Dim magazzinoStyle As New DataGridTextBoxColumn
         magazzinoStyle.MappingName = "Magazzino"
         magazzinoStyle.HeaderText = "Magazzino"
         magazzinoStyle.Width = 100
         magazzinoStyle.NullText = ""
         magazzinoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(magazzinoStyle)
         ' Codice a barre
         Dim barcodStyle As New DataGridTextBoxColumn
         barcodStyle.MappingName = "CodBarre"
         barcodStyle.HeaderText = "Codice a barre"
         barcodStyle.Width = 90
         barcodStyle.NullText = ""
         barcodStyle.Alignment = HorizontalAlignment.Right
         barcodStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(barcodStyle)

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
            Case "Codice a barre"
               campoRicerca = "CodBarre"
            Case "Unit‡ di misura"
               campoRicerca = "Unit‡Misura"
            Case "Prezzo di acquisto"
               campoRicerca = "PrezzoAcquisto"
            Case "Scorta minima"
               campoRicerca = "ScortaMin"
            Case "Situazione"
               campoRicerca = "SituazioneScorta"
         End Select

         If testoRicerca <> "" Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE (SituazioneScorta < 0 OR Giacenza < 0) AND ({1} LIKE '" & testoRicerca & "%') ORDER BY {2} ASC", TAB_ARTICOLI, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE (SituazioneScorta < 0 OR Giacenza < 0) AND ({1} LIKE '" & testoRicerca & "%') ORDER BY {2} ASC", TAB_ARTICOLI, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE SituazioneScorta < 0 OR Giacenza < 0 ORDER BY Codice ASC", dimPagina, TAB_ARTICOLI)
            repSql = String.Format("SELECT * FROM {0} WHERE SituazioneScorta < 0 OR Giacenza < 0 ORDER BY Codice ASC", TAB_ARTICOLI)

            'repSql = String.Format("SELECT TOP {0} * INTO RepClienti FROM {1} ORDER BY Id ASC", dimPagina, NomeTabella)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_ARTICOLI, sql)
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

   Private Sub CaricaCampiRic()
      Try
         CampoRicerca.Items.Add("Codice")
         CampoRicerca.Items.Add("Descrizione")
         CampoRicerca.Items.Add("Unit‡ di misura")
         CampoRicerca.Items.Add("Giacenza")
         CampoRicerca.Items.Add("Scorta minima")
         CampoRicerca.Items.Add("Situazione")
         CampoRicerca.Items.Add("Categoria")
         CampoRicerca.Items.Add("Fornitore")
         CampoRicerca.Items.Add("Magazzino")
         CampoRicerca.Items.Add("Codice a barre")

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

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String, Optional ByVal frmId As String = "")
      Dim cn As OleDbConnection

      Try
         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            If frmId = "Clienti" Then
               ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

               ' Dichiara un oggetto connessione.
               cn = New OleDbConnection(ConnStringAnagrafiche)
            Else
               'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
               cn = New OleDbConnection(ConnString)
            End If

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

   Private Sub ElencoScorte_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub ElencoScorte_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmScorte)

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Distrugge l'oggetto e libera le risorse.
         g_frmScorte.Dispose()
         g_frmScorte = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_MAGAZZINO_SCORTE, MODULO_MAGAZZINO_SCORTE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoScorte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonneScorte(TAB_ARTICOLI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE SituazioneScorta < 0 OR Giacenza < 0 ORDER BY Codice", dimPagina, TAB_ARTICOLI)
         LeggiDati(TAB_ARTICOLI, sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione efettuata dall'operatore identificato.
         strModulo = MODULO_MAGAZZINO_SCORTE

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_MAGAZZINO_SCORTE, MODULO_MAGAZZINO_SCORTE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ElencoScorte_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Carico"
            Dim frm As New CaricoScarico("Carico", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 11), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 12))
            frm.ShowDialog()

         Case "Scarico"
            Dim frm As New CaricoScarico("Scarico", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7), , _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 12))
            frm.ShowDialog()

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_MAGAZZINO_SCORTE, MODULO_MAGAZZINO_SCORTE)

            StampaDocumento(PERCORSO_REP_SCORTE, TAB_ARTICOLI, repSql)

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_MAGAZZINO_SCORTE, MODULO_MAGAZZINO_SCORTE)

            g_frmMain.ApriReports(repSql, TAB_ARTICOLI, PERCORSO_REP_SCORTE)

         Case "Primo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE SituazioneScorta < 0 OR Giacenza < 0 ORDER BY Id", dimPagina, TAB_ARTICOLI)

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Precedente"
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} AND (SituazioneScorta < 0 OR Giacenza < 0) ORDER BY Id DESC) ORDER BY Id", TAB_ARTICOLI, dimPagina, TAB_ARTICOLI, dt.Rows(0)("Id"))

            ' Visualizza la pagina di dati precedente.
            VisualizzaPagina(pagCorrente - 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Successivo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} AND (SituazioneScorta < 0 OR Giacenza < 0) ORDER BY Id", dimPagina, TAB_ARTICOLI, dt.Rows(dt.Rows.Count - 1)("Id"))

            ' Visualizza la pagina di dati successiva.
            VisualizzaPagina(pagCorrente + 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Ultimo"
            Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE (SituazioneScorta < 0 OR Giacenza < 0) ORDER BY Id DESC) ORDER BY Id", TAB_ARTICOLI, num, TAB_ARTICOLI)

            ' Visualizza l'ultima pagina di dati.
            VisualizzaPagina(numPagine, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_MAGAZZINO_SCORTE, MODULO_MAGAZZINO_SCORTE)

            ' Aggiorna la griglia dati.
            AggiornaDati()

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

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

End Class
