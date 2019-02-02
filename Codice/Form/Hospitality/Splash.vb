Option Strict Off
Option Explicit On 

Friend Class frmSplash
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
   'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
	'Può essere modificata utilizzando la finestra di progettazione Windows Form.
	'Non modificarla mediante l'editor di codice.
   Friend WithEvents picSplash As System.Windows.Forms.PictureBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.picSplash = New System.Windows.Forms.PictureBox()
      CType(Me.picSplash, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'picSplash
      '
      Me.picSplash.BackColor = System.Drawing.Color.Transparent
      Me.picSplash.Image = Global.Hospitality_Solution.My.Resources.Resources.Splash_screen_ombra_hospitality
      Me.picSplash.Location = New System.Drawing.Point(1, -1)
      Me.picSplash.Name = "picSplash"
      Me.picSplash.Size = New System.Drawing.Size(434, 235)
      Me.picSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picSplash.TabIndex = 26
      Me.picSplash.TabStop = False
      '
      'frmSplash
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.Window
      Me.ClientSize = New System.Drawing.Size(434, 233)
      Me.ControlBox = False
      Me.Controls.Add(Me.picSplash)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.Location = New System.Drawing.Point(1, 1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSplash"
      Me.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.TopMost = True
      CType(Me.picSplash, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

   Private Sub frmSplash_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      ' Imposta l'immagine in base al prodotto installato.
      ImpostaImmagine(picSplash)
   End Sub
End Class