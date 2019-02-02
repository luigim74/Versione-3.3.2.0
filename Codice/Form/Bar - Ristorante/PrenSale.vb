' Nome form:            frmPrenSale
' Autore:               Luigi Montana, Montana Software
' Data creazione:       24/08/2006
' Data ultima modifica: 24/08/2006
' Descrizione:          Scheda prenotazione Sale.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmPrenSale
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(Optional ByVal pData As String = "", Optional ByVal pRisorsa As String = "", Optional ByVal pOra As String = "")
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      Risorsa = pRisorsa
      Ora = pOra
      Data = pData
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
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
   Friend WithEvents cmbRisorsa As System.Windows.Forms.ComboBox
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents txtPersone As System.Windows.Forms.TextBox
   Friend WithEvents cmbIdCliente As System.Windows.Forms.ComboBox
   Friend WithEvents dtpOraInizio As System.Windows.Forms.DateTimePicker
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents dtpOraFine As System.Windows.Forms.DateTimePicker
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrenSale))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.dtpOraFine = New System.Windows.Forms.DateTimePicker()
      Me.dtpOraInizio = New System.Windows.Forms.DateTimePicker()
      Me.cmbIdCliente = New System.Windows.Forms.ComboBox()
      Me.txtPersone = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cmbRisorsa = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmbCliente = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(544, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(544, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(544, 322)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.dtpOraFine)
      Me.TabPage1.Controls.Add(Me.dtpOraInizio)
      Me.TabPage1.Controls.Add(Me.cmbIdCliente)
      Me.TabPage1.Controls.Add(Me.txtPersone)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.cmbRisorsa)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.cmbCliente)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.dtpData)
      Me.TabPage1.Controls.Add(Me.cmdColore)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(536, 296)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'dtpOraFine
      '
      Me.dtpOraFine.CustomFormat = ""
      Me.dtpOraFine.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraFine.Location = New System.Drawing.Point(128, 216)
      Me.dtpOraFine.Name = "dtpOraFine"
      Me.dtpOraFine.ShowUpDown = True
      Me.dtpOraFine.Size = New System.Drawing.Size(80, 20)
      Me.dtpOraFine.TabIndex = 6
      Me.dtpOraFine.Value = New Date(2006, 8, 23, 0, 0, 0, 0)
      '
      'dtpOraInizio
      '
      Me.dtpOraInizio.CustomFormat = ""
      Me.dtpOraInizio.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraInizio.Location = New System.Drawing.Point(128, 184)
      Me.dtpOraInizio.Name = "dtpOraInizio"
      Me.dtpOraInizio.ShowUpDown = True
      Me.dtpOraInizio.Size = New System.Drawing.Size(80, 20)
      Me.dtpOraInizio.TabIndex = 5
      Me.dtpOraInizio.Value = New Date(2006, 8, 23, 0, 0, 0, 0)
      '
      'cmbIdCliente
      '
      Me.cmbIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdCliente.Location = New System.Drawing.Point(424, 112)
      Me.cmbIdCliente.Name = "cmbIdCliente"
      Me.cmbIdCliente.Size = New System.Drawing.Size(70, 21)
      Me.cmbIdCliente.TabIndex = 203
      Me.cmbIdCliente.Visible = False
      '
      'txtPersone
      '
      Me.txtPersone.Location = New System.Drawing.Point(128, 152)
      Me.txtPersone.Name = "txtPersone"
      Me.txtPersone.Size = New System.Drawing.Size(80, 20)
      Me.txtPersone.TabIndex = 4
      Me.txtPersone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(24, 152)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(49, 13)
      Me.Label11.TabIndex = 202
      Me.Label11.Text = "Persone:"
      '
      'cmbRisorsa
      '
      Me.cmbRisorsa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRisorsa.Location = New System.Drawing.Point(128, 120)
      Me.cmbRisorsa.Name = "cmbRisorsa"
      Me.cmbRisorsa.Size = New System.Drawing.Size(200, 21)
      Me.cmbRisorsa.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(24, 120)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(31, 13)
      Me.Label3.TabIndex = 199
      Me.Label3.Text = "Sala:"
      '
      'cmbCliente
      '
      Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCliente.Location = New System.Drawing.Point(128, 88)
      Me.cmbCliente.Name = "cmbCliente"
      Me.cmbCliente.Size = New System.Drawing.Size(368, 21)
      Me.cmbCliente.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(24, 216)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(45, 13)
      Me.Label2.TabIndex = 197
      Me.Label2.Text = "Alle ore:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(24, 56)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(33, 13)
      Me.Label1.TabIndex = 195
      Me.Label1.Text = "Data:"
      '
      'dtpData
      '
      Me.dtpData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpData.Location = New System.Drawing.Point(132, 56)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 1
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(128, 248)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(80, 19)
      Me.cmdColore.TabIndex = 7
      Me.cmdColore.TabStop = False
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(24, 248)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(40, 13)
      Me.Label8.TabIndex = 193
      Me.Label8.Text = "Colore:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(24, 184)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(52, 13)
      Me.Label6.TabIndex = 191
      Me.Label6.Text = "Dalle ore:"
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Control
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(128, 24)
      Me.txtNumero.MaxLength = 0
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(120, 20)
      Me.txtNumero.TabIndex = 0
      Me.txtNumero.TabStop = False
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(24, 24)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(43, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Codice:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(24, 88)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(42, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Cliente:"
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(536, 296)
      Me.TabPage6.TabIndex = 5
      Me.TabPage6.Text = "Note"
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
      'frmPrenSale
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(544, 368)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPrenSale"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Prenotazione Sala"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   ' B_TODO: VER. FUTURA.
   'Public IAllegati As New Allegati
   ' B_TODO: VER. FUTURA.
   'Const TAB_ALLEGATI As String = "Allegati"

   Dim Ora As String
   Dim Risorsa As String
   Dim Data As String

   Private IPren As New Prenotazione
   Private CConvalida As New ConvalidaKeyPress

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_SALE As String = "Sale"
   Const NOME_TABELLA As String = "PrenSale"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Private Function SalvaDati() As Boolean
      Try
         With IPren
            ' Assegna i dati dei campi della classe alle caselle di testo.
            If dtpData.Value < Date.Today Then
               MessageBox.Show("Data non valida! La data di una prenotazione non può essere passata.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpData.Focus()
               Return False
            Else
               ' Formato italiano.
               .Data = FormattaData(dtpData.Value, True)
            End If

            If cmbCliente.Text = String.Empty Then
               MessageBox.Show("Specificare il nome di un cliente!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               cmbCliente.Focus()
               Return False
            Else
               .Cliente = FormattaApici(cmbCliente.Text)
            End If

            .IdRisorsa = LeggiIdRisorsa(ANA_SALE, cmbRisorsa.Text)
            .DescrizioneRisorsa = FormattaApici(cmbRisorsa.Text)

            ' Controllo sul campo Persone.
            If txtPersone.Text <> "0" And txtPersone.Text <> String.Empty Then
               .Persone = txtPersone.Text
            Else
               MessageBox.Show("Numero di persone non valido! Specificare un numero di uno o più persone.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               txtPersone.Focus()
               Return False
            End If

            ' Controllo sul campo Ore.
            Dim timeInizio As DateTime = dtpOraInizio.Value
            Dim timeFine As DateTime = dtpOraFine.Value
            Dim timeIntervallo As DateTime = dtpOraInizio.Value.AddMinutes(30)
            Dim messaggio As String = "Ore non valide!" & vbCrLf & _
                                      "Le ore di una prenotazione non possono essere invertite, ravvicinate o passate. " & vbCrLf & _
                                      "Specificare un intervallo di ore di almeno trenta minuti."
            ' Se l'ora è uguale.
            If timeInizio = timeFine Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False

            ElseIf timeFine < timeInizio Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False

            ElseIf timeInizio < DateTime.Now And dtpData.Value = Date.Today Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraInizio.Focus()
               Return False

            ElseIf timeFine < DateTime.Now And dtpData.Value = Date.Today Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False

            ElseIf timeFine < timeIntervallo Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False
            Else
               .OraInizio = RimuoviSecondi(dtpOraInizio.Text)
               .OraFine = RimuoviSecondi(dtpOraFine.Text)
            End If

            .Note = FormattaApici(txtNote.Text)

            If .Colore = 0 Then
               .Colore = Convert.ToInt32(Color.White.ToArgb)
            End If

            '  Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
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

   Private Sub ModificaColore()
      Try
         With ColorDialog1()
            .Color = cmdColore.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColore.BackColor = .Color
            End If

            IPren.Colore = Convert.ToString(.Color.ToArgb)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Public Sub RimuoviAllegati(ByVal tabella As String, ByVal id As Integer)
      'Try
      '   Dim Risposta As Short
      '   Dim sql As String

      '   Dim Documento As String = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text

      '   ' Chiede conferma per l'eliminazione.
      '   Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf & _
      '                     "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

      '   If Risposta = MsgBoxResult.Yes Then
      '      ' Apre la connessione.
      '      cn.Open()

      '      ' Avvia una transazione.
      '      tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

      '      ' Crea la stringa di eliminazione.
      '      sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

      '      ' Crea il comando per la connessione corrente.
      '      Dim cmdDelete As New OleDbCommand(sql, cn, tr)

      '      ' Esegue il comando.
      '      Dim Record As Integer = cmdDelete.ExecuteNonQuery()

      '      ' Conferma la transazione.
      '      tr.Commit()

      '   End If

      'Catch ex As Exception
      '   ' Annulla la transazione.
      '   tr.Rollback()

      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   'err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   ' Chiude la connessione.
      '   cn.Close()
      'End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      'Try
      '   OpenFileDialog1.Filter = "Tutti i file |*.*"

      '   OpenFileDialog1.FilterIndex = 1

      '   IAllegati.IdCliente = CInt(IPren.IdCliente)

      '   If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
      '      ' Assegna i dati dei campi della classe alle caselle di testo.
      '      IAllegati.Documento = Path.GetFileName(OpenFileDialog1.FileName)
      '      IAllegati.Data = CStr(Today)
      '      IAllegati.Ora = CStr(TimeOfDay)
      '      IAllegati.Percorso = OpenFileDialog1.FileName
      '      IAllegati.Estensione = Path.GetExtension(OpenFileDialog1.FileName)
      '   Else
      '      If ins = True Then
      '         Return False
      '      End If
      '   End If

      '   Dim val As String
      '   val = InputBox("Digitare il testo per il campo Note.", "Note", note)
      '   If val <> "" Then
      '      IAllegati.Note = val
      '   Else
      '      IAllegati.Note = note
      '   End If

      '   Return True

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Function

   ' B_TODO: VER. FUTURA.
   Private Sub ConvalidaAllegati()
      '' Carica la lista dei componenti aggiuntivi.
      'If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, IPren.IdCliente) = True Then
      '   cmdModifica.Enabled = True
      '   cmdRimuovi.Enabled = True
      'Else
      '   cmdModifica.Enabled = False
      '   cmdRimuovi.Enabled = False
      'End If

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

   Private Function VerificaEsistenzaPren(ByVal tabella As String, ByVal data As String, ByVal idRisorsa As String, ByVal oraInizio As String, ByVal oraFine As String) As Boolean
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Data = '{1}' " & _
                                         "AND IdRisorsa = '{2}' AND oraInizio = '{3}' " & _
                                         "AND oraFine = '{4}'", _
                                          tabella, _
                                          data, _
                                          idRisorsa, _
                                          oraInizio, _
                                          oraFine)

         numRec = CInt(cmd.ExecuteScalar())

         If numRec = 0 Then
            Return False
         ElseIf numRec > 0 Then
            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   ' NON UTILIZZATA...
   Private Function LeggiUltimaPren(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim id As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         cmd.CommandText = String.Format("SELECT MAX(Id) FROM {0}", tabella)

         id = CInt(cmd.ExecuteScalar())

         Return id

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            If Me.Tag = "" Then
               If VerificaEsistenzaPren(NOME_TABELLA, FormattaData(dtpData.Value, True), _
                  LeggiIdRisorsa(ANA_SALE, cmbRisorsa.Text), dtpOraInizio.Value.ToShortTimeString, dtpOraFine.Value.ToShortTimeString) = True Then

                  MsgBox("La prenotazione che si vuole salvare è già esistente!" & vbCrLf & _
                         "Si suggerisce di modificare i dati della prenotazione o annullare l'operazione.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
                  Exit Sub
               End If
            End If

            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmPrenSale) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmPrenSale.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & IPren.Cliente & " - Per " & IPren.Persone & " il " & IPren.Data & " alle " & IPren.OraInizio & " / " & IPren.OraFine & " - Sala: " & IPren.DescrizioneRisorsa & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_GESTIONE_PREN_SALE)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_SALE)
      End Select
   End Sub

   Private Sub frmPrenotazioni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica le liste.
         CaricaListaClienti(cmbCliente, cmbIdCliente, ANA_CLIENTI)
         CaricaLista(cmbRisorsa, ANA_SALE)

         If cmbRisorsa.Items.Count = 0 Then
            MessageBox.Show("Non ci sono Sale da prenotare! " & vbCrLf & _
                            "Si suggerisce di creare una nuova Sala e in seguito effettuare la prenotazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
            Exit Sub
         End If

         If Me.Tag <> "" Then
            With IPren
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = .Codice
               dtpData.Value = .Data
               cmbCliente.Text = .Cliente
               cmbRisorsa.Text = .DescrizioneRisorsa
               txtPersone.Text = .Persone
               dtpOraInizio.Value = FormattaOra(.OraInizio)
               dtpOraFine.Value = FormattaOra(.OraFine)
               txtNote.Text = .Note

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
               End If
            End With
         Else
            With IPren
               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = ""

               If Data = "" Then
                  dtpData.Value = Today
               Else
                  dtpData.Value = Convert.ToDateTime(Data)
               End If

               cmbCliente.Text = ""
               txtPersone.Text = "0"

               If Risorsa = "" Then
                  cmbRisorsa.SelectedIndex = 0
               Else
                  cmbRisorsa.SelectedIndex = cmbRisorsa.Items.IndexOf(Risorsa)
               End If

               If Ora = "" Then
                  dtpOraInizio.Value = Now
               Else
                  dtpOraInizio.Value = FormattaOra(Ora)
               End If

               dtpOraFine.Value = Now
               txtNote.Text = ""
            End With
         End If

         ' Carica la lista delle degli allegati.
         'ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCliente.Text, "")

         ' Imposta lo stato attivo.
         cmbCliente.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub frmPrenSale_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_SALE)
      End If
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            dtpData.Focus()
         Case 1
            ' Imposta lo stato attivo.
            txtNote.Focus()
            'Case 2
            '   ' Imposta lo stato attivo.
            '   lvwAllegati.Focus()
      End Select
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub cmdRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   cmdInserimento.NotifyDefault(False)

      '   RimuoviAllegati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
      '   ConvalidaAllegati()

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub cmdModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   cmdInserimento.NotifyDefault(False)

      '   With IAllegati
      '      .Documento = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
      '      .Data = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(1).Text
      '      .Ora = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(2).Text
      '      .Note = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(3).Text
      '      .Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

      '      If ImpostaDatiAllegati(.Note, False) = True Then
      '         .ModificaDati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
      '         ConvalidaAllegati()
      '      End If
      '   End With

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub cmdInserimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If ImpostaDatiAllegati("", True) = True Then
      '   IAllegati.InserisciDati(TAB_ALLEGATI)
      '   ConvalidaAllegati()
      'End If

   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub lvwAllegati_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
      '' a_todo: DA TERMINARE - IMPOSTARE TUTTI I PROGRAMMI APRIBILI.
      'Dim Estensione As String
      'Dim NomeFile As String
      'Dim Percorso As String
      'Dim PercorsoApp As String
      'Dim NomeApp As String
      'Dim Proc As New Process

      'Try

      '   ' Nome del file.
      '   NomeFile = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
      '   ' Percorso del file.
      '   Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

      '   ' Ottiene l'estensione del file.
      '   Estensione = Path.GetExtension(Percorso)

      '   Select Case Estensione.ToUpper
      '      Case ".DOC", ".RTF"
      '         ' Word
      '         NomeApp = "WINWORD.EXE"

      '      Case ".XLS"
      '         ' Excel
      '         NomeApp = "EXCEL.EXE"

      '      Case ".MDB"
      '         ' Access
      '         NomeApp = "MSACCESS.EXE"

      '      Case ".PPT"
      '         ' Power Point
      '         NomeApp = "POWERPNT.EXE"

      '      Case ".TXT"
      '         ' Blocco note.
      '         NomeApp = "NOTEPAD.EXE"

      '      Case ".PDF"
      '         ' Acrobat Reader
      '         NomeApp = "ACRORD32.EXE"

      '      Case ".HTM"
      '         ' Internet Explorer
      '         NomeApp = "IEXPLORE.EXE"
      '   End Select

      '   ' Avvia l'applicazione.
      '   Proc.StartInfo.FileName = NomeApp
      '   Proc.StartInfo.Arguments = Percorso
      '   Proc.StartInfo.ErrorDialog = True
      '   Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
      '   Proc.StartInfo.UseShellExecute = True
      '   Proc.Start()

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   'err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub cmdColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColore.Click
      ModificaColore()

   End Sub

   Private Sub txtPersone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersone.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub


End Class
