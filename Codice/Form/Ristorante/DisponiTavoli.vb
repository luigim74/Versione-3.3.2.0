' ATTENZIONE! IL FORM NON è PIU' UTILIZZATO.

#Region "Importazioni"

Imports System.IO
Imports System.Data.OleDb

#End Region

Public Class frmDisponiTavoli
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()

      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Me.Text = "Disponi tavoli - " & sala

      'cmdTavolo.Text = nome

      'infoNuovaRisorsa = "Posti: " & posti & vbCrLf & _
      '"Cameriere: " & cameriere & vbCrLf & _
      '"Listino: " & listino & vbCrLf & _
      '"Note: " & note

      'LARGHEZZA_RISORSA = larghezza
      'ALTEZZA_RISORSA = altezza

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
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents picImmagine As System.Windows.Forms.PictureBox
   Friend WithEvents cmdOk As System.Windows.Forms.Button
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents cmbSala As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisponiTavoli))
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.picImmagine = New System.Windows.Forms.PictureBox()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.cmbSala = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.White
      Me.Panel1.Controls.Add(Me.picImmagine)
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(696, 672)
      Me.Panel1.TabIndex = 0
      '
      'picImmagine
      '
      Me.picImmagine.BackColor = System.Drawing.Color.White
      Me.picImmagine.Location = New System.Drawing.Point(8, 10)
      Me.picImmagine.Name = "picImmagine"
      Me.picImmagine.Size = New System.Drawing.Size(680, 650)
      Me.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picImmagine.TabIndex = 227
      Me.picImmagine.TabStop = False
      '
      'cmdOk
      '
      Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOk.Location = New System.Drawing.Point(712, 624)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(104, 32)
      Me.cmdOk.TabIndex = 0
      Me.cmdOk.Text = "&OK"
      '
      'cmbSala
      '
      Me.cmbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSala.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbSala.Location = New System.Drawing.Point(712, 32)
      Me.cmbSala.Name = "cmbSala"
      Me.cmbSala.Size = New System.Drawing.Size(104, 21)
      Me.cmbSala.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(712, 16)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 206
      Me.Label2.Text = "Sala:"
      '
      'frmDisponiTavoli
      '
      Me.AcceptButton = Me.cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.Color.Gray
      Me.ClientSize = New System.Drawing.Size(829, 672)
      Me.Controls.Add(Me.cmbSala)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cmdOk)
      Me.Controls.Add(Me.Panel1)
      Me.ForeColor = System.Drawing.SystemColors.Desktop
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MinimizeBox = False
      Me.Name = "frmDisponiTavoli"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Disponi tavoli - Sala A"
      Me.Panel1.ResumeLayout(False)
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni"

   Const START_POS_X As Integer = 0
   Const START_POS_Y As Integer = 0
   Const LARGHEZZA As Integer = 48
   Const ALTEZZA As Integer = 48
   Const NUM_MAX_RISORSE As Integer = 100

   Const ANAG_TAVOLI As String = "Tavoli"
   Const TAB_SALE As String = "Sale"

   Public LARGHEZZA_RISORSA As Integer = LARGHEZZA
   Public ALTEZZA_RISORSA As Integer = ALTEZZA

   Public Risorsa() As Button
   Public NumRisorse As Short = 0

   Public infoNuovaRisorsa As String = ""

   Dim cursorOffset As Point

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

#End Region

#Region "Procedure"

   Public Sub ImpostaFunzioniOperatore(ByVal wnd As String)
      Try
         Select Case wnd
            Case Finestra.DisponiTavoli
               If operatore.StruDispTavoli = VALORE_LETTURA Then
                  Panel1.Enabled = False
               Else
                  Panel1.Enabled = True
               End If

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaRisorse(ByVal nome As String, ByVal note As String, ByVal id As Integer, ByVal posX As Integer, ByVal posY As Integer)
      Try
         NumRisorse += 1

         Risorsa(NumRisorse) = New Button
         Risorsa(NumRisorse).Name = id.ToString
         Risorsa(NumRisorse).Tag = nome
         Risorsa(NumRisorse).Location = New Point(posX, posY)
         Risorsa(NumRisorse).Size = New Size(LARGHEZZA_RISORSA, ALTEZZA_RISORSA)
         Risorsa(NumRisorse).FlatStyle = FlatStyle.Popup
         Risorsa(NumRisorse).BackColor = Color.DimGray
         Risorsa(NumRisorse).ForeColor = Color.White
         Risorsa(NumRisorse).Text = nome & vbCrLf & _
                                    "X: " & CStr(Risorsa(NumRisorse).Location.X) & vbCrLf & _
                                    "Y: " & CStr(Risorsa(NumRisorse).Location.Y)
         If note = "" Then
            ToolTip1.SetToolTip(Risorsa(NumRisorse), "Nessuna nota.")
         Else
            ToolTip1.SetToolTip(Risorsa(NumRisorse), note)
         End If

         Panel1.Controls.Add(Risorsa(NumRisorse))

         Risorsa(NumRisorse).BringToFront()

         AddHandler Risorsa(NumRisorse).MouseMove, AddressOf Risorsa_MouseMove
         AddHandler Risorsa(NumRisorse).MouseUp, AddressOf Risorsa_MouseUp
         AddHandler Risorsa(NumRisorse).MouseDown, AddressOf Risorsa_MouseDown

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub LeggiDatiRisorse(ByVal tabella As String, ByVal val As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim infoRisorse As String = ""

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Sala = '" & val & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            infoRisorse = "Posti: " & dr.Item("Posti") & vbCrLf & _
                          "Cameriere: " & dr.Item("Cameriere") & vbCrLf & _
                          "Listino: " & dr.Item("Listino") & vbCrLf & _
                          "Note: " & dr.Item("Note")

            ImpostaDimensioniTavolo(dr.Item("Posti"), dr.Item("orientamento"))

            DisegnaRisorse(dr.Item("Descrizione"), infoRisorse, dr.Item("Id"), dr.Item("PosX"), dr.Item("PosY"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub SalvaDatiRisorse(ByVal tabella As String, ByVal id As String, ByVal posX As Integer, ByVal posY As Integer)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET PosX = '{1}', " & _
                             "PosY = '{2}' " & _
                             "WHERE Id = {3}", _
                             tabella, _
                             posX, _
                             posY, _
                             id)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Public Sub CaricaImgSala(ByVal tabella As String, ByVal val As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & val & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            Dim imgSfondo As String = dr.Item("Sfondo")

            If File.Exists(imgSfondo) = True Then
               Dim bmp As New Bitmap(imgSfondo)
               picImmagine.Image = bmp
            Else
               picImmagine.Image = Nothing
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ImpostaDimensioniTavolo(ByVal posti As String, ByVal orientamento As String)
      Try
         Dim numPosti As Integer = CInt(posti)

         ' Tavolo standard.
         If numPosti < 5 Then
            LARGHEZZA_RISORSA = LARGHEZZA
            ALTEZZA_RISORSA = ALTEZZA

            ' Tavolo più grande di 4 posti.
         ElseIf numPosti > 4 Then
            Dim menoQuattro As Integer = (numPosti - 4)
            Dim restoPosti As Integer = 0

            ' Se è dispari lo fa diventare pari.
            If (menoQuattro Mod 2) <> 0 Then
               restoPosti = menoQuattro + 1
            Else
               restoPosti = menoQuattro
            End If

            ' Posti da aggiungere.
            Dim postiDaAgg As Integer = ((restoPosti / 2) + 1)

            Select Case orientamento
               Case "Orizzontale"
                  If postiDaAgg <> 0 Then
                     LARGHEZZA_RISORSA = (postiDaAgg * LARGHEZZA)
                     ALTEZZA_RISORSA = ALTEZZA
                  End If

               Case "Verticale"
                  If postiDaAgg <> 0 Then
                     ALTEZZA_RISORSA = (postiDaAgg * ALTEZZA)
                     LARGHEZZA_RISORSA = LARGHEZZA
                  End If
            End Select

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaPosTavoli()
      Try
         Dim i As Integer = 0
         For i = 0 To Panel1.Controls.Count - 1
            If Panel1.Controls.Contains(Risorsa(i)) = True Then
               SalvaDatiRisorse(ANAG_TAVOLI, Risorsa(i).Name, Risorsa(i).Location.X, Risorsa(i).Location.Y)
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RimuoviTavoli()
      Dim i As Integer = 0
      For i = 0 To Panel1.Controls.Count - 1
         If Panel1.Controls.Contains(Risorsa(i)) = True Then
            Panel1.Controls.Remove(Risorsa(i))
         End If
      Next
   End Sub

#End Region

#Region "Eventi"

   Private Sub DisponiTavoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ImpostaFunzioniOperatore(Finestra.DisponiTavoli)

      If LeggiNumRecord(ANAG_TAVOLI, cn, cmd) <> 0 Then
         ReDim Risorsa(LeggiNumRecord(ANAG_TAVOLI, cn, cmd))

         CaricaLista(cmbSala, TAB_SALE)

         cmbSala.SelectedIndex = 0
      End If

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_DISPONI_TAVOLI, MODULO_STRUMENTI_DISPONI_TAVOLI)

   End Sub

   Private Sub frmDisponiTavoli_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_STRUMENTI_DISPONI_TAVOLI, MODULO_STRUMENTI_DISPONI_TAVOLI)

   End Sub

   Private Sub Risorsa_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      MuoviControllo(sender, Panel1, sender.Tag, e, cursorOffset, Me)

   End Sub

   Private Sub Risorsa_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      ' Posiziona il cursore al centro del controllo.
      'Cursor.Position = sender.PointToScreen(New Point(CInt(sender.Width / 2), CInt(sender.Height / 2)))

      ' Posiziona il cursore nell'angolo superiore sinistro.
      'Cursor.Position = sender.PointToScreen(New Point(0, 0))

      cursorOffset = e.Location
   End Sub

   Private Sub Risorsa_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      ' free the mouse cursor
      Cursor.Clip = Nothing

   End Sub

   Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      If LeggiNumRecord(ANAG_TAVOLI, cn, cmd) <> 0 Then
         SalvaPosTavoli()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Salva, "(Disposizione dei tavoli)", MODULO_STRUMENTI_DISPONI_TAVOLI)
      End If

      Me.Close()
   End Sub

   Private Sub cmbSala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSala.SelectedIndexChanged
      SalvaPosTavoli()

      RimuoviTavoli()

      CaricaImgSala(TAB_SALE, sender.Text)

      NumRisorse = 0

      LeggiDatiRisorse(ANAG_TAVOLI, sender.Text)
   End Sub

#End Region

End Class
