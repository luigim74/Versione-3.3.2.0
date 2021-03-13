#Region " DATI FILE.VB "
' **********************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       13/03/2021
' Data ultima modifica: 13/03/2021
' Descrizione:          Anagrafica Noleggi.
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

Public Class frmNoleggi
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
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents TabControl2 As Elegant.Ui.TabControl
   Friend WithEvents tpDati As Elegant.Ui.TabPage
   Friend WithEvents eui_txtSconto As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoAssicurazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoMora As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoGiorno As Elegant.Ui.TextBox
   Friend WithEvents eui_dtpDataFine As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_dtpDataInizio As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_cmbCausale As Elegant.Ui.ComboBox
   Friend WithEvents eui_txtCodice As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbCliente As Elegant.Ui.ComboBox
   Friend WithEvents Label7 As Label
   Public WithEvents Label8 As Label
   Public WithEvents Label12 As Label
   Public WithEvents Label17 As Label
   Public WithEvents Label18 As Label
   Public WithEvents Label19 As Label
   Public WithEvents Label20 As Label
   Public WithEvents Label23 As Label
   Public WithEvents Label24 As Label
   Friend WithEvents tpArticoli As Elegant.Ui.TabPage
   Friend WithEvents tpAllegati As Elegant.Ui.TabPage
   Friend WithEvents tpNote As Elegant.Ui.TabPage
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbPeriodo As Elegant.Ui.ComboBox
   Friend WithEvents lstvElencoCamerieri As ListView
   Friend WithEvents ColumnHeader7 As ColumnHeader
   Friend WithEvents ColumnHeader8 As ColumnHeader
   Friend WithEvents ColumnHeader9 As ColumnHeader
   Friend WithEvents ColumnHeader10 As ColumnHeader
   Friend WithEvents ColumnHeader11 As ColumnHeader
   Friend WithEvents ColumnHeader12 As ColumnHeader
   Friend WithEvents cmdRimuovi As Button
   Friend WithEvents cmdModifica As Button
   Friend WithEvents cmdInserimento As Button
   Friend WithEvents lvwAllegati As ListView
   Friend WithEvents ColumnHeader1 As ColumnHeader
   Friend WithEvents ColumnHeader2 As ColumnHeader
   Friend WithEvents ColumnHeader3 As ColumnHeader
   Friend WithEvents ColumnHeader4 As ColumnHeader
   Friend WithEvents ColumnHeader5 As ColumnHeader
   Friend WithEvents ColumnHeader6 As ColumnHeader
   Friend WithEvents TextBox2 As Elegant.Ui.TextBox
   Friend WithEvents Label1 As Label
   Friend WithEvents Button3 As Elegant.Ui.Button
   Friend WithEvents Button2 As Elegant.Ui.Button
   Friend WithEvents Button1 As Elegant.Ui.Button
   Friend WithEvents eui_txtCodiceBarre As Elegant.Ui.TextBox
   Friend WithEvents Label2 As Label
   Friend WithEvents Button4 As Button
   Friend WithEvents ComboBox1 As Elegant.Ui.ComboBox
   Public WithEvents Label4 As Label
   Public WithEvents Label3 As Label
   Public WithEvents Label25 As Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoleggi))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.TabControl2 = New Elegant.Ui.TabControl()
      Me.tpDati = New Elegant.Ui.TabPage()
      Me.TextBox2 = New Elegant.Ui.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.eui_cmbPeriodo = New Elegant.Ui.ComboBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.eui_txtSconto = New Elegant.Ui.TextBox()
      Me.eui_txtCostoAssicurazione = New Elegant.Ui.TextBox()
      Me.eui_txtCostoMora = New Elegant.Ui.TextBox()
      Me.eui_txtCostoGiorno = New Elegant.Ui.TextBox()
      Me.eui_dtpDataFine = New Elegant.Ui.DateTimePicker()
      Me.eui_dtpDataInizio = New Elegant.Ui.DateTimePicker()
      Me.eui_cmbCausale = New Elegant.Ui.ComboBox()
      Me.eui_txtCodice = New Elegant.Ui.TextBox()
      Me.eui_cmbCliente = New Elegant.Ui.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.tpArticoli = New Elegant.Ui.TabPage()
      Me.lstvElencoCamerieri = New System.Windows.Forms.ListView()
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.tpAllegati = New Elegant.Ui.TabPage()
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
      Me.tpNote = New Elegant.Ui.TabPage()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.Button1 = New Elegant.Ui.Button()
      Me.Button2 = New Elegant.Ui.Button()
      Me.Button3 = New Elegant.Ui.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.eui_txtCodiceBarre = New Elegant.Ui.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Button4 = New System.Windows.Forms.Button()
      Me.ComboBox1 = New Elegant.Ui.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpDati.SuspendLayout()
      Me.tpArticoli.SuspendLayout()
      Me.tpAllegati.SuspendLayout()
      Me.tpNote.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(580, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(580, 28)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(3, 5)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(16, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
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
      'TabControl2
      '
      Me.TabControl2.Location = New System.Drawing.Point(2, 57)
      Me.TabControl2.Name = "TabControl2"
      Me.TabControl2.SelectedTabPage = Me.tpDati
      Me.TabControl2.Size = New System.Drawing.Size(577, 353)
      Me.TabControl2.TabIndex = 1
      Me.TabControl2.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.tpDati, Me.tpArticoli, Me.tpAllegati, Me.tpNote})
      Me.TabControl2.Text = "TabControl2"
      '
      'tpDati
      '
      Me.tpDati.ActiveControl = Nothing
      Me.tpDati.Controls.Add(Me.Button4)
      Me.tpDati.Controls.Add(Me.ComboBox1)
      Me.tpDati.Controls.Add(Me.Label4)
      Me.tpDati.Controls.Add(Me.Label3)
      Me.tpDati.Controls.Add(Me.eui_txtCodiceBarre)
      Me.tpDati.Controls.Add(Me.Label2)
      Me.tpDati.Controls.Add(Me.TextBox2)
      Me.tpDati.Controls.Add(Me.Label1)
      Me.tpDati.Controls.Add(Me.eui_cmbPeriodo)
      Me.tpDati.Controls.Add(Me.Label25)
      Me.tpDati.Controls.Add(Me.eui_txtSconto)
      Me.tpDati.Controls.Add(Me.eui_txtCostoAssicurazione)
      Me.tpDati.Controls.Add(Me.eui_txtCostoMora)
      Me.tpDati.Controls.Add(Me.eui_txtCostoGiorno)
      Me.tpDati.Controls.Add(Me.eui_dtpDataFine)
      Me.tpDati.Controls.Add(Me.eui_dtpDataInizio)
      Me.tpDati.Controls.Add(Me.eui_cmbCausale)
      Me.tpDati.Controls.Add(Me.eui_txtCodice)
      Me.tpDati.Controls.Add(Me.eui_cmbCliente)
      Me.tpDati.Controls.Add(Me.Label7)
      Me.tpDati.Controls.Add(Me.Label8)
      Me.tpDati.Controls.Add(Me.Label12)
      Me.tpDati.Controls.Add(Me.Label17)
      Me.tpDati.Controls.Add(Me.Label18)
      Me.tpDati.Controls.Add(Me.Label19)
      Me.tpDati.Controls.Add(Me.Label20)
      Me.tpDati.Controls.Add(Me.Label23)
      Me.tpDati.Controls.Add(Me.Label24)
      Me.tpDati.KeyTip = Nothing
      Me.tpDati.Name = "tpDati"
      Me.tpDati.Size = New System.Drawing.Size(575, 332)
      Me.tpDati.TabIndex = 0
      Me.tpDati.Text = "Dati principali"
      '
      'TextBox2
      '
      Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TextBox2.Id = "c2318864-8dc9-4fa5-8871-e1675b39c457"
      Me.TextBox2.Location = New System.Drawing.Point(156, 280)
      Me.TextBox2.Name = "TextBox2"
      Me.TextBox2.Size = New System.Drawing.Size(174, 21)
      Me.TextBox2.TabIndex = 55716
      Me.TextBox2.Text = "500,00"
      Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.TextBox2.TextEditorWidth = 168
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(21, 284)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(120, 13)
      Me.Label1.TabIndex = 55715
      Me.Label1.Text = "Totale importo noleggio:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'eui_cmbPeriodo
      '
      Me.eui_cmbPeriodo.FormattingEnabled = False
      Me.eui_cmbPeriodo.Id = "2f9cd914-1baf-40d1-aa0c-b709734c5e6f"
      Me.eui_cmbPeriodo.Location = New System.Drawing.Point(156, 98)
      Me.eui_cmbPeriodo.Name = "eui_cmbPeriodo"
      Me.eui_cmbPeriodo.Size = New System.Drawing.Size(174, 21)
      Me.eui_cmbPeriodo.TabIndex = 55714
      Me.eui_cmbPeriodo.TextEditorWidth = 155
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(21, 102)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(46, 13)
      Me.Label25.TabIndex = 55713
      Me.Label25.Text = "Periodo:"
      '
      'eui_txtSconto
      '
      Me.eui_txtSconto.Id = "5b063bf5-811f-496a-854d-663860336292"
      Me.eui_txtSconto.Location = New System.Drawing.Point(156, 205)
      Me.eui_txtSconto.Name = "eui_txtSconto"
      Me.eui_txtSconto.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtSconto.TabIndex = 55712
      Me.eui_txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtSconto.TextEditorWidth = 168
      '
      'eui_txtCostoAssicurazione
      '
      Me.eui_txtCostoAssicurazione.Id = "3b9be2ff-bc66-4911-963b-40f5f2a889bc"
      Me.eui_txtCostoAssicurazione.Location = New System.Drawing.Point(156, 255)
      Me.eui_txtCostoAssicurazione.Name = "eui_txtCostoAssicurazione"
      Me.eui_txtCostoAssicurazione.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoAssicurazione.TabIndex = 55711
      Me.eui_txtCostoAssicurazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoAssicurazione.TextEditorWidth = 168
      '
      'eui_txtCostoMora
      '
      Me.eui_txtCostoMora.Id = "9bc8022a-1a8b-4644-8c93-827bc55b820c"
      Me.eui_txtCostoMora.Location = New System.Drawing.Point(156, 230)
      Me.eui_txtCostoMora.Name = "eui_txtCostoMora"
      Me.eui_txtCostoMora.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoMora.TabIndex = 55710
      Me.eui_txtCostoMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoMora.TextEditorWidth = 168
      '
      'eui_txtCostoGiorno
      '
      Me.eui_txtCostoGiorno.Id = "69a16ebe-88f3-46cd-ba2d-2b6b1abdefb5"
      Me.eui_txtCostoGiorno.Location = New System.Drawing.Point(156, 180)
      Me.eui_txtCostoGiorno.Name = "eui_txtCostoGiorno"
      Me.eui_txtCostoGiorno.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoGiorno.TabIndex = 55709
      Me.eui_txtCostoGiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoGiorno.TextEditorWidth = 168
      '
      'eui_dtpDataFine
      '
      Me.eui_dtpDataFine.Id = "8be6323f-c3ff-4c10-9f7a-7b4abec7f5f0"
      Me.eui_dtpDataFine.Location = New System.Drawing.Point(156, 149)
      Me.eui_dtpDataFine.Name = "eui_dtpDataFine"
      Me.eui_dtpDataFine.Size = New System.Drawing.Size(174, 21)
      Me.eui_dtpDataFine.TabIndex = 55708
      Me.eui_dtpDataFine.TextEditorWidth = 155
      '
      'eui_dtpDataInizio
      '
      Me.eui_dtpDataInizio.Id = "9b71e287-44f5-43fa-a84e-0311ed08ad52"
      Me.eui_dtpDataInizio.Location = New System.Drawing.Point(156, 124)
      Me.eui_dtpDataInizio.Name = "eui_dtpDataInizio"
      Me.eui_dtpDataInizio.Size = New System.Drawing.Size(174, 21)
      Me.eui_dtpDataInizio.TabIndex = 55707
      Me.eui_dtpDataInizio.TextEditorWidth = 155
      '
      'eui_cmbCausale
      '
      Me.eui_cmbCausale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmbCausale.FormattingEnabled = False
      Me.eui_cmbCausale.Id = "9a095b6c-0aaf-4879-b604-cd6a91beab70"
      Me.eui_cmbCausale.Location = New System.Drawing.Point(156, 68)
      Me.eui_cmbCausale.Name = "eui_cmbCausale"
      Me.eui_cmbCausale.Size = New System.Drawing.Size(360, 21)
      Me.eui_cmbCausale.TabIndex = 55706
      Me.eui_cmbCausale.TextEditorWidth = 341
      '
      'eui_txtCodice
      '
      Me.eui_txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodice.Id = "b3b14f14-c9d0-43cb-ba84-405bc8faaf49"
      Me.eui_txtCodice.Location = New System.Drawing.Point(156, 18)
      Me.eui_txtCodice.Name = "eui_txtCodice"
      Me.eui_txtCodice.Size = New System.Drawing.Size(131, 21)
      Me.eui_txtCodice.TabIndex = 55705
      Me.eui_txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCodice.TextEditorWidth = 125
      '
      'eui_cmbCliente
      '
      Me.eui_cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmbCliente.FormattingEnabled = False
      Me.eui_cmbCliente.Id = "afadeb17-01f4-4309-938a-da3222121b47"
      Me.eui_cmbCliente.Location = New System.Drawing.Point(156, 43)
      Me.eui_cmbCliente.Name = "eui_cmbCliente"
      Me.eui_cmbCliente.Size = New System.Drawing.Size(360, 21)
      Me.eui_cmbCliente.TabIndex = 55704
      Me.eui_cmbCliente.TextEditorWidth = 341
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(21, 22)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(40, 13)
      Me.Label7.TabIndex = 55703
      Me.Label7.Text = "Codice"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(21, 259)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(104, 13)
      Me.Label8.TabIndex = 55702
      Me.Label8.Text = "Costo assicurazione:"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(21, 184)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(88, 13)
      Me.Label12.TabIndex = 55701
      Me.Label12.Text = "Costo giornaliero:"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(21, 234)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(63, 13)
      Me.Label17.TabIndex = 55700
      Me.Label17.Text = "Costo mora:"
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(21, 209)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(44, 13)
      Me.Label18.TabIndex = 55699
      Me.Label18.Text = "Sconto:"
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(21, 153)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(53, 13)
      Me.Label19.TabIndex = 55698
      Me.Label19.Text = "Data fine:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(21, 128)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(59, 13)
      Me.Label20.TabIndex = 55697
      Me.Label20.Text = "Data inizio:"
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(21, 72)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(91, 13)
      Me.Label23.TabIndex = 55696
      Me.Label23.Text = "Causale noleggio:"
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(21, 47)
      Me.Label24.Name = "Label24"
      Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label24.Size = New System.Drawing.Size(42, 13)
      Me.Label24.TabIndex = 55695
      Me.Label24.Text = "Cliente:"
      '
      'tpArticoli
      '
      Me.tpArticoli.ActiveControl = Nothing
      Me.tpArticoli.Controls.Add(Me.Button3)
      Me.tpArticoli.Controls.Add(Me.Button2)
      Me.tpArticoli.Controls.Add(Me.Button1)
      Me.tpArticoli.Controls.Add(Me.lstvElencoCamerieri)
      Me.tpArticoli.KeyTip = Nothing
      Me.tpArticoli.Name = "tpArticoli"
      Me.tpArticoli.Size = New System.Drawing.Size(575, 332)
      Me.tpArticoli.TabIndex = 1
      Me.tpArticoli.Text = "Articoli noleggiati"
      '
      'lstvElencoCamerieri
      '
      Me.lstvElencoCamerieri.AllowColumnReorder = True
      Me.lstvElencoCamerieri.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
      Me.lstvElencoCamerieri.FullRowSelect = True
      Me.lstvElencoCamerieri.HideSelection = False
      Me.lstvElencoCamerieri.Location = New System.Drawing.Point(0, 0)
      Me.lstvElencoCamerieri.MultiSelect = False
      Me.lstvElencoCamerieri.Name = "lstvElencoCamerieri"
      Me.lstvElencoCamerieri.Size = New System.Drawing.Size(574, 287)
      Me.lstvElencoCamerieri.StateImageList = Me.ImageList1
      Me.lstvElencoCamerieri.TabIndex = 2
      Me.lstvElencoCamerieri.UseCompatibleStateImageBehavior = False
      Me.lstvElencoCamerieri.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "Nome"
      Me.ColumnHeader7.Width = 150
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "Costo / Ora"
      Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader8.Width = 80
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Costo / Giorno"
      Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader9.Width = 90
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "Cellulare"
      Me.ColumnHeader10.Width = 100
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "E-mail"
      Me.ColumnHeader11.Width = 200
      '
      'ColumnHeader12
      '
      Me.ColumnHeader12.Text = "Codice"
      Me.ColumnHeader12.Width = 0
      '
      'tpAllegati
      '
      Me.tpAllegati.ActiveControl = Nothing
      Me.tpAllegati.Controls.Add(Me.cmdRimuovi)
      Me.tpAllegati.Controls.Add(Me.cmdModifica)
      Me.tpAllegati.Controls.Add(Me.cmdInserimento)
      Me.tpAllegati.Controls.Add(Me.lvwAllegati)
      Me.tpAllegati.KeyTip = Nothing
      Me.tpAllegati.Name = "tpAllegati"
      Me.tpAllegati.Size = New System.Drawing.Size(575, 332)
      Me.tpAllegati.TabIndex = 2
      Me.tpAllegati.Text = "Documenti allegati"
      '
      'cmdRimuovi
      '
      Me.cmdRimuovi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRimuovi.Location = New System.Drawing.Point(472, 297)
      Me.cmdRimuovi.Name = "cmdRimuovi"
      Me.cmdRimuovi.Size = New System.Drawing.Size(88, 24)
      Me.cmdRimuovi.TabIndex = 6
      Me.cmdRimuovi.Text = "&Rimuovi"
      '
      'cmdModifica
      '
      Me.cmdModifica.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdModifica.Location = New System.Drawing.Point(376, 297)
      Me.cmdModifica.Name = "cmdModifica"
      Me.cmdModifica.Size = New System.Drawing.Size(88, 24)
      Me.cmdModifica.TabIndex = 5
      Me.cmdModifica.Text = "&Modifica"
      '
      'cmdInserimento
      '
      Me.cmdInserimento.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdInserimento.Location = New System.Drawing.Point(288, 297)
      Me.cmdInserimento.Name = "cmdInserimento"
      Me.cmdInserimento.Size = New System.Drawing.Size(80, 24)
      Me.cmdInserimento.TabIndex = 4
      Me.cmdInserimento.Text = "&Inserimento"
      '
      'lvwAllegati
      '
      Me.lvwAllegati.AllowColumnReorder = True
      Me.lvwAllegati.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
      Me.lvwAllegati.HideSelection = False
      Me.lvwAllegati.Location = New System.Drawing.Point(0, 0)
      Me.lvwAllegati.MultiSelect = False
      Me.lvwAllegati.Name = "lvwAllegati"
      Me.lvwAllegati.Size = New System.Drawing.Size(574, 287)
      Me.lvwAllegati.StateImageList = Me.ImageList1
      Me.lvwAllegati.TabIndex = 1
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
      'tpNote
      '
      Me.tpNote.ActiveControl = Nothing
      Me.tpNote.Controls.Add(Me.eui_txtNote)
      Me.tpNote.KeyTip = Nothing
      Me.tpNote.Name = "tpNote"
      Me.tpNote.Size = New System.Drawing.Size(575, 332)
      Me.tpNote.TabIndex = 3
      Me.tpNote.Text = "Note"
      '
      'eui_txtNote
      '
      Me.eui_txtNote.Id = "e5c9cad8-2145-43be-9f3c-f29d123bd56b"
      Me.eui_txtNote.Location = New System.Drawing.Point(1, 0)
      Me.eui_txtNote.Multiline = True
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.Size = New System.Drawing.Size(573, 331)
      Me.eui_txtNote.TabIndex = 2
      Me.eui_txtNote.TextEditorWidth = 567
      '
      'Button1
      '
      Me.Button1.Id = "53c7e9e3-00ac-4b69-b43c-5f17efd9d3ba"
      Me.Button1.Location = New System.Drawing.Point(323, 293)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 30)
      Me.Button1.TabIndex = 3
      Me.Button1.Text = "Button1"
      '
      'Button2
      '
      Me.Button2.Id = "194ff039-f822-43ad-af26-63ee4a6d8ad1"
      Me.Button2.Location = New System.Drawing.Point(404, 293)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(75, 30)
      Me.Button2.TabIndex = 4
      Me.Button2.Text = "Button2"
      '
      'Button3
      '
      Me.Button3.Id = "3975157f-8eb5-4fd9-bc44-92d74dab2af2"
      Me.Button3.Location = New System.Drawing.Point(485, 293)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(75, 30)
      Me.Button3.TabIndex = 5
      Me.Button3.Text = "Button3"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(300, 22)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(79, 13)
      Me.Label2.TabIndex = 55717
      Me.Label2.Text = "Codice a barre:"
      '
      'eui_txtCodiceBarre
      '
      Me.eui_txtCodiceBarre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodiceBarre.Id = "81ed89d4-46fb-45f1-a44a-3d1dc55f8942"
      Me.eui_txtCodiceBarre.Location = New System.Drawing.Point(385, 18)
      Me.eui_txtCodiceBarre.Name = "eui_txtCodiceBarre"
      Me.eui_txtCodiceBarre.Size = New System.Drawing.Size(131, 21)
      Me.eui_txtCodiceBarre.TabIndex = 55718
      Me.eui_txtCodiceBarre.TextEditorWidth = 125
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(339, 283)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(40, 13)
      Me.Label3.TabIndex = 55719
      Me.Label3.Text = "Colore:"
      '
      'Button4
      '
      Me.Button4.BackColor = System.Drawing.Color.LightSalmon
      Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
      Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Button4.Location = New System.Drawing.Point(385, 279)
      Me.Button4.Name = "Button4"
      Me.Button4.Size = New System.Drawing.Size(131, 21)
      Me.Button4.TabIndex = 2
      Me.Button4.UseVisualStyleBackColor = False
      '
      'ComboBox1
      '
      Me.ComboBox1.FormattingEnabled = False
      Me.ComboBox1.Id = "eb5cdda5-eda0-4dcb-8a13-d77eb500267d"
      Me.ComboBox1.Location = New System.Drawing.Point(385, 255)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(131, 21)
      Me.ComboBox1.TabIndex = 55721
      Me.ComboBox1.TextEditorWidth = 112
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(339, 259)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(35, 13)
      Me.Label4.TabIndex = 55720
      Me.Label4.Text = "Stato:"
      '
      'frmNoleggi
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(580, 411)
      Me.Controls.Add(Me.TabControl2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmNoleggi"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Noleggi"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpDati.ResumeLayout(False)
      Me.tpDati.PerformLayout()
      Me.tpArticoli.ResumeLayout(False)
      Me.tpAllegati.ResumeLayout(False)
      Me.tpNote.ResumeLayout(False)
      Me.tpNote.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   ' TODO_A: Modificare.
   Private CAgenzieCamerieri As New Anagrafiche.AziendaCliente(ConnString)
   Private CNoleggi As New Noleggi
   Private IAllegati As New Allegati
   Private CConvalida As New ConvalidaKeyPress
   Private CFormatta As New ClsFormatta

   ' TODO_A: Modificare.
   Const TAB_CAP As String = "CAP"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_ELENCO_CAMERIERI As String = "Camerieri"
   Const TAB_ALLEGATI As String = "Agenzie_Allegati"
   Const NOME_TABELLA As String = "Noleggi"

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

   ' TODO_A: Modificare.
   Private Function SalvaDati() As Boolean
      Try
         ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
         'AggiornaTabella(cmbNazione, TAB_NAZIONI)

         ' Assegna i dati dei campi della classe alle caselle di testo.
         With CAgenzieCamerieri

            '.RagSociale = txtRagSoc.Text
            '.Indirizzo1 = txtIndirizzo1.Text
            '.Cap = txtCap.Text
            '.Città = cmbCittà.Text
            '.Provincia = txtProv.Text
            '.Regione = txtRegione.Text
            '.Nazione = cmbNazione.Text
            '.Contatto = txtContatto.Text
            '.PIva = txtPIva.Text
            '.TelCasa = txtTelCasa.Text
            '.TelUfficio = txtTelUfficio.Text
            '.Cell = txtCell.Text
            '.Fax = txtFax.Text
            '.Email = txtEmail.Text
            '.PEC = txtPec.Text
            '.Internet = txtInternet.Text
            '.Note = txtNote.Text

            If .Immagine = Nothing Then
               .Immagine = String.Empty
            End If

            ' Campi non utilizzati.
            .Attività = String.Empty
            .Sconto = VALORE_ZERO
            .Iva = VALORE_ZERO
            .NoteDoc = String.Empty
            .CodAzienda = String.Empty
            .CodFisc = String.Empty
            .RagSocialeDest = String.Empty
            .IndirizzoDest = String.Empty
            .CapDest = String.Empty
            .CittàDest = String.Empty
            .ProvDest = String.Empty
            .NazioneDest = String.Empty
            .TelDest = String.Empty
            .FaxDest = String.Empty
            .TipoPagamento = String.Empty
            .Banca = String.Empty
            .Cin = String.Empty
            .Abi = String.Empty
            .Cab = String.Empty
            .Cc = String.Empty
            .Iban = String.Empty
            .Listino = String.Empty
            .IvaInFatt = String.Empty
            .CodIva = String.Empty
            .Aliquota = String.Empty
            .DescrizioneIva = String.Empty
            .Puntualità = String.Empty
            .Privacy = String.Empty
            .Titolo = String.Empty
         End With


         ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
         ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
         If Me.Tag <> "" Then
            Return CAgenzieCamerieri.ModificaDati(NOME_TABELLA, Me.Tag)
         Else
            Return CAgenzieCamerieri.InserisciDati(NOME_TABELLA)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      Try
         OpenFileDialog1.Filter = "Tutti i file |*.*"

         OpenFileDialog1.FilterIndex = 1

         IAllegati.IdCliente = CInt(CAgenzieCamerieri.Codice)

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
         Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf &
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
         If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, CAgenzieCamerieri.Codice) = True Then
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

   ' TODO_A: Modificare.
   Private Function CaricaElencoCamerieri(ByVal lst As ListView, ByVal tabella As String, ByVal nomeAgenzia As String) As Boolean
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim Caricati As Boolean = False

         Try
            cn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Agenzia = '" & nomeAgenzia & "' ORDER BY Nome ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Dim i As Integer

            lst.Items.Clear()

            Do While dr.Read
               lst.Items.Add(dr.Item("Nome"))

               ' Costo Ora.
               If IsDBNull(dr.Item("CostoOra")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("CostoOra"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If
               ' Costo Giorno.
               If IsDBNull(dr.Item("CostoGiorno")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("CostoGiorno"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If
               ' Cellulare.
               If IsDBNull(dr.Item("Cell")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Cell").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If
               ' E-mail.
               If IsDBNull(dr.Item("Email")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Email").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If
               ' Id.
               If IsDBNull(dr.Item("Id")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Id").ToString)
               Else
                  lst.Items(i).SubItems.Add(0.ToString)
               End If

               ' Imposta l'immagine.
               lst.Items(i).StateImageIndex = 0

               ' Contatore.
               i += 1

               Caricati = True
            Loop

            Return Caricati

         Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

            Return False

         Finally
            cn.Close()

         End Try

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   ' TODO_A: Modificare.
   Private Sub Noleggi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(NOLEGGI_LARGHEZZA, NOLEGGI_ALTEZZA)

         '' Carica le liste.
         'CaricaLista(cmbCittà, TAB_CAP)
         'CaricaLista(cmbNazione, TAB_NAZIONI)

         If Me.Tag <> "" Then
            With CNoleggi

               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               eui_txtCodice.Text = .Codice
               eui_txtCodiceBarre.Text = .CodiceBarre
               eui_cmbCliente.Text = .Cliente
               eui_cmbCausale.Text = .Causale
               eui_dtpDataInizio.Text = .DataInizio
               eui_dtpDataFine.Text = .DataFine
               eui_txtCostoGiorno.Text = .CostoGiorno
               eui_txtSconto.Text = .Sconto
               eui_txtCostoMora.Text = .CostoMora
               eui_txtCostoAssicurazione.Text = .CostoAssicurazione
               eui_txtNote.Text = .Note

               ' Per i dati già esistenti nel database (con un id) rende la scheda Allegati disponibile.
               'TabControl1.TabPages(2).Enabled = True

               ' Carica la lista delle degli allegati.
               ConvalidaAllegati()

               ' Carica la lista dei Camerieri.
               'CaricaElencoCamerieri(lstvElencoCamerieri, TAB_ELENCO_CAMERIERI, CAgenzieCamerieri.RagSociale)

            End With
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.

            ' Per i nuovi fornitori che non sono nel database (con un id)
            ' disattiva la scheda Allegati.
            'TabControl1.TabPages(2).Enabled = False
         End If

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(eui_txtCodice.Text, eui_cmbCliente.Text, String.Empty)

         ' Imposta lo stato attivo.
         eui_cmbCliente.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   ' TODO_A: Modificare.
   Private Sub Noleggi_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_FORNITORI)
      End If
   End Sub

   ' TODO_A: Modificare.
   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmAgenzieCamerieri) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmAgenzieCamerieri.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & CAgenzieCamerieri.RagSociale & ")"

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

   ' TODO_A: Modificare.
   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         'Select Case TabControl1.SelectedIndex()
         '   Case 0
         '      ' Imposta lo stato attivo.
         '      Me.txtRagSoc.Focus()

         '   Case 1
         '      ' Imposta lo stato attivo.
         '      Me.txtTelUfficio.Focus()

         '   Case 2
         '      ' Imposta lo stato attivo.
         '      Me.lvwAllegati.Focus()
         '      ' Imposta il pulsante di default.
         '      cmdInserimento.NotifyDefault(True)

         '   Case 3
         '      ' Imposta lo stato attivo.
         '      Me.txtNote.Focus()

         'End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   ' TODO_A: Modificare.
   Private Sub cmdInserimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

   ' TODO_A: Modificare.
   Private Sub cmdModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

   ' TODO_A: Modificare.
   Private Sub cmdRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         cmdInserimento.NotifyDefault(False)

         RimuoviAllegati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
         ConvalidaAllegati()

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Private Sub lvwAllegati_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
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

   ' TODO_A: Modificare.
   Private Sub txtCap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   ' TODO_A: Modificare.
   Private Sub txtPIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

End Class
