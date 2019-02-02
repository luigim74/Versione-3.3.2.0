Imports System.IO
Imports System.Data.OleDb

Public Class TipoContoPos
   Inherits System.Windows.Forms.Form

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents netBtn_ContoRomana As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_ContoSeparato As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_ContoUnico As Softgroup.NetButton.NetButton
   Private cmd As New OleDbCommand(sql, cn)

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TipoContoPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.netBtn_ContoRomana = New Softgroup.NetButton.NetButton()
      Me.netBtn_ContoSeparato = New Softgroup.NetButton.NetButton()
      Me.netBtn_ContoUnico = New Softgroup.NetButton.NetButton()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
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
      Me.pnlPag.Controls.Add(Me.netBtn_ContoRomana)
      Me.pnlPag.Controls.Add(Me.netBtn_ContoSeparato)
      Me.pnlPag.Controls.Add(Me.netBtn_ContoUnico)
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(536, 328)
      Me.pnlPag.TabIndex = 228
      '
      'netBtn_ContoRomana
      '
      Me.netBtn_ContoRomana.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ContoRomana.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ContoRomana.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ContoRomana.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ContoRomana.ColorText = System.Drawing.Color.White
      Me.netBtn_ContoRomana.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ContoRomana.CornerRadius = 2
      Me.netBtn_ContoRomana.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ContoRomana.Location = New System.Drawing.Point(358, 8)
      Me.netBtn_ContoRomana.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ContoRomana.Name = "netBtn_ContoRomana"
      Me.netBtn_ContoRomana.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_ContoRomana.TabIndex = 2
      Me.netBtn_ContoRomana.TextButton = "Alla romana"
      '
      'netBtn_ContoSeparato
      '
      Me.netBtn_ContoSeparato.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ContoSeparato.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ContoSeparato.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ContoSeparato.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ContoSeparato.ColorText = System.Drawing.Color.White
      Me.netBtn_ContoSeparato.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ContoSeparato.CornerRadius = 2
      Me.netBtn_ContoSeparato.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ContoSeparato.Location = New System.Drawing.Point(180, 8)
      Me.netBtn_ContoSeparato.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ContoSeparato.Name = "netBtn_ContoSeparato"
      Me.netBtn_ContoSeparato.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_ContoSeparato.TabIndex = 1
      Me.netBtn_ContoSeparato.TextButton = "Separato manuale"
      '
      'netBtn_ContoUnico
      '
      Me.netBtn_ContoUnico.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ContoUnico.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ContoUnico.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ContoUnico.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ContoUnico.ColorText = System.Drawing.Color.White
      Me.netBtn_ContoUnico.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ContoUnico.CornerRadius = 2
      Me.netBtn_ContoUnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ContoUnico.Location = New System.Drawing.Point(4, 8)
      Me.netBtn_ContoUnico.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ContoUnico.Name = "netBtn_ContoUnico"
      Me.netBtn_ContoUnico.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_ContoUnico.TabIndex = 0
      Me.netBtn_ContoUnico.TextButton = "Unico"
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
      Me.eui_cmdAnnulla.Id = "85f470a7-b621-4f5d-b91b-a5e37135ef20"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(404, 347)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 0
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'TipoContoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(553, 406)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TipoContoPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "TIPO CONTO"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlPag.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub TipoContoPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub netBtn_ContoUnico_Click(sender As Object, e As EventArgs) Handles netBtn_ContoUnico.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_ContoUnico.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_ContoSeparato_Click(sender As Object, e As EventArgs) Handles netBtn_ContoSeparato.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_ContoSeparato.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_ContoRomana_Click(sender As Object, e As EventArgs) Handles netBtn_ContoRomana.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_ContoRomana.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub
End Class
