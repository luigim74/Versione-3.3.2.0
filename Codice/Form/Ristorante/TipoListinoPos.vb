Imports System.IO
Imports System.Data.OleDb

Public Class TipoListinoPos
   Inherits System.Windows.Forms.Form

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents netBtn_Listino3 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Listino2 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Listino1 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Listino4 As Softgroup.NetButton.NetButton
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TipoListinoPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.netBtn_Listino4 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Listino3 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Listino2 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Listino1 = New Softgroup.NetButton.NetButton()
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
      Me.pnlPag.Controls.Add(Me.netBtn_Listino4)
      Me.pnlPag.Controls.Add(Me.netBtn_Listino3)
      Me.pnlPag.Controls.Add(Me.netBtn_Listino2)
      Me.pnlPag.Controls.Add(Me.netBtn_Listino1)
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(354, 205)
      Me.pnlPag.TabIndex = 228
      '
      'netBtn_Listino4
      '
      Me.netBtn_Listino4.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Listino4.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Listino4.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Listino4.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Listino4.ColorText = System.Drawing.Color.White
      Me.netBtn_Listino4.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Listino4.CornerRadius = 2
      Me.netBtn_Listino4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Listino4.Location = New System.Drawing.Point(180, 104)
      Me.netBtn_Listino4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Listino4.Name = "netBtn_Listino4"
      Me.netBtn_Listino4.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Listino4.TabIndex = 3
      Me.netBtn_Listino4.TextButton = "Listino 4"
      '
      'netBtn_Listino3
      '
      Me.netBtn_Listino3.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Listino3.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Listino3.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Listino3.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Listino3.ColorText = System.Drawing.Color.White
      Me.netBtn_Listino3.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Listino3.CornerRadius = 2
      Me.netBtn_Listino3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Listino3.Location = New System.Drawing.Point(6, 104)
      Me.netBtn_Listino3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Listino3.Name = "netBtn_Listino3"
      Me.netBtn_Listino3.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Listino3.TabIndex = 2
      Me.netBtn_Listino3.TextButton = "Listino 3"
      '
      'netBtn_Listino2
      '
      Me.netBtn_Listino2.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Listino2.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Listino2.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Listino2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Listino2.ColorText = System.Drawing.Color.White
      Me.netBtn_Listino2.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Listino2.CornerRadius = 2
      Me.netBtn_Listino2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Listino2.Location = New System.Drawing.Point(180, 8)
      Me.netBtn_Listino2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Listino2.Name = "netBtn_Listino2"
      Me.netBtn_Listino2.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Listino2.TabIndex = 1
      Me.netBtn_Listino2.TextButton = "Listino 2"
      '
      'netBtn_Listino1
      '
      Me.netBtn_Listino1.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Listino1.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Listino1.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Listino1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Listino1.ColorText = System.Drawing.Color.White
      Me.netBtn_Listino1.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Listino1.CornerRadius = 2
      Me.netBtn_Listino1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Listino1.Location = New System.Drawing.Point(4, 8)
      Me.netBtn_Listino1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Listino1.Name = "netBtn_Listino1"
      Me.netBtn_Listino1.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Listino1.TabIndex = 0
      Me.netBtn_Listino1.TextButton = "Listino 1"
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
      Me.eui_cmdAnnulla.Id = "d010452a-2a92-4f45-a622-db0510da34db"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(228, 216)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 0
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'TipoListinoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(369, 277)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TipoListinoPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "TIPO LISTINO"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlPag.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub TipoListinoPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub netBtn_Listino1_Click(sender As Object, e As EventArgs) Handles netBtn_Listino1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Listino1.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Listino2_Click(sender As Object, e As EventArgs) Handles netBtn_Listino2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Listino2.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Listino3_Click(sender As Object, e As EventArgs) Handles netBtn_Listino3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Listino3.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Listino4_Click(sender As Object, e As EventArgs) Handles netBtn_Listino4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Listino4.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

End Class
