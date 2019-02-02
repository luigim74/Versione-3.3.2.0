' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 28/02/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class frmElencoDatiSport
   Inherits System.Windows.Forms.Form

   Const TAB_ACCESSORI_SERVIZI As String = "AccessoriServizi"
   Const TAB_RISORSE As String = "Risorse"
   Const TAB_PREN As String = "PrenRisorse"

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
   Private strDescrizione As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   Private DatiConfig As AppConfig

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal val As Short)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      Select Case val
         Case Elenco.AccessoriServizi
            TipoElenco = Elenco.AccessoriServizi
            NomeTabella = "AccessoriServizi"
            TitoloFinestra = "Elenco accessori e servizi"

         Case Elenco.Risorse
            TipoElenco = Elenco.Risorse
            NomeTabella = "Risorse"
            TitoloFinestra = "Elenco risorse"

         Case Elenco.Prenotazioni
            TipoElenco = Elenco.Prenotazioni
            NomeTabella = "PrenRisorse"
            TitoloFinestra = "Elenco prenotazioni risorse"

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

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Modifica As System.Windows.Forms.ToolBarButton
   Friend WithEvents Elimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents Stampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents Anteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents Primo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Precedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents Successivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Ultimo As System.Windows.Forms.ToolBarButton
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents Aggiorna As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents tbNuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Sep13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Inserisci As System.Windows.Forms.ToolBarButton
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoDatiSport))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbNuovo = New System.Windows.Forms.ToolBarButton()
      Me.Modifica = New System.Windows.Forms.ToolBarButton()
      Me.Elimina = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
      Me.Primo = New System.Windows.Forms.ToolBarButton()
      Me.Precedente = New System.Windows.Forms.ToolBarButton()
      Me.Successivo = New System.Windows.Forms.ToolBarButton()
      Me.Ultimo = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
      Me.Aggiorna = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
      Me.Anteprima = New System.Windows.Forms.ToolBarButton()
      Me.Stampa = New System.Windows.Forms.ToolBarButton()
      Me.Sep13 = New System.Windows.Forms.ToolBarButton()
      Me.Inserisci = New System.Windows.Forms.ToolBarButton()
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
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbNuovo, Me.Modifica, Me.Elimina, Me.ToolBarButton4, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.ToolBarButton7, Me.Aggiorna, Me.ToolBarButton1, Me.Anteprima, Me.Stampa, Me.Sep13, Me.Inserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(584, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'tbNuovo
      '
      Me.tbNuovo.ImageIndex = 0
      Me.tbNuovo.Name = "tbNuovo"
      Me.tbNuovo.Tag = "Nuovo"
      Me.tbNuovo.Text = "Nuovo"
      Me.tbNuovo.ToolTipText = "Nuovo"
      '
      'Modifica
      '
      Me.Modifica.ImageIndex = 1
      Me.Modifica.Name = "Modifica"
      Me.Modifica.Tag = "Modifica"
      Me.Modifica.Text = "Apri"
      Me.Modifica.ToolTipText = "Apri"
      '
      'Elimina
      '
      Me.Elimina.ImageIndex = 2
      Me.Elimina.Name = "Elimina"
      Me.Elimina.Tag = "Elimina"
      Me.Elimina.Text = "Elimina"
      Me.Elimina.ToolTipText = "Elimina"
      '
      'ToolBarButton4
      '
      Me.ToolBarButton4.Name = "ToolBarButton4"
      Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Primo
      '
      Me.Primo.ImageIndex = 3
      Me.Primo.Name = "Primo"
      Me.Primo.Tag = "Primo"
      Me.Primo.ToolTipText = "Prima pagina"
      '
      'Precedente
      '
      Me.Precedente.ImageIndex = 4
      Me.Precedente.Name = "Precedente"
      Me.Precedente.Tag = "Precedente"
      Me.Precedente.ToolTipText = "Pagina precedente "
      '
      'Successivo
      '
      Me.Successivo.ImageIndex = 5
      Me.Successivo.Name = "Successivo"
      Me.Successivo.Tag = "Successivo"
      Me.Successivo.ToolTipText = "Pagina successiva"
      '
      'Ultimo
      '
      Me.Ultimo.ImageIndex = 6
      Me.Ultimo.Name = "Ultimo"
      Me.Ultimo.Tag = "Ultimo"
      Me.Ultimo.ToolTipText = "Ultima pagina"
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Aggiorna
      '
      Me.Aggiorna.ImageIndex = 7
      Me.Aggiorna.Name = "Aggiorna"
      Me.Aggiorna.Tag = "Aggiorna"
      Me.Aggiorna.ToolTipText = "Aggiorna"
      '
      'ToolBarButton1
      '
      Me.ToolBarButton1.Name = "ToolBarButton1"
      Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Anteprima
      '
      Me.Anteprima.ImageIndex = 8
      Me.Anteprima.Name = "Anteprima"
      Me.Anteprima.Tag = "Anteprima"
      Me.Anteprima.ToolTipText = "Anteprima di stampa"
      '
      'Stampa
      '
      Me.Stampa.ImageIndex = 9
      Me.Stampa.Name = "Stampa"
      Me.Stampa.Tag = "Stampa"
      Me.Stampa.ToolTipText = "Stampa"
      '
      'Sep13
      '
      Me.Sep13.Name = "Sep13"
      Me.Sep13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.Sep13.Visible = False
      '
      'Inserisci
      '
      Me.Inserisci.Name = "Inserisci"
      Me.Inserisci.Tag = ""
      Me.Inserisci.Visible = False
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
      '
      'DataGrid1
      '
      Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 56)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(584, 277)
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
      Me.Panel1.Size = New System.Drawing.Size(584, 30)
      Me.Panel1.TabIndex = 0
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(442, 8)
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
      Me.Label2.Location = New System.Drawing.Point(360, 8)
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
      Me.TestoRicerca.Location = New System.Drawing.Point(112, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(239, 20)
      Me.TestoRicerca.TabIndex = 0
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Risorse.rpt"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmElencoDatiSport
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(584, 334)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmElencoDatiSport"
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
            Case Elenco.Risorse
               If DatiConfig.GetValue("WSRisorse") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSRisorse") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("ARisorse") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("ARisorse"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LRisorse") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LRisorse"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("RisorseX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("RisorseX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("RisorseY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("RisorseY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.AccessoriServizi
               If DatiConfig.GetValue("WSAccessoriServizi") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSAccessoriServizi") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("AAccessoriServizi") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("AAccessoriServizi"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LAccessoriServizi") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LAccessoriServizi"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("AccessoriServiziX") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("AccessoriServiziX")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("AccessoriServiziY") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("AccessoriServiziY")))
                  End If

                  Exit Sub
               End If

            Case Elenco.Prenotazioni
               If DatiConfig.GetValue("WSPrenRisorse") = CStr(FormWindowState.Maximized) Then
                  Me.WindowState = FormWindowState.Maximized
                  Exit Sub
               ElseIf DatiConfig.GetValue("WSPrenRisorse") = CStr(FormWindowState.Minimized) Then
                  Me.WindowState = FormWindowState.Minimized
                  Exit Sub
               Else
                  If DatiConfig.GetValue("APrenRisorse") <> "" Then
                     Me.Height = CInt(DatiConfig.GetValue("APrenRisorse"))
                  Else
                     Me.Height = FORM_ALTEZZA
                  End If

                  If DatiConfig.GetValue("LPrenRisorse") <> "" Then
                     Me.Width = CInt(DatiConfig.GetValue("LPrenRisorse"))
                  Else
                     Me.Width = FORM_LARGHEZZA
                  End If

                  If DatiConfig.GetValue("PrenXRisorse") <> "" Then
                     Me.Location = New Point(CInt(DatiConfig.GetValue("PrenXRisorse")), Me.Location.Y)
                  End If

                  If DatiConfig.GetValue("PrenYRisorse") <> "" Then
                     Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PrenYRisorse")))
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
            Case Elenco.Risorse
               DatiConfig.SetValue("WSRisorse", Me.WindowState)
               DatiConfig.SetValue("RisorseX", Me.Location.X)
               DatiConfig.SetValue("RisorseY", Me.Location.Y)
               DatiConfig.SetValue("ARisorse", Me.Height)
               DatiConfig.SetValue("LRisorse", Me.Width)

            Case Elenco.AccessoriServizi
               DatiConfig.SetValue("WSAccessoriServizi", Me.WindowState)
               DatiConfig.SetValue("AccessoriServiziX", Me.Location.X)
               DatiConfig.SetValue("AccessoriServiziY", Me.Location.Y)
               DatiConfig.SetValue("AAccessoriServizi", Me.Height)
               DatiConfig.SetValue("LAccessoriServizi", Me.Width)

            Case Elenco.Prenotazioni
               DatiConfig.SetValue("WSPrenRisorse", Me.WindowState)
               DatiConfig.SetValue("PrenXRisorse", Me.Location.X)
               DatiConfig.SetValue("PrenYRisorse", Me.Location.Y)
               DatiConfig.SetValue("APrenRisorse", Me.Height)
               DatiConfig.SetValue("LPrenRisorse", Me.Width)
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Risorse
               If operatore.AnagRisorse = VALORE_LETTURA Then
                  tbNuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  tbNuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.PrenRisorse
               If operatore.GestPrenRisorse = VALORE_LETTURA Then
                  tbNuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  tbNuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.AccessoriServizi
               If operatore.AnagAccessoriServizi = VALORE_LETTURA Then
                  tbNuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  tbNuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

         End Select

         Return tbNuovo.Enabled

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
            Case Elenco.Risorse
               ' Registra l'operazione.
               Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
               Dim Descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               strDescrizione = "(" & Numero & " " & Descrizione & ")"

            Case Elenco.Prenotazioni
               ' Registra l'operazione.
               Dim Codice As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
               Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
               Dim Intestatario As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
               Dim Risorsa As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6)
               Dim OraInizio As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8)
               Dim OraFine As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 9)

               strDescrizione = " (" & Codice & " - " & Data & " " & Intestatario & " - " & Risorsa & " - Ora: " & OraInizio & "/" & OraFine & ")"

            Case Elenco.AccessoriServizi
               ' Registra l'operazione.
               Dim Codice As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
               Dim Descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               strDescrizione = "(" & Codice & " " & Descrizione & ")"

         End Select

         ' Registra loperazione efettuata dall'operatore identificato.
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

         ' Chiude la connessione se è da chiudere.
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
         Primo.Enabled = (n > 1)
         Precedente.Enabled = (n > 1)
         Successivo.Enabled = (n < numPagine)
         Ultimo.Enabled = (n < numPagine)

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
            Case Elenco.Risorse
               Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
               Dim Descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               ' Registra l'operazione.
               strDescrizione = "(" & Numero & " " & Descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la risorsa """ & Numero & " " & Descrizione & _
                                 """?" & vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.AccessoriServizi
               Dim Codice As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
               Dim Descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               strDescrizione = "(" & Codice & " " & Descrizione & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare l'accessorio o servizio """ & Codice & " " & Descrizione & _
                                 """?" & vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

            Case Elenco.Prenotazioni
               Dim Cliente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

               ' Registra l'operazione.
               strDescrizione = " (" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) & _
                 " - Per " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) & _
                 " il " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & _
                 " alle " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5) & _
                 " / " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6) & _
                 " - " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) & ")"

               ' Chiede conferma per l'eliminazione.
               Risposta = MsgBox("Si desidera eliminare la prenotazione del cliente """ & Cliente & _
                                 """?" & vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")
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
         Modifica.Enabled = False
         Elimina.Enabled = False
         Primo.Enabled = False
         Precedente.Enabled = False
         Successivo.Enabled = False
         Ultimo.Enabled = False
         Aggiorna.Enabled = False
      Else
         ' Disattiva i pulsanti appropriati.
         Modifica.Enabled = True
         Elimina.Enabled = True
         Aggiorna.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      Select Case TipoElenco
         Case Elenco.Risorse
            If ImpostaFunzioniOperatore(Finestra.Risorse) = True Then
               ImpostaComandi()
            End If

         Case Elenco.Prenotazioni
            If ImpostaFunzioniOperatore(Finestra.PrenRisorse) = True Then
               ImpostaComandi()
            End If

         Case Elenco.AccessoriServizi
            If ImpostaFunzioniOperatore(Finestra.AccessoriServizi) = True Then
               ImpostaComandi()
            End If
      End Select

   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Select Case TipoElenco
            Case Elenco.AccessoriServizi
               ' Per la versione demo.
               If g_VerDemo = True Then
                  ' Test per la versione demo.
                  If VerificaNumRecord(LeggiNumRecord(TAB_ACCESSORI_SERVIZI)) = True Then
                     Exit Sub
                  End If
               End If

               Dim frm As New frmAccessoriServizi
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Risorse
               ' Per la versione demo.
               If g_VerDemo = True Then
                  ' Test per la versione demo.
                  If VerificaNumRecord(LeggiNumRecord(TAB_RISORSE)) = True Then
                     Exit Sub
                  End If
               End If

               Dim frm As New frmRisorse
               frm.Tag = val
               frm.ShowDialog()

            Case Elenco.Prenotazioni
               ' Per la versione demo.
               If g_VerDemo = True Then
                  ' Test per la versione demo.
                  If VerificaNumRecord(LeggiNumRecord(TAB_PREN)) = True Then
                     Exit Sub
                  End If
               End If

               If val = "" Then
                  ' Nuovo inserimento.
                  g_frmDatiPrenRisorse = New frmPrenRisorse
               Else
                  ' Modifica.
                  'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
                  g_frmDatiPrenRisorse = New frmPrenRisorse(String.Empty, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3), String.Empty)
               End If

               g_frmDatiPrenRisorse.Tag = val
               g_frmDatiPrenRisorse.ShowDialog()
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
               Case Elenco.AccessoriServizi
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " & _
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & _
                                                        " " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))
               Case Elenco.Risorse
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " & _
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & _
                                                        " " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))
               Case Elenco.Prenotazioni
                  DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " & _
                                                        DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))
            End Select
         Else
            DataGrid1.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n° totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonne()
      Try
         Select Case TipoElenco
            Case Elenco.AccessoriServizi
               CreaColonneAccessoriServizi(NomeTabella)

            Case Elenco.Risorse
               CreaColonneRisorse(NomeTabella)

            Case Elenco.Prenotazioni
               CreaColonnePren(NomeTabella)
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub CreaColonneAccessoriServizi(ByVal tabella As String)
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
         ' Tipologia
         Dim tipologiaStyle As New DataGridTextBoxColumn
         tipologiaStyle.MappingName = "Tipologia"
         tipologiaStyle.HeaderText = "Tipologia"
         tipologiaStyle.Width = 100
         tipologiaStyle.NullText = ""
         tipologiaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipologiaStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 200
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Costo
         Dim costoStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         costoStyle.MappingName = "Costo"
         costoStyle.HeaderText = "Costo"
         costoStyle.Width = 50
         costoStyle.NullText = ""
         costoStyle.Format = "##,##0.00"
         costoStyle.Alignment = HorizontalAlignment.Right
         costoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(costoStyle)

         ' Disponibile
         'Dim disponibileStyle As New DataGridTextBoxColumn
         'disponibileStyle.MappingName = "Disponibile"
         'disponibileStyle.HeaderText = "Disponibile"
         'disponibileStyle.Width = 60
         'disponibileStyle.Alignment = HorizontalAlignment.Center
         'disponibileStyle.NullText = ""
         'disponibileStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(disponibileStyle)

         ' Escludi
         Dim escludiStyle As New DataGridTextBoxColumn
         escludiStyle.MappingName = "Escludi"
         escludiStyle.HeaderText = "Escludi dalla gestione"
         escludiStyle.Width = 120
         escludiStyle.Alignment = HorizontalAlignment.Center
         escludiStyle.NullText = ""
         escludiStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(escludiStyle)

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

   Private Sub CreaColonneRisorse(ByVal tabella As String)
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
         ' Tipologia
         Dim tipologiaStyle As New DataGridTextBoxColumn
         tipologiaStyle.MappingName = "Tipologia"
         tipologiaStyle.HeaderText = "Tipologia"
         tipologiaStyle.Width = 100
         tipologiaStyle.NullText = ""
         tipologiaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipologiaStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 200
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Costo
         Dim costoStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         costoStyle.MappingName = "Costo"
         costoStyle.HeaderText = "Costo"
         costoStyle.Width = 50
         costoStyle.NullText = ""
         costoStyle.Format = "##,##0.00"
         costoStyle.Alignment = HorizontalAlignment.Right
         costoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(costoStyle)

         ' Disponibile
         'Dim disponibileStyle As New DataGridTextBoxColumn
         'disponibileStyle.MappingName = "Disponibile"
         'disponibileStyle.HeaderText = "Disponibile"
         'disponibileStyle.Width = 60
         'disponibileStyle.Alignment = HorizontalAlignment.Center
         'disponibileStyle.NullText = ""
         'disponibileStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(disponibileStyle)

         ' Escludi
         Dim escludiStyle As New DataGridTextBoxColumn
         escludiStyle.MappingName = "Escludi"
         escludiStyle.HeaderText = "Escludi dal planning"
         escludiStyle.Width = 120
         escludiStyle.Alignment = HorizontalAlignment.Center
         escludiStyle.NullText = ""
         escludiStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(escludiStyle)

         ' Colore
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "Colore"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 50
         coloreStyle.NullText = ""
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)

         ' Tipo Planning.
         Dim tipoPlanningStyle As New DataGridTextBoxColumn
         tipoPlanningStyle.MappingName = "TipoPlanning"
         tipoPlanningStyle.HeaderText = "Tipologia planning"
         tipoPlanningStyle.Width = 350
         tipoPlanningStyle.NullText = ""
         tipoPlanningStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipoPlanningStyle)

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
         ' Numero
         'Dim numeroStyle As New DataGridTextBoxColumn
         'numeroStyle.MappingName = "Numero"
         'numeroStyle.HeaderText = "Numero"
         'numeroStyle.Width = 50
         'numeroStyle.NullText = ""
         'numeroStyle.Alignment = HorizontalAlignment.Right
         'numeroStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(numeroStyle)
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
         clienteStyle.MappingName = "Intestatario"
         clienteStyle.HeaderText = "Intestatario"
         clienteStyle.Width = 120
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(clienteStyle)
         '' Componente1
         'Dim comp1Style As New DataGridTextBoxColumn
         'comp1Style.MappingName = "Componente1"
         'comp1Style.HeaderText = "Secondo giocatore"
         'comp1Style.Width = 120
         'comp1Style.NullText = ""
         'comp1Style.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(comp1Style)
         '' Componente2
         'Dim comp2Style As New DataGridTextBoxColumn
         'comp2Style.MappingName = "Componente2"
         'comp2Style.HeaderText = "Terzo giocatore"
         'comp2Style.Width = 120
         'comp2Style.NullText = ""
         'comp2Style.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(comp2Style)
         '' Componente3
         'Dim comp3Style As New DataGridTextBoxColumn
         'comp3Style.MappingName = "Componente3"
         'comp3Style.HeaderText = "Quarto giocatore"
         'comp3Style.Width = 120
         'comp3Style.NullText = ""
         'comp3Style.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(comp3Style)
         ' Risorsa
         Dim risorsaStyle As New DataGridTextBoxColumn
         risorsaStyle.MappingName = "DescrizioneRisorsa"
         risorsaStyle.HeaderText = "Risorsa"
         risorsaStyle.Width = 200
         risorsaStyle.NullText = ""
         risorsaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(risorsaStyle)
         ' A_TODO: MODIFICHE ASD AGON
         ' Tipologia di utilizzo Risorsa
         Dim utilizzoRisorsaStyle As New DataGridTextBoxColumn
         utilizzoRisorsaStyle.MappingName = "CaratteristicaRisorsa"
         utilizzoRisorsaStyle.HeaderText = "Tipologia di utilizzo"
         utilizzoRisorsaStyle.Width = 250
         utilizzoRisorsaStyle.NullText = ""
         utilizzoRisorsaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(utilizzoRisorsaStyle)
         ' Stato
         Dim statoStyle As New DataGridTextBoxColumn
         statoStyle.MappingName = "Stato"
         statoStyle.HeaderText = "Stato prenotazione"
         statoStyle.Width = 110
         statoStyle.NullText = ""
         statoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(statoStyle)
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
         ' Totale conto
         Dim totaleContoStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         totaleContoStyle.MappingName = "Totale"
         totaleContoStyle.HeaderText = "Totale conto"
         totaleContoStyle.Width = 80
         totaleContoStyle.NullText = ""
         totaleContoStyle.Format = "##,##0.00"
         totaleContoStyle.Alignment = HorizontalAlignment.Right
         totaleContoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(totaleContoStyle)
         ' Pagato
         Dim pagatoStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         pagatoStyle.MappingName = "Pagato"
         pagatoStyle.HeaderText = "Pagato"
         pagatoStyle.Width = 60
         pagatoStyle.NullText = ""
         pagatoStyle.Alignment = HorizontalAlignment.Center
         pagatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(pagatoStyle)
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

   Private Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
      Try
         Dim sql As String

         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Codice"
               campoRicerca = "Id"
            Case "Escludi dal planning"
               campoRicerca = "Escludi"
            Case "Tipologia planning"
               campoRicerca = "TipoPlanning"
            Case "Stato prenotazione"
               campoRicerca = "Stato"
            Case "Risorsa"
               campoRicerca = "DescrizioneRisorsa"
            Case "Tipologia di utilizzo"
               ' A_TODO: MODIFICHE ASD AGON
               campoRicerca = "CaratteristicaRisorsa"
            Case "Dalle ore"
               campoRicerca = "OraInizio"
            Case "Alle ore"
               campoRicerca = "OraFine"
            Case "Totale conto"
               campoRicerca = "Totale"

               'Case "Secondo giocatore"
               '   campoRicerca = "Componente1"
               'Case "Terzo giocatore"
               '   campoRicerca = "Componente2"
               'Case "Quarto giocatore"
               '   campoRicerca = "Componente3"

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
            Case Elenco.AccessoriServizi
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Tipologia")
               CampoRicerca.Items.Add("Descrizione")
               CampoRicerca.Items.Add("Costo")
               CampoRicerca.Items.Add("Escludi dalla gestione")

            Case Elenco.Risorse
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Tipologia")
               CampoRicerca.Items.Add("Descrizione")
               CampoRicerca.Items.Add("Costo")
               CampoRicerca.Items.Add("Escludi dal planning")
               CampoRicerca.Items.Add("Tipologia planning")

            Case Elenco.Prenotazioni
               CampoRicerca.Items.Add("Codice")
               CampoRicerca.Items.Add("Data")
               CampoRicerca.Items.Add("Intestatario")
               'CampoRicerca.Items.Add("Secondo giocatore")
               'CampoRicerca.Items.Add("Terzo giocatore")
               'CampoRicerca.Items.Add("Quarto giocatore")
               CampoRicerca.Items.Add("Risorsa")
               ' A_TODO: MODIFICHE ASD AGON
               CampoRicerca.Items.Add("Tipologia di utilizzo")
               CampoRicerca.Items.Add("Stato prenotazione")
               CampoRicerca.Items.Add("Dalle ore")
               CampoRicerca.Items.Add("Alle ore")
               CampoRicerca.Items.Add("Totale conto")
               CampoRicerca.Items.Add("Pagato")
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
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
         Dim frm As New RepAccessoriServizi(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String, Optional ByVal frmId As String = "")
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter

         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New HospitalityDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         rep.Load(Application.StartupPath & nomeDoc)

         rep.SetDataSource(ds)

         rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True,
                            PrintDialog1.PrinterSettings.FromPage,
                            PrintDialog1.PrinterSettings.ToPage)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub frmElencoDatiSport_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub frmElencoDatiSport_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         Select Case TipoElenco
            Case Elenco.AccessoriServizi
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmAccessoriServizi)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmAccessoriServizi.Dispose()
               g_frmAccessoriServizi = Nothing

            Case Elenco.Risorse
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmRisorse)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmRisorse.Dispose()
               g_frmRisorse = Nothing

            Case Elenco.Prenotazioni
               ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
               g_frmMain.RimuoviFormMenuSeleziona(g_frmPrenRisorse)

               ' Distrugge l'oggetto e libera le risorse.
               g_frmPrenRisorse.Dispose()
               g_frmPrenRisorse = Nothing

         End Select

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub frmElencoDatiSport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Case Elenco.AccessoriServizi

               CampoRicerca.SelectedIndex = 0

               strDescrizione = STR_ANAGRAFICA_ACCESSORI_SERVIZI
               strModulo = MODULO_ANAGRAFICA_ACCESSORI_SERVIZI

            Case Elenco.Risorse
               CampoRicerca.SelectedIndex = 0

               strDescrizione = STR_ANAGRAFICA_RISORSE
               strModulo = MODULO_ANAGRAFICA_RISORSE

            Case Elenco.Prenotazioni
               CampoRicerca.SelectedIndex = 2

               strDescrizione = STR_GESTIONE_PREN_RISORSE
               strModulo = MODULO_GESTIONE_PREN_RISORSE

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

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
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

            If IsNothing(g_frmPlanningSport1) = False Then
               ' Aggiorna il planning.
               g_frmPlanningSport1.CaricaPrenotazioni(False)
            End If

            If IsNothing(g_frmPlanningSport2) = False Then
               ' Aggiorna il planning.
               g_frmPlanningSport2.CaricaPrenotazioni(False)
            End If

            If IsNothing(g_frmPlanningSport3) = False Then
               ' Aggiorna il planning.
               g_frmPlanningSport3.CaricaPrenotazioni(False)
            End If

            If IsNothing(g_frmPlanningSport4) = False Then
               ' Aggiorna il planning.
               g_frmPlanningSport4.CaricaPrenotazioni(False)
            End If

         Case "Stampa"
            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, strDescrizione, strModulo)

            Select Case TipoElenco
               Case Elenco.AccessoriServizi
                  If PrintDialog1.ShowDialog() = DialogResult.OK Then
                     AnteprimaDiStampa(PERCORSO_REP_ACCESSORI_SERVIZI_A4, TAB_ACCESSORI_SERVIZI, repSql)
                  End If

               Case Elenco.Risorse
                  StampaDocumento(PERCORSO_REP_RISORSE, TAB_RISORSE, repSql)

               Case Elenco.Prenotazioni
                  StampaDocumento(PERCORSO_REP_PREN_RISORSE, TAB_PREN, repSql)

            End Select

         Case "Anteprima"
            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, strDescrizione, strModulo)

            Select Case TipoElenco
               Case Elenco.AccessoriServizi
                  AnteprimaDiStampa(PERCORSO_REP_ACCESSORI_SERVIZI_A4, TAB_ACCESSORI_SERVIZI, repSql)

               Case Elenco.Risorse
                  g_frmMain.ApriReports(repSql, TAB_RISORSE, PERCORSO_REP_RISORSE)

               Case Elenco.Prenotazioni
                  g_frmMain.ApriReports(repSql, TAB_PREN, PERCORSO_REP_PREN_RISORSE)

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
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, strDescrizione, strModulo)

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
      If Modifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         RegistraModifica()

         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      End If
   End Sub

End Class
