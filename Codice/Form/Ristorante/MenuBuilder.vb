Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb
Imports ZXing


Public Class Menu
   Inherits System.Windows.Forms.Form

   Const TAB_FORMAZIONE_MENU As String = "FormazioneMenu"
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
   Dim repSqlMenu As String
   Dim repSqlPiatti As String
   Private CMenu As New FormazioneMenu

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
   Friend WithEvents picImmagine As PictureBox
   Friend WithEvents eui_cmdOK As Elegant.Ui.Button
   Friend WithEvents eui_ApriModello As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents Label3 As Elegant.Ui.Label
   Friend WithEvents eui_txtPercorsoDocumentoCodiceQR As Elegant.Ui.TextBox
   Friend WithEvents picCodiceQR As PictureBox
   Friend WithEvents eui_txtPercorsoReport As Elegant.Ui.TextBox
   Friend WithEvents Label8 As Elegant.Ui.Label
   Friend WithEvents Label7 As Elegant.Ui.Label
   Friend WithEvents eui_cmdEliminaCodiceQR As Elegant.Ui.Button
   Friend WithEvents eui_ddwnGeneraCodiceQR As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu2 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdGeneraFileBmp As Elegant.Ui.Button
   Friend WithEvents eui_cmdGeneraFileGif As Elegant.Ui.Button
   Friend WithEvents eui_cmdGeneraFileJpeg As Elegant.Ui.Button
   Friend WithEvents eui_cmdGeneraFilePng As Elegant.Ui.Button
   Friend WithEvents eui_cmdGeneraFileTiff As Elegant.Ui.Button
   Friend WithEvents eui_cmdGeneraFileWmf As Elegant.Ui.Button
   Friend WithEvents eui_txtPercorsoImmagineCodiceQR As Elegant.Ui.TextBox
   Friend WithEvents Label9 As Elegant.Ui.Label
   Friend WithEvents OpenFileDialog1 As OpenFileDialog

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
   Friend WithEvents lstCategorie As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
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
      Me.picImmagine = New System.Windows.Forms.PictureBox()
      Me.eui_cmdOK = New Elegant.Ui.Button()
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.eui_ApriModello = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.picCodiceQR = New System.Windows.Forms.PictureBox()
      Me.Label3 = New Elegant.Ui.Label()
      Me.eui_txtPercorsoDocumentoCodiceQR = New Elegant.Ui.TextBox()
      Me.Label7 = New Elegant.Ui.Label()
      Me.eui_txtPercorsoReport = New Elegant.Ui.TextBox()
      Me.Label8 = New Elegant.Ui.Label()
      Me.eui_cmdEliminaCodiceQR = New Elegant.Ui.Button()
      Me.eui_ddwnGeneraCodiceQR = New Elegant.Ui.DropDown()
      Me.PopupMenu2 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdGeneraFileBmp = New Elegant.Ui.Button()
      Me.eui_cmdGeneraFileGif = New Elegant.Ui.Button()
      Me.eui_cmdGeneraFileJpeg = New Elegant.Ui.Button()
      Me.eui_cmdGeneraFilePng = New Elegant.Ui.Button()
      Me.eui_cmdGeneraFileTiff = New Elegant.Ui.Button()
      Me.eui_cmdGeneraFileWmf = New Elegant.Ui.Button()
      Me.eui_txtPercorsoImmagineCodiceQR = New Elegant.Ui.TextBox()
      Me.Label9 = New Elegant.Ui.Label()
        CType(Me.eui_lstCategorie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCodiceQR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lstCategorie
        '
        Me.lstCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCategorie.Location = New System.Drawing.Point(580, 6)
        Me.lstCategorie.Name = "lstCategorie"
        Me.lstCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstCategorie.Size = New System.Drawing.Size(88, 17)
        Me.lstCategorie.TabIndex = 14
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
        Me.eui_lstCategorie.Location = New System.Drawing.Point(438, 26)
        Me.eui_lstCategorie.Name = "eui_lstCategorie"
        Me.eui_lstCategorie.Size = New System.Drawing.Size(230, 394)
        Me.eui_lstCategorie.TabIndex = 5
        Me.eui_lstCategorie.Text = "ListBox1"
        '
        'eui_cmdSpostaAlto
        '
        Me.eui_cmdSpostaAlto.Id = "73125b18-c1a9-4177-8f8c-b7c005fc30a1"
        Me.eui_cmdSpostaAlto.Location = New System.Drawing.Point(677, 26)
        Me.eui_cmdSpostaAlto.Name = "eui_cmdSpostaAlto"
        Me.eui_cmdSpostaAlto.Size = New System.Drawing.Size(110, 45)
        Me.eui_cmdSpostaAlto.TabIndex = 6
        Me.eui_cmdSpostaAlto.Text = "Sposta in alt&o"
        '
        'eui_cmdSpostaBasso
        '
        Me.eui_cmdSpostaBasso.Id = "44d27db8-ee46-471e-a878-b4864550aced"
        Me.eui_cmdSpostaBasso.Location = New System.Drawing.Point(677, 79)
        Me.eui_cmdSpostaBasso.Name = "eui_cmdSpostaBasso"
        Me.eui_cmdSpostaBasso.Size = New System.Drawing.Size(110, 45)
        Me.eui_cmdSpostaBasso.TabIndex = 7
        Me.eui_cmdSpostaBasso.Text = "Sposta in &basso"
        '
        'eui_cmdAnteprima
        '
        Me.eui_cmdAnteprima.Id = "69312706-b4d7-40ed-9c2f-f3ced604d8a3"
        Me.eui_cmdAnteprima.Location = New System.Drawing.Point(678, 252)
        Me.eui_cmdAnteprima.Name = "eui_cmdAnteprima"
        Me.eui_cmdAnteprima.Size = New System.Drawing.Size(110, 45)
        Me.eui_cmdAnteprima.TabIndex = 10
        Me.eui_cmdAnteprima.Text = "A&nteprima"
        '
        'eui_ddwnListino
        '
        Me.eui_ddwnListino.Id = "e0fc8ce9-0b1b-410a-9cbe-23cd3f800a5b"
        Me.eui_ddwnListino.Location = New System.Drawing.Point(678, 199)
        Me.eui_ddwnListino.Name = "eui_ddwnListino"
        Me.eui_ddwnListino.Popup = Me.PopupMenu1
        Me.eui_ddwnListino.Size = New System.Drawing.Size(110, 45)
        Me.eui_ddwnListino.TabIndex = 9
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
        Me.eui_cmdCaricaImmagine.Location = New System.Drawing.Point(8, 385)
        Me.eui_cmdCaricaImmagine.Name = "eui_cmdCaricaImmagine"
        Me.eui_cmdCaricaImmagine.Size = New System.Drawing.Size(99, 35)
        Me.eui_cmdCaricaImmagine.TabIndex = 3
        Me.eui_cmdCaricaImmagine.Text = "&Carica"
        '
        'eui_cmdEliminaImmagine
        '
        Me.eui_cmdEliminaImmagine.Id = "f48679c1-9292-4764-b69c-d70b448032ce"
        Me.eui_cmdEliminaImmagine.Location = New System.Drawing.Point(109, 385)
        Me.eui_cmdEliminaImmagine.Name = "eui_cmdEliminaImmagine"
        Me.eui_cmdEliminaImmagine.Size = New System.Drawing.Size(99, 35)
        Me.eui_cmdEliminaImmagine.TabIndex = 4
        Me.eui_cmdEliminaImmagine.Text = "&Elimina"
        '
        'eui_txtTitolo
        '
        Me.eui_txtTitolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_txtTitolo.Id = "164de92c-2c2c-4520-a019-af95b1da2179"
        Me.eui_txtTitolo.Location = New System.Drawing.Point(8, 26)
        Me.eui_txtTitolo.Name = "eui_txtTitolo"
        Me.eui_txtTitolo.Size = New System.Drawing.Size(416, 21)
        Me.eui_txtTitolo.TabIndex = 0
        Me.eui_txtTitolo.TextEditorWidth = 410
        '
        'eui_txtSottotitolo
        '
        Me.eui_txtSottotitolo.Id = "44365ba7-622a-492f-a845-933f2c0fbc46"
        Me.eui_txtSottotitolo.Location = New System.Drawing.Point(8, 77)
        Me.eui_txtSottotitolo.Name = "eui_txtSottotitolo"
        Me.eui_txtSottotitolo.Size = New System.Drawing.Size(416, 21)
        Me.eui_txtSottotitolo.TabIndex = 1
        Me.eui_txtSottotitolo.TextEditorWidth = 410
        '
        'eui_txtNote
        '
        Me.eui_txtNote.Id = "835c5301-f2fc-452c-b1a6-8b327fd2adbc"
        Me.eui_txtNote.Location = New System.Drawing.Point(8, 127)
        Me.eui_txtNote.Name = "eui_txtNote"
        Me.eui_txtNote.Size = New System.Drawing.Size(416, 21)
        Me.eui_txtNote.TabIndex = 2
        Me.eui_txtNote.TextEditorWidth = 410
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Immagine:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(438, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 16)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Categorie:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(416, 15)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Titolo:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(417, 15)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Sotto titolo:"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(416, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Note:"
        '
        'picImmagine
        '
        Me.picImmagine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImmagine.Location = New System.Drawing.Point(8, 182)
        Me.picImmagine.Name = "picImmagine"
        Me.picImmagine.Size = New System.Drawing.Size(200, 200)
        Me.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImmagine.TabIndex = 36
        Me.picImmagine.TabStop = False
        '
        'eui_cmdOK
        '
        Me.eui_cmdOK.Id = "4c2e26a0-f512-4fc5-bf3b-a29251486399"
        Me.eui_cmdOK.Location = New System.Drawing.Point(678, 321)
        Me.eui_cmdOK.Name = "eui_cmdOK"
        Me.eui_cmdOK.Size = New System.Drawing.Size(110, 45)
        Me.eui_cmdOK.TabIndex = 11
        Me.eui_cmdOK.Text = "&OK"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'eui_ApriModello
        '
        Me.eui_ApriModello.Id = "40907598-0b08-4cbc-b831-5178036057b0"
        Me.eui_ApriModello.Location = New System.Drawing.Point(677, 146)
        Me.eui_ApriModello.Name = "eui_ApriModello"
        Me.eui_ApriModello.Size = New System.Drawing.Size(110, 45)
        Me.eui_ApriModello.TabIndex = 8
        Me.eui_ApriModello.Text = "Apri &Modello"
        '
        'eui_cmdAnnulla
        '
        Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.eui_cmdAnnulla.Id = "93870fb6-defc-40c7-8379-9cecc8be6f8d"
        Me.eui_cmdAnnulla.Location = New System.Drawing.Point(678, 374)
        Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
        Me.eui_cmdAnnulla.Size = New System.Drawing.Size(110, 45)
        Me.eui_cmdAnnulla.TabIndex = 12
        Me.eui_cmdAnnulla.Text = "&Annulla"
        '
        'picCodiceQR
        '
        Me.picCodiceQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picCodiceQR.Location = New System.Drawing.Point(224, 182)
        Me.picCodiceQR.Name = "picCodiceQR"
        Me.picCodiceQR.Size = New System.Drawing.Size(200, 200)
        Me.picCodiceQR.TabIndex = 37
        Me.picCodiceQR.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 524)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 15)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Percorso modello Report:"
        '
        'eui_txtPercorsoDocumentoCodiceQR
        '
        Me.eui_txtPercorsoDocumentoCodiceQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_txtPercorsoDocumentoCodiceQR.Id = "4578039d-95bf-4e1a-8b6d-eb9312bddc73"
        Me.eui_txtPercorsoDocumentoCodiceQR.Location = New System.Drawing.Point(10, 448)
        Me.eui_txtPercorsoDocumentoCodiceQR.Name = "eui_txtPercorsoDocumentoCodiceQR"
        Me.eui_txtPercorsoDocumentoCodiceQR.Size = New System.Drawing.Size(780, 21)
        Me.eui_txtPercorsoDocumentoCodiceQR.TabIndex = 38
        Me.eui_txtPercorsoDocumentoCodiceQR.TextEditorWidth = 774
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(224, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 16)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Codice QR:"
        '
        'eui_txtPercorsoReport
        '
        Me.eui_txtPercorsoReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_txtPercorsoReport.Id = "c7b56a99-868f-4f3b-aa66-0b4022379a81"
        Me.eui_txtPercorsoReport.Location = New System.Drawing.Point(10, 539)
        Me.eui_txtPercorsoReport.Name = "eui_txtPercorsoReport"
        Me.eui_txtPercorsoReport.ReadOnly = True
        Me.eui_txtPercorsoReport.Size = New System.Drawing.Size(780, 21)
        Me.eui_txtPercorsoReport.TabIndex = 42
        Me.eui_txtPercorsoReport.TextEditorWidth = 774
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 433)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 15)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Codice QR - Percorso file documento:"
        '
        'eui_cmdEliminaCodiceQR
        '
        Me.eui_cmdEliminaCodiceQR.Id = "643f1cd3-76d9-4a31-862f-95acdc697b9e"
        Me.eui_cmdEliminaCodiceQR.Location = New System.Drawing.Point(325, 385)
        Me.eui_cmdEliminaCodiceQR.Name = "eui_cmdEliminaCodiceQR"
        Me.eui_cmdEliminaCodiceQR.Size = New System.Drawing.Size(99, 35)
        Me.eui_cmdEliminaCodiceQR.TabIndex = 44
        Me.eui_cmdEliminaCodiceQR.Text = "&Elimina"
        '
        'eui_ddwnGeneraCodiceQR
        '
        Me.eui_ddwnGeneraCodiceQR.Id = "a8e48fe3-3fdf-48b3-b83f-caa0f122ec9d"
        Me.eui_ddwnGeneraCodiceQR.Location = New System.Drawing.Point(224, 385)
        Me.eui_ddwnGeneraCodiceQR.Name = "eui_ddwnGeneraCodiceQR"
        Me.eui_ddwnGeneraCodiceQR.Popup = Me.PopupMenu2
        Me.eui_ddwnGeneraCodiceQR.Size = New System.Drawing.Size(99, 35)
        Me.eui_ddwnGeneraCodiceQR.TabIndex = 45
        Me.eui_ddwnGeneraCodiceQR.Text = "&Genera"
        '
        'PopupMenu2
        '
        Me.PopupMenu2.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdGeneraFileBmp, Me.eui_cmdGeneraFileGif, Me.eui_cmdGeneraFileJpeg, Me.eui_cmdGeneraFilePng, Me.eui_cmdGeneraFileTiff, Me.eui_cmdGeneraFileWmf})
        Me.PopupMenu2.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
        Me.PopupMenu2.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
        Me.PopupMenu2.Size = New System.Drawing.Size(100, 100)
        '
        'eui_cmdGeneraFileBmp
        '
        Me.eui_cmdGeneraFileBmp.Id = "05226779-7de0-4848-9f9f-4880be23e600"
        Me.eui_cmdGeneraFileBmp.Location = New System.Drawing.Point(2, 2)
        Me.eui_cmdGeneraFileBmp.Name = "eui_cmdGeneraFileBmp"
        Me.eui_cmdGeneraFileBmp.Size = New System.Drawing.Size(126, 23)
        Me.eui_cmdGeneraFileBmp.TabIndex = 3
        Me.eui_cmdGeneraFileBmp.Text = "File (.bmp)"
        '
        'eui_cmdGeneraFileGif
        '
        Me.eui_cmdGeneraFileGif.Id = "6a8ed530-77c2-41fa-8af6-d49ced6b3d57"
        Me.eui_cmdGeneraFileGif.Location = New System.Drawing.Point(2, 25)
        Me.eui_cmdGeneraFileGif.Name = "eui_cmdGeneraFileGif"
        Me.eui_cmdGeneraFileGif.Size = New System.Drawing.Size(126, 23)
        Me.eui_cmdGeneraFileGif.TabIndex = 4
        Me.eui_cmdGeneraFileGif.Text = "File (.gif)"
        '
        'eui_cmdGeneraFileJpeg
        '
        Me.eui_cmdGeneraFileJpeg.Id = "429ece3a-7991-45b0-beb5-386afc24c047"
        Me.eui_cmdGeneraFileJpeg.Location = New System.Drawing.Point(2, 48)
        Me.eui_cmdGeneraFileJpeg.Name = "eui_cmdGeneraFileJpeg"
        Me.eui_cmdGeneraFileJpeg.Size = New System.Drawing.Size(126, 23)
        Me.eui_cmdGeneraFileJpeg.TabIndex = 5
        Me.eui_cmdGeneraFileJpeg.Text = "File (.jpeg)"
        '
        'eui_cmdGeneraFilePng
        '
        Me.eui_cmdGeneraFilePng.Id = "3409bbe5-f9a4-4cd2-bfbd-a903355feaf4"
        Me.eui_cmdGeneraFilePng.Location = New System.Drawing.Point(2, 71)
        Me.eui_cmdGeneraFilePng.Name = "eui_cmdGeneraFilePng"
        Me.eui_cmdGeneraFilePng.Size = New System.Drawing.Size(126, 23)
        Me.eui_cmdGeneraFilePng.TabIndex = 6
        Me.eui_cmdGeneraFilePng.Text = "File (.png)"
        '
        'eui_cmdGeneraFileTiff
        '
        Me.eui_cmdGeneraFileTiff.Id = "452a08ea-8776-4f70-8f93-46a68633eacd"
        Me.eui_cmdGeneraFileTiff.Location = New System.Drawing.Point(2, 94)
        Me.eui_cmdGeneraFileTiff.Name = "eui_cmdGeneraFileTiff"
        Me.eui_cmdGeneraFileTiff.Size = New System.Drawing.Size(126, 23)
        Me.eui_cmdGeneraFileTiff.TabIndex = 7
        Me.eui_cmdGeneraFileTiff.Text = "File (.tiff)"
        '
        'eui_cmdGeneraFileWmf
        '
        Me.eui_cmdGeneraFileWmf.Id = "c01d98c3-6dca-4a5c-b3bc-7d7cf4f9e581"
        Me.eui_cmdGeneraFileWmf.Location = New System.Drawing.Point(2, 117)
        Me.eui_cmdGeneraFileWmf.Name = "eui_cmdGeneraFileWmf"
        Me.eui_cmdGeneraFileWmf.Size = New System.Drawing.Size(126, 23)
        Me.eui_cmdGeneraFileWmf.TabIndex = 8
        Me.eui_cmdGeneraFileWmf.Text = "File (.wmf)"
        '
        'eui_txtPercorsoImmagineCodiceQR
        '
        Me.eui_txtPercorsoImmagineCodiceQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eui_txtPercorsoImmagineCodiceQR.Id = "b1be1ac6-8160-4358-b91f-a1e1c98c9f60"
        Me.eui_txtPercorsoImmagineCodiceQR.Location = New System.Drawing.Point(10, 493)
        Me.eui_txtPercorsoImmagineCodiceQR.Name = "eui_txtPercorsoImmagineCodiceQR"
        Me.eui_txtPercorsoImmagineCodiceQR.ReadOnly = True
        Me.eui_txtPercorsoImmagineCodiceQR.Size = New System.Drawing.Size(780, 21)
        Me.eui_txtPercorsoImmagineCodiceQR.TabIndex = 47
        Me.eui_txtPercorsoImmagineCodiceQR.TextEditorWidth = 774
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 478)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 15)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Codice QR - Percorso file immagine:"
        '
        'Menu
        '
        Me.AcceptButton = Me.eui_cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.CancelButton = Me.eui_cmdAnnulla
        Me.ClientSize = New System.Drawing.Size(798, 574)
        Me.Controls.Add(Me.eui_txtPercorsoImmagineCodiceQR)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.eui_ddwnGeneraCodiceQR)
        Me.Controls.Add(Me.eui_cmdEliminaCodiceQR)
        Me.Controls.Add(Me.eui_txtPercorsoReport)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.eui_txtPercorsoDocumentoCodiceQR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.picCodiceQR)
        Me.Controls.Add(Me.lstCategorie)
        Me.Controls.Add(Me.eui_cmdAnnulla)
        Me.Controls.Add(Me.eui_ApriModello)
        Me.Controls.Add(Me.eui_cmdOK)
        Me.Controls.Add(Me.picImmagine)
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
        CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCodiceQR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Function SalvaDati() As Boolean
      Try
         ' Assegna i dati dei campi della classe alle caselle di testo.
         With CMenu
            ' Carica i dati contenuti nel database.
            .Titolo = eui_txtTitolo.Text
            .Sottotitolo = eui_txtSottotitolo.Text
            .Note = eui_txtNote.Text
            .Documento = eui_txtPercorsoDocumentoCodiceQR.Text
            .ImmagineQR = eui_txtPercorsoImmagineCodiceQR.Text
            .Modello = eui_txtPercorsoReport.Text
            .Listino = eui_ddwnListino.Text

            Select Case CMenu.Listino
               Case eui_cmdListino1.Text
                  ApplicaListino(TAB_PIATTI, Listino.Listino1.ToString)

               Case eui_cmdListino2.Text
                  ApplicaListino(TAB_PIATTI, Listino.Listino2.ToString)

               Case eui_cmdListino3.Text
                  ApplicaListino(TAB_PIATTI, Listino.Listino3.ToString)

               Case eui_cmdListino4.Text
                  ApplicaListino(TAB_PIATTI, Listino.Listino4.ToString)
            End Select

            ' Carica l'immagine.
            If .Immagine = Nothing Then
               .Immagine = String.Empty
            End If

            ' Carica l'immagine.
            If .ImmagineQR = Nothing Then
               .ImmagineQR = String.Empty
            End If

            ' Salva i dati nel dadabase.
            Return .ModificaDati(TAB_FORMAZIONE_MENU, .Codice)

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Sub GeneraCodiciBarre(ByVal indirizzo As String, ByVal formatoImg As String)
      Try
         If indirizzo <> String.Empty Then
            Dim Testo As String = indirizzo

            Dim GeneraBarcode As IBarcodeWriter = New BarcodeWriter() With {.Format = BarcodeFormat.QR_CODE}
            GeneraBarcode.Options.Height = 200
            GeneraBarcode.Options.Width = 200

            Dim risultato As Bitmap = GeneraBarcode.Write(Testo)

            Dim bitmapBarcode As Bitmap
            bitmapBarcode = New Bitmap(risultato)

            picCodiceQR.Image = bitmapBarcode
            eui_txtPercorsoImmagineCodiceQR.Text = Application.StartupPath & PERCORSO_IMMAGINE_CODICE_QR & formatoImg
            picCodiceQR.Image.Save(eui_txtPercorsoImmagineCodiceQR.Text)
         Else
            MessageBox.Show("Per generare il codice QR è necessario specificare il percorso del file contenete il Menu.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_txtPercorsoDocumentoCodiceQR.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

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

   Private Sub AnteprimaDiStampa(ByVal nomeDoc As String, ByVal tabMenu As String, ByVal tabPiatti As String, ByVal sqlMenu As String, ByVal sqlPiatti As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapterMenu As New OleDbDataAdapter
         oleAdapterMenu.SelectCommand = New OleDbCommand(sqlMenu, cn)

         Dim oleAdapterPiatti As New OleDbDataAdapter
         oleAdapterPiatti.SelectCommand = New OleDbCommand(sqlPiatti, cn)

         Dim ds As New MenuDataSet
         ds.Clear()
         oleAdapterMenu.Fill(ds, tabMenu)
         oleAdapterPiatti.Fill(ds, tabPiatti)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepMenu(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

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
         OpenFileDialog1.FileName = RestituisciNomeFileDirectory(CMenu.Immagine)
         OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
         OpenFileDialog1.ShowDialog()

         CMenu.Immagine = OpenFileDialog1.FileName

         If File.Exists(CMenu.Immagine) = True Then
            Dim bmp As New Bitmap(CMenu.Immagine)
            picImmagine.Image = bmp
         End If

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
            CMenu.Immagine = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaImmagineCodiceQR()
      Try
         If Not (picCodiceQR.Image Is Nothing) Then
            picCodiceQR.Image.Dispose()
            picCodiceQR.Image = Nothing
            CMenu.ImmagineQR = String.Empty
            eui_txtPercorsoImmagineCodiceQR.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica la lista delle categorie dei piatti.
         CaricaListaCategorie(eui_lstCategorie, TAB_CATEGORIE)
         Procedure.CaricaListaCategorie(lstCategorie, TAB_CATEGORIE)

         ' Seleziona il primo elemento della lista categorie.
         If eui_lstCategorie.Items.Count <> 0 Then
            eui_lstCategorie.SelectedItemIndex = 0
         End If

         ' Visualizza i dati nei rispettivi campi.
         CMenu.LeggiDati(TAB_FORMAZIONE_MENU)

         ' Carica i dati contenuti nel database.
         eui_txtTitolo.Text = CMenu.Titolo
         eui_txtSottotitolo.Text = CMenu.Sottotitolo
         eui_txtNote.Text = CMenu.Note
         eui_txtPercorsoDocumentoCodiceQR.Text = CMenu.Documento
         eui_txtPercorsoImmagineCodiceQR.Text = CMenu.ImmagineQR
         eui_txtPercorsoReport.Text = CMenu.Modello

         ' Carica l'immagine.
         If CMenu.Immagine <> Nothing Then
            If File.Exists(CMenu.Immagine) = True Then
               Dim bmp As New Bitmap(CMenu.Immagine)
               picImmagine.Image = bmp
            End If
         End If

         ' Carica l'immagine del Codice QR.
         If CMenu.ImmagineQR <> Nothing Then
            If File.Exists(CMenu.ImmagineQR) = True Then
               Dim bmp As New Bitmap(CMenu.ImmagineQR)
               picCodiceQR.Image = bmp
            End If
         End If

         ' Carica e applica il Listino.
         eui_ddwnListino.Text = CMenu.Listino

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_MENU, MODULO_STRUMENTI_MENU)

         eui_txtTitolo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub Menu_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
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

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
      'Select Case e.Button.Tag
      '   Case "Stile1"
      '      tbStile1.Pushed = True
      '      tbStile2.Pushed = False
      '      tbStile3.Pushed = False
      '      percorsoReports = PERCORSO_REP_MENU_ARIAL
      '      strDescrizione = "(Stile 1)"

      '   Case "Stile2"
      '      tbStile1.Pushed = False
      '      tbStile2.Pushed = True
      '      tbStile3.Pushed = False
      '      percorsoReports = PERCORSO_REP_MENU_TIMES
      '      strDescrizione = "(Stile 2)"

      '   Case "Stile3"
      '      tbStile1.Pushed = False
      '      tbStile2.Pushed = False
      '      tbStile3.Pushed = True
      '      percorsoReports = PERCORSO_REP_MENU_COMIC
      '      strDescrizione = "(Stile 3)"
      'End Select
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
         Dim strDescrizione As String = "(" & sender.Text & ")"

         eui_ddwnListino.Text = sender.Text

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdListino2_Click(sender As Object, e As EventArgs) Handles eui_cmdListino2.Click
      Try
         Dim strDescrizione As String = "(" & sender.Text & ")"

         eui_ddwnListino.Text = sender.Text

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino3_Click(sender As Object, e As EventArgs) Handles eui_cmdListino3.Click
      Try
         Dim strDescrizione As String = "(" & sender.Text & ")"

         eui_ddwnListino.Text = sender.Text

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino4_Click(sender As Object, e As EventArgs) Handles eui_cmdListino4.Click
      Try
         Dim strDescrizione As String = "(" & sender.Text & ")"

         eui_ddwnListino.Text = sender.Text

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ModificaMenù, strDescrizione, MODULO_STRUMENTI_MENU)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnteprima_Click(sender As Object, e As EventArgs) Handles eui_cmdAnteprima.Click
      Try
         ' Salva l'ordine per le categorie dei piatti.
         SalvaOrdine()

         ' Salva tutti i dati nel database per essere caricati nel Report di stampa.
         SalvaDati()

         ' Visualizza l'anteprima del Report di stampa.
         repSqlMenu = String.Format("SELECT * FROM {0}", TAB_FORMAZIONE_MENU)
         repSqlPiatti = String.Format("SELECT * FROM {0} WHERE EscludiMenu = 'No' ORDER BY OrdCategoria ASC", TAB_PIATTI)

         AnteprimaDiStampa(eui_txtPercorsoReport.Text, TAB_FORMAZIONE_MENU, TAB_PIATTI, repSqlMenu, repSqlPiatti)

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

   Private Sub eui_cmdEliminaCodiceQR_Click(sender As Object, e As EventArgs) Handles eui_cmdEliminaCodiceQR.Click
      EliminaImmagineCodiceQR()
   End Sub

   Private Sub eui_cmdOK_Click(sender As Object, e As EventArgs) Handles eui_cmdOK.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Salva l'ordine per le categorie dei piatti.
         SalvaOrdine()

         ' Salva tutti i dati nel database per essere caricati nel Report di stampa.
         SalvaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Me.Close()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_ApriModello_Click(sender As Object, e As EventArgs) Handles eui_ApriModello.Click
      Try
         OpenFileDialog1.Filter = "File report |*.rdlc"

         OpenFileDialog1.FilterIndex = 1
         OpenFileDialog1.FileName = RestituisciNomeFileDirectory(CMenu.Modello)
         OpenFileDialog1.InitialDirectory = Application.StartupPath & "\Reports"
         OpenFileDialog1.ShowDialog()

         CMenu.Modello = OpenFileDialog1.FileName

         If File.Exists(CMenu.Modello) = True Then
            eui_txtPercorsoReport.Text = CMenu.Modello
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdGeneraFileBmp_Click_1(sender As Object, e As EventArgs) Handles eui_cmdGeneraFileBmp.Click
      Try
         GeneraCodiciBarre(eui_txtPercorsoDocumentoCodiceQR.Text, ".bmp")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdGeneraFileGif_Click(sender As Object, e As EventArgs) Handles eui_cmdGeneraFileGif.Click
      Try
         GeneraCodiciBarre(eui_txtPercorsoDocumentoCodiceQR.Text, ".gif")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdGeneraFileJpeg_Click(sender As Object, e As EventArgs) Handles eui_cmdGeneraFileJpeg.Click
      Try
         GeneraCodiciBarre(eui_txtPercorsoDocumentoCodiceQR.Text, ".jpeg")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdGeneraFilePng_Click(sender As Object, e As EventArgs) Handles eui_cmdGeneraFilePng.Click
      Try
         GeneraCodiciBarre(eui_txtPercorsoDocumentoCodiceQR.Text, ".png")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdGeneraFileTiff_Click(sender As Object, e As EventArgs) Handles eui_cmdGeneraFileTiff.Click
      Try
         GeneraCodiciBarre(eui_txtPercorsoDocumentoCodiceQR.Text, ".tiff")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdGeneraFileWmf_Click(sender As Object, e As EventArgs) Handles eui_cmdGeneraFileWmf.Click
      Try
         GeneraCodiciBarre(eui_txtPercorsoDocumentoCodiceQR.Text, ".wmf")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
