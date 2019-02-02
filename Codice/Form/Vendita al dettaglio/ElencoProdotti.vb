' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 15/04/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class frmElencoProdotti
   Inherits System.Windows.Forms.Form

   Const TAB_PRODOTTI As String = "Prodotti"
   Public Const TAB_CATEGORIE As String = "CategorieProdotti"
   Const TAB_ARTICOLI_PRODOTTI As String = "ArticoliProdotti"

   Const TITOLO_FINESTRA As String = "Elenco prodotti"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   ' Numero di record.
   Dim numRecord As Integer
   Dim numRecordArticoliProdotti As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim dtArticoliProdotti As DataTable
   Dim sql As String
   Dim repSql As String

   Private DatiConfig As AppConfig
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private CFormatta As New ClsFormatta

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_PRODOTTI)
      dtArticoliProdotti = ds.Tables.Add(TAB_ARTICOLI_PRODOTTI)

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
   Friend WithEvents Sep13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Inserisci As System.Windows.Forms.ToolBarButton
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lstCategorie As System.Windows.Forms.ListBox
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Public WithEvents DataGrid2 As System.Windows.Forms.DataGrid
   Public WithEvents tbrIngredienti As System.Windows.Forms.ToolBar
   Friend WithEvents NuovoIng As System.Windows.Forms.ToolBarButton
   Friend WithEvents ModificaIng As System.Windows.Forms.ToolBarButton
   Friend WithEvents EliminaIng As System.Windows.Forms.ToolBarButton
   Friend WithEvents Nuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Modifica As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoProdotti))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Nuovo = New System.Windows.Forms.ToolBarButton()
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
      Me.lstCategorie = New System.Windows.Forms.ListBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.DataGrid2 = New System.Windows.Forms.DataGrid()
      Me.tbrIngredienti = New System.Windows.Forms.ToolBar()
      Me.NuovoIng = New System.Windows.Forms.ToolBarButton()
      Me.ModificaIng = New System.Windows.Forms.ToolBarButton()
      Me.EliminaIng = New System.Windows.Forms.ToolBarButton()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Nuovo, Me.Modifica, Me.Elimina, Me.ToolBarButton4, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.ToolBarButton7, Me.Aggiorna, Me.ToolBarButton1, Me.Anteprima, Me.Stampa, Me.Sep13, Me.Inserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(744, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'Nuovo
      '
      Me.Nuovo.ImageIndex = 0
      Me.Nuovo.Name = "Nuovo"
      Me.Nuovo.Tag = "Nuovo"
      Me.Nuovo.Text = "Nuovo"
      Me.Nuovo.ToolTipText = "Nuovo piatto"
      '
      'Modifica
      '
      Me.Modifica.ImageIndex = 1
      Me.Modifica.Name = "Modifica"
      Me.Modifica.Tag = "Modifica"
      Me.Modifica.Text = "Apri"
      Me.Modifica.ToolTipText = "Apri piatto"
      '
      'Elimina
      '
      Me.Elimina.ImageIndex = 2
      Me.Elimina.Name = "Elimina"
      Me.Elimina.Tag = "Elimina"
      Me.Elimina.Text = "Elimina"
      Me.Elimina.ToolTipText = "Elimina piatto"
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
      Me.Primo.Visible = False
      '
      'Precedente
      '
      Me.Precedente.ImageIndex = 4
      Me.Precedente.Name = "Precedente"
      Me.Precedente.Tag = "Precedente"
      Me.Precedente.ToolTipText = "Pagina precedente "
      Me.Precedente.Visible = False
      '
      'Successivo
      '
      Me.Successivo.ImageIndex = 5
      Me.Successivo.Name = "Successivo"
      Me.Successivo.Tag = "Successivo"
      Me.Successivo.ToolTipText = "Pagina successiva"
      Me.Successivo.Visible = False
      '
      'Ultimo
      '
      Me.Ultimo.ImageIndex = 6
      Me.Ultimo.Name = "Ultimo"
      Me.Ultimo.Tag = "Ultimo"
      Me.Ultimo.ToolTipText = "Ultima pagina"
      Me.Ultimo.Visible = False
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.ToolBarButton7.Visible = False
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
      Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(216, 56)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(528, 164)
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
      Me.Panel1.Size = New System.Drawing.Size(744, 30)
      Me.Panel1.TabIndex = 0
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(602, 8)
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
      Me.Label2.Location = New System.Drawing.Point(520, 8)
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
      Me.TestoRicerca.Location = New System.Drawing.Point(105, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(399, 20)
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
      'lstCategorie
      '
      Me.lstCategorie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstCategorie.Location = New System.Drawing.Point(2, 80)
      Me.lstCategorie.Name = "lstCategorie"
      Me.lstCategorie.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lstCategorie.Size = New System.Drawing.Size(212, 342)
      Me.lstCategorie.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Gray
      Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(-1, 55)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(218, 22)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "CATEGORIE:"
      '
      'DataGrid2
      '
      Me.DataGrid2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGrid2.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid2.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid2.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid2.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid2.DataMember = ""
      Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid2.Location = New System.Drawing.Point(216, 244)
      Me.DataGrid2.Name = "DataGrid2"
      Me.DataGrid2.ReadOnly = True
      Me.DataGrid2.Size = New System.Drawing.Size(528, 182)
      Me.DataGrid2.TabIndex = 10
      '
      'tbrIngredienti
      '
      Me.tbrIngredienti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbrIngredienti.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.tbrIngredienti.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.NuovoIng, Me.ModificaIng, Me.EliminaIng})
      Me.tbrIngredienti.Divider = False
      Me.tbrIngredienti.Dock = System.Windows.Forms.DockStyle.None
      Me.tbrIngredienti.DropDownArrows = True
      Me.tbrIngredienti.ImageList = Me.ImageList1
      Me.tbrIngredienti.Location = New System.Drawing.Point(216, 220)
      Me.tbrIngredienti.Name = "tbrIngredienti"
      Me.tbrIngredienti.ShowToolTips = True
      Me.tbrIngredienti.Size = New System.Drawing.Size(528, 26)
      Me.tbrIngredienti.TabIndex = 11
      Me.tbrIngredienti.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.tbrIngredienti.Wrappable = False
      '
      'NuovoIng
      '
      Me.NuovoIng.ImageIndex = 0
      Me.NuovoIng.Name = "NuovoIng"
      Me.NuovoIng.Tag = "NuovoIng"
      Me.NuovoIng.Text = "Nuovo"
      Me.NuovoIng.ToolTipText = "Nuovo  ingrediente"
      '
      'ModificaIng
      '
      Me.ModificaIng.ImageIndex = 1
      Me.ModificaIng.Name = "ModificaIng"
      Me.ModificaIng.Tag = "ModificaIng"
      Me.ModificaIng.Text = "Apri"
      Me.ModificaIng.ToolTipText = "Apri ingrediente "
      '
      'EliminaIng
      '
      Me.EliminaIng.ImageIndex = 2
      Me.EliminaIng.Name = "EliminaIng"
      Me.EliminaIng.Tag = "EliminaIng"
      Me.EliminaIng.Text = "Elimina"
      Me.EliminaIng.ToolTipText = "Elimina ingrediente"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmElencoProdotti
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(744, 426)
      Me.Controls.Add(Me.tbrIngredienti)
      Me.Controls.Add(Me.DataGrid2)
      Me.Controls.Add(Me.lstCategorie)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Controls.Add(Me.Label3)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmElencoProdotti"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco prodotti"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("WSProdotti") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSProdotti") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AProdotti") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AProdotti"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LProdotti") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LProdotti"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("ProdottiX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("ProdottiX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("ProdottiY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("ProdottiY")))
            End If

            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         DatiConfig.SetValue("WSProdotti", Me.WindowState)
         DatiConfig.SetValue("ProdottiX", Me.Location.X)
         DatiConfig.SetValue("ProdottiY", Me.Location.Y)
         DatiConfig.SetValue("AProdotti", Me.Height)
         DatiConfig.SetValue("LProdotti", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Prodotti
               If operatore.AnagProdotti = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
                  NuovoIng.Enabled = False
                  ModificaIng.Enabled = False
                  EliminaIng.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
                  NuovoIng.Enabled = True
                  ModificaIng.Enabled = True
                  EliminaIng.Enabled = True
               End If
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Sub registraModifica(ByVal prodotto As String, ByVal articoloProdotto As String)
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         Dim descrizione As String

         If prodotto = String.Empty Then
            ' Registra loperazione effettuata dall'operatore identificato.
            descrizione = "(" & prodotto & ")"
         Else
            ' Registra loperazione effettuata dall'operatore identificato.
            descrizione = "(" & prodotto & " - " & articoloProdotto & ")"
         End If

         g_frmMain.RegistraOperazione(TipoOperazione.Modifica, descrizione, MODULO_ANAGRAFICA_PRODOTTI)

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
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Categoria = '{1}'", tabella, FormattaApici(lstCategorie.SelectedItem))
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
         If closeOnExit Then cn.Close()

         If TestoRicerca.Text <> "" Then
            numPagine = 1
         Else
            ' Ottiene il numero di pagine.
            numPagine = (numRecord + DIM_PAGINA_GRANDE - 1) \ DIM_PAGINA_GRANDE 'dimPagina
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

         Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare il prodotto """ & descrizione & _
                           """? Verranno eliminati anche gli eventuali articoli collegati." & vbCrLf & vbCrLf & _
                           "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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

            ' Elimina eventuali Ingredienti associati.
            '-------------------------------------------------------------------------------
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM ArticoliProdotti WHERE Id_Prodotto = {0}", id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
            '-------------------------------------------------------------------------------

            ' Conferma la transazione.
            tr.Commit()

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & descrizione & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_ANAGRAFICA_PRODOTTI)

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
         AggiornaDatiArticoliProdotti(id)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
         ConvalidaDatiArticoliProdotti()
      End Try
   End Sub

   Public Sub EliminaDatiArticoliProdotti(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim descrizione As String = DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 1)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare l'articolo """ & descrizione & _
                           """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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

            ' Conferma la transazione.
            tr.Commit()

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " - " & descrizione & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_ANAGRAFICA_PRODOTTI)

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
         FiltraDatiArticoliProdotti(CInt(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstCategorie.SelectedItem)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_PRODOTTI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(pagCorrente, sql)

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiArticoliProdotti(ByVal id As Integer)
      Try
         If numRecord <> 0 Then
            FiltraDatiArticoliProdotti(CInt(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGrigliaArticoliProdotti()
         Else
            FiltraDatiArticoliProdotti(id)

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGrigliaArticoliProdotti()
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

         ' Articoli prodotti.
         NuovoIng.Enabled = False
         ConvalidaDatiArticoliProdotti()
      Else
         ' Disattiva i pulsanti appropriati.
         Modifica.Enabled = True
         Elimina.Enabled = True
         Aggiorna.Enabled = True

         ' Se Ë attivo il modulo Magazzino.
         If moduloAttivo.Magazzino = True Then
            ' Articoli prodotti.
            NuovoIng.Enabled = True
            ConvalidaDatiArticoliProdotti()
         Else
            ' Disattiva i pulsanti appropriati.
            NuovoIng.Enabled = False
            ModificaIng.Enabled = False
            EliminaIng.Enabled = False
         End If
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.Prodotti) = True Then
         ImpostaComandi()
      End If
   End Sub

   Public Sub ConvalidaDatiArticoliProdotti()
      ' Se Ë attivo il modulo Magazzino.
      If moduloAttivo.Magazzino = True Then
         If numRecordArticoliProdotti = 0 Then
            ' Disattiva i pulsanti appropriati.
            ModificaIng.Enabled = False
            EliminaIng.Enabled = False
         Else
            ' Disattiva i pulsanti appropriati.
            ModificaIng.Enabled = True
            EliminaIng.Enabled = True
         End If
      Else
         ' Disattiva i pulsanti appropriati.
         NuovoIng.Enabled = False
         ModificaIng.Enabled = False
         EliminaIng.Enabled = False
      End If
   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se Ë un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_PRODOTTI)) = True Then
                  Exit Sub
               End If
            End If
         End If

         'Dim frm As New frmProdotti
         'frm.Tag = val
         'frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ApriDatiArticoliProdotti(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim frm As New Ingredienti(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase("Prodotto:  " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)) & _
                                                  " - ( Costo di produzione del prodotto: Ä " & _
                                                  CalcolaCostoProdotto("Articoli", CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))) & " )"
         Else
            DataGrid1.CaptionText = Strings.UCase("Prodotto:")
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGrigliaArticoliProdotti()
      Try
         If numRecordArticoliProdotti <> 0 Then
            DataGrid2.CaptionText = Strings.UCase("Articolo:  " & DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 1))
         Else
            DataGrid2.CaptionText = Strings.UCase("Articolo:")
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n∞ totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonneProdotti(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 80
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
         '' Quantit‡ venduta
         'Dim qt‡VendutaStyle As New DataGridTextBoxColumn
         'qt‡VendutaStyle.MappingName = "Qt‡Venduta"
         'qt‡VendutaStyle.HeaderText = "Q.t‡ venduta"
         'qt‡VendutaStyle.Width = 70
         'qt‡VendutaStyle.NullText = ""
         'qt‡VendutaStyle.Alignment = HorizontalAlignment.Right
         'qt‡VendutaStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(qt‡VendutaStyle)
         '' Valore venduto
         'Dim valVendutoStyle As New DataGridTextBoxColumn
         'valVendutoStyle.MappingName = "ValVenduto"
         'valVendutoStyle.HeaderText = "Val. venduto"
         'valVendutoStyle.Width = 70
         'valVendutoStyle.NullText = ""
         'valVendutoStyle.Alignment = HorizontalAlignment.Right
         'valVendutoStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(valVendutoStyle)
         ' Listino1
         Dim listino1Style As New DataGridTextBoxColumn
         listino1Style.MappingName = "Listino1"
         listino1Style.HeaderText = "Listino 1"
         listino1Style.Width = 60
         listino1Style.NullText = ""
         listino1Style.Format = "##,##0.00"
         listino1Style.Alignment = HorizontalAlignment.Right
         listino1Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(listino1Style)
         ' Listino2
         Dim listino2Style As New DataGridTextBoxColumn
         listino2Style.MappingName = "Listino2"
         listino2Style.HeaderText = "Listino 2"
         listino2Style.Width = 60
         listino2Style.NullText = ""
         listino2Style.Format = "##,##0.00"
         listino2Style.Alignment = HorizontalAlignment.Right
         listino2Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(listino2Style)
         ' Listino3
         Dim listino3Style As New DataGridTextBoxColumn
         listino3Style.MappingName = "Listino3"
         listino3Style.HeaderText = "Listino 3"
         listino3Style.Width = 60
         listino3Style.NullText = ""
         listino3Style.Format = "##,##0.00"
         listino3Style.Alignment = HorizontalAlignment.Right
         listino2Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(listino3Style)
         ' Listino4
         Dim listino4Style As New DataGridTextBoxColumn
         listino4Style.MappingName = "Listino4"
         listino4Style.HeaderText = "Listino 4"
         listino4Style.Width = 60
         listino4Style.NullText = ""
         listino4Style.Format = "##,##0.00"
         listino4Style.Alignment = HorizontalAlignment.Right
         listino4Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(listino4Style)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneArticoliProdotti(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 80
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 310
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Unit‡ di misura
         Dim umStyle As New DataGridTextBoxColumn
         umStyle.MappingName = "Unit‡Misura"
         umStyle.HeaderText = "U.M."
         umStyle.Width = 60
         umStyle.NullText = ""
         umStyle.Alignment = HorizontalAlignment.Center
         umStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(umStyle)
         ' Quantit‡
         Dim giacenzaStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         giacenzaStyle.MappingName = "Quantit‡"
         giacenzaStyle.HeaderText = "Quantit‡"
         giacenzaStyle.Width = 70
         giacenzaStyle.NullText = ""
         giacenzaStyle.Format = "##,##0.00"
         giacenzaStyle.Alignment = HorizontalAlignment.Right
         giacenzaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(giacenzaStyle)
         ' Costo
         'Dim pAcquistoStyle As New DataGridTextBoxColumn
         'pAcquistoStyle.MappingName = "Costo"
         'pAcquistoStyle.HeaderText = "Costo"
         'pAcquistoStyle.Width = 110
         'pAcquistoStyle.NullText = ""
         'pAcquistoStyle.Format = "##,##0.00"
         'pAcquistoStyle.Alignment = HorizontalAlignment.Right
         'pAcquistoStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(pAcquistoStyle)

         DataGrid2.TableStyles.Clear()
         DataGrid2.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String, ByVal categoria As String)
      Try
         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Codice"
               campoRicerca = "Id"
               'Case "Quantit‡ venduta"
               '   campoRicerca = "Qt‡Venduta"
               'Case "Valore venduto"
               '   campoRicerca = "ValVenduto"
               'Case "Escludi dal men˘"
               '   campoRicerca = "EscludiMenu"
            Case "Listino 1"
               campoRicerca = "Listino1"
            Case "Listino 2"
               campoRicerca = "Listino2"
            Case "Listino 3"
               campoRicerca = "Listino3"
            Case "Listino 4"
               campoRicerca = "Listino4"
         End Select

         If testoRicerca <> "" Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' AND Categoria = '{2}' ORDER BY {3} ASC", TAB_PRODOTTI, campoRicerca, FormattaApici(categoria), campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' AND Categoria = '{2}' ORDER BY {3} ASC", TAB_PRODOTTI, campoRicerca, FormattaApici(categoria), campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Categoria = '{2}' ORDER BY Id ASC", DIM_PAGINA_GRANDE, TAB_PRODOTTI, FormattaApici(categoria))
            repSql = String.Format("SELECT * FROM {0} WHERE Categoria = '{1}' ORDER BY Id ASC", TAB_PRODOTTI, FormattaApici(categoria))

            'repSql = String.Format("SELECT TOP {0} * INTO RepClienti FROM {1} ORDER BY Id ASC", DIM_PAGINA_STAT, NomeTabella)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_PRODOTTI, sql)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         If numRecord <> 0 Then
            FiltraDatiArticoliProdotti(CInt(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
         Else
            FiltraDatiArticoliProdotti(0)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDatiArticoliProdotti(ByVal id_prodotto As Integer)
      Try
         Dim sqlArticoliProdotti As String = String.Format("SELECT * FROM {0} WHERE Id_Prodotto = {1} ORDER BY Id ASC", TAB_ARTICOLI_PRODOTTI, id_prodotto)

         DataGrid2.DataSource = dtArticoliProdotti

         ' Apre la connessione.
         cn.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sqlArticoliProdotti, cn)

         ' Pulisce la tabella da precedenti dati.
         dtArticoliProdotti.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dtArticoliProdotti)

         numRecordArticoliProdotti = LeggiNumRecordIngredienti(TAB_ARTICOLI_PRODOTTI, id_prodotto)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDatiArticoliProdotti()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGrigliaArticoliProdotti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaCampiRic()
      Try
         CampoRicerca.Items.Add("Codice")
         CampoRicerca.Items.Add("Descrizione")
         'CampoRicerca.Items.Add("Quantit‡ venduta")
         'CampoRicerca.Items.Add("Valore venduto")
         CampoRicerca.Items.Add("Listino 1")
         CampoRicerca.Items.Add("Listino 2")
         CampoRicerca.Items.Add("Listino 3")
         CampoRicerca.Items.Add("Listino 4")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Function LeggiNumRecordIngredienti(ByVal tabella As String, ByVal id_prodotto As Integer) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Id_Prodotto = {1}", tabella, id_prodotto)
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

   Public Function CalcolaCostoProdotto(ByVal tabella As String, ByVal idProdotto As String) As Double
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim numRec As Integer
      Dim prezzoUnitario As Double
      Dim costoArticoloProdotto As Double
      Dim costoProdotto As Double

      Try
         cn.Open()

         ' Ottiene il numero di Articoli.
         Dim cmdNumRec As New OleDbCommand("SELECT COUNT(*) FROM ArticoliProdotti WHERE Id_Prodotto = " & idProdotto, cn)
         numRec = CInt(cmdNumRec.ExecuteScalar())

         Dim idArticolo(numRec - 1) As Integer
         Dim quantit‡ArticoliProdotti(numRec - 1) As Double

         ' Legge i dati degli Articoli del prodotto.
         Dim cmd As New OleDbCommand("SELECT * FROM ArticoliProdotti WHERE Id_Prodotto = " & idProdotto & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         ' Dati Articoli.
         Dim i As Integer = 0
         Do While dr.Read
            idArticolo(i) = CStr(dr.Item("Id_Articolo"))
            quantit‡ArticoliProdotti(i) = CDbl(dr.Item("Quantit‡"))
            i += 1
         Loop

         ' Libero le risorse.
         i = 0
         cmd.Dispose()
         dr.Close()

         Dim cmd1 As OleDbCommand
         Dim dr1 As OleDbDataReader
         For i = 0 To numRec - 1
            ' Leggo l'Articolo e recupero il prezzo di acquisto.
            cmd1 = New OleDbCommand("SELECT PrezzoAcquisto FROM " & tabella & " WHERE Id = " & idArticolo(i), cn)
            dr1 = cmd1.ExecuteReader()

            Do While dr1.Read
               prezzoUnitario = CDec(dr1.Item("PrezzoAcquisto"))
            Loop

            ' Libero le risorse.
            cmd1.Dispose()
            dr1.Close()

            ' Calcola il costo totale del prodotto.
            costoArticoloProdotto = (prezzoUnitario * quantit‡ArticoliProdotti(i))
            costoProdotto = costoProdotto + costoArticoloProdotto
            costoArticoloProdotto = 0
         Next i

         Return CFormatta.FormattaNumeroDouble(costoProdotto)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()
      End Try
   End Function

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try

         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
            Dim cn As New OleDbConnection(ConnString)

            cn.Open()

            Dim oleAdapter As New OleDbDataAdapter

            oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

            Dim ds As New Dataset1

            ds.Clear()

            oleAdapter.Fill(ds, tabella)

            Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            rep.Load(Application.StartupPath & nomeDoc)

            rep.SetDataSource(ds)

            rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True, _
                               PrintDialog1.PrinterSettings.FromPage, _
                               PrintDialog1.PrinterSettings.ToPage)

            cn.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmElencoProdotti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonneProdotti(TAB_PRODOTTI)
         ' Crea le colonne della griglia dati.
         CreaColonneArticoliProdotti(TAB_ARTICOLI_PRODOTTI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         ' Carica la lista delle categorie dei piatti.
         CaricaListaProdotti(lstCategorie, TAB_CATEGORIE)

         ' Seleziona il primo elemento della lista categorie.
         If lstCategorie.Items.Count <> 0 Then
            lstCategorie.SelectedIndex = 0
         End If

         ' Filtra i dati in base al testo digitato.
         FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstCategorie.SelectedItem)
         If numRecord <> 0 Then
            FiltraDatiArticoliProdotti(CInt(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_ANAGRAFICA_PRODOTTI, MODULO_ANAGRAFICA_PRODOTTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmElencoProdotti_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmProdotti)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmProdotti.Dispose()
         g_frmProdotti = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_ANAGRAFICA_PRODOTTI, MODULO_ANAGRAFICA_PRODOTTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Nuovo"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_ANAGRAFICA_PRODOTTI, MODULO_ANAGRAFICA_PRODOTTI)

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDati("")

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

         Case "Modifica"
            ' Registra loperazione efettuata dall'operatore identificato.
            registraModifica(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), String.Empty)

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

         Case "Elimina"
            ' Elimina il valore selezionato.
            EliminaDati(TAB_PRODOTTI, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_ANAGRAFICA_PRODOTTI, MODULO_ANAGRAFICA_PRODOTTI)

            StampaDocumento(PERCORSO_REP_PRODOTTI, TAB_PRODOTTI, repSql)

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_ANAGRAFICA_PRODOTTI, MODULO_ANAGRAFICA_PRODOTTI)

            g_frmMain.ApriReports(repSql, TAB_PRODOTTI, PERCORSO_REP_PRODOTTI)

         Case "Primo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, TAB_PRODOTTI)

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Precedente"
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} ORDER BY Id DESC) ORDER BY Id", TAB_PRODOTTI, dimPagina, TAB_PRODOTTI, dt.Rows(0)("Id"))

            ' Visualizza la pagina di dati precedente.
            VisualizzaPagina(pagCorrente - 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Successivo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} ORDER BY Id", dimPagina, TAB_PRODOTTI, dt.Rows(dt.Rows.Count - 1)("Id"))

            ' Visualizza la pagina di dati successiva.
            VisualizzaPagina(pagCorrente + 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Ultimo"
            Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} ORDER BY Id DESC) ORDER BY Id", TAB_PRODOTTI, num, TAB_PRODOTTI)

            ' Visualizza l'ultima pagina di dati.
            VisualizzaPagina(numPagine, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_ANAGRAFICA_PRODOTTI, MODULO_ANAGRAFICA_PRODOTTI)

            ' Aggiorna la griglia dati.
            AggiornaDati()

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

      End Select
   End Sub

   Private Sub ToolBar2_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrIngredienti.ButtonClick
      Select Case e.Button.Tag
         Case "NuovoIng"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_ANAGRAFICA_PRODOTTI, MODULO_ANAGRAFICA_PRODOTTI)

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDatiArticoliProdotti("")

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDatiArticoliProdotti()

         Case "ModificaIng"
            registraModifica(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 1))

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDatiArticoliProdotti(CStr(DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 0)))

         Case "EliminaIng"
            ' Elimina il valore selezionato.
            EliminaDatiArticoliProdotti(TAB_ARTICOLI_PRODOTTI, DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 0))
      End Select
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstCategorie.SelectedItem)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstCategorie.SelectedItem)
   End Sub

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      If Modifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         registraModifica(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), String.Empty)

         ' Apre la finestra Prodotti per la modifica dei dati.
         ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      End If
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()

      If numRecord <> 0 Then
         FiltraDatiArticoliProdotti(CInt(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      Else
         FiltraDatiArticoliProdotti(0)
      End If
   End Sub

   Private Sub DataGrid2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid2.DoubleClick
      If ModificaIng.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         registraModifica(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 1))

         ' Apre la finestra Articoli prodotti per la modifica dei dati.
         ApriDatiArticoliProdotti(CStr(DataGrid2.Item(DataGrid2.CurrentCell.RowNumber, 0)))
      End If
   End Sub

   Private Sub DataGrid2_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid2.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGrigliaArticoliProdotti()
   End Sub

   Private Sub lstCategorie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCategorie.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstCategorie.SelectedItem)

      If numRecord <> 0 Then
         FiltraDatiArticoliProdotti(CInt(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      End If
   End Sub

End Class
