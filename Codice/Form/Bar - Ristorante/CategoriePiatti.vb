' Nome form:            frmPiatti
' Autore:               Luigi Montana, Montana Software
' Data creazione:       23/04/2006
' Data ultima modifica: 23/04/2006
' Descrizione:          Anagrafica Piatti.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmCategoriePiatti
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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Public WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoIcona As System.Windows.Forms.ComboBox
   Friend WithEvents lstwIcona As System.Windows.Forms.ListView
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents cmdRipristina As System.Windows.Forms.Button
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents cmdAnteprima As System.Windows.Forms.Button
   Friend WithEvents cmdImmagine As System.Windows.Forms.Button
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmbReparto As System.Windows.Forms.ComboBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCategoriePiatti))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbReparto = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.cmdImmagine = New System.Windows.Forms.Button()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.cmdAnteprima = New System.Windows.Forms.Button()
      Me.cmdRipristina = New System.Windows.Forms.Button()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.lstwIcona = New System.Windows.Forms.ListView()
      Me.cmbTipoIcona = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabPage2.SuspendLayout()
      Me.Panel2.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(548, 26)
      Me.ToolBar1.TabIndex = 0
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
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(548, 20)
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
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(548, 324)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbReparto)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(540, 298)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'cmbReparto
      '
      Me.cmbReparto.Location = New System.Drawing.Point(136, 96)
      Me.cmbReparto.Name = "cmbReparto"
      Me.cmbReparto.Size = New System.Drawing.Size(256, 21)
      Me.cmbReparto.TabIndex = 2
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(24, 96)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(48, 13)
      Me.Label1.TabIndex = 164
      Me.Label1.Text = "Reparto:"
      '
      'txtDescrizione
      '
      Me.txtDescrizione.AcceptsReturn = True
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizione.Location = New System.Drawing.Point(136, 64)
      Me.txtDescrizione.MaxLength = 0
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizione.Size = New System.Drawing.Size(368, 20)
      Me.txtDescrizione.TabIndex = 1
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(24, 64)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(65, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Descrizione:"
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Control
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(136, 32)
      Me.txtNumero.MaxLength = 5
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(104, 20)
      Me.txtNumero.TabIndex = 0
      Me.txtNumero.TabStop = False
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(24, 32)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(43, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Codice:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.cmdImmagine)
      Me.TabPage2.Controls.Add(Me.Panel2)
      Me.TabPage2.Controls.Add(Me.cmdRipristina)
      Me.TabPage2.Controls.Add(Me.Label14)
      Me.TabPage2.Controls.Add(Me.lstwIcona)
      Me.TabPage2.Controls.Add(Me.cmbTipoIcona)
      Me.TabPage2.Controls.Add(Me.Label13)
      Me.TabPage2.Controls.Add(Me.cmdColore)
      Me.TabPage2.Controls.Add(Me.Label11)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(540, 298)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Punto cassa"
      '
      'cmdImmagine
      '
      Me.cmdImmagine.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdImmagine.Location = New System.Drawing.Point(152, 232)
      Me.cmdImmagine.Name = "cmdImmagine"
      Me.cmdImmagine.Size = New System.Drawing.Size(120, 32)
      Me.cmdImmagine.TabIndex = 2
      Me.cmdImmagine.Text = "&Aggiungi immagine"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.SystemColors.Window
      Me.Panel2.Controls.Add(Me.cmdAnteprima)
      Me.Panel2.Location = New System.Drawing.Point(152, 56)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(256, 160)
      Me.Panel2.TabIndex = 203
      '
      'cmdAnteprima
      '
      Me.cmdAnteprima.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdAnteprima.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAnteprima.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnteprima.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdAnteprima.Location = New System.Drawing.Point(59, 45)
      Me.cmdAnteprima.Name = "cmdAnteprima"
      Me.cmdAnteprima.Size = New System.Drawing.Size(138, 70)
      Me.cmdAnteprima.TabIndex = 0
      Me.cmdAnteprima.TabStop = False
      Me.cmdAnteprima.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmdAnteprima.UseVisualStyleBackColor = False
      '
      'cmdRipristina
      '
      Me.cmdRipristina.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRipristina.Location = New System.Drawing.Point(288, 232)
      Me.cmdRipristina.Name = "cmdRipristina"
      Me.cmdRipristina.Size = New System.Drawing.Size(120, 32)
      Me.cmdRipristina.TabIndex = 3
      Me.cmdRipristina.Text = "&Ripristina"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(40, 56)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(57, 13)
      Me.Label14.TabIndex = 202
      Me.Label14.Text = "Anteprima:"
      '
      'lstwIcona
      '
      Me.lstwIcona.LargeImageList = Me.ImageList1
      Me.lstwIcona.Location = New System.Drawing.Point(88, 160)
      Me.lstwIcona.Name = "lstwIcona"
      Me.lstwIcona.Size = New System.Drawing.Size(56, 32)
      Me.lstwIcona.TabIndex = 2
      Me.lstwIcona.UseCompatibleStateImageBehavior = False
      Me.lstwIcona.Visible = False
      '
      'cmbTipoIcona
      '
      Me.cmbTipoIcona.Items.AddRange(New Object() {"Bevande", "Dolci", "Frutta e verdura", "Pane e panini", "Pesce", "Pizze", "Primi", "Secondi e contorni", "Varie"})
      Me.cmbTipoIcona.Location = New System.Drawing.Point(88, 136)
      Me.cmbTipoIcona.Name = "cmbTipoIcona"
      Me.cmbTipoIcona.Size = New System.Drawing.Size(56, 21)
      Me.cmbTipoIcona.TabIndex = 1
      Me.cmbTipoIcona.Visible = False
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(24, 136)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(55, 13)
      Me.Label13.TabIndex = 198
      Me.Label13.Text = "Immagine:"
      Me.Label13.Visible = False
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(152, 24)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(80, 19)
      Me.cmdColore.TabIndex = 1
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(40, 24)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(40, 13)
      Me.Label11.TabIndex = 195
      Me.Label11.Text = "Colore:"
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
      'frmCategoriePiatti
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(548, 370)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmCategoriePiatti"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Categorie piatti"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public ACatPiatti As New CategoriePiatti

   Const NOME_TABELLA As String = "CategoriePiatti"
   Const TAB_REPARTI As String = "Reparti"

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
         AggiornaTabella(cmbReparto, TAB_REPARTI)

         With ACatPiatti
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Descrizione = FormattaApici(txtDescrizione.Text)
            .Reparto = FormattaApici(cmbReparto.Text)

            If IsNothing(.Icona) = True Then
               .Icona = ""
            End If

            ACatPiatti.Colore = cmdColore.BackColor.ToArgb

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

      Finally

      End Try
   End Function

   Private Sub InserisciIcona()
      Try
         With OpenFileDialog1
            .Filter = "Ico |*.Ico"

            .FilterIndex = 1
            .InitialDirectory = Application.StartupPath & "\Immagini"

            .ShowDialog()

            ACatPiatti.Icona = .FileName

         End With

         If File.Exists(ACatPiatti.Icona) = True Then
            Dim bmp As New Bitmap(ACatPiatti.Icona)
            cmdAnteprima.Image = bmp
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaIcona()
      Try
         If Not (cmdAnteprima.Image Is Nothing) Then
            cmdAnteprima.Image.Dispose()
            cmdAnteprima.Image = Nothing
            ACatPiatti.Icona = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColore()
      Try
         With ColorDialog1()
            .Color = cmdColore.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColore.BackColor = .Color
               cmdAnteprima.BackColor = .Color
            End If

            ACatPiatti.Colore = Convert.ToString(.Color.ToArgb)

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmCategoriePiatti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With ACatPiatti
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = .Codice
               txtDescrizione.Text = .Descrizione
               cmbReparto.Text = .Reparto

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
                  cmdAnteprima.BackColor = Color.FromArgb(.Colore)
               End If

               If .Icona <> Nothing Then
                  If File.Exists(ACatPiatti.Icona) = True Then
                     Dim bmp As New Bitmap(ACatPiatti.Icona)
                     cmdAnteprima.Image = bmp
                  End If
               End If

               cmdAnteprima.Text = txtDescrizione.Text

            End With
         Else
            ' Inserisce automaticamente la categoria selezionata.
            cmdColore.BackColor = Color.White
            cmdAnteprima.BackColor = Color.White
            ACatPiatti.Colore = Convert.ToString(Color.White.ToArgb)
         End If

         ' Carica la lista.
         CaricaLista(cmbReparto, TAB_REPARTI)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, txtDescrizione.Text, "")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Imposta lo stato attivo.
         txtDescrizione.Focus()

      End Try
   End Sub

   Private Sub frmCategoriePiatti_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CAT_PIATTI)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmCatPiatti) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmCatPiatti.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & ACatPiatti.Descrizione & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_CAT_PIATTI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CAT_PIATTI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            Me.txtDescrizione.Focus()
         Case 1
            ' Imposta lo stato attivo.
            Me.cmdColore.Focus()
      End Select
   End Sub

   Private Sub cmdColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColore.Click
      ModificaColore()
   End Sub

   Private Sub cmdRipristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRipristina.Click
      cmdColore.BackColor = Color.DodgerBlue
      cmdAnteprima.BackColor = Color.DodgerBlue
      ACatPiatti.Colore = Convert.ToString(Color.DodgerBlue.ToArgb)
      EliminaIcona()
   End Sub

   Private Sub cmdImmagine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImmagine.Click
      InserisciIcona()
   End Sub

   Private Sub txtDescrizione_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescrizione.TextChanged
      cmdAnteprima.Text = txtDescrizione.Text
   End Sub

End Class

