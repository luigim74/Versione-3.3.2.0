<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiudizioDemo
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGiudizioDemo))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Label1 = New Elegant.Ui.Label()
      Me.Label2 = New Elegant.Ui.Label()
      Me.Label3 = New Elegant.Ui.Label()
      Me.Label4 = New Elegant.Ui.Label()
      Me.nudVotoSemplicità = New Elegant.Ui.NumericUpDown()
      Me.nudVotoUtilità = New Elegant.Ui.NumericUpDown()
      Me.nudVotoGrafica = New Elegant.Ui.NumericUpDown()
      Me.Label5 = New Elegant.Ui.Label()
      Me.txtCommento = New Elegant.Ui.TextBox()
      Me.cmdInvia = New Elegant.Ui.Button()
      Me.cmdEsci = New Elegant.Ui.Button()
      Me.Label7 = New System.Windows.Forms.Label()
      CType(Me.nudVotoSemplicità, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudVotoUtilità, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudVotoGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(24, 120)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(287, 16)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Quanto reputi SEMPLICE l'utilizzo del programma da 1 a 10 ?"
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(24, 184)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(313, 16)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Quanto ti è piaciuta l'interfaccia GRAFICA del prodotto da 1 a 10 ?"
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(24, 152)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(409, 16)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Quanto reputi UTILE questo software per il tuo lavoro da 1 a 10 ?"
      '
      'Label4
      '
      Me.Label4.AutoSize = False
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.Location = New System.Drawing.Point(24, 32)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(424, 72)
      Me.Label4.TabIndex = 4
      Me.Label4.Text = resources.GetString("Label4.Text")
      '
      'nudVotoSemplicità
      '
      Me.nudVotoSemplicità.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.nudVotoSemplicità.Id = "c7b22858-81f2-47c4-bdd8-b48661334c95"
      Me.nudVotoSemplicità.Location = New System.Drawing.Point(392, 120)
      Me.nudVotoSemplicità.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.nudVotoSemplicità.Name = "nudVotoSemplicità"
      Me.nudVotoSemplicità.Size = New System.Drawing.Size(56, 21)
      Me.nudVotoSemplicità.TabIndex = 0
      Me.nudVotoSemplicità.TextEditorWidth = 33
      '
      'nudVotoUtilità
      '
      Me.nudVotoUtilità.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.nudVotoUtilità.Id = "645cfad1-4235-409b-8e0d-f36e8e2fc4ae"
      Me.nudVotoUtilità.Location = New System.Drawing.Point(392, 152)
      Me.nudVotoUtilità.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.nudVotoUtilità.Name = "nudVotoUtilità"
      Me.nudVotoUtilità.Size = New System.Drawing.Size(56, 21)
      Me.nudVotoUtilità.TabIndex = 1
      Me.nudVotoUtilità.TextEditorWidth = 33
      '
      'nudVotoGrafica
      '
      Me.nudVotoGrafica.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.nudVotoGrafica.Id = "4ef7a7d7-93f4-4f0a-ab1e-758191139cee"
      Me.nudVotoGrafica.Location = New System.Drawing.Point(392, 184)
      Me.nudVotoGrafica.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.nudVotoGrafica.Name = "nudVotoGrafica"
      Me.nudVotoGrafica.Size = New System.Drawing.Size(56, 21)
      Me.nudVotoGrafica.TabIndex = 2
      Me.nudVotoGrafica.TextEditorWidth = 33
      '
      'Label5
      '
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.Location = New System.Drawing.Point(24, 232)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(296, 16)
      Me.Label5.TabIndex = 8
      Me.Label5.Text = "Lascia un commento, suggerimento, critica positiva o negativa:"
      '
      'txtCommento
      '
      Me.txtCommento.Id = "b21c73ab-bd10-4e16-8c09-1b88aba4d1d1"
      Me.txtCommento.Location = New System.Drawing.Point(24, 256)
      Me.txtCommento.Multiline = True
      Me.txtCommento.Name = "txtCommento"
      Me.txtCommento.Size = New System.Drawing.Size(424, 136)
      Me.txtCommento.TabIndex = 3
      Me.txtCommento.TextEditorWidth = 418
      '
      'cmdInvia
      '
      Me.cmdInvia.Id = "05960bb7-2399-432c-9b69-74396e9db2ba"
      Me.cmdInvia.KeyTip = "I"
      Me.cmdInvia.Location = New System.Drawing.Point(248, 406)
      Me.cmdInvia.Name = "cmdInvia"
      Me.cmdInvia.Size = New System.Drawing.Size(96, 32)
      Me.cmdInvia.TabIndex = 4
      Me.cmdInvia.Text = "&Invia giudizio"
      '
      'cmdEsci
      '
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.Id = "d62d71f4-aff7-4096-a1e4-70aa95c12a35"
      Me.cmdEsci.KeyTip = "E"
      Me.cmdEsci.Location = New System.Drawing.Point(352, 406)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(96, 32)
      Me.cmdEsci.TabIndex = 5
      Me.cmdEsci.Text = "&Esci"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.Red
      Me.Label7.Location = New System.Drawing.Point(22, 8)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(363, 16)
      Me.Label7.TabIndex = 13
      Me.Label7.Text = "GRAZIE PER AVERE PROVATO IL NOSTRO SOFTWARE!"
      '
      'frmGiudizioDemo
      '
      Me.AcceptButton = Me.cmdInvia
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdEsci
      Me.ClientSize = New System.Drawing.Size(467, 447)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.cmdEsci)
      Me.Controls.Add(Me.cmdInvia)
      Me.Controls.Add(Me.txtCommento)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.nudVotoGrafica)
      Me.Controls.Add(Me.nudVotoUtilità)
      Me.Controls.Add(Me.nudVotoSemplicità)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmGiudizioDemo"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "GiudizioDemo"
      CType(Me.nudVotoSemplicità, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudVotoUtilità, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudVotoGrafica, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents txtCommento As Elegant.Ui.TextBox
   Friend WithEvents Label5 As Elegant.Ui.Label
   Friend WithEvents nudVotoGrafica As Elegant.Ui.NumericUpDown
   Friend WithEvents nudVotoUtilità As Elegant.Ui.NumericUpDown
   Friend WithEvents nudVotoSemplicità As Elegant.Ui.NumericUpDown
   Friend WithEvents Label4 As Elegant.Ui.Label
   Friend WithEvents Label3 As Elegant.Ui.Label
   Friend WithEvents Label2 As Elegant.Ui.Label
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents cmdEsci As Elegant.Ui.Button
   Friend WithEvents cmdInvia As Elegant.Ui.Button
   Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
