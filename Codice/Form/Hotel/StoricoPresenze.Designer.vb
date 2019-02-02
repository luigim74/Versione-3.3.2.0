<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StoricoPresenze
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
   'Non modificarla mediante l'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
      Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
      Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 3.0R)
      Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint7 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint8 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint9 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint10 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim DataPoint11 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoricoPresenze))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_tpcPresenze = New Elegant.Ui.TabControl()
      Me.tpElenco = New Elegant.Ui.TabPage()
      Me.eui_txtTotalePresenze = New Elegant.Ui.TextBox()
      Me.Label2 = New Elegant.Ui.Label()
      Me.eui_txtTotaleOccupazione = New Elegant.Ui.TextBox()
      Me.Label18 = New Elegant.Ui.Label()
      Me.dgvDettagli = New System.Windows.Forms.DataGridView()
      Me.clnMese = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnPresenze = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnOccupazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tpGrafico = New Elegant.Ui.TabPage()
      Me.chartPresenze = New System.Windows.Forms.DataVisualization.Charting.Chart()
      Me.Label1 = New Elegant.Ui.Label()
      Me.eui_cmbTipologia = New Elegant.Ui.ComboBox()
      Me.eui_cmdStampa = New Elegant.Ui.Button()
      Me.eui_cmdEsci = New Elegant.Ui.Button()
      Me.Label3 = New Elegant.Ui.Label()
      Me.eui_cmbAnno = New Elegant.Ui.ComboBox()
      CType(Me.eui_tpcPresenze, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpElenco.SuspendLayout()
      CType(Me.dgvDettagli, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpGrafico.SuspendLayout()
      CType(Me.chartPresenze, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_tpcPresenze
      '
      Me.eui_tpcPresenze.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_tpcPresenze.EndScrollButtonVisible = True
      Me.eui_tpcPresenze.EqualTabHeight = True
      Me.eui_tpcPresenze.EqualTabWidth = True
      Me.eui_tpcPresenze.Location = New System.Drawing.Point(9, 9)
      Me.eui_tpcPresenze.Name = "eui_tpcPresenze"
      Me.eui_tpcPresenze.SelectedTabPage = Me.tpElenco
      Me.eui_tpcPresenze.Size = New System.Drawing.Size(706, 512)
      Me.eui_tpcPresenze.TabIndex = 1
      Me.eui_tpcPresenze.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.tpElenco, Me.tpGrafico})
      Me.eui_tpcPresenze.Text = " "
      '
      'tpElenco
      '
      Me.tpElenco.ActiveControl = Nothing
      Me.tpElenco.Controls.Add(Me.eui_txtTotalePresenze)
      Me.tpElenco.Controls.Add(Me.Label2)
      Me.tpElenco.Controls.Add(Me.eui_txtTotaleOccupazione)
      Me.tpElenco.Controls.Add(Me.Label18)
      Me.tpElenco.Controls.Add(Me.dgvDettagli)
      Me.tpElenco.KeyTip = Nothing
      Me.tpElenco.Name = "tpElenco"
      Me.tpElenco.Size = New System.Drawing.Size(704, 491)
      Me.tpElenco.TabIndex = 0
      Me.tpElenco.Text = "Elenco"
      '
      'eui_txtTotalePresenze
      '
      Me.eui_txtTotalePresenze.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTotalePresenze.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotalePresenze.Id = "93e5be5f-7b2f-45ff-a3b6-f0e2c54977b0"
      Me.eui_txtTotalePresenze.Location = New System.Drawing.Point(468, 456)
      Me.eui_txtTotalePresenze.Name = "eui_txtTotalePresenze"
      Me.eui_txtTotalePresenze.ReadOnly = True
      Me.eui_txtTotalePresenze.Size = New System.Drawing.Size(115, 21)
      Me.eui_txtTotalePresenze.TabIndex = 1
      Me.eui_txtTotalePresenze.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotalePresenze.TextEditorWidth = 109
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.Location = New System.Drawing.Point(468, 440)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(79, 16)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "Totale presenze:"
      '
      'eui_txtTotaleOccupazione
      '
      Me.eui_txtTotaleOccupazione.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTotaleOccupazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotaleOccupazione.Id = "e683d444-c6d4-41ea-9bda-3901b401a822"
      Me.eui_txtTotaleOccupazione.Location = New System.Drawing.Point(585, 456)
      Me.eui_txtTotaleOccupazione.Name = "eui_txtTotaleOccupazione"
      Me.eui_txtTotaleOccupazione.ReadOnly = True
      Me.eui_txtTotaleOccupazione.Size = New System.Drawing.Size(115, 21)
      Me.eui_txtTotaleOccupazione.TabIndex = 2
      Me.eui_txtTotaleOccupazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaleOccupazione.TextEditorWidth = 109
      '
      'Label18
      '
      Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label18.Location = New System.Drawing.Point(585, 440)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(116, 16)
      Me.Label18.TabIndex = 0
      Me.Label18.Text = "Totale % occupazione:"
      '
      'dgvDettagli
      '
      Me.dgvDettagli.AllowUserToDeleteRows = False
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Me.dgvDettagli.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDettagli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgvDettagli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDettagli.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnMese, Me.clnPresenze, Me.clnOccupazione})
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDettagli.DefaultCellStyle = DataGridViewCellStyle5
      Me.dgvDettagli.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
      Me.dgvDettagli.Location = New System.Drawing.Point(3, 3)
      Me.dgvDettagli.MultiSelect = False
      Me.dgvDettagli.Name = "dgvDettagli"
      Me.dgvDettagli.ReadOnly = True
      Me.dgvDettagli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDettagli.Size = New System.Drawing.Size(698, 424)
      Me.dgvDettagli.TabIndex = 0
      '
      'clnMese
      '
      Me.clnMese.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.NullValue = Nothing
      Me.clnMese.DefaultCellStyle = DataGridViewCellStyle2
      Me.clnMese.HeaderText = "Mese"
      Me.clnMese.Name = "clnMese"
      Me.clnMese.ReadOnly = True
      Me.clnMese.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.clnMese.ToolTipText = "Mese"
      '
      'clnPresenze
      '
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle3.Format = "N0"
      DataGridViewCellStyle3.NullValue = Nothing
      Me.clnPresenze.DefaultCellStyle = DataGridViewCellStyle3
      Me.clnPresenze.HeaderText = "Presenze"
      Me.clnPresenze.Name = "clnPresenze"
      Me.clnPresenze.ReadOnly = True
      Me.clnPresenze.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.clnPresenze.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.clnPresenze.ToolTipText = "Numero presenze"
      Me.clnPresenze.Width = 120
      '
      'clnOccupazione
      '
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red
      DataGridViewCellStyle4.Format = "N2"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.clnOccupazione.DefaultCellStyle = DataGridViewCellStyle4
      Me.clnOccupazione.HeaderText = "%  Occupazione"
      Me.clnOccupazione.Name = "clnOccupazione"
      Me.clnOccupazione.ReadOnly = True
      Me.clnOccupazione.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.clnOccupazione.ToolTipText = "Percentuale di occupazione"
      Me.clnOccupazione.Width = 120
      '
      'tpGrafico
      '
      Me.tpGrafico.ActiveControl = Nothing
      Me.tpGrafico.Controls.Add(Me.chartPresenze)
      Me.tpGrafico.KeyTip = Nothing
      Me.tpGrafico.Name = "tpGrafico"
      Me.tpGrafico.Size = New System.Drawing.Size(680, 467)
      Me.tpGrafico.TabIndex = 1
      Me.tpGrafico.Text = "Grafico"
      '
      'chartPresenze
      '
      Me.chartPresenze.BackColor = System.Drawing.SystemColors.AppWorkspace
      ChartArea1.Name = "ChartArea1"
      Me.chartPresenze.ChartAreas.Add(ChartArea1)
      Me.chartPresenze.Dock = System.Windows.Forms.DockStyle.Fill
      Me.chartPresenze.Location = New System.Drawing.Point(0, 0)
      Me.chartPresenze.Name = "chartPresenze"
      Series1.ChartArea = "ChartArea1"
      Series1.CustomProperties = "DrawingStyle=Cylinder, LabelStyle=Top"
      Series1.IsValueShownAsLabel = True
      Series1.Name = "Series1"
      DataPoint1.AxisLabel = ""
      DataPoint1.CustomProperties = "LabelStyle=Top"
      DataPoint1.IsValueShownAsLabel = True
      DataPoint1.IsVisibleInLegend = True
      DataPoint1.LegendText = ""
      DataPoint2.CustomProperties = "LabelStyle=Auto"
      DataPoint3.CustomProperties = "LabelStyle=Auto"
      Series1.Points.Add(DataPoint1)
      Series1.Points.Add(DataPoint2)
      Series1.Points.Add(DataPoint3)
      Series1.Points.Add(DataPoint4)
      Series1.Points.Add(DataPoint5)
      Series1.Points.Add(DataPoint6)
      Series1.Points.Add(DataPoint7)
      Series1.Points.Add(DataPoint8)
      Series1.Points.Add(DataPoint9)
      Series1.Points.Add(DataPoint10)
      Series1.Points.Add(DataPoint11)
      Me.chartPresenze.Series.Add(Series1)
      Me.chartPresenze.Size = New System.Drawing.Size(680, 467)
      Me.chartPresenze.TabIndex = 0
      Me.chartPresenze.Text = "Chart1"
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.Location = New System.Drawing.Point(727, 12)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(46, 16)
      Me.Label1.TabIndex = 11
      Me.Label1.Text = "Tipologia:"
      '
      'eui_cmbTipologia
      '
      Me.eui_cmbTipologia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbTipologia.Editable = False
      Me.eui_cmbTipologia.FormattingEnabled = False
      Me.eui_cmbTipologia.Id = "e3bad87f-e4ea-4c52-87fc-b9ef1d206b88"
      Me.eui_cmbTipologia.Items.AddRange(New Object() {"Hotel"})
      Me.eui_cmbTipologia.Location = New System.Drawing.Point(727, 28)
      Me.eui_cmbTipologia.Name = "eui_cmbTipologia"
      Me.eui_cmbTipologia.Size = New System.Drawing.Size(113, 21)
      Me.eui_cmbTipologia.Sorted = True
      Me.eui_cmbTipologia.TabIndex = 0
      Me.eui_cmbTipologia.Text = "Hotel"
      Me.eui_cmbTipologia.TextEditorWidth = 94
      '
      'eui_cmdStampa
      '
      Me.eui_cmdStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdStampa.Id = "63b7281d-2400-4a95-b56e-3706f3912fe3"
      Me.eui_cmdStampa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdStampa.Location = New System.Drawing.Point(727, 377)
      Me.eui_cmdStampa.Name = "eui_cmdStampa"
      Me.eui_cmdStampa.ScreenTip.Caption = "Stampa"
      Me.eui_cmdStampa.ScreenTip.Text = "Stampa l'elenco delle presenze."
      Me.eui_cmdStampa.Size = New System.Drawing.Size(114, 65)
      Me.eui_cmdStampa.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdStampa.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdStampa.TabIndex = 2
      Me.eui_cmdStampa.Text = "Stampa..."
      Me.eui_cmdStampa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdEsci
      '
      Me.eui_cmdEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdEsci.Id = "939bbe43-2558-40f8-9053-da695bc51ddd"
      Me.eui_cmdEsci.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdEsci.Location = New System.Drawing.Point(727, 456)
      Me.eui_cmdEsci.Name = "eui_cmdEsci"
      Me.eui_cmdEsci.ScreenTip.Caption = "Esci"
      Me.eui_cmdEsci.ScreenTip.Text = "Chiude la finestra."
      Me.eui_cmdEsci.Size = New System.Drawing.Size(114, 65)
      Me.eui_cmdEsci.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdEsci.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdEsci.TabIndex = 3
      Me.eui_cmdEsci.Text = "Esci"
      Me.eui_cmdEsci.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.Location = New System.Drawing.Point(727, 59)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(42, 16)
      Me.Label3.TabIndex = 15
      Me.Label3.Text = "Anno:"
      '
      'eui_cmbAnno
      '
      Me.eui_cmbAnno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbAnno.Editable = False
      Me.eui_cmbAnno.FormattingEnabled = False
      Me.eui_cmbAnno.Id = "9a06333f-b42a-49f3-9cad-415d7360ffd5"
      Me.eui_cmbAnno.Location = New System.Drawing.Point(727, 75)
      Me.eui_cmbAnno.Name = "eui_cmbAnno"
      Me.eui_cmbAnno.Size = New System.Drawing.Size(113, 21)
      Me.eui_cmbAnno.Sorted = True
      Me.eui_cmbAnno.TabIndex = 1
      Me.eui_cmbAnno.TextEditorWidth = 94
      '
      'StoricoPresenze
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(850, 530)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.eui_cmbAnno)
      Me.Controls.Add(Me.eui_cmdEsci)
      Me.Controls.Add(Me.eui_cmdStampa)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.eui_cmbTipologia)
      Me.Controls.Add(Me.eui_tpcPresenze)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "StoricoPresenze"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Storico Presenze"
      CType(Me.eui_tpcPresenze, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpElenco.ResumeLayout(False)
      Me.tpElenco.PerformLayout()
      CType(Me.dgvDettagli, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpGrafico.ResumeLayout(False)
      CType(Me.chartPresenze, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_tpcPresenze As Elegant.Ui.TabControl
   Friend WithEvents tpElenco As Elegant.Ui.TabPage
   Friend WithEvents tpGrafico As Elegant.Ui.TabPage
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents eui_cmbTipologia As Elegant.Ui.ComboBox
   Friend WithEvents dgvDettagli As DataGridView
   Friend WithEvents eui_cmdStampa As Elegant.Ui.Button
   Friend WithEvents eui_cmdEsci As Elegant.Ui.Button
   Friend WithEvents Label3 As Elegant.Ui.Label
   Friend WithEvents eui_cmbAnno As Elegant.Ui.ComboBox
   Friend WithEvents eui_txtTotalePresenze As Elegant.Ui.TextBox
   Friend WithEvents Label2 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaleOccupazione As Elegant.Ui.TextBox
   Friend WithEvents Label18 As Elegant.Ui.Label

   Public Sub New()

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Friend WithEvents clnMese As DataGridViewTextBoxColumn
   Friend WithEvents clnPresenze As DataGridViewTextBoxColumn
   Friend WithEvents clnOccupazione As DataGridViewTextBoxColumn
   Friend WithEvents chartPresenze As DataVisualization.Charting.Chart
End Class
