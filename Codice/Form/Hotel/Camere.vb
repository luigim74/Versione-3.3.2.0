' Nome form:            frmCamere
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/01/2005
' Data ultima modifica: 14/08/2014
' Descrizione:          Anagrafica Camere.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmCamere
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
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents Label34 As System.Windows.Forms.Label
   Public WithEvents label As System.Windows.Forms.Label
   Public WithEvents Label21 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents cmbDisponibile As System.Windows.Forms.ComboBox
   Friend WithEvents cmbEscludi As System.Windows.Forms.ComboBox
   Friend WithEvents cmbPosizione As System.Windows.Forms.ComboBox
   Friend WithEvents cmbUbicazione As System.Windows.Forms.ComboBox
   Friend WithEvents cmbTipologia As System.Windows.Forms.ComboBox
   Public WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmbListino As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents nudPostiLetto As System.Windows.Forms.NumericUpDown
   Friend WithEvents cmbEvidenzia As ComboBox
   Public WithEvents Label8 As Label
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCamere))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbEvidenzia = New System.Windows.Forms.ComboBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.nudPostiLetto = New System.Windows.Forms.NumericUpDown()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbListino = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbDisponibile = New System.Windows.Forms.ComboBox()
      Me.cmbEscludi = New System.Windows.Forms.ComboBox()
      Me.cmbPosizione = New System.Windows.Forms.ComboBox()
      Me.cmbUbicazione = New System.Windows.Forms.ComboBox()
      Me.cmbTipologia = New System.Windows.Forms.ComboBox()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.label = New System.Windows.Forms.Label()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.nudPostiLetto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage6.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.DimGray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(552, 20)
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
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(544, 320)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbEvidenzia)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.nudPostiLetto)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.cmbListino)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.cmdColore)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.cmbDisponibile)
      Me.TabPage1.Controls.Add(Me.cmbEscludi)
      Me.TabPage1.Controls.Add(Me.cmbPosizione)
      Me.TabPage1.Controls.Add(Me.cmbUbicazione)
      Me.TabPage1.Controls.Add(Me.cmbTipologia)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.Label34)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(536, 294)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'cmbEvidenzia
      '
      Me.cmbEvidenzia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEvidenzia.Items.AddRange(New Object() {"Sì", "No"})
      Me.cmbEvidenzia.Location = New System.Drawing.Point(414, 254)
      Me.cmbEvidenzia.Name = "cmbEvidenzia"
      Me.cmbEvidenzia.Size = New System.Drawing.Size(74, 21)
      Me.cmbEvidenzia.TabIndex = 11
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(255, 256)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(153, 13)
      Me.Label8.TabIndex = 189
      Me.Label8.Text = "Evidenzia periodo sul planning:"
      '
      'nudPostiLetto
      '
      Me.nudPostiLetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.nudPostiLetto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.nudPostiLetto.Location = New System.Drawing.Point(104, 192)
      Me.nudPostiLetto.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
      Me.nudPostiLetto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudPostiLetto.Name = "nudPostiLetto"
      Me.nudPostiLetto.Size = New System.Drawing.Size(80, 20)
      Me.nudPostiLetto.TabIndex = 6
      Me.nudPostiLetto.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(104, 24)
      Me.txtCodice.MaxLength = 5
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(80, 20)
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TabStop = False
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(24, 24)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(43, 13)
      Me.Label7.TabIndex = 187
      Me.Label7.Text = "Codice:"
      '
      'cmbListino
      '
      Me.cmbListino.Location = New System.Drawing.Point(352, 192)
      Me.cmbListino.Name = "cmbListino"
      Me.cmbListino.Size = New System.Drawing.Size(136, 21)
      Me.cmbListino.TabIndex = 7
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(255, 194)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(40, 13)
      Me.Label2.TabIndex = 185
      Me.Label2.Text = "Listino:"
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(104, 256)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(80, 19)
      Me.cmdColore.TabIndex = 10
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(24, 256)
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
      Me.cmbDisponibile.Location = New System.Drawing.Point(104, 224)
      Me.cmbDisponibile.Name = "cmbDisponibile"
      Me.cmbDisponibile.Size = New System.Drawing.Size(80, 21)
      Me.cmbDisponibile.TabIndex = 8
      '
      'cmbEscludi
      '
      Me.cmbEscludi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEscludi.Items.AddRange(New Object() {"Sì", "No"})
      Me.cmbEscludi.Location = New System.Drawing.Point(414, 224)
      Me.cmbEscludi.Name = "cmbEscludi"
      Me.cmbEscludi.Size = New System.Drawing.Size(74, 21)
      Me.cmbEscludi.TabIndex = 9
      '
      'cmbPosizione
      '
      Me.cmbPosizione.Location = New System.Drawing.Point(104, 160)
      Me.cmbPosizione.Name = "cmbPosizione"
      Me.cmbPosizione.Size = New System.Drawing.Size(384, 21)
      Me.cmbPosizione.TabIndex = 5
      '
      'cmbUbicazione
      '
      Me.cmbUbicazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUbicazione.Location = New System.Drawing.Point(104, 128)
      Me.cmbUbicazione.Name = "cmbUbicazione"
      Me.cmbUbicazione.Size = New System.Drawing.Size(384, 21)
      Me.cmbUbicazione.TabIndex = 4
      '
      'cmbTipologia
      '
      Me.cmbTipologia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipologia.Location = New System.Drawing.Point(104, 96)
      Me.cmbTipologia.Name = "cmbTipologia"
      Me.cmbTipologia.Size = New System.Drawing.Size(384, 21)
      Me.cmbTipologia.TabIndex = 3
      '
      'txtDescrizione
      '
      Me.txtDescrizione.AcceptsReturn = True
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizione.Location = New System.Drawing.Point(104, 56)
      Me.txtDescrizione.MaxLength = 0
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizione.Size = New System.Drawing.Size(384, 20)
      Me.txtDescrizione.TabIndex = 2
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.BackColor = System.Drawing.Color.Transparent
      Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label34.ForeColor = System.Drawing.Color.Black
      Me.Label34.Location = New System.Drawing.Point(24, 160)
      Me.Label34.Name = "Label34"
      Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label34.Size = New System.Drawing.Size(55, 13)
      Me.Label34.TabIndex = 171
      Me.Label34.Text = "Posizione:"
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
      Me.Label21.Location = New System.Drawing.Point(255, 224)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(104, 13)
      Me.Label21.TabIndex = 168
      Me.Label21.Text = "Escludi dal planning:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(24, 224)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(61, 13)
      Me.Label6.TabIndex = 165
      Me.Label6.Text = "Disponibile:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(24, 192)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(56, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Posti letto:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(24, 128)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(63, 13)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Ubicazione:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(24, 56)
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
      Me.txtNumero.Location = New System.Drawing.Point(352, 24)
      Me.txtNumero.MaxLength = 5
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(136, 20)
      Me.txtNumero.TabIndex = 1
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(288, 24)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(47, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Numero:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.EliminaImg)
      Me.TabPage2.Controls.Add(Me.ApriImg)
      Me.TabPage2.Controls.Add(Me.picFoto)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage2.Size = New System.Drawing.Size(536, 294)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Immagine"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(448, 264)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(72, 24)
      Me.EliminaImg.TabIndex = 1
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(368, 264)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(72, 24)
      Me.ApriImg.TabIndex = 0
      Me.ApriImg.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.Color.White
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(8, 8)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(520, 248)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 181
      Me.picFoto.TabStop = False
      '
      'TabPage6
      '
      Me.TabPage6.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(536, 294)
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
      Me.txtNote.Size = New System.Drawing.Size(536, 294)
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
      Me.ToolBar1.Size = New System.Drawing.Size(552, 26)
      Me.ToolBar1.TabIndex = 2
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
      'frmCamere
      '
      Me.AcceptButton = Me.ApriImg
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(552, 374)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Controls.Add(Me.TabControl1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmCamere"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Camere"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.nudPostiLetto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public ACamere As New Camera

   Const TAB_TIPOLOGIE As String = "TipologieCamere"
   Const TAB_UBICAZIONI As String = "UbicazioniCamere"
   Const TAB_POSIZIONI As String = "PosizioniCamere"
   Const TAB_LISTINI As String = "ListiniCamere"
   Const NOME_TABELLA As String = "Camere"

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
      AggiornaTabella(cmbUbicazione, TAB_UBICAZIONI)
      AggiornaTabella(cmbPosizione, TAB_POSIZIONI)
      AggiornaTabella(cmbListino, TAB_LISTINI)

      Try
         ' Assegna i dati dei campi della classe alle caselle di testo.
         ACamere.Numero = txtNumero.Text
         ACamere.Descrizione = txtDescrizione.Text
         ACamere.Tipologia = cmbTipologia.Text
         ACamere.Posizione = cmbPosizione.Text
         ACamere.Ubicazione = cmbUbicazione.Text
         ACamere.PostiLetto = nudPostiLetto.Value.ToString
         ACamere.Disponibile = cmbDisponibile.Text
         ACamere.Escludi = cmbEscludi.Text
         ACamere.Evidenzia = cmbEvidenzia.Text
         ACamere.Listino = cmbListino.Text
         ACamere.Note = txtNote.Text

         ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
         ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
         If Me.Tag <> "" Then
            Return ACamere.ModificaDati(NOME_TABELLA, Me.Tag)
         Else
            Return ACamere.InserisciDati(NOME_TABELLA)
         End If

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

            ACamere.Colore = Convert.ToString(.Color.ToArgb)

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

            ACamere.Immagine = .FileName

         End With

         If File.Exists(ACamere.Immagine) = True Then
            Dim bmp As New Bitmap(ACamere.Immagine)
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
            ACamere.Immagine = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmCamere_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            ' Visualizza i dati nei rispettivi campi.
            ACamere.LeggiDati(NOME_TABELLA, Me.Tag)

            ' Assegna i dati dei campi della classe alle caselle di testo.
            txtCodice.Text = ACamere.Codice
            txtNumero.Text = ACamere.Numero
            txtDescrizione.Text = ACamere.Descrizione
            cmbTipologia.Text = ACamere.Tipologia
            cmbPosizione.Text = ACamere.Posizione
            cmbUbicazione.Text = ACamere.Ubicazione
            nudPostiLetto.Value = Convert.ToDecimal(ACamere.PostiLetto)
            cmbDisponibile.Text = ACamere.Disponibile
            cmbEscludi.Text = ACamere.Escludi
            cmbEvidenzia.Text = ACamere.Evidenzia
            cmbListino.Text = ACamere.Listino
            txtNote.Text = ACamere.Note

            If ACamere.Colore <> 0 Then
               cmdColore.BackColor = Color.FromArgb(ACamere.Colore)
            End If

            If ACamere.Immagine <> Nothing Then
               If File.Exists(ACamere.Immagine) = True Then
                  Dim bmp As New Bitmap(ACamere.Immagine)
                  picFoto.Image = bmp
               End If
            End If
         Else
            cmbDisponibile.SelectedIndex = 0
            cmbEscludi.SelectedIndex = 1
            cmbEvidenzia.SelectedIndex = 1

            ACamere.Immagine = ""
         End If

         ' Carica le liste.
         CaricaLista(cmbTipologia, TAB_TIPOLOGIE)
         CaricaLista(cmbUbicazione, TAB_UBICAZIONI)
         CaricaLista(cmbPosizione, TAB_POSIZIONI)
         CaricaLista(cmbListino, TAB_LISTINI)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, txtDescrizione.Text, cmbPosizione.Text)

         ' Imposta il pulsante di default.
         ApriImg.NotifyDefault(True)

         ' Imposta lo stato attivo.
         txtNumero.Focus()

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
            txtNumero.Focus()
         Case 1
            ' Imposta lo stato attivo.
            picFoto.Focus()
         Case 2
            ' Imposta lo stato attivo.
            txtNote.Focus()
      End Select
   End Sub

   Private Sub txtPostiLetto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ConvalidaCampi(nudPostiLetto.Value.ToString, nudPostiLetto, ErrorProvider1)
   End Sub

   Private Sub cmdColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColore.Click
      ModificaColore()
   End Sub

   Private Sub ToolBar1_ButtonClick_1(sender As System.Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then
               ' Aggiorna la griglia dati.
               g_frmCamere.AggiornaDati()
               ' Chiude la finestra.
               Me.Close()
            End If

         Case "Annulla"
            ' Chiude la finestra.
            Me.Close()
      End Select

   End Sub

   Private Sub ApriImg_Click_1(sender As System.Object, e As System.EventArgs) Handles ApriImg.Click
      InserisciImmagine()
   End Sub

   Private Sub EliminaImg_Click_1(sender As System.Object, e As System.EventArgs) Handles EliminaImg.Click
      ApriImg.NotifyDefault(False)
      EliminaImmagine()
   End Sub
End Class
