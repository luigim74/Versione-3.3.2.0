' Nome form:            frmPlanningP
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/01/2006
' Data ultima modifica: 05/03/2006
' Descrizione:          Planning di periodo per la visualizzazione grafica delle prenotazioni.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class frmPlanningP
   Inherits System.Windows.Forms.Form

   Public NUM_ORE As Short = 36
   Public NUM_RISORSE As Short
   Public NUM_PREN As Short

   Public LARGHEZZA_CELLE As Short = 150
   Public ALTEZZA_CELLE As Short = 40

   Public LARGHEZZA_GRIGLIA As Short
   Public ALTEZZA_GRIGLIA As Short

   Public LARGHEZZA_GRIGLIA_MAX As Short
   Public ALTEZZA_GRIGLIA_MAX As Short

   Public HS_BAR_MAX As Short
   Public VS_BAR_MAX As Short

   Const POS_GRIGLIA As Short = 32
   Const POS_ORE As Short = 136

   Const TAB_STATO_PREN As String = "StatoPrenotazione"
   Const TAB_PRENOTAZIONE As String = "PrenRisorse"
   Const ANAG_RISORSE As String = "Risorse"

   Public Prenotazione() As Button
   Public Risorsa() As Button
   Public NumPren As Short = 0
   Public NumRisorse As Short = 0
   Public Cursore(0) As Label

   Dim CordX, CordY As Integer
   Dim ultimaCordX, ultimaCordY As Integer
   Dim Ora(NUM_ORE) As String

   Dim IntestazioneRisorsa As String
   Dim IntestazioneOra As String

   Public ControlIndex As Integer = 0
   Dim IndiceRisorsa As Short = 1

   Dim HBarVisibile As Boolean = False
   Dim VBarVisibile As Boolean = False

   Dim PosX As Integer = 1

   Dim TipoPlanningSport As Short
   Dim TitoloFinestra As String
   Dim nomePlanning As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Private DatiConfig As AppConfig
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private CFormatta As New ClsFormatta

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal val As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      Select Case val
         Case TipoPlanning.Planning1
            TipoPlanningSport = TipoPlanning.Planning1
            TitoloFinestra = "Planning giornaliero 1"
            nomePlanning = PLANNING_1

         Case TipoPlanning.Planning2
            TipoPlanningSport = TipoPlanning.Planning2
            TitoloFinestra = "Planning giornaliero 2"
            nomePlanning = PLANNING_2

         Case TipoPlanning.Planning3
            TipoPlanningSport = TipoPlanning.Planning3
            TitoloFinestra = "Planning giornaliero 3"
            nomePlanning = PLANNING_3

         Case TipoPlanning.Planning4
            TipoPlanningSport = TipoPlanning.Planning4
            TitoloFinestra = "Planning giornaliero 4"
            nomePlanning = PLANNING_4

      End Select

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      InizializzaOrePlanning(TipoPlanningSport)
      InizializzaVariabili()

      'NUM_RISORSE = NumeroRisorse(ANAG_RISORSE)
      'NUM_PREN = NUM_ORE * NUM_RISORSE

      'LARGHEZZA_CELLE = 150
      'ALTEZZA_CELLE = 40

      'LARGHEZZA_GRIGLIA = LARGHEZZA_CELLE * NUM_RISORSE + 1
      'ALTEZZA_GRIGLIA = ALTEZZA_CELLE * NUM_ORE - ALTEZZA_CELLE

      'LARGHEZZA_GRIGLIA_MAX = LARGHEZZA_GRIGLIA + 1
      'ALTEZZA_GRIGLIA_MAX = ALTEZZA_CELLE * NUM_ORE + 1

      'HS_BAR_MAX = LARGHEZZA_CELLE * 2
      'VS_BAR_MAX = ALTEZZA_CELLE * 3

      'ReDim Prenotazione(NUM_PREN)
      'ReDim Risorsa(NUM_RISORSE)

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
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents ToolBar2 As System.Windows.Forms.ToolBar
   Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Panel4 As System.Windows.Forms.Panel
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Griglia As System.Windows.Forms.Panel
   Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
   Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
   Friend WithEvents Panel5 As System.Windows.Forms.Panel
   Friend WithEvents Panel6 As System.Windows.Forms.Panel
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents Risorse As System.Windows.Forms.Panel
   Friend WithEvents Ore As System.Windows.Forms.Panel
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents lblDettagliPren As System.Windows.Forms.Label
   Friend WithEvents lblRisorsaOra As System.Windows.Forms.Label
   Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton8 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Larghezza As System.Windows.Forms.ComboBox
   Friend WithEvents Altezza As System.Windows.Forms.ComboBox
   Friend WithEvents lblVostraCanc As System.Windows.Forms.Label
   Friend WithEvents lblNostraCanc As System.Windows.Forms.Label
   Friend WithEvents lblSospesa As System.Windows.Forms.Label
   Friend WithEvents lblConfermata As System.Windows.Forms.Label
   Friend WithEvents lblInCorso As System.Windows.Forms.Label
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents lblScaduta As System.Windows.Forms.Label
   Friend WithEvents tbbNuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbbModifica As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbbElimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbbProprietà As System.Windows.Forms.ToolBarButton
   Friend WithEvents lblAbbonamento1 As System.Windows.Forms.Label
   Friend WithEvents lblAbbonamento2 As System.Windows.Forms.Label
   Friend WithEvents lblAbbonamento3 As System.Windows.Forms.Label
   Friend WithEvents lblTorneo As System.Windows.Forms.Label
   Friend WithEvents ckbVisCosto As System.Windows.Forms.CheckBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanningP))
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.lblAbbonamento1 = New System.Windows.Forms.Label()
      Me.lblTorneo = New System.Windows.Forms.Label()
      Me.lblAbbonamento3 = New System.Windows.Forms.Label()
      Me.lblAbbonamento2 = New System.Windows.Forms.Label()
      Me.lblInCorso = New System.Windows.Forms.Label()
      Me.lblScaduta = New System.Windows.Forms.Label()
      Me.lblVostraCanc = New System.Windows.Forms.Label()
      Me.lblNostraCanc = New System.Windows.Forms.Label()
      Me.lblSospesa = New System.Windows.Forms.Label()
      Me.lblConfermata = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ToolBar2 = New System.Windows.Forms.ToolBar()
      Me.tbbNuovo = New System.Windows.Forms.ToolBarButton()
      Me.tbbModifica = New System.Windows.Forms.ToolBarButton()
      Me.tbbElimina = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton()
      Me.tbbProprietà = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton8 = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
      Me.Panel4 = New System.Windows.Forms.Panel()
      Me.Altezza = New System.Windows.Forms.ComboBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.ckbVisCosto = New System.Windows.Forms.CheckBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Larghezza = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.lblDettagliPren = New System.Windows.Forms.Label()
      Me.lblRisorsaOra = New System.Windows.Forms.Label()
      Me.Ore = New System.Windows.Forms.Panel()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.Risorse = New System.Windows.Forms.Panel()
      Me.Griglia = New System.Windows.Forms.Panel()
      Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
      Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
      Me.Panel5 = New System.Windows.Forms.Panel()
      Me.Panel6 = New System.Windows.Forms.Panel()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel3.SuspendLayout()
      Me.Panel4.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.Gray
      Me.Panel3.Controls.Add(Me.lblAbbonamento1)
      Me.Panel3.Controls.Add(Me.lblTorneo)
      Me.Panel3.Controls.Add(Me.lblAbbonamento3)
      Me.Panel3.Controls.Add(Me.lblAbbonamento2)
      Me.Panel3.Controls.Add(Me.lblInCorso)
      Me.Panel3.Controls.Add(Me.lblScaduta)
      Me.Panel3.Controls.Add(Me.lblVostraCanc)
      Me.Panel3.Controls.Add(Me.lblNostraCanc)
      Me.Panel3.Controls.Add(Me.lblSospesa)
      Me.Panel3.Controls.Add(Me.lblConfermata)
      Me.Panel3.Controls.Add(Me.Label1)
      Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel3.Location = New System.Drawing.Point(0, 523)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(893, 19)
      Me.Panel3.TabIndex = 11
      '
      'lblAbbonamento1
      '
      Me.lblAbbonamento1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.lblAbbonamento1.Location = New System.Drawing.Point(582, 0)
      Me.lblAbbonamento1.Name = "lblAbbonamento1"
      Me.lblAbbonamento1.Size = New System.Drawing.Size(116, 19)
      Me.lblAbbonamento1.TabIndex = 7
      Me.lblAbbonamento1.Text = "Abbonamento 1"
      Me.lblAbbonamento1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblAbbonamento1, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'lblTorneo
      '
      Me.lblTorneo.BackColor = System.Drawing.Color.Green
      Me.lblTorneo.Location = New System.Drawing.Point(930, 0)
      Me.lblTorneo.Name = "lblTorneo"
      Me.lblTorneo.Size = New System.Drawing.Size(116, 19)
      Me.lblTorneo.TabIndex = 10
      Me.lblTorneo.Text = "Torneo"
      Me.lblTorneo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblTorneo, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'lblAbbonamento3
      '
      Me.lblAbbonamento3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblAbbonamento3.Location = New System.Drawing.Point(814, 0)
      Me.lblAbbonamento3.Name = "lblAbbonamento3"
      Me.lblAbbonamento3.Size = New System.Drawing.Size(116, 19)
      Me.lblAbbonamento3.TabIndex = 9
      Me.lblAbbonamento3.Text = "Abbonamento 3"
      Me.lblAbbonamento3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblAbbonamento3, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'lblAbbonamento2
      '
      Me.lblAbbonamento2.BackColor = System.Drawing.Color.Magenta
      Me.lblAbbonamento2.Location = New System.Drawing.Point(698, 0)
      Me.lblAbbonamento2.Name = "lblAbbonamento2"
      Me.lblAbbonamento2.Size = New System.Drawing.Size(116, 19)
      Me.lblAbbonamento2.TabIndex = 8
      Me.lblAbbonamento2.Text = "Abbonamento 2"
      Me.lblAbbonamento2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblAbbonamento2, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'lblInCorso
      '
      Me.lblInCorso.BackColor = System.Drawing.Color.LightCoral
      Me.lblInCorso.Location = New System.Drawing.Point(1106, 0)
      Me.lblInCorso.Name = "lblInCorso"
      Me.lblInCorso.Size = New System.Drawing.Size(51, 19)
      Me.lblInCorso.TabIndex = 6
      Me.lblInCorso.Text = "In corso"
      Me.lblInCorso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblInCorso, "Fare doppio click per cambiare il colore di stato della prenotazione")
      Me.lblInCorso.Visible = False
      '
      'lblScaduta
      '
      Me.lblScaduta.BackColor = System.Drawing.Color.PeachPuff
      Me.lblScaduta.ForeColor = System.Drawing.Color.Black
      Me.lblScaduta.ImageAlign = System.Drawing.ContentAlignment.TopRight
      Me.lblScaduta.Location = New System.Drawing.Point(1050, 0)
      Me.lblScaduta.Name = "lblScaduta"
      Me.lblScaduta.Size = New System.Drawing.Size(51, 19)
      Me.lblScaduta.TabIndex = 5
      Me.lblScaduta.Text = "Scaduta"
      Me.lblScaduta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblScaduta, "Fare doppio click per cambiare il colore di stato della prenotazione")
      Me.lblScaduta.Visible = False
      '
      'lblVostraCanc
      '
      Me.lblVostraCanc.BackColor = System.Drawing.Color.DarkCyan
      Me.lblVostraCanc.Location = New System.Drawing.Point(466, 0)
      Me.lblVostraCanc.Name = "lblVostraCanc"
      Me.lblVostraCanc.Size = New System.Drawing.Size(116, 19)
      Me.lblVostraCanc.TabIndex = 4
      Me.lblVostraCanc.Text = "Vostra cancellazione"
      Me.lblVostraCanc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblVostraCanc, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'lblNostraCanc
      '
      Me.lblNostraCanc.BackColor = System.Drawing.Color.Salmon
      Me.lblNostraCanc.Location = New System.Drawing.Point(350, 0)
      Me.lblNostraCanc.Name = "lblNostraCanc"
      Me.lblNostraCanc.Size = New System.Drawing.Size(116, 19)
      Me.lblNostraCanc.TabIndex = 3
      Me.lblNostraCanc.Text = "Nostra cancellazione"
      Me.lblNostraCanc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblNostraCanc, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'lblSospesa
      '
      Me.lblSospesa.BackColor = System.Drawing.Color.Silver
      Me.lblSospesa.Location = New System.Drawing.Point(234, 0)
      Me.lblSospesa.Name = "lblSospesa"
      Me.lblSospesa.Size = New System.Drawing.Size(116, 19)
      Me.lblSospesa.TabIndex = 2
      Me.lblSospesa.Text = "Sospesa"
      Me.lblSospesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblSospesa, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'lblConfermata
      '
      Me.lblConfermata.BackColor = System.Drawing.Color.DodgerBlue
      Me.lblConfermata.ForeColor = System.Drawing.Color.Black
      Me.lblConfermata.ImageAlign = System.Drawing.ContentAlignment.TopRight
      Me.lblConfermata.Location = New System.Drawing.Point(118, 0)
      Me.lblConfermata.Name = "lblConfermata"
      Me.lblConfermata.Size = New System.Drawing.Size(116, 19)
      Me.lblConfermata.TabIndex = 1
      Me.lblConfermata.Text = "Confermata"
      Me.lblConfermata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ToolTip1.SetToolTip(Me.lblConfermata, "Fare doppio click per cambiare il colore di stato della prenotazione")
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Gray
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.Window
      Me.Label1.Location = New System.Drawing.Point(0, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(116, 19)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Legenda:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
      '
      'ToolBar2
      '
      Me.ToolBar2.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar2.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbNuovo, Me.tbbModifica, Me.tbbElimina, Me.ToolBarButton5, Me.tbbProprietà, Me.ToolBarButton3, Me.ToolBarButton8, Me.ToolBarButton7})
      Me.ToolBar2.Divider = False
      Me.ToolBar2.DropDownArrows = True
      Me.ToolBar2.ImageList = Me.ImageList1
      Me.ToolBar2.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar2.Name = "ToolBar2"
      Me.ToolBar2.ShowToolTips = True
      Me.ToolBar2.Size = New System.Drawing.Size(893, 26)
      Me.ToolBar2.TabIndex = 15
      Me.ToolBar2.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'tbbNuovo
      '
      Me.tbbNuovo.Enabled = False
      Me.tbbNuovo.ImageIndex = 1
      Me.tbbNuovo.Name = "tbbNuovo"
      Me.tbbNuovo.Tag = "Nuovo"
      Me.tbbNuovo.Text = "Nuova"
      Me.tbbNuovo.ToolTipText = "Nuova prenotazione"
      '
      'tbbModifica
      '
      Me.tbbModifica.Enabled = False
      Me.tbbModifica.ImageIndex = 2
      Me.tbbModifica.Name = "tbbModifica"
      Me.tbbModifica.Tag = "Modifica"
      Me.tbbModifica.Text = "Apri"
      Me.tbbModifica.ToolTipText = "Modifica prenotazione"
      '
      'tbbElimina
      '
      Me.tbbElimina.Enabled = False
      Me.tbbElimina.ImageIndex = 3
      Me.tbbElimina.Name = "tbbElimina"
      Me.tbbElimina.Tag = "Elimina"
      Me.tbbElimina.Text = "Elimina"
      Me.tbbElimina.ToolTipText = "Elimina prenotazione"
      '
      'ToolBarButton5
      '
      Me.ToolBarButton5.Name = "ToolBarButton5"
      Me.ToolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.ToolBarButton5.Text = "Filtri"
      '
      'tbbProprietà
      '
      Me.tbbProprietà.Enabled = False
      Me.tbbProprietà.ImageIndex = 4
      Me.tbbProprietà.Name = "tbbProprietà"
      Me.tbbProprietà.Tag = "Proprietà"
      Me.tbbProprietà.Text = "Proprietà"
      Me.tbbProprietà.ToolTipText = "Proprietà risorse"
      '
      'ToolBarButton3
      '
      Me.ToolBarButton3.Name = "ToolBarButton3"
      Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.ToolBarButton3.Visible = False
      '
      'ToolBarButton8
      '
      Me.ToolBarButton8.Name = "ToolBarButton8"
      Me.ToolBarButton8.Tag = "Anteprima"
      Me.ToolBarButton8.Text = "Anteprima"
      Me.ToolBarButton8.ToolTipText = "Anteprima di stampa"
      Me.ToolBarButton8.Visible = False
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Text = "Stampa"
      Me.ToolBarButton7.Visible = False
      '
      'Panel4
      '
      Me.Panel4.BackColor = System.Drawing.Color.Gray
      Me.Panel4.Controls.Add(Me.Altezza)
      Me.Panel4.Controls.Add(Me.Label8)
      Me.Panel4.Controls.Add(Me.ckbVisCosto)
      Me.Panel4.Controls.Add(Me.Label9)
      Me.Panel4.Controls.Add(Me.Larghezza)
      Me.Panel4.Controls.Add(Me.Label7)
      Me.Panel4.Controls.Add(Me.dtpData)
      Me.Panel4.Controls.Add(Me.lblDettagliPren)
      Me.Panel4.Controls.Add(Me.lblRisorsaOra)
      Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel4.Location = New System.Drawing.Point(0, 26)
      Me.Panel4.Name = "Panel4"
      Me.Panel4.Size = New System.Drawing.Size(893, 70)
      Me.Panel4.TabIndex = 16
      '
      'Altezza
      '
      Me.Altezza.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Altezza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.Altezza.Items.AddRange(New Object() {"40", "50", "60", "70", "80"})
      Me.Altezza.Location = New System.Drawing.Point(520, 21)
      Me.Altezza.Name = "Altezza"
      Me.Altezza.Size = New System.Drawing.Size(72, 21)
      Me.Altezza.TabIndex = 10
      Me.ToolTip1.SetToolTip(Me.Altezza, "Altezza righe")
      Me.Altezza.Visible = False
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label8.Location = New System.Drawing.Point(520, 2)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(57, 15)
      Me.Label8.TabIndex = 12
      Me.Label8.Text = "Altezza:"
      Me.Label8.Visible = False
      '
      'ckbVisCosto
      '
      Me.ckbVisCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ckbVisCosto.AutoSize = True
      Me.ckbVisCosto.BackColor = System.Drawing.Color.Transparent
      Me.ckbVisCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ckbVisCosto.Enabled = False
      Me.ckbVisCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ckbVisCosto.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ckbVisCosto.Location = New System.Drawing.Point(696, 48)
      Me.ckbVisCosto.Name = "ckbVisCosto"
      Me.ckbVisCosto.Size = New System.Drawing.Size(177, 19)
      Me.ckbVisCosto.TabIndex = 14
      Me.ckbVisCosto.Text = "Visualizza costo risorse"
      Me.ckbVisCosto.UseVisualStyleBackColor = False
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label9.Location = New System.Drawing.Point(800, 5)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(78, 15)
      Me.Label9.TabIndex = 13
      Me.Label9.Text = "Larghezza:"
      '
      'Larghezza
      '
      Me.Larghezza.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Larghezza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.Larghezza.Enabled = False
      Me.Larghezza.Items.AddRange(New Object() {"150", "160", "170", "180", "190", "200", "210", "220", "230", "240", "250"})
      Me.Larghezza.Location = New System.Drawing.Point(800, 24)
      Me.Larghezza.Name = "Larghezza"
      Me.Larghezza.Size = New System.Drawing.Size(72, 21)
      Me.Larghezza.TabIndex = 1
      Me.ToolTip1.SetToolTip(Me.Larghezza, "Larghezza colonne")
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label7.Location = New System.Drawing.Point(600, 5)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(41, 15)
      Me.Label7.TabIndex = 7
      Me.Label7.Text = "Data:"
      '
      'dtpData
      '
      Me.dtpData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpData.Enabled = False
      Me.dtpData.Location = New System.Drawing.Point(600, 24)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(192, 20)
      Me.dtpData.TabIndex = 0
      '
      'lblDettagliPren
      '
      Me.lblDettagliPren.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDettagliPren.BackColor = System.Drawing.Color.Transparent
      Me.lblDettagliPren.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDettagliPren.ForeColor = System.Drawing.SystemColors.Window
      Me.lblDettagliPren.Location = New System.Drawing.Point(16, 40)
      Me.lblDettagliPren.Name = "lblDettagliPren"
      Me.lblDettagliPren.Size = New System.Drawing.Size(576, 16)
      Me.lblDettagliPren.TabIndex = 9
      '
      'lblRisorsaOra
      '
      Me.lblRisorsaOra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblRisorsaOra.BackColor = System.Drawing.Color.Transparent
      Me.lblRisorsaOra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblRisorsaOra.ForeColor = System.Drawing.SystemColors.Window
      Me.lblRisorsaOra.Location = New System.Drawing.Point(11, 13)
      Me.lblRisorsaOra.Name = "lblRisorsaOra"
      Me.lblRisorsaOra.Size = New System.Drawing.Size(581, 18)
      Me.lblRisorsaOra.TabIndex = 8
      '
      'Ore
      '
      Me.Ore.BackColor = System.Drawing.SystemColors.Control
      Me.Ore.Location = New System.Drawing.Point(0, 136)
      Me.Ore.Name = "Ore"
      Me.Ore.Size = New System.Drawing.Size(64, 1320)
      Me.Ore.TabIndex = 21
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.BackColor = System.Drawing.SystemColors.Window
      Me.Panel1.Controls.Add(Me.Risorse)
      Me.Panel1.Controls.Add(Me.Griglia)
      Me.Panel1.Location = New System.Drawing.Point(64, 104)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(813, 400)
      Me.Panel1.TabIndex = 62
      '
      'Risorse
      '
      Me.Risorse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Risorse.BackColor = System.Drawing.Color.Gray
      Me.Risorse.Location = New System.Drawing.Point(0, -1)
      Me.Risorse.Name = "Risorse"
      Me.Risorse.Size = New System.Drawing.Size(10093, 33)
      Me.Risorse.TabIndex = 63
      '
      'Griglia
      '
      Me.Griglia.BackColor = System.Drawing.SystemColors.Window
      Me.Griglia.Enabled = False
      Me.Griglia.Location = New System.Drawing.Point(0, 40)
      Me.Griglia.Name = "Griglia"
      Me.Griglia.Size = New System.Drawing.Size(616, 296)
      Me.Griglia.TabIndex = 62
      '
      'HScrollBar1
      '
      Me.HScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.HScrollBar1.LargeChange = 80
      Me.HScrollBar1.Location = New System.Drawing.Point(64, 504)
      Me.HScrollBar1.Name = "HScrollBar1"
      Me.HScrollBar1.Size = New System.Drawing.Size(812, 18)
      Me.HScrollBar1.SmallChange = 40
      Me.HScrollBar1.TabIndex = 1
      '
      'VScrollBar1
      '
      Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.VScrollBar1.LargeChange = 80
      Me.VScrollBar1.Location = New System.Drawing.Point(875, 136)
      Me.VScrollBar1.Name = "VScrollBar1"
      Me.VScrollBar1.Size = New System.Drawing.Size(18, 368)
      Me.VScrollBar1.SmallChange = 40
      Me.VScrollBar1.TabIndex = 0
      '
      'Panel5
      '
      Me.Panel5.BackColor = System.Drawing.Color.Gray
      Me.Panel5.Location = New System.Drawing.Point(0, 96)
      Me.Panel5.Name = "Panel5"
      Me.Panel5.Size = New System.Drawing.Size(64, 40)
      Me.Panel5.TabIndex = 67
      '
      'Panel6
      '
      Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Panel6.BackColor = System.Drawing.SystemColors.Control
      Me.Panel6.Location = New System.Drawing.Point(0, 505)
      Me.Panel6.Name = "Panel6"
      Me.Panel6.Size = New System.Drawing.Size(64, 18)
      Me.Panel6.TabIndex = 68
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmPlanningP
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.Color.Gray
      Me.ClientSize = New System.Drawing.Size(893, 542)
      Me.Controls.Add(Me.Panel5)
      Me.Controls.Add(Me.Panel6)
      Me.Controls.Add(Me.VScrollBar1)
      Me.Controls.Add(Me.HScrollBar1)
      Me.Controls.Add(Me.Panel4)
      Me.Controls.Add(Me.ToolBar2)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.Ore)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmPlanningP"
      Me.Text = "Plannig giornaliero"
      Me.Panel3.ResumeLayout(False)
      Me.Panel4.ResumeLayout(False)
      Me.Panel4.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1

               If DatiConfig.GetValue("WSPlanning1") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
               ElseIf DatiConfig.GetValue("WSPlanning1") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
               Else
                  If DatiConfig.GetValue("APlanning1") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("APlanning1"))
                  Else
                     Me.Height = PLANNING_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LPlanning1") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LPlanning1"))
                  Else
                     Me.Width = PLANNING_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("PlanningX1") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("PlanningX1")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("PlanningY1") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PlanningY1")))
                  End If

               End If

               If DatiConfig.GetValue("LCelle1") = "" Then
                  Larghezza.Text = "150"
                  LARGHEZZA_CELLE = 150
               Else
                  Larghezza.Text = CShort(DatiConfig.GetValue("LCelle1"))
                  LARGHEZZA_CELLE = Larghezza.Text
               End If

               If DatiConfig.GetValue("VCosto1") = "" Then
                  ckbVisCosto.Checked = False
               Else
                  ckbVisCosto.Checked = DatiConfig.GetValue("VCosto1")
               End If

            Case TipoPlanning.Planning2

               If DatiConfig.GetValue("WSPlanning2") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
               ElseIf DatiConfig.GetValue("WSPlanning2") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
               Else
                  If DatiConfig.GetValue("APlanning2") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("APlanning2"))
                  Else
                     Me.Height = PLANNING_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LPlanning2") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LPlanning2"))
                  Else
                     Me.Width = PLANNING_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("PlanningX2") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("PlanningX2")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("PlanningY2") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PlanningY2")))
                  End If

               End If

               If DatiConfig.GetValue("LCelle2") = "" Then
                  Larghezza.Text = "150"
                  LARGHEZZA_CELLE = 150
               Else
                  Larghezza.Text = CShort(DatiConfig.GetValue("LCelle2"))
                  LARGHEZZA_CELLE = Larghezza.Text
               End If

               If DatiConfig.GetValue("VCosto2") = "" Then
                  ckbVisCosto.Checked = False
               Else
                  ckbVisCosto.Checked = DatiConfig.GetValue("VCosto2")
               End If

            Case TipoPlanning.Planning3

               If DatiConfig.GetValue("WSPlanning3") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
               ElseIf DatiConfig.GetValue("WSPlanning3") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
               Else
                  If DatiConfig.GetValue("APlanning3") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("APlanning3"))
                  Else
                     Me.Height = PLANNING_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LPlanning3") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LPlanning3"))
                  Else
                     Me.Width = PLANNING_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("PlanningX3") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("PlanningX3")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("PlanningY3") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PlanningY3")))
                  End If

               End If

               If DatiConfig.GetValue("LCelle3") = "" Then
                  Larghezza.Text = "150"
                  LARGHEZZA_CELLE = 150
               Else
                  Larghezza.Text = CShort(DatiConfig.GetValue("LCelle3"))
                  LARGHEZZA_CELLE = Larghezza.Text
               End If

               If DatiConfig.GetValue("VCosto3") = "" Then
                  ckbVisCosto.Checked = False
               Else
                  ckbVisCosto.Checked = DatiConfig.GetValue("VCosto3")
               End If

            Case TipoPlanning.Planning4

               If DatiConfig.GetValue("WSPlanning4") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
               ElseIf DatiConfig.GetValue("WSPlanning4") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
               Else
                  If DatiConfig.GetValue("APlanning4") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("APlanning4"))
                  Else
                     Me.Height = PLANNING_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LPlanning4") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LPlanning4"))
                  Else
                     Me.Width = PLANNING_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("PlanningX4") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("PlanningX4")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("PlanningY4") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PlanningY4")))
                  End If

               End If

               If DatiConfig.GetValue("LCelle4") = "" Then
                  Larghezza.Text = "150"
                  LARGHEZZA_CELLE = 150
               Else
                  Larghezza.Text = CShort(DatiConfig.GetValue("LCelle4"))
                  LARGHEZZA_CELLE = Larghezza.Text
               End If

               If DatiConfig.GetValue("VCosto4") = "" Then
                  ckbVisCosto.Checked = False
               Else
                  ckbVisCosto.Checked = DatiConfig.GetValue("VCosto4")
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

         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               DatiConfig.SetValue("WSPlanning1", Me.WindowState)
               DatiConfig.SetValue("APlanning1", Me.Height)
               DatiConfig.SetValue("LPlanning1", Me.Width)
               DatiConfig.SetValue("PlanningX1", Me.Location.X)
               DatiConfig.SetValue("PlanningY1", Me.Location.Y)
               DatiConfig.SetValue("LCelle1", Larghezza.Text)
               DatiConfig.SetValue("VCosto1", ckbVisCosto.Checked)

            Case TipoPlanning.Planning2
               DatiConfig.SetValue("WSPlanning2", Me.WindowState)
               DatiConfig.SetValue("APlanning2", Me.Height)
               DatiConfig.SetValue("LPlanning2", Me.Width)
               DatiConfig.SetValue("PlanningX2", Me.Location.X)
               DatiConfig.SetValue("PlanningY2", Me.Location.Y)
               DatiConfig.SetValue("LCelle2", Larghezza.Text)
               DatiConfig.SetValue("VCosto2", ckbVisCosto.Checked)

            Case TipoPlanning.Planning3
               DatiConfig.SetValue("WSPlanning3", Me.WindowState)
               DatiConfig.SetValue("APlanning3", Me.Height)
               DatiConfig.SetValue("LPlanning3", Me.Width)
               DatiConfig.SetValue("PlanningX3", Me.Location.X)
               DatiConfig.SetValue("PlanningY3", Me.Location.Y)
               DatiConfig.SetValue("LCelle3", Larghezza.Text)
               DatiConfig.SetValue("VCosto3", ckbVisCosto.Checked)

            Case TipoPlanning.Planning4
               DatiConfig.SetValue("WSPlanning4", Me.WindowState)
               DatiConfig.SetValue("APlanning4", Me.Height)
               DatiConfig.SetValue("LPlanning4", Me.Width)
               DatiConfig.SetValue("PlanningX4", Me.Location.X)
               DatiConfig.SetValue("PlanningY4", Me.Location.Y)
               DatiConfig.SetValue("LCelle4", Larghezza.Text)
               DatiConfig.SetValue("VCosto4", ckbVisCosto.Checked)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.PlanningRisorse
               If operatore.AnagPiatti = VALORE_LETTURA Then
                  tbbNuovo.Enabled = False
                  tbbModifica.Enabled = False
                  tbbElimina.Enabled = False
                  tbbProprietà.Enabled = False
               Else
                  tbbNuovo.Enabled = True
                  tbbModifica.Enabled = True
                  tbbElimina.Enabled = True
                  tbbProprietà.Enabled = True
               End If
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Sub registraModifica()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         Dim Descrizione As String = "(Prenotazione N° " & lblDettagliPren.Text & " - " & lblRisorsaOra.Text & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Modifica, Descrizione, MODULO_GESTIONE_PLANNING_RISORSE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DisegnaPlanning()
      DisegnaGrigliaOre(TipoPlanningSport)
      DisegnaGriglia()
   End Sub

   Public Sub InizializzaOrePlanning(ByVal planning As Short)
      Try
         ' Un'ora.
         Select Case planning
            Case TipoPlanning.Planning1
               ' Prenotazione minima di mezz'ora.
               NUM_ORE = 36

            Case TipoPlanning.Planning2
               ' Prenotazione minima di un'ora.
               NUM_ORE = 18

            Case TipoPlanning.Planning3, TipoPlanning.Planning4
               ' Prenotazione minima di un'ora.
               NUM_ORE = 17

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub InizializzaVariabili()
      NUM_RISORSE = NumeroRisorse(ANAG_RISORSE, nomePlanning)
      NUM_PREN = NUM_ORE * NUM_RISORSE

      LARGHEZZA_CELLE = 150
      ALTEZZA_CELLE = 40

      LARGHEZZA_GRIGLIA = LARGHEZZA_CELLE * NUM_RISORSE + 1
      ALTEZZA_GRIGLIA = ALTEZZA_CELLE * NUM_ORE - ALTEZZA_CELLE

      LARGHEZZA_GRIGLIA_MAX = LARGHEZZA_GRIGLIA + 1
      ALTEZZA_GRIGLIA_MAX = ALTEZZA_GRIGLIA + 1 'ALTEZZA_CELLE * NUM_ORE + 1

      HS_BAR_MAX = LARGHEZZA_CELLE * 2
      VS_BAR_MAX = ALTEZZA_CELLE * 3

      ReDim Ora(NUM_ORE)
      ReDim Prenotazione(NUM_PREN)
      ReDim Risorsa(NUM_RISORSE)
   End Sub

   Private Sub DisegnaGrigliaOre(ByVal planning As Short)
      ' *** DISEGNO DELLA GRIGLIA CONTENENTE LE ORE ***
      Const LARGHEZZA_GRIGLIA_ORE As Short = 60

      Try
         Dim grOre As Graphics = Ore.CreateGraphics

         ' Assegna il colore alla griglia ore.
         grOre.Clear(Color.DodgerBlue)
         grOre.FillRectangle(Brushes.DodgerBlue, New Rectangle(0, 0, LARGHEZZA_GRIGLIA_ORE, ALTEZZA_GRIGLIA))

         ' Definisce il tipo di font.
         Dim fnt As New Font("Arial", 8)
         Dim strFormat As New StringFormat
         Dim rett As RectangleF

         ' Allineamento a destra.
         strFormat.Alignment = StringAlignment.Far
         ' Allineamento centrato.
         strFormat.LineAlignment = StringAlignment.Center

         Dim msg As String
         Dim i As Single
         Dim j As Short = 1
         Dim DataAttuale As String

         ' Assegna le ore necessarie alla matrice.
         Select Case planning
            Case TipoPlanning.Planning1
               ' Prenotazione minima di mezz'ora.
               Ora(1) = "6:00"
               Ora(2) = "6:30"
               Ora(3) = "7:00"
               Ora(4) = "7:30"
               Ora(5) = "8:00"
               Ora(6) = "8:30"
               Ora(7) = "9:00"
               Ora(8) = "9:30"
               Ora(9) = "10:00"
               Ora(10) = "10:30"
               Ora(11) = "11:00"
               Ora(12) = "11:30"
               Ora(13) = "12:00"
               Ora(14) = "12:30"
               Ora(15) = "13:00"
               Ora(16) = "13:30"
               Ora(17) = "14:00"
               Ora(18) = "14:30"
               Ora(19) = "15:00"
               Ora(20) = "15:30"
               Ora(21) = "16:00"
               Ora(22) = "16:30"
               Ora(23) = "17:00"
               Ora(24) = "17:30"
               Ora(25) = "18:00"
               Ora(26) = "18:30"
               Ora(27) = "19:00"
               Ora(28) = "19:30"
               Ora(29) = "20:00"
               Ora(30) = "20:30"
               Ora(31) = "21:00"
               Ora(32) = "21:30"
               Ora(33) = "22:00"
               Ora(34) = "22:30"
               Ora(35) = "23:00"
               Ora(36) = "23:30"

            Case TipoPlanning.Planning2
               ' Prenotazione minima di un'ora.
               Ora(1) = "6:45"
               Ora(2) = "7:45"
               Ora(3) = "8:45"
               Ora(4) = "9:45"
               Ora(5) = "10:45"
               Ora(6) = "11:45"
               Ora(7) = "12:45"
               Ora(8) = "13:45"
               Ora(9) = "14:45"
               Ora(10) = "15:45"
               Ora(11) = "16:45"
               Ora(12) = "17:45"
               Ora(13) = "18:45"
               Ora(14) = "19:45"
               Ora(15) = "20:45"
               Ora(16) = "21:45"
               Ora(17) = "22:45"
               Ora(18) = "23:45"

            Case TipoPlanning.Planning3
               ' Prenotazione minima di un'ora.
               Ora(1) = "7:00"
               Ora(2) = "8:00"
               Ora(3) = "9:00"
               Ora(4) = "10:00"
               Ora(5) = "11:00"
               Ora(6) = "12:00"
               Ora(7) = "13:00"
               Ora(8) = "14:00"
               Ora(9) = "15:00"
               Ora(10) = "16:00"
               Ora(11) = "17:00"
               Ora(12) = "18:00"
               Ora(13) = "19:00"
               Ora(14) = "20:00"
               Ora(15) = "21:00"
               Ora(16) = "22:00"
               Ora(17) = "23:00"

            Case TipoPlanning.Planning4
               ' Prenotazione minima di un'ora.
               Ora(1) = "7:15"
               Ora(2) = "8:15"
               Ora(3) = "9:15"
               Ora(4) = "10:15"
               Ora(5) = "11:15"
               Ora(6) = "12:15"
               Ora(7) = "13:15"
               Ora(8) = "14:15"
               Ora(9) = "15:15"
               Ora(10) = "16:15"
               Ora(11) = "17:15"
               Ora(12) = "18:15"
               Ora(13) = "19:15"
               Ora(14) = "20:15"
               Ora(15) = "21:15"
               Ora(16) = "22:15"
               Ora(17) = "23:15"
         End Select

         For i = 0 To ALTEZZA_GRIGLIA Step ALTEZZA_CELLE
            ' Crea il rettangolo contenente l'ora.
            msg = String.Format("{0}", Ora(j))
            rett = New RectangleF(10, i, 40, 40)
            grOre.DrawString(msg, fnt, Brushes.White, rett, strFormat)
            j += 1
         Next i

         ' Distrugge l'oggetto font.
         fnt.Dispose()

         ' Disegna le linee per la griglia delle ore.
         Dim grOreLine As Graphics = Ore.CreateGraphics

         ' Assegna il colore alla linea.
         Dim p1 As New Pen(Color.White, 1)
         Dim x1, y1 As Single

         ' Disegna le linee orizzontali.
         For y1 = 0 To ALTEZZA_GRIGLIA + ALTEZZA_CELLE Step ALTEZZA_CELLE
            grOreLine.DrawLine(p1, 0, y1, Ore.ClientSize.Width, y1)
         Next y1

         ' Distrugge gli oggetti grafici.
         grOre.Dispose()
         grOreLine.Dispose()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaGriglia()
      ' DISEGNO DELLA GRIGLIA CONTENENTE LE PRENOTAZIONI.
      Try
         Dim grGriglia As Graphics = Griglia.CreateGraphics
         grGriglia.Clear(Color.White)

         Dim p As New Pen(Color.Silver, 1)
         Dim x As Single = 0
         Dim y As Single = 0

         For x = 0 To LARGHEZZA_GRIGLIA Step LARGHEZZA_CELLE
            grGriglia.DrawLine(p, x, 0, x, ALTEZZA_CELLE * NUM_ORE) '1340
         Next x

         For y = 0 To ALTEZZA_GRIGLIA + ALTEZZA_CELLE Step ALTEZZA_CELLE
            grGriglia.DrawLine(p, 0, y, LARGHEZZA_GRIGLIA, y)
         Next y

         ' Distrugge gli oggetti grafici.
         grGriglia.Dispose()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaRisorse(ByVal nome As String, ByVal colore As String, ByVal note As String, ByVal costo As String, ByVal id As Integer)
      Try
         NumRisorse += 1

         Risorsa(NumRisorse) = New Button
         Risorsa(NumRisorse).Name = id '"Risorsa" & NumRisorse
         Risorsa(NumRisorse).Location = New Point(PosX, 1) '3
         Risorsa(NumRisorse).Size = New Size(LARGHEZZA_CELLE - 2, 31) '28
         Risorsa(NumRisorse).FlatStyle = FlatStyle.Popup
         Risorsa(NumRisorse).BackColor = Color.FromArgb(CInt(colore))
         Risorsa(NumRisorse).ForeColor = Color.White
         Risorsa(NumRisorse).Tag = nome

         If ckbVisCosto.Checked = True Then
            Risorsa(NumRisorse).Text = nome & vbNewLine & "€ " & CFormatta.FormattaEuro(costo)
         Else
            Risorsa(NumRisorse).Text = nome
         End If

         If note = "" Then
            ToolTip1.SetToolTip(Risorsa(NumRisorse), "Nessuna nota.")
         Else
            ToolTip1.SetToolTip(Risorsa(NumRisorse), note)
         End If

         Risorse.Controls.Add(Risorsa(NumRisorse))

         AddHandler Risorsa(NumRisorse).Click, AddressOf Risorsa_Click

         PosX = PosX + LARGHEZZA_CELLE

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RidimensionaRisorse()
      Try
         If Risorse.Controls.Count <> 0 Then
            Dim i As Short
            Dim PosX As Integer = 1
            For i = 1 To NUM_RISORSE
               Risorsa(i).Location = New Point(PosX, 1) '3
               Risorsa(i).Size = New Size(LARGHEZZA_CELLE - 2, 31) '28
               PosX = PosX + LARGHEZZA_CELLE
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RidimensionaRigheColonne()
      Try
         If Larghezza.Text <> "" Then
            LARGHEZZA_CELLE = CShort(Larghezza.Text)
         Else
            LARGHEZZA_CELLE = 150
         End If

         ' B_TODO: CODICE DA INSERIRE PER GESTIRE L'ALTEZZA DELLE RIGHE.
         'If Altezza.Text <> "" Then
         '   ALTEZZA_CELLE = CShort(Altezza.Text)
         'Else
         '   ALTEZZA_CELLE = 40
         'End If

         LARGHEZZA_GRIGLIA = LARGHEZZA_CELLE * NUM_RISORSE + 1
         ALTEZZA_GRIGLIA = ALTEZZA_CELLE * NUM_ORE - ALTEZZA_CELLE

         LARGHEZZA_GRIGLIA_MAX = LARGHEZZA_GRIGLIA + 1
         ALTEZZA_GRIGLIA_MAX = ALTEZZA_CELLE * NUM_ORE + 1

         HS_BAR_MAX = LARGHEZZA_CELLE * 2
         VS_BAR_MAX = ALTEZZA_CELLE * 3

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' A_TODO: MODIFICHE ASD AGON
   Private Sub DisegnaPrenotazione(ByVal numero As String, ByVal cliente As String, ByVal componenti As String, ByVal colore As String, _
                                   ByVal costoRisorsa As String, ByVal tipologiaUtilizzo As String, ByVal pagato As String, _
                                   ByVal importo As String, ByVal note As String, ByVal orePren As Integer, ByVal x As Integer, ByVal y As Integer)

      Try
         NumPren += 1

         Prenotazione(NumPren) = New Button
         Prenotazione(NumPren).Name = numero
         Prenotazione(NumPren).Location = New Point(x + 1, y + 2)
         Prenotazione(NumPren).Size = New Size(LARGHEZZA_CELLE - 3, (ALTEZZA_CELLE * orePren) - 3)
         Prenotazione(NumPren).FlatStyle = FlatStyle.Popup
         Prenotazione(NumPren).BackColor = Color.FromArgb(CInt(colore))
         Prenotazione(NumPren).ForeColor = Color.White
         Prenotazione(NumPren).TextAlign = ContentAlignment.TopLeft

         Prenotazione(NumPren).Tag = componenti

         ' A_TODO: MODIFICHE ASD AGON
         If tipologiaUtilizzo <> VALORE_NESSUNA And tipologiaUtilizzo <> String.Empty Then
            Prenotazione(NumPren).Text = numero & vbNewLine & cliente & vbNewLine & vbNewLine & tipologiaUtilizzo
         Else
            Prenotazione(NumPren).Text = numero & vbNewLine & cliente
         End If

         ' Se pagato è uguale a sì visualizza l'immagine.
         Prenotazione(NumPren).ImageList = ImageList1
         Prenotazione(NumPren).ImageIndex = 0
         Prenotazione(NumPren).ImageAlign = ContentAlignment.TopRight

         ' A_TODO: MODIFICHE ASD AGON

         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               ToolTip1.SetToolTip(Prenotazione(NumPren), "Tipologia di utilizzo: " & tipologiaUtilizzo & vbNewLine & vbNewLine & _
                                                          "Ore prenotate: " & (orePren / 2).ToString & vbNewLine & _
                                                          "Costo risorsa: € " & costoRisorsa & vbNewLine & _
                                                          "Pagato: " & pagato & " - € " & importo & vbNewLine & vbNewLine & _
                                                          "Note: " & note)

            Case TipoPlanning.Planning2, TipoPlanning.Planning3, TipoPlanning.Planning4
               ToolTip1.SetToolTip(Prenotazione(NumPren), "Tipologia di utilizzo: " & tipologiaUtilizzo & vbNewLine & vbNewLine & _
                                                          "Ore prenotate: " & (orePren).ToString & vbNewLine & _
                                                          "Costo risorsa: € " & costoRisorsa & vbNewLine & _
                                                          "Pagato: " & pagato & " - € " & importo & vbNewLine & vbNewLine & _
                                                          "Note: " & note)
         End Select

         Griglia.Controls.Add(Prenotazione(NumPren))

         AddHandler Prenotazione(NumPren).Click, AddressOf Prenotazione_Click
         AddHandler Prenotazione(NumPren).DoubleClick, AddressOf Prenotazione_DoubleClick
         AddHandler Prenotazione(NumPren).GotFocus, AddressOf Prenotazione_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
   Private Sub DisegnaCursore(ByVal x As Integer, ByVal y As Integer)
      Try
         Cursore(0) = New Label
         Cursore(0).Name = "lblCursore"
         Cursore(0).Location = New Point(x, y)
         Cursore(0).Size = New Size(LARGHEZZA_CELLE, ALTEZZA_CELLE)
         Cursore(0).FlatStyle = FlatStyle.Popup
         Cursore(0).BorderStyle = BorderStyle.FixedSingle
         Cursore(0).BackColor = Color.White

         Griglia.Controls.Add(Cursore(0))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaPrenotazione(ByVal indice As Integer)
      Try
         Griglia.Controls.RemoveAt(indice)

         NumPren -= 1

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaTuttePrenotazioni()
      Try
         Griglia.Controls.Clear()

         NumPren = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub EliminaTutteRisorse()
      Dim i As Short

      Try
         For i = 1 To NumRisorse
            Risorse.Controls.RemoveAt(Risorse.Controls.Count - 1)
         Next

         NumRisorse = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' A_TODO: MODIFICHE ASD AGON
   Private Function CalcolaOrePrenotate(ByVal oraInizio As String, ByVal oraFine As String) As Integer
      Try
         Dim Ore As Double = 0
         Dim valOraInizio As Double = ConvertiOra(oraInizio)
         Dim valOraFine As Double = ConvertiOra(oraFine)

         Ore = (valOraFine - valOraInizio)

         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               ' Mezz'ora.
               Return Ore * 2

            Case TipoPlanning.Planning2, TipoPlanning.Planning3, TipoPlanning.Planning4
               'Un'ora.
               Return Ore

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         ' Mezz'ora.
         Return 1

      End Try

   End Function

   Public Function LeggiDatiPren(ByVal tabella As String, ByVal data As String, ByVal idRisorsa As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()
         ' A_TODO: MODIFICHE ASD AGON
         Dim costoRisorsa As String
         Dim tipologiaUtilizzo As String
         Dim pagato As String
         Dim importo As String
         Dim note As String

         Dim oraInizio As String
         Dim oraFine As String


         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Data = #" & data & "# AND IdRisorsa = '" & idRisorsa & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("CostoRisorsa")) = False Then
               costoRisorsa = CFormatta.FormattaEuro(dr.Item("CostoRisorsa"))
            Else
               costoRisorsa = "0,00"
            End If
            If IsDBNull(dr.Item("CaratteristicaRisorsa")) = False Then
               tipologiaUtilizzo = dr.Item("CaratteristicaRisorsa")
            Else
               tipologiaUtilizzo = VALORE_NESSUNA
            End If
            If IsDBNull(dr.Item("pagato")) = False Then
               pagato = dr.Item("pagato")
            Else
               pagato = "No"
            End If
            If IsDBNull(dr.Item("Totale")) = False Then
               importo = CFormatta.FormattaEuro(dr.Item("Totale"))
            Else
               importo = "0,00"
            End If
            If IsDBNull(dr.Item("Note")) = False Then
               note = dr.Item("Note")
            Else
               note = ""
            End If

            Dim testoGiocatori As String = ""

            If IsDBNull(dr.Item("Componente1")) = False Then
               If dr.Item("Componente1") <> "" Then
                  testoGiocatori = "( " & dr.Item("Componente1")
               End If
            End If

            If IsDBNull(dr.Item("Componente2")) = False Then
               If dr.Item("Componente2") <> "" Then
                  testoGiocatori = testoGiocatori & ", " & dr.Item("Componente2")
               End If
            End If

            If IsDBNull(dr.Item("Componente3")) = False Then
               If dr.Item("Componente3") <> "" Then
                  testoGiocatori = testoGiocatori & ", " & dr.Item("Componente3")
               End If
            End If

            If testoGiocatori <> "" Then
               testoGiocatori = testoGiocatori & " )"
            End If

            If IsDBNull(dr.Item("OraInizio")) = False Then
               oraInizio = dr.Item("OraInizio")
            Else
               oraInizio = "6:00"
            End If
            If IsDBNull(dr.Item("OraFine")) = False Then
               oraFine = dr.Item("OraFine")
            Else
               oraFine = "6:30"
            End If

            Dim valOrePren As Integer = CalcolaOrePrenotate(oraInizio, oraFine)

            Dim i As Integer
            For i = 1 To NUM_RISORSE
               If Risorsa(i).Name = idRisorsa Then
                  DisegnaPrenotazione(dr.Item("Id"), dr.Item("Intestatario"), testoGiocatori, dr.Item("colore"), _
                                      costoRisorsa, tipologiaUtilizzo, pagato, importo, note, valOrePren, Risorsa(i).Location.X, dr.Item("CordY"))
                  Exit For
               End If
            Next

            Caricati = True
         Loop

         Return Caricati

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDatiRisorse(ByVal tabella As String, ByVal tipoPlanning As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim risorse As Boolean = False

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Escludi = 'No' AND TipoPlanning = '" & FormattaApici(tipoPlanning) & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         PosX = 1

         Do While dr.Read()
            DisegnaRisorse(dr.Item("Descrizione"), dr.Item("Colore"), dr.Item("Note"), dr.Item("Costo"), dr.Item("Id"))

            risorse = True
         Loop

         Return risorse

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return risorse

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiIdRisorse(ByVal tabella As String, ByVal data As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Escludi = 'No' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            LeggiDatiPren(TAB_PRENOTAZIONE, data, dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function NumeroRisorse(ByVal tabella As String, ByVal tipoPlanning As String) As Short
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim NumRecord As Integer

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Escludi = 'No' AND TipoPlanning = '" & FormattaApici(tipoPlanning) & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Ottiene il numero di record
            NumRecord += 1
         Loop

         Return NumRecord

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Function CordinataX(ByVal x As Integer) As Integer
      Dim i As Short

      Try
         ' Questa casistica gestisce 25 risorse.
         Select Case x
            Case 0 To LARGHEZZA_CELLE
               CordinataX = 0
               IntestazioneRisorsa = Risorsa(1).Tag
               IndiceRisorsa = 1

            Case LARGHEZZA_CELLE + 1 To LARGHEZZA_CELLE * 2
               CordinataX = LARGHEZZA_CELLE
               IntestazioneRisorsa = Risorsa(2).Tag
               IndiceRisorsa = 2

            Case (LARGHEZZA_CELLE * 2) + 1 To LARGHEZZA_CELLE * 3
               CordinataX = LARGHEZZA_CELLE * 2
               IntestazioneRisorsa = Risorsa(3).Tag
               IndiceRisorsa = 3

            Case (LARGHEZZA_CELLE * 3) + 1 To LARGHEZZA_CELLE * 4
               CordinataX = LARGHEZZA_CELLE * 3
               IntestazioneRisorsa = Risorsa(4).Tag
               IndiceRisorsa = 4

            Case (LARGHEZZA_CELLE * 4) + 1 To LARGHEZZA_CELLE * 5
               CordinataX = LARGHEZZA_CELLE * 4
               IntestazioneRisorsa = Risorsa(5).Tag
               IndiceRisorsa = 5

            Case (LARGHEZZA_CELLE * 5) + 1 To LARGHEZZA_CELLE * 6
               CordinataX = LARGHEZZA_CELLE * 5
               IntestazioneRisorsa = Risorsa(6).Tag
               IndiceRisorsa = 6

            Case (LARGHEZZA_CELLE * 6) + 1 To LARGHEZZA_CELLE * 7
               CordinataX = LARGHEZZA_CELLE * 6
               IntestazioneRisorsa = Risorsa(7).Tag
               IndiceRisorsa = 7

            Case (LARGHEZZA_CELLE * 7) + 1 To LARGHEZZA_CELLE * 8
               CordinataX = LARGHEZZA_CELLE * 7
               IntestazioneRisorsa = Risorsa(8).Tag
               IndiceRisorsa = 8

            Case (LARGHEZZA_CELLE * 8) + 1 To LARGHEZZA_CELLE * 9
               CordinataX = LARGHEZZA_CELLE * 8
               IntestazioneRisorsa = Risorsa(9).Tag
               IndiceRisorsa = 9

            Case (LARGHEZZA_CELLE * 9) + 1 To LARGHEZZA_CELLE * 10
               CordinataX = LARGHEZZA_CELLE * 9
               IntestazioneRisorsa = Risorsa(10).Tag
               IndiceRisorsa = 10

            Case (LARGHEZZA_CELLE * 10) + 1 To LARGHEZZA_CELLE * 11
               CordinataX = LARGHEZZA_CELLE * 10
               IntestazioneRisorsa = Risorsa(11).Tag
               IndiceRisorsa = 11

            Case (LARGHEZZA_CELLE * 11) + 1 To LARGHEZZA_CELLE * 12
               CordinataX = LARGHEZZA_CELLE * 11
               IntestazioneRisorsa = Risorsa(12).Tag
               IndiceRisorsa = 12

            Case (LARGHEZZA_CELLE * 12) + 1 To LARGHEZZA_CELLE * 13
               CordinataX = LARGHEZZA_CELLE * 12
               IntestazioneRisorsa = Risorsa(13).Tag
               IndiceRisorsa = 13

            Case (LARGHEZZA_CELLE * 13) + 1 To LARGHEZZA_CELLE * 14
               CordinataX = LARGHEZZA_CELLE * 13
               IntestazioneRisorsa = Risorsa(14).Tag
               IndiceRisorsa = 14

            Case (LARGHEZZA_CELLE * 14) + 1 To LARGHEZZA_CELLE * 15
               CordinataX = LARGHEZZA_CELLE * 14
               IntestazioneRisorsa = Risorsa(15).Tag
               IndiceRisorsa = 15

            Case (LARGHEZZA_CELLE * 15) + 1 To LARGHEZZA_CELLE * 16
               CordinataX = LARGHEZZA_CELLE * 15
               IntestazioneRisorsa = Risorsa(16).Tag
               IndiceRisorsa = 16

            Case (LARGHEZZA_CELLE * 16) + 1 To LARGHEZZA_CELLE * 17
               CordinataX = LARGHEZZA_CELLE * 16
               IntestazioneRisorsa = Risorsa(17).Tag
               IndiceRisorsa = 17

            Case (LARGHEZZA_CELLE * 17) + 1 To LARGHEZZA_CELLE * 18
               CordinataX = LARGHEZZA_CELLE * 17
               IntestazioneRisorsa = Risorsa(18).Tag
               IndiceRisorsa = 18

            Case (LARGHEZZA_CELLE * 18) + 1 To LARGHEZZA_CELLE * 19
               CordinataX = LARGHEZZA_CELLE * 18
               IntestazioneRisorsa = Risorsa(19).Tag
               IndiceRisorsa = 19

            Case (LARGHEZZA_CELLE * 19) + 1 To LARGHEZZA_CELLE * 20
               CordinataX = LARGHEZZA_CELLE * 19
               IntestazioneRisorsa = Risorsa(20).Tag
               IndiceRisorsa = 20

            Case (LARGHEZZA_CELLE * 20) + 1 To LARGHEZZA_CELLE * 21
               CordinataX = LARGHEZZA_CELLE * 20
               IntestazioneRisorsa = Risorsa(21).Tag
               IndiceRisorsa = 21

            Case (LARGHEZZA_CELLE * 21) + 1 To LARGHEZZA_CELLE * 22
               CordinataX = LARGHEZZA_CELLE * 21
               IntestazioneRisorsa = Risorsa(22).Tag
               IndiceRisorsa = 22

            Case (LARGHEZZA_CELLE * 22) + 1 To LARGHEZZA_CELLE * 23
               CordinataX = LARGHEZZA_CELLE * 22
               IntestazioneRisorsa = Risorsa(23).Tag
               IndiceRisorsa = 23

            Case (LARGHEZZA_CELLE * 23) + 1 To LARGHEZZA_CELLE * 24
               CordinataX = LARGHEZZA_CELLE * 23
               IntestazioneRisorsa = Risorsa(24).Tag
               IndiceRisorsa = 24

            Case (LARGHEZZA_CELLE * 24) + 1 To LARGHEZZA_CELLE * 25
               CordinataX = LARGHEZZA_CELLE * 24
               IntestazioneRisorsa = Risorsa(25).Tag
               IndiceRisorsa = 25

            Case Else
               CordinataX = 0
               IntestazioneRisorsa = Risorsa(1).Tag
               IndiceRisorsa = 1

         End Select

         ' Salva l'ultima posizione in cordinata X del cursore.
         ultimaCordX = CordinataX

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function CordinataY(ByVal y As Integer) As Integer
      Try
         Select Case y
            Case 0 To ALTEZZA_CELLE
               CordinataY = 0
               IntestazioneOra = Ora(1)

            Case ALTEZZA_CELLE + 1 To ALTEZZA_CELLE * 2
               CordinataY = ALTEZZA_CELLE
               IntestazioneOra = Ora(2)

            Case (ALTEZZA_CELLE * 2) + 1 To ALTEZZA_CELLE * 3
               CordinataY = ALTEZZA_CELLE * 2
               IntestazioneOra = Ora(3)

            Case (ALTEZZA_CELLE * 3) + 1 To ALTEZZA_CELLE * 4
               CordinataY = ALTEZZA_CELLE * 3
               IntestazioneOra = Ora(4)

            Case (ALTEZZA_CELLE * 4) + 1 To ALTEZZA_CELLE * 5
               CordinataY = ALTEZZA_CELLE * 4
               IntestazioneOra = Ora(5)

            Case (ALTEZZA_CELLE * 5) + 1 To ALTEZZA_CELLE * 6
               CordinataY = ALTEZZA_CELLE * 5
               IntestazioneOra = Ora(6)

            Case (ALTEZZA_CELLE * 6) + 1 To ALTEZZA_CELLE * 7
               CordinataY = ALTEZZA_CELLE * 6
               IntestazioneOra = Ora(7)

            Case (ALTEZZA_CELLE * 7) + 1 To ALTEZZA_CELLE * 8
               CordinataY = ALTEZZA_CELLE * 7
               IntestazioneOra = Ora(8)

            Case (ALTEZZA_CELLE * 8) + 1 To ALTEZZA_CELLE * 9
               CordinataY = ALTEZZA_CELLE * 8
               IntestazioneOra = Ora(9)

            Case (ALTEZZA_CELLE * 9) + 1 To ALTEZZA_CELLE * 10
               CordinataY = ALTEZZA_CELLE * 9
               IntestazioneOra = Ora(10)

            Case (ALTEZZA_CELLE * 10) + 1 To ALTEZZA_CELLE * 11
               CordinataY = ALTEZZA_CELLE * 10
               IntestazioneOra = Ora(11)

            Case (ALTEZZA_CELLE * 11) + 1 To ALTEZZA_CELLE * 12
               CordinataY = ALTEZZA_CELLE * 11
               IntestazioneOra = Ora(12)

            Case (ALTEZZA_CELLE * 12) + 1 To ALTEZZA_CELLE * 13
               CordinataY = ALTEZZA_CELLE * 12
               IntestazioneOra = Ora(13)

            Case (ALTEZZA_CELLE * 13) + 1 To ALTEZZA_CELLE * 14
               CordinataY = ALTEZZA_CELLE * 13
               IntestazioneOra = Ora(14)

            Case (ALTEZZA_CELLE * 14) + 1 To ALTEZZA_CELLE * 15
               CordinataY = ALTEZZA_CELLE * 14
               IntestazioneOra = Ora(15)

            Case (ALTEZZA_CELLE * 15) + 1 To ALTEZZA_CELLE * 16
               CordinataY = ALTEZZA_CELLE * 15
               IntestazioneOra = Ora(16)

            Case (ALTEZZA_CELLE * 16) + 1 To ALTEZZA_CELLE * 17
               CordinataY = ALTEZZA_CELLE * 16
               IntestazioneOra = Ora(17)

            Case (ALTEZZA_CELLE * 17) + 1 To ALTEZZA_CELLE * 18
               CordinataY = ALTEZZA_CELLE * 17
               IntestazioneOra = Ora(18)

            Case (ALTEZZA_CELLE * 18) + 1 To ALTEZZA_CELLE * 19
               CordinataY = ALTEZZA_CELLE * 18
               IntestazioneOra = Ora(19)

            Case (ALTEZZA_CELLE * 19) + 1 To ALTEZZA_CELLE * 20
               CordinataY = ALTEZZA_CELLE * 19
               IntestazioneOra = Ora(20)

            Case (ALTEZZA_CELLE * 20) + 1 To ALTEZZA_CELLE * 21
               CordinataY = ALTEZZA_CELLE * 20
               IntestazioneOra = Ora(21)

            Case (ALTEZZA_CELLE * 21) + 1 To ALTEZZA_CELLE * 22
               CordinataY = ALTEZZA_CELLE * 21
               IntestazioneOra = Ora(22)

            Case (ALTEZZA_CELLE * 22) + 1 To ALTEZZA_CELLE * 23
               CordinataY = ALTEZZA_CELLE * 22
               IntestazioneOra = Ora(23)

            Case (ALTEZZA_CELLE * 23) + 1 To ALTEZZA_CELLE * 24
               CordinataY = ALTEZZA_CELLE * 23
               IntestazioneOra = Ora(24)

            Case (ALTEZZA_CELLE * 24) + 1 To ALTEZZA_CELLE * 25
               CordinataY = ALTEZZA_CELLE * 24
               IntestazioneOra = Ora(25)

            Case (ALTEZZA_CELLE * 25) + 1 To ALTEZZA_CELLE * 26
               CordinataY = ALTEZZA_CELLE * 25
               IntestazioneOra = Ora(26)

            Case (ALTEZZA_CELLE * 26) + 1 To ALTEZZA_CELLE * 27
               CordinataY = ALTEZZA_CELLE * 26
               IntestazioneOra = Ora(27)

            Case (ALTEZZA_CELLE * 27) + 1 To ALTEZZA_CELLE * 28
               CordinataY = ALTEZZA_CELLE * 27
               IntestazioneOra = Ora(28)

            Case (ALTEZZA_CELLE * 28) + 1 To ALTEZZA_CELLE * 29
               CordinataY = ALTEZZA_CELLE * 28
               IntestazioneOra = Ora(29)

            Case (ALTEZZA_CELLE * 29) + 1 To ALTEZZA_CELLE * 30
               CordinataY = ALTEZZA_CELLE * 29
               IntestazioneOra = Ora(30)

            Case (ALTEZZA_CELLE * 30) + 1 To ALTEZZA_CELLE * 31
               CordinataY = ALTEZZA_CELLE * 30
               IntestazioneOra = Ora(31)

            Case (ALTEZZA_CELLE * 31) + 1 To ALTEZZA_CELLE * 32
               CordinataY = ALTEZZA_CELLE * 31
               IntestazioneOra = Ora(32)

            Case Else
               CordinataY = 0
               IntestazioneOra = Ora(1)

         End Select

         ' Salva l'ultima posizione in cordinata Y del cursore.
         ultimaCordY = CordinataY

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub InizializzaControlli()
      Try
         dtpData.Enabled = True
         Larghezza.Enabled = True
         ckbVisCosto.Enabled = True
         Griglia.Enabled = True

         ' Imposta le dimensioni dei controlli.
         Griglia.Width = LARGHEZZA_GRIGLIA
         Griglia.Height = ALTEZZA_GRIGLIA_MAX

         Ore.Height = ALTEZZA_GRIGLIA_MAX
         Ore.Top = POS_ORE

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub VisualizzaIntestazione(ByVal val As String)
      Try
         ' Risorsa - ora.
         lblRisorsaOra.Text = " RISORSA: " & IntestazioneRisorsa.ToUpper & " - ORE: " & IntestazioneOra & " "

         ' Prenotazione.
         If val = "" Then
            lblDettagliPren.Text = "[Nessuna prenotazione]"
         ElseIf val = VALORE_NESSUNA Then
            lblDettagliPren.Text = "[Nessuna selezione]"
         Else
            lblDettagliPren.Text = val
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub PosizionaCursore(ByVal x As Integer, ByVal y As Integer)
      Try
         ' Posiziona il cursore nella cella selezionata con il mouse.
         Cursore(0).Location = New Point(CordinataX(x), CordinataY(y))
         Cursore(0).Visible = True
         Cursore(0).Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      Try
         ' Imposta le dimensioni standard del form.
         Me.Width = larghezza
         Me.Height = altezza

         HScrollBar1.Maximum = LARGHEZZA_GRIGLIA_MAX - HScrollBar1.Width
         HScrollBar1.Minimum = 0
         HScrollBar1.SmallChange = LARGHEZZA_CELLE
         HScrollBar1.LargeChange = LARGHEZZA_CELLE * 2

         VScrollBar1.Maximum = ALTEZZA_GRIGLIA_MAX - VScrollBar1.Height
         VScrollBar1.Minimum = 0
         VScrollBar1.SmallChange = ALTEZZA_CELLE
         VScrollBar1.LargeChange = ALTEZZA_CELLE * 3

         If LARGHEZZA_GRIGLIA >= Me.HScrollBar1.Width Then
            VScrollBar1.Maximum = ALTEZZA_GRIGLIA_MAX - VScrollBar1.Height + VS_BAR_MAX
            HScrollBar1.Visible = True
            Panel6.Visible = True
         Else
            HScrollBar1.Visible = False
            Panel6.Visible = False
            Risorse.Left = 0
            Griglia.Left = 0
         End If

         If ALTEZZA_GRIGLIA >= Me.VScrollBar1.Height Then
            HScrollBar1.Maximum = LARGHEZZA_GRIGLIA_MAX - HScrollBar1.Width + HS_BAR_MAX
            VScrollBar1.Visible = True
         Else
            VScrollBar1.Visible = False
            Ore.Top = POS_ORE
            Griglia.Top = POS_GRIGLIA
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CaricaPrenotazioni(ByVal curVisibile As Boolean)
      Try
         Dim DataAttuale As String

         ' Formato italiano.
         DataAttuale = FormattaData(dtpData.Value, False)

         EliminaTuttePrenotazioni()

         DisegnaCursore(ultimaCordX, ultimaCordY)

         LeggiIdRisorse("Risorse", DataAttuale)

         Cursore(0).Visible = curVisibile

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColore(ByVal lbl As Label)
      Try
         With ColorDialog1()
            .Color = lbl.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               ' Modifica il colore per la tabella StatoPrenotazioni.
               ModificaDati(TAB_STATO_PREN, lbl.Text, Convert.ToString(.Color.ToArgb))

               ' Modifica il colore delle Prenotazioni con un valore uguale per il campo Stato.
               ModificaDatiPren(TAB_PRENOTAZIONE, lbl.Text, Convert.ToString(.Color.ToArgb))

               ' Carica nuovamente le Prenotazioni per impostare i nuovi colori assegnati al campo Stato.
               CaricaPrenotazioni(Cursore(0).Visible)

               ' Cambia il colore nella legenda.
               lbl.BackColor = .Color
            End If

         End With

         If ControlIndex > 0 Then
            Prenotazione(ControlIndex).Focus()
         Else
            ImpostaComandiTB()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaColoriLegenda()
      Try
         ' B_TODO: VERSIONE FUTURA.
         'lblInCorso.BackColor = Color.FromArgb(AssegnaColore(lblInCorso.Text, TAB_STATO_PREN))
         'lblScaduta.BackColor = Color.FromArgb(AssegnaColore(lblScaduta.Text, TAB_STATO_PREN))
         lblConfermata.BackColor = Color.FromArgb(AssegnaColore(lblConfermata.Text, TAB_STATO_PREN))
         lblSospesa.BackColor = Color.FromArgb(AssegnaColore(lblSospesa.Text, TAB_STATO_PREN))
         lblNostraCanc.BackColor = Color.FromArgb(AssegnaColore(lblNostraCanc.Text, TAB_STATO_PREN))
         lblVostraCanc.BackColor = Color.FromArgb(AssegnaColore(lblVostraCanc.Text, TAB_STATO_PREN))
         lblAbbonamento1.BackColor = Color.FromArgb(AssegnaColore(lblAbbonamento1.Text, TAB_STATO_PREN))
         lblAbbonamento2.BackColor = Color.FromArgb(AssegnaColore(lblAbbonamento2.Text, TAB_STATO_PREN))
         lblAbbonamento3.BackColor = Color.FromArgb(AssegnaColore(lblAbbonamento3.Text, TAB_STATO_PREN))
         lblTorneo.BackColor = Color.FromArgb(AssegnaColore(lblTorneo.Text, TAB_STATO_PREN))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ApriDati(ByVal Tag As String, Optional ByVal data As String = "", Optional ByVal pRisorsa As String = "", Optional ByVal pOra As String = "")
      Try
         ' Per la versione demo.
         If g_VerDemo = True Then
            ' Test per la versione demo.
            If VerificaNumRecord(LeggiNumRecord(TAB_PRENOTAZIONE)) = True Then
               Exit Sub
            End If
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         g_frmDatiPrenRisorse = New frmPrenRisorse(data, pRisorsa, pOra)
         g_frmDatiPrenRisorse.Tag = Tag
         g_frmDatiPrenRisorse.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ApriDatiRisorse(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim frm As New frmRisorse
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim Descrizione As String = "(Prenotazione N° " & lblDettagliPren.Text & " - " & lblRisorsaOra.Text & ")"

         Dim Cliente As String = ActiveControl.Text.Replace(vbNewLine, " - ")

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare la prenotazione del cliente """ & Cliente & _
                           """?" & vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            ' Elimina i dati della prenotazione per le statistiche.
            '-------------------------------------------------------------------------------
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM StatisticheGioco WHERE Codice = '{0}'", id.ToString)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
            '-------------------------------------------------------------------------------

            ' Elimina i dati del conto per la prenotazione.
            '-------------------------------------------------------------------------------
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM PrenRisorseConto WHERE RifPren = {0}", id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete2 As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record2 As Integer = cmdDelete2.ExecuteNonQuery()
            '-------------------------------------------------------------------------------

            ' Conferma la transazione.
            tr.Commit()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, Descrizione, MODULO_GESTIONE_PLANNING_RISORSE)
         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         If IsNothing(g_frmPren) = False Then
            ' Aggiorna la griglia dati.
            g_frmPren.AggiornaDati()
         End If

      End Try
   End Sub

   Public Sub ModificaDati(ByVal tabella As String, ByVal Descrizione As String, ByVal Colore As String)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Colore = '{1}' WHERE Descrizione = '{2}' ", tabella, Colore, Descrizione)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Public Sub ModificaDatiPren(ByVal tabella As String, ByVal stato As String, ByVal colore As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Colore = '{1}' WHERE stato = '{2}' ", tabella, colore, stato)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub ImpostaComandiTB()
      tbbNuovo.Enabled = True
      tbbModifica.Enabled = False
      tbbElimina.Enabled = False
      tbbProprietà.Enabled = False
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.PlanningRisorse) = True Then
         ImpostaComandiTB()
      End If
   End Sub

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

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo
   End Sub

   Private Sub frmPlanningP_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub frmPlanningP_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmPlanningSport1)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmPlanningSport1.Dispose()
               g_frmPlanningSport1 = Nothing

            Case TipoPlanning.Planning2
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmPlanningSport2)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmPlanningSport2.Dispose()
               g_frmPlanningSport2 = Nothing

            Case TipoPlanning.Planning3
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmPlanningSport3)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmPlanningSport3.Dispose()
               g_frmPlanningSport3 = Nothing

            Case TipoPlanning.Planning4
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmPlanningSport4)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmPlanningSport4.Dispose()
               g_frmPlanningSport4 = Nothing

         End Select

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_GESTIONE_PLANNING_RISORSE, MODULO_GESTIONE_PLANNING_RISORSE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmPlanningP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If LeggiDatiRisorse(ANAG_RISORSE, nomePlanning) = False Then
            Exit Sub
         End If

         ' Imposta le dimensioni dei controlli.
         InizializzaControlli()

         ' Richiama le procedure grafiche per il disegno del planning.
         DisegnaPlanning()

         DisegnaCursore(0, 0)

         CaricaColoriLegenda()

         CaricaPrenotazioni(False)

         LeggiDatiConfig()

         FormResize(Me.Width, Me.Height)

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TitoloFinestra)

         ' Visualizza dati informativi.
         VisualizzaIntestazione(VALORE_NESSUNA)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_GESTIONE_PLANNING_RISORSE, MODULO_GESTIONE_PLANNING_RISORSE)

         Griglia.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmPlanningP_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      FormResize(Me.Width, Me.Height)
   End Sub

   Private Sub HScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
      Try
         HScrollBar1.Maximum = LARGHEZZA_GRIGLIA_MAX - HScrollBar1.Width + HS_BAR_MAX

         If Me.HScrollBar1.Visible = True Then
            Risorse.Location = New Point(-HScrollBar1.Value, Risorse.Location.Y)
            Griglia.Location = New Point(-HScrollBar1.Value, Griglia.Location.Y)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub HScrollBar1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.VisibleChanged
      Try
         If HScrollBar1.Visible = True Then
            ' Riduci dimensioni.
            If HBarVisibile = True Then
               VScrollBar1.Height = VScrollBar1.Height - 18
               Panel1.Height = Panel1.Height - 18
            Else
               HBarVisibile = True
            End If
         Else
            ' Aumenta dimensioni.
            VScrollBar1.Height = VScrollBar1.Height + 18
            Panel1.Height = Panel1.Height + 18
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub VScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
      Try
         VScrollBar1.Maximum = ALTEZZA_GRIGLIA_MAX - VScrollBar1.Height + VS_BAR_MAX

         If Me.VScrollBar1.Visible = True Then
            Ore.Location = New Point(Ore.Location.X, -VScrollBar1.Value + POS_ORE)
            Griglia.Location = New Point(Griglia.Location.X, -VScrollBar1.Value + POS_GRIGLIA)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub VScrollBar1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBar1.VisibleChanged
      Try
         If VScrollBar1.Visible = True Then
            ' Riduci dimensioni.
            If VBarVisibile = True Then
               HScrollBar1.Width = HScrollBar1.Width - 18
               Panel1.Width = Panel1.Width - 18
            Else
               VBarVisibile = True
            End If
         Else
            ' Aumenta dimensioni.
            HScrollBar1.Width = HScrollBar1.Width + 18
            Panel1.Width = Panel1.Width + 18
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Griglia_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Griglia.Paint
      DisegnaPlanning()
   End Sub

   Private Sub Griglia_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Griglia.MouseDown
      Try
         ' Posiziona il cursore nella cella selezionata con il mouse.
         PosizionaCursore(e.X, e.Y)

         ' Visualizza dati informativi.
         VisualizzaIntestazione("")

         ImpostaComandiTB()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Ore_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Ore.Paint
      DisegnaPlanning()
   End Sub

   Private Sub Prenotazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Salva l'indice del controllo selezionato.
         ControlIndex = Griglia.Controls.IndexOf(CType(sender, Button))

         PosizionaCursore(CType(sender, Button).Location.X, CType(sender, Button).Location.Y)
         Cursore(0).Visible = False

         CType(sender, Button).Focus()

         ' Apre la finestra per l'inserimento di nuovi dati.
         'ApriDati(ActiveControl.Name, String.Empty, Risorsa(IndiceRisorsa).Tag, String.Empty)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Prenotazione_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         ' NON FUNZIONA ! - NON VIENE RILEVATO L'EVENTO...

         ' Salva l'indice del controllo selezionato.
         ControlIndex = Griglia.Controls.IndexOf(CType(sender, Button))

         PosizionaCursore(CType(sender, Button).Location.X, CType(sender, Button).Location.Y)
         Cursore(0).Visible = False

         CType(sender, Button).Focus()

         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati(ActiveControl.Name, String.Empty, Risorsa(IndiceRisorsa).Tag, String.Empty)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Prenotazione_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         Dim str As String = CType(sender, Button).Text.Replace(vbNewLine, "*")

         Dim stringa() As String = str.Split("*")

         ' A_TODO: MODIFICHE ASD AGON
         VisualizzaIntestazione(stringa(0).ToUpper & " - " & stringa(1).ToUpper & "  " & CType(sender, Button).Tag)

         tbbNuovo.Enabled = False
         tbbModifica.Enabled = True
         tbbElimina.Enabled = True
         tbbProprietà.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Risorsa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         tbbNuovo.Enabled = False
         tbbModifica.Enabled = False
         tbbElimina.Enabled = False
         tbbProprietà.Enabled = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ToolBar2_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar2.ButtonClick
      Try
         Select Case e.Button.Tag
            Case "Nuovo"
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_GESTIONE_PLANNING_RISORSE, MODULO_GESTIONE_PLANNING_RISORSE)

               ' Apre la finestra per l'inserimento di nuovi dati.
               ApriDati("", dtpData.Text, IntestazioneRisorsa, IntestazioneOra)

               Do
                  ControlIndex += 1
                  If IsNothing(Prenotazione(ControlIndex)) = True Then
                     Exit Sub
                  End If
               Loop Until Prenotazione(ControlIndex).Location.X = Cursore(0).Location.X + 2 And Prenotazione(ControlIndex).Location.Y = Cursore(0).Location.Y + 2

               Prenotazione(ControlIndex).Focus()

               'lblCursore.Visible = False

            Case "Modifica"
               ' Registra loperazione efettuata dall'operatore identificato.
               registraModifica()

               ' Apre la finestra per l'inserimento di nuovi dati.
               ApriDati(ActiveControl.Name, , IntestazioneRisorsa)

               Prenotazione(ControlIndex).Focus()

            Case "Elimina"
               ' Elimina i dati dall'archivio
               EliminaDati(TAB_PRENOTAZIONE, CInt(ActiveControl.Name))

               ' Elimina il controllo dal planning.
               EliminaPrenotazione(ControlIndex)

               CaricaPrenotazioni(True)

               ' Visualizza dati informativi.
               VisualizzaIntestazione("")

               ImpostaComandiTB()

            Case "Proprietà"
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.ProprietàRisorsa, STR_GESTIONE_PLANNING_RISORSE, MODULO_GESTIONE_PLANNING_RISORSE)

               ' Apre la finestra per l'inserimento di nuovi dati.
               ApriDatiRisorse(ActiveControl.Name)

            Case "Stampa"

            Case "Anteprima"

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Larghezza_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Larghezza.SelectedIndexChanged
      Dim cursoreVisibile As Boolean
      cursoreVisibile = Cursore(0).Visible

      RidimensionaRigheColonne()

      RidimensionaRisorse()

      ' Imposta le dimensioni dei controlli.
      InizializzaControlli()

      DisegnaPlanning()

      FormResize(Me.Width, Me.Height)

      EliminaTuttePrenotazioni()

      CaricaPrenotazioni(Cursore(0).Visible)

      ' Posiziona il cursore nella cella selezionata con il mouse.
      PosizionaCursore(Risorsa(IndiceRisorsa).Location.X, Cursore(0).Location.Y + 1)

      Cursore(0).Visible = cursoreVisibile

      If cursoreVisibile = False Then
         If ControlIndex <> 0 Then
            Prenotazione(ControlIndex).Focus()
         End If
      End If
   End Sub

   Private Sub Altezza_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Altezza.SelectedIndexChanged
      ' B_TODO: CODICE DA INSERIRE PER GESTIRE L'ALTEZZA DELLE RIGHE.
      'RidimensionaRigheColonne()

      '' Imposta le dimensioni dei controlli.
      'InizializzaControlli()

      'DisegnaPlanning()

      'FormResize(Me.Width, Me.Height)
   End Sub

   Private Sub dtpData_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpData.ValueChanged
      CaricaPrenotazioni(False)
   End Sub

   Private Sub lblConfermata_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblConfermata.DoubleClick
      ModificaColore(sender)
   End Sub

   Private Sub lblNostraCanc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNostraCanc.DoubleClick
      ModificaColore(sender)
   End Sub

   Private Sub lblSospesa_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSospesa.DoubleClick
      ModificaColore(sender)
   End Sub

   Private Sub lblVostraCanc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblVostraCanc.DoubleClick
      ModificaColore(sender)
   End Sub

   Private Sub lblAbbonamento1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAbbonamento1.DoubleClick
      ModificaColore(sender)
   End Sub

   Private Sub lblAbbonamento2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAbbonamento2.DoubleClick
      ModificaColore(sender)
   End Sub

   Private Sub lblAbbonamento3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAbbonamento3.DoubleClick
      ModificaColore(sender)
   End Sub

   Private Sub lblTorneo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTorneo.DoubleClick
      ModificaColore(sender)

   End Sub

   Private Sub ckbVisCosto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbVisCosto.CheckedChanged
      ' Elimina le risorse presenti.
      NumRisorse = 0
      Risorse.Controls.Clear()

      ' Carica nuovamente le risorse per aggiornare i dati.
      LeggiDatiRisorse(ANAG_RISORSE, nomePlanning)

   End Sub
End Class
