#Region " DATI FILE.VB "

' **************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 28/06/2021
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.
' Note:
'
' Elenco Attivita:
'
' **************************************************************************************

#End Region

Option Strict Off
Option Explicit On

Imports System.Data.OleDb

Public Class frmElencoDati
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Public Const TAB_CLIENTI = "Clienti"
   Public Const TAB_AZIENDE = "Aziende"
   Public Const TAB_FORNITORI = "Fornitori"
   Public Const TAB_ARTICOLI = "Articoli"
   Public Const TAB_CAT_PIATTI = "CategoriePiatti"
   Public Const TAB_PREN = "Prenotazioni"
   Public Const TAB_PREN_SALE = "PrenSale"
   Public Const TAB_CAMERIERI = "Camerieri"
   Public Const TAB_AGENZIE_CAMERIERI = "AgenzieCamerieri"
   Public Const TAB_SALE = "Sale"
   Public Const TAB_TAVOLI = "Tavoli"
   Public Const TAB_CAMERE = "Camere"
   Public Const TAB_STATO_PREN = "StatoPren"
   Public Const TAB_STATO_NOLEGGI = "StatoNoleggi"
   Public Const TAB_OPERATORI = "Operatori"
   Public Const TAB_GRUPPI = "Gruppi"
   Public Const TAB_CARATT_RISORSE = "CaratteristicheRisorse"
   Public Const TAB_SCONTI_MAGGIORAZIONI = "ScontiMaggiorazioni"

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
   Public repSql As String

   Private DatiConfig As AppConfig
   Private strDescrizione As String
   Friend WithEvents eui_txtTestoRicerca As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbCampoRicerca As Elegant.Ui.ComboBox
   Friend WithEvents DataGridView1 As DataGridView
   Friend WithEvents lblIntestazione As Label
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
            TitoloFinestra = "Elenco Categorie piatti"

         Case Elenco.Prenotazioni
            TipoElenco = Elenco.Prenotazioni
            NomeTabella = "Prenotazioni"
            TitoloFinestra = "Elenco prenotazioni Tavoli"

         Case Elenco.PrenSale
            TipoElenco = Elenco.PrenSale
            NomeTabella = "PrenSale"
            TitoloFinestra = "Elenco prenotazioni Sale"

         Case Elenco.Camerieri
            TipoElenco = Elenco.Camerieri
            NomeTabella = "Camerieri"
            TitoloFinestra = "Elenco " & DenominazioneCamerieri

         Case Elenco.AgenzieCamerieri
            TipoElenco = Elenco.AgenzieCamerieri
            NomeTabella = "AgenzieCamerieri"
            TitoloFinestra = "Elenco Agenzie " & DenominazioneCamerieri

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

         Case Elenco.StatoNoleggi
            TipoElenco = Elenco.StatoNoleggi
            NomeTabella = "StatoNoleggi"
            TitoloFinestra = "Elenco Stato noleggio"

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

         Case Elenco.ScontiMaggiorazioni
            TipoElenco = Elenco.ScontiMaggiorazioni
            NomeTabella = "ScontiMaggiorazioni"
            TitoloFinestra = "Elenco Sconti e Maggiorazioni"

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
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoDati))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.eui_cmbCampoRicerca = New Elegant.Ui.ComboBox()
      Me.eui_txtTestoRicerca = New Elegant.Ui.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.Panel1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
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
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Controls.Add(Me.eui_cmbCampoRicerca)
      Me.Panel1.Controls.Add(Me.eui_txtTestoRicerca)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(760, 63)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.Color.White
      Me.lblIntestazione.Location = New System.Drawing.Point(2, 38)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(182, 16)
      Me.lblIntestazione.TabIndex = 9
      Me.lblIntestazione.Text = "INTESTAZIONE ELENCO"
      '
      'eui_cmbCampoRicerca
      '
      Me.eui_cmbCampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbCampoRicerca.FormattingEnabled = False
      Me.eui_cmbCampoRicerca.Id = "d43a4748-fb7c-4a92-b314-e99dd371f091"
      Me.eui_cmbCampoRicerca.Location = New System.Drawing.Point(619, 8)
      Me.eui_cmbCampoRicerca.Name = "eui_cmbCampoRicerca"
      Me.eui_cmbCampoRicerca.Size = New System.Drawing.Size(131, 21)
      Me.eui_cmbCampoRicerca.TabIndex = 1
      Me.eui_cmbCampoRicerca.TextEditorWidth = 112
      '
      'eui_txtTestoRicerca
      '
      Me.eui_txtTestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTestoRicerca.Id = "d11254da-9c61-45ed-96c7-2e47ad041e41"
      Me.eui_txtTestoRicerca.Location = New System.Drawing.Point(116, 8)
      Me.eui_txtTestoRicerca.Name = "eui_txtTestoRicerca"
      Me.eui_txtTestoRicerca.Size = New System.Drawing.Size(410, 21)
      Me.eui_txtTestoRicerca.TabIndex = 0
      Me.eui_txtTestoRicerca.TextEditorWidth = 268
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(530, 8)
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
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.GridColor = System.Drawing.Color.LightGray
      Me.DataGridView1.Location = New System.Drawing.Point(2, 65)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.Size = New System.Drawing.Size(756, 342)
      Me.DataGridView1.TabIndex = 0
      '
      'frmElencoDati
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(760, 409)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGridView1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmElencoDati"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

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

            Case Elenco.AgenzieCamerieri
               If DatiConfig.GetValue("WSAgenzieCamerieri") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSAgenzieCamerieri") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AAgenzieCamerieri") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AAgenzieCamerieri"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LAgenzieCamerieri") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LAgenzieCamerieri"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("AgenzieCamerieriX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("AgenzieCamerieriX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("AgenzieCamerieriY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("AgenzieCamerieriY")))
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

            Case Elenco.StatoNoleggi
               If DatiConfig.GetValue("WSStatoNoleggi") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSStatoNoleggi") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AStatoNoleggi") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AStatoNoleggi"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LStatoNoleggi") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LStatoNoleggi"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("StatoNoleggiX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("StatoNoleggiX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("StatoNoleggiY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("StatoNoleggiY")))
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

            Case Elenco.ScontiMaggiorazioni
               If DatiConfig.GetValue("WSScontiMaggiorazioni") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSScontiMaggiorazioni") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AScontiMaggiorazioni") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AScontiMaggiorazioni"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LScontiMaggiorazioni") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LScontiMaggiorazioni"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("ScontiMaggiorazioniX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("ScontiMaggiorazioniX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("ScontiMaggiorazioniY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("ScontiMaggiorazioniY")))
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

            Case Elenco.AgenzieCamerieri
               DatiConfig.SetValue("WSAgenzieCamerieri", Me.WindowState)
               DatiConfig.SetValue("AgenzieCamerieriX", Me.Location.X)
               DatiConfig.SetValue("AgenzieCamerieriY", Me.Location.Y)
               DatiConfig.SetValue("AAgenzieCamerieri", Me.Height)
               DatiConfig.SetValue("LAgenzieCamerieri", Me.Width)

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

            Case Elenco.StatoNoleggi
               DatiConfig.SetValue("WSStatoNoleggi", Me.WindowState)
               DatiConfig.SetValue("StatoNoleggiX", Me.Location.X)
               DatiConfig.SetValue("StatoNoleggiY", Me.Location.Y)
               DatiConfig.SetValue("AStatoNoleggi", Me.Height)
               DatiConfig.SetValue("LStatoNoleggi", Me.Width)

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

            Case Elenco.ScontiMaggiorazioni
               DatiConfig.SetValue("WSScontiMaggiorazioni", Me.WindowState)
               DatiConfig.SetValue("ScontiMaggiorazioniX", Me.Location.X)
               DatiConfig.SetValue("ScontiMaggiorazioniY", Me.Location.Y)
               DatiConfig.SetValue("AScontiMaggiorazioni", Me.Height)
               DatiConfig.SetValue("LScontiMaggiorazioni", Me.Width)

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
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Camerieri
               If operatore.AnagCamerieri = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.AgenzieCamerieri
               If operatore.AnagAgenzieCamerieri = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.CatPiatti
               If operatore.AnagCatPiatti = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Clienti
               If operatore.AnagClienti = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Fornitori
               If operatore.AnagFornitori = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Sale
               If operatore.AnagSale = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Tavoli
               If operatore.AnagTavoli = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Camere
               If operatore.AnagCamere = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.StatoPren
               If operatore.TabStatoPren = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.StatoNoleggi
               If operatore.TabStatoNoleggi = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Articoli
               If operatore.MagArticoli = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
                  g_frmMain.eui_Strumenti_Magazzino_Carico.Enabled = False
                  g_frmMain.eui_Strumenti_Magazzino_Scarico.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
                  g_frmMain.eui_Strumenti_Magazzino_Carico.Enabled = True
                  g_frmMain.eui_Strumenti_Magazzino_Scarico.Enabled = True
               End If

            Case Finestra.PrenTavoli
               If operatore.GestPrenTavoli = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.PrenSale
               If operatore.GestPrenSale = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Operatori
               If operatore.GestOperatori = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

            Case Finestra.Gruppi
               If operatore.GestGruppi = VALORE_LETTURA Then
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
               End If

               ' A_TODO: Inserire qui il codice per gestire la finestra Caratteristiche Risorse.
         End Select

         Return g_frmMain.eui_Strumenti_Nuovo.Enabled

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
               Dim Cognome As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               Dim Nome As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & Cognome & " " & Nome & ")"

            Case Elenco.Aziende
               ' Registra l'operazione.
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & ragSoc & ")"

            Case Elenco.Fornitori
               ' Registra l'operazione.
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & ragSoc & ")"

            Case Elenco.Prenotazioni, Elenco.PrenSale
               ' Registra l'operazione.
               Dim Cliente As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & Cliente & ")"

            Case Elenco.CatPiatti
               ' Registra l'operazione.
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Camerieri
               ' Registra l'operazione.
               Dim Nome As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & Nome & ")"

            Case Elenco.AgenzieCamerieri
               ' Registra l'operazione.
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & ragSoc & ")"

            Case Elenco.Sale
               ' Registra l'operazione.
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Tavoli
               ' Registra l'operazione.
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Camere
               ' Registra l'operazione.
               Dim numero As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               Dim descrizione As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & numero & " - " & descrizione & ")"

            Case Elenco.StatoPren
               ' Registra l'operazione.
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.StatoNoleggi
               ' Registra l'operazione.
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & descrizione & ")"

            Case Elenco.Articoli
               ' Registra l'operazione.
               Dim codice As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               Dim descrizione As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & codice & " - " & descrizione & ")"

            Case Elenco.Operatori
               ' Registra l'operazione.
               Dim nomeUtente As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & nomeUtente & ")"

            Case Elenco.Gruppi
               ' Registra l'operazione.
               Dim nomeGruppo As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
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

   Public Sub RegistraDuplica()
      Try
         Dim strDescrizione As String

         Select Case TipoElenco
            Case Elenco.Clienti
               ' Registra l'operazione.
               Dim Cognome As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               Dim Nome As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & Cognome & " " & Nome & ")"

            Case Elenco.Aziende
               ' Registra l'operazione.
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & ragSoc & ")"

            Case Elenco.Fornitori
               ' Registra l'operazione.
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               strDescrizione = "(" & ragSoc & ")"

               'Case Elenco.Prenotazioni, Elenco.PrenSale
               '   ' Registra l'operazione.
               '   Dim Cliente As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & Cliente & ")"

               'Case Elenco.CatPiatti
               '   ' Registra l'operazione.
               '   Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & descrizione & ")"

               'Case Elenco.Camerieri
               '   ' Registra l'operazione.
               '   Dim Nome As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & Nome & ")"

               'Case Elenco.AgenzieCamerieri
               '   ' Registra l'operazione.
               '   Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & ragSoc & ")"

               'Case Elenco.Sale
               '   ' Registra l'operazione.
               '   Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & descrizione & ")"

               'Case Elenco.Tavoli
               '   ' Registra l'operazione.
               '   Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & descrizione & ")"

               'Case Elenco.Camere
               '   ' Registra l'operazione.
               '   Dim numero As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   Dim descrizione As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & numero & " - " & descrizione & ")"

               'Case Elenco.StatoPren
               '   ' Registra l'operazione.
               '   Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & descrizione & ")"

               'Case Elenco.StatoNoleggi
               '   ' Registra l'operazione.
               '   Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & descrizione & ")"

               'Case Elenco.Articoli
               '   ' Registra l'operazione.
               '   Dim codice As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   Dim descrizione As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & codice & " - " & descrizione & ")"

               'Case Elenco.Operatori
               '   ' Registra l'operazione.
               '   Dim nomeUtente As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & nomeUtente & ")"

               'Case Elenco.Gruppi
               '   ' Registra l'operazione.
               '   Dim nomeGruppo As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               '   strDescrizione = "(" & nomeGruppo & ")"

               ' A_TODO: Inserire qui il codice per gestire la finestra Caratteristiche Risorse.

         End Select

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Duplica, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub LeggiDati(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         DataGridView1.DataSource = dt

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

         If eui_txtTestoRicerca.Text <> "" Then
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

         ' Abilita/disabilita i pulsanti. Utilizzato nelle vecchia versione.
         'tbrPrimo.Enabled = (n > 1)
         'tbrPrecedente.Enabled = (n > 1)
         'tbrSuccessivo.Enabled = (n < numPagine)
         'tbrUltimo.Enabled = (n < numPagine)

      Catch ex As Exception
         '' Si verifica quando la griglia viene aperta in modalit‡ Massima o Minima.
         'If ex.Message = "Testo del comando non impostato per l'oggetto comando." Then
         '   Exit Try
         'End If

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
               Dim Cognome As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               Dim Nome As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & Cognome & " " & Nome & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di """ & Cognome & " " & Nome &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")
            Case Elenco.Aziende
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & ragSoc & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di " & ragSoc &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati, incassare eventuali documenti Sospesi o fatturare eventuali Buoni pasto.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")
            Case Elenco.Fornitori
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & ragSoc & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di " & ragSoc &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Prenotazioni, Elenco.PrenSale
               Dim Cliente As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = " (" & DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString &
                 " - Per " & DataGridView1.Item(4, DataGridView1.CurrentCell.RowIndex).Value.ToString &
                 " il " & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString &
                 " alle " & DataGridView1.Item(5, DataGridView1.CurrentCell.RowIndex).Value.ToString &
                 " / " & DataGridView1.Item(6, DataGridView1.CurrentCell.RowIndex).Value.ToString &
                 " - " & DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value.ToString & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la prenotazione del cliente """ & Cliente &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.CatPiatti
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la Categoria """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Camerieri
               Dim Nome As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & Nome & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare il cameriere """ & Nome &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.AgenzieCamerieri
               Dim ragSoc As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & ragSoc & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare l'Agenzia """ & ragSoc &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Sale
               If IsNothing(g_frmVCTavoli) = False Then
                  ' Aggiorna Visual POS
                  MessageBox.Show("Non Ë possibile eliminare una sala perchË Visual POS Ë in esecuzione." & vbCrLf &
                                  "Si consiglia di chiudere Visual POS e ripetere l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If

               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

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

               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare il tavolo """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Camere
               Dim numero As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
               Dim descrizione As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & numero & " " & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la camera numero """ & numero & " " & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.StatoPren
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare lo stato prenotazione """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.StatoNoleggi
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare lo stato noleggio """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Articoli
               Dim descrizione As String = DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare l'articolo """ & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Operatori
               Dim nomeUtente As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & nomeUtente & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la scheda di " & nomeUtente &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Gruppi
               Dim nomeGruppo As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & nomeGruppo & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare il gruppo " & nomeGruppo &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.CaratteristicheRisorse
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la tipologia di utilizzo risorsa " & descrizione &
                                 """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.ScontiMaggiorazioni
               Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

               ' Registra l'operazione.
               strDescrizione = "(" & descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare lo Sconto / Maggiorazione '" & descrizione &
                                 "'?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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
         If eui_txtTestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGridView1.DataSource = dt

            FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(NomeTabella)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGridView1.DataSource = dt

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

         ' Strumenti di Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = False
         g_frmMain.eui_Strumenti_Elimina.Enabled = False
         g_frmMain.eui_Strumenti_Duplica.Enabled = False
         g_frmMain.eui_Strumenti_Annulla.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
         g_frmMain.eui_Strumenti_Esporta.Enabled = False
         g_frmMain.eui_Strumenti_Magazzino_Carico.Enabled = False
         g_frmMain.eui_Strumenti_Magazzino_Scarico.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False

      Else
         ' Attiva i pulsanti appropriati.

         ' Strumenti di Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = True
         g_frmMain.eui_Strumenti_Elimina.Enabled = True
         g_frmMain.eui_Strumenti_Duplica.Enabled = True
         g_frmMain.eui_Strumenti_Annulla.Enabled = True
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
         g_frmMain.eui_Strumenti_Esporta.Enabled = True
         g_frmMain.eui_Strumenti_Magazzino_Carico.Enabled = True
         g_frmMain.eui_Strumenti_Magazzino_Scarico.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True

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

         Case Elenco.AgenzieCamerieri
            If ImpostaFunzioniOperatore(Finestra.AgenzieCamerieri) = True Then
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

         Case Elenco.StatoNoleggi
            If ImpostaFunzioniOperatore(Finestra.StatoNoleggi) = True Then
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

         Case Elenco.ScontiMaggiorazioni
            ' A_TODO: Da gestire per Sconti Maggiorazioni.
            'If ImpostaFunzioniOperatore(Finestra.Gruppi) = True Then
            '   ImpostaComandi()
            'End If
      End Select

   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse. 
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

            Case Elenco.AgenzieCamerieri
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_AGENZIE_CAMERIERI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmAgenzieCamerieri
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

            Case Elenco.StatoNoleggi
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_STATO_NOLEGGI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmStatoNoleggi
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

            Case Elenco.ScontiMaggiorazioni
               ' Per la versione demo.
               ' Se Ë un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(TAB_SCONTI_MAGGIORAZIONI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

               Dim frm As New frmScontiMaggiorazioni
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
         ' Se le celle non sono ancora state caricate.
         If IsNothing(DataGridView1.CurrentCell) = True Then
            lblIntestazione.Text = "Non ci sono elementi da visualizzare nell'elenco dati."
            Exit Sub
         End If

         If numRecord <> 0 Then
            Select Case TipoElenco
               Case Elenco.Clienti
                  lblIntestazione.Text = Strings.UCase(DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value &
                                                       " " & DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value)

               Case Elenco.Aziende
                  lblIntestazione.Text = Strings.UCase(DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value)

               Case Elenco.Prenotazioni, Elenco.PrenSale
                  lblIntestazione.Text = Strings.UCase(DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value)

               Case Elenco.Articoli
                  lblIntestazione.Text = Strings.UCase(DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value &
                                                       " " & DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value)

               Case Elenco.Camere
                  lblIntestazione.Text = Strings.UCase(DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value &
                                                       " " & DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value)

               Case Elenco.Fornitori, Elenco.CatPiatti, Elenco.Camerieri, Elenco.AgenzieCamerieri, Elenco.Sale,
                    Elenco.Tavoli, Elenco.Operatori, Elenco.Gruppi, Elenco.StatoPren, Elenco.StatoNoleggi, Elenco.CaratteristicheRisorse,
                    Elenco.ScontiMaggiorazioni
                  lblIntestazione.Text = Strings.UCase(DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value)

            End Select
         Else
            lblIntestazione.Text = "Non ci sono elementi da visualizzare nell'elenco dati."
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

               Dim idUtente As String = DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString

               If idUtente = "1" Then
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
               Else
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
               End If

         End Select

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      Try
         ' Imposta il titolo della finestra.
         If TipoElenco = Elenco.Camere Then
            Dim val As Integer = SommaColonna(DataGridView1, 6, numRecord)
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

            Case Elenco.AgenzieCamerieri
               CreaColonneAgenzieCamerieri(NomeTabella)

            Case Elenco.Sale
               CreaColonneSale(NomeTabella)

            Case Elenco.Tavoli
               CreaColonneTavoli(NomeTabella)

            Case Elenco.Camere
               CreaColonneCamere(NomeTabella)

            Case Elenco.StatoPren, Elenco.StatoNoleggi
               CreaColonneStatoPren(NomeTabella)

            Case Elenco.Articoli
               CreaColonneArticoli(NomeTabella)

            Case Elenco.Operatori
               CreaColonneOperatori(NomeTabella)

            Case Elenco.Gruppi
               CreaColonneGruppi(NomeTabella)

            Case Elenco.CaratteristicheRisorse
               CreaColonneCarattRisorse(NomeTabella)

            Case Elenco.ScontiMaggiorazioni
               CreaColonneScontiMaggiorazioni(NomeTabella)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub CreaColonneFornitori(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Ragione sociale
         Dim ragSocStyle As New DataGridViewTextBoxColumn()
         With ragSocStyle
            .DataPropertyName = "RagSociale"
            .HeaderText = "Ragione sociale"
            .Name = "RagSociale"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, ragSocStyle)

         ' Indirizzo
         Dim IndirizzoStyle As New DataGridViewTextBoxColumn()
         With IndirizzoStyle
            .DataPropertyName = "Indirizzo"
            .HeaderText = "Indirizzo"
            .Name = "Indirizzo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, IndirizzoStyle)

         ' Cap
         Dim capStyle As New DataGridViewTextBoxColumn()
         With capStyle
            .DataPropertyName = "Cap"
            .HeaderText = "C.A.P."
            .Name = "Cap"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, capStyle)

         ' Citt‡
         Dim citt‡Style As New DataGridViewTextBoxColumn()
         With citt‡Style
            .DataPropertyName = "Citt‡"
            .HeaderText = "Citt‡"
            .Name = "Citt‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, citt‡Style)

         ' Provincia
         Dim provStyle As New DataGridViewTextBoxColumn()
         With provStyle
            .DataPropertyName = "Provincia"
            .HeaderText = "Provincia"
            .Name = "Provincia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, provStyle)

         ' Regione
         Dim regioneStyle As New DataGridViewTextBoxColumn()
         With regioneStyle
            .DataPropertyName = "Regione"
            .HeaderText = "Regione"
            .Name = "Regione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, regioneStyle)

         ' Nazione
         Dim nazioneStyle As New DataGridViewTextBoxColumn()
         With nazioneStyle
            .DataPropertyName = "Nazione"
            .HeaderText = "Nazione"
            .Name = "Nazione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nazioneStyle)

         ' Contatto
         Dim contattoStyle As New DataGridViewTextBoxColumn()
         With contattoStyle
            .DataPropertyName = "Contatto"
            .HeaderText = "Contatto"
            .Name = "Contatto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, contattoStyle)

         ' Attivit‡
         Dim attivit‡Style As New DataGridViewTextBoxColumn()
         With attivit‡Style
            .DataPropertyName = "Attivit‡"
            .HeaderText = "Attivit‡"
            .Name = "Attivit‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, attivit‡Style)

         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridViewTextBoxColumn()
         With telUfficioStyle
            .DataPropertyName = "TelUfficio"
            .HeaderText = "Tel. ufficio"
            .Name = "TelUfficio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telUfficioStyle)

         ' Fax
         Dim faxStyle As New DataGridViewTextBoxColumn()
         With faxStyle
            .DataPropertyName = "Fax"
            .HeaderText = "Fax"
            .Name = "Fax"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, faxStyle)

         ' Cell
         Dim cellStyle As New DataGridViewTextBoxColumn()
         With cellStyle
            .DataPropertyName = "Cell"
            .HeaderText = "Cellulare"
            .Name = "Cell"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, cellStyle)

         ' Email
         Dim emailStyle As New DataGridViewLinkColumn()
         With emailStyle
            .DataPropertyName = "Email"
            .HeaderText = "E-mail"
            .Name = "Email"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewLinkCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, emailStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneClienti(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Cognome
         Dim cognomeStyle As New DataGridViewTextBoxColumn()
         With cognomeStyle
            .DataPropertyName = "Cognome"
            .HeaderText = "Rag. Soc. / Cognome"
            .Name = "Cognome"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, cognomeStyle)

         ' Nome
         Dim nomeStyle As New DataGridViewTextBoxColumn()
         With nomeStyle
            .DataPropertyName = "Nome"
            .HeaderText = "Nome"
            .Name = "Nome"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nomeStyle)

         ' Indirizzo
         Dim Indirizzo1Style As New DataGridViewTextBoxColumn()
         With Indirizzo1Style
            .DataPropertyName = "Indirizzo"
            .HeaderText = "Indirizzo"
            .Name = "Indirizzo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, Indirizzo1Style)

         ' Cap
         Dim capStyle As New DataGridViewTextBoxColumn()
         With capStyle
            .DataPropertyName = "Cap"
            .HeaderText = "C.A.P."
            .Name = "Cap"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, capStyle)

         ' Citt‡
         Dim citt‡Style As New DataGridViewTextBoxColumn()
         With citt‡Style
            .DataPropertyName = "Citt‡"
            .HeaderText = "Citt‡"
            .Name = "Citt‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, citt‡Style)

         ' Provincia
         Dim provStyle As New DataGridViewTextBoxColumn()
         With provStyle
            .DataPropertyName = "Provincia"
            .HeaderText = "Provincia"
            .Name = "Provincia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, provStyle)

         ' Regione
         Dim regioneStyle As New DataGridViewTextBoxColumn()
         With regioneStyle
            .DataPropertyName = "Regione"
            .HeaderText = "Regione"
            .Name = "Regione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, regioneStyle)

         ' Nazione
         Dim nazioneStyle As New DataGridViewTextBoxColumn()
         With nazioneStyle
            .DataPropertyName = "Nazione"
            .HeaderText = "Nazione"
            .Name = "Nazione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nazioneStyle)

         ' Data di nascita
         Dim dataNascitaStyle As New DataGridViewTextBoxColumn()
         With dataNascitaStyle
            .DataPropertyName = "DataNascita"
            .HeaderText = "Data di nascita"
            .Name = "DataNascita"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, dataNascitaStyle)

         ' Tipo Alloggiato
         Dim tipoAlloggiatoStyle As New DataGridViewTextBoxColumn()
         With tipoAlloggiatoStyle
            .DataPropertyName = "TipoAlloggiato"
            .HeaderText = "Tipo cliente"
            .Name = "TipoAlloggiato"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, tipoAlloggiatoStyle)

         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridViewTextBoxColumn()
         With telUfficioStyle
            .DataPropertyName = "TelUfficio"
            .HeaderText = "Tel. ufficio"
            .Name = "TelUfficio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telUfficioStyle)

         ' Tel. casa
         Dim telCasaStyle As New DataGridViewTextBoxColumn()
         With telCasaStyle
            .DataPropertyName = "TelCasa"
            .HeaderText = "Tel. casa"
            .Name = "TelCasa"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telCasaStyle)

         ' Fax
         Dim faxStyle As New DataGridViewTextBoxColumn()
         With faxStyle
            .DataPropertyName = "Fax"
            .HeaderText = "Fax"
            .Name = "Fax"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, faxStyle)

         ' Cell
         Dim cellStyle As New DataGridViewTextBoxColumn()
         With cellStyle
            .DataPropertyName = "Cell"
            .HeaderText = "Cellulare"
            .Name = "Cell"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, cellStyle)

         ' Email
         Dim emailStyle As New DataGridViewLinkColumn()
         With emailStyle
            .DataPropertyName = "Email"
            .HeaderText = "E-mail"
            .Name = "Email"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewLinkCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, emailStyle)

         ' Obsoleto
         Dim obsoletoStyle As New DataGridViewTextBoxColumn()
         With obsoletoStyle
            .DataPropertyName = "Obsoleto"
            .HeaderText = "Obsoleto"
            .Name = "Obsoleto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, obsoletoStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneAziende(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Ragione sociale
         Dim ragSocStyle As New DataGridViewTextBoxColumn()
         With ragSocStyle
            .DataPropertyName = "RagSociale"
            .HeaderText = "Ragione sociale"
            .Name = "RagSociale"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, ragSocStyle)

         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridViewTextBoxColumn()
         With Indirizzo1Style
            .DataPropertyName = "Indirizzo"
            .HeaderText = "Indirizzo"
            .Name = "Indirizzo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, Indirizzo1Style)

         ' Cap
         Dim capStyle As New DataGridViewTextBoxColumn()
         With capStyle
            .DataPropertyName = "Cap"
            .HeaderText = "C.A.P."
            .Name = "Cap"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, capStyle)

         ' Citt‡
         Dim citt‡Style As New DataGridViewTextBoxColumn()
         With citt‡Style
            .DataPropertyName = "Citt‡"
            .HeaderText = "Citt‡"
            .Name = "Citt‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, citt‡Style)

         ' Provincia
         Dim provStyle As New DataGridViewTextBoxColumn()
         With provStyle
            .DataPropertyName = "Provincia"
            .HeaderText = "Provincia"
            .Name = "Provincia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, provStyle)

         ' Regione
         Dim regioneStyle As New DataGridViewTextBoxColumn()
         With regioneStyle
            .DataPropertyName = "Regione"
            .HeaderText = "Regione"
            .Name = "Regione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, regioneStyle)

         ' Nazione
         Dim nazioneStyle As New DataGridViewTextBoxColumn()
         With nazioneStyle
            .DataPropertyName = "Nazione"
            .HeaderText = "Nazione"
            .Name = "Nazione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nazioneStyle)

         ' Contatto
         Dim contattoStyle As New DataGridViewTextBoxColumn()
         With contattoStyle
            .DataPropertyName = "Contatto"
            .HeaderText = "Contatto"
            .Name = "Contatto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, contattoStyle)

         ' Attivit‡
         Dim attivit‡Style As New DataGridViewTextBoxColumn()
         With attivit‡Style
            .DataPropertyName = "Attivit‡"
            .HeaderText = "Attivit‡"
            .Name = "Attivit‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, attivit‡Style)

         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridViewTextBoxColumn()
         With telUfficioStyle
            .DataPropertyName = "TelUfficio"
            .HeaderText = "Tel. ufficio"
            .Name = "TelUfficio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telUfficioStyle)

         ' Fax
         Dim faxStyle As New DataGridViewTextBoxColumn()
         With faxStyle
            .DataPropertyName = "Fax"
            .HeaderText = "Fax"
            .Name = "Fax"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, faxStyle)

         ' Cell
         Dim cellStyle As New DataGridViewTextBoxColumn()
         With cellStyle
            .DataPropertyName = "Cell"
            .HeaderText = "Cellulare"
            .Name = "Cell"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, cellStyle)

         ' Email
         Dim emailStyle As New DataGridViewLinkColumn()
         With emailStyle
            .DataPropertyName = "Email"
            .HeaderText = "E-mail"
            .Name = "Email"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewLinkCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, emailStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonnePren(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Data
         Dim dataStyle As New DataGridViewTextBoxColumn()
         With dataStyle
            .DataPropertyName = "Data"
            .HeaderText = "Data"
            .Name = "Data"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, dataStyle)

         ' Cliente
         Dim clienteStyle As New DataGridViewTextBoxColumn()
         With clienteStyle
            .DataPropertyName = "Cliente"
            .HeaderText = "Cliente"
            .Name = "Cliente"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, clienteStyle)

         ' Tavolo
         Dim risorsaStyle As New DataGridViewTextBoxColumn()
         With risorsaStyle
            .DataPropertyName = "DescrizioneRisorsa"
            .HeaderText = "Tavolo"
            .Name = "DescrizioneRisorsa"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, risorsaStyle)

         ' Persone
         Dim personeStyle As New DataGridViewTextBoxColumn()
         With personeStyle
            .DataPropertyName = "Persone"
            .HeaderText = "Persone"
            .Name = "Persone"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, personeStyle)

         ' OraInizio
         Dim oraInizioStyle As New DataGridViewTextBoxColumn()
         With oraInizioStyle
            .DataPropertyName = "OraInizio"
            .HeaderText = "Dalle ore"
            .Name = "OraInizio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, oraInizioStyle)

         ' OraFine
         Dim oraFineStyle As New DataGridViewTextBoxColumn()
         With oraFineStyle
            .DataPropertyName = "OraFine"
            .HeaderText = "Alle ore"
            .Name = "OraFine"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, oraFineStyle)

         ' Telefono
         Dim telefonoStyle As New DataGridViewTextBoxColumn()
         With telefonoStyle
            .DataPropertyName = "Telefono"
            .HeaderText = "Telefono"
            .Name = "Telefono"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telefonoStyle)

         ' E-mail
         Dim emailStyle As New DataGridViewLinkColumn()
         With emailStyle
            .DataPropertyName = "eMail"
            .HeaderText = "E-mail"
            .Name = "eMail"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewLinkCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, emailStyle)

         ' Stato prenotazione
         Dim statoStyle As New DataGridViewTextBoxColumn()
         With statoStyle
            .DataPropertyName = "Stato"
            .HeaderText = "Stato prenotazione"
            .Name = "Stato"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, statoStyle)

         ' Colore
         Dim coloreStyle As New DataGridViewTextBoxColumn
         With coloreStyle
            .DataPropertyName = "Colore"
            .HeaderText = "Colore"
            .Name = "ColoreSfondo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonnePrenSale(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Data
         Dim dataStyle As New DataGridViewTextBoxColumn()
         With dataStyle
            .DataPropertyName = "Data"
            .HeaderText = "Data"
            .Name = "Data"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, dataStyle)

         ' Cliente
         Dim clienteStyle As New DataGridViewTextBoxColumn()
         With clienteStyle
            .DataPropertyName = "Cliente"
            .HeaderText = "Cliente"
            .Name = "Cliente"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, clienteStyle)

         ' Risorsa
         Dim risorsaStyle As New DataGridViewTextBoxColumn()
         With risorsaStyle
            .DataPropertyName = "DescrizioneRisorsa"
            .HeaderText = "Sala"
            .Name = "DescrizioneRisorsa"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, risorsaStyle)

         ' Persone
         Dim personeStyle As New DataGridViewTextBoxColumn()
         With personeStyle
            .DataPropertyName = "Persone"
            .HeaderText = "Persone"
            .Name = "Persone"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, personeStyle)

         ' OraInizio
         Dim oraInizioStyle As New DataGridViewTextBoxColumn()
         With oraInizioStyle
            .DataPropertyName = "OraInizio"
            .HeaderText = "Dalle ore"
            .Name = "OraInizio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, oraInizioStyle)

         ' OraFine
         Dim oraFineStyle As New DataGridViewTextBoxColumn()
         With oraFineStyle
            .DataPropertyName = "OraFine"
            .HeaderText = "Alle ore"
            .Name = "OraFine"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, oraFineStyle)

         ' Stato prenotazione
         Dim statoStyle As New DataGridViewTextBoxColumn()
         With statoStyle
            .DataPropertyName = "Stato"
            .HeaderText = "Stato prenotazione"
            .Name = "Stato"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, statoStyle)

         ' Colore
         Dim coloreStyle As New DataGridViewTextBoxColumn
         With coloreStyle
            .DataPropertyName = "Colore"
            .HeaderText = "Colore"
            .Name = "ColoreSfondo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCatPiatti(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

         ' Reparto
         Dim repartoStyle As New DataGridViewTextBoxColumn()
         With repartoStyle
            .DataPropertyName = "Reparto"
            .HeaderText = "Reparto"
            .Name = "Reparto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, repartoStyle)

         ' Colore
         Dim coloreStyle As New DataGridViewTextBoxColumn
         With coloreStyle
            .DataPropertyName = "ColoreSfondo"
            .HeaderText = "Colore"
            .Name = "ColoreSfondo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCamerieri(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Nome
         Dim nomeStyle As New DataGridViewTextBoxColumn()
         With nomeStyle
            .DataPropertyName = "Nome"
            .HeaderText = "Nome"
            .Name = "Nome"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nomeStyle)

         ' Costo ora
         Dim costoOraStyle As New DataGridViewTextBoxColumn()
         With costoOraStyle
            .DataPropertyName = "CostoOra"
            .HeaderText = "Costo/Ora"
            .Name = "CostoOra"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, costoOraStyle)

         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridViewTextBoxColumn()
         With Indirizzo1Style
            .DataPropertyName = "Indirizzo"
            .HeaderText = "Indirizzo"
            .Name = "Indirizzo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, Indirizzo1Style)

         ' Cap
         Dim capStyle As New DataGridViewTextBoxColumn()
         With capStyle
            .DataPropertyName = "Cap"
            .HeaderText = "C.A.P."
            .Name = "Cap"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, capStyle)

         ' Citt‡
         Dim citt‡Style As New DataGridViewTextBoxColumn()
         With citt‡Style
            .DataPropertyName = "Citt‡"
            .HeaderText = "Citt‡"
            .Name = "Citt‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, citt‡Style)

         ' Provincia
         Dim provStyle As New DataGridViewTextBoxColumn()
         With provStyle
            .DataPropertyName = "Provincia"
            .HeaderText = "Provincia"
            .Name = "Provincia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, provStyle)

         ' Nazione
         Dim nazioneStyle As New DataGridViewTextBoxColumn()
         With nazioneStyle
            .DataPropertyName = "Nazione"
            .HeaderText = "Nazione"
            .Name = "Nazione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nazioneStyle)

         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridViewTextBoxColumn()
         With telUfficioStyle
            .DataPropertyName = "TelUfficio"
            .HeaderText = "Tel. ufficio"
            .Name = "TelUfficio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telUfficioStyle)

         ' Tel. casa
         Dim telCasaStyle As New DataGridViewTextBoxColumn()
         With telCasaStyle
            .DataPropertyName = "TelCasa"
            .HeaderText = "Tel. casa"
            .Name = "TelCasa"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telCasaStyle)

         ' Fax
         Dim faxStyle As New DataGridViewTextBoxColumn()
         With faxStyle
            .DataPropertyName = "Fax"
            .HeaderText = "Fax"
            .Name = "Fax"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, faxStyle)

         ' Cell
         Dim cellStyle As New DataGridViewTextBoxColumn()
         With cellStyle
            .DataPropertyName = "Cell"
            .HeaderText = "Cellulare"
            .Name = "Cell"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, cellStyle)

         ' Email
         Dim emailStyle As New DataGridViewLinkColumn()
         With emailStyle
            .DataPropertyName = "Email"
            .HeaderText = "E-mail"
            .Name = "Email"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewLinkCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, emailStyle)

         ' Agenzia
         Dim agenziaStyle As New DataGridViewTextBoxColumn()
         With agenziaStyle
            .DataPropertyName = "Agenzia"
            .HeaderText = "Agenzia"
            .Name = "Agenzia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, agenziaStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneAgenzieCamerieri(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Ragione sociale
         Dim ragSocStyle As New DataGridViewTextBoxColumn()
         With ragSocStyle
            .DataPropertyName = "RagSociale"
            .HeaderText = "Ragione sociale"
            .Name = "RagSociale"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, ragSocStyle)

         ' Indirizzo1
         Dim Indirizzo1Style As New DataGridViewTextBoxColumn()
         With Indirizzo1Style
            .DataPropertyName = "Indirizzo"
            .HeaderText = "Indirizzo"
            .Name = "Indirizzo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, Indirizzo1Style)

         ' Cap
         Dim capStyle As New DataGridViewTextBoxColumn()
         With capStyle
            .DataPropertyName = "Cap"
            .HeaderText = "C.A.P."
            .Name = "Cap"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, capStyle)

         ' Citt‡
         Dim citt‡Style As New DataGridViewTextBoxColumn()
         With citt‡Style
            .DataPropertyName = "Citt‡"
            .HeaderText = "Citt‡"
            .Name = "Citt‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, citt‡Style)

         ' Provincia
         Dim provStyle As New DataGridViewTextBoxColumn()
         With provStyle
            .DataPropertyName = "Provincia"
            .HeaderText = "Provincia"
            .Name = "Provincia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, provStyle)

         ' Regione
         Dim regioneStyle As New DataGridViewTextBoxColumn()
         With regioneStyle
            .DataPropertyName = "Regione"
            .HeaderText = "Regione"
            .Name = "Regione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, regioneStyle)

         ' Nazione
         Dim nazioneStyle As New DataGridViewTextBoxColumn()
         With nazioneStyle
            .DataPropertyName = "Nazione"
            .HeaderText = "Nazione"
            .Name = "Nazione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nazioneStyle)

         ' Contatto
         Dim contattoStyle As New DataGridViewTextBoxColumn()
         With contattoStyle
            .DataPropertyName = "Contatto"
            .HeaderText = "Contatto"
            .Name = "Contatto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, contattoStyle)

         ' Tel. ufficio
         Dim telUfficioStyle As New DataGridViewTextBoxColumn()
         With telUfficioStyle
            .DataPropertyName = "TelUfficio"
            .HeaderText = "Tel. ufficio"
            .Name = "TelUfficio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, telUfficioStyle)

         ' Fax
         Dim faxStyle As New DataGridViewTextBoxColumn()
         With faxStyle
            .DataPropertyName = "Fax"
            .HeaderText = "Fax"
            .Name = "Fax"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, faxStyle)

         ' Cell
         Dim cellStyle As New DataGridViewTextBoxColumn()
         With cellStyle
            .DataPropertyName = "Cell"
            .HeaderText = "Cellulare"
            .Name = "Cell"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, cellStyle)

         ' Email
         Dim emailStyle As New DataGridViewLinkColumn()
         With emailStyle
            .DataPropertyName = "Email"
            .HeaderText = "E-mail"
            .Name = "Email"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewLinkCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, emailStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneSale(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

         ' Colore
         Dim coloreStyle As New DataGridViewTextBoxColumn
         With coloreStyle
            .DataPropertyName = "ColoreSfondo"
            .HeaderText = "Colore"
            .Name = "ColoreSfondo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneTavoli(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

         'Posti
         Dim postiStyle As New DataGridViewTextBoxColumn()
         With postiStyle
            .DataPropertyName = "Posti"
            .HeaderText = "Posti"
            .Name = "Posti"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, postiStyle)

         ' Cameriere
         Dim cameriereStyle As New DataGridViewTextBoxColumn()
         With cameriereStyle
            .DataPropertyName = "Cameriere"
            .HeaderText = "Cameriere"
            .Name = "Cameriere"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, cameriereStyle)

         ' Listino
         Dim listinoStyle As New DataGridViewTextBoxColumn()
         With listinoStyle
            .DataPropertyName = "Listino"
            .HeaderText = "Listino"
            .Name = "Listino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, listinoStyle)

         ' Sala
         Dim salaStyle As New DataGridViewTextBoxColumn()
         With salaStyle
            .DataPropertyName = "Sala"
            .HeaderText = "Sala"
            .Name = "Sala"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, salaStyle)

         ' Escludi
         Dim escludiStyle As New DataGridViewTextBoxColumn()
         With escludiStyle
            .DataPropertyName = "Escludi"
            .HeaderText = "Escludi dalla gestione"
            .Name = "Escludi"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, escludiStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCamere(ByVal tabella As String)
      DataGridView1.AutoGenerateColumns = False
      DataGridView1.DataMember = tabella

      ' Id - Codice
      Dim codiceStyle As New DataGridViewTextBoxColumn()
      With codiceStyle
         .DataPropertyName = "Id"
         .HeaderText = "Codice"
         .Name = "Id"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
         .CellTemplate.Style.NullValue = String.Empty
         .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

      ' Numero
      Dim numeroStyle As New DataGridViewTextBoxColumn()
      With numeroStyle
         .DataPropertyName = "Numero"
         .HeaderText = "Numero"
         .Name = "Numero"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
         .CellTemplate.Style.NullValue = String.Empty
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, numeroStyle)

      ' Descrizione
      Dim descrizioneStyle As New DataGridViewTextBoxColumn()
      With descrizioneStyle
         .DataPropertyName = "Descrizione"
         .HeaderText = "Descrizione"
         .Name = "Descrizione"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
         .CellTemplate.Style.NullValue = String.Empty
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

      ' Ubicazione
      Dim ubicazioneStyle As New DataGridViewTextBoxColumn()
      With ubicazioneStyle
         .DataPropertyName = "Ubicazione"
         .HeaderText = "Ubicazione"
         .Name = "Ubicazione"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, ubicazioneStyle)

      ' Posizione
      Dim posizioneStyle As New DataGridViewTextBoxColumn()
      With posizioneStyle
         .DataPropertyName = "Posizione"
         .HeaderText = "Posizione"
         .Name = "Posizione"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, posizioneStyle)

      ' Tipologia
      Dim tipologiaStyle As New DataGridViewTextBoxColumn()
      With tipologiaStyle
         .DataPropertyName = "Tipologia"
         .HeaderText = "Tipologia"
         .Name = "Tipologia"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, tipologiaStyle)

      ' Posti letto
      Dim lettiAggStyle As New DataGridViewTextBoxColumn()
      With lettiAggStyle
         .DataPropertyName = "PostiLetto"
         .HeaderText = "Posti letto"
         .Name = "PostiLetto"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
         .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, lettiAggStyle)

      ' Disponibile
      Dim disponibileStyle As New DataGridViewTextBoxColumn()
      With disponibileStyle
         .DataPropertyName = "Disponibile"
         .HeaderText = "Disponibile"
         .Name = "Disponibile"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
         .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, disponibileStyle)

      ' Escludi
      Dim escludiStyle As New DataGridViewTextBoxColumn()
      With escludiStyle
         .DataPropertyName = "Escludi"
         .HeaderText = "Escludi dal Planning"
         .Name = "Escludi"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
         .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, escludiStyle)

      ' Evidenzia
      Dim evidenziaStyle As New DataGridViewTextBoxColumn()
      With evidenziaStyle
         .DataPropertyName = "Evidenzia"
         .HeaderText = "Evidenzia Planning"
         .Name = "Evidenzia"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
         .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, evidenziaStyle)

      ' Listino
      Dim listinoStyle As New DataGridViewTextBoxColumn()
      With listinoStyle
         .DataPropertyName = "Listino"
         .HeaderText = "Listino"
         .Name = "Listino"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, listinoStyle)

      ' Colore
      Dim coloreStyle As New DataGridViewTextBoxColumn
      With coloreStyle
         .DataPropertyName = "Colore"
         .HeaderText = "Colore"
         .Name = "ColoreSfondo"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .CellTemplate = New DataGridViewTextBoxCell()
         .CellTemplate.Style.NullValue = String.Empty
      End With
      DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

   End Sub

   Private Sub CreaColonneStatoPren(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

         ' Colore
         Dim coloreStyle As New DataGridViewTextBoxColumn
         With coloreStyle
            .DataPropertyName = "Colore"
            .HeaderText = "Colore"
            .Name = "ColoreSfondo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneArticoli(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id (non visibile)
         Dim idStyle As New DataGridViewTextBoxColumn()
         With idStyle
            .DataPropertyName = "Id"
            .HeaderText = "Id"
            .Name = "Id"
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, idStyle)

         ' Scorta minima (non visibile)
         Dim smStyle As New DataGridViewTextBoxColumn()
         With smStyle
            .DataPropertyName = "ScortaMin"
            .HeaderText = "ScortaMin"
            .Name = "ScortaMin"
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, smStyle)

         ' Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Codice"
            .HeaderText = "Codice"
            .Name = "Codice"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

         ' Unit‡ di misura
         Dim umStyle As New DataGridViewTextBoxColumn()
         With umStyle
            .DataPropertyName = "Unit‡Misura"
            .HeaderText = "U.M."
            .Name = "Unit‡Misura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, umStyle)

         ' Giacenza
         Dim giacenzaStyle As New DataGridViewTextBoxColumn()
         With giacenzaStyle
            .DataPropertyName = "Giacenza"
            .HeaderText = "Giacenza"
            .Name = "Giacenza"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Blue
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, giacenzaStyle)

         ' Caricato
         Dim caricatoStyle As New DataGridViewTextBoxColumn()
         With caricatoStyle
            .DataPropertyName = "Carico"
            .HeaderText = "Carico"
            .Name = "Carico"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Black
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, caricatoStyle)

         ' Scaricato
         Dim scaricatoStyle As New DataGridViewTextBoxColumn()
         With scaricatoStyle
            .DataPropertyName = "Scarico"
            .HeaderText = "Scarico"
            .Name = "Scarico"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, scaricatoStyle)

         ' Prezzo Acquisto
         Dim pAcquistoStyle As New DataGridViewTextBoxColumn()
         With pAcquistoStyle
            .DataPropertyName = "PrezzoAcquisto"
            .HeaderText = "Prezzo di acquisto"
            .Name = "PrezzoAcquisto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, pAcquistoStyle)

         ' Prezzo Vendita
         Dim pVenditaStyle As New DataGridViewTextBoxColumn()
         With pVenditaStyle
            .DataPropertyName = "PrezzoVendita"
            .HeaderText = "Prezzo di vendita"
            .Name = "PrezzoVendita"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, pVenditaStyle)

         ' Categoria
         Dim categoriaStyle As New DataGridViewTextBoxColumn()
         With categoriaStyle
            .DataPropertyName = "Categoria"
            .HeaderText = "Categoria"
            .Name = "Categoria"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, categoriaStyle)

         ' Fornitore
         Dim fornitoreStyle As New DataGridViewTextBoxColumn()
         With fornitoreStyle
            .DataPropertyName = "Fornitore"
            .HeaderText = "Fornitore"
            .Name = "Fornitore"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, fornitoreStyle)

         ' Magazzino
         Dim magazzinoStyle As New DataGridViewTextBoxColumn()
         With magazzinoStyle
            .DataPropertyName = "Magazzino"
            .HeaderText = "Magazzino"
            .Name = "Magazzino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, magazzinoStyle)

         ' Codice a barre
         Dim barcodStyle As New DataGridViewTextBoxColumn()
         With barcodStyle
            .DataPropertyName = "CodBarre"
            .HeaderText = "Codice a barre"
            .Name = "CodBarre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, barcodStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneOperatori(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Nome utente
         Dim nomeUtenteStyle As New DataGridViewTextBoxColumn()
         With nomeUtenteStyle
            .DataPropertyName = "NomeUtente"
            .HeaderText = "Nome utente"
            .Name = "NomeUtente"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nomeUtenteStyle)

         ' Gruppo
         Dim gruppoStyle As New DataGridViewTextBoxColumn
         With gruppoStyle
            .DataPropertyName = "Gruppo"
            .HeaderText = "Gruppo"
            .Name = "Gruppo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, gruppoStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneGruppi(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Nome gruppo
         Dim nomeGruppoStyle As New DataGridViewTextBoxColumn()
         With nomeGruppoStyle
            .DataPropertyName = "NomeGruppo"
            .HeaderText = "Nome gruppo"
            .Name = "NomeGruppo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, nomeGruppoStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneCarattRisorse(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

         ' Costo
         Dim costoStyle As New DataGridViewTextBoxColumn()
         With costoStyle
            .DataPropertyName = "Costo"
            .HeaderText = "Costo"
            .Name = "Costo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, costoStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneScontiMaggiorazioni(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn()
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, descrizioneStyle)

         ' Tipologia
         Dim tipologiaStyle As New DataGridViewTextBoxColumn()
         With tipologiaStyle
            .DataPropertyName = "Tipologia"
            .HeaderText = "Tipologia"
            .Name = "Tipologia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, tipologiaStyle)

         ' Tipo Importo
         Dim tipoImportoStyle As New DataGridViewTextBoxColumn()
         With tipoImportoStyle
            .DataPropertyName = "TipoImporto"
            .HeaderText = "Tipo Importo"
            .Name = "TipoImporto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, tipoImportoStyle)

         ' Valore
         Dim valoreStyle As New DataGridViewTextBoxColumn()
         With valoreStyle
            .DataPropertyName = "Valore"
            .HeaderText = "Valore"
            .Name = "Valore"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, valoreStyle)

         ' Colore
         Dim coloreStyle As New DataGridViewTextBoxColumn()
         With coloreStyle
            .DataPropertyName = "Colore"
            .HeaderText = "Colore"
            .Name = "ColoreSfondo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

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
            Case "Prezzo di vendita"
               campoRicerca = "PrezzoVendita"
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
            Case "Tipo importo"
               campoRicerca = "TipoImporto"
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
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Rag. Soc. / Cognome")
               eui_cmbCampoRicerca.Items.Add("Nome")
               eui_cmbCampoRicerca.Items.Add("Tipo cliente")
               eui_cmbCampoRicerca.Items.Add("Data di nascita")
               eui_cmbCampoRicerca.Items.Add("Indirizzo")
               eui_cmbCampoRicerca.Items.Add("C.A.P.")
               eui_cmbCampoRicerca.Items.Add("Citt‡")
               eui_cmbCampoRicerca.Items.Add("Provincia")
               eui_cmbCampoRicerca.Items.Add("Regione")
               eui_cmbCampoRicerca.Items.Add("Nazione")
               eui_cmbCampoRicerca.Items.Add("Tel. ufficio")
               eui_cmbCampoRicerca.Items.Add("Tel. casa")
               eui_cmbCampoRicerca.Items.Add("Fax")
               eui_cmbCampoRicerca.Items.Add("Cellulare")
               eui_cmbCampoRicerca.Items.Add("E-mail")
               eui_cmbCampoRicerca.Items.Add("Obsoleto")

            Case Elenco.Aziende
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Ragione sociale")
               eui_cmbCampoRicerca.Items.Add("Indirizzo")
               eui_cmbCampoRicerca.Items.Add("C.A.P.")
               eui_cmbCampoRicerca.Items.Add("Citt‡")
               eui_cmbCampoRicerca.Items.Add("Provincia")
               eui_cmbCampoRicerca.Items.Add("Regione")
               eui_cmbCampoRicerca.Items.Add("Nazione")
               eui_cmbCampoRicerca.Items.Add("Contatto")
               eui_cmbCampoRicerca.Items.Add("Attivit‡")
               eui_cmbCampoRicerca.Items.Add("Tel. ufficio")
               eui_cmbCampoRicerca.Items.Add("Fax")
               eui_cmbCampoRicerca.Items.Add("Cellulare")
               eui_cmbCampoRicerca.Items.Add("E-mail")

            Case Elenco.Fornitori
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Ragione sociale")
               eui_cmbCampoRicerca.Items.Add("Indirizzo")
               eui_cmbCampoRicerca.Items.Add("C.A.P.")
               eui_cmbCampoRicerca.Items.Add("Citt‡")
               eui_cmbCampoRicerca.Items.Add("Provincia")
               eui_cmbCampoRicerca.Items.Add("Regione")
               eui_cmbCampoRicerca.Items.Add("Nazione")
               eui_cmbCampoRicerca.Items.Add("Contatto")
               eui_cmbCampoRicerca.Items.Add("Attivit‡")
               eui_cmbCampoRicerca.Items.Add("Tel. ufficio")
               eui_cmbCampoRicerca.Items.Add("Fax")
               eui_cmbCampoRicerca.Items.Add("Cellulare")
               eui_cmbCampoRicerca.Items.Add("E-mail")

            Case Elenco.Articoli
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Descrizione")
               eui_cmbCampoRicerca.Items.Add("Unit‡ di misura")
               eui_cmbCampoRicerca.Items.Add("Giacenza")
               eui_cmbCampoRicerca.Items.Add("Carico")
               eui_cmbCampoRicerca.Items.Add("Scarico")
               eui_cmbCampoRicerca.Items.Add("Prezzo di acquisto")
               eui_cmbCampoRicerca.Items.Add("Prezzo di vendita")
               eui_cmbCampoRicerca.Items.Add("Categoria")
               eui_cmbCampoRicerca.Items.Add("Fornitore")
               eui_cmbCampoRicerca.Items.Add("Magazzino")
               eui_cmbCampoRicerca.Items.Add("Codice a barre")

            Case Elenco.Prenotazioni
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Data")
               eui_cmbCampoRicerca.Items.Add("Cliente")
               eui_cmbCampoRicerca.Items.Add("Tavolo")
               eui_cmbCampoRicerca.Items.Add("Dalle ore")
               eui_cmbCampoRicerca.Items.Add("Alle ore")
               eui_cmbCampoRicerca.Items.Add("Telefono")
               eui_cmbCampoRicerca.Items.Add("E-mail")
               eui_cmbCampoRicerca.Items.Add("Stato prenotazione")

            Case Elenco.PrenSale
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Data")
               eui_cmbCampoRicerca.Items.Add("Cliente")
               eui_cmbCampoRicerca.Items.Add("Sala")
               eui_cmbCampoRicerca.Items.Add("Dalle ore")
               eui_cmbCampoRicerca.Items.Add("Alle ore")
               eui_cmbCampoRicerca.Items.Add("Stato prenotazione")

            Case Elenco.Sale
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Descrizione")

            Case Elenco.CatPiatti
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Descrizione")
               eui_cmbCampoRicerca.Items.Add("Reparto")

            Case Elenco.Camerieri
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Nome")
               eui_cmbCampoRicerca.Items.Add("Costo/Ora")
               eui_cmbCampoRicerca.Items.Add("Indirizzo")
               eui_cmbCampoRicerca.Items.Add("C.A.P.")
               eui_cmbCampoRicerca.Items.Add("Citt‡")
               eui_cmbCampoRicerca.Items.Add("Provincia")
               eui_cmbCampoRicerca.Items.Add("Nazione")
               eui_cmbCampoRicerca.Items.Add("Tel. ufficio")
               eui_cmbCampoRicerca.Items.Add("Tel. casa")
               eui_cmbCampoRicerca.Items.Add("Fax")
               eui_cmbCampoRicerca.Items.Add("Cellulare")
               eui_cmbCampoRicerca.Items.Add("E-mail")
               eui_cmbCampoRicerca.Items.Add("Agenzia")

            Case Elenco.AgenzieCamerieri
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Ragione sociale")
               eui_cmbCampoRicerca.Items.Add("Indirizzo")
               eui_cmbCampoRicerca.Items.Add("C.A.P.")
               eui_cmbCampoRicerca.Items.Add("Citt‡")
               eui_cmbCampoRicerca.Items.Add("Provincia")
               eui_cmbCampoRicerca.Items.Add("Regione")
               eui_cmbCampoRicerca.Items.Add("Nazione")
               eui_cmbCampoRicerca.Items.Add("Contatto")
               eui_cmbCampoRicerca.Items.Add("Tel. ufficio")
               eui_cmbCampoRicerca.Items.Add("Fax")
               eui_cmbCampoRicerca.Items.Add("Cellulare")
               eui_cmbCampoRicerca.Items.Add("E-mail")

            Case Elenco.Tavoli
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Descrizione")
               eui_cmbCampoRicerca.Items.Add("Posti")
               eui_cmbCampoRicerca.Items.Add("Cameriere")
               eui_cmbCampoRicerca.Items.Add("Listino")
               eui_cmbCampoRicerca.Items.Add("Sala")
               eui_cmbCampoRicerca.Items.Add("Escludi")

            Case Elenco.Camere
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Numero")
               eui_cmbCampoRicerca.Items.Add("Descrizione")
               eui_cmbCampoRicerca.Items.Add("Ubicazione")
               eui_cmbCampoRicerca.Items.Add("Posizione")
               eui_cmbCampoRicerca.Items.Add("Tipologia")
               eui_cmbCampoRicerca.Items.Add("Posti letto")
               eui_cmbCampoRicerca.Items.Add("Disponibile")
               eui_cmbCampoRicerca.Items.Add("Escludi dal Planning")
               eui_cmbCampoRicerca.Items.Add("Evidenzia Planning")
               eui_cmbCampoRicerca.Items.Add("Listino")

            Case Elenco.StatoPren, Elenco.StatoNoleggi
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Descrizione")

            Case Elenco.Operatori
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Nome utente")
               eui_cmbCampoRicerca.Items.Add("Gruppo")

            Case Elenco.Gruppi
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Nome gruppo")

            Case Elenco.CaratteristicheRisorse
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Descrizione")
               eui_cmbCampoRicerca.Items.Add("Costo")

            Case Elenco.ScontiMaggiorazioni
               eui_cmbCampoRicerca.Items.Add("Codice")
               eui_cmbCampoRicerca.Items.Add("Descrizione")
               eui_cmbCampoRicerca.Items.Add("Tipologia")
               eui_cmbCampoRicerca.Items.Add("Tipo importo")
               eui_cmbCampoRicerca.Items.Add("Valore")

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

   Public Sub AnteprimaDiStampaCamere(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New CamereDataSet
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

   Public Sub AnteprimaDiStampaClienti(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New ClientiDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepClienti(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaFornitori(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New FornitoriDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepFornitori(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaCamerieri(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New CamerieriDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepCamerieri(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   ' TODO: Modificare per AgenzieCamerieri.
   Private Sub AnteprimaDiStampaAgenzieCamerieri(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New CamerieriDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepCamerieri(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaAziende(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New AziendeDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepAziende(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaCategoriePiatti(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New CategoriePiattiDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepCategoriePiatti(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaSale(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New SaleDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepSale(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaTavoli(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New TavoliDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepTavoli(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaPrenTavoli(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New PrenTavoliDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepPrenTavoli(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaPrenSale(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New PrenSaleDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepPrenSale(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaGruppiOp(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New GruppiOpDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepGruppiOp(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaOperatori(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New OperatoriDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepOperatori(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AnteprimaDiStampaArticoli(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New ArticoliDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepArticoli(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub AnteprimaDiStampaScontiMaggiorazioni(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New ScontiMaggiorazioniDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepScontiMaggiorazioni(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoCamere(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New CamereDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_CAMERE)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoClienti(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New ClientiDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_CLIENTI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoFornitori(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New FornitoriDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_FORNITORI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoCamerieri(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New CamerieriDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_CAMERIERI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   ' TODO: Modificare per AgenzieCamerieri.
   Private Sub StampaElencoAgenzieCamerieri(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New CamerieriDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_CAMERIERI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoAziende(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New AziendeDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_AZIENDE)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoCategoriePiatti(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New CategoriePiattiDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_CAT_PIATTI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoSale(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New SaleDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_SALE)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoTavoli(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New TavoliDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_TAVOLI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoPrenTavoli(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New PrenTavoliDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_PREN)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoPrenSale(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New PrenSaleDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_PREN_SALE)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoGruppiOp(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New GruppiOpDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_GRUPPI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoOperatori(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New OperatoriDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_OPERATORI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElencoArticoli(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New ArticoliDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_ARTICOLI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub StampaElencoScontiMaggiorazioni(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New ScontiMaggiorazioniDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_SCONTI_MAGGIORAZIONI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

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

         Case Elenco.AgenzieCamerieri
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

         Case Elenco.StatoPren, Elenco.StatoNoleggi
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

#Region "Strumenti di Modifica - (Condivisa) "
      ' Visualizza i comandi Strumenti di modifica sul Ribbon.
      g_frmMain.rtgStrumentiModifica.Visible = True

      Select Case TipoElenco
         Case Elenco.Clienti

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False


            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Aziende

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False


            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Fornitori

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.CatPiatti

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Camerieri

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.AgenzieCamerieri

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Sale

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Tavoli

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Camere

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.StatoPren, Elenco.StatoNoleggi

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Operatori

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Gruppi

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.CaratteristicheRisorse

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Prenotazioni

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TODO_A: Per Elenco prenotazioni Tavoli e Sale implementare comandi Filtro periodo sul Ribbon.
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

            '' Periodo.
            'g_frmMain.eui_Strumenti_Periodo_Tutte.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Anno.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Mese.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_DalAl.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Sep1.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Arrivo.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_Partenza.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_Sep2.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_NonAssegnate.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_Terminate.Visible = True

            '' Visualizza.
            'g_frmMain.eui_Strumenti_Visualizza_Presenze.Visible = False
            'g_frmMain.eui_rib_Visualizza.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.PrenSale

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = False

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TODO_A: Per Elenco prenotazioni Tavoli e Sale implementare comandi Filtro periodo sul Ribbon.
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

            '' Periodo.
            'g_frmMain.eui_Strumenti_Periodo_Tutte.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Anno.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Mese.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_DalAl.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Sep1.Visible = True
            'g_frmMain.eui_Strumenti_Periodo_Arrivo.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_Partenza.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_Sep2.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_NonAssegnate.Visible = False
            'g_frmMain.eui_Strumenti_Periodo_Terminate.Visible = True

            '' Visualizza.
            'g_frmMain.eui_Strumenti_Visualizza_Presenze.Visible = False
            'g_frmMain.eui_rib_Visualizza.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

         Case Elenco.Articoli

#Region "Modifica - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiModifica.Visible = True

            ' Dati.
            g_frmMain.eui_Strumenti_Nuovo.Visible = True
            g_frmMain.eui_Strumenti_Modifica.Visible = True
            g_frmMain.eui_Strumenti_Duplica.Visible = True
            g_frmMain.eui_Strumenti_Elimina.Visible = True
            g_frmMain.eui_Strumenti_Annulla.Visible = False
            g_frmMain.eui_Strumenti_Aggiorna.Visible = True

            ' Esporta.
            g_frmMain.eui_Strumenti_Esporta.Visible = True
            g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_XML.Visible = False
            g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

            ' Magazzino.
            g_frmMain.eui_Strumenti_Magazzino.Visible = True

            ' Stampa.
            g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
            g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
            ' TabPage.
            g_frmMain.eui_StrumentiPeriodo.Visible = False

#End Region

#Region "Documenti "
            ' TabPage.
            g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
            ' TabPage.
            g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

      End Select

      ' Serve ad attivare/disattivare i vari comandi in base ai dati visualizzati.
      AggiornaDati()

#End Region

   End Sub

   Private Sub frmElencoDati_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Strumenti di Modifica - (Condivisa) "

      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgStrumentiModifica.Visible = False

#End Region

#Region "Gestionale Amica - (Condivisa) "

      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

#End Region

   End Sub

   Private Sub frmElencoDati_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Crea le colonne della griglia dati.
         CreaColonne()

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         Select Case TipoElenco
            Case Elenco.Clienti
               eui_cmbCampoRicerca.SelectedIndex = 2

               strDescrizione = STR_ANAGRAFICA_CLIENTI
               strModulo = MODULO_ANAGRAFICA_CLIENTI

            Case Elenco.Aziende
               eui_cmbCampoRicerca.SelectedIndex = 2

               strDescrizione = STR_ANAGRAFICA_AZIENDE
               strModulo = MODULO_ANAGRAFICA_AZIENDE

            Case Elenco.Fornitori
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_FORNITORI
               strModulo = MODULO_ANAGRAFICA_FORNITORI

            Case Elenco.CatPiatti
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_CAT_PIATTI
               strModulo = MODULO_ANAGRAFICA_CAT_PIATTI

            Case Elenco.Camerieri
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_AGENZIE_CAMERIERI
               strModulo = MODULO_ANAGRAFICA_AGENZIE_CAMERIERI

            Case Elenco.AgenzieCamerieri
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_AGENZIE_CAMERIERI
               strModulo = MODULO_ANAGRAFICA_AGENZIE_CAMERIERI

            Case Elenco.Sale
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_SALE
               strModulo = MODULO_ANAGRAFICA_SALE

            Case Elenco.Tavoli
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_TAVOLI
               strModulo = MODULO_ANAGRAFICA_TAVOLI

            Case Elenco.Camere
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_ANAGRAFICA_CAMERE
               strModulo = MODULO_ANAGRAFICA_CAMERE

            Case Elenco.StatoPren
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_TABELLA_STATO_PREN
               strModulo = MODULO_TABELLA_STATO_PREN

            Case Elenco.StatoNoleggi
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_TABELLA_STATO_NOLEGGI
               strModulo = MODULO_TABELLA_STATO_NOLEGGI

            Case Elenco.Operatori
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_GESTIONE_OPERATORI
               strModulo = MODULO_GESTIONE_OPERATORI

            Case Elenco.Gruppi
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_GESTIONE_GRUPPI
               strModulo = MODULO_GESTIONE_GRUPPI

            Case Elenco.CaratteristicheRisorse
               eui_cmbCampoRicerca.SelectedIndex = 1

               ' A_TODO: da gestire per Caratteristiche Risorse.
               strDescrizione = "l'elenco Caratteristiche di utilizzo Risorse." ' STR_GESTIONE_GRUPPI
               strModulo = "GESTIONE CARATTERISTICHE DI UTILIZZO RISORSE" ' MODULO_GESTIONE_GRUPPI

            Case Elenco.ScontiMaggiorazioni
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_TABELLA_STATO_PREN
               strModulo = MODULO_TABELLA_STATO_PREN

            Case Elenco.Prenotazioni
               eui_cmbCampoRicerca.SelectedIndex = 2

               strDescrizione = STR_GESTIONE_PREN_TAVOLI
               strModulo = MODULO_GESTIONE_PREN_TAVOLI

            Case Elenco.PrenSale
               eui_cmbCampoRicerca.SelectedIndex = 2

               strDescrizione = STR_GESTIONE_PREN_SALE
               strModulo = MODULO_GESTIONE_PREN_SALE

            Case Elenco.Articoli
               eui_cmbCampoRicerca.SelectedIndex = 1

               strDescrizione = STR_MAGAZZINO_ARTICOLI
               strModulo = MODULO_MAGAZZINO_ARTICOLI

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
            g_frmMain.eui_Strumenti_Elimina.Enabled = False
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, strDescrizione, strModulo)

         ' Imposta lo stato attivo per la griglia dati.
         DataGridView1.Focus()

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

            Case Elenco.AgenzieCamerieri
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmAgenzieCamerieri)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmAgenzieCamerieri.Dispose()
               g_frmAgenzieCamerieri = Nothing

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

            Case Elenco.StatoNoleggi
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmStatoNoleggi)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmStatoNoleggi.Dispose()
               g_frmStatoNoleggi = Nothing

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

            Case Elenco.ScontiMaggiorazioni
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmScontiMaggiorazioni)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmScontiMaggiorazioni.Dispose()
               g_frmScontiMaggiorazioni = Nothing
         End Select

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_txtTestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_txtTestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmbCampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
   End Sub

   Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
      Try
         ' Imposta il colore per la cella in base al valore del campo ColoreSfondo.
         If DataGridView1.Columns(e.ColumnIndex).Name = "ColoreSfondo" AndAlso Not (TypeOf e.Value Is System.DBNull) Then
            ' Colore di sfondo.
            e.CellStyle.BackColor = Color.FromArgb(e.Value)

            ' Colore testo.
            e.CellStyle.ForeColor = Color.FromArgb(e.Value)

            ' Non visualizza il valore del campo.
            e.Value = String.Empty
         End If

         ' Imposta il colore per la cella in base al valore del campo Giacenza per Articoli.
         If DataGridView1.Columns(e.ColumnIndex).Name = "Giacenza" AndAlso Not (TypeOf e.Value Is System.DBNull) Then

            Dim giacenza As Double = Convert.ToDouble(e.Value)

            If giacenza <= 0 Then
               ' Colore testo.
               e.CellStyle.ForeColor = Color.Red
            Else
               ' Colore testo.
               e.CellStyle.ForeColor = Color.Blue
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()

      ImpostaComandoElimina()
   End Sub

   Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
      If g_frmMain.eui_Strumenti_Modifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         RegistraModifica()

         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDati(DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)
      End If
   End Sub

   Public Sub Nuovo()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, strDescrizione, strModulo)

         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati("")

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub Modifica()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         RegistraModifica()

         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati(DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub Elimina()
      Try
         ' Elimina il valore selezionato.
         EliminaDati(NomeTabella, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value)

         If TipoElenco = Elenco.Prenotazioni Then
            Dim nomeTavolo As String = DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value.ToString

            ' Cancella il colore di eventuali prenotazioni non pi˘ valide.
            ModificaStatoColoreTavolo(TAB_TAVOLI, LeggiIdRisorsa(TAB_TAVOLI, nomeTavolo), Color.MediumSeaGreen)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CaricoMagazzino()
      Try
         Dim frm As New CaricoScarico("Carico", DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(5, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(6, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(7, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(8, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(11, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(12, DataGridView1.CurrentCell.RowIndex).Value)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ScaricoMagazzino()
      Try
         Dim frm As New CaricoScarico("Scarico", DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(5, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(6, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(7, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(8, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(11, DataGridView1.CurrentCell.RowIndex).Value,
                                                   DataGridView1.Item(12, DataGridView1.CurrentCell.RowIndex).Value)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiClienti()
      Try
         Dim Risposta As Short
         Dim cliente As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString & " " & DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare il cliente '" & cliente & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CClienti As New Anagrafiche.Cliente(ConnString)

            With CClienti
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_CLIENTI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_CLIENTI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiAziende()
      Try
         Dim Risposta As Short
         Dim azienda As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare l'azienda '" & azienda & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CAzienda As New Anagrafiche.AziendaCliente(ConnString)

            With CAzienda
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_AZIENDE, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_AZIENDE)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiFornitori()
      Try
         Dim Risposta As Short
         Dim fornitore As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare il fornitore '" & fornitore & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CFornitore As New Anagrafiche.AziendaCliente(ConnString)

            With CFornitore
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_FORNITORI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_FORNITORI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiCategoriePiatti()
      Try
         Dim Risposta As Short
         Dim catPiatti As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_CAT_PIATTI)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare la categoria Piatti '" & catPiatti & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CCatPiatti As New CategoriePiatti()

            With CCatPiatti
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_CAT_PIATTI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Descrizione = .Descrizione & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_CAT_PIATTI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiCamerieri()
      Try
         Dim Risposta As Short
         Dim cameriere As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare il cameriere '" & cameriere & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CCameriere As New Cameriere(ConnStringAnagrafiche)

            With CCameriere
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_CAMERIERI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_CAMERIERI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiAgenzieCamerieri()
      Try
         Dim Risposta As Short
         Dim agenzia As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare l'agenzia '" & agenzia & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CAgenzia As New Anagrafiche.AziendaCliente(ConnString)

            With CAgenzia
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_AGENZIE_CAMERIERI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_AGENZIE_CAMERIERI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiSale()
      Try
         Dim Risposta As Short
         Dim sala As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_SALE)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare la Sala '" & sala & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CSala As New Sale()

            With CSala
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_SALE, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Descrizione = .Descrizione & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_SALE)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiTavoli()
      Try
         Dim Risposta As Short
         Dim tavolo As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_TAVOLI)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare il Tavolo '" & tavolo & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CTavolo As New Tavoli()

            With CTavolo
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_TAVOLI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Descrizione = .Descrizione & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_TAVOLI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiCamere()
      Try
         Dim Risposta As Short
         Dim numero As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim camera As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_CAMERE)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare la Camera '" & numero & " " & camera & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CCamera As New Camera()

            With CCamera
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_CAMERE, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Numero = "Copia" & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_CAMERE)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiStatoPren()
      Try
         Dim Risposta As Short
         Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_STATO_PREN)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare lo Stato prenotazione '" & descrizione & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CStatoPren As New StatoPren()

            With CStatoPren
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_STATO_PREN, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Descrizione = .Descrizione & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_STATO_PREN)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiStatoNoleggi()
      Try
         Dim Risposta As Short
         Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_STATO_NOLEGGI)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare lo Stato noleggio '" & descrizione & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CStatoNoleggi As New StatoNoleggi()

            With CStatoNoleggi
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_STATO_NOLEGGI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Descrizione = .Descrizione & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_STATO_NOLEGGI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub


   Public Sub DuplicaDatiOperatori()
      Try
         Dim Risposta As Short
         Dim nomeUtente As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_OPERATORI)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare l'operatore '" & nomeUtente & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim COperatori As New Operatori()

            With COperatori
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_OPERATORI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .NomeUtente = .NomeUtente & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_OPERATORI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiGruppi()
      Try
         Dim Risposta As Short
         Dim nomeGruppo As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_GRUPPI)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare il Gruppo '" & nomeGruppo & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CGruppi As New Gruppi()

            With CGruppi
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_GRUPPI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .NomeGruppo = .NomeGruppo & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_GRUPPI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaCaratteristicheRisorse()
      Try
         Dim Risposta As Short
         Dim descrizione As String = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_CARATT_RISORSE)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare la Tipologia di utillizzo Risorsa '" & descrizione & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CCaratteristicheRisorse As New CaratteristicheRisorse()

            With CCaratteristicheRisorse
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_CARATT_RISORSE, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Modifica il campo Descrizione per consentire l'inserimento di un nuovo record.
               .Descrizione = .Descrizione & " - Copia " & (ultimoCodice + 1).ToString

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_CARATT_RISORSE)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiPrenTavoli()
      Try
         Dim Risposta As Short
         Dim numero As String = DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim cliente As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare la prenotazione N. " & numero & " del cliente '" & cliente & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CPrenTavoli As New Prenotazione()

            With CPrenTavoli
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_PREN, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_PREN)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiPrenSale()
      Try
         Dim Risposta As Short
         Dim numero As String = DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim cliente As String = DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare la prenotazione N. " & numero & " del cliente '" & cliente & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CPrenSale As New PrenSale()

            With CPrenSale
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_PREN_SALE, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_PREN_SALE)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DuplicaDatiArticoli()
      Try
         Dim Risposta As Short
         Dim descrizione As String = DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim ultimoCodice As Integer = LeggiUltimoRecord(TAB_ARTICOLI)

         ' Chiede conferma per la duplicazione.
         Risposta = MsgBox("Si desidera duplicare l'articolo '" & descrizione & "' e tutti i suoi dati?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma duplicazione")

         If Risposta = MsgBoxResult.Yes Then

            ' Registra loperazione effettuata dall'operatore identificato.
            RegistraDuplica()

            Dim CArticolo As New Articoli()

            With CArticolo
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_ARTICOLI, DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

               .Codice = .Codice & " - Copia " & (ultimoCodice + 1).ToString
               .CodBarre = String.Empty

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_ARTICOLI)
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
