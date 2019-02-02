Option Strict Off
Option Explicit On 

Friend Class frmSplash1
   Inherits System.Windows.Forms.Form

#Region "Codice generato dalla finestra di progettazione Windows Form "
   Public Sub New()
      MyBase.New()
      'Chiamata richiesta dalla progettazione Windows Form.
      InitializeComponent()
   End Sub
   'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
      If Disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(Disposing)
   End Sub
   'Richiesto dalla progettazione Windows Form
   Private components As System.ComponentModel.IContainer
   Public ToolTip1 As System.Windows.Forms.ToolTip
   Public WithEvents lblInfo As System.Windows.Forms.Label
   Public WithEvents lblDemo As System.Windows.Forms.Label
   Public WithEvents lblVersione As System.Windows.Forms.Label
   'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
   'Può essere modificata utilizzando la finestra di progettazione Windows Form.
   'Non modificarla mediante l'editor di codice.
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Public WithEvents Image1 As System.Windows.Forms.PictureBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents lblFreeware As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSplash1))
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.lblInfo = New System.Windows.Forms.Label
      Me.lblDemo = New System.Windows.Forms.Label
      Me.lblVersione = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.Image1 = New System.Windows.Forms.PictureBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.lblFreeware = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'lblInfo
      '
      Me.lblInfo.AutoSize = True
      Me.lblInfo.BackColor = System.Drawing.Color.Transparent
      Me.lblInfo.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblInfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblInfo.ForeColor = System.Drawing.Color.Black
      Me.lblInfo.Location = New System.Drawing.Point(40, 384)
      Me.lblInfo.Name = "lblInfo"
      Me.lblInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblInfo.Size = New System.Drawing.Size(128, 16)
      Me.lblInfo.TabIndex = 5
      Me.lblInfo.Text = "Copyright © 2005 - 2007"
      Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblDemo
      '
      Me.lblDemo.BackColor = System.Drawing.Color.Black
      Me.lblDemo.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblDemo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lblDemo.Font = New System.Drawing.Font("Frutiger SAIN Bd v.1", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDemo.ForeColor = System.Drawing.Color.LightSteelBlue
      Me.lblDemo.Location = New System.Drawing.Point(0, 200)
      Me.lblDemo.Name = "lblDemo"
      Me.lblDemo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblDemo.Size = New System.Drawing.Size(336, 16)
      Me.lblDemo.TabIndex = 2
      Me.lblDemo.Text = "C O P I A   D I   V A L U T A Z I O N E"
      Me.lblDemo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblDemo.Visible = False
      '
      'lblVersione
      '
      Me.lblVersione.AutoSize = True
      Me.lblVersione.BackColor = System.Drawing.Color.Black
      Me.lblVersione.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblVersione.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblVersione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblVersione.Location = New System.Drawing.Point(8, 384)
      Me.lblVersione.Name = "lblVersione"
      Me.lblVersione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblVersione.Size = New System.Drawing.Size(21, 16)
      Me.lblVersione.TabIndex = 1
      Me.lblVersione.Tag = "Versione"
      Me.lblVersione.Text = "#V."
      Me.lblVersione.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Black
      Me.Label1.Font = New System.Drawing.Font("Frutiger SAIN Bd v.1", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.LightSteelBlue
      Me.Label1.Location = New System.Drawing.Point(0, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(336, 32)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = " CHEF SOLUTION 2009"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'PictureBox1
      '
      Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(0, 216)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(334, 32)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox1.TabIndex = 7
      Me.PictureBox1.TabStop = False
      '
      'Image1
      '
      Me.Image1.BackColor = System.Drawing.SystemColors.Window
      Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
      Me.Image1.Location = New System.Drawing.Point(0, 32)
      Me.Image1.Name = "Image1"
      Me.Image1.Size = New System.Drawing.Size(336, 168)
      Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.Image1.TabIndex = 22
      Me.Image1.TabStop = False
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.SystemColors.InfoText
      Me.Label2.Font = New System.Drawing.Font("Frutiger SAIN Bd v.1", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(277, 13)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(52, 19)
      Me.Label2.TabIndex = 23
      Me.Label2.Text = "Ver.  2.5"
      '
      'lblFreeware
      '
      Me.lblFreeware.BackColor = System.Drawing.Color.Black
      Me.lblFreeware.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblFreeware.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lblFreeware.Font = New System.Drawing.Font("Frutiger SAIN Bd v.1", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFreeware.ForeColor = System.Drawing.Color.LightSteelBlue
      Me.lblFreeware.Location = New System.Drawing.Point(0, 200)
      Me.lblFreeware.Name = "lblFreeware"
      Me.lblFreeware.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblFreeware.Size = New System.Drawing.Size(336, 16)
      Me.lblFreeware.TabIndex = 25
      Me.lblFreeware.Text = "V E R S I O N E  F R E E W A R E"
      Me.lblFreeware.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblFreeware.Visible = False
      '
      'frmSplash
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.Window
      Me.ClientSize = New System.Drawing.Size(334, 248)
      Me.ControlBox = False
      Me.Controls.Add(Me.lblVersione)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblInfo)
      Me.Controls.Add(Me.lblDemo)
      Me.Controls.Add(Me.lblFreeware)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.Image1)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Location = New System.Drawing.Point(1, 1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSplash"
      Me.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.TopMost = True
      Me.ResumeLayout(False)

   End Sub
#End Region

   Private Sub frmSplash_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      If g_VerDemo = True Then
         lblDemo.Visible = True
         lblFreeware.Visible = False
      Else
         lblDemo.Visible = False
         lblFreeware.Visible = True
      End If
   End Sub
End Class