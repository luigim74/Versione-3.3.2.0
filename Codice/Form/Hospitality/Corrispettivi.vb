Imports System.Data
Imports System.Data.OleDb

Public Class Corrispettivi
   Inherits System.Windows.Forms.Form

   Const NOME_TABELLA As String = "Corrispettivi"

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   ' Dichiara un oggetto Transazione
   Private tr As OleDbTransaction


#Region " Windows Form Designer generated code "

   Public Sub New(ByVal codice As String, ByVal data As String, ByVal fatture As String, ByVal ricevute As String, ByVal scontrini As String, ByVal nonIncassato As String)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Me.Text = "Corrispettivi del " & data
      Me.Tag = codice
      txtFatture.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(fatture))
      txtRicevute.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(ricevute))
      txtScontrini.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(scontrini))
      txtNonIncassato.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(nonIncassato))
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
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmdSalva As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents txtRicevute As System.Windows.Forms.TextBox
   Friend WithEvents txtFatture As System.Windows.Forms.TextBox
   Friend WithEvents txtScontrini As System.Windows.Forms.TextBox
   Friend WithEvents txtNonIncassato As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Corrispettivi))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtRicevute = New System.Windows.Forms.TextBox()
      Me.cmdSalva = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtFatture = New System.Windows.Forms.TextBox()
      Me.txtScontrini = New System.Windows.Forms.TextBox()
      Me.txtNonIncassato = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(43, 13)
      Me.Label1.TabIndex = 55634
      Me.Label1.Text = "Fatture:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 40)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(53, 13)
      Me.Label2.TabIndex = 55635
      Me.Label2.Text = "Ricevute:"
      '
      'txtRicevute
      '
      Me.txtRicevute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRicevute.ForeColor = System.Drawing.Color.Red
      Me.txtRicevute.Location = New System.Drawing.Point(104, 40)
      Me.txtRicevute.MaxLength = 255
      Me.txtRicevute.Name = "txtRicevute"
      Me.txtRicevute.Size = New System.Drawing.Size(128, 20)
      Me.txtRicevute.TabIndex = 1
      Me.txtRicevute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdSalva
      '
      Me.cmdSalva.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdSalva.Location = New System.Drawing.Point(64, 128)
      Me.cmdSalva.Name = "cmdSalva"
      Me.cmdSalva.Size = New System.Drawing.Size(80, 24)
      Me.cmdSalva.TabIndex = 4
      Me.cmdSalva.Text = "&Salva"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(152, 128)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnnulla.TabIndex = 5
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtFatture
      '
      Me.txtFatture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtFatture.ForeColor = System.Drawing.Color.Red
      Me.txtFatture.Location = New System.Drawing.Point(104, 16)
      Me.txtFatture.MaxLength = 255
      Me.txtFatture.Name = "txtFatture"
      Me.txtFatture.Size = New System.Drawing.Size(128, 20)
      Me.txtFatture.TabIndex = 0
      Me.txtFatture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtScontrini
      '
      Me.txtScontrini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontrini.ForeColor = System.Drawing.Color.Red
      Me.txtScontrini.Location = New System.Drawing.Point(104, 64)
      Me.txtScontrini.MaxLength = 255
      Me.txtScontrini.Name = "txtScontrini"
      Me.txtScontrini.Size = New System.Drawing.Size(128, 20)
      Me.txtScontrini.TabIndex = 2
      Me.txtScontrini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNonIncassato
      '
      Me.txtNonIncassato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNonIncassato.ForeColor = System.Drawing.Color.Red
      Me.txtNonIncassato.Location = New System.Drawing.Point(104, 88)
      Me.txtNonIncassato.MaxLength = 255
      Me.txtNonIncassato.Name = "txtNonIncassato"
      Me.txtNonIncassato.Size = New System.Drawing.Size(128, 20)
      Me.txtNonIncassato.TabIndex = 3
      Me.txtNonIncassato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 64)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(51, 13)
      Me.Label3.TabIndex = 55637
      Me.Label3.Text = "Scontrini:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 88)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(78, 13)
      Me.Label4.TabIndex = 55646
      Me.Label4.Text = "Non incassato:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Corrispettivi
      '
      Me.AcceptButton = Me.cmdSalva
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(250, 160)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtNonIncassato)
      Me.Controls.Add(Me.txtScontrini)
      Me.Controls.Add(Me.txtFatture)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdSalva)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtRicevute)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Corrispettivi"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Corrispettivi del "
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Function SalvaDati(ByVal tabella As String) As Boolean
      Try
         Dim sql As String

         Dim valTotale As Double = Convert.ToDouble(txtFatture.Text) + _
                                   Convert.ToDouble(txtRicevute.Text) + _
                                   Convert.ToDouble(txtScontrini.Text)

         Dim valIncassato As Double = valTotale - Convert.ToDouble(txtNonIncassato.Text)


         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa 
         sql = String.Format("UPDATE {0} " & _
                             "SET Fatture = @Fatture, " & _
                             "Ricevute = @Ricevute, " & _
                             "Scontrini = @Scontrini, " & _
                             "Totale = @Totale, " & _
                             "Incassato = @Incassato, " & _
                              "NonIncassato = @NonIncassato " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              Me.Tag)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Fatture", txtFatture.Text)
         cmdUpdate.Parameters.Add("@Ricevute", txtRicevute.Text)
         cmdUpdate.Parameters.Add("@Scontrini", txtScontrini.Text)
         cmdUpdate.Parameters.Add("@Totale", valTotale)
         cmdUpdate.Parameters.Add("@Incassato", valIncassato)
         cmdUpdate.Parameters.Add("@NonIncassato", txtNonIncassato.Text)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()
         ' Conferma transazione.
         tr.Commit()
         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         ' Annulla transazione.
         tr.Rollback()

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Private Sub cmdSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalva.Click
      Try
         If IsNumeric(txtFatture.Text) = False Then
            txtFatture.Text = "0,00"
         End If
         If IsNumeric(txtRicevute.Text) = False Then
            txtRicevute.Text = "0,00"
         End If
         If IsNumeric(txtScontrini.Text) = False Then
            txtScontrini.Text = "0,00"
         End If
         If IsNumeric(txtNonIncassato.Text) = False Then
            txtNonIncassato.Text = "0,00"
         End If

         SalvaDati(NOME_TABELLA)
         ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
         Me.Tag = "0"

         ' Chiude la finestra.
         Me.Close()

         g_frmMain.RegistraOperazione(TipoOperazione.Salva, "(" & Me.Text & ")", MODULO_CONTABILITA_CORRISPETTIVI)

         With g_frmCorrispettivi
            If .tbrMese.Pushed = True Then
               ' Aggiorna la griglia dati.
               .FiltraDati("Mese")
            ElseIf .tbrAnno.Pushed = True Then
               ' Aggiorna la griglia dati.
               .FiltraDati("Anno")
            ElseIf .tbrPeriodo.Pushed = True Then
               ' Aggiorna la griglia dati.
               .FiltraDati("Periodo")
            Else
               ' Aggiorna la griglia dati.
               .FiltraDati("Tutti")
            End If
         End With

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
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_CORRISPETTIVI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Corrispettivi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Corrispettivi_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_CORRISPETTIVI)
      End If
   End Sub

   Private Sub txtFatture_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFatture.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
      End If
   End Sub

   Private Sub txtFatture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFatture.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtRicevute_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRicevute.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
      End If
   End Sub

   Private Sub txtRicevute_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRicevute.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtScontrini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScontrini.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
      End If
   End Sub

   Private Sub txtScontrini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontrini.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtNonIncassato_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNonIncassato.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
      End If
   End Sub

   Private Sub txtNonIncassato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNonIncassato.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

End Class
