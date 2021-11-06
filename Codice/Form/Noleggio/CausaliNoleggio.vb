#Region " DATI FILE.VB "
' **********************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/09/2021
' Data ultima modifica: 23/10/2021
' Descrizione:          Anagrafica Causale noleggio.
' Note:
'
' Elenco Attivita:
'
' 
'
' ***********************************************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class frmCausaliNoleggio
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

   'NOTA: la procedura che segue Ë richiesta da Progettazione Windows Form.
   'PuÚ essere modificata in Progettazione Windows Form.  
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
   Friend WithEvents eui_txtCostoAssicurazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoMora As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoGiorno As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCodice As Elegant.Ui.TextBox
   Friend WithEvents Label7 As Label
   Public WithEvents Label8 As Label
   Public WithEvents lblCostoOreGiorni As Label
   Public WithEvents lblCostoMoraOreGiorni As Label
   Public WithEvents Label23 As Label
   Friend WithEvents tpArticoli As Elegant.Ui.TabPage
   Friend WithEvents tpNote As Elegant.Ui.TabPage
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Friend WithEvents lstvElencoArticoli As ListView
   Friend WithEvents clnCodice As ColumnHeader
   Friend WithEvents clnDescrizione As ColumnHeader
   Friend WithEvents clnUM As ColumnHeader
   Friend WithEvents clnQuantit‡ As ColumnHeader
   Friend WithEvents clnCostoUnitario As ColumnHeader
   Friend WithEvents clnId As ColumnHeader
   Friend WithEvents eui_cmdElimina As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisci As Elegant.Ui.Button
   Friend WithEvents clnCostoTotale As ColumnHeader
   Friend WithEvents clnIva As ColumnHeader
   Friend WithEvents clnCategoria As ColumnHeader
   Friend WithEvents eui_txtDescrizione As Elegant.Ui.TextBox
   Friend WithEvents clnRifNoleggio As ColumnHeader
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCausaliNoleggio))
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
      Me.eui_txtDescrizione = New Elegant.Ui.TextBox()
      Me.eui_txtCostoAssicurazione = New Elegant.Ui.TextBox()
      Me.eui_txtCostoMora = New Elegant.Ui.TextBox()
      Me.eui_txtCostoGiorno = New Elegant.Ui.TextBox()
      Me.eui_txtCodice = New Elegant.Ui.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.lblCostoOreGiorni = New System.Windows.Forms.Label()
      Me.lblCostoMoraOreGiorni = New System.Windows.Forms.Label()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.tpArticoli = New Elegant.Ui.TabPage()
      Me.eui_cmdElimina = New Elegant.Ui.Button()
      Me.eui_cmdInserisci = New Elegant.Ui.Button()
      Me.lstvElencoArticoli = New System.Windows.Forms.ListView()
      Me.clnCodice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnDescrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnQuantit‡ = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCostoUnitario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCostoTotale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnRifNoleggio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.tpNote = New Elegant.Ui.TabPage()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.Panel1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpDati.SuspendLayout()
      Me.tpArticoli.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(581, 26)
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
      Me.ImageList1.Images.SetKeyName(11, "id_insert_shapes_large.png")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(581, 28)
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
      Me.TabControl2.Size = New System.Drawing.Size(577, 354)
      Me.TabControl2.TabIndex = 1
      Me.TabControl2.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.tpDati, Me.tpArticoli, Me.tpNote})
      Me.TabControl2.Text = "TabControl2"
      '
      'tpDati
      '
      Me.tpDati.ActiveControl = Nothing
      Me.tpDati.Controls.Add(Me.eui_txtDescrizione)
      Me.tpDati.Controls.Add(Me.eui_txtCostoAssicurazione)
      Me.tpDati.Controls.Add(Me.eui_txtCostoMora)
      Me.tpDati.Controls.Add(Me.eui_txtCostoGiorno)
      Me.tpDati.Controls.Add(Me.eui_txtCodice)
      Me.tpDati.Controls.Add(Me.Label7)
      Me.tpDati.Controls.Add(Me.Label8)
      Me.tpDati.Controls.Add(Me.lblCostoOreGiorni)
      Me.tpDati.Controls.Add(Me.lblCostoMoraOreGiorni)
      Me.tpDati.Controls.Add(Me.Label23)
      Me.tpDati.KeyTip = Nothing
      Me.tpDati.Name = "tpDati"
      Me.tpDati.Size = New System.Drawing.Size(575, 333)
      Me.tpDati.TabIndex = 0
      Me.tpDati.Text = "Dati principali"
      '
      'eui_txtDescrizione
      '
      Me.eui_txtDescrizione.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtDescrizione.Id = "899acbc0-d23d-4c7c-a475-f91c02f0d5df"
      Me.eui_txtDescrizione.Location = New System.Drawing.Point(156, 48)
      Me.eui_txtDescrizione.Name = "eui_txtDescrizione"
      Me.eui_txtDescrizione.Size = New System.Drawing.Size(382, 21)
      Me.eui_txtDescrizione.TabIndex = 1
      Me.eui_txtDescrizione.TextEditorWidth = 376
      '
      'eui_txtCostoAssicurazione
      '
      Me.eui_txtCostoAssicurazione.Id = "3b9be2ff-bc66-4911-963b-40f5f2a889bc"
      Me.eui_txtCostoAssicurazione.Location = New System.Drawing.Point(156, 124)
      Me.eui_txtCostoAssicurazione.Name = "eui_txtCostoAssicurazione"
      Me.eui_txtCostoAssicurazione.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoAssicurazione.TabIndex = 3
      Me.eui_txtCostoAssicurazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoAssicurazione.TextEditorWidth = 168
      '
      'eui_txtCostoMora
      '
      Me.eui_txtCostoMora.Id = "9bc8022a-1a8b-4644-8c93-827bc55b820c"
      Me.eui_txtCostoMora.Location = New System.Drawing.Point(156, 156)
      Me.eui_txtCostoMora.Name = "eui_txtCostoMora"
      Me.eui_txtCostoMora.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoMora.TabIndex = 4
      Me.eui_txtCostoMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoMora.TextEditorWidth = 168
      '
      'eui_txtCostoGiorno
      '
      Me.eui_txtCostoGiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCostoGiorno.Id = "69a16ebe-88f3-46cd-ba2d-2b6b1abdefb5"
      Me.eui_txtCostoGiorno.Location = New System.Drawing.Point(156, 93)
      Me.eui_txtCostoGiorno.Name = "eui_txtCostoGiorno"
      Me.eui_txtCostoGiorno.ReadOnly = True
      Me.eui_txtCostoGiorno.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoGiorno.TabIndex = 2
      Me.eui_txtCostoGiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoGiorno.TextEditorWidth = 168
      '
      'eui_txtCodice
      '
      Me.eui_txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodice.Id = "b3b14f14-c9d0-43cb-ba84-405bc8faaf49"
      Me.eui_txtCodice.Location = New System.Drawing.Point(156, 18)
      Me.eui_txtCodice.Name = "eui_txtCodice"
      Me.eui_txtCodice.ReadOnly = True
      Me.eui_txtCodice.Size = New System.Drawing.Size(131, 21)
      Me.eui_txtCodice.TabIndex = 0
      Me.eui_txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCodice.TextEditorWidth = 125
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
      Me.Label8.Location = New System.Drawing.Point(21, 128)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(104, 13)
      Me.Label8.TabIndex = 55702
      Me.Label8.Text = "Costo assicurazione:"
      '
      'lblCostoOreGiorni
      '
      Me.lblCostoOreGiorni.AutoSize = True
      Me.lblCostoOreGiorni.BackColor = System.Drawing.Color.Transparent
      Me.lblCostoOreGiorni.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCostoOreGiorni.ForeColor = System.Drawing.Color.Black
      Me.lblCostoOreGiorni.Location = New System.Drawing.Point(21, 97)
      Me.lblCostoOreGiorni.Name = "lblCostoOreGiorni"
      Me.lblCostoOreGiorni.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblCostoOreGiorni.Size = New System.Drawing.Size(88, 13)
      Me.lblCostoOreGiorni.TabIndex = 55701
      Me.lblCostoOreGiorni.Text = "Costo giornaliero:"
      '
      'lblCostoMoraOreGiorni
      '
      Me.lblCostoMoraOreGiorni.AutoSize = True
      Me.lblCostoMoraOreGiorni.BackColor = System.Drawing.Color.Transparent
      Me.lblCostoMoraOreGiorni.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCostoMoraOreGiorni.ForeColor = System.Drawing.Color.Black
      Me.lblCostoMoraOreGiorni.Location = New System.Drawing.Point(21, 160)
      Me.lblCostoMoraOreGiorni.Name = "lblCostoMoraOreGiorni"
      Me.lblCostoMoraOreGiorni.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblCostoMoraOreGiorni.Size = New System.Drawing.Size(114, 13)
      Me.lblCostoMoraOreGiorni.TabIndex = 55700
      Me.lblCostoMoraOreGiorni.Text = "Costo mora giornaliera:"
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(21, 52)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(65, 13)
      Me.Label23.TabIndex = 55696
      Me.Label23.Text = "Descrizione:"
      '
      'tpArticoli
      '
      Me.tpArticoli.ActiveControl = Nothing
      Me.tpArticoli.Controls.Add(Me.eui_cmdElimina)
      Me.tpArticoli.Controls.Add(Me.eui_cmdInserisci)
      Me.tpArticoli.Controls.Add(Me.lstvElencoArticoli)
      Me.tpArticoli.KeyTip = Nothing
      Me.tpArticoli.Name = "tpArticoli"
      Me.tpArticoli.Size = New System.Drawing.Size(575, 333)
      Me.tpArticoli.TabIndex = 1
      Me.tpArticoli.Text = "Articoli noleggiati"
      '
      'eui_cmdElimina
      '
      Me.eui_cmdElimina.Id = "194ff039-f822-43ad-af26-63ee4a6d8ad1"
      Me.eui_cmdElimina.Location = New System.Drawing.Point(491, 295)
      Me.eui_cmdElimina.Name = "eui_cmdElimina"
      Me.eui_cmdElimina.Size = New System.Drawing.Size(75, 30)
      Me.eui_cmdElimina.TabIndex = 2
      Me.eui_cmdElimina.Text = "&Elimina"
      '
      'eui_cmdInserisci
      '
      Me.eui_cmdInserisci.Id = "53c7e9e3-00ac-4b69-b43c-5f17efd9d3ba"
      Me.eui_cmdInserisci.Location = New System.Drawing.Point(410, 295)
      Me.eui_cmdInserisci.Name = "eui_cmdInserisci"
      Me.eui_cmdInserisci.Size = New System.Drawing.Size(75, 30)
      Me.eui_cmdInserisci.TabIndex = 1
      Me.eui_cmdInserisci.Text = "&Inserisci"
      '
      'lstvElencoArticoli
      '
      Me.lstvElencoArticoli.AllowColumnReorder = True
      Me.lstvElencoArticoli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnCodice, Me.clnDescrizione, Me.clnUM, Me.clnQuantit‡, Me.clnCostoUnitario, Me.clnCostoTotale, Me.clnIva, Me.clnCategoria, Me.clnId, Me.clnRifNoleggio})
      Me.lstvElencoArticoli.FullRowSelect = True
      Me.lstvElencoArticoli.HideSelection = False
      Me.lstvElencoArticoli.Location = New System.Drawing.Point(0, 0)
      Me.lstvElencoArticoli.MultiSelect = False
      Me.lstvElencoArticoli.Name = "lstvElencoArticoli"
      Me.lstvElencoArticoli.Size = New System.Drawing.Size(574, 287)
      Me.lstvElencoArticoli.StateImageList = Me.ImageList1
      Me.lstvElencoArticoli.TabIndex = 0
      Me.lstvElencoArticoli.UseCompatibleStateImageBehavior = False
      Me.lstvElencoArticoli.View = System.Windows.Forms.View.Details
      '
      'clnCodice
      '
      Me.clnCodice.Text = "Codice"
      Me.clnCodice.Width = 100
      '
      'clnDescrizione
      '
      Me.clnDescrizione.Text = "Descrizione"
      Me.clnDescrizione.Width = 150
      '
      'clnUM
      '
      Me.clnUM.Text = "U.M."
      Me.clnUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'clnQuantit‡
      '
      Me.clnQuantit‡.Text = "Quantit‡"
      Me.clnQuantit‡.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'clnCostoUnitario
      '
      Me.clnCostoUnitario.Text = "Costo unitario"
      Me.clnCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnCostoUnitario.Width = 90
      '
      'clnCostoTotale
      '
      Me.clnCostoTotale.Text = "Costo totale"
      Me.clnCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnCostoTotale.Width = 90
      '
      'clnIva
      '
      Me.clnIva.Text = "Aliquota Iva"
      Me.clnIva.Width = 0
      '
      'clnCategoria
      '
      Me.clnCategoria.Text = "Categoria"
      Me.clnCategoria.Width = 0
      '
      'clnId
      '
      Me.clnId.Text = "Id"
      Me.clnId.Width = 0
      '
      'clnRifNoleggio
      '
      Me.clnRifNoleggio.Text = "RifNoleggio"
      Me.clnRifNoleggio.Width = 0
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
      Me.eui_txtNote.TabIndex = 0
      Me.eui_txtNote.TextEditorWidth = 567
      '
      'frmCausaliNoleggio
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(581, 412)
      Me.Controls.Add(Me.TabControl2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmCausaliNoleggio"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Causale noleggio"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpDati.ResumeLayout(False)
      Me.tpDati.PerformLayout()
      Me.tpArticoli.ResumeLayout(False)
      Me.tpNote.ResumeLayout(False)
      Me.tpNote.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private CCausaleNoleggio As New CausaliNoleggio
   Private CDettagliCausaliNoleggio As New DettagliCausaliNoleggio

   Private CConvalida As New ConvalidaKeyPress
   Private CFormatta As New ClsFormatta

   Public Const TAB_CAUSALI_NOLEGGIO As String = "CausaliNoleggio"
   Const TAB_DETTAGLI_CAUSALI_NOLEGGIO As String = "DettagliCausaliNoleggio"

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
         ' Assegna i dati dei campi della classe alle caselle di testo.
         With CCausaleNoleggio

            .Descrizione = eui_txtDescrizione.Text

            If IsNumeric(eui_txtCostoGiorno.Text) = True Then
               .CostoGiorno = Convert.ToDouble(eui_txtCostoGiorno.Text)
            Else
               .CostoGiorno = 0.0
            End If

            If IsNumeric(eui_txtCostoAssicurazione.Text) = True Then
               .CostoAssicurazione = Convert.ToDouble(eui_txtCostoAssicurazione.Text)
            Else
               .CostoAssicurazione = 0.0
            End If

            If IsNumeric(eui_txtCostoMora.Text) = True Then
               .CostoMora = Convert.ToDouble(eui_txtCostoMora.Text)
            Else
               .CostoMora = 0.0
            End If

            .Totale = .CostoGiorno
            .Note = eui_txtNote.Text

         End With

         ' Se la propriet‡ 'Tag' contiene un valore viene richiamata la procedura
         ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
         If Me.Tag <> String.Empty Then
            Return CCausaleNoleggio.ModificaDati(TAB_CAUSALI_NOLEGGIO, Me.Tag)
         Else
            Return CCausaleNoleggio.InserisciDati(TAB_CAUSALI_NOLEGGIO)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function SalvaArticoli(ByVal id As String) As Boolean
      ' Salva i dati degli Articoli.
      Try
         Dim rifCausale As Integer

         If id <> String.Empty Then
            rifCausale = id
         Else
            rifCausale = LeggiUltimoRecord(TAB_CAUSALI_NOLEGGIO)
         End If

         With CDettagliCausaliNoleggio
            .EliminaDati(TAB_DETTAGLI_CAUSALI_NOLEGGIO, rifCausale)

            Dim i As Integer
            For i = 0 To lstvElencoArticoli.Items.Count - 1
               .RifNoleggio = rifCausale
               .CodiceArticolo = lstvElencoArticoli.Items(i).SubItems(0).Text
               .Descrizione = lstvElencoArticoli.Items(i).SubItems(1).Text
               .Unit‡Misura = lstvElencoArticoli.Items(i).SubItems(2).Text
               .Quantit‡ = Convert.ToDouble(lstvElencoArticoli.Items(i).SubItems(3).Text)
               .ValoreUnitario = lstvElencoArticoli.Items(i).SubItems(4).Text
               .ImportoNetto = lstvElencoArticoli.Items(i).SubItems(5).Text
               .AliquotaIva = lstvElencoArticoli.Items(i).SubItems(6).Text
               .Categoria = lstvElencoArticoli.Items(i).SubItems(7).Text
               .IdArticolo = lstvElencoArticoli.Items(i).SubItems(8).Text

               .InserisciDati(TAB_DETTAGLI_CAUSALI_NOLEGGIO)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function CalcolaCostoTotaleArticoli() As String
      Try
         Dim valCostoArticolo As Double
         Dim valTotaleCostoArticoli As Double

         Dim i As Integer
         For i = 0 To lstvElencoArticoli.Items.Count - 1
            valCostoArticolo = lstvElencoArticoli.Items(i).SubItems(5).Text

            valTotaleCostoArticoli = valTotaleCostoArticoli + valCostoArticolo
         Next

         Return CFormatta.FormattaNumeroDouble(valTotaleCostoArticoli)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0.0
      End Try
   End Function

   Private Function CaricaElencoArticoli(ByVal lst As ListView, ByVal tabella As String, ByVal rifCausale As String) As Boolean
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim Caricati As Boolean = False

         Try
            cn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifCausale = " & rifCausale & " ORDER BY Descrizione ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Dim i As Integer

            lst.Items.Clear()

            Do While dr.Read
               ' Codice.
               lst.Items.Add(dr.Item("CodiceArticolo"))

               ' Descrizione.
               If IsDBNull(dr.Item("Descrizione")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Descrizione").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Unit‡ Misura.
               If IsDBNull(dr.Item("Unit‡Misura")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Unit‡Misura").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Quantit‡.
               If IsDBNull(dr.Item("Quantit‡")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Quantit‡"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Valore Unitario.
               If IsDBNull(dr.Item("ValoreUnitario")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("ValoreUnitario"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Importo Netto.
               If IsDBNull(dr.Item("ImportoNetto")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("ImportoNetto"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Aliquota Iva.
               If IsDBNull(dr.Item("AliquotaIva")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("AliquotaIva"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Categoria.
               If IsDBNull(dr.Item("Categoria")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Categoria").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Id.
               If IsDBNull(dr.Item("Id")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Id").ToString)
               Else
                  lst.Items(i).SubItems.Add(0.ToString)
               End If

               ' RifNoleggio.
               If IsDBNull(dr.Item("RifCausale")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("RifCausale").ToString)
               Else
                  lst.Items(i).SubItems.Add(0.ToString)
               End If

               ' Imposta l'immagine.
               lst.Items(i).StateImageIndex = 11

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

   Public Sub EliminaArticolo()
      Try
         Dim Risposta As Short
         Dim Articolo As String = lstvElencoArticoli.Items(lstvElencoArticoli.FocusedItem.Index).SubItems(1).Text

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera rimuovere l'articolo """ & Articolo & """ dalla lista?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma elimina")

         If Risposta = MsgBoxResult.Yes Then
            lstvElencoArticoli.Items(lstvElencoArticoli.FocusedItem.Index).Remove()
         End If

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CausaleNoleggio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(NOLEGGI_LARGHEZZA, NOLEGGI_ALTEZZA)

         If Me.Tag <> String.Empty Then
            With CCausaleNoleggio

               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(TAB_CAUSALI_NOLEGGIO, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               eui_txtCodice.Text = .Codice
               eui_txtDescrizione.Text = .Descrizione
               eui_txtCostoGiorno.Text = CFormatta.FormattaNumeroDouble(.CostoGiorno)
               eui_txtCostoAssicurazione.Text = CFormatta.FormattaNumeroDouble(.CostoAssicurazione)
               eui_txtCostoMora.Text = CFormatta.FormattaNumeroDouble(.CostoMora)
               eui_txtNote.Text = .Note

               ' Carica la lista degli Articoli Noleggiati.
               CaricaElencoArticoli(lstvElencoArticoli, TAB_DETTAGLI_CAUSALI_NOLEGGIO, CCausaleNoleggio.Codice)

            End With
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.

         End If

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(eui_txtCodice.Text, eui_txtDescrizione.Text, String.Empty)

         ' Imposta lo stato attivo.
         eui_txtDescrizione.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub CausaleNoleggio_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' TODO_B: Sviluppare RegistraOperazione.
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_FORNITORI)
      End If

      g_frmSchedaCausaliNoleggio.Dispose()
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               ' Salva gli articoli noleggiati.
               SalvaArticoli(Me.Tag)

               If IsNothing(g_frmCausaliNoleggio) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmCausaliNoleggio.AggiornaDati()
               End If

               Me.DialogResult = Windows.Forms.DialogResult.OK

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & CCausaleNoleggio.Descrizione & ")"

               ' TODO_B: Modificare RegistraOperazione.
               'g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_FORNITORI)
            End If

         Case "Annulla"
            Me.DialogResult = Windows.Forms.DialogResult.Cancel

            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' TODO_B: Modificare RegistraOperazione.
            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_FORNITORI)
      End Select
   End Sub

   Private Sub TabControl2_SelectedTabPageChanged(sender As Object, e As Elegant.Ui.TabPageChangedEventArgs) Handles TabControl2.SelectedTabPageChanged
      Try
         Select Case TabControl2.SelectedTabPage.TabIndex
            Case 0
               ' Imposta lo stato attivo.
               eui_txtCodice.Focus()

            Case 1
               ' Imposta lo stato attivo.
               lstvElencoArticoli.Focus()

               ' Imposta il pulsante di default.
               eui_cmdInserisci.NotifyDefault(True)

            Case 2
               ' Imposta lo stato attivo.
               eui_txtNote.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_txtCostoGiorno_LostFocus(sender As Object, e As EventArgs) Handles eui_txtCostoGiorno.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCostoMora_LostFocus(sender As Object, e As EventArgs) Handles eui_txtCostoMora.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCostoAssicurazione_LostFocus(sender As Object, e As EventArgs) Handles eui_txtCostoAssicurazione.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCostoGiorno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCostoGiorno.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_txtCostoMora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCostoMora.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_txtCostoAssicurazione_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCostoAssicurazione.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_cmdElimina_Click(sender As Object, e As EventArgs) Handles eui_cmdElimina.Click
      Try
         eui_cmdInserisci.NotifyDefault(False)

         lstvElencoArticoli.Focus()

         EliminaArticolo()

         eui_txtCostoGiorno.Text = CalcolaCostoTotaleArticoli()

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInserisci_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisci.Click
      Try
         Dim frm As New ListaArticoli(Me)
         frm.ShowDialog()

         eui_txtCostoGiorno.Text = CalcolaCostoTotaleArticoli()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

End Class
