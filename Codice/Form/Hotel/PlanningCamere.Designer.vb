<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PlanningCamere
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.dgvCamere = New System.Windows.Forms.DataGridView()
      Me.ColonnaCamere = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.pnlPrenotazioni = New System.Windows.Forms.Panel()
      Me.dgvPrenotazioni = New System.Windows.Forms.DataGridView()
      Me.ColonnaPren = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.dgvGiorni = New System.Windows.Forms.DataGridView()
      Me.ColonnaGiorni = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.pnlGenerale = New System.Windows.Forms.Panel()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.dtpCalendario = New System.Windows.Forms.DateTimePicker()
      Me.NetButton1 = New Softgroup.NetButton.NetButton()
      Me.lblDescrizioneCamera = New Elegant.Ui.Label()
      Me.dtpDataPlanning = New Elegant.Ui.DateTimePicker()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.dgvMesi = New System.Windows.Forms.DataGridView()
      Me.ColonnaMese = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.VerticalScrollBar1 = New Elegant.Ui.VerticalScrollBar()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.HorizontalScrollBar1 = New Elegant.Ui.HorizontalScrollBar()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ScreenTip1 = New Elegant.Ui.ScreenTip(Me.components)
      CType(Me.dgvCamere, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlPrenotazioni.SuspendLayout()
      CType(Me.dgvPrenotazioni, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvGiorni, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlGenerale.SuspendLayout()
      Me.Panel3.SuspendLayout()
      CType(Me.dgvMesi, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dgvCamere
      '
      Me.dgvCamere.AllowUserToResizeColumns = False
      Me.dgvCamere.AllowUserToResizeRows = False
      Me.dgvCamere.BackgroundColor = System.Drawing.Color.White
      Me.dgvCamere.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgvCamere.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      Me.dgvCamere.ColumnHeadersHeight = 40
      Me.dgvCamere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      Me.dgvCamere.ColumnHeadersVisible = False
      Me.dgvCamere.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColonnaCamere})
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvCamere.DefaultCellStyle = DataGridViewCellStyle1
      Me.dgvCamere.GridColor = System.Drawing.SystemColors.AppWorkspace
      Me.dgvCamere.Location = New System.Drawing.Point(0, 77)
      Me.dgvCamere.MultiSelect = False
      Me.dgvCamere.Name = "dgvCamere"
      Me.dgvCamere.ReadOnly = True
      Me.dgvCamere.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      Me.dgvCamere.RowHeadersVisible = False
      Me.dgvCamere.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
      Me.dgvCamere.ScrollBars = System.Windows.Forms.ScrollBars.None
      Me.dgvCamere.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.dgvCamere.ShowCellErrors = False
      Me.dgvCamere.Size = New System.Drawing.Size(336, 500)
      Me.dgvCamere.StandardTab = True
      Me.dgvCamere.TabIndex = 0
      '
      'ColonnaCamere
      '
      Me.ColonnaCamere.FillWeight = 15.22843!
      Me.ColonnaCamere.HeaderText = "Camera"
      Me.ColonnaCamere.Name = "ColonnaCamere"
      Me.ColonnaCamere.ReadOnly = True
      Me.ColonnaCamere.Width = 336
      '
      'pnlPrenotazioni
      '
      Me.pnlPrenotazioni.Controls.Add(Me.dgvPrenotazioni)
      Me.pnlPrenotazioni.Location = New System.Drawing.Point(335, 77)
      Me.pnlPrenotazioni.Name = "pnlPrenotazioni"
      Me.pnlPrenotazioni.Size = New System.Drawing.Size(512, 442)
      Me.pnlPrenotazioni.TabIndex = 2
      '
      'dgvPrenotazioni
      '
      Me.dgvPrenotazioni.AllowUserToDeleteRows = False
      Me.dgvPrenotazioni.AllowUserToResizeColumns = False
      Me.dgvPrenotazioni.AllowUserToResizeRows = False
      Me.dgvPrenotazioni.BackgroundColor = System.Drawing.Color.White
      Me.dgvPrenotazioni.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgvPrenotazioni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvPrenotazioni.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
      Me.dgvPrenotazioni.ColumnHeadersHeight = 25
      Me.dgvPrenotazioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      Me.dgvPrenotazioni.ColumnHeadersVisible = False
      Me.dgvPrenotazioni.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColonnaPren})
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvPrenotazioni.DefaultCellStyle = DataGridViewCellStyle3
      Me.dgvPrenotazioni.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgvPrenotazioni.GridColor = System.Drawing.SystemColors.AppWorkspace
      Me.dgvPrenotazioni.Location = New System.Drawing.Point(0, 0)
      Me.dgvPrenotazioni.MultiSelect = False
      Me.dgvPrenotazioni.Name = "dgvPrenotazioni"
      Me.dgvPrenotazioni.ReadOnly = True
      Me.dgvPrenotazioni.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      Me.dgvPrenotazioni.RowHeadersVisible = False
      Me.dgvPrenotazioni.RowHeadersWidth = 40
      Me.dgvPrenotazioni.RowTemplate.Height = 28
      Me.dgvPrenotazioni.RowTemplate.ReadOnly = True
      Me.dgvPrenotazioni.ScrollBars = System.Windows.Forms.ScrollBars.None
      Me.dgvPrenotazioni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.dgvPrenotazioni.ShowCellErrors = False
      Me.dgvPrenotazioni.ShowCellToolTips = False
      Me.dgvPrenotazioni.ShowEditingIcon = False
      Me.dgvPrenotazioni.ShowRowErrors = False
      Me.dgvPrenotazioni.Size = New System.Drawing.Size(512, 442)
      Me.dgvPrenotazioni.StandardTab = True
      Me.dgvPrenotazioni.TabIndex = 0
      '
      'ColonnaPren
      '
      Me.ColonnaPren.HeaderText = "Column1"
      Me.ColonnaPren.Name = "ColonnaPren"
      Me.ColonnaPren.ReadOnly = True
      Me.ColonnaPren.Width = 40
      '
      'dgvGiorni
      '
      Me.dgvGiorni.AllowUserToAddRows = False
      Me.dgvGiorni.AllowUserToDeleteRows = False
      Me.dgvGiorni.AllowUserToResizeColumns = False
      Me.dgvGiorni.AllowUserToResizeRows = False
      Me.dgvGiorni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvGiorni.BackgroundColor = System.Drawing.Color.White
      Me.dgvGiorni.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgvGiorni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvGiorni.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
      Me.dgvGiorni.ColumnHeadersHeight = 40
      Me.dgvGiorni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      Me.dgvGiorni.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColonnaGiorni})
      Me.dgvGiorni.EnableHeadersVisualStyles = False
      Me.dgvGiorni.GridColor = System.Drawing.SystemColors.AppWorkspace
      Me.dgvGiorni.Location = New System.Drawing.Point(335, 38)
      Me.dgvGiorni.MultiSelect = False
      Me.dgvGiorni.Name = "dgvGiorni"
      Me.dgvGiorni.ReadOnly = True
      Me.dgvGiorni.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      Me.dgvGiorni.RowHeadersVisible = False
      Me.dgvGiorni.RowHeadersWidth = 28
      Me.dgvGiorni.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
      Me.dgvGiorni.ScrollBars = System.Windows.Forms.ScrollBars.None
      Me.dgvGiorni.ShowCellErrors = False
      Me.dgvGiorni.Size = New System.Drawing.Size(754, 40)
      Me.dgvGiorni.StandardTab = True
      Me.dgvGiorni.TabIndex = 5
      Me.dgvGiorni.TabStop = False
      '
      'ColonnaGiorni
      '
      Me.ColonnaGiorni.HeaderText = "Lun 1"
      Me.ColonnaGiorni.Name = "ColonnaGiorni"
      Me.ColonnaGiorni.ReadOnly = True
      Me.ColonnaGiorni.Width = 40
      '
      'pnlGenerale
      '
      Me.pnlGenerale.Controls.Add(Me.Panel3)
      Me.pnlGenerale.Controls.Add(Me.dgvCamere)
      Me.pnlGenerale.Controls.Add(Me.Panel2)
      Me.pnlGenerale.Controls.Add(Me.dgvMesi)
      Me.pnlGenerale.Controls.Add(Me.dgvGiorni)
      Me.pnlGenerale.Controls.Add(Me.VerticalScrollBar1)
      Me.pnlGenerale.Controls.Add(Me.Panel1)
      Me.pnlGenerale.Controls.Add(Me.HorizontalScrollBar1)
      Me.pnlGenerale.Controls.Add(Me.pnlPrenotazioni)
      Me.pnlGenerale.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlGenerale.Location = New System.Drawing.Point(0, 0)
      Me.pnlGenerale.Name = "pnlGenerale"
      Me.pnlGenerale.Size = New System.Drawing.Size(1077, 585)
      Me.pnlGenerale.TabIndex = 3
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.White
      Me.Panel3.Controls.Add(Me.dtpCalendario)
      Me.Panel3.Controls.Add(Me.NetButton1)
      Me.Panel3.Controls.Add(Me.lblDescrizioneCamera)
      Me.Panel3.Controls.Add(Me.dtpDataPlanning)
      Me.Panel3.Location = New System.Drawing.Point(0, 0)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(335, 77)
      Me.Panel3.TabIndex = 15
      '
      'dtpCalendario
      '
      Me.dtpCalendario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtpCalendario.Location = New System.Drawing.Point(0, 24)
      Me.dtpCalendario.Name = "dtpCalendario"
      Me.dtpCalendario.Size = New System.Drawing.Size(168, 20)
      Me.dtpCalendario.TabIndex = 4
      Me.dtpCalendario.TabStop = False
      Me.dtpCalendario.Visible = False
      '
      'NetButton1
      '
      Me.NetButton1.ColorBottom = System.Drawing.Color.DimGray
      Me.NetButton1.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton1.ColorLight = System.Drawing.Color.WhiteSmoke
      Me.NetButton1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Gray
      Me.NetButton1.ColorText = System.Drawing.Color.Black
      Me.NetButton1.ColorTop = System.Drawing.Color.White
      Me.NetButton1.CornerRadius = 0
      Me.NetButton1.Location = New System.Drawing.Point(256, 32)
      Me.NetButton1.Name = "NetButton1"
      Me.ScreenTip1.GetScreenTip(Me.NetButton1).Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
      Me.NetButton1.Size = New System.Drawing.Size(72, 24)
      Me.NetButton1.TabIndex = 15
      Me.NetButton1.TextButtonAlign = System.Drawing.ContentAlignment.TopLeft
      Me.NetButton1.Visible = False
      '
      'lblDescrizioneCamera
      '
      Me.lblDescrizioneCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDescrizioneCamera.Location = New System.Drawing.Point(8, 48)
      Me.lblDescrizioneCamera.Name = "lblDescrizioneCamera"
      Me.lblDescrizioneCamera.Size = New System.Drawing.Size(232, 24)
      Me.lblDescrizioneCamera.TabIndex = 14
      Me.lblDescrizioneCamera.Text = "102 Matrimoniale Standard"
      '
      'dtpDataPlanning
      '
      Me.dtpDataPlanning.BannerText = "Controllo data"
      Me.dtpDataPlanning.BannerTextColor = System.Drawing.Color.Maroon
      Me.dtpDataPlanning.Dock = System.Windows.Forms.DockStyle.Top
      Me.dtpDataPlanning.Enabled = False
      Me.dtpDataPlanning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpDataPlanning.Id = "412df70f-19ae-4da7-a842-056f2f7c00a1"
      Me.dtpDataPlanning.Location = New System.Drawing.Point(0, 0)
      Me.dtpDataPlanning.Name = "dtpDataPlanning"
      Me.dtpDataPlanning.Size = New System.Drawing.Size(335, 24)
      Me.dtpDataPlanning.TabIndex = 0
      Me.dtpDataPlanning.TextEditorWidth = 299
      '
      'Panel2
      '
      Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel2.Location = New System.Drawing.Point(1061, -1)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(20, 81)
      Me.Panel2.TabIndex = 14
      '
      'dgvMesi
      '
      Me.dgvMesi.AllowUserToAddRows = False
      Me.dgvMesi.AllowUserToDeleteRows = False
      Me.dgvMesi.AllowUserToResizeColumns = False
      Me.dgvMesi.AllowUserToResizeRows = False
      Me.dgvMesi.BackgroundColor = System.Drawing.Color.White
      Me.dgvMesi.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgvMesi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvMesi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
      Me.dgvMesi.ColumnHeadersHeight = 40
      Me.dgvMesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      Me.dgvMesi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColonnaMese})
      Me.dgvMesi.EnableHeadersVisualStyles = False
      Me.dgvMesi.GridColor = System.Drawing.SystemColors.AppWorkspace
      Me.dgvMesi.Location = New System.Drawing.Point(335, -1)
      Me.dgvMesi.MultiSelect = False
      Me.dgvMesi.Name = "dgvMesi"
      Me.dgvMesi.ReadOnly = True
      Me.dgvMesi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      Me.dgvMesi.RowHeadersVisible = False
      Me.dgvMesi.RowHeadersWidth = 28
      Me.dgvMesi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
      Me.dgvMesi.ScrollBars = System.Windows.Forms.ScrollBars.None
      Me.dgvMesi.ShowCellErrors = False
      Me.dgvMesi.Size = New System.Drawing.Size(537, 40)
      Me.dgvMesi.StandardTab = True
      Me.dgvMesi.TabIndex = 10
      Me.dgvMesi.TabStop = False
      '
      'ColonnaMese
      '
      Me.ColonnaMese.HeaderText = "G e n n a i o  2 0 1 4"
      Me.ColonnaMese.Name = "ColonnaMese"
      Me.ColonnaMese.ReadOnly = True
      Me.ColonnaMese.Width = 1300
      '
      'VerticalScrollBar1
      '
      Me.VerticalScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.VerticalScrollBar1.LargeChange = 300
      Me.VerticalScrollBar1.Location = New System.Drawing.Point(1060, 80)
      Me.VerticalScrollBar1.Maximum = 100
      Me.VerticalScrollBar1.Minimum = 0
      Me.VerticalScrollBar1.Name = "VerticalScrollBar1"
      Me.VerticalScrollBar1.Size = New System.Drawing.Size(17, 489)
      Me.VerticalScrollBar1.SmallChange = 28
      Me.VerticalScrollBar1.TabIndex = 11
      Me.VerticalScrollBar1.Text = "VerticalScrollBar1"
      Me.VerticalScrollBar1.Value = 0
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.Location = New System.Drawing.Point(1061, 569)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(26, 22)
      Me.Panel1.TabIndex = 13
      '
      'HorizontalScrollBar1
      '
      Me.HorizontalScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.HorizontalScrollBar1.LargeChange = 1200
      Me.HorizontalScrollBar1.Location = New System.Drawing.Point(336, 568)
      Me.HorizontalScrollBar1.Maximum = 100
      Me.HorizontalScrollBar1.Minimum = 0
      Me.HorizontalScrollBar1.Name = "HorizontalScrollBar1"
      Me.HorizontalScrollBar1.Size = New System.Drawing.Size(725, 17)
      Me.HorizontalScrollBar1.SmallChange = 40
      Me.HorizontalScrollBar1.TabIndex = 9
      Me.HorizontalScrollBar1.Text = "HorizontalScrollBar1"
      Me.HorizontalScrollBar1.Value = 0
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'PlanningCamere
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.ClientSize = New System.Drawing.Size(1077, 585)
      Me.Controls.Add(Me.pnlGenerale)
      Me.Name = "PlanningCamere"
      Me.Text = "Planning camere"
      CType(Me.dgvCamere, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlPrenotazioni.ResumeLayout(False)
      CType(Me.dgvPrenotazioni, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvGiorni, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlGenerale.ResumeLayout(False)
      Me.pnlGenerale.PerformLayout()
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      CType(Me.dgvMesi, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents dgvCamere As System.Windows.Forms.DataGridView
   Friend WithEvents pnlPrenotazioni As System.Windows.Forms.Panel
   Friend WithEvents dgvGiorni As System.Windows.Forms.DataGridView
   Friend WithEvents dgvPrenotazioni As System.Windows.Forms.DataGridView
   Friend WithEvents pnlGenerale As System.Windows.Forms.Panel
   Friend WithEvents HorizontalScrollBar1 As Elegant.Ui.HorizontalScrollBar
   Friend WithEvents dgvMesi As System.Windows.Forms.DataGridView
   Friend WithEvents VerticalScrollBar1 As Elegant.Ui.VerticalScrollBar
   Friend WithEvents dtpCalendario As System.Windows.Forms.DateTimePicker
   Friend WithEvents ColonnaPren As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ColonnaGiorni As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ColonnaMese As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ColonnaCamere As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
   Friend WithEvents dtpDataPlanning As Elegant.Ui.DateTimePicker
   Friend WithEvents lblDescrizioneCamera As Elegant.Ui.Label
   Friend WithEvents NetButton1 As Softgroup.NetButton.NetButton
   Friend WithEvents ScreenTip1 As Elegant.Ui.ScreenTip
End Class
