' Nome form:            frmPiatti
' Autore:               Luigi Montana, Montana Software
' Data creazione:       23/04/2006
' Data ultima modifica: 23/04/2006
' Descrizione:          Anagrafica Piatti.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb
Imports System.Globalization.NumberFormatInfo

Public Class frmPiatti
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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents label As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
   Public WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
   Friend WithEvents chkVariazione As System.Windows.Forms.CheckBox
   Public WithEvents Label39 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label7 As System.Windows.Forms.Label
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents txtListino4 As System.Windows.Forms.TextBox
   Public WithEvents txtListino3 As System.Windows.Forms.TextBox
   Public WithEvents txtListino2 As System.Windows.Forms.TextBox
   Public WithEvents txtListino1 As System.Windows.Forms.TextBox
   Public WithEvents txtValVenduto As System.Windows.Forms.TextBox
   Public WithEvents txtQVenduta As System.Windows.Forms.TextBox
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents txtIngredienti As System.Windows.Forms.TextBox
   Friend WithEvents chkEscludiMenu As System.Windows.Forms.CheckBox
   Public WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label14 As System.Windows.Forms.Label
   Public WithEvents txtDescrizionePos As System.Windows.Forms.TextBox
   Friend WithEvents cmbTipoIcona As System.Windows.Forms.ComboBox
   Friend WithEvents lstwIcona As System.Windows.Forms.ListView
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents cmdRipristina As System.Windows.Forms.Button
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents cmdAnteprima As System.Windows.Forms.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdImmagine As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPiatti))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.chkEscludiMenu = New System.Windows.Forms.CheckBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.txtIngredienti = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtListino4 = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtListino3 = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtListino2 = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtListino1 = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtValVenduto = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtQVenduta = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.chkVariazione = New System.Windows.Forms.CheckBox()
      Me.Label39 = New System.Windows.Forms.Label()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.cmbCategoria = New System.Windows.Forms.ComboBox()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.label = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.cmdImmagine = New System.Windows.Forms.Button()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.cmdAnteprima = New System.Windows.Forms.Button()
      Me.cmdRipristina = New System.Windows.Forms.Button()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.lstwIcona = New System.Windows.Forms.ListView()
      Me.cmbTipoIcona = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtDescrizionePos = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(548, 26)
      Me.ToolBar1.TabIndex = 0
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'Salva
      '
      Me.Salva.ImageIndex = 0
      Me.Salva.Name = "Salva"
      Me.Salva.Tag = "Salva"
      Me.Salva.Text = "Salva"
      Me.Salva.ToolTipText = "Salva"
      '
      'Annulla
      '
      Me.Annulla.ImageIndex = 1
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
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(548, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(548, 324)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.chkEscludiMenu)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.txtIngredienti)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.txtListino4)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.txtListino3)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.txtListino2)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.txtListino1)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.txtValVenduto)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.txtQVenduta)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.chkVariazione)
      Me.TabPage1.Controls.Add(Me.Label39)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.cmbCategoria)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.ForeColor = System.Drawing.Color.Black
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(540, 298)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'chkEscludiMenu
      '
      Me.chkEscludiMenu.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkEscludiMenu.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkEscludiMenu.Location = New System.Drawing.Point(504, 200)
      Me.chkEscludiMenu.Name = "chkEscludiMenu"
      Me.chkEscludiMenu.Size = New System.Drawing.Size(16, 16)
      Me.chkEscludiMenu.TabIndex = 8
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(384, 200)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(90, 13)
      Me.Label10.TabIndex = 198
      Me.Label10.Text = "Escludi dal menù:"
      '
      'txtIngredienti
      '
      Me.txtIngredienti.AcceptsReturn = True
      Me.txtIngredienti.BackColor = System.Drawing.SystemColors.Window
      Me.txtIngredienti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIngredienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIngredienti.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIngredienti.Location = New System.Drawing.Point(128, 224)
      Me.txtIngredienti.MaxLength = 0
      Me.txtIngredienti.Name = "txtIngredienti"
      Me.txtIngredienti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIngredienti.Size = New System.Drawing.Size(392, 20)
      Me.txtIngredienti.TabIndex = 9
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(16, 224)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(112, 13)
      Me.Label9.TabIndex = 196
      Me.Label9.Text = "Descrizione nel Menù:"
      '
      'txtListino4
      '
      Me.txtListino4.AcceptsReturn = True
      Me.txtListino4.BackColor = System.Drawing.SystemColors.Window
      Me.txtListino4.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtListino4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtListino4.Location = New System.Drawing.Point(128, 184)
      Me.txtListino4.MaxLength = 0
      Me.txtListino4.Name = "txtListino4"
      Me.txtListino4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtListino4.Size = New System.Drawing.Size(144, 20)
      Me.txtListino4.TabIndex = 7
      Me.txtListino4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(16, 184)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(49, 13)
      Me.Label8.TabIndex = 194
      Me.Label8.Text = "Listino 4:"
      '
      'txtListino3
      '
      Me.txtListino3.AcceptsReturn = True
      Me.txtListino3.BackColor = System.Drawing.SystemColors.Window
      Me.txtListino3.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtListino3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtListino3.Location = New System.Drawing.Point(128, 160)
      Me.txtListino3.MaxLength = 0
      Me.txtListino3.Name = "txtListino3"
      Me.txtListino3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtListino3.Size = New System.Drawing.Size(144, 20)
      Me.txtListino3.TabIndex = 6
      Me.txtListino3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(16, 160)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(49, 13)
      Me.Label7.TabIndex = 192
      Me.Label7.Text = "Listino 3:"
      '
      'txtListino2
      '
      Me.txtListino2.AcceptsReturn = True
      Me.txtListino2.BackColor = System.Drawing.SystemColors.Window
      Me.txtListino2.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtListino2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtListino2.Location = New System.Drawing.Point(128, 136)
      Me.txtListino2.MaxLength = 0
      Me.txtListino2.Name = "txtListino2"
      Me.txtListino2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtListino2.Size = New System.Drawing.Size(144, 20)
      Me.txtListino2.TabIndex = 5
      Me.txtListino2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(16, 136)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(49, 13)
      Me.Label6.TabIndex = 190
      Me.Label6.Text = "Listino 2:"
      '
      'txtListino1
      '
      Me.txtListino1.AcceptsReturn = True
      Me.txtListino1.BackColor = System.Drawing.SystemColors.Window
      Me.txtListino1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtListino1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtListino1.Location = New System.Drawing.Point(128, 112)
      Me.txtListino1.MaxLength = 0
      Me.txtListino1.Name = "txtListino1"
      Me.txtListino1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtListino1.Size = New System.Drawing.Size(144, 20)
      Me.txtListino1.TabIndex = 4
      Me.txtListino1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 112)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(49, 13)
      Me.Label5.TabIndex = 188
      Me.Label5.Text = "Listino 1:"
      '
      'txtValVenduto
      '
      Me.txtValVenduto.AcceptsReturn = True
      Me.txtValVenduto.BackColor = System.Drawing.SystemColors.Control
      Me.txtValVenduto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtValVenduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValVenduto.ForeColor = System.Drawing.Color.Red
      Me.txtValVenduto.Location = New System.Drawing.Point(128, 256)
      Me.txtValVenduto.MaxLength = 0
      Me.txtValVenduto.Name = "txtValVenduto"
      Me.txtValVenduto.ReadOnly = True
      Me.txtValVenduto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtValVenduto.Size = New System.Drawing.Size(144, 20)
      Me.txtValVenduto.TabIndex = 10
      Me.txtValVenduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 256)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(82, 13)
      Me.Label4.TabIndex = 186
      Me.Label4.Text = "Valore venduto:"
      '
      'txtQVenduta
      '
      Me.txtQVenduta.AcceptsReturn = True
      Me.txtQVenduta.BackColor = System.Drawing.SystemColors.Control
      Me.txtQVenduta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtQVenduta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtQVenduta.ForeColor = System.Drawing.Color.Red
      Me.txtQVenduta.Location = New System.Drawing.Point(384, 256)
      Me.txtQVenduta.MaxLength = 0
      Me.txtQVenduta.Name = "txtQVenduta"
      Me.txtQVenduta.ReadOnly = True
      Me.txtQVenduta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtQVenduta.Size = New System.Drawing.Size(136, 20)
      Me.txtQVenduta.TabIndex = 11
      Me.txtQVenduta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(288, 256)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(92, 13)
      Me.Label2.TabIndex = 184
      Me.Label2.Text = "Quantità venduta:"
      '
      'chkVariazione
      '
      Me.chkVariazione.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkVariazione.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkVariazione.Location = New System.Drawing.Point(352, 16)
      Me.chkVariazione.Name = "chkVariazione"
      Me.chkVariazione.Size = New System.Drawing.Size(16, 16)
      Me.chkVariazione.TabIndex = 1
      '
      'Label39
      '
      Me.Label39.AutoSize = True
      Me.Label39.BackColor = System.Drawing.Color.Transparent
      Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label39.ForeColor = System.Drawing.Color.Black
      Me.Label39.Location = New System.Drawing.Point(288, 16)
      Me.Label39.Name = "Label39"
      Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label39.Size = New System.Drawing.Size(59, 13)
      Me.Label39.TabIndex = 182
      Me.Label39.Text = "Variazione:"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(456, 160)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(64, 24)
      Me.EliminaImg.TabIndex = 13
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(384, 160)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(64, 24)
      Me.ApriImg.TabIndex = 12
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
      'cmbCategoria
      '
      Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCategoria.Location = New System.Drawing.Point(128, 80)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(240, 21)
      Me.cmbCategoria.TabIndex = 3
      '
      'txtDescrizione
      '
      Me.txtDescrizione.AcceptsReturn = True
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizione.Location = New System.Drawing.Point(128, 48)
      Me.txtDescrizione.MaxLength = 0
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizione.Size = New System.Drawing.Size(240, 20)
      Me.txtDescrizione.TabIndex = 2
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(16, 80)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(55, 13)
      Me.label.TabIndex = 169
      Me.label.Text = "Categoria:"
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
      Me.Label3.Size = New System.Drawing.Size(65, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Descrizione:"
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Control
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(128, 16)
      Me.txtNumero.MaxLength = 5
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(104, 20)
      Me.txtNumero.TabIndex = 0
      Me.txtNumero.TabStop = False
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(16, 16)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(43, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Codice:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.cmdImmagine)
      Me.TabPage2.Controls.Add(Me.Panel2)
      Me.TabPage2.Controls.Add(Me.cmdRipristina)
      Me.TabPage2.Controls.Add(Me.Label14)
      Me.TabPage2.Controls.Add(Me.lstwIcona)
      Me.TabPage2.Controls.Add(Me.cmbTipoIcona)
      Me.TabPage2.Controls.Add(Me.Label13)
      Me.TabPage2.Controls.Add(Me.txtDescrizionePos)
      Me.TabPage2.Controls.Add(Me.Label12)
      Me.TabPage2.Controls.Add(Me.cmdColore)
      Me.TabPage2.Controls.Add(Me.Label11)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(540, 298)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Punto cassa"
      '
      'cmdImmagine
      '
      Me.cmdImmagine.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdImmagine.Location = New System.Drawing.Point(152, 240)
      Me.cmdImmagine.Name = "cmdImmagine"
      Me.cmdImmagine.Size = New System.Drawing.Size(120, 32)
      Me.cmdImmagine.TabIndex = 2
      Me.cmdImmagine.Text = "&Aggiungi immagine"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.SystemColors.Window
      Me.Panel2.Controls.Add(Me.cmdAnteprima)
      Me.Panel2.Location = New System.Drawing.Point(152, 88)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(256, 136)
      Me.Panel2.TabIndex = 203
      '
      'cmdAnteprima
      '
      Me.cmdAnteprima.BackColor = System.Drawing.Color.White
      Me.cmdAnteprima.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAnteprima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnteprima.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdAnteprima.Location = New System.Drawing.Point(76, 33)
      Me.cmdAnteprima.Name = "cmdAnteprima"
      Me.cmdAnteprima.Size = New System.Drawing.Size(104, 70)
      Me.cmdAnteprima.TabIndex = 0
      Me.cmdAnteprima.TabStop = False
      Me.cmdAnteprima.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmdAnteprima.UseVisualStyleBackColor = False
      '
      'cmdRipristina
      '
      Me.cmdRipristina.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRipristina.Location = New System.Drawing.Point(288, 240)
      Me.cmdRipristina.Name = "cmdRipristina"
      Me.cmdRipristina.Size = New System.Drawing.Size(120, 32)
      Me.cmdRipristina.TabIndex = 3
      Me.cmdRipristina.Text = "&Ripristina"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(40, 88)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(57, 13)
      Me.Label14.TabIndex = 202
      Me.Label14.Text = "Anteprima:"
      '
      'lstwIcona
      '
      Me.lstwIcona.LargeImageList = Me.ImageList1
      Me.lstwIcona.Location = New System.Drawing.Point(88, 192)
      Me.lstwIcona.Name = "lstwIcona"
      Me.lstwIcona.Size = New System.Drawing.Size(56, 32)
      Me.lstwIcona.TabIndex = 2
      Me.lstwIcona.UseCompatibleStateImageBehavior = False
      Me.lstwIcona.Visible = False
      '
      'cmbTipoIcona
      '
      Me.cmbTipoIcona.Items.AddRange(New Object() {"Bevande", "Dolci", "Frutta e verdura", "Pane e panini", "Pesce", "Pizze", "Primi", "Secondi e contorni", "Varie"})
      Me.cmbTipoIcona.Location = New System.Drawing.Point(88, 168)
      Me.cmbTipoIcona.Name = "cmbTipoIcona"
      Me.cmbTipoIcona.Size = New System.Drawing.Size(56, 21)
      Me.cmbTipoIcona.TabIndex = 1
      Me.cmbTipoIcona.Visible = False
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(24, 168)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(55, 13)
      Me.Label13.TabIndex = 198
      Me.Label13.Text = "Immagine:"
      Me.Label13.Visible = False
      '
      'txtDescrizionePos
      '
      Me.txtDescrizionePos.AcceptsReturn = True
      Me.txtDescrizionePos.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizionePos.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizionePos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizionePos.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizionePos.Location = New System.Drawing.Point(152, 24)
      Me.txtDescrizionePos.MaxLength = 0
      Me.txtDescrizionePos.Name = "txtDescrizionePos"
      Me.txtDescrizionePos.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizionePos.Size = New System.Drawing.Size(256, 20)
      Me.txtDescrizionePos.TabIndex = 0
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(40, 24)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(108, 13)
      Me.Label12.TabIndex = 197
      Me.Label12.Text = "Descrizione pulsante:"
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(152, 56)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(80, 19)
      Me.cmdColore.TabIndex = 1
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(40, 56)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(40, 13)
      Me.Label11.TabIndex = 195
      Me.Label11.Text = "Colore:"
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(540, 298)
      Me.TabPage6.TabIndex = 5
      Me.TabPage6.Text = "Note"
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
      Me.txtNote.Size = New System.Drawing.Size(540, 298)
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
      'frmPiatti
      '
      Me.AcceptButton = Me.ApriImg
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(548, 370)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPiatti"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Piatti"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private APiatti As New Piatti
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   Const NOME_TABELLA As String = "Piatti"
   Const TAB_CATEGORIA As String = "CategoriePiatti"
   Const TAB_STATISTICHE As String = "Statistiche"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Function SalvaDati() As Boolean

      ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
      AggiornaTabellaCategorie(cmbCategoria, TAB_CATEGORIA)

      Try
         With APiatti
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Descrizione = FormattaApici(txtDescrizione.Text)
            .DescrizionePos = FormattaApici(txtDescrizionePos.Text)
            .Ingredienti = FormattaApici(txtIngredienti.Text)
            .Categoria = FormattaApici(cmbCategoria.Text)

            If IsNumeric(txtQVenduta.Text) Then
               .QtàVenduta = CFormatta.FormattaNumero(txtQVenduta.Text)
            Else
               .QtàVenduta = 0
            End If
            If IsNumeric(txtValVenduto.Text) Then
               .ValVenduto = CFormatta.FormattaEuro(txtValVenduto.Text)
            Else
               .ValVenduto = VALORE_ZERO
            End If
            If IsNumeric(txtListino1.Text) Then
               .Listino1 = CFormatta.FormattaEuro(txtListino1.Text)
            Else
               .Listino1 = VALORE_ZERO
            End If
            If IsNumeric(txtListino2.Text) Then
               .Listino2 = CFormatta.FormattaEuro(txtListino2.Text)
            Else
               .Listino2 = VALORE_ZERO
            End If
            If IsNumeric(txtListino3.Text) Then
               .Listino3 = CFormatta.FormattaEuro(txtListino3.Text)
            Else
               .Listino3 = VALORE_ZERO
            End If
            If IsNumeric(txtListino4.Text) Then
               .Listino4 = CFormatta.FormattaEuro(txtListino4.Text)
            Else
               .Listino4 = VALORE_ZERO
            End If

            .Note = FormattaApici(txtNote.Text)

            If chkVariazione.Checked = True Then
               .Variazione = "Sì"
            Else
               .Variazione = "No"
            End If

            If chkEscludiMenu.Checked = True Then
               .EscludiMenu = "Sì"
            Else
               .EscludiMenu = "No"
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

      Finally

      End Try
   End Function

   Private Sub InserisciImmagine()
      Try
         With OpenFileDialog1
            .Filter = "Tutti i formati |*.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" & _
                                     "Bmp (Bitmap di Windows)|*.Bmp|" & _
                                     "Gif |*.Gif|" & _
                                     "Jpeg/Jpg |*.Jpg; *.Jpeg |" & _
                                     "Png |*.Png|" & _
                                     "Tga |*.Tga|" & _
                                     "Tiff |*.Tiff|" & _
                                     "Wmf (Metafile di Windows) |*.Wmf"

            .FilterIndex = 1
            .ShowDialog()

            APiatti.Immagine = .FileName

         End With

         If File.Exists(APiatti.Immagine) = True Then
            Dim bmp As New Bitmap(APiatti.Immagine)
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
            APiatti.Immagine = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InserisciIcona()
      Try
         With OpenFileDialog1
            .Filter = "Ico |*.Ico"

            .FilterIndex = 1
            .InitialDirectory = Application.StartupPath & "\Immagini"

            .ShowDialog()

            APiatti.Icona = .FileName

         End With

         If File.Exists(APiatti.Icona) = True Then
            Dim bmp As New Bitmap(APiatti.Icona)
            cmdAnteprima.Image = bmp
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaIcona()
      Try
         If Not (cmdAnteprima.Image Is Nothing) Then
            cmdAnteprima.Image.Dispose()
            cmdAnteprima.Image = Nothing
            APiatti.Icona = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function SommaCampoQtà(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim somma As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT SUM(Quantità) FROM {0} WHERE IdPiatto = '" & Me.Tag & "'", tabella)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            somma = CInt(cmd.ExecuteScalar())
         Else
            somma = 0
         End If

         Return somma

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function SommaCampoValore(ByVal tabella As String) As Decimal
      Dim closeOnExit As Boolean
      Dim somma As Decimal

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT SUM(Importo) FROM {0} WHERE IdPiatto = '" & Me.Tag & "'", tabella)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            somma = CDec(cmd.ExecuteScalar())
         Else
            somma = 0
         End If

         Return somma

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub ModificaColore()
      Try
         With ColorDialog1()
            .Color = cmdColore.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColore.BackColor = .Color
               cmdAnteprima.BackColor = .Color
            End If

            APiatti.Colore = Convert.ToString(.Color.ToArgb)

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmPiatti) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmPiatti.AggiornaDati()

                  ' Carica la lista delle categorie dei piatti.
                  g_frmPiatti.lstCategorie.Items.Clear()
                  CaricaListaPiatti(g_frmPiatti.lstCategorie, g_frmPiatti.TAB_CATEGORIE)

                  ' Seleziona il primo elemento della lista categorie.
                  If g_frmPiatti.lstCategorie.Items.Count <> 0 Then
                     g_frmPiatti.lstCategorie.SelectedIndex = 0
                  End If
               End If

               If IsNothing(g_frmMenu) = False Then
                  Dim listino As String
                  If g_frmMenu.tbListino1.Pushed = True Then
                     listino = "1"
                  End If
                  If g_frmMenu.tbListino2.Pushed = True Then
                     listino = "2"
                  End If
                  If g_frmMenu.tbListino3.Pushed = True Then
                     listino = "3"
                  End If
                  If g_frmMenu.tbListino4.Pushed = True Then
                     listino = "4"
                  End If

                  g_frmMenu.ApplicaListino(NOME_TABELLA, listino)
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & APiatti.Descrizione & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_PIATTI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_PIATTI)
      End Select
   End Sub

   Private Sub frmPiatti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With APiatti
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = .Codice
               txtDescrizione.Text = .Descrizione
               txtDescrizionePos.Text = .DescrizionePos
               txtIngredienti.Text = .Ingredienti
               cmbCategoria.Text = .Categoria
               txtQVenduta.Text = CFormatta.FormattaNumero(SommaCampoQtà(TAB_STATISTICHE))
               txtValVenduto.Text = CFormatta.FormattaEuro(SommaCampoValore(TAB_STATISTICHE))
               txtListino1.Text = .Listino1
               txtListino2.Text = .Listino2
               txtListino3.Text = .Listino3
               txtListino4.Text = .Listino4
               txtNote.Text = .Note

               If .Variazione = "Sì" Then
                  chkVariazione.Checked = True
               Else
                  chkVariazione.Checked = False
               End If

               If .EscludiMenu = "Sì" Then
                  chkEscludiMenu.Checked = True
               Else
                  chkEscludiMenu.Checked = False
               End If

               If .Immagine <> Nothing Then
                  If File.Exists(.Immagine) = True Then
                     Dim bmp As New Bitmap(.Immagine)
                     picFoto.Image = bmp
                  End If
               End If

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
                  cmdAnteprima.BackColor = Color.FromArgb(.Colore)
               End If

               If .Icona <> Nothing Then
                  If File.Exists(.Icona) = True Then
                     Dim bmp As New Bitmap(.Icona)
                     cmdAnteprima.Image = bmp
                  End If
               End If

               cmdAnteprima.Text = txtDescrizionePos.Text

               If chkVariazione.Checked = True Then
                  cmdImmagine.Enabled = False
               Else
                  cmdImmagine.Enabled = True
               End If

            End With
         Else
            ' Inserisce automaticamente la categoria selezionata.
            cmbCategoria.Text = g_frmPiatti.lstCategorie.SelectedItem
            cmdColore.BackColor = Color.White
            cmdAnteprima.BackColor = Color.White
            APiatti.Colore = Convert.ToString(Color.White.ToArgb)
            APiatti.Icona = ""
         End If

         ' Carica le liste.
         CaricaLista(cmbCategoria, TAB_CATEGORIA)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, txtDescrizione.Text, "")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Imposta lo stato attivo.
         txtDescrizione.Focus()

      End Try
   End Sub

   Private Sub frmPiatti_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_ACQUISTI)
      End If
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            txtDescrizione.Focus()
         Case 1
            ' Imposta lo stato attivo.
            'cmdColore.Focus()
            txtDescrizionePos.Focus()
         Case 2
            ' Imposta lo stato attivo.
            txtNote.Focus()
      End Select
   End Sub

   Private Sub ApriImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApriImg.Click
      InserisciImmagine()
   End Sub

   Private Sub EliminaImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaImg.Click
      ApriImg.NotifyDefault(False)
      EliminaImmagine()
   End Sub

   Private Sub cmdColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColore.Click
      ModificaColore()
   End Sub

   Private Sub cmdRipristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRipristina.Click
      cmdColore.BackColor = Color.White
      cmdAnteprima.BackColor = Color.White
      APiatti.Colore = Convert.ToString(Color.White.ToArgb)
      EliminaIcona()
   End Sub

   Private Sub txtDescrizionePos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescrizionePos.TextChanged
      cmdAnteprima.Text = txtDescrizionePos.Text
   End Sub

   Private Sub cmdImmagine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImmagine.Click
      InserisciIcona()
   End Sub

   Private Sub chkVariazione_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVariazione.CheckedChanged
      If sender.Checked = True Then
         cmdImmagine.Enabled = False
      Else
         cmdImmagine.Enabled = True
      End If
   End Sub

   Private Sub txtListino1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtListino1.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtListino2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtListino2.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtListino3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtListino3.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtListino4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtListino4.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtListino4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtListino4.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtListino3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtListino3.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtListino2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtListino2.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtListino1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtListino1.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

End Class

