Imports System.Data.OleDb

Public Class frmPostazione
   Inherits System.Windows.Forms.Form

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
   Friend WithEvents cmdOK As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Public WithEvents label As System.Windows.Forms.Label
   Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents nudNumero As System.Windows.Forms.NumericUpDown
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPostazione))
      Me.cmdOK = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.label = New System.Windows.Forms.Label()
      Me.PictureBox2 = New System.Windows.Forms.PictureBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.nudNumero = New System.Windows.Forms.NumericUpDown()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudNumero, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cmdOK
      '
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(208, 136)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(75, 23)
      Me.cmdOK.TabIndex = 2
      Me.cmdOK.Text = "&OK"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(288, 136)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(75, 23)
      Me.cmdAnnulla.TabIndex = 3
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(176, 24)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(47, 13)
      Me.label.TabIndex = 182
      Me.label.Text = "Numero:"
      '
      'PictureBox2
      '
      Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
      Me.PictureBox2.Location = New System.Drawing.Point(8, 0)
      Me.PictureBox2.Name = "PictureBox2"
      Me.PictureBox2.Size = New System.Drawing.Size(160, 160)
      Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox2.TabIndex = 185
      Me.PictureBox2.TabStop = False
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'nudNumero
      '
      Me.nudNumero.Location = New System.Drawing.Point(176, 40)
      Me.nudNumero.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudNumero.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudNumero.Name = "nudNumero"
      Me.nudNumero.Size = New System.Drawing.Size(192, 20)
      Me.nudNumero.TabIndex = 0
      Me.nudNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudNumero.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'txtDescrizione
      '
      Me.txtDescrizione.Location = New System.Drawing.Point(176, 88)
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.Size = New System.Drawing.Size(192, 20)
      Me.txtDescrizione.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(176, 72)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(65, 13)
      Me.Label1.TabIndex = 188
      Me.Label1.Text = "Descrizione:"
      '
      'frmPostazione
      '
      Me.AcceptButton = Me.cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(378, 170)
      Me.Controls.Add(Me.txtDescrizione)
      Me.Controls.Add(Me.nudNumero)
      Me.Controls.Add(Me.PictureBox2)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.label)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPostazione"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Postazione - P0001"
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudNumero, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Dim DatiConfig As AppConfig
   Dim nomePostazione As String

   Private Sub LeggiDatiConfig()
      Try

         If DatiConfig.GetValue("NomePostazione") <> String.Empty Then
            Dim val As String = DatiConfig.GetValue("NomePostazione").Replace("P", "0")
            nudNumero.Value = Convert.ToDecimal(val)
         Else
            nudNumero.Value = 1
         End If

         txtDescrizione.Text = DatiConfig.GetValue("DescrizionePostazione")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try

         DatiConfig.SetValue("NomePostazione", nomePostazione)
         DatiConfig.SetValue("DescrizionePostazione", txtDescrizione.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmPostazione_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         LeggiDatiConfig()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
      Try
         g_frmMain.eui_cmdPostazione.Text = nomePostazione
         g_frmMain.eui_cmdPostazione.ScreenTip.Text = txtDescrizione.Text

         SalvaDatiConfig()

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

  
   Private Sub nudNumero_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudNumero.ValueChanged
      Dim val As String

      Select Case nudNumero.Value.ToString.Length
         Case 1
            val = "P000" & nudNumero.Value.ToString

         Case 2
            val = "P00" & nudNumero.Value.ToString

         Case 3
            val = "P0" & nudNumero.Value.ToString

         Case 4
            val = "P" & nudNumero.Value.ToString

      End Select

      Me.Text = "Postazione - " & val

      nomePostazione = val

   End Sub
End Class
