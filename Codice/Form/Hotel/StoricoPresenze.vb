#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            StoricoPresenze
' Autore:               Luigi Montana, Montana Software
' Data creazione:       24/06/2018
' Data ultima modifica: 08/09/2018
' Descrizione:          Visualizza l'elenco storico delle presenze delle camere divise per mese, con grafico.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Imports Elegant.Ui

Public Class StoricoPresenze

   Const TAB_STRORICO_PRESENZE_CAMERE As String = "StoricoPresenzeCamere"
   Const TAB_STRORICO_PRESENZE_TEMP As String = "StoricoPresenzeTemp"

   Dim Mese(11) As String
   Dim numGiorniMese(11) As Integer
   Private CFormatta As New ClsFormatta

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   Dim tr As OleDbTransaction
   Dim sql As String
   Dim cmd As New OleDbCommand(sql, cn)

   Private Sub LeggiStoricoPresenzeCamere(ByVal anno As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim totalePersoneCamera As Integer
      Dim totalePersoneMese As Integer
      Dim totaleOccupazione As Double
      Dim numCamere As Integer
      Dim numTotalePosti As Integer

      Try
         ' Assegna i mesi alla matrice.
         Mese(0) = "Gennaio"
         Mese(1) = "Febbraio"
         Mese(2) = "Marzo"
         Mese(3) = "Aprile"
         Mese(4) = "Maggio"
         Mese(5) = "Giugno"
         Mese(6) = "Luglio"
         Mese(7) = "Agosto"
         Mese(8) = "Settembre"
         Mese(9) = "Ottobre"
         Mese(10) = "Novembre"
         Mese(11) = "Dicembre"

         ' Assegna il numero di giorni per ogni mese alla matrice.
         numGiorniMese(0) = "31"
         numGiorniMese(1) = "28"
         numGiorniMese(2) = "31"
         numGiorniMese(3) = "30"
         numGiorniMese(4) = "31"
         numGiorniMese(5) = "30"
         numGiorniMese(6) = "31"
         numGiorniMese(7) = "31"
         numGiorniMese(8) = "30"
         numGiorniMese(9) = "31"
         numGiorniMese(10) = "30"
         numGiorniMese(11) = "31"

         ' Legge il numero totale di camere.
         numCamere = LeggiNumCamere()

         ' Restituisce il focus alla griglia e cancella eventuali valori.
         dgvDettagli.Focus()
         dgvDettagli.Rows.Clear()

         cn.Open()

         Dim i As Integer
         For i = 1 To 12

            Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_STRORICO_PRESENZE_CAMERE & " WHERE Mese = " & i & "AND Anno = " & anno & " ORDER BY Id ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Do While dr.Read()

               ' Adulti.
               Dim numAdulti As Integer
               If IsDBNull(dr.Item("Adulti")) = False Then
                  numAdulti = Convert.ToInt32(dr.Item("Adulti"))
               Else
                  numAdulti = 0
               End If

               ' Neonati.
               Dim numNeonati As Integer
               If IsDBNull(dr.Item("Neonati")) = False Then
                  numNeonati = Convert.ToInt32(dr.Item("Neonati"))
               Else
                  numNeonati = 0
               End If

               ' Bambini.
               Dim numBambini As Integer
               If IsDBNull(dr.Item("Bambini")) = False Then
                  numBambini = Convert.ToInt32(dr.Item("Bambini"))
               Else
                  numBambini = 0
               End If

               ' Ragazzi.
               Dim numRagazzi As Integer
               If IsDBNull(dr.Item("Ragazzi")) = False Then
                  numRagazzi = Convert.ToInt32(dr.Item("Ragazzi"))
               Else
                  numRagazzi = 0
               End If

               ' Numero notti.
               Dim numNotti As Integer
               If IsDBNull(dr.Item("NumeroNotti")) = False Then
                  numNotti = Convert.ToInt32(dr.Item("NumeroNotti"))
               Else
                  numNotti = 0
               End If

               ' Somma di tutti gli occupanti della camera.
               totalePersoneCamera = (numAdulti + numNeonati + numBambini + numRagazzi) * numNotti

               ' Somma di tutti gli occupanti del mese.
               totalePersoneMese = totalePersoneMese + totalePersoneCamera

               ' Calcola il numero totale di posti in un mese.
               numTotalePosti = numCamere * numGiorniMese(i - 1)

               ' Calcola la percentuale di occupazione in un mese.
               totaleOccupazione = (totalePersoneMese / numTotalePosti) * 100

            Loop

            dgvDettagli.Focus()
            dgvDettagli.Rows.Add()
            dgvDettagli.Rows.Item(dgvDettagli.Rows.Count - 2).Selected = True
            dgvDettagli.Rows.Item(dgvDettagli.Rows.Count - 2).Cells.Item(0).Selected = True

            ' Mese.
            dgvDettagli.CurrentRow.Cells(clnMese.Name).Value = Mese(i - 1)

            ' Numero presenze.
            dgvDettagli.CurrentRow.Cells(clnPresenze.Name).Value = totalePersoneMese.ToString

            ' Percentuale di occupazione.
            If totaleOccupazione = 0 Then
               dgvDettagli.CurrentRow.Cells(clnOccupazione.Name).Value = totaleOccupazione.ToString
            Else
               dgvDettagli.CurrentRow.Cells(clnOccupazione.Name).Value = CFormatta.FormattaNumeroDouble(totaleOccupazione)
            End If

            ' Assegna un colore in base ai valori.
            Select Case totaleOccupazione
               Case = 0
                  dgvDettagli.CurrentRow.Cells(clnPresenze.Name).Style.ForeColor = Color.Black
                  dgvDettagli.CurrentRow.Cells(clnOccupazione.Name).Style.ForeColor = Color.Black

               Case < 50
                  dgvDettagli.CurrentRow.Cells(clnPresenze.Name).Style.ForeColor = Color.Red
                  dgvDettagli.CurrentRow.Cells(clnOccupazione.Name).Style.ForeColor = Color.Red

               Case > 50
                  dgvDettagli.CurrentRow.Cells(clnPresenze.Name).Style.ForeColor = Color.Blue
                  dgvDettagli.CurrentRow.Cells(clnOccupazione.Name).Style.ForeColor = Color.Blue

               Case = 100
                  dgvDettagli.CurrentRow.Cells(clnPresenze.Name).Style.ForeColor = Color.Green
                  dgvDettagli.CurrentRow.Cells(clnOccupazione.Name).Style.ForeColor = Color.Green

            End Select

            ' Ripristina le variabili.
            totalePersoneMese = 0
            totaleOccupazione = 0
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaAnniPresenze()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim annoTrovato As Boolean

      Try
         ' Pulisce la lista da eventuali anni.
         eui_cmbAnno.Items.Clear()

         ' Inserisce nella lista l'anno corrente.
         eui_cmbAnno.Items.Add(Today.Year.ToString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_STRORICO_PRESENZE_CAMERE & " ORDER BY DataArrivo ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' Data Arrivo.
            Dim anno As String
            If IsDBNull(dr.Item("Anno")) = False Then
               anno = dr.Item("Anno")
            Else
               anno = String.Empty
            End If

            Dim i As Integer
            For i = 0 To eui_cmbAnno.Items.Count - 1

               If anno = eui_cmbAnno.Items(i).ToString Then
                  annoTrovato = True
                  Exit For
               End If
            Next

            ' Se l'anno non è stato trovato nella lista lo inserisce.
            If annoTrovato = False Then
               eui_cmbAnno.Items.Add(anno)
            End If

            annoTrovato = False
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CalcolaTotalePresenze()
      Try
         ' Numero presenze..
         Dim numPresenze As Integer

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1
            ' Somma tutte le presenze delle righe della griglia.
            numPresenze = (numPresenze + Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnPresenze.Name).Value))
         Next

         ' Aggiorna i totali.
         eui_txtTotalePresenze.Text = numPresenze.ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaTotaleOccupazione()
      Try
         ' Importo.
         Dim percOccupazione As Double

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1
            ' Somma tutte le presenze delle righe della griglia.
            percOccupazione = (percOccupazione + Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnOccupazione.Name).Value))
         Next

         ' Aggiorna i totali.
         eui_txtTotaleOccupazione.Text = percOccupazione.ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiNumCamere() As Integer
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String
      Dim cmd As New OleDbCommand(sql, cn)

      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = "SELECT COUNT(*) FROM Camere"
         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub GeneraGrafico()
      Try
         ' Elimina tutti gli eventuali punti della serie.
         chartPresenze.Series.Item("Series1").Points.Clear()

         ' Genera i dati dei mesi.
         Dim i As Integer
         For i = 0 To 11
            ' Nome del mese.
            chartPresenze.Series.Item("Series1").Points.Add(Convert.ToInt32(dgvDettagli.Rows.Item(i).Cells.Item(1).Value), 0).AxisLabel = Mese(i)

            ' Numero presenze.
            chartPresenze.Series.Item("Series1").Points.Item(i).YValues.SetValue(Convert.ToInt32(dgvDettagli.Rows.Item(i).Cells.Item(1).Value), 0)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function InserisciDati(ByVal mese As String, ByVal anno As String, ByVal presenze As String, ByVal occupazione As String, ByVal tabella As String) As Boolean
      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         Sql = String.Format("INSERT INTO {0} (Mese, Anno, Presenze, Occupazione) " &
                                       "VALUES(@Mese, @Anno, @Presenze, @Occupazione)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(Sql, cn, tr)

         cmdInsert.Parameters.Add("@Mese", mese)
         cmdInsert.Parameters.Add("@Anno", anno)
         cmdInsert.Parameters.Add("@Presenze", presenze)
         cmdInsert.Parameters.Add("@Occupazione", occupazione)

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

   Public Sub EliminaDati(ByVal tabella As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0}", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Private Sub SalvaDatiTempPresenze()
      Try
         Dim anno As String = eui_cmbAnno.Text
         Dim mese As String
         Dim presenze As String
         Dim occupazione As String

         ' Pulisce la tabella dai vecchi valori.
         EliminaDati(TAB_STRORICO_PRESENZE_TEMP)

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 2
            mese = dgvDettagli.Rows.Item(i).Cells(clnMese.Name).Value
            presenze = dgvDettagli.Rows.Item(i).Cells(clnPresenze.Name).Value
            occupazione = dgvDettagli.Rows.Item(i).Cells(clnOccupazione.Name).Value

            InserisciDati(mese, anno, presenze, occupazione, TAB_STRORICO_PRESENZE_TEMP)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AnteprimaDiStampa(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New HospitalityDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepStoricoPresenzeCamere(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub StoricoPresenze_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona del prodotto.
         ImpostaIcona(Me)

         ' Carica l'elenco degli anni in cui ci sono state presenze.
         CaricaAnniPresenze()

         ' Seleziona l'anno corrente.
         eui_cmbAnno.SelectedItem = Today.Year.ToString

         ' Carica i dati nella griglia.
         LeggiStoricoPresenzeCamere(eui_cmbAnno.SelectedItem.ToString)

         ' Somma tutti i valori della colonna Presenze.
         CalcolaTotalePresenze()

         ' SommaColonna tutti i valori della colonna % Occupazione.
         CalcolaTotaleOccupazione()

         ' Restituisce il focus alla griglia.
         dgvDettagli.Focus()

         ' Crea il grafico con i dati della griglia.
         GeneraGrafico()

         ' Salva i dati in una tabella temporanea per permettere l'anteprima di stampa.
         SalvaDatiTempPresenze()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmbAnno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbAnno.SelectedIndexChanged
      Try
         ' Carica i dati nella griglia.
         LeggiStoricoPresenzeCamere(eui_cmbAnno.SelectedItem.ToString)

         ' Somma tutti i valori della colonna Presenze.
         CalcolaTotalePresenze()

         ' SommaColonna tutti i valori della colonna % Occupazione.
         CalcolaTotaleOccupazione()

         ' Restituisce il focus alla griglia.
         dgvDettagli.Focus()

         ' Crea il grafico con i dati della griglia.
         GeneraGrafico()

         ' Salva i dati in una tabella temporanea per permettere l'anteprima di stampa.
         SalvaDatiTempPresenze()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdStampa_Click(sender As Object, e As EventArgs) Handles eui_cmdStampa.Click
      Try
         Dim repSql As String = "SELECT * FROM " & TAB_STRORICO_PRESENZE_TEMP & " ORDER BY Id ASC"

         AnteprimaDiStampa(PERCORSO_REP_STORICO_PRESENZE_CAMERE_A4, TAB_STRORICO_PRESENZE_TEMP, repSql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub
End Class