' Nome form:            frmCamere
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/01/2005
' Data ultima modifica: 14/08/2014
' Descrizione:          Anagrafica Camere.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmListiniCamere
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
   Public WithEvents label As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents cmbTipologia As System.Windows.Forms.ComboBox
   Public WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents Panel4 As System.Windows.Forms.Panel
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents txtScontoRagazzo_Bassa As System.Windows.Forms.TextBox
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents txtScontoBambino_Bassa As System.Windows.Forms.TextBox
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents txtScontoNeonato_Bassa As System.Windows.Forms.TextBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents txtPensioneCompleta_Bassa As System.Windows.Forms.TextBox
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents txtMezzaPensione_Bassa As System.Windows.Forms.TextBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents txtBB_Bassa As System.Windows.Forms.TextBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents txtSoloPernottamento_Bassa As System.Windows.Forms.TextBox
   Public WithEvents Label17 As System.Windows.Forms.Label
   Public WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label22 As System.Windows.Forms.Label
   Public WithEvents Label23 As System.Windows.Forms.Label
   Public WithEvents txtScontoRagazzo_Alta As System.Windows.Forms.TextBox
   Public WithEvents Label24 As System.Windows.Forms.Label
   Public WithEvents txtScontoBambino_Alta As System.Windows.Forms.TextBox
   Public WithEvents Label25 As System.Windows.Forms.Label
   Public WithEvents txtScontoNeonato_Alta As System.Windows.Forms.TextBox
   Public WithEvents Label26 As System.Windows.Forms.Label
   Public WithEvents txtPensioneCompleta_Alta As System.Windows.Forms.TextBox
   Public WithEvents Label27 As System.Windows.Forms.Label
   Public WithEvents txtMezzaPensione_Alta As System.Windows.Forms.TextBox
   Public WithEvents Label28 As System.Windows.Forms.Label
   Public WithEvents txtBB_Alta As System.Windows.Forms.TextBox
   Public WithEvents Label29 As System.Windows.Forms.Label
   Public WithEvents txtSoloPernottamento_Alta As System.Windows.Forms.TextBox
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label14 As System.Windows.Forms.Label
   Public WithEvents txtScontoRagazzo_Media As System.Windows.Forms.TextBox
   Public WithEvents Label15 As System.Windows.Forms.Label
   Public WithEvents txtScontoBambino_Media As System.Windows.Forms.TextBox
   Public WithEvents Label16 As System.Windows.Forms.Label
   Public WithEvents txtScontoNeonato_Media As System.Windows.Forms.TextBox
   Public WithEvents Label18 As System.Windows.Forms.Label
   Public WithEvents txtPensioneCompleta_Media As System.Windows.Forms.TextBox
   Public WithEvents Label19 As System.Windows.Forms.Label
   Public WithEvents txtMezzaPensione_Media As System.Windows.Forms.TextBox
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtBB_Media As System.Windows.Forms.TextBox
   Public WithEvents Label21 As System.Windows.Forms.Label
   Public WithEvents txtSoloPernottamento_Media As System.Windows.Forms.TextBox
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListiniCamere))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Panel4 = New System.Windows.Forms.Panel()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.txtScontoRagazzo_Alta = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.txtScontoBambino_Alta = New System.Windows.Forms.TextBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.txtScontoNeonato_Alta = New System.Windows.Forms.TextBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.txtPensioneCompleta_Alta = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.txtMezzaPensione_Alta = New System.Windows.Forms.TextBox()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.txtBB_Alta = New System.Windows.Forms.TextBox()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.txtSoloPernottamento_Alta = New System.Windows.Forms.TextBox()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtScontoRagazzo_Media = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.txtScontoBambino_Media = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.txtScontoNeonato_Media = New System.Windows.Forms.TextBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.txtPensioneCompleta_Media = New System.Windows.Forms.TextBox()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.txtMezzaPensione_Media = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.txtBB_Media = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.txtSoloPernottamento_Media = New System.Windows.Forms.TextBox()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtScontoRagazzo_Bassa = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtScontoBambino_Bassa = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtScontoNeonato_Bassa = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtPensioneCompleta_Bassa = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtMezzaPensione_Bassa = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtBB_Bassa = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtSoloPernottamento_Bassa = New System.Windows.Forms.TextBox()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbTipologia = New System.Windows.Forms.ComboBox()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.label = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
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
      Me.Panel4.SuspendLayout()
      Me.Panel3.SuspendLayout()
      Me.Panel2.SuspendLayout()
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
      Me.Panel1.Size = New System.Drawing.Size(778, 20)
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
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(776, 402)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Panel4)
      Me.TabPage1.Controls.Add(Me.Panel3)
      Me.TabPage1.Controls.Add(Me.Panel2)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.cmbTipologia)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(768, 376)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(504, 93)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(104, 13)
      Me.Label12.TabIndex = 210
      Me.Label12.Text = "Tariffa Alta stagione:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(264, 93)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(115, 13)
      Me.Label11.TabIndex = 209
      Me.Label11.Text = "Tariffa Media stagione:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(24, 93)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(115, 13)
      Me.Label10.TabIndex = 208
      Me.Label10.Text = "Tariffa Bassa stagione:"
      '
      'Panel4
      '
      Me.Panel4.BackColor = System.Drawing.Color.LightCoral
      Me.Panel4.Controls.Add(Me.Label22)
      Me.Panel4.Controls.Add(Me.Label23)
      Me.Panel4.Controls.Add(Me.txtScontoRagazzo_Alta)
      Me.Panel4.Controls.Add(Me.Label24)
      Me.Panel4.Controls.Add(Me.txtScontoBambino_Alta)
      Me.Panel4.Controls.Add(Me.Label25)
      Me.Panel4.Controls.Add(Me.txtScontoNeonato_Alta)
      Me.Panel4.Controls.Add(Me.Label26)
      Me.Panel4.Controls.Add(Me.txtPensioneCompleta_Alta)
      Me.Panel4.Controls.Add(Me.Label27)
      Me.Panel4.Controls.Add(Me.txtMezzaPensione_Alta)
      Me.Panel4.Controls.Add(Me.Label28)
      Me.Panel4.Controls.Add(Me.txtBB_Alta)
      Me.Panel4.Controls.Add(Me.Label29)
      Me.Panel4.Controls.Add(Me.txtSoloPernottamento_Alta)
      Me.Panel4.Location = New System.Drawing.Point(504, 112)
      Me.Panel4.Name = "Panel4"
      Me.Panel4.Size = New System.Drawing.Size(240, 240)
      Me.Panel4.TabIndex = 5
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(132, 18)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(82, 13)
      Me.Label22.TabIndex = 222
      Me.Label22.Text = "Prezzo / giorno:"
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(20, 202)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(100, 13)
      Me.Label23.TabIndex = 221
      Me.Label23.Text = "Sconto Ragazzo %:"
      '
      'txtScontoRagazzo_Alta
      '
      Me.txtScontoRagazzo_Alta.AcceptsReturn = True
      Me.txtScontoRagazzo_Alta.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoRagazzo_Alta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoRagazzo_Alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoRagazzo_Alta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoRagazzo_Alta.Location = New System.Drawing.Point(132, 202)
      Me.txtScontoRagazzo_Alta.MaxLength = 0
      Me.txtScontoRagazzo_Alta.Name = "txtScontoRagazzo_Alta"
      Me.txtScontoRagazzo_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoRagazzo_Alta.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoRagazzo_Alta.TabIndex = 6
      Me.txtScontoRagazzo_Alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(20, 178)
      Me.Label24.Name = "Label24"
      Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label24.Size = New System.Drawing.Size(99, 13)
      Me.Label24.TabIndex = 219
      Me.Label24.Text = "Sconto Bambino %:"
      '
      'txtScontoBambino_Alta
      '
      Me.txtScontoBambino_Alta.AcceptsReturn = True
      Me.txtScontoBambino_Alta.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoBambino_Alta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoBambino_Alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoBambino_Alta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoBambino_Alta.Location = New System.Drawing.Point(132, 178)
      Me.txtScontoBambino_Alta.MaxLength = 0
      Me.txtScontoBambino_Alta.Name = "txtScontoBambino_Alta"
      Me.txtScontoBambino_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoBambino_Alta.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoBambino_Alta.TabIndex = 5
      Me.txtScontoBambino_Alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(20, 154)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(99, 13)
      Me.Label25.TabIndex = 217
      Me.Label25.Text = "Sconto Neonato %:"
      '
      'txtScontoNeonato_Alta
      '
      Me.txtScontoNeonato_Alta.AcceptsReturn = True
      Me.txtScontoNeonato_Alta.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoNeonato_Alta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoNeonato_Alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoNeonato_Alta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoNeonato_Alta.Location = New System.Drawing.Point(132, 154)
      Me.txtScontoNeonato_Alta.MaxLength = 0
      Me.txtScontoNeonato_Alta.Name = "txtScontoNeonato_Alta"
      Me.txtScontoNeonato_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoNeonato_Alta.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoNeonato_Alta.TabIndex = 4
      Me.txtScontoNeonato_Alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.BackColor = System.Drawing.Color.Transparent
      Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label26.ForeColor = System.Drawing.Color.Black
      Me.Label26.Location = New System.Drawing.Point(20, 114)
      Me.Label26.Name = "Label26"
      Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label26.Size = New System.Drawing.Size(101, 13)
      Me.Label26.TabIndex = 215
      Me.Label26.Text = "Pensione Completa:"
      '
      'txtPensioneCompleta_Alta
      '
      Me.txtPensioneCompleta_Alta.AcceptsReturn = True
      Me.txtPensioneCompleta_Alta.BackColor = System.Drawing.SystemColors.Window
      Me.txtPensioneCompleta_Alta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPensioneCompleta_Alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPensioneCompleta_Alta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPensioneCompleta_Alta.Location = New System.Drawing.Point(132, 114)
      Me.txtPensioneCompleta_Alta.MaxLength = 0
      Me.txtPensioneCompleta_Alta.Name = "txtPensioneCompleta_Alta"
      Me.txtPensioneCompleta_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPensioneCompleta_Alta.Size = New System.Drawing.Size(88, 20)
      Me.txtPensioneCompleta_Alta.TabIndex = 3
      Me.txtPensioneCompleta_Alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.Color.Transparent
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.Color.Black
      Me.Label27.Location = New System.Drawing.Point(20, 90)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(88, 13)
      Me.Label27.TabIndex = 213
      Me.Label27.Text = "Mezza Pensione:"
      '
      'txtMezzaPensione_Alta
      '
      Me.txtMezzaPensione_Alta.AcceptsReturn = True
      Me.txtMezzaPensione_Alta.BackColor = System.Drawing.SystemColors.Window
      Me.txtMezzaPensione_Alta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtMezzaPensione_Alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtMezzaPensione_Alta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtMezzaPensione_Alta.Location = New System.Drawing.Point(132, 90)
      Me.txtMezzaPensione_Alta.MaxLength = 0
      Me.txtMezzaPensione_Alta.Name = "txtMezzaPensione_Alta"
      Me.txtMezzaPensione_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtMezzaPensione_Alta.Size = New System.Drawing.Size(88, 20)
      Me.txtMezzaPensione_Alta.TabIndex = 2
      Me.txtMezzaPensione_Alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.BackColor = System.Drawing.Color.Transparent
      Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label28.ForeColor = System.Drawing.Color.Black
      Me.Label28.Location = New System.Drawing.Point(20, 66)
      Me.Label28.Name = "Label28"
      Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label28.Size = New System.Drawing.Size(86, 13)
      Me.Label28.TabIndex = 211
      Me.Label28.Text = "Bed && Breakfast:"
      '
      'txtBB_Alta
      '
      Me.txtBB_Alta.AcceptsReturn = True
      Me.txtBB_Alta.BackColor = System.Drawing.SystemColors.Window
      Me.txtBB_Alta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBB_Alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBB_Alta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBB_Alta.Location = New System.Drawing.Point(132, 66)
      Me.txtBB_Alta.MaxLength = 0
      Me.txtBB_Alta.Name = "txtBB_Alta"
      Me.txtBB_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBB_Alta.Size = New System.Drawing.Size(88, 20)
      Me.txtBB_Alta.TabIndex = 1
      Me.txtBB_Alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.BackColor = System.Drawing.Color.Transparent
      Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label29.ForeColor = System.Drawing.Color.Black
      Me.Label29.Location = New System.Drawing.Point(20, 42)
      Me.Label29.Name = "Label29"
      Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label29.Size = New System.Drawing.Size(103, 13)
      Me.Label29.TabIndex = 209
      Me.Label29.Text = "Solo Pernottamento:"
      '
      'txtSoloPernottamento_Alta
      '
      Me.txtSoloPernottamento_Alta.AcceptsReturn = True
      Me.txtSoloPernottamento_Alta.BackColor = System.Drawing.SystemColors.Window
      Me.txtSoloPernottamento_Alta.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSoloPernottamento_Alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSoloPernottamento_Alta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtSoloPernottamento_Alta.Location = New System.Drawing.Point(132, 42)
      Me.txtSoloPernottamento_Alta.MaxLength = 0
      Me.txtSoloPernottamento_Alta.Name = "txtSoloPernottamento_Alta"
      Me.txtSoloPernottamento_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSoloPernottamento_Alta.Size = New System.Drawing.Size(88, 20)
      Me.txtSoloPernottamento_Alta.TabIndex = 0
      Me.txtSoloPernottamento_Alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.Khaki
      Me.Panel3.Controls.Add(Me.Label13)
      Me.Panel3.Controls.Add(Me.Label14)
      Me.Panel3.Controls.Add(Me.txtScontoRagazzo_Media)
      Me.Panel3.Controls.Add(Me.Label15)
      Me.Panel3.Controls.Add(Me.txtScontoBambino_Media)
      Me.Panel3.Controls.Add(Me.Label16)
      Me.Panel3.Controls.Add(Me.txtScontoNeonato_Media)
      Me.Panel3.Controls.Add(Me.Label18)
      Me.Panel3.Controls.Add(Me.txtPensioneCompleta_Media)
      Me.Panel3.Controls.Add(Me.Label19)
      Me.Panel3.Controls.Add(Me.txtMezzaPensione_Media)
      Me.Panel3.Controls.Add(Me.Label20)
      Me.Panel3.Controls.Add(Me.txtBB_Media)
      Me.Panel3.Controls.Add(Me.Label21)
      Me.Panel3.Controls.Add(Me.txtSoloPernottamento_Media)
      Me.Panel3.Location = New System.Drawing.Point(264, 112)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(240, 240)
      Me.Panel3.TabIndex = 4
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(132, 18)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(82, 13)
      Me.Label13.TabIndex = 222
      Me.Label13.Text = "Prezzo / giorno:"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(20, 202)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(100, 13)
      Me.Label14.TabIndex = 221
      Me.Label14.Text = "Sconto Ragazzo %:"
      '
      'txtScontoRagazzo_Media
      '
      Me.txtScontoRagazzo_Media.AcceptsReturn = True
      Me.txtScontoRagazzo_Media.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoRagazzo_Media.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoRagazzo_Media.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoRagazzo_Media.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoRagazzo_Media.Location = New System.Drawing.Point(132, 202)
      Me.txtScontoRagazzo_Media.MaxLength = 0
      Me.txtScontoRagazzo_Media.Name = "txtScontoRagazzo_Media"
      Me.txtScontoRagazzo_Media.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoRagazzo_Media.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoRagazzo_Media.TabIndex = 6
      Me.txtScontoRagazzo_Media.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(20, 178)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(99, 13)
      Me.Label15.TabIndex = 219
      Me.Label15.Text = "Sconto Bambino %:"
      '
      'txtScontoBambino_Media
      '
      Me.txtScontoBambino_Media.AcceptsReturn = True
      Me.txtScontoBambino_Media.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoBambino_Media.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoBambino_Media.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoBambino_Media.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoBambino_Media.Location = New System.Drawing.Point(132, 178)
      Me.txtScontoBambino_Media.MaxLength = 0
      Me.txtScontoBambino_Media.Name = "txtScontoBambino_Media"
      Me.txtScontoBambino_Media.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoBambino_Media.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoBambino_Media.TabIndex = 5
      Me.txtScontoBambino_Media.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(20, 154)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(99, 13)
      Me.Label16.TabIndex = 217
      Me.Label16.Text = "Sconto Neonato %:"
      '
      'txtScontoNeonato_Media
      '
      Me.txtScontoNeonato_Media.AcceptsReturn = True
      Me.txtScontoNeonato_Media.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoNeonato_Media.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoNeonato_Media.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoNeonato_Media.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoNeonato_Media.Location = New System.Drawing.Point(132, 154)
      Me.txtScontoNeonato_Media.MaxLength = 0
      Me.txtScontoNeonato_Media.Name = "txtScontoNeonato_Media"
      Me.txtScontoNeonato_Media.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoNeonato_Media.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoNeonato_Media.TabIndex = 4
      Me.txtScontoNeonato_Media.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(20, 114)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(101, 13)
      Me.Label18.TabIndex = 215
      Me.Label18.Text = "Pensione Completa:"
      '
      'txtPensioneCompleta_Media
      '
      Me.txtPensioneCompleta_Media.AcceptsReturn = True
      Me.txtPensioneCompleta_Media.BackColor = System.Drawing.SystemColors.Window
      Me.txtPensioneCompleta_Media.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPensioneCompleta_Media.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPensioneCompleta_Media.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPensioneCompleta_Media.Location = New System.Drawing.Point(132, 114)
      Me.txtPensioneCompleta_Media.MaxLength = 0
      Me.txtPensioneCompleta_Media.Name = "txtPensioneCompleta_Media"
      Me.txtPensioneCompleta_Media.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPensioneCompleta_Media.Size = New System.Drawing.Size(88, 20)
      Me.txtPensioneCompleta_Media.TabIndex = 3
      Me.txtPensioneCompleta_Media.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(20, 90)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(88, 13)
      Me.Label19.TabIndex = 213
      Me.Label19.Text = "Mezza Pensione:"
      '
      'txtMezzaPensione_Media
      '
      Me.txtMezzaPensione_Media.AcceptsReturn = True
      Me.txtMezzaPensione_Media.BackColor = System.Drawing.SystemColors.Window
      Me.txtMezzaPensione_Media.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtMezzaPensione_Media.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtMezzaPensione_Media.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtMezzaPensione_Media.Location = New System.Drawing.Point(132, 90)
      Me.txtMezzaPensione_Media.MaxLength = 0
      Me.txtMezzaPensione_Media.Name = "txtMezzaPensione_Media"
      Me.txtMezzaPensione_Media.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtMezzaPensione_Media.Size = New System.Drawing.Size(88, 20)
      Me.txtMezzaPensione_Media.TabIndex = 2
      Me.txtMezzaPensione_Media.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(20, 66)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(86, 13)
      Me.Label20.TabIndex = 211
      Me.Label20.Text = "Bed && Breakfast:"
      '
      'txtBB_Media
      '
      Me.txtBB_Media.AcceptsReturn = True
      Me.txtBB_Media.BackColor = System.Drawing.SystemColors.Window
      Me.txtBB_Media.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBB_Media.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBB_Media.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBB_Media.Location = New System.Drawing.Point(132, 66)
      Me.txtBB_Media.MaxLength = 0
      Me.txtBB_Media.Name = "txtBB_Media"
      Me.txtBB_Media.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBB_Media.Size = New System.Drawing.Size(88, 20)
      Me.txtBB_Media.TabIndex = 1
      Me.txtBB_Media.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(20, 42)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(103, 13)
      Me.Label21.TabIndex = 209
      Me.Label21.Text = "Solo Pernottamento:"
      '
      'txtSoloPernottamento_Media
      '
      Me.txtSoloPernottamento_Media.AcceptsReturn = True
      Me.txtSoloPernottamento_Media.BackColor = System.Drawing.SystemColors.Window
      Me.txtSoloPernottamento_Media.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSoloPernottamento_Media.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSoloPernottamento_Media.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtSoloPernottamento_Media.Location = New System.Drawing.Point(132, 42)
      Me.txtSoloPernottamento_Media.MaxLength = 0
      Me.txtSoloPernottamento_Media.Name = "txtSoloPernottamento_Media"
      Me.txtSoloPernottamento_Media.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSoloPernottamento_Media.Size = New System.Drawing.Size(88, 20)
      Me.txtSoloPernottamento_Media.TabIndex = 0
      Me.txtSoloPernottamento_Media.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.LightGreen
      Me.Panel2.Controls.Add(Me.Label17)
      Me.Panel2.Controls.Add(Me.Label9)
      Me.Panel2.Controls.Add(Me.txtScontoRagazzo_Bassa)
      Me.Panel2.Controls.Add(Me.Label8)
      Me.Panel2.Controls.Add(Me.txtScontoBambino_Bassa)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Controls.Add(Me.txtScontoNeonato_Bassa)
      Me.Panel2.Controls.Add(Me.Label5)
      Me.Panel2.Controls.Add(Me.txtPensioneCompleta_Bassa)
      Me.Panel2.Controls.Add(Me.Label4)
      Me.Panel2.Controls.Add(Me.txtMezzaPensione_Bassa)
      Me.Panel2.Controls.Add(Me.Label2)
      Me.Panel2.Controls.Add(Me.txtBB_Bassa)
      Me.Panel2.Controls.Add(Me.Label1)
      Me.Panel2.Controls.Add(Me.txtSoloPernottamento_Bassa)
      Me.Panel2.Location = New System.Drawing.Point(24, 112)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(240, 240)
      Me.Panel2.TabIndex = 3
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(128, 16)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(82, 13)
      Me.Label17.TabIndex = 207
      Me.Label17.Text = "Prezzo / giorno:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(16, 200)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(100, 13)
      Me.Label9.TabIndex = 205
      Me.Label9.Text = "Sconto Ragazzo %:"
      '
      'txtScontoRagazzo_Bassa
      '
      Me.txtScontoRagazzo_Bassa.AcceptsReturn = True
      Me.txtScontoRagazzo_Bassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoRagazzo_Bassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoRagazzo_Bassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoRagazzo_Bassa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoRagazzo_Bassa.Location = New System.Drawing.Point(128, 200)
      Me.txtScontoRagazzo_Bassa.MaxLength = 0
      Me.txtScontoRagazzo_Bassa.Name = "txtScontoRagazzo_Bassa"
      Me.txtScontoRagazzo_Bassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoRagazzo_Bassa.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoRagazzo_Bassa.TabIndex = 6
      Me.txtScontoRagazzo_Bassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(16, 176)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(99, 13)
      Me.Label8.TabIndex = 203
      Me.Label8.Text = "Sconto Bambino %:"
      '
      'txtScontoBambino_Bassa
      '
      Me.txtScontoBambino_Bassa.AcceptsReturn = True
      Me.txtScontoBambino_Bassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoBambino_Bassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoBambino_Bassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoBambino_Bassa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoBambino_Bassa.Location = New System.Drawing.Point(128, 176)
      Me.txtScontoBambino_Bassa.MaxLength = 0
      Me.txtScontoBambino_Bassa.Name = "txtScontoBambino_Bassa"
      Me.txtScontoBambino_Bassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoBambino_Bassa.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoBambino_Bassa.TabIndex = 5
      Me.txtScontoBambino_Bassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(16, 152)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(99, 13)
      Me.Label6.TabIndex = 201
      Me.Label6.Text = "Sconto Neonato %:"
      '
      'txtScontoNeonato_Bassa
      '
      Me.txtScontoNeonato_Bassa.AcceptsReturn = True
      Me.txtScontoNeonato_Bassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontoNeonato_Bassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontoNeonato_Bassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontoNeonato_Bassa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtScontoNeonato_Bassa.Location = New System.Drawing.Point(128, 152)
      Me.txtScontoNeonato_Bassa.MaxLength = 0
      Me.txtScontoNeonato_Bassa.Name = "txtScontoNeonato_Bassa"
      Me.txtScontoNeonato_Bassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontoNeonato_Bassa.Size = New System.Drawing.Size(88, 20)
      Me.txtScontoNeonato_Bassa.TabIndex = 4
      Me.txtScontoNeonato_Bassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.Label5.Size = New System.Drawing.Size(101, 13)
      Me.Label5.TabIndex = 199
      Me.Label5.Text = "Pensione Completa:"
      '
      'txtPensioneCompleta_Bassa
      '
      Me.txtPensioneCompleta_Bassa.AcceptsReturn = True
      Me.txtPensioneCompleta_Bassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtPensioneCompleta_Bassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPensioneCompleta_Bassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPensioneCompleta_Bassa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPensioneCompleta_Bassa.Location = New System.Drawing.Point(128, 112)
      Me.txtPensioneCompleta_Bassa.MaxLength = 0
      Me.txtPensioneCompleta_Bassa.Name = "txtPensioneCompleta_Bassa"
      Me.txtPensioneCompleta_Bassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPensioneCompleta_Bassa.Size = New System.Drawing.Size(88, 20)
      Me.txtPensioneCompleta_Bassa.TabIndex = 3
      Me.txtPensioneCompleta_Bassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 88)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(88, 13)
      Me.Label4.TabIndex = 197
      Me.Label4.Text = "Mezza Pensione:"
      '
      'txtMezzaPensione_Bassa
      '
      Me.txtMezzaPensione_Bassa.AcceptsReturn = True
      Me.txtMezzaPensione_Bassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtMezzaPensione_Bassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtMezzaPensione_Bassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtMezzaPensione_Bassa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtMezzaPensione_Bassa.Location = New System.Drawing.Point(128, 88)
      Me.txtMezzaPensione_Bassa.MaxLength = 0
      Me.txtMezzaPensione_Bassa.Name = "txtMezzaPensione_Bassa"
      Me.txtMezzaPensione_Bassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtMezzaPensione_Bassa.Size = New System.Drawing.Size(88, 20)
      Me.txtMezzaPensione_Bassa.TabIndex = 2
      Me.txtMezzaPensione_Bassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 64)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(86, 13)
      Me.Label2.TabIndex = 195
      Me.Label2.Text = "Bed && Breakfast:"
      '
      'txtBB_Bassa
      '
      Me.txtBB_Bassa.AcceptsReturn = True
      Me.txtBB_Bassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtBB_Bassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBB_Bassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBB_Bassa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBB_Bassa.Location = New System.Drawing.Point(128, 64)
      Me.txtBB_Bassa.MaxLength = 0
      Me.txtBB_Bassa.Name = "txtBB_Bassa"
      Me.txtBB_Bassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBB_Bassa.Size = New System.Drawing.Size(88, 20)
      Me.txtBB_Bassa.TabIndex = 1
      Me.txtBB_Bassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(103, 13)
      Me.Label1.TabIndex = 193
      Me.Label1.Text = "Solo Pernottamento:"
      '
      'txtSoloPernottamento_Bassa
      '
      Me.txtSoloPernottamento_Bassa.AcceptsReturn = True
      Me.txtSoloPernottamento_Bassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtSoloPernottamento_Bassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSoloPernottamento_Bassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSoloPernottamento_Bassa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtSoloPernottamento_Bassa.Location = New System.Drawing.Point(128, 40)
      Me.txtSoloPernottamento_Bassa.MaxLength = 0
      Me.txtSoloPernottamento_Bassa.Name = "txtSoloPernottamento_Bassa"
      Me.txtSoloPernottamento_Bassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSoloPernottamento_Bassa.Size = New System.Drawing.Size(88, 20)
      Me.txtSoloPernottamento_Bassa.TabIndex = 0
      Me.txtSoloPernottamento_Bassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(24, 40)
      Me.txtCodice.MaxLength = 5
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(104, 20)
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
      'cmbTipologia
      '
      Me.cmbTipologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipologia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipologia.Items.AddRange(New Object() {"Tariffa a Persona", "Tariffa a Camera"})
      Me.cmbTipologia.Location = New System.Drawing.Point(608, 40)
      Me.cmbTipologia.Name = "cmbTipologia"
      Me.cmbTipologia.Size = New System.Drawing.Size(136, 21)
      Me.cmbTipologia.TabIndex = 2
      '
      'txtDescrizione
      '
      Me.txtDescrizione.AcceptsReturn = True
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizione.Location = New System.Drawing.Point(136, 40)
      Me.txtDescrizione.MaxLength = 0
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizione.Size = New System.Drawing.Size(464, 20)
      Me.txtDescrizione.TabIndex = 1
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(608, 24)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(53, 13)
      Me.label.TabIndex = 169
      Me.label.Text = "Tipologia:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(136, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(65, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Descrizione:"
      '
      'TabPage6
      '
      Me.TabPage6.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(768, 376)
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
      Me.txtNote.Size = New System.Drawing.Size(768, 376)
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
      Me.ToolBar1.Size = New System.Drawing.Size(778, 26)
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
      'frmListiniCamere
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(778, 450)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Controls.Add(Me.TabControl1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmListiniCamere"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Listini Camere"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.Panel4.ResumeLayout(False)
      Me.Panel4.PerformLayout()
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Const NOME_TABELLA As String = "ListiniCamere"

   Public AListinoCamera As New ListinoCamera

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
         With AListinoCamera
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Descrizione = txtDescrizione.Text
            .Tipologia = cmbTipologia.Text

            .SoloPernottamento_Bassa = txtSoloPernottamento_Bassa.Text
            .BB_Bassa = txtBB_Bassa.Text
            .MezzaPensione_Bassa = txtMezzaPensione_Bassa.Text
            .PensioneCompleta_Bassa = txtPensioneCompleta_Bassa.Text
            .ScontoNeonato_Bassa = txtScontoNeonato_Bassa.Text
            .ScontoBambino_Bassa = txtScontoBambino_Bassa.Text
            .ScontoRagazzo_Bassa = txtScontoRagazzo_Bassa.Text

            .SoloPernottamento_Media = txtSoloPernottamento_Media.Text
            .BB_Media = txtBB_Media.Text
            .MezzaPensione_Media = txtMezzaPensione_Media.Text
            .PensioneCompleta_Media = txtPensioneCompleta_Media.Text
            .ScontoNeonato_Media = txtScontoNeonato_Media.Text
            .ScontoBambino_Media = txtScontoBambino_Media.Text
            .ScontoRagazzo_Media = txtScontoRagazzo_Media.Text

            .SoloPernottamento_Alta = txtSoloPernottamento_Alta.Text
            .BB_Alta = txtBB_Alta.Text
            .MezzaPensione_Alta = txtMezzaPensione_Alta.Text
            .PensioneCompleta_Alta = txtPensioneCompleta_Alta.Text
            .ScontoNeonato_Alta = txtScontoNeonato_Alta.Text
            .ScontoBambino_Alta = txtScontoBambino_Alta.Text
            .ScontoRagazzo_Alta = txtScontoRagazzo_Alta.Text

            .Note = txtNote.Text

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

         Return False

      End Try
   End Function

   Private Sub frmListiniCamere_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(LISTINI_LARGHEZZA, lISTINI_ALTEZZA)

         With AListinoCamera

            If Me.Tag <> "" Then
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtDescrizione.Text = .Descrizione
               cmbTipologia.Text = .Tipologia

               txtSoloPernottamento_Bassa.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.SoloPernottamento_Bassa))
               txtBB_Bassa.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.BB_Bassa))
               txtMezzaPensione_Bassa.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.MezzaPensione_Bassa))
               txtPensioneCompleta_Bassa.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.PensioneCompleta_Bassa))
               txtScontoNeonato_Bassa.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoNeonato_Bassa))
               txtScontoBambino_Bassa.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoBambino_Bassa))
               txtScontoRagazzo_Bassa.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoRagazzo_Bassa))

               txtSoloPernottamento_Media.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.SoloPernottamento_Media))
               txtBB_Media.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.BB_Media))
               txtMezzaPensione_Media.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.MezzaPensione_Media))
               txtPensioneCompleta_Media.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.PensioneCompleta_Media))
               txtScontoNeonato_Media.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoNeonato_Media))
               txtScontoBambino_Media.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoBambino_Media))
               txtScontoRagazzo_Media.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoRagazzo_Media))

               txtSoloPernottamento_Alta.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.SoloPernottamento_Alta))
               txtBB_Alta.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.BB_Alta))
               txtMezzaPensione_Alta.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.MezzaPensione_Alta))
               txtPensioneCompleta_Alta.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.PensioneCompleta_Alta))
               txtScontoNeonato_Alta.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoNeonato_Alta))
               txtScontoBambino_Alta.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoBambino_Alta))
               txtScontoRagazzo_Alta.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.ScontoRagazzo_Alta))

               txtNote.Text = .Note

            Else
               ' Nuovo inserimento.
               cmbTipologia.SelectedIndex = 0

               txtSoloPernottamento_Bassa.Text = VALORE_ZERO
               txtBB_Bassa.Text = VALORE_ZERO
               txtMezzaPensione_Bassa.Text = VALORE_ZERO
               txtPensioneCompleta_Bassa.Text = VALORE_ZERO
               txtScontoNeonato_Bassa.Text = VALORE_ZERO
               txtScontoBambino_Bassa.Text = VALORE_ZERO
               txtScontoRagazzo_Bassa.Text = VALORE_ZERO

               txtSoloPernottamento_Media.Text = VALORE_ZERO
               txtBB_Media.Text = VALORE_ZERO
               txtMezzaPensione_Media.Text = VALORE_ZERO
               txtPensioneCompleta_Media.Text = VALORE_ZERO
               txtScontoNeonato_Media.Text = VALORE_ZERO
               txtScontoBambino_Media.Text = VALORE_ZERO
               txtScontoRagazzo_Media.Text = VALORE_ZERO

               txtSoloPernottamento_Alta.Text = VALORE_ZERO
               txtBB_Alta.Text = VALORE_ZERO
               txtMezzaPensione_Alta.Text = VALORE_ZERO
               txtPensioneCompleta_Alta.Text = VALORE_ZERO
               txtScontoNeonato_Alta.Text = VALORE_ZERO
               txtScontoBambino_Alta.Text = VALORE_ZERO
               txtScontoRagazzo_Alta.Text = VALORE_ZERO

            End If

         End With

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtDescrizione.Text, cmbTipologia.Text)

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
            txtDescrizione.Focus()

         Case 1
            ' Imposta lo stato attivo.
            txtNote.Focus()
      End Select
   End Sub

   Private Sub ToolBar1_ButtonClick_1(sender As System.Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then
               ' Aggiorna la griglia dati.
               g_frmListiniCamere.AggiornaDati()

               ' Chiude la finestra.
               Me.Close()
            End If

         Case "Annulla"
            ' Chiude la finestra.
            Me.Close()
      End Select

   End Sub

   Private Sub txtSoloPernottamento_Bassa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoloPernottamento_Bassa.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtBB_Bassa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBB_Bassa.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtMezzaPensione_Bassa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMezzaPensione_Bassa.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPensioneCompleta_Bassa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPensioneCompleta_Bassa.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoNeonato_Bassa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoNeonato_Bassa.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoBambino_Bassa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoBambino_Bassa.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoRagazzo_Bassa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoRagazzo_Bassa.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSoloPernottamento_Media_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoloPernottamento_Media.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtBB_Media_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBB_Media.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtMezzaPensione_Media_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMezzaPensione_Media.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPensioneCompleta_Media_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPensioneCompleta_Media.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoNeonato_Media_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoNeonato_Media.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoBambino_Media_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoBambino_Media.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoRagazzo_Media_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoRagazzo_Media.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSoloPernottamento_Alta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoloPernottamento_Alta.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtBB_Alta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBB_Alta.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtMezzaPensione_Alta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMezzaPensione_Alta.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPensioneCompleta_Alta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPensioneCompleta_Alta.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoNeonato_Alta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoNeonato_Alta.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoBambino_Alta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoBambino_Alta.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoRagazzo_Alta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoRagazzo_Alta.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSoloPernottamento_Bassa_LostFocus(sender As Object, e As System.EventArgs) Handles txtSoloPernottamento_Bassa.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub txtBB_Bassa_LostFocus(sender As Object, e As System.EventArgs) Handles txtBB_Bassa.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtMezzaPensione_Bassa_LostFocus(sender As Object, e As System.EventArgs) Handles txtMezzaPensione_Bassa.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPensioneCompleta_Bassa_LostFocus(sender As Object, e As System.EventArgs) Handles txtPensioneCompleta_Bassa.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoNeonato_Bassa_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoNeonato_Bassa.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoBambino_Bassa_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoBambino_Bassa.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoRagazzo_Bassa_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoRagazzo_Bassa.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSoloPernottamento_Media_LostFocus(sender As Object, e As System.EventArgs) Handles txtSoloPernottamento_Media.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtBB_Media_LostFocus(sender As Object, e As System.EventArgs) Handles txtBB_Media.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtMezzaPensione_Media_LostFocus(sender As Object, e As System.EventArgs) Handles txtMezzaPensione_Media.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPensioneCompleta_Media_LostFocus(sender As Object, e As System.EventArgs) Handles txtPensioneCompleta_Media.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoNeonato_Media_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoNeonato_Media.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoBambino_Media_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoBambino_Media.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoRagazzo_Media_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoRagazzo_Media.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSoloPernottamento_Alta_LostFocus(sender As Object, e As System.EventArgs) Handles txtSoloPernottamento_Alta.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtBB_Alta_LostFocus(sender As Object, e As System.EventArgs) Handles txtBB_Alta.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtMezzaPensione_Alta_LostFocus(sender As Object, e As System.EventArgs) Handles txtMezzaPensione_Alta.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPensioneCompleta_Alta_LostFocus(sender As Object, e As System.EventArgs) Handles txtPensioneCompleta_Alta.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoNeonato_Alta_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoNeonato_Alta.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoBambino_Alta_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoBambino_Alta.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtScontoRagazzo_Alta_LostFocus(sender As Object, e As System.EventArgs) Handles txtScontoRagazzo_Alta.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
