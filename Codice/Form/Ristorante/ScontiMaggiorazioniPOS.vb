Imports System.IO
Imports System.Data.OleDb
Imports Softgroup.NetButton

Public Class ScontiMaggiorazioniPOS
   Inherits System.Windows.Forms.Form

   Const TAB_SCONTI_MAGGIORAZIONI As String = "ScontiMaggiorazioni"
   Const LARGHEZZA_PULSANTE As Short = 82 '184
   Const ALTEZZA_PULSANTE As Short = 50 '80

   Public Sconti_Maggiorazioni() As NetButton
   Public NumScontiMaggiorazioni As Integer = 0

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Private cmd As New OleDbCommand(sql, cn)

   Private CFormatta As New ClsFormatta
   Private tipologiaValore As String

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal tipologia As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      ReDim Sconti_Maggiorazioni(LeggiNumRecord(TAB_SCONTI_MAGGIORAZIONI))

      tipologiaValore = tipologia
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

   'NOTA: la procedura che segue � richiesta da Progettazione Windows Form.
   'Pu� essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents pnlPag As System.Windows.Forms.Panel
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScontiMaggiorazioniPOS))
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
      'ScontiMaggiorazioniPOS
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(577, 493)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.pnlPag)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ScontiMaggiorazioniPOS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "SCONTI E MAGGIORAZIONI"
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

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Tipologia = '" & tipologiaValore & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordX As Integer = 0
         Dim CordY As Integer = 0
         Dim i As Integer = 0

         Do While dr.Read()
            i += 1

            Dim valoreImporto As String
            If dr.Item("TipoImporto").ToString = "Valore" Then
               ' Importo valore.
               valoreImporto = CFormatta.FormattaNumeroDouble(dr.Item("valore"))
            Else
               ' Importo percentuale.
               valoreImporto = CFormatta.FormattaNumeroDouble(dr.Item("valore")) & "%"
            End If

            If IsDBNull(dr.Item("Descrizione")) = False Then
               DisegnaPulsante(dr.Item("Id").ToString, dr.Item("Descrizione").ToString, valoreImporto, Color.FromArgb(Convert.ToInt32(dr.Item("Colore"))), CordX, CordY)
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

   Private Sub DisegnaPulsante(ByVal numero As String, ByVal nome As String, ByVal valoreImporto As String, ByVal coloreSfondo As Color, ByVal x As Integer, ByVal y As Integer)
      Try
         NumScontiMaggiorazioni += 1

         Sconti_Maggiorazioni(NumScontiMaggiorazioni) = New NetButton
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).Name = numero
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).CornerRadius = 2
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).Location = New Point(x, y)
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).Size = New Size(LARGHEZZA_PULSANTE, ALTEZZA_PULSANTE)
         'Sconti_Maggiorazioni(NumScontiMaggiorazioni).FlatStyle = FlatStyle.Popup
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).ColorBottom = coloreSfondo
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).ColorText = Color.Black
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).TextButtonAlign = ContentAlignment.MiddleCenter
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).TextButton = nome
         Sconti_Maggiorazioni(NumScontiMaggiorazioni).Tag = valoreImporto
         'Sconti_Maggiorazioni(NumScontiMaggiorazioni).DialogResult = DialogResult.OK
         'Sconti_Maggiorazioni(NumScontiMaggiorazioni).ImageAlign = ContentAlignment.TopCenter

         'If File.Exists(icona) = True Then
         '   Dim bmp As New Bitmap(icona)
         '   Sconti_Maggiorazioni(NumScontiMaggiorazioni).Image = bmp
         'End If

         pnlPag.Controls.Add(Sconti_Maggiorazioni(NumScontiMaggiorazioni))

         AddHandler Sconti_Maggiorazioni(NumScontiMaggiorazioni).Click, AddressOf ScontiMaggiorazioni_Click

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ScontiMaggiorazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.Tag = sender.Tag
         Me.DialogResult = DialogResult.OK
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ScontiMaggiorazioni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      ' Imposta il titolo della finestra.
      If tipologiaValore = "Sconto" Then
         Me.Text = "SCONTI"
      Else
         Me.Text = "MAGGIORAZIONI"
      End If

      LeggiDati(TAB_SCONTI_MAGGIORAZIONI)
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub
End Class
