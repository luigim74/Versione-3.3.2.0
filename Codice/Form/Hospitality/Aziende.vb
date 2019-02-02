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

Public Class frmAziende
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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents cmdScrivi As System.Windows.Forms.Button
   Friend WithEvents cmdVai As System.Windows.Forms.Button
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents txtSconto As System.Windows.Forms.TextBox
   Public WithEvents txtIva As System.Windows.Forms.TextBox
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
   Friend WithEvents cmbTitolo As System.Windows.Forms.ComboBox
   Public WithEvents label As System.Windows.Forms.Label
   Friend WithEvents txtContatto As System.Windows.Forms.TextBox
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cmbAttività As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents txtRagSociale As System.Windows.Forms.TextBox
   Public WithEvents Label17 As System.Windows.Forms.Label
   Public WithEvents Label18 As System.Windows.Forms.Label
   Public WithEvents Label19 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Public WithEvents Label25 As System.Windows.Forms.Label
   Public WithEvents txtIBAN As System.Windows.Forms.TextBox
   Friend WithEvents cmbPagamento As System.Windows.Forms.ComboBox
   Public WithEvents txtCIN As System.Windows.Forms.TextBox
   Public WithEvents txtCC As System.Windows.Forms.TextBox
   Public WithEvents txtCAB As System.Windows.Forms.TextBox
   Public WithEvents txtABI As System.Windows.Forms.TextBox
   Public WithEvents txtBanca As System.Windows.Forms.TextBox
   Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdEliminaBuono As System.Windows.Forms.Button
   Friend WithEvents cmdModificaBuono As System.Windows.Forms.Button
   Friend WithEvents cmdNuovoBuono As System.Windows.Forms.Button
   Friend WithEvents lvwBuoniPasto As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
   Public WithEvents Label26 As System.Windows.Forms.Label
   Public WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lblAl As System.Windows.Forms.Label
   Friend WithEvents lblDal As System.Windows.Forms.Label
   Friend WithEvents cmdCercaBuoni As System.Windows.Forms.Button
   Friend WithEvents cmdCercaSospesi As System.Windows.Forms.Button
   Public WithEvents txtCodAzienda As System.Windows.Forms.TextBox
   Friend WithEvents cmdStampaFatt As System.Windows.Forms.Button
   Public WithEvents Label28 As System.Windows.Forms.Label
   Public WithEvents Label29 As System.Windows.Forms.Label
   Public WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents cmbDataAl As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmbDataDal As System.Windows.Forms.DateTimePicker
   Friend WithEvents lstvDatiFatt As System.Windows.Forms.ListView
   Public WithEvents txtTotaleDocFatt As System.Windows.Forms.TextBox
   Public WithEvents txtScontoFatt As System.Windows.Forms.TextBox
   Public WithEvents txtTotaleFatt As System.Windows.Forms.TextBox
   Friend WithEvents cmdRimuoviFatt As System.Windows.Forms.Button
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents txtNoteDoc As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAziende))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbAttività = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtContatto = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.cmbTitolo = New System.Windows.Forms.ComboBox()
      Me.label = New System.Windows.Forms.Label()
      Me.txtIva = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtSconto = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cmbTipoCliente = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.cmbNazione = New System.Windows.Forms.ComboBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.txtCodFisc = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.txtRegione = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo1 = New System.Windows.Forms.TextBox()
      Me.txtRagSociale = New System.Windows.Forms.TextBox()
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
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.txtIBAN = New System.Windows.Forms.TextBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.cmbPagamento = New System.Windows.Forms.ComboBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.txtCIN = New System.Windows.Forms.TextBox()
      Me.txtCC = New System.Windows.Forms.TextBox()
      Me.txtCAB = New System.Windows.Forms.TextBox()
      Me.txtABI = New System.Windows.Forms.TextBox()
      Me.txtBanca = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.TabPage5 = New System.Windows.Forms.TabPage()
      Me.cmdEliminaBuono = New System.Windows.Forms.Button()
      Me.cmdModificaBuono = New System.Windows.Forms.Button()
      Me.cmdNuovoBuono = New System.Windows.Forms.Button()
      Me.lvwBuoniPasto = New System.Windows.Forms.ListView()
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage7 = New System.Windows.Forms.TabPage()
      Me.txtNoteDoc = New System.Windows.Forms.TextBox()
      Me.cmdRimuoviFatt = New System.Windows.Forms.Button()
      Me.txtTotaleDocFatt = New System.Windows.Forms.TextBox()
      Me.txtScontoFatt = New System.Windows.Forms.TextBox()
      Me.txtTotaleFatt = New System.Windows.Forms.TextBox()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.cmdStampaFatt = New System.Windows.Forms.Button()
      Me.cmdCercaBuoni = New System.Windows.Forms.Button()
      Me.cmdCercaSospesi = New System.Windows.Forms.Button()
      Me.cmbDataAl = New System.Windows.Forms.DateTimePicker()
      Me.cmbDataDal = New System.Windows.Forms.DateTimePicker()
      Me.lblAl = New System.Windows.Forms.Label()
      Me.lblDal = New System.Windows.Forms.Label()
      Me.lstvDatiFatt = New System.Windows.Forms.ListView()
      Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label26 = New System.Windows.Forms.Label()
      Me.txtCodAzienda = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
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
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage3.SuspendLayout()
      Me.TabPage2.SuspendLayout()
      Me.TabPage5.SuspendLayout()
      Me.TabPage7.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      Me.TabPage6.SuspendLayout()
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
      Me.ImageList1.Images.SetKeyName(11, "")
      Me.ImageList1.Images.SetKeyName(12, "")
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
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Controls.Add(Me.TabPage5)
      Me.TabControl1.Controls.Add(Me.TabPage7)
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
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.txtContatto)
      Me.TabPage1.Controls.Add(Me.Label16)
      Me.TabPage1.Controls.Add(Me.cmbTitolo)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.txtIva)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.txtSconto)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.cmbTipoCliente)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.cmbNazione)
      Me.TabPage1.Controls.Add(Me.txtPIva)
      Me.TabPage1.Controls.Add(Me.txtCodFisc)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.Label30)
      Me.TabPage1.Controls.Add(Me.txtRegione)
      Me.TabPage1.Controls.Add(Me.txtProv)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtCittà)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo1)
      Me.TabPage1.Controls.Add(Me.txtRagSociale)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.chkPrivacy)
      Me.TabPage1.Controls.Add(Me.Label39)
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
      Me.cmbAttività.Location = New System.Drawing.Point(104, 240)
      Me.cmbAttività.Name = "cmbAttività"
      Me.cmbAttività.Size = New System.Drawing.Size(184, 21)
      Me.cmbAttività.TabIndex = 13
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 240)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(42, 13)
      Me.Label2.TabIndex = 55716
      Me.Label2.Text = "Attività:"
      '
      'txtContatto
      '
      Me.txtContatto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtContatto.Location = New System.Drawing.Point(104, 216)
      Me.txtContatto.MaxLength = 255
      Me.txtContatto.Name = "txtContatto"
      Me.txtContatto.Size = New System.Drawing.Size(184, 20)
      Me.txtContatto.TabIndex = 10
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(16, 216)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(50, 13)
      Me.Label16.TabIndex = 55714
      Me.Label16.Text = "Contatto:"
      '
      'cmbTitolo
      '
      Me.cmbTitolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTitolo.Location = New System.Drawing.Point(104, 16)
      Me.cmbTitolo.Name = "cmbTitolo"
      Me.cmbTitolo.Size = New System.Drawing.Size(184, 21)
      Me.cmbTitolo.TabIndex = 0
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(16, 16)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(90, 13)
      Me.label.TabIndex = 232
      Me.label.Text = "Forma di cortesia:"
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIva.Location = New System.Drawing.Point(480, 216)
      Me.txtIva.MaxLength = 16
      Me.txtIva.Name = "txtIva"
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(40, 20)
      Me.txtIva.TabIndex = 12
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(440, 216)
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
      Me.txtSconto.Location = New System.Drawing.Point(384, 216)
      Me.txtSconto.MaxLength = 16
      Me.txtSconto.Name = "txtSconto"
      Me.txtSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSconto.Size = New System.Drawing.Size(40, 20)
      Me.txtSconto.TabIndex = 11
      Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(304, 216)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(55, 13)
      Me.Label8.TabIndex = 228
      Me.Label8.Text = "% Sconto:"
      '
      'cmbTipoCliente
      '
      Me.cmbTipoCliente.Location = New System.Drawing.Point(104, 264)
      Me.cmbTipoCliente.Name = "cmbTipoCliente"
      Me.cmbTipoCliente.Size = New System.Drawing.Size(184, 21)
      Me.cmbTipoCliente.TabIndex = 14
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(16, 264)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(55, 13)
      Me.Label7.TabIndex = 185
      Me.Label7.Text = "Categoria:"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(456, 160)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(64, 24)
      Me.EliminaImg.TabIndex = 18
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(384, 160)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(64, 24)
      Me.ApriImg.TabIndex = 17
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
      Me.txtPIva.Location = New System.Drawing.Point(104, 192)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(184, 20)
      Me.txtPIva.TabIndex = 8
      '
      'txtCodFisc
      '
      Me.txtCodFisc.AcceptsReturn = True
      Me.txtCodFisc.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodFisc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodFisc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodFisc.Location = New System.Drawing.Point(384, 192)
      Me.txtCodFisc.MaxLength = 16
      Me.txtCodFisc.Name = "txtCodFisc"
      Me.txtCodFisc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodFisc.Size = New System.Drawing.Size(136, 20)
      Me.txtCodFisc.TabIndex = 9
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(16, 192)
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
      Me.Label30.Location = New System.Drawing.Point(304, 192)
      Me.Label30.Name = "Label30"
      Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label30.Size = New System.Drawing.Size(76, 13)
      Me.Label30.TabIndex = 174
      Me.Label30.Text = "Codice fiscale:"
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
      'txtRagSociale
      '
      Me.txtRagSociale.AcceptsReturn = True
      Me.txtRagSociale.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagSociale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagSociale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagSociale.Location = New System.Drawing.Point(104, 48)
      Me.txtRagSociale.MaxLength = 50
      Me.txtRagSociale.Name = "txtRagSociale"
      Me.txtRagSociale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagSociale.Size = New System.Drawing.Size(264, 20)
      Me.txtRagSociale.TabIndex = 1
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
      Me.Label3.Location = New System.Drawing.Point(16, 48)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(88, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Ragione Sociale:"
      '
      'chkPrivacy
      '
      Me.chkPrivacy.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkPrivacy.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkPrivacy.Location = New System.Drawing.Point(384, 264)
      Me.chkPrivacy.Name = "chkPrivacy"
      Me.chkPrivacy.Size = New System.Drawing.Size(16, 16)
      Me.chkPrivacy.TabIndex = 15
      '
      'Label39
      '
      Me.Label39.AutoSize = True
      Me.Label39.BackColor = System.Drawing.Color.Transparent
      Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label39.ForeColor = System.Drawing.Color.Black
      Me.Label39.Location = New System.Drawing.Point(400, 264)
      Me.Label39.Name = "Label39"
      Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label39.Size = New System.Drawing.Size(126, 13)
      Me.Label39.TabIndex = 16
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
      Me.TabPage3.Size = New System.Drawing.Size(536, 296)
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
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.txtIBAN)
      Me.TabPage2.Controls.Add(Me.Label25)
      Me.TabPage2.Controls.Add(Me.cmbPagamento)
      Me.TabPage2.Controls.Add(Me.Label24)
      Me.TabPage2.Controls.Add(Me.txtCIN)
      Me.TabPage2.Controls.Add(Me.txtCC)
      Me.TabPage2.Controls.Add(Me.txtCAB)
      Me.TabPage2.Controls.Add(Me.txtABI)
      Me.TabPage2.Controls.Add(Me.txtBanca)
      Me.TabPage2.Controls.Add(Me.Label17)
      Me.TabPage2.Controls.Add(Me.Label18)
      Me.TabPage2.Controls.Add(Me.Label19)
      Me.TabPage2.Controls.Add(Me.Label20)
      Me.TabPage2.Controls.Add(Me.Label23)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(536, 296)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Modalità pagamento"
      '
      'txtIBAN
      '
      Me.txtIBAN.AcceptsReturn = True
      Me.txtIBAN.BackColor = System.Drawing.SystemColors.Window
      Me.txtIBAN.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIBAN.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIBAN.Location = New System.Drawing.Point(120, 192)
      Me.txtIBAN.MaxLength = 0
      Me.txtIBAN.Name = "txtIBAN"
      Me.txtIBAN.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIBAN.Size = New System.Drawing.Size(260, 20)
      Me.txtIBAN.TabIndex = 6
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(32, 192)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(35, 13)
      Me.Label25.TabIndex = 55720
      Me.Label25.Text = "IBAN:"
      '
      'cmbPagamento
      '
      Me.cmbPagamento.Location = New System.Drawing.Point(120, 32)
      Me.cmbPagamento.Name = "cmbPagamento"
      Me.cmbPagamento.Size = New System.Drawing.Size(312, 21)
      Me.cmbPagamento.TabIndex = 0
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(32, 32)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(87, 13)
      Me.Label24.TabIndex = 55718
      Me.Label24.Text = "Tipo pagamento:"
      '
      'txtCIN
      '
      Me.txtCIN.AcceptsReturn = True
      Me.txtCIN.BackColor = System.Drawing.SystemColors.Window
      Me.txtCIN.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCIN.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCIN.Location = New System.Drawing.Point(120, 168)
      Me.txtCIN.MaxLength = 1
      Me.txtCIN.Name = "txtCIN"
      Me.txtCIN.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCIN.Size = New System.Drawing.Size(40, 20)
      Me.txtCIN.TabIndex = 5
      '
      'txtCC
      '
      Me.txtCC.AcceptsReturn = True
      Me.txtCC.BackColor = System.Drawing.SystemColors.Window
      Me.txtCC.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCC.Location = New System.Drawing.Point(120, 136)
      Me.txtCC.MaxLength = 12
      Me.txtCC.Name = "txtCC"
      Me.txtCC.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCC.Size = New System.Drawing.Size(144, 20)
      Me.txtCC.TabIndex = 4
      '
      'txtCAB
      '
      Me.txtCAB.AcceptsReturn = True
      Me.txtCAB.BackColor = System.Drawing.SystemColors.Window
      Me.txtCAB.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCAB.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCAB.Location = New System.Drawing.Point(120, 112)
      Me.txtCAB.MaxLength = 5
      Me.txtCAB.Name = "txtCAB"
      Me.txtCAB.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCAB.Size = New System.Drawing.Size(144, 20)
      Me.txtCAB.TabIndex = 3
      '
      'txtABI
      '
      Me.txtABI.AcceptsReturn = True
      Me.txtABI.BackColor = System.Drawing.SystemColors.Window
      Me.txtABI.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtABI.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtABI.Location = New System.Drawing.Point(120, 88)
      Me.txtABI.MaxLength = 5
      Me.txtABI.Name = "txtABI"
      Me.txtABI.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtABI.Size = New System.Drawing.Size(144, 20)
      Me.txtABI.TabIndex = 2
      '
      'txtBanca
      '
      Me.txtBanca.AcceptsReturn = True
      Me.txtBanca.BackColor = System.Drawing.SystemColors.Window
      Me.txtBanca.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBanca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBanca.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBanca.Location = New System.Drawing.Point(120, 64)
      Me.txtBanca.MaxLength = 50
      Me.txtBanca.Name = "txtBanca"
      Me.txtBanca.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBanca.Size = New System.Drawing.Size(312, 20)
      Me.txtBanca.TabIndex = 1
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(32, 168)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(28, 13)
      Me.Label17.TabIndex = 176
      Me.Label17.Text = "CIN:"
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(32, 136)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(29, 13)
      Me.Label18.TabIndex = 175
      Me.Label18.Text = "C/C:"
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(32, 112)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(31, 13)
      Me.Label19.TabIndex = 174
      Me.Label19.Text = "CAB:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(32, 88)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(27, 13)
      Me.Label20.TabIndex = 173
      Me.Label20.Text = "ABI:"
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(32, 64)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(41, 13)
      Me.Label23.TabIndex = 172
      Me.Label23.Text = "Banca:"
      '
      'TabPage5
      '
      Me.TabPage5.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage5.Controls.Add(Me.cmdEliminaBuono)
      Me.TabPage5.Controls.Add(Me.cmdModificaBuono)
      Me.TabPage5.Controls.Add(Me.cmdNuovoBuono)
      Me.TabPage5.Controls.Add(Me.lvwBuoniPasto)
      Me.TabPage5.Location = New System.Drawing.Point(4, 22)
      Me.TabPage5.Name = "TabPage5"
      Me.TabPage5.Size = New System.Drawing.Size(536, 296)
      Me.TabPage5.TabIndex = 7
      Me.TabPage5.Text = "Buoni pasto"
      '
      'cmdEliminaBuono
      '
      Me.cmdEliminaBuono.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdEliminaBuono.Location = New System.Drawing.Point(432, 256)
      Me.cmdEliminaBuono.Name = "cmdEliminaBuono"
      Me.cmdEliminaBuono.Size = New System.Drawing.Size(88, 24)
      Me.cmdEliminaBuono.TabIndex = 7
      Me.cmdEliminaBuono.Text = "&Elimina"
      '
      'cmdModificaBuono
      '
      Me.cmdModificaBuono.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdModificaBuono.Location = New System.Drawing.Point(336, 256)
      Me.cmdModificaBuono.Name = "cmdModificaBuono"
      Me.cmdModificaBuono.Size = New System.Drawing.Size(88, 24)
      Me.cmdModificaBuono.TabIndex = 6
      Me.cmdModificaBuono.Text = "&Modifica"
      '
      'cmdNuovoBuono
      '
      Me.cmdNuovoBuono.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdNuovoBuono.Location = New System.Drawing.Point(248, 256)
      Me.cmdNuovoBuono.Name = "cmdNuovoBuono"
      Me.cmdNuovoBuono.Size = New System.Drawing.Size(80, 24)
      Me.cmdNuovoBuono.TabIndex = 5
      Me.cmdNuovoBuono.Text = "&Nuovo"
      '
      'lvwBuoniPasto
      '
      Me.lvwBuoniPasto.AllowColumnReorder = True
      Me.lvwBuoniPasto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader12})
      Me.lvwBuoniPasto.FullRowSelect = True
      Me.lvwBuoniPasto.Location = New System.Drawing.Point(0, 0)
      Me.lvwBuoniPasto.MultiSelect = False
      Me.lvwBuoniPasto.Name = "lvwBuoniPasto"
      Me.lvwBuoniPasto.Size = New System.Drawing.Size(535, 248)
      Me.lvwBuoniPasto.StateImageList = Me.ImageList1
      Me.lvwBuoniPasto.TabIndex = 4
      Me.lvwBuoniPasto.UseCompatibleStateImageBehavior = False
      Me.lvwBuoniPasto.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "Descrizione"
      Me.ColumnHeader7.Width = 175
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "Valore"
      Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Quantità"
      Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader9.Width = 55
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "Valore totale"
      Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader10.Width = 80
      '
      'ColumnHeader13
      '
      Me.ColumnHeader13.Text = "Q.tà Fatt."
      Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ColumnHeader14
      '
      Me.ColumnHeader14.Text = "Valore Fatt."
      Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader14.Width = 80
      '
      'ColumnHeader12
      '
      Me.ColumnHeader12.Text = "Codice"
      Me.ColumnHeader12.Width = 0
      '
      'TabPage7
      '
      Me.TabPage7.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage7.Controls.Add(Me.txtNoteDoc)
      Me.TabPage7.Controls.Add(Me.cmdRimuoviFatt)
      Me.TabPage7.Controls.Add(Me.txtTotaleDocFatt)
      Me.TabPage7.Controls.Add(Me.txtScontoFatt)
      Me.TabPage7.Controls.Add(Me.txtTotaleFatt)
      Me.TabPage7.Controls.Add(Me.Label32)
      Me.TabPage7.Controls.Add(Me.Label29)
      Me.TabPage7.Controls.Add(Me.Label28)
      Me.TabPage7.Controls.Add(Me.cmdStampaFatt)
      Me.TabPage7.Controls.Add(Me.cmdCercaBuoni)
      Me.TabPage7.Controls.Add(Me.cmdCercaSospesi)
      Me.TabPage7.Controls.Add(Me.cmbDataAl)
      Me.TabPage7.Controls.Add(Me.cmbDataDal)
      Me.TabPage7.Controls.Add(Me.lblAl)
      Me.TabPage7.Controls.Add(Me.lblDal)
      Me.TabPage7.Controls.Add(Me.lstvDatiFatt)
      Me.TabPage7.Controls.Add(Me.Label26)
      Me.TabPage7.Controls.Add(Me.txtCodAzienda)
      Me.TabPage7.Controls.Add(Me.Label27)
      Me.TabPage7.Location = New System.Drawing.Point(4, 22)
      Me.TabPage7.Name = "TabPage7"
      Me.TabPage7.Size = New System.Drawing.Size(536, 296)
      Me.TabPage7.TabIndex = 8
      Me.TabPage7.Text = "Fatturazione"
      '
      'txtNoteDoc
      '
      Me.txtNoteDoc.AcceptsReturn = True
      Me.txtNoteDoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtNoteDoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNoteDoc.ForeColor = System.Drawing.Color.Black
      Me.txtNoteDoc.Location = New System.Drawing.Point(96, 264)
      Me.txtNoteDoc.MaxLength = 0
      Me.txtNoteDoc.Name = "txtNoteDoc"
      Me.txtNoteDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNoteDoc.Size = New System.Drawing.Size(176, 20)
      Me.txtNoteDoc.TabIndex = 6
      Me.ToolTip1.SetToolTip(Me.txtNoteDoc, "Note visualizzate nella fattura.")
      '
      'cmdRimuoviFatt
      '
      Me.cmdRimuoviFatt.Enabled = False
      Me.cmdRimuoviFatt.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRimuoviFatt.Location = New System.Drawing.Point(8, 210)
      Me.cmdRimuoviFatt.Name = "cmdRimuoviFatt"
      Me.cmdRimuoviFatt.Size = New System.Drawing.Size(264, 24)
      Me.cmdRimuoviFatt.TabIndex = 4
      Me.cmdRimuoviFatt.Text = "&Rimuovi Documento sospeso selezionato"
      '
      'txtTotaleDocFatt
      '
      Me.txtTotaleDocFatt.AcceptsReturn = True
      Me.txtTotaleDocFatt.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotaleDocFatt.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleDocFatt.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleDocFatt.Location = New System.Drawing.Point(408, 264)
      Me.txtTotaleDocFatt.MaxLength = 0
      Me.txtTotaleDocFatt.Name = "txtTotaleDocFatt"
      Me.txtTotaleDocFatt.ReadOnly = True
      Me.txtTotaleDocFatt.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleDocFatt.Size = New System.Drawing.Size(112, 20)
      Me.txtTotaleDocFatt.TabIndex = 9
      Me.txtTotaleDocFatt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtScontoFatt
      '
      Me.txtScontoFatt.AcceptsReturn = True
      Me.txtScontoFatt.BackColor = System.Drawing.SystemColors.Control
      Me.txtScontoFatt.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoFatt.ForeColor = System.Drawing.Color.Red
      Me.txtScontoFatt.Location = New System.Drawing.Point(408, 240)
      Me.txtScontoFatt.MaxLength = 0
      Me.txtScontoFatt.Name = "txtScontoFatt"
      Me.txtScontoFatt.ReadOnly = True
      Me.txtScontoFatt.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoFatt.Size = New System.Drawing.Size(112, 20)
      Me.txtScontoFatt.TabIndex = 8
      Me.txtScontoFatt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotaleFatt
      '
      Me.txtTotaleFatt.AcceptsReturn = True
      Me.txtTotaleFatt.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotaleFatt.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleFatt.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleFatt.Location = New System.Drawing.Point(408, 216)
      Me.txtTotaleFatt.MaxLength = 0
      Me.txtTotaleFatt.Name = "txtTotaleFatt"
      Me.txtTotaleFatt.ReadOnly = True
      Me.txtTotaleFatt.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleFatt.Size = New System.Drawing.Size(112, 20)
      Me.txtTotaleFatt.TabIndex = 7
      Me.txtTotaleFatt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.BackColor = System.Drawing.Color.Transparent
      Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label32.ForeColor = System.Drawing.Color.Black
      Me.Label32.Location = New System.Drawing.Point(312, 264)
      Me.Label32.Name = "Label32"
      Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label32.Size = New System.Drawing.Size(96, 13)
      Me.Label32.TabIndex = 55675
      Me.Label32.Text = "Totale documento:"
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.BackColor = System.Drawing.Color.Transparent
      Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label29.ForeColor = System.Drawing.Color.Black
      Me.Label29.Location = New System.Drawing.Point(312, 240)
      Me.Label29.Name = "Label29"
      Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label29.Size = New System.Drawing.Size(44, 13)
      Me.Label29.TabIndex = 55674
      Me.Label29.Text = "Sconto:"
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.BackColor = System.Drawing.Color.Transparent
      Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label28.ForeColor = System.Drawing.Color.Black
      Me.Label28.Location = New System.Drawing.Point(312, 216)
      Me.Label28.Name = "Label28"
      Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label28.Size = New System.Drawing.Size(40, 13)
      Me.Label28.TabIndex = 55673
      Me.Label28.Text = "Totale:"
      '
      'cmdStampaFatt
      '
      Me.cmdStampaFatt.Enabled = False
      Me.cmdStampaFatt.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdStampaFatt.Location = New System.Drawing.Point(408, 8)
      Me.cmdStampaFatt.Name = "cmdStampaFatt"
      Me.cmdStampaFatt.Size = New System.Drawing.Size(112, 24)
      Me.cmdStampaFatt.TabIndex = 2
      Me.cmdStampaFatt.Text = "&Stampa Fattura"
      '
      'cmdCercaBuoni
      '
      Me.cmdCercaBuoni.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdCercaBuoni.Location = New System.Drawing.Point(96, 8)
      Me.cmdCercaBuoni.Name = "cmdCercaBuoni"
      Me.cmdCercaBuoni.Size = New System.Drawing.Size(88, 24)
      Me.cmdCercaBuoni.TabIndex = 1
      Me.cmdCercaBuoni.Text = "Cerca &Buoni"
      '
      'cmdCercaSospesi
      '
      Me.cmdCercaSospesi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdCercaSospesi.Location = New System.Drawing.Point(8, 8)
      Me.cmdCercaSospesi.Name = "cmdCercaSospesi"
      Me.cmdCercaSospesi.Size = New System.Drawing.Size(80, 24)
      Me.cmdCercaSospesi.TabIndex = 0
      Me.cmdCercaSospesi.Text = "Cerca S&ospesi"
      '
      'cmbDataAl
      '
      Me.cmbDataAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbDataAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbDataAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.cmbDataAl.Location = New System.Drawing.Point(344, 8)
      Me.cmbDataAl.Name = "cmbDataAl"
      Me.cmbDataAl.Size = New System.Drawing.Size(88, 20)
      Me.cmbDataAl.TabIndex = 10
      Me.cmbDataAl.Visible = False
      '
      'cmbDataDal
      '
      Me.cmbDataDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbDataDal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbDataDal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.cmbDataDal.Location = New System.Drawing.Point(224, 8)
      Me.cmbDataDal.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
      Me.cmbDataDal.Name = "cmbDataDal"
      Me.cmbDataDal.Size = New System.Drawing.Size(88, 20)
      Me.cmbDataDal.TabIndex = 9
      Me.cmbDataDal.Visible = False
      '
      'lblAl
      '
      Me.lblAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAl.AutoSize = True
      Me.lblAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblAl.ForeColor = System.Drawing.Color.Black
      Me.lblAl.Location = New System.Drawing.Point(320, 8)
      Me.lblAl.Name = "lblAl"
      Me.lblAl.Size = New System.Drawing.Size(20, 15)
      Me.lblAl.TabIndex = 55667
      Me.lblAl.Text = "Al:"
      Me.lblAl.Visible = False
      '
      'lblDal
      '
      Me.lblDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDal.AutoSize = True
      Me.lblDal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDal.ForeColor = System.Drawing.Color.Black
      Me.lblDal.Location = New System.Drawing.Point(192, 8)
      Me.lblDal.Name = "lblDal"
      Me.lblDal.Size = New System.Drawing.Size(29, 15)
      Me.lblDal.TabIndex = 55666
      Me.lblDal.Text = "Dal:"
      Me.lblDal.Visible = False
      '
      'lstvDatiFatt
      '
      Me.lstvDatiFatt.AllowColumnReorder = True
      Me.lstvDatiFatt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader11, Me.ColumnHeader15, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader17, Me.ColumnHeader16})
      Me.lstvDatiFatt.FullRowSelect = True
      Me.lstvDatiFatt.Location = New System.Drawing.Point(0, 40)
      Me.lstvDatiFatt.MultiSelect = False
      Me.lstvDatiFatt.Name = "lstvDatiFatt"
      Me.lstvDatiFatt.Size = New System.Drawing.Size(535, 168)
      Me.lstvDatiFatt.StateImageList = Me.ImageList1
      Me.lstvDatiFatt.TabIndex = 3
      Me.lstvDatiFatt.UseCompatibleStateImageBehavior = False
      Me.lstvDatiFatt.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader18
      '
      Me.ColumnHeader18.Text = "Q.tà"
      Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader18.Width = 80
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "Descrizione"
      Me.ColumnHeader11.Width = 250
      '
      'ColumnHeader15
      '
      Me.ColumnHeader15.Text = "Valore"
      Me.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader15.Width = 80
      '
      'ColumnHeader19
      '
      Me.ColumnHeader19.Text = "Valore totale"
      Me.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader19.Width = 100
      '
      'ColumnHeader20
      '
      Me.ColumnHeader20.Text = "Codice"
      Me.ColumnHeader20.Width = 0
      '
      'ColumnHeader17
      '
      Me.ColumnHeader17.Text = "Valore totale"
      Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader17.Width = 0
      '
      'ColumnHeader16
      '
      Me.ColumnHeader16.Text = "Quantità"
      Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader16.Width = 0
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.BackColor = System.Drawing.Color.Transparent
      Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label26.ForeColor = System.Drawing.Color.Black
      Me.Label26.Location = New System.Drawing.Point(8, 264)
      Me.Label26.Name = "Label26"
      Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label26.Size = New System.Drawing.Size(89, 13)
      Me.Label26.TabIndex = 215
      Me.Label26.Text = "Note documento:"
      '
      'txtCodAzienda
      '
      Me.txtCodAzienda.AcceptsReturn = True
      Me.txtCodAzienda.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodAzienda.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodAzienda.ForeColor = System.Drawing.Color.Black
      Me.txtCodAzienda.Location = New System.Drawing.Point(96, 240)
      Me.txtCodAzienda.MaxLength = 0
      Me.txtCodAzienda.Name = "txtCodAzienda"
      Me.txtCodAzienda.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodAzienda.Size = New System.Drawing.Size(176, 20)
      Me.txtCodAzienda.TabIndex = 5
      Me.ToolTip1.SetToolTip(Me.txtCodAzienda, "Codice fornito dall'azienda emettitrice dei Buoni pasto.")
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.Color.Transparent
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.Color.Black
      Me.Label27.Location = New System.Drawing.Point(8, 240)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(89, 13)
      Me.Label27.TabIndex = 214
      Me.Label27.Text = "Codice ristorante:"
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
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Fattura.rpt"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmAziende
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
      Me.Name = "frmAziende"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Aziende"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.TabPage5.ResumeLayout(False)
      Me.TabPage7.ResumeLayout(False)
      Me.TabPage7.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni "

   Private AAziende As New Anagrafiche.AziendaCliente(ConnStringAnagrafiche)
   Private Doc As New Documenti
   Private IAllegati As New Allegati
   Private CBuoniPasto As New Buoni
   Private CConvalida As New ConvalidaKeyPress
   Private CFormatta As New ClsFormatta
   Private DatiConfig As AppConfig

   Const TAB_QUALIFICHE As String = "Qualifiche"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_TIPO_CLIENTE As String = "CategorieClienti"
   Const TAB_ATTIVITA As String = "Attività"
   Const TAB_PAGAMENTO As String = "ModPagamento"
   Const TAB_ALLEGATI As String = "Aziende_Allegati"
   Const TAB_BUONI_PASTO As String = "BuoniPasto"
   Const TAB_BUONI_PASTO_FATT As String = "BuoniPastoFatt"
   Const TAB_DOC As String = "Documenti"
   Const TAB_DETTAGLI_DOC As String = "DettagliDoc"
   Const TAB_AZIENDA As String = "Azienda"
   Const NOME_TABELLA As String = "Aziende"

   Const TIPO_DOC_FF As String = "Fattura"
   Dim percorsoRep As String

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

   Dim buoniInLista As Boolean = False
   Dim sospesiInLista As Boolean = False

   Enum formatoFattAziende As Short
      Grande = 0
      Piccola = 1
   End Enum

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

         AAziende.Immagine = OpenFileDialog1.FileName

         If File.Exists(AAziende.Immagine) = True Then
            Dim bmp As New Bitmap(AAziende.Immagine)
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
            AAziende.Immagine = ""
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
         AggiornaTabella(cmbAttività, TAB_ATTIVITA)
         AggiornaTabella(cmbPagamento, TAB_PAGAMENTO)

         With AAziende
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .RagSociale = FormattaApici(txtRagSociale.Text)
            .Titolo = FormattaApici(cmbTitolo.Text)
            .CodFisc = FormattaApici(txtCodFisc.Text)
            .PIva = FormattaApici(txtPIva.Text)
            .Indirizzo1 = FormattaApici(txtIndirizzo1.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .Regione = FormattaApici(txtRegione.Text)
            .Nazione = FormattaApici(cmbNazione.Text)
            .TipoCliente = FormattaApici(cmbTipoCliente.Text)
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
            If chkPrivacy.Checked = True Then
               .Privacy = "Sì"
            Else
               .Privacy = "No"
            End If
            .TelCasa = FormattaApici(txtTelCasa.Text)
            .TelUfficio = FormattaApici(txtTelUfficio.Text)
            .Cell = FormattaApici(txtCell.Text)
            .Fax = FormattaApici(txtFax.Text)
            .Email = FormattaApici(txtEmail.Text)
            .Internet = FormattaApici(txtInternet.Text)
            .TipoPagamento = FormattaApici(cmbPagamento.Text)
            .Banca = FormattaApici(txtBanca.Text)
            .Abi = FormattaApici(txtABI.Text)
            .Cab = FormattaApici(txtCAB.Text)
            .Cc = FormattaApici(txtCC.Text)
            .Cin = FormattaApici(txtCIN.Text)
            .Iban = FormattaApici(txtIBAN.Text)

            .CodAzienda = FormattaApici(txtCodAzienda.Text)
            .Note = FormattaApici(txtNote.Text)
            .NoteDoc = FormattaApici(txtNoteDoc.Text)

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

#End Region

#Region "Allegati "

   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      Try
         OpenFileDialog1.Filter = "Tutti i file |*.*"

         OpenFileDialog1.FilterIndex = 1

         IAllegati.IdCliente = CInt(AAziende.Codice)

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
         If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, AAziende.Codice) = True Then
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

#End Region

#Region "Buoni pasto "

   Private Sub CaricaBuoniPasto()
      Try
         ' Carica la lista dei componenti aggiuntivi.
         If CBuoniPasto.LeggiDati(lvwBuoniPasto, TAB_BUONI_PASTO, AAziende.Codice) = True Then
            cmdModificaBuono.Enabled = True
            cmdEliminaBuono.Enabled = True
         Else
            cmdModificaBuono.Enabled = False
            cmdEliminaBuono.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub EliminaBuoniPasto(ByVal tabella As String, ByVal id As Integer, ByVal descrizione As String)
      Try
         Dim Risposta As Short
         Dim sql As String

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare il Buono pasto """ & descrizione & """?" & vbCrLf & vbCrLf & _
                           "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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

   Private Function ImpostaDatiBuoniPasto(ByVal descrizione As String, ByVal valore As String, ByVal nuovo As Boolean) As Boolean
      Try
         CBuoniPasto.IdAzienda = CInt(AAziende.Codice)

         If nuovo = True Then
            CBuoniPasto.Quantità = 0
            CBuoniPasto.ValoreTotale = VALORE_ZERO
            CBuoniPasto.QuantitàFatt = 0
            CBuoniPasto.ValoreFatt = VALORE_ZERO
         End If

         Dim val As String

         Do
            val = InputBox("Inserire un valore numerico unitario per il Buono pasto.", "Valore", valore)
            If val <> "" Then
               If IsNumeric(val) = True Then
                  CBuoniPasto.ValoreUnitario = CFormatta.FormattaEuro(Convert.ToDecimal(val))
                  If nuovo = True Then
                     descrizione = txtRagSociale.Text & " - € " & CBuoniPasto.ValoreUnitario
                  End If
               End If
            Else
               If nuovo = True Then
                  CBuoniPasto.ValoreUnitario = VALORE_ZERO
               Else
                  CBuoniPasto.ValoreUnitario = valore
               End If
            End If
         Loop Until IsNumeric(val) = True

         val = InputBox("Inserire una descrizione per il Buono pasto.", "Descrizione", descrizione)
         If val <> "" Then
            CBuoniPasto.Descrizione = val
         Else
            If nuovo = True Then
               Return False
            Else
               CBuoniPasto.Descrizione = descrizione
            End If
         End If

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

#End Region

#Region "Fatturazione "

   Private Sub CercaBuoni(ByVal lst As ListView, ByVal tabella As String)
      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & _
                                     " WHERE IdAzienda = " & AAziende.Codice & _
                                     " AND QuantitàFatt > 0 ORDER BY Id ASC", cn)

         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim i As Integer = lst.Items.Count

         Do While dr.Read()
            lst.Items.Add(dr.Item("QuantitàFatt"))
            lst.Items(i).SubItems.Add(dr.Item("Descrizione"))
            lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(dr.Item("ValoreUnitario")))
            lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(dr.Item("ValoreFatt")))
            lst.Items(i).SubItems.Add(dr.Item("Id"))
            lst.Items(i).StateImageIndex = 11

            i = i + 1
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CercaSospesi(ByVal lst As ListView, ByVal tabella As String)
      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & _
                                     " WHERE IdCliente = 'A" & AAziende.Codice & "'" & _
                                     " AND SospesoIncassare > 0 ORDER BY Id ASC", cn)

         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim i As Integer = lst.Items.Count
         Dim descrizioneDoc As String

         Do While dr.Read()
            descrizioneDoc = "Rif. " & dr.Item("TipoDoc") & " N. " & dr.Item("NumDoc") & " del " & dr.Item("DataDoc")
            lst.Items.Add("1")
            lst.Items(i).SubItems.Add(descrizioneDoc)
            lst.Items(i).SubItems.Add("")
            lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(dr.Item("SospesoIncassare")))
            lst.Items(i).SubItems.Add(dr.Item("Id"))
            lst.Items(i).StateImageIndex = 12

            i = i + 1
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaSospesiBuoni()
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      lstvDatiFatt.Items.Clear()

      If buoniInLista = True And sospesiInLista = True Then
         CercaBuoni(lstvDatiFatt, TAB_BUONI_PASTO)
         CercaSospesi(lstvDatiFatt, TAB_DOC)

      ElseIf buoniInLista = True And sospesiInLista = False Then
         CercaBuoni(lstvDatiFatt, TAB_BUONI_PASTO)

      ElseIf buoniInLista = False And sospesiInLista = True Then
         CercaSospesi(lstvDatiFatt, TAB_DOC)

      End If

      CalcolaTotaliDocumento()

      If lstvDatiFatt.Items.Count = 0 Then
         cmdRimuoviFatt.Enabled = False
         cmdStampaFatt.Enabled = False
      Else
         cmdRimuoviFatt.Enabled = True
         cmdStampaFatt.Enabled = True
      End If

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Private Sub CalcolaTotaliDocumento()
      ' Valore totale delgli importi.
      Dim valTotale As Double = SommaColonna(lstvDatiFatt, 3)

      ' Sconto percentuale.
      Dim sconto As Double
      If IsNumeric(txtSconto.Text) = True Then
         sconto = Convert.ToDouble(txtSconto.Text)
      Else
         sconto = 0
      End If

      ' Valore dello sconto.
      Dim valSconto As Double = CalcolaPercentuale(valTotale, sconto)

      ' Valore del totale documento.
      Dim valTotaleDoc As Double = valTotale - valSconto

      ' Visualizzo i valori.
      txtTotaleFatt.Text = CFormatta.FormattaNumeroDouble(valTotale)
      txtScontoFatt.Text = CFormatta.FormattaNumeroDouble(valSconto)
      txtTotaleDocFatt.Text = CFormatta.FormattaNumeroDouble(valTotaleDoc)
   End Sub

   Private Sub RimuoviElementoLista()
      Try
         If lstvDatiFatt.Items.Count <> 0 Then
            lstvDatiFatt.Focus()
            If lstvDatiFatt.Items(lstvDatiFatt.FocusedItem.Index).SubItems(2).Text = "" Then
               lstvDatiFatt.Items.RemoveAt(lstvDatiFatt.FocusedItem.Index)
            Else
               MessageBox.Show("Non è possibile rimuovere Buoni pasto.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDocumento()
      Try
         ' Valore ID per l'Azienda o Buono pasto.
         Dim IdAziendaBuono As String

         With Doc
            Dim valDaPagare As Double = Convert.ToDouble(txtTotaleDocFatt.Text)

            .Numero = LeggiNumeroMax(TAB_DOC, TIPO_DOC_FF) + 1
            .Data = Today '.ToShortDateString 'dtpData.Value.Date

            If DateTime.Now.Minute.ToString.Length = 1 Then
               .Ora = DateTime.Now.Hour & "." & "0" & DateTime.Now.Minute
            Else
               .Ora = DateTime.Now.Hour & "." & DateTime.Now.Minute
            End If

            .Tipo = TIPO_DOC_FF
            .IdCliente = "A" & AAziende.Codice
            .Cliente = FormattaApici(txtRagSociale.Text)
            .Indirizzo = FormattaApici(txtIndirizzo1.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .PIva = txtPIva.Text
            .CodAzienda = FormattaApici(txtCodAzienda.Text)
            .Sconto = CFormatta.FormattaNumeroDouble(txtScontoFatt.Text)
            .Servizio = VALORE_ZERO
            .BuoniPasto = VALORE_ZERO
            .BuoniPastoIncassare = VALORE_ZERO
            .TipoPagamento = ""
            .Tavolo = ""
            .Cameriere = ""
            .Sospeso = VALORE_ZERO
            .SospesoIncassare = VALORE_ZERO
            .TotDoc = valDaPagare
            .Chiuso = "No"
            .Note = FormattaApici(txtNoteDoc.Text)

            '---------------------------------------------------------------------------------
            '' Calcola l'IVA - VECCHIA VERSIONE -
            'Dim valImposta As Double
            'If IsNumeric(txtIva.Text) = True Then
            '   valImposta = CalcolaPercentuale(valDaPagare, Convert.ToDouble(txtIva.Text))
            'Else
            '   valImposta = 0.0
            '   txtIva.Text = VALORE_ZERO
            'End If

            'Dim valImponibile As Double = (valDaPagare - valImposta)
            '.Imponibile = CFormatta.FormattaNumeroDouble(valImponibile)
            '.Iva = txtIva.Text
            '.Imposta = CFormatta.FormattaNumeroDouble(valImposta)
            '---------------------------------------------------------------------------------

            ' Calcola l'IVA. - NUOVA VERSIONE - 
               Dim valImposta As Double
               Dim valImponibile As Double
               If IsNumeric(txtIva.Text) = True Then

                  Dim valCoefficiente As Double
                  Select Case txtIva.Text
                     Case "20,00"
                        valCoefficiente = 1.2
                     Case "10,00"
                        valCoefficiente = 1.1
                     Case "4,00"
                        valCoefficiente = 1.04
                     Case Else
                        valCoefficiente = 0.0
                  End Select

                  If valCoefficiente <> 0.0 Then
                     valImponibile = (valDaPagare / valCoefficiente)
                  Else
                     valImponibile = 0.0
                  End If

                  valImposta = CalcolaPercentuale(valImponibile, Convert.ToDouble(txtIva.Text))
               Else
                  valImposta = 0.0
                  txtIva.Text = VALORE_ZERO
               End If

            .Imponibile = CFormatta.FormattaNumeroDouble(valImponibile)
            .Iva = txtIva.Text
            .Imposta = CFormatta.FormattaNumeroDouble(valImposta)

            .InserisciDati(TAB_DOC)
         End With

         ' SALVA I DETTAGLI DEL DOCUMENTO.
         Dim sql As String
         ' Apre la connessione.
         cn.Open()

         Dim i As Integer
         For i = 0 To lstvDatiFatt.Items.Count - 1
            Dim valUnitario As String
            If lstvDatiFatt.Items(i).SubItems(2).Text <> "" Then
               valUnitario = lstvDatiFatt.Items(i).SubItems(2).Text
            Else
               valUnitario = VALORE_ZERO
            End If

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa.
            sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ValoreUnitario, ImportoNetto) " & _
                                                "VALUES(@RifDoc, @Descrizione, @Quantità, @ValoreUnitario, @ImportoNetto)", TAB_DETTAGLI_DOC)
            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)
            cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
            cmdInsert.Parameters.Add("@Descrizione", FormattaApici(lstvDatiFatt.Items(i).SubItems(1).Text))
            cmdInsert.Parameters.Add("@Quantità", lstvDatiFatt.Items(i).SubItems(0).Text)
            cmdInsert.Parameters.Add("@ValoreUnitario", valUnitario)
            cmdInsert.Parameters.Add("@ImportoNetto", lstvDatiFatt.Items(i).SubItems(3).Text)
            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()
         Next

         If LeggiFormatoFatt() = formatoFattAziende.Piccola Then
            ' SALVA I DETTAGLI PER LO SCONTO.
            If Doc.Sconto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " & _
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)
               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)
               cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.Add("@Descrizione", "Sconto")
               cmdInsert.Parameters.Add("@Quantità", "1")
               cmdInsert.Parameters.Add("@ImportoNetto", "-" & Doc.Sconto)
               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         ' AZZERA I DOCUMENTI IN SOSPESO SELEZIONATI.
         For i = 0 To lstvDatiFatt.Items.Count - 1
            IdAziendaBuono = lstvDatiFatt.Items(i).SubItems(4).Text
            ' Se nella lista è assente il valore unitario allora è un Sospeso.
            If lstvDatiFatt.Items(i).SubItems(2).Text = "" Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa.
               sql = String.Format("UPDATE {0} SET SospesoIncassare = @SospesoIncassare WHERE Id = {1}", TAB_DOC, Convert.ToInt32(IdAziendaBuono))
               ' Crea il comando per la connessione corrente.
               Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
               cmdUpdate.Parameters.Add("@SospesoIncassare", VALORE_ZERO)
               ' Esegue il comando.
               Dim Record1 As Integer = cmdUpdate.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         Next

         ' AZZERA IL VALORE PER I BUONI DA FATTURARE.
         For i = 0 To lstvDatiFatt.Items.Count - 1
            IdAziendaBuono = lstvDatiFatt.Items(i).SubItems(4).Text
            ' Se nella lista è presente il valore unitario allora è un Buono pasto.
            If lstvDatiFatt.Items(i).SubItems(2).Text <> "" Then

               ' Aggiorna i valori per la scheda Buoni Pasto.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa.
               sql = String.Format("UPDATE {0} SET QuantitàFatt = @QuantitàFatt, ValoreFatt = @ValoreFatt WHERE Id = {1}", TAB_BUONI_PASTO, Convert.ToInt32(IdAziendaBuono))
               ' Crea il comando per la connessione corrente.
               Dim cmdUpdate3 As New OleDbCommand(sql, cn, tr)
               cmdUpdate3.Parameters.Add("@QuantitàFatt", VALORE_ZERO)
               cmdUpdate3.Parameters.Add("@ValoreFatt", VALORE_ZERO)
               ' Esegue il comando.
               Dim Record3 As Integer = cmdUpdate3.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()

               ' AZZERA IL VALORE BUONI PASTO PER I DOCUMENTI DA INCASSARE.
               ' Leggo i dati dei buoni emessi per conoscere l'ID del documento a cui appartengono.
               Dim CBuoniFatt As New BuoniFatt
               ' Visualizza i dati nei rispettivi campi.
               CBuoniFatt.LeggiDati(TAB_BUONI_PASTO_FATT, IdAziendaBuono)
               Dim valTotaleBuoni As Double = Convert.ToDouble(CBuoniFatt.ValoreTotale)

               ' Leggo i dati del documento a cui fa riferimento l'ID preso dal Buono.
               Dim docFatt As New Documenti
               docFatt.LeggiDati(TAB_DOC, CBuoniFatt.IdDoc)
               Dim valBuoniPastoIncassare As Double = Convert.ToDouble(docFatt.BuoniPastoIncassare)
               ' Sottraggo il valore totale del Buono dal valore dei Buoni da incassare.
               Dim nuovoValBuoniPastoIncassare As Double = valBuoniPastoIncassare - valTotaleBuoni

               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa.
               sql = String.Format("UPDATE {0} SET BuoniPastoIncassare = @BuoniPastoIncassare WHERE Id = {1}", TAB_DOC, CBuoniFatt.IdDoc)
               ' Crea il comando per la connessione corrente.
               Dim cmdUpdate2 As New OleDbCommand(sql, cn, tr)
               cmdUpdate2.Parameters.Add("@BuoniPastoIncassare", nuovoValBuoniPastoIncassare)
               ' Esegue il comando.
               Dim Record2 As Integer = cmdUpdate2.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()

               ' Elimino il Buono Pasto dalla tabella BuoniPastoFatt.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM {0} WHERE IdBuono = {1}", TAB_BUONI_PASTO_FATT, IdAziendaBuono)
               ' Crea il comando per la connessione corrente.
               Dim cmdDelete As New OleDbCommand(sql, cn, tr)
               ' Esegue il comando.
               Dim Record4 As Integer = cmdDelete.ExecuteNonQuery()
               ' Conferma la transazione.
               tr.Commit()

            End If
         Next

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal numDoc As Integer)
      Try
         'If PrintDialog1.ShowDialog() = DialogResult.OK Then

         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella Documenti.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DOC & " WHERE Id = " & numDoc, cn)

         Dim ds As New Dataset1
         ds.Clear()
         oleAdapter.Fill(ds, TAB_DOC)

         ' Tabella DettagliDoc
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_DOC & " WHERE RifDoc = " & numDoc, cn)
         oleAdapter1.Fill(ds, TAB_DETTAGLI_DOC)

         ' Tabella Azienda
         Dim oleAdapter2 As New OleDbDataAdapter
         oleAdapter2.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_AZIENDA, cn)
         oleAdapter2.Fill(ds, TAB_AZIENDA)

         Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         rep.Load(Application.StartupPath & nomeDoc)

         rep.SetDataSource(ds)

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

   Private Function LeggiNumeroMax(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}'", tabella, tipoDoc)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            numRec = CInt(cmd.ExecuteScalar())
         Else
            numRec = 0
         End If

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub AzzeraFatturazione()
      cmdStampaFatt.Enabled = False
      cmdRimuoviFatt.Enabled = False
      lstvDatiFatt.Items.Clear()
      buoniInLista = False
      sospesiInLista = False
      txtTotaleFatt.Text = VALORE_ZERO
      txtScontoFatt.Text = VALORE_ZERO
      txtTotaleDocFatt.Text = VALORE_ZERO
   End Sub

   Private Function LeggiFormatoFatt() As String
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If DatiConfig.GetValue("FormatoFattAziende").Length = 0 Then
            Return formatoFattAziende.Grande
         Else
            Return formatoFattAziende.Piccola
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

#End Region

#Region "Eventi "

   Private Sub frmAziende_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With AAziende
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtRagSociale.Text = .RagSociale
               cmbTitolo.Text = .Titolo
               txtCodFisc.Text = .CodFisc
               txtPIva.Text = .PIva
               txtIndirizzo1.Text = .Indirizzo1
               txtCap.Text = .Cap
               txtCittà.Text = .Città
               txtProv.Text = .Provincia
               txtRegione.Text = .Regione
               cmbNazione.Text = .Nazione
               txtContatto.Text = .Contatto
               cmbAttività.Text = .Attività
               cmbTipoCliente.Text = .TipoCliente
               txtSconto.Text = .Sconto
               txtIva.Text = .Iva
               txtTelCasa.Text = .TelCasa
               txtTelUfficio.Text = .TelUfficio
               txtCell.Text = .Cell
               txtFax.Text = .Fax
               txtEmail.Text = .Email
               txtInternet.Text = .Internet
               cmbPagamento.Text = .TipoPagamento
               txtBanca.Text = .Banca
               txtABI.Text = .Abi
               txtCAB.Text = .Cab
               txtCC.Text = .Cc
               txtCIN.Text = .Cin
               txtIBAN.Text = .Iban
               txtCodAzienda.Text = .CodAzienda
               txtNote.Text = .Note
               txtNoteDoc.Text = .NoteDoc

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
            TabControl1.TabPages(3).Enabled = True
            TabControl1.TabPages(5).Enabled = True
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.
            txtSconto.Text = VALORE_ZERO
            txtIva.Text = VALORE_ZERO

            ' Per i nuovi clienti che non sono nel database (con un id)
            ' disattiva la scheda Allegati.
            TabControl1.TabPages(3).Enabled = False
            TabControl1.TabPages(5).Enabled = False
         End If

         ' Carica le liste.
         CaricaLista(cmbTitolo, TAB_QUALIFICHE)
         CaricaLista(cmbNazione, TAB_NAZIONI)
         CaricaLista(cmbTipoCliente, TAB_TIPO_CLIENTE)
         CaricaLista(cmbAttività, TAB_ATTIVITA)
         CaricaLista(cmbPagamento, TAB_PAGAMENTO)

         ' Carica la lista delle dei Buoni pasto.
         CaricaBuoniPasto()

         ' Carica la lista delle degli allegati.
         ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione("", txtRagSociale.Text, "")

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

   Private Sub frmAziende_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_AZIENDE)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmAziende) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmAziende.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & AAziende.RagSociale & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_AZIENDE)

            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_AZIENDE)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               Me.cmbTitolo.Focus()
               AzzeraFatturazione()

            Case 1
               ' Imposta lo stato attivo.
               Me.txtTelCasa.Focus()
               AzzeraFatturazione()

            Case 2
               ' Imposta lo stato attivo.
               Me.cmbPagamento.Focus()
               AzzeraFatturazione()

            Case 3
               ' Carica la lista delle dei Buoni pasto.
               CaricaBuoniPasto()

               ' Imposta lo stato attivo.
               lvwBuoniPasto.Focus()
               ' Imposta il pulsante di default.
               cmdNuovoBuono.NotifyDefault(True)
               AzzeraFatturazione()

            Case 4
               ' UTILIZZARE PER LA RICERCA PER PERIODO.
               ' -----------------------------------------------------------------------
               ' cmbDataDal.Text = CFormatta.FormattaData("01/01/" & Year(Now).ToString)
               ' -----------------------------------------------------------------------

               ' Imposta lo stato attivo.
               cmdCercaSospesi.Focus()
               AzzeraFatturazione()

            Case 5
               ' Imposta lo stato attivo.
               lvwAllegati.Focus()
               ' Imposta il pulsante di default.
               cmdInserimento.NotifyDefault(True)
               AzzeraFatturazione()

            Case 6
               ' Imposta lo stato attivo.
               Me.txtNote.Focus()
               AzzeraFatturazione()

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

   Private Sub txtABI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtABI.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtCAB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAB.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub cmdNuovoBuono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuovoBuono.Click
      Try
         If ImpostaDatiBuoniPasto("", "", True) = True Then
            CBuoniPasto.InserisciDati(TAB_BUONI_PASTO)
            CaricaBuoniPasto()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdModificaBuono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModificaBuono.Click
      Try
         cmdNuovoBuono.NotifyDefault(False)

         With CBuoniPasto
            .Descrizione = lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(0).Text
            .ValoreUnitario = lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(1).Text
            .Quantità = lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(2).Text
            .ValoreTotale = lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(3).Text
            .QuantitàFatt = lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(4).Text
            .ValoreFatt = lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(5).Text

            If ImpostaDatiBuoniPasto(.Descrizione, .ValoreUnitario, False) = True Then
               .ModificaDati(TAB_BUONI_PASTO, lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(6).Text)
               CaricaBuoniPasto()
            End If
         End With

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

   Private Sub cmdEliminaBuono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminaBuono.Click
      Try
         cmdNuovoBuono.NotifyDefault(False)

         If lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(4).Text = "0" Then
            EliminaBuoniPasto(TAB_BUONI_PASTO, lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(6).Text, lvwBuoniPasto.Items(lvwBuoniPasto.FocusedItem.Index).SubItems(0).Text)
            CaricaBuoniPasto()
         Else
            MessageBox.Show("Non è possibile eliminare Buoni pasto con quantità da fatturare diversa da zero.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

#End Region

   Private Sub cmdCercaBuoni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCercaBuoni.Click
      buoniInLista = True
      CaricaSospesiBuoni()
   End Sub

   Private Sub cmdCercaSospesi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCercaSospesi.Click
      sospesiInLista = True
      CaricaSospesiBuoni()
   End Sub

   Private Sub cmdRimuoviFatt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRimuoviFatt.Click
      RimuoviElementoLista()
      CalcolaTotaliDocumento()

      If lstvDatiFatt.Items.Count = 0 Then
         cmdRimuoviFatt.Enabled = False
         cmdStampaFatt.Enabled = False
      End If

      buoniInLista = False
      sospesiInLista = False
   End Sub

   Private Sub cmdStampaFatt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStampaFatt.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Select Case LeggiFormatoFatt()
            Case formatoFattAziende.Grande
               percorsoRep = PERCORSO_REP_FF_AZIENDE

            Case formatoFattAziende.Piccola
               percorsoRep = PERCORSO_REP_FF
         End Select

         ' Salva il documento fiscale.
         SalvaDocumento()


         ' Esegue la stampa.
         StampaDocumento(percorsoRep, LeggiUltimoRecord(TAB_DOC))

         AzzeraFatturazione()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         If IsNothing(g_frmDocumenti) = False Then
            With g_frmDocumenti
               If .tbrSospesi.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiSospesi()
                  Exit Sub
               ElseIf .tbrMese.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiMese()
                  Exit Sub
               ElseIf .tbrAnno.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiAnno()
                  Exit Sub
               ElseIf .tbrPeriodo.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiPeriodo()
                  Exit Sub
               Else
                  ' Aggiorna la griglia dati.
                  .AggiornaDati()
                  Exit Sub
               End If
            End With
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
