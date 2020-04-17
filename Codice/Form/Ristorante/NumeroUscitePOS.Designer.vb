<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NumeroUscitePOS
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
   'Non modificarla mediante l'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NumeroUscitePOS))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.netBtn_Uscita5 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Uscita4 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Uscita3 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Uscita2 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Uscita1 = New Softgroup.NetButton.NetButton()
      Me.pnlPag.SuspendLayout()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "4328f694-a5cd-4187-b1f9-98b428db96a3"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(232, 313)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 5
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'pnlPag
      '
      Me.pnlPag.AutoScroll = True
      Me.pnlPag.Controls.Add(Me.netBtn_Uscita5)
      Me.pnlPag.Controls.Add(Me.netBtn_Uscita4)
      Me.pnlPag.Controls.Add(Me.netBtn_Uscita3)
      Me.pnlPag.Controls.Add(Me.netBtn_Uscita2)
      Me.pnlPag.Controls.Add(Me.netBtn_Uscita1)
      Me.pnlPag.Location = New System.Drawing.Point(12, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(354, 302)
      Me.pnlPag.TabIndex = 230
      '
      'netBtn_Uscita5
      '
      Me.netBtn_Uscita5.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Uscita5.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Uscita5.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Uscita5.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Uscita5.ColorText = System.Drawing.Color.White
      Me.netBtn_Uscita5.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Uscita5.CornerRadius = 2
      Me.netBtn_Uscita5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Uscita5.Location = New System.Drawing.Point(6, 200)
      Me.netBtn_Uscita5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Uscita5.Name = "netBtn_Uscita5"
      Me.netBtn_Uscita5.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Uscita5.TabIndex = 4
      Me.netBtn_Uscita5.TextButton = "Uscita 5"
      '
      'netBtn_Uscita4
      '
      Me.netBtn_Uscita4.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Uscita4.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Uscita4.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Uscita4.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Uscita4.ColorText = System.Drawing.Color.White
      Me.netBtn_Uscita4.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Uscita4.CornerRadius = 2
      Me.netBtn_Uscita4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Uscita4.Location = New System.Drawing.Point(180, 104)
      Me.netBtn_Uscita4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Uscita4.Name = "netBtn_Uscita4"
      Me.netBtn_Uscita4.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Uscita4.TabIndex = 3
      Me.netBtn_Uscita4.TextButton = "Uscita 4"
      '
      'netBtn_Uscita3
      '
      Me.netBtn_Uscita3.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Uscita3.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Uscita3.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Uscita3.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Uscita3.ColorText = System.Drawing.Color.White
      Me.netBtn_Uscita3.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Uscita3.CornerRadius = 2
      Me.netBtn_Uscita3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Uscita3.Location = New System.Drawing.Point(6, 104)
      Me.netBtn_Uscita3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Uscita3.Name = "netBtn_Uscita3"
      Me.netBtn_Uscita3.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Uscita3.TabIndex = 2
      Me.netBtn_Uscita3.TextButton = "Uscita 3"
      '
      'netBtn_Uscita2
      '
      Me.netBtn_Uscita2.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Uscita2.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Uscita2.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Uscita2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Uscita2.ColorText = System.Drawing.Color.White
      Me.netBtn_Uscita2.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Uscita2.CornerRadius = 2
      Me.netBtn_Uscita2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Uscita2.Location = New System.Drawing.Point(180, 8)
      Me.netBtn_Uscita2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Uscita2.Name = "netBtn_Uscita2"
      Me.netBtn_Uscita2.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Uscita2.TabIndex = 1
      Me.netBtn_Uscita2.TextButton = "Uscita 2"
      '
      'netBtn_Uscita1
      '
      Me.netBtn_Uscita1.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Uscita1.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Uscita1.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Uscita1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Uscita1.ColorText = System.Drawing.Color.White
      Me.netBtn_Uscita1.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Uscita1.CornerRadius = 2
      Me.netBtn_Uscita1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Uscita1.Location = New System.Drawing.Point(4, 8)
      Me.netBtn_Uscita1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Uscita1.Name = "netBtn_Uscita1"
      Me.netBtn_Uscita1.Size = New System.Drawing.Size(168, 88)
      Me.netBtn_Uscita1.TabIndex = 0
      Me.netBtn_Uscita1.TextButton = "Uscita 1"
      '
      'NumeroUscitePOS
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(380, 380)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "NumeroUscitePOS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "ORDINE DI USCITA"
      Me.pnlPag.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents pnlPag As Panel
   Friend WithEvents netBtn_Uscita4 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Uscita3 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Uscita2 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Uscita1 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Uscita5 As Softgroup.NetButton.NetButton
End Class
