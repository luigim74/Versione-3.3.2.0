' Nome form:            frmClienti
' Autore:               Luigi Montana, Montana Software
' Data creazione:       07/01/2006
' Data ultima modifica: 23/06/2006
' Descrizione:          Anagrafica Clienti.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class frmClienti
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
   Public WithEvents txtCodFisc As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents Label30 As System.Windows.Forms.Label
   Public WithEvents txtNome As System.Windows.Forms.TextBox
   Public WithEvents txtRegione As System.Windows.Forms.TextBox
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents txtCognome As System.Windows.Forms.TextBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents label As System.Windows.Forms.Label
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
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label15 As System.Windows.Forms.Label
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents cmbNazione As System.Windows.Forms.ComboBox
   Friend WithEvents cmbTitolo As System.Windows.Forms.ComboBox
   Public WithEvents txtIndirizzo1 As System.Windows.Forms.TextBox
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
   Public WithEvents txtInternet As System.Windows.Forms.TextBox
   Public WithEvents Label14 As System.Windows.Forms.Label
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
   Public WithEvents Label39 As System.Windows.Forms.Label
   Friend WithEvents chkPrivacy As System.Windows.Forms.CheckBox
   Friend WithEvents cmbTipoCliente As System.Windows.Forms.ComboBox
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents txtDataNascita As System.Windows.Forms.TextBox
   Public WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents cmdScrivi As System.Windows.Forms.Button
   Friend WithEvents cmdVai As System.Windows.Forms.Button
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txtSconto As System.Windows.Forms.TextBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents txtCodTessera As System.Windows.Forms.TextBox
   Public WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents tbpStatGioco As System.Windows.Forms.TabPage
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents txtTotPartite As System.Windows.Forms.TextBox
   Public WithEvents Label17 As System.Windows.Forms.Label
   Public WithEvents txtTotOre As System.Windows.Forms.TextBox
   Public WithEvents Label18 As System.Windows.Forms.Label
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Public WithEvents txtIva As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClienti))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.txtCodTessera = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.txtIva = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtSconto = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtDataNascita = New System.Windows.Forms.TextBox()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.cmbTipoCliente = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.cmbNazione = New System.Windows.Forms.ComboBox()
      Me.cmbTitolo = New System.Windows.Forms.ComboBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.txtCodFisc = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.txtRegione = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo1 = New System.Windows.Forms.TextBox()
      Me.txtCognome = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.label = New System.Windows.Forms.Label()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.chkPrivacy = New System.Windows.Forms.CheckBox()
      Me.Label39 = New System.Windows.Forms.Label()
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
      Me.tbpStatGioco = New System.Windows.Forms.TabPage()
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtTotPartite = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.txtTotOre = New System.Windows.Forms.TextBox()
      Me.Label18 = New System.Windows.Forms.Label()
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
      Me.tbpStatGioco.SuspendLayout()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel2.SuspendLayout()
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
      Me.TabControl1.Controls.Add(Me.tbpStatGioco)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(544, 338)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.txtCodTessera)
      Me.TabPage1.Controls.Add(Me.Label16)
      Me.TabPage1.Controls.Add(Me.txtIva)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.txtSconto)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.txtDataNascita)
      Me.TabPage1.Controls.Add(Me.Label29)
      Me.TabPage1.Controls.Add(Me.cmbTipoCliente)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.cmbNazione)
      Me.TabPage1.Controls.Add(Me.cmbTitolo)
      Me.TabPage1.Controls.Add(Me.txtPIva)
      Me.TabPage1.Controls.Add(Me.txtCodFisc)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.Label30)
      Me.TabPage1.Controls.Add(Me.txtNome)
      Me.TabPage1.Controls.Add(Me.txtRegione)
      Me.TabPage1.Controls.Add(Me.txtProv)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtCittà)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo1)
      Me.TabPage1.Controls.Add(Me.txtCognome)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.chkPrivacy)
      Me.TabPage1.Controls.Add(Me.Label39)
      Me.TabPage1.ForeColor = System.Drawing.Color.Black
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(536, 312)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'txtCodTessera
      '
      Me.txtCodTessera.AcceptsReturn = True
      Me.txtCodTessera.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodTessera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodTessera.ForeColor = System.Drawing.Color.Red
      Me.txtCodTessera.Location = New System.Drawing.Point(107, 280)
      Me.txtCodTessera.MaxLength = 16
      Me.txtCodTessera.Name = "txtCodTessera"
      Me.txtCodTessera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodTessera.Size = New System.Drawing.Size(184, 20)
      Me.txtCodTessera.TabIndex = 15
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(14, 280)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(80, 13)
      Me.Label16.TabIndex = 232
      Me.Label16.Text = "Codice tessera:"
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIva.Location = New System.Drawing.Point(480, 248)
      Me.txtIva.MaxLength = 16
      Me.txtIva.Name = "txtIva"
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(40, 20)
      Me.txtIva.TabIndex = 14
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(440, 250)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(38, 13)
      Me.Label12.TabIndex = 230
      Me.Label12.Text = "% IVA:"
      '
      'txtSconto
      '
      Me.txtSconto.AcceptsReturn = True
      Me.txtSconto.BackColor = System.Drawing.SystemColors.Window
      Me.txtSconto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSconto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtSconto.Location = New System.Drawing.Point(384, 248)
      Me.txtSconto.MaxLength = 16
      Me.txtSconto.Name = "txtSconto"
      Me.txtSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSconto.Size = New System.Drawing.Size(40, 20)
      Me.txtSconto.TabIndex = 13
      Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(302, 250)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(55, 13)
      Me.Label8.TabIndex = 228
      Me.Label8.Text = "% Sconto:"
      '
      'txtDataNascita
      '
      Me.txtDataNascita.AcceptsReturn = True
      Me.txtDataNascita.BackColor = System.Drawing.SystemColors.Window
      Me.txtDataNascita.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDataNascita.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDataNascita.Location = New System.Drawing.Point(384, 200)
      Me.txtDataNascita.MaxLength = 10
      Me.txtDataNascita.Name = "txtDataNascita"
      Me.txtDataNascita.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDataNascita.Size = New System.Drawing.Size(136, 20)
      Me.txtDataNascita.TabIndex = 9
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.BackColor = System.Drawing.Color.Transparent
      Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label29.ForeColor = System.Drawing.Color.Black
      Me.Label29.Location = New System.Drawing.Point(302, 200)
      Me.Label29.Name = "Label29"
      Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label29.Size = New System.Drawing.Size(81, 13)
      Me.Label29.TabIndex = 226
      Me.Label29.Text = "Data di nascita:"
      '
      'cmbTipoCliente
      '
      Me.cmbTipoCliente.Location = New System.Drawing.Point(107, 248)
      Me.cmbTipoCliente.Name = "cmbTipoCliente"
      Me.cmbTipoCliente.Size = New System.Drawing.Size(184, 21)
      Me.cmbTipoCliente.TabIndex = 12
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(14, 248)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(89, 13)
      Me.Label7.TabIndex = 185
      Me.Label7.Text = "Categoria cliente:"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(456, 160)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(64, 24)
      Me.EliminaImg.TabIndex = 19
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(384, 160)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(64, 24)
      Me.ApriImg.TabIndex = 18
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
      Me.cmbNazione.Location = New System.Drawing.Point(107, 200)
      Me.cmbNazione.Name = "cmbNazione"
      Me.cmbNazione.Size = New System.Drawing.Size(184, 21)
      Me.cmbNazione.TabIndex = 8
      '
      'cmbTitolo
      '
      Me.cmbTitolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTitolo.Location = New System.Drawing.Point(107, 16)
      Me.cmbTitolo.Name = "cmbTitolo"
      Me.cmbTitolo.Size = New System.Drawing.Size(184, 21)
      Me.cmbTitolo.TabIndex = 0
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(107, 224)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(184, 20)
      Me.txtPIva.TabIndex = 10
      '
      'txtCodFisc
      '
      Me.txtCodFisc.AcceptsReturn = True
      Me.txtCodFisc.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodFisc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodFisc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodFisc.Location = New System.Drawing.Point(384, 224)
      Me.txtCodFisc.MaxLength = 16
      Me.txtCodFisc.Name = "txtCodFisc"
      Me.txtCodFisc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodFisc.Size = New System.Drawing.Size(136, 20)
      Me.txtCodFisc.TabIndex = 11
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(14, 224)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(69, 13)
      Me.Label31.TabIndex = 175
      Me.Label31.Text = "Partita I.V.A.:"
      '
      'Label30
      '
      Me.Label30.AutoSize = True
      Me.Label30.BackColor = System.Drawing.Color.Transparent
      Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label30.ForeColor = System.Drawing.Color.Black
      Me.Label30.Location = New System.Drawing.Point(302, 224)
      Me.Label30.Name = "Label30"
      Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label30.Size = New System.Drawing.Size(76, 13)
      Me.Label30.TabIndex = 174
      Me.Label30.Text = "Codice fiscale:"
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(107, 72)
      Me.txtNome.MaxLength = 50
      Me.txtNome.Name = "txtNome"
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(264, 20)
      Me.txtNome.TabIndex = 2
      '
      'txtRegione
      '
      Me.txtRegione.AcceptsReturn = True
      Me.txtRegione.BackColor = System.Drawing.SystemColors.Window
      Me.txtRegione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRegione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRegione.Location = New System.Drawing.Point(107, 176)
      Me.txtRegione.MaxLength = 50
      Me.txtRegione.Name = "txtRegione"
      Me.txtRegione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRegione.Size = New System.Drawing.Size(184, 20)
      Me.txtRegione.TabIndex = 7
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(251, 152)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(40, 20)
      Me.txtProv.TabIndex = 6
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(107, 152)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(49, 20)
      Me.txtCap.TabIndex = 5
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(107, 128)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(264, 20)
      Me.txtCittà.TabIndex = 4
      '
      'txtIndirizzo1
      '
      Me.txtIndirizzo1.AcceptsReturn = True
      Me.txtIndirizzo1.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo1.Location = New System.Drawing.Point(107, 104)
      Me.txtIndirizzo1.MaxLength = 100
      Me.txtIndirizzo1.Name = "txtIndirizzo1"
      Me.txtIndirizzo1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo1.Size = New System.Drawing.Size(264, 20)
      Me.txtIndirizzo1.TabIndex = 3
      '
      'txtCognome
      '
      Me.txtCognome.AcceptsReturn = True
      Me.txtCognome.BackColor = System.Drawing.SystemColors.Window
      Me.txtCognome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCognome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCognome.Location = New System.Drawing.Point(107, 48)
      Me.txtCognome.MaxLength = 50
      Me.txtCognome.Name = "txtCognome"
      Me.txtCognome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCognome.Size = New System.Drawing.Size(264, 20)
      Me.txtCognome.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(14, 72)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 170
      Me.Label2.Text = "Nome:"
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(14, 16)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(90, 13)
      Me.label.TabIndex = 169
      Me.label.Text = "Forma di cortesia:"
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(14, 176)
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
      Me.Label10.Location = New System.Drawing.Point(14, 200)
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
      Me.Label9.Location = New System.Drawing.Point(195, 152)
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
      Me.Label6.Location = New System.Drawing.Point(14, 152)
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
      Me.Label5.Location = New System.Drawing.Point(14, 128)
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
      Me.Label4.Location = New System.Drawing.Point(14, 104)
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
      Me.Label3.Location = New System.Drawing.Point(14, 48)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(55, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Cognome:"
      '
      'chkPrivacy
      '
      Me.chkPrivacy.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkPrivacy.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPrivacy.Location = New System.Drawing.Point(384, 280)
      Me.chkPrivacy.Name = "chkPrivacy"
      Me.chkPrivacy.Size = New System.Drawing.Size(16, 16)
      Me.chkPrivacy.TabIndex = 16
      '
      'Label39
      '
      Me.Label39.AutoSize = True
      Me.Label39.BackColor = System.Drawing.Color.Transparent
      Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label39.ForeColor = System.Drawing.Color.Black
      Me.Label39.Location = New System.Drawing.Point(400, 280)
      Me.Label39.Name = "Label39"
      Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label39.Size = New System.Drawing.Size(126, 13)
      Me.Label39.TabIndex = 17
      Me.Label39.Text = "Autorizza trattamento dati"
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
      Me.TabPage3.Size = New System.Drawing.Size(536, 312)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Tel./Internet"
      Me.TabPage3.ToolTipText = "Dati sul telefono e Internet"
      '
      'cmdVai
      '
      Me.cmdVai.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdVai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdVai.Location = New System.Drawing.Point(443, 192)
      Me.cmdVai.Name = "cmdVai"
      Me.cmdVai.Size = New System.Drawing.Size(48, 19)
      Me.cmdVai.TabIndex = 7
      Me.cmdVai.Text = "&Vai..."
      '
      'cmdScrivi
      '
      Me.cmdScrivi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdScrivi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdScrivi.Location = New System.Drawing.Point(443, 160)
      Me.cmdScrivi.Name = "cmdScrivi"
      Me.cmdScrivi.Size = New System.Drawing.Size(48, 19)
      Me.cmdScrivi.TabIndex = 5
      Me.cmdScrivi.Text = "&Scrivi..."
      '
      'txtInternet
      '
      Me.txtInternet.AcceptsReturn = True
      Me.txtInternet.BackColor = System.Drawing.SystemColors.Window
      Me.txtInternet.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtInternet.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtInternet.Location = New System.Drawing.Point(96, 192)
      Me.txtInternet.MaxLength = 0
      Me.txtInternet.Name = "txtInternet"
      Me.txtInternet.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtInternet.Size = New System.Drawing.Size(344, 20)
      Me.txtInternet.TabIndex = 6
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(32, 192)
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
      Me.txtFax.Location = New System.Drawing.Point(96, 96)
      Me.txtFax.MaxLength = 15
      Me.txtFax.Name = "txtFax"
      Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtFax.Size = New System.Drawing.Size(233, 20)
      Me.txtFax.TabIndex = 2
      '
      'txtEmail
      '
      Me.txtEmail.AcceptsReturn = True
      Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
      Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtEmail.Location = New System.Drawing.Point(96, 160)
      Me.txtEmail.MaxLength = 100
      Me.txtEmail.Name = "txtEmail"
      Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEmail.Size = New System.Drawing.Size(344, 20)
      Me.txtEmail.TabIndex = 4
      '
      'txtTelUfficio
      '
      Me.txtTelUfficio.AcceptsReturn = True
      Me.txtTelUfficio.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelUfficio.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelUfficio.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTelUfficio.Location = New System.Drawing.Point(96, 64)
      Me.txtTelUfficio.MaxLength = 15
      Me.txtTelUfficio.Name = "txtTelUfficio"
      Me.txtTelUfficio.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelUfficio.Size = New System.Drawing.Size(233, 20)
      Me.txtTelUfficio.TabIndex = 1
      '
      'txtCell
      '
      Me.txtCell.AcceptsReturn = True
      Me.txtCell.BackColor = System.Drawing.SystemColors.Window
      Me.txtCell.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCell.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCell.Location = New System.Drawing.Point(96, 128)
      Me.txtCell.MaxLength = 15
      Me.txtCell.Name = "txtCell"
      Me.txtCell.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCell.Size = New System.Drawing.Size(233, 20)
      Me.txtCell.TabIndex = 3
      '
      'txtTelCasa
      '
      Me.txtTelCasa.AcceptsReturn = True
      Me.txtTelCasa.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelCasa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelCasa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTelCasa.Location = New System.Drawing.Point(96, 32)
      Me.txtTelCasa.MaxLength = 15
      Me.txtTelCasa.Name = "txtTelCasa"
      Me.txtTelCasa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelCasa.Size = New System.Drawing.Size(233, 20)
      Me.txtTelCasa.TabIndex = 0
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(32, 128)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(50, 13)
      Me.Label22.TabIndex = 117
      Me.Label22.Text = "Cellulare:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(32, 64)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(59, 13)
      Me.Label1.TabIndex = 116
      Me.Label1.Text = "Tel. ufficio:"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(32, 160)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(38, 13)
      Me.Label15.TabIndex = 115
      Me.Label15.Text = "E-mail:"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(32, 96)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(27, 13)
      Me.Label13.TabIndex = 114
      Me.Label13.Text = "Fax:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(32, 32)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(54, 13)
      Me.Label11.TabIndex = 113
      Me.Label11.Text = "Tel. casa:"
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
      Me.TabPage4.Size = New System.Drawing.Size(536, 312)
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
      Me.lvwAllegati.FullRowSelect = True
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
      'tbpStatGioco
      '
      Me.tbpStatGioco.Controls.Add(Me.DataGrid1)
      Me.tbpStatGioco.Controls.Add(Me.Panel2)
      Me.tbpStatGioco.Location = New System.Drawing.Point(4, 22)
      Me.tbpStatGioco.Name = "tbpStatGioco"
      Me.tbpStatGioco.Size = New System.Drawing.Size(536, 312)
      Me.tbpStatGioco.TabIndex = 6
      Me.tbpStatGioco.Text = "Statistiche di gioco"
      Me.tbpStatGioco.UseVisualStyleBackColor = True
      '
      'DataGrid1
      '
      Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.CaptionText = "ELENCO PARTITE GIOCATE"
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGrid1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 40)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(536, 272)
      Me.DataGrid1.TabIndex = 233
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.txtTotPartite)
      Me.Panel2.Controls.Add(Me.Label17)
      Me.Panel2.Controls.Add(Me.txtTotOre)
      Me.Panel2.Controls.Add(Me.Label18)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel2.Location = New System.Drawing.Point(0, 0)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(536, 40)
      Me.Panel2.TabIndex = 232
      '
      'txtTotPartite
      '
      Me.txtTotPartite.AcceptsReturn = True
      Me.txtTotPartite.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotPartite.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotPartite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotPartite.ForeColor = System.Drawing.Color.Red
      Me.txtTotPartite.Location = New System.Drawing.Point(152, 8)
      Me.txtTotPartite.MaxLength = 0
      Me.txtTotPartite.Name = "txtTotPartite"
      Me.txtTotPartite.ReadOnly = True
      Me.txtTotPartite.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotPartite.Size = New System.Drawing.Size(92, 20)
      Me.txtTotPartite.TabIndex = 233
      Me.txtTotPartite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label17.ForeColor = System.Drawing.SystemColors.Window
      Me.Label17.Location = New System.Drawing.Point(16, 10)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(133, 13)
      Me.Label17.TabIndex = 234
      Me.Label17.Text = "Totale partite giocate:"
      '
      'txtTotOre
      '
      Me.txtTotOre.AcceptsReturn = True
      Me.txtTotOre.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotOre.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotOre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotOre.ForeColor = System.Drawing.Color.Red
      Me.txtTotOre.Location = New System.Drawing.Point(432, 8)
      Me.txtTotOre.MaxLength = 0
      Me.txtTotOre.Name = "txtTotOre"
      Me.txtTotOre.ReadOnly = True
      Me.txtTotOre.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotOre.Size = New System.Drawing.Size(92, 20)
      Me.txtTotOre.TabIndex = 231
      Me.txtTotOre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label18.ForeColor = System.Drawing.SystemColors.Window
      Me.Label18.Location = New System.Drawing.Point(312, 11)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(118, 13)
      Me.Label18.TabIndex = 232
      Me.Label18.Text = "Totale ore di gioco:"
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(536, 312)
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
      Me.txtNote.Size = New System.Drawing.Size(536, 312)
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
      'frmClienti
      '
      Me.AcceptButton = Me.ApriImg
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(544, 384)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmClienti"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Clienti"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.tbpStatGioco.ResumeLayout(False)
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni "

   Private AClienti As New Anagrafiche.Cliente(ConnStringAnagrafiche)
   Private IAllegati As New Allegati
   Private CConvalida As New ConvalidaKeyPress
   Private CFormatta As New ClsFormatta

   Const TAB_QUALIFICHE As String = "Qualifiche"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_TIPO_CLIENTE As String = "CategorieClienti"
   Const TAB_ALLEGATI As String = "Cli_Allegati"
   Const TAB_STAT As String = "StatisticheGioco"
   Const TAB_PREN As String = "Prenotazioni"
   Const NOME_TABELLA As String = "Clienti"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnStringAnagrafiche)
   ' Dichiara un oggetto connessione.
   Dim cnStat As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim cmdStat As New OleDbCommand(sql, cnStat)
   Dim ds As New DataSet
   Dim dt As DataTable

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

#End Region

#Region "Procedure "

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      Try
         ' Imposta le dimensioni standard del form.
         Me.Width = larghezza
         Me.Height = altezza

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

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

         AClienti.Immagine = OpenFileDialog1.FileName

         If File.Exists(AClienti.Immagine) = True Then
            Dim bmp As New Bitmap(AClienti.Immagine)
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
            AClienti.Immagine = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

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
         If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, AClienti.Codice) = True Then
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

   Private Sub CreaColonneStat(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Partita
         Dim idPartitaStyle As New DataGridTextBoxColumn
         idPartitaStyle.MappingName = "IdPartita"
         idPartitaStyle.HeaderText = "Codice partita"
         idPartitaStyle.Width = 100
         idPartitaStyle.NullText = ""
         idPartitaStyle.Alignment = HorizontalAlignment.Right
         idPartitaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idPartitaStyle)
         ' Id - Codice
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Codice"
         codiceStyle.HeaderText = "Codice prenotazione"
         codiceStyle.Width = 110
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Data
         Dim dataStyle As New DataGridTextBoxColumn
         dataStyle.MappingName = "Data"
         dataStyle.HeaderText = "Data partita"
         dataStyle.Width = 100
         dataStyle.NullText = ""
         dataStyle.Alignment = HorizontalAlignment.Right
         dataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Minuti
         Dim minutiStyle As New DataGridTextBoxColumn
         minutiStyle.MappingName = "Minuti"
         minutiStyle.HeaderText = "Minuti di gioco"
         minutiStyle.Width = 100
         minutiStyle.NullText = ""
         minutiStyle.Alignment = HorizontalAlignment.Right
         minutiStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(minutiStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonnePren(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Numero
         'Dim numeroStyle As New DataGridTextBoxColumn
         'numeroStyle.MappingName = "Numero"
         'numeroStyle.HeaderText = "Numero"
         'numeroStyle.Width = 50
         'numeroStyle.NullText = ""
         'numeroStyle.Alignment = HorizontalAlignment.Right
         'numeroStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(numeroStyle)
         ' Data
         Dim dataStyle As New DataGridTextBoxColumn
         dataStyle.MappingName = "Data"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 80
         dataStyle.NullText = ""
         dataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Cliente
         Dim clienteStyle As New DataGridTextBoxColumn
         clienteStyle.MappingName = "Intestatario"
         clienteStyle.HeaderText = "Intestatario"
         clienteStyle.Width = 120
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(clienteStyle)
         ' Componente1
         Dim comp1Style As New DataGridTextBoxColumn
         comp1Style.MappingName = "Componente1"
         comp1Style.HeaderText = "Secondo giocatore"
         comp1Style.Width = 120
         comp1Style.NullText = ""
         comp1Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(comp1Style)
         ' Componente2
         Dim comp2Style As New DataGridTextBoxColumn
         comp2Style.MappingName = "Componente2"
         comp2Style.HeaderText = "Terzo giocatore"
         comp2Style.Width = 120
         comp2Style.NullText = ""
         comp2Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(comp2Style)
         ' Componente3
         Dim comp3Style As New DataGridTextBoxColumn
         comp3Style.MappingName = "Componente3"
         comp3Style.HeaderText = "Quarto giocatore"
         comp3Style.Width = 120
         comp3Style.NullText = ""
         comp3Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(comp3Style)
         ' Risorsa
         Dim risorsaStyle As New DataGridTextBoxColumn
         risorsaStyle.MappingName = "DescrizioneRisorsa"
         risorsaStyle.HeaderText = "Risorsa"
         risorsaStyle.Width = 150
         risorsaStyle.NullText = ""
         risorsaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(risorsaStyle)
         ' Stato
         Dim statoStyle As New DataGridTextBoxColumn
         statoStyle.MappingName = "Stato"
         statoStyle.HeaderText = "Stato prenotazione"
         statoStyle.Width = 110
         statoStyle.NullText = ""
         statoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(statoStyle)
         ' OraInizio
         Dim oraInizioStyle As New DataGridTextBoxColumn
         oraInizioStyle.MappingName = "OraInizio"
         oraInizioStyle.HeaderText = "Dalle ore"
         oraInizioStyle.Width = 75
         oraInizioStyle.NullText = ""
         oraInizioStyle.Alignment = HorizontalAlignment.Right
         oraInizioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraInizioStyle)
         ' OraFine
         Dim oraFineStyle As New DataGridTextBoxColumn
         oraFineStyle.MappingName = "OraFine"
         oraFineStyle.HeaderText = "Alle ore"
         oraFineStyle.Width = 75
         oraFineStyle.NullText = ""
         oraFineStyle.Alignment = HorizontalAlignment.Right
         oraFineStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraFineStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaStat(ByVal tabella As String)
      Try
         dt = ds.Tables.Add(tabella)
         DataGrid1.DataSource = dt

         ' Apre la connessione.
         cnStat.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter("SELECT * FROM " & tabella & " WHERE IdCliente = '" & Me.Tag & "' ORDER BY Codice ASC", cnStat)

         ' Pulisce la tabella da precedenti dati.
         dt.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dt)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cnStat.Close()

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase("Partita del " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) & "  -  " & _
                                                  "Minuti di gioco:  " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3))
         Else
            DataGrid1.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Funzioni "

   Private Function SalvaDati() As Boolean
      Try
         ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
         AggiornaTabella(cmbTitolo, TAB_QUALIFICHE)
         AggiornaTabella(cmbNazione, TAB_NAZIONI)
         AggiornaTabella(cmbTipoCliente, TAB_TIPO_CLIENTE)

         With AClienti
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Cognome = FormattaApici(txtCognome.Text)
            .Nome = FormattaApici(txtNome.Text)
            .Titolo = FormattaApici(cmbTitolo.Text)
            .DataNascita = FormattaApici(txtDataNascita.Text)
            .CodFisc = FormattaApici(txtCodFisc.Text)
            .PIva = FormattaApici(txtPIva.Text)
            .Indirizzo1 = FormattaApici(txtIndirizzo1.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .Regione = FormattaApici(txtRegione.Text)
            .Nazione = FormattaApici(cmbNazione.Text)
            .TipoCliente = FormattaApici(cmbTipoCliente.Text)
            .NumeroDoc = FormattaApici(txtCodTessera.Text)
            If IsNumeric(txtSconto.Text) = True Then
               .Sconto = txtSconto.Text
            Else
               .Sconto = VALORE_ZERO
            End If
            If IsNumeric(txtIva.Text) = True Then
               .Iva = txtIva.Text
            Else
               .Iva = VALORE_ZERO
            End If
            .TelCasa = FormattaApici(txtTelCasa.Text)
            .TelUfficio = FormattaApici(txtTelUfficio.Text)
            .Cell = FormattaApici(txtCell.Text)
            .Fax = FormattaApici(txtFax.Text)
            .Email = FormattaApici(txtEmail.Text)
            .Internet = FormattaApici(txtInternet.Text)
            .Note = FormattaApici(txtNote.Text)

            If chkPrivacy.Checked = True Then
               .Privacy = "Sì"
            Else
               .Privacy = "No"
            End If

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(NOME_TABELLA, Me.Tag)
            Else
               Return .InserisciDati(NOME_TABELLA)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      Try
         OpenFileDialog1.Filter = "Tutti i file |*.*"

         OpenFileDialog1.FilterIndex = 1

         IAllegati.IdCliente = CInt(AClienti.Codice)

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

   Private Function SommaCampo(ByVal tabella As String) As Single
      Dim closeOnExit As Boolean
      Dim somma As Single

      Try
         ' Se necessario apre la connessione.
         If cnStat.State = ConnectionState.Closed Then
            cnStat.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmdStat.CommandText = String.Format("SELECT SUM(Minuti) FROM {0} WHERE IdCliente = '" & Me.Tag & "'", tabella)
         If IsDBNull(cmdStat.ExecuteScalar()) = False Then
            somma = CSng(cmdStat.ExecuteScalar())
         Else
            somma = 0
         End If

         Return somma

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cnStat.Close()

      End Try
   End Function

   Private Function CalcolaOreGiocate(ByVal minuti As Single) As String
      Try
         Const MINUTI_ORA As Integer = 60
         Dim ore As Integer
         Dim min As Single

         If minuti <> 0 Then
            If minuti >= MINUTI_ORA Then
               ore = minuti / MINUTI_ORA
            Else
               ore = 0
            End If

            min = minuti Mod MINUTI_ORA
         End If

         If ore = 0 And min = 0 Then
            Return 0
         ElseIf ore <> 0 And min = 0 Then
            Return ore.ToString
         ElseIf ore = 0 And min <> 0 Then
            Return ore.ToString & "." & min.ToString
         ElseIf ore <> 0 And min <> 0 Then
            Return ore.ToString & "." & min.ToString
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

#End Region

#Region "Eventi "

   Private Sub frmClienti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(CLIENTI_LARGHEZZA, CLIENTI_ALTEZZA)

         If Me.Tag <> "" Then
            With AClienti
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCognome.Text = .Cognome
               txtNome.Text = .Nome
               cmbTitolo.Text = .Titolo
               txtDataNascita.Text = .DataNascita
               txtCodFisc.Text = .CodFisc
               txtPIva.Text = .PIva
               txtIndirizzo1.Text = .Indirizzo1
               txtCap.Text = .Cap
               txtCittà.Text = .Città
               txtProv.Text = .Provincia
               txtRegione.Text = .Regione
               cmbNazione.Text = .Nazione
               cmbTipoCliente.Text = .TipoCliente
               txtCodTessera.Text = .NumeroDoc
               txtSconto.Text = .Sconto
               txtIva.Text = .Iva
               txtTelCasa.Text = .TelCasa
               txtTelUfficio.Text = .TelUfficio
               txtCell.Text = .Cell
               txtFax.Text = .Fax
               txtEmail.Text = .Email
               txtInternet.Text = .Internet
               txtNote.Text = .Note

               If .Privacy = "Sì" Then
                  chkPrivacy.Checked = True
               Else
                  chkPrivacy.Checked = False
               End If

               If .Immagine <> Nothing Then
                  If File.Exists(.Immagine) = True Then
                     Dim bmp As New Bitmap(.Immagine)
                     picFoto.Image = bmp
                  End If
               End If
            End With

            ' Per i clienti già esistenti nel database (con un id)
            ' rende la scheda Allegati disponibile.
            TabControl1.TabPages(2).Enabled = True
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.
            txtSconto.Text = VALORE_ZERO
            txtIva.Text = VALORE_ZERO

            ' Per i nuovi clienti che non sono nel database (con un id)
            ' disattiva la scheda Allegati.
            TabControl1.TabPages(2).Enabled = False
         End If

         ' Carica le liste.
         CaricaLista(cmbTitolo, TAB_QUALIFICHE)
         CaricaLista(cmbNazione, TAB_NAZIONI)
         CaricaLista(cmbTipoCliente, TAB_TIPO_CLIENTE)

         ' Carica la lista delle degli allegati.
         ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione("", txtNome.Text, txtCognome.Text)

         CreaColonneStat(TAB_STAT)
         CaricaStat(TAB_STAT)
         ' Totale partite giocate.
         numRecord = LeggiNumRecord(TAB_STAT)
         txtTotPartite.Text = numRecord.ToString
         ' Totale ore giocate.
         txtTotOre.Text = CalcolaOreGiocate(SommaCampo(TAB_STAT))

         ' Imposta lo stato attivo.
         cmbTitolo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub frmClienti_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CLIENTI)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmClienti) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmClienti.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & AClienti.Cognome & " " & AClienti.Nome & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_CLIENTI)

            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CLIENTI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               Me.cmbTitolo.Focus()

            Case 1
               ' Imposta lo stato attivo.
               Me.txtTelCasa.Focus()

            Case 2
               ' Imposta lo stato attivo.
               Me.lvwAllegati.Focus()
               ' Imposta il pulsante di default.
               cmdInserimento.NotifyDefault(True)

            Case 3
               Me.DataGrid1.Focus()
               ' Aggiorna l'intestazione della griglia dati.
               AggIntGriglia()

            Case 4
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

   Private Sub txtSconto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSconto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtSconto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSconto.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
      End If
   End Sub

   Private Sub txtIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtIva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIva.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
      End If
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      AggIntGriglia()
   End Sub

#End Region

End Class
