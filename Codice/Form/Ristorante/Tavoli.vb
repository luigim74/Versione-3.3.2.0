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

Public Class frmTavoli
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
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Public WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Public WithEvents txtPosti As System.Windows.Forms.TextBox
   Friend WithEvents cmbCameriere As System.Windows.Forms.ComboBox
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmbListino As System.Windows.Forms.ComboBox
   Friend WithEvents cmbOrientamento As System.Windows.Forms.ComboBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbSala As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents chkEscludi As System.Windows.Forms.CheckBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents Panel2 As Panel
   Friend WithEvents netBtn_Anteprima As Softgroup.NetButton.NetButton
   Public WithEvents lblEscludi As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTavoli))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.chkEscludi = New System.Windows.Forms.CheckBox()
      Me.lblEscludi = New System.Windows.Forms.Label()
      Me.cmbSala = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmbOrientamento = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbListino = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtPosti = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmbCameriere = New System.Windows.Forms.ComboBox()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.label = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.netBtn_Anteprima = New Softgroup.NetButton.NetButton()
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
      Me.ToolBar1.Size = New System.Drawing.Size(569, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(569, 20)
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
      Me.TabControl1.Size = New System.Drawing.Size(569, 310)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.chkEscludi)
      Me.TabPage1.Controls.Add(Me.lblEscludi)
      Me.TabPage1.Controls.Add(Me.cmbSala)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.cmbOrientamento)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.cmbListino)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.txtPosti)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.cmbCameriere)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(561, 284)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'chkEscludi
      '
      Me.chkEscludi.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkEscludi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkEscludi.Location = New System.Drawing.Point(112, 248)
      Me.chkEscludi.Name = "chkEscludi"
      Me.chkEscludi.Size = New System.Drawing.Size(16, 16)
      Me.chkEscludi.TabIndex = 6
      '
      'lblEscludi
      '
      Me.lblEscludi.AutoSize = True
      Me.lblEscludi.BackColor = System.Drawing.Color.Transparent
      Me.lblEscludi.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblEscludi.ForeColor = System.Drawing.Color.Black
      Me.lblEscludi.Location = New System.Drawing.Point(128, 248)
      Me.lblEscludi.Name = "lblEscludi"
      Me.lblEscludi.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblEscludi.Size = New System.Drawing.Size(109, 13)
      Me.lblEscludi.TabIndex = 205
      Me.lblEscludi.Text = "Escludi dalla gestione"
      '
      'cmbSala
      '
      Me.cmbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSala.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbSala.Location = New System.Drawing.Point(112, 184)
      Me.cmbSala.Name = "cmbSala"
      Me.cmbSala.Size = New System.Drawing.Size(240, 21)
      Me.cmbSala.TabIndex = 4
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(32, 184)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 202
      Me.Label2.Text = "Sala:"
      '
      'cmbOrientamento
      '
      Me.cmbOrientamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOrientamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbOrientamento.Items.AddRange(New Object() {"Orizzontale", "Verticale"})
      Me.cmbOrientamento.Location = New System.Drawing.Point(112, 216)
      Me.cmbOrientamento.Name = "cmbOrientamento"
      Me.cmbOrientamento.Size = New System.Drawing.Size(240, 21)
      Me.cmbOrientamento.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(32, 216)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(73, 13)
      Me.Label1.TabIndex = 200
      Me.Label1.Text = "Orientamento:"
      '
      'cmbListino
      '
      Me.cmbListino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbListino.Items.AddRange(New Object() {"1", "2", "3", "4"})
      Me.cmbListino.Location = New System.Drawing.Point(112, 120)
      Me.cmbListino.Name = "cmbListino"
      Me.cmbListino.Size = New System.Drawing.Size(64, 21)
      Me.cmbListino.TabIndex = 2
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(32, 120)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 190
      Me.Label6.Text = "Listino:"
      '
      'txtPosti
      '
      Me.txtPosti.AcceptsReturn = True
      Me.txtPosti.BackColor = System.Drawing.SystemColors.Window
      Me.txtPosti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPosti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPosti.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPosti.Location = New System.Drawing.Point(112, 88)
      Me.txtPosti.MaxLength = 0
      Me.txtPosti.Name = "txtPosti"
      Me.txtPosti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPosti.Size = New System.Drawing.Size(64, 20)
      Me.txtPosti.TabIndex = 1
      Me.txtPosti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(32, 88)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(33, 13)
      Me.Label5.TabIndex = 188
      Me.Label5.Text = "Posti:"
      '
      'cmbCameriere
      '
      Me.cmbCameriere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCameriere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCameriere.Location = New System.Drawing.Point(112, 152)
      Me.cmbCameriere.Name = "cmbCameriere"
      Me.cmbCameriere.Size = New System.Drawing.Size(240, 21)
      Me.cmbCameriere.TabIndex = 3
      '
      'txtDescrizione
      '
      Me.txtDescrizione.AcceptsReturn = True
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizione.Location = New System.Drawing.Point(112, 56)
      Me.txtDescrizione.MaxLength = 0
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizione.Size = New System.Drawing.Size(240, 20)
      Me.txtDescrizione.TabIndex = 0
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(32, 152)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(57, 13)
      Me.label.TabIndex = 169
      Me.label.Text = "Cameriere:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(32, 56)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(65, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Descrizione:"
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(112, 24)
      Me.txtCodice.MaxLength = 5
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(104, 20)
      Me.txtCodice.TabIndex = 7
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(32, 24)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(43, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Codice:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.Panel2)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(561, 284)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Anteprima"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel2.Controls.Add(Me.netBtn_Anteprima)
      Me.Panel2.Location = New System.Drawing.Point(8, 12)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(544, 254)
      Me.Panel2.TabIndex = 204
      '
      'netBtn_Anteprima
      '
      Me.netBtn_Anteprima.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Anteprima.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Anteprima.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Anteprima.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Anteprima.ColorText = System.Drawing.Color.White
      Me.netBtn_Anteprima.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Anteprima.CornerRadius = 2
      Me.netBtn_Anteprima.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Anteprima.Location = New System.Drawing.Point(247, 96)
      Me.netBtn_Anteprima.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Anteprima.Name = "netBtn_Anteprima"
      Me.netBtn_Anteprima.Size = New System.Drawing.Size(50, 50)
      Me.netBtn_Anteprima.TabIndex = 1
      Me.netBtn_Anteprima.TextButton = ""
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(560, 274)
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
      Me.txtNote.Size = New System.Drawing.Size(560, 274)
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
      'frmTavoli
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(569, 356)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmTavoli"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Tavoli"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.Panel2.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private ATavoli As New Tavoli
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   Const NOME_TABELLA As String = "Tavoli"
   Const TAB_STATO_TAVOLO As String = "StatoTavolo"
   Const TAB_CAMERIERI As String = "Camerieri"
   Const TAB_SALE As String = "Sale"

   Const LARGHEZZA As Integer = 50
   Const ALTEZZA As Integer = 50
   Dim LARGHEZZA_RISORSA As Integer = LARGHEZZA
   Dim ALTEZZA_RISORSA As Integer = ALTEZZA

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
      Try
         With ATavoli
            ' Assegna i dati dei campi della classe alle caselle di testo.
            If txtDescrizione.Text = String.Empty Then
               MessageBox.Show("Specificare una descrizione per il tavolo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               txtDescrizione.Focus()
               Return False
            Else
               .Descrizione = FormattaApici(txtDescrizione.Text)
            End If

            ' Controllo sul campo Persone.
            If txtPosti.Text <> "0" And txtPosti.Text <> String.Empty Then
               .Posti = txtPosti.Text
            Else
               MessageBox.Show("Numero di posti non valido! Specificare un numero di uno o più posti.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               txtPosti.Focus()
               Return False
            End If

            .Cameriere = FormattaApici(cmbCameriere.Text)
            .Listino = cmbListino.Text
            .Orientamento = cmbOrientamento.Text
            .Sala = cmbSala.Text
            .Note = FormattaApici(txtNote.Text)

            If chkEscludi.Checked = True Then
               .Escludi = "Sì"
            Else
               .Escludi = "No"
            End If

            .AltezzaTasto = .AltezzaTasto
            .LarghezzaTasto = .LarghezzaTasto
            .NumTastiRiga = .NumTastiRiga
            .DimensioneTasto = .DimensioneTasto
            .OrdineTasto = .OrdineTasto

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(NOME_TABELLA, Me.Tag)
            Else
               .PosX = 0
               .PosY = 0
               .Colore = Convert.ToString(Color.MediumSeaGreen.ToArgb)
               .OraOcc = ""
               .Coperti = ""

               .AltezzaTasto = .LeggiUltimoRecord("AltezzaTasto", NOME_TABELLA)
               .LarghezzaTasto = .LeggiUltimoRecord("LarghezzaTasto", NOME_TABELLA)
               .NumTastiRiga = .LeggiUltimoRecord("NumTastiRiga", NOME_TABELLA)
               .DimensioneTasto = .LeggiUltimoRecord("DimensioneTasto", NOME_TABELLA)
               .OrdineTasto = .LeggiUltimoRecord("OrdineTasto", NOME_TABELLA) + 1

               Return .InserisciDati(NOME_TABELLA)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub ImpostaTavolo()
      Try
         If txtPosti.Text = "" Then
            Exit Sub
         End If

         Dim numPosti As Integer = CInt(txtPosti.Text)

         ' Tavolo standard.
         If numPosti < 5 Then
            LARGHEZZA_RISORSA = LARGHEZZA
            ALTEZZA_RISORSA = ALTEZZA

            ' Tavolo più grande di 4 posti.
         ElseIf numPosti > 4 Then
            Dim menoQuattro As Integer = (numPosti - 4)
            Dim restoPosti As Integer = 0

            ' Se è dispari lo fa diventare pari.
            If (menoQuattro Mod 2) <> 0 Then
               restoPosti = menoQuattro + 1
            Else
               restoPosti = menoQuattro
            End If

            ' Posti da aggiungere.
            Dim postiDaAgg As Integer = ((restoPosti / 2) + 1)

            Select Case cmbOrientamento.Text
               Case "Orizzontale"
                  If postiDaAgg <> 0 Then
                     LARGHEZZA_RISORSA = (postiDaAgg * LARGHEZZA)
                     ALTEZZA_RISORSA = ALTEZZA
                  End If

               Case "Verticale"
                  If postiDaAgg <> 0 Then
                     ALTEZZA_RISORSA = (postiDaAgg * ALTEZZA)
                     LARGHEZZA_RISORSA = LARGHEZZA
                  End If
            End Select

         End If

         ' Applica le dimensioni.
         netBtn_Anteprima.Size = New Size(LARGHEZZA_RISORSA, ALTEZZA_RISORSA)

         ' Centra il pulsante nel controllo contenitore.
         netBtn_Anteprima.Location = CentraControllo(netBtn_Anteprima, Panel2)

         ' Visualizza il nome del tavolo.
         netBtn_Anteprima.Text = txtDescrizione.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiNumPren(ByVal tabella As String, ByVal val As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE IdRisorsa = '" & val & "'", tabella)
         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub frmTavoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         ' Carica le liste.
         CaricaListaCamerieri(cmbCameriere, TAB_CAMERIERI)
         CaricaLista(cmbSala, TAB_SALE)

         If cmbSala.Items.Count = 0 Then
            MessageBox.Show("Non esistono Sale dove inserire il tavolo! " & vbCrLf &
                            "Si suggerisce di creare una nuova Sala e in seguito creare il tavolo.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
            Exit Sub
         End If

         If Me.Tag <> "" Then
            With ATavoli
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtDescrizione.Text = .Descrizione
               txtPosti.Text = .Posti
               cmbCameriere.Text = .Cameriere
               cmbListino.Text = .Listino
               cmbOrientamento.Text = .Orientamento
               cmbSala.Text = .Sala
               txtNote.Text = .Note

               If .OraOcc = "" Then
                  If LeggiNumPren("Prenotazioni", Me.Tag) = 0 Then
                     chkEscludi.Visible = True
                     lblEscludi.Visible = True
                  Else
                     chkEscludi.Visible = False
                     lblEscludi.Visible = False
                  End If
               Else
                  chkEscludi.Visible = False
                  lblEscludi.Visible = False
               End If

               If .Escludi = "Sì" Then
                  chkEscludi.Checked = True
               Else
                  chkEscludi.Checked = False
               End If

            End With
         Else
            ' Inserisce automaticamente la categoria selezionata.
            txtPosti.Text = "0"
            cmbListino.Text = "1"
            If cmbSala.Items.Count <> 0 Then
               cmbSala.SelectedIndex = 0
            End If
            cmbOrientamento.Text = "Orizzontale"
            netBtn_Anteprima.TextButton = String.Empty
         End If

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtDescrizione.Text, String.Empty, String.Empty)

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

   Private Sub frmTavoli_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_TAVOLI)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmTavoli) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmTavoli.AggiornaDati()
               End If

               'If IsNothing(g_frmVCTavoli) = False Then
               '   ' Aggiorna Visual Chef
               '   g_frmVCTavoli.AggiornaVCTavoli()
               'End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & ATavoli.Descrizione & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_TAVOLI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_TAVOLI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            txtDescrizione.Focus()
         Case 1
            ImpostaTavolo()

            ' Imposta lo stato attivo.
            netBtn_Anteprima.Focus()
         Case 2
            ' Imposta lo stato attivo.
            Me.txtNote.Focus()
      End Select
   End Sub

   Private Sub txtPosti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPosti.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

End Class

