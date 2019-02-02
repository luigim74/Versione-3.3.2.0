' Nome form:            frmSale
' Autore:               Luigi Montana, Montana Software
' Data creazione:       08/08/2006
' Data ultima modifica: 08/08/2006
' Descrizione:          Anagrafica Sale.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmSale
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
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents cmdImmagine As System.Windows.Forms.Button
   Friend WithEvents chkIniziale As System.Windows.Forms.CheckBox
   Public WithEvents Label39 As System.Windows.Forms.Label
   Friend WithEvents cmdElimina As System.Windows.Forms.Button
   Friend WithEvents picImmagine As System.Windows.Forms.PictureBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents TabPage4 As TabPage
   Friend WithEvents Panel2 As Panel
   Public WithEvents Label14 As Label
   Friend WithEvents cmdColoreSfondo As Button
   Public WithEvents Label11 As Label
   Friend WithEvents cmdColoreTesto As Button
   Public WithEvents Label1 As Label
   Friend WithEvents netBtn_Anteprima As Softgroup.NetButton.NetButton
   Friend WithEvents cmdRipristina As System.Windows.Forms.Button
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSale))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.chkIniziale = New System.Windows.Forms.CheckBox()
      Me.Label39 = New System.Windows.Forms.Label()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.picImmagine = New System.Windows.Forms.PictureBox()
      Me.cmdImmagine = New System.Windows.Forms.Button()
      Me.cmdElimina = New System.Windows.Forms.Button()
      Me.TabPage4 = New System.Windows.Forms.TabPage()
      Me.cmdRipristina = New System.Windows.Forms.Button()
      Me.cmdColoreTesto = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.netBtn_Anteprima = New Softgroup.NetButton.NetButton()
      Me.Label14 = New System.Windows.Forms.Label()
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
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage4.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(537, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(537, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage4)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(537, 331)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.chkIniziale)
      Me.TabPage1.Controls.Add(Me.Label39)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(529, 305)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'chkIniziale
      '
      Me.chkIniziale.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkIniziale.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIniziale.Location = New System.Drawing.Point(136, 96)
      Me.chkIniziale.Name = "chkIniziale"
      Me.chkIniziale.Size = New System.Drawing.Size(16, 16)
      Me.chkIniziale.TabIndex = 2
      '
      'Label39
      '
      Me.Label39.AutoSize = True
      Me.Label39.BackColor = System.Drawing.Color.Transparent
      Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label39.ForeColor = System.Drawing.Color.Black
      Me.Label39.Location = New System.Drawing.Point(152, 96)
      Me.Label39.Name = "Label39"
      Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label39.Size = New System.Drawing.Size(112, 13)
      Me.Label39.TabIndex = 164
      Me.Label39.Text = "Visualizzazione iniziale"
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
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(136, 32)
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
      Me.TabPage2.Controls.Add(Me.picImmagine)
      Me.TabPage2.Controls.Add(Me.cmdImmagine)
      Me.TabPage2.Controls.Add(Me.cmdElimina)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(529, 305)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Sfondo"
      '
      'picImmagine
      '
      Me.picImmagine.BackColor = System.Drawing.Color.White
      Me.picImmagine.Location = New System.Drawing.Point(8, 8)
      Me.picImmagine.Name = "picImmagine"
      Me.picImmagine.Size = New System.Drawing.Size(397, 288)
      Me.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picImmagine.TabIndex = 196
      Me.picImmagine.TabStop = False
      '
      'cmdImmagine
      '
      Me.cmdImmagine.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdImmagine.Location = New System.Drawing.Point(411, 8)
      Me.cmdImmagine.Name = "cmdImmagine"
      Me.cmdImmagine.Size = New System.Drawing.Size(112, 32)
      Me.cmdImmagine.TabIndex = 2
      Me.cmdImmagine.Text = "&Aggiungi immagine"
      '
      'cmdElimina
      '
      Me.cmdElimina.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdElimina.Location = New System.Drawing.Point(411, 48)
      Me.cmdElimina.Name = "cmdElimina"
      Me.cmdElimina.Size = New System.Drawing.Size(112, 32)
      Me.cmdElimina.TabIndex = 3
      Me.cmdElimina.Text = "&Rimuovi immagine"
      '
      'TabPage4
      '
      Me.TabPage4.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage4.Controls.Add(Me.cmdRipristina)
      Me.TabPage4.Controls.Add(Me.cmdColoreTesto)
      Me.TabPage4.Controls.Add(Me.Label1)
      Me.TabPage4.Controls.Add(Me.Panel2)
      Me.TabPage4.Controls.Add(Me.Label14)
      Me.TabPage4.Controls.Add(Me.cmdColoreSfondo)
      Me.TabPage4.Controls.Add(Me.Label11)
      Me.TabPage4.Location = New System.Drawing.Point(4, 22)
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Size = New System.Drawing.Size(529, 305)
      Me.TabPage4.TabIndex = 8
      Me.TabPage4.Text = "Punto cassa"
      '
      'cmdRipristina
      '
      Me.cmdRipristina.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdRipristina.Location = New System.Drawing.Point(152, 256)
      Me.cmdRipristina.Name = "cmdRipristina"
      Me.cmdRipristina.Size = New System.Drawing.Size(120, 32)
      Me.cmdRipristina.TabIndex = 2
      Me.cmdRipristina.Text = "&Ripristina"
      '
      'cmdColoreTesto
      '
      Me.cmdColoreTesto.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTesto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTesto.Location = New System.Drawing.Point(152, 49)
      Me.cmdColoreTesto.Name = "cmdColoreTesto"
      Me.cmdColoreTesto.Size = New System.Drawing.Size(80, 19)
      Me.cmdColoreTesto.TabIndex = 1
      Me.cmdColoreTesto.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(40, 49)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(66, 13)
      Me.Label1.TabIndex = 205
      Me.Label1.Text = "Colore testo:"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel2.Controls.Add(Me.netBtn_Anteprima)
      Me.Panel2.Location = New System.Drawing.Point(152, 86)
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
      Me.netBtn_Anteprima.Location = New System.Drawing.Point(59, 40)
      Me.netBtn_Anteprima.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Anteprima.Name = "netBtn_Anteprima"
      Me.netBtn_Anteprima.Size = New System.Drawing.Size(138, 70)
      Me.netBtn_Anteprima.TabIndex = 0
      Me.netBtn_Anteprima.TextButton = ""
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(40, 86)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(57, 13)
      Me.Label14.TabIndex = 202
      Me.Label14.Text = "Anteprima:"
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
      'frmSale
      '
      Me.AcceptButton = Me.cmdImmagine
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(537, 377)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSale"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Sale"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage4.ResumeLayout(False)
      Me.TabPage4.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni"

   Public ASale As New Sale

   Const NOME_TABELLA As String = "Sale"
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

#End Region

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Function SalvaDati() As Boolean
      Try
         With ASale
            ' Assegna i dati dei campi della classe alle caselle di testo.
            If txtDescrizione.Text = String.Empty Then
               MessageBox.Show("Specificare una descrizione per la Sala!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               txtDescrizione.Focus()
               Return False
            Else
               .Descrizione = FormattaApici(txtDescrizione.Text)
            End If

            If chkIniziale.Checked = True Then
               .Iniziale = "Sì"
               .ModificaCampoIniziale(NOME_TABELLA)
            Else
               .Iniziale = "No"
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

   Private Sub InserisciImmagine()
      Try
         OpenFileDialog1.InitialDirectory = Application.StartupPath & "\Piantine"

         OpenFileDialog1.Filter = "Tutti i formati |*.Ico; *.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                                  "Ico (Icona di Windows)|*.Ico|" &
                                  "Bmp (Bitmap di Windows)|*.Bmp|" &
                                  "Gif |*.Gif|" &
                                  "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                                  "Png |*.Png|" &
                                  "Tga |*.Tga|" &
                                  "Tiff |*.Tiff|" &
                                  "Wmf (Metafile di Windows) |*.Wmf"

         OpenFileDialog1.FilterIndex = 1
         OpenFileDialog1.ShowDialog()

         ASale.Sfondo = OpenFileDialog1.FileName

         If File.Exists(ASale.Sfondo) = True Then
            Dim bmp As New Bitmap(ASale.Sfondo)
            picImmagine.Image = bmp
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaImmagine()
      Try
         If Not (picImmagine.Image Is Nothing) Then
            picImmagine.Image.Dispose()
            picImmagine.Image = Nothing
            ASale.Sfondo = ""
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

            ASale.ColoreSfondo = Convert.ToString(.Color.ToArgb)

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

            ASale.ColoreTesto = Convert.ToString(.Color.ToArgb)

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With ASale
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtDescrizione.Text = .Descrizione

               If .Iniziale = "Sì" Then
                  chkIniziale.Checked = True
               Else
                  chkIniziale.Checked = False
               End If

               If .ColoreSfondo <> 0 Then
                  cmdColoreSfondo.BackColor = Color.FromArgb(.ColoreSfondo)
                  netBtn_Anteprima.ColorBottom = Color.FromArgb(.ColoreSfondo)
               End If

               If .ColoreTesto <> 0 Then
                  cmdColoreTesto.BackColor = Color.FromArgb(.ColoreTesto)
                  netBtn_Anteprima.ColorText = Color.FromArgb(.ColoreTesto)
               End If

               If .Sfondo <> Nothing Then
                  If File.Exists(.Sfondo) = True Then
                     Dim bmp As New Bitmap(.Sfondo)
                     picImmagine.Image = bmp
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
            ASale.ColoreSfondo = Convert.ToString(Color.Black.ToArgb)
            ASale.ColoreTesto = Convert.ToString(Color.White.ToArgb)
         End If

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtDescrizione.Text, "")

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

   Private Sub frmSale_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_SALE)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmSale) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmSale.AggiornaDati()
               End If

               'If IsNothing(g_frmVCTavoli) = False Then
               '   ' Aggiorna Visual Chef
               '   g_frmVCTavoli.AggiornaVCTavoli()
               'End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & ASale.Descrizione & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_SALE)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_SALE)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            txtDescrizione.Focus()
         Case 1
            ' Imposta lo stato attivo.
            cmdImmagine.Focus()
         Case 2
            ' Visualizza la descrizone sul tasto.
            netBtn_Anteprima.TextButton = txtDescrizione.Text

            ' Imposta lo stato attivo.
            Me.cmdColoreSfondo.Focus()
      End Select
   End Sub

   Private Sub cmdImmagine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImmagine.Click
      InserisciImmagine()
   End Sub

   Private Sub cmdElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElimina.Click
      EliminaImmagine()
   End Sub

   Private Sub cmdColoreSfondo_Click(sender As Object, e As EventArgs) Handles cmdColoreSfondo.Click
      ModificaColoreSfondo()
   End Sub

   Private Sub cmdColoreTesto_Click(sender As Object, e As EventArgs) Handles cmdColoreTesto.Click
      ModificaColoreTesto()
   End Sub

   Private Sub cmdRipristina_Click(sender As Object, e As EventArgs) Handles cmdRipristina.Click
      cmdColoreSfondo.BackColor = Color.Black
      cmdColoreTesto.BackColor = Color.White

      netBtn_Anteprima.ColorBottom = Color.Black
      netBtn_Anteprima.ColorText = Color.White

      ASale.ColoreSfondo = Convert.ToString(Color.Black.ToArgb)
      ASale.ColoreTesto = Convert.ToString(Color.White.ToArgb)
   End Sub
End Class

