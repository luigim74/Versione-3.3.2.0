Imports System.Data
Imports System.Data.OleDb

Public Class CaricoScarico
   Inherits System.Windows.Forms.Form

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto Transazione
   Private tr As OleDbTransaction

   Dim nomeMagazzino As String = ""
   Dim idArticolo As Integer
   Dim codArticolo As String
   Dim descrArticolo As String
   Dim fornArticolo As String
   Dim magArticolo As String
   Dim giacenzaAttuale As Double
   Dim caricoAttuale As Double
   Dim scaricoAttuale As Double
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Dim scortaMinima As Double

#Region " Windows Form Designer generated code "

   Public Sub New(ByVal titolo As String, ByVal id As Integer, ByVal codice As String, ByVal descrizione As String, _
                  ByVal giacenza As Double, ByVal carico As Double, ByVal scarico As Double, ByVal scortaMin As Double, _
                  Optional ByVal prezzo As String = "", Optional ByVal fornitore As String = "", Optional ByVal magazzino As String = "")

      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

      Me.Text = titolo
      idArticolo = id
      txtCodice.Text = codice
      txtDescrizione.Text = descrizione
      txtQuantit‡.Text = "1,00"
      scortaMinima = scortaMin
      cmbFornitore.Text = fornitore
      txtPrezzo.Text = CFormatta.FormattaEuro(prezzo)
      txtCausale.Text = titolo & " manuale"
      nomeMagazzino = magazzino
      codArticolo = codice
      descrArticolo = descrizione
      fornArticolo = fornitore
      magArticolo = magazzino

      giacenzaAttuale = giacenza
      caricoAttuale = carico
      scaricoAttuale = scarico
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
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents cmdOk As System.Windows.Forms.Button
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmbFornitore As System.Windows.Forms.ComboBox
   Friend WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents Label45 As System.Windows.Forms.Label
   Friend WithEvents Label46 As System.Windows.Forms.Label
   Friend WithEvents txtPrezzo As System.Windows.Forms.TextBox
   Friend WithEvents txtCausale As System.Windows.Forms.TextBox
   Friend WithEvents txtQuantit‡ As System.Windows.Forms.TextBox
   Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Friend WithEvents lblPrezzo As System.Windows.Forms.Label
   Friend WithEvents lblFornitore As System.Windows.Forms.Label
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaricoScarico))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblPrezzo = New System.Windows.Forms.Label()
      Me.txtPrezzo = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtCausale = New System.Windows.Forms.TextBox()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtQuantit‡ = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.cmbFornitore = New System.Windows.Forms.ComboBox()
      Me.lblFornitore = New System.Windows.Forms.Label()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label45 = New System.Windows.Forms.Label()
      Me.Label46 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 72)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(33, 13)
      Me.Label1.TabIndex = 55634
      Me.Label1.Text = "Data:"
      '
      'lblPrezzo
      '
      Me.lblPrezzo.AutoSize = True
      Me.lblPrezzo.ForeColor = System.Drawing.Color.Black
      Me.lblPrezzo.Location = New System.Drawing.Point(176, 104)
      Me.lblPrezzo.Name = "lblPrezzo"
      Me.lblPrezzo.Size = New System.Drawing.Size(96, 13)
      Me.lblPrezzo.TabIndex = 55635
      Me.lblPrezzo.Text = "Prezzo di acquisto:"
      '
      'txtPrezzo
      '
      Me.txtPrezzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPrezzo.Location = New System.Drawing.Point(272, 104)
      Me.txtPrezzo.MaxLength = 255
      Me.txtPrezzo.Name = "txtPrezzo"
      Me.txtPrezzo.Size = New System.Drawing.Size(96, 20)
      Me.txtPrezzo.TabIndex = 2
      Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 168)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(48, 13)
      Me.Label3.TabIndex = 55637
      Me.Label3.Text = "Causale:"
      '
      'txtCausale
      '
      Me.txtCausale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCausale.Location = New System.Drawing.Point(88, 168)
      Me.txtCausale.MaxLength = 255
      Me.txtCausale.Name = "txtCausale"
      Me.txtCausale.Size = New System.Drawing.Size(280, 20)
      Me.txtCausale.TabIndex = 4
      '
      'cmdOk
      '
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOk.Location = New System.Drawing.Point(192, 208)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(80, 24)
      Me.cmdOk.TabIndex = 5
      Me.cmdOk.Text = "&OK"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(280, 208)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnnulla.TabIndex = 6
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'dtpData
      '
      Me.dtpData.Location = New System.Drawing.Point(88, 72)
      Me.dtpData.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(184, 20)
      Me.dtpData.TabIndex = 0
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtQuantit‡
      '
      Me.txtQuantit‡.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtQuantit‡.Location = New System.Drawing.Point(88, 104)
      Me.txtQuantit‡.MaxLength = 255
      Me.txtQuantit‡.Name = "txtQuantit‡"
      Me.txtQuantit‡.Size = New System.Drawing.Size(80, 20)
      Me.txtQuantit‡.TabIndex = 1
      Me.txtQuantit‡.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 104)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 55665
      Me.Label4.Text = "Quantit‡:"
      '
      'txtDescrizione
      '
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Control
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.Location = New System.Drawing.Point(88, 40)
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.ReadOnly = True
      Me.txtDescrizione.Size = New System.Drawing.Size(280, 20)
      Me.txtDescrizione.TabIndex = 8
      Me.txtDescrizione.TabStop = False
      '
      'cmbFornitore
      '
      Me.cmbFornitore.Location = New System.Drawing.Point(88, 136)
      Me.cmbFornitore.MaxLength = 32767
      Me.cmbFornitore.Name = "cmbFornitore"
      Me.cmbFornitore.Size = New System.Drawing.Size(280, 21)
      Me.cmbFornitore.TabIndex = 3
      '
      'lblFornitore
      '
      Me.lblFornitore.AutoSize = True
      Me.lblFornitore.ForeColor = System.Drawing.Color.Black
      Me.lblFornitore.Location = New System.Drawing.Point(16, 136)
      Me.lblFornitore.Name = "lblFornitore"
      Me.lblFornitore.Size = New System.Drawing.Size(51, 13)
      Me.lblFornitore.TabIndex = 55772
      Me.lblFornitore.Text = "Fornitore:"
      '
      'txtCodice
      '
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtCodice.Location = New System.Drawing.Point(88, 16)
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.Size = New System.Drawing.Size(184, 20)
      Me.txtCodice.TabIndex = 7
      Me.txtCodice.TabStop = False
      '
      'Label45
      '
      Me.Label45.AutoSize = True
      Me.Label45.ForeColor = System.Drawing.Color.Black
      Me.Label45.Location = New System.Drawing.Point(16, 40)
      Me.Label45.Name = "Label45"
      Me.Label45.Size = New System.Drawing.Size(65, 13)
      Me.Label45.TabIndex = 55771
      Me.Label45.Text = "Descrizione:"
      '
      'Label46
      '
      Me.Label46.AutoSize = True
      Me.Label46.ForeColor = System.Drawing.Color.Black
      Me.Label46.Location = New System.Drawing.Point(16, 16)
      Me.Label46.Name = "Label46"
      Me.Label46.Size = New System.Drawing.Size(43, 13)
      Me.Label46.TabIndex = 55770
      Me.Label46.Text = "Codice:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'CaricoScarico
      '
      Me.AcceptButton = Me.cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(386, 240)
      Me.Controls.Add(Me.txtDescrizione)
      Me.Controls.Add(Me.cmbFornitore)
      Me.Controls.Add(Me.lblFornitore)
      Me.Controls.Add(Me.txtCodice)
      Me.Controls.Add(Me.Label45)
      Me.Controls.Add(Me.Label46)
      Me.Controls.Add(Me.txtQuantit‡)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.cmdOk)
      Me.Controls.Add(Me.txtCausale)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtPrezzo)
      Me.Controls.Add(Me.lblPrezzo)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CaricoScarico"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Function SalvaDati(ByVal tabella As String, ByVal id As Integer, ByVal giacenza As Double, _
                              ByVal carico As Double, ByVal scarico As Double, _
                              ByVal situazione As Double, ByVal prezzo As String, _
                              ByVal valCarico As Double, ByVal valScarico As Double, ByVal valAttuale As Double) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET Giacenza = @Giacenza, " & _
                             "Carico = @Carico, " & _
                             "Scarico = @Scarico, " & _
                             "SituazioneScorta = @SituazioneScorta, " & _
                             "ValCarico = @ValCarico, " & _
                             "valScarico = @ValScarico, " & _
                             "ValAttuale = @ValAttuale, " & _
                             "PrezzoAcquisto = @Prezzo " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              id)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Giacenza", giacenza)
         cmdUpdate.Parameters.Add("@Carico", carico)
         cmdUpdate.Parameters.Add("@Scarico", scarico)
         cmdUpdate.Parameters.Add("@SituazioneScorta", situazione)
         cmdUpdate.Parameters.Add("@ValCarico", valCarico)
         cmdUpdate.Parameters.Add("@ValScarico", valScarico)
         cmdUpdate.Parameters.Add("@ValAttuale", valAttuale)
         cmdUpdate.Parameters.Add("@Prezzo", prezzo)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Private Function SalvaMovimentiMag(ByVal tabella As String, ByVal id_Articolo As Integer, ByVal data As String, _
                                      ByVal codice As String, ByVal descrizione As String, _
                                      ByVal carico As Double, ByVal scarico As Double, _
                                      ByVal causale As String, ByVal prezzo As String, _
                                      ByVal fornitore As String, ByVal magazzino As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Id_Articolo, Data, Codice, Descrizione, PrezzoAcquisto, " & _
                                              "Carico, Scarico, Causale, Fornitore, Magazzino) " & _
                                       "VALUES(@Id_Articolo, @Data, @Codice, @Descrizione, @PrezzoAcquisto, " & _
                                              "@Carico, @Scarico, @Causale, @Fornitore, @Magazzino)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Id_Articolo", id_Articolo)
         cmdInsert.Parameters.Add("@Data", data)
         cmdInsert.Parameters.Add("@Codice", codice)
         cmdInsert.Parameters.Add("@Descrizione", descrizione)
         cmdInsert.Parameters.Add("@PrezzoAcquisto", prezzo)
         cmdInsert.Parameters.Add("@Carico", carico)
         cmdInsert.Parameters.Add("@Scarico", scarico)
         cmdInsert.Parameters.Add("@Causale", causale)
         cmdInsert.Parameters.Add("@Fornitore", fornitore)
         cmdInsert.Parameters.Add("@Magazzino", magazzino)

         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function


   Private Function CalcolaGiacenza(ByVal giacenza As Double, ByVal scortaMin As Double, ByVal quantit‡ As Double, ByVal tipoOperazione As String) As Decimal
      Try
         If tipoOperazione = "Carico" Then
            Return (giacenza + quantit‡)

         ElseIf tipoOperazione = "Scarico" Then
            If scortaMin > 0 Then
               If (giacenza - quantit‡) < scortaMin Then
                  ' Messaggio sottoscorta.
                  MessageBox.Show("L'articolo o l'ingrediente selezionato risulter‡ essere sottoscorta!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               End If
               Return (giacenza - quantit‡)

            ElseIf scortaMin = 0 Then
               If quantit‡ = giacenza Then
                  ' Messaggio giacenza pari a zero.
                  MessageBox.Show("L'articolo o l'ingrediente selezionato risulter‡ essere con giacenza pari a zero!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return 0

               ElseIf quantit‡ > giacenza Then
                  ' Messaggio quantit‡ maggiore della giacenza.
                  MessageBox.Show("Si sta scaricando una quantit‡ maggiore della giacenza! " & _
                                  "La quantit‡ presente in giacenza assumer‡ un valore negativo.", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return (giacenza - quantit‡)
               Else
                  Return (giacenza - quantit‡)
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Function CalcolaCarico(ByVal carico As Double, ByVal nuovoCarico As Double) As Double
      Try
         Return (carico + nuovoCarico)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Function CalcolaScarico(ByVal scarico As Double, ByVal nuovoScarico As Double) As Double
      Try
         Return (scarico + nuovoScarico)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub cmdSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      Try
         Dim nuovaGiacenza As Double = CalcolaGiacenza(giacenzaAttuale, scortaMinima, CDbl(txtQuantit‡.Text), Me.Text)
         Dim Carico As Double = 0
         Dim Scarico As Double = 0
         Dim situazioneScorta As Double = 0
         Dim valCarico As Double = 0
         Dim valScarico As Double = 0
         Dim valAttuale As Double = 0

         If Me.Text = "Carico" Then
            Carico = CalcolaCarico(caricoAttuale, CDbl(txtQuantit‡.Text))
            Scarico = scaricoAttuale
         ElseIf Me.Text = "Scarico" Then
            Scarico = CalcolaScarico(scaricoAttuale, CDbl(txtQuantit‡.Text))
            Carico = caricoAttuale
         End If

         If scortaMinima > 0 Then
            situazioneScorta = (nuovaGiacenza - scortaMinima)
         Else
            situazioneScorta = 0
         End If

         ' Calcola i progressivi.
         If txtPrezzo.Text <> "" Then
            If IsNumeric(txtPrezzo.Text) = True Then
               If Carico <> 0 Then
                  valCarico = CFormatta.FormattaEuro(CalcolaValore(CDec(txtPrezzo.Text), Carico))
               Else
                  valCarico = 0
               End If

               If Scarico <> 0 Then
                  valScarico = CFormatta.FormattaEuro(CalcolaValore(CDec(txtPrezzo.Text), Scarico))
               Else
                  valScarico = 0
               End If

               If nuovaGiacenza <> 0 Then
                  valAttuale = CFormatta.FormattaEuro(CalcolaValore(CDec(txtPrezzo.Text), nuovaGiacenza))
               Else
                  valAttuale = 0
               End If
            Else
               valCarico = 0
               valScarico = 0
               valAttuale = 0
            End If
         Else
            valCarico = 0
            valScarico = 0
            valAttuale = 0
         End If

         ' Aggiorna i dati della tabella Articoli.
         SalvaDati("Articoli", idArticolo, nuovaGiacenza, _
                    Carico, Scarico, situazioneScorta, txtPrezzo.Text, _
                    valCarico, valScarico, valAttuale)

         ' Verifica se Ë un carico o scarico.
         Dim qt‡Caricata As Double = 0
         Dim qt‡Scaricata As Double = 0
         If Me.Text = "Carico" Then
            qt‡Caricata = CDbl(txtQuantit‡.Text)
            qt‡Scaricata = 0
         ElseIf Me.Text = "Scarico" Then
            qt‡Scaricata = CDbl(txtQuantit‡.Text)
            qt‡Caricata = 0
         End If

         Dim data As Date = dtpData.Text

         ' Salva i dati per i movimenti di magazzino.
         SalvaMovimentiMag("MovMagazzino", idArticolo, data.ToShortDateString, codArticolo, descrArticolo, _
                            qt‡Caricata, qt‡Scaricata, txtCausale.Text, txtPrezzo.Text, _
                            fornArticolo, magArticolo)
         Me.Close()

         If IsNothing(g_frmArticoli) = False Then
            ' Aggiorna la griglia dati.
            g_frmArticoli.AggiornaDati()
         End If

         If IsNothing(g_frmScorte) = False Then
            ' Aggiorna la griglia dati.
            g_frmScorte.AggiornaDati()
         End If

         If IsNothing(g_frmInventario) = False Then
            ' Aggiorna la griglia dati.
            g_frmInventario.AggiornaDati()
         End If

         If IsNothing(g_frmMovMag) = False Then
            ' Aggiorna la griglia dati.
            g_frmMovMag.AggiornaDati()
         End If

         Dim strDescrizione As String

         If Me.Text = "Carico" Then
            strDescrizione = "(" & codArticolo & " - " & descrArticolo & " - Qt‡: " & CFormatta.FormattaNumeroDouble(qt‡Caricata) & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Carico, strDescrizione, strModulo)

         ElseIf Me.Text = "Scarico" Then
            strDescrizione = "(" & codArticolo & " - " & descrArticolo & " - Qt‡: " & CFormatta.FormattaNumeroDouble(qt‡Scaricata) & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Scarico, strDescrizione, strModulo)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      Try
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub CaricoScarico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         If Me.Text = "Scarico" Then
            lblPrezzo.Visible = False
            txtPrezzo.Visible = False
            lblFornitore.Visible = False
            cmbFornitore.Visible = False
         Else
            CaricaListaFornitori(cmbFornitore, "Fornitori")
         End If

         dtpData.Text = Today

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtPrezzo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrezzo.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtQuantit‡_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantit‡.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtPrezzo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzo.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtQuantit‡_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantit‡.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub
End Class
