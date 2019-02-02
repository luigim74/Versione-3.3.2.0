Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class Menu
   Inherits System.Windows.Forms.Form

   Const TAB_PIATTI As String = "Piatti"
   Const TAB_CATEGORIE As String = "CategoriePiatti"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter
   Dim ds As New DataSet
   Dim dt As DataTable
   Dim sql As String
   Dim repSql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   Dim percorsoReports As String = PERCORSO_REP_MENU_ARIAL

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
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents lstCategorie As System.Windows.Forms.ListBox
   Friend WithEvents tbSu As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbGiu As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbListino1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbListino2 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbListino3 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbListino4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbAnteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbStile2 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbStile1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbStile3 As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbSu = New System.Windows.Forms.ToolBarButton()
      Me.tbGiu = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton()
      Me.tbListino1 = New System.Windows.Forms.ToolBarButton()
      Me.tbListino2 = New System.Windows.Forms.ToolBarButton()
      Me.tbListino3 = New System.Windows.Forms.ToolBarButton()
      Me.tbListino4 = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton6 = New System.Windows.Forms.ToolBarButton()
      Me.tbStile1 = New System.Windows.Forms.ToolBarButton()
      Me.tbStile2 = New System.Windows.Forms.ToolBarButton()
      Me.tbStile3 = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
      Me.tbAnteprima = New System.Windows.Forms.ToolBarButton()
      Me.lstCategorie = New System.Windows.Forms.ListBox()
      Me.Label3 = New System.Windows.Forms.Label()
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
      'ToolBar1
      '
      Me.ToolBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.AutoSize = False
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbSu, Me.tbGiu, Me.ToolBarButton5, Me.tbListino1, Me.tbListino2, Me.tbListino3, Me.tbListino4, Me.ToolBarButton6, Me.tbStile1, Me.tbStile2, Me.tbStile3, Me.ToolBarButton1, Me.tbAnteprima})
      Me.ToolBar1.ButtonSize = New System.Drawing.Size(80, 22)
      Me.ToolBar1.Divider = False
      Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(307, 32)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(88, 360)
      Me.ToolBar1.TabIndex = 3
      Me.ToolBar1.Tag = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'tbSu
      '
      Me.tbSu.ImageIndex = 2
      Me.tbSu.Name = "tbSu"
      Me.tbSu.Tag = "Su"
      Me.tbSu.Text = "Sposta su"
      Me.tbSu.ToolTipText = "Sposta l'elemento selezionato verso l'alto"
      '
      'tbGiu
      '
      Me.tbGiu.ImageIndex = 3
      Me.tbGiu.Name = "tbGiu"
      Me.tbGiu.Tag = "Giù"
      Me.tbGiu.Text = "Sposta giù"
      Me.tbGiu.ToolTipText = "Sposta l'elemento selezionato verso il basso"
      '
      'ToolBarButton5
      '
      Me.ToolBarButton5.Name = "ToolBarButton5"
      Me.ToolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbListino1
      '
      Me.tbListino1.ImageIndex = 4
      Me.tbListino1.Name = "tbListino1"
      Me.tbListino1.Pushed = True
      Me.tbListino1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbListino1.Tag = "Listino1"
      Me.tbListino1.Text = "Listino 1"
      Me.tbListino1.ToolTipText = "Applica Listino1"
      '
      'tbListino2
      '
      Me.tbListino2.ImageIndex = 4
      Me.tbListino2.Name = "tbListino2"
      Me.tbListino2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbListino2.Tag = "Listino2"
      Me.tbListino2.Text = "Listino 2"
      Me.tbListino2.ToolTipText = "Applica Listino 2"
      '
      'tbListino3
      '
      Me.tbListino3.ImageIndex = 4
      Me.tbListino3.Name = "tbListino3"
      Me.tbListino3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbListino3.Tag = "Listino3"
      Me.tbListino3.Text = "Listino 3"
      Me.tbListino3.ToolTipText = "Applica Listino 3"
      '
      'tbListino4
      '
      Me.tbListino4.ImageIndex = 4
      Me.tbListino4.Name = "tbListino4"
      Me.tbListino4.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbListino4.Tag = "Listino4"
      Me.tbListino4.Text = "Listino 4"
      Me.tbListino4.ToolTipText = "Applica Listino 4"
      '
      'ToolBarButton6
      '
      Me.ToolBarButton6.Name = "ToolBarButton6"
      Me.ToolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbStile1
      '
      Me.tbStile1.ImageIndex = 5
      Me.tbStile1.Name = "tbStile1"
      Me.tbStile1.Pushed = True
      Me.tbStile1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbStile1.Tag = "Stile1"
      Me.tbStile1.Text = "Stile 1"
      Me.tbStile1.ToolTipText = "Tipo di carattere utilizzato per il testo: Arial"
      '
      'tbStile2
      '
      Me.tbStile2.ImageIndex = 5
      Me.tbStile2.Name = "tbStile2"
      Me.tbStile2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbStile2.Tag = "Stile2"
      Me.tbStile2.Text = "Stile 2"
      Me.tbStile2.ToolTipText = "Tipo di carattere utilizzato per il testo: Times New Roman"
      '
      'tbStile3
      '
      Me.tbStile3.ImageIndex = 5
      Me.tbStile3.Name = "tbStile3"
      Me.tbStile3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbStile3.Tag = "Stile3"
      Me.tbStile3.Text = "Stile 3"
      Me.tbStile3.ToolTipText = "Tipo di carattere utilizzato per il testo: Comic Sans MS"
      '
      'ToolBarButton1
      '
      Me.ToolBarButton1.Name = "ToolBarButton1"
      Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbAnteprima
      '
      Me.tbAnteprima.ImageIndex = 0
      Me.tbAnteprima.Name = "tbAnteprima"
      Me.tbAnteprima.Tag = "Anteprima"
      Me.tbAnteprima.Text = "Anteprima"
      Me.tbAnteprima.ToolTipText = "Anteprima di stampa"
      '
      'lstCategorie
      '
      Me.lstCategorie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstCategorie.Location = New System.Drawing.Point(8, 32)
      Me.lstCategorie.Name = "lstCategorie"
      Me.lstCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lstCategorie.Size = New System.Drawing.Size(288, 355)
      Me.lstCategorie.TabIndex = 4
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Gray
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(0, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(398, 22)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "  ORDINAMENTO CATEGORIE:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Menu
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(398, 400)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.lstCategorie)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Menu"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Formazione Menù"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Public Function ApplicaListino(ByVal tabella As String, ByVal listino As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET ApplicaListino = '{1}'", tabella, listino)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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

   Public Function AssegnaOrdineCategorie(ByVal tabella As String, ByVal numOrd As Integer, ByVal nome As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET IdOrd = {1} WHERE Descrizione = '{2}'", tabella, numOrd, FormattaApici(nome))

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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

   Public Function AssegnaOrdinePiatti(ByVal tabella As String, ByVal numOrd As Integer, ByVal nome As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET OrdCategoria = {1} WHERE Categoria = '{2}'", tabella, numOrd, FormattaApici(nome))

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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

   Public Sub SalvaOrdine()
      Try
         Dim i As Integer
         For i = 0 To lstCategorie.Items.Count - 1
            AssegnaOrdineCategorie(TAB_CATEGORIE, i, lstCategorie.Items.Item(i))
            AssegnaOrdinePiatti(TAB_PIATTI, i, lstCategorie.Items.Item(i))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub VisAnteprima(ByVal percorsoRep As String)
      Try
         repSql = String.Format("SELECT * FROM {0} WHERE EscludiMenu = 'No' ORDER BY OrdCategoria, Id ASC", TAB_PIATTI)
         g_frmMain.ApriReports(repSql, TAB_PIATTI, percorsoRep, "Menu")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica la lista delle categorie dei piatti.
         CaricaListaCategorie(lstCategorie, TAB_CATEGORIE)

         ' Seleziona il primo elemento della lista categorie.
         If lstCategorie.Items.Count <> 0 Then
            lstCategorie.SelectedIndex = 0
         End If

         ' Imposta il primo listino per tutti i piatti.
         ApplicaListino(TAB_PIATTI, "1")

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_MENU, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Menu_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         SalvaOrdine()

         If IsNothing(g_frmPiatti) = False Then
            ' Carica la lista delle categorie dei piatti.
            g_frmPiatti.lstCategorie.Items.Clear()
            CaricaListaPiatti(g_frmPiatti.lstCategorie, g_frmPiatti.TAB_CATEGORIE)

            ' Seleziona il primo elemento della lista categorie.
            If g_frmPiatti.lstCategorie.Items.Count <> 0 Then
               g_frmPiatti.lstCategorie.SelectedIndex = 0
            End If
         End If

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Distrugge l'oggetto e libera le risorse.
         g_frmMenu.Dispose()
         g_frmMenu = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_STRUMENTI_MENU, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Dim strDescrizione As String

      Select Case e.Button.Tag
         Case "Su"
            SpostaElememtoSu(lstCategorie)
            strDescrizione = "(Su)"

         Case "Giù"
            SpostaElememtoGiù(lstCategorie)
            strDescrizione = "(Giù)"

         Case "Listino1"
            tbListino1.Pushed = True
            tbListino2.Pushed = False
            tbListino3.Pushed = False
            tbListino4.Pushed = False
            ApplicaListino(TAB_PIATTI, "1")
            strDescrizione = "(Listino 1)"

         Case "Listino2"
            tbListino1.Pushed = False
            tbListino2.Pushed = True
            tbListino3.Pushed = False
            tbListino4.Pushed = False
            ApplicaListino(TAB_PIATTI, "2")
            strDescrizione = "(Listino 2)"

         Case "Listino3"
            tbListino1.Pushed = False
            tbListino2.Pushed = False
            tbListino3.Pushed = True
            tbListino4.Pushed = False
            ApplicaListino(TAB_PIATTI, "3")
            strDescrizione = "(Listino 3)"

         Case "Listino4"
            tbListino1.Pushed = False
            tbListino2.Pushed = False
            tbListino3.Pushed = False
            tbListino4.Pushed = True
            ApplicaListino(TAB_PIATTI, "4")
            strDescrizione = "(Listino 4)"

         Case "Stile1"
            tbStile1.Pushed = True
            tbStile2.Pushed = False
            tbStile3.Pushed = False
            percorsoReports = PERCORSO_REP_MENU_ARIAL
            strDescrizione = "(Stile 1)"

         Case "Stile2"
            tbStile1.Pushed = False
            tbStile2.Pushed = True
            tbStile3.Pushed = False
            percorsoReports = PERCORSO_REP_MENU_TIMES
            strDescrizione = "(Stile 2)"

         Case "Stile3"
            tbStile1.Pushed = False
            tbStile2.Pushed = False
            tbStile3.Pushed = True
            percorsoReports = PERCORSO_REP_MENU_COMIC
            strDescrizione = "(Stile 3)"

         Case "Anteprima"
            SalvaOrdine()
            VisAnteprima(percorsoReports)

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_STRUMENTI_MENU, MODULO_STRUMENTI_MENU)

            Exit Sub
      End Select

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

   End Sub

End Class
