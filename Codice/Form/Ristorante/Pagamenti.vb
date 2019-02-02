Imports System.IO
Imports System.Data.OleDb
Imports Softgroup.NetButton

Public Class Pagamenti
   Inherits System.Windows.Forms.Form

   Const TAB_PAGAMENTO As String = "ModPagamento"
   Const LARGHEZZA_PULSANTE As Short = 82 '184
   Const ALTEZZA_PULSANTE As Short = 50 '80

   Public Pagamenti() As NetButton
   Public NumPagamenti As Integer = 0

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pagamenti))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.pnlPag = New System.Windows.Forms.Panel()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
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
      Me.pnlPag.Size = New System.Drawing.Size(562, 424)
      Me.pnlPag.TabIndex = 0
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "27859f66-aaf1-49a4-8ff9-b854b92b080d"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(439, 435)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 1
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'Pagamenti
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(576, 496)
      Me.Controls.Add(Me.eui_cmdAnnulla)
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
               DisegnaPulsante(dr.Item("Id").ToString, dr.Item("Descrizione").ToString, CordX, CordY)
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

         Pagamenti(NumPagamenti) = New NetButton
         Pagamenti(NumPagamenti).Name = numero
         Pagamenti(NumPagamenti).CornerRadius = 2
         Pagamenti(NumPagamenti).Location = New Point(x, y)
         Pagamenti(NumPagamenti).Size = New Size(LARGHEZZA_PULSANTE, ALTEZZA_PULSANTE)
         'Pagamenti(NumPagamenti).FlatStyle = FlatStyle.Popup
         Pagamenti(NumPagamenti).ColorBottom = Color.Black
         Pagamenti(NumPagamenti).ColorText = Color.White
         Pagamenti(NumPagamenti).Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
         Pagamenti(NumPagamenti).TextButtonAlign = ContentAlignment.MiddleCenter
         Pagamenti(NumPagamenti).TextButton = nome
         'Pagamenti(NumPagamenti).DialogResult = DialogResult.OK
         'Pagamenti(NumPagamenti).Tag = ""
         'Pagamenti(NumPagamenti).ImageAlign = ContentAlignment.TopCenter

         'If File.Exists(icona) = True Then
         '   Dim bmp As New Bitmap(icona)
         '   Pagamenti(NumPagamenti).Image = bmp
         'End If

         pnlPag.Controls.Add(Pagamenti(NumPagamenti))

         AddHandler Pagamenti(NumPagamenti).Click, AddressOf Pagamenti_Click

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Pagamenti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.Tag = sender.TextButton
         Me.DialogResult = DialogResult.OK
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Pagamenti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      LeggiDati(TAB_PAGAMENTO)

      'If NumPagamenti <> 0 Then
      '   Me.AcceptButton = Pagamenti(1)
      'End If
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub
End Class
