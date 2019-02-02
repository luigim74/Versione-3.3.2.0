Imports System.Data
Imports System.Data.OleDb

Public Class Ingredienti
   Inherits System.Windows.Forms.Form

   Const NOME_TABELLA As String = "Ingredienti"
   Const TAB_ARTICOLI As String = "Articoli"

   Private AIngredienti As New IngredientiPiatti
   Private AArticoli As New Articoli
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto Transazione
   Private tr As OleDbTransaction
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Dim Id_Piatto As Integer

#Region " Windows Form Designer generated code "

   Public Sub New(ByVal id As Integer)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Id_Piatto = id
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
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents cmdOk As System.Windows.Forms.Button
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents Label45 As System.Windows.Forms.Label
   Friend WithEvents Label46 As System.Windows.Forms.Label
   Friend WithEvents txtQuantit‡ As System.Windows.Forms.TextBox
   Friend WithEvents lblPrezzo As System.Windows.Forms.Label
   Friend WithEvents txtCosto As System.Windows.Forms.TextBox
   Friend WithEvents txtUM As System.Windows.Forms.TextBox
   Friend WithEvents cmbDescrizione As System.Windows.Forms.ComboBox
   Friend WithEvents cmbId_Art As System.Windows.Forms.ComboBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ingredienti))
      Me.lblPrezzo = New System.Windows.Forms.Label()
      Me.txtCosto = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtUM = New System.Windows.Forms.TextBox()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtQuantit‡ = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmbDescrizione = New System.Windows.Forms.ComboBox()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label45 = New System.Windows.Forms.Label()
      Me.Label46 = New System.Windows.Forms.Label()
      Me.cmbId_Art = New System.Windows.Forms.ComboBox()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblPrezzo
      '
      Me.lblPrezzo.AutoSize = True
      Me.lblPrezzo.BackColor = System.Drawing.Color.Transparent
      Me.lblPrezzo.ForeColor = System.Drawing.Color.Black
      Me.lblPrezzo.Location = New System.Drawing.Point(16, 120)
      Me.lblPrezzo.Name = "lblPrezzo"
      Me.lblPrezzo.Size = New System.Drawing.Size(37, 13)
      Me.lblPrezzo.TabIndex = 55635
      Me.lblPrezzo.Text = "Costo:"
      Me.lblPrezzo.Visible = False
      '
      'txtCosto
      '
      Me.txtCosto.BackColor = System.Drawing.SystemColors.Control
      Me.txtCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCosto.Location = New System.Drawing.Point(88, 120)
      Me.txtCosto.MaxLength = 255
      Me.txtCosto.Name = "txtCosto"
      Me.txtCosto.ReadOnly = True
      Me.txtCosto.Size = New System.Drawing.Size(112, 20)
      Me.txtCosto.TabIndex = 4
      Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtCosto.Visible = False
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(215, 88)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(79, 13)
      Me.Label3.TabIndex = 55637
      Me.Label3.Text = "Unit‡ di misura:"
      '
      'txtUM
      '
      Me.txtUM.BackColor = System.Drawing.SystemColors.Control
      Me.txtUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtUM.Location = New System.Drawing.Point(295, 88)
      Me.txtUM.MaxLength = 255
      Me.txtUM.Name = "txtUM"
      Me.txtUM.ReadOnly = True
      Me.txtUM.Size = New System.Drawing.Size(72, 20)
      Me.txtUM.TabIndex = 3
      '
      'cmdOk
      '
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOk.Location = New System.Drawing.Point(192, 144)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(80, 24)
      Me.cmdOk.TabIndex = 5
      Me.cmdOk.Text = "&OK"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(280, 144)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnnulla.TabIndex = 6
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtQuantit‡
      '
      Me.txtQuantit‡.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtQuantit‡.Location = New System.Drawing.Point(88, 88)
      Me.txtQuantit‡.MaxLength = 255
      Me.txtQuantit‡.Name = "txtQuantit‡"
      Me.txtQuantit‡.Size = New System.Drawing.Size(112, 20)
      Me.txtQuantit‡.TabIndex = 2
      Me.txtQuantit‡.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 88)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 55665
      Me.Label4.Text = "Quantit‡:"
      '
      'cmbDescrizione
      '
      Me.cmbDescrizione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDescrizione.Location = New System.Drawing.Point(88, 56)
      Me.cmbDescrizione.MaxLength = 32767
      Me.cmbDescrizione.Name = "cmbDescrizione"
      Me.cmbDescrizione.Size = New System.Drawing.Size(280, 21)
      Me.cmbDescrizione.TabIndex = 1
      '
      'txtCodice
      '
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtCodice.Location = New System.Drawing.Point(88, 24)
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.Size = New System.Drawing.Size(208, 20)
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TabStop = False
      '
      'Label45
      '
      Me.Label45.AutoSize = True
      Me.Label45.BackColor = System.Drawing.Color.Transparent
      Me.Label45.ForeColor = System.Drawing.Color.Black
      Me.Label45.Location = New System.Drawing.Point(16, 56)
      Me.Label45.Name = "Label45"
      Me.Label45.Size = New System.Drawing.Size(65, 13)
      Me.Label45.TabIndex = 55771
      Me.Label45.Text = "Descrizione:"
      '
      'Label46
      '
      Me.Label46.AutoSize = True
      Me.Label46.BackColor = System.Drawing.Color.Transparent
      Me.Label46.ForeColor = System.Drawing.Color.Black
      Me.Label46.Location = New System.Drawing.Point(16, 24)
      Me.Label46.Name = "Label46"
      Me.Label46.Size = New System.Drawing.Size(43, 13)
      Me.Label46.TabIndex = 55770
      Me.Label46.Text = "Codice:"
      '
      'cmbId_Art
      '
      Me.cmbId_Art.Location = New System.Drawing.Point(320, 24)
      Me.cmbId_Art.MaxLength = 32767
      Me.cmbId_Art.Name = "cmbId_Art"
      Me.cmbId_Art.Size = New System.Drawing.Size(48, 21)
      Me.cmbId_Art.TabIndex = 55772
      Me.cmbId_Art.Visible = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Ingredienti
      '
      Me.AcceptButton = Me.cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(386, 182)
      Me.Controls.Add(Me.cmbId_Art)
      Me.Controls.Add(Me.cmbDescrizione)
      Me.Controls.Add(Me.txtCodice)
      Me.Controls.Add(Me.Label45)
      Me.Controls.Add(Me.Label46)
      Me.Controls.Add(Me.txtQuantit‡)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtUM)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.lblPrezzo)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdOk)
      Me.Controls.Add(Me.txtCosto)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Ingredienti"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Dettaglio ingrediente"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Function SalvaDati() As Boolean
      Try
         With AIngredienti
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Id_Piatto = Id_Piatto
            .Id_Articolo = cmbId_Art.Items.Item(cmbDescrizione.Items.IndexOf(cmbDescrizione.Text))
            .Descrizione = cmbDescrizione.Text 'FormattaApici(cmbDescrizione.Text)- NON UTILIZZARE CON QUERY PARAMETRICHE.
            .Unit‡Misura = txtUM.Text

            If IsNumeric(txtCosto.Text) Then
               .Costo = CDec(CFormatta.FormattaEuro(txtCosto.Text))
            Else
               .Costo = 0
            End If

            If IsNumeric(txtQuantit‡.Text) Then
               .Quantit‡ = CDbl(CFormatta.FormattaNumeroDouble(txtQuantit‡.Text))
            Else
               .Quantit‡ = 0
            End If

            ' Se la propriet‡ 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(NOME_TABELLA, Me.Tag)
            Else
               Return .InserisciDati(NOME_TABELLA)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

      End Try
   End Function

   Private Sub cmdSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      Try
         ' Salva i dati nel database.
         If SalvaDati() = True Then

            If IsNothing(g_frmPiatti) = False Then
               ' Aggiorna la griglia dati.
               g_frmPiatti.AggiornaDatiIngredienti(0)
            End If

            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = " (" & g_frmPiatti.DataGrid1.Item(g_frmPiatti.DataGrid1.CurrentCell.RowNumber, 1) & " - " & AIngredienti.Descrizione & ")"

            g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_PIATTI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      Try
         ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
         Me.Tag = "0"

         ' Chiude la finestra.
         Me.Close()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_PIATTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Ingredienti_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica le liste.
         CaricaListaArticoli(cmbDescrizione, cmbId_Art, TAB_ARTICOLI)

         If Me.Tag <> "" Then
            With AIngredienti
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Id
               cmbDescrizione.Text = .Descrizione
               txtUM.Text = .Unit‡Misura
               txtQuantit‡.Text = CFormatta.FormattaNumeroDouble(.Quantit‡)
               txtCosto.Text = CFormatta.FormattaEuro(.Costo)
            End With
         Else

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Imposta lo stato attivo.
         cmbDescrizione.Focus()

      End Try
   End Sub

   Private Sub Ingredienti_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_PIATTI)
      End If
   End Sub

   Private Sub txtQuantit‡_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantit‡.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub cmbDescrizione_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDescrizione.SelectedIndexChanged
      With AArticoli
         ' Visualizza i dati nei rispettivi campi.
         .LeggiDati("Articoli", cmbId_Art.Items.Item(cmbDescrizione.Items.IndexOf(cmbDescrizione.Text)))

         ' Assegna i dati dei campi della classe alle caselle di testo.
         txtUM.Text = .Unit‡Misura
         txtCosto.Text = CFormatta.FormattaEuro(.PrezzoAcquisto)
      End With
   End Sub

   Private Sub txtQuantit‡_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantit‡.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub


End Class
