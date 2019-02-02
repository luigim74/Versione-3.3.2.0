Imports System.Data
Imports System.Data.OleDb

Public Class FiltroPeriodo
   Inherits System.Windows.Forms.Form

   Private CFormatta As New ClsFormatta

    ' Dichiara un oggetto Transazione
    Private tr As OleDbTransaction

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents eui_dtpDataDal As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_dtpDataAl As Elegant.Ui.DateTimePicker

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroPeriodo))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_dtpDataAl = New Elegant.Ui.DateTimePicker()
      Me.eui_dtpDataDal = New Elegant.Ui.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(26, 13)
      Me.Label1.TabIndex = 55634
      Me.Label1.Text = "Dal:"
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
      'eui_dtpDataAl
      '
      Me.eui_dtpDataAl.Id = "89aceb2f-f343-4582-8f68-1e0fe2cac584"
      Me.eui_dtpDataAl.Location = New System.Drawing.Point(48, 48)
      Me.eui_dtpDataAl.Name = "eui_dtpDataAl"
      Me.eui_dtpDataAl.Size = New System.Drawing.Size(176, 21)
      Me.eui_dtpDataAl.TabIndex = 1
      Me.eui_dtpDataAl.TextEditorWidth = 157
      '
      'eui_dtpDataDal
      '
      Me.eui_dtpDataDal.Id = "e234a021-1ff0-4151-9ff4-7e9c66526b04"
      Me.eui_dtpDataDal.Location = New System.Drawing.Point(48, 16)
      Me.eui_dtpDataDal.Name = "eui_dtpDataDal"
      Me.eui_dtpDataDal.Size = New System.Drawing.Size(176, 21)
      Me.eui_dtpDataDal.TabIndex = 0
      Me.eui_dtpDataDal.TextEditorWidth = 157
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 48)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(19, 13)
      Me.Label2.TabIndex = 55667
      Me.Label2.Text = "Al:"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Id = "ea8e600e-ad20-4336-b155-46cbfdcfca3b"
      Me.eui_cmdOk.Location = New System.Drawing.Point(88, 88)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(64, 25)
      Me.eui_cmdOk.TabIndex = 2
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "6aa420f1-3c78-4fb0-99fa-f5e94600911b"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(160, 88)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(64, 25)
      Me.eui_cmdAnnulla.TabIndex = 3
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'FiltroPeriodo
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(240, 126)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.eui_dtpDataDal)
      Me.Controls.Add(Me.eui_dtpDataAl)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FiltroPeriodo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Filtro periodo"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub FiltroPeriodo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta i campi data alla data del giorno.
         eui_dtpDataDal.Value = Now.Date
         eui_dtpDataAl.Value = Now.Date

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub FiltroPeriodo_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      'If Me.Tag.ToString <> "0" Then
      '   ' Registra loperazione effettuata dall'operatore identificato.
      '   'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_PRIMA_NOTA)
      'End If
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
        Try

            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = "Dal " & eui_dtpDataDal.Value.GetValueOrDefault.ToShortDateString & " " &
                                                         "Al " & eui_dtpDataAl.Value.GetValueOrDefault.ToShortDateString

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_PRIMA_NOTA)

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
        Try
            ' Prenotazioni Camere.
            If IsNothing(g_frmPrenCamere) = False Then
                ' Se il filtro di periodo non è impostato visualizza tutti i dati.
                If g_frmMain.eui_Strumenti_Periodo_DalAl.Text = "Dal... Al..." Then
                    g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
                    g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
                    g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
                    g_frmMain.eui_Strumenti_Periodo_Arrivo.Pressed = False
                    g_frmMain.eui_Strumenti_Periodo_Partenza.Pressed = False
                    g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
                    g_frmPrenCamere.AggiornaDatiTutte()
                End If
            End If

            ' Elenco Documenti.
            If IsNothing(g_frmDocumenti) = False Then
                ' Se il filtro di periodo non è impostato visualizza tutti i dati.
                If g_frmMain.eui_Strumenti_Periodo_DalAl.Text = "Dal... Al..." Then
                    g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
                    g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
                    g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
                    g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
                    g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
                    g_frmDocumenti.filtroDati = "Tutti"
                    g_frmDocumenti.eui_txtTestoRicerca.Text = String.Empty
                    g_frmDocumenti.AggiornaDati()
                End If

            End If

            ' Inserire qui il codice per gestire le altre finestre.

            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_PRIMA_NOTA)

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub
End Class
