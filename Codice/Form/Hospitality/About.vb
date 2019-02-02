Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Reflection.Assembly

Friend Class frmAbout
   Inherits System.Windows.Forms.Form

#Region "Codice generato dalla finestra di progettazione Windows Form "
   Public Sub New()
      MyBase.New()
      'Chiamata richiesta dalla progettazione Windows Form.
      InitializeComponent()
   End Sub
   'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
      If Disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(Disposing)
   End Sub
   'Richiesto dalla progettazione Windows Form
   Private components As System.ComponentModel.IContainer
   Public ToolTip1 As System.Windows.Forms.ToolTip
   Public WithEvents cmdOK As System.Windows.Forms.Button
   Public WithEvents cmdSysInfo As System.Windows.Forms.Button
   Public WithEvents imgIcona As System.Windows.Forms.PictureBox
   Public WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents lblDemo As System.Windows.Forms.Label
   Public WithEvents lblNumSerie As System.Windows.Forms.Label
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents lblRagSoc As System.Windows.Forms.Label
   Public WithEvents lblUtente As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents lblCommenti As System.Windows.Forms.Label
   Public WithEvents lblInfo As System.Windows.Forms.Label
   Public WithEvents lblNomeProdotto As System.Windows.Forms.Label
   Public WithEvents lblVersione As System.Windows.Forms.Label
   'Public WithEvents lblIndirizzo As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
   'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
   'Può essere modificata utilizzando la finestra di progettazione Windows Form.
   'Non modificarla mediante l'editor di codice.
   Public WithEvents lblAttenzione As System.Windows.Forms.Label
   Friend WithEvents lnkInfo As System.Windows.Forms.LinkLabel
   Friend WithEvents lnkAss As System.Windows.Forms.LinkLabel
   Friend WithEvents lnkWeb As System.Windows.Forms.LinkLabel
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents lblFreeware As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.cmdOK = New System.Windows.Forms.Button()
      Me.cmdSysInfo = New System.Windows.Forms.Button()
      Me.imgIcona = New System.Windows.Forms.PictureBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.lblDemo = New System.Windows.Forms.Label()
      Me.lblNumSerie = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.lblRagSoc = New System.Windows.Forms.Label()
      Me.lblUtente = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.lblCommenti = New System.Windows.Forms.Label()
      Me.lblInfo = New System.Windows.Forms.Label()
      Me.lblNomeProdotto = New System.Windows.Forms.Label()
      Me.lblVersione = New System.Windows.Forms.Label()
      Me.lnkInfo = New System.Windows.Forms.LinkLabel()
      Me.lnkAss = New System.Windows.Forms.LinkLabel()
      Me.lnkWeb = New System.Windows.Forms.LinkLabel()
      Me.lblAttenzione = New System.Windows.Forms.Label()
      Me.lblFreeware = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.imgIcona, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cmdOK
      '
      Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
      Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmdOK.Location = New System.Drawing.Point(336, 352)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.cmdOK.Size = New System.Drawing.Size(97, 25)
      Me.cmdOK.TabIndex = 0
      Me.cmdOK.Text = "&Ok"
      Me.cmdOK.UseVisualStyleBackColor = False
      '
      'cmdSysInfo
      '
      Me.cmdSysInfo.BackColor = System.Drawing.SystemColors.Control
      Me.cmdSysInfo.Cursor = System.Windows.Forms.Cursors.Default
      Me.cmdSysInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdSysInfo.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmdSysInfo.Location = New System.Drawing.Point(336, 384)
      Me.cmdSysInfo.Name = "cmdSysInfo"
      Me.cmdSysInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.cmdSysInfo.Size = New System.Drawing.Size(97, 25)
      Me.cmdSysInfo.TabIndex = 1
      Me.cmdSysInfo.Text = "&System info..."
      Me.cmdSysInfo.UseVisualStyleBackColor = False
      '
      'imgIcona
      '
      Me.imgIcona.BackColor = System.Drawing.Color.Transparent
      Me.imgIcona.Cursor = System.Windows.Forms.Cursors.Default
      Me.imgIcona.Image = CType(resources.GetObject("imgIcona.Image"), System.Drawing.Image)
      Me.imgIcona.Location = New System.Drawing.Point(24, 8)
      Me.imgIcona.Name = "imgIcona"
      Me.imgIcona.Size = New System.Drawing.Size(48, 48)
      Me.imgIcona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.imgIcona.TabIndex = 21
      Me.imgIcona.TabStop = False
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label12.Location = New System.Drawing.Point(80, 320)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(54, 13)
      Me.Label12.TabIndex = 16
      Me.Label12.Text = "Sito Web:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label11.Location = New System.Drawing.Point(80, 304)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(60, 13)
      Me.Label11.TabIndex = 15
      Me.Label11.Text = "Assistenza:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label9.Location = New System.Drawing.Point(80, 288)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(66, 13)
      Me.Label9.TabIndex = 14
      Me.Label9.Text = "Informazioni:"
      '
      'lblDemo
      '
      Me.lblDemo.AutoSize = True
      Me.lblDemo.BackColor = System.Drawing.Color.Transparent
      Me.lblDemo.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblDemo.ForeColor = System.Drawing.Color.Red
      Me.lblDemo.Location = New System.Drawing.Point(296, 32)
      Me.lblDemo.Name = "lblDemo"
      Me.lblDemo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblDemo.Size = New System.Drawing.Size(131, 13)
      Me.lblDemo.TabIndex = 13
      Me.lblDemo.Text = "COPIA DI VALUTAZIONE"
      Me.lblDemo.Visible = False
      '
      'lblNumSerie
      '
      Me.lblNumSerie.AutoSize = True
      Me.lblNumSerie.BackColor = System.Drawing.Color.Transparent
      Me.lblNumSerie.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblNumSerie.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblNumSerie.Location = New System.Drawing.Point(168, 256)
      Me.lblNumSerie.Name = "lblNumSerie"
      Me.lblNumSerie.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblNumSerie.Size = New System.Drawing.Size(14, 13)
      Me.lblNumSerie.TabIndex = 11
      Me.lblNumSerie.Text = "#"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label8.Location = New System.Drawing.Point(80, 256)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(86, 13)
      Me.Label8.TabIndex = 10
      Me.Label8.Text = "Numero di serie: "
      '
      'lblRagSoc
      '
      Me.lblRagSoc.AutoSize = True
      Me.lblRagSoc.BackColor = System.Drawing.Color.Transparent
      Me.lblRagSoc.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblRagSoc.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblRagSoc.Location = New System.Drawing.Point(288, 200)
      Me.lblRagSoc.Name = "lblRagSoc"
      Me.lblRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblRagSoc.Size = New System.Drawing.Size(14, 13)
      Me.lblRagSoc.TabIndex = 9
      Me.lblRagSoc.Text = "#"
      Me.lblRagSoc.Visible = False
      '
      'lblUtente
      '
      Me.lblUtente.AutoSize = True
      Me.lblUtente.BackColor = System.Drawing.Color.Transparent
      Me.lblUtente.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblUtente.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblUtente.Location = New System.Drawing.Point(80, 216)
      Me.lblUtente.Name = "lblUtente"
      Me.lblUtente.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblUtente.Size = New System.Drawing.Size(14, 13)
      Me.lblUtente.TabIndex = 8
      Me.lblUtente.Text = "#"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label5.Location = New System.Drawing.Point(80, 200)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(200, 13)
      Me.Label5.TabIndex = 7
      Me.Label5.Text = "Questo prodotto è concesso in licenza a:"
      '
      'lblCommenti
      '
      Me.lblCommenti.BackColor = System.Drawing.Color.Transparent
      Me.lblCommenti.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCommenti.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCommenti.Location = New System.Drawing.Point(80, 96)
      Me.lblCommenti.Name = "lblCommenti"
      Me.lblCommenti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblCommenti.Size = New System.Drawing.Size(360, 32)
      Me.lblCommenti.TabIndex = 6
      Me.lblCommenti.Text = "#Commenti"
      '
      'lblInfo
      '
      Me.lblInfo.BackColor = System.Drawing.Color.Transparent
      Me.lblInfo.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblInfo.Location = New System.Drawing.Point(80, 64)
      Me.lblInfo.Name = "lblInfo"
      Me.lblInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblInfo.Size = New System.Drawing.Size(360, 29)
      Me.lblInfo.TabIndex = 5
      Me.lblInfo.Text = "#Info"
      '
      'lblNomeProdotto
      '
      Me.lblNomeProdotto.AutoSize = True
      Me.lblNomeProdotto.BackColor = System.Drawing.Color.Transparent
      Me.lblNomeProdotto.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblNomeProdotto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNomeProdotto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblNomeProdotto.Location = New System.Drawing.Point(80, 16)
      Me.lblNomeProdotto.Name = "lblNomeProdotto"
      Me.lblNomeProdotto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblNomeProdotto.Size = New System.Drawing.Size(98, 13)
      Me.lblNomeProdotto.TabIndex = 4
      Me.lblNomeProdotto.Text = "#Nome prodotto"
      '
      'lblVersione
      '
      Me.lblVersione.AutoSize = True
      Me.lblVersione.BackColor = System.Drawing.Color.Transparent
      Me.lblVersione.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblVersione.ForeColor = System.Drawing.Color.Black
      Me.lblVersione.Location = New System.Drawing.Point(80, 32)
      Me.lblVersione.Name = "lblVersione"
      Me.lblVersione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblVersione.Size = New System.Drawing.Size(55, 13)
      Me.lblVersione.TabIndex = 3
      Me.lblVersione.Text = "#Versione"
      '
      'lnkInfo
      '
      Me.lnkInfo.AutoSize = True
      Me.lnkInfo.BackColor = System.Drawing.Color.Transparent
      Me.lnkInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lnkInfo.Location = New System.Drawing.Point(152, 288)
      Me.lnkInfo.Name = "lnkInfo"
      Me.lnkInfo.Size = New System.Drawing.Size(124, 13)
      Me.lnkInfo.TabIndex = 22
      Me.lnkInfo.TabStop = True
      Me.lnkInfo.Text = "info@montanasoftware.it"
      '
      'lnkAss
      '
      Me.lnkAss.AutoSize = True
      Me.lnkAss.BackColor = System.Drawing.Color.Transparent
      Me.lnkAss.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lnkAss.Location = New System.Drawing.Point(152, 304)
      Me.lnkAss.Name = "lnkAss"
      Me.lnkAss.Size = New System.Drawing.Size(156, 13)
      Me.lnkAss.TabIndex = 23
      Me.lnkAss.TabStop = True
      Me.lnkAss.Text = "assistenza@montanasoftware.it"
      '
      'lnkWeb
      '
      Me.lnkWeb.AutoSize = True
      Me.lnkWeb.BackColor = System.Drawing.Color.Transparent
      Me.lnkWeb.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lnkWeb.Location = New System.Drawing.Point(152, 320)
      Me.lnkWeb.Name = "lnkWeb"
      Me.lnkWeb.Size = New System.Drawing.Size(123, 13)
      Me.lnkWeb.TabIndex = 24
      Me.lnkWeb.TabStop = True
      Me.lnkWeb.Text = "www.montanasoftware.it"
      '
      'lblAttenzione
      '
      Me.lblAttenzione.BackColor = System.Drawing.Color.Transparent
      Me.lblAttenzione.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblAttenzione.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblAttenzione.Location = New System.Drawing.Point(80, 128)
      Me.lblAttenzione.Name = "lblAttenzione"
      Me.lblAttenzione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblAttenzione.Size = New System.Drawing.Size(360, 64)
      Me.lblAttenzione.TabIndex = 25
      Me.lblAttenzione.Text = "#Attenzione"
      '
      'lblFreeware
      '
      Me.lblFreeware.AutoSize = True
      Me.lblFreeware.BackColor = System.Drawing.Color.Transparent
      Me.lblFreeware.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblFreeware.ForeColor = System.Drawing.Color.Red
      Me.lblFreeware.Location = New System.Drawing.Point(296, 16)
      Me.lblFreeware.Name = "lblFreeware"
      Me.lblFreeware.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblFreeware.Size = New System.Drawing.Size(126, 13)
      Me.lblFreeware.TabIndex = 26
      Me.lblFreeware.Text = "VERSIONE FREEWARE"
      Me.lblFreeware.Visible = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmAbout
      '
      Me.AcceptButton = Me.cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(444, 419)
      Me.Controls.Add(Me.lblFreeware)
      Me.Controls.Add(Me.lblAttenzione)
      Me.Controls.Add(Me.lnkWeb)
      Me.Controls.Add(Me.lnkAss)
      Me.Controls.Add(Me.lnkInfo)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.cmdSysInfo)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.lblDemo)
      Me.Controls.Add(Me.lblNumSerie)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.lblRagSoc)
      Me.Controls.Add(Me.lblUtente)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.lblCommenti)
      Me.Controls.Add(Me.lblInfo)
      Me.Controls.Add(Me.lblNomeProdotto)
      Me.Controls.Add(Me.lblVersione)
      Me.Controls.Add(Me.imgIcona)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Location = New System.Drawing.Point(3, 22)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmAbout"
      Me.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informazioni su..."
      CType(Me.imgIcona, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

   ' Nome form:            frmAbout
   ' Autore:               Luigi Montana, Montana Software
   ' Data creazione:       20/02/2006
   ' Data ultima modifica: 20/02/2006
   ' Descrizione:          Informazioni sull'applicazione .

   ' Opzioni di protezione chiave registro...

   Public Sub StartSysInfo()
      Try
         Dim Proc As New Process

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = "MSINFO32.EXE"
         'Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdSysInfo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSysInfo.Click
      Call StartSysInfo()
   End Sub

   Private Sub frmAbout_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'immagine dell'icona in base al prodotto installato.
         ImpostaIcona(imgIcona)

         Me.Text = "Informazioni su " & NOME_PRODOTTO

         lblNomeProdotto.Text = NOME_PRODOTTO 'FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductName
         lblVersione.Text = " Versione " & FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductVersion & " (32 Bit)"
         lblInfo.Text = FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).LegalCopyright
         lblCommenti.Text = FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).Comments
         lblAttenzione.Text = "ATTENZIONE. Questo programma è tutelato dalle leggi sul copyright, " & _
                              "dalle leggi sui diritti d'autore e dalle disposizioni dei trattati internazionali. " & _
                              "La riproduzione o distribuzione non autorizzata di questo programma, o di parte di esso, " & _
                              "sara perseguibile civilmente e penalmente nella misura massima consentita dalla legge in vigore."

         lblUtente.Text = Environment.UserName
         lblNumSerie.Text = NUMERO_SERIE

         If g_VerDemo = True Then
            lblDemo.Visible = True
            'lblFreeware.Visible = False
         Else
            lblDemo.Visible = False
            'lblFreeware.Visible = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmAbout_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
      ' Effetto restringimento.
      Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
   End Sub

   Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
      Me.Close()
   End Sub

   Private Sub lnkInfo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInfo.LinkClicked
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim Web As New Varie.WebSolution
         Dim allegato(-1) As String

         Web.createEmail(Application.StartupPath & "\Documenti\Richiesta informazioni.eml", EMAIL_DA, lnkInfo.Text, "Richiesta informazioni sul software " & NOME_PRODOTTO, "", allegato)
         Process.Start(Application.StartupPath & "\Documenti\Richiesta informazioni.eml")

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub lnkAss_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAss.LinkClicked
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim Web As New Varie.WebSolution
         Dim allegato(-1) As String

         Web.createEmail(Application.StartupPath & "\Documenti\" & EMAIL_NOME_FILE, EMAIL_DA, EMAIL_A, EMAIL_OGGETTO & NOME_PRODOTTO, EMAIL_TESTO, allegato)
         Process.Start(Application.StartupPath & "\Documenti\" & EMAIL_NOME_FILE)

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub lnkWeb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkWeb.LinkClicked
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim Web As New Varie.WebSolution
         Web.ConnettiInternet(MS_WEB)

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lblDemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDemo.Click

   End Sub
End Class