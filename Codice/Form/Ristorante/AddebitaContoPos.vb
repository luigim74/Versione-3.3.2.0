Imports System.IO
Imports System.Data.OleDb

Public Class AddebitaContoPos
   Inherits System.Windows.Forms.Form

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents netBtn_CentroBalneare As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CentroSportivo As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Hotel As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Campeggio As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CentroBenessere As Softgroup.NetButton.NetButton
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddebitaContoPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.netBtn_CentroBenessere = New Softgroup.NetButton.NetButton()
      Me.netBtn_Campeggio = New Softgroup.NetButton.NetButton()
      Me.netBtn_CentroBalneare = New Softgroup.NetButton.NetButton()
      Me.netBtn_CentroSportivo = New Softgroup.NetButton.NetButton()
      Me.netBtn_Hotel = New Softgroup.NetButton.NetButton()
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
      Me.pnlPag.Controls.Add(Me.netBtn_CentroBenessere)
      Me.pnlPag.Controls.Add(Me.netBtn_Campeggio)
      Me.pnlPag.Controls.Add(Me.netBtn_CentroBalneare)
      Me.pnlPag.Controls.Add(Me.netBtn_CentroSportivo)
      Me.pnlPag.Controls.Add(Me.netBtn_Hotel)
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(358, 302)
      Me.pnlPag.TabIndex = 228
      '
      'netBtn_CentroBenessere
      '
      Me.netBtn_CentroBenessere.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_CentroBenessere.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_CentroBenessere.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_CentroBenessere.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_CentroBenessere.ColorText = System.Drawing.Color.White
      Me.netBtn_CentroBenessere.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_CentroBenessere.CornerRadius = 2
      Me.netBtn_CentroBenessere.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_CentroBenessere.Location = New System.Drawing.Point(6, 200)
      Me.netBtn_CentroBenessere.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CentroBenessere.Name = "netBtn_CentroBenessere"
      Me.netBtn_CentroBenessere.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_CentroBenessere.TabIndex = 4
      Me.netBtn_CentroBenessere.TextButton = "Centro Benessere"
      '
      'netBtn_Campeggio
      '
      Me.netBtn_Campeggio.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Campeggio.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Campeggio.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Campeggio.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Campeggio.ColorText = System.Drawing.Color.White
      Me.netBtn_Campeggio.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Campeggio.CornerRadius = 2
      Me.netBtn_Campeggio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Campeggio.Location = New System.Drawing.Point(4, 104)
      Me.netBtn_Campeggio.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Campeggio.Name = "netBtn_Campeggio"
      Me.netBtn_Campeggio.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Campeggio.TabIndex = 2
      Me.netBtn_Campeggio.TextButton = "Campeggio"
      '
      'netBtn_CentroBalneare
      '
      Me.netBtn_CentroBalneare.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_CentroBalneare.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_CentroBalneare.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_CentroBalneare.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_CentroBalneare.ColorText = System.Drawing.Color.White
      Me.netBtn_CentroBalneare.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_CentroBalneare.CornerRadius = 2
      Me.netBtn_CentroBalneare.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_CentroBalneare.Location = New System.Drawing.Point(180, 104)
      Me.netBtn_CentroBalneare.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CentroBalneare.Name = "netBtn_CentroBalneare"
      Me.netBtn_CentroBalneare.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_CentroBalneare.TabIndex = 3
      Me.netBtn_CentroBalneare.TextButton = "Centro Balneare"
      '
      'netBtn_CentroSportivo
      '
      Me.netBtn_CentroSportivo.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_CentroSportivo.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_CentroSportivo.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_CentroSportivo.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_CentroSportivo.ColorText = System.Drawing.Color.White
      Me.netBtn_CentroSportivo.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_CentroSportivo.CornerRadius = 2
      Me.netBtn_CentroSportivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_CentroSportivo.Location = New System.Drawing.Point(180, 8)
      Me.netBtn_CentroSportivo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CentroSportivo.Name = "netBtn_CentroSportivo"
      Me.netBtn_CentroSportivo.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_CentroSportivo.TabIndex = 1
      Me.netBtn_CentroSportivo.TextButton = "Centro Sportivo"
      '
      'netBtn_Hotel
      '
      Me.netBtn_Hotel.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Hotel.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Hotel.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Hotel.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Hotel.ColorText = System.Drawing.Color.White
      Me.netBtn_Hotel.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Hotel.CornerRadius = 2
      Me.netBtn_Hotel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Hotel.Location = New System.Drawing.Point(4, 8)
      Me.netBtn_Hotel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Hotel.Name = "netBtn_Hotel"
      Me.netBtn_Hotel.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Hotel.TabIndex = 0
      Me.netBtn_Hotel.TextButton = "Hotel"
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
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(228, 313)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 0
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'AddebitaContoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(375, 372)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AddebitaContoPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "ADDEBITA CONTO SU PRENOTAZIONE"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlPag.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub AddebitaContoPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub netBtn_Hotel_Click(sender As Object, e As EventArgs) Handles netBtn_Hotel.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Hotel.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_CentroSportivo_Click(sender As Object, e As EventArgs) Handles netBtn_CentroSportivo.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_CentroSportivo.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Campeggio_Click(sender As Object, e As EventArgs) Handles netBtn_Campeggio.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Campeggio.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_CentroBalneare_Click(sender As Object, e As EventArgs) Handles netBtn_CentroBalneare.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_CentroBalneare.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_CentroBenessere_Click(sender As Object, e As EventArgs) Handles netBtn_CentroBenessere.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_CentroBenessere.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub
End Class
