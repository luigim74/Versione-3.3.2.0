#Region " DATI FILE.VB "
' **********************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       07/01/2006
' Data ultima modifica: 15/12/2018
' Descrizione:          Anagrafica Camerieri.
' Note:
'
' Elenco Attivita:
'
' ***********************************************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class frmCamerieri
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

   'NOTA: la procedura che segue � richiesta da Progettazione Windows Form.
   'Pu� essere modificata in Progettazione Windows Form.  
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
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
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
   Public WithEvents txtIndirizzo1 As System.Windows.Forms.TextBox
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
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
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtCostoOra As System.Windows.Forms.TextBox
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmbCitt� As ComboBox
   Public WithEvents Label7 As Label
   Friend WithEvents txtCostoGiorno As TextBox
   Friend WithEvents cmbAgenzia As ComboBox
   Public WithEvents Label8 As Label
   Friend WithEvents TabPage2 As TabPage
   Public WithEvents DataGrid1 As DataGrid
   Friend WithEvents tbpStatisticheVendita As TabPage
   Friend WithEvents lvwStatistiche As ListView
   Friend WithEvents clnData As ColumnHeader
   Friend WithEvents clnCategoria As ColumnHeader
   Friend WithEvents clnDescrizione As ColumnHeader
   Friend WithEvents clnTavolo As ColumnHeader
   Friend WithEvents clnQuantit� As ColumnHeader
   Friend WithEvents clnPrezzo As ColumnHeader
   Friend WithEvents clnTotale As ColumnHeader
   Friend WithEvents txtTotale As TextBox
   Friend WithEvents txtTotaleQuantit� As TextBox
   Friend WithEvents Label14 As Label
   Friend WithEvents Label12 As Label
   Friend WithEvents eui_cmdStatContabilizza As Elegant.Ui.Button
   Friend WithEvents clnContabilizzata As ColumnHeader
   Friend WithEvents eui_ddwnFiltro As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdStatTutte As Elegant.Ui.Button
   Friend WithEvents eui_cmdStatDaContabilizzare As Elegant.Ui.Button
   Friend WithEvents eui_cmdStatContabilizzate As Elegant.Ui.Button
   Friend WithEvents clnSpettanza As ColumnHeader
   Friend WithEvents txtTotaleSpettanza As TextBox
   Friend WithEvents Label16 As Label
   Friend WithEvents eui_cmdStatDaContabilizzareSpett As Elegant.Ui.Button
   Friend WithEvents clnIdTavolo As ColumnHeader
   Friend WithEvents txtTotaleEuroGiorni As TextBox
   Friend WithEvents Label17 As Label
   Friend WithEvents txtTotaleGiorni As TextBox
   Friend WithEvents Label18 As Label
   Friend WithEvents eui_cmdNuovoMsg As Elegant.Ui.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCamerieri))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbAgenzia = New System.Windows.Forms.ComboBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtCostoGiorno = New System.Windows.Forms.TextBox()
      Me.cmbCitt� = New System.Windows.Forms.ComboBox()
      Me.txtCostoOra = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.cmbNazione = New System.Windows.Forms.ComboBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.txtCodFisc = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo1 = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.eui_cmdNuovoMsg = New Elegant.Ui.Button()
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
      Me.tbpStatisticheVendita = New System.Windows.Forms.TabPage()
      Me.txtTotaleGiorni = New System.Windows.Forms.TextBox()
      Me.txtTotaleEuroGiorni = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.txtTotaleSpettanza = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.eui_ddwnFiltro = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdStatTutte = New Elegant.Ui.Button()
      Me.eui_cmdStatContabilizzate = New Elegant.Ui.Button()
      Me.eui_cmdStatDaContabilizzare = New Elegant.Ui.Button()
      Me.eui_cmdStatDaContabilizzareSpett = New Elegant.Ui.Button()
      Me.eui_cmdStatContabilizza = New Elegant.Ui.Button()
      Me.txtTotale = New System.Windows.Forms.TextBox()
      Me.txtTotaleQuantit� = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.lvwStatistiche = New System.Windows.Forms.ListView()
      Me.clnData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnDescrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnTavolo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnQuantit� = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnPrezzo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnTotale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnSpettanza = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnContabilizzata = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnIdTavolo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
      Me.tbpStatisticheVendita.SuspendLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.ToolBar1.Size = New System.Drawing.Size(781, 26)
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
      Me.Panel1.BackColor = System.Drawing.Color.DimGray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(781, 20)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(4, 2)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(17, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage4)
      Me.TabControl1.Controls.Add(Me.tbpStatisticheVendita)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(780, 458)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbAgenzia)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.txtCostoGiorno)
      Me.TabPage1.Controls.Add(Me.cmbCitt�)
      Me.TabPage1.Controls.Add(Me.txtCostoOra)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.cmbNazione)
      Me.TabPage1.Controls.Add(Me.txtPIva)
      Me.TabPage1.Controls.Add(Me.txtCodFisc)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.Label30)
      Me.TabPage1.Controls.Add(Me.txtNome)
      Me.TabPage1.Controls.Add(Me.txtProv)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo1)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(772, 432)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'cmbAgenzia
      '
      Me.cmbAgenzia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAgenzia.Location = New System.Drawing.Point(127, 237)
      Me.cmbAgenzia.Name = "cmbAgenzia"
      Me.cmbAgenzia.Size = New System.Drawing.Size(184, 21)
      Me.cmbAgenzia.TabIndex = 9
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(39, 237)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(48, 13)
      Me.Label8.TabIndex = 192
      Me.Label8.Text = "Agenzia:"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(39, 274)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(73, 13)
      Me.Label7.TabIndex = 190
      Me.Label7.Text = "Costo/Giorno:"
      '
      'txtCostoGiorno
      '
      Me.txtCostoGiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCostoGiorno.Location = New System.Drawing.Point(127, 271)
      Me.txtCostoGiorno.Name = "txtCostoGiorno"
      Me.txtCostoGiorno.Size = New System.Drawing.Size(97, 20)
      Me.txtCostoGiorno.TabIndex = 10
      Me.txtCostoGiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbCitt�
      '
      Me.cmbCitt�.Location = New System.Drawing.Point(127, 102)
      Me.cmbCitt�.Name = "cmbCitt�"
      Me.cmbCitt�.Size = New System.Drawing.Size(264, 21)
      Me.cmbCitt�.TabIndex = 3
      '
      'txtCostoOra
      '
      Me.txtCostoOra.AcceptsReturn = True
      Me.txtCostoOra.BackColor = System.Drawing.SystemColors.Window
      Me.txtCostoOra.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCostoOra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCostoOra.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtCostoOra.Location = New System.Drawing.Point(127, 297)
      Me.txtCostoOra.MaxLength = 0
      Me.txtCostoOra.Name = "txtCostoOra"
      Me.txtCostoOra.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCostoOra.Size = New System.Drawing.Size(96, 20)
      Me.txtCostoOra.TabIndex = 11
      Me.txtCostoOra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(39, 300)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 188
      Me.Label3.Text = "Costo/Ora:"
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(127, 22)
      Me.txtCodice.MaxLength = 5
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(104, 20)
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TabStop = False
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(39, 22)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(43, 13)
      Me.Label20.TabIndex = 180
      Me.Label20.Text = "Codice:"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(683, 323)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(64, 24)
      Me.EliminaImg.TabIndex = 13
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(611, 323)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(64, 24)
      Me.ApriImg.TabIndex = 12
      Me.ApriImg.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.Color.White
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(452, 22)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(295, 295)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 178
      Me.picFoto.TabStop = False
      '
      'cmbNazione
      '
      Me.cmbNazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNazione.Location = New System.Drawing.Point(127, 150)
      Me.cmbNazione.Name = "cmbNazione"
      Me.cmbNazione.Size = New System.Drawing.Size(184, 21)
      Me.cmbNazione.TabIndex = 6
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(127, 182)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(184, 20)
      Me.txtPIva.TabIndex = 7
      '
      'txtCodFisc
      '
      Me.txtCodFisc.AcceptsReturn = True
      Me.txtCodFisc.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodFisc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodFisc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodFisc.Location = New System.Drawing.Point(127, 206)
      Me.txtCodFisc.MaxLength = 16
      Me.txtCodFisc.Name = "txtCodFisc"
      Me.txtCodFisc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodFisc.Size = New System.Drawing.Size(184, 20)
      Me.txtCodFisc.TabIndex = 8
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(39, 182)
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
      Me.Label30.Location = New System.Drawing.Point(39, 206)
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
      Me.txtNome.Location = New System.Drawing.Point(127, 46)
      Me.txtNome.MaxLength = 50
      Me.txtNome.Name = "txtNome"
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(264, 20)
      Me.txtNome.TabIndex = 1
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(271, 126)
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
      Me.txtCap.Location = New System.Drawing.Point(127, 126)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(49, 20)
      Me.txtCap.TabIndex = 4
      '
      'txtIndirizzo1
      '
      Me.txtIndirizzo1.AcceptsReturn = True
      Me.txtIndirizzo1.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo1.Location = New System.Drawing.Point(127, 78)
      Me.txtIndirizzo1.MaxLength = 100
      Me.txtIndirizzo1.Name = "txtIndirizzo1"
      Me.txtIndirizzo1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo1.Size = New System.Drawing.Size(264, 20)
      Me.txtIndirizzo1.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(39, 46)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 170
      Me.Label2.Text = "Nome:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(39, 150)
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
      Me.Label9.Location = New System.Drawing.Point(215, 126)
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
      Me.Label6.Location = New System.Drawing.Point(39, 126)
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
      Me.Label5.Location = New System.Drawing.Point(39, 102)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(31, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Citt�:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(39, 78)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Indirizzo:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.eui_cmdNuovoMsg)
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
      Me.TabPage3.Size = New System.Drawing.Size(772, 432)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Tel./Internet"
      Me.TabPage3.ToolTipText = "Dati sul telefono e Internet"
      '
      'eui_cmdNuovoMsg
      '
      Me.eui_cmdNuovoMsg.Id = "0c1bdcf2-a9de-47d8-8030-fcbf758bfcb5"
      Me.eui_cmdNuovoMsg.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.eui_cmdNuovoMsg.Location = New System.Drawing.Point(433, 158)
      Me.eui_cmdNuovoMsg.Name = "eui_cmdNuovoMsg"
      Me.eui_cmdNuovoMsg.ScreenTip.Caption = "Nuovo messaggio"
      Me.eui_cmdNuovoMsg.ScreenTip.Text = "Scrivi un nuovo messaggio e-mail all'indirizzo specificato." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
      Me.eui_cmdNuovoMsg.Size = New System.Drawing.Size(31, 23)
      Me.eui_cmdNuovoMsg.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Nothing)})
      Me.eui_cmdNuovoMsg.TabIndex = 5
      Me.eui_cmdNuovoMsg.Text = "..."
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
      Me.txtEmail.Size = New System.Drawing.Size(336, 20)
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
      Me.TabPage4.Size = New System.Drawing.Size(772, 432)
      Me.TabPage4.TabIndex = 3
      Me.TabPage4.Text = "Documenti allegati"
      '
      'cmdRimuovi
      '
      Me.cmdRimuovi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRimuovi.Location = New System.Drawing.Point(677, 400)
      Me.cmdRimuovi.Name = "cmdRimuovi"
      Me.cmdRimuovi.Size = New System.Drawing.Size(88, 24)
      Me.cmdRimuovi.TabIndex = 3
      Me.cmdRimuovi.Text = "&Rimuovi"
      '
      'cmdModifica
      '
      Me.cmdModifica.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdModifica.Location = New System.Drawing.Point(581, 400)
      Me.cmdModifica.Name = "cmdModifica"
      Me.cmdModifica.Size = New System.Drawing.Size(88, 24)
      Me.cmdModifica.TabIndex = 2
      Me.cmdModifica.Text = "&Modifica"
      '
      'cmdInserimento
      '
      Me.cmdInserimento.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdInserimento.Location = New System.Drawing.Point(493, 400)
      Me.cmdInserimento.Name = "cmdInserimento"
      Me.cmdInserimento.Size = New System.Drawing.Size(80, 24)
      Me.cmdInserimento.TabIndex = 1
      Me.cmdInserimento.Text = "&Inserimento"
      '
      'lvwAllegati
      '
      Me.lvwAllegati.AllowColumnReorder = True
      Me.lvwAllegati.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvwAllegati.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
      Me.lvwAllegati.FullRowSelect = True
      Me.lvwAllegati.HideSelection = False
      Me.lvwAllegati.Location = New System.Drawing.Point(0, 0)
      Me.lvwAllegati.MultiSelect = False
      Me.lvwAllegati.Name = "lvwAllegati"
      Me.lvwAllegati.Size = New System.Drawing.Size(772, 394)
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
      'tbpStatisticheVendita
      '
      Me.tbpStatisticheVendita.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpStatisticheVendita.Controls.Add(Me.txtTotaleGiorni)
      Me.tbpStatisticheVendita.Controls.Add(Me.txtTotaleEuroGiorni)
      Me.tbpStatisticheVendita.Controls.Add(Me.Label17)
      Me.tbpStatisticheVendita.Controls.Add(Me.Label18)
      Me.tbpStatisticheVendita.Controls.Add(Me.txtTotaleSpettanza)
      Me.tbpStatisticheVendita.Controls.Add(Me.Label16)
      Me.tbpStatisticheVendita.Controls.Add(Me.eui_ddwnFiltro)
      Me.tbpStatisticheVendita.Controls.Add(Me.eui_cmdStatContabilizza)
      Me.tbpStatisticheVendita.Controls.Add(Me.txtTotale)
      Me.tbpStatisticheVendita.Controls.Add(Me.txtTotaleQuantit�)
      Me.tbpStatisticheVendita.Controls.Add(Me.Label14)
      Me.tbpStatisticheVendita.Controls.Add(Me.Label12)
      Me.tbpStatisticheVendita.Controls.Add(Me.lvwStatistiche)
      Me.tbpStatisticheVendita.Location = New System.Drawing.Point(4, 22)
      Me.tbpStatisticheVendita.Name = "tbpStatisticheVendita"
      Me.tbpStatisticheVendita.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpStatisticheVendita.Size = New System.Drawing.Size(772, 432)
      Me.tbpStatisticheVendita.TabIndex = 6
      Me.tbpStatisticheVendita.Text = "Statistiche di vendita"
      '
      'txtTotaleGiorni
      '
      Me.txtTotaleGiorni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleGiorni.ForeColor = System.Drawing.Color.Black
      Me.txtTotaleGiorni.Location = New System.Drawing.Point(443, 397)
      Me.txtTotaleGiorni.Name = "txtTotaleGiorni"
      Me.txtTotaleGiorni.ReadOnly = True
      Me.txtTotaleGiorni.Size = New System.Drawing.Size(100, 20)
      Me.txtTotaleGiorni.TabIndex = 8
      Me.txtTotaleGiorni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotaleEuroGiorni
      '
      Me.txtTotaleEuroGiorni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleEuroGiorni.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleEuroGiorni.Location = New System.Drawing.Point(655, 397)
      Me.txtTotaleEuroGiorni.Name = "txtTotaleEuroGiorni"
      Me.txtTotaleEuroGiorni.ReadOnly = True
      Me.txtTotaleEuroGiorni.Size = New System.Drawing.Size(100, 20)
      Me.txtTotaleEuroGiorni.TabIndex = 9
      Me.txtTotaleEuroGiorni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.Location = New System.Drawing.Point(558, 400)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(78, 13)
      Me.Label17.TabIndex = 10
      Me.Label17.Text = "Importo Totale:"
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(372, 400)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(73, 13)
      Me.Label18.TabIndex = 7
      Me.Label18.Text = "Giorni Lavoro:"
      '
      'txtTotaleSpettanza
      '
      Me.txtTotaleSpettanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleSpettanza.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleSpettanza.Location = New System.Drawing.Point(655, 371)
      Me.txtTotaleSpettanza.Name = "txtTotaleSpettanza"
      Me.txtTotaleSpettanza.ReadOnly = True
      Me.txtTotaleSpettanza.Size = New System.Drawing.Size(100, 20)
      Me.txtTotaleSpettanza.TabIndex = 6
      Me.txtTotaleSpettanza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.Location = New System.Drawing.Point(558, 374)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(91, 13)
      Me.Label16.TabIndex = 6
      Me.Label16.Text = "Totale Spettanza:"
      '
      'eui_ddwnFiltro
      '
      Me.eui_ddwnFiltro.Id = "e9d3598d-dc23-4df5-99d1-1d1cd48543da"
      Me.eui_ddwnFiltro.Location = New System.Drawing.Point(5, 3)
      Me.eui_ddwnFiltro.Name = "eui_ddwnFiltro"
      Me.eui_ddwnFiltro.Popup = Me.PopupMenu1
      Me.eui_ddwnFiltro.Size = New System.Drawing.Size(226, 32)
      Me.eui_ddwnFiltro.TabIndex = 0
      Me.eui_ddwnFiltro.Text = "VISTA - (Da contabilizzre)"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdStatTutte, Me.eui_cmdStatContabilizzate, Me.eui_cmdStatDaContabilizzare, Me.eui_cmdStatDaContabilizzareSpett})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdStatTutte
      '
      Me.eui_cmdStatTutte.Id = "b7540cb0-256d-40c9-8591-85b5e48a88d9"
      Me.eui_cmdStatTutte.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdStatTutte.Name = "eui_cmdStatTutte"
      Me.eui_cmdStatTutte.Size = New System.Drawing.Size(224, 23)
      Me.eui_cmdStatTutte.TabIndex = 3
      Me.eui_cmdStatTutte.Text = "&Tutte"
      '
      'eui_cmdStatContabilizzate
      '
      Me.eui_cmdStatContabilizzate.Id = "1410cc34-531f-4f9d-a996-fd6b73c445d7"
      Me.eui_cmdStatContabilizzate.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdStatContabilizzate.Name = "eui_cmdStatContabilizzate"
      Me.eui_cmdStatContabilizzate.Size = New System.Drawing.Size(224, 23)
      Me.eui_cmdStatContabilizzate.TabIndex = 5
      Me.eui_cmdStatContabilizzate.Text = "&Contabilizzate"
      '
      'eui_cmdStatDaContabilizzare
      '
      Me.eui_cmdStatDaContabilizzare.Id = "d29c8263-7df8-4928-a572-f105f2813e1f"
      Me.eui_cmdStatDaContabilizzare.Location = New System.Drawing.Point(2, 48)
      Me.eui_cmdStatDaContabilizzare.Name = "eui_cmdStatDaContabilizzare"
      Me.eui_cmdStatDaContabilizzare.Size = New System.Drawing.Size(224, 23)
      Me.eui_cmdStatDaContabilizzare.TabIndex = 4
      Me.eui_cmdStatDaContabilizzare.Text = "&Da contabilizzare"
      '
      'eui_cmdStatDaContabilizzareSpett
      '
      Me.eui_cmdStatDaContabilizzareSpett.Id = "88d5dc65-fcec-49e3-9d6d-8a45ed82c66c"
      Me.eui_cmdStatDaContabilizzareSpett.Location = New System.Drawing.Point(2, 71)
      Me.eui_cmdStatDaContabilizzareSpett.Name = "eui_cmdStatDaContabilizzareSpett"
      Me.eui_cmdStatDaContabilizzareSpett.Size = New System.Drawing.Size(224, 23)
      Me.eui_cmdStatDaContabilizzareSpett.TabIndex = 7
      Me.eui_cmdStatDaContabilizzareSpett.Text = "Da contabilizzare con &spettanza"
      '
      'eui_cmdStatContabilizza
      '
      Me.eui_cmdStatContabilizza.Id = "47ae13c6-0f01-4346-bbb8-c509f7bada73"
      Me.eui_cmdStatContabilizza.Location = New System.Drawing.Point(616, 3)
      Me.eui_cmdStatContabilizza.Name = "eui_cmdStatContabilizza"
      Me.eui_cmdStatContabilizza.Size = New System.Drawing.Size(150, 32)
      Me.eui_cmdStatContabilizza.TabIndex = 1
      Me.eui_cmdStatContabilizza.Text = "&Contabilizza"
      '
      'txtTotale
      '
      Me.txtTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotale.ForeColor = System.Drawing.Color.Black
      Me.txtTotale.Location = New System.Drawing.Point(443, 371)
      Me.txtTotale.Name = "txtTotale"
      Me.txtTotale.ReadOnly = True
      Me.txtTotale.Size = New System.Drawing.Size(100, 20)
      Me.txtTotale.TabIndex = 5
      Me.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotaleQuantit�
      '
      Me.txtTotaleQuantit�.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleQuantit�.ForeColor = System.Drawing.Color.Black
      Me.txtTotaleQuantit�.Location = New System.Drawing.Point(258, 371)
      Me.txtTotaleQuantit�.Name = "txtTotaleQuantit�"
      Me.txtTotaleQuantit�.ReadOnly = True
      Me.txtTotaleQuantit�.Size = New System.Drawing.Size(100, 20)
      Me.txtTotaleQuantit�.TabIndex = 4
      Me.txtTotaleQuantit�.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(372, 374)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(65, 13)
      Me.Label14.TabIndex = 2
      Me.Label14.Text = "Totale Euro:"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(129, 374)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(123, 13)
      Me.Label12.TabIndex = 1
      Me.Label12.Text = "Totale quantit� vendute:"
      '
      'lvwStatistiche
      '
      Me.lvwStatistiche.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvwStatistiche.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnData, Me.clnCategoria, Me.clnDescrizione, Me.clnTavolo, Me.clnQuantit�, Me.clnPrezzo, Me.clnTotale, Me.clnSpettanza, Me.clnContabilizzata, Me.clnIdTavolo})
      Me.lvwStatistiche.FullRowSelect = True
      Me.lvwStatistiche.HideSelection = False
      Me.lvwStatistiche.Location = New System.Drawing.Point(0, 38)
      Me.lvwStatistiche.Name = "lvwStatistiche"
      Me.lvwStatistiche.ShowGroups = False
      Me.lvwStatistiche.Size = New System.Drawing.Size(772, 325)
      Me.lvwStatistiche.TabIndex = 3
      Me.lvwStatistiche.UseCompatibleStateImageBehavior = False
      Me.lvwStatistiche.View = System.Windows.Forms.View.Details
      '
      'clnData
      '
      Me.clnData.Text = "Data"
      Me.clnData.Width = 70
      '
      'clnCategoria
      '
      Me.clnCategoria.Text = "Categoria"
      Me.clnCategoria.Width = 80
      '
      'clnDescrizione
      '
      Me.clnDescrizione.Text = "Descrizione"
      Me.clnDescrizione.Width = 150
      '
      'clnTavolo
      '
      Me.clnTavolo.Text = "Tavolo"
      Me.clnTavolo.Width = 80
      '
      'clnQuantit�
      '
      Me.clnQuantit�.Text = "Quantit�"
      Me.clnQuantit�.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'clnPrezzo
      '
      Me.clnPrezzo.Text = "Prezzo"
      Me.clnPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'clnTotale
      '
      Me.clnTotale.Text = "Totale"
      Me.clnTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnTotale.Width = 80
      '
      'clnSpettanza
      '
      Me.clnSpettanza.Text = "Spettanza"
      Me.clnSpettanza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnSpettanza.Width = 80
      '
      'clnContabilizzata
      '
      Me.clnContabilizzata.Text = "Contabilizzata"
      Me.clnContabilizzata.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.clnContabilizzata.Width = 80
      '
      'clnIdTavolo
      '
      Me.clnIdTavolo.Width = 0
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(772, 432)
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
      Me.txtNote.Size = New System.Drawing.Size(772, 432)
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
      'frmCamerieri
      '
      Me.AcceptButton = Me.ApriImg
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(781, 505)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmCamerieri"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Camerieri"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.tbpStatisticheVendita.ResumeLayout(False)
      Me.tbpStatisticheVendita.PerformLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni "

   Private ACamerieri As New Cameriere(ConnStringAnagrafiche)
   Private IAllegati As New Allegati
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   Const TAB_CAP As String = "CAP"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_AGENZIE As String = "AgenzieCamerieri"
   Const TAB_ALLEGATI As String = "Ca_Allegati"
   Const TAB_PREN As String = "Prenotazioni"
   Const TAB_STATISTICHE As String = "Statistiche"
   Const NOME_TABELLA As String = "Camerieri"

   Const FILTRO_TUTTE As String = "Tutte"
   Const FILTRO_CONTABILIZZATE As String = "Contabilizzate"
   Const FILTRO_DA_CONTABILIZZARE As String = "Da contabilizzare"
   Const FILTRO_DA_CONTABILIZZARE_SPETTANZA As String = "Da contabilizzare con spettanza"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnStringAnagrafiche)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   Dim dt As DataTable

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

#End Region

#Region "Procedure "

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
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

         ACamerieri.Immagine = OpenFileDialog1.FileName

         If File.Exists(ACamerieri.Immagine) = True Then
            Dim bmp As New Bitmap(ACamerieri.Immagine)
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
            ACamerieri.Immagine = ""
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
         Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf &
                           "Non sar� pi� possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

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
         If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, ACamerieri.Codice) = True Then
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

   Private Sub CaricaListaStatisticheVendita(ByVal lstView As ListView, ByVal idCameriere As String, ByVal tabella As String, ByVal filtro As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String
      Dim sqlGroupBy As String

      Try
         Select Case filtro
            Case FILTRO_TUTTE
               ' Aggiorna il pulsante filtro.
               eui_ddwnFiltro.Text = "VISTA - (" & FILTRO_TUTTE & ")"

               ' Crea la stringa sql di selezione dati.
               sql = "SELECT * FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' ORDER BY Id DESC"
               sqlGroupBy = "SELECT Data FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' GROUP BY Data"

            Case FILTRO_CONTABILIZZATE
               ' Aggiorna il pulsante filtro.
               eui_ddwnFiltro.Text = "VISTA - (" & FILTRO_CONTABILIZZATE & ")"

               ' Crea la stringa sql di selezione dati.
               sql = "SELECT * FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' AND Contabilizzata = 'S�' ORDER BY Id DESC"
               sqlGroupBy = "SELECT Data FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' AND Contabilizzata = 'S�' GROUP BY Data"

            Case FILTRO_DA_CONTABILIZZARE
               ' Aggiorna il pulsante filtro.
               eui_ddwnFiltro.Text = "VISTA - (" & FILTRO_DA_CONTABILIZZARE & ")"

               ' Crea la stringa sql di selezione dati.
               sql = "SELECT * FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' AND Contabilizzata = 'No' ORDER BY Id DESC"
               sqlGroupBy = "SELECT Data FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' AND Contabilizzata = 'No' GROUP BY Data"

            Case FILTRO_DA_CONTABILIZZARE_SPETTANZA
               ' Aggiorna il pulsante filtro.
               eui_ddwnFiltro.Text = "VISTA - (" & FILTRO_DA_CONTABILIZZARE_SPETTANZA & ")"

               ' Crea la stringa sql di selezione dati.
               sql = "SELECT * FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' AND SpettanzaCameriere > 0 AND Contabilizzata = 'No' ORDER BY Id DESC"
               sqlGroupBy = "SELECT Data FROM " & tabella & " WHERE IdCameriere = '" & idCameriere & "' AND SpettanzaCameriere > 0 AND Contabilizzata = 'No' GROUP BY Data"
         End Select

         cn.Open()

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstView.Items.Clear()

         Dim i As Integer

         Do While dr.Read
            ' Data.
            lstView.Items.Add(dr.Item("Data"))

            ' Categoria.
            If IsDBNull(dr.Item("DesCategoria")) = False Then
               lstView.Items(i).SubItems.Add(dr.Item("DesCategoria").ToString)
            Else
               lstView.Items(i).SubItems.Add(String.Empty)
            End If

            ' Descrizione.
            If IsDBNull(dr.Item("DesPiatto")) = False Then
               lstView.Items(i).SubItems.Add(dr.Item("DesPiatto").ToString)
            Else
               lstView.Items(i).SubItems.Add(String.Empty)
            End If

            ' Tavolo.
            If IsDBNull(dr.Item("DesTavolo")) = False Then
               lstView.Items(i).SubItems.Add(dr.Item("DesTavolo").ToString)
            Else
               lstView.Items(i).SubItems.Add(String.Empty)
            End If

            ' Quantit�.
            If IsDBNull(dr.Item("Quantit�")) = False Then
               lstView.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Quantit�"))))
            Else
               lstView.Items(i).SubItems.Add(VALORE_ZERO)
            End If

            ' Prezzo.
            If IsDBNull(dr.Item("Prezzo")) = False Then
               lstView.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Prezzo"))))
            Else
               lstView.Items(i).SubItems.Add(VALORE_ZERO)
            End If

            ' Totale.
            If IsDBNull(dr.Item("Importo")) = False Then
               lstView.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Importo"))))
            Else
               lstView.Items(i).SubItems.Add(VALORE_ZERO)
            End If

            ' Spettanza.
            If IsDBNull(dr.Item("SpettanzaCameriere")) = False Then
               lstView.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("SpettanzaCameriere"))))
            Else
               lstView.Items(i).SubItems.Add(VALORE_ZERO)
            End If

            ' Contabilizzata.
            If IsDBNull(dr.Item("Contabilizzata")) = False Then
               lstView.Items(i).SubItems.Add(dr.Item("Contabilizzata").ToString)
            Else
               lstView.Items(i).SubItems.Add("No")
            End If

            ' IdTavolo.
            If IsDBNull(dr.Item("IdTavolo")) = False Then
               lstView.Items(i).SubItems.Add(dr.Item("IdTavolo").ToString)
            Else
               lstView.Items(i).SubItems.Add(String.Empty)
            End If

            ' Contatore.
            i += 1

         Loop

         ' Calcola i totali della lista.
         txtTotaleQuantit�.Text = CFormatta.FormattaNumeroDouble(SommaColonna(lvwStatistiche, 4))
         txtTotale.Text = "� " & CFormatta.FormattaNumeroDouble(SommaColonna(lvwStatistiche, 6))
         txtTotaleSpettanza.Text = "� " & CFormatta.FormattaNumeroDouble(SommaColonna(lvwStatistiche, 7))

         ' Ottiene il numero dei giorni lavorati e calcola il rispettivo importo.
         Dim totaleGiorni As Integer = TrovaNumeroGiorni(sqlGroupBy)
         Dim costoGiorno As Double = txtCostoGiorno.Text
         Dim totaleImporto As Double = totaleGiorni * costoGiorno
         txtTotaleGiorni.Text = totaleGiorni.ToString
         txtTotaleEuroGiorni.Text = "� " & CFormatta.FormattaNumeroDouble(totaleImporto)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

#End Region

#Region "Funzioni "

   Private Function SalvaDati() As Boolean
      Try
         ' TODO: Modifcare procedure della Classe e rimuovere FormattApici.

         ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
         'AggiornaTabella(cmbNazione, TAB_NAZIONI)

         With ACamerieri
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Nome = FormattaApici(txtNome.Text)
            .CodFisc = FormattaApici(txtCodFisc.Text)
            .PIva = FormattaApici(txtPIva.Text)
            .Indirizzo1 = FormattaApici(txtIndirizzo1.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Citt� = FormattaApici(cmbCitt�.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .Nazione = FormattaApici(cmbNazione.Text)
            .Agenzia = FormattaApici(cmbAgenzia.Text)
            .TelCasa = FormattaApici(txtTelCasa.Text)
            .TelUfficio = FormattaApici(txtTelUfficio.Text)
            .Cell = FormattaApici(txtCell.Text)
            .Fax = FormattaApici(txtFax.Text)
            .Email = FormattaApici(txtEmail.Text)
            .Note = FormattaApici(txtNote.Text)

            If IsNumeric(txtCostoGiorno.Text) Then
               .CostoGiorno = CFormatta.FormattaNumeroDouble(Convert.ToDouble(txtCostoGiorno.Text))
            Else
               .CostoGiorno = VALORE_ZERO
            End If

            If IsNumeric(txtCostoOra.Text) Then
               .CostoOra = CFormatta.FormattaNumeroDouble(Convert.ToDouble(txtCostoOra.Text))
            Else
               .CostoOra = VALORE_ZERO
            End If

            ' Se la propriet� 'Tag' contiene un valore viene richiamata la procedura
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

         IAllegati.IdCliente = CInt(ACamerieri.Codice)

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

   Public Function ModificaStatistiche(ByVal tabella As String, ByVal contabilizzata As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Contabilizzata = @Contabilizzata " &
                             "WHERE Contabilizzata = 'No'",
                             tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Contabilizzata", contabilizzata)

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

   Private Function TrovaNumeroGiorni(ByVal sql As String) As Integer
      Try
         cn.Open()

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim numGiorni As Integer = 0

         Do While dr.Read
            numGiorni += 1
         Loop

         ' Ottiene il numero di record.
         'cmd.CommandText = sql

         'Dim numGiorni As Integer = cmd.ExecuteScalar()

         Return numGiorni

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

#End Region

#Region "Eventi "

   Private Sub frmCamerieri_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' TODO_A: NIGHT_CLUB
         moduloAttivo.NightClub = True

         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(CAMERIERI_LARGHEZZA, CAMERIERI_ALTEZZA)

         ' Imposta il titolo del form con la denominazione associata.
         Me.Text = DenominazioneCamerieri

         ' Carica le liste.
         CaricaLista(cmbCitt�, TAB_CAP)
         CaricaLista(cmbNazione, TAB_NAZIONI)
         CaricaListaFornitori(cmbAgenzia, TAB_AGENZIE)

         If Me.Tag <> String.Empty Then
            With ACamerieri
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtNome.Text = .Nome
               txtCodFisc.Text = .CodFisc
               txtPIva.Text = .PIva
               txtIndirizzo1.Text = .Indirizzo1
               txtCap.Text = .Cap
               cmbCitt�.Text = .Citt�
               txtProv.Text = .Provincia
               cmbNazione.Text = .Nazione
               cmbAgenzia.Text = .Agenzia
               txtTelCasa.Text = .TelCasa
               txtTelUfficio.Text = .TelUfficio
               txtCell.Text = .Cell
               txtFax.Text = .Fax
               txtEmail.Text = .Email
               txtNote.Text = .Note

               If IsNumeric(.CostoGiorno) = True Then
                  txtCostoGiorno.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.CostoGiorno))
               Else
                  txtCostoGiorno.Text = VALORE_ZERO
               End If

               If IsNumeric(.CostoOra) = True Then
                  txtCostoOra.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.CostoOra))
               Else
                  txtCostoOra.Text = VALORE_ZERO
               End If

               If .Immagine <> Nothing Then
                  If File.Exists(.Immagine) = True Then
                     Dim bmp As New Bitmap(.Immagine)
                     picFoto.Image = bmp
                  End If
               End If
            End With

            ' Per i camerieri gi� esistenti nel database (con un id)
            ' rende la scheda Allegati disponibile.
            TabControl1.TabPages(2).Enabled = True

            ' Carica la lista delle degli allegati.
            ConvalidaAllegati()
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.
            ' Per i nuovi camerieri che non sono nel database (con un id).

            ' Disattiva la scheda Allegati.
            TabControl1.TabPages(2).Enabled = False

            ' Disattiva i comandi per le statistiche di vendita.
            eui_ddwnFiltro.Enabled = False
            eui_cmdStatContabilizza.Enabled = False
         End If

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtNome.Text, "")

         ' Impostazioni per il modulo NightClub.
         If moduloAttivo.NightClub = True Then
            tbpStatisticheVendita.Enabled = True
         Else
            tbpStatisticheVendita.Enabled = False
         End If

         ' Imposta lo stato attivo.
         txtNome.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub frmCamerieri_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CAMERIERI)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmCamerieri) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmCamerieri.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & ACamerieri.Nome & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_CAMERIERI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CAMERIERI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               Me.txtNome.Focus()

            Case 1
               ' Imposta lo stato attivo.
               Me.txtTelCasa.Focus()

            Case 2
               ' Imposta lo stato attivo.
               Me.lvwAllegati.Focus()
               ' Imposta il pulsante di default.
               cmdInserimento.NotifyDefault(True)

            Case 3
               ' Impostazioni per il modulo NightClub.
               If moduloAttivo.NightClub = True Then
                  If Me.Tag <> String.Empty Then
                     ' Carica le statistiche di vendita per il cameriere selezionato.
                     CaricaListaStatisticheVendita(lvwStatistiche, Me.Tag, TAB_STATISTICHE, FILTRO_TUTTE)
                  End If
               End If

               ' Imposta lo stato attivo.
               Me.lvwStatistiche.Focus()

            Case 4
               ' Imposta lo stato attivo.
               Me.txtNote.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtPIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTelCasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelCasa.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriTelefono(e.KeyChar)
   End Sub

   Private Sub txtTelUfficio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelUfficio.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriTelefono(e.KeyChar)
   End Sub

   Private Sub txtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriTelefono(e.KeyChar)
   End Sub

   Private Sub txtCell_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCell.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriTelefono(e.KeyChar)
   End Sub

   Private Sub txtCostoOra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoOra.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtCostoOra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostoOra.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
      Else
         sender.Text = VALORE_ZERO
      End If
   End Sub

   Private Sub txtCostoGiorno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoGiorno.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtCostoGiorno_LostFocus(sender As Object, e As EventArgs) Handles txtCostoGiorno.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
      Else
         sender.Text = VALORE_ZERO
      End If
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
            Case ".RTF"
               ' WordPad
               NomeApp = "WORDPAD.EXE"

            Case ".DOC"
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

            Case ".HTM", ".HTML"
               ' Internet Explorer
               NomeApp = "IEXPLORE.EXE"

            Case ".BMP", ".PNG", ".JPG", ".JPEG", ".JPE", ".JFIF", ".GIF", ".TIF", ".TIFF"
               ' Paint
               NomeApp = "MSPAINT.EXE"

         End Select

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.Verb = "runas"
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Proc.Close()
         Proc.Dispose()
      End Try
   End Sub

   Private Sub eui_cmdNuovoMsg_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovoMsg.Click
      Try
         InviaEmail(g_frmMain.LeggiEmailMittente, txtEmail.Text, String.Empty, String.Empty, String.Empty)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmbCitt�_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCitt�.SelectedIndexChanged
      Try
         txtCap.Text = LeggiCapCAP(sender.text)
         txtProv.Text = LeggiProvinciaCAP(sender.text)
         'txtRegione.Text = LeggiRegioneCAP(sender.text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Eui_cmdStatTutte_Click(sender As Object, e As EventArgs) Handles eui_cmdStatTutte.Click
      Try
         ' Carica le statistiche di vendita per il cameriere selezionato.
         CaricaListaStatisticheVendita(lvwStatistiche, Me.Tag, TAB_STATISTICHE, FILTRO_TUTTE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub Eui_cmdStatDaContabilizzare_Click(sender As Object, e As EventArgs) Handles eui_cmdStatDaContabilizzare.Click
      Try
         ' Carica le statistiche di vendita per il cameriere selezionato.
         CaricaListaStatisticheVendita(lvwStatistiche, Me.Tag, TAB_STATISTICHE, FILTRO_DA_CONTABILIZZARE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Eui_cmdStatDaContabilizzareSpett_Click(sender As Object, e As EventArgs) Handles eui_cmdStatDaContabilizzareSpett.Click
      Try
         ' Carica le statistiche di vendita per il cameriere selezionato.
         CaricaListaStatisticheVendita(lvwStatistiche, Me.Tag, TAB_STATISTICHE, FILTRO_DA_CONTABILIZZARE_SPETTANZA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub


   Private Sub Eui_cmdStatContabilizzate_Click(sender As Object, e As EventArgs) Handles eui_cmdStatContabilizzate.Click
      Try
         ' Carica le statistiche di vendita per il cameriere selezionato.
         CaricaListaStatisticheVendita(lvwStatistiche, Me.Tag, TAB_STATISTICHE, FILTRO_CONTABILIZZATE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Eui_cmdStatContabilizza_Click(sender As Object, e As EventArgs) Handles eui_cmdStatContabilizza.Click
      Try
         Dim risposta As Integer
         risposta = MessageBox.Show("Si desidera contabilizzare tutte le vendite ancora aperte?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = MsgBoxResult.Yes Then
            If lvwStatistiche.Items.Count <> 0 Then

               If ModificaStatistiche(TAB_STATISTICHE, "S�") = True Then
                  ' Carica le statistiche di vendita per il cameriere selezionato.
                  CaricaListaStatisticheVendita(lvwStatistiche, Me.Tag, TAB_STATISTICHE, FILTRO_TUTTE)

                  MessageBox.Show("Tutte le vendite sono state contabilizzate.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Else
                  MessageBox.Show("Non � stato possibile contabilizzare le vendite. Si suggerisce di riprovare con l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            Else
               MessageBox.Show("Non ci sono vendite da contabilizzare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lvwStatistiche_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwStatistiche.SelectedIndexChanged
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         Dim dataStat As String = FormattaData(lvwStatistiche.Items(lvwStatistiche.FocusedItem.Index).Text, False)
         Dim idTavolo As String = lvwStatistiche.Items(lvwStatistiche.FocusedItem.Index).SubItems(9).Text
         Dim idCameriere As String
         Dim nomeCameriere As String
         Dim elencoCamerieri As String

         ' Crea la stringa sql di selezione dati.
         sql = "SELECT IdCameriere, DesCameriere FROM " & TAB_STATISTICHE & " WHERE IdTavolo = '" & idTavolo & "' AND Data = #" & dataStat & "# GROUP BY IdCameriere, DesCameriere"

         cn.Open()

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim i As Integer = 0
         Do While dr.Read
            ' Id cameriere.
            If IsDBNull(dr.Item("IdCameriere")) = False Then
               idCameriere = dr.Item("IdCameriere").ToString
            Else
               idCameriere = String.Empty
            End If

            ' Nome cameriere.
            If IsDBNull(dr.Item("DesCameriere")) = False Then
               nomeCameriere = dr.Item("DesCameriere").ToString
            Else
               nomeCameriere = String.Empty
            End If

            If idCameriere <> Me.Tag Then
               i += 1

               If i = 1 Then
                  elencoCamerieri = nomeCameriere
               Else
                  elencoCamerieri = elencoCamerieri & ", " & nomeCameriere
               End If
            End If
         Loop

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtNome.Text, "(" & elencoCamerieri & ")")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

#End Region


End Class
