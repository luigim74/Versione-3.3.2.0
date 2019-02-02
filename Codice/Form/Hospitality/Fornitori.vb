' Nome form:            Fornitori
' Autore:               Luigi Montana, Montana Software
' Data creazione:       15/04/2006
' Data ultima modifica: 16/04/2006
' Descrizione:          Anagrafica Fornitori.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class Fornitori
   Inherits System.Windows.Forms.Form

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
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents txtRegione As System.Windows.Forms.TextBox
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents Label21 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtFax As System.Windows.Forms.TextBox
   Public WithEvents txtEmail As System.Windows.Forms.TextBox
   Public WithEvents txtTelUfficio As System.Windows.Forms.TextBox
   Public WithEvents txtCell As System.Windows.Forms.TextBox
   Public WithEvents txtTelCasa As System.Windows.Forms.TextBox
   Public WithEvents Label22 As System.Windows.Forms.Label
   Public WithEvents Label15 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents cmbNazione As System.Windows.Forms.ComboBox
   Public WithEvents txtIndirizzo1 As System.Windows.Forms.TextBox
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
   Public WithEvents txtInternet As System.Windows.Forms.TextBox
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdInserimento As System.Windows.Forms.Button
   Friend WithEvents cmdModifica As System.Windows.Forms.Button
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lvwAllegati As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdRimuovi As System.Windows.Forms.Button
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents cmbAttività As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents txtContatto As System.Windows.Forms.TextBox
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Public WithEvents txtRagSoc As System.Windows.Forms.TextBox
   Friend WithEvents cmdVai As System.Windows.Forms.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdScrivi As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fornitori))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbAttività = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtContatto = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.cmbNazione = New System.Windows.Forms.ComboBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.txtRegione = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo1 = New System.Windows.Forms.TextBox()
      Me.txtRagSoc = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.cmdVai = New System.Windows.Forms.Button()
      Me.cmdScrivi = New System.Windows.Forms.Button()
      Me.txtInternet = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtFax = New System.Windows.Forms.TextBox()
      Me.txtEmail = New System.Windows.Forms.TextBox()
      Me.txtTelUfficio = New System.Windows.Forms.TextBox()
      Me.txtCell = New System.Windows.Forms.TextBox()
      Me.txtTelCasa = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.TabPage4 = New System.Windows.Forms.TabPage()
      Me.cmdRimuovi = New System.Windows.Forms.Button()
      Me.cmdModifica = New System.Windows.Forms.Button()
      Me.cmdInserimento = New System.Windows.Forms.Button()
      Me.lvwAllegati = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage3.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      Me.TabPage6.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Salva, Me.Annulla})
      Me.ToolBar1.ButtonSize = New System.Drawing.Size(22, 22)
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(544, 26)
      Me.ToolBar1.TabIndex = 0
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'Salva
      '
      Me.Salva.ImageIndex = 9
      Me.Salva.Name = "Salva"
      Me.Salva.Tag = "Salva"
      Me.Salva.Text = "Salva"
      Me.Salva.ToolTipText = "Salva"
      '
      'Annulla
      '
      Me.Annulla.ImageIndex = 10
      Me.Annulla.Name = "Annulla"
      Me.Annulla.Tag = "Annulla"
      Me.Annulla.Text = "Annulla"
      Me.Annulla.ToolTipText = "Annulla"
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
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(544, 20)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(4, 2)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(16, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage4)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(544, 322)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbAttività)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.txtContatto)
      Me.TabPage1.Controls.Add(Me.Label16)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.cmbNazione)
      Me.TabPage1.Controls.Add(Me.txtPIva)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.txtRegione)
      Me.TabPage1.Controls.Add(Me.txtProv)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtCittà)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo1)
      Me.TabPage1.Controls.Add(Me.txtRagSoc)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(536, 296)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'cmbAttività
      '
      Me.cmbAttività.Location = New System.Drawing.Point(104, 256)
      Me.cmbAttività.Name = "cmbAttività"
      Me.cmbAttività.Size = New System.Drawing.Size(264, 21)
      Me.cmbAttività.TabIndex = 10
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(16, 256)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(42, 13)
      Me.Label7.TabIndex = 55713
      Me.Label7.Text = "Attività:"
      '
      'txtContatto
      '
      Me.txtContatto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtContatto.Location = New System.Drawing.Point(104, 232)
      Me.txtContatto.MaxLength = 255
      Me.txtContatto.Name = "txtContatto"
      Me.txtContatto.Size = New System.Drawing.Size(264, 20)
      Me.txtContatto.TabIndex = 9
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(16, 232)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(50, 13)
      Me.Label16.TabIndex = 55712
      Me.Label16.Text = "Contatto:"
      '
      'txtCodice
      '
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(104, 16)
      Me.txtCodice.MaxLength = 255
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.Size = New System.Drawing.Size(144, 20)
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 16)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(40, 13)
      Me.Label2.TabIndex = 55694
      Me.Label2.Text = "Codice"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(456, 160)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(64, 24)
      Me.EliminaImg.TabIndex = 12
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(384, 160)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(64, 24)
      Me.ApriImg.TabIndex = 11
      Me.ApriImg.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.Color.White
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(384, 16)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(136, 136)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 178
      Me.picFoto.TabStop = False
      '
      'cmbNazione
      '
      Me.cmbNazione.Location = New System.Drawing.Point(104, 168)
      Me.cmbNazione.Name = "cmbNazione"
      Me.cmbNazione.Size = New System.Drawing.Size(184, 21)
      Me.cmbNazione.TabIndex = 7
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(104, 200)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(184, 20)
      Me.txtPIva.TabIndex = 8
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(16, 200)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(69, 13)
      Me.Label31.TabIndex = 175
      Me.Label31.Text = "Partita I.V.A.:"
      '
      'txtRegione
      '
      Me.txtRegione.AcceptsReturn = True
      Me.txtRegione.BackColor = System.Drawing.SystemColors.Window
      Me.txtRegione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRegione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRegione.Location = New System.Drawing.Point(104, 144)
      Me.txtRegione.MaxLength = 50
      Me.txtRegione.Name = "txtRegione"
      Me.txtRegione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRegione.Size = New System.Drawing.Size(184, 20)
      Me.txtRegione.TabIndex = 6
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(248, 120)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(40, 20)
      Me.txtProv.TabIndex = 5
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(104, 120)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(49, 20)
      Me.txtCap.TabIndex = 4
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(104, 96)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(264, 20)
      Me.txtCittà.TabIndex = 3
      '
      'txtIndirizzo1
      '
      Me.txtIndirizzo1.AcceptsReturn = True
      Me.txtIndirizzo1.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo1.Location = New System.Drawing.Point(104, 72)
      Me.txtIndirizzo1.MaxLength = 100
      Me.txtIndirizzo1.Name = "txtIndirizzo1"
      Me.txtIndirizzo1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo1.Size = New System.Drawing.Size(264, 20)
      Me.txtIndirizzo1.TabIndex = 2
      '
      'txtRagSoc
      '
      Me.txtRagSoc.AcceptsReturn = True
      Me.txtRagSoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagSoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagSoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagSoc.Location = New System.Drawing.Point(104, 40)
      Me.txtRagSoc.MaxLength = 50
      Me.txtRagSoc.Name = "txtRagSoc"
      Me.txtRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagSoc.Size = New System.Drawing.Size(264, 20)
      Me.txtRagSoc.TabIndex = 1
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(16, 144)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(50, 13)
      Me.Label21.TabIndex = 168
      Me.Label21.Text = "Regione:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(16, 168)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(49, 13)
      Me.Label10.TabIndex = 167
      Me.Label10.Text = "Nazione:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(192, 120)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(54, 13)
      Me.Label9.TabIndex = 166
      Me.Label9.Text = "Provincia:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(16, 120)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 165
      Me.Label6.Text = "C.A.P.:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 96)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(31, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Città:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 72)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Indirizzo:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 40)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(86, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Ragione sociale:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.cmdVai)
      Me.TabPage3.Controls.Add(Me.cmdScrivi)
      Me.TabPage3.Controls.Add(Me.txtInternet)
      Me.TabPage3.Controls.Add(Me.Label14)
      Me.TabPage3.Controls.Add(Me.txtFax)
      Me.TabPage3.Controls.Add(Me.txtEmail)
      Me.TabPage3.Controls.Add(Me.txtTelUfficio)
      Me.TabPage3.Controls.Add(Me.txtCell)
      Me.TabPage3.Controls.Add(Me.txtTelCasa)
      Me.TabPage3.Controls.Add(Me.Label22)
      Me.TabPage3.Controls.Add(Me.Label1)
      Me.TabPage3.Controls.Add(Me.Label15)
      Me.TabPage3.Controls.Add(Me.Label13)
      Me.TabPage3.Controls.Add(Me.Label11)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(536, 296)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Tel./Internet"
      Me.TabPage3.ToolTipText = "Dati sul telefono e Internet"
      '
      'cmdVai
      '
      Me.cmdVai.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdVai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdVai.Location = New System.Drawing.Point(442, 160)
      Me.cmdVai.Name = "cmdVai"
      Me.cmdVai.Size = New System.Drawing.Size(48, 19)
      Me.cmdVai.TabIndex = 191
      Me.cmdVai.Text = "&Vai..."
      '
      'cmdScrivi
      '
      Me.cmdScrivi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdScrivi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdScrivi.Location = New System.Drawing.Point(442, 128)
      Me.cmdScrivi.Name = "cmdScrivi"
      Me.cmdScrivi.Size = New System.Drawing.Size(48, 19)
      Me.cmdScrivi.TabIndex = 190
      Me.cmdScrivi.Text = "&Scrivi..."
      '
      'txtInternet
      '
      Me.txtInternet.AcceptsReturn = True
      Me.txtInternet.BackColor = System.Drawing.SystemColors.Window
      Me.txtInternet.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtInternet.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtInternet.Location = New System.Drawing.Point(96, 160)
      Me.txtInternet.MaxLength = 0
      Me.txtInternet.Name = "txtInternet"
      Me.txtInternet.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtInternet.Size = New System.Drawing.Size(344, 20)
      Me.txtInternet.TabIndex = 4
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(32, 160)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(46, 13)
      Me.Label14.TabIndex = 189
      Me.Label14.Text = "Internet:"
      '
      'txtFax
      '
      Me.txtFax.AcceptsReturn = True
      Me.txtFax.BackColor = System.Drawing.SystemColors.Window
      Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtFax.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtFax.Location = New System.Drawing.Point(96, 64)
      Me.txtFax.MaxLength = 15
      Me.txtFax.Name = "txtFax"
      Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtFax.Size = New System.Drawing.Size(233, 20)
      Me.txtFax.TabIndex = 1
      '
      'txtEmail
      '
      Me.txtEmail.AcceptsReturn = True
      Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
      Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtEmail.Location = New System.Drawing.Point(96, 128)
      Me.txtEmail.MaxLength = 100
      Me.txtEmail.Name = "txtEmail"
      Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEmail.Size = New System.Drawing.Size(344, 20)
      Me.txtEmail.TabIndex = 3
      '
      'txtTelUfficio
      '
      Me.txtTelUfficio.AcceptsReturn = True
      Me.txtTelUfficio.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelUfficio.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelUfficio.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTelUfficio.Location = New System.Drawing.Point(96, 32)
      Me.txtTelUfficio.MaxLength = 15
      Me.txtTelUfficio.Name = "txtTelUfficio"
      Me.txtTelUfficio.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelUfficio.Size = New System.Drawing.Size(233, 20)
      Me.txtTelUfficio.TabIndex = 0
      '
      'txtCell
      '
      Me.txtCell.AcceptsReturn = True
      Me.txtCell.BackColor = System.Drawing.SystemColors.Window
      Me.txtCell.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCell.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCell.Location = New System.Drawing.Point(96, 96)
      Me.txtCell.MaxLength = 15
      Me.txtCell.Name = "txtCell"
      Me.txtCell.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCell.Size = New System.Drawing.Size(233, 20)
      Me.txtCell.TabIndex = 2
      '
      'txtTelCasa
      '
      Me.txtTelCasa.AcceptsReturn = True
      Me.txtTelCasa.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelCasa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelCasa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTelCasa.Location = New System.Drawing.Point(96, 248)
      Me.txtTelCasa.MaxLength = 15
      Me.txtTelCasa.Name = "txtTelCasa"
      Me.txtTelCasa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelCasa.Size = New System.Drawing.Size(233, 20)
      Me.txtTelCasa.TabIndex = 5
      Me.txtTelCasa.Visible = False
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(32, 96)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(50, 13)
      Me.Label22.TabIndex = 117
      Me.Label22.Text = "Cellulare:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(32, 32)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(59, 13)
      Me.Label1.TabIndex = 116
      Me.Label1.Text = "Tel. ufficio:"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(32, 128)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(38, 13)
      Me.Label15.TabIndex = 115
      Me.Label15.Text = "E-mail:"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(32, 64)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(27, 13)
      Me.Label13.TabIndex = 114
      Me.Label13.Text = "Fax:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(32, 248)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(54, 13)
      Me.Label11.TabIndex = 113
      Me.Label11.Text = "Tel. casa:"
      Me.Label11.Visible = False
      '
      'TabPage4
      '
      Me.TabPage4.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage4.Controls.Add(Me.cmdRimuovi)
      Me.TabPage4.Controls.Add(Me.cmdModifica)
      Me.TabPage4.Controls.Add(Me.cmdInserimento)
      Me.TabPage4.Controls.Add(Me.lvwAllegati)
      Me.TabPage4.Location = New System.Drawing.Point(4, 22)
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Size = New System.Drawing.Size(536, 296)
      Me.TabPage4.TabIndex = 3
      Me.TabPage4.Text = "Documenti allegati"
      '
      'cmdRimuovi
      '
      Me.cmdRimuovi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRimuovi.Location = New System.Drawing.Point(432, 256)
      Me.cmdRimuovi.Name = "cmdRimuovi"
      Me.cmdRimuovi.Size = New System.Drawing.Size(88, 24)
      Me.cmdRimuovi.TabIndex = 3
      Me.cmdRimuovi.Text = "&Rimuovi"
      '
      'cmdModifica
      '
      Me.cmdModifica.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdModifica.Location = New System.Drawing.Point(336, 256)
      Me.cmdModifica.Name = "cmdModifica"
      Me.cmdModifica.Size = New System.Drawing.Size(88, 24)
      Me.cmdModifica.TabIndex = 2
      Me.cmdModifica.Text = "&Modifica"
      '
      'cmdInserimento
      '
      Me.cmdInserimento.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdInserimento.Location = New System.Drawing.Point(248, 256)
      Me.cmdInserimento.Name = "cmdInserimento"
      Me.cmdInserimento.Size = New System.Drawing.Size(80, 24)
      Me.cmdInserimento.TabIndex = 1
      Me.cmdInserimento.Text = "&Inserimento"
      '
      'lvwAllegati
      '
      Me.lvwAllegati.AllowColumnReorder = True
      Me.lvwAllegati.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
      Me.lvwAllegati.Location = New System.Drawing.Point(0, 0)
      Me.lvwAllegati.MultiSelect = False
      Me.lvwAllegati.Name = "lvwAllegati"
      Me.lvwAllegati.Size = New System.Drawing.Size(535, 248)
      Me.lvwAllegati.StateImageList = Me.ImageList1
      Me.lvwAllegati.TabIndex = 0
      Me.lvwAllegati.UseCompatibleStateImageBehavior = False
      Me.lvwAllegati.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Documento"
      Me.ColumnHeader1.Width = 200
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Data"
      Me.ColumnHeader2.Width = 75
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Ora"
      Me.ColumnHeader3.Width = 75
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Note"
      Me.ColumnHeader4.Width = 500
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "Percorso"
      Me.ColumnHeader5.Width = 500
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Text = "Codice"
      Me.ColumnHeader6.Width = 0
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(536, 296)
      Me.TabPage6.TabIndex = 5
      Me.TabPage6.Text = "Note"
      Me.TabPage6.ToolTipText = "Note varie"
      '
      'txtNote
      '
      Me.txtNote.AcceptsReturn = True
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
      Me.txtNote.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNote.Location = New System.Drawing.Point(0, 0)
      Me.txtNote.MaxLength = 0
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(536, 296)
      Me.txtNote.TabIndex = 0
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Fornitori
      '
      Me.AcceptButton = Me.ApriImg
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(544, 368)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Fornitori"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Fornitori"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private AFornitori As New Anagrafiche.AziendaCliente(ConnString)
   Private IAllegati As New Allegati
   Private CConvalida As New ConvalidaKeyPress

   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_ATTIVITA As String = "Attività"
   Const TAB_ALLEGATI As String = "Forn_Allegati"
   Const NOME_TABELLA As String = "Fornitori"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   Dim dt As DataTable

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Function SalvaDati() As Boolean
      Try
         ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
         AggiornaTabella(cmbNazione, TAB_NAZIONI)
         AggiornaTabella(cmbAttività, TAB_ATTIVITA)

         ' Assegna i dati dei campi della classe alle caselle di testo.
         AFornitori.RagSociale = FormattaApici(txtRagSoc.Text)
         AFornitori.PIva = FormattaApici(txtPIva.Text)
         AFornitori.Indirizzo1 = FormattaApici(txtIndirizzo1.Text)
         AFornitori.Cap = FormattaApici(txtCap.Text)
         AFornitori.Città = FormattaApici(txtCittà.Text)
         AFornitori.Provincia = FormattaApici(txtProv.Text)
         AFornitori.Regione = FormattaApici(txtRegione.Text)
         AFornitori.Nazione = FormattaApici(cmbNazione.Text)
         AFornitori.Contatto = FormattaApici(txtContatto.Text)
         AFornitori.Attività = FormattaApici(cmbAttività.Text)
         AFornitori.TelUfficio = FormattaApici(txtTelUfficio.Text)
         AFornitori.Cell = FormattaApici(txtCell.Text)
         AFornitori.Fax = FormattaApici(txtFax.Text)
         AFornitori.Email = FormattaApici(txtEmail.Text)
         AFornitori.Internet = FormattaApici(txtInternet.Text)
         AFornitori.Note = FormattaApici(txtNote.Text)
         AFornitori.NoteDoc = ""
         AFornitori.CodAzienda = ""
         AFornitori.Sconto = VALORE_ZERO
         AFornitori.Iva = VALORE_ZERO

         ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
         ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
         If Me.Tag <> "" Then
            Return AFornitori.ModificaDati(NOME_TABELLA, Me.Tag)
         Else
            Return AFornitori.InserisciDati(NOME_TABELLA)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Sub InserisciImmagine()
      Try
         OpenFileDialog1.Filter = "Tutti i formati |*.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" & _
                                  "Bmp (Bitmap di Windows)|*.Bmp|" & _
                                  "Gif |*.Gif|" & _
                                  "Jpeg/Jpg |*.Jpg; *.Jpeg |" & _
                                  "Png |*.Png|" & _
                                  "Tga |*.Tga|" & _
                                  "Tiff |*.Tiff|" & _
                                  "Wmf (Metafile di Windows) |*.Wmf"

         OpenFileDialog1.FilterIndex = 1
         OpenFileDialog1.ShowDialog()

         AFornitori.Immagine = OpenFileDialog1.FileName

         If File.Exists(AFornitori.Immagine) = True Then
            Dim bmp As New Bitmap(AFornitori.Immagine)
            picFoto.Image = bmp
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaImmagine()
      Try
         If Not (picFoto.Image Is Nothing) Then
            picFoto.Image.Dispose()
            picFoto.Image = Nothing
            AFornitori.Immagine = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      Try
         OpenFileDialog1.Filter = "Tutti i file |*.*"

         OpenFileDialog1.FilterIndex = 1

         IAllegati.IdCliente = CInt(AFornitori.Codice)

         If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Assegna i dati dei campi della classe alle caselle di testo.
            IAllegati.Documento = Path.GetFileName(OpenFileDialog1.FileName)
            IAllegati.Data = CStr(Today)
            IAllegati.Ora = CStr(TimeOfDay)
            IAllegati.Percorso = OpenFileDialog1.FileName
            IAllegati.Estensione = Path.GetExtension(OpenFileDialog1.FileName)
         Else
            If ins = True Then
               Return False
            End If
         End If

         Dim val As String
         val = InputBox("Digitare il testo per il campo Note.", "Note", note)
         If val <> "" Then
            IAllegati.Note = val
         Else
            IAllegati.Note = note
         End If

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub RimuoviAllegati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Documento As String = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf & _
                           "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

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
      End Try
   End Sub

   Private Sub ConvalidaAllegati()
      Try
         ' Carica la lista dei componenti aggiuntivi.
         If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, AFornitori.Codice) = True Then
            cmdModifica.Enabled = True
            cmdRimuovi.Enabled = True
         Else
            cmdModifica.Enabled = False
            cmdRimuovi.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Function LeggiNumRecord(ByVal tabella As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer = 0
         Dim cmd As New OleDbCommand("SELECT IdPartita FROM " & tabella & " WHERE IdCliente = '" & Me.Tag & "' GROUP BY IdPartita", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            i = i + 1
         Loop

         Return i

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub Fornitori_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            ' Visualizza i dati nei rispettivi campi.
            AFornitori.LeggiDati(NOME_TABELLA, Me.Tag)

            ' Assegna i dati dei campi della classe alle caselle di testo.
            txtCodice.Text = AFornitori.Codice
            txtRagSoc.Text = AFornitori.RagSociale
            txtPIva.Text = AFornitori.PIva
            txtIndirizzo1.Text = AFornitori.Indirizzo1
            txtCap.Text = AFornitori.Cap
            txtCittà.Text = AFornitori.Città
            txtProv.Text = AFornitori.Provincia
            txtRegione.Text = AFornitori.Regione
            cmbNazione.Text = AFornitori.Nazione
            txtContatto.Text = AFornitori.Contatto
            cmbAttività.Text = AFornitori.Attività
            txtTelCasa.Text = AFornitori.TelCasa
            txtTelUfficio.Text = AFornitori.TelUfficio
            txtCell.Text = AFornitori.Cell
            txtFax.Text = AFornitori.Fax
            txtEmail.Text = AFornitori.Email
            txtInternet.Text = AFornitori.Internet
            txtNote.Text = AFornitori.Note

            If AFornitori.Immagine <> Nothing Then
               If File.Exists(AFornitori.Immagine) = True Then
                  Dim bmp As New Bitmap(AFornitori.Immagine)
                  picFoto.Image = bmp
               End If
            End If

            ' Per i fornitori già esistenti nel database (con un id)
            ' rende la scheda Allegati disponibile.
            TabControl1.TabPages(2).Enabled = True
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.

            ' Per i nuovi fornitori che non sono nel database (con un id)
            ' disattiva la scheda Allegati.
            TabControl1.TabPages(2).Enabled = False
         End If

         ' Carica le liste.
         CaricaLista(cmbNazione, TAB_NAZIONI)
         CaricaLista(cmbAttività, TAB_ATTIVITA)

         ' Carica la lista delle degli allegati.
         ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtRagSoc.Text, "")

         ' Imposta lo stato attivo.
         txtRagSoc.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub Fornitori_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_FORNITORI)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmFornitori) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmFornitori.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & AFornitori.RagSociale & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_FORNITORI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_FORNITORI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               Me.txtRagSoc.Focus()

            Case 1
               ' Imposta lo stato attivo.
               Me.txtTelUfficio.Focus()

            Case 2
               ' Imposta lo stato attivo.
               Me.lvwAllegati.Focus()
               ' Imposta il pulsante di default.
               cmdInserimento.NotifyDefault(True)

            Case 3
               ' Imposta lo stato attivo.
               Me.txtNote.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ApriImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApriImg.Click
      InserisciImmagine()
   End Sub

   Private Sub EliminaImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaImg.Click
      ApriImg.NotifyDefault(False)
      EliminaImmagine()
   End Sub

   Private Sub cmdInserimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInserimento.Click
      Try
         If ImpostaDatiAllegati("", True) = True Then
            IAllegati.InserisciDati(TAB_ALLEGATI)
            ConvalidaAllegati()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModifica.Click
      Try
         cmdInserimento.NotifyDefault(False)

         With IAllegati
            .Documento = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
            .Data = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(1).Text
            .Ora = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(2).Text
            .Note = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(3).Text
            .Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

            If ImpostaDatiAllegati(.Note, False) = True Then
               .ModificaDati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
               ConvalidaAllegati()
            End If
         End With

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

   Private Sub cmdRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRimuovi.Click
      Try
         cmdInserimento.NotifyDefault(False)

         RimuoviAllegati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
         ConvalidaAllegati()

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

   Private Sub lvwAllegati_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwAllegati.DoubleClick
      Dim Estensione As String
      Dim NomeFile As String
      Dim Percorso As String
      Dim PercorsoApp As String
      Dim NomeApp As String
      Dim Proc As New Process

      Try
         ' Nome del file.
         NomeFile = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
         ' Percorso del file.
         Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

         ' Ottiene l'estensione del file.
         Estensione = Path.GetExtension(Percorso)

         Select Case Estensione.ToUpper
            Case ".DOC", ".RTF"
               ' Word
               NomeApp = "WINWORD.EXE"

            Case ".XLS"
               ' Excel
               NomeApp = "EXCEL.EXE"

            Case ".MDB"
               ' Access
               NomeApp = "MSACCESS.EXE"

            Case ".PPT"
               ' Power Point
               NomeApp = "POWERPNT.EXE"

            Case ".TXT"
               ' Blocco note.
               NomeApp = "NOTEPAD.EXE"

            Case ".PDF"
               ' Acrobat Reader
               NomeApp = "ACRORD32.EXE"

            Case ".HTM"
               ' Internet Explorer
               NomeApp = "IEXPLORE.EXE"
         End Select

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdVai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVai.Click
      Try
         ApriSitoInternet(txtInternet.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdVai_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVai.MouseEnter
      ToolTip1.SetToolTip(sender, "Vai a """ & txtInternet.Text & """")
   End Sub

   Private Sub cmdScrivi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrivi.Click
      Try
         ScriviEmail(txtEmail.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdScrivi_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdScrivi.MouseEnter
      ToolTip1.SetToolTip(sender, "Scrivi a """ & txtEmail.Text & """")
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtPIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTelCasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelCasa.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTelUfficio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelUfficio.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtCell_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCell.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

End Class
