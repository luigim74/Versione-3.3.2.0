Imports System.IO
Imports System.Data.OleDb

Public Class Pagamenti
   Inherits System.Windows.Forms.Form

   Const TAB_PAGAMENTO As String = "ModPagamento"
   Const LARGHEZZA_PULSANTE As Short = 184
   Const ALTEZZA_PULSANTE As Short = 80

   Public Pagamenti() As Button
   Public NumPagamenti As Short = 0

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private cmd As New OleDbCommand(sql, cn)

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      ReDim Pagamenti(LeggiNumRecord(TAB_PAGAMENTO))
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pagamenti))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.pnlPag.Location = New System.Drawing.Point(8, 8)
      Me.pnlPag.Name = "pnlPag"
      Me.pnlPag.Size = New System.Drawing.Size(592, 424)
      Me.pnlPag.TabIndex = 228
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.BackColor = System.Drawing.Color.LightCoral
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnnulla.ForeColor = System.Drawing.Color.White
      Me.cmdAnnulla.Location = New System.Drawing.Point(608, 16)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(112, 56)
      Me.cmdAnnulla.TabIndex = 233
      Me.cmdAnnulla.Text = "&Annulla"
      Me.cmdAnnulla.UseVisualStyleBackColor = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Pagamenti
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(730, 440)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Pagamenti"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "SISTEMI DI PAGAMENTO"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Function LeggiNumRecord(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function LeggiDati(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordX As Integer = 0
         Dim CordY As Integer = 0
         Dim i As Integer = 0

         Do While dr.Read()
            i += 1
            If IsDBNull(dr.Item("Descrizione")) = False Then
               DisegnaPulsante(dr.Item("Id"), dr.Item("Descrizione"), CordX, CordY)
            End If

            CordX = CordX + LARGHEZZA_PULSANTE + 1

            If i = 3 Then
               CordY = CordY + ALTEZZA_PULSANTE + 1
               CordX = 0
               i = 0
            End If

         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub DisegnaPulsante(ByVal numero As String, ByVal nome As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumPagamenti += 1

         Pagamenti(NumPagamenti) = New Button
         Pagamenti(NumPagamenti).Name = numero
         Pagamenti(NumPagamenti).Location = New Point(x, y)
         Pagamenti(NumPagamenti).Size = New Size(LARGHEZZA_PULSANTE, ALTEZZA_PULSANTE)
         Pagamenti(NumPagamenti).FlatStyle = FlatStyle.Popup
         Pagamenti(NumPagamenti).BackColor = Color.DimGray
         Pagamenti(NumPagamenti).ForeColor = Color.White
         Pagamenti(NumPagamenti).Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
         Pagamenti(NumPagamenti).TextAlign = ContentAlignment.MiddleCenter
         Pagamenti(NumPagamenti).Text = nome.ToUpper
         Pagamenti(NumPagamenti).DialogResult = DialogResult.OK
         'Pagamenti(NumPagamenti).Tag = ""
         'Pagamenti(NumPagamenti).ImageAlign = ContentAlignment.TopCenter

         'If File.Exists(icona) = True Then
         '   Dim bmp As New Bitmap(icona)
         '   Pagamenti(NumPagamenti).Image = bmp
         'End If

         pnlPag.Controls.Add(Pagamenti(NumPagamenti))

         AddHandler Pagamenti(NumPagamenti).Click, AddressOf Pagamenti_Click
         'AddHandler Piatti(NumPiatti).DoubleClick, AddressOf Piatti_DoubleClick
         'AddHandler Piatti(NumPiatti).GotFocus, AddressOf Piatti_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Pagamenti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.Tag = sender.Text
      Me.Close()
   End Sub

   Private Sub Pagamenti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      LeggiDati(TAB_PAGAMENTO)

      If NumPagamenti <> 0 Then
         Me.AcceptButton = Pagamenti(1)
      End If
   End Sub

End Class
