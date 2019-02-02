' Nome form:            frmGruppi
' Autore:               Luigi Montana, Montana Software
' Data creazione:       07/01/2006
' Data ultima modifica: 2/08/2011
' Descrizione:          Anagrafica Gruppi.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class frmGruppi
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
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Public WithEvents txtNomeGruppo As System.Windows.Forms.TextBox
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lvwPermessi As System.Windows.Forms.ListView
   Friend WithEvents cmdScrittura As System.Windows.Forms.Button
   Friend WithEvents cmdLettura As System.Windows.Forms.Button
   Friend WithEvents cmdNessuno As System.Windows.Forms.Button
   Friend WithEvents ColonnaDB As System.Windows.Forms.ColumnHeader
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents chkAmministratore As System.Windows.Forms.CheckBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGruppi))
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - ACCESSORI E SERVIZI", "", "AnagAccessoriServizi"}, -1)
      Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - AZIENDE", "", "AnagAziende"}, -1)
      Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - CAMERIERI", "", "AnagCamerieri"}, -1)
      Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - CATEGORIE PIATTI", "", "AnagCatPiatti"}, -1)
      Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "ARCHIVI - ANAGRAFICHE - CLIENTI", System.Drawing.SystemColors.ControlText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.SystemColors.AppWorkspace, System.Drawing.SystemColors.Highlight, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "AnagClienti")}, -1)
      Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - DATI GENERALI AZIENDA", "", "AnagDatiAzienda"}, -1)
      Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - FORNITORI", "", "AnagFornitori"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
      Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - PIATTI", "", "AnagPiatti"}, -1)
      Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - RISORSE", "", "AnagRisorse"}, -1)
      Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - SALE", "", "AnagSale"}, -1)
      Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - ANAGRAFICHE - TAVOLI", "", "AnagTavoli"}, -1)
      Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - BACKUP DEI DATI", "", "ArchiviBackup"}, -1)
      Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - COMPATTA E RIPRISTINA", "", "ArchiviCompatta"}, -1)
      Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - PULIZIA DEGLI ARCHIVI", "", "ArchiviPulizia"}, -1)
      Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - ATTIVITA'", "", "TabAttività"}, -1)
      Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - CATEGORIE CLIENTI", "", "TabCatClienti"}, -1)
      Dim ListViewItem17 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - CATEGORIE MERCEOLOGICHE", "", "TabCatMerce"}, -1)
      Dim ListViewItem18 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - FORME DI CORTESIA", "", "TabFormeCortesia"}, -1)
      Dim ListViewItem19 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - MAGAZZINI", "", "TabMagazzini"}, -1)
      Dim ListViewItem20 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - MESSAGGI PER I REPARTI", "", "TabMsg"}, -1)
      Dim ListViewItem21 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - NAZIONI", "", "TabNazioni"}, -1)
      Dim ListViewItem22 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - PAGAMENTI", "", "TabPagamenti"}, -1)
      Dim ListViewItem23 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - PIANI", "", "TabPiani"}, -1)
      Dim ListViewItem24 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - REPARTI", "", "TabReparti"}, -1)
      Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - SCAFFALI", "", "TabScaffali"}, -1)
      Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - TIPO DOCUMENTI", "", "TabTipoDoc"}, -1)
      Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - TIPOLOGIE RISORSE", "", "TabTipoRisorse"}, -1)
      Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - UBICAZIONI", "", "TabUbicazioni"}, -1)
      Dim ListViewItem29 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ARCHIVI - TABELLE - UNITA' DI MISURA", "", "TabUM"}, -1)
      Dim ListViewItem30 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"CONTABILITA' - CHIUSURA GIORNALIERA", "", "ContChiusura"}, -1)
      Dim ListViewItem31 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"CONTABILITA' - CORRISPETTIVI", "", "ContCorrispettivi"}, -1)
      Dim ListViewItem32 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"CONTABILITA' - DOCUMENTI EMESSI", "", "ContDoc"}, -1)
      Dim ListViewItem33 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"CONTABILITA' - PRIMA NOTA", "", "ContPrimaNota"}, -1)
      Dim ListViewItem34 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - ACQUISTI", "", "GestAcquisti"}, -1)
      Dim ListViewItem35 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - GRUPPI", "", "GestGruppi"}, -1)
      Dim ListViewItem36 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - OPERATORI", "", "GestOperatori"}, -1)
      Dim ListViewItem37 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - PLANNING RISORSE", "", "GestPlanningRisorse"}, -1)
      Dim ListViewItem38 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - PRENOTAZIONE RISORSE", "", "GestPrenRisorse"}, -1)
      Dim ListViewItem39 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - PRENOTAZIONE SALE", "", "GestPrenSale"}, -1)
      Dim ListViewItem40 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - PRENOTAZIONE TAVOLI", "", "GestPrenTavoli"}, -1)
      Dim ListViewItem41 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - PUNTO CASSA", "", "GestPuntoCassa"}, -1)
      Dim ListViewItem42 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - STATISTICHE DI VENDITA BAR/RISTORANTE", "", "GestStatistiche"}, -1)
      Dim ListViewItem43 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - STATISTICHE DI VENDITA CENTRO SPORTIVO", "", "GestStatRisorse"}, -1)
      Dim ListViewItem44 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GESTIONE - TAVOLI E CONTO", "", "GestTavoli"}, -1)
      Dim ListViewItem45 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"MAGAZZINO - ARTICOLI E INGREDIENTI", "", "MagArticoli"}, -1)
      Dim ListViewItem46 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"MAGAZZINO - INVENTARIO", "", "MagInventario"}, -1)
      Dim ListViewItem47 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"MAGAZZINO - SITUAZIONE SCORTE", "", "MagScorte"}, -1)
      Dim ListViewItem48 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"MAGAZZINO - STORICO MOVIMENTI", "", "MagMovimenti"}, -1)
      Dim ListViewItem49 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"STRUMENTI - DISPONI TAVOLI", "", "StruDispTavoli"}, -1)
      Dim ListViewItem50 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"STRUMENTI - ELENCO C.A.P.", "", "StruCap"}, -1)
      Dim ListViewItem51 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"STRUMENTI - ELENCO MESSAGGI AI REPARTI", "", "StruMsg"}, -1)
      Dim ListViewItem52 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"STRUMENTI - ETICHETTE E CODICI A BARRE", "", "StruCodiciBarre"}, -1)
      Dim ListViewItem53 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"STRUMENTI - FORMAZIONE MENU'", "", "StruMenù"}, -1)
      Dim ListViewItem54 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"VISUALIZZA - OPZIONI", "", "VisOpzioni"}, -1)
      Dim ListViewItem55 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"VISUALIZZA - REGISTRO ERRORI", "", "VisErrori"}, -1)
      Dim ListViewItem56 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"VISUALIZZA - REGISTRO OPERAZIONI", "", "VisOperazioni"}, -1)
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.chkAmministratore = New System.Windows.Forms.CheckBox()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.txtNomeGruppo = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.cmdScrittura = New System.Windows.Forms.Button()
      Me.cmdLettura = New System.Windows.Forms.Button()
      Me.cmdNessuno = New System.Windows.Forms.Button()
      Me.lvwPermessi = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColonnaDB = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabPage2.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(543, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(543, 20)
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
      Me.TabControl1.Size = New System.Drawing.Size(543, 314)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.chkAmministratore)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Controls.Add(Me.txtNomeGruppo)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(535, 288)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'chkAmministratore
      '
      Me.chkAmministratore.BackColor = System.Drawing.Color.Transparent
      Me.chkAmministratore.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAmministratore.ForeColor = System.Drawing.Color.Black
      Me.chkAmministratore.Location = New System.Drawing.Point(24, 88)
      Me.chkAmministratore.Name = "chkAmministratore"
      Me.chkAmministratore.Size = New System.Drawing.Size(104, 24)
      Me.chkAmministratore.TabIndex = 2
      Me.chkAmministratore.Text = "&Amministratore"
      Me.chkAmministratore.UseVisualStyleBackColor = False
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
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TabStop = False
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(24, 24)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(43, 13)
      Me.Label20.TabIndex = 180
      Me.Label20.Text = "Codice:"
      '
      'txtNomeGruppo
      '
      Me.txtNomeGruppo.AcceptsReturn = True
      Me.txtNomeGruppo.BackColor = System.Drawing.SystemColors.Window
      Me.txtNomeGruppo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNomeGruppo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNomeGruppo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNomeGruppo.Location = New System.Drawing.Point(112, 56)
      Me.txtNomeGruppo.MaxLength = 100
      Me.txtNomeGruppo.Name = "txtNomeGruppo"
      Me.txtNomeGruppo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNomeGruppo.Size = New System.Drawing.Size(264, 20)
      Me.txtNomeGruppo.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(24, 56)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(74, 13)
      Me.Label2.TabIndex = 170
      Me.Label2.Text = "Nome gruppo:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.cmdScrittura)
      Me.TabPage2.Controls.Add(Me.cmdLettura)
      Me.TabPage2.Controls.Add(Me.cmdNessuno)
      Me.TabPage2.Controls.Add(Me.lvwPermessi)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(535, 288)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Permessi"
      Me.TabPage2.ToolTipText = "Permessi"
      '
      'cmdScrittura
      '
      Me.cmdScrittura.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdScrittura.Location = New System.Drawing.Point(432, 256)
      Me.cmdScrittura.Name = "cmdScrittura"
      Me.cmdScrittura.Size = New System.Drawing.Size(88, 24)
      Me.cmdScrittura.TabIndex = 3
      Me.cmdScrittura.Text = "&Scrittura"
      '
      'cmdLettura
      '
      Me.cmdLettura.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdLettura.Location = New System.Drawing.Point(336, 256)
      Me.cmdLettura.Name = "cmdLettura"
      Me.cmdLettura.Size = New System.Drawing.Size(88, 24)
      Me.cmdLettura.TabIndex = 2
      Me.cmdLettura.Text = "&Lettura"
      '
      'cmdNessuno
      '
      Me.cmdNessuno.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdNessuno.Location = New System.Drawing.Point(248, 256)
      Me.cmdNessuno.Name = "cmdNessuno"
      Me.cmdNessuno.Size = New System.Drawing.Size(80, 24)
      Me.cmdNessuno.TabIndex = 1
      Me.cmdNessuno.Text = "&Nessuno"
      '
      'lvwPermessi
      '
      Me.lvwPermessi.CheckBoxes = True
      Me.lvwPermessi.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader6, Me.ColonnaDB})
      Me.lvwPermessi.FullRowSelect = True
      Me.lvwPermessi.GridLines = True
      ListViewItem1.StateImageIndex = 0
      ListViewItem2.StateImageIndex = 0
      ListViewItem3.StateImageIndex = 0
      ListViewItem4.StateImageIndex = 0
      ListViewItem5.StateImageIndex = 0
      ListViewItem6.StateImageIndex = 0
      ListViewItem7.StateImageIndex = 0
      ListViewItem8.StateImageIndex = 0
      ListViewItem9.StateImageIndex = 0
      ListViewItem10.StateImageIndex = 0
      ListViewItem11.StateImageIndex = 0
      ListViewItem12.StateImageIndex = 0
      ListViewItem13.StateImageIndex = 0
      ListViewItem14.StateImageIndex = 0
      ListViewItem15.StateImageIndex = 0
      ListViewItem16.StateImageIndex = 0
      ListViewItem17.StateImageIndex = 0
      ListViewItem18.StateImageIndex = 0
      ListViewItem19.StateImageIndex = 0
      ListViewItem20.StateImageIndex = 0
      ListViewItem21.StateImageIndex = 0
      ListViewItem22.StateImageIndex = 0
      ListViewItem23.StateImageIndex = 0
      ListViewItem24.StateImageIndex = 0
      ListViewItem25.StateImageIndex = 0
      ListViewItem26.StateImageIndex = 0
      ListViewItem27.StateImageIndex = 0
      ListViewItem28.StateImageIndex = 0
      ListViewItem29.StateImageIndex = 0
      ListViewItem30.StateImageIndex = 0
      ListViewItem31.StateImageIndex = 0
      ListViewItem32.StateImageIndex = 0
      ListViewItem33.StateImageIndex = 0
      ListViewItem34.StateImageIndex = 0
      ListViewItem35.StateImageIndex = 0
      ListViewItem36.StateImageIndex = 0
      ListViewItem37.StateImageIndex = 0
      ListViewItem38.StateImageIndex = 0
      ListViewItem39.StateImageIndex = 0
      ListViewItem40.StateImageIndex = 0
      ListViewItem41.StateImageIndex = 0
      ListViewItem42.StateImageIndex = 0
      ListViewItem43.StateImageIndex = 0
      ListViewItem44.StateImageIndex = 0
      ListViewItem45.StateImageIndex = 0
      ListViewItem46.StateImageIndex = 0
      ListViewItem47.StateImageIndex = 0
      ListViewItem48.StateImageIndex = 0
      ListViewItem49.StateImageIndex = 0
      ListViewItem50.StateImageIndex = 0
      ListViewItem51.StateImageIndex = 0
      ListViewItem52.StateImageIndex = 0
      ListViewItem53.StateImageIndex = 0
      ListViewItem54.StateImageIndex = 0
      ListViewItem55.StateImageIndex = 0
      ListViewItem56.StateImageIndex = 0
      Me.lvwPermessi.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17, ListViewItem18, ListViewItem19, ListViewItem20, ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30, ListViewItem31, ListViewItem32, ListViewItem33, ListViewItem34, ListViewItem35, ListViewItem36, ListViewItem37, ListViewItem38, ListViewItem39, ListViewItem40, ListViewItem41, ListViewItem42, ListViewItem43, ListViewItem44, ListViewItem45, ListViewItem46, ListViewItem47, ListViewItem48, ListViewItem49, ListViewItem50, ListViewItem51, ListViewItem52, ListViewItem53, ListViewItem54, ListViewItem55, ListViewItem56})
      Me.lvwPermessi.Location = New System.Drawing.Point(0, 0)
      Me.lvwPermessi.MultiSelect = False
      Me.lvwPermessi.Name = "lvwPermessi"
      Me.lvwPermessi.Size = New System.Drawing.Size(535, 248)
      Me.lvwPermessi.Sorting = System.Windows.Forms.SortOrder.Ascending
      Me.lvwPermessi.TabIndex = 0
      Me.lvwPermessi.UseCompatibleStateImageBehavior = False
      Me.lvwPermessi.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Descrizione"
      Me.ColumnHeader1.Width = 410
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Text = "Accesso"
      Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.ColumnHeader6.Width = 100
      '
      'ColonnaDB
      '
      Me.ColonnaDB.Width = 100
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmGruppi
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(543, 360)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmGruppi"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Gruppi operatori"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni "

   Private CGruppi As New Gruppi
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   Const NOME_TABELLA As String = "Gruppi"

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

   Dim itemClick As Boolean = False
   Dim gruppo As String

#End Region

#Region "Procedure "

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Sub LeggiPermessi()
      Try
         Dim i As Integer
         For i = 0 To lvwPermessi.Items.Count - 1
            With CGruppi
               Select Case lvwPermessi.Items(i).SubItems(2).Text

                  Case "AnagAziende"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagAziende
                     If .AnagAziende <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If
                     Select Case .AnagAziende
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagCamerieri"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagCamerieri
                     If .AnagCamerieri <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagCamerieri
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagCatPiatti"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagCatPiatti
                     If .AnagCatPiatti <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagCatPiatti
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagClienti"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagClienti
                     If .AnagClienti <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If
                     Select Case .AnagClienti
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagDatiAzienda"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagDatiAzienda
                     If .AnagDatiAzienda <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagDatiAzienda
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagFornitori"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagFornitori
                     If .AnagFornitori <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagFornitori
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagPiatti"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagPiatti
                     If .AnagPiatti <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagPiatti
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagSale"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagSale
                     If .AnagSale <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagSale
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagTavoli"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagTavoli
                     If .AnagTavoli <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagTavoli
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagRisorse"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagRisorse
                     If .AnagRisorse <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagRisorse
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "AnagAccessoriServizi"
                     lvwPermessi.Items(i).SubItems(1).Text = .AnagAccessoriServizi
                     If .AnagAccessoriServizi <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .AnagAccessoriServizi
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "ArchiviBackup"
                     lvwPermessi.Items(i).SubItems(1).Text = .ArchiviBackup
                     If .ArchiviBackup <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .ArchiviBackup
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "ArchiviCompatta"
                     lvwPermessi.Items(i).SubItems(1).Text = .ArchiviCompatta
                     If .ArchiviCompatta <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .ArchiviCompatta
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "ArchiviPulizia"
                     lvwPermessi.Items(i).SubItems(1).Text = .ArchiviPulizia
                     If .ArchiviPulizia <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .ArchiviPulizia
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabAttività"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabAttività
                     If .TabAttività <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabAttività
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabCatClienti"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabCatClienti
                     If .TabCatClienti <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabCatClienti
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabCatMerce"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabCatMerce
                     If .TabCatMerce <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabCatMerce
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabFormeCortesia"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabFormeCortesia
                     If .TabFormeCortesia <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabFormeCortesia
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabMagazzini"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabMagazzini
                     If .TabMagazzini <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabMagazzini
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabMsg"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabMsg
                     If .TabMsg <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabMsg
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabNazioni"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabNazioni
                     If .TabNazioni <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabNazioni
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabPagamenti"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabPagamenti
                     If .TabPagamenti <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabPagamenti
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabPiani"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabPiani
                     If .TabPiani <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabPiani
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabReparti"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabReparti
                     If .TabReparti <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabReparti
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabScaffali"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabScaffali
                     If .TabScaffali <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabScaffali
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabTipoDoc"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabTipoDoc
                     If .TabTipoDoc <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabTipoDoc
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabUbicazioni"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabUbicazioni
                     If .TabUbicazioni <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabUbicazioni
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabUM"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabUM
                     If .TabUM <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabUM
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "TabTipoRisorse"
                     lvwPermessi.Items(i).SubItems(1).Text = .TabTipoRisorse
                     If .TabTipoRisorse <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .TabTipoRisorse
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "ContChiusura"
                     lvwPermessi.Items(i).SubItems(1).Text = .ContChiusura
                     If .ContChiusura <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .ContChiusura
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "ContCorrispettivi"
                     lvwPermessi.Items(i).SubItems(1).Text = .ContCorrispettivi
                     If .ContCorrispettivi <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .ContCorrispettivi
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "ContDoc"
                     lvwPermessi.Items(i).SubItems(1).Text = .ContDoc
                     If .ContDoc <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .ContDoc
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "ContPrimaNota"
                     lvwPermessi.Items(i).SubItems(1).Text = .ContPrimaNota
                     If .ContPrimaNota <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .ContPrimaNota
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestAcquisti"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestAcquisti
                     If .GestAcquisti <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestAcquisti
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestGruppi"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestGruppi
                     If .GestGruppi <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestGruppi
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestOperatori"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestOperatori
                     If .GestOperatori <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestOperatori
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestPrenSale"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestPrenSale
                     If .GestPrenSale <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestPrenSale
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestPrenTavoli"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestPrenTavoli
                     If .GestPrenTavoli <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestPrenTavoli
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestPrenRisorse"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestPrenRisorse
                     If .GestPrenRisorse <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestPrenRisorse
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestPlanningRisorse"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestPlanningRisorse
                     If .GestPlanningRisorse <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestPlanningRisorse
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestStatRisorse"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestStatRisorse
                     If .GestStatRisorse <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestStatRisorse
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select


                  Case "GestPuntoCassa"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestPuntoCassa
                     If .GestPuntoCassa <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestPuntoCassa
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestStatistiche"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestStatistiche
                     If .GestStatistiche <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestStatistiche
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "GestTavoli"
                     lvwPermessi.Items(i).SubItems(1).Text = .GestTavoli
                     If .GestTavoli <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .GestTavoli
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "MagArticoli"
                     lvwPermessi.Items(i).SubItems(1).Text = .MagArticoli
                     If .MagArticoli <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .MagArticoli
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "MagInventario"
                     lvwPermessi.Items(i).SubItems(1).Text = .MagInventario
                     If .MagInventario <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .MagInventario
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "MagScorte"
                     lvwPermessi.Items(i).SubItems(1).Text = .MagScorte
                     If .MagScorte <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .MagScorte
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "MagMovimenti"
                     lvwPermessi.Items(i).SubItems(1).Text = .MagMov
                     If .MagMov <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .MagMov
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "StruDispTavoli"
                     lvwPermessi.Items(i).SubItems(1).Text = .StruDispTavoli
                     If .StruDispTavoli <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .StruDispTavoli
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "StruCap"
                     lvwPermessi.Items(i).SubItems(1).Text = .StruCap
                     If .StruCap <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .StruCap
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "StruMsg"
                     lvwPermessi.Items(i).SubItems(1).Text = .StruMsg
                     If .StruMsg <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .StruMsg
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "StruCodiciBarre"
                     lvwPermessi.Items(i).SubItems(1).Text = .StruCodiciBarre
                     If .StruCodiciBarre <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .StruCodiciBarre
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "StruMenù"
                     lvwPermessi.Items(i).SubItems(1).Text = .StruMenù
                     If .StruMenù <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .StruMenù
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "VisOpzioni"
                     lvwPermessi.Items(i).SubItems(1).Text = .VisOpzioni
                     If .VisOpzioni <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .VisOpzioni
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "VisErrori"
                     lvwPermessi.Items(i).SubItems(1).Text = .VisErrori
                     If .VisErrori <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .VisErrori
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

                  Case "VisOperazioni"
                     lvwPermessi.Items(i).SubItems(1).Text = .VisOperazioni
                     If .VisOperazioni <> VALORE_NESSUNO Then
                        lvwPermessi.Items(i).Checked = True
                     End If

                     Select Case .VisOperazioni
                        Case VALORE_SCRITTURA
                           lvwPermessi.Items(i).ForeColor = Color.Black

                        Case VALORE_LETTURA
                           lvwPermessi.Items(i).ForeColor = Color.DodgerBlue

                        Case VALORE_NESSUNO
                           lvwPermessi.Items(i).ForeColor = Color.LightCoral
                     End Select

               End Select
            End With
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub SalvaPermessi()
      Try
         Dim i As Integer
         For i = 0 To lvwPermessi.Items.Count - 1
            With CGruppi
               Select Case lvwPermessi.Items(i).SubItems(2).Text
                  Case "AnagAziende"
                     .AnagAziende = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagCamerieri"
                     .AnagCamerieri = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagCatPiatti"
                     .AnagCatPiatti = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagClienti"
                     .AnagClienti = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagDatiAzienda"
                     .AnagDatiAzienda = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagFornitori"
                     .AnagFornitori = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagPiatti"
                     .AnagPiatti = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagSale"
                     .AnagSale = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagTavoli"
                     .AnagTavoli = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagRisorse"
                     .AnagRisorse = lvwPermessi.Items(i).SubItems(1).Text

                  Case "AnagAccessoriServizi"
                     .AnagAccessoriServizi = lvwPermessi.Items(i).SubItems(1).Text

                  Case "ArchiviBackup"
                     .ArchiviBackup = lvwPermessi.Items(i).SubItems(1).Text

                  Case "ArchiviCompatta"
                     .ArchiviCompatta = lvwPermessi.Items(i).SubItems(1).Text

                  Case "ArchiviPulizia"
                     .ArchiviPulizia = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabAttività"
                     .TabAttività = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabCatClienti"
                     .TabCatClienti = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabCatMerce"
                     .TabCatMerce = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabFormeCortesia"
                     .TabFormeCortesia = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabMagazzini"
                     .TabMagazzini = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabMsg"
                     .TabMsg = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabNazioni"
                     .TabNazioni = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabPagamenti"
                     .TabPagamenti = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabPiani"
                     .TabPiani = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabReparti"
                     .TabReparti = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabScaffali"
                     .TabScaffali = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabTipoDoc"
                     .TabTipoDoc = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabUbicazioni"
                     .TabUbicazioni = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabUM"
                     .TabUM = lvwPermessi.Items(i).SubItems(1).Text

                  Case "TabTipoRisorse"
                     .TabTipoRisorse = lvwPermessi.Items(i).SubItems(1).Text

                  Case "ContChiusura"
                     .ContChiusura = lvwPermessi.Items(i).SubItems(1).Text

                  Case "ContCorrispettivi"
                     .ContCorrispettivi = lvwPermessi.Items(i).SubItems(1).Text

                  Case "ContDoc"
                     .ContDoc = lvwPermessi.Items(i).SubItems(1).Text

                  Case "ContPrimaNota"
                     .ContPrimaNota = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestAcquisti"
                     .GestAcquisti = lvwPermessi.Items(i).SubItems(1).Text

                  Case "StruMenù"
                     .StruMenù = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestGruppi"
                     .GestGruppi = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestOperatori"
                     .GestOperatori = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestPrenSale"
                     .GestPrenSale = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestPrenTavoli"
                     .GestPrenTavoli = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestPrenRisorse"
                     .GestPrenRisorse = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestPlanningRisorse"
                     .GestPlanningRisorse = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestStatRisorse"
                     .GestStatRisorse = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestPuntoCassa"
                     .GestPuntoCassa = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestStatistiche"
                     .GestStatistiche = lvwPermessi.Items(i).SubItems(1).Text

                  Case "GestTavoli"
                     .GestTavoli = lvwPermessi.Items(i).SubItems(1).Text

                  Case "MagArticoli"
                     .MagArticoli = lvwPermessi.Items(i).SubItems(1).Text

                  Case "MagInventario"
                     .MagInventario = lvwPermessi.Items(i).SubItems(1).Text

                  Case "MagScorte"
                     .MagScorte = lvwPermessi.Items(i).SubItems(1).Text

                  Case "MagMovimenti"
                     .MagMov = lvwPermessi.Items(i).SubItems(1).Text

                  Case "StruDispTavoli"
                     .StruDispTavoli = lvwPermessi.Items(i).SubItems(1).Text

                  Case "StruCap"
                     .StruCap = lvwPermessi.Items(i).SubItems(1).Text

                  Case "StruMsg"
                     .StruMsg = lvwPermessi.Items(i).SubItems(1).Text

                  Case "StruCodiciBarre"
                     .StruCodiciBarre = lvwPermessi.Items(i).SubItems(1).Text

                  Case "VisOpzioni"
                     .VisOpzioni = lvwPermessi.Items(i).SubItems(1).Text

                  Case "VisErrori"
                     .VisErrori = lvwPermessi.Items(i).SubItems(1).Text

                  Case "VisOperazioni"
                     .VisOperazioni = lvwPermessi.Items(i).SubItems(1).Text

               End Select
            End With
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub ImpostaPermessi()
      Try
         Dim i As Integer
         For i = 0 To lvwPermessi.Items.Count - 1
            lvwPermessi.Items(i).SubItems(1).Text = VALORE_NESSUNO
            'lvwPermessi.Items(i).Checked = false
            lvwPermessi.Items(i).ForeColor = Color.LightCoral
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

#End Region

#Region "Funzioni "

   Private Function SalvaDati() As Boolean
      Try
         With CGruppi
            gruppo = .NomeGruppo

            ' Assegna i dati dei campi della classe alle caselle di testo.
            .NomeGruppo = FormattaApici(txtNomeGruppo.Text)
            .Note = FormattaApici(txtNote.Text)

            If chkAmministratore.Checked = True Then
               .Amministratore = "Sì"
            Else
               .Amministratore = "No"
            End If

            SalvaPermessi()

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

#Region "Eventi "

   Private Sub frmGruppi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With CGruppi
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Id
               txtNomeGruppo.Text = .NomeGruppo
               txtNote.Text = .Note

               If .Amministratore = "Sì" Then
                  chkAmministratore.Checked = True
               Else
                  chkAmministratore.Checked = False
               End If
            End With

            LeggiPermessi()

            ' Gruppo di sistema. Il campo Amministratore non è modificabile.
            If txtCodice.Text = "1" Then
               chkAmministratore.Enabled = False
               cmdNessuno.Enabled = False
               cmdLettura.Enabled = False
               cmdScrittura.Enabled = False
            End If

         Else
            ' Imposta tutti permessi su Nessuno.
            ImpostaPermessi()
         End If

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtNomeGruppo.Text, "")

         ' Imposta lo stato attivo.
         txtNomeGruppo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub frmGruppi_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         If Me.Tag <> "0" Then
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_GRUPPI)
         End If

         ' Nel caso il gruppo in uso sia stato modificato.
         If gruppo = operatore.Gruppo Then
            MessageBox.Show("Si sono apportate modifiche ad un Gruppo attualmente in uso. Per applicare le modifiche tutte le finestre aperte " & _
                            "verranno chiuse e sarà necessario identificarsi nuovamente.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Hide()

                g_frmMain.eui_cmdGestioneCambiaOp.PerformClick()
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

               If IsNothing(g_frmGruppi) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmGruppi.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & CGruppi.NomeGruppo & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_GESTIONE_GRUPPI)
            End If

         Case "Annulla"
            gruppo = String.Empty

            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_GRUPPI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               Me.txtNomeGruppo.Focus()

            Case 1
               ' Imposta lo stato attivo.
               Me.txtNote.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdScrittura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrittura.Click
      Try
         ' Assegna il valore SCRITTURA per l'elemento selezionato.
         itemClick = False
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).SubItems(1).Text = VALORE_SCRITTURA
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).Checked = True
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).ForeColor = Color.Black
         lvwPermessi.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdLettura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLettura.Click
      Try
         ' Assegna il valore LETTURA per l'elemento selezionato.
         itemClick = False
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).SubItems(1).Text = VALORE_LETTURA
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).Checked = True
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).ForeColor = Color.DodgerBlue
         chkAmministratore.Checked = False
         lvwPermessi.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdNessuno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNessuno.Click
      Try
         ' Assegna il valore NESSUNO per l'elemento selezionato.
         itemClick = False
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).SubItems(1).Text = VALORE_NESSUNO
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).Checked = False
         lvwPermessi.Items(lvwPermessi.FocusedItem.Index).ForeColor = Color.LightCoral
         chkAmministratore.Checked = False
         lvwPermessi.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub chkAmministratore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAmministratore.CheckedChanged
      Try
         If chkAmministratore.Checked = True Then
            Dim i As Integer
            For i = 0 To lvwPermessi.Items.Count - 1
               lvwPermessi.Items(i).SubItems(1).Text = VALORE_SCRITTURA
               lvwPermessi.Items(i).Checked = True
               lvwPermessi.Items(i).ForeColor = Color.Black
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lvwPermessi_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvwPermessi.ItemCheck
      Try
         If itemClick = True Then

            ' Gruppo di sistema. I permessi non sono modificabili.
            If txtCodice.Text = "1" Then
               e.NewValue = e.CurrentValue
               Exit Sub
            End If

            Select Case e.NewValue
               Case CheckState.Checked
                  lvwPermessi.Items(e.Index).SubItems(1).Text = VALORE_LETTURA
                  lvwPermessi.Items(e.Index).ForeColor = Color.DodgerBlue

               Case CheckState.Unchecked, CheckState.Indeterminate
                  lvwPermessi.Items(e.Index).SubItems(1).Text = VALORE_NESSUNO
                  lvwPermessi.Items(e.Index).ForeColor = Color.LightCoral

            End Select

            itemClick = False
            chkAmministratore.Checked = False
         End If


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lvwPermessi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwPermessi.Click
      itemClick = True
   End Sub

   Private Sub lvwPermessi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwPermessi.SelectedIndexChanged
      Try
         If txtCodice.Text = "1" Then
            Exit Sub
         End If

         Select Case lvwPermessi.Items(lvwPermessi.FocusedItem.Index).SubItems(2).Text
            Case "ArchiviBackup", "ArchiviCompatta", "ArchiviPulizia", "ContChiusura", "StruMenù", _
                 "MagMovimenti", "StruCap", "VisOpzioni", "VisErrori", "VisOperazioni", "GestPuntoCassa", "GestTavoli"

               cmdLettura.Enabled = False

            Case Else
               cmdLettura.Enabled = True

         End Select

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

#End Region

End Class
