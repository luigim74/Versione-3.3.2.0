Imports System.IO
Imports System.Data.OleDb

Public Class TipoElencoPos
   Inherits System.Windows.Forms.Form

   Const LARGHEZZA_PULSANTE As Short = 184
   Const ALTEZZA_PULSANTE As Short = 80

   Public Pagamenti() As Button
   Public NumPagamenti As Short = 0

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdRigaUnica As System.Windows.Forms.Button
   Friend WithEvents cmdElencoCompleto As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents txtTestoRigaUnica As System.Windows.Forms.TextBox
   Friend WithEvents cmdCompattaElenco As System.Windows.Forms.Button
   Friend WithEvents cmdTastiera As System.Windows.Forms.Button
   Private cmd As New OleDbCommand(sql, cn)

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal tipoConto As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      Me.Tag = tipoConto

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
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents pnlPag As System.Windows.Forms.Panel
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TipoElencoPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.cmdCompattaElenco = New System.Windows.Forms.Button()
      Me.txtTestoRigaUnica = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdRigaUnica = New System.Windows.Forms.Button()
      Me.cmdElencoCompleto = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.cmdTastiera = New System.Windows.Forms.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlPag.SuspendLayout()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "RFiscale.rpt"
      '
      'pnlPag
      '
      Me.pnlPag.AutoScroll = True
      Me.pnlPag.Controls.Add(Me.cmdCompattaElenco)
      Me.pnlPag.Controls.Add(Me.txtTestoRigaUnica)
      Me.pnlPag.Controls.Add(Me.Label2)
      Me.pnlPag.Controls.Add(Me.cmdRigaUnica)
      Me.pnlPag.Controls.Add(Me.cmdElencoCompleto)
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(536, 328)
      Me.pnlPag.TabIndex = 228
      '
      'cmdCompattaElenco
      '
      Me.cmdCompattaElenco.BackColor = System.Drawing.Color.White
      Me.cmdCompattaElenco.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdCompattaElenco.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCompattaElenco.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCompattaElenco.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdCompattaElenco.Location = New System.Drawing.Point(184, 8)
      Me.cmdCompattaElenco.Name = "cmdCompattaElenco"
      Me.cmdCompattaElenco.Size = New System.Drawing.Size(168, 88)
      Me.cmdCompattaElenco.TabIndex = 1
      Me.cmdCompattaElenco.Text = "ELENCO COMPATTO"
      Me.cmdCompattaElenco.UseVisualStyleBackColor = False
      '
      'txtTestoRigaUnica
      '
      Me.txtTestoRigaUnica.AcceptsReturn = True
      Me.txtTestoRigaUnica.BackColor = System.Drawing.SystemColors.Window
      Me.txtTestoRigaUnica.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTestoRigaUnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTestoRigaUnica.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTestoRigaUnica.Location = New System.Drawing.Point(16, 280)
      Me.txtTestoRigaUnica.MaxLength = 100
      Me.txtTestoRigaUnica.Name = "txtTestoRigaUnica"
      Me.txtTestoRigaUnica.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTestoRigaUnica.Size = New System.Drawing.Size(504, 29)
      Me.txtTestoRigaUnica.TabIndex = 3
      Me.txtTestoRigaUnica.Text = "Quota alla romana"
      '
      'Label2
      '
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 256)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(168, 18)
      Me.Label2.TabIndex = 190
      Me.Label2.Text = "TESTO RIGA UNICA:"
      '
      'cmdRigaUnica
      '
      Me.cmdRigaUnica.BackColor = System.Drawing.Color.White
      Me.cmdRigaUnica.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdRigaUnica.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdRigaUnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdRigaUnica.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdRigaUnica.Location = New System.Drawing.Point(360, 8)
      Me.cmdRigaUnica.Name = "cmdRigaUnica"
      Me.cmdRigaUnica.Size = New System.Drawing.Size(168, 88)
      Me.cmdRigaUnica.TabIndex = 2
      Me.cmdRigaUnica.Text = "RIGA UNICA"
      Me.cmdRigaUnica.UseVisualStyleBackColor = False
      '
      'cmdElencoCompleto
      '
      Me.cmdElencoCompleto.BackColor = System.Drawing.Color.White
      Me.cmdElencoCompleto.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdElencoCompleto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdElencoCompleto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdElencoCompleto.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdElencoCompleto.Location = New System.Drawing.Point(8, 8)
      Me.cmdElencoCompleto.Name = "cmdElencoCompleto"
      Me.cmdElencoCompleto.Size = New System.Drawing.Size(168, 88)
      Me.cmdElencoCompleto.TabIndex = 0
      Me.cmdElencoCompleto.Text = "ELENCO COMPLETO"
      Me.cmdElencoCompleto.UseVisualStyleBackColor = False
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.BackColor = System.Drawing.Color.LightCoral
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnnulla.ForeColor = System.Drawing.Color.White
      Me.cmdAnnulla.Location = New System.Drawing.Point(552, 16)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(128, 56)
      Me.cmdAnnulla.TabIndex = 0
      Me.cmdAnnulla.Text = "&ANNULLA"
      Me.cmdAnnulla.UseVisualStyleBackColor = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'cmdTastiera
      '
      Me.cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdTastiera.BackColor = System.Drawing.Color.Gray
      Me.cmdTastiera.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTastiera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTastiera.ForeColor = System.Drawing.Color.White
      Me.cmdTastiera.Image = CType(resources.GetObject("cmdTastiera.Image"), System.Drawing.Image)
      Me.cmdTastiera.Location = New System.Drawing.Point(624, 288)
      Me.cmdTastiera.Name = "cmdTastiera"
      Me.cmdTastiera.Size = New System.Drawing.Size(56, 40)
      Me.cmdTastiera.TabIndex = 276
      Me.cmdTastiera.UseVisualStyleBackColor = False
      '
      'TipoElencoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(688, 344)
      Me.Controls.Add(Me.cmdTastiera)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TipoElencoPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "TIPO ELENCO PIETANZE"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlPag.ResumeLayout(False)
      Me.pnlPag.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub SalvaTestoRigaUnicaConfig()
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If txtTestoRigaUnica.Text <> String.Empty Then
            DatiConfig.SetValue("TestoRigaUnica", txtTestoRigaUnica.Text)
         Else
            DatiConfig.SetValue("TestoRigaUnica", "Quota alla romana")
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub TipoElencoPos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SalvaTestoRigaUnicaConfig()
   End Sub

   Private Sub TipoElencoPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      If Me.Tag.ToString = "ALLA ROMANA" Then
         cmdElencoCompleto.Enabled = False
         cmdCompattaElenco.Enabled = False
      End If

      txtTestoRigaUnica.Text = g_frmContoPos.LeggiTestoRigaUnicaConfig()
   End Sub

   Private Sub cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdElencoCompleto_Click(sender As System.Object, e As System.EventArgs) Handles cmdElencoCompleto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = cmdElencoCompleto.Text
      Me.Close()
   End Sub

   Private Sub cmdCompattaElenco_Click(sender As System.Object, e As System.EventArgs) Handles cmdCompattaElenco.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = cmdCompattaElenco.Text
      Me.Close()
   End Sub

   Private Sub cmdRigaUnica_Click(sender As System.Object, e As System.EventArgs) Handles cmdRigaUnica.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = cmdRigaUnica.Text
      Me.Close()
   End Sub


   Private Sub cmdTastiera_Click(sender As System.Object, e As System.EventArgs) Handles cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub
End Class
