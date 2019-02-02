Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmSelezionaPrenotazione
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
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAddebita As Elegant.Ui.Button
   Friend WithEvents lvwPrenotazioni As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As ColumnHeader
   Friend WithEvents ColumnHeader2 As ColumnHeader
   Friend WithEvents eui_cmdPrenSu As Elegant.Ui.Button
   Friend WithEvents eui_cmdPrenGiù As Elegant.Ui.Button
   Public WithEvents Label6 As Label
   Friend WithEvents eui_txtTrovaCognome As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelezionaPrenotazione))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAddebita = New Elegant.Ui.Button()
      Me.lvwPrenotazioni = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdPrenSu = New Elegant.Ui.Button()
      Me.eui_cmdPrenGiù = New Elegant.Ui.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.eui_txtTrovaCognome = New Elegant.Ui.TextBox()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "saveHS.png")
      Me.ImageList1.Images.SetKeyName(1, "Edit_UndoHS.png")
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
      'eui_cmdAddebita
      '
      Me.eui_cmdAddebita.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdAddebita.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdAddebita.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAddebita.Id = "c1e102ea-84d7-4e3c-8acf-9fe3c5e5ebb0"
      Me.eui_cmdAddebita.Location = New System.Drawing.Point(732, 518)
      Me.eui_cmdAddebita.Name = "eui_cmdAddebita"
      Me.eui_cmdAddebita.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAddebita.TabIndex = 5
      Me.eui_cmdAddebita.Text = "&Addebita"
      '
      'lvwPrenotazioni
      '
      Me.lvwPrenotazioni.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvwPrenotazioni.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lvwPrenotazioni.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader13, Me.ColumnHeader3, Me.ColumnHeader2, Me.ColumnHeader12})
      Me.lvwPrenotazioni.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lvwPrenotazioni.FullRowSelect = True
      Me.lvwPrenotazioni.Location = New System.Drawing.Point(2, 0)
      Me.lvwPrenotazioni.MultiSelect = False
      Me.lvwPrenotazioni.Name = "lvwPrenotazioni"
      Me.lvwPrenotazioni.ShowGroups = False
      Me.lvwPrenotazioni.Size = New System.Drawing.Size(1002, 500)
      Me.lvwPrenotazioni.TabIndex = 0
      Me.lvwPrenotazioni.UseCompatibleStateImageBehavior = False
      Me.lvwPrenotazioni.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Indice"
      Me.ColumnHeader1.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "Numero"
      Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader7.Width = 90
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "Data"
      Me.ColumnHeader8.Width = 110
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Rag. Soc./Cognome"
      Me.ColumnHeader9.Width = 300
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "Nome"
      Me.ColumnHeader10.Width = 150
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "Camera"
      Me.ColumnHeader11.Width = 100
      '
      'ColumnHeader13
      '
      Me.ColumnHeader13.Text = "Arrivo"
      Me.ColumnHeader13.Width = 110
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Partenza"
      Me.ColumnHeader3.Width = 110
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Totale Conto"
      Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader2.Width = 0
      '
      'ColumnHeader12
      '
      Me.ColumnHeader12.Text = "Codice"
      Me.ColumnHeader12.Width = 0
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "ad79e064-a6af-41ac-88c1-1cf83860744e"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(869, 518)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 6
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdPrenSu
      '
      Me.eui_cmdPrenSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdPrenSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdPrenSu.Id = "c0143c92-f784-4c71-8ae2-4daff3fbf5ab"
      Me.eui_cmdPrenSu.Location = New System.Drawing.Point(443, 518)
      Me.eui_cmdPrenSu.Name = "eui_cmdPrenSu"
      Me.eui_cmdPrenSu.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdPrenSu.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdPrenSu.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdPrenSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdPrenSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdPrenSu.TabIndex = 3
      '
      'eui_cmdPrenGiù
      '
      Me.eui_cmdPrenGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdPrenGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdPrenGiù.Id = "7a370a7a-c200-480c-9c8e-e8786e7033cf"
      Me.eui_cmdPrenGiù.Location = New System.Drawing.Point(572, 518)
      Me.eui_cmdPrenGiù.Name = "eui_cmdPrenGiù"
      Me.eui_cmdPrenGiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdPrenGiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdPrenGiù.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdPrenGiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdPrenGiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdPrenGiù.TabIndex = 4
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(97, 514)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(200, 24)
      Me.Label6.TabIndex = 280
      Me.Label6.Text = "TROVA COGNOME:"
      '
      'eui_txtTrovaCognome
      '
      Me.eui_txtTrovaCognome.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTrovaCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTrovaCognome.Id = "da8bd1f2-77f2-4ce1-97bb-e9e1ac426dcb"
      Me.eui_txtTrovaCognome.Location = New System.Drawing.Point(101, 538)
      Me.eui_txtTrovaCognome.Name = "eui_txtTrovaCognome"
      Me.eui_txtTrovaCognome.Size = New System.Drawing.Size(327, 33)
      Me.eui_txtTrovaCognome.TabIndex = 2
      Me.eui_txtTrovaCognome.TextEditorWidth = 321
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdTastiera.Id = "57e6209c-4998-46b6-a4a0-a223dce1ffaa"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(9, 518)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 1
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'frmSelezionaPrenotazione
      '
      Me.AcceptButton = Me.eui_cmdAddebita
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(1006, 583)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_txtTrovaCognome)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.eui_cmdPrenSu)
      Me.Controls.Add(Me.eui_cmdPrenGiù)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdAddebita)
      Me.Controls.Add(Me.lvwPrenotazioni)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSelezionaPrenotazione"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleziona Prenotazione"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public IPren As New PrenCamere

   Const TAB_PREN_CAMERE As String = "PrenCamere"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   Dim CFormatta As ClsFormatta

   Private Sub frmSelezionaPrenotazione_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica l'elenco delle prenotazioni.
         FiltraDati(String.Empty)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Public Sub CaricaPrenotazioni(ByVal strSql As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lvwPrenotazioni.Items.Clear()

         Do While dr.Read()
            ' Indice
            lvwPrenotazioni.Items.Add(lvwPrenotazioni.Items.Count)

            ' Numero.
            If IsDBNull(dr.Item("Numero")) = False Then
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("Numero"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Data.
            If IsDBNull(dr.Item("Data")) = False Then
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("Data"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Ragione sociale / Cognome.
            If IsDBNull(dr.Item("Cognome")) = False Then
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("Cognome"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Nome.
            If IsDBNull(dr.Item("Nome")) = False Then
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("Nome"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Camera.
            If IsDBNull(dr.Item("NumeroCamera")) = False Then
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("NumeroCamera"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Data Arrivo.
            If IsDBNull(dr.Item("DataArrivo")) = False Then
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("DataArrivo"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Data Partenza.
            If IsDBNull(dr.Item("DataPartenza")) = False Then
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("DataPartenza"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Totale Conto.
            If IsDBNull(dr.Item("TotaleConto")) = False Then
               'Dim totaleConto As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("TotaleConto")))
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("TotaleConto"))
            Else
               lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Codice.
            lvwPrenotazioni.Items(lvwPrenotazioni.Items.Count - 1).SubItems.Add(dr.Item("Id"))

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub AddebitaConto(ByVal codice As String)
      '' Dichiara un oggetto connessione.
      'Dim cn As New OleDbConnection(ConnString)

      'Try
      '   cn.Open()

      '   Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_CLIENTI & " WHERE Id = " & codice & " ORDER BY Id ASC", cn)
      '   Dim dr As OleDbDataReader = cmd.ExecuteReader()

      '   Do While dr.Read()
      '      With g_frmPrenCamera

      '         ' Indice
      '         .lvwOccupanti.Items.Add(.lvwOccupanti.Items.Count)

      '         ' Ragione sociale / Cognome.
      '         If IsDBNull(dr.Item("Cognome")) = False Then
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Cognome"))
      '         Else
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
      '         End If

      '         ' Nome.
      '         If IsDBNull(dr.Item("Nome")) = False Then
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Nome"))
      '         Else
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
      '         End If

      '         ' Data di nascita.
      '         If IsDBNull(dr.Item("DataNascita")) = False Then
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("DataNascita"))
      '         Else
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
      '         End If

      '         ' Luogo di nascita.
      '         If IsDBNull(dr.Item("LuogoNascita")) = False Then
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("LuogoNascita"))
      '         Else
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
      '         End If

      '         ' Provincia.
      '         If IsDBNull(dr.Item("ProvNascita")) = False Then
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("ProvNascita"))
      '         Else
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
      '         End If

      '         ' Nazionalità.
      '         If IsDBNull(dr.Item("Nazionalità")) = False Then
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Nazionalità"))
      '         Else
      '            .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
      '         End If

      '         ' Codice.
      '         .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Id"))

      '      End With

      '   Loop

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
   End Sub

   Private Sub FiltraDati(ByVal testoRicerca As String)
      Try
         testoRicerca = FormattaApici(testoRicerca)

         If testoRicerca <> String.Empty Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Cognome LIKE '" & testoRicerca & "%' ORDER BY Numero ASC", TAB_PREN_CAMERE)
         Else
            sql = String.Format("SELECT * FROM {0} ORDER BY Numero ASC", TAB_PREN_CAMERE)
         End If

         ' Carica l'elenco delle prenotazioni.
         CaricaPrenotazioni(sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         If lvwPrenotazioni.Items.Count = 0 Then
            eui_cmdAddebita.Enabled = False
         Else
            eui_cmdAddebita.Enabled = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAddebita_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAddebita.Click
      Try
         If lvwPrenotazioni.Items.Count <> 0 Then

            lvwPrenotazioni.Focus()

            Me.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_txtTrovaCognome_TextChanged(sender As Object, e As EventArgs) Handles eui_txtTrovaCognome.TextChanged
      Try
         FiltraDati(eui_txtTrovaCognome.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub eui_cmdPrenSu_Click(sender As Object, e As EventArgs) Handles eui_cmdPrenSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lvwPrenotazioni.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lvwPrenotazioni.TopItem.Index

         IndiceLista = PrimoElemento - 1

         If IndiceLista < 0 Then
            Exit Sub
         Else
            lvwPrenotazioni.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdPrenGiù_Click(sender As Object, e As EventArgs) Handles eui_cmdPrenGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lvwPrenotazioni.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lvwPrenotazioni.TopItem.Index

         IndiceLista = PrimoElemento + NumElementi

         If IndiceLista > lvwPrenotazioni.Items.Count - 1 Then
            Exit Sub
         Else
            lvwPrenotazioni.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub lvwPrenotazioni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwPrenotazioni.SelectedIndexChanged
      Try
         Dim numPren As String = lvwPrenotazioni.Items(lvwPrenotazioni.FocusedItem.Index).SubItems(1).Text
         Dim idPren As String = lvwPrenotazioni.Items(lvwPrenotazioni.FocusedItem.Index).SubItems(9).Text
         Dim totConto As String = lvwPrenotazioni.Items(lvwPrenotazioni.FocusedItem.Index).SubItems(8).Text

         ' Unisce l'Id con il Numero della prenotazione per passarli al form ContoPos.
         Me.Tag = idPren & "," & numPren & "," & totConto

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub
End Class
