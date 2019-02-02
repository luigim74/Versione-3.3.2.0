Imports System.Data
Imports System.Data.OleDb

Public Class Chiusura
   Inherits System.Windows.Forms.Form

   Const TABELLA_DOCUMENTI As String = "Documenti"
   Const TABELLA_CORRISPETTIVI As String = "Corrispettivi"
   Const DOC_FATTURA As String = "Fattura"
   Const DOC_RICEVUTA As String = "Ricevuta Fiscale"
   Const DOC_SCONTRINO As String = "Scontrino"

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   Dim cmd As New OleDbCommand(sql, cn)
   Dim sql As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   ' Dichiara un oggetto Transazione
   Private tr As OleDbTransaction


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
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents txtRicevute As System.Windows.Forms.TextBox
   Friend WithEvents txtFatture As System.Windows.Forms.TextBox
   Friend WithEvents txtScontrini As System.Windows.Forms.TextBox
   Friend WithEvents txtNonIncassato As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmdEsegui As System.Windows.Forms.Button
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtIncassato As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtTotale As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents txtScontriniQ As System.Windows.Forms.TextBox
   Friend WithEvents txtFattureQ As System.Windows.Forms.TextBox
   Friend WithEvents txtRicevuteQ As System.Windows.Forms.TextBox
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Chiusura))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtRicevute = New System.Windows.Forms.TextBox()
      Me.cmdEsegui = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtFatture = New System.Windows.Forms.TextBox()
      Me.txtScontrini = New System.Windows.Forms.TextBox()
      Me.txtNonIncassato = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtIncassato = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtTotale = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtScontriniQ = New System.Windows.Forms.TextBox()
      Me.txtFattureQ = New System.Windows.Forms.TextBox()
      Me.txtRicevuteQ = New System.Windows.Forms.TextBox()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 56)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(43, 13)
      Me.Label1.TabIndex = 55634
      Me.Label1.Text = "Fatture:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 80)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(53, 13)
      Me.Label2.TabIndex = 55635
      Me.Label2.Text = "Ricevute:"
      '
      'txtRicevute
      '
      Me.txtRicevute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRicevute.ForeColor = System.Drawing.Color.Red
      Me.txtRicevute.Location = New System.Drawing.Point(152, 80)
      Me.txtRicevute.MaxLength = 255
      Me.txtRicevute.Name = "txtRicevute"
      Me.txtRicevute.Size = New System.Drawing.Size(128, 20)
      Me.txtRicevute.TabIndex = 2
      Me.txtRicevute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdEsegui
      '
      Me.cmdEsegui.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdEsegui.Location = New System.Drawing.Point(112, 232)
      Me.cmdEsegui.Name = "cmdEsegui"
      Me.cmdEsegui.Size = New System.Drawing.Size(80, 24)
      Me.cmdEsegui.TabIndex = 7
      Me.cmdEsegui.Text = "&Esegui"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(200, 232)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnnulla.TabIndex = 8
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
      Me.txtFatture.Location = New System.Drawing.Point(152, 56)
      Me.txtFatture.MaxLength = 255
      Me.txtFatture.Name = "txtFatture"
      Me.txtFatture.Size = New System.Drawing.Size(128, 20)
      Me.txtFatture.TabIndex = 1
      Me.txtFatture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtScontrini
      '
      Me.txtScontrini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontrini.ForeColor = System.Drawing.Color.Red
      Me.txtScontrini.Location = New System.Drawing.Point(152, 104)
      Me.txtScontrini.MaxLength = 255
      Me.txtScontrini.Name = "txtScontrini"
      Me.txtScontrini.Size = New System.Drawing.Size(128, 20)
      Me.txtScontrini.TabIndex = 3
      Me.txtScontrini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNonIncassato
      '
      Me.txtNonIncassato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNonIncassato.ForeColor = System.Drawing.Color.Red
      Me.txtNonIncassato.Location = New System.Drawing.Point(152, 192)
      Me.txtNonIncassato.MaxLength = 255
      Me.txtNonIncassato.Name = "txtNonIncassato"
      Me.txtNonIncassato.Size = New System.Drawing.Size(128, 20)
      Me.txtNonIncassato.TabIndex = 6
      Me.txtNonIncassato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 104)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(51, 13)
      Me.Label3.TabIndex = 55637
      Me.Label3.Text = "Scontrini:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 192)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(78, 13)
      Me.Label4.TabIndex = 55646
      Me.Label4.Text = "Non incassato:"
      '
      'dtpData
      '
      Me.dtpData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpData.Location = New System.Drawing.Point(104, 16)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(176, 20)
      Me.dtpData.TabIndex = 0
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 16)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(85, 13)
      Me.Label5.TabIndex = 55648
      Me.Label5.Text = "Totali del giorno:"
      '
      'txtIncassato
      '
      Me.txtIncassato.BackColor = System.Drawing.SystemColors.Control
      Me.txtIncassato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIncassato.ForeColor = System.Drawing.Color.Red
      Me.txtIncassato.Location = New System.Drawing.Point(152, 168)
      Me.txtIncassato.MaxLength = 255
      Me.txtIncassato.Name = "txtIncassato"
      Me.txtIncassato.ReadOnly = True
      Me.txtIncassato.Size = New System.Drawing.Size(128, 20)
      Me.txtIncassato.TabIndex = 5
      Me.txtIncassato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(16, 168)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(53, 13)
      Me.Label6.TabIndex = 55652
      Me.Label6.Text = "Incassato"
      '
      'txtTotale
      '
      Me.txtTotale.BackColor = System.Drawing.SystemColors.Control
      Me.txtTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotale.ForeColor = System.Drawing.Color.Red
      Me.txtTotale.Location = New System.Drawing.Point(152, 136)
      Me.txtTotale.MaxLength = 255
      Me.txtTotale.Name = "txtTotale"
      Me.txtTotale.ReadOnly = True
      Me.txtTotale.Size = New System.Drawing.Size(128, 20)
      Me.txtTotale.TabIndex = 4
      Me.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(16, 136)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(40, 13)
      Me.Label7.TabIndex = 55651
      Me.Label7.Text = "Totale:"
      '
      'txtScontriniQ
      '
      Me.txtScontriniQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontriniQ.ForeColor = System.Drawing.SystemColors.Control
      Me.txtScontriniQ.Location = New System.Drawing.Point(104, 104)
      Me.txtScontriniQ.MaxLength = 255
      Me.txtScontriniQ.Name = "txtScontriniQ"
      Me.txtScontriniQ.ReadOnly = True
      Me.txtScontriniQ.Size = New System.Drawing.Size(40, 20)
      Me.txtScontriniQ.TabIndex = 55655
      Me.txtScontriniQ.TabStop = False
      Me.txtScontriniQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtFattureQ
      '
      Me.txtFattureQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtFattureQ.ForeColor = System.Drawing.SystemColors.Control
      Me.txtFattureQ.Location = New System.Drawing.Point(104, 56)
      Me.txtFattureQ.MaxLength = 255
      Me.txtFattureQ.Name = "txtFattureQ"
      Me.txtFattureQ.ReadOnly = True
      Me.txtFattureQ.Size = New System.Drawing.Size(40, 20)
      Me.txtFattureQ.TabIndex = 55653
      Me.txtFattureQ.TabStop = False
      Me.txtFattureQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRicevuteQ
      '
      Me.txtRicevuteQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRicevuteQ.ForeColor = System.Drawing.SystemColors.Control
      Me.txtRicevuteQ.Location = New System.Drawing.Point(104, 80)
      Me.txtRicevuteQ.MaxLength = 255
      Me.txtRicevuteQ.Name = "txtRicevuteQ"
      Me.txtRicevuteQ.ReadOnly = True
      Me.txtRicevuteQ.Size = New System.Drawing.Size(40, 20)
      Me.txtRicevuteQ.TabIndex = 55654
      Me.txtRicevuteQ.TabStop = False
      Me.txtRicevuteQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Chiusura
      '
      Me.AcceptButton = Me.cmdEsegui
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(298, 264)
      Me.Controls.Add(Me.txtScontriniQ)
      Me.Controls.Add(Me.txtFattureQ)
      Me.Controls.Add(Me.txtRicevuteQ)
      Me.Controls.Add(Me.txtIncassato)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.txtTotale)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtNonIncassato)
      Me.Controls.Add(Me.txtScontrini)
      Me.Controls.Add(Me.txtFatture)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdEsegui)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtRicevute)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Chiusura"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Chiusura giornaliera"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Function SalvaDatiCorrispettivi(ByVal tabella As String) As Boolean
      Try
         Dim sql As String

         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa 
         sql = String.Format("INSERT INTO {0} (Data, Giorno, Fatture, Ricevute, Scontrini, Totale, Incassato, NonIncassato) " & _
                                       "VALUES(@Data, @Giorno, @Fatture, @Ricevute, @Scontrini, @Totale, @Incassato, @NonIncassato)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", dtpData.Value.Date)
         cmdInsert.Parameters.Add("@Giorno", ConvertiGiornoSettimana(dtpData.Value.DayOfWeek))
         cmdInsert.Parameters.Add("@Fatture", txtFatture.Text)
         cmdInsert.Parameters.Add("@Ricevute", txtRicevute.Text)
         cmdInsert.Parameters.Add("@Scontrini", txtScontrini.Text)
         cmdInsert.Parameters.Add("@Totale", txtTotale.Text)
         cmdInsert.Parameters.Add("@Incassato", txtIncassato.Text)
         cmdInsert.Parameters.Add("@NonIncassato", txtNonIncassato.Text)

         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()
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

   Public Function SalvaChiusuraDoc(ByVal tabella As String) As Boolean
      Try
         Dim sql As String

         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa 
         sql = String.Format("UPDATE {0} SET Chiuso = @Chiuso WHERE Chiuso = 'No'", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Chiuso", "Sì")

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

   Private Function LeggiNumDocumenti(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE (Chiuso = 'No') AND (TipoDoc = '{1}')", tabella, tipoDoc)
         numRec = Convert.ToInt32(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function SommaValDocumenti(ByVal tabella As String, ByVal tipoDoc As String) As Double
      Dim closeOnExit As Boolean
      Dim valTotale As Double

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT SUM(TotDoc) FROM {0} WHERE (Chiuso = 'No')AND (TipoDoc = '{1}')", tabella, tipoDoc)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            valTotale = Convert.ToDouble(cmd.ExecuteScalar())
         Else
            valTotale = 0
         End If

         Return valTotale

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function SommaValSospeso(ByVal tabella As String) As Double
      Dim closeOnExit As Boolean
      Dim valTotale As Double

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT SUM(SospesoIncassare) FROM {0} WHERE (Chiuso = 'No')", tabella)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            valTotale = Convert.ToDouble(cmd.ExecuteScalar())
         Else
            valTotale = 0
         End If

         Return valTotale

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function SommaValBuoni(ByVal tabella As String) As Double
      Dim closeOnExit As Boolean
      Dim valTotale As Double

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT SUM(BuoniPastoIncassare) FROM {0} WHERE (Chiuso = 'No')", tabella)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            valTotale = Convert.ToDouble(cmd.ExecuteScalar())
         Else
            valTotale = 0
         End If

         Return valTotale

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub AggiornaValori()
      Dim valFatture As Double = txtFatture.Text
      Dim valRicevute As Double = txtRicevute.Text
      Dim valScontrini As Double = txtScontrini.Text
      Dim valTotale As Double = valFatture + valRicevute + valScontrini
      Dim valNonIncassato As Double = txtNonIncassato.Text
      Dim valIncassato As Double = valTotale - valNonIncassato

      txtTotale.Text = CFormatta.FormattaNumeroDouble(valTotale)
      txtIncassato.Text = CFormatta.FormattaNumeroDouble(valIncassato)
   End Sub

   Private Sub cmdEsegui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsegui.Click
      Try
         Dim risposta As MsgBoxResult
         risposta = MsgBox("La chiusura giornaliera riepiloga la produzione del giorno. " & _
                           "Per una corretta valorizzazione degli importi, " & _
                           "la chiusura contabile definitiva deve essere effettuata ogni giorno " & _
                           "come ultima operazione contabile della giornata. " & vbCr + vbNewLine & _
                           "Procedere con la chiusura giornaliera?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

         If risposta = MsgBoxResult.No Then
            Exit Sub
         End If

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

         SalvaChiusuraDoc(TABELLA_DOCUMENTI)
         SalvaDatiCorrispettivi(TABELLA_CORRISPETTIVI)
         Me.Close()

         If IsNothing(g_frmCorrispettivi) = False Then
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
         End If

         ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
         Me.Tag = "0"

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiusura, STR_CONTABILITA_CHIUSURA, MODULO_CONTABILITA_CHIUSURA)

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
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_CHIUSURA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Chiusura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         txtFattureQ.Text = Convert.ToString(LeggiNumDocumenti(TABELLA_DOCUMENTI, DOC_FATTURA))
         txtRicevuteQ.Text = Convert.ToString(LeggiNumDocumenti(TABELLA_DOCUMENTI, DOC_RICEVUTA))
         txtScontriniQ.Text = Convert.ToString(LeggiNumDocumenti(TABELLA_DOCUMENTI, DOC_SCONTRINO))

         Dim valFatture As Double = SommaValDocumenti(TABELLA_DOCUMENTI, DOC_FATTURA)
         Dim valRicevute As Double = SommaValDocumenti(TABELLA_DOCUMENTI, DOC_RICEVUTA)
         Dim valScontrini As Double = SommaValDocumenti(TABELLA_DOCUMENTI, DOC_SCONTRINO)
         Dim valTotale As Double = valFatture + valRicevute + valScontrini
         Dim valBuoni As Double = SommaValBuoni(TABELLA_DOCUMENTI)
         Dim valNonIncassato As Double = SommaValSospeso(TABELLA_DOCUMENTI) + valBuoni
         Dim valIncassato As Double = valTotale - valNonIncassato

         txtFatture.Text = CFormatta.FormattaNumeroDouble(valFatture)
         txtRicevute.Text = CFormatta.FormattaNumeroDouble(valRicevute)
         txtScontrini.Text = CFormatta.FormattaNumeroDouble(valScontrini)
         txtTotale.Text = CFormatta.FormattaNumeroDouble(valTotale)
         txtIncassato.Text = CFormatta.FormattaNumeroDouble(valIncassato)
         txtNonIncassato.Text = CFormatta.FormattaNumeroDouble(valNonIncassato)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTABILITA_CHIUSURA, MODULO_CONTABILITA_CHIUSURA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Chiusura_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_CHIUSURA, MODULO_CONTABILITA_CHIUSURA)
      End If
   End Sub

   Private Sub txtFatture_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFatture.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
         AggiornaValori()
      End If
   End Sub

   Private Sub txtFatture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFatture.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtRicevute_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRicevute.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
         AggiornaValori()
      End If
   End Sub

   Private Sub txtRicevute_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRicevute.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtScontrini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScontrini.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
         AggiornaValori()
      End If
   End Sub

   Private Sub txtScontrini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontrini.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtTotale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotale.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
      End If
   End Sub

   Private Sub txtTotale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotale.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtIncassato_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncassato.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
      End If
   End Sub

   Private Sub txtIncassato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIncassato.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtNonIncassato_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNonIncassato.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaNumeroDouble(sender.Text)
         AggiornaValori()
      End If
   End Sub

   Private Sub txtNonIncassato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNonIncassato.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

End Class
