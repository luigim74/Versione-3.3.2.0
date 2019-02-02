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
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents txtTestoRigaUnica As System.Windows.Forms.TextBox
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents netBtn_ElencoCompleto As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_RigaUnica As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CompattaElenco As Softgroup.NetButton.NetButton
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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TipoElencoPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.netBtn_RigaUnica = New Softgroup.NetButton.NetButton()
      Me.netBtn_CompattaElenco = New Softgroup.NetButton.NetButton()
      Me.netBtn_ElencoCompleto = New Softgroup.NetButton.NetButton()
      Me.txtTestoRigaUnica = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
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
      Me.pnlPag.Controls.Add(Me.netBtn_RigaUnica)
      Me.pnlPag.Controls.Add(Me.netBtn_CompattaElenco)
      Me.pnlPag.Controls.Add(Me.netBtn_ElencoCompleto)
      Me.pnlPag.Controls.Add(Me.txtTestoRigaUnica)
      Me.pnlPag.Controls.Add(Me.Label2)
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(541, 319)
      Me.pnlPag.TabIndex = 228
      '
      'netBtn_RigaUnica
      '
      Me.netBtn_RigaUnica.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_RigaUnica.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_RigaUnica.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_RigaUnica.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_RigaUnica.ColorText = System.Drawing.Color.White
      Me.netBtn_RigaUnica.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_RigaUnica.CornerRadius = 2
      Me.netBtn_RigaUnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_RigaUnica.Location = New System.Drawing.Point(361, 7)
      Me.netBtn_RigaUnica.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_RigaUnica.Name = "netBtn_RigaUnica"
      Me.netBtn_RigaUnica.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_RigaUnica.TabIndex = 2
      Me.netBtn_RigaUnica.TextButton = "Riga unica"
      '
      'netBtn_CompattaElenco
      '
      Me.netBtn_CompattaElenco.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_CompattaElenco.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_CompattaElenco.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_CompattaElenco.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_CompattaElenco.ColorText = System.Drawing.Color.White
      Me.netBtn_CompattaElenco.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_CompattaElenco.CornerRadius = 2
      Me.netBtn_CompattaElenco.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_CompattaElenco.Location = New System.Drawing.Point(183, 7)
      Me.netBtn_CompattaElenco.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CompattaElenco.Name = "netBtn_CompattaElenco"
      Me.netBtn_CompattaElenco.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_CompattaElenco.TabIndex = 1
      Me.netBtn_CompattaElenco.TextButton = "Elenco compatto"
      '
      'netBtn_ElencoCompleto
      '
      Me.netBtn_ElencoCompleto.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ElencoCompleto.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ElencoCompleto.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ElencoCompleto.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ElencoCompleto.ColorText = System.Drawing.Color.White
      Me.netBtn_ElencoCompleto.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ElencoCompleto.CornerRadius = 2
      Me.netBtn_ElencoCompleto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ElencoCompleto.Location = New System.Drawing.Point(7, 7)
      Me.netBtn_ElencoCompleto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ElencoCompleto.Name = "netBtn_ElencoCompleto"
      Me.netBtn_ElencoCompleto.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_ElencoCompleto.TabIndex = 0
      Me.netBtn_ElencoCompleto.TextButton = "Elenco completo"
      '
      'txtTestoRigaUnica
      '
      Me.txtTestoRigaUnica.AcceptsReturn = True
      Me.txtTestoRigaUnica.BackColor = System.Drawing.SystemColors.Window
      Me.txtTestoRigaUnica.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTestoRigaUnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTestoRigaUnica.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTestoRigaUnica.Location = New System.Drawing.Point(9, 277)
      Me.txtTestoRigaUnica.MaxLength = 100
      Me.txtTestoRigaUnica.Name = "txtTestoRigaUnica"
      Me.txtTestoRigaUnica.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTestoRigaUnica.Size = New System.Drawing.Size(520, 29)
      Me.txtTestoRigaUnica.TabIndex = 3
      Me.txtTestoRigaUnica.Text = "Quota alla romana"
      '
      'Label2
      '
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(7, 256)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(168, 18)
      Me.Label2.TabIndex = 190
      Me.Label2.Text = "TESTO RIGA UNICA:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "110b8a04-9b84-4cd7-bf9a-7139e0ea4f2b"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(410, 339)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 0
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "86c09d61-cee7-4018-8564-895f94339a89"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(18, 339)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 1
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'TipoElencoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(558, 401)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdTastiera)
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

      If Me.Tag.ToString.ToUpper = "ALLA ROMANA" Then
         netBtn_ElencoCompleto.Enabled = False
         netBtn_CompattaElenco.Enabled = False
      End If

      txtTestoRigaUnica.Text = g_frmContoPos.LeggiTestoRigaUnicaConfig()
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub netBtn_ElencoCompleto_Click(sender As Object, e As EventArgs) Handles netBtn_ElencoCompleto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_ElencoCompleto.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_CompattaElenco_Click(sender As Object, e As EventArgs) Handles netBtn_CompattaElenco.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_CompattaElenco.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_RigaUnica_Click(sender As Object, e As EventArgs) Handles netBtn_RigaUnica.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_RigaUnica.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub
End Class
