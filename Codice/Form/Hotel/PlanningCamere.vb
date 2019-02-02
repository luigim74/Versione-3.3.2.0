#Region " DATI FILE.VB "

' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       05/08/2016
' Data ultima modifica: 01/10/2018
' Descrizione:          Planning prenotazioni Camere.
' Note:

' Elenco Attivita: 

' ******************************************************************

#End Region

Imports Softgroup.NetButton

Public Class PlanningCamere

   Const NOME_TABELLA As String = "Camere"
   Const TAB_PRENOTAZIONI As String = "PrenCamere"
   Const TAB_STORICO_PRESENZE_ISTAT As String = "StoricoPresenzeIstat"
   Const TAB_STORICO_PRESENZE_ISTAT_C59 As String = "StoricoPresenzeIstatC59"

   Const ALTEZZA_PRENOTAZIONE As Short = 30
   Public Const ALTEZZA_CELLA As Short = 32
   Public Const LARGHEZZA_CELLA As Short = 40
   Const LARGHEZZA_GRIGLIA_CAMERE As Short = 336
   Const LARGHEZZA_GRIGLIA_PRENOTAZIONI As Short = 14601

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Private tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Public Prenotazioni() As NetButton
   Public NumPren As Short = 0
   Public ControlIndex As Integer = 0

   Dim valHBar As Integer
   Dim valVBar As Integer

   ' Numero totale di camere.
   Dim numCamere As Integer

   ' Identifica che il form è stato caricato.
   Dim frmLoad As Boolean = False
   Dim procChiamanteData As Boolean = False
   Dim procChiamanteCamere As Boolean = False
   Dim procChiamantePrenotazioni As Boolean = False

   Private CFormatta As New ClsFormatta

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

      ' Ridimensiona la variabile Prenotazioni con il numero di prenotazioni esistenti.
      ReDim Prenotazioni(LeggiNumRecord(TAB_PRENOTAZIONI, cn, cmd) + 100)

   End Sub

#End Region

   Private Sub PlanningCamere_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
#Region "Planning Camere "
      ' Visualizza i comandi sul Ribbon per il Planning Camere.
      g_frmMain.rtgPlanningCamere.Visible = True

#End Region

   End Sub

   Private Sub PlanningCamere_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
#Region "Planning Camere "
      ' Nasconde i comandi sul Ribbon per il Planning Camere.
      g_frmMain.rtgPlanningCamere.Visible = False

#End Region

   End Sub

   Private Sub PlanningCamere_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica le camere prelevando i dati dal database.
         numCamere = CaricaCamere()

         ' Carica il calendario per l'anno corrente.
         CaricaCalendario(Now.Year)
         CaricaRighePrenotazioni()

         ' Imposta la data selezionata sulla griglia.
         dtpCalendario.Value = Today
         dtpDataPlanning.Value = Today

         ' Legge le prenotazioni salvate.
         LeggiDatiPrenotazioni(TAB_PRENOTAZIONI)

         ' Attiva Nuova e disattiva Modifica ed Elimina.
         AttivaComandoRibbonNuova()

         ' Il form è stato caricato. 
         ' Serve a non generare un errore in dgvCamere_CurrentCellChanged.
         frmLoad = True

         ' Ridimensiona la finestra per forzare la visualizzazione corretta della barra di scorrimento verticale.
         Me.Size = New Size(Me.Width, Me.Height + 1)

         ' Evidenzia il cursore sul Planning.
         dgvPrenotazioni.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub PlanningCamere_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
      g_frmMain.RimuoviFormMenuSeleziona(g_frmPlanningCamere)

      ' Distrugge l'oggetto e libera le risorse.
      g_frmPlanningCamere.Dispose()
      g_frmPlanningCamere = Nothing

   End Sub

   Private Sub HorizontalScrollBar1_ValueChanged(sender As System.Object, e As Elegant.Ui.ScrollBarValueChangedEventArgs) Handles HorizontalScrollBar1.ValueChanged
      valHBar = HorizontalScrollBar1.Value - e.OldValue

      pnlPrenotazioni.Location = New Point(pnlPrenotazioni.Location.X - valHBar, pnlPrenotazioni.Location.Y)
      dgvMesi.Location = New Point(dgvMesi.Location.X - valHBar, dgvMesi.Location.Y)
      dgvGiorni.Location = New Point(dgvGiorni.Location.X - valHBar, dgvGiorni.Location.Y)

   End Sub

   Private Sub VerticalScrollBar1_ValueChanged(sender As System.Object, e As Elegant.Ui.ScrollBarValueChangedEventArgs) Handles VerticalScrollBar1.ValueChanged
      valVBar = VerticalScrollBar1.Value - e.OldValue

      pnlPrenotazioni.Location = New Point(pnlPrenotazioni.Location.X, pnlPrenotazioni.Location.Y - valVBar)
      dgvCamere.Location = New Point(dgvCamere.Location.X, dgvCamere.Location.Y - valVBar)

   End Sub

   Private Sub dgvCamere_MouseWheel(sender As Object, e As MouseEventArgs) Handles dgvCamere.MouseWheel
      Try
         If e.Delta.ToString.Contains("-") = True Then
            If VerticalScrollBar1.Value < (VerticalScrollBar1.Maximum - 300) Then
               VerticalScrollBar1.Value += ALTEZZA_CELLA
            End If
         Else
            VerticalScrollBar1.Value -= ALTEZZA_CELLA
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub pnlPrenotazioni_MouseWheel(sender As Object, e As MouseEventArgs) Handles pnlPrenotazioni.MouseWheel
      Try
         If e.Delta.ToString.Contains("-") = True Then
            If VerticalScrollBar1.Value < (VerticalScrollBar1.Maximum - 300) Then
               VerticalScrollBar1.Value += ALTEZZA_CELLA
            End If
         Else
            VerticalScrollBar1.Value -= ALTEZZA_CELLA
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub PlanningCamere_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
      Try
         HorizontalScrollBar1.Maximum = 15800 - HorizontalScrollBar1.Width
         HorizontalScrollBar1.Minimum = 0

         VerticalScrollBar1.Maximum = ((ALTEZZA_CELLA * numCamere) + 310) - VerticalScrollBar1.Height
         VerticalScrollBar1.Minimum = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub dgvPrenotazioni_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrenotazioni.CellClick
      ' B_TODO: NON UTILIZZATA!

      'Dim posCellaX As Integer = e.ColumnIndex
      'Dim posCellaY As Integer = e.RowIndex

      'Dim nomeGiorno As String

      'Dim strGiorno As String = dgvGiorni.Columns(e.ColumnIndex).HeaderText.Substring(0, 2)

      'Select Case strGiorno
      '   Case "Lun"
      '      nomeGiorno = "Lunedì"
      '   Case "Mar"
      '      nomeGiorno = "Martedì"

      '   Case "Mer"
      '      nomeGiorno = "Mercoledì"

      '   Case "Gio"
      '      nomeGiorno = "Giovedì"

      '   Case "Ven"
      '      nomeGiorno = "Venerdì"

      '   Case "Sab"
      '      nomeGiorno = "Sabato"

      '   Case "Dom"
      '      nomeGiorno = "Domenica"

      'End Select

      'Label1.Text = nomeGiorno & " " & dgvGiorni.Columns(e.ColumnIndex).HeaderText.Remove(3) & " "

   End Sub

   Private Function CaricaCamere() As Integer
      Try
         ' Aggiunge le colonne.
         dgvCamere.Columns.Add("Numero", "Numero")
         dgvCamere.Columns("Numero").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

         dgvCamere.Columns.Add("PostiLetto", "Posti letto")
         dgvCamere.Columns("PostiLetto").DefaultCellStyle.BackColor = Color.LimeGreen
         dgvCamere.Columns("PostiLetto").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
         dgvCamere.Columns("PostiLetto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         dgvCamere.Columns.Add("Ubicazione", "Ubicazione")
         dgvCamere.Columns("Ubicazione").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

         dgvCamere.Columns.Add("Descrizione", "Descrizione")
         dgvCamere.Columns("Descrizione").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         dgvCamere.Columns.Add("Posizione", "Posizione")
         dgvCamere.Columns("Posizione").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

         dgvCamere.Columns.Add("Tipologia", "Tipologia")
         dgvCamere.Columns("Tipologia").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

         dgvCamere.Columns.Remove(ColonnaCamere)

         ' Legge i dati delle camere e li carica nella griglia dati.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & NOME_TABELLA & " WHERE Escludi = 'No' ORDER BY Numero ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         ' Traforma l'ultima riga già esistente in una barra.
         dgvCamere.Rows(0).Height = 0
         dgvCamere.Rows(0).DefaultCellStyle.BackColor = Color.DarkGray

         Dim i As Integer = 0
         Do While dr.Read()

            dgvCamere.Rows.Add()
            dgvCamere.Rows(i).Height = ALTEZZA_CELLA

            ' Numero.
            If IsDBNull(dr.Item("Numero")) = False Then
               dgvCamere.Rows(i).Cells("Numero").Value = dr.Item("Numero")
            Else
               dgvCamere.Rows(i).Cells("Numero").Value = String.Empty
            End If
            ' Posti letto.
            If IsDBNull(dr.Item("PostiLetto")) = False Then
               dgvCamere.Rows(i).Cells("PostiLetto").Value = dr.Item("PostiLetto")

               ' Verifica se la camera è occupata o libera e gli assegna il colore appropriato.
               If VerificaStatoCamera(dr.Item("Numero").ToString) = True Then
                  dgvCamere.Rows(i).Cells("PostiLetto").Style.BackColor = Color.Red
                  dgvCamere.Rows(i).Cells("PostiLetto").Style.ForeColor = Color.Black
                  dgvCamere.Rows(i).Cells("PostiLetto").ToolTipText = "Occupata"
               Else
                  dgvCamere.Rows(i).Cells("PostiLetto").Style.BackColor = Color.LimeGreen
                  dgvCamere.Rows(i).Cells("PostiLetto").Style.ForeColor = Color.Black
                  dgvCamere.Rows(i).Cells("PostiLetto").ToolTipText = "Libera"
               End If
            Else
               dgvCamere.Rows(i).Cells("PostiLetto").Value = String.Empty
               dgvCamere.Rows(i).Cells("PostiLetto").ToolTipText = String.Empty
            End If

            ' Ubicazione.
            If IsDBNull(dr.Item("Ubicazione")) = False Then
               dgvCamere.Rows(i).Cells("Ubicazione").Value = dr.Item("Ubicazione")
            Else
               dgvCamere.Rows(i).Cells("Ubicazione").Value = String.Empty
            End If
            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               dgvCamere.Rows(i).Cells("Descrizione").Value = dr.Item("Descrizione")
            Else
               dgvCamere.Rows(i).Cells("Descrizione").Value = String.Empty
            End If
            ' Posizione.
            If IsDBNull(dr.Item("Posizione")) = False Then
               dgvCamere.Rows(i).Cells("Posizione").Value = dr.Item("Posizione")
            Else
               dgvCamere.Rows(i).Cells("Posizione").Value = String.Empty
            End If
            ' Tipologia.
            If IsDBNull(dr.Item("Tipologia")) = False Then
               dgvCamere.Rows(i).Cells("Tipologia").Value = dr.Item("Tipologia")
            Else
               dgvCamere.Rows(i).Cells("Tipologia").Value = String.Empty
            End If
            ' Disponibile.
            If IsDBNull(dr.Item("Disponibile")) = False Then
               If dr.Item("Disponibile") = "No" Then
                  dgvCamere.Rows(i).Cells("PostiLetto").Style.BackColor = Color.Black
                  dgvCamere.Rows(i).Cells("PostiLetto").Style.ForeColor = Color.White
                  dgvCamere.Rows(i).Cells("PostiLetto").ToolTipText = "Non disponibile"
               End If
            Else
               dgvCamere.Rows(i).Cells("PostiLetto").ToolTipText = String.Empty
            End If
            ' Colore.
            If IsDBNull(dr.Item("Colore")) = False Then
               dgvCamere.Rows(i).Cells("Descrizione").Style.BackColor = Color.FromArgb(Convert.ToInt32(dr.Item("Colore")))
            Else
               dgvCamere.Rows(i).Cells("Descrizione").Style.BackColor = Color.White
            End If
            ' Note.
            If IsDBNull(dr.Item("Note")) = False Then
               dgvCamere.Rows(i).Cells("Descrizione").ToolTipText = dr.Item("Note")
            Else
               dgvCamere.Rows(i).Cells("Descrizione").ToolTipText = String.Empty
            End If

            i += 1
         Loop

         ' Imposta la dimensione della griglia.
         dgvCamere.Size = New Size(LARGHEZZA_GRIGLIA_CAMERE, (ALTEZZA_CELLA * i) + ALTEZZA_CELLA)

         ' Numero camere trovate nel database.
         Return i

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub CaricaCalendario(ByVal anno As Integer)
      Dim NumGiorno As Integer
      Dim GiornoSett As String
      Dim DataAttuale As String
      Dim NumGiorniMese As Integer
      Dim NumMese As Integer
      Dim Mese As String
      Dim NuovoMese As Boolean
      Dim toolTipGiornoSett As String

      Try
         dtpCalendario.Value = Convert.ToDateTime("1/1/" & anno)

         dgvMesi.Columns.Clear()
         dgvGiorni.Columns.Clear()
         dgvPrenotazioni.Columns.Clear()

         Dim x As Integer
         For x = 1 To 365

            GiornoSett = dtpCalendario.Value.DayOfWeek.ToString
            NumGiorno = dtpCalendario.Value.Day
            Mese = dtpCalendario.Value.Month.ToString
            NumGiorniMese = dtpCalendario.Value.DaysInMonth(dtpCalendario.Value.Year, dtpCalendario.Value.Month)

            Select Case Mese
               Case "1"
                  Mese = "G e n n a i o"
               Case "2"
                  Mese = "F e b b r a i o"
               Case "3"
                  Mese = "M a r z o"
               Case "4"
                  Mese = "A p r i l e"
               Case "5"
                  Mese = "M a g g i o"
               Case "6"
                  Mese = "G i u g n o"
               Case "7"
                  Mese = "L u g l i o"
               Case "8"
                  Mese = "A g o s t o"
               Case "9"
                  Mese = "S e t t e m b r e"
               Case "10"
                  Mese = "O t t o b r e"
               Case "11"
                  Mese = "N o v e m b r e"
               Case "12"
                  Mese = "D i c e m b r e"
            End Select

            ' Mese.
            If NumGiorno = NumGiorniMese Then
               Mese = Mese & "  " & dtpCalendario.Value.Year.ToString
               dgvMesi.Columns.Add(Mese, Mese)
               dgvMesi.Columns(Mese).Width = NumGiorniMese * LARGHEZZA_CELLA
            End If

            Select Case GiornoSett
               Case "Monday"
                  GiornoSett = "Lun"
                  toolTipGiornoSett = "Lunedì"
               Case "Tuesday"
                  GiornoSett = "Mar"
                  toolTipGiornoSett = "Martedì"
               Case "Wednesday"
                  GiornoSett = "Mer"
                  toolTipGiornoSett = "Mercoledì"
               Case "Thursday"
                  GiornoSett = "Gio"
                  toolTipGiornoSett = "Giovedì"
               Case "Friday"
                  GiornoSett = "Ven"
                  toolTipGiornoSett = "Venerdì"
               Case "Saturday"
                  GiornoSett = "Sab"
                  toolTipGiornoSett = "Sabato"
               Case "Sunday"
                  GiornoSett = "Dom"
                  toolTipGiornoSett = "Domenica"
            End Select

            ' Giorno e Numero della settimana.
            dgvGiorni.Columns.Add(x.ToString, x.ToString)
            dgvGiorni.Columns(x.ToString).Width = LARGHEZZA_CELLA
            dgvGiorni.Columns(x.ToString).HeaderText = GiornoSett & " " & NumGiorno
            dgvGiorni.Columns(x.ToString).ToolTipText = toolTipGiornoSett & " " & NumGiorno & " " & Mese.Replace(" ", "") & " " & dtpCalendario.Value.Year.ToString

            ' Colonne prenotazioni.
            Dim nomeColonna As String = FormattaData(dtpCalendario.Value.Day.ToString & "/" & dtpCalendario.Value.Month.ToString & "/" & dtpCalendario.Value.Year.ToString, True)

            dgvPrenotazioni.Columns.Add(nomeColonna, x.ToString)
            dgvPrenotazioni.Columns(nomeColonna).Width = LARGHEZZA_CELLA

            Select Case GiornoSett
               '  ' DA_FARE: Aggiungere tutti i giorni della settimana.

               Case "Sab"
                  ' dgvGiorni.Columns(x.ToString).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                  ' dgvGiorni.Columns(x.ToString).HeaderCell.Style.ForeColor = Color.LightCoral

                  dgvGiorni.Columns(x.ToString).HeaderCell.Style.BackColor = Color.Gainsboro ' Color.Pink
                  dgvPrenotazioni.Columns(nomeColonna).DefaultCellStyle.BackColor = Color.Gainsboro ' Color.Pink

               Case "Dom"
                  ' dgvGiorni.Columns(x.ToString).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                  ' dgvGiorni.Columns(x.ToString).HeaderCell.Style.ForeColor = Color.LightCoral

                  dgvGiorni.Columns(x.ToString).HeaderCell.Style.BackColor = Color.LightGray ' Color.PaleVioletRed
                  dgvPrenotazioni.Columns(nomeColonna).DefaultCellStyle.BackColor = Color.LightGray ' Color.PaleVioletRed

            End Select

            ' Giorno corrente.
            If dtpCalendario.Value = Now.Today Then
               dgvGiorni.Columns(x.ToString).HeaderCell.Style.BackColor = Color.Orange
               dgvPrenotazioni.Columns(nomeColonna).DefaultCellStyle.BackColor = Color.Orange
               HorizontalScrollBar1.Value = (x * LARGHEZZA_CELLA) - (NumGiorno * LARGHEZZA_CELLA)
            End If

            dtpCalendario.Value = dtpCalendario.Value.AddDays(1)
         Next

         ' Imposta le dimenioni delle griglie.
         dgvMesi.Size = New Size(14680, LARGHEZZA_CELLA)
         dgvGiorni.Size = New Size(14680, LARGHEZZA_CELLA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaRighePrenotazioni()
      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         '  Leggo tutte le prenotazioni della camera.
         Dim cmd As New OleDbCommand("SELECT * FROM " & NOME_TABELLA & " WHERE Escludi = 'No' ORDER BY Numero ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         ' Traforma l'ultima riga già esistente in una barra.
         dgvPrenotazioni.Rows(0).Height = 0
         dgvPrenotazioni.Rows(0).DefaultCellStyle.BackColor = Color.DarkGray
         dgvPrenotazioni.Rows(0).DefaultCellStyle.SelectionBackColor = Color.DarkGray

         Dim j As Integer = 0
         Do While dr.Read()
            dgvPrenotazioni.Rows.Add()
            dgvPrenotazioni.Rows(j).Height = ALTEZZA_CELLA

            ' Evidenzia.
            Dim evidenzia As String
            If IsDBNull(dr.Item("Evidenzia")) = False Then
               evidenzia = dr.Item("Evidenzia").ToString
            Else
               evidenzia = "No"
            End If

            If evidenzia = "Sì" Then
               dgvPrenotazioni.Rows(j).DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(dr.Item("Colore")))
            End If

            j = j + 1
         Loop

         ' Imposta la dimensione della griglia.
         pnlPrenotazioni.Size = New Size(LARGHEZZA_GRIGLIA_PRENOTAZIONI, (ALTEZZA_CELLA * numCamere) + ALTEZZA_CELLA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Private Function VerificaDisponibilitàCamera(ByVal numeroCamera As String) As Boolean
      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         '  Leggo tutte le prenotazioni della camera.
         Dim cmd As New OleDbCommand("SELECT * FROM Camere WHERE Numero = '" & numeroCamera & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Disponibile.
            Dim disponibile As String
            If IsDBNull(dr.Item("Disponibile")) = False Then
               disponibile = dr.Item("Disponibile").ToString
            Else
               disponibile = "No"
            End If

            If disponibile = "Sì" Then
               Return True
            Else
               Return False
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function VerificaStatoCamera(ByVal numeroCamera As String) As Boolean
      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         '  Leggo tutte le prenotazioni della camera.
         Dim cmd As New OleDbCommand("SELECT * FROM PrenCamere WHERE NumeroCamera = '" & numeroCamera & "' ORDER BY DataArrivo ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Data arrivo.
            Dim valDataArrivo As Date
            If IsDate(dr.Item("DataArrivo")) = True Then
               valDataArrivo = Convert.ToDateTime(dr.Item("DataArrivo"))
            Else
               Return False
            End If

            ' Data partenza.
            Dim valDataPartenza As Date
            If IsDate(dr.Item("DataPartenza")) = True Then
               valDataPartenza = Convert.ToDateTime(dr.Item("DataPartenza"))
            Else
               Return False
            End If

            ' Numero notti.
            Dim valNumNotti As Integer
            If IsDBNull(dr.Item("NumeroNotti")) = False Then
               valNumNotti = Convert.ToInt32(dr.Item("NumeroNotti"))
            Else
               Return False
            End If

            Dim dataDalTemp As Date = Today

            Dim valDatatemp As Date = valDataArrivo
            Dim i As Integer
            For i = 0 To valNumNotti
               If valDatatemp = dataDalTemp Then
                  ' Prenotazione esistente!
                  Return True
               Else
                  ' Incrementa di un giorno.
                  valDatatemp = valDatatemp.AddDays(1)
               End If
            Next
         Loop

         Return False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Sub ApriDatiPrenotazione(ByVal nomeFrm As String, ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_PRENOTAZIONI, cn, cmd)) = True Then
                  Exit Sub
               End If
            End If
         End If

         ' Per le nuove prenotazioni.
         If val = String.Empty Then
            ' Verifica se la camera selezionata è disponibile sul Planning.
            If VerificaDisponibilitàCamera(g_frmPlanningCamere.dgvCamere.Rows(g_frmPlanningCamere.dgvPrenotazioni.CurrentCell.RowIndex).Cells("Numero").Value) = True Then
               g_frmPrenCamera = New frmPrenCamera(nomeFrm)
               g_frmPrenCamera.Tag = val
               g_frmPrenCamera.ShowDialog()
            Else
               ' Visualizza un messaggio.
               MessageBox.Show("La camera selezionata non è disponibile! Non è possibile assegnare prenotazioni a questa camera.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
         Else
            g_frmPrenCamera = New frmPrenCamera(nomeFrm)
            g_frmPrenCamera.Tag = val
            g_frmPrenCamera.ShowDialog()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub DisegnaPrenotazione(ByVal Id As Integer, ByVal numero As String, ByVal numCamera As String, ByVal intestatario As String, ByVal gruppo As String, ByVal persone As Integer, ByVal tipologia As String, ByVal stato As String, ByVal trattamento As String,
                                  ByVal dataArrivo As String, ByVal dataPartenza As String, ByVal numNotti As Integer, ByVal note As String,
                                  ByVal totaleCamera As String, ByVal totaleAddebiti As String, ByVal acconto As String, ByVal totaleConto As String, ByVal colore As Integer)
      Try
         Dim posCellaX As Integer
         Dim posCellaY As Integer
         Dim cordX As Boolean
         Dim cordY As Boolean

         ' Cerca la colonna X dove disegnare la prenotazione.
         Dim x As Integer
         For x = 0 To dgvPrenotazioni.Columns.Count - 1
            If dgvPrenotazioni.Columns(x).Name = dataArrivo Then
               posCellaX = x
               cordX = True
               Exit For
            End If
         Next

         If cordX = False Then
            ' Se non trova la colonna - data di arrivo non disegna la prenotazione.
            Exit Sub
         End If

         ' Cerca la riga Y dove disegnare la prenotazione.
         Dim y As Integer
         For y = 0 To dgvCamere.Rows.Count - 1
            If dgvCamere.Rows(y).Cells("Numero").Value = numCamera Then
               posCellaY = y
               cordY = True
               Exit For
            End If
         Next

         If cordY = False Then
            ' Se non trova la riga - numero camera non disegna la prenotazione.
            Exit Sub
         End If

         Dim larghezzaPren As Integer = numNotti * LARGHEZZA_CELLA

         NumPren += 1
         Prenotazioni(NumPren) = New NetButton
         Prenotazioni(NumPren).Name = Id.ToString
         Prenotazioni(NumPren).Location = New Point((posCellaX * LARGHEZZA_CELLA) + 21, (posCellaY * ALTEZZA_CELLA) + 1)
         Prenotazioni(NumPren).Size = New Point(larghezzaPren, ALTEZZA_PRENOTAZIONE)

         ' Imposta i colori primari.
         Select Case Color.FromArgb(colore)
            Case Color.FromArgb(255, 255, 255) ' Nessuno
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Default

            Case Color.Silver ' Default
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Default

            Case Color.RoyalBlue ' Blue
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Blue

            Case Color.FromArgb(0, 192, 0) ' Green
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Green

            Case Color.Gold ' Yellow
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Yellow

            Case Color.FromArgb(210, 0, 0) ' Red
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Red

            Case Color.DarkMagenta ' Pink
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Pink

            Case Color.DimGray ' Gray
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Gray

            Case Else ' Custom
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Custom
               Prenotazioni(NumPren).ColorBottom = Color.FromArgb(colore)

         End Select

         Prenotazioni(NumPren).TextButtonAlign = ContentAlignment.MiddleLeft

         If gruppo <> String.Empty And gruppo <> Space(1) Then
            Prenotazioni(NumPren).TextButton = intestatario & " [Gruppo " & gruppo & "]"
         Else
            Prenotazioni(NumPren).TextButton = intestatario
         End If

         Prenotazioni(NumPren).CornerRadius = 8
         Prenotazioni(NumPren).Tag = ""

         ' ScreenTip informativa.
         Dim infoPrenotazione As New Elegant.Ui.ScreenTipData(Prenotazioni(NumPren))
         infoPrenotazione.Caption = intestatario & " - N. " & numero
         infoPrenotazione.Text = "Intestatario: " & intestatario & vbCrLf &
                                 "Prenotazione numero: " & numero & vbCrLf &
                                 "Persone: " & persone.ToString & vbCrLf &
                                 "Tipologia: " & tipologia & vbCrLf &
                                 "Stato: " & stato & vbCrLf &
                                 "Trattamento: " & trattamento & vbCrLf &
                                 "Gruppo: " & gruppo & vbCrLf & vbCrLf &
                                 "Arrivo: " & dataArrivo & vbCrLf &
                                 "Partenza: " & dataPartenza & vbCrLf &
                                 "Notti: " & numNotti & vbCrLf & vbCrLf &
                                 "Camera: € " & totaleCamera & vbCrLf &
                                 "Addebiti extra: € " & totaleAddebiti & vbCrLf &
                                 "Acconto: € " & acconto & vbCrLf &
                                 "Totale soggiorno: € " & totaleConto & vbCrLf & vbCrLf &
                                 "Note: " & note

         ' DA_FARE_B: Sviluppare! Aggiungere anche l'elenco dei componenti.

         pnlPrenotazioni.Controls.Add(Prenotazioni(NumPren))

         Prenotazioni(NumPren).BringToFront()

         AddHandler Prenotazioni(NumPren).Click, AddressOf Prenotazioni_Click
         AddHandler Prenotazioni(NumPren).DoubleClick, AddressOf Prenotazioni_DoubleClick
         AddHandler Prenotazioni(NumPren).GotFocus, AddressOf Prenotazioni_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub DisegnaPrenotazioneDueAnni(ByVal Id As Integer, ByVal numero As String, ByVal numCamera As String, ByVal intestatario As String, ByVal gruppo As String, ByVal persone As Integer, ByVal tipologia As String, ByVal stato As String, ByVal trattamento As String,
                                         ByVal dataArrivo As String, ByVal dataPartenza As String, ByVal numNotti As Integer, ByVal note As String,
                                         ByVal totaleCamera As String, ByVal totaleAddebiti As String, ByVal acconto As String, ByVal totaleConto As String, ByVal colore As Integer)
      Try
         Dim posCellaX As Integer
         Dim posCellaY As Integer
         Dim cordX As Boolean
         Dim cordY As Boolean

         ' Cerca la colonna X dove disegnare la prenotazione.
         Dim x As Integer
         For x = 0 To dgvPrenotazioni.Columns.Count - 1
            If dgvPrenotazioni.Columns(x).Name = dataPartenza Then
               posCellaX = x
               cordX = True
               Exit For
            End If
         Next

         If cordX = False Then
            ' Se non trova la colonna - data di arrivo non disegna la prenotazione.
            Exit Sub
         End If

         ' Cerca la riga Y dove disegnare la prenotazione.
         Dim y As Integer
         For y = 0 To dgvCamere.Rows.Count - 1
            If dgvCamere.Rows(y).Cells("Numero").Value = numCamera Then
               posCellaY = y
               cordY = True
               Exit For
            End If
         Next

         If cordY = False Then
            ' Se non trova la riga - numero camera non disegna la prenotazione.
            Exit Sub
         End If

         Dim larghezzaPren As Integer = numNotti * LARGHEZZA_CELLA
         posCellaX = (posCellaX * LARGHEZZA_CELLA) - larghezzaPren

         NumPren += 1
         Prenotazioni(NumPren) = New NetButton
         Prenotazioni(NumPren).Name = Id.ToString
         Prenotazioni(NumPren).Location = New Point((posCellaX) + 21, (posCellaY * ALTEZZA_CELLA) + 1)
         Prenotazioni(NumPren).Size = New Point(larghezzaPren, ALTEZZA_PRENOTAZIONE)

         ' Imposta i colori primari.
         Select Case Color.FromArgb(colore)
            Case Color.FromArgb(255, 255, 255) ' Nessuno
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Default

            Case Color.Silver ' Default
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Default

            Case Color.RoyalBlue ' Blue
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Blue

            Case Color.FromArgb(0, 192, 0) ' Green
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Green

            Case Color.Gold ' Yellow
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Yellow

            Case Color.FromArgb(210, 0, 0) ' Red
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Red

            Case Color.DarkMagenta ' Pink
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Pink

            Case Color.DimGray ' Gray
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Gray

            Case Else ' Custom
               Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Custom
               Prenotazioni(NumPren).ColorBottom = Color.FromArgb(colore)

         End Select

         Prenotazioni(NumPren).TextButtonAlign = ContentAlignment.MiddleRight

         If gruppo <> String.Empty And gruppo <> Space(1) Then
            Prenotazioni(NumPren).TextButton = intestatario & " [Gruppo " & gruppo & "]"
         Else
            Prenotazioni(NumPren).TextButton = intestatario
         End If

         Prenotazioni(NumPren).CornerRadius = 8
         Prenotazioni(NumPren).Tag = ""

         ' ScreenTip informativa.
         Dim infoPrenotazione As New Elegant.Ui.ScreenTipData(Prenotazioni(NumPren))
         infoPrenotazione.Caption = intestatario & " - N. " & numero
         infoPrenotazione.Text = "Intestatario: " & intestatario & vbCrLf &
                                 "Prenotazione numero: " & numero & vbCrLf &
                                 "Persone: " & persone.ToString & vbCrLf &
                                 "Tipologia: " & tipologia & vbCrLf &
                                 "Stato: " & stato & vbCrLf &
                                 "Trattamento: " & trattamento & vbCrLf &
                                 "Gruppo: " & gruppo & vbCrLf & vbCrLf &
                                 "Arrivo: " & dataArrivo & vbCrLf &
                                 "Partenza: " & dataPartenza & vbCrLf &
                                 "Notti: " & numNotti & vbCrLf & vbCrLf &
                                 "Camera: € " & totaleCamera & vbCrLf &
                                 "Addebiti extra: € " & totaleAddebiti & vbCrLf &
                                 "Acconto: € " & acconto & vbCrLf &
                                 "Totale soggiorno: € " & totaleConto & vbCrLf & vbCrLf &
                                 "Note: " & note

         ' DA_FARE_B: Sviluppare! Aggiungere anche l'elenco dei componenti.

         pnlPrenotazioni.Controls.Add(Prenotazioni(NumPren))

         Prenotazioni(NumPren).BringToFront()

         AddHandler Prenotazioni(NumPren).Click, AddressOf Prenotazioni_Click
         AddHandler Prenotazioni(NumPren).DoubleClick, AddressOf Prenotazioni_DoubleClick
         AddHandler Prenotazioni(NumPren).GotFocus, AddressOf Prenotazioni_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   ' DA_FARE: Funzionalità futura.
   Public Sub DisegnaEtichetta()
      Try
         Dim posCellaX As Integer
         Dim posCellaY As Integer
         Dim cordX As Boolean
         Dim cordY As Boolean

         ' Cerca la colonna X dove disegnare la prenotazione.
         'Dim x As Integer
         'For x = 0 To dgvPrenotazioni.Columns.Count - 1
         '   If dgvPrenotazioni.Columns(x).Name = dataArrivo Then
         '      posCellaX = x
         '      cordX = True
         '      Exit For
         '   End If
         'Next

         'If cordX = False Then
         '   ' Se non trova la colonna - data di arrivo non disegna la prenotazione.
         '   Exit Sub
         'End If

         '' Cerca la riga Y dove disegnare la prenotazione.
         'Dim y As Integer
         'For y = 0 To dgvCamere.Rows.Count - 1
         '   If dgvCamere.Rows(y).Cells("Numero").Value = numCamera Then
         '      posCellaY = y
         '      cordY = True
         '      Exit For
         '   End If
         'Next

         'If cordY = False Then
         '   ' Se non trova la riga - numero camera non disegna la prenotazione.
         '   Exit Sub
         'End If

         Dim larghezzaPren As Integer = 160 'numNotti * LARGHEZZA_CELLA

         NumPren += 1
         Prenotazioni(NumPren) = New NetButton
         Prenotazioni(NumPren).Name = 1000 ' Id.ToString
         Prenotazioni(NumPren).Location = New Point((5000) + 21, (2000) + 1)
         Prenotazioni(NumPren).Size = New Point(larghezzaPren, ALTEZZA_PRENOTAZIONE)

         '' Imposta i colori primari.
         'Select Case Color.FromArgb(colore)
         '   Case Color.FromArgb(255, 255, 255) ' Nessuno
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Default

         '   Case Color.Silver ' Default
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Default

         '   Case Color.RoyalBlue ' Blue
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Blue

         '   Case Color.FromArgb(0, 192, 0) ' Green
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Green

         '   Case Color.Gold ' Yellow
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Yellow

         '   Case Color.FromArgb(210, 0, 0) ' Red
         Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Red

         '   Case Color.DarkMagenta ' Pink
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Pink

         '   Case Color.DimGray ' Gray
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Gray

         '   Case Else ' Custom
         '      Prenotazioni(NumPren).ColorStyle = NetButton.ColorStyleEnum.Custom
         '      Prenotazioni(NumPren).ColorBottom = Color.FromArgb(colore)

         'End Select

         Prenotazioni(NumPren).TextButtonAlign = ContentAlignment.MiddleLeft
         Prenotazioni(NumPren).TextButton = "Manutenzione" 'intestatario
         Prenotazioni(NumPren).CornerRadius = 0
         Prenotazioni(NumPren).Tag = ""

         '' ScreenTip informativa.
         'Dim infoPrenotazione As New Elegant.Ui.ScreenTipData(Prenotazioni(NumPren))
         'infoPrenotazione.Caption = intestatario & " - N. " & numero
         'infoPrenotazione.Text = "Intestatario: " & intestatario & vbCrLf &
         '                        "Prenotazione numero: " & numero & vbCrLf &
         '                        "Persone: " & persone.ToString & vbCrLf &
         '                        "Tipologia: " & tipologia & vbCrLf &
         '                        "Stato: " & stato & vbCrLf &
         '                        "Trattamento: " & trattamento & vbCrLf & vbCrLf &
         '                        "Arrivo: " & dataArrivo & vbCrLf &
         '                        "Partenza: " & dataPartenza & vbCrLf &
         '                        "Notti: " & numNotti & vbCrLf & vbCrLf &
         '                        "Camera: € " & totaleCamera & vbCrLf &
         '                        "Addebiti extra: € " & totaleAddebiti & vbCrLf &
         '                        "Acconto: € " & acconto & vbCrLf &
         '                        "Totale soggiorno: € " & totaleConto & vbCrLf & vbCrLf &
         '                        "Note: " & note

         pnlPrenotazioni.Controls.Add(Prenotazioni(NumPren))

         Prenotazioni(NumPren).BringToFront()

         AddHandler Prenotazioni(NumPren).Click, AddressOf Prenotazioni_Click
         AddHandler Prenotazioni(NumPren).DoubleClick, AddressOf Prenotazioni_DoubleClick
         AddHandler Prenotazioni(NumPren).GotFocus, AddressOf Prenotazioni_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Function CalcolaTotaleAddebiti(ByVal rifPren As Integer) As String
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim totAddebiti As Double

         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         Dim cmd As New OleDbCommand("SELECT * FROM PrenCamereAddebiti WHERE RifPren = " & rifPren & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' Calcola il totale.
            Dim importo As Double
            If IsNumeric(dr.Item("Importo")) = True Then
               importo = dr.Item("Importo")
            Else
               importo = 0
            End If

            totAddebiti = totAddebiti + importo
         Loop

         Return CFormatta.FormattaNumeroDouble(totAddebiti)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDatiPrenotazioni(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumeroCamera <> '' ORDER BY DataArrivo ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Calcola il numero di persone totali.
            Dim adulti As Integer = Convert.ToInt32(dr.Item("Adulti"))
            Dim ragazzi As Integer = Convert.ToInt32(dr.Item("Ragazzi"))
            Dim bambini As Integer = Convert.ToInt32(dr.Item("Bambini"))
            Dim neonati As Integer = Convert.ToInt32(dr.Item("Neonati"))
            Dim numPersone As Integer = adulti + ragazzi + bambini + neonati

            ' Calcola il totale del costo della camera.
            Dim costoCamera As Double
            If IsNumeric(dr.Item("CostoCamera")) = True Then
               costoCamera = dr.Item("CostoCamera")
            Else
               costoCamera = 0
            End If

            Dim numNotti As Integer = Convert.ToInt32(dr.Item("NumeroNotti"))
            Dim totCamera As Double = ((costoCamera * adulti) * numNotti)

            ' Prenotazioni nell'anno corrente.
            DisegnaPrenotazione(dr.Item("Id"), dr.Item("Numero"), dr.Item("NumeroCamera"), dr.Item("Cognome") & " " & dr.Item("Nome"), dr.Item("Gruppo").ToString, numPersone, dr.Item("Tipologia"), dr.Item("Stato"), dr.Item("Trattamento"),
                                dr.Item("DataArrivo"), dr.Item("DataPartenza"), dr.Item("NumeroNotti"), dr.Item("Note"),
                                CFormatta.FormattaEuro(totCamera), CalcolaTotaleAddebiti(dr.Item("Id")), CFormatta.FormattaEuro(dr.Item("AccontoCamera")), CFormatta.FormattaEuro(dr.Item("TotaleConto")), dr.Item("Colore"))

            ' Prenotazioni che comprendono due anni diversi.
            If Convert.ToDateTime(dr.Item("DataArrivo")).Year = (dtpDataPlanning.Value.GetValueOrDefault.AddYears(-1).Year) And Convert.ToDateTime(dr.Item("DataPartenza")).Year = dtpDataPlanning.Value.GetValueOrDefault.Year Then

               DisegnaPrenotazioneDueAnni(dr.Item("Id"), dr.Item("Numero"), dr.Item("NumeroCamera"), dr.Item("Cognome") & " " & dr.Item("Nome"), dr.Item("Gruppo").ToString, numPersone, dr.Item("Tipologia"), dr.Item("Stato"), dr.Item("Trattamento"),
                                dr.Item("DataArrivo"), dr.Item("DataPartenza"), dr.Item("NumeroNotti"), dr.Item("Note"),
                                CFormatta.FormattaEuro(totCamera), CalcolaTotaleAddebiti(dr.Item("Id")), CFormatta.FormattaEuro(dr.Item("AccontoCamera")), CFormatta.FormattaEuro(dr.Item("TotaleConto")), dr.Item("Colore"))
            End If
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDescrizionePrenotazione(ByVal idPren As Integer) As String
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM PrenCamere WHERE Id = " & idPren & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim cognome As String
         Dim nome As String
         Dim numero As String
         Dim data As String

         Do While dr.Read()
            cognome = dr.Item("Cognome").ToString
            nome = dr.Item("Nome").ToString
            numero = dr.Item("Numero").ToString
            data = dr.Item("Data").ToString
         Loop

         If nome = String.Empty Then
            Return cognome & " numero " & numero & " del " & data
         Else
            Return cognome & " " & nome & " numero " & numero & " del " & data
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub Prenotazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Modifica la prenotazione selezionata.
         Me.Tag = CType(sender, NetButton).Name

         ' Salva l'indice del controllo selezionato.
         ControlIndex = pnlPrenotazioni.Controls.IndexOf(CType(sender, NetButton))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub Prenotazioni_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Modifica la prenotazione selezionata.
      ApriDatiPrenotazione(Me.Name, CType(sender, NetButton).Name)
   End Sub

   Private Sub Prenotazioni_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
      ' Disattiva Nuova e attiva Modifica ed Elimina.
      DisattivaComandoRibbonNuova()
   End Sub

   Private Sub dgvPrenotazioni_GotFocus(sender As Object, e As EventArgs) Handles dgvPrenotazioni.GotFocus
      ' Attiva Nuova e disattiva Modifica ed Elimina.
      AttivaComandoRibbonNuova()
   End Sub

   Private Sub dgvCamere_GotFocus(sender As Object, e As EventArgs) Handles dgvCamere.GotFocus
      ' Attiva Nuova e disattiva Modifica ed Elimina.
      AttivaComandoRibbonNuova()
   End Sub

   Private Sub dtpDataPlanning_GotFocus(sender As Object, e As EventArgs) Handles dtpDataPlanning.GotFocus
      ' Attiva Nuova e disattiva Modifica ed Elimina.
      AttivaComandoRibbonNuova()
   End Sub

   Public Sub AnteprimaDiStampa(ByVal nomeDoc As String)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella StoricoPresenzeIstatC59.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("Select * FROM " & TAB_STORICO_PRESENZE_ISTAT_C59, cn)
         Dim ds As New IstatDataSet
         ds.Clear()
         oleAdapter.Fill(ds, TAB_STORICO_PRESENZE_ISTAT_C59)

         ' Tabella StoricoPresenzeIstat.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand("Select * FROM " & TAB_STORICO_PRESENZE_ISTAT, cn)
         oleAdapter1.Fill(ds, TAB_STORICO_PRESENZE_ISTAT)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepIstat(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try

   End Sub

   Private Sub RimuoviPrenotazioni()
      Try
         Dim i As Integer = 0
         For i = 0 To pnlPrenotazioni.Controls.Count - 1
            If pnlPrenotazioni.Controls.Contains(Prenotazioni(i)) = True Then
               pnlPrenotazioni.Controls.Remove(Prenotazioni(i))
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaPlanning()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Rimuove tutte le prenotazioni esistenti.
         RimuoviPrenotazioni()

         NumPren = 0
         ' Legge le prenotazioni salvate.
         LeggiDatiPrenotazioni(TAB_PRENOTAZIONI)

         ' Attiva Nuova e disattiva Modifica ed Elimina.
         AttivaComandoRibbonNuova()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Restituisce lo stato attivo alla griglia.
         dgvPrenotazioni.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         ' Registra loperazione effettuata dall'operatore identificato.
         'Dim Descrizione As String = "(Prenotazione N° " & lblDettagliPren.Text & " - " & lblRisorsaOra.Text & ")"

         Dim descrizione As String = LeggiDescrizionePrenotazione(Me.Tag)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare la prenotazione del cliente """ & descrizione & """?" &
                           vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            ' Elimina i dati degli Occupanti per la prenotazione.
            '-------------------------------------------------------------------------------
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM PrenCamereOccupanti WHERE RifPren = {0}", id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
            '-------------------------------------------------------------------------------

            ' Elimina i dati degli Addebiti per la prenotazione.
            '-------------------------------------------------------------------------------
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM PrenCamereAddebiti WHERE RifPren = {0}", id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete2 As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record2 As Integer = cmdDelete2.ExecuteNonQuery()
            '-------------------------------------------------------------------------------

            ' A_TODO: Inserire qui il codice per eliminare anche gli Allegati.

            ' Conferma la transazione.
            tr.Commit()

            ' A_TODO: HOTEL - da modificare!
            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Elimina, Descrizione, MODULO_GESTIONE_PLANNING_RISORSE)
         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         If IsNothing(g_frmPrenCamere) = False Then
            ' Aggiorna la griglia dati.
            g_frmPrenCamere.AggiornaDati()
         End If

      End Try
   End Sub

   Private Sub EliminaControllo(ByVal indice As Integer)
      Try
         ' Elimina il controllo dal planning.
         pnlPrenotazioni.Controls.RemoveAt(indice)

         NumPren -= 1

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AnnullaPrenotazione()
      Try
         ' Chiede conferma per l'annullamento.
         Dim risposta As Integer
         risposta = MessageBox.Show("Si desidera annullare la prenotazione del cliente '" & LeggiDescrizionePrenotazione(Me.Tag) & "? " & vbCrLf & vbCrLf &
                                 "Confermando l'operazione la prenotazione sarà contrassegnata come 'Annullata' e l'assegnazione della Camera sarà eliminata. Procedere?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         If risposta = vbYes Then
            ModificaStatoPren(TAB_PRENOTAZIONI, Me.Tag)
         Else
            Exit Sub
         End If

         ' Aggiorna la griglia dati.
         AggiornaPlanning()

         If IsNothing(g_frmPrenCamere) = False Then
            ' Aggiorna la griglia dati.
            g_frmPrenCamere.AggiornaDati()
         End If

         ' DA_FARE_B: Sviluppare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - € " & CFormatta.FormattaEuro(Importo) & ")"
         'g_frmMain.RegistraOperazione(TipoOperazione.AnnullaDoc, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaComandoRibbonNuova()
      Try
         g_frmMain.eui_PCamere_PrenNuova.Enabled = True
         g_frmMain.eui_PCamere_PrenModifica.Enabled = False
         g_frmMain.eui_PCamere_PrenElimina.Enabled = False
         g_frmMain.eui_PCamere_PrenAnnulla.Enabled = False
         g_frmMain.eui_PCamere_PrenSchedina.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisattivaComandoRibbonNuova()
      Try
         g_frmMain.eui_PCamere_PrenNuova.Enabled = False
         g_frmMain.eui_PCamere_PrenModifica.Enabled = True
         g_frmMain.eui_PCamere_PrenElimina.Enabled = True
         g_frmMain.eui_PCamere_PrenAnnulla.Enabled = True
         g_frmMain.eui_PCamere_PrenSchedina.Enabled = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisattivaTuttiComandiRibbon()
      Try
         g_frmMain.eui_PCamere_PrenNuova.Enabled = False
         g_frmMain.eui_PCamere_PrenModifica.Enabled = False
         g_frmMain.eui_PCamere_PrenElimina.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub EliminaPrenotazione()
      Try
         ' Elimina i dati dall'archivio
         EliminaDati(TAB_PRENOTAZIONI, Me.Tag)

         ' Elimina il controllo dal planning.
         EliminaControllo(ControlIndex)

         ' Aggiorna la griglia del planning.
         AggiornaPlanning()

         ' Attiva Nuova e disattiva Modifica ed Elimina.
         AttivaComandoRibbonNuova()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub SelezionaGiorno()
      Try
         ' Data e ora di arrivo
         dtpDataPlanning.Value = Convert.ToDateTime(dgvPrenotazioni.Columns(dgvPrenotazioni.CurrentCell.ColumnIndex).Name).Date

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaMese()
      ' B_TODO: NON UTILIZZATA!

      'Try
      '   Dim numMeseCorrente As Integer = dtpCalendario.Value.Month
      '   Dim numMeseNuovo As Integer = dtpDataPlanning.Value.GetValueOrDefault.Month

      '   Select Case numMeseNuovo
      '      Case Is = numMeseCorrente
      '         Exit Sub

      '      Case Is > numMeseCorrente
      '         Dim numMesi As Integer = numMeseNuovo - numMeseCorrente

      '         Dim i As Integer
      '         For i = 1 To numMesi
      '            g_frmMain.eui_PCamere_VisMeseAvanti.PerformClick()
      '         Next

      '      Case Is < numMeseCorrente
      '         Dim numMesi As Integer = numMeseCorrente - numMeseNuovo

      '         Dim i As Integer
      '         For i = 1 To numMesi
      '            g_frmMain.eui_PCamere_VisMeseIndietro.PerformClick()
      '         Next

      '   End Select

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Public Sub SelezionaAnno(ByVal avanti As Boolean)
      Try
         Const messaggio As String = "Limite raggiunto! E' possibile scorrere il Planning avanti o indietro di un solo anno rispetto all'anno corrente."
         Dim annoCorrente As Integer = dtpDataPlanning.Value.GetValueOrDefault.Year
         Dim annoNuovo As Integer

         ' Avanti di un Anno.
         If avanti = True Then
            annoNuovo = annoCorrente + 1
            If (annoNuovo - Now.Year) > 1 Then
               ' Raggiunto il limite di un anno disattiva il pulsante sul Ribbon.
               g_frmMain.eui_PCamere_VisAnnoAvanti.Enabled = False

               ' Avvisa del limite raggiunto.
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If
         Else
            ' Indietro di un Anno.
            annoNuovo = annoCorrente - 1
            If (Now.Year - annoNuovo) > 1 Then
               ' Raggiunto il limite di un anno disattiva il pulsante sul Ribbon.
               g_frmMain.eui_PCamere_VisAnnoIndietro.Enabled = False

               ' Avvisa del limite raggiunto.
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If
         End If

         ' Aggiorna il calendario con il nuovo anno.
         If avanti = True Then
            dtpDataPlanning.Value = dtpDataPlanning.Value.GetValueOrDefault.AddYears(1)
         Else
            dtpDataPlanning.Value = dtpDataPlanning.Value.GetValueOrDefault.AddYears(-1)
         End If

         ' Crea la nuova vista per il Planning.
         CaricaCalendario(annoNuovo)
         CaricaRighePrenotazioni()
         AggiornaPlanning()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub SelezionaRigaCamera(ByVal dataGrid As DataGridView)
      Try
         If dgvCamere.Rows.Count <> 0 Then

            ' Numero della camera.
            Dim numero As String = dgvCamere.Rows(dataGrid.CurrentRow.Index).Cells("Numero").Value.ToString

            ' Descrizione della camera.
            Dim descrizione As String = dgvCamere.Rows(dataGrid.CurrentRow.Index).Cells("Descrizione").Value.ToString

            ' Visualizza i dati della camera.
            lblDescrizioneCamera.Text = numero & " " & descrizione

         Else
            ' Visualizza i dati della camera.
            lblDescrizioneCamera.Text = "Nessuna camera"

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub dgvCamere_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvCamere.CurrentCellChanged
      Try
         If dgvCamere.CurrentRow.Index >= dgvCamere.Rows.Count - 1 Then
            Exit Sub
         End If

         ' Serve a non generare un errore.
         If frmLoad = True Then
            procChiamanteCamere = True

            If procChiamanteData = True Or procChiamantePrenotazioni = True Then
               procChiamanteData = False
               procChiamantePrenotazioni = False

               Exit Sub
            End If

            ' Seleziona la riga camere corrispondende.
            SelezionaRigaCamera(dgvCamere)

            ' Seleziona la riga camere corrispondende.
            dgvPrenotazioni.Rows(dgvCamere.CurrentRow.Index).Cells(dtpDataPlanning.Value.GetValueOrDefault.ToShortDateString).Selected = True

            procChiamanteData = False
            procChiamantePrenotazioni = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub dgvPrenotazioni_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvPrenotazioni.CurrentCellChanged
      Try
         If dgvPrenotazioni.CurrentRow.Index >= dgvPrenotazioni.Rows.Count - 1 Then
            Exit Sub
         End If

         ' Serve a non generare un errore.
         If frmLoad = True Then
            procChiamantePrenotazioni = True

            If procChiamanteData = True Or procChiamanteCamere = True Then
               procChiamanteData = False
               procChiamanteCamere = False

               Exit Sub
            End If

            ' Seleziona il giorno del calendario.
            SelezionaGiorno()

            ' Seleziona la riga camere corrispondende.
            SelezionaRigaCamera(dgvPrenotazioni)

            ' Seleziona la riga camere corrispondende.
            dgvCamere.Rows(dgvPrenotazioni.CurrentRow.Index).Cells("Numero").Selected = True

            procChiamanteData = False
            procChiamanteCamere = False
         End If

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub dgvPrenotazioni_DoubleClick(sender As Object, e As EventArgs) Handles dgvPrenotazioni.DoubleClick
      ' Apre una nuova prenotazione.
      ApriDatiPrenotazione(Me.Name, "")
   End Sub

   Private Sub dtpDataPlanning_ValueChanged(sender As Object, e As EventArgs) Handles dtpDataPlanning.ValueChanged
      ' B_TODO: NON UTILIZZATA!

      '' Serve a non generare un errore.
      'If frmLoad = True Then
      '   procChiamanteData = True

      '   If procChiamanteCamere = True Or procChiamantePrenotazioni = True Then
      '      procChiamantePrenotazioni = False
      '      procChiamanteCamere = False
      '      Exit Sub
      '   End If

      '   SelezionaAnno()
      '   SelezionaMese()

      '   ' Seleziona la cella prenotazione corrispondende.
      '   dgvPrenotazioni.Rows(dgvPrenotazioni.CurrentRow.Index).Cells(dtpDataPlanning.Value.GetValueOrDefault.ToShortDateString).Selected = True

      '   procChiamantePrenotazioni = False
      '   procChiamanteCamere = False
      'End If

   End Sub

   Public Sub ScorriAnno(ByVal avanti As Boolean)
      Try
         ' Serve a non generare un errore.
         If frmLoad = True Then
            procChiamanteData = True

            If procChiamanteCamere = True Or procChiamantePrenotazioni = True Then
               procChiamantePrenotazioni = False
               procChiamanteCamere = False
               Exit Sub
            End If

            ' Salva la riga (Camera) corrente.
            Dim rigaCorrente As Integer = dgvPrenotazioni.CurrentRow.Index


            ' Aggiorna il calendario con il nuovo anno.
            Dim dataSel As String
            If avanti = True Then
               dataSel = dtpDataPlanning.Value.GetValueOrDefault.AddYears(1).ToShortDateString
            Else
               dataSel = dtpDataPlanning.Value.GetValueOrDefault.AddYears(-1).ToShortDateString
            End If

            SelezionaAnno(avanti)

            procChiamantePrenotazioni = False
            procChiamanteCamere = False

            ' Seleziona la cella prenotazione corrispondende.
            dgvPrenotazioni.Rows(rigaCorrente).Cells(dataSel).Selected = True

            ' Evidenzia il cursore sul Planning.
            dgvPrenotazioni.Focus()

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         'err.GestisciErrore(ex.StackTrace, ex.Message)

         Exit Sub

      End Try
   End Sub

   Public Sub VisualizzaOggi()
      Try
         ' Serve a non generare un eccezzione.
         procChiamanteData = True

         ' Salva la riga (Camera) corrente.
         Dim rigaCorrente As Integer = dgvPrenotazioni.CurrentRow.Index

         ' Carica il calendario per l'anno corrente.
         CaricaCalendario(Now.Year)
         CaricaRighePrenotazioni()

         ' Legge le prenotazioni salvate.
         AggiornaPlanning()

         ' Imposta la data selezionata sulla griglia.
         dtpCalendario.Value = Today
         dtpDataPlanning.Value = Today

         procChiamantePrenotazioni = False
         procChiamanteCamere = False

         ' Seleziona la cella prenotazione corrispondende.
         dgvPrenotazioni.Rows(rigaCorrente).Cells(Today.ToShortDateString).Selected = True

         ' Evidenzia il cursore sul Planning.
         dgvPrenotazioni.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

End Class