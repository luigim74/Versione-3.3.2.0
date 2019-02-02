#Region " DATI FILE.VB "

' ********************************************************************************
' Nome form:            frmTabelle
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/01/2005
' Data ultima modifica: 30/08/2018
' Descrizione:          Form per la visualizzazione dei dati di tutte le tabelle.
' Note:

' Elenco Attivita:

' ********************************************************************************

#End Region

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class TabelleDati
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   ' Numero di record.
   Dim numRecord As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim sql As String

   ' Per registrare le operazioni.
   Dim strDescrizione As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Dim strModulo As String

#End Region

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

   'NOTE: la procedura che segue Ë richiesta da Progettazione Windows Form.
   'PuÚ essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Nuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Modifica As System.Windows.Forms.ToolBarButton
   Friend WithEvents Elimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Stampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents Anteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Trova As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton9 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Primo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Precedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents Successivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Ultimo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Aggiorna As System.Windows.Forms.ToolBarButton
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabelleDati))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Nuovo = New System.Windows.Forms.ToolBarButton()
      Me.Modifica = New System.Windows.Forms.ToolBarButton()
      Me.Elimina = New System.Windows.Forms.ToolBarButton()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
      Me.Stampa = New System.Windows.Forms.ToolBarButton()
      Me.Anteprima = New System.Windows.Forms.ToolBarButton()
      Me.Trova = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
      Me.Primo = New System.Windows.Forms.ToolBarButton()
      Me.Precedente = New System.Windows.Forms.ToolBarButton()
      Me.Successivo = New System.Windows.Forms.ToolBarButton()
      Me.Ultimo = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton9 = New System.Windows.Forms.ToolBarButton()
      Me.Aggiorna = New System.Windows.Forms.ToolBarButton()
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
      Me.ImageList1.Images.SetKeyName(2, "")
      Me.ImageList1.Images.SetKeyName(3, "")
      Me.ImageList1.Images.SetKeyName(4, "")
      Me.ImageList1.Images.SetKeyName(5, "")
      Me.ImageList1.Images.SetKeyName(6, "")
      Me.ImageList1.Images.SetKeyName(7, "")
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Nuovo, Me.Modifica, Me.Elimina, Me.Salva, Me.Annulla, Me.ToolBarButton4, Me.Stampa, Me.Anteprima, Me.Trova, Me.ToolBarButton7, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.ToolBarButton9, Me.Aggiorna})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(492, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'Nuovo
      '
      Me.Nuovo.ImageIndex = 0
      Me.Nuovo.Name = "Nuovo"
      Me.Nuovo.Tag = "Nuovo"
      Me.Nuovo.ToolTipText = "Nuovo"
      '
      'Modifica
      '
      Me.Modifica.ImageIndex = 1
      Me.Modifica.Name = "Modifica"
      Me.Modifica.Tag = "Modifica"
      Me.Modifica.ToolTipText = "Modifica"
      '
      'Elimina
      '
      Me.Elimina.ImageIndex = 2
      Me.Elimina.Name = "Elimina"
      Me.Elimina.Tag = "Elimina"
      Me.Elimina.ToolTipText = "Elimina"
      '
      'Salva
      '
      Me.Salva.Enabled = False
      Me.Salva.ImageIndex = 3
      Me.Salva.Name = "Salva"
      Me.Salva.Tag = "Salva"
      Me.Salva.ToolTipText = "Salva"
      Me.Salva.Visible = False
      '
      'Annulla
      '
      Me.Annulla.Enabled = False
      Me.Annulla.ImageIndex = 14
      Me.Annulla.Name = "Annulla"
      Me.Annulla.Tag = "Annulla"
      Me.Annulla.ToolTipText = "Annulla"
      Me.Annulla.Visible = False
      '
      'ToolBarButton4
      '
      Me.ToolBarButton4.Name = "ToolBarButton4"
      Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.ToolBarButton4.Visible = False
      '
      'Stampa
      '
      Me.Stampa.ImageIndex = 4
      Me.Stampa.Name = "Stampa"
      Me.Stampa.Tag = "Stampa"
      Me.Stampa.ToolTipText = "Stampa"
      Me.Stampa.Visible = False
      '
      'Anteprima
      '
      Me.Anteprima.ImageIndex = 5
      Me.Anteprima.Name = "Anteprima"
      Me.Anteprima.Tag = "Anteprima"
      Me.Anteprima.ToolTipText = "Anteprima di stampa"
      Me.Anteprima.Visible = False
      '
      'Trova
      '
      Me.Trova.ImageIndex = 6
      Me.Trova.Name = "Trova"
      Me.Trova.Tag = "Trova"
      Me.Trova.ToolTipText = "Trova"
      Me.Trova.Visible = False
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Primo
      '
      Me.Primo.ImageIndex = 3
      Me.Primo.Name = "Primo"
      Me.Primo.Tag = "Primo"
      Me.Primo.ToolTipText = "Prima pagina"
      '
      'Precedente
      '
      Me.Precedente.ImageIndex = 4
      Me.Precedente.Name = "Precedente"
      Me.Precedente.Tag = "Precedente"
      Me.Precedente.ToolTipText = "Pagina precedente "
      '
      'Successivo
      '
      Me.Successivo.ImageIndex = 5
      Me.Successivo.Name = "Successivo"
      Me.Successivo.Tag = "Successivo"
      Me.Successivo.ToolTipText = "Pagina successiva"
      '
      'Ultimo
      '
      Me.Ultimo.ImageIndex = 6
      Me.Ultimo.Name = "Ultimo"
      Me.Ultimo.Tag = "Ultimo"
      Me.Ultimo.ToolTipText = "Ultima pagina"
      '
      'ToolBarButton9
      '
      Me.ToolBarButton9.Name = "ToolBarButton9"
      Me.ToolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Aggiorna
      '
      Me.Aggiorna.ImageIndex = 7
      Me.Aggiorna.Name = "Aggiorna"
      Me.Aggiorna.Tag = "Aggiorna"
      Me.Aggiorna.ToolTipText = "Aggiorna"
      '
      'DataGrid1
      '
      Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 26)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(492, 293)
      Me.DataGrid1.TabIndex = 3
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'TabelleDati
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(492, 319)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Name = "TabelleDati"
      Me.ShowInTaskbar = False
      Me.Text = "Tabelle"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Attivit‡
               If operatore.TabAttivit‡ = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.CatCliente
               If operatore.TabCatClienti = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.CatMerce
               If operatore.TabCatMerce = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.FormeCortesia
               If operatore.TabFormeCortesia = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.Magazzini
               If operatore.TabMagazzini = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.MsgReparti
               If operatore.TabMsg = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.Nazioni
               'If operatore.TabNazioni = VALORE_LETTURA Then
               Nuovo.Enabled = False
               Modifica.Enabled = False
               Elimina.Enabled = False
               'Else
               '   Nuovo.Enabled = True
               '   Modifica.Enabled = True
               '   Elimina.Enabled = True
               'End If

            Case Finestra.Pagamenti
               If operatore.TabPagamenti = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.TipologieRisorse
               If operatore.TabTipoRisorse = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.Reparti
               If operatore.TabReparti = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.Scaffali
               If operatore.TabScaffali = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            ' DA_FARE_B: GESTIONE DOCUMENTI - Tipo documenti eliminata dal menu - Sostituire con tabella Causali Documenti.
            Case Finestra.CausaliDoc
               If operatore.TabCausaliDoc = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.Ubicazioni
               If operatore.TabUbicazioni = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.Unit‡Misura
               If operatore.TabUM = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.TipologieCamere
               If operatore.TabTipologieCamere = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.Ubicazioni
               If operatore.TabUbicazioniCamere = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.PosizioniCamere
               If operatore.TabPosizioniCamere = VALORE_LETTURA Then
                  Nuovo.Enabled = False
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Nuovo.Enabled = True
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If

            Case Finestra.DocIdentit‡
               'If operatore.TabDocIdentit‡ = VALORE_LETTURA Then
               Nuovo.Enabled = False
               Modifica.Enabled = False
               Elimina.Enabled = False
               'Else
               '   Nuovo.Enabled = True
               '   Modifica.Enabled = True
               '   Elimina.Enabled = True
               'End If

            Case Finestra.GruppiOspiti
               'If operatore.TabDocIdentit‡ = VALORE_LETTURA Then
               '   Nuovo.Enabled = False
               '   Modifica.Enabled = False
               '   Elimina.Enabled = False
               'Else
               '   Nuovo.Enabled = True
               '   Modifica.Enabled = True
               '   Elimina.Enabled = True
               'End If

            Case Finestra.Agenzie
               'If operatore.TabDocIdentit‡ = VALORE_LETTURA Then
               '   Nuovo.Enabled = False
               '   Modifica.Enabled = False
               '   Elimina.Enabled = False
               'Else
               '   Nuovo.Enabled = True
               '   Modifica.Enabled = True
               '   Elimina.Enabled = True
               'End If

            Case Finestra.CanaliVendita
               'If operatore.TabDocIdentit‡ = VALORE_LETTURA Then
               '   Nuovo.Enabled = False
               '   Modifica.Enabled = False
               '   Elimina.Enabled = False
               'Else
               '   Nuovo.Enabled = True
               '   Modifica.Enabled = True
               '   Elimina.Enabled = True
               'End If

            Case Finestra.TipoAlloggiato
               'If operatore.TabDocIdentit‡ = VALORE_LETTURA Then
               Nuovo.Enabled = False
               Modifica.Enabled = False
               Elimina.Enabled = False
               'Else
               '   Nuovo.Enabled = True
               '   Modifica.Enabled = True
               '   Elimina.Enabled = True
               'End If

            Case Finestra.Comuni
               'If operatore.TabDocIdentit‡ = VALORE_LETTURA Then
               Nuovo.Enabled = False
               Modifica.Enabled = False
               Elimina.Enabled = False
               'Else
               '   Nuovo.Enabled = True
               '   Modifica.Enabled = True
               '   Elimina.Enabled = True
               'End If

         End Select

         Return Nuovo.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   Public Sub LeggiDati(ByVal tabella As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         CreaColonne(tabella)

         ' Collega la tabella clienti al controllo griglia dati.
         DataGrid1.DataSource = dt

         ' Crea la stringa sql.
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, tabella)

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(1, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Sub LeggiNumPagine(ByVal tabella As String)
      Try
         Dim closeOnExit As Boolean

         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
         If closeOnExit Then cn.Close()

         ' Ottiene il numero di pagine.
         numPagine = (numRecord + dimPagina - 1) \ dimPagina

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub VisualizzaPagina(ByVal n As Integer, ByVal sql As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sql, cn)

         ' Pulisce la tabella da precedenti dati.
         dt.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dt)

         ' Salva il numero di pagina corrente.
         pagCorrente = n

         ' Abilita/disabilita i pulsanti.
         Primo.Enabled = (n > 1)
         Precedente.Enabled = (n > 1)
         Successivo.Enabled = (n < numPagine)
         Ultimo.Enabled = (n < numPagine)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(Me.Tag)

         ' Collega la tabella clienti al controllo griglia dati.
         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(pagCorrente, sql)

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord > 0 Then
            DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1))
         Else
            DataGrid1.CaptionText = Strings.UCase("Non ci sono valori.")
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InserisciDati(ByVal tabella As String, ByVal val As String)
      Dim sql As String
      val = FormattaApici(val)

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Descrizione) VALUES('{1}')", tabella, val)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

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

   Public Sub ModificaDati(ByVal tabella As String, ByVal codice As String, ByVal val As String)
      Dim sql As String
      val = FormattaApici(val)

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Descrizione = '{1}' WHERE Id = {2} ", tabella, val, codice)

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

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

         ' Registra l'operazione.
         strDescrizione = "(" & descrizione & ")"

         Dim Risposta As Short
         Dim sql As String

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare il valore """ & Descrizione &
                           """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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

            ' Conferma la transazione.
            tr.Commit()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, strModulo)

         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         ' Aggiorna la griglia dati.
         AggiornaDati()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub ImpostaComandi()
      Try
         If numRecord = 0 Then
            ' Disattiva i pulsanti appropriati.
            Modifica.Enabled = False
            Elimina.Enabled = False
            Trova.Enabled = False
            Primo.Enabled = False
            Precedente.Enabled = False
            Successivo.Enabled = False
            Ultimo.Enabled = False
            Aggiorna.Enabled = False
         Else
            ' Disattiva i pulsanti appropriati.
            Modifica.Enabled = True
            Elimina.Enabled = True
            Trova.Enabled = True
            Aggiorna.Enabled = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ConvalidaDati()
      Try
         Select Case Me.Tag
            Case "CategorieClienti"
               If ImpostaFunzioniOperatore(Finestra.CatCliente) = True Then
                  ImpostaComandi()
               End If

            Case "Attivit‡"
               If ImpostaFunzioniOperatore(Finestra.Attivit‡) = True Then
                  ImpostaComandi()
               End If

            Case "ModPagamento"
               If ImpostaFunzioniOperatore(Finestra.Pagamenti) = True Then
                  ImpostaComandi()
               End If

            Case "Qualifiche"
               If ImpostaFunzioniOperatore(Finestra.FormeCortesia) = True Then
                  ImpostaComandi()
               End If

            Case "CausaliDocumento"
               If ImpostaFunzioniOperatore(Finestra.CausaliDoc) = True Then
                  ImpostaComandi()
               End If

            Case "CategorieMerce"
               If ImpostaFunzioniOperatore(Finestra.CatMerce) = True Then
                  ImpostaComandi()
               End If

            Case "Unit‡Misura"
               If ImpostaFunzioniOperatore(Finestra.Unit‡Misura) = True Then
                  ImpostaComandi()
               End If

            Case "MessaggiReparti"
               If ImpostaFunzioniOperatore(Finestra.MsgReparti) = True Then
                  ImpostaComandi()
               End If

            Case "Nazioni"
               If ImpostaFunzioniOperatore(Finestra.Nazioni) = True Then
                  ImpostaComandi()
               End If

            Case "Magazzini"
               If ImpostaFunzioniOperatore(Finestra.Magazzini) = True Then
                  ImpostaComandi()
               End If

            Case "Ubicazioni"
               If ImpostaFunzioniOperatore(Finestra.Ubicazioni) = True Then
                  ImpostaComandi()
               End If

            Case "Scaffali"
               If ImpostaFunzioniOperatore(Finestra.Scaffali) = True Then
                  ImpostaComandi()
               End If

            Case "Reparti"
               If ImpostaFunzioniOperatore(Finestra.Reparti) = True Then
                  ImpostaComandi()
               End If

            Case "Tipologie"
               If ImpostaFunzioniOperatore(Finestra.TipologieRisorse) = True Then
                  ImpostaComandi()
               End If

            Case "TipologieCamere"
               If ImpostaFunzioniOperatore(Finestra.TipologieCamere) = True Then
                  ImpostaComandi()
               End If

            Case "UbicazioniCamere"
               If ImpostaFunzioniOperatore(Finestra.UbicazioniCamere) = True Then
                  ImpostaComandi()
               End If

            Case "PosizioniCamere"
               If ImpostaFunzioniOperatore(Finestra.PosizioniCamere) = True Then
                  ImpostaComandi()
               End If

            Case "DocIdentit‡"
               If ImpostaFunzioniOperatore(Finestra.DocIdentit‡) = True Then
                  ImpostaComandi()
               End If

            Case "GruppiOspiti"
               If ImpostaFunzioniOperatore(Finestra.GruppiOspiti) = True Then
                  ImpostaComandi()
               End If

            Case "Agenzie"
               If ImpostaFunzioniOperatore(Finestra.Agenzie) = True Then
                  ImpostaComandi()
               End If

            Case "CanaliVendite"
               If ImpostaFunzioniOperatore(Finestra.CanaliVendita) = True Then
                  ImpostaComandi()
               End If

            Case "TipoAlloggiato"
               If ImpostaFunzioniOperatore(Finestra.TipoAlloggiato) = True Then
                  ImpostaComandi()
               End If

            Case "Comuni"
               If ImpostaFunzioniOperatore(Finestra.Comuni) = True Then
                  ImpostaComandi()
               End If

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub AggTitoloFinestra()
      Try
         Select Case Me.Tag
            Case "CategorieClienti"
               ' Imposta il titolo della tabella.
               Me.Text = "Categorie clienti" & " (n∞ totale: " & numRecord & ")"

            Case "Attivit‡"
               ' Imposta il titolo della tabella.
               Me.Text = "Attivit‡" & " (n∞ totale: " & numRecord & ")"

            Case "ModPagamento"
               ' Imposta il titolo della tabella.
               Me.Text = "Modalita di pagamento" & " (n∞ totale: " & numRecord & ")"

            Case "Qualifiche"
               ' Imposta il titolo della tabella.
               Me.Text = "Forme di cortesia" & " (n∞ totale: " & numRecord & ")"

            Case "CausaliDocumento"
               ' Imposta il titolo della tabella.
               Me.Text = "Causali documento" & " (n∞ totale: " & numRecord & ")"

            Case "CategorieMerce"
               ' Imposta il titolo della tabella.
               Me.Text = "Categorie merceologiche" & " (n∞ totale: " & numRecord & ")"

            Case "Unit‡Misura"
               ' Imposta il titolo della tabella.
               Me.Text = "Unit‡ di misura" & " (n∞ totale: " & numRecord & ")"

            Case "MessaggiReparti"
               ' Imposta il titolo della tabella.
               Me.Text = "Messaggi per i reparti" & " (n∞ totale: " & numRecord & ")"

            Case "Tipologie"
               ' Imposta il titolo della tabella.
               Me.Text = "Tipologie risorse" & " (n∞ totale: " & numRecord & ")"

            Case "Ubicazioni"
               ' Imposta il titolo della tabella.
               Me.Text = "Ubicazioni articoli" & " (n∞ totale: " & numRecord & ")"

            Case "TipologieCamere"
               ' Imposta il titolo della tabella.
               Me.Text = "Tipologie camere" & " (n∞ totale: " & numRecord & ")"

            Case "UbicazioniCamere"
               ' Imposta il titolo della tabella.
               Me.Text = "Ubicazioni camere" & " (n∞ totale: " & numRecord & ")"

            Case "PosizioniCamere"
               ' Imposta il titolo della tabella.
               Me.Text = "Posizioni camere" & " (n∞ totale: " & numRecord & ")"

            Case "DocIdentit‡"
               ' Imposta il titolo della tabella.
               Me.Text = "Documenti d'identit‡" & " (n∞ totale: " & numRecord & ")"

            Case "GruppiOspiti"
               ' Imposta il titolo della tabella.
               Me.Text = "Gruppi" & " (n∞ totale: " & numRecord & ")"

            Case "CanaliVendita"
               ' Imposta il titolo della tabella.
               Me.Text = "Canali di provenienza" & " (n∞ totale: " & numRecord & ")"

            Case "TipoAlloggiato"
               ' Imposta il titolo della tabella.
               Me.Text = "Tipo alloggiato" & " (n∞ totale: " & numRecord & ")"

            Case Else
               ' Imposta il titolo della tabella.
               Me.Text = Me.Tag & " (n∞ totale: " & numRecord & ")"

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub LeggiTipoTabella()
      Try
         Select Case Me.Tag
            Case "Qualifiche"
               strDescrizione = STR_TABELLA_QUALIFICHE
               strModulo = MODULO_TABELLA_QUALIFICHE

            Case "CategorieClienti"
               strDescrizione = STR_TABELLA_CAT_CLIENTE
               strModulo = MODULO_TABELLA_CAT_CLIENTE

            Case "Attivit‡"
               strDescrizione = STR_TABELLA_ATTIVITA
               strModulo = MODULO_TABELLA_ATTIVITA

            Case "Nazioni"
               strDescrizione = STR_TABELLA_NAZIONI
               strModulo = MODULO_TABELLA_NAZIONI

            Case "Unit‡Misura"
               strDescrizione = STR_TABELLA_UM
               strModulo = MODULO_TABELLA_UM

            Case "CategorieMerce"
               strDescrizione = STR_TABELLA_CAT_MERCE
               strModulo = MODULO_TABELLA_CAT_MERCE

            Case "Magazzini"
               strDescrizione = STR_TABELLA_MAGAZZINI
               strModulo = MODULO_TABELLA_MAGAZZINI

            Case "Ubicazioni"
               strDescrizione = STR_TABELLA_UBICAZIONI
               strModulo = MODULO_TABELLA_UBICAZIONI

            Case "Scaffali"
               strDescrizione = STR_TABELLA_SCAFFALI
               strModulo = MODULO_TABELLA_SCAFFALI

            Case "Reparti"
               strDescrizione = STR_TABELLA_REPARTI
               strModulo = MODULO_TABELLA_REPARTI

            Case "MessaggiReparti"
               strDescrizione = STR_TABELLA_MSG_REP
               strModulo = MODULO_TABELLA_MSG_REP

            ' DA_FARE_B: GESTIONE DOCUMENTI - Tipo documenti eliminata dal menu - Sostituire con tabella Causali Documenti.
            Case "CausaliDocumento"
               strDescrizione = STR_TABELLA_CAUSALI_DOC
               strModulo = MODULO_TABELLA_CAUSALI_DOC

            Case "ModPagamento"
               strDescrizione = STR_TABELLA_PAGAMENTI
               strModulo = MODULO_TABELLA_PAGAMENTI

            Case "Tipologie"
               strDescrizione = STR_TABELLA_TIPO_RISORSE
               strModulo = MODULO_TABELLA_TIPO_RISORSE

            Case "TipologieCamere"
               strDescrizione = STR_TABELLA_TIPOLOGIE_CAMERE
               strModulo = MODULO_TABELLA_TIPOLOGIE_CAMERE

            Case "UbicazioniCamere"
               strDescrizione = STR_TABELLA_UBICAZIONI_CAMERE
               strModulo = MODULO_TABELLA_UBICAZIONI_CAMERE

            Case "PosizioniCamere"
               strDescrizione = STR_TABELLA_POSIZIONI_CAMERE
               strModulo = MODULO_TABELLA_POSIZIONI_CAMERE

            Case "DocIdentit‡"
               strDescrizione = STR_TABELLA_DOC_IDENTITA
               strModulo = MODULO_TABELLA_DOC_IDENTITA

            Case "GruppiOspiti"
               strDescrizione = STR_TABELLA_GRUPPI
               strModulo = MODULO_TABELLA_GRUPPI_OSPITI

            Case "Agenzie"
               strDescrizione = STR_TABELLA_AGENZIE
               strModulo = MODULO_TABELLA_AGENZIE

            Case "CanaliVendita"
               strDescrizione = STR_TABELLA_CANALI
               strModulo = MODULO_TABELLA_CANALI

            Case "TipoAlloggiato"
               strDescrizione = STR_TABELLA_TIPO_ALLOGGIATO
               strModulo = MODULO_TABELLA_TIPO_ALLOGGIATO

            Case "Comuni"
               strDescrizione = STR_TABELLA_COMUNI
               strModulo = MODULO_TABELLA_COMUNI
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 60
         codiceStyle.NullText = ""
         codiceStyle.ReadOnly = True
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)

         ' Descrizione
         Dim descrizioneStyle As New DataGridTextBoxColumn
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 199
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(descrizioneStyle)

         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Function LeggiNumRecord(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
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

   Private Sub TabelleDati_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

#Region "Gestionale Amica - (Condivisa) "
      Try
         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         Select Case Me.Tag
            Case "CategorieClienti"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Attivit‡"
               g_frmMain.rtgGestionaleAmica.Visible = True

            Case "ModPagamento"
               g_frmMain.rtgGestionaleAmica.Visible = True

            Case "Qualifiche"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "CausaliDocumento"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "CategorieMerce"
               g_frmMain.rtgGestionaleAmica.Visible = True

            Case "Unit‡Misura"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "MessaggiReparti"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Tipologie"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Nazioni"
               g_frmMain.rtgGestionaleAmica.Visible = True

            Case "Magazzini"
               g_frmMain.rtgGestionaleAmica.Visible = True

            Case "Reparti"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Ubicazioni"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Scaffali"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "TipologieCamere"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "UbicazioniCamere"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "PosizioniCamere"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "DocIdentit‡"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Gruppi"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Agenzie"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "CanaliVendita"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "TipoAlloggiato"
               g_frmMain.rtgGestionaleAmica.Visible = False

            Case "Comuni"
               g_frmMain.rtgGestionaleAmica.Visible = False

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

#End Region

   End Sub

   Private Sub TabelleDati_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Gestionale Amica - (Condivisa) "
      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

#End Region

   End Sub

   Private Sub TabelleDati_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(Me)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub Tabelle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(TAB_LARGHEZZA, TAB_ALTEZZA)

         dt = ds.Tables.Add(Me.Tag)

         ' Legge i dati e ottiene il numero totale dei record.
         LeggiDati(Me.Tag)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra()

         ' Legge il tipo della tabella per impostare le stringhe delle operazioni.
         LeggiTipoTabella()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, strDescrizione, strModulo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Visualizza un messaggio nella barra di stato.
         g_frmMain.eui_Informazioni.Text = g_frmMain.LeggiDatiRivenditore()
      End Try

   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Nuovo"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, strDescrizione, strModulo)

            If Me.Tag = "Reparti" Then
               If VerificaNumRecord(LeggiNumRecord(Me.Tag), 10) = True Then
                  MessageBox.Show("Limite massimo raggiunto! Non Ë possibile inserire altri Reparti.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Exit Sub
               End If
            End If

            Dim val As String
            val = InputBox("Inserire una nuova descrizione.", "Nuovo", "")

            ' Registra l'operazione.
            Dim descrizione As String = "(" & val & ")"

            If val <> "" Then
               ' Inserisce i nuovi dati nella tabella.
               InserisciDati(Me.Tag, val)

               ' Aggiorna la tabella dati.
               AggiornaDati()

               ' Se nella tabella non ci sono record disattiva i pulsanti.
               ConvalidaDati()

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Salva, descrizione, strModulo)
            Else
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, strModulo)
            End If

         Case "Modifica"
            ' Registra l'operazione.
            Dim descrizione As String = "(" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & ")"

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Modifica, descrizione, strModulo)

            Dim val As String
            val = InputBox("Modifica descrizione.", "Modifica", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1))

            If val <> "" Then
               ' Modifica i dati nella tabella.
               ModificaDati(Me.Tag, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0), val)

               ' Aggiorna la tabella dati.
               AggiornaDati()

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Salva, Descrizione, strModulo)
            Else
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, strModulo)
            End If

         Case "Elimina"
            ' Elimina il valore selezionato nella tabella.
            EliminaDati(Me.Tag, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         Case "Primo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, Me.Tag)

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Precedente"
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {0} WHERE Id < {2} ORDER BY Id DESC) ORDER BY Id", Me.Tag, dimPagina, dt.Rows(0)("Id"))

            ' Visualizza la pagina di dati precedente.
            VisualizzaPagina(pagCorrente - 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Successivo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} ORDER BY Id", dimPagina, Me.Tag, dt.Rows(dt.Rows.Count - 1)("Id"))

            ' Visualizza la pagina di dati successiva.
            VisualizzaPagina(pagCorrente + 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Ultimo"
            Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {0} ORDER BY Id DESC) ORDER BY Id", Me.Tag, num)

            ' Visualizza l'ultima pagina di dati.
            VisualizzaPagina(numPagine, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, strDescrizione, strModulo)

            ' Aggiorna la griglia dati.
            AggiornaDati()

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

      End Select
   End Sub

End Class
