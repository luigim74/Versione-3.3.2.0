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
   Friend WithEvents eui_lstCategorie As Elegant.Ui.ListBox
   Friend WithEvents eui_cmdAnteprima As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaBasso As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaAlto As Elegant.Ui.Button
   Friend WithEvents eui_ddwnListino As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdListino1 As Elegant.Ui.Button
   Friend WithEvents eui_cmdListino2 As Elegant.Ui.Button
   Friend WithEvents eui_cmdListino3 As Elegant.Ui.Button
   Friend WithEvents eui_cmdListino4 As Elegant.Ui.Button
   Friend WithEvents Label6 As Elegant.Ui.Label
   Friend WithEvents Label5 As Elegant.Ui.Label
   Friend WithEvents Label4 As Elegant.Ui.Label
   Friend WithEvents Label2 As Elegant.Ui.Label
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Friend WithEvents eui_txtSottotitolo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTitolo As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdEliminaImmagine As Elegant.Ui.Button
   Friend WithEvents eui_cmdCaricaImmagine As Elegant.Ui.Button
   Friend WithEvents DropDown1 As Elegant.Ui.DropDown
   Friend WithEvents picImmagine As PictureBox
   Friend WithEvents PopupMenu2 As Elegant.Ui.PopupMenu
   Friend WithEvents Button3 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOK As Elegant.Ui.Button
   Friend WithEvents Label3 As Label
   Friend WithEvents OpenFileDialog1 As OpenFileDialog
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
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_lstCategorie = New Elegant.Ui.ListBox()
      Me.eui_cmdSpostaAlto = New Elegant.Ui.Button()
      Me.eui_cmdSpostaBasso = New Elegant.Ui.Button()
      Me.eui_cmdAnteprima = New Elegant.Ui.Button()
      Me.eui_ddwnListino = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdListino1 = New Elegant.Ui.Button()
      Me.eui_cmdListino2 = New Elegant.Ui.Button()
      Me.eui_cmdListino3 = New Elegant.Ui.Button()
      Me.eui_cmdListino4 = New Elegant.Ui.Button()
      Me.eui_cmdCaricaImmagine = New Elegant.Ui.Button()
      Me.eui_cmdEliminaImmagine = New Elegant.Ui.Button()
      Me.eui_txtTitolo = New Elegant.Ui.TextBox()
      Me.eui_txtSottotitolo = New Elegant.Ui.TextBox()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.Label1 = New Elegant.Ui.Label()
      Me.Label2 = New Elegant.Ui.Label()
      Me.Label4 = New Elegant.Ui.Label()
      Me.Label5 = New Elegant.Ui.Label()
      Me.Label6 = New Elegant.Ui.Label()
      Me.DropDown1 = New Elegant.Ui.DropDown()
      Me.PopupMenu2 = New Elegant.Ui.PopupMenu(Me.components)
      Me.Button3 = New Elegant.Ui.Button()
      Me.picImmagine = New System.Windows.Forms.PictureBox()
      Me.eui_cmdOK = New Elegant.Ui.Button()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      CType(Me.eui_lstCategorie, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.ToolBar1.Location = New System.Drawing.Point(606, 25)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(88, 265)
      Me.ToolBar1.TabIndex = 3
      Me.ToolBar1.Tag = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Visible = False
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
      Me.lstCategorie.Location = New System.Drawing.Point(604, 291)
      Me.lstCategorie.Name = "lstCategorie"
      Me.lstCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lstCategorie.Size = New System.Drawing.Size(88, 56)
      Me.lstCategorie.TabIndex = 4
      Me.lstCategorie.Visible = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_lstCategorie
      '
      Me.eui_lstCategorie.AutoScroll = True
      Me.eui_lstCategorie.Id = "9d13a859-17af-4924-adf7-661d839888fc"
      Me.eui_lstCategorie.Location = New System.Drawing.Point(245, 49)
      Me.eui_lstCategorie.Name = "eui_lstCategorie"
      Me.eui_lstCategorie.Size = New System.Drawing.Size(237, 394)
      Me.eui_lstCategorie.TabIndex = 6
      Me.eui_lstCategorie.Text = "ListBox1"
      '
      'eui_cmdSpostaAlto
      '
      Me.eui_cmdSpostaAlto.Id = "73125b18-c1a9-4177-8f8c-b7c005fc30a1"
      Me.eui_cmdSpostaAlto.Location = New System.Drawing.Point(488, 49)
      Me.eui_cmdSpostaAlto.Name = "eui_cmdSpostaAlto"
      Me.eui_cmdSpostaAlto.Size = New System.Drawing.Size(110, 45)
      Me.eui_cmdSpostaAlto.TabIndex = 7
      Me.eui_cmdSpostaAlto.Text = "Sposta in &alto"
      '
      'eui_cmdSpostaBasso
      '
      Me.eui_cmdSpostaBasso.Id = "44d27db8-ee46-471e-a878-b4864550aced"
      Me.eui_cmdSpostaBasso.Location = New System.Drawing.Point(488, 102)
      Me.eui_cmdSpostaBasso.Name = "eui_cmdSpostaBasso"
      Me.eui_cmdSpostaBasso.Size = New System.Drawing.Size(110, 45)
      Me.eui_cmdSpostaBasso.TabIndex = 8
      Me.eui_cmdSpostaBasso.Text = "Sposta in &basso"
      '
      'eui_cmdAnteprima
      '
      Me.eui_cmdAnteprima.Id = "69312706-b4d7-40ed-9c2f-f3ced604d8a3"
      Me.eui_cmdAnteprima.Location = New System.Drawing.Point(489, 346)
      Me.eui_cmdAnteprima.Name = "eui_cmdAnteprima"
      Me.eui_cmdAnteprima.Size = New System.Drawing.Size(110, 45)
      Me.eui_cmdAnteprima.TabIndex = 11
      Me.eui_cmdAnteprima.Text = "A&nteprima"
      '
      'eui_ddwnListino
      '
      Me.eui_ddwnListino.Id = "e0fc8ce9-0b1b-410a-9cbe-23cd3f800a5b"
      Me.eui_ddwnListino.Location = New System.Drawing.Point(489, 294)
      Me.eui_ddwnListino.Name = "eui_ddwnListino"
      Me.eui_ddwnListino.Popup = Me.PopupMenu1
      Me.eui_ddwnListino.Size = New System.Drawing.Size(110, 45)
      Me.eui_ddwnListino.TabIndex = 10
      Me.eui_ddwnListino.Text = "Listino"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdListino1, Me.eui_cmdListino2, Me.eui_cmdListino3, Me.eui_cmdListino4})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdListino1
      '
      Me.eui_cmdListino1.Id = "77a505a5-83c6-4986-82aa-aa47f858f4f8"
      Me.eui_cmdListino1.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdListino1.Name = "eui_cmdListino1"
      Me.eui_cmdListino1.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino1.TabIndex = 3
      Me.eui_cmdListino1.Text = "Listino &1"
      '
      'eui_cmdListino2
      '
      Me.eui_cmdListino2.Id = "c662c52e-2472-44a8-a9f6-11c6d9b62929"
      Me.eui_cmdListino2.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdListino2.Name = "eui_cmdListino2"
      Me.eui_cmdListino2.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino2.TabIndex = 4
      Me.eui_cmdListino2.Text = "Listino &2"
      '
      'eui_cmdListino3
      '
      Me.eui_cmdListino3.Id = "b65dcd20-d5e9-4af5-915b-2c31956fb926"
      Me.eui_cmdListino3.Location = New System.Drawing.Point(2, 48)
      Me.eui_cmdListino3.Name = "eui_cmdListino3"
      Me.eui_cmdListino3.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino3.TabIndex = 5
      Me.eui_cmdListino3.Text = "Listino &3"
      '
      'eui_cmdListino4
      '
      Me.eui_cmdListino4.Id = "a3e256ca-1967-4af5-91c6-ca37882a0327"
      Me.eui_cmdListino4.Location = New System.Drawing.Point(2, 71)
      Me.eui_cmdListino4.Name = "eui_cmdListino4"
      Me.eui_cmdListino4.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdListino4.TabIndex = 6
      Me.eui_cmdListino4.Text = "Listino &4"
      '
      'eui_cmdCaricaImmagine
      '
      Me.eui_cmdCaricaImmagine.Id = "2b7c81f4-b99f-4c5f-a3ea-f1a795667673"
      Me.eui_cmdCaricaImmagine.Location = New System.Drawing.Point(8, 408)
      Me.eui_cmdCaricaImmagine.Name = "eui_cmdCaricaImmagine"
      Me.eui_cmdCaricaImmagine.Size = New System.Drawing.Size(110, 35)
      Me.eui_cmdCaricaImmagine.TabIndex = 4
      Me.eui_cmdCaricaImmagine.Text = "&Carica"
      '
      'eui_cmdEliminaImmagine
      '
      Me.eui_cmdEliminaImmagine.Id = "f48679c1-9292-4764-b69c-d70b448032ce"
      Me.eui_cmdEliminaImmagine.Location = New System.Drawing.Point(128, 408)
      Me.eui_cmdEliminaImmagine.Name = "eui_cmdEliminaImmagine"
      Me.eui_cmdEliminaImmagine.Size = New System.Drawing.Size(110, 35)
      Me.eui_cmdEliminaImmagine.TabIndex = 5
      Me.eui_cmdEliminaImmagine.Text = "&Elimina"
      '
      'eui_txtTitolo
      '
      Me.eui_txtTitolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTitolo.Id = "164de92c-2c2c-4520-a019-af95b1da2179"
      Me.eui_txtTitolo.Location = New System.Drawing.Point(8, 49)
      Me.eui_txtTitolo.Name = "eui_txtTitolo"
      Me.eui_txtTitolo.Size = New System.Drawing.Size(230, 21)
      Me.eui_txtTitolo.TabIndex = 0
      Me.eui_txtTitolo.TextEditorWidth = 224
      '
      'eui_txtSottotitolo
      '
      Me.eui_txtSottotitolo.Id = "44365ba7-622a-492f-a845-933f2c0fbc46"
      Me.eui_txtSottotitolo.Location = New System.Drawing.Point(8, 100)
      Me.eui_txtSottotitolo.Name = "eui_txtSottotitolo"
      Me.eui_txtSottotitolo.Size = New System.Drawing.Size(230, 21)
      Me.eui_txtSottotitolo.TabIndex = 1
      Me.eui_txtSottotitolo.TextEditorWidth = 224
      '
      'eui_txtNote
      '
      Me.eui_txtNote.Id = "835c5301-f2fc-452c-b1a6-8b327fd2adbc"
      Me.eui_txtNote.Location = New System.Drawing.Point(8, 150)
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.Size = New System.Drawing.Size(230, 21)
      Me.eui_txtNote.TabIndex = 2
      Me.eui_txtNote.TextEditorWidth = 224
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(9, 198)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(182, 16)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Immagine:"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(245, 31)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(182, 16)
      Me.Label2.TabIndex = 31
      Me.Label2.Text = "Categorie:"
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(8, 32)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(230, 15)
      Me.Label4.TabIndex = 32
      Me.Label4.Text = "Titolo:"
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(8, 85)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(231, 15)
      Me.Label5.TabIndex = 33
      Me.Label5.Text = "Sotto titolo:"
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(8, 135)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(230, 15)
      Me.Label6.TabIndex = 34
      Me.Label6.Text = "Note:"
      '
      'DropDown1
      '
      Me.DropDown1.Id = "266d3c1d-d4fe-4830-98c6-24d6194e6b43"
      Me.DropDown1.Location = New System.Drawing.Point(489, 242)
      Me.DropDown1.Name = "DropDown1"
      Me.DropDown1.Popup = Me.PopupMenu2
      Me.DropDown1.Size = New System.Drawing.Size(110, 45)
      Me.DropDown1.TabIndex = 9
      Me.DropDown1.Text = "Modello"
      '
      'PopupMenu2
      '
      Me.PopupMenu2.Items.AddRange(New System.Windows.Forms.Control() {Me.Button3})
      Me.PopupMenu2.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu2.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu2.Size = New System.Drawing.Size(100, 100)
      '
      'Button3
      '
      Me.Button3.Id = "a06705d2-873b-4021-8d04-874ecb236e4d"
      Me.Button3.Location = New System.Drawing.Point(2, 2)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(126, 23)
      Me.Button3.TabIndex = 3
      Me.Button3.Text = "Standard"
      '
      'picImmagine
      '
      Me.picImmagine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picImmagine.Image = CType(resources.GetObject("picImmagine.Image"), System.Drawing.Image)
      Me.picImmagine.Location = New System.Drawing.Point(8, 216)
      Me.picImmagine.Name = "picImmagine"
      Me.picImmagine.Size = New System.Drawing.Size(230, 189)
      Me.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picImmagine.TabIndex = 36
      Me.picImmagine.TabStop = False
      '
      'eui_cmdOK
      '
      Me.eui_cmdOK.Id = "4c2e26a0-f512-4fc5-bf3b-a29251486399"
      Me.eui_cmdOK.Location = New System.Drawing.Point(488, 398)
      Me.eui_cmdOK.Name = "eui_cmdOK"
      Me.eui_cmdOK.Size = New System.Drawing.Size(110, 45)
      Me.eui_cmdOK.TabIndex = 12
      Me.eui_cmdOK.Text = "&OK"
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Gray
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(0, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(694, 22)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "Modello: [C:\Program Files (x86)\Menu_Standard_A4.rpt]"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'OpenFileDialog1
      '
      Me.OpenFileDialog1.FileName = "OpenFileDialog1"
      '
      'Menu
      '
      Me.AcceptButton = Me.eui_cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(694, 452)
      Me.Controls.Add(Me.eui_cmdOK)
      Me.Controls.Add(Me.picImmagine)
      Me.Controls.Add(Me.DropDown1)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.eui_txtNote)
      Me.Controls.Add(Me.eui_txtSottotitolo)
      Me.Controls.Add(Me.eui_txtTitolo)
      Me.Controls.Add(Me.eui_cmdEliminaImmagine)
      Me.Controls.Add(Me.eui_cmdCaricaImmagine)
      Me.Controls.Add(Me.eui_ddwnListino)
      Me.Controls.Add(Me.eui_cmdAnteprima)
      Me.Controls.Add(Me.eui_cmdSpostaBasso)
      Me.Controls.Add(Me.eui_cmdSpostaAlto)
      Me.Controls.Add(Me.eui_lstCategorie)
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
      Me.Text = "Formazione Menu"
      CType(Me.eui_lstCategorie, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

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

   Public Sub CaricaListaCategorie(ByVal lstBox As Elegant.Ui.ListBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY IdOrd ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim coll As Integer
         Do While dr.Read
            coll = lstBox.Items.Add(String.Format(dr.Item("Descrizione")).ToUpper)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaOrdinata()
      Try
         ' Pulisco la seconda lista.
         eui_lstCategorie.Items.Clear()

         ' Carico gli elementi ordinati della prima lista nella seconda.
         For Each elemento As String In lstCategorie.Items
            eui_lstCategorie.Items.Add(elemento)
         Next

         ' Seleziono l'elemento spostato.
         eui_lstCategorie.SelectedItemIndex = lstCategorie.SelectedIndex

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InserisciImmagine()
      Try
         OpenFileDialog1.Filter = "Tutti i formati |*.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                                  "Bmp (Bitmap di Windows)|*.Bmp|" &
                                  "Gif |*.Gif|" &
                                  "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                                  "Png |*.Png|" &
                                  "Tga |*.Tga|" &
                                  "Tiff |*.Tiff|" &
                                  "Wmf (Metafile di Windows) |*.Wmf"

         OpenFileDialog1.FilterIndex = 1
         OpenFileDialog1.ShowDialog()

         'AArticoli.Immagine = OpenFileDialog1.FileName

         'If File.Exists(AArticoli.Immagine) = True Then
         Dim bmp As New Bitmap(OpenFileDialog1.FileName)
         picImmagine.Image = bmp
         'End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaImmagine()
      Try
         If Not (picImmagine.Image Is Nothing) Then
            picImmagine.Image.Dispose()
            picImmagine.Image = Nothing
            'AArticoli.Immagine = ""
         End If

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
         CaricaListaCategorie(eui_lstCategorie, TAB_CATEGORIE)
         Procedure.CaricaListaCategorie(lstCategorie, TAB_CATEGORIE)

         ' Seleziona il primo elemento della lista categorie.
         If eui_lstCategorie.Items.Count <> 0 Then
            eui_lstCategorie.SelectedItemIndex = 0
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
            'SpostaElememtoSu(lstCategorie)
            strDescrizione = "(Su)"

         Case "Giù"
            'SpostaElememtoGiù(lstCategorie)
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

   Private Sub eui_cmdSpostaAlto_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaAlto.Click
      Try
         Dim strDescrizione As String = "(Su)"

         ' Ordino gli elementi ella prima lista.
         SpostaElememtoSu(lstCategorie)

         ' Carico gli elementi ordinati della prima lista nella seconda.
         CaricaListaOrdinata()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSpostaBasso_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaBasso.Click
      Try
         Dim strDescrizione As String = "(Giù)"

         ' Ordino gli elementi ella prima lista.
         SpostaElememtoGiù(lstCategorie)

         ' Carico gli elementi ordinati della prima lista nella seconda.
         CaricaListaOrdinata()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_lstCategorie_SelectionChanged(sender As Object, e As EventArgs) Handles eui_lstCategorie.SelectionChanged
      Try
         lstCategorie.SelectedIndex = eui_lstCategorie.SelectedItemIndex

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino1_Click(sender As Object, e As EventArgs) Handles eui_cmdListino1.Click
      Try
         Dim strDescrizione As String = "(Listino 1)"

         eui_ddwnListino.Text = sender.Text

         ApplicaListino(TAB_PIATTI, "1")

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdListino2_Click(sender As Object, e As EventArgs) Handles eui_cmdListino2.Click
      Try
         Dim strDescrizione As String = "(Listino 2)"

         eui_ddwnListino.Text = sender.Text

         ApplicaListino(TAB_PIATTI, "2")

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino3_Click(sender As Object, e As EventArgs) Handles eui_cmdListino3.Click
      Try
         Dim strDescrizione As String = "(Listino 3)"

         eui_ddwnListino.Text = sender.Text

         ApplicaListino(TAB_PIATTI, "3")

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino4_Click(sender As Object, e As EventArgs) Handles eui_cmdListino4.Click
      Try
         Dim strDescrizione As String = "(Listino 4)"

         eui_ddwnListino.Text = sender.Text

         ApplicaListino(TAB_PIATTI, "4")

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnteprima_Click(sender As Object, e As EventArgs) Handles eui_cmdAnteprima.Click
      Try
         SalvaOrdine()

         VisAnteprima(percorsoReports)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_STRUMENTI_MENU, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdCaricaImmagine_Click(sender As Object, e As EventArgs) Handles eui_cmdCaricaImmagine.Click
      InserisciImmagine()
   End Sub

   Private Sub eui_cmdEliminaImmagine_Click(sender As Object, e As EventArgs) Handles eui_cmdEliminaImmagine.Click
      EliminaImmagine()
   End Sub

   Private Sub eui_cmdOK_Click(sender As Object, e As EventArgs) Handles eui_cmdOK.Click
      Me.Close()
   End Sub
End Class
