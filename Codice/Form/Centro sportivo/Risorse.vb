' Nome form:            frmRisorse
' Autore:               Luigi Montana, Montana Software
' Data creazione:       05/01/2006
' Data ultima modifica: 28/02/2006
' Descrizione:          Anagrafica Risorse.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmRisorse
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
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents label As System.Windows.Forms.Label
   Public WithEvents Label21 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
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
   Friend WithEvents cmbDisponibile As System.Windows.Forms.ComboBox
   Friend WithEvents cmbTipologia As System.Windows.Forms.ComboBox
   Public WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents cmbEscludi As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents cmbTipoPlanning As System.Windows.Forms.ComboBox
   Public WithEvents Label7 As System.Windows.Forms.Label
   Public WithEvents txtCosto As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRisorse))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbTipoPlanning = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtCosto = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbDisponibile = New System.Windows.Forms.ComboBox()
      Me.cmbEscludi = New System.Windows.Forms.ComboBox()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.cmbTipologia = New System.Windows.Forms.ComboBox()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.label = New System.Windows.Forms.Label()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
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
      Me.ToolBar1.Size = New System.Drawing.Size(538, 26)
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
      Me.ImageList1.Images.SetKeyName(0, "saveHS.png")
      Me.ImageList1.Images.SetKeyName(1, "Edit_UndoHS.png")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(538, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(538, 331)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbTipoPlanning)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.txtCosto)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.cmdColore)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.cmbDisponibile)
      Me.TabPage1.Controls.Add(Me.cmbEscludi)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.cmbTipologia)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(530, 305)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'cmbTipoPlanning
      '
      Me.cmbTipoPlanning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoPlanning.Items.AddRange(New Object() {"Planning 1 - (Inizio ore: 6:00 - Prenotazione minima mezz'ora)", "Planning 2 - (Inizio ore: 6:45 - Prenotazione minima un'ora)", "Planning 3 - (Inizio ore: 7:00 - Prenotazione minima un'ora)", "Planning 4 - (Inizio ore: 7:15 - Prenotazione minima un'ora)"})
      Me.cmbTipoPlanning.Location = New System.Drawing.Point(128, 224)
      Me.cmbTipoPlanning.Name = "cmbTipoPlanning"
      Me.cmbTipoPlanning.Size = New System.Drawing.Size(384, 21)
      Me.cmbTipoPlanning.TabIndex = 6
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(24, 224)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(96, 13)
      Me.Label7.TabIndex = 191
      Me.Label7.Text = "Tipologia planning:"
      '
      'txtCosto
      '
      Me.txtCosto.AcceptsReturn = True
      Me.txtCosto.BackColor = System.Drawing.SystemColors.Window
      Me.txtCosto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCosto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCosto.Location = New System.Drawing.Point(128, 128)
      Me.txtCosto.MaxLength = 0
      Me.txtCosto.Name = "txtCosto"
      Me.txtCosto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCosto.Size = New System.Drawing.Size(120, 20)
      Me.txtCosto.TabIndex = 3
      Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(24, 128)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(59, 13)
      Me.Label2.TabIndex = 185
      Me.Label2.Text = "Costo/Ora:"
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(128, 192)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(80, 19)
      Me.cmdColore.TabIndex = 5
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(24, 192)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 183
      Me.Label1.Text = "Colore:"
      '
      'cmbDisponibile
      '
      Me.cmbDisponibile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDisponibile.Items.AddRange(New Object() {"Sì", "No"})
      Me.cmbDisponibile.Location = New System.Drawing.Point(24, 275)
      Me.cmbDisponibile.Name = "cmbDisponibile"
      Me.cmbDisponibile.Size = New System.Drawing.Size(80, 21)
      Me.cmbDisponibile.TabIndex = 11
      Me.cmbDisponibile.Visible = False
      '
      'cmbEscludi
      '
      Me.cmbEscludi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEscludi.Items.AddRange(New Object() {"Sì", "No"})
      Me.cmbEscludi.Location = New System.Drawing.Point(128, 160)
      Me.cmbEscludi.Name = "cmbEscludi"
      Me.cmbEscludi.Size = New System.Drawing.Size(80, 21)
      Me.cmbEscludi.TabIndex = 4
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(448, 176)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(64, 24)
      Me.EliminaImg.TabIndex = 8
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(376, 176)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(64, 24)
      Me.ApriImg.TabIndex = 7
      Me.ApriImg.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.Color.White
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(376, 32)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(136, 136)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 178
      Me.picFoto.TabStop = False
      '
      'cmbTipologia
      '
      Me.cmbTipologia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipologia.Location = New System.Drawing.Point(128, 96)
      Me.cmbTipologia.Name = "cmbTipologia"
      Me.cmbTipologia.Size = New System.Drawing.Size(224, 21)
      Me.cmbTipologia.TabIndex = 2
      '
      'txtDescrizione
      '
      Me.txtDescrizione.AcceptsReturn = True
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizione.Location = New System.Drawing.Point(128, 64)
      Me.txtDescrizione.MaxLength = 0
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizione.Size = New System.Drawing.Size(224, 20)
      Me.txtDescrizione.TabIndex = 1
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(24, 96)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(53, 13)
      Me.label.TabIndex = 169
      Me.label.Text = "Tipologia:"
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(24, 160)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(98, 13)
      Me.Label21.TabIndex = 168
      Me.Label21.Text = "Escludi dal plannig:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(24, 259)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(61, 13)
      Me.Label6.TabIndex = 165
      Me.Label6.Text = "Disponibile:"
      Me.Label6.Visible = False
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(24, 64)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(65, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Descrizione:"
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(128, 32)
      Me.txtNumero.MaxLength = 5
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(120, 20)
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
      Me.Label20.Location = New System.Drawing.Point(24, 32)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(43, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Codice:"
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(535, 328)
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
      Me.txtNote.Size = New System.Drawing.Size(535, 328)
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
      'frmRisorse
      '
      Me.AcceptButton = Me.ApriImg
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(538, 377)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmRisorse"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Risorse"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public ARisorsa As New Risorsa
   Private CFormatta As New ClsFormatta

   Const NOME_TABELLA As String = "Risorse"
   Const TAB_TIPOLOGIE As String = "Tipologie"

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
      AggiornaTabella(cmbTipologia, TAB_TIPOLOGIE)

      Try
         With ARisorsa
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Descrizione = FormattaApici(txtDescrizione.Text)
            .Tipologia = FormattaApici(cmbTipologia.Text)
            .Disponibile = cmbDisponibile.Text
            .Escludi = cmbEscludi.Text
            .TipoPlanning = FormattaApici(cmbTipoPlanning.Text)
            .Note = FormattaApici(txtNote.Text)

            If IsNumeric(txtCosto.Text) Then
               .Costo = CFormatta.FormattaEuro(txtCosto.Text)
            Else
               .Costo = "0,00"
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

   Private Sub ModificaColore()
      Try
         With ColorDialog1()
            .Color = cmdColore.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColore.BackColor = .Color
            End If

            ARisorsa.Colore = Convert.ToString(.Color.ToArgb)

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

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

            ARisorsa.Immagine = .FileName

         End With

         If File.Exists(ARisorsa.Immagine) = True Then
            Dim bmp As New Bitmap(ARisorsa.Immagine)
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
            ARisorsa.Immagine = ""
         End If

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

               If IsNothing(g_frmPlanningSport1) = False Then
                  ' Aggiorna il planning.
                  'g_frmPP.EliminaTutteRisorse()
                  'g_frmPP.LeggiDatiRisorse(NOME_TABELLA)
                  'g_frmPP.CaricaPrenotazioni()
                  'g_frmPP.InizializzaVariabili()
                  'g_frmPP.DisegnaPlanning()
                  g_frmPlanningSport1.Close()
                  g_frmMain.ApriPlanningP()
               End If

               If IsNothing(g_frmRisorse) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmRisorse.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & ARisorsa.Tipologia & " - " & ARisorsa.Descrizione & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_RISORSE)
            End If

         Case "Annulla"

            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_RISORSE)
      End Select
   End Sub

   Private Sub frmRisorse_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_RISORSE)
      End If
   End Sub

   Private Sub frmRisorse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With ARisorsa
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = .Codice
               txtDescrizione.Text = .Descrizione
               cmbTipologia.Text = .Tipologia
               txtCosto.Text = CFormatta.FormattaEuro(.Costo)
               cmbDisponibile.Text = .Disponibile
               cmbEscludi.Text = .Escludi
               cmbTipoPlanning.Text = .TipoPlanning
               txtNote.Text = .Note

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
               End If

               If .Immagine <> Nothing Then
                  If File.Exists(.Immagine) = True Then
                     Dim bmp As New Bitmap(.Immagine)
                     picFoto.Image = bmp
                  End If
               End If
            End With
         Else
            cmbDisponibile.SelectedIndex = 0
            cmbEscludi.SelectedIndex = 1
         End If

         ' Carica le liste.
         CaricaLista(cmbTipologia, TAB_TIPOLOGIE)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, txtDescrizione.Text, "")

         ' Se è aperto il planning il campo escludi dal planning viene disattivato
         ' per evitare problemi di aggiornamento e disegno della griglia.
         'If IsNothing(g_frmPP) = True Then
         '   cmbEscludi.Enabled = True
         'Else
         '   cmbEscludi.Enabled = False
         'End If

         ' Imposta lo stato attivo.
         txtDescrizione.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            Me.txtDescrizione.Focus()
         Case 1
            ' Imposta lo stato attivo.
            Me.txtNote.Focus()
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

   Private Sub txtCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCosto.TextChanged
      ConvalidaCampi(sender.Text, sender, ErrorProvider1)
   End Sub

   Private Sub txtCosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCosto.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub
End Class
