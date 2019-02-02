
Public Class Contanti
   Inherits System.Windows.Forms.Form

   Private CFormatta As New ClsFormatta

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

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
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents cmdRicevuta As System.Windows.Forms.Button
   Friend WithEvents cmdEuro500 As System.Windows.Forms.Button
   Friend WithEvents cmdOk As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents cmdEuro2c As System.Windows.Forms.Button
   Friend WithEvents cmdEuro5c As System.Windows.Forms.Button
   Friend WithEvents cmdEuro10c As System.Windows.Forms.Button
   Friend WithEvents cmdEuro20c As System.Windows.Forms.Button
   Friend WithEvents cmdEuro50c As System.Windows.Forms.Button
   Friend WithEvents cmdEuro1 As System.Windows.Forms.Button
   Friend WithEvents cmdEuro2 As System.Windows.Forms.Button
   Friend WithEvents cmdEuro1c As System.Windows.Forms.Button
   Friend WithEvents cmdEuro5 As System.Windows.Forms.Button
   Friend WithEvents cmdEuro10 As System.Windows.Forms.Button
   Friend WithEvents cmdEuro20 As System.Windows.Forms.Button
   Friend WithEvents cmdEuro50 As System.Windows.Forms.Button
   Friend WithEvents cmdEuro100 As System.Windows.Forms.Button
   Friend WithEvents cmdEuro200 As System.Windows.Forms.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdContanti As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contanti))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.cmdContanti = New System.Windows.Forms.Button()
      Me.cmdEuro2c = New System.Windows.Forms.Button()
      Me.cmdEuro5c = New System.Windows.Forms.Button()
      Me.cmdEuro10c = New System.Windows.Forms.Button()
      Me.cmdEuro20c = New System.Windows.Forms.Button()
      Me.cmdEuro50c = New System.Windows.Forms.Button()
      Me.cmdEuro1 = New System.Windows.Forms.Button()
      Me.cmdEuro2 = New System.Windows.Forms.Button()
      Me.cmdEuro1c = New System.Windows.Forms.Button()
      Me.cmdEuro5 = New System.Windows.Forms.Button()
      Me.cmdEuro10 = New System.Windows.Forms.Button()
      Me.cmdEuro20 = New System.Windows.Forms.Button()
      Me.cmdEuro50 = New System.Windows.Forms.Button()
      Me.cmdEuro100 = New System.Windows.Forms.Button()
      Me.cmdEuro200 = New System.Windows.Forms.Button()
      Me.cmdEuro500 = New System.Windows.Forms.Button()
      Me.cmdRicevuta = New System.Windows.Forms.Button()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
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
      'Panel1
      '
      Me.Panel1.AutoScroll = True
      Me.Panel1.Controls.Add(Me.cmdContanti)
      Me.Panel1.Controls.Add(Me.cmdEuro2c)
      Me.Panel1.Controls.Add(Me.cmdEuro5c)
      Me.Panel1.Controls.Add(Me.cmdEuro10c)
      Me.Panel1.Controls.Add(Me.cmdEuro20c)
      Me.Panel1.Controls.Add(Me.cmdEuro50c)
      Me.Panel1.Controls.Add(Me.cmdEuro1)
      Me.Panel1.Controls.Add(Me.cmdEuro2)
      Me.Panel1.Controls.Add(Me.cmdEuro1c)
      Me.Panel1.Controls.Add(Me.cmdEuro5)
      Me.Panel1.Controls.Add(Me.cmdEuro10)
      Me.Panel1.Controls.Add(Me.cmdEuro20)
      Me.Panel1.Controls.Add(Me.cmdEuro50)
      Me.Panel1.Controls.Add(Me.cmdEuro100)
      Me.Panel1.Controls.Add(Me.cmdEuro200)
      Me.Panel1.Controls.Add(Me.cmdEuro500)
      Me.Panel1.Controls.Add(Me.cmdRicevuta)
      Me.Panel1.Location = New System.Drawing.Point(8, 8)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(624, 408)
      Me.Panel1.TabIndex = 228
      '
      'cmdContanti
      '
      Me.cmdContanti.BackColor = System.Drawing.Color.White
      Me.cmdContanti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdContanti.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdContanti.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdContanti.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdContanti.Location = New System.Drawing.Point(434, 305)
      Me.cmdContanti.Name = "cmdContanti"
      Me.cmdContanti.Size = New System.Drawing.Size(183, 98)
      Me.cmdContanti.TabIndex = 229
      Me.cmdContanti.Text = "0,00"
      Me.cmdContanti.UseVisualStyleBackColor = False
      '
      'cmdEuro2c
      '
      Me.cmdEuro2c.BackColor = System.Drawing.Color.White
      Me.cmdEuro2c.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro2c.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro2c.ForeColor = System.Drawing.Color.White
      Me.cmdEuro2c.Image = CType(resources.GetObject("cmdEuro2c.Image"), System.Drawing.Image)
      Me.cmdEuro2c.Location = New System.Drawing.Point(8, 305)
      Me.cmdEuro2c.Name = "cmdEuro2c"
      Me.cmdEuro2c.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro2c.TabIndex = 6
      Me.cmdEuro2c.UseVisualStyleBackColor = False
      '
      'cmdEuro5c
      '
      Me.cmdEuro5c.BackColor = System.Drawing.Color.White
      Me.cmdEuro5c.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro5c.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro5c.ForeColor = System.Drawing.Color.White
      Me.cmdEuro5c.Image = CType(resources.GetObject("cmdEuro5c.Image"), System.Drawing.Image)
      Me.cmdEuro5c.Location = New System.Drawing.Point(129, 206)
      Me.cmdEuro5c.Name = "cmdEuro5c"
      Me.cmdEuro5c.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro5c.TabIndex = 5
      Me.cmdEuro5c.UseVisualStyleBackColor = False
      '
      'cmdEuro10c
      '
      Me.cmdEuro10c.BackColor = System.Drawing.Color.White
      Me.cmdEuro10c.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro10c.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro10c.ForeColor = System.Drawing.Color.White
      Me.cmdEuro10c.Image = CType(resources.GetObject("cmdEuro10c.Image"), System.Drawing.Image)
      Me.cmdEuro10c.Location = New System.Drawing.Point(8, 206)
      Me.cmdEuro10c.Name = "cmdEuro10c"
      Me.cmdEuro10c.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro10c.TabIndex = 4
      Me.cmdEuro10c.UseVisualStyleBackColor = False
      '
      'cmdEuro20c
      '
      Me.cmdEuro20c.BackColor = System.Drawing.Color.White
      Me.cmdEuro20c.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro20c.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro20c.ForeColor = System.Drawing.Color.White
      Me.cmdEuro20c.Image = CType(resources.GetObject("cmdEuro20c.Image"), System.Drawing.Image)
      Me.cmdEuro20c.Location = New System.Drawing.Point(129, 107)
      Me.cmdEuro20c.Name = "cmdEuro20c"
      Me.cmdEuro20c.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro20c.TabIndex = 3
      Me.cmdEuro20c.UseVisualStyleBackColor = False
      '
      'cmdEuro50c
      '
      Me.cmdEuro50c.BackColor = System.Drawing.Color.White
      Me.cmdEuro50c.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro50c.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro50c.ForeColor = System.Drawing.Color.White
      Me.cmdEuro50c.Image = CType(resources.GetObject("cmdEuro50c.Image"), System.Drawing.Image)
      Me.cmdEuro50c.Location = New System.Drawing.Point(8, 107)
      Me.cmdEuro50c.Name = "cmdEuro50c"
      Me.cmdEuro50c.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro50c.TabIndex = 2
      Me.cmdEuro50c.UseVisualStyleBackColor = False
      '
      'cmdEuro1
      '
      Me.cmdEuro1.BackColor = System.Drawing.Color.White
      Me.cmdEuro1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro1.ForeColor = System.Drawing.Color.White
      Me.cmdEuro1.Image = CType(resources.GetObject("cmdEuro1.Image"), System.Drawing.Image)
      Me.cmdEuro1.Location = New System.Drawing.Point(129, 8)
      Me.cmdEuro1.Name = "cmdEuro1"
      Me.cmdEuro1.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro1.TabIndex = 1
      Me.cmdEuro1.UseVisualStyleBackColor = False
      '
      'cmdEuro2
      '
      Me.cmdEuro2.BackColor = System.Drawing.Color.White
      Me.cmdEuro2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro2.ForeColor = System.Drawing.Color.White
      Me.cmdEuro2.Image = CType(resources.GetObject("cmdEuro2.Image"), System.Drawing.Image)
      Me.cmdEuro2.Location = New System.Drawing.Point(8, 8)
      Me.cmdEuro2.Name = "cmdEuro2"
      Me.cmdEuro2.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro2.TabIndex = 0
      Me.cmdEuro2.UseVisualStyleBackColor = False
      '
      'cmdEuro1c
      '
      Me.cmdEuro1c.BackColor = System.Drawing.Color.White
      Me.cmdEuro1c.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro1c.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro1c.ForeColor = System.Drawing.Color.White
      Me.cmdEuro1c.Image = CType(resources.GetObject("cmdEuro1c.Image"), System.Drawing.Image)
      Me.cmdEuro1c.Location = New System.Drawing.Point(129, 305)
      Me.cmdEuro1c.Name = "cmdEuro1c"
      Me.cmdEuro1c.Size = New System.Drawing.Size(120, 98)
      Me.cmdEuro1c.TabIndex = 7
      Me.cmdEuro1c.UseVisualStyleBackColor = False
      '
      'cmdEuro5
      '
      Me.cmdEuro5.BackColor = System.Drawing.Color.Transparent
      Me.cmdEuro5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro5.ForeColor = System.Drawing.Color.White
      Me.cmdEuro5.Image = CType(resources.GetObject("cmdEuro5.Image"), System.Drawing.Image)
      Me.cmdEuro5.Location = New System.Drawing.Point(250, 305)
      Me.cmdEuro5.Name = "cmdEuro5"
      Me.cmdEuro5.Size = New System.Drawing.Size(183, 98)
      Me.cmdEuro5.TabIndex = 14
      Me.cmdEuro5.UseVisualStyleBackColor = False
      '
      'cmdEuro10
      '
      Me.cmdEuro10.BackColor = System.Drawing.Color.Transparent
      Me.cmdEuro10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro10.ForeColor = System.Drawing.Color.White
      Me.cmdEuro10.Image = CType(resources.GetObject("cmdEuro10.Image"), System.Drawing.Image)
      Me.cmdEuro10.Location = New System.Drawing.Point(434, 206)
      Me.cmdEuro10.Name = "cmdEuro10"
      Me.cmdEuro10.Size = New System.Drawing.Size(183, 98)
      Me.cmdEuro10.TabIndex = 13
      Me.cmdEuro10.UseVisualStyleBackColor = False
      '
      'cmdEuro20
      '
      Me.cmdEuro20.BackColor = System.Drawing.Color.Transparent
      Me.cmdEuro20.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro20.ForeColor = System.Drawing.Color.White
      Me.cmdEuro20.Image = CType(resources.GetObject("cmdEuro20.Image"), System.Drawing.Image)
      Me.cmdEuro20.Location = New System.Drawing.Point(250, 206)
      Me.cmdEuro20.Name = "cmdEuro20"
      Me.cmdEuro20.Size = New System.Drawing.Size(183, 98)
      Me.cmdEuro20.TabIndex = 12
      Me.cmdEuro20.UseVisualStyleBackColor = False
      '
      'cmdEuro50
      '
      Me.cmdEuro50.BackColor = System.Drawing.Color.Transparent
      Me.cmdEuro50.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro50.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro50.ForeColor = System.Drawing.Color.White
      Me.cmdEuro50.Image = CType(resources.GetObject("cmdEuro50.Image"), System.Drawing.Image)
      Me.cmdEuro50.Location = New System.Drawing.Point(434, 107)
      Me.cmdEuro50.Name = "cmdEuro50"
      Me.cmdEuro50.Size = New System.Drawing.Size(183, 98)
      Me.cmdEuro50.TabIndex = 11
      Me.cmdEuro50.UseVisualStyleBackColor = False
      '
      'cmdEuro100
      '
      Me.cmdEuro100.BackColor = System.Drawing.Color.Transparent
      Me.cmdEuro100.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro100.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro100.ForeColor = System.Drawing.Color.White
      Me.cmdEuro100.Image = CType(resources.GetObject("cmdEuro100.Image"), System.Drawing.Image)
      Me.cmdEuro100.Location = New System.Drawing.Point(250, 107)
      Me.cmdEuro100.Name = "cmdEuro100"
      Me.cmdEuro100.Size = New System.Drawing.Size(183, 98)
      Me.cmdEuro100.TabIndex = 10
      Me.cmdEuro100.UseVisualStyleBackColor = False
      '
      'cmdEuro200
      '
      Me.cmdEuro200.BackColor = System.Drawing.Color.Transparent
      Me.cmdEuro200.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro200.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro200.ForeColor = System.Drawing.Color.White
      Me.cmdEuro200.Image = CType(resources.GetObject("cmdEuro200.Image"), System.Drawing.Image)
      Me.cmdEuro200.Location = New System.Drawing.Point(434, 8)
      Me.cmdEuro200.Name = "cmdEuro200"
      Me.cmdEuro200.Size = New System.Drawing.Size(183, 98)
      Me.cmdEuro200.TabIndex = 9
      Me.cmdEuro200.UseVisualStyleBackColor = False
      '
      'cmdEuro500
      '
      Me.cmdEuro500.BackColor = System.Drawing.Color.Transparent
      Me.cmdEuro500.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEuro500.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEuro500.ForeColor = System.Drawing.Color.White
      Me.cmdEuro500.Image = CType(resources.GetObject("cmdEuro500.Image"), System.Drawing.Image)
      Me.cmdEuro500.Location = New System.Drawing.Point(250, 8)
      Me.cmdEuro500.Name = "cmdEuro500"
      Me.cmdEuro500.Size = New System.Drawing.Size(183, 98)
      Me.cmdEuro500.TabIndex = 8
      Me.cmdEuro500.UseVisualStyleBackColor = False
      '
      'cmdRicevuta
      '
      Me.cmdRicevuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdRicevuta.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdRicevuta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdRicevuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdRicevuta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.cmdRicevuta.Location = New System.Drawing.Point(329, -76)
      Me.cmdRicevuta.Name = "cmdRicevuta"
      Me.cmdRicevuta.Size = New System.Drawing.Size(184, 76)
      Me.cmdRicevuta.TabIndex = 228
      Me.cmdRicevuta.Text = "&RICEVUTA FISCALE"
      Me.cmdRicevuta.UseVisualStyleBackColor = False
      '
      'cmdOk
      '
      Me.cmdOk.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdOk.ForeColor = System.Drawing.Color.White
      Me.cmdOk.Location = New System.Drawing.Point(640, 16)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(128, 56)
      Me.cmdOk.TabIndex = 0
      Me.cmdOk.Text = "&OK"
      Me.cmdOk.UseVisualStyleBackColor = False
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.BackColor = System.Drawing.Color.LightCoral
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnnulla.ForeColor = System.Drawing.Color.White
      Me.cmdAnnulla.Location = New System.Drawing.Point(640, 80)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(128, 56)
      Me.cmdAnnulla.TabIndex = 1
      Me.cmdAnnulla.Text = "&ANNULLA"
      Me.cmdAnnulla.UseVisualStyleBackColor = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Contanti
      '
      Me.AcceptButton = Me.cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(779, 424)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdOk)
      Me.Controls.Add(Me.Panel1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Contanti"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "CONTANTI"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Function SommaBanconota(ByVal banconota As Double) As String
      Dim contanti As Double = CDbl(cmdContanti.Text)

      Return CStr(contanti + banconota)

   End Function

   Private Sub Pagamenti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      cmdContanti.Text = VALORE_ZERO
   End Sub

   Private Sub cmdContanti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContanti.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = VALORE_ZERO
   End Sub

   Private Sub cmdEuro2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(2))
   End Sub

   Private Sub cmdEuro1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(1))
   End Sub

   Private Sub cmdEuro50c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro50c.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(0.5))
   End Sub

   Private Sub cmdEuro20c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro20c.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(0.2))
   End Sub

   Private Sub cmdEuro10c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro10c.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(0.1))
   End Sub

   Private Sub cmdEuro5c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro5c.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(0.05))
   End Sub

   Private Sub cmdEuro2c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro2c.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(0.02))
   End Sub

   Private Sub cmdEuro1c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro1c.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(0.01))
   End Sub

   Private Sub cmdEuro500_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro500.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(500))
   End Sub

   Private Sub cmdEuro200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro200.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(200))
   End Sub

   Private Sub cmdEuro100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro100.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(100))
   End Sub

   Private Sub cmdEuro50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro50.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(50))
   End Sub

   Private Sub cmdEuro20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro20.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(20))
   End Sub

   Private Sub cmdEuro10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro10.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(10))
   End Sub

   Private Sub cmdEuro5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEuro5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      cmdContanti.Text = CFormatta.FormattaNumeroDouble(SommaBanconota(5))
   End Sub

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = cmdContanti.Text
      Me.Close()
   End Sub
End Class
