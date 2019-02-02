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
   Friend WithEvents cmdColoreSfondo As System.Windows.Forms.Button
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoIcona As System.Windows.Forms.ComboBox
   Friend WithEvents lstwIcona As System.Windows.Forms.ListView
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents cmdRipristina As System.Windows.Forms.Button
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents cmdImmagine As System.Windows.Forms.Button
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdColoreTesto As System.Windows.Forms.Button
   Public WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents netBtn_Anteprima As Softgroup.NetButton.NetButton
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
      Me.cmdColoreTesto = New System.Windows.Forms.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdImmagine = New System.Windows.Forms.Button()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.netBtn_Anteprima = New Softgroup.NetButton.NetButton()
      Me.cmdRipristina = New System.Windows.Forms.Button()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.lstwIcona = New System.Windows.Forms.ListView()
      Me.cmbTipoIcona = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cmdColoreSfondo = New System.Windows.Forms.Button()
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
      Me.ToolBar1.Size = New System.Drawing.Size(536, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(536, 20)
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
      Me.TabControl1.Size = New System.Drawing.Size(536, 330)
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
      Me.TabPage1.Size = New System.Drawing.Size(528, 304)
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
      Me.TabPage2.Controls.Add(Me.cmdColoreTesto)
      Me.TabPage2.Controls.Add(Me.Label2)
      Me.TabPage2.Controls.Add(Me.cmdImmagine)
      Me.TabPage2.Controls.Add(Me.Panel2)
      Me.TabPage2.Controls.Add(Me.cmdRipristina)
      Me.TabPage2.Controls.Add(Me.Label14)
      Me.TabPage2.Controls.Add(Me.lstwIcona)
      Me.TabPage2.Controls.Add(Me.cmbTipoIcona)
      Me.TabPage2.Controls.Add(Me.Label13)
      Me.TabPage2.Controls.Add(Me.cmdColoreSfondo)
      Me.TabPage2.Controls.Add(Me.Label11)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(528, 304)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Punto cassa"
      '
      'cmdColoreTesto
      '
      Me.cmdColoreTesto.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTesto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTesto.Location = New System.Drawing.Point(152, 48)
      Me.cmdColoreTesto.Name = "cmdColoreTesto"
      Me.cmdColoreTesto.Size = New System.Drawing.Size(80, 19)
      Me.cmdColoreTesto.TabIndex = 1
      Me.cmdColoreTesto.UseVisualStyleBackColor = False
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(40, 48)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(66, 13)
      Me.Label2.TabIndex = 207
      Me.Label2.Text = "Colore testo:"
      '
      'cmdImmagine
      '
      Me.cmdImmagine.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdImmagine.Location = New System.Drawing.Point(152, 264)
      Me.cmdImmagine.Name = "cmdImmagine"
      Me.cmdImmagine.Size = New System.Drawing.Size(120, 32)
      Me.cmdImmagine.TabIndex = 2
      Me.cmdImmagine.Text = "&Aggiungi immagine"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel2.Controls.Add(Me.netBtn_Anteprima)
      Me.Panel2.Location = New System.Drawing.Point(152, 88)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(256, 160)
      Me.Panel2.TabIndex = 203
      '
      'netBtn_Anteprima
      '
      Me.netBtn_Anteprima.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Anteprima.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Anteprima.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Anteprima.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Anteprima.ColorText = System.Drawing.Color.White
      Me.netBtn_Anteprima.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Anteprima.CornerRadius = 2
      Me.netBtn_Anteprima.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Anteprima.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.netBtn_Anteprima.Location = New System.Drawing.Point(59, 45)
      Me.netBtn_Anteprima.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Anteprima.Name = "netBtn_Anteprima"
      Me.netBtn_Anteprima.Size = New System.Drawing.Size(138, 70)
      Me.netBtn_Anteprima.TabIndex = 0
      Me.netBtn_Anteprima.TextButton = ""
      '
      'cmdRipristina
      '
      Me.cmdRipristina.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRipristina.Location = New System.Drawing.Point(288, 264)
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
      Me.Label14.Location = New System.Drawing.Point(40, 88)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(57, 13)
      Me.Label14.TabIndex = 202
      Me.Label14.Text = "Anteprima:"
      '
      'lstwIcona
      '
      Me.lstwIcona.LargeImageList = Me.ImageList1
      Me.lstwIcona.Location = New System.Drawing.Point(80, 264)
      Me.lstwIcona.Name = "lstwIcona"
      Me.lstwIcona.Size = New System.Drawing.Size(56, 32)
      Me.lstwIcona.TabIndex = 2
      Me.lstwIcona.UseCompatibleStateImageBehavior = False
      Me.lstwIcona.Visible = False
      '
      'cmbTipoIcona
      '
      Me.cmbTipoIcona.Items.AddRange(New Object() {"Bevande", "Dolci", "Frutta e verdura", "Pane e panini", "Pesce", "Pizze", "Primi", "Secondi e contorni", "Varie"})
      Me.cmbTipoIcona.Location = New System.Drawing.Point(80, 240)
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
      Me.Label13.Location = New System.Drawing.Point(16, 240)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(55, 13)
      Me.Label13.TabIndex = 198
      Me.Label13.Text = "Immagine:"
      Me.Label13.Visible = False
      '
      'cmdColoreSfondo
      '
      Me.cmdColoreSfondo.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreSfondo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreSfondo.Location = New System.Drawing.Point(152, 24)
      Me.cmdColoreSfondo.Name = "cmdColoreSfondo"
      Me.cmdColoreSfondo.Size = New System.Drawing.Size(80, 19)
      Me.cmdColoreSfondo.TabIndex = 0
      Me.cmdColoreSfondo.UseVisualStyleBackColor = False
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
      Me.Label11.Size = New System.Drawing.Size(75, 13)
      Me.Label11.TabIndex = 195
      Me.Label11.Text = "Colore sfondo:"
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
      Me.ClientSize = New System.Drawing.Size(536, 376)
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
   Const ALTEZZA_TASTO As Integer = 50

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
               .Icona = String.Empty
            End If

            .ColoreSfondo = cmdColoreSfondo.BackColor.ToArgb
            .ColoreTesto = cmdColoreTesto.BackColor.ToArgb
            .OrdineTasto = .OrdineTasto

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(NOME_TABELLA, Me.Tag)
            Else
               .AltezzaTasto = ALTEZZA_TASTO
               .OrdineTasto = .LeggiUltimoRecord(NOME_TABELLA) + 1

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
            .Filter = "Tutti i formati |*.Ico; *.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                      "Ico (Icona di Windows)|*.Ico|" &
                      "Bmp (Bitmap di Windows)|*.Bmp|" &
                      "Gif |*.Gif|" &
                      "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                      "Png |*.Png|" &
                      "Tga |*.Tga|" &
                      "Tiff |*.Tiff|" &
                      "Wmf (Metafile di Windows) |*.Wmf"

            .FilterIndex = 1
            .InitialDirectory = Application.StartupPath & "\Immagini"

            .ShowDialog()

            ACatPiatti.Icona = .FileName

         End With

         If File.Exists(ACatPiatti.Icona) = True Then
            Dim bmp As New Bitmap(ACatPiatti.Icona)
            netBtn_Anteprima.Image = bmp
            netBtn_Anteprima.TextButtonAlign = ContentAlignment.BottomCenter
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaIcona()
      Try
         If Not (netBtn_Anteprima.Image Is Nothing) Then
            netBtn_Anteprima.Image.Dispose()
            netBtn_Anteprima.Image = Nothing
            ACatPiatti.Icona = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreSfondo()
      Try
         With ColorDialog1()
            .Color = cmdColoreSfondo.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreSfondo.BackColor = .Color
               netBtn_Anteprima.ColorBottom = .Color
            End If

            ACatPiatti.ColoreSfondo = Convert.ToString(.Color.ToArgb)

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreTesto()
      Try
         With ColorDialog1()
            .Color = cmdColoreTesto.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreTesto.BackColor = .Color
               netBtn_Anteprima.ColorText = .Color
            End If

            ACatPiatti.ColoreTesto = Convert.ToString(.Color.ToArgb)

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

               If .ColoreSfondo <> 0 Then
                  cmdColoreSfondo.BackColor = Color.FromArgb(.ColoreSfondo)
                  netBtn_Anteprima.ColorBottom = Color.FromArgb(.ColoreSfondo)
               End If

               If .ColoreTesto <> 0 Then
                  cmdColoreTesto.BackColor = Color.FromArgb(.ColoreTesto)
                  netBtn_Anteprima.ColorText = Color.FromArgb(.ColoreTesto)
               End If

               If .Icona <> Nothing Then
                  If File.Exists(ACatPiatti.Icona) = True Then
                     Dim bmp As New Bitmap(ACatPiatti.Icona)
                     netBtn_Anteprima.Image = bmp
                     netBtn_Anteprima.TextButtonAlign = ContentAlignment.BottomCenter
                  End If
               End If

               netBtn_Anteprima.TextButton = txtDescrizione.Text

            End With
         Else
            ' Imposta il colore di default.
            cmdColoreSfondo.BackColor = Color.Black
            cmdColoreTesto.BackColor = Color.White
            netBtn_Anteprima.ColorBottom = Color.Black
            netBtn_Anteprima.ColorText = Color.White
            ACatPiatti.ColoreSfondo = Convert.ToString(Color.Black.ToArgb)
            ACatPiatti.ColoreTesto = Convert.ToString(Color.White.ToArgb)
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
            ' Visualizza la descrizone sul tasto.
            netBtn_Anteprima.TextButton = txtDescrizione.Text

            ' Imposta lo stato attivo.
            Me.cmdColoreSfondo.Focus()
      End Select
   End Sub

   Private Sub cmdColoreSfondo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColoreSfondo.Click
      ModificaColoreSfondo()
   End Sub

   Private Sub cmdColoreTesto_Click(sender As Object, e As EventArgs) Handles cmdColoreTesto.Click
      ModificaColoreTesto()
   End Sub

   Private Sub cmdRipristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRipristina.Click
      cmdColoreSfondo.BackColor = Color.Black
      cmdColoreTesto.BackColor = Color.White

      netBtn_Anteprima.ColorBottom = Color.Black
      netBtn_Anteprima.ColorText = Color.White

      ACatPiatti.ColoreSfondo = Convert.ToString(Color.Black.ToArgb)
      ACatPiatti.ColoreTesto = Convert.ToString(Color.White.ToArgb)

      netBtn_Anteprima.TextButtonAlign = ContentAlignment.MiddleCenter

      EliminaIcona()
   End Sub

   Private Sub cmdImmagine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImmagine.Click
      InserisciIcona()
   End Sub

   Private Sub txtDescrizione_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescrizione.TextChanged
      netBtn_Anteprima.TextButton = txtDescrizione.Text
   End Sub

End Class

