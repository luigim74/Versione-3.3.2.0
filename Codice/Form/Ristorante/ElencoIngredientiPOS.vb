' Nome form:            ElencoIngredientiPOS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       03/11/2015
' Data ultima modifica: 03/11/2015
' Descrizione:          Elenco ingredienti dei piatti.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoIngredientiPOS
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Const DIMENSIONE_PAGINA As Integer = 1000

   Const ANA_INGREDIENTI As String = "Ingredienti"

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

   Dim idPiattoSelezionato As String
   Dim descrizionePiatto As String

   Dim titoloFinestra As String
   Dim CFormatta As New ClsFormatta

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents dgElencoIngredienti As DataGrid
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button

#End Region

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal idPiatto As String, ByVal descrizione As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      idPiattoSelezionato = idPiatto
      descrizionePiatto = descrizione

      titoloFinestra = "Elenco Ingredienti " & descrizionePiatto

      dt = ds.Tables.Add(ANA_INGREDIENTI)

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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoIngredientiPOS))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.dgElencoIngredienti = New System.Windows.Forms.DataGrid()
      CType(Me.dgElencoIngredienti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "1a9e92d9-0dbf-4c02-b78b-ee8ce7ae6166"
      Me.eui_cmdOk.Location = New System.Drawing.Point(617, 442)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 1
      Me.eui_cmdOk.Text = "&OK"
      '
      'dgElencoIngredienti
      '
      Me.dgElencoIngredienti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgElencoIngredienti.BackgroundColor = System.Drawing.Color.White
      Me.dgElencoIngredienti.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgElencoIngredienti.CaptionBackColor = System.Drawing.Color.Gray
      Me.dgElencoIngredienti.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgElencoIngredienti.CaptionForeColor = System.Drawing.Color.White
      Me.dgElencoIngredienti.DataMember = ""
      Me.dgElencoIngredienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgElencoIngredienti.GridLineColor = System.Drawing.Color.Transparent
      Me.dgElencoIngredienti.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgElencoIngredienti.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dgElencoIngredienti.Location = New System.Drawing.Point(0, 0)
      Me.dgElencoIngredienti.Name = "dgElencoIngredienti"
      Me.dgElencoIngredienti.ReadOnly = True
      Me.dgElencoIngredienti.Size = New System.Drawing.Size(756, 426)
      Me.dgElencoIngredienti.TabIndex = 0
      '
      'ElencoIngredientiPOS
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(754, 508)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.dgElencoIngredienti)
      Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ElencoIngredientiPOS"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Elenco Ingredienti"
      CType(Me.dgElencoIngredienti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Public Sub LeggiDati(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         dgElencoIngredienti.DataSource = dt

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
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Id_Piatto = {1}", tabella, idPiattoSelezionato)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
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

   Public Sub AggiornaDati()
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(ANA_INGREDIENTI)

         ' Collega la tabella clienti al controllo griglia dati.
         dgElencoIngredienti.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(pagCorrente, sql)

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(titoloFinestra)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            dgElencoIngredienti.CaptionText = Strings.UCase(dgElencoIngredienti.Item(dgElencoIngredienti.CurrentCell.RowNumber, 1))
         Else
            dgElencoIngredienti.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " - (n∞ totale: " & numRecord & ") - Costo di produzione del piatto: Ä " & CFormatta.FormattaEuro(SommaColonnaDouble(dgElencoIngredienti, 4, numRecord))
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(dgElencoIngredienti, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 80
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(dgElencoIngredienti, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 300
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Unit‡ di misura.
         Dim umStyle As New DataGridTextBoxColumn
         umStyle.MappingName = "Unit‡Misura"
         umStyle.HeaderText = "U.M."
         umStyle.Width = 80
         umStyle.NullText = ""
         umStyle.Alignment = HorizontalAlignment.Center
         umStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(umStyle)
         ' Quantit‡
         Dim quantit‡Style As New DataGridTextBoxColumn
         quantit‡Style.MappingName = "Quantit‡"
         quantit‡Style.HeaderText = "Quantit‡"
         quantit‡Style.Width = 120
         quantit‡Style.NullText = ""
         quantit‡Style.Format = "##,##0.000"
         quantit‡Style.Alignment = HorizontalAlignment.Right
         quantit‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(quantit‡Style)
         ' Costo
         Dim costoStyle As New ColonnaColorata(dgElencoIngredienti, Color.White, Color.Red)
         costoStyle.MappingName = "Costo"
         costoStyle.HeaderText = "Costo"
         costoStyle.Width = 120
         costoStyle.NullText = ""
         costoStyle.Format = "##,##0.00"
         costoStyle.Alignment = HorizontalAlignment.Right
         costoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(costoStyle)

         dgElencoIngredienti.TableStyles.Clear()
         dgElencoIngredienti.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati()
      Try
         sql = String.Format("SELECT * FROM {0} WHERE Id_Piatto = {1} ORDER BY Id ASC", ANA_INGREDIENTI, idPiattoSelezionato)

         ' Legge i dati e ottiene il numero totale dei record.
         LeggiDati(ANA_INGREDIENTI, sql)

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(titoloFinestra)

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

   Private Sub ElencoIngredientiPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Crea le colonne della griglia dati.
         CreaColonne(ANA_INGREDIENTI)

         FiltraDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub dgElencoIngredienti_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgElencoIngredienti.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

End Class
