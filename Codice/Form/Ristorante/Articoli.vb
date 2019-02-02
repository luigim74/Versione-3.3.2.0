' Nome form:            frmArticoli
' Autore:               Luigi Montana, Montana Software
' Data creazione:       09/10/2006
' Data ultima modifica: 14/10/2006
' Descrizione:          Anagrafica Articoli e Ingredienti.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmArticoli
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni "

   Private AArticoli As New Articoli
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   Const TAB_UM As String = "Unit‡Misura"
   Const TAB_FORNITORI As String = "Fornitori"
   Const TAB_CATEGORIE As String = "CategorieMerce"
   Const TAB_MAGAZZINI As String = "Magazzini"
   Const TAB_UBICAZIONI As String = "Ubicazioni"
   Const TAB_SCAFFALI As String = "Scaffali"
   Const NOME_TABELLA As String = "Articoli"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents txtValoreScarichi As System.Windows.Forms.TextBox
   Friend WithEvents Label47 As System.Windows.Forms.Label
   Friend WithEvents Label51 As System.Windows.Forms.Label
   Friend WithEvents txtValoreAttuale As System.Windows.Forms.TextBox
   Friend WithEvents Label52 As System.Windows.Forms.Label
   Friend WithEvents txtValoreCarichi As TextBox
   Dim situazioneScorta As Double = 0

#End Region

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents Immagine As System.Windows.Forms.TabPage
   Friend WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents DatiPrincipale As System.Windows.Forms.TabPage
   Friend WithEvents Note As System.Windows.Forms.TabPage
   Friend WithEvents cmbScaffale As System.Windows.Forms.ComboBox
   Friend WithEvents Label35 As System.Windows.Forms.Label
   Friend WithEvents txtAliquotaIVA As System.Windows.Forms.ComboBox
   Friend WithEvents cmbUbicazione As System.Windows.Forms.ComboBox
   Friend WithEvents cmbSottocategoria As System.Windows.Forms.ComboBox
   Friend WithEvents Label36 As System.Windows.Forms.Label
   Friend WithEvents Label37 As System.Windows.Forms.Label
   Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Friend WithEvents Label38 As System.Windows.Forms.Label
   Friend WithEvents txtCodiceBarre As System.Windows.Forms.TextBox
   Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
   Friend WithEvents cmbFornitore As System.Windows.Forms.ComboBox
   Friend WithEvents Label39 As System.Windows.Forms.Label
   Friend WithEvents Label40 As System.Windows.Forms.Label
   Friend WithEvents Label41 As System.Windows.Forms.Label
   Friend WithEvents Label42 As System.Windows.Forms.Label
   Friend WithEvents Label43 As System.Windows.Forms.Label
   Friend WithEvents Label44 As System.Windows.Forms.Label
   Friend WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents Label45 As System.Windows.Forms.Label
   Friend WithEvents Label46 As System.Windows.Forms.Label
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents txtListino10 As System.Windows.Forms.TextBox
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents txtListino9 As System.Windows.Forms.TextBox
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents txtListino8 As System.Windows.Forms.TextBox
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents txtListino7 As System.Windows.Forms.TextBox
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents txtListino6 As System.Windows.Forms.TextBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents txtListino5 As System.Windows.Forms.TextBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents txtListino4 As System.Windows.Forms.TextBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents txtListino3 As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents txtListino2 As System.Windows.Forms.TextBox
   Friend WithEvents Label61 As System.Windows.Forms.Label
   Friend WithEvents txtListino1 As System.Windows.Forms.TextBox
   Friend WithEvents Label49 As System.Windows.Forms.Label
   Friend WithEvents Label50 As System.Windows.Forms.Label
   Friend WithEvents Label48 As System.Windows.Forms.Label
   Friend WithEvents lbl35 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents txtPesoLordo As System.Windows.Forms.TextBox
   Friend WithEvents txtPesoNetto As System.Windows.Forms.TextBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtVolumeLordo As System.Windows.Forms.TextBox
   Friend WithEvents txtVolumeNetto As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtProfonditaLordo As System.Windows.Forms.TextBox
   Friend WithEvents txtProfonditaNetto As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtAltezzaLordo As System.Windows.Forms.TextBox
   Friend WithEvents txtAltezzaNetto As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtLarghezzaLordo As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbUnitaMisuraDimensionePeso2 As System.Windows.Forms.ComboBox
   Friend WithEvents UnitaMisuraDimensione As System.Windows.Forms.ComboBox
   Friend WithEvents txtLarghezzaNetto As System.Windows.Forms.TextBox
   Friend WithEvents Label53 As System.Windows.Forms.Label
   Friend WithEvents txtPeso As System.Windows.Forms.TextBox
   Friend WithEvents Label55 As System.Windows.Forms.Label
   Friend WithEvents txtDimensione As System.Windows.Forms.TextBox
   Friend WithEvents Label56 As System.Windows.Forms.Label
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Friend WithEvents cmdElimina As System.Windows.Forms.Button
   Friend WithEvents cmdApri As System.Windows.Forms.Button
   Friend WithEvents Progressivi As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents txtScortaMinima As System.Windows.Forms.TextBox
   Friend WithEvents Label34 As System.Windows.Forms.Label
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents txtPrezzoAcquisto As System.Windows.Forms.TextBox
   Friend WithEvents cmbMagazzino As System.Windows.Forms.ComboBox
   Friend WithEvents cmbUM As System.Windows.Forms.ComboBox
   Friend WithEvents txtValScarichi As System.Windows.Forms.TextBox
   Friend WithEvents txtValCarichi As System.Windows.Forms.TextBox
   Friend WithEvents txtValAttuale As System.Windows.Forms.TextBox
   Friend WithEvents txtTotScarichi As System.Windows.Forms.TextBox
   Friend WithEvents txtTotCarichi As System.Windows.Forms.TextBox
   Friend WithEvents txtGiacenza As System.Windows.Forms.TextBox
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents InfoVini As System.Windows.Forms.TabPage
   Friend WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents Label30 As System.Windows.Forms.Label
   Friend WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents Label33 As System.Windows.Forms.Label
   Friend WithEvents txtAnnoVino As System.Windows.Forms.TextBox
   Friend WithEvents txtFormatoVino As System.Windows.Forms.TextBox
   Friend WithEvents txtZonaVino As System.Windows.Forms.TextBox
   Friend WithEvents txtRegioneVino As System.Windows.Forms.TextBox
   Friend WithEvents txtProduttoreVino As System.Windows.Forms.TextBox
   Friend WithEvents Label28 As System.Windows.Forms.Label
   Friend WithEvents txtScansiaVino As System.Windows.Forms.TextBox
   Friend WithEvents cmdCalcolaPrezzo As System.Windows.Forms.Button
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticoli))
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.DatiPrincipale = New System.Windows.Forms.TabPage()
      Me.cmdCalcolaPrezzo = New System.Windows.Forms.Button()
      Me.cmbScaffale = New System.Windows.Forms.ComboBox()
      Me.Label35 = New System.Windows.Forms.Label()
      Me.txtPrezzoAcquisto = New System.Windows.Forms.TextBox()
      Me.txtAliquotaIVA = New System.Windows.Forms.ComboBox()
      Me.cmbUbicazione = New System.Windows.Forms.ComboBox()
      Me.cmbMagazzino = New System.Windows.Forms.ComboBox()
      Me.cmbSottocategoria = New System.Windows.Forms.ComboBox()
      Me.Label36 = New System.Windows.Forms.Label()
      Me.cmbUM = New System.Windows.Forms.ComboBox()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.txtCodiceBarre = New System.Windows.Forms.TextBox()
      Me.cmbCategoria = New System.Windows.Forms.ComboBox()
      Me.cmbFornitore = New System.Windows.Forms.ComboBox()
      Me.Label39 = New System.Windows.Forms.Label()
      Me.Label40 = New System.Windows.Forms.Label()
      Me.Label41 = New System.Windows.Forms.Label()
      Me.Label42 = New System.Windows.Forms.Label()
      Me.Label43 = New System.Windows.Forms.Label()
      Me.Label44 = New System.Windows.Forms.Label()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label45 = New System.Windows.Forms.Label()
      Me.Label46 = New System.Windows.Forms.Label()
      Me.Label37 = New System.Windows.Forms.Label()
      Me.Label38 = New System.Windows.Forms.Label()
      Me.InfoVini = New System.Windows.Forms.TabPage()
      Me.txtScansiaVino = New System.Windows.Forms.TextBox()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.txtFormatoVino = New System.Windows.Forms.TextBox()
      Me.txtAnnoVino = New System.Windows.Forms.TextBox()
      Me.txtZonaVino = New System.Windows.Forms.TextBox()
      Me.txtRegioneVino = New System.Windows.Forms.TextBox()
      Me.txtProduttoreVino = New System.Windows.Forms.TextBox()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.Label33 = New System.Windows.Forms.Label()
      Me.Progressivi = New System.Windows.Forms.TabPage()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.txtValoreCarichi = New System.Windows.Forms.TextBox()
      Me.txtValoreScarichi = New System.Windows.Forms.TextBox()
      Me.Label47 = New System.Windows.Forms.Label()
      Me.Label51 = New System.Windows.Forms.Label()
      Me.txtValoreAttuale = New System.Windows.Forms.TextBox()
      Me.Label52 = New System.Windows.Forms.Label()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.txtValScarichi = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.txtValCarichi = New System.Windows.Forms.TextBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.txtValAttuale = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.txtTotScarichi = New System.Windows.Forms.TextBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.txtTotCarichi = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.txtGiacenza = New System.Windows.Forms.TextBox()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.txtScortaMinima = New System.Windows.Forms.TextBox()
      Me.Immagine = New System.Windows.Forms.TabPage()
      Me.cmdElimina = New System.Windows.Forms.Button()
      Me.cmdApri = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.Note = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.txtListino10 = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.txtListino9 = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.txtListino8 = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.txtListino7 = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.txtListino6 = New System.Windows.Forms.TextBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.txtListino5 = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtListino4 = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtListino3 = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtListino2 = New System.Windows.Forms.TextBox()
      Me.Label61 = New System.Windows.Forms.Label()
      Me.txtListino1 = New System.Windows.Forms.TextBox()
      Me.Label49 = New System.Windows.Forms.Label()
      Me.Label50 = New System.Windows.Forms.Label()
      Me.Label48 = New System.Windows.Forms.Label()
      Me.lbl35 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.txtPesoLordo = New System.Windows.Forms.TextBox()
      Me.txtPesoNetto = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtVolumeLordo = New System.Windows.Forms.TextBox()
      Me.txtVolumeNetto = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtProfonditaLordo = New System.Windows.Forms.TextBox()
      Me.txtProfonditaNetto = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtAltezzaLordo = New System.Windows.Forms.TextBox()
      Me.txtAltezzaNetto = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtLarghezzaLordo = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbUnitaMisuraDimensionePeso2 = New System.Windows.Forms.ComboBox()
      Me.UnitaMisuraDimensione = New System.Windows.Forms.ComboBox()
      Me.txtLarghezzaNetto = New System.Windows.Forms.TextBox()
      Me.Label53 = New System.Windows.Forms.Label()
      Me.txtPeso = New System.Windows.Forms.TextBox()
      Me.Label55 = New System.Windows.Forms.Label()
      Me.txtDimensione = New System.Windows.Forms.TextBox()
      Me.Label56 = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.TabControl1.SuspendLayout()
      Me.DatiPrincipale.SuspendLayout()
      Me.InfoVini.SuspendLayout()
      Me.Progressivi.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.Immagine.SuspendLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Note.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.DatiPrincipale)
      Me.TabControl1.Controls.Add(Me.InfoVini)
      Me.TabControl1.Controls.Add(Me.Progressivi)
      Me.TabControl1.Controls.Add(Me.Immagine)
      Me.TabControl1.Controls.Add(Me.Note)
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(540, 318)
      Me.TabControl1.TabIndex = 0
      '
      'DatiPrincipale
      '
      Me.DatiPrincipale.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.DatiPrincipale.Controls.Add(Me.cmdCalcolaPrezzo)
      Me.DatiPrincipale.Controls.Add(Me.cmbScaffale)
      Me.DatiPrincipale.Controls.Add(Me.Label35)
      Me.DatiPrincipale.Controls.Add(Me.txtPrezzoAcquisto)
      Me.DatiPrincipale.Controls.Add(Me.txtAliquotaIVA)
      Me.DatiPrincipale.Controls.Add(Me.cmbUbicazione)
      Me.DatiPrincipale.Controls.Add(Me.cmbMagazzino)
      Me.DatiPrincipale.Controls.Add(Me.cmbSottocategoria)
      Me.DatiPrincipale.Controls.Add(Me.Label36)
      Me.DatiPrincipale.Controls.Add(Me.cmbUM)
      Me.DatiPrincipale.Controls.Add(Me.txtDescrizione)
      Me.DatiPrincipale.Controls.Add(Me.txtCodiceBarre)
      Me.DatiPrincipale.Controls.Add(Me.cmbCategoria)
      Me.DatiPrincipale.Controls.Add(Me.cmbFornitore)
      Me.DatiPrincipale.Controls.Add(Me.Label39)
      Me.DatiPrincipale.Controls.Add(Me.Label40)
      Me.DatiPrincipale.Controls.Add(Me.Label41)
      Me.DatiPrincipale.Controls.Add(Me.Label42)
      Me.DatiPrincipale.Controls.Add(Me.Label43)
      Me.DatiPrincipale.Controls.Add(Me.Label44)
      Me.DatiPrincipale.Controls.Add(Me.txtCodice)
      Me.DatiPrincipale.Controls.Add(Me.Label45)
      Me.DatiPrincipale.Controls.Add(Me.Label46)
      Me.DatiPrincipale.Controls.Add(Me.Label37)
      Me.DatiPrincipale.Controls.Add(Me.Label38)
      Me.DatiPrincipale.Location = New System.Drawing.Point(4, 22)
      Me.DatiPrincipale.Name = "DatiPrincipale"
      Me.DatiPrincipale.Size = New System.Drawing.Size(532, 292)
      Me.DatiPrincipale.TabIndex = 1
      Me.DatiPrincipale.Text = " Dati principali"
      Me.DatiPrincipale.Visible = False
      '
      'cmdCalcolaPrezzo
      '
      Me.cmdCalcolaPrezzo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdCalcolaPrezzo.Location = New System.Drawing.Point(492, 88)
      Me.cmdCalcolaPrezzo.Name = "cmdCalcolaPrezzo"
      Me.cmdCalcolaPrezzo.Size = New System.Drawing.Size(20, 20)
      Me.cmdCalcolaPrezzo.TabIndex = 55786
      Me.cmdCalcolaPrezzo.Text = "..."
      Me.ToolTip1.SetToolTip(Me.cmdCalcolaPrezzo, "Apri la calcolatrice")
      '
      'cmbScaffale
      '
      Me.cmbScaffale.Location = New System.Drawing.Point(112, 248)
      Me.cmbScaffale.MaxLength = 32767
      Me.cmbScaffale.Name = "cmbScaffale"
      Me.cmbScaffale.Size = New System.Drawing.Size(248, 21)
      Me.cmbScaffale.TabIndex = 9
      '
      'Label35
      '
      Me.Label35.AutoSize = True
      Me.Label35.ForeColor = System.Drawing.Color.Black
      Me.Label35.Location = New System.Drawing.Point(24, 248)
      Me.Label35.Name = "Label35"
      Me.Label35.Size = New System.Drawing.Size(49, 13)
      Me.Label35.TabIndex = 55785
      Me.Label35.Text = "Scaffale:"
      '
      'txtPrezzoAcquisto
      '
      Me.txtPrezzoAcquisto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPrezzoAcquisto.Location = New System.Drawing.Point(360, 88)
      Me.txtPrezzoAcquisto.Name = "txtPrezzoAcquisto"
      Me.txtPrezzoAcquisto.Size = New System.Drawing.Size(132, 20)
      Me.txtPrezzoAcquisto.TabIndex = 4
      Me.txtPrezzoAcquisto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAliquotaIVA
      '
      Me.txtAliquotaIVA.Location = New System.Drawing.Point(112, 280)
      Me.txtAliquotaIVA.Name = "txtAliquotaIVA"
      Me.txtAliquotaIVA.Size = New System.Drawing.Size(152, 21)
      Me.txtAliquotaIVA.TabIndex = 9
      Me.txtAliquotaIVA.Visible = False
      '
      'cmbUbicazione
      '
      Me.cmbUbicazione.Location = New System.Drawing.Point(112, 216)
      Me.cmbUbicazione.MaxLength = 32767
      Me.cmbUbicazione.Name = "cmbUbicazione"
      Me.cmbUbicazione.Size = New System.Drawing.Size(248, 21)
      Me.cmbUbicazione.TabIndex = 8
      '
      'cmbMagazzino
      '
      Me.cmbMagazzino.Location = New System.Drawing.Point(112, 184)
      Me.cmbMagazzino.MaxLength = 32767
      Me.cmbMagazzino.Name = "cmbMagazzino"
      Me.cmbMagazzino.Size = New System.Drawing.Size(248, 21)
      Me.cmbMagazzino.TabIndex = 7
      '
      'cmbSottocategoria
      '
      Me.cmbSottocategoria.Location = New System.Drawing.Point(360, 280)
      Me.cmbSottocategoria.Name = "cmbSottocategoria"
      Me.cmbSottocategoria.Size = New System.Drawing.Size(152, 21)
      Me.cmbSottocategoria.TabIndex = 55780
      Me.cmbSottocategoria.Visible = False
      '
      'Label36
      '
      Me.Label36.AutoSize = True
      Me.Label36.ForeColor = System.Drawing.Color.Black
      Me.Label36.Location = New System.Drawing.Point(280, 280)
      Me.Label36.Name = "Label36"
      Me.Label36.Size = New System.Drawing.Size(79, 13)
      Me.Label36.TabIndex = 55779
      Me.Label36.Text = "Sottocategoria:"
      Me.Label36.Visible = False
      '
      'cmbUM
      '
      Me.cmbUM.Location = New System.Drawing.Point(112, 88)
      Me.cmbUM.Name = "cmbUM"
      Me.cmbUM.Size = New System.Drawing.Size(144, 21)
      Me.cmbUM.TabIndex = 3
      '
      'txtDescrizione
      '
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.Location = New System.Drawing.Point(112, 56)
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.Size = New System.Drawing.Size(400, 20)
      Me.txtDescrizione.TabIndex = 2
      '
      'txtCodiceBarre
      '
      Me.txtCodiceBarre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodiceBarre.Location = New System.Drawing.Point(360, 24)
      Me.txtCodiceBarre.Name = "txtCodiceBarre"
      Me.txtCodiceBarre.Size = New System.Drawing.Size(152, 20)
      Me.txtCodiceBarre.TabIndex = 1
      '
      'cmbCategoria
      '
      Me.cmbCategoria.Location = New System.Drawing.Point(112, 152)
      Me.cmbCategoria.MaxLength = 32767
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(248, 21)
      Me.cmbCategoria.TabIndex = 6
      '
      'cmbFornitore
      '
      Me.cmbFornitore.Location = New System.Drawing.Point(112, 120)
      Me.cmbFornitore.MaxLength = 32767
      Me.cmbFornitore.Name = "cmbFornitore"
      Me.cmbFornitore.Size = New System.Drawing.Size(400, 21)
      Me.cmbFornitore.TabIndex = 5
      '
      'Label39
      '
      Me.Label39.AutoSize = True
      Me.Label39.ForeColor = System.Drawing.Color.Black
      Me.Label39.Location = New System.Drawing.Point(264, 88)
      Me.Label39.Name = "Label39"
      Me.Label39.Size = New System.Drawing.Size(96, 13)
      Me.Label39.TabIndex = 55771
      Me.Label39.Text = "Prezzo di acquisto:"
      '
      'Label40
      '
      Me.Label40.AutoSize = True
      Me.Label40.ForeColor = System.Drawing.Color.Black
      Me.Label40.Location = New System.Drawing.Point(16, 280)
      Me.Label40.Name = "Label40"
      Me.Label40.Size = New System.Drawing.Size(77, 13)
      Me.Label40.TabIndex = 55770
      Me.Label40.Text = "Aliquota I.V.A.:"
      Me.Label40.Visible = False
      '
      'Label41
      '
      Me.Label41.AutoSize = True
      Me.Label41.ForeColor = System.Drawing.Color.Black
      Me.Label41.Location = New System.Drawing.Point(24, 216)
      Me.Label41.Name = "Label41"
      Me.Label41.Size = New System.Drawing.Size(63, 13)
      Me.Label41.TabIndex = 55769
      Me.Label41.Text = "Ubicazione:"
      '
      'Label42
      '
      Me.Label42.AutoSize = True
      Me.Label42.ForeColor = System.Drawing.Color.Black
      Me.Label42.Location = New System.Drawing.Point(24, 184)
      Me.Label42.Name = "Label42"
      Me.Label42.Size = New System.Drawing.Size(61, 13)
      Me.Label42.TabIndex = 55768
      Me.Label42.Text = "Magazzino:"
      '
      'Label43
      '
      Me.Label43.AutoSize = True
      Me.Label43.ForeColor = System.Drawing.Color.Black
      Me.Label43.Location = New System.Drawing.Point(24, 152)
      Me.Label43.Name = "Label43"
      Me.Label43.Size = New System.Drawing.Size(55, 13)
      Me.Label43.TabIndex = 55767
      Me.Label43.Text = "Categoria:"
      '
      'Label44
      '
      Me.Label44.AutoSize = True
      Me.Label44.ForeColor = System.Drawing.Color.Black
      Me.Label44.Location = New System.Drawing.Point(24, 120)
      Me.Label44.Name = "Label44"
      Me.Label44.Size = New System.Drawing.Size(51, 13)
      Me.Label44.TabIndex = 55766
      Me.Label44.Text = "Fornitore:"
      '
      'txtCodice
      '
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtCodice.Location = New System.Drawing.Point(112, 24)
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.Size = New System.Drawing.Size(144, 20)
      Me.txtCodice.TabIndex = 0
      '
      'Label45
      '
      Me.Label45.AutoSize = True
      Me.Label45.ForeColor = System.Drawing.Color.Black
      Me.Label45.Location = New System.Drawing.Point(24, 56)
      Me.Label45.Name = "Label45"
      Me.Label45.Size = New System.Drawing.Size(65, 13)
      Me.Label45.TabIndex = 55764
      Me.Label45.Text = "Descrizione:"
      '
      'Label46
      '
      Me.Label46.AutoSize = True
      Me.Label46.ForeColor = System.Drawing.Color.Black
      Me.Label46.Location = New System.Drawing.Point(24, 24)
      Me.Label46.Name = "Label46"
      Me.Label46.Size = New System.Drawing.Size(43, 13)
      Me.Label46.TabIndex = 55763
      Me.Label46.Text = "Codice:"
      '
      'Label37
      '
      Me.Label37.AutoSize = True
      Me.Label37.ForeColor = System.Drawing.Color.Black
      Me.Label37.Location = New System.Drawing.Point(24, 88)
      Me.Label37.Name = "Label37"
      Me.Label37.Size = New System.Drawing.Size(79, 13)
      Me.Label37.TabIndex = 55778
      Me.Label37.Text = "Unit‡ di misura:"
      '
      'Label38
      '
      Me.Label38.AutoSize = True
      Me.Label38.ForeColor = System.Drawing.Color.Black
      Me.Label38.Location = New System.Drawing.Point(264, 24)
      Me.Label38.Name = "Label38"
      Me.Label38.Size = New System.Drawing.Size(80, 13)
      Me.Label38.TabIndex = 55775
      Me.Label38.Text = "Codice a Barre:"
      '
      'InfoVini
      '
      Me.InfoVini.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.InfoVini.Controls.Add(Me.txtScansiaVino)
      Me.InfoVini.Controls.Add(Me.Label28)
      Me.InfoVini.Controls.Add(Me.txtFormatoVino)
      Me.InfoVini.Controls.Add(Me.txtAnnoVino)
      Me.InfoVini.Controls.Add(Me.txtZonaVino)
      Me.InfoVini.Controls.Add(Me.txtRegioneVino)
      Me.InfoVini.Controls.Add(Me.txtProduttoreVino)
      Me.InfoVini.Controls.Add(Me.Label29)
      Me.InfoVini.Controls.Add(Me.Label30)
      Me.InfoVini.Controls.Add(Me.Label31)
      Me.InfoVini.Controls.Add(Me.Label32)
      Me.InfoVini.Controls.Add(Me.Label33)
      Me.InfoVini.Location = New System.Drawing.Point(4, 22)
      Me.InfoVini.Name = "InfoVini"
      Me.InfoVini.Size = New System.Drawing.Size(532, 292)
      Me.InfoVini.TabIndex = 8
      Me.InfoVini.Text = "Informazioni vini"
      '
      'txtScansiaVino
      '
      Me.txtScansiaVino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScansiaVino.Location = New System.Drawing.Point(128, 184)
      Me.txtScansiaVino.Name = "txtScansiaVino"
      Me.txtScansiaVino.Size = New System.Drawing.Size(104, 20)
      Me.txtScansiaVino.TabIndex = 55785
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.ForeColor = System.Drawing.Color.Black
      Me.Label28.Location = New System.Drawing.Point(24, 184)
      Me.Label28.Name = "Label28"
      Me.Label28.Size = New System.Drawing.Size(45, 13)
      Me.Label28.TabIndex = 55786
      Me.Label28.Text = "Scansia"
      '
      'txtFormatoVino
      '
      Me.txtFormatoVino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtFormatoVino.Location = New System.Drawing.Point(128, 152)
      Me.txtFormatoVino.Name = "txtFormatoVino"
      Me.txtFormatoVino.Size = New System.Drawing.Size(208, 20)
      Me.txtFormatoVino.TabIndex = 4
      '
      'txtAnnoVino
      '
      Me.txtAnnoVino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtAnnoVino.Location = New System.Drawing.Point(128, 120)
      Me.txtAnnoVino.MaxLength = 4
      Me.txtAnnoVino.Name = "txtAnnoVino"
      Me.txtAnnoVino.Size = New System.Drawing.Size(104, 20)
      Me.txtAnnoVino.TabIndex = 3
      '
      'txtZonaVino
      '
      Me.txtZonaVino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtZonaVino.Location = New System.Drawing.Point(128, 88)
      Me.txtZonaVino.Name = "txtZonaVino"
      Me.txtZonaVino.Size = New System.Drawing.Size(208, 20)
      Me.txtZonaVino.TabIndex = 2
      '
      'txtRegioneVino
      '
      Me.txtRegioneVino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRegioneVino.Location = New System.Drawing.Point(128, 56)
      Me.txtRegioneVino.Name = "txtRegioneVino"
      Me.txtRegioneVino.Size = New System.Drawing.Size(208, 20)
      Me.txtRegioneVino.TabIndex = 1
      '
      'txtProduttoreVino
      '
      Me.txtProduttoreVino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProduttoreVino.Location = New System.Drawing.Point(128, 24)
      Me.txtProduttoreVino.Name = "txtProduttoreVino"
      Me.txtProduttoreVino.Size = New System.Drawing.Size(376, 20)
      Me.txtProduttoreVino.TabIndex = 0
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.ForeColor = System.Drawing.Color.Black
      Me.Label29.Location = New System.Drawing.Point(24, 152)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(48, 13)
      Me.Label29.TabIndex = 55782
      Me.Label29.Text = "Formato:"
      '
      'Label30
      '
      Me.Label30.AutoSize = True
      Me.Label30.ForeColor = System.Drawing.Color.Black
      Me.Label30.Location = New System.Drawing.Point(24, 120)
      Me.Label30.Name = "Label30"
      Me.Label30.Size = New System.Drawing.Size(35, 13)
      Me.Label30.TabIndex = 55781
      Me.Label30.Text = "Anno:"
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(24, 88)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(101, 13)
      Me.Label31.TabIndex = 55780
      Me.Label31.Text = "Zona di produzione:"
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.ForeColor = System.Drawing.Color.Black
      Me.Label32.Location = New System.Drawing.Point(24, 56)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(50, 13)
      Me.Label32.TabIndex = 55779
      Me.Label32.Text = "Regione:"
      '
      'Label33
      '
      Me.Label33.AutoSize = True
      Me.Label33.ForeColor = System.Drawing.Color.Black
      Me.Label33.Location = New System.Drawing.Point(24, 24)
      Me.Label33.Name = "Label33"
      Me.Label33.Size = New System.Drawing.Size(59, 13)
      Me.Label33.TabIndex = 55784
      Me.Label33.Text = "Produttore:"
      '
      'Progressivi
      '
      Me.Progressivi.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Progressivi.Controls.Add(Me.GroupBox3)
      Me.Progressivi.Controls.Add(Me.GroupBox2)
      Me.Progressivi.Controls.Add(Me.GroupBox1)
      Me.Progressivi.Location = New System.Drawing.Point(4, 22)
      Me.Progressivi.Name = "Progressivi"
      Me.Progressivi.Size = New System.Drawing.Size(532, 292)
      Me.Progressivi.TabIndex = 7
      Me.Progressivi.Text = "Progressivi"
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.txtValoreCarichi)
      Me.GroupBox3.Controls.Add(Me.txtValoreScarichi)
      Me.GroupBox3.Controls.Add(Me.Label47)
      Me.GroupBox3.Controls.Add(Me.Label51)
      Me.GroupBox3.Controls.Add(Me.txtValoreAttuale)
      Me.GroupBox3.Controls.Add(Me.Label52)
      Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.GroupBox3.Location = New System.Drawing.Point(272, 16)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(248, 264)
      Me.GroupBox3.TabIndex = 1
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Valori"
      '
      'txtValoreCarichi
      '
      Me.txtValoreCarichi.BackColor = System.Drawing.SystemColors.Window
      Me.txtValoreCarichi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValoreCarichi.ForeColor = System.Drawing.Color.Red
      Me.txtValoreCarichi.Location = New System.Drawing.Point(112, 32)
      Me.txtValoreCarichi.Name = "txtValoreCarichi"
      Me.txtValoreCarichi.ReadOnly = True
      Me.txtValoreCarichi.Size = New System.Drawing.Size(112, 20)
      Me.txtValoreCarichi.TabIndex = 55803
      Me.txtValoreCarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtValoreScarichi
      '
      Me.txtValoreScarichi.BackColor = System.Drawing.SystemColors.Control
      Me.txtValoreScarichi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValoreScarichi.ForeColor = System.Drawing.Color.Red
      Me.txtValoreScarichi.Location = New System.Drawing.Point(112, 64)
      Me.txtValoreScarichi.Name = "txtValoreScarichi"
      Me.txtValoreScarichi.ReadOnly = True
      Me.txtValoreScarichi.Size = New System.Drawing.Size(112, 20)
      Me.txtValoreScarichi.TabIndex = 1
      Me.txtValoreScarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label47
      '
      Me.Label47.AutoSize = True
      Me.Label47.ForeColor = System.Drawing.Color.Black
      Me.Label47.Location = New System.Drawing.Point(16, 64)
      Me.Label47.Name = "Label47"
      Me.Label47.Size = New System.Drawing.Size(81, 13)
      Me.Label47.TabIndex = 55802
      Me.Label47.Text = "Valore Scarichi:"
      '
      'Label51
      '
      Me.Label51.AutoSize = True
      Me.Label51.ForeColor = System.Drawing.Color.Black
      Me.Label51.Location = New System.Drawing.Point(16, 32)
      Me.Label51.Name = "Label51"
      Me.Label51.Size = New System.Drawing.Size(75, 13)
      Me.Label51.TabIndex = 55800
      Me.Label51.Text = "Valore Carichi:"
      '
      'txtValoreAttuale
      '
      Me.txtValoreAttuale.BackColor = System.Drawing.SystemColors.Control
      Me.txtValoreAttuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValoreAttuale.ForeColor = System.Drawing.Color.Red
      Me.txtValoreAttuale.Location = New System.Drawing.Point(112, 96)
      Me.txtValoreAttuale.Name = "txtValoreAttuale"
      Me.txtValoreAttuale.ReadOnly = True
      Me.txtValoreAttuale.Size = New System.Drawing.Size(112, 20)
      Me.txtValoreAttuale.TabIndex = 2
      Me.txtValoreAttuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label52
      '
      Me.Label52.AutoSize = True
      Me.Label52.ForeColor = System.Drawing.Color.Black
      Me.Label52.Location = New System.Drawing.Point(16, 96)
      Me.Label52.Name = "Label52"
      Me.Label52.Size = New System.Drawing.Size(75, 13)
      Me.Label52.TabIndex = 55798
      Me.Label52.Text = "Valore attuale:"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.txtValScarichi)
      Me.GroupBox2.Controls.Add(Me.Label24)
      Me.GroupBox2.Controls.Add(Me.txtValCarichi)
      Me.GroupBox2.Controls.Add(Me.Label26)
      Me.GroupBox2.Controls.Add(Me.txtValAttuale)
      Me.GroupBox2.Controls.Add(Me.Label27)
      Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.GroupBox2.Location = New System.Drawing.Point(272, 16)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(248, 264)
      Me.GroupBox2.TabIndex = 1
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Valori"
      '
      'txtValScarichi
      '
      Me.txtValScarichi.BackColor = System.Drawing.SystemColors.Control
      Me.txtValScarichi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValScarichi.ForeColor = System.Drawing.Color.Red
      Me.txtValScarichi.Location = New System.Drawing.Point(112, 64)
      Me.txtValScarichi.Name = "txtValScarichi"
      Me.txtValScarichi.ReadOnly = True
      Me.txtValScarichi.Size = New System.Drawing.Size(112, 20)
      Me.txtValScarichi.TabIndex = 1
      Me.txtValScarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label24.Location = New System.Drawing.Point(16, 64)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(81, 13)
      Me.Label24.TabIndex = 55802
      Me.Label24.Text = "Valore Scarichi:"
      '
      'txtValCarichi
      '
      Me.txtValCarichi.BackColor = System.Drawing.SystemColors.Control
      Me.txtValCarichi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValCarichi.ForeColor = System.Drawing.Color.Red
      Me.txtValCarichi.Location = New System.Drawing.Point(112, 32)
      Me.txtValCarichi.Name = "txtValCarichi"
      Me.txtValCarichi.ReadOnly = True
      Me.txtValCarichi.Size = New System.Drawing.Size(112, 20)
      Me.txtValCarichi.TabIndex = 0
      Me.txtValCarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label26.Location = New System.Drawing.Point(16, 32)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(75, 13)
      Me.Label26.TabIndex = 55800
      Me.Label26.Text = "Valore Carichi:"
      '
      'txtValAttuale
      '
      Me.txtValAttuale.BackColor = System.Drawing.SystemColors.Control
      Me.txtValAttuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValAttuale.ForeColor = System.Drawing.Color.Red
      Me.txtValAttuale.Location = New System.Drawing.Point(112, 96)
      Me.txtValAttuale.Name = "txtValAttuale"
      Me.txtValAttuale.ReadOnly = True
      Me.txtValAttuale.Size = New System.Drawing.Size(112, 20)
      Me.txtValAttuale.TabIndex = 2
      Me.txtValAttuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label27.Location = New System.Drawing.Point(16, 96)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(75, 13)
      Me.Label27.TabIndex = 55798
      Me.Label27.Text = "Valore attuale:"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.txtTotScarichi)
      Me.GroupBox1.Controls.Add(Me.Label23)
      Me.GroupBox1.Controls.Add(Me.txtTotCarichi)
      Me.GroupBox1.Controls.Add(Me.Label22)
      Me.GroupBox1.Controls.Add(Me.txtGiacenza)
      Me.GroupBox1.Controls.Add(Me.Label34)
      Me.GroupBox1.Controls.Add(Me.Label25)
      Me.GroupBox1.Controls.Add(Me.txtScortaMinima)
      Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(248, 264)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Quantit‡"
      '
      'txtTotScarichi
      '
      Me.txtTotScarichi.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotScarichi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotScarichi.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtTotScarichi.Location = New System.Drawing.Point(112, 64)
      Me.txtTotScarichi.Name = "txtTotScarichi"
      Me.txtTotScarichi.ReadOnly = True
      Me.txtTotScarichi.Size = New System.Drawing.Size(112, 20)
      Me.txtTotScarichi.TabIndex = 1
      Me.txtTotScarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(16, 64)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(81, 13)
      Me.Label23.TabIndex = 55802
      Me.Label23.Text = "Totale Scarichi:"
      '
      'txtTotCarichi
      '
      Me.txtTotCarichi.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotCarichi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotCarichi.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtTotCarichi.Location = New System.Drawing.Point(112, 32)
      Me.txtTotCarichi.Name = "txtTotCarichi"
      Me.txtTotCarichi.ReadOnly = True
      Me.txtTotCarichi.Size = New System.Drawing.Size(112, 20)
      Me.txtTotCarichi.TabIndex = 0
      Me.txtTotCarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(16, 32)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(75, 13)
      Me.Label22.TabIndex = 55800
      Me.Label22.Text = "Totale Carichi:"
      '
      'txtGiacenza
      '
      Me.txtGiacenza.BackColor = System.Drawing.SystemColors.Control
      Me.txtGiacenza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtGiacenza.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtGiacenza.Location = New System.Drawing.Point(112, 96)
      Me.txtGiacenza.Name = "txtGiacenza"
      Me.txtGiacenza.ReadOnly = True
      Me.txtGiacenza.Size = New System.Drawing.Size(112, 20)
      Me.txtGiacenza.TabIndex = 2
      Me.txtGiacenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.ForeColor = System.Drawing.Color.Black
      Me.Label34.Location = New System.Drawing.Point(16, 96)
      Me.Label34.Name = "Label34"
      Me.Label34.Size = New System.Drawing.Size(55, 13)
      Me.Label34.TabIndex = 55798
      Me.Label34.Text = "Giacenza:"
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(16, 128)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(77, 13)
      Me.Label25.TabIndex = 55796
      Me.Label25.Text = "Scorta Minima:"
      '
      'txtScortaMinima
      '
      Me.txtScortaMinima.BackColor = System.Drawing.SystemColors.Window
      Me.txtScortaMinima.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScortaMinima.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtScortaMinima.Location = New System.Drawing.Point(112, 128)
      Me.txtScortaMinima.Name = "txtScortaMinima"
      Me.txtScortaMinima.Size = New System.Drawing.Size(112, 20)
      Me.txtScortaMinima.TabIndex = 3
      Me.txtScortaMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Immagine
      '
      Me.Immagine.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Immagine.Controls.Add(Me.cmdElimina)
      Me.Immagine.Controls.Add(Me.cmdApri)
      Me.Immagine.Controls.Add(Me.picFoto)
      Me.Immagine.Location = New System.Drawing.Point(4, 22)
      Me.Immagine.Name = "Immagine"
      Me.Immagine.Size = New System.Drawing.Size(532, 292)
      Me.Immagine.TabIndex = 4
      Me.Immagine.Text = "Immagine"
      Me.Immagine.Visible = False
      '
      'cmdElimina
      '
      Me.cmdElimina.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdElimina.Location = New System.Drawing.Point(432, 264)
      Me.cmdElimina.Name = "cmdElimina"
      Me.cmdElimina.Size = New System.Drawing.Size(88, 24)
      Me.cmdElimina.TabIndex = 1
      Me.cmdElimina.Text = "&Elimina"
      '
      'cmdApri
      '
      Me.cmdApri.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApri.Location = New System.Drawing.Point(344, 264)
      Me.cmdApri.Name = "cmdApri"
      Me.cmdApri.Size = New System.Drawing.Size(80, 24)
      Me.cmdApri.TabIndex = 0
      Me.cmdApri.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.Color.White
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(10, 8)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(512, 248)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 179
      Me.picFoto.TabStop = False
      '
      'Note
      '
      Me.Note.Controls.Add(Me.txtNote)
      Me.Note.Location = New System.Drawing.Point(4, 22)
      Me.Note.Name = "Note"
      Me.Note.Size = New System.Drawing.Size(532, 292)
      Me.Note.TabIndex = 6
      Me.Note.Text = "Note"
      Me.Note.Visible = False
      '
      'txtNote
      '
      Me.txtNote.Location = New System.Drawing.Point(0, 0)
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(532, 292)
      Me.txtNote.TabIndex = 0
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
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
      Me.Panel1.Size = New System.Drawing.Size(542, 20)
      Me.Panel1.TabIndex = 10
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
      Me.ToolBar1.Size = New System.Drawing.Size(542, 26)
      Me.ToolBar1.TabIndex = 9
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
      'Label21
      '
      Me.Label21.ForeColor = System.Drawing.Color.Blue
      Me.Label21.Location = New System.Drawing.Point(680, 56)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(56, 16)
      Me.Label21.TabIndex = 55760
      Me.Label21.Text = "Prezzo:"
      Me.Label21.Visible = False
      '
      'Label19
      '
      Me.Label19.ForeColor = System.Drawing.Color.Blue
      Me.Label19.Location = New System.Drawing.Point(624, 296)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(56, 16)
      Me.Label19.TabIndex = 55759
      Me.Label19.Text = "Listino 10:"
      Me.Label19.Visible = False
      '
      'txtListino10
      '
      Me.txtListino10.BackColor = System.Drawing.Color.White
      Me.txtListino10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino10.Location = New System.Drawing.Point(680, 296)
      Me.txtListino10.MaxLength = 255
      Me.txtListino10.Name = "txtListino10"
      Me.txtListino10.Size = New System.Drawing.Size(184, 20)
      Me.txtListino10.TabIndex = 55758
      Me.txtListino10.Visible = False
      '
      'Label20
      '
      Me.Label20.ForeColor = System.Drawing.Color.Blue
      Me.Label20.Location = New System.Drawing.Point(624, 272)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(56, 16)
      Me.Label20.TabIndex = 55757
      Me.Label20.Text = "Listino 9:"
      Me.Label20.Visible = False
      '
      'txtListino9
      '
      Me.txtListino9.BackColor = System.Drawing.Color.White
      Me.txtListino9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino9.Location = New System.Drawing.Point(680, 272)
      Me.txtListino9.MaxLength = 255
      Me.txtListino9.Name = "txtListino9"
      Me.txtListino9.Size = New System.Drawing.Size(184, 20)
      Me.txtListino9.TabIndex = 55756
      Me.txtListino9.Visible = False
      '
      'Label15
      '
      Me.Label15.ForeColor = System.Drawing.Color.Blue
      Me.Label15.Location = New System.Drawing.Point(624, 248)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(56, 16)
      Me.Label15.TabIndex = 55755
      Me.Label15.Text = "Listino 8:"
      Me.Label15.Visible = False
      '
      'txtListino8
      '
      Me.txtListino8.BackColor = System.Drawing.Color.White
      Me.txtListino8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino8.Location = New System.Drawing.Point(680, 248)
      Me.txtListino8.MaxLength = 255
      Me.txtListino8.Name = "txtListino8"
      Me.txtListino8.Size = New System.Drawing.Size(184, 20)
      Me.txtListino8.TabIndex = 55754
      Me.txtListino8.Visible = False
      '
      'Label16
      '
      Me.Label16.ForeColor = System.Drawing.Color.Blue
      Me.Label16.Location = New System.Drawing.Point(624, 224)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(56, 16)
      Me.Label16.TabIndex = 55753
      Me.Label16.Text = "Listino 7:"
      Me.Label16.Visible = False
      '
      'txtListino7
      '
      Me.txtListino7.BackColor = System.Drawing.Color.White
      Me.txtListino7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino7.Location = New System.Drawing.Point(680, 224)
      Me.txtListino7.MaxLength = 255
      Me.txtListino7.Name = "txtListino7"
      Me.txtListino7.Size = New System.Drawing.Size(184, 20)
      Me.txtListino7.TabIndex = 55752
      Me.txtListino7.Visible = False
      '
      'Label17
      '
      Me.Label17.ForeColor = System.Drawing.Color.Blue
      Me.Label17.Location = New System.Drawing.Point(624, 200)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(56, 16)
      Me.Label17.TabIndex = 55751
      Me.Label17.Text = "Listino 6:"
      Me.Label17.Visible = False
      '
      'txtListino6
      '
      Me.txtListino6.BackColor = System.Drawing.Color.White
      Me.txtListino6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino6.Location = New System.Drawing.Point(680, 200)
      Me.txtListino6.MaxLength = 255
      Me.txtListino6.Name = "txtListino6"
      Me.txtListino6.Size = New System.Drawing.Size(184, 20)
      Me.txtListino6.TabIndex = 55750
      Me.txtListino6.Visible = False
      '
      'Label18
      '
      Me.Label18.ForeColor = System.Drawing.Color.Blue
      Me.Label18.Location = New System.Drawing.Point(624, 176)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(56, 16)
      Me.Label18.TabIndex = 55749
      Me.Label18.Text = "Listino 5:"
      Me.Label18.Visible = False
      '
      'txtListino5
      '
      Me.txtListino5.BackColor = System.Drawing.Color.White
      Me.txtListino5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino5.Location = New System.Drawing.Point(680, 176)
      Me.txtListino5.MaxLength = 255
      Me.txtListino5.Name = "txtListino5"
      Me.txtListino5.Size = New System.Drawing.Size(184, 20)
      Me.txtListino5.TabIndex = 55748
      Me.txtListino5.Visible = False
      '
      'Label13
      '
      Me.Label13.ForeColor = System.Drawing.Color.Blue
      Me.Label13.Location = New System.Drawing.Point(624, 152)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(56, 16)
      Me.Label13.TabIndex = 55747
      Me.Label13.Text = "Listino 4:"
      Me.Label13.Visible = False
      '
      'txtListino4
      '
      Me.txtListino4.BackColor = System.Drawing.Color.White
      Me.txtListino4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino4.Location = New System.Drawing.Point(680, 152)
      Me.txtListino4.MaxLength = 255
      Me.txtListino4.Name = "txtListino4"
      Me.txtListino4.Size = New System.Drawing.Size(184, 20)
      Me.txtListino4.TabIndex = 55746
      Me.txtListino4.Visible = False
      '
      'Label14
      '
      Me.Label14.ForeColor = System.Drawing.Color.Blue
      Me.Label14.Location = New System.Drawing.Point(624, 128)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(56, 16)
      Me.Label14.TabIndex = 55745
      Me.Label14.Text = "Listino 3:"
      Me.Label14.Visible = False
      '
      'txtListino3
      '
      Me.txtListino3.BackColor = System.Drawing.Color.White
      Me.txtListino3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino3.Location = New System.Drawing.Point(680, 128)
      Me.txtListino3.MaxLength = 255
      Me.txtListino3.Name = "txtListino3"
      Me.txtListino3.Size = New System.Drawing.Size(184, 20)
      Me.txtListino3.TabIndex = 55744
      Me.txtListino3.Visible = False
      '
      'Label12
      '
      Me.Label12.ForeColor = System.Drawing.Color.Blue
      Me.Label12.Location = New System.Drawing.Point(624, 104)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(56, 16)
      Me.Label12.TabIndex = 55743
      Me.Label12.Text = "Listino 2:"
      Me.Label12.Visible = False
      '
      'txtListino2
      '
      Me.txtListino2.BackColor = System.Drawing.Color.White
      Me.txtListino2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino2.Location = New System.Drawing.Point(680, 104)
      Me.txtListino2.MaxLength = 255
      Me.txtListino2.Name = "txtListino2"
      Me.txtListino2.Size = New System.Drawing.Size(184, 20)
      Me.txtListino2.TabIndex = 55742
      Me.txtListino2.Visible = False
      '
      'Label61
      '
      Me.Label61.ForeColor = System.Drawing.Color.Blue
      Me.Label61.Location = New System.Drawing.Point(624, 80)
      Me.Label61.Name = "Label61"
      Me.Label61.Size = New System.Drawing.Size(56, 16)
      Me.Label61.TabIndex = 55741
      Me.Label61.Text = "Listino 1:"
      Me.Label61.Visible = False
      '
      'txtListino1
      '
      Me.txtListino1.BackColor = System.Drawing.Color.White
      Me.txtListino1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtListino1.Location = New System.Drawing.Point(680, 80)
      Me.txtListino1.MaxLength = 255
      Me.txtListino1.Name = "txtListino1"
      Me.txtListino1.Size = New System.Drawing.Size(184, 20)
      Me.txtListino1.TabIndex = 55740
      Me.txtListino1.Visible = False
      '
      'Label49
      '
      Me.Label49.ForeColor = System.Drawing.Color.Blue
      Me.Label49.Location = New System.Drawing.Point(1040, 400)
      Me.Label49.Name = "Label49"
      Me.Label49.Size = New System.Drawing.Size(48, 16)
      Me.Label49.TabIndex = 55792
      Me.Label49.Text = "Lordo"
      Me.Label49.Visible = False
      '
      'Label50
      '
      Me.Label50.ForeColor = System.Drawing.Color.Blue
      Me.Label50.Location = New System.Drawing.Point(968, 400)
      Me.Label50.Name = "Label50"
      Me.Label50.Size = New System.Drawing.Size(48, 16)
      Me.Label50.TabIndex = 55791
      Me.Label50.Text = "Netto"
      Me.Label50.Visible = False
      '
      'Label48
      '
      Me.Label48.ForeColor = System.Drawing.Color.Blue
      Me.Label48.Location = New System.Drawing.Point(776, 400)
      Me.Label48.Name = "Label48"
      Me.Label48.Size = New System.Drawing.Size(48, 16)
      Me.Label48.TabIndex = 55790
      Me.Label48.Text = "Lordo"
      Me.Label48.Visible = False
      '
      'lbl35
      '
      Me.lbl35.ForeColor = System.Drawing.Color.Blue
      Me.lbl35.Location = New System.Drawing.Point(704, 400)
      Me.lbl35.Name = "lbl35"
      Me.lbl35.Size = New System.Drawing.Size(48, 16)
      Me.lbl35.TabIndex = 55789
      Me.lbl35.Text = "Netto"
      Me.lbl35.Visible = False
      '
      'Label10
      '
      Me.Label10.ForeColor = System.Drawing.Color.Blue
      Me.Label10.Location = New System.Drawing.Point(1112, 416)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(39, 16)
      Me.Label10.TabIndex = 55788
      Me.Label10.Text = "Kg"
      Me.Label10.Visible = False
      '
      'txtPesoLordo
      '
      Me.txtPesoLordo.BackColor = System.Drawing.Color.White
      Me.txtPesoLordo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPesoLordo.Location = New System.Drawing.Point(1040, 416)
      Me.txtPesoLordo.MaxLength = 255
      Me.txtPesoLordo.Name = "txtPesoLordo"
      Me.txtPesoLordo.Size = New System.Drawing.Size(64, 20)
      Me.txtPesoLordo.TabIndex = 55787
      Me.txtPesoLordo.Visible = False
      '
      'txtPesoNetto
      '
      Me.txtPesoNetto.BackColor = System.Drawing.Color.White
      Me.txtPesoNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPesoNetto.Location = New System.Drawing.Point(968, 416)
      Me.txtPesoNetto.MaxLength = 255
      Me.txtPesoNetto.Name = "txtPesoNetto"
      Me.txtPesoNetto.Size = New System.Drawing.Size(64, 20)
      Me.txtPesoNetto.TabIndex = 55786
      Me.txtPesoNetto.Visible = False
      '
      'Label11
      '
      Me.Label11.ForeColor = System.Drawing.Color.Blue
      Me.Label11.Location = New System.Drawing.Point(896, 416)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(64, 16)
      Me.Label11.TabIndex = 55785
      Me.Label11.Text = "Peso"
      Me.Label11.Visible = False
      '
      'Label9
      '
      Me.Label9.ForeColor = System.Drawing.Color.Blue
      Me.Label9.Location = New System.Drawing.Point(848, 512)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(39, 16)
      Me.Label9.TabIndex = 55784
      Me.Label9.Text = "cm"
      Me.Label9.Visible = False
      '
      'Label8
      '
      Me.Label8.ForeColor = System.Drawing.Color.Blue
      Me.Label8.Location = New System.Drawing.Point(848, 480)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(39, 16)
      Me.Label8.TabIndex = 55783
      Me.Label8.Text = "cm"
      Me.Label8.Visible = False
      '
      'Label7
      '
      Me.Label7.ForeColor = System.Drawing.Color.Blue
      Me.Label7.Location = New System.Drawing.Point(848, 448)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(39, 16)
      Me.Label7.TabIndex = 55782
      Me.Label7.Text = "cm"
      Me.Label7.Visible = False
      '
      'Label6
      '
      Me.Label6.ForeColor = System.Drawing.Color.Blue
      Me.Label6.Location = New System.Drawing.Point(848, 416)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(39, 16)
      Me.Label6.TabIndex = 55781
      Me.Label6.Text = "cm"
      Me.Label6.Visible = False
      '
      'txtVolumeLordo
      '
      Me.txtVolumeLordo.BackColor = System.Drawing.Color.White
      Me.txtVolumeLordo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtVolumeLordo.Location = New System.Drawing.Point(776, 512)
      Me.txtVolumeLordo.MaxLength = 255
      Me.txtVolumeLordo.Name = "txtVolumeLordo"
      Me.txtVolumeLordo.Size = New System.Drawing.Size(64, 20)
      Me.txtVolumeLordo.TabIndex = 55780
      Me.txtVolumeLordo.Visible = False
      '
      'txtVolumeNetto
      '
      Me.txtVolumeNetto.BackColor = System.Drawing.Color.White
      Me.txtVolumeNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtVolumeNetto.Location = New System.Drawing.Point(704, 512)
      Me.txtVolumeNetto.MaxLength = 255
      Me.txtVolumeNetto.Name = "txtVolumeNetto"
      Me.txtVolumeNetto.Size = New System.Drawing.Size(64, 20)
      Me.txtVolumeNetto.TabIndex = 55779
      Me.txtVolumeNetto.Visible = False
      '
      'Label4
      '
      Me.Label4.ForeColor = System.Drawing.Color.Blue
      Me.Label4.Location = New System.Drawing.Point(608, 520)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(94, 16)
      Me.Label4.TabIndex = 55778
      Me.Label4.Text = "Volume"
      Me.Label4.Visible = False
      '
      'txtProfonditaLordo
      '
      Me.txtProfonditaLordo.BackColor = System.Drawing.Color.White
      Me.txtProfonditaLordo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProfonditaLordo.Location = New System.Drawing.Point(776, 480)
      Me.txtProfonditaLordo.MaxLength = 255
      Me.txtProfonditaLordo.Name = "txtProfonditaLordo"
      Me.txtProfonditaLordo.Size = New System.Drawing.Size(64, 20)
      Me.txtProfonditaLordo.TabIndex = 55777
      Me.txtProfonditaLordo.Visible = False
      '
      'txtProfonditaNetto
      '
      Me.txtProfonditaNetto.BackColor = System.Drawing.Color.White
      Me.txtProfonditaNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProfonditaNetto.Location = New System.Drawing.Point(704, 480)
      Me.txtProfonditaNetto.MaxLength = 255
      Me.txtProfonditaNetto.Name = "txtProfonditaNetto"
      Me.txtProfonditaNetto.Size = New System.Drawing.Size(64, 20)
      Me.txtProfonditaNetto.TabIndex = 55776
      Me.txtProfonditaNetto.Visible = False
      '
      'Label5
      '
      Me.Label5.ForeColor = System.Drawing.Color.Blue
      Me.Label5.Location = New System.Drawing.Point(608, 488)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(94, 16)
      Me.Label5.TabIndex = 55775
      Me.Label5.Text = "Profondit‡"
      Me.Label5.Visible = False
      '
      'txtAltezzaLordo
      '
      Me.txtAltezzaLordo.BackColor = System.Drawing.Color.White
      Me.txtAltezzaLordo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtAltezzaLordo.Location = New System.Drawing.Point(776, 448)
      Me.txtAltezzaLordo.MaxLength = 255
      Me.txtAltezzaLordo.Name = "txtAltezzaLordo"
      Me.txtAltezzaLordo.Size = New System.Drawing.Size(64, 20)
      Me.txtAltezzaLordo.TabIndex = 55774
      Me.txtAltezzaLordo.Visible = False
      '
      'txtAltezzaNetto
      '
      Me.txtAltezzaNetto.BackColor = System.Drawing.Color.White
      Me.txtAltezzaNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtAltezzaNetto.Location = New System.Drawing.Point(704, 448)
      Me.txtAltezzaNetto.MaxLength = 255
      Me.txtAltezzaNetto.Name = "txtAltezzaNetto"
      Me.txtAltezzaNetto.Size = New System.Drawing.Size(64, 20)
      Me.txtAltezzaNetto.TabIndex = 55773
      Me.txtAltezzaNetto.Visible = False
      '
      'Label3
      '
      Me.Label3.ForeColor = System.Drawing.Color.Blue
      Me.Label3.Location = New System.Drawing.Point(608, 456)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(94, 16)
      Me.Label3.TabIndex = 55772
      Me.Label3.Text = "Altezza"
      Me.Label3.Visible = False
      '
      'txtLarghezzaLordo
      '
      Me.txtLarghezzaLordo.BackColor = System.Drawing.Color.White
      Me.txtLarghezzaLordo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtLarghezzaLordo.Location = New System.Drawing.Point(776, 416)
      Me.txtLarghezzaLordo.MaxLength = 255
      Me.txtLarghezzaLordo.Name = "txtLarghezzaLordo"
      Me.txtLarghezzaLordo.Size = New System.Drawing.Size(64, 20)
      Me.txtLarghezzaLordo.TabIndex = 55771
      Me.txtLarghezzaLordo.Visible = False
      '
      'Label2
      '
      Me.Label2.ForeColor = System.Drawing.Color.Blue
      Me.Label2.Location = New System.Drawing.Point(880, 360)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(72, 16)
      Me.Label2.TabIndex = 55770
      Me.Label2.Text = "Unita di misura:"
      Me.Label2.Visible = False
      '
      'Label1
      '
      Me.Label1.ForeColor = System.Drawing.Color.Blue
      Me.Label1.Location = New System.Drawing.Point(608, 360)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(83, 16)
      Me.Label1.TabIndex = 55769
      Me.Label1.Text = "Unit‡ di misura:"
      Me.Label1.Visible = False
      '
      'cmbUnitaMisuraDimensionePeso2
      '
      Me.cmbUnitaMisuraDimensionePeso2.Location = New System.Drawing.Point(960, 360)
      Me.cmbUnitaMisuraDimensionePeso2.Name = "cmbUnitaMisuraDimensionePeso2"
      Me.cmbUnitaMisuraDimensionePeso2.Size = New System.Drawing.Size(136, 21)
      Me.cmbUnitaMisuraDimensionePeso2.TabIndex = 55768
      Me.cmbUnitaMisuraDimensionePeso2.Visible = False
      '
      'UnitaMisuraDimensione
      '
      Me.UnitaMisuraDimensione.Location = New System.Drawing.Point(696, 360)
      Me.UnitaMisuraDimensione.Name = "UnitaMisuraDimensione"
      Me.UnitaMisuraDimensione.Size = New System.Drawing.Size(136, 21)
      Me.UnitaMisuraDimensione.TabIndex = 55767
      Me.UnitaMisuraDimensione.Visible = False
      '
      'txtLarghezzaNetto
      '
      Me.txtLarghezzaNetto.BackColor = System.Drawing.Color.White
      Me.txtLarghezzaNetto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtLarghezzaNetto.Location = New System.Drawing.Point(704, 416)
      Me.txtLarghezzaNetto.MaxLength = 255
      Me.txtLarghezzaNetto.Name = "txtLarghezzaNetto"
      Me.txtLarghezzaNetto.Size = New System.Drawing.Size(64, 20)
      Me.txtLarghezzaNetto.TabIndex = 55766
      Me.txtLarghezzaNetto.Visible = False
      '
      'Label53
      '
      Me.Label53.ForeColor = System.Drawing.Color.Blue
      Me.Label53.Location = New System.Drawing.Point(608, 424)
      Me.Label53.Name = "Label53"
      Me.Label53.Size = New System.Drawing.Size(94, 16)
      Me.Label53.TabIndex = 55765
      Me.Label53.Text = "Larghezza"
      Me.Label53.Visible = False
      '
      'txtPeso
      '
      Me.txtPeso.BackColor = System.Drawing.Color.White
      Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPeso.Location = New System.Drawing.Point(960, 328)
      Me.txtPeso.MaxLength = 255
      Me.txtPeso.Name = "txtPeso"
      Me.txtPeso.Size = New System.Drawing.Size(136, 20)
      Me.txtPeso.TabIndex = 55764
      Me.txtPeso.Visible = False
      '
      'Label55
      '
      Me.Label55.ForeColor = System.Drawing.Color.Blue
      Me.Label55.Location = New System.Drawing.Point(880, 336)
      Me.Label55.Name = "Label55"
      Me.Label55.Size = New System.Drawing.Size(80, 16)
      Me.Label55.TabIndex = 55763
      Me.Label55.Text = "Peso:"
      Me.Label55.Visible = False
      '
      'txtDimensione
      '
      Me.txtDimensione.BackColor = System.Drawing.Color.White
      Me.txtDimensione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDimensione.Location = New System.Drawing.Point(696, 328)
      Me.txtDimensione.MaxLength = 255
      Me.txtDimensione.Name = "txtDimensione"
      Me.txtDimensione.Size = New System.Drawing.Size(136, 20)
      Me.txtDimensione.TabIndex = 55762
      Me.txtDimensione.Visible = False
      '
      'Label56
      '
      Me.Label56.ForeColor = System.Drawing.Color.Blue
      Me.Label56.Location = New System.Drawing.Point(608, 328)
      Me.Label56.Name = "Label56"
      Me.Label56.Size = New System.Drawing.Size(80, 16)
      Me.Label56.TabIndex = 55761
      Me.Label56.Text = "Dimensioni:"
      Me.Label56.Visible = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmArticoli
      '
      Me.AcceptButton = Me.cmdApri
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(542, 366)
      Me.Controls.Add(Me.Label49)
      Me.Controls.Add(Me.Label50)
      Me.Controls.Add(Me.Label48)
      Me.Controls.Add(Me.lbl35)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.txtPesoLordo)
      Me.Controls.Add(Me.txtPesoNetto)
      Me.Controls.Add(Me.txtVolumeLordo)
      Me.Controls.Add(Me.txtVolumeNetto)
      Me.Controls.Add(Me.txtProfonditaLordo)
      Me.Controls.Add(Me.txtProfonditaNetto)
      Me.Controls.Add(Me.txtAltezzaLordo)
      Me.Controls.Add(Me.txtAltezzaNetto)
      Me.Controls.Add(Me.txtLarghezzaLordo)
      Me.Controls.Add(Me.txtLarghezzaNetto)
      Me.Controls.Add(Me.txtPeso)
      Me.Controls.Add(Me.txtDimensione)
      Me.Controls.Add(Me.txtListino10)
      Me.Controls.Add(Me.txtListino9)
      Me.Controls.Add(Me.txtListino8)
      Me.Controls.Add(Me.txtListino7)
      Me.Controls.Add(Me.txtListino6)
      Me.Controls.Add(Me.txtListino5)
      Me.Controls.Add(Me.txtListino4)
      Me.Controls.Add(Me.txtListino3)
      Me.Controls.Add(Me.txtListino2)
      Me.Controls.Add(Me.txtListino1)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbUnitaMisuraDimensionePeso2)
      Me.Controls.Add(Me.UnitaMisuraDimensione)
      Me.Controls.Add(Me.Label53)
      Me.Controls.Add(Me.Label55)
      Me.Controls.Add(Me.Label56)
      Me.Controls.Add(Me.Label21)
      Me.Controls.Add(Me.Label19)
      Me.Controls.Add(Me.Label20)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.Label16)
      Me.Controls.Add(Me.Label17)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.Label61)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Controls.Add(Me.TabControl1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmArticoli"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Articoli e Ingredienti"
      Me.TabControl1.ResumeLayout(False)
      Me.DatiPrincipale.ResumeLayout(False)
      Me.DatiPrincipale.PerformLayout()
      Me.InfoVini.ResumeLayout(False)
      Me.InfoVini.PerformLayout()
      Me.Progressivi.ResumeLayout(False)
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.Immagine.ResumeLayout(False)
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Note.ResumeLayout(False)
      Me.Note.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

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

         AArticoli.Immagine = OpenFileDialog1.FileName

         If File.Exists(AArticoli.Immagine) = True Then
            Dim bmp As New Bitmap(AArticoli.Immagine)
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
            AArticoli.Immagine = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaProgressivi()
      Try
         If txtPrezzoAcquisto.Text <> String.Empty Then

            If IsNumeric(txtPrezzoAcquisto.Text) = True Then

               If txtTotCarichi.Text <> String.Empty Then
                  txtValoreCarichi.Text = CFormatta.FormattaEuro(CalcolaValore(Convert.ToDecimal(txtPrezzoAcquisto.Text), Convert.ToDecimal(txtTotCarichi.Text)))
               Else
                  txtValoreCarichi.Text = VALORE_ZERO
               End If

               If txtTotScarichi.Text <> String.Empty Then
                  txtValoreScarichi.Text = CFormatta.FormattaEuro(CalcolaValore(Convert.ToDecimal(txtPrezzoAcquisto.Text), Convert.ToDecimal(txtTotScarichi.Text)))
               Else
                  txtValoreScarichi.Text = VALORE_ZERO
               End If

               If txtGiacenza.Text <> String.Empty Then
                  txtValoreAttuale.Text = CFormatta.FormattaEuro(CalcolaValore(Convert.ToDecimal(txtPrezzoAcquisto.Text), Convert.ToDecimal(txtGiacenza.Text)))
               Else
                  txtValoreAttuale.Text = VALORE_ZERO
               End If

            Else
               txtValoreCarichi.Text = VALORE_ZERO
               txtValoreScarichi.Text = VALORE_ZERO
               txtValoreAttuale.Text = VALORE_ZERO
            End If

         Else
            txtValoreCarichi.Text = VALORE_ZERO
            txtValoreScarichi.Text = VALORE_ZERO
            txtValoreAttuale.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub VerificaSottoscorta()
      Try
         Dim scortaMinima As Double = CDbl(txtScortaMinima.Text)
         Dim giacenza As Double = CDbl(txtGiacenza.Text)

         If scortaMinima > giacenza Then
            ' Messaggio sottoscorta.
            MessageBox.Show("E' stata modificata la Scorta minima ad un valore maggiore della Giacenza. L'articolo o l'ingrediente risulter‡ essere sottoscorta!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            If scortaMinima > 0 Then
               situazioneScorta = (giacenza - scortaMinima)
            Else
               situazioneScorta = 0
            End If
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
         AggiornaTabella(cmbUM, TAB_UM)
         AggiornaTabella(cmbCategoria, TAB_CATEGORIE)
         AggiornaTabella(cmbMagazzino, TAB_MAGAZZINI)
         AggiornaTabella(cmbUbicazione, TAB_UBICAZIONI)
         AggiornaTabella(cmbScaffale, TAB_SCAFFALI)

         CalcolaProgressivi()
         VerificaSottoscorta()

         With AArticoli
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Codice = txtCodice.Text
            .CodBarre = txtCodiceBarre.Text
            .Descrizione = FormattaApici(txtDescrizione.Text)
            .Fornitore = FormattaApici(cmbFornitore.Text)
            .Unit‡Misura = cmbUM.Text
            .Categoria = FormattaApici(cmbCategoria.Text)
            .Magazzino = FormattaApici(cmbMagazzino.Text)
            .Ubicazione = FormattaApici(cmbUbicazione.Text)
            .Scaffale = FormattaApici(cmbScaffale.Text)
            .SituazioneScorta = situazioneScorta

            If IsNumeric(txtPrezzoAcquisto.Text) Then
               .PrezzoAcquisto = CFormatta.FormattaEuro(txtPrezzoAcquisto.Text)
            Else
               .PrezzoAcquisto = VALORE_ZERO
            End If
            If IsNumeric(txtGiacenza.Text) Then
               .Giacenza = CFormatta.FormattaQuantit‡(txtGiacenza.Text, 3)
            Else
               .Giacenza = 0
            End If
            If IsNumeric(txtTotCarichi.Text) Then
               .Carico = CFormatta.FormattaQuantit‡(txtTotCarichi.Text, 3)
            Else
               .Carico = 0
            End If
            If IsNumeric(txtTotScarichi.Text) Then
               .Scarico = CFormatta.FormattaQuantit‡(txtTotScarichi.Text, 3)
            Else
               .Scarico = 0
            End If
            If IsNumeric(txtScortaMinima.Text) Then
               .ScortaMin = CFormatta.FormattaQuantit‡(txtScortaMinima.Text, 3)
            Else
               .ScortaMin = 0
            End If
            If IsNumeric(txtValoreCarichi.Text) Then
               .ValCarico = CFormatta.FormattaEuro(txtValoreCarichi.Text)
            Else
               .ValCarico = VALORE_ZERO
            End If
            If IsNumeric(txtValoreScarichi.Text) Then
               .ValScarico = CFormatta.FormattaEuro(txtValoreScarichi.Text)
            Else
               .ValScarico = VALORE_ZERO
            End If
            If IsNumeric(txtValoreAttuale.Text) Then
               .ValAttuale = CFormatta.FormattaEuro(txtValoreAttuale.Text)
            Else
               .ValAttuale = VALORE_ZERO
            End If

            .ProduttoreVino = FormattaApici(txtProduttoreVino.Text)
            .RegioneVino = FormattaApici(txtRegioneVino.Text)
            .ZonaVino = FormattaApici(txtZonaVino.Text)
            .AnnoVino = txtAnnoVino.Text
            .FormatoVino = FormattaApici(txtFormatoVino.Text)
            .ScansiaVino = FormattaApici(txtScansiaVino.Text)
            .Note = FormattaApici(txtNote.Text)

            ' Se la propriet‡ 'Tag' contiene un valore viene richiamata la procedura
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


   Private Sub Articoli_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With AArticoli
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtCodiceBarre.Text = .CodBarre
               txtDescrizione.Text = .Descrizione
               cmbFornitore.Text = .Fornitore
               cmbUM.Text = .Unit‡Misura
               cmbCategoria.Text = .Categoria
               cmbMagazzino.Text = .Magazzino
               cmbUbicazione.Text = .Ubicazione
               cmbScaffale.Text = .Scaffale
               txtPrezzoAcquisto.Text = CFormatta.FormattaEuro(.PrezzoAcquisto)
               txtGiacenza.Text = CFormatta.FormattaQuantit‡(.Giacenza, 3)
               txtTotCarichi.Text = CFormatta.FormattaQuantit‡(.Carico, 3)
               txtTotScarichi.Text = CFormatta.FormattaQuantit‡(.Scarico, 3)
               txtScortaMinima.Text = CFormatta.FormattaQuantit‡(.ScortaMin, 3)
               txtValoreCarichi.Text = CFormatta.FormattaEuro(.ValCarico)
               txtValoreScarichi.Text = CFormatta.FormattaEuro(.ValScarico)
               txtValoreAttuale.Text = CFormatta.FormattaEuro(.ValAttuale)
               txtProduttoreVino.Text = .ProduttoreVino
               txtRegioneVino.Text = .RegioneVino
               txtZonaVino.Text = .ZonaVino
               txtAnnoVino.Text = .AnnoVino
               txtFormatoVino.Text = .FormatoVino
               txtScansiaVino.Text = .ScansiaVino
               txtNote.Text = .Note

               If .Immagine <> Nothing Then
                  If File.Exists(.Immagine) = True Then
                     Dim bmp As New Bitmap(.Immagine)
                     picFoto.Image = bmp
                  End If
               End If
            End With

         Else
            AArticoli.Immagine = ""
            txtGiacenza.Text = "0"
            txtTotCarichi.Text = "0"
            txtTotScarichi.Text = "0"
            txtScortaMinima.Text = "0"
         End If

         ' Carica le liste.
         CaricaListaFornitori(cmbFornitore, TAB_FORNITORI)
         CaricaLista(cmbUM, TAB_UM)
         CaricaLista(cmbCategoria, TAB_CATEGORIE)
         CaricaLista(cmbMagazzino, TAB_MAGAZZINI)
         CaricaLista(cmbUbicazione, TAB_UBICAZIONI)
         CaricaLista(cmbScaffale, TAB_SCAFFALI)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtDescrizione.Text, "")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Imposta lo stato attivo.
         txtCodice.Focus()

      End Try
   End Sub

   Private Sub frmArticoli_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_MAGAZZINO_ARTICOLI)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            If Me.Tag = "" Then
               If VerificaEsistenzaValore(NOME_TABELLA, cn, cmd, "Codice", txtCodice.Text) <> 0 Then
                  MessageBox.Show("Il campo 'Codice' contiene un valore gi‡ esistente! Inserire un valore univoco.", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Exit Sub
               End If

               If txtCodiceBarre.Text <> "" Then
                  If VerificaEsistenzaValore(NOME_TABELLA, cn, cmd, "CodBarre", txtCodiceBarre.Text) <> 0 Then
                     MessageBox.Show("Il campo 'Codice a barre' contiene un valore gi‡ esistente! Inserire un valore univoco.", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     Exit Sub
                  End If
               End If
            End If

            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmArticoli) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmArticoli.AggiornaDati()
               End If
               If IsNothing(g_frmScorte) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmScorte.AggiornaDati()
               End If
               If IsNothing(g_frmInventario) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmInventario.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & AArticoli.Codice & " - " & AArticoli.Descrizione & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_MAGAZZINO_ARTICOLI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_MAGAZZINO_ARTICOLI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            txtCodice.Focus()
         Case 1
            ' Imposta lo stato attivo.
            txtProduttoreVino.Focus()

         Case 2
            ' Calcola i valori dei progressivi.
            CalcolaProgressivi()

            ' Imposta lo stato attivo.
            txtScortaMinima.Focus()
         Case 3
            ' Imposta lo stato attivo.
            cmdApri.Focus()
         Case 4
            ' Imposta lo stato attivo.
            txtNote.Focus()
      End Select
   End Sub

   Private Sub txtPrezzoAcquisto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrezzoAcquisto.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtScortaMinima_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScortaMinima.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaQuantit‡(sender.Text, 3)
      End If
   End Sub

   Private Sub cmdApri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApri.Click
      InserisciImmagine()
   End Sub

   Private Sub cmdElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElimina.Click
      cmdApri.NotifyDefault(False)
      EliminaImmagine()
   End Sub

   Private Sub txtPrezzoAcquisto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzoAcquisto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtScortaMinima_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScortaMinima.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtAnnoVino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnnoVino.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub cmdCalcolaPrezzo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalcolaPrezzo.Click
      AvviaWinCalc(Me.Handle)
   End Sub

End Class
