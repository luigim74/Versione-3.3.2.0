' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 15/04/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class frmElencoAcquisti
   Inherits System.Windows.Forms.Form

   Const TAB_ACQUISTI As String = "Acquisti"
   Const TITOLO_FINESTRA As String = "Elenco documenti di Acquisto"
   Const COLONNA_IMPORTO As Short = 5

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   'Dim TipoElenco As Short
   'Dim NomeTabella As String
   'Dim TitoloFinestra As String

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

   Private DatiConfig As AppConfig
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private CFormatta As New ClsFormatta

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_ACQUISTI)

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
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
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
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents txtTotImporto As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Nuovo As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoAcquisti))
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
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtTotImporto = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(590, 26)
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
      Me.DataGrid1.Size = New System.Drawing.Size(590, 284)
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
      Me.Panel1.Size = New System.Drawing.Size(590, 30)
      Me.Panel1.TabIndex = 0
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(448, 8)
      Me.CampoRicerca.Name = "CampoRicerca"
      Me.CampoRicerca.Size = New System.Drawing.Size(136, 21)
      Me.CampoRicerca.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.SystemColors.Control
      Me.Label2.Location = New System.Drawing.Point(359, 8)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 15)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "Ricerca per:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.Control
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
      Me.TestoRicerca.Location = New System.Drawing.Point(115, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(230, 20)
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
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.txtTotImporto)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 342)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(590, 32)
      Me.Panel2.TabIndex = 13
      '
      'txtTotImporto
      '
      Me.txtTotImporto.AcceptsReturn = True
      Me.txtTotImporto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotImporto.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotImporto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotImporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotImporto.ForeColor = System.Drawing.Color.Red
      Me.txtTotImporto.Location = New System.Drawing.Point(446, 6)
      Me.txtTotImporto.MaxLength = 0
      Me.txtTotImporto.Name = "txtTotImporto"
      Me.txtTotImporto.ReadOnly = True
      Me.txtTotImporto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotImporto.Size = New System.Drawing.Size(136, 20)
      Me.txtTotImporto.TabIndex = 235
      Me.txtTotImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.White
      Me.Label6.Location = New System.Drawing.Point(337, 8)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(105, 15)
      Me.Label6.TabIndex = 16
      Me.Label6.Text = "Totale acquisti:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmElencoAcquisti
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(590, 374)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmElencoAcquisti"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco documenti di Acquisto"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
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

         If DatiConfig.GetValue("WSAcquisti") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSAcquisti") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AAcquisti") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AAcquisti"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LAcquisti") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LAcquisti"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("AcquistiX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("AcquistiX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("AcquistiY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("AcquistiY")))
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

         DatiConfig.SetValue("WSAcquisti", Me.WindowState)
         DatiConfig.SetValue("AcquistiX", Me.Location.X)
         DatiConfig.SetValue("AcquistiY", Me.Location.Y)
         DatiConfig.SetValue("AAcquisti", Me.Height)
         DatiConfig.SetValue("LAcquisti", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Acquisti
               If operatore.GestAcquisti = VALORE_LETTURA Then
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
         Dim Fornitore As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
         Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
         Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
         Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
         Dim strDescrizione As String = "(" & Fornitore & " - " & Documento & " n. " & Numero & " del " & Data & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Modifica, strDescrizione, MODULO_GESTIONE_ACQUISTI)

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

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Fornitore As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
         Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
         Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
         Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare il documento """ & Fornitore & " - " & Documento & " n. " & Numero & " del " & Data & """?" & _
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

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Fornitore & " - " & Documento & " n. " & Numero & " del " & Data & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_GESTIONE_ACQUISTI)

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
            LeggiNumPagine(TAB_ACQUISTI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(pagCorrente, sql)

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)

            ' Somma i valori della colonna Importo.
            txtTotImporto.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO, numRecord))
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
      If ImpostaFunzioniOperatore(Finestra.Acquisti) = True Then
         ImpostaComandi()
      End If

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
               If VerificaNumRecord(LeggiNumRecord(TAB_ACQUISTI)) = True Then
                  Exit Sub
               End If
            End If
         End If

         Dim frm As New frmAcquisti
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
            DataGrid1.CaptionText = Strings.UCase(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " - " & _
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) & " n. " & _
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) & " del " & _
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
      Me.Text = titolo & " (n° totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 0
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Fornitore
         Dim fornitoreStyle As New DataGridTextBoxColumn
         fornitoreStyle.MappingName = "Destinatario"
         fornitoreStyle.HeaderText = "Fornitore"
         fornitoreStyle.Width = 150
         fornitoreStyle.NullText = ""
         fornitoreStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(fornitoreStyle)
         ' Data documento
         Dim dataStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         dataStyle.MappingName = "DataDoc"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 75
         dataStyle.NullText = ""
         dataStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Documento
         Dim documentoStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         documentoStyle.MappingName = "TipoDoc"
         documentoStyle.HeaderText = "Documento"
         documentoStyle.Width = 150
         documentoStyle.NullText = ""
         documentoStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(documentoStyle)
         ' Numero documento
         Dim numeroStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         numeroStyle.MappingName = "NumDoc"
         numeroStyle.HeaderText = "N°"
         numeroStyle.Width = 50
         numeroStyle.NullText = ""
         numeroStyle.Format = "##,##0"
         numeroStyle.Alignment = HorizontalAlignment.Right
         numeroStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(numeroStyle)
         ' Totale documento
         Dim totDocStyle As New DataGridTextBoxColumn
         totDocStyle.MappingName = "TotDoc"
         totDocStyle.HeaderText = "Totale documento"
         totDocStyle.Width = 100
         totDocStyle.NullText = ""
         totDocStyle.Format = "##,##0.00"
         totDocStyle.Alignment = HorizontalAlignment.Right
         totDocStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(totDocStyle)
         ' Pagamento
         Dim pagamentoStyle As New DataGridTextBoxColumn
         pagamentoStyle.MappingName = "ModPagamento"
         pagamentoStyle.HeaderText = "Pagamento"
         pagamentoStyle.Width = 150
         pagamentoStyle.NullText = ""
         pagamentoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(pagamentoStyle)
         ' Note
         Dim noteStyle As New DataGridTextBoxColumn
         noteStyle.MappingName = "Note"
         noteStyle.HeaderText = "Note"
         noteStyle.Width = 300
         noteStyle.NullText = ""
         noteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(noteStyle)

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
            Case "Fornitore"
               campoRicerca = "Destinatario"
            Case "Data"
               campoRicerca = "DataDoc"
            Case "Documento"
               campoRicerca = "TipoDoc"
            Case "Numero documento"
               campoRicerca = "NumDoc"
            Case "Totale documento"
               campoRicerca = "TotDoc"
            Case "Pagamento"
               campoRicerca = "ModPagamento"
            Case "Note"
               campoRicerca = "NoteInt"
         End Select

         If testoRicerca <> "" Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ACQUISTI, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ACQUISTI, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id ASC", DIM_PAGINA_GRANDE, TAB_ACQUISTI)
            repSql = String.Format("SELECT * FROM {0} ORDER BY Id ASC", TAB_ACQUISTI)

            'repSql = String.Format("SELECT TOP {0} * INTO RepClienti FROM {1} ORDER BY Id ASC", dimPagina, NomeTabella)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_ACQUISTI, sql)
         End If

         ' Somma i valori della colonna Importo.
         txtTotImporto.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO, numRecord))

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
         CampoRicerca.Items.Add("Fornitore")
         CampoRicerca.Items.Add("Data")
         CampoRicerca.Items.Add("Documento")
         CampoRicerca.Items.Add("Numero documento")
         CampoRicerca.Items.Add("Totale documento")
         CampoRicerca.Items.Add("Pagamento")
         CampoRicerca.Items.Add("Note")

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

   Private Sub frmElencoAcquisti_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub frmElencoAcquisti_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmAcquisti)

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Distrugge l'oggetto e libera le risorse.
         g_frmAcquisti.Dispose()
         g_frmAcquisti = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_ELENCO_ACQUISTI, MODULO_GESTIONE_ACQUISTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmElencoAcquisti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_ACQUISTI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 0

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", DIM_PAGINA_GRANDE, TAB_ACQUISTI)
         LeggiDati(TAB_ACQUISTI, sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_ELENCO_ACQUISTI, MODULO_GESTIONE_ACQUISTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Nuovo"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_ELENCO_ACQUISTI, MODULO_GESTIONE_ACQUISTI)

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDati("")

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

         Case "Modifica"
            ' Registra loperazione efettuata dall'operatore identificato.
            registraModifica()

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

         Case "Elimina"
            ' Elimina il valore selezionato.
            EliminaDati(TAB_ACQUISTI, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_ELENCO_ACQUISTI, MODULO_GESTIONE_ACQUISTI)

            StampaDocumento(PERCORSO_REP_ACQUISTI, TAB_ACQUISTI, repSql)

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_ELENCO_ACQUISTI, MODULO_GESTIONE_ACQUISTI)

            g_frmMain.ApriReports(repSql, TAB_ACQUISTI, PERCORSO_REP_ACQUISTI)

         Case "Primo"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, TAB_ACQUISTI)

            '' Visualizza la prima pagina di dati.
            'VisualizzaPagina(1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Precedente"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} ORDER BY Id DESC) ORDER BY Id", TAB_ACQUISTI, dimPagina, TAB_ACQUISTI, dt.Rows(0)("Id"))

            '' Visualizza la pagina di dati precedente.
            'VisualizzaPagina(pagCorrente - 1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Successivo"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} ORDER BY Id", dimPagina, TAB_ACQUISTI, dt.Rows(dt.Rows.Count - 1)("Id"))

            '' Visualizza la pagina di dati successiva.
            'VisualizzaPagina(pagCorrente + 1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Ultimo"
            'Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            '' Crea la stringa sql.
            'sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} ORDER BY Id DESC) ORDER BY Id", TAB_ACQUISTI, num, TAB_ACQUISTI)

            '' Visualizza l'ultima pagina di dati.
            'VisualizzaPagina(numPagine, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_ELENCO_ACQUISTI, MODULO_GESTIONE_ACQUISTI)

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

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      If Modifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         registraModifica()

         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      End If
   End Sub

End Class
