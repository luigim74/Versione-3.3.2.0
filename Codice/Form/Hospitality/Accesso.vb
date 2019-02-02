Imports System.Data.OleDb

Public Class frmAccesso
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
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
    Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
    Friend WithEvents eui_cmdOK As Elegant.Ui.Button
    Friend WithEvents eui_txtPassword As Elegant.Ui.TextBox
    Friend WithEvents eui_cmbOperatore As Elegant.Ui.ComboBox
    Friend WithEvents Label2 As Elegant.Ui.Label
    Friend WithEvents Label1 As Elegant.Ui.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccesso))
      Me.PictureBox2 = New System.Windows.Forms.PictureBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOK = New Elegant.Ui.Button()
      Me.eui_cmbOperatore = New Elegant.Ui.ComboBox()
      Me.eui_txtPassword = New Elegant.Ui.TextBox()
      Me.Label1 = New Elegant.Ui.Label()
      Me.Label2 = New Elegant.Ui.Label()
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'PictureBox2
      '
      Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
      Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
      Me.PictureBox2.Name = "PictureBox2"
      Me.PictureBox2.Size = New System.Drawing.Size(160, 168)
      Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox2.TabIndex = 185
      Me.PictureBox2.TabStop = False
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
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "5815fb08-3511-4c54-a173-cd48cbc7eb17"
      Me.eui_cmdAnnulla.KeyTip = "A"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(290, 135)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.ScreenTip.Caption = "Annulla"
      Me.eui_cmdAnnulla.ScreenTip.Text = "Annulla l'operazione e chiude la finestra"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.eui_cmdAnnulla.TabIndex = 3
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOK
      '
      Me.eui_cmdOK.Id = "3aec9268-18c4-4062-85b2-1459f457e1f3"
      Me.eui_cmdOK.KeyTip = "O"
      Me.eui_cmdOK.Location = New System.Drawing.Point(202, 135)
      Me.eui_cmdOK.Name = "eui_cmdOK"
      Me.eui_cmdOK.ScreenTip.Caption = "OK"
      Me.eui_cmdOK.ScreenTip.Text = "Conferma l'operazione  e chiude la finestra." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nella versione Dimostrativa non è" &
    " necessario specificare la password. Premere sul tasto OK."
      Me.eui_cmdOK.Size = New System.Drawing.Size(80, 24)
      Me.eui_cmdOK.TabIndex = 2
      Me.eui_cmdOK.Text = "&OK"
      '
      'eui_cmbOperatore
      '
      Me.eui_cmbOperatore.Editable = False
      Me.eui_cmbOperatore.FormattingEnabled = False
      Me.eui_cmbOperatore.Id = "6048c6d5-a8bc-4e96-973d-6f7639cc70be"
      Me.eui_cmbOperatore.Location = New System.Drawing.Point(169, 31)
      Me.eui_cmbOperatore.Name = "eui_cmbOperatore"
      Me.eui_cmbOperatore.Size = New System.Drawing.Size(201, 21)
      Me.eui_cmbOperatore.TabIndex = 0
      '
      'eui_txtPassword
      '
      Me.eui_txtPassword.Id = "e00e3276-2503-423a-a886-0fb242add818"
      Me.eui_txtPassword.Location = New System.Drawing.Point(169, 77)
      Me.eui_txtPassword.Name = "eui_txtPassword"
      Me.eui_txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.eui_txtPassword.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtPassword.TabIndex = 1
      Me.eui_txtPassword.TextEditorWidth = 195
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(169, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(50, 13)
      Me.Label1.TabIndex = 190
      Me.Label1.Text = "Operatore:"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(169, 62)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(50, 13)
      Me.Label2.TabIndex = 191
      Me.Label2.Text = "Password:"
      '
      'frmAccesso
      '
      Me.AcceptButton = Me.eui_cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(379, 163)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.eui_txtPassword)
      Me.Controls.Add(Me.eui_cmbOperatore)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOK)
      Me.Controls.Add(Me.PictureBox2)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmAccesso"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleziona operatore"
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Dim TAB_OPERATORI = "Operatori"
    Dim TAB_GRUPPI = "Gruppi"

    Dim DatiConfig As AppConfig

    Private Function LeggiDatiConfig() As String
        Try
            Dim ultimoNomeOperatore As String

            ultimoNomeOperatore = DatiConfig.GetValue("UltimoNomeOperatore")
            If ultimoNomeOperatore = String.Empty Then
                ultimoNomeOperatore = "Amministratore"
            End If

            Return ultimoNomeOperatore

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

        End Try
    End Function

    Private Sub SalvaDatiConfig(ByVal codiceOperatore As String, ByVal ultimoNomeOperatore As String)
        Try

            If ultimoNomeOperatore = String.Empty Then
                DatiConfig.SetValue("CodiceOperatore", "1")
                DatiConfig.SetValue("UltimoNomeOperatore", "Amministratore")
            Else
                DatiConfig.SetValue("CodiceOperatore", codiceOperatore)
                DatiConfig.SetValue("UltimoNomeOperatore", ultimoNomeOperatore)
            End If

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

        End Try
    End Sub

    Public Sub CaricaListaOperatori(ByVal cmb As Elegant.Ui.ComboBox, ByVal tabella As String)
        ' Dichiara un oggetto connessione.
        Dim cn As New OleDbConnection(ConnString)

        Try
            cn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Do While dr.Read
                cmb.Items.Add(dr.Item("NomeUtente"))
            Loop

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

        Finally
            cn.Close()

        End Try
    End Sub

    Public Sub LeggiDatiOperatore(ByVal nome As String, ByVal tabella As String)
        ' Dichiara un oggetto connessione.
        Dim cn As New OleDbConnection(ConnString)

        Try
            cn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NomeUtente = '" & nome & "' ORDER BY NomeUtente ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Do While dr.Read
                operatore.Codice = dr.Item("Id").ToString
                operatore.Nome = dr.Item("NomeUtente")
                operatore.Pwd = dr.Item("Password")
                operatore.Gruppo = dr.Item("Gruppo")
            Loop

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

        Finally
            cn.Close()

        End Try
    End Sub

    Public Sub LeggiDatiAccesso(ByVal nome As String, ByVal tabella As String)
        ' Dichiara un oggetto connessione.
        Dim cn As New OleDbConnection(ConnString)

        Try
            cn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NomeGruppo = '" & nome & "' ORDER BY NomeGruppo ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Do While dr.Read
                operatore.Amministratore = dr.Item("Amministratore")
                operatore.AnagAziende = dr.Item("AnagAziende")
                operatore.AnagCamerieri = dr.Item("AnagCamerieri")
                operatore.AnagCatPiatti = dr.Item("AnagCatPiatti")
                operatore.AnagClienti = dr.Item("AnagClienti")
                operatore.AnagDatiAzienda = dr.Item("AnagDatiAzienda")
                operatore.AnagFornitori = dr.Item("AnagFornitori")
                operatore.AnagPiatti = dr.Item("AnagPiatti")
                operatore.AnagSale = dr.Item("AnagSale")
                operatore.AnagTavoli = dr.Item("AnagTavoli")
                operatore.AnagRisorse = dr.Item("AnagRisorse")
                operatore.AnagAccessoriServizi = dr.Item("AnagAccessoriServizi")
                operatore.ArchiviBackup = dr.Item("ArchiviBackup")
                operatore.ArchiviCompatta = dr.Item("ArchiviCompatta")
                operatore.ArchiviPulizia = dr.Item("ArchiviPulizia")
                operatore.TabAttività = dr.Item("TabAttività")
                operatore.TabCatClienti = dr.Item("TabCatClienti")
                operatore.TabCatMerce = dr.Item("TabCatMerce")
                operatore.TabFormeCortesia = dr.Item("TabFormeCortesia")
                operatore.TabMagazzini = dr.Item("TabMagazzini")
                operatore.TabMsg = dr.Item("TabMsg")
                operatore.TabNazioni = dr.Item("TabNazioni")
                operatore.TabPagamenti = dr.Item("TabPagamenti")
                operatore.TabPiani = dr.Item("TabPiani")
                operatore.TabReparti = dr.Item("TabReparti")
                operatore.TabScaffali = dr.Item("TabScaffali")
                ' DA_FARE_B: GESTIONE DOCUMENTI - Tipo documenti eliminata dal menu - Sostituire con tabella Causali Documenti.
                'operatore.TabTipoDoc = dr.Item("TabTipoDoc")
                operatore.TabUbicazioni = dr.Item("TabUbicazioni")
                operatore.TabUM = dr.Item("TabUM")
                operatore.TabTipoRisorse = dr.Item("TabTipoRisorse")
                operatore.ContChiusura = dr.Item("ContChiusura")
                operatore.ContCorrispettivi = dr.Item("ContCorrispettivi")
                operatore.ContDoc = dr.Item("ContDoc")
                operatore.ContPrimaNota = dr.Item("ContPrimaNota")
                operatore.GestAcquisti = dr.Item("GestAcquisti")
                operatore.GestGruppi = dr.Item("GestGruppi")
                operatore.GestOperatori = dr.Item("GestOperatori")
                operatore.GestPrenSale = dr.Item("GestPrenSale")
                operatore.GestPrenTavoli = dr.Item("GestPrenTavoli")
                operatore.GestPrenRisorse = dr.Item("GestPrenRisorse")
                operatore.GestPlanningRisorse = dr.Item("GestPlanningRisorse")
                operatore.GestStatRisorse = dr.Item("GestStatRisorse")
                operatore.GestPuntoCassa = dr.Item("GestPuntoCassa")
                operatore.GestStatistiche = dr.Item("GestStatistiche")
                operatore.GestTavoli = dr.Item("GestTavoli")
                operatore.MagArticoli = dr.Item("MagArticoli")
                operatore.MagInventario = dr.Item("MagInventario")
                operatore.MagMovimenti = dr.Item("MagMov")
                operatore.MagScorte = dr.Item("MagScorte")
                operatore.StruCap = dr.Item("StruCap")
                operatore.StruCodiciBarre = dr.Item("StruCodiciBarre")
                operatore.StruDispTavoli = dr.Item("StruDispTavoli")
                operatore.StruMsg = dr.Item("StruMsg")
                operatore.StruMenù = dr.Item("StruMenù")
                operatore.VisOpzioni = dr.Item("VisOpzioni")
                operatore.VisErrori = dr.Item("VisErrori")
                operatore.VisOperazioni = dr.Item("VisOperazioni")
            Loop

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

        Finally
            cn.Close()

        End Try
    End Sub

    Private Sub frmPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Imposta l'icona della finestra in base al prodotto installato.
            ImpostaIcona(Me)

            DatiConfig = New AppConfig
            DatiConfig.ConfigType = ConfigFileType.AppConfig

            g_frmMain.eui_cmdOperatore.Text = String.Empty

            operatore.EliminaDati()

            CaricaListaOperatori(eui_cmbOperatore, TAB_OPERATORI)

            eui_cmbOperatore.SelectedItem = LeggiDatiConfig()

            eui_cmbOperatore.Focus()

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

        End Try
    End Sub

    Private Sub eui_cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdAnnulla.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub eui_cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdOK.Click
        Try
            LeggiDatiOperatore(eui_cmbOperatore.Text, TAB_OPERATORI)

            Dim pwdInChiaro As String = LeggiPwd(operatore.Pwd)

            If eui_txtPassword.Text = pwdInChiaro Then
                Me.DialogResult = DialogResult.OK
                g_frmMain.eui_cmdOperatore.Text = eui_cmbOperatore.Text.ToUpper
                LeggiDatiAccesso(operatore.Gruppo, TAB_GRUPPI)

                ' Imposta i vari comandi per l'operatore indentificato.
                Dim i As Integer
                For i = 1 To NUMERO_TOT_ENUM_FINESTRA ' Numero totale dell'enumerazione Finestra.
                    g_frmMain.ImpostaFunzioniOperatore(i)
                Next

                SalvaDatiConfig(operatore.Codice, operatore.Nome)

                Me.Close()

                ' Registra loperazione efettuata dall'operatore identificato.
                g_frmMain.RegistraOperazione(TipoOperazione.Login, String.Empty, MODULO_ACCESSO_OPERATORE)

            Else
                Me.DialogResult = DialogResult.None
                eui_txtPassword.Text = String.Empty
                eui_txtPassword.Focus()
                ErrorProvider1.SetError(eui_txtPassword, "La password non è corretta!")
                operatore.EliminaDati()
                Exit Sub
            End If

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

        End Try
    End Sub

    Private Sub eui_txtPassword_TextChanged(sender As Object, e As EventArgs) Handles eui_txtPassword.TextChanged
        ErrorProvider1.SetError(eui_txtPassword, String.Empty)
    End Sub
End Class
