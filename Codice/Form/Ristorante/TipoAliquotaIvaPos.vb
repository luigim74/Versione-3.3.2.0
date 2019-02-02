Imports System.IO
Imports System.Data.OleDb

Public Class TipoAliquotaIvaPos
   Inherits System.Windows.Forms.Form

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private CFormatta As New ClsFormatta
   Private DatiConfig As AppConfig

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents netBtn_Reparto3 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Reparto2 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Reparto1 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Reparto4 As Softgroup.NetButton.NetButton
   Private cmd As New OleDbCommand(sql, cn)

   Dim modificaReparto As Boolean = False

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal modificaAliquotaReparto As Boolean)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      modificaReparto = modificaAliquotaReparto

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TipoAliquotaIvaPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.netBtn_Reparto4 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Reparto3 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Reparto2 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Reparto1 = New Softgroup.NetButton.NetButton()
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
      Me.pnlPag.Controls.Add(Me.netBtn_Reparto4)
      Me.pnlPag.Controls.Add(Me.netBtn_Reparto3)
      Me.pnlPag.Controls.Add(Me.netBtn_Reparto2)
      Me.pnlPag.Controls.Add(Me.netBtn_Reparto1)
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(354, 205)
      Me.pnlPag.TabIndex = 228
      '
      'netBtn_Reparto4
      '
      Me.netBtn_Reparto4.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Reparto4.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Reparto4.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Reparto4.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Reparto4.ColorText = System.Drawing.Color.White
      Me.netBtn_Reparto4.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Reparto4.CornerRadius = 2
      Me.netBtn_Reparto4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Reparto4.Location = New System.Drawing.Point(180, 104)
      Me.netBtn_Reparto4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Reparto4.Name = "netBtn_Reparto4"
      Me.netBtn_Reparto4.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Reparto4.TabIndex = 3
      Me.netBtn_Reparto4.TextButton = "Reparto 4"
      '
      'netBtn_Reparto3
      '
      Me.netBtn_Reparto3.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Reparto3.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Reparto3.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Reparto3.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Reparto3.ColorText = System.Drawing.Color.White
      Me.netBtn_Reparto3.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Reparto3.CornerRadius = 2
      Me.netBtn_Reparto3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Reparto3.Location = New System.Drawing.Point(6, 104)
      Me.netBtn_Reparto3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Reparto3.Name = "netBtn_Reparto3"
      Me.netBtn_Reparto3.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Reparto3.TabIndex = 2
      Me.netBtn_Reparto3.TextButton = "Reparto 3"
      '
      'netBtn_Reparto2
      '
      Me.netBtn_Reparto2.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Reparto2.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Reparto2.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Reparto2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Reparto2.ColorText = System.Drawing.Color.White
      Me.netBtn_Reparto2.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Reparto2.CornerRadius = 2
      Me.netBtn_Reparto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Reparto2.Location = New System.Drawing.Point(180, 8)
      Me.netBtn_Reparto2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Reparto2.Name = "netBtn_Reparto2"
      Me.netBtn_Reparto2.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Reparto2.TabIndex = 1
      Me.netBtn_Reparto2.TextButton = "Reparto 2"
      '
      'netBtn_Reparto1
      '
      Me.netBtn_Reparto1.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Reparto1.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Reparto1.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Reparto1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Reparto1.ColorText = System.Drawing.Color.White
      Me.netBtn_Reparto1.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Reparto1.CornerRadius = 2
      Me.netBtn_Reparto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Reparto1.Location = New System.Drawing.Point(4, 8)
      Me.netBtn_Reparto1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Reparto1.Name = "netBtn_Reparto1"
      Me.netBtn_Reparto1.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Reparto1.TabIndex = 0
      Me.netBtn_Reparto1.TextButton = "Reparto 1"
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
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(228, 225)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 0
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'TipoAliquotaIvaPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(370, 287)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TipoAliquotaIvaPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "ALIQUOTA IVA"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlPag.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub TipoAliquotaIvaPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Aliquote IVA per i reparti.
         Dim Reparto1 As String = DatiConfig.GetValue("AliquotaIva1")
         If Reparto1 <> String.Empty Then
            netBtn_Reparto1.TextButton = netBtn_Reparto1.TextButton & " (" & CFormatta.FormattaAliquotaIva(Reparto1) & "%)"
            netBtn_Reparto1.Tag = Reparto1
         Else
            netBtn_Reparto1.TextButton = netBtn_Reparto1.TextButton & " (0%)"
            netBtn_Reparto1.Tag = VALORE_ZERO
         End If

         Dim Reparto2 As String = DatiConfig.GetValue("AliquotaIva2")
         If Reparto2 <> String.Empty Then
            netBtn_Reparto2.TextButton = netBtn_Reparto2.TextButton & " (" & CFormatta.FormattaAliquotaIva(Reparto2) & "%)"
            netBtn_Reparto2.Tag = Reparto2
         Else
            netBtn_Reparto2.TextButton = netBtn_Reparto2.TextButton & " (0%)"
            netBtn_Reparto2.Tag = VALORE_ZERO
         End If

         Dim Reparto3 As String = DatiConfig.GetValue("AliquotaIva3")
         If Reparto3 <> String.Empty Then
            netBtn_Reparto3.TextButton = netBtn_Reparto3.TextButton & " (" & CFormatta.FormattaAliquotaIva(Reparto3) & "%)"
            netBtn_Reparto3.Tag = Reparto3
         Else
            netBtn_Reparto3.TextButton = netBtn_Reparto3.TextButton & " (0%)"
            netBtn_Reparto3.Tag = VALORE_ZERO
         End If

         Dim Reparto4 As String = DatiConfig.GetValue("AliquotaIva4")
         If Reparto4 <> String.Empty Then
            netBtn_Reparto4.TextButton = netBtn_Reparto4.TextButton & " (" & CFormatta.FormattaAliquotaIva(Reparto4) & "%)"
            netBtn_Reparto4.Tag = Reparto4
         Else
            netBtn_Reparto4.TextButton = netBtn_Reparto4.TextButton & " (0%)"
            netBtn_Reparto4.Tag = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub netBtn_Reparto1_Click(sender As Object, e As EventArgs) Handles netBtn_Reparto1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If modificaReparto = True Then
         g_frmPos.netBtn_Reparto.TextButton = netBtn_Reparto1.TextButton
      End If

      Me.Tag = netBtn_Reparto1.Tag
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Reparto2_Click(sender As Object, e As EventArgs) Handles netBtn_Reparto2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If modificaReparto = True Then
         g_frmPos.netBtn_Reparto.TextButton = netBtn_Reparto2.TextButton
      End If

      Me.Tag = netBtn_Reparto2.Tag
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Reparto3_Click(sender As Object, e As EventArgs) Handles netBtn_Reparto3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If modificaReparto = True Then
         g_frmPos.netBtn_Reparto.TextButton = netBtn_Reparto3.TextButton
      End If

      Me.Tag = netBtn_Reparto3.Tag
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Reparto4_Click(sender As Object, e As EventArgs) Handles netBtn_Reparto4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If modificaReparto = True Then
         g_frmPos.netBtn_Reparto.TextButton = netBtn_Reparto4.TextButton
      End If

      Me.Tag = netBtn_Reparto4.Tag
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

End Class
