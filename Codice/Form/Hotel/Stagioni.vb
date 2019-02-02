' Nome form:            frmCamere
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/01/2005
' Data ultima modifica: 14/08/2014
' Descrizione:          Anagrafica Camere.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmStagioni
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

   'NOTE: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Panel4 As System.Windows.Forms.Panel
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents cmbGiornoFine3_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine3_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoInizio3_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio3_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoFine2_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine2_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoInizio2_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio2_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoFine1_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine1_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents chkIntervallo3_Alta As System.Windows.Forms.CheckBox
   Friend WithEvents chkIntervallo2_Alta As System.Windows.Forms.CheckBox
   Friend WithEvents chkIntervallo1_Alta As System.Windows.Forms.CheckBox
   Friend WithEvents cmbGiornoInizio1_Alta As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio1_Alta As System.Windows.Forms.ComboBox
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cmbGiornoFine3_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine3_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoInizio3_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio3_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoFine2_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine2_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoInizio2_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio2_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoFine1_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine1_Media As System.Windows.Forms.ComboBox
   Friend WithEvents chkIntervallo3_Media As System.Windows.Forms.CheckBox
   Friend WithEvents chkIntervallo2_Media As System.Windows.Forms.CheckBox
   Friend WithEvents chkIntervallo1_Media As System.Windows.Forms.CheckBox
   Friend WithEvents cmbGiornoInizio1_Media As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio1_Media As System.Windows.Forms.ComboBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmbGiornoFine3_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine3_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoInizio3_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio3_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoFine2_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine2_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoInizio2_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio2_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbGiornoFine1_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseFine1_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents chkIntervallo3_Bassa As System.Windows.Forms.CheckBox
   Friend WithEvents chkIntervallo2_Bassa As System.Windows.Forms.CheckBox
   Friend WithEvents chkIntervallo1_Bassa As System.Windows.Forms.CheckBox
   Friend WithEvents cmbGiornoInizio1_Bassa As System.Windows.Forms.ComboBox
   Friend WithEvents cmbMeseInizio1_Bassa As System.Windows.Forms.ComboBox
   Public WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStagioni))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Panel4 = New System.Windows.Forms.Panel()
      Me.cmbGiornoFine3_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine3_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoInizio3_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio3_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoFine2_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine2_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoInizio2_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio2_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoFine1_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine1_Alta = New System.Windows.Forms.ComboBox()
      Me.chkIntervallo3_Alta = New System.Windows.Forms.CheckBox()
      Me.chkIntervallo2_Alta = New System.Windows.Forms.CheckBox()
      Me.chkIntervallo1_Alta = New System.Windows.Forms.CheckBox()
      Me.cmbGiornoInizio1_Alta = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio1_Alta = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.cmbGiornoFine3_Media = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine3_Media = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoInizio3_Media = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio3_Media = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoFine2_Media = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine2_Media = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoInizio2_Media = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio2_Media = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoFine1_Media = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine1_Media = New System.Windows.Forms.ComboBox()
      Me.chkIntervallo3_Media = New System.Windows.Forms.CheckBox()
      Me.chkIntervallo2_Media = New System.Windows.Forms.CheckBox()
      Me.chkIntervallo1_Media = New System.Windows.Forms.CheckBox()
      Me.cmbGiornoInizio1_Media = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio1_Media = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.cmbGiornoFine3_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine3_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoInizio3_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio3_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoFine2_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine2_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoInizio2_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio2_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbGiornoFine1_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbMeseFine1_Bassa = New System.Windows.Forms.ComboBox()
      Me.chkIntervallo3_Bassa = New System.Windows.Forms.CheckBox()
      Me.chkIntervallo2_Bassa = New System.Windows.Forms.CheckBox()
      Me.chkIntervallo1_Bassa = New System.Windows.Forms.CheckBox()
      Me.cmbGiornoInizio1_Bassa = New System.Windows.Forms.ComboBox()
      Me.cmbMeseInizio1_Bassa = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel4.SuspendLayout()
      Me.Panel3.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.DimGray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(493, 20)
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
      Me.ToolBar1.Size = New System.Drawing.Size(493, 26)
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
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(24, 416)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(113, 13)
      Me.Label12.TabIndex = 5
      Me.Label12.Text = "Intervalli Alta stagione:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(24, 240)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(124, 13)
      Me.Label11.TabIndex = 4
      Me.Label11.Text = "Intervalli Media stagione:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(24, 64)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(124, 13)
      Me.Label10.TabIndex = 3
      Me.Label10.Text = "Intervalli Bassa stagione:"
      '
      'Panel4
      '
      Me.Panel4.BackColor = System.Drawing.Color.LightCoral
      Me.Panel4.Controls.Add(Me.cmbGiornoFine3_Alta)
      Me.Panel4.Controls.Add(Me.cmbMeseFine3_Alta)
      Me.Panel4.Controls.Add(Me.cmbGiornoInizio3_Alta)
      Me.Panel4.Controls.Add(Me.cmbMeseInizio3_Alta)
      Me.Panel4.Controls.Add(Me.cmbGiornoFine2_Alta)
      Me.Panel4.Controls.Add(Me.cmbMeseFine2_Alta)
      Me.Panel4.Controls.Add(Me.cmbGiornoInizio2_Alta)
      Me.Panel4.Controls.Add(Me.cmbMeseInizio2_Alta)
      Me.Panel4.Controls.Add(Me.cmbGiornoFine1_Alta)
      Me.Panel4.Controls.Add(Me.cmbMeseFine1_Alta)
      Me.Panel4.Controls.Add(Me.chkIntervallo3_Alta)
      Me.Panel4.Controls.Add(Me.chkIntervallo2_Alta)
      Me.Panel4.Controls.Add(Me.chkIntervallo1_Alta)
      Me.Panel4.Controls.Add(Me.cmbGiornoInizio1_Alta)
      Me.Panel4.Controls.Add(Me.cmbMeseInizio1_Alta)
      Me.Panel4.Controls.Add(Me.Label4)
      Me.Panel4.Controls.Add(Me.Label5)
      Me.Panel4.Location = New System.Drawing.Point(24, 435)
      Me.Panel4.Name = "Panel4"
      Me.Panel4.Size = New System.Drawing.Size(448, 141)
      Me.Panel4.TabIndex = 2
      '
      'cmbGiornoFine3_Alta
      '
      Me.cmbGiornoFine3_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine3_Alta.Enabled = False
      Me.cmbGiornoFine3_Alta.FormattingEnabled = True
      Me.cmbGiornoFine3_Alta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine3_Alta.Location = New System.Drawing.Point(280, 104)
      Me.cmbGiornoFine3_Alta.Name = "cmbGiornoFine3_Alta"
      Me.cmbGiornoFine3_Alta.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine3_Alta.TabIndex = 13
      '
      'cmbMeseFine3_Alta
      '
      Me.cmbMeseFine3_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine3_Alta.Enabled = False
      Me.cmbMeseFine3_Alta.FormattingEnabled = True
      Me.cmbMeseFine3_Alta.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine3_Alta.Location = New System.Drawing.Point(336, 104)
      Me.cmbMeseFine3_Alta.Name = "cmbMeseFine3_Alta"
      Me.cmbMeseFine3_Alta.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine3_Alta.TabIndex = 14
      '
      'cmbGiornoInizio3_Alta
      '
      Me.cmbGiornoInizio3_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio3_Alta.Enabled = False
      Me.cmbGiornoInizio3_Alta.FormattingEnabled = True
      Me.cmbGiornoInizio3_Alta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio3_Alta.Location = New System.Drawing.Point(112, 104)
      Me.cmbGiornoInizio3_Alta.Name = "cmbGiornoInizio3_Alta"
      Me.cmbGiornoInizio3_Alta.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio3_Alta.TabIndex = 11
      '
      'cmbMeseInizio3_Alta
      '
      Me.cmbMeseInizio3_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio3_Alta.Enabled = False
      Me.cmbMeseInizio3_Alta.FormattingEnabled = True
      Me.cmbMeseInizio3_Alta.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio3_Alta.Location = New System.Drawing.Point(168, 104)
      Me.cmbMeseInizio3_Alta.Name = "cmbMeseInizio3_Alta"
      Me.cmbMeseInizio3_Alta.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio3_Alta.TabIndex = 12
      '
      'cmbGiornoFine2_Alta
      '
      Me.cmbGiornoFine2_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine2_Alta.Enabled = False
      Me.cmbGiornoFine2_Alta.FormattingEnabled = True
      Me.cmbGiornoFine2_Alta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine2_Alta.Location = New System.Drawing.Point(280, 72)
      Me.cmbGiornoFine2_Alta.Name = "cmbGiornoFine2_Alta"
      Me.cmbGiornoFine2_Alta.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine2_Alta.TabIndex = 8
      '
      'cmbMeseFine2_Alta
      '
      Me.cmbMeseFine2_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine2_Alta.Enabled = False
      Me.cmbMeseFine2_Alta.FormattingEnabled = True
      Me.cmbMeseFine2_Alta.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine2_Alta.Location = New System.Drawing.Point(336, 72)
      Me.cmbMeseFine2_Alta.Name = "cmbMeseFine2_Alta"
      Me.cmbMeseFine2_Alta.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine2_Alta.TabIndex = 9
      '
      'cmbGiornoInizio2_Alta
      '
      Me.cmbGiornoInizio2_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio2_Alta.Enabled = False
      Me.cmbGiornoInizio2_Alta.FormattingEnabled = True
      Me.cmbGiornoInizio2_Alta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio2_Alta.Location = New System.Drawing.Point(112, 72)
      Me.cmbGiornoInizio2_Alta.Name = "cmbGiornoInizio2_Alta"
      Me.cmbGiornoInizio2_Alta.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio2_Alta.TabIndex = 6
      '
      'cmbMeseInizio2_Alta
      '
      Me.cmbMeseInizio2_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio2_Alta.Enabled = False
      Me.cmbMeseInizio2_Alta.FormattingEnabled = True
      Me.cmbMeseInizio2_Alta.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio2_Alta.Location = New System.Drawing.Point(168, 72)
      Me.cmbMeseInizio2_Alta.Name = "cmbMeseInizio2_Alta"
      Me.cmbMeseInizio2_Alta.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio2_Alta.TabIndex = 7
      '
      'cmbGiornoFine1_Alta
      '
      Me.cmbGiornoFine1_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine1_Alta.Enabled = False
      Me.cmbGiornoFine1_Alta.FormattingEnabled = True
      Me.cmbGiornoFine1_Alta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine1_Alta.Location = New System.Drawing.Point(280, 40)
      Me.cmbGiornoFine1_Alta.Name = "cmbGiornoFine1_Alta"
      Me.cmbGiornoFine1_Alta.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine1_Alta.TabIndex = 3
      '
      'cmbMeseFine1_Alta
      '
      Me.cmbMeseFine1_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine1_Alta.Enabled = False
      Me.cmbMeseFine1_Alta.FormattingEnabled = True
      Me.cmbMeseFine1_Alta.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine1_Alta.Location = New System.Drawing.Point(336, 40)
      Me.cmbMeseFine1_Alta.Name = "cmbMeseFine1_Alta"
      Me.cmbMeseFine1_Alta.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine1_Alta.TabIndex = 4
      '
      'chkIntervallo3_Alta
      '
      Me.chkIntervallo3_Alta.AutoSize = True
      Me.chkIntervallo3_Alta.Location = New System.Drawing.Point(24, 104)
      Me.chkIntervallo3_Alta.Name = "chkIntervallo3_Alta"
      Me.chkIntervallo3_Alta.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo3_Alta.TabIndex = 10
      Me.chkIntervallo3_Alta.Text = "Intervallo 3:"
      Me.chkIntervallo3_Alta.UseVisualStyleBackColor = True
      '
      'chkIntervallo2_Alta
      '
      Me.chkIntervallo2_Alta.AutoSize = True
      Me.chkIntervallo2_Alta.Location = New System.Drawing.Point(24, 72)
      Me.chkIntervallo2_Alta.Name = "chkIntervallo2_Alta"
      Me.chkIntervallo2_Alta.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo2_Alta.TabIndex = 5
      Me.chkIntervallo2_Alta.Text = "Intervallo 2:"
      Me.chkIntervallo2_Alta.UseVisualStyleBackColor = True
      '
      'chkIntervallo1_Alta
      '
      Me.chkIntervallo1_Alta.AutoSize = True
      Me.chkIntervallo1_Alta.Location = New System.Drawing.Point(24, 40)
      Me.chkIntervallo1_Alta.Name = "chkIntervallo1_Alta"
      Me.chkIntervallo1_Alta.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo1_Alta.TabIndex = 0
      Me.chkIntervallo1_Alta.Text = "Intervallo 1:"
      Me.chkIntervallo1_Alta.UseVisualStyleBackColor = True
      '
      'cmbGiornoInizio1_Alta
      '
      Me.cmbGiornoInizio1_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio1_Alta.Enabled = False
      Me.cmbGiornoInizio1_Alta.FormattingEnabled = True
      Me.cmbGiornoInizio1_Alta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio1_Alta.Location = New System.Drawing.Point(112, 40)
      Me.cmbGiornoInizio1_Alta.Name = "cmbGiornoInizio1_Alta"
      Me.cmbGiornoInizio1_Alta.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio1_Alta.TabIndex = 1
      '
      'cmbMeseInizio1_Alta
      '
      Me.cmbMeseInizio1_Alta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio1_Alta.Enabled = False
      Me.cmbMeseInizio1_Alta.FormattingEnabled = True
      Me.cmbMeseInizio1_Alta.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio1_Alta.Location = New System.Drawing.Point(168, 40)
      Me.cmbMeseInizio1_Alta.Name = "cmbMeseInizio1_Alta"
      Me.cmbMeseInizio1_Alta.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio1_Alta.TabIndex = 2
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(280, 16)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 16
      Me.Label4.Text = "Data fine"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(112, 16)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(56, 13)
      Me.Label5.TabIndex = 15
      Me.Label5.Text = "Data inizio"
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.Khaki
      Me.Panel3.Controls.Add(Me.cmbGiornoFine3_Media)
      Me.Panel3.Controls.Add(Me.cmbMeseFine3_Media)
      Me.Panel3.Controls.Add(Me.cmbGiornoInizio3_Media)
      Me.Panel3.Controls.Add(Me.cmbMeseInizio3_Media)
      Me.Panel3.Controls.Add(Me.cmbGiornoFine2_Media)
      Me.Panel3.Controls.Add(Me.cmbMeseFine2_Media)
      Me.Panel3.Controls.Add(Me.cmbGiornoInizio2_Media)
      Me.Panel3.Controls.Add(Me.cmbMeseInizio2_Media)
      Me.Panel3.Controls.Add(Me.cmbGiornoFine1_Media)
      Me.Panel3.Controls.Add(Me.cmbMeseFine1_Media)
      Me.Panel3.Controls.Add(Me.chkIntervallo3_Media)
      Me.Panel3.Controls.Add(Me.chkIntervallo2_Media)
      Me.Panel3.Controls.Add(Me.chkIntervallo1_Media)
      Me.Panel3.Controls.Add(Me.cmbGiornoInizio1_Media)
      Me.Panel3.Controls.Add(Me.cmbMeseInizio1_Media)
      Me.Panel3.Controls.Add(Me.Label1)
      Me.Panel3.Controls.Add(Me.Label2)
      Me.Panel3.Location = New System.Drawing.Point(24, 259)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(448, 141)
      Me.Panel3.TabIndex = 1
      '
      'cmbGiornoFine3_Media
      '
      Me.cmbGiornoFine3_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine3_Media.Enabled = False
      Me.cmbGiornoFine3_Media.FormattingEnabled = True
      Me.cmbGiornoFine3_Media.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine3_Media.Location = New System.Drawing.Point(280, 104)
      Me.cmbGiornoFine3_Media.Name = "cmbGiornoFine3_Media"
      Me.cmbGiornoFine3_Media.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine3_Media.TabIndex = 13
      '
      'cmbMeseFine3_Media
      '
      Me.cmbMeseFine3_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine3_Media.Enabled = False
      Me.cmbMeseFine3_Media.FormattingEnabled = True
      Me.cmbMeseFine3_Media.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine3_Media.Location = New System.Drawing.Point(336, 104)
      Me.cmbMeseFine3_Media.Name = "cmbMeseFine3_Media"
      Me.cmbMeseFine3_Media.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine3_Media.TabIndex = 14
      '
      'cmbGiornoInizio3_Media
      '
      Me.cmbGiornoInizio3_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio3_Media.Enabled = False
      Me.cmbGiornoInizio3_Media.FormattingEnabled = True
      Me.cmbGiornoInizio3_Media.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio3_Media.Location = New System.Drawing.Point(112, 104)
      Me.cmbGiornoInizio3_Media.Name = "cmbGiornoInizio3_Media"
      Me.cmbGiornoInizio3_Media.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio3_Media.TabIndex = 11
      '
      'cmbMeseInizio3_Media
      '
      Me.cmbMeseInizio3_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio3_Media.Enabled = False
      Me.cmbMeseInizio3_Media.FormattingEnabled = True
      Me.cmbMeseInizio3_Media.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio3_Media.Location = New System.Drawing.Point(168, 104)
      Me.cmbMeseInizio3_Media.Name = "cmbMeseInizio3_Media"
      Me.cmbMeseInizio3_Media.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio3_Media.TabIndex = 12
      '
      'cmbGiornoFine2_Media
      '
      Me.cmbGiornoFine2_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine2_Media.Enabled = False
      Me.cmbGiornoFine2_Media.FormattingEnabled = True
      Me.cmbGiornoFine2_Media.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine2_Media.Location = New System.Drawing.Point(280, 72)
      Me.cmbGiornoFine2_Media.Name = "cmbGiornoFine2_Media"
      Me.cmbGiornoFine2_Media.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine2_Media.TabIndex = 8
      '
      'cmbMeseFine2_Media
      '
      Me.cmbMeseFine2_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine2_Media.Enabled = False
      Me.cmbMeseFine2_Media.FormattingEnabled = True
      Me.cmbMeseFine2_Media.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine2_Media.Location = New System.Drawing.Point(336, 72)
      Me.cmbMeseFine2_Media.Name = "cmbMeseFine2_Media"
      Me.cmbMeseFine2_Media.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine2_Media.TabIndex = 9
      '
      'cmbGiornoInizio2_Media
      '
      Me.cmbGiornoInizio2_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio2_Media.Enabled = False
      Me.cmbGiornoInizio2_Media.FormattingEnabled = True
      Me.cmbGiornoInizio2_Media.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio2_Media.Location = New System.Drawing.Point(112, 72)
      Me.cmbGiornoInizio2_Media.Name = "cmbGiornoInizio2_Media"
      Me.cmbGiornoInizio2_Media.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio2_Media.TabIndex = 6
      '
      'cmbMeseInizio2_Media
      '
      Me.cmbMeseInizio2_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio2_Media.Enabled = False
      Me.cmbMeseInizio2_Media.FormattingEnabled = True
      Me.cmbMeseInizio2_Media.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio2_Media.Location = New System.Drawing.Point(168, 72)
      Me.cmbMeseInizio2_Media.Name = "cmbMeseInizio2_Media"
      Me.cmbMeseInizio2_Media.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio2_Media.TabIndex = 7
      '
      'cmbGiornoFine1_Media
      '
      Me.cmbGiornoFine1_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine1_Media.Enabled = False
      Me.cmbGiornoFine1_Media.FormattingEnabled = True
      Me.cmbGiornoFine1_Media.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine1_Media.Location = New System.Drawing.Point(280, 40)
      Me.cmbGiornoFine1_Media.Name = "cmbGiornoFine1_Media"
      Me.cmbGiornoFine1_Media.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine1_Media.TabIndex = 3
      '
      'cmbMeseFine1_Media
      '
      Me.cmbMeseFine1_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine1_Media.Enabled = False
      Me.cmbMeseFine1_Media.FormattingEnabled = True
      Me.cmbMeseFine1_Media.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine1_Media.Location = New System.Drawing.Point(336, 40)
      Me.cmbMeseFine1_Media.Name = "cmbMeseFine1_Media"
      Me.cmbMeseFine1_Media.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine1_Media.TabIndex = 4
      '
      'chkIntervallo3_Media
      '
      Me.chkIntervallo3_Media.AutoSize = True
      Me.chkIntervallo3_Media.Location = New System.Drawing.Point(24, 104)
      Me.chkIntervallo3_Media.Name = "chkIntervallo3_Media"
      Me.chkIntervallo3_Media.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo3_Media.TabIndex = 10
      Me.chkIntervallo3_Media.Text = "Intervallo 3:"
      Me.chkIntervallo3_Media.UseVisualStyleBackColor = True
      '
      'chkIntervallo2_Media
      '
      Me.chkIntervallo2_Media.AutoSize = True
      Me.chkIntervallo2_Media.Location = New System.Drawing.Point(24, 72)
      Me.chkIntervallo2_Media.Name = "chkIntervallo2_Media"
      Me.chkIntervallo2_Media.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo2_Media.TabIndex = 5
      Me.chkIntervallo2_Media.Text = "Intervallo 2:"
      Me.chkIntervallo2_Media.UseVisualStyleBackColor = True
      '
      'chkIntervallo1_Media
      '
      Me.chkIntervallo1_Media.AutoSize = True
      Me.chkIntervallo1_Media.Location = New System.Drawing.Point(24, 40)
      Me.chkIntervallo1_Media.Name = "chkIntervallo1_Media"
      Me.chkIntervallo1_Media.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo1_Media.TabIndex = 0
      Me.chkIntervallo1_Media.Text = "Intervallo 1:"
      Me.chkIntervallo1_Media.UseVisualStyleBackColor = True
      '
      'cmbGiornoInizio1_Media
      '
      Me.cmbGiornoInizio1_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio1_Media.Enabled = False
      Me.cmbGiornoInizio1_Media.FormattingEnabled = True
      Me.cmbGiornoInizio1_Media.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio1_Media.Location = New System.Drawing.Point(112, 40)
      Me.cmbGiornoInizio1_Media.Name = "cmbGiornoInizio1_Media"
      Me.cmbGiornoInizio1_Media.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio1_Media.TabIndex = 1
      '
      'cmbMeseInizio1_Media
      '
      Me.cmbMeseInizio1_Media.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio1_Media.Enabled = False
      Me.cmbMeseInizio1_Media.FormattingEnabled = True
      Me.cmbMeseInizio1_Media.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio1_Media.Location = New System.Drawing.Point(168, 40)
      Me.cmbMeseInizio1_Media.Name = "cmbMeseInizio1_Media"
      Me.cmbMeseInizio1_Media.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio1_Media.TabIndex = 2
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(280, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(50, 13)
      Me.Label1.TabIndex = 16
      Me.Label1.Text = "Data fine"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(112, 16)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(56, 13)
      Me.Label2.TabIndex = 15
      Me.Label2.Text = "Data inizio"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.LightGreen
      Me.Panel2.Controls.Add(Me.cmbGiornoFine3_Bassa)
      Me.Panel2.Controls.Add(Me.cmbMeseFine3_Bassa)
      Me.Panel2.Controls.Add(Me.cmbGiornoInizio3_Bassa)
      Me.Panel2.Controls.Add(Me.cmbMeseInizio3_Bassa)
      Me.Panel2.Controls.Add(Me.cmbGiornoFine2_Bassa)
      Me.Panel2.Controls.Add(Me.cmbMeseFine2_Bassa)
      Me.Panel2.Controls.Add(Me.cmbGiornoInizio2_Bassa)
      Me.Panel2.Controls.Add(Me.cmbMeseInizio2_Bassa)
      Me.Panel2.Controls.Add(Me.cmbGiornoFine1_Bassa)
      Me.Panel2.Controls.Add(Me.cmbMeseFine1_Bassa)
      Me.Panel2.Controls.Add(Me.chkIntervallo3_Bassa)
      Me.Panel2.Controls.Add(Me.chkIntervallo2_Bassa)
      Me.Panel2.Controls.Add(Me.chkIntervallo1_Bassa)
      Me.Panel2.Controls.Add(Me.cmbGiornoInizio1_Bassa)
      Me.Panel2.Controls.Add(Me.cmbMeseInizio1_Bassa)
      Me.Panel2.Controls.Add(Me.Label3)
      Me.Panel2.Controls.Add(Me.Label17)
      Me.Panel2.Location = New System.Drawing.Point(24, 83)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(448, 141)
      Me.Panel2.TabIndex = 0
      '
      'cmbGiornoFine3_Bassa
      '
      Me.cmbGiornoFine3_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine3_Bassa.Enabled = False
      Me.cmbGiornoFine3_Bassa.FormattingEnabled = True
      Me.cmbGiornoFine3_Bassa.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine3_Bassa.Location = New System.Drawing.Point(280, 104)
      Me.cmbGiornoFine3_Bassa.Name = "cmbGiornoFine3_Bassa"
      Me.cmbGiornoFine3_Bassa.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine3_Bassa.TabIndex = 13
      '
      'cmbMeseFine3_Bassa
      '
      Me.cmbMeseFine3_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine3_Bassa.Enabled = False
      Me.cmbMeseFine3_Bassa.FormattingEnabled = True
      Me.cmbMeseFine3_Bassa.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine3_Bassa.Location = New System.Drawing.Point(336, 104)
      Me.cmbMeseFine3_Bassa.Name = "cmbMeseFine3_Bassa"
      Me.cmbMeseFine3_Bassa.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine3_Bassa.TabIndex = 14
      '
      'cmbGiornoInizio3_Bassa
      '
      Me.cmbGiornoInizio3_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio3_Bassa.Enabled = False
      Me.cmbGiornoInizio3_Bassa.FormattingEnabled = True
      Me.cmbGiornoInizio3_Bassa.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio3_Bassa.Location = New System.Drawing.Point(112, 104)
      Me.cmbGiornoInizio3_Bassa.Name = "cmbGiornoInizio3_Bassa"
      Me.cmbGiornoInizio3_Bassa.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio3_Bassa.TabIndex = 11
      '
      'cmbMeseInizio3_Bassa
      '
      Me.cmbMeseInizio3_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio3_Bassa.Enabled = False
      Me.cmbMeseInizio3_Bassa.FormattingEnabled = True
      Me.cmbMeseInizio3_Bassa.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio3_Bassa.Location = New System.Drawing.Point(168, 104)
      Me.cmbMeseInizio3_Bassa.Name = "cmbMeseInizio3_Bassa"
      Me.cmbMeseInizio3_Bassa.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio3_Bassa.TabIndex = 12
      '
      'cmbGiornoFine2_Bassa
      '
      Me.cmbGiornoFine2_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine2_Bassa.Enabled = False
      Me.cmbGiornoFine2_Bassa.FormattingEnabled = True
      Me.cmbGiornoFine2_Bassa.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine2_Bassa.Location = New System.Drawing.Point(280, 72)
      Me.cmbGiornoFine2_Bassa.Name = "cmbGiornoFine2_Bassa"
      Me.cmbGiornoFine2_Bassa.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine2_Bassa.TabIndex = 8
      '
      'cmbMeseFine2_Bassa
      '
      Me.cmbMeseFine2_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine2_Bassa.Enabled = False
      Me.cmbMeseFine2_Bassa.FormattingEnabled = True
      Me.cmbMeseFine2_Bassa.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine2_Bassa.Location = New System.Drawing.Point(336, 72)
      Me.cmbMeseFine2_Bassa.Name = "cmbMeseFine2_Bassa"
      Me.cmbMeseFine2_Bassa.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine2_Bassa.TabIndex = 9
      '
      'cmbGiornoInizio2_Bassa
      '
      Me.cmbGiornoInizio2_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio2_Bassa.Enabled = False
      Me.cmbGiornoInizio2_Bassa.FormattingEnabled = True
      Me.cmbGiornoInizio2_Bassa.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio2_Bassa.Location = New System.Drawing.Point(112, 72)
      Me.cmbGiornoInizio2_Bassa.Name = "cmbGiornoInizio2_Bassa"
      Me.cmbGiornoInizio2_Bassa.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio2_Bassa.TabIndex = 6
      '
      'cmbMeseInizio2_Bassa
      '
      Me.cmbMeseInizio2_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio2_Bassa.Enabled = False
      Me.cmbMeseInizio2_Bassa.FormattingEnabled = True
      Me.cmbMeseInizio2_Bassa.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio2_Bassa.Location = New System.Drawing.Point(168, 72)
      Me.cmbMeseInizio2_Bassa.Name = "cmbMeseInizio2_Bassa"
      Me.cmbMeseInizio2_Bassa.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio2_Bassa.TabIndex = 7
      '
      'cmbGiornoFine1_Bassa
      '
      Me.cmbGiornoFine1_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoFine1_Bassa.Enabled = False
      Me.cmbGiornoFine1_Bassa.FormattingEnabled = True
      Me.cmbGiornoFine1_Bassa.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoFine1_Bassa.Location = New System.Drawing.Point(280, 40)
      Me.cmbGiornoFine1_Bassa.Name = "cmbGiornoFine1_Bassa"
      Me.cmbGiornoFine1_Bassa.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoFine1_Bassa.TabIndex = 3
      '
      'cmbMeseFine1_Bassa
      '
      Me.cmbMeseFine1_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseFine1_Bassa.Enabled = False
      Me.cmbMeseFine1_Bassa.FormattingEnabled = True
      Me.cmbMeseFine1_Bassa.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseFine1_Bassa.Location = New System.Drawing.Point(336, 40)
      Me.cmbMeseFine1_Bassa.Name = "cmbMeseFine1_Bassa"
      Me.cmbMeseFine1_Bassa.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseFine1_Bassa.TabIndex = 4
      '
      'chkIntervallo3_Bassa
      '
      Me.chkIntervallo3_Bassa.AutoSize = True
      Me.chkIntervallo3_Bassa.Location = New System.Drawing.Point(24, 104)
      Me.chkIntervallo3_Bassa.Name = "chkIntervallo3_Bassa"
      Me.chkIntervallo3_Bassa.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo3_Bassa.TabIndex = 10
      Me.chkIntervallo3_Bassa.Text = "Intervallo 3:"
      Me.chkIntervallo3_Bassa.UseVisualStyleBackColor = True
      '
      'chkIntervallo2_Bassa
      '
      Me.chkIntervallo2_Bassa.AutoSize = True
      Me.chkIntervallo2_Bassa.Location = New System.Drawing.Point(24, 72)
      Me.chkIntervallo2_Bassa.Name = "chkIntervallo2_Bassa"
      Me.chkIntervallo2_Bassa.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo2_Bassa.TabIndex = 5
      Me.chkIntervallo2_Bassa.Text = "Intervallo 2:"
      Me.chkIntervallo2_Bassa.UseVisualStyleBackColor = True
      '
      'chkIntervallo1_Bassa
      '
      Me.chkIntervallo1_Bassa.AutoSize = True
      Me.chkIntervallo1_Bassa.Location = New System.Drawing.Point(24, 40)
      Me.chkIntervallo1_Bassa.Name = "chkIntervallo1_Bassa"
      Me.chkIntervallo1_Bassa.Size = New System.Drawing.Size(81, 17)
      Me.chkIntervallo1_Bassa.TabIndex = 0
      Me.chkIntervallo1_Bassa.Text = "Intervallo 1:"
      Me.chkIntervallo1_Bassa.UseVisualStyleBackColor = True
      '
      'cmbGiornoInizio1_Bassa
      '
      Me.cmbGiornoInizio1_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGiornoInizio1_Bassa.Enabled = False
      Me.cmbGiornoInizio1_Bassa.FormattingEnabled = True
      Me.cmbGiornoInizio1_Bassa.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
      Me.cmbGiornoInizio1_Bassa.Location = New System.Drawing.Point(112, 40)
      Me.cmbGiornoInizio1_Bassa.Name = "cmbGiornoInizio1_Bassa"
      Me.cmbGiornoInizio1_Bassa.Size = New System.Drawing.Size(48, 21)
      Me.cmbGiornoInizio1_Bassa.TabIndex = 1
      '
      'cmbMeseInizio1_Bassa
      '
      Me.cmbMeseInizio1_Bassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMeseInizio1_Bassa.Enabled = False
      Me.cmbMeseInizio1_Bassa.FormattingEnabled = True
      Me.cmbMeseInizio1_Bassa.Items.AddRange(New Object() {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"})
      Me.cmbMeseInizio1_Bassa.Location = New System.Drawing.Point(168, 40)
      Me.cmbMeseInizio1_Bassa.Name = "cmbMeseInizio1_Bassa"
      Me.cmbMeseInizio1_Bassa.Size = New System.Drawing.Size(88, 21)
      Me.cmbMeseInizio1_Bassa.TabIndex = 2
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(280, 16)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(50, 13)
      Me.Label3.TabIndex = 16
      Me.Label3.Text = "Data fine"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(112, 16)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(56, 13)
      Me.Label17.TabIndex = 15
      Me.Label17.Text = "Data inizio"
      '
      'frmStagioni
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(493, 594)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.Panel4)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmStagioni"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Stagioni"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel4.ResumeLayout(False)
      Me.Panel4.PerformLayout()
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Const NOME_TABELLA As String = "Stagioni"

   Public AStagioni As New Stagioni

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

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
         With AStagioni
            ' Assegna i dati dei campi della classe alle caselle di testo.

            ' Bassa Stagione
            If chkIntervallo1_Bassa.Checked = True Then
               If cmbGiornoInizio1_Bassa.Text = String.Empty Or cmbMeseInizio1_Bassa.Text = String.Empty Or
                  cmbGiornoFine1_Bassa.Text = String.Empty Or cmbMeseFine1_Bassa.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 1 di Bassa stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio1_Bassa = cmbGiornoInizio1_Bassa.Text & " " & cmbMeseInizio1_Bassa.Text
                  .DataFine1_Bassa = cmbGiornoFine1_Bassa.Text & " " & cmbMeseFine1_Bassa.Text
               End If
            Else
               .DataInizio1_Bassa = String.Empty
               .DataFine1_Bassa = String.Empty
            End If

            If chkIntervallo2_Bassa.Checked = True Then
               If cmbGiornoInizio2_Bassa.Text = String.Empty Or cmbMeseInizio2_Bassa.Text = String.Empty Or
                  cmbGiornoFine2_Bassa.Text = String.Empty Or cmbMeseFine2_Bassa.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 2 di Bassa stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio2_Bassa = cmbGiornoInizio2_Bassa.Text & " " & cmbMeseInizio2_Bassa.Text
                  .DataFine2_Bassa = cmbGiornoFine2_Bassa.Text & " " & cmbMeseFine2_Bassa.Text
               End If
            Else
               .DataInizio2_Bassa = String.Empty
               .DataFine2_Bassa = String.Empty
            End If

            If chkIntervallo3_Bassa.Checked = True Then
               If cmbGiornoInizio3_Bassa.Text = String.Empty Or cmbMeseInizio3_Bassa.Text = String.Empty Or
                  cmbGiornoFine3_Bassa.Text = String.Empty Or cmbMeseFine3_Bassa.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 3 di Bassa stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio3_Bassa = cmbGiornoInizio3_Bassa.Text & " " & cmbMeseInizio3_Bassa.Text
                  .DataFine3_Bassa = cmbGiornoFine3_Bassa.Text & " " & cmbMeseFine3_Bassa.Text
               End If
            Else
               .DataInizio3_Bassa = String.Empty
               .DataFine3_Bassa = String.Empty
            End If

               ' Media Stagione
            If chkIntervallo1_Media.Checked = True Then
               If cmbGiornoInizio1_Media.Text = String.Empty Or cmbMeseInizio1_Media.Text = String.Empty Or
                  cmbGiornoFine1_Media.Text = String.Empty Or cmbMeseFine1_Media.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 1 di Media stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio1_Media = cmbGiornoInizio1_Media.Text & " " & cmbMeseInizio1_Media.Text
                  .DataFine1_Media = cmbGiornoFine1_Media.Text & " " & cmbMeseFine1_Media.Text
               End If
            Else
               .DataInizio1_Media = String.Empty
               .DataFine1_Media = String.Empty
            End If

            If chkIntervallo2_Media.Checked = True Then
               If cmbGiornoInizio2_Media.Text = String.Empty Or cmbMeseInizio2_Media.Text = String.Empty Or
                  cmbGiornoFine2_Media.Text = String.Empty Or cmbMeseFine2_Media.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 2 di Media stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio2_Media = cmbGiornoInizio2_Media.Text & " " & cmbMeseInizio2_Media.Text
                  .DataFine2_Media = cmbGiornoFine2_Media.Text & " " & cmbMeseFine2_Media.Text
               End If
            Else
               .DataInizio2_Media = String.Empty
               .DataFine2_Media = String.Empty
            End If

            If chkIntervallo3_Media.Checked = True Then
               If cmbGiornoInizio3_Media.Text = String.Empty Or cmbMeseInizio3_Media.Text = String.Empty Or
                  cmbGiornoFine3_Media.Text = String.Empty Or cmbMeseFine3_Media.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 3 di Media stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio3_Media = cmbGiornoInizio3_Media.Text & " " & cmbMeseInizio3_Media.Text
                  .DataFine3_Media = cmbGiornoFine3_Media.Text & " " & cmbMeseFine3_Media.Text
               End If
            Else
               .DataInizio3_Media = String.Empty
               .DataFine3_Media = String.Empty
            End If

               ' Alta Stagione
            If chkIntervallo1_Alta.Checked = True Then
               If cmbGiornoInizio1_Alta.Text = String.Empty Or cmbMeseInizio1_Alta.Text = String.Empty Or
                  cmbGiornoFine1_Alta.Text = String.Empty Or cmbMeseFine1_Alta.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 1 di Alta stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio1_Alta = cmbGiornoInizio1_Alta.Text & " " & cmbMeseInizio1_Alta.Text
                  .DataFine1_Alta = cmbGiornoFine1_Alta.Text & " " & cmbMeseFine1_Alta.Text
               End If
            Else
               .DataInizio1_Alta = String.Empty
               .DataFine1_Alta = String.Empty
            End If

            If chkIntervallo2_Alta.Checked = True Then
               If cmbGiornoInizio2_Alta.Text = String.Empty Or cmbMeseInizio2_Alta.Text = String.Empty Or
                  cmbGiornoFine2_Alta.Text = String.Empty Or cmbMeseFine2_Alta.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 2 di Alta stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio2_Alta = cmbGiornoInizio2_Alta.Text & " " & cmbMeseInizio2_Alta.Text
                  .DataFine2_Alta = cmbGiornoFine2_Alta.Text & " " & cmbMeseFine2_Alta.Text
               End If
            Else
               .DataInizio2_Alta = String.Empty
               .DataFine2_Alta = String.Empty
            End If

            If chkIntervallo3_Alta.Checked = True Then
               If cmbGiornoInizio3_Alta.Text = String.Empty Or cmbMeseInizio3_Alta.Text = String.Empty Or
                  cmbGiornoFine3_Alta.Text = String.Empty Or cmbMeseFine3_Alta.Text = String.Empty Then

                  MessageBox.Show("Uno o più campi dell'Intervallo 3 di Alta stagione non sono stati specificati! Inserire i valori o deselezionare l'intervallo di date.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  .DataInizio3_Alta = cmbGiornoInizio3_Alta.Text & " " & cmbMeseInizio3_Alta.Text
                  .DataFine3_Alta = cmbGiornoFine3_Alta.Text & " " & cmbMeseFine3_Alta.Text
               End If
            Else
               .DataInizio3_Alta = String.Empty
               .DataFine3_Alta = String.Empty
            End If

            ' Richiamata la procedura di modifica dati.
            Return .ModificaDati(NOME_TABELLA, .Codice)

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   ' A_TODO: HOTEL - da modificare!
   Private Sub frmStagioni_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Distrugge l'oggetto e libera le risorse.
         g_frmStagioni.Dispose()
         g_frmStagioni = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         ' g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

         If Me.Tag <> "0" Then
            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CLIENTI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmStagioni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(STAGIONI_LARGHEZZA, STAGIONI_ALTEZZA)

         With AStagioni

            ' Visualizza i dati nei rispettivi campi.
            .LeggiDati(NOME_TABELLA)

            ' Assegna i dati dei campi della classe alle caselle di testo.

            ' Bassa Stagione
            If .DataInizio1_Bassa = String.Empty And .DataFine1_Bassa = String.Empty Then
               cmbGiornoInizio1_Bassa.Text = String.Empty
               cmbMeseInizio1_Bassa.Text = String.Empty
               cmbGiornoFine1_Bassa.Text = String.Empty
               cmbMeseFine1_Bassa.Text = String.Empty
               chkIntervallo1_Bassa.Checked = False
            Else
               chkIntervallo1_Bassa.Checked = True
               Dim valInizio() As String = .DataInizio1_Bassa.Split(" ")
               Dim valFine() As String = .DataFine1_Bassa.Split(" ")
               cmbGiornoInizio1_Bassa.Text = valInizio(0)
               cmbMeseInizio1_Bassa.Text = valInizio(1)
               cmbGiornoFine1_Bassa.Text = valFine(0)
               cmbMeseFine1_Bassa.Text = valFine(1)
            End If

            If .DataInizio2_Bassa = String.Empty And .DataFine2_Bassa = String.Empty Then
               cmbGiornoInizio2_Bassa.Text = String.Empty
               cmbMeseInizio2_Bassa.Text = String.Empty
               cmbGiornoFine2_Bassa.Text = String.Empty
               cmbMeseFine2_Bassa.Text = String.Empty
               chkIntervallo2_Bassa.Checked = False
            Else
               chkIntervallo2_Bassa.Checked = True
               Dim valInizio() As String = .DataInizio2_Bassa.Split(" ")
               Dim valFine() As String = .DataFine2_Bassa.Split(" ")
               cmbGiornoInizio2_Bassa.Text = valInizio(0)
               cmbMeseInizio2_Bassa.Text = valInizio(1)
               cmbGiornoFine2_Bassa.Text = valFine(0)
               cmbMeseFine2_Bassa.Text = valFine(1)
            End If

            If .DataInizio3_Bassa = String.Empty And .DataFine3_Bassa = String.Empty Then
               cmbGiornoInizio3_Bassa.Text = String.Empty
               cmbMeseInizio3_Bassa.Text = String.Empty
               cmbGiornoFine3_Bassa.Text = String.Empty
               cmbMeseFine3_Bassa.Text = String.Empty
               chkIntervallo3_Bassa.Checked = False
            Else
               chkIntervallo3_Bassa.Checked = True
               Dim valInizio() As String = .DataInizio3_Bassa.Split(" ")
               Dim valFine() As String = .DataFine3_Bassa.Split(" ")
               cmbGiornoInizio3_Bassa.Text = valInizio(0)
               cmbMeseInizio3_Bassa.Text = valInizio(1)
               cmbGiornoFine3_Bassa.Text = valFine(0)
               cmbMeseFine3_Bassa.Text = valFine(1)
            End If


            ' Media Stagione
            If .DataInizio1_Media = String.Empty And .DataFine1_Media = String.Empty Then
               cmbGiornoInizio1_Media.Text = String.Empty
               cmbMeseInizio1_Media.Text = String.Empty
               cmbGiornoFine1_Media.Text = String.Empty
               cmbMeseFine1_Media.Text = String.Empty
               chkIntervallo1_Media.Checked = False
            Else
               chkIntervallo1_Media.Checked = True
               Dim valInizio() As String = .DataInizio1_Media.Split(" ")
               Dim valFine() As String = .DataFine1_Media.Split(" ")
               cmbGiornoInizio1_Media.Text = valInizio(0)
               cmbMeseInizio1_Media.Text = valInizio(1)
               cmbGiornoFine1_Media.Text = valFine(0)
               cmbMeseFine1_Media.Text = valFine(1)
            End If

            If .DataInizio2_Media = String.Empty And .DataFine2_Media = String.Empty Then
               cmbGiornoInizio2_Media.Text = String.Empty
               cmbMeseInizio2_Media.Text = String.Empty
               cmbGiornoFine2_Media.Text = String.Empty
               cmbMeseFine2_Media.Text = String.Empty
               chkIntervallo2_Media.Checked = False
            Else
               chkIntervallo2_Media.Checked = True
               Dim valInizio() As String = .DataInizio2_Media.Split(" ")
               Dim valFine() As String = .DataFine2_Media.Split(" ")
               cmbGiornoInizio2_Media.Text = valInizio(0)
               cmbMeseInizio2_Media.Text = valInizio(1)
               cmbGiornoFine2_Media.Text = valFine(0)
               cmbMeseFine2_Media.Text = valFine(1)
            End If

            If .DataInizio3_Media = String.Empty And .DataFine3_Media = String.Empty Then
               cmbGiornoInizio3_Media.Text = String.Empty
               cmbMeseInizio3_Media.Text = String.Empty
               cmbGiornoFine3_Media.Text = String.Empty
               cmbMeseFine3_Media.Text = String.Empty
               chkIntervallo3_Media.Checked = False
            Else
               chkIntervallo3_Media.Checked = True
               Dim valInizio() As String = .DataInizio3_Media.Split(" ")
               Dim valFine() As String = .DataFine3_Media.Split(" ")
               cmbGiornoInizio3_Media.Text = valInizio(0)
               cmbMeseInizio3_Media.Text = valInizio(1)
               cmbGiornoFine3_Media.Text = valFine(0)
               cmbMeseFine3_Media.Text = valFine(1)
            End If

            ' Alta Stagione
            If .DataInizio1_Alta = String.Empty And .DataFine1_Alta = String.Empty Then
               cmbGiornoInizio1_Alta.Text = String.Empty
               cmbMeseInizio1_Alta.Text = String.Empty
               cmbGiornoFine1_Alta.Text = String.Empty
               cmbMeseFine1_Alta.Text = String.Empty
               chkIntervallo1_Alta.Checked = False
            Else
               chkIntervallo1_Alta.Checked = True
               Dim valInizio() As String = .DataInizio1_Alta.Split(" ")
               Dim valFine() As String = .DataFine1_Alta.Split(" ")
               cmbGiornoInizio1_Alta.Text = valInizio(0)
               cmbMeseInizio1_Alta.Text = valInizio(1)
               cmbGiornoFine1_Alta.Text = valFine(0)
               cmbMeseFine1_Alta.Text = valFine(1)
            End If

            If .DataInizio2_Alta = String.Empty And .DataFine2_Alta = String.Empty Then
               cmbGiornoInizio2_Alta.Text = String.Empty
               cmbMeseInizio2_Alta.Text = String.Empty
               cmbGiornoFine2_Alta.Text = String.Empty
               cmbMeseFine2_Alta.Text = String.Empty
               chkIntervallo2_Alta.Checked = False
            Else
               chkIntervallo2_Alta.Checked = True
               Dim valInizio() As String = .DataInizio2_Alta.Split(" ")
               Dim valFine() As String = .DataFine2_Alta.Split(" ")
               cmbGiornoInizio2_Alta.Text = valInizio(0)
               cmbMeseInizio2_Alta.Text = valInizio(1)
               cmbGiornoFine2_Alta.Text = valFine(0)
               cmbMeseFine2_Alta.Text = valFine(1)
            End If

            If .DataInizio3_Alta = String.Empty And .DataFine3_Alta = String.Empty Then
               cmbGiornoInizio3_Alta.Text = String.Empty
               cmbMeseInizio3_Alta.Text = String.Empty
               cmbGiornoFine3_Alta.Text = String.Empty
               cmbMeseFine3_Alta.Text = String.Empty
               chkIntervallo3_Alta.Checked = False
            Else
               chkIntervallo3_Alta.Checked = True
               Dim valInizio() As String = .DataInizio3_Alta.Split(" ")
               Dim valFine() As String = .DataFine3_Alta.Split(" ")
               cmbGiornoInizio3_Alta.Text = valInizio(0)
               cmbMeseInizio3_Alta.Text = valInizio(1)
               cmbGiornoFine3_Alta.Text = valFine(0)
               cmbMeseFine3_Alta.Text = valFine(1)
            End If

         End With

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione("Intervalli di Stagione", "", "")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub ToolBar1_ButtonClick_1(sender As System.Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then
               ' Aggiorna la griglia dati.
               'g_frmListiniCamere.AggiornaDati()

               ' Chiude la finestra.
               Me.Close()
            End If

         Case "Annulla"
            ' Chiude la finestra.
            Me.Close()
      End Select

   End Sub

   Private Sub chkIntervallo1_Bassa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo1_Bassa.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio1_Bassa.Enabled = sender.Checked
         cmbMeseInizio1_Bassa.Enabled = sender.Checked
         cmbGiornoFine1_Bassa.Enabled = sender.Checked
         cmbMeseFine1_Bassa.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo2_Bassa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo2_Bassa.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio2_Bassa.Enabled = sender.Checked
         cmbMeseInizio2_Bassa.Enabled = sender.Checked
         cmbGiornoFine2_Bassa.Enabled = sender.Checked
         cmbMeseFine2_Bassa.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo3_Bassa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo3_Bassa.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio3_Bassa.Enabled = sender.Checked
         cmbMeseInizio3_Bassa.Enabled = sender.Checked
         cmbGiornoFine3_Bassa.Enabled = sender.Checked
         cmbMeseFine3_Bassa.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo1_Media_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo1_Media.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio1_Media.Enabled = sender.Checked
         cmbMeseInizio1_Media.Enabled = sender.Checked
         cmbGiornoFine1_Media.Enabled = sender.Checked
         cmbMeseFine1_Media.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo2_Media_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo2_Media.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio2_Media.Enabled = sender.Checked
         cmbMeseInizio2_Media.Enabled = sender.Checked
         cmbGiornoFine2_Media.Enabled = sender.Checked
         cmbMeseFine2_Media.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo3_Media_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo3_Media.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio3_Media.Enabled = sender.Checked
         cmbMeseInizio3_Media.Enabled = sender.Checked
         cmbGiornoFine3_Media.Enabled = sender.Checked
         cmbMeseFine3_Media.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo1_Alta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo1_Alta.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio1_Alta.Enabled = sender.Checked
         cmbMeseInizio1_Alta.Enabled = sender.Checked
         cmbGiornoFine1_Alta.Enabled = sender.Checked
         cmbMeseFine1_Alta.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo2_Alta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo2_Alta.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio2_Alta.Enabled = sender.Checked
         cmbMeseInizio2_Alta.Enabled = sender.Checked
         cmbGiornoFine2_Alta.Enabled = sender.Checked
         cmbMeseFine2_Alta.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkIntervallo3_Alta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIntervallo3_Alta.CheckedChanged
      Try
         ' Se viene selezionato un intervallo attiva/disattiva le caselle appropriate.
         cmbGiornoInizio3_Alta.Enabled = sender.Checked
         cmbMeseInizio3_Alta.Enabled = sender.Checked
         cmbGiornoFine3_Alta.Enabled = sender.Checked
         cmbMeseFine3_Alta.Enabled = sender.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)


      End Try
   End Sub
End Class

