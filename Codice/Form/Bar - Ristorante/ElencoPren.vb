' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 10/08/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class frmElencoPren
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Const DIMENSIONE_PAGINA As Integer = 1000

   Dim TAB_PREN = "Prenotazioni"
   Const ANA_TAVOLI As String = "Tavoli"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnStringAnagrafiche)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   Dim NomeTabella As String
   Dim TitoloFinestra As String

   ' Numero di record.
   Dim numRecord As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim sql As String
   Dim repSql As String
   Dim dataSelezionata As String = ""
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents mcCalendario As System.Windows.Forms.MonthCalendar
   Private DatiConfig As AppConfig

#End Region

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      NomeTabella = "Prenotazioni"
      TitoloFinestra = "Elenco prenotazioni"

      dt = ds.Tables.Add(NomeTabella)

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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents cmdEsci As System.Windows.Forms.Button
   Friend WithEvents cmdElimina As System.Windows.Forms.Button
   Friend WithEvents cmdNuova As System.Windows.Forms.Button
   Friend WithEvents cmdModifica As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoPren))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.cmdElimina = New System.Windows.Forms.Button()
      Me.cmdEsci = New System.Windows.Forms.Button()
      Me.cmdNuova = New System.Windows.Forms.Button()
      Me.cmdModifica = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.mcCalendario = New System.Windows.Forms.MonthCalendar()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
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
      Me.ImageList1.Images.SetKeyName(8, "")
      Me.ImageList1.Images.SetKeyName(9, "")
      '
      'DataGrid1
      '
      Me.DataGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.GridLineColor = System.Drawing.Color.Transparent
      Me.DataGrid1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 0)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(604, 464)
      Me.DataGrid1.TabIndex = 0
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = ""
      '
      'cmdElimina
      '
      Me.cmdElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdElimina.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdElimina.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdElimina.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdElimina.ForeColor = System.Drawing.Color.White
      Me.cmdElimina.Location = New System.Drawing.Point(524, 480)
      Me.cmdElimina.Name = "cmdElimina"
      Me.cmdElimina.Size = New System.Drawing.Size(160, 40)
      Me.cmdElimina.TabIndex = 4
      Me.cmdElimina.Text = "E&LIMINA"
      Me.cmdElimina.UseVisualStyleBackColor = False
      '
      'cmdEsci
      '
      Me.cmdEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdEsci.BackColor = System.Drawing.Color.LightCoral
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEsci.ForeColor = System.Drawing.Color.White
      Me.cmdEsci.Location = New System.Drawing.Point(692, 480)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(160, 40)
      Me.cmdEsci.TabIndex = 5
      Me.cmdEsci.Text = "&ESCI"
      Me.cmdEsci.UseVisualStyleBackColor = False
      '
      'cmdNuova
      '
      Me.cmdNuova.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNuova.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdNuova.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNuova.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNuova.ForeColor = System.Drawing.Color.White
      Me.cmdNuova.Location = New System.Drawing.Point(188, 480)
      Me.cmdNuova.Name = "cmdNuova"
      Me.cmdNuova.Size = New System.Drawing.Size(160, 40)
      Me.cmdNuova.TabIndex = 2
      Me.cmdNuova.Text = "&NUOVA"
      Me.cmdNuova.UseVisualStyleBackColor = False
      '
      'cmdModifica
      '
      Me.cmdModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdModifica.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdModifica.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdModifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdModifica.ForeColor = System.Drawing.Color.White
      Me.cmdModifica.Location = New System.Drawing.Point(356, 480)
      Me.cmdModifica.Name = "cmdModifica"
      Me.cmdModifica.Size = New System.Drawing.Size(160, 40)
      Me.cmdModifica.TabIndex = 3
      Me.cmdModifica.Text = "&MODIFICA"
      Me.cmdModifica.UseVisualStyleBackColor = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.BackColor = System.Drawing.Color.White
      Me.Panel1.Controls.Add(Me.mcCalendario)
      Me.Panel1.Location = New System.Drawing.Point(604, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(264, 464)
      Me.Panel1.TabIndex = 6
      '
      'mcCalendario
      '
      Me.mcCalendario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.mcCalendario.CalendarDimensions = New System.Drawing.Size(1, 3)
      Me.mcCalendario.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.mcCalendario.ForeColor = System.Drawing.Color.Black
      Me.mcCalendario.Location = New System.Drawing.Point(16, 8)
      Me.mcCalendario.Name = "mcCalendario"
      Me.mcCalendario.TabIndex = 2
      '
      'frmElencoPren
      '
      Me.AcceptButton = Me.cmdNuova
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdEsci
      Me.ClientSize = New System.Drawing.Size(863, 533)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.cmdNuova)
      Me.Controls.Add(Me.cmdModifica)
      Me.Controls.Add(Me.cmdElimina)
      Me.Controls.Add(Me.cmdEsci)
      Me.Controls.Add(Me.DataGrid1)
      Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmElencoPren"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Elenco"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub RegistraModifica()
      Try
         Dim strDescrizione As String

         ' Registra l'operazione.
         Dim Cliente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
         strDescrizione = "(" & Cliente & ")"

         ' Registra loperazione efettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Modifica, strDescrizione, MODULO_GESTIONE_PREN_TAVOLI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub LeggiDati(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(1, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Sub LeggiNumPagine(ByVal tabella As String)
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Data = #{1}#", tabella, dataSelezionata)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se è da chiudere.
         If closeOnExit Then cn.Close()

         ' Ottiene il numero di pagine.
         numPagine = (numRecord + DIMENSIONE_PAGINA - 1) \ DIMENSIONE_PAGINA

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

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

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String
         Dim strDescrizione As String

         Dim Cliente As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

         ' Registra l'operazione.
         strDescrizione = " (" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & _
                          " - Per " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3) & _
                          " il " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0) & _
                          " alle " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) & _
                          " / " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5) & _
                          " - Tavolo: " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) & ")"

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare la prenotazione del cliente """ & Cliente & _
                                 """?" & vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

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
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_GESTIONE_PREN_TAVOLI)

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

      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(NomeTabella)

         ' Collega la tabella clienti al controllo griglia dati.
         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(pagCorrente, sql)

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TitoloFinestra)

         ' Applica il grassetto ai giorni del calendario dove ci sono prenotazioni.
         LeggiPren(TAB_PREN)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_PREN)) = True Then
                  Exit Sub
               End If
            End If
         End If

         Dim frm As New frmVCPren
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1))
         Else
            DataGrid1.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n° totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonnePren(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 0
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Data
         'Dim dataStyle As New DataGridTextBoxColumn
         'dataStyle.MappingName = "Data"
         'dataStyle.HeaderText = "Data"
         'dataStyle.Width = 80
         'dataStyle.NullText = ""
         'dataStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(dataStyle)
         ' Cliente
         Dim clienteStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         clienteStyle.MappingName = "Cliente"
         clienteStyle.HeaderText = "Cliente"
         clienteStyle.Width = 160
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(clienteStyle)
         ' Risorsa
         Dim risorsaStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         risorsaStyle.MappingName = "DescrizioneRisorsa"
         risorsaStyle.HeaderText = "Tavolo"
         risorsaStyle.Width = 80
         risorsaStyle.NullText = ""
         risorsaStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(risorsaStyle)
         ' Persone
         Dim personeStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         personeStyle.MappingName = "Persone"
         personeStyle.HeaderText = "Persone"
         personeStyle.Width = 80
         personeStyle.NullText = ""
         personeStyle.Alignment = HorizontalAlignment.Right
         personeStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(personeStyle)
         ' OraInizio
         Dim oraInizioStyle As New DataGridTextBoxColumn
         oraInizioStyle.MappingName = "OraInizio"
         oraInizioStyle.HeaderText = "Dalle"
         oraInizioStyle.Width = 65
         oraInizioStyle.NullText = ""
         oraInizioStyle.Alignment = HorizontalAlignment.Right
         oraInizioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraInizioStyle)
         ' OraFine
         Dim oraFineStyle As New DataGridTextBoxColumn
         oraFineStyle.MappingName = "OraFine"
         oraFineStyle.HeaderText = "Alle"
         oraFineStyle.Width = 65
         oraFineStyle.NullText = ""
         oraFineStyle.Alignment = HorizontalAlignment.Right
         oraFineStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraFineStyle)
         ' Colore
         Dim coloreStyle As New CellaColorata(DataGrid1)
         coloreStyle.MappingName = "Colore"
         coloreStyle.HeaderText = "Colore"
         coloreStyle.Width = 70
         coloreStyle.NullText = ""
         coloreStyle.TextBox.BackColor = Color.White
         coloreStyle.TextBox.ForeColor = Color.White
         gridStyle.GridColumnStyles.Add(coloreStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati()
      Try
         sql = String.Format("SELECT * FROM {0} WHERE Data = #{1}# ORDER BY Data ASC", NomeTabella, dataSelezionata)

         ' Legge i dati e ottiene il numero totale dei record.
         LeggiDati(NomeTabella, sql)

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TitoloFinestra)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiIdRisorsa(ByVal tabella As String, ByVal descrizione As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & descrizione & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Id")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

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

   Public Function LeggiPren(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT Data FROM " & tabella & " GROUP BY Data ORDER BY Data ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         mcCalendario.RemoveAllBoldedDates()

         Do While dr.Read()
            mcCalendario.AddBoldedDate(dr.Item("Data"))
            mcCalendario.UpdateBoldedDates()
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub frmElencoPren_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonnePren(TAB_PREN)

         ' Crea la stringa di selezione dei dati..
         dataSelezionata = FormattaData(Today.ToShortDateString, False)
         FiltraDati()

         ' Applica il grassetto ai giorni del calendario dove ci sono prenotazioni.
         LeggiPren(TAB_PREN)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_GESTIONE_PREN_TAVOLI, MODULO_GESTIONE_PREN_TAVOLI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmElencoPren_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Distrugge l'oggetto e libera le risorse.
         g_frmVCPren.Dispose()
         g_frmVCPren = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_GESTIONE_PREN_TAVOLI, MODULO_GESTIONE_PREN_TAVOLI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      RegistraModifica()

      ' Apre la finestra Cliente per la modifica dei dati.
      ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
   End Sub

   Private Sub mcCalendario_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcCalendario.DateChanged
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      Application.DoEvents()
      dataSelezionata = FormattaData(sender.SelectionStart, False)
      FiltraDati()
   End Sub

   Private Sub cmdNuova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuova.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_GESTIONE_PREN_TAVOLI, MODULO_GESTIONE_PREN_TAVOLI)

      ' Apre la finestra per l'inserimento di nuovi dati.
      ApriDati("")
   End Sub

   Private Sub cmdModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModifica.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If numRecord <> 0 Then
         RegistraModifica()

         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      End If
   End Sub

   Private Sub cmdElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdElimina.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If numRecord <> 0 Then
         Dim nomeTavolo As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)

         ' Elimina il valore selezionato.
         EliminaDati(NomeTabella, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         ' Cancella il colore di eventuali prenotazioni non più valide.
         g_frmVCTavoli.CancellaColorePren(LeggiIdRisorsa(ANA_TAVOLI, nomeTavolo))
      End If
   End Sub

   Private Sub cmdEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

End Class
