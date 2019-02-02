Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class EtichetteIndirizzi
   Inherits System.Windows.Forms.Form

   Const FORMATO_ETICHETTA_8 As String = "8 etichette per foglio; dimensione 99.1 x 67.7 mm"
   Const FORMATO_ETICHETTA_12 As String = "12 etichette per foglio; dimensione 63.5 x 72 mm"
   Const FORMATO_ETICHETTA_14 As String = "14 etichette per foglio; dimensione 99.1 x 38.1 mm"
   Const FORMATO_ETICHETTA_16 As String = "16 etichette per foglio; dimensione 99.1 x 33.1 mm"
   Const FORMATO_ETICHETTA_21 As String = "21 etichette per foglio; dimensione 63.5 x 38.1 mm"
   Const FORMATO_ETICHETTA_24 As String = "24 etichette per foglio; dimensione 63.5 x 33.9 mm"

   Const TAB_CLIENTI As String = "Clienti"

   Dim percorsoRepEtichette As String = ""
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   ' Dichiara un oggetto connessione.
   'Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   'Dim tr As OleDbTransaction
   'Dim cmd As New OleDbCommand(sql, cn)
   'Dim da As OleDbDataAdapter
   'Dim ds As New DataSet
   'Dim dt As DataTable
   'Dim sql As String
   Dim repSql As String

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal sql As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      repSql = sql
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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lstEtichette As System.Windows.Forms.ListBox
   Friend WithEvents lblDescrizione As System.Windows.Forms.Label
   Friend WithEvents picAnteprima As System.Windows.Forms.PictureBox
   Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
   Public WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents cmbNumero As System.Windows.Forms.ComboBox
   Friend WithEvents cmdAnteprima As System.Windows.Forms.Button
   Friend WithEvents cmdStampa As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtichetteIndirizzi))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.lstEtichette = New System.Windows.Forms.ListBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.lblDescrizione = New System.Windows.Forms.Label()
      Me.picAnteprima = New System.Windows.Forms.PictureBox()
      Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
      Me.cmdAnteprima = New System.Windows.Forms.Button()
      Me.cmdStampa = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.cmbNumero = New System.Windows.Forms.ComboBox()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.picAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
      Me.ImageList1.Images.SetKeyName(2, "")
      Me.ImageList1.Images.SetKeyName(3, "")
      Me.ImageList1.Images.SetKeyName(4, "")
      Me.ImageList1.Images.SetKeyName(5, "")
      '
      'lstEtichette
      '
      Me.lstEtichette.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstEtichette.Location = New System.Drawing.Point(8, 56)
      Me.lstEtichette.Name = "lstEtichette"
      Me.lstEtichette.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lstEtichette.Size = New System.Drawing.Size(264, 134)
      Me.lstEtichette.TabIndex = 4
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label3.Location = New System.Drawing.Point(0, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(369, 22)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "  FORMATO ETICHETTE:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblDescrizione
      '
      Me.lblDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDescrizione.ForeColor = System.Drawing.Color.Black
      Me.lblDescrizione.Location = New System.Drawing.Point(96, 192)
      Me.lblDescrizione.Name = "lblDescrizione"
      Me.lblDescrizione.Size = New System.Drawing.Size(160, 64)
      Me.lblDescrizione.TabIndex = 11
      Me.lblDescrizione.Text = "#"
      Me.lblDescrizione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'picAnteprima
      '
      Me.picAnteprima.Location = New System.Drawing.Point(16, 192)
      Me.picAnteprima.Name = "picAnteprima"
      Me.picAnteprima.Size = New System.Drawing.Size(72, 72)
      Me.picAnteprima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picAnteprima.TabIndex = 12
      Me.picAnteprima.TabStop = False
      '
      'ImageList2
      '
      Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList2.Images.SetKeyName(0, "")
      Me.ImageList2.Images.SetKeyName(1, "")
      Me.ImageList2.Images.SetKeyName(2, "")
      Me.ImageList2.Images.SetKeyName(3, "")
      Me.ImageList2.Images.SetKeyName(4, "")
      Me.ImageList2.Images.SetKeyName(5, "")
      Me.ImageList2.Images.SetKeyName(6, "")
      Me.ImageList2.Images.SetKeyName(7, "")
      Me.ImageList2.Images.SetKeyName(8, "")
      Me.ImageList2.Images.SetKeyName(9, "")
      Me.ImageList2.Images.SetKeyName(10, "")
      Me.ImageList2.Images.SetKeyName(11, "")
      '
      'cmdAnteprima
      '
      Me.cmdAnteprima.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnteprima.Location = New System.Drawing.Point(280, 32)
      Me.cmdAnteprima.Name = "cmdAnteprima"
      Me.cmdAnteprima.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnteprima.TabIndex = 13
      Me.cmdAnteprima.Text = "A&nteprima"
      '
      'cmdStampa
      '
      Me.cmdStampa.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdStampa.Location = New System.Drawing.Point(280, 64)
      Me.cmdStampa.Name = "cmdStampa"
      Me.cmdStampa.Size = New System.Drawing.Size(80, 24)
      Me.cmdStampa.TabIndex = 14
      Me.cmdStampa.Text = "&Stampa"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(280, 104)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnnulla.TabIndex = 15
      Me.cmdAnnulla.Text = "Annulla"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(8, 32)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(189, 13)
      Me.Label20.TabIndex = 154
      Me.Label20.Text = "Inizia a stampare dall'etichetta numero:"
      '
      'cmbNumero
      '
      Me.cmbNumero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNumero.Location = New System.Drawing.Point(208, 32)
      Me.cmbNumero.Name = "cmbNumero"
      Me.cmbNumero.Size = New System.Drawing.Size(64, 21)
      Me.cmbNumero.TabIndex = 155
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = ""
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.Form = Me
      '
      'EtichetteIndirizzi
      '
      Me.AcceptButton = Me.cmdAnteprima
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(369, 282)
      Me.Controls.Add(Me.cmbNumero)
      Me.Controls.Add(Me.Label20)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdStampa)
      Me.Controls.Add(Me.cmdAnteprima)
      Me.Controls.Add(Me.picAnteprima)
      Me.Controls.Add(Me.lblDescrizione)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.lstEtichette)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EtichetteIndirizzi"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Etichette indirizzi"
      CType(Me.picAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Sub CaricaListaFormati()
      Try
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 1")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 2")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 3")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 4")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 5")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 6")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub VisAnteprima(ByVal percorsoRep As String)
      Try
         g_frmMain.ApriReports(repSql, TAB_CLIENTI, percorsoRep, "Clienti")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String, Optional ByVal frmId As String = "")
      Dim cn As OleDbConnection

      Try
         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            If frmId = "Clienti" Then
               ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

               ' Dichiara un oggetto connessione.
               cn = New OleDbConnection(ConnStringAnagrafiche)
            Else
               'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
               cn = New OleDbConnection(ConnString)
            End If

            cn.Open()

            Dim oleAdapter As New OleDbDataAdapter

            oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

            Dim ds As New Dataset1

            ds.Clear()

            oleAdapter.Fill(ds, tabella)

            Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            rep.Load(Application.StartupPath & nomeDoc)

            rep.SetDataSource(ds)

            rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True, _
                               PrintDialog1.PrinterSettings.FromPage, _
                               PrintDialog1.PrinterSettings.ToPage)

            cn.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica la lista delle categorie dei piatti.
         CaricaListaFormati()

         ' Seleziona il primo elemento della lista categorie.
         If lstEtichette.Items.Count <> 0 Then
            lstEtichette.SelectedIndex = 0
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Menu_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lstEtichette_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEtichette.SelectedIndexChanged
      Dim numEtichette As Short = 0

      Select Case sender.SelectedIndex
         Case 0
            lblDescrizione.Text = FORMATO_ETICHETTA_8
            picAnteprima.Image = ImageList2.Images(4)
            numEtichette = 8
            percorsoRepEtichette = PERCORSO_ETICHETTE_991_677

         Case 1
            lblDescrizione.Text = FORMATO_ETICHETTA_12
            picAnteprima.Image = ImageList2.Images(6)
            numEtichette = 12
            percorsoRepEtichette = PERCORSO_ETICHETTE_635_72

         Case 2
            lblDescrizione.Text = FORMATO_ETICHETTA_14
            picAnteprima.Image = ImageList2.Images(7)
            numEtichette = 14
            percorsoRepEtichette = PERCORSO_ETICHETTE_991_381

         Case 3
            lblDescrizione.Text = FORMATO_ETICHETTA_16
            picAnteprima.Image = ImageList2.Images(8)
            numEtichette = 16
            percorsoRepEtichette = PERCORSO_ETICHETTE_991_331

         Case 4
            lblDescrizione.Text = FORMATO_ETICHETTA_21
            picAnteprima.Image = ImageList2.Images(10)
            numEtichette = 21
            percorsoRepEtichette = PERCORSO_ETICHETTE_635_381

         Case 5
            lblDescrizione.Text = FORMATO_ETICHETTA_24
            picAnteprima.Image = ImageList2.Images(11)
            numEtichette = 24
            percorsoRepEtichette = PERCORSO_ETICHETTE_635_339

      End Select

      Dim i As Integer = 0
      cmbNumero.Items.Clear()

      For i = 1 To numEtichette
         cmbNumero.Items.Add(i)
      Next i

      cmbNumero.SelectedIndex = 0

   End Sub

   Private Sub cmdAnteprima_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnteprima.Click
      VisAnteprima(percorsoRepEtichette)
   End Sub

   Private Sub cmdStampa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStampa.Click
      StampaDocumento(percorsoRepEtichette, TAB_CLIENTI, repSql, "Clienti")
   End Sub
End Class
