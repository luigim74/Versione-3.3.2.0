' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 18/08/2014
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On

Imports System.Data.OleDb

Public Class frmElencoDati
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Dim TAB_CLIENTI = "Clienti"
   Dim TAB_AZIENDE = "Aziende"
   Dim TAB_FORNITORI = "Fornitori"
   Dim TAB_ARTICOLI = "Articoli"
   Dim TAB_CAT_PIATTI = "CategoriePiatti"
   Dim TAB_PREN = "Prenotazioni"
   Dim TAB_PREN_SALE = "PrenSale"
   Dim TAB_CAMERIERI = "Camerieri"
   Dim TAB_SALE = "Sale"
   Dim TAB_TAVOLI = "Tavoli"
   Dim TAB_CAMERE = "Camere"
   Dim TAB_STATO_PREN = "Gruppi"
   Dim TAB_OPERATORI = "Operatori"
   Dim TAB_GRUPPI = "Gruppi"
   Dim TAB_CARATT_RISORSE = "CaratteristicheRisorse"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnStringAnagrafiche)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   Dim TipoElenco As Short
   Dim NomeTabella As String
   Dim TitoloFinestra As String

   ' Numero di record.
   Dim numRecord As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim sql As String
   Dim repSql As String

   Private DatiConfig As AppConfig
   Private strDescrizione As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

#End Region

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal val As Short)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      Select Case val
         Case Elenco.Clienti
            TipoElenco = Elenco.Clienti
            NomeTabella = "Clienti"
            TitoloFinestra = "Elenco Clienti"

         Case Elenco.Aziende
            TipoElenco = Elenco.Aziende
            NomeTabella = "Aziende"
            TitoloFinestra = "Elenco Aziende"

         Case Elenco.Fornitori
            TipoElenco = Elenco.Fornitori
            NomeTabella = "Fornitori"
            TitoloFinestra = "Elenco Fornitori"

         Case Elenco.Articoli
            TipoElenco = Elenco.Articoli
            NomeTabella = "Articoli"
            TitoloFinestra = "Elenco Articoli e Ingredienti"

         Case Elenco.CatPiatti
            TipoElenco = Elenco.CatPiatti
            NomeTabella = "CategoriePiatti"
            TitoloFinestra = "Categorie piatti"

         Case Elenco.Prenotazioni
            TipoElenco = Elenco.Prenotazioni
            NomeTabella = "Prenotazioni"
            TitoloFinestra = "Elenco prenotazione Tavoli"

         Case Elenco.PrenSale
            TipoElenco = Elenco.PrenSale
            NomeTabella = "PrenSale"
            TitoloFinestra = "Elenco prenotazione Sale"

         Case Elenco.Camerieri
            TipoElenco = Elenco.Camerieri
            NomeTabella = "Camerieri"
            TitoloFinestra = "Elenco Camerieri"

         Case Elenco.Sale
            TipoElenco = Elenco.Sale
            NomeTabella = "Sale"
            TitoloFinestra = "Elenco Sale"

         Case Elenco.Tavoli
            TipoElenco = Elenco.Tavoli
            NomeTabella = "Tavoli"
            TitoloFinestra = "Elenco Tavoli"

         Case Elenco.Camere
            TipoElenco = Elenco.Camere
            NomeTabella = "Camere"
            TitoloFinestra = "Elenco Camere"

         Case Elenco.StatoPren
            TipoElenco = Elenco.StatoPren
            NomeTabella = "StatoPren"
            TitoloFinestra = "Elenco Stato prenotazione"

         Case Elenco.Operatori
            TipoElenco = Elenco.Operatori
            NomeTabella = "Operatori"
            TitoloFinestra = "Elenco Operatori"

         Case Elenco.Gruppi
            TipoElenco = Elenco.Gruppi
            NomeTabella = "Gruppi"
            TitoloFinestra = "Elenco Gruppi operatori"

         Case Elenco.CaratteristicheRisorse
            TipoElenco = Elenco.CaratteristicheRisorse
            NomeTabella = "CaratteristicheRisorse"
            TitoloFinestra = "Elenco Tipologie di utilizzo Risorse"

      End Select

      dt = ds.Tables.Add(NomeTabella)

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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents tbSep As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbSep1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrNuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrModifica As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrElimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrCarico As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrScarico As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrEtichette As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrPrimo As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrPrecedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrSuccessivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrUltimo As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAggiorna As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAnteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrStampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrInserisci As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoDati))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbrNuovo = New System.Windows.Forms.ToolBarButton()
      Me.tbrModifica = New System.Windows.Forms.ToolBarButton()
      Me.tbrElimina = New System.Windows.Forms.ToolBarButton()
      Me.tbSep = New System.Windows.Forms.ToolBarButton()
      Me.tbrCarico = New System.Windows.Forms.ToolBarButton()
      Me.tbrScarico = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
      Me.tbrPrimo = New System.Windows.Forms.ToolBarButton()
      Me.tbrPrecedente = New System.Windows.Forms.ToolBarButton()
      Me.tbrSuccessivo = New System.Windows.Forms.ToolBarButton()
      Me.tbrUltimo = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
      Me.tbrAggiorna = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnteprima = New System.Windows.Forms.ToolBarButton()
      Me.tbrStampa = New System.Windows.Forms.ToolBarButton()
      Me.tbSep1 = New System.Windows.Forms.ToolBarButton()
      Me.tbrEtichette = New System.Windows.Forms.ToolBarButton()
      Me.tbrInserisci = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbrNuovo, Me.tbrModifica, Me.tbrElimina, Me.tbSep, Me.tbrCarico, Me.tbrScarico, Me.ToolBarButton4, Me.tbrPrimo, Me.tbrPrecedente, Me.tbrSuccessivo, Me.tbrUltimo, Me.ToolBarButton7, Me.tbrAggiorna, Me.ToolBarButton1, Me.tbrAnteprima, Me.tbrStampa, Me.tbSep1, Me.tbrEtichette, Me.tbrInserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(608, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'tbrNuovo
      '
      Me.tbrNuovo.ImageIndex = 0
      Me.tbrNuovo.Name = "tbrNuovo"
      Me.tbrNuovo.Tag = "Nuovo"
      Me.tbrNuovo.Text = "Nuovo"
      Me.tbrNuovo.ToolTipText = "Nuovo"
      '
      'tbrModifica
      '
      Me.tbrModifica.ImageIndex = 1
      Me.tbrModifica.Name = "tbrModifica"
      Me.tbrModifica.Tag = "Modifica"
      Me.tbrModifica.Text = "Apri"
      Me.tbrModifica.ToolTipText = "Apri"
      '
      'tbrElimina
      '
      Me.tbrElimina.ImageIndex = 2
      Me.tbrElimina.Name = "tbrElimina"
      Me.tbrElimina.Tag = "Elimina"
      Me.tbrElimina.Text = "Elimina"
      Me.tbrElimina.ToolTipText = "Elimina"
      '
      'tbSep
      '
      Me.tbSep.Name = "tbSep"
      Me.tbSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.tbSep.Visible = False
      '
      'tbrCarico
      '
      Me.tbrCarico.ImageIndex = 10
      Me.tbrCarico.Name = "tbrCarico"
      Me.tbrCarico.Tag = "Carico"
      Me.tbrCarico.Text = "Carico"
      Me.tbrCarico.ToolTipText = "Carico"
      Me.tbrCarico.Visible = False
      '
      'tbrScarico
      '
      Me.tbrScarico.ImageIndex = 11
      Me.tbrScarico.Name = "tbrScarico"
      Me.tbrScarico.Tag = "Scarico"
      Me.tbrScarico.Text = "Scarico"
      Me.tbrScarico.ToolTipText = "Scarico"
      Me.tbrScarico.Visible = False
      '
      'ToolBarButton4
      '
      Me.ToolBarButton4.Name = "ToolBarButton4"
      Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrPrimo
      '
      Me.tbrPrimo.ImageIndex = 3
      Me.tbrPrimo.Name = "tbrPrimo"
      Me.tbrPrimo.Tag = "Primo"
      Me.tbrPrimo.ToolTipText = "Prima pagina"
      '
      'tbrPrecedente
      '
      Me.tbrPrecedente.ImageIndex = 4
      Me.tbrPrecedente.Name = "tbrPrecedente"
      Me.tbrPrecedente.Tag = "Precedente"
      Me.tbrPrecedente.ToolTipText = "Pagina precedente "
      '
      'tbrSuccessivo
      '
      Me.tbrSuccessivo.ImageIndex = 5
      Me.tbrSuccessivo.Name = "tbrSuccessivo"
      Me.tbrSuccessivo.Tag = "Successivo"
      Me.tbrSuccessivo.ToolTipText = "Pagina successiva"
      '
      'tbrUltimo
      '
      Me.tbrUltimo.ImageIndex = 6
      Me.tbrUltimo.Name = "tbrUltimo"
      Me.tbrUltimo.Tag = "Ultimo"
      Me.tbrUltimo.ToolTipText = "Ultima pagina"
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrAggiorna
      '
      Me.tbrAggiorna.ImageIndex = 7
      Me.tbrAggiorna.Name = "tbrAggiorna"
      Me.tbrAggiorna.Tag = "Aggiorna"
      Me.tbrAggiorna.ToolTipText = "Aggiorna"
      '
      'ToolBarButton1
      '
      Me.ToolBarButton1.Name = "ToolBarButton1"
      Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrAnteprima
      '
      Me.tbrAnteprima.ImageIndex = 8
      Me.tbrAnteprima.Name = "tbrAnteprima"
      Me.tbrAnteprima.Tag = "Anteprima"
      Me.tbrAnteprima.ToolTipText = "Anteprima di stampa"
      '
      'tbrStampa
      '
      Me.tbrStampa.ImageIndex = 9
      Me.tbrStampa.Name = "tbrStampa"
      Me.tbrStampa.Tag = "Stampa"
      Me.tbrStampa.ToolTipText = "Stampa"
      '
      'tbSep1
      '
      Me.tbSep1.Name = "tbSep1"
      Me.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.tbSep1.Visible = False
      '
      'tbrEtichette
      '
      Me.tbrEtichette.ImageIndex = 12
      Me.tbrEtichette.Name = "tbrEtichette"
      Me.tbrEtichette.Tag = "Etichette"
      Me.tbrEtichette.ToolTipText = "Etichette indirizzi per spedizione"
      Me.tbrEtichette.Visible = False
      '
      'tbrInserisci
      '
      Me.tbrInserisci.Name = "tbrInserisci"
      Me.tbrInserisci.Tag = ""
      Me.tbrInserisci.Visible = False
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
      Me.ImageList1.Images.SetKeyName(11, "")
      Me.ImageList1.Images.SetKeyName(12, "")
      '
      'DataGrid1
      '
      Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 56)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(608, 285)
      Me.DataGrid1.TabIndex = 1
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.CampoRicerca)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.TestoRicerca)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(608, 30)
      Me.Panel1.TabIndex = 0
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(466, 8)
      Me.CampoRicerca.Name = "CampoRicerca"
      Me.CampoRicerca.Size = New System.Drawing.Size(136, 21)
      Me.CampoRicerca.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(378, 8)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 15)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "Ricerca per:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(2, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(110, 15)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Testo di ricerca:"
      '
      'TestoRicerca
      '
      Me.TestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TestoRicerca.Location = New System.Drawing.Point(113, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(254, 20)
      Me.TestoRicerca.TabIndex = 0
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = ""
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmElencoDati
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(608, 342)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmElencoDati"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         Select Case TipoElenco
            Case Elenco.Clienti
               If DatiConfig.GetValue("WSClienti") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSClienti") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AClienti") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AClienti"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LClienti") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LClienti"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("ClientiX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("ClientiX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("ClientiY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("ClientiY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Aziende
               If DatiConfig.GetValue("WSAziende") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSAziende") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AAziende") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AAziende"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LAziende") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LAziende"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("AziendeX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("AziendeX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("AziendeY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("AziendeY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Fornitori
               If DatiConfig.GetValue("WSFornitori") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSFornitori") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AFornitori") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AFornitori"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LFornitori") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LFornitori"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("FornitoriX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("FornitoriX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("FornitoriY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("FornitoriY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Prenotazioni
               If DatiConfig.GetValue("WSPren") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSPren") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("APren") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("APren"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LPren") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LPren"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("PrenX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("PrenX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("PrenY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PrenY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.PrenSale
               If DatiConfig.GetValue("WSPrenSale") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSPrenSale") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("APrenSale") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("APrenSale"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LPrenSale") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LPrenSale"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("PrenXSale") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("PrenXSale")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("PrenYSale") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PrenYSale")))
                  End If

                  Exit Sub
               End If

            Case Elenco.CatPiatti
               If DatiConfig.GetValue("WSCatPiatti") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSCatPiatti") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("ACatPiatti") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("ACatPiatti"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LCatPiatti") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LCatPiatti"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("CatPiattiX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("CatPiattiX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("CatPiattiY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("CatPiattiY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Camerieri
               If DatiConfig.GetValue("WSCamerieri") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSCamerieri") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("ACamerieri") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("ACamerieri"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LCamerieri") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LCamerieri"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("CamerieriX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("CamerieriX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("CamerieriY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("CamerieriY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Sale
               If DatiConfig.GetValue("WSSale") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSSale") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("ASale") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("ASale"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LSale") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LSale"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("SaleX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("SaleX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("SaleY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("SaleY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Tavoli
               If DatiConfig.GetValue("WSTavoli") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSTavoli") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("ATavoli") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("ATavoli"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LTavoli") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LTavoli"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("TavoliX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("TavoliX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("TavoliY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("TavoliY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Camere
               If DatiConfig.GetValue("WSCamere") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSCamere") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("ACamere") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("ACamere"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LCamere") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LCamere"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("CamereX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("CamereX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("CamereY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("CamereY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.StatoPren
               If DatiConfig.GetValue("WSStatoPren") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSStatoPren") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AStatoPren") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AStatoPren"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LStatoPren") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LStatoPren"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("StatoPrenX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("StatoPrenX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("StatoPrenY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("StatoPrenY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Articoli
               If DatiConfig.GetValue("WSArticoli") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSArticoli") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AArticoli") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AArticoli"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LArticoli") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LArticoli"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("ArticoliX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("ArticoliX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("ArticoliY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("ArticoliY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Operatori
               If DatiConfig.GetValue("WSOperatori") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSOperatori") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AOperatori") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AOperatori"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LOperatori") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LOperatori"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("OperatoriX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("OperatoriX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("OperatoriY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("OperatoriY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Gruppi
               If DatiConfig.GetValue("WSGruppi") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSGruppi") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AGruppi") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AGruppi"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LGruppi") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LGruppi"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("GruppiX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("GruppiX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("GruppiY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("GruppiY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.CaratteristicheRisorse
               If DatiConfig.GetValue("WSCarattRisorse") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSCarattRisorse") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("ACarattRisorse") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("ACarattRisorse"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LCarattRisorse") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LCarattRisorse"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("CarattRisorseX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("CarattRisorseX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("CarattRisorseY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("CarattRisorseY")))
                  End If

                  Exit Sub
               End If

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         Select Case TipoElenco
            Case Elenco.Clienti
               DatiConfig.SetValue("WSClienti", Me.WindowState)
               DatiConfig.SetValue("ClientiX", Me.Location.X)
               DatiConfig.SetValue("ClientiY", Me.Location.Y)
               DatiConfig.SetValue("AClienti", Me.Height)
               DatiConfig.SetValue("LClienti", Me.Width)

            Case Elenco.Aziende
               DatiConfig.SetValue("WSAziende", Me.WindowState)
               DatiConfig.SetValue("AziendeX", Me.Location.X)
               DatiConfig.SetValue("AziendeY", Me.Location.Y)
               DatiConfig.SetValue("AAziende", Me.Height)
               DatiConfig.SetValue("LAziende", Me.Width)

            Case Elenco.Fornitori
               DatiConfig.SetValue("WSFornitori", Me.WindowState)
               DatiConfig.SetValue("FornitoriX", Me.Location.X)
               DatiConfig.SetValue("FornitoriY", Me.Location.Y)
               DatiConfig.SetValue("AFornitori", Me.Height)
               DatiConfig.SetValue("LFornitori", Me.Width)

            Case Elenco.Prenotazioni
               DatiConfig.SetValue("WSPren", Me.WindowState)
               DatiConfig.SetValue("PrenX", Me.Location.X)
               DatiConfig.SetValue("PrenY", Me.Location.Y)
               DatiConfig.SetValue("APren", Me.Height)
               DatiConfig.SetValue("LPren", Me.Width)

            Case Elenco.PrenSale
               DatiConfig.SetValue("WSPrenSale", Me.WindowState)
               DatiConfig.SetValue("PrenXSale", Me.Location.X)
               DatiConfig.SetValue("PrenYSale", Me.Location.Y)
               DatiConfig.SetValue("APrenSale", Me.Height)
               DatiConfig.SetValue("LPrenSale", Me.Width)

            Case Elenco.CatPiatti
               DatiConfig.SetValue("WSCatPiatti", Me.WindowState)
               DatiConfig.SetValue("CatPiattiX", Me.Location.X)
               DatiConfig.SetValue("CatPiattiY", Me.Location.Y)
               DatiConfig.SetValue("ACatPiatti", Me.Height)
               DatiConfig.SetValue("LCatPiatti", Me.Width)

            Case Elenco.Camerieri
               DatiConfig.SetValue("WSCamerieri", Me.WindowState)
               DatiConfig.SetValue("CamerieriX", Me.Location.X)
               DatiConfig.SetValue("CamerieriY", Me.Location.Y)
               DatiConfig.SetValue("ACamerieri", Me.Height)
               DatiConfig.SetValue("LCamerieri", Me.Width)

            Case Elenco.Sale
               DatiConfig.SetValue("WSSale", Me.WindowState)
               DatiConfig.SetValue("SaleX", Me.Location.X)
               DatiConfig.SetValue("SaleY", Me.Location.Y)
               DatiConfig.SetValue("ASale", Me.Height)
               DatiConfig.SetValue("LSale", Me.Width)

            Case Elenco.Tavoli
               DatiConfig.SetValue("WSTavoli", Me.WindowState)
               DatiConfig.SetValue("TavoliX", Me.Location.X)
               DatiConfig.SetValue("TavoliY", Me.Location.Y)
               DatiConfig.SetValue("ATavoli", Me.Height)
               DatiConfig.SetValue("LTavoli", Me.Width)

            Case Elenco.Camere
               DatiConfig.SetValue("WSCamere", Me.WindowState)
               DatiConfig.SetValue("CamereX", Me.Location.X)
               DatiConfig.SetValue("CamereY", Me.Location.Y)
               DatiConfig.SetValue("ACamere", Me.Height)
               DatiConfig.SetValue("LCamere", Me.Width)

            Case Elenco.StatoPren
               DatiConfig.SetValue("WSStatoPren", Me.WindowState)
               DatiConfig.SetValue("StatoPrenX", Me.Location.X)
               DatiConfig.SetValue("StatoPrenY", Me.Location.Y)
               DatiConfig.SetValue("AStatoPren", Me.Height)
               DatiConfig.SetValue("LStatoPren", Me.Width)

            Case Elenco.Articoli
               DatiConfig.SetValue("WSArticoli", Me.WindowState)
               DatiConfig.SetValue("ArticoliX", Me.Location.X)
               DatiConfig.SetValue("ArticoliY", Me.Location.Y)
               DatiConfig.SetValue("AArticoli", Me.Height)
               DatiConfig.SetValue("LArticoli", Me.Width)

            Case Elenco.Operatori
               DatiConfig.SetValue("WSOperatori", Me.WindowState)
               DatiConfig.SetValue("OperatoriX", Me.Location.X)
               DatiConfig.SetValue("OperatoriY", Me.Location.Y)
               DatiConfig.SetValue("AOperatori", Me.Height)
               DatiConfig.SetValue("LOperatori", Me.Width)

            Case Elenco.Gruppi
               DatiConfig.SetValue("WSGruppi", Me.WindowState)
               DatiConfig.SetValue("GruppiX", Me.Location.X)
               DatiConfig.SetValue("GruppiY", Me.Location.Y)
               DatiConfig.SetValue("AGruppi", Me.Height)
               DatiConfig.SetValue("LGruppi", Me.Width)

            Case Elenco.CaratteristicheRisorse
               DatiConfig.SetValue("WSCarattRisorse", Me.WindowState)
               DatiConfig.SetValue("CarattRisorseX", Me.Location.X)
               DatiConfig.SetValue("CarattRisorseY", Me.Location.Y)
               DatiConfig.SetValue("ACarattRisorse", Me.Height)
               DatiConfig.SetValue("LCarattRisorse", Me.Width)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ModificaStatoColoreTavolo(ByVal tabella As String, ByVal codice As String, ByVal colore As Color) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Colore = {1} " &
                             "WHERE Id = {2}",
                             tabella,
                             Convert.ToString(colore.ToArgb),
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Aziende
               If operatore.AnagAziende = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Camerieri
               If operatore.AnagCamerieri = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.CatPiatti
               If operatore.AnagCatPiatti = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Clienti
               If operatore.AnagClienti = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Fornitori
               If operatore.AnagFornitori = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Sale
               If operatore.AnagSale = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Tavoli
               If operatore.AnagTavoli = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Camere
               If operatore.AnagCamere = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.StatoPren
               If operatore.TabStatoPren = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Articoli
               If operatore.MagArticoli = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
                  tbrCarico.Enabled = False
                  tbrScarico.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
                  tbrCarico.Enabled = True
                  tbrScarico.Enabled = True
               End If

            Case Finestra.PrenTavoli
               If operatore.GestPrenTavoli = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.PrenSale
               If operatore.GestPrenSale = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Operatori
               If operatore.GestOperatori = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

            Case Finestra.Gruppi
               If operatore.GestGruppi = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrModifica.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrModifica.Enabled = True
                  tbrElimina.Enabled = True
               End If

               ' A_TODO: Inserire qui il codice per gestire la finestra Caratteristiche Risorse.
         End Select

         Return tbrNuovo.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   Public Sub RegistraModifica()
      Try
         Dim strDescrizione As String

         Select Case TipoElenco
            Case Elenco.Clienti
               ' Registra l'operazione.
               Dim Cognome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
               Dim Nome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
               strDescrizione = "(" & Cognome & " " & Nome & ")"

            Case Elenco.Aziende
               ' Registra l'operazione.
               Dim ragSoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
               strDescrizione = "(" & ragSoc & ")"

            Case Elenco.Fornitori
               ' Registra l'operazione.
               Dim ragSoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & ragSoc & ")"

            Case Elenco.Prenotazioni, Elenco.PrenSale
               ' Registra l'operazione.
               Dim Cliente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
               strDescrizione = "(" & Cliente & ")"

            Case Elenco.CatPiatti
               ' Registra l'operazione.
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Camerieri
               ' Registra l'operazione.
               Dim Nome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & Nome & ")"

            Case Elenco.Sale
               ' Registra l'operazione.
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Tavoli
               ' Registra l'operazione.
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Camere
               ' Registra l'operazione.
               Dim numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
               strDescrizione = "(" & numero & " - " & descrizione & ")"

            Case Elenco.StatoPren
               ' Registra l'operazione.
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Articoli
               ' Registra l'operazione.
               Dim codice As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)
               strDescrizione = "(" & codice & " - " & descrizione & ")"

            Case Elenco.Operatori
               ' Registra l'operazione.
               Dim nomeUtente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & nomeUtente & ")"

            Case Elenco.Gruppi
               ' Registra l'operazione.
               Dim nomeGruppo As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               strDescrizione = "(" & nomeGruppo & ")"

               ' A_TODO: Inserire qui il codice per gestire la finestra Caratteristiche Risorse.

         End Select

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Modifica, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub LeggiDati(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(1, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Sub LeggiNumPagine(ByVal tabella As String)
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
         If closeOnExit Then cn.Close()

         If TestoRicerca.Text <> "" Then
            numPagine = 1
         Else
            ' Ottiene il numero di pagine.
            numPagine = (numRecord + dimPagina - 1) \ dimPagina
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub VisualizzaPagina(ByVal n As Integer, ByVal sql As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sql, cn)

         ' Pulisce la tabella da precedenti dati.
         dt.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dt)

         ' Salva il numero di pagina corrente.
         pagCorrente = n

         ' Abilita/disabilita i pulsanti.
         tbrPrimo.Enabled = (n > 1)
         tbrPrecedente.Enabled = (n > 1)
         tbrSuccessivo.Enabled = (n < numPagine)
         tbrUltimo.Enabled = (n < numPagine)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String
         Dim strDescrizione As String

         Select Case TipoElenco
            Case Elenco.Clienti
               Dim Cognome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               Dim Nome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               ' Registra l'operazione.
               strDescrizione = "(" & Cognome & " " & Nome & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di """ & Cognome & " " & Nome &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")
            Case Elenco.Aziende
               Dim ragSoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & ragSoc & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di " & ragSoc &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati, incassare eventuali documenti Sospesi o fatturare eventuali Buoni pasto.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")
            Case Elenco.Fornitori
               Dim ragSoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & ragSoc & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di " & ragSoc &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Prenotazioni, Elenco.PrenSale
               Dim Cliente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               ' Registra l'operazione.
               strDescrizione = " (" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) &
                 " - Per " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) &
                 " il " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) &
                 " alle " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5) &
                 " / " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6) &
                 " - " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la prenotazione del cliente """ & Cliente &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.CatPiatti
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la Categoria """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Camerieri
               Dim Nome As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & Nome & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare il cameriere """ & Nome &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Sale
               If IsNothing(g_frmVCTavoli) = False Then
                  ' Aggiorna Visual POS
                  MessageBox.Show("Non Ë possibile eliminare una sala perchË Visual POS Ë in esecuzione." & vbCrLf &
                                  "Si consiglia di chiudere Visual POS e ripetere l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If

               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la Sala """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")
            Case Elenco.Tavoli
               If IsNothing(g_frmVCTavoli) = False Then
                  ' Aggiorna Visual POS
                  MessageBox.Show("Non Ë possibile eliminare un tavolo perchË Visual POS Ë in esecuzione." & vbCrLf &
                                  "Si consiglia di chiudere Visual POS e ripetere l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If

               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare il tavolo """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Camere
               Dim numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               ' Registra l'operazione.
               strDescrizione = "(" & numero & " " & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la camera numero """ & numero & " " & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.StatoPren
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare lo stato prenotazione """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Articoli
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare l'articolo """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Operatori
               Dim nomeUtente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & nomeUtente & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di " & nomeUtente &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Gruppi
               Dim nomeGruppo As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & nomeGruppo & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare il gruppo " & nomeGruppo &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.CaratteristicheRisorse
               Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la tipologia di utilizzo risorsa " & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

         End Select

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            'If TipoElenco = Elenco.Risorse Then
            ' Crea la stringa di eliminazione.
            'sql = String.Format("DELETE FROM {0} WHERE Numero = '{1}'", tabella, id)
            'Else
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)
            'End If

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            If TipoElenco = Elenco.Aziende Then
               ' Elimina i dati dei Buoni pasto relativi all'azienda.
               ' Crea la stringa di eliminazione.
               sql = String.Format("DELETE FROM BuoniPasto WHERE IdAzienda = {0}", id)

               ' Crea il comando per la connessione corrente.
               Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)

               ' Esegue il comando.
               Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
            End If

            ' Conferma la transazione.
            tr.Commit()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, strModulo)

         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         ' Aggiorna la griglia dati.
         AggiornaDati()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(NomeTabella)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(pagCorrente, sql)

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TitoloFinestra)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         tbrModifica.Enabled = False
         tbrElimina.Enabled = False
         tbrCarico.Enabled = False
         tbrScarico.Enabled = False
         tbrPrimo.Enabled = False
         tbrPrecedente.Enabled = False
         tbrSuccessivo.Enabled = False
         tbrUltimo.Enabled = False
         tbrAggiorna.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         tbrModifica.Enabled = True
         tbrElimina.Enabled = True
         tbrCarico.Enabled = True
         tbrScarico.Enabled = True
         tbrAggiorna.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      Select Case TipoElenco
         Case Elenco.Clienti
            If ImpostaFunzioniOperatore(Finestra.Clienti) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Aziende
            If ImpostaFunzioniOperatore(Finestra.Aziende) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Fornitori
            If ImpostaFunzioniOperatore(Finestra.Fornitori) = True Then
               ImpostaComandi()
            End If

         Case Elenco.CatPiatti
            If ImpostaFunzioniOperatore(Finestra.CatPiatti) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Camerieri
            If ImpostaFunzioniOperatore(Finestra.Camerieri) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Sale
            If ImpostaFunzioniOperatore(Finestra.Sale) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Tavoli
            If ImpostaFunzioniOperatore(Finestra.Tavoli) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Camere
            If ImpostaFunzioniOperatore(Finestra.Camere) = True Then
               ImpostaComandi()
            End If

         Case Elenco.StatoPren
            If ImpostaFunzioniOperatore(Finestra.StatoPren) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Operatori
            If ImpostaFunzioniOperatore(Finestra.Operatori) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Gruppi
            If ImpostaFunzioniOperatore(Finestra.Gruppi) = True Then
               ImpostaComandi()
            End If

         Case Elenco.CaratteristicheRisorse
            ' A_TODO: Da gestire per Caratteristiche Risorse.
            'If ImpostaFunzioniOperatore(Finestra.Gruppi) = True Then
            '   ImpostaComandi()
            'End If

         Case Elenco.Prenotazioni
            If ImpostaFunzioniOperatore(Finestra.PrenTavoli) = True Then
               ImpostaComandi()
            End If

         Case Elenco.PrenSale
            If ImpostaFunzioniOperatore(Finestra.PrenSale) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Articoli
            If ImpostaFunzioniOperatore(Finestra.Articoli) = True Then
               ImpostaComandi()
            End If
      End Select

   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse. 6666
         Cursor.Current = Cursors.AppStarting

         Select Case TipoElenco
            Case Elenco.Clienti
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_CLIENTI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmClienti
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Aziende
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_AZIENDE)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmAziende
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Fornitori
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_FORNITORI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New Fornitori
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.CatPiatti
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_CAT_PIATTI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmCategoriePiatti
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Camerieri
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_CAMERIERI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmCamerieri
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Sale
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_SALE)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               If IsNothing(g_frmVCTavoli) = False Then
                  ' Aggiorna Visual POS
                  MessageBox.Show("Non Ë possibile modificare o creare una nuova sala perchË Visual POS Ë in esecuzione." & vbCrLf &
                                  "Si consiglia di chiudere Visual POS e ripetere l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If

               Dim frm As New frmSale
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Tavoli
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_TAVOLI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               If IsNothing(g_frmVCTavoli) = False Then
                  ' Aggiorna Visual POS
                  MessageBox.Show("Non Ë possibile modificare o creare un nuovo tavolo perchË Visual POS Ë in esecuzione." & vbCrLf &
                                  "Si consiglia di chiudere Visual POS e ripetere l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If

               Dim frm As New frmTavoli
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Camere
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_CAMERE)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmCamere
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.StatoPren
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_STATO_PREN)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmStatoPrenotazioni
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Prenotazioni
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_PREN)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmPrenotazioni
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.PrenSale
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_PREN_SALE)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmPrenSale
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Articoli
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_ARTICOLI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmArticoli
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Operatori
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_OPERATORI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmOperatori
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Gruppi
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_GRUPPI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmGruppi
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.CaratteristicheRisorse
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_CARATT_RISORSE)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmCaratteristicheRisorse
               frm.Tag = val
               frm.ShowDialog()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            Select Case TipoElenco
               Case Elenco.Clienti
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " &
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) &
                                                        " " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3))

               Case Elenco.Aziende
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " &
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))

               Case Elenco.Prenotazioni, Elenco.PrenSale, Elenco.Articoli
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " &
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3))

               Case Elenco.Camere
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " &
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) &
                                                        " " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))

               Case Elenco.Fornitori, Elenco.CatPiatti, Elenco.Camerieri, Elenco.Sale, Elenco.Tavoli,
                    Elenco.Operatori, Elenco.Gruppi, Elenco.StatoPren, Elenco.CaratteristicheRisorse
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " &
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1))
            End Select
         Else
            DataGrid1.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ImpostaComandoElimina()
      Try
         Select Case NomeTabella
            Case TAB_OPERATORI, TAB_GRUPPI
               Dim idUtente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)

               If idUtente = "1" Then
                  tbrElimina.Enabled = False
               Else
                  tbrElimina.Enabled = True
               End If

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      Try
         ' Imposta il titolo della finestra.
         If TipoElenco = Elenco.Camere Then
            Dim val As Decimal = SommaColonna(DataGrid1, 6, numRecord)
            Me.Text = titolo & " (n∞ totale: " & numRecord & " camere - " & val.ToString & " posti letto)"
         Else
            Me.Text = titolo & " (n∞ totale: " & numRecord & ")"
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonne()
      Try
         Select Case TipoElenco
            Case Elenco.Clienti
               CreaColonneClienti(NomeTabella)

            Case Elenco.Aziende
               CreaColonneAziende(NomeTabella)

            Case Elenco.Fornitori
               CreaColonneFornitori(NomeTabella)

            Case Elenco.CatPiatti
               CreaColonneCatPiatti(NomeTabella)

            Case Elenco.Prenotazioni
               CreaColonnePren(NomeTabella)

            Case Elenco.PrenSale
               CreaColonnePrenSale(NomeTabella)

            Case Elenco.Camerieri
               CreaColonneCamerieri(NomeTabella)

            Case Elenco.Sale
               CreaColonneSale(NomeTabella)

            Case Elenco.Tavoli
               CreaColonneTavoli(NomeTabella)

            Case Elenco.Camere
               CreaColonneCamere(NomeTabella)

            Case Elenco.StatoPren
               CreaColonneStatoPren(NomeTabella)

            Case Elenco.Articoli
               CreaColonneArticoli(NomeTabella)

            Case Elenco.Operatori
               CreaColonneOperatori(NomeTabella)

            Case Elenco.Gruppi
               CreaColonneGruppi(NomeTabella)

            Case Elenco.CaratteristicheRisorse
               CreaColonneCarattRisorse(NomeTabella)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub CreaColonneClienti(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 75
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Cognome
         Dim cognomeStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         cognomeStyle.MappingName = "Cognome"
         cognomeStyle.HeaderText = "Rag. Soc. / Cognome"
         cognomeStyle.Width = 150
         cognomeStyle.NullText = ""
         cognomeStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(cognomeStyle)
         ' Nome
         Dim nomeStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         nomeStyle.MappingName = "Nome"
         nomeStyle.HeaderText = "Nome"
         nomeStyle.Width = 100
         nomeStyle.NullText = ""
         nomeStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(nomeStyle)
         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridTextBoxColumn
         Indirizzo1Style.MappingName = "Indirizzo"
         Indirizzo1Style.HeaderText = "Indirizzo"
         Indirizzo1Style.Width = 150
         Indirizzo1Style.NullText = ""
         Indirizzo1Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(Indirizzo1Style)
         ' Cap
         Dim capStyle As New DataGridTextBoxColumn
         capStyle.MappingName = "Cap"
         capStyle.HeaderText = "C.A.P."
         capStyle.Width = 60
         capStyle.NullText = ""
         capStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(capStyle)
         ' Citt‡
         Dim citt‡Style As New DataGridTextBoxColumn
         citt‡Style.MappingName = "Citt‡"
         citt‡Style.HeaderText = "Citt‡"
         citt‡Style.Width = 150
         citt‡Style.NullText = ""
         citt‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(citt‡Style)
         ' Provincia
         Dim provStyle As New DataGridTextBoxColumn
         provStyle.MappingName = "Provincia"
         provStyle.HeaderText = "Provincia"
         provStyle.Width = 60
         provStyle.NullText = ""
         provStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(provStyle)
         ' Regione
         Dim regioneStyle As New DataGridTextBoxColumn
         regioneStyle.MappingName = "Regione"
         regioneStyle.HeaderText = "Regione"
         regioneStyle.Width = 75
         regioneStyle.NullText = ""
         regioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(regioneStyle)
         ' Nazione
         Dim nazioneStyle As New DataGridTextBoxColumn
         nazioneStyle.MappingName = "Nazione"
         nazioneStyle.HeaderText = "Nazione"
         nazioneStyle.Width = 75
         nazioneStyle.NullText = ""
         nazioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(nazioneStyle)
         ' Data di nascita
         Dim dataNascitaStyle As New DataGridTextBoxColumn
         dataNascitaStyle.MappingName = "DataNascita"
         dataNascitaStyle.HeaderText = "Data di nascita"
         dataNascitaStyle.Width = 85
         dataNascitaStyle.NullText = ""
         dataNascitaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataNascitaStyle)
         ' Tipo Alloggiato
         Dim tipoAlloggiatoStyle As New DataGridTextBoxColumn
         tipoAlloggiatoStyle.MappingName = "TipoAlloggiato"
         tipoAlloggiatoStyle.HeaderText = "Tipo cliente"
         tipoAlloggiatoStyle.Width = 100
         tipoAlloggiatoStyle.NullText = ""
         tipoAlloggiatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipoAlloggiatoStyle)
         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridTextBoxColumn
         telUfficioStyle.MappingName = "TelUfficio"
         telUfficioStyle.HeaderText = "Tel. ufficio"
         telUfficioStyle.Width = 100
         telUfficioStyle.NullText = ""
         telUfficioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(telUfficioStyle)
         ' Tel. casa
         Dim telCasaStyle As New DataGridTextBoxColumn
         telCasaStyle.MappingName = "TelCasa"
         telCasaStyle.HeaderText = "Tel. casa"
         telCasaStyle.Width = 100
         telCasaStyle.NullText = ""
         telCasaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(telCasaStyle)
         ' Fax
         Dim faxStyle As New DataGridTextBoxColumn
         faxStyle.MappingName = "Fax"
         faxStyle.HeaderText = "Fax"
         faxStyle.Width = 100
         faxStyle.NullText = ""
         faxStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(faxStyle)
         ' Cell
         Dim cellStyle As New DataGridTextBoxColumn
         cellStyle.MappingName = "Cell"
         cellStyle.HeaderText = "Cellulare"
         cellStyle.Width = 100
         cellStyle.NullText = ""
         cellStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(cellStyle)
         ' Email
         Dim emailStyle As New DataGridTextBoxColumn
         emailStyle.MappingName = "Email"
         emailStyle.HeaderText = "E-mail"
         emailStyle.Width = 150
         emailStyle.NullText = ""
         emailStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(emailStyle)
         ' Obsoleto
         Dim obsoletoStyle As New DataGridTextBoxColumn
         obsoletoStyle.MappingName = "Obsoleto"
         obsoletoStyle.HeaderText = "Obsoleto"
         obsoletoStyle.Width = 80
         obsoletoStyle.NullText = ""
         obsoletoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(obsoletoStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneAziende(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 75
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Ragione sociale
         Dim ragSocStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         ragSocStyle.MappingName = "RagSociale"
         ragSocStyle.HeaderText = "Ragione sociale"
         ragSocStyle.Width = 150
         ragSocStyle.NullText = ""
         ragSocStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(ragSocStyle)
         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridTextBoxColumn
         Indirizzo1Style.MappingName = "Indirizzo"
         Indirizzo1Style.HeaderText = "Indirizzo"
         Indirizzo1Style.Width = 150
         Indirizzo1Style.NullText = ""
         Indirizzo1Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(Indirizzo1Style)
         ' Cap
         Dim capStyle As New DataGridTextBoxColumn
         capStyle.MappingName = "Cap"
         capStyle.HeaderText = "C.A.P."
         capStyle.Width = 60
         capStyle.NullText = ""
         capStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(capStyle)
         ' Citt‡
         Dim citt‡Style As New DataGridTextBoxColumn
         citt‡Style.MappingName = "Citt‡"
         citt‡Style.HeaderText = "Citt‡"
         citt‡Style.Width = 150
         citt‡Style.NullText = ""
         citt‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(citt‡Style)
         ' Provincia
         Dim provStyle As New DataGridTextBoxColumn
         provStyle.MappingName = "Provincia"
         provStyle.HeaderText = "Provincia"
         provStyle.Width = 60
         provStyle.NullText = ""
         provStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(provStyle)
         ' Regione
         Dim regioneStyle As New DataGridTextBoxColumn
         regioneStyle.MappingName = "Regione"
         regioneStyle.HeaderText = "Regione"
         regioneStyle.Width = 75
         regioneStyle.NullText = ""
         regioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(regioneStyle)
         ' Nazione
         Dim nazioneStyle As New DataGridTextBoxColumn
         nazioneStyle.MappingName = "Nazione"
         nazioneStyle.HeaderText = "Nazione"
         nazioneStyle.Width = 75
         nazioneStyle.NullText = ""
         nazioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(nazioneStyle)
         ' Contatto
         Dim contattoStyle As New DataGridTextBoxColumn
         contattoStyle.MappingName = "Contatto"
         contattoStyle.HeaderText = "Contatto"
         contattoStyle.Width = 75
         contattoStyle.NullText = ""
         contattoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(contattoStyle)
         ' Attivit‡
         Dim attivit‡Style As New DataGridTextBoxColumn
         attivit‡Style.MappingName = "Attivit‡"
         attivit‡Style.HeaderText = "Attivit‡"
         attivit‡Style.Width = 75
         attivit‡Style.NullText = ""
         attivit‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(attivit‡Style)
         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridTextBoxColumn
         telUfficioStyle.MappingName = "TelUfficio"
         telUfficioStyle.HeaderText = "Tel. ufficio"
         telUfficioStyle.Width = 100
         telUfficioStyle.NullText = ""
         telUfficioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(telUfficioStyle)
         ' Fax
         Dim faxStyle As New DataGridTextBoxColumn
         faxStyle.MappingName = "Fax"
         faxStyle.HeaderText = "Fax"
         faxStyle.Width = 100
         faxStyle.NullText = ""
         faxStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(faxStyle)
         ' Cell
         Dim cellStyle As New DataGridTextBoxColumn
         cellStyle.MappingName = "Cell"
         cellStyle.HeaderText = "Cellulare"
         cellStyle.Width = 100
         cellStyle.NullText = ""
         cellStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(cellStyle)
         ' Email
         Dim emailStyle As New DataGridTextBoxColumn
         emailStyle.MappingName = "Email"
         emailStyle.HeaderText = "E-mail"
         emailStyle.Width = 150
         emailStyle.NullText = ""
         emailStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(emailStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneFornitori(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 75
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)

         ' Ragione sociale
         Dim ragSocStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         ragSocStyle.MappingName = "RagSociale"
         ragSocStyle.HeaderText = "Ragione sociale"
         ragSocStyle.Width = 150
         ragSocStyle.NullText = ""
         ragSocStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(ragSocStyle)
         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridTextBoxColumn
         Indirizzo1Style.MappingName = "Indirizzo"
         Indirizzo1Style.HeaderText = "Indirizzo"
         Indirizzo1Style.Width = 150
         Indirizzo1Style.NullText = ""
         Indirizzo1Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(Indirizzo1Style)
         ' Cap
         Dim capStyle As New DataGridTextBoxColumn
         capStyle.MappingName = "Cap"
         capStyle.HeaderText = "C.A.P."
         capStyle.Width = 60
         capStyle.NullText = ""
         capStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(capStyle)
         ' Citt‡
         Dim citt‡Style As New DataGridTextBoxColumn
         citt‡Style.MappingName = "Citt‡"
         citt‡Style.HeaderText = "Citt‡"
         citt‡Style.Width = 150
         citt‡Style.NullText = ""
         citt‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(citt‡Style)
         ' Provincia
         Dim provStyle As New DataGridTextBoxColumn
         provStyle.MappingName = "Provincia"
         provStyle.HeaderText = "Provincia"
         provStyle.Width = 60
         provStyle.NullText = ""
         provStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(provStyle)
         ' Regione
         Dim regioneStyle As New DataGridTextBoxColumn
         regioneStyle.MappingName = "Regione"
         regioneStyle.HeaderText = "Regione"
         regioneStyle.Width = 75
         regioneStyle.NullText = ""
         regioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(regioneStyle)
         ' Nazione
         Dim nazioneStyle As New DataGridTextBoxColumn
         nazioneStyle.MappingName = "Nazione"
         nazioneStyle.HeaderText = "Nazione"
         nazioneStyle.Width = 75
         nazioneStyle.NullText = ""
         nazioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(nazioneStyle)
         ' Contatto
         Dim contattoStyle As New DataGridTextBoxColumn
         contattoStyle.MappingName = "Contatto"
         contattoStyle.HeaderText = "Contatto"
         contattoStyle.Width = 75
         contattoStyle.NullText = ""
         contattoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(contattoStyle)
         ' Attivit‡
         Dim attivit‡Style As New DataGridTextBoxColumn
         attivit‡Style.MappingName = "Attivit‡"
         attivit‡Style.HeaderText = "Attivit‡"
         attivit‡Style.Width = 75
         attivit‡Style.NullText = ""
         attivit‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(attivit‡Style)
         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridTextBoxColumn
         telUfficioStyle.MappingName = "TelUfficio"
         telUfficioStyle.HeaderText = "Tel. ufficio"
         telUfficioStyle.Width = 100
         telUfficioStyle.NullText = ""
         telUfficioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(telUfficioStyle)
         ' Fax
         Dim faxStyle As New DataGridTextBoxColumn
         faxStyle.MappingName = "Fax"
         faxStyle.HeaderText = "Fax"
         faxStyle.Width = 100
         faxStyle.NullText = ""
         faxStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(faxStyle)
         ' Cell
         Dim cellStyle As New DataGridTextBoxColumn
         cellStyle.MappingName = "Cell"
         cellStyle.HeaderText = "Cellulare"
         cellStyle.Width = 100
         cellStyle.NullText = ""
         cellStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(cellStyle)
         ' Email
         Dim emailStyle As New DataGridTextBoxColumn
         emailStyle.MappingName = "Email"
         emailStyle.HeaderText = "E-mail"
         emailStyle.Width = 150
         emailStyle.NullText = ""
         emailStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(emailStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonnePren(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Data
         Dim dataStyle As New DataGridTextBoxColumn
         dataStyle.MappingName = "Data"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 80
         dataStyle.NullText = ""
         dataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Cliente
         Dim clienteStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         clienteStyle.MappingName = "Cliente"
         clienteStyle.HeaderText = "Cliente"
         clienteStyle.Width = 200
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(clienteStyle)
         ' Risorsa
         Dim risorsaStyle As New DataGridTextBoxColumn
         risorsaStyle.MappingName = "DescrizioneRisorsa"
         risorsaStyle.HeaderText = "Tavolo"
         risorsaStyle.Width = 100
         risorsaStyle.NullText = ""
         risorsaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(risorsaStyle)
         ' Persone
         Dim personeStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         personeStyle.MappingName = "Persone"
         personeStyle.HeaderText = "Persone"
         personeStyle.Width = 80
         personeStyle.NullText = ""
         personeStyle.Alignment = HorizontalAlignment.Right
         personeStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(personeStyle)
         ' OraInizio
         Dim oraInizioStyle As New DataGridTextBoxColumn
         oraInizioStyle.MappingName = "OraInizio"
         oraInizioStyle.HeaderText = "Dalle ore"
         oraInizioStyle.Width = 75
         oraInizioStyle.NullText = ""
         'oraInizioStyle.Format = "HH:mm"
         oraInizioStyle.Alignment = HorizontalAlignment.Right
         oraInizioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraInizioStyle)
         ' OraFine
         Dim oraFineStyle As New DataGridTextBoxColumn
         oraFineStyle.MappingName = "OraFine"
         oraFineStyle.HeaderText = "Alle ore"
         oraFineStyle.Width = 75
         oraFineStyle.NullText = ""
         'oraFineStyle.Format = "HH:mm"
         oraFineStyle.Alignment = HorizontalAlignment.Right
         oraFineStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraFineStyle)
         ' Telefono
         Dim telefonoStyle As New DataGridTextBoxColumn
         telefonoStyle.MappingName = "Telefono"
         telefonoStyle.HeaderText = "Telefono"
         telefonoStyle.Width = 100
         telefonoStyle.NullText = ""
         telefonoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(telefonoStyle)
         ' E-mail
         Dim eMailStyle As New DataGridTextBoxColumn
         eMailStyle.MappingName = "eMail"
         eMailStyle.HeaderText = "eMail"
         eMailStyle.Width = 200
         eMailStyle.NullText = ""
         eMailStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(eMailStyle)
         ' Stato prenotazione
         Dim statoStyle As New DataGridTextBoxColumn
         statoStyle.MappingName = "Stato"
         statoStyle.HeaderText = "Stato prenotazione"
         statoStyle.Width = 150
         statoStyle.NullText = ""
         statoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(statoStyle)
         ' Colore
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "Colore"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 50
         coloreStyle.NullText = ""
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonnePrenSale(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Data
         Dim dataStyle As New DataGridTextBoxColumn
         dataStyle.MappingName = "Data"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 80
         dataStyle.NullText = ""
         dataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Cliente
         Dim clienteStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         clienteStyle.MappingName = "Cliente"
         clienteStyle.HeaderText = "Cliente"
         clienteStyle.Width = 200
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(clienteStyle)
         ' Risorsa
         Dim risorsaStyle As New DataGridTextBoxColumn
         risorsaStyle.MappingName = "DescrizioneRisorsa"
         risorsaStyle.HeaderText = "Sala"
         risorsaStyle.Width = 100
         risorsaStyle.NullText = ""
         risorsaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(risorsaStyle)
         ' Persone
         Dim personeStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         personeStyle.MappingName = "Persone"
         personeStyle.HeaderText = "Persone"
         personeStyle.Width = 80
         personeStyle.NullText = ""
         personeStyle.Alignment = HorizontalAlignment.Right
         personeStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(personeStyle)
         ' OraInizio
         Dim oraInizioStyle As New DataGridTextBoxColumn
         oraInizioStyle.MappingName = "OraInizio"
         oraInizioStyle.HeaderText = "Dalle ore"
         oraInizioStyle.Width = 75
         oraInizioStyle.NullText = ""
         oraInizioStyle.Alignment = HorizontalAlignment.Right
         oraInizioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraInizioStyle)
         ' OraFine
         Dim oraFineStyle As New DataGridTextBoxColumn
         oraFineStyle.MappingName = "OraFine"
         oraFineStyle.HeaderText = "Alle ore"
         oraFineStyle.Width = 75
         oraFineStyle.NullText = ""
         oraFineStyle.Alignment = HorizontalAlignment.Right
         oraFineStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraFineStyle)
         ' Stato prenotazione
         Dim statoStyle As New DataGridTextBoxColumn
         statoStyle.MappingName = "Stato"
         statoStyle.HeaderText = "Stato prenotazione"
         statoStyle.Width = 150
         statoStyle.NullText = ""
         statoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(statoStyle)
         ' Colore
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "Colore"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 50
         coloreStyle.NullText = ""
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCatPiatti(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 300
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Reparto
         Dim repartoStyle As New DataGridTextBoxColumn
         repartoStyle.MappingName = "Reparto"
         repartoStyle.HeaderText = "Reparto"
         repartoStyle.Width = 100
         repartoStyle.NullText = ""
         repartoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(repartoStyle)

         ' Colore
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "ColoreSfondo"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 50
         coloreStyle.NullText = ""
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCamerieri(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 60
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Nome
         Dim nomeStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         nomeStyle.MappingName = "Nome"
         nomeStyle.HeaderText = "Nome"
         nomeStyle.Width = 100
         nomeStyle.NullText = ""
         nomeStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(nomeStyle)
         ' Costo ora
         Dim costoOraStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         costoOraStyle.MappingName = "CostoOra"
         costoOraStyle.HeaderText = "Costo/Ora"
         costoOraStyle.Width = 80
         costoOraStyle.NullText = ""
         costoOraStyle.Format = "##,##0.00"
         costoOraStyle.Alignment = HorizontalAlignment.Right
         costoOraStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(costoOraStyle)
         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridTextBoxColumn
         Indirizzo1Style.MappingName = "Indirizzo"
         Indirizzo1Style.HeaderText = "Indirizzo"
         Indirizzo1Style.Width = 150
         Indirizzo1Style.NullText = ""
         Indirizzo1Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(Indirizzo1Style)
         ' Cap
         Dim capStyle As New DataGridTextBoxColumn
         capStyle.MappingName = "Cap"
         capStyle.HeaderText = "C.A.P."
         capStyle.Width = 60
         capStyle.NullText = ""
         capStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(capStyle)
         ' Citt‡
         Dim citt‡Style As New DataGridTextBoxColumn
         citt‡Style.MappingName = "Citt‡"
         citt‡Style.HeaderText = "Citt‡"
         citt‡Style.Width = 150
         citt‡Style.NullText = ""
         citt‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(citt‡Style)
         ' Provincia
         Dim provStyle As New DataGridTextBoxColumn
         provStyle.MappingName = "Provincia"
         provStyle.HeaderText = "Provincia"
         provStyle.Width = 60
         provStyle.NullText = ""
         provStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(provStyle)
         ' Nazione
         Dim nazioneStyle As New DataGridTextBoxColumn
         nazioneStyle.MappingName = "Nazione"
         nazioneStyle.HeaderText = "Nazione"
         nazioneStyle.Width = 75
         nazioneStyle.NullText = ""
         nazioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(nazioneStyle)
         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridTextBoxColumn
         telUfficioStyle.MappingName = "TelUfficio"
         telUfficioStyle.HeaderText = "Tel. ufficio"
         telUfficioStyle.Width = 100
         telUfficioStyle.NullText = ""
         telUfficioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(telUfficioStyle)
         ' Tel. casa
         Dim telCasaStyle As New DataGridTextBoxColumn
         telCasaStyle.MappingName = "TelCasa"
         telCasaStyle.HeaderText = "Tel. casa"
         telCasaStyle.Width = 100
         telCasaStyle.NullText = ""
         telCasaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(telCasaStyle)
         ' Fax
         Dim faxStyle As New DataGridTextBoxColumn
         faxStyle.MappingName = "Fax"
         faxStyle.HeaderText = "Fax"
         faxStyle.Width = 100
         faxStyle.NullText = ""
         faxStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(faxStyle)
         ' Cell
         Dim cellStyle As New DataGridTextBoxColumn
         cellStyle.MappingName = "Cell"
         cellStyle.HeaderText = "Cellulare"
         cellStyle.Width = 100
         cellStyle.NullText = ""
         cellStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(cellStyle)
         ' Email
         Dim emailStyle As New DataGridTextBoxColumn
         emailStyle.MappingName = "Email"
         emailStyle.HeaderText = "E-mail"
         emailStyle.Width = 150
         emailStyle.NullText = ""
         emailStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(emailStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneSale(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 300
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)

         ' Colore
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "ColoreSfondo"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 50
         coloreStyle.NullText = ""
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneTavoli(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 100
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Posti
         Dim postiStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         postiStyle.MappingName = "Posti"
         postiStyle.HeaderText = "Posti"
         postiStyle.Width = 40
         postiStyle.NullText = ""
         postiStyle.Alignment = HorizontalAlignment.Right
         postiStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(postiStyle)
         ' Cameriere
         Dim cameriereStyle As New DataGridTextBoxColumn
         cameriereStyle.MappingName = "Cameriere"
         cameriereStyle.HeaderText = "Cameriere"
         cameriereStyle.Width = 100
         cameriereStyle.NullText = ""
         cameriereStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(cameriereStyle)
         ' Listino
         Dim listinoStyle As New DataGridTextBoxColumn
         listinoStyle.MappingName = "Listino"
         listinoStyle.HeaderText = "Listino"
         listinoStyle.Width = 50
         listinoStyle.NullText = ""
         listinoStyle.Alignment = HorizontalAlignment.Right
         listinoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(listinoStyle)
         ' Sala
         Dim salaStyle As New DataGridTextBoxColumn
         salaStyle.MappingName = "Sala"
         salaStyle.HeaderText = "Sala"
         salaStyle.Width = 100
         salaStyle.NullText = ""
         salaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(salaStyle)
         ' Escludi
         Dim escludiStyle As New DataGridTextBoxColumn
         escludiStyle.MappingName = "Escludi"
         escludiStyle.HeaderText = "Escludi dalla gestione"
         escludiStyle.Width = 120
         escludiStyle.Alignment = HorizontalAlignment.Center
         escludiStyle.NullText = ""
         escludiStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(escludiStyle)
         ' Tipologia
         'Dim tipologiaStyle As New DataGridTextBoxColumn
         'tipologiaStyle.MappingName = "Tipologia"
         'tipologiaStyle.HeaderText = "Tipologia"
         'tipologiaStyle.Width = 100
         'tipologiaStyle.NullText = ""
         'tipologiaStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(tipologiaStyle)
         ' Disponibile
         'Dim disponibileStyle As New DataGridTextBoxColumn
         'disponibileStyle.MappingName = "Disponibile"
         'disponibileStyle.HeaderText = "Disponibile"
         'disponibileStyle.Width = 60
         'disponibileStyle.Alignment = HorizontalAlignment.Center
         'disponibileStyle.NullText = ""
         'disponibileStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(disponibileStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCamere(ByVal tabella As String)
      Dim gridStyle As New DataGridTableStyle
      gridStyle.MappingName = tabella

      ' Codice
      Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
      codiceStyle.MappingName = "Id"
      codiceStyle.HeaderText = "Codice"
      codiceStyle.Width = 50
      codiceStyle.NullText = ""
      codiceStyle.Alignment = HorizontalAlignment.Right
      codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
      gridStyle.GridColumnStyles.Add(codiceStyle)
      ' Numero
      Dim numeroStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
      numeroStyle.MappingName = "Numero"
      numeroStyle.HeaderText = "Numero"
      numeroStyle.Width = 50
      numeroStyle.NullText = ""
      numeroStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
      gridStyle.GridColumnStyles.Add(numeroStyle)
      ' Descrizione
      Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
      descrizioneStyle.MappingName = "Descrizione"
      descrizioneStyle.HeaderText = "Descrizione"
      descrizioneStyle.Width = 150
      descrizioneStyle.NullText = ""
      descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
      gridStyle.GridColumnStyles.Add(descrizioneStyle)
      ' Ubicazione
      Dim ubicazioneStyle As New DataGridTextBoxColumn
      ubicazioneStyle.MappingName = "Ubicazione"
      ubicazioneStyle.HeaderText = "Ubicazione"
      ubicazioneStyle.Width = 100
      ubicazioneStyle.NullText = ""
      ubicazioneStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(ubicazioneStyle)
      ' Posizione
      Dim posizioneStyle As New DataGridTextBoxColumn
      posizioneStyle.MappingName = "Posizione"
      posizioneStyle.HeaderText = "Posizione"
      posizioneStyle.Width = 100
      posizioneStyle.NullText = ""
      posizioneStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(posizioneStyle)
      ' Tipologia
      Dim tipologiaStyle As New DataGridTextBoxColumn
      tipologiaStyle.MappingName = "Tipologia"
      tipologiaStyle.HeaderText = "Tipologia"
      tipologiaStyle.Width = 100
      tipologiaStyle.NullText = ""
      tipologiaStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(tipologiaStyle)
      ' Posti letto
      Dim lettiAggStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
      lettiAggStyle.MappingName = "PostiLetto"
      lettiAggStyle.HeaderText = "Posti letto"
      lettiAggStyle.Width = 60
      lettiAggStyle.Alignment = HorizontalAlignment.Right
      lettiAggStyle.NullText = ""
      lettiAggStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(lettiAggStyle)
      ' Disponibile
      Dim disponibileStyle As New DataGridTextBoxColumn
      disponibileStyle.MappingName = "Disponibile"
      disponibileStyle.HeaderText = "Disponibile"
      disponibileStyle.Width = 70
      disponibileStyle.Alignment = HorizontalAlignment.Center
      disponibileStyle.NullText = ""
      disponibileStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(disponibileStyle)
      ' Escludi
      Dim escludiStyle As New DataGridTextBoxColumn
      escludiStyle.MappingName = "Escludi"
      escludiStyle.HeaderText = "Escludi dal Planning"
      escludiStyle.Width = 120
      escludiStyle.Alignment = HorizontalAlignment.Center
      escludiStyle.NullText = ""
      escludiStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(escludiStyle)
      ' Evidenzia
      Dim evidenziaStyle As New DataGridTextBoxColumn
      evidenziaStyle.MappingName = "Evidenzia"
      evidenziaStyle.HeaderText = "Evidenzia Planning"
      evidenziaStyle.Width = 120
      evidenziaStyle.Alignment = HorizontalAlignment.Center
      evidenziaStyle.NullText = ""
      evidenziaStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(evidenziaStyle)
      ' Listino
      Dim listinoStyle As New DataGridTextBoxColumn
      listinoStyle.MappingName = "Listino"
      listinoStyle.HeaderText = "Listino"
      listinoStyle.Width = 100
      listinoStyle.NullText = ""
      listinoStyle.TextBox.BackColor = Color.White
      gridStyle.GridColumnStyles.Add(listinoStyle)
      ' Colore
      Dim coloreStyle As New CellaColorata(DataGrid1)
      coloreStyle.MappingName = "Colore"
      coloreStyle.HeaderText = "Colore"
      coloreStyle.Width = 50
      coloreStyle.NullText = ""
      coloreStyle.TextBox.BackColor = Color.White
      coloreStyle.TextBox.ForeColor = Color.White
      gridStyle.GridColumnStyles.Add(coloreStyle)

      DataGrid1.TableStyles.Clear()
      DataGrid1.TableStyles.Add(gridStyle)

   End Sub

   Private Sub CreaColonneStatoPren(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 300
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)

         ' Colore
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "Colore"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 50
         coloreStyle.NullText = ""
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneArticoli(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella
         ' Id (non visibile)
         Dim idStyle As New DataGridTextBoxColumn
         idStyle.MappingName = "Id"
         idStyle.HeaderText = "Id"
         idStyle.Width = 0
         idStyle.NullText = ""
         idStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idStyle)
         ' Scorta minima (non visibile)
         Dim smStyle As New DataGridTextBoxColumn
         smStyle.MappingName = "ScortaMin"
         smStyle.HeaderText = "Sm"
         smStyle.Width = 0
         smStyle.NullText = ""
         smStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(smStyle)
         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Codice"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 70
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 200
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Unit‡ di misura
         Dim umStyle As New DataGridTextBoxColumn
         umStyle.MappingName = "Unit‡Misura"
         umStyle.HeaderText = "U.M."
         umStyle.Width = 50
         umStyle.NullText = ""
         umStyle.Alignment = HorizontalAlignment.Center
         umStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(umStyle)
         ' Giacenza
         Dim giacenzaStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         giacenzaStyle.MappingName = "Giacenza"
         giacenzaStyle.HeaderText = "Giacenza"
         giacenzaStyle.Width = 60
         giacenzaStyle.NullText = ""
         giacenzaStyle.Format = "##,##0.000"
         giacenzaStyle.Alignment = HorizontalAlignment.Right
         giacenzaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(giacenzaStyle)
         ' Caricato
         Dim caricatoStyle As New DataGridTextBoxColumn
         caricatoStyle.MappingName = "Carico"
         caricatoStyle.HeaderText = "Carico"
         caricatoStyle.Width = 60
         caricatoStyle.NullText = ""
         caricatoStyle.Format = "##,##0.000"
         caricatoStyle.Alignment = HorizontalAlignment.Right
         caricatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(caricatoStyle)
         ' Scaricato
         Dim scaricatoStyle As New DataGridTextBoxColumn
         scaricatoStyle.MappingName = "Scarico"
         scaricatoStyle.HeaderText = "Scarico"
         scaricatoStyle.Width = 60
         scaricatoStyle.NullText = ""
         scaricatoStyle.Format = "##,##0.000"
         scaricatoStyle.Alignment = HorizontalAlignment.Right
         scaricatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(scaricatoStyle)
         ' Prezzo Acquisto
         Dim pAcquistoStyle As New DataGridTextBoxColumn
         pAcquistoStyle.MappingName = "PrezzoAcquisto"
         pAcquistoStyle.HeaderText = "Prezzo di acquisto"
         pAcquistoStyle.Width = 110
         pAcquistoStyle.NullText = ""
         pAcquistoStyle.Format = "##,##0.00"
         pAcquistoStyle.Alignment = HorizontalAlignment.Right
         pAcquistoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(pAcquistoStyle)
         ' Categoria
         Dim categoriaStyle As New DataGridTextBoxColumn
         categoriaStyle.MappingName = "Categoria"
         categoriaStyle.HeaderText = "Categoria"
         categoriaStyle.Width = 100
         categoriaStyle.NullText = ""
         categoriaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(categoriaStyle)
         ' Fornitore
         Dim fornitoreStyle As New DataGridTextBoxColumn
         fornitoreStyle.MappingName = "Fornitore"
         fornitoreStyle.HeaderText = "Fornitore"
         fornitoreStyle.Width = 150
         fornitoreStyle.NullText = ""
         fornitoreStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(fornitoreStyle)
         ' Magazzino
         Dim magazzinoStyle As New DataGridTextBoxColumn
         magazzinoStyle.MappingName = "Magazzino"
         magazzinoStyle.HeaderText = "Magazzino"
         magazzinoStyle.Width = 100
         magazzinoStyle.NullText = ""
         magazzinoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(magazzinoStyle)
         ' Codice a barre
         Dim barcodStyle As New DataGridTextBoxColumn
         barcodStyle.MappingName = "CodBarre"
         barcodStyle.HeaderText = "Codice a barre"
         barcodStyle.Width = 90
         barcodStyle.NullText = ""
         barcodStyle.Alignment = HorizontalAlignment.Right
         barcodStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(barcodStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneOperatori(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 75
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)

         ' Nome utente
         Dim nomeUtenteStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         nomeUtenteStyle.MappingName = "NomeUtente"
         nomeUtenteStyle.HeaderText = "Nome utente"
         nomeUtenteStyle.Width = 200
         nomeUtenteStyle.NullText = ""
         nomeUtenteStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(nomeUtenteStyle)
         ' Password
         'Dim pwdStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         'pwdStyle.MappingName = "Password"
         'pwdStyle.HeaderText = "Password"
         'pwdStyle.Width = 100
         'pwdStyle.NullText = ""
         'pwdStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         'gridStyle.GridColumnStyles.Add(pwdStyle)
         ' Gruppo
         Dim gruppoStyle As New DataGridTextBoxColumn
         gruppoStyle.MappingName = "Gruppo"
         gruppoStyle.HeaderText = "Gruppo"
         gruppoStyle.Width = 200
         gruppoStyle.NullText = ""
         gruppoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(gruppoStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneGruppi(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 75
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)

         ' Nome gruppo
         Dim nomeGruppoStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         nomeGruppoStyle.MappingName = "NomeGruppo"
         nomeGruppoStyle.HeaderText = "Nome gruppo"
         nomeGruppoStyle.Width = 200
         nomeGruppoStyle.NullText = ""
         nomeGruppoStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(nomeGruppoStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCarattRisorse(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 300
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Costo
         Dim costoStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         costoStyle.MappingName = "Costo"
         costoStyle.HeaderText = "Costo"
         costoStyle.Width = 80
         costoStyle.NullText = ""
         costoStyle.Format = "##,##0.00"
         costoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(costoStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
      Try
         Dim sql As String

         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Codice"
               If TipoElenco = Elenco.Articoli Then
                  campoRicerca = "Codice"
               Else
                  campoRicerca = "Id"
               End If
            Case "Ragione sociale"
               campoRicerca = "RagSociale"
            Case "Rag. Soc. / Cognome"
               campoRicerca = "Cognome"
            Case "C.A.P."
               campoRicerca = "Cap"
            Case "Tel. ufficio"
               campoRicerca = "TelUfficio"
            Case "Tel. casa"
               campoRicerca = "TelCasa"
            Case "Cellulare"
               campoRicerca = "Cell"
            Case "E-mail"
               campoRicerca = "Email"
            Case "Escludi dal planning", "Escludi dalla gestione"
               campoRicerca = "Escludi"
            Case "Stato prenotazione"
               campoRicerca = "Stato"
            Case "Tavolo", "Sala"
               campoRicerca = "DescrizioneRisorsa"
            Case "Dalle ore"
               campoRicerca = "OraInizio"
            Case "Alle ore"
               campoRicerca = "OraFine"
            Case "Data di nascita"
               campoRicerca = "DataNascita"
            Case "Costo/Ora"
               campoRicerca = "CostoOra"
            Case "Codice a barre"
               campoRicerca = "CodBarre"
            Case "Unit‡ di misura"
               campoRicerca = "Unit‡Misura"
            Case "Prezzo di acquisto"
               campoRicerca = "PrezzoAcquisto"
            Case "Nome utente"
               campoRicerca = "NomeUtente"
            Case "Nome gruppo"
               campoRicerca = "NomeGruppo"
            Case "Posti letto"
               campoRicerca = "PostiLetto"
            Case "Escludi dal Planning"
               campoRicerca = "Escludi"
            Case "Evidenzia Planning"
               campoRicerca = "Evidenzia"
            Case "Stato prenotazione"
               campoRicerca = "Stato"
            Case "Tipo cliente"
               campoRicerca = "TipoAlloggiato"
         End Select

         If testoRicerca <> "" Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", NomeTabella, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", NomeTabella, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id ASC", dimPagina, NomeTabella)
            repSql = String.Format("SELECT * FROM {0} ORDER BY Id ASC", NomeTabella)

            'repSql = String.Format("SELECT TOP {0} * INTO RepClienti FROM {1} ORDER BY Id ASC", dimPagina, NomeTabella)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(NomeTabella, sql)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TitoloFinestra)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaCampiRic()
      Try
         Select Case TipoElenco
            Case Elenco.Clienti
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Rag. Soc. / Cognome")
               CampoRicerca.Items.Add("Nome")
               CampoRicerca.Items.Add("Tipo cliente")
               CampoRicerca.Items.Add("Data di nascita")
               CampoRicerca.Items.Add("Indirizzo")
               CampoRicerca.Items.Add("C.A.P.")
               CampoRicerca.Items.Add("Citt‡")
               CampoRicerca.Items.Add("Provincia")
               CampoRicerca.Items.Add("Regione")
               CampoRicerca.Items.Add("Nazione")
               CampoRicerca.Items.Add("Tel. ufficio")
               CampoRicerca.Items.Add("Tel. casa")
               CampoRicerca.Items.Add("Fax")
               CampoRicerca.Items.Add("Cellulare")
               CampoRicerca.Items.Add("E-mail")
               CampoRicerca.Items.Add("Obsoleto")

            Case Elenco.Aziende
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Ragione sociale")
               CampoRicerca.Items.Add("Indirizzo")
               CampoRicerca.Items.Add("C.A.P.")
               CampoRicerca.Items.Add("Citt‡")
               CampoRicerca.Items.Add("Provincia")
               CampoRicerca.Items.Add("Regione")
               CampoRicerca.Items.Add("Nazione")
               CampoRicerca.Items.Add("Contatto")
               CampoRicerca.Items.Add("Attivit‡")
               CampoRicerca.Items.Add("Tel. ufficio")
               CampoRicerca.Items.Add("Fax")
               CampoRicerca.Items.Add("Cellulare")
               CampoRicerca.Items.Add("E-mail")

            Case Elenco.Fornitori
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Ragione sociale")
               CampoRicerca.Items.Add("Indirizzo")
               CampoRicerca.Items.Add("C.A.P.")
               CampoRicerca.Items.Add("Citt‡")
               CampoRicerca.Items.Add("Provincia")
               CampoRicerca.Items.Add("Regione")
               CampoRicerca.Items.Add("Nazione")
               CampoRicerca.Items.Add("Contatto")
               CampoRicerca.Items.Add("Attivit‡")
               CampoRicerca.Items.Add("Tel. ufficio")
               CampoRicerca.Items.Add("Fax")
               CampoRicerca.Items.Add("Cellulare")
               CampoRicerca.Items.Add("E-mail")

            Case Elenco.Articoli
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Descrizione")
               CampoRicerca.Items.Add("Unit‡ di misura")
               CampoRicerca.Items.Add("Giacenza")
               CampoRicerca.Items.Add("Carico")
               CampoRicerca.Items.Add("Scarico")
               CampoRicerca.Items.Add("Prezzo di acquisto")
               CampoRicerca.Items.Add("Categoria")
               CampoRicerca.Items.Add("Fornitore")
               CampoRicerca.Items.Add("Magazzino")
               CampoRicerca.Items.Add("Codice a barre")

            Case Elenco.Prenotazioni
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Data")
               CampoRicerca.Items.Add("Cliente")
               CampoRicerca.Items.Add("Tavolo")
               CampoRicerca.Items.Add("Dalle ore")
               CampoRicerca.Items.Add("Alle ore")
               CampoRicerca.Items.Add("Telefono")
               CampoRicerca.Items.Add("E-mail")
               CampoRicerca.Items.Add("Stato prenotazione")

            Case Elenco.PrenSale
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Data")
               CampoRicerca.Items.Add("Cliente")
               CampoRicerca.Items.Add("Sala")
               CampoRicerca.Items.Add("Dalle ore")
               CampoRicerca.Items.Add("Alle ore")
               CampoRicerca.Items.Add("Stato prenotazione")

            Case Elenco.Sale
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Descrizione")

            Case Elenco.CatPiatti
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Descrizione")
               CampoRicerca.Items.Add("Reparto")

            Case Elenco.Camerieri
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Nome")
               CampoRicerca.Items.Add("Costo/Ora")
               CampoRicerca.Items.Add("Indirizzo")
               CampoRicerca.Items.Add("C.A.P.")
               CampoRicerca.Items.Add("Citt‡")
               CampoRicerca.Items.Add("Provincia")
               CampoRicerca.Items.Add("Nazione")
               CampoRicerca.Items.Add("Tel. ufficio")
               CampoRicerca.Items.Add("Tel. casa")
               CampoRicerca.Items.Add("Fax")
               CampoRicerca.Items.Add("Cellulare")
               CampoRicerca.Items.Add("E-mail")

            Case Elenco.Tavoli
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Descrizione")
               CampoRicerca.Items.Add("Posti")
               CampoRicerca.Items.Add("Cameriere")
               CampoRicerca.Items.Add("Listino")
               CampoRicerca.Items.Add("Sala")
               CampoRicerca.Items.Add("Escludi")

            Case Elenco.Camere
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Numero")
               CampoRicerca.Items.Add("Descrizione")
               CampoRicerca.Items.Add("Ubicazione")
               CampoRicerca.Items.Add("Posizione")
               CampoRicerca.Items.Add("Tipologia")
               CampoRicerca.Items.Add("Posti letto")
               CampoRicerca.Items.Add("Disponibile")
               CampoRicerca.Items.Add("Escludi dal Planning")
               CampoRicerca.Items.Add("Evidenzia Planning")
               CampoRicerca.Items.Add("Listino")

            Case Elenco.StatoPren
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Descrizione")

            Case Elenco.Operatori
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Nome utente")
               CampoRicerca.Items.Add("Gruppo")

            Case Elenco.Gruppi
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Nome gruppo")

            Case Elenco.CaratteristicheRisorse
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Descrizione")
               CampoRicerca.Items.Add("Costo")

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Function LeggiIdRisorsa(ByVal tabella As String, ByVal descrizione As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & descrizione & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Id")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Function LeggiNumRecord(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
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

   Private Sub AnteprimaDiStampa(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New HospitalityDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepCamere(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String, Optional ByVal frmId As String = "")
      Dim cn As OleDbConnection

      Try
         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            If frmId = "Clienti" Or frmId = "Aziende" Then
               ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

               ' Dichiara un oggetto connessione.
               cn = New OleDbConnection(ConnStringAnagrafiche)
            Else
               'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
               cn = New OleDbConnection(ConnString)
            End If

            cn.Open()

            Dim oleAdapter As New OleDbDataAdapter

            oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

            Dim ds As New Dataset1

            ds.Clear()

            oleAdapter.Fill(ds, tabella)

            Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            rep.Load(Application.StartupPath & nomeDoc)

            rep.SetDataSource(ds)

            rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True,
                               PrintDialog1.PrinterSettings.FromPage,
                               PrintDialog1.PrinterSettings.ToPage)

            cn.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmElencoDati_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

#Region "Gestionale Amica - (Condivisa) "

      Select Case TipoElenco
         Case Elenco.Clienti
            ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = True

         Case Elenco.Aziende
            ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = True

         Case Elenco.Fornitori
            ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = True

         Case Elenco.CatPiatti
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Camerieri
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Sale
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Tavoli
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Camere
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.StatoPren
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Operatori
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Gruppi
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.CaratteristicheRisorse
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Prenotazioni
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.PrenSale
            ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = False

         Case Elenco.Articoli
            ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            g_frmMain.rtgGestionaleAmica.Visible = True

      End Select

#End Region

   End Sub

   Private Sub frmElencoDati_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Gestionale Amica - (Condivisa) "

      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

#End Region

   End Sub

   Private Sub frmElencoDati_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne()

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         Select Case TipoElenco
            Case Elenco.Clienti
               CampoRicerca.SelectedIndex = 2

               strDescrizione = STR_ANAGRAFICA_CLIENTI
               strModulo = MODULO_ANAGRAFICA_CLIENTI

            Case Elenco.Aziende
               CampoRicerca.SelectedIndex = 2

               strDescrizione = STR_ANAGRAFICA_AZIENDE
               strModulo = MODULO_ANAGRAFICA_AZIENDE

            Case Elenco.Fornitori
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_FORNITORI
               strModulo = MODULO_ANAGRAFICA_FORNITORI

            Case Elenco.CatPiatti
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_CAT_PIATTI
               strModulo = MODULO_ANAGRAFICA_CAT_PIATTI

            Case Elenco.Camerieri
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_CAMERIERI
               strModulo = MODULO_ANAGRAFICA_CAMERIERI

            Case Elenco.Sale
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_SALE
               strModulo = MODULO_ANAGRAFICA_SALE

            Case Elenco.Tavoli
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_TAVOLI
               strModulo = MODULO_ANAGRAFICA_TAVOLI

            Case Elenco.Camere
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_CAMERE
               strModulo = MODULO_ANAGRAFICA_CAMERE

            Case Elenco.StatoPren
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_TABELLA_STATO_PREN
               strModulo = MODULO_TABELLA_STATO_PREN

            Case Elenco.Operatori
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_GESTIONE_OPERATORI
               strModulo = MODULO_GESTIONE_OPERATORI

            Case Elenco.Gruppi
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_GESTIONE_GRUPPI
               strModulo = MODULO_GESTIONE_GRUPPI

            Case Elenco.CaratteristicheRisorse
               CampoRicerca.SelectedIndex = 1

               ' A_TODO: da gestire per Caratteristiche Risorse.
               strDescrizione = "l'elenco Caratteristiche di utilizzo Risorse." ' STR_GESTIONE_GRUPPI
               strModulo = "GESTIONE CARATTERISTICHE DI UTILIZZO RISORSE" ' MODULO_GESTIONE_GRUPPI

            Case Elenco.Prenotazioni
               CampoRicerca.SelectedIndex = 2

               strDescrizione = STR_GESTIONE_PREN_TAVOLI
               strModulo = MODULO_GESTIONE_PREN_TAVOLI

            Case Elenco.PrenSale
               CampoRicerca.SelectedIndex = 2

               strDescrizione = STR_GESTIONE_PREN_SALE
               strModulo = MODULO_GESTIONE_PREN_SALE

            Case Elenco.Articoli
               CampoRicerca.SelectedIndex = 1

               strDescrizione = STR_MAGAZZINO_ARTICOLI
               strModulo = MODULO_MAGAZZINO_ARTICOLI

               ' Visualizza ulteriori pulsanti sulla ToolBar.
               tbSep.Visible = True
               tbrCarico.Visible = True
               tbrScarico.Visible = True

               ' Inserire qui il codice per gestire ulteriori tabelle dati.
         End Select

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, NomeTabella)
         LeggiDati(NomeTabella, sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TitoloFinestra)

         ' Rende impossibile eliminare il primo record.
         If TipoElenco = Elenco.Gruppi Or TipoElenco = Elenco.Operatori Then
            tbrElimina.Enabled = False
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmElencoDati_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         Select Case TipoElenco
            Case Elenco.Clienti
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmClienti)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmClienti.Dispose()
               g_frmClienti = Nothing

            Case Elenco.Aziende
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmAziende)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmAziende.Dispose()
               g_frmAziende = Nothing

            Case Elenco.Fornitori
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmFornitori)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmFornitori.Dispose()
               g_frmFornitori = Nothing

            Case Elenco.CatPiatti
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmCatPiatti)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmCatPiatti.Dispose()
               g_frmCatPiatti = Nothing

            Case Elenco.Camerieri
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmCamerieri)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmCamerieri.Dispose()
               g_frmCamerieri = Nothing

            Case Elenco.Sale
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmSale)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmSale.Dispose()
               g_frmSale = Nothing

            Case Elenco.Tavoli
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmTavoli)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmTavoli.Dispose()
               g_frmTavoli = Nothing

            Case Elenco.Camere
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmCamere)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmCamere.Dispose()
               g_frmCamere = Nothing

            Case Elenco.StatoPren
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmStatoPren)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmStatoPren.Dispose()
               g_frmStatoPren = Nothing

            Case Elenco.Prenotazioni
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmPren)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmPren.Dispose()
               g_frmPren = Nothing

            Case Elenco.PrenSale
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmPrenSale)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmPrenSale.Dispose()
               g_frmPrenSale = Nothing

            Case Elenco.Articoli
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmArticoli)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmArticoli.Dispose()
               g_frmArticoli = Nothing

            Case Elenco.Operatori
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmOperatori)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmOperatori.Dispose()
               g_frmOperatori = Nothing

            Case Elenco.Gruppi
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmGruppi)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmGruppi.Dispose()
               g_frmGruppi = Nothing

            Case Elenco.CaratteristicheRisorse
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmCaratteristicheRisorse)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmCaratteristicheRisorse.Dispose()
               g_frmCaratteristicheRisorse = Nothing

         End Select

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()

      ImpostaComandoElimina()
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Nuovo"
            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, strDescrizione, strModulo)

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDati("")

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

         Case "Modifica"
            ' Registra loperazione efettuata dall'operatore identificato.
            RegistraModifica()

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

         Case "Elimina"
            ' Elimina il valore selezionato.
            EliminaDati(NomeTabella, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

            If TipoElenco = Elenco.Prenotazioni Then
               Dim nomeTavolo As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)

               ' Cancella il colore di eventuali prenotazioni non pi˘ valide.
               ModificaStatoColoreTavolo(TAB_TAVOLI, LeggiIdRisorsa(TAB_TAVOLI, nomeTavolo), Color.MediumSeaGreen)
            End If

         Case "Carico"
            Dim frm As New CaricoScarico("Carico", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 10),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 11))
            frm.ShowDialog()

         Case "Scarico"
            Dim frm As New CaricoScarico("Scarico", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1),
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8), ,
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 11))
            frm.ShowDialog()

         Case "Stampa"
            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, strDescrizione, strModulo)

            Select Case TipoElenco
               Case Elenco.Clienti
                  StampaDocumento(PERCORSO_REP_CLIENTI, TAB_CLIENTI, repSql, "Clienti")

               Case Elenco.Aziende
                  StampaDocumento(PERCORSO_REP_AZIENDE, TAB_AZIENDE, repSql, "Aziende")

               Case Elenco.Fornitori
                  StampaDocumento(PERCORSO_REP_FORNITORI, TAB_FORNITORI, repSql)

               Case Elenco.CatPiatti
                  StampaDocumento(PERCORSO_REP_CAT_PIATTI, TAB_CAT_PIATTI, repSql)

               Case Elenco.Articoli
                  StampaDocumento(PERCORSO_REP_ARTICOLI, TAB_ARTICOLI, repSql)

               Case Elenco.Camerieri
                  StampaDocumento(PERCORSO_REP_CAMERIERI, TAB_CAMERIERI, repSql)

               Case Elenco.Sale
                  StampaDocumento(PERCORSO_REP_SALE, TAB_SALE, repSql)

               Case Elenco.Tavoli
                  StampaDocumento(PERCORSO_REP_TAVOLI, TAB_TAVOLI, repSql)

               Case Elenco.Camere
                  If PrintDialog1.ShowDialog() = DialogResult.OK Then
                     AnteprimaDiStampa(PERCORSO_REP_CAMERE, TAB_CAMERE, repSql)
                  End If

               Case Elenco.StatoPren
                  ' StampaDocumento(PERCORSO_REP_STATO_PREN, TAB_STATO_PREN, repSql)
                  MessageBox.Show(MESSAGGIO_REPORT_NON_DISPONIBILE, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

               Case Elenco.Prenotazioni
                  StampaDocumento(PERCORSO_REP_PREN, TAB_PREN, repSql)

               Case Elenco.PrenSale
                  StampaDocumento(PERCORSO_REP_PREN_SALE, TAB_PREN_SALE, repSql)

               Case Elenco.Gruppi
                  StampaDocumento(PERCORSO_REP_GRUPPI, TAB_GRUPPI, repSql)

               Case Elenco.Operatori
                  StampaDocumento(PERCORSO_REP_OPERATORI, TAB_OPERATORI, repSql)

               Case Elenco.CaratteristicheRisorse
                  'StampaDocumento(PERCORSO_REP_GRUPPI, TAB_GRUPPI, repSql)
                  MessageBox.Show(MESSAGGIO_REPORT_NON_DISPONIBILE, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Select

         Case "Anteprima"
            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, strDescrizione, strModulo)

            Select Case TipoElenco
               Case Elenco.Clienti
                  g_frmMain.ApriReports(repSql, TAB_CLIENTI, PERCORSO_REP_CLIENTI, "Clienti")

               Case Elenco.Aziende
                  g_frmMain.ApriReports(repSql, TAB_AZIENDE, PERCORSO_REP_AZIENDE, "Aziende")

               Case Elenco.Fornitori
                  g_frmMain.ApriReports(repSql, TAB_FORNITORI, PERCORSO_REP_FORNITORI)

               Case Elenco.CatPiatti
                  g_frmMain.ApriReports(repSql, TAB_CAT_PIATTI, PERCORSO_REP_CAT_PIATTI)

               Case Elenco.Articoli
                  g_frmMain.ApriReports(repSql, TAB_ARTICOLI, PERCORSO_REP_ARTICOLI)

               Case Elenco.Camerieri
                  g_frmMain.ApriReports(repSql, TAB_CAMERIERI, PERCORSO_REP_CAMERIERI)

               Case Elenco.Sale
                  g_frmMain.ApriReports(repSql, TAB_SALE, PERCORSO_REP_SALE)

               Case Elenco.Tavoli
                  g_frmMain.ApriReports(repSql, TAB_TAVOLI, PERCORSO_REP_TAVOLI)

               Case Elenco.Camere
                  AnteprimaDiStampa(PERCORSO_REP_CAMERE, TAB_CAMERE, repSql)

               Case Elenco.StatoPren
                  'g_frmMain.ApriReports(repSql, TAB_STATO_PREN, PERCORSO_REP_STATO_PREN)
                  MessageBox.Show(MESSAGGIO_REPORT_NON_DISPONIBILE, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

               Case Elenco.Prenotazioni
                  g_frmMain.ApriReports(repSql, TAB_PREN, PERCORSO_REP_PREN)

               Case Elenco.PrenSale
                  g_frmMain.ApriReports(repSql, TAB_PREN_SALE, PERCORSO_REP_PREN_SALE)

               Case Elenco.Gruppi
                  g_frmMain.ApriReports(repSql, TAB_GRUPPI, PERCORSO_REP_GRUPPI)

               Case Elenco.Operatori
                  g_frmMain.ApriReports(repSql, TAB_OPERATORI, PERCORSO_REP_OPERATORI)

               Case Elenco.CaratteristicheRisorse
                  'g_frmMain.ApriReports(repSql, TAB_OPERATORI, PERCORSO_REP_OPERATORI)
                  MessageBox.Show(MESSAGGIO_REPORT_NON_DISPONIBILE, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Select

         Case "Primo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, NomeTabella)

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Precedente"
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} ORDER BY Id DESC) ORDER BY Id", NomeTabella, dimPagina, NomeTabella, dt.Rows(0)("Id"))

            ' Visualizza la pagina di dati precedente.
            VisualizzaPagina(pagCorrente - 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Successivo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} ORDER BY Id", dimPagina, NomeTabella, dt.Rows(dt.Rows.Count - 1)("Id"))

            ' Visualizza la pagina di dati successiva.
            VisualizzaPagina(pagCorrente + 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Ultimo"
            Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} ORDER BY Id DESC) ORDER BY Id", NomeTabella, num, NomeTabella)

            ' Visualizza l'ultima pagina di dati.
            VisualizzaPagina(numPagine, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, strDescrizione, strModulo)

            ' Se il modulo Prenotazioni On-line Ë attivo, verifica la presenza di eventuali prenotazioni arrivate da internet. (www.tavoloso.it)
            If moduloAttivo.PrenOnLine = True Then
               ' Legge eventuali file di prenotazioni per Tavoloso.
               g_frmMain.LeggiFilePrenTavoloso(True)
            End If

            ' Aggiorna la griglia dati.
            AggiornaDati()

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

      End Select
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      If tbrModifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         RegistraModifica()

         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      End If
   End Sub

End Class
