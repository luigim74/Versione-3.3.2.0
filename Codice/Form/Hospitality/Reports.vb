Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReports

   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal sql As String, ByVal tabella As String, ByVal percorso As String, ByVal frm As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      frmId = frm
      sqlRep = sql
      TabellaRep = tabella
      percorsoRep = percorso
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
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents crwReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
      Me.crwReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.SuspendLayout()
      '
      'crwReport
      '
      Me.crwReport.ActiveViewIndex = -1
      Me.crwReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.crwReport.Cursor = System.Windows.Forms.Cursors.Default
      Me.crwReport.Dock = System.Windows.Forms.DockStyle.Fill
      Me.crwReport.Location = New System.Drawing.Point(0, 0)
      Me.crwReport.Name = "crwReport"
      Me.crwReport.Size = New System.Drawing.Size(907, 442)
      Me.crwReport.TabIndex = 1
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmReports
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(907, 442)
      Me.Controls.Add(Me.crwReport)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmReports"
      Me.Text = "Anteprima di stampa"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private frmId As String
   Private sqlRep As String
   Private TabellaRep As String
   Private percorsoRep As String

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Sub CaricaReport()
      Dim cn As OleDbConnection

      Try
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

         oleAdapter.Fill(ds, TabellaRep)

         ' LOGO AZIENDA - MENU
         ' Questo codice viene eseguito solo per caricare il logo azienda nella formazione del menu.
         ' -----------------------------------------------------------------------------------------
         If frmId = "Menu" Then
            Dim oleAdapter1 As New OleDbDataAdapter
            oleAdapter1.SelectCommand = New OleDbCommand("SELECT * FROM Azienda ORDER BY Id ASC", cn)
            oleAdapter1.Fill(ds, "Azienda")
         End If
         ' -----------------------------------------------------------------------------------------

         Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         rep.Load(Application.StartupPath & percorsoRep)

         rep.SetDataSource(ds)

         crwReport.ReportSource = rep

         cn.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmReports_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub frmReports_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      ' Imposta le dimensioni del form.
      FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

      CaricaReport()
   End Sub

End Class
