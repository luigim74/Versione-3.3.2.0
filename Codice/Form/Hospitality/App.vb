Public Class App
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(App))
      Me.SuspendLayout()
      '
      'App
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(128, 30)
      Me.Enabled = False
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "App"
      Me.Opacity = 0.0R
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "App"
      Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private DatiConfig As AppConfig
   Private Pwd As String

   Private Sub App_Load1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      'Try
      '   ' Se il prog. è una versione dimostrativa chiede il codice di accesso. 
      '   If g_VerDemo = True Then
      '      If InserisciChiaveAccesso() = False Then
      '         Application.Exit()
      '         Exit Sub
      '      End If

      '      ' Verifica la data di installazione.
      '      If VerificaDataDemo() = False Then
      '         Application.Exit()
      '         Exit Sub
      '      End If
      '   End If

      '   Dim frm As New frmSplash
      '   frm.Show()

      '   Application.DoEvents()

      '   ' Modifica il cursore del mouse.
      '   Cursor.Current = Cursors.AppStarting

      '   g_frmMain = New frmMain
      '   g_frmMain.Show()

      '   ' Verifica della password.
      '   DatiConfig = New AppConfig
      '   DatiConfig.ConfigType = ConfigFileType.AppConfig
      '   ' Legge la password.
      '   Pwd = DatiConfig.GetValue("Pwd")

      '   frm.Close()

      '   ' Modifica il cursore del mouse.
      '   Cursor.Current = Cursors.Default

      '   If Pwd <> "" Then
      '      g_frmMain.mnuArchiviProteggi.Text = "&Annulla password"
      '      Dim frmPwd As New frmPassword(False)

      '      If frmPwd.ShowDialog() = DialogResult.Cancel Then
      '         Application.Exit()
      '      Else
      '         Exit Sub
      '      End If
      '   Else
      '      g_frmMain.mnuArchiviProteggi.Text = "&Imposta password"
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)
      'End Try
   End Sub

   Private Sub App_Load2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      'Try
      '   ' Verifica la presenza della chiave di attivazione.
      '   DatiConfig = New AppConfig
      '   DatiConfig.ConfigType = ConfigFileType.AppConfig

      '   'Se il prog. è una versione dimostrativa chiede il codice di accesso. 
      '   'Legge la chiave.
      '   If DatiConfig.GetValue("KeyAccess") = String.Empty Then
      '      If InserisciChiaveAttivazione() = False Then
      '         If CHIAVE_ACCESSO = CHIAVE_ACCESSO Then ' If DatiConfig.GetValue("KeyAccess") = CHIAVE_ACCESSO Then- Per disattivare il codice.
      '            ' Verifica la data di installazione.
      '            If VerificaDataDemo() = False Then
      '               If InserisciChiaveAttivazione() = True Then
      '                  g_VerDemo = False
      '               Else
      '                  Application.Exit()
      '                  Exit Sub
      '               End If
      '            Else
      '               g_VerDemo = True
      '            End If
      '         Else
      '            If InserisciChiaveAttivazione() = True Then
      '               g_VerDemo = False
      '            Else
      '               Application.Exit()
      '               Exit Sub
      '            End If
      '         End If
      '      Else
      '         g_VerDemo = False
      '      End If
      '   Else
      '      If DatiConfig.GetValue("KeyAccess") = CHIAVE_ACCESSO Then
      '         ' Verifica la data di installazione.
      '         If VerificaDataDemo() = False Then
      '            If InserisciChiaveAttivazione() = True Then
      '               g_VerDemo = False
      '            Else
      '               Application.Exit()
      '               Exit Sub
      '            End If
      '         Else
      '            g_VerDemo = True
      '         End If
      '      Else
      '         g_VerDemo = False
      '      End If
      '   End If

      '   Dim frm As New frmSplash
      '   frm.Show()

      '   Application.DoEvents()

      '   ' Modifica il cursore del mouse.
      '   Cursor.Current = Cursors.AppStarting

      '   g_frmMain = New frmMain
      '   g_frmMain.Show()

      '   frm.Close()

      '   ' Modifica il cursore del mouse.
      '   Cursor.Current = Cursors.Default

      '   Dim frmAccesso As New frmAccesso
      '   If frmAccesso.ShowDialog() = DialogResult.Cancel Then
      '      Application.Exit()
      '   Else
      '      Exit Sub
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)
      'End Try
   End Sub

   Private Sub App_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Verifica la presenza della chiave di attivazione.
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         'Se il prog. è una versione dimostrativa chiede il codice di accesso. 
         'Legge la chiave.
         Dim chiaveAttivazione As Boolean = False

         If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = String.Empty Then

            ' Installazione su computer - La chiave di attivazione viene generata dal PC e confrontata con quella salvata nel file di configurazione.
            If DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY) Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOTEL) Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR) Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE) Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO) Then
               chiaveAttivazione = True
            End If

         Else

            ' Installazione su USB Pen Drive - La chiave di attivazione non viene generata dal PC ma viene controllata la sua esistenza nel file di configurazione.
            If DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG).Length = 25 Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG).Length = 25 Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG).Length = 25 Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG).Length = 25 Then
               chiaveAttivazione = True
            End If
            If DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG).Length = 25 Then
               chiaveAttivazione = True
            End If

         End If

         ' Imposta la versione demo.
         Dim tempoDemoScaduto As Boolean = True
         If chiaveAttivazione = False Then
            If VerificaDataDemo(FILE_DATA_DEMO) = False Then
               tempoDemoScaduto = False
            End If

            g_VerDemo = True
         Else
            g_VerDemo = False
         End If

         ' Legge il nome del prodotto attivo per poter impostare l'immagine nello Splash Screen.
         If DatiConfig.GetValue("NomeProdotto") = String.Empty Then
            NOME_PRODOTTO = NOME_PRODOTTO_HOSPITALITY_SUITE
         Else
            NOME_PRODOTTO = DatiConfig.GetValue("NomeProdotto")
         End If

         Dim frm As New frmSplash
         frm.Show()

         Application.DoEvents()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         g_frmMain = New frmMain
         g_frmMain.Show()

         frm.Close()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         If g_VerDemo = True Then
            ' Verifica la data di installazione.
            If tempoDemoScaduto = False Then
               g_frmMain.AttivaDisattivaTutto(False)
            End If

            ' Visualizza i giorni rimanenti della Licenza sulla barra di stato.
            g_frmMain.eui_cmdLicenza.Text = giorniVerDemo
         Else
            ' Verifica senza messaggio a video!
            g_frmMain.VerificaLicenza(False)
         End If

         ' Verifica senza messaggio a video!
         g_frmMain.VerificaAggiornamenti(False)

         Dim frmAccesso As New frmAccesso
         If frmAccesso.ShowDialog() = DialogResult.Cancel Then
            Application.Exit()
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

End Class
