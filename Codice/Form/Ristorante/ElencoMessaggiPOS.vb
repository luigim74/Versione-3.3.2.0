' ATTENZIONE! FORM NON UTILIZZATO.

Imports System.IO
Imports System.Data.OleDb

Public Class ElencoMessaggiPos
   Inherits System.Windows.Forms.Form

   Const ANA_MESSAGGI As String = "MessaggiReparti"
   Const ALTEZZA_RIGA_DETTAGLI As Short = 24

   Const TITOLO_FINESTRA As String = "ELENCO MESSAGGI"

   Private CFormatta As New ClsFormatta

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents lstvMessaggi As System.Windows.Forms.ListView
   Friend WithEvents NomeCliente As System.Windows.Forms.ColumnHeader
   Friend WithEvents Id As System.Windows.Forms.ColumnHeader
   Public WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents eui_txtMessaggio As Elegant.Ui.TextBox
   Friend WithEvents IdCliente As System.Windows.Forms.ColumnHeader

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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Azienda Ligure SRL")
      Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Montana Luigi")
      Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Rossi Fabio")
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoMessaggiPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.lstvMessaggi = New System.Windows.Forms.ListView()
      Me.Id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.NomeCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.IdCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label4 = New System.Windows.Forms.Label()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.eui_txtMessaggio = New Elegant.Ui.TextBox()
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
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'lstvMessaggi
      '
      Me.lstvMessaggi.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvMessaggi.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Id, Me.NomeCliente, Me.IdCliente})
      Me.lstvMessaggi.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvMessaggi.FullRowSelect = True
      Me.lstvMessaggi.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvMessaggi.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
      Me.lstvMessaggi.Location = New System.Drawing.Point(12, 16)
      Me.lstvMessaggi.MultiSelect = False
      Me.lstvMessaggi.Name = "lstvMessaggi"
      Me.lstvMessaggi.Size = New System.Drawing.Size(621, 384)
      Me.lstvMessaggi.TabIndex = 0
      Me.lstvMessaggi.UseCompatibleStateImageBehavior = False
      Me.lstvMessaggi.View = System.Windows.Forms.View.Details
      '
      'Id
      '
      Me.Id.DisplayIndex = 2
      Me.Id.Text = ""
      Me.Id.Width = 0
      '
      'NomeCliente
      '
      Me.NomeCliente.DisplayIndex = 0
      Me.NomeCliente.Text = ""
      Me.NomeCliente.Width = 480
      '
      'IdCliente
      '
      Me.IdCliente.DisplayIndex = 1
      Me.IdCliente.Text = ""
      Me.IdCliente.Width = 0
      '
      'Label4
      '
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(12, 406)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(101, 29)
      Me.Label4.TabIndex = 236
      Me.Label4.Text = "MESSAGGIO:"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "2b8ba805-3369-4c5e-b816-dc81f831067e"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(505, 453)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 3
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "7a1eb92e-859a-4d27-b576-33ca41ac3da8"
      Me.eui_cmdOk.Location = New System.Drawing.Point(362, 453)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 2
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "e6db68e1-fb2c-463e-9961-3c57f522cfd2"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(15, 453)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(80, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 4
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_txtMessaggio
      '
      Me.eui_txtMessaggio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtMessaggio.Id = "96133e96-6dd4-4022-9280-ec537c28eb0f"
      Me.eui_txtMessaggio.Location = New System.Drawing.Point(116, 406)
      Me.eui_txtMessaggio.Name = "eui_txtMessaggio"
      Me.eui_txtMessaggio.Size = New System.Drawing.Size(517, 32)
      Me.eui_txtMessaggio.TabIndex = 270
      Me.eui_txtMessaggio.TextEditorWidth = 511
      '
      'ElencoMessaggiPos
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(23, 55)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(645, 516)
      Me.Controls.Add(Me.eui_txtMessaggio)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.lstvMessaggi)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ElencoMessaggiPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "ELENCO MESSAGGI"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Sub CaricaListaMessaggi(ByVal lstv As ListView, ByVal tabella As String)
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstv.Items.Clear()

         Do While dr.Read
            ' Id.
            lstv.Items.Add(lstv.Items.Count)

            ' Messaggio.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Descrizione").ToString.ToUpper)

            ' IdMessaggio.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ElencoMessaggiPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         CaricaListaMessaggi(lstvMessaggi, ANA_MESSAGGI)

         eui_txtMessaggio.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.Tag = eui_txtMessaggio.Text

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub lstvMessaggi_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lstvMessaggi.ItemSelectionChanged
      Try
         eui_txtMessaggio.Text = lstvMessaggi.Items(e.ItemIndex).SubItems(1).Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub
End Class
