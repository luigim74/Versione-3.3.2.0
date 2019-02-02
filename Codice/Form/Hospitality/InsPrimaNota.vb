Imports System.Data
Imports System.Data.OleDb

Public Class InPrimaNota
   Inherits System.Windows.Forms.Form

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   ' Dichiara un oggetto Transazione
   Private tr As OleDbTransaction

   Public Function SalvaDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Dim AppoEntrateCassa As Decimal = 0
      Dim AppoUsciteCassa As Decimal = 0
      Dim AppoVersamentiBanca As Decimal = 0
      Dim AppoPrelieviBanca As Decimal = 0
      Dim AppoEntrateVarie As Decimal = 0
      Dim AppoUsciteVarie As Decimal = 0

      Try
         Select Case Me.Text
            Case "Entrate Cassa"
               If IsNumeric(txtImporto.Text) Then
                  AppoEntrateCassa = CFormatta.FormattaEuro(CDec(txtImporto.Text))
               Else
                  AppoEntrateCassa = CDec(0)
               End If

            Case "Uscite Cassa"
               If IsNumeric(txtImporto.Text) Then
                  AppoUsciteCassa = CFormatta.FormattaEuro(CDec(txtImporto.Text))
               Else
                  AppoUsciteCassa = CDec(0)
               End If

            Case "Versamenti Banca"
               If IsNumeric(txtImporto.Text) Then
                  AppoVersamentiBanca = CFormatta.FormattaEuro(CDec(txtImporto.Text))
               Else
                  AppoVersamentiBanca = CDec(0)
               End If

            Case "Prelievi Banca"
               If IsNumeric(txtImporto.Text) Then
                  AppoPrelieviBanca = CFormatta.FormattaEuro(CDec(txtImporto.Text))
               Else
                  AppoPrelieviBanca = CDec(0)
               End If

            Case "Entrate Varie"
               If IsNumeric(txtImporto.Text) Then
                  AppoEntrateVarie = CFormatta.FormattaEuro(CDec(txtImporto.Text))
               Else
                  AppoEntrateVarie = CDec(0)
               End If

            Case "Entrate Cassa"
               If IsNumeric(txtImporto.Text) Then
                  AppoUsciteCassa = CFormatta.FormattaEuro(CDec(txtImporto.Text))
               Else
                  AppoUsciteCassa = CDec(0)
               End If

            Case "Uscite Varie"
               If IsNumeric(txtImporto.Text) Then
                  AppoUsciteVarie = CFormatta.FormattaEuro(CDec(txtImporto.Text))
               Else
                  AppoUsciteVarie = CDec(0)
               End If
         End Select

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa 
         sql = "INSERT INTO " & tabella & " (Data, Descrizione, EntrateCassa, UsciteCassa, " & _
               "VersamentiBanca, PrelieviBanca, EntrateVarie, UsciteVarie) " & _
               "VALUES ('" & FormattaData(txtdata.Text, True) & "','" & FormattaApici(txtDescrizione.Text) & "','" & AppoEntrateCassa & "','" & AppoUsciteCassa & "','" & AppoVersamentiBanca & "','" & AppoPrelieviBanca & "','" & AppoEntrateVarie & "','" & AppoUsciteVarie & "');"

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)
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
   Friend WithEvents txtImporto As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Friend WithEvents cmdSalva As System.Windows.Forms.Button
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents txtdata As System.Windows.Forms.DateTimePicker
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InPrimaNota))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtImporto = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.cmdSalva = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.txtdata = New System.Windows.Forms.DateTimePicker()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(8, 32)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(33, 13)
      Me.Label1.TabIndex = 55634
      Me.Label1.Text = "Data:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(8, 64)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(45, 13)
      Me.Label2.TabIndex = 55635
      Me.Label2.Text = "Importo:"
      '
      'txtImporto
      '
      Me.txtImporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtImporto.Location = New System.Drawing.Point(80, 64)
      Me.txtImporto.MaxLength = 255
      Me.txtImporto.Name = "txtImporto"
      Me.txtImporto.Size = New System.Drawing.Size(176, 20)
      Me.txtImporto.TabIndex = 55636
      Me.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(8, 96)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(65, 13)
      Me.Label3.TabIndex = 55637
      Me.Label3.Text = "Descrizione:"
      '
      'txtDescrizione
      '
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.Location = New System.Drawing.Point(80, 96)
      Me.txtDescrizione.MaxLength = 255
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.Size = New System.Drawing.Size(304, 20)
      Me.txtDescrizione.TabIndex = 55638
      '
      'cmdSalva
      '
      Me.cmdSalva.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdSalva.Location = New System.Drawing.Point(208, 136)
      Me.cmdSalva.Name = "cmdSalva"
      Me.cmdSalva.Size = New System.Drawing.Size(80, 24)
      Me.cmdSalva.TabIndex = 55641
      Me.cmdSalva.Text = "&Salva"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(296, 136)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnnulla.TabIndex = 55642
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'txtdata
      '
      Me.txtdata.Location = New System.Drawing.Point(80, 32)
      Me.txtdata.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
      Me.txtdata.Name = "txtdata"
      Me.txtdata.Size = New System.Drawing.Size(176, 20)
      Me.txtdata.TabIndex = 55664
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
      'InPrimaNota
      '
      Me.AcceptButton = Me.cmdSalva
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(397, 170)
      Me.Controls.Add(Me.txtdata)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdSalva)
      Me.Controls.Add(Me.txtDescrizione)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtImporto)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "InPrimaNota"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub cmdSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalva.Click
      Try
         SalvaDati("PrimaNota")
         Me.Close()

         ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
         Me.Tag = "0"

         ' Chiude la finestra.
         Me.Close()

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = " (" & txtDescrizione.Text & " - € " & txtImporto.Text & ")"
         g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_CONTABILITA_PRIMA_NOTA)

         With g_frmPrimaNota
            If .tbrMese.Pushed = True Then
               ' Aggiorna la griglia dati.
               .CaricaGriglia("Mese")
               Exit Sub
            ElseIf .tbrAnno.Pushed = True Then
               ' Aggiorna la griglia dati.
               .CaricaGriglia("Anno")
               Exit Sub
            ElseIf .tbrPeriodo.Pushed = True Then
               ' Aggiorna la griglia dati.
               .CaricaGriglia("Periodo")
               Exit Sub
            Else
               ' Aggiorna la griglia dati.
               .CaricaGriglia("Tutti")
               Exit Sub
            End If

            .SommaImporti()
            .AggIntGriglia()
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
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_PRIMA_NOTA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub InsPrimaNota_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         txtdata.Text = Now.Date

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub InPrimaNota_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_PRIMA_NOTA)
      End If
   End Sub

   Private Sub txtImporto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporto.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtImporto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub


End Class
