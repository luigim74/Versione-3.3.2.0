Imports System.IO
Imports System.Data.OleDb

Public Class TipoContoPos
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
   Friend WithEvents cmdContoRomana As System.Windows.Forms.Button
   Friend WithEvents cmdContoSeparato As System.Windows.Forms.Button
   Friend WithEvents cmdContoUnico As System.Windows.Forms.Button
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
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TipoContoPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.cmdContoRomana = New System.Windows.Forms.Button()
      Me.cmdContoSeparato = New System.Windows.Forms.Button()
      Me.cmdContoUnico = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
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
      Me.pnlPag.Controls.Add(Me.cmdContoRomana)
      Me.pnlPag.Controls.Add(Me.cmdContoSeparato)
      Me.pnlPag.Controls.Add(Me.cmdContoUnico)
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(536, 328)
      Me.pnlPag.TabIndex = 228
      '
      'cmdContoRomana
      '
      Me.cmdContoRomana.BackColor = System.Drawing.Color.White
      Me.cmdContoRomana.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdContoRomana.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdContoRomana.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdContoRomana.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdContoRomana.Location = New System.Drawing.Point(360, 8)
      Me.cmdContoRomana.Name = "cmdContoRomana"
      Me.cmdContoRomana.Size = New System.Drawing.Size(168, 88)
      Me.cmdContoRomana.TabIndex = 2
      Me.cmdContoRomana.Text = "ALLA ROMANA"
      Me.cmdContoRomana.UseVisualStyleBackColor = False
      '
      'cmdContoSeparato
      '
      Me.cmdContoSeparato.BackColor = System.Drawing.Color.White
      Me.cmdContoSeparato.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdContoSeparato.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdContoSeparato.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdContoSeparato.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdContoSeparato.Location = New System.Drawing.Point(184, 8)
      Me.cmdContoSeparato.Name = "cmdContoSeparato"
      Me.cmdContoSeparato.Size = New System.Drawing.Size(168, 88)
      Me.cmdContoSeparato.TabIndex = 1
      Me.cmdContoSeparato.Text = "SEPARATO MANUALE"
      Me.cmdContoSeparato.UseVisualStyleBackColor = False
      '
      'cmdContoUnico
      '
      Me.cmdContoUnico.BackColor = System.Drawing.Color.White
      Me.cmdContoUnico.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdContoUnico.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdContoUnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdContoUnico.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdContoUnico.Location = New System.Drawing.Point(8, 8)
      Me.cmdContoUnico.Name = "cmdContoUnico"
      Me.cmdContoUnico.Size = New System.Drawing.Size(168, 88)
      Me.cmdContoUnico.TabIndex = 0
      Me.cmdContoUnico.Text = "UNICO"
      Me.cmdContoUnico.UseVisualStyleBackColor = False
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
      'TipoContoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(689, 344)
      Me.Controls.Add(Me.cmdAnnulla)
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

   Private Sub cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdContoUnico_Click(sender As System.Object, e As System.EventArgs) Handles cmdContoUnico.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = cmdContoUnico.Text
      Me.Close()
   End Sub

   Private Sub cmdContoSeparato_Click(sender As System.Object, e As System.EventArgs) Handles cmdContoSeparato.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = cmdContoSeparato.Text
      Me.Close()
   End Sub

   Private Sub cmdContoRomana_Click(sender As System.Object, e As System.EventArgs) Handles cmdContoRomana.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = cmdContoRomana.Text
      Me.Close()
   End Sub
End Class
