#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            ElencoNoleggi
' Autore:               Luigi Montana, Montana Software
' Data creazione:       27/02/2021
' Data ultima modifica: 03/07/2021
' Descrizione:          Elenco Noleggi.
' Note:

' Elenco Attivita:

' ******************************************************************
#End Region

Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Data.OleDb

Public Class ElencoNoleggi
   Inherits System.Windows.Forms.Form

   Public Const TAB_NOLEGGI As String = "Noleggi"
   Const TAB_DETTAGLI_NOLEGGI As String = "DettagliNoleggi"
   Const TITOLO_FINESTRA As String = "Elenco Noleggi"

   Public Const COLONNA_ID_DOC As Short = 0
   Const COLONNA_CLIENTE As Short = 1
   Const COLONNA_CAUSALE As Short = 2
   Const COLONNA_DATA_INIZIO As Short = 3
   Const COLONNA_DATA_FINE As Short = 4
   Const COLONNA_TOTALE_GIORNI As Short = 5
   Const COLONNA_STATO As Short = 6
   Const COLONNA_TOTALE As Short = 7
   Const COLONNA_CODICE_BARRE As Short = 8
   Const COLONNA_CONTABILIZZATO As Short = 9
   Const COLONNA_ID_CLIENTE As Short = 10

   ' TODO_A: Modificare.
   Const STATO_DOC_EMESSO As String = "Emesso"
   Const STATO_DOC_EMESSO_STAMPATO As String = "Emesso e stampato"
   Const STATO_DOC_ANNULLATO As String = "Annullato"
   Public Const STATO_DOC_EMESSO_XML As String = "Emesso in XML"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   ' Numero di record.
   Dim numRecord As Integer
   Dim numRecordArticoli As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim dtArticoli As DataTable
   Dim sql As String
   Public repSql As String

   Private DatiConfig As AppConfig
   Private CFormatta As New ClsFormatta

   ' TODO_A: Modificare.
   Private AArticoli As New Articoli

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_txtTestoRicerca As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbCampoRicerca As Elegant.Ui.ComboBox
   Friend WithEvents eui_txtTotale As Elegant.Ui.TextBox
   Friend WithEvents DataGridView1 As DataGridView
   Friend WithEvents lblIntestazione As Label
   Friend WithEvents DataGridView2 As DataGridView
   Friend WithEvents Panel1 As Panel
   Friend WithEvents Panel2 As Panel
   Friend WithEvents Panel3 As Panel
   Friend WithEvents Label1 As Label
   Public filtroDati As String

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_NOLEGGI)
      dtArticoli = ds.Tables.Add(TAB_DETTAGLI_NOLEGGI)

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

   'NOTA: la procedura che segue Ë richiesta da Progettazione Windows Form.
   'PuÚ essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents lblCampo As System.Windows.Forms.Label
   Friend WithEvents lblTesto As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoNoleggi))
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.eui_cmbCampoRicerca = New Elegant.Ui.ComboBox()
      Me.eui_txtTestoRicerca = New Elegant.Ui.TextBox()
      Me.lblCampo = New System.Windows.Forms.Label()
      Me.lblTesto = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.eui_txtTotale = New Elegant.Ui.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.DataGridView2 = New System.Windows.Forms.DataGridView()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel3.SuspendLayout()
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
      Me.ImageList1.Images.SetKeyName(10, "")
      Me.ImageList1.Images.SetKeyName(11, "")
      Me.ImageList1.Images.SetKeyName(12, "")
      Me.ImageList1.Images.SetKeyName(13, "")
      Me.ImageList1.Images.SetKeyName(14, "")
      Me.ImageList1.Images.SetKeyName(15, "")
      Me.ImageList1.Images.SetKeyName(16, "")
      Me.ImageList1.Images.SetKeyName(17, "")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Controls.Add(Me.eui_cmbCampoRicerca)
      Me.Panel1.Controls.Add(Me.eui_txtTestoRicerca)
      Me.Panel1.Controls.Add(Me.lblCampo)
      Me.Panel1.Controls.Add(Me.lblTesto)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(714, 63)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.Color.White
      Me.lblIntestazione.Location = New System.Drawing.Point(2, 39)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(182, 16)
      Me.lblIntestazione.TabIndex = 55673
      Me.lblIntestazione.Text = "INTESTAZIONE ELENCO"
      '
      'eui_cmbCampoRicerca
      '
      Me.eui_cmbCampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbCampoRicerca.Editable = False
      Me.eui_cmbCampoRicerca.FormattingEnabled = False
      Me.eui_cmbCampoRicerca.Id = "6e85627c-5d62-4010-971d-8de73ae45222"
      Me.eui_cmbCampoRicerca.Location = New System.Drawing.Point(570, 7)
      Me.eui_cmbCampoRicerca.Name = "eui_cmbCampoRicerca"
      Me.eui_cmbCampoRicerca.Size = New System.Drawing.Size(134, 21)
      Me.eui_cmbCampoRicerca.TabIndex = 1
      Me.eui_cmbCampoRicerca.TextEditorWidth = 115
      '
      'eui_txtTestoRicerca
      '
      Me.eui_txtTestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTestoRicerca.Id = "bb5a861b-2fcf-4573-8803-b69d17c915f7"
      Me.eui_txtTestoRicerca.Location = New System.Drawing.Point(114, 7)
      Me.eui_txtTestoRicerca.Name = "eui_txtTestoRicerca"
      Me.eui_txtTestoRicerca.Size = New System.Drawing.Size(353, 21)
      Me.eui_txtTestoRicerca.TabIndex = 0
      Me.eui_txtTestoRicerca.TextEditorWidth = 529
      '
      'lblCampo
      '
      Me.lblCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCampo.AutoSize = True
      Me.lblCampo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCampo.ForeColor = System.Drawing.Color.White
      Me.lblCampo.Location = New System.Drawing.Point(481, 8)
      Me.lblCampo.Name = "lblCampo"
      Me.lblCampo.Size = New System.Drawing.Size(85, 15)
      Me.lblCampo.TabIndex = 8
      Me.lblCampo.Text = "Ricerca per:"
      '
      'lblTesto
      '
      Me.lblTesto.AutoSize = True
      Me.lblTesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTesto.ForeColor = System.Drawing.Color.White
      Me.lblTesto.Location = New System.Drawing.Point(2, 8)
      Me.lblTesto.Name = "lblTesto"
      Me.lblTesto.Size = New System.Drawing.Size(110, 15)
      Me.lblTesto.TabIndex = 6
      Me.lblTesto.Text = "Testo di ricerca:"
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Risorse.rpt"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.eui_txtTotale)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 422)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(714, 40)
      Me.Panel2.TabIndex = 13
      '
      'eui_txtTotale
      '
      Me.eui_txtTotale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotale.Id = "0d65cebb-55d0-4baf-aa53-aa5d7ed71ce2"
      Me.eui_txtTotale.Location = New System.Drawing.Point(570, 10)
      Me.eui_txtTotale.Name = "eui_txtTotale"
      Me.eui_txtTotale.ReadOnly = True
      Me.eui_txtTotale.Size = New System.Drawing.Size(134, 21)
      Me.eui_txtTotale.TabIndex = 0
      Me.eui_txtTotale.Text = "1.000"
      Me.eui_txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotale.TextEditorWidth = 128
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.White
      Me.Label6.Location = New System.Drawing.Point(410, 12)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(156, 15)
      Me.Label6.TabIndex = 16
      Me.Label6.Text = "Totale importo noleggi:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.GridColor = System.Drawing.Color.LightGray
      Me.DataGridView1.Location = New System.Drawing.Point(0, 63)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.Size = New System.Drawing.Size(714, 162)
      Me.DataGridView1.TabIndex = 14
      '
      'DataGridView2
      '
      Me.DataGridView2.AllowUserToAddRows = False
      Me.DataGridView2.AllowUserToDeleteRows = False
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
      Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView2.GridColor = System.Drawing.Color.LightGray
      Me.DataGridView2.Location = New System.Drawing.Point(0, 255)
      Me.DataGridView2.Name = "DataGridView2"
      Me.DataGridView2.ReadOnly = True
      Me.DataGridView2.Size = New System.Drawing.Size(714, 165)
      Me.DataGridView2.TabIndex = 15
      '
      'Panel3
      '
      Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel3.BackColor = System.Drawing.Color.Gray
      Me.Panel3.Controls.Add(Me.Label1)
      Me.Panel3.Location = New System.Drawing.Point(0, 227)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(714, 26)
      Me.Panel3.TabIndex = 16
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(3, 6)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(170, 16)
      Me.Label1.TabIndex = 55674
      Me.Label1.Text = "ARTICOLI NOLEGGIATI"
      '
      'ElencoNoleggi
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(714, 462)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.DataGridView2)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoNoleggi"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Noleggi"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   ' TODO_A: Modificare.
#Region "Scarico articoli"

   Private Function SalvaDati(ByVal tabella As String, ByVal id As Integer, ByVal giacenza As Double,
                              ByVal carico As Double, ByVal scarico As Double,
                              ByVal situazione As Double, ByVal prezzo As String,
                              ByVal valCarico As Double, ByVal valScarico As Double, ByVal valAttuale As Double) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Giacenza = @Giacenza, " &
                             "Carico = @Carico, " &
                             "Scarico = @Scarico, " &
                             "SituazioneScorta = @SituazioneScorta, " &
                             "ValCarico = @ValCarico, " &
                             "valScarico = @ValScarico, " &
                             "ValAttuale = @ValAttuale, " &
                             "PrezzoAcquisto = @Prezzo " &
                             "WHERE Id = {1}",
                              tabella,
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

   Private Function SalvaMovimentiMag(ByVal tabella As String, ByVal id_Articolo As Integer, ByVal data As String,
                                      ByVal codice As String, ByVal descrizione As String,
                                      ByVal carico As Double, ByVal scarico As Double,
                                      ByVal causale As String, ByVal prezzo As String,
                                      ByVal fornitore As String, ByVal magazzino As String) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Id_Articolo, Data, Codice, Descrizione, PrezzoAcquisto, " &
                                              "Carico, Scarico, Causale, Fornitore, Magazzino) " &
                                       "VALUES(@Id_Articolo, @Data, @Codice, @Descrizione, @PrezzoAcquisto, " &
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

   Private Function CalcolaScarico(ByVal scarico As Double, ByVal nuovoScarico As Double) As Double
      Try
         Return (scarico - nuovoScarico)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub RipristinaIngredientiScaricati()
      Try
         Dim idArticolo As Integer
         Dim qt‡Carico As Double
         Dim IdPiatto As Integer = 0
         Dim qt‡Piatto As Integer = 0
         Dim descrizione As String
         Dim rifDoc As Integer
         Dim CausaleMovMag As String = "Documento annullato"

         Dim listaPiatti As New ListBox
         Dim listaIdPiatti As New ListBox
         Dim listaIngredienti As New ListBox

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGridView1.Item(COLONNA_ID_DOC, DataGridView1.CurrentCell.RowIndex).Value

         cn.Open()

         ' Legge i dati di dettaglio (comande).
         Dim cmdComande As New OleDbCommand("SELECT * FROM DettagliDoc WHERE RifDoc = " & rifDoc & " ORDER BY Id ASC", cn)
         Dim drComande As OleDbDataReader = cmdComande.ExecuteReader()
         Do While drComande.Read
            ' Ottiene la quantit‡ del piatto.
            qt‡Piatto = Convert.ToInt32(drComande.Item("Quantit‡"))
            descrizione = drComande.Item("Descrizione")
            listaPiatti.Items.Add(qt‡Piatto & "/" & descrizione)
         Loop

         cmdComande.Dispose()
         drComande.Close()

         Dim i As Integer
         For i = 0 To listaPiatti.Items.Count - 1
            Dim piatto As String = listaPiatti.Items.Item(i)
            Dim datiPiatto As String()
            datiPiatto = piatto.Split("/")

            ' Legge i dati di dettaglio (comande).
            Dim cmdIdPiatto As New OleDbCommand("SELECT * FROM Piatti WHERE Descrizione = '" & datiPiatto(1) & "'", cn)
            Dim drIdPiatto As OleDbDataReader = cmdIdPiatto.ExecuteReader()
            Do While drIdPiatto.Read
               ' Ottiene l'Id del piatto.
               listaIdPiatti.Items.Add(drIdPiatto.Item("Id"))
            Loop

            cmdIdPiatto.Dispose()
            drIdPiatto.Close()
         Next

         Dim y As Integer
         For y = 0 To listaIdPiatti.Items.Count - 1
            ' Legge i dati di dettaglio (comande).
            Dim cmdIngrediente As New OleDbCommand("SELECT * FROM Ingredienti WHERE Id_Piatto = " & listaIdPiatti.Items.Item(y), cn)
            Dim drIngrediente As OleDbDataReader = cmdIngrediente.ExecuteReader()

            Do While drIngrediente.Read
               ' Ottiene la quantit‡ del piatto.
               idArticolo = Convert.ToInt32(drIngrediente.Item("Id_Articolo"))
               qt‡Carico = drIngrediente.Item("Quantit‡")
               listaIngredienti.Items.Add(idArticolo & "/" & qt‡Carico)

               AArticoli.LeggiDati("Articoli", idArticolo)
               Dim nuovaGiacenza As Double = (AArticoli.Giacenza + qt‡Carico)
               Dim Carico As Double = 0
               Dim Scarico As Double = 0
               Dim situazioneScorta As Double = 0
               Dim valCarico As Double = 0
               Dim valScarico As Double = 0
               Dim valAttuale As Double = 0

               Scarico = CalcolaScarico(AArticoli.Scarico, qt‡Carico)
               Carico = AArticoli.Carico

               If AArticoli.ScortaMin > 0 Then
                  situazioneScorta = (nuovaGiacenza - AArticoli.ScortaMin)
               Else
                  situazioneScorta = 0
               End If

               ' Calcola i progressivi.
               If AArticoli.PrezzoAcquisto <> "" Then
                  If IsNumeric(AArticoli.PrezzoAcquisto) = True Then
                     If Carico <> 0 Then
                        valCarico = CFormatta.FormattaEuro(CalcolaValore(CDec(AArticoli.PrezzoAcquisto), Carico))
                     Else
                        valCarico = 0
                     End If

                     If Scarico <> 0 Then
                        valScarico = CFormatta.FormattaEuro(CalcolaValore(CDec(AArticoli.PrezzoAcquisto), Scarico))
                     Else
                        valScarico = 0
                     End If

                     If nuovaGiacenza <> 0 Then
                        valAttuale = CFormatta.FormattaEuro(CalcolaValore(CDec(AArticoli.PrezzoAcquisto), nuovaGiacenza))
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
               SalvaDati("Articoli", idArticolo, nuovaGiacenza,
                          Carico, Scarico, situazioneScorta, AArticoli.PrezzoAcquisto,
                          valCarico, valScarico, valAttuale)

               ' Verifica se Ë un carico o scarico.
               Dim qt‡Caricata As Double = 0
               Dim qt‡Scaricata As Double = 0
               qt‡Scaricata = 0
               qt‡Caricata = qt‡Carico

               Dim data As Date = Now.Today

               ' Salva i dati per i movimenti di magazzino.
               SalvaMovimentiMag("MovMagazzino", idArticolo, data.ToShortDateString, AArticoli.Codice, AArticoli.Descrizione,
                                  qt‡Caricata, qt‡Scaricata, CausaleMovMag, AArticoli.PrezzoAcquisto,
                                  AArticoli.Fornitore, AArticoli.Magazzino)

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
            Loop

            cmdIngrediente.Dispose()
            drIngrediente.Close()
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      Finally
         cn.Close()
      End Try
   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("FiltroNoleggi") <> "" Then
            filtroDati = DatiConfig.GetValue("FiltroNoleggi")
         Else
            filtroDati = "Tutti"
         End If

         If DatiConfig.GetValue("WSNoleggi") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSNoleggi") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("ANoleggi") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("ANoleggi"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LNoleggi") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LNoleggi"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("NoleggiX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("NoleggiX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("NoleggiY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("NoleggiY")))
            End If

            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         DatiConfig.SetValue("FiltroNoleggi", filtroDati)
         DatiConfig.SetValue("WSNoleggi", Me.WindowState)
         DatiConfig.SetValue("NoleggiX", Me.Location.X)
         DatiConfig.SetValue("NoleggiY", Me.Location.Y)
         DatiConfig.SetValue("ANoleggi", Me.Height)
         DatiConfig.SetValue("LNoleggi", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Documenti
               If operatore.ContDoc = VALORE_LETTURA Then

                  ' Modifica.
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Annulla.Enabled = False
                  g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
                  g_frmMain.eui_Strumenti_Esporta.Enabled = False
                  g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
                  g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False

                  ' Sospesi.
                  g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = False
                  g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = False
                  g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = False
                  g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = False

               Else
                  ' Modifica.
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Annulla.Enabled = True
                  g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
                  g_frmMain.eui_Strumenti_Esporta.Enabled = True
                  g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
                  g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True

                  ' Sospesi.
                  g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = True
                  g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = True
                  g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = True
                  g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = True
               End If

         End Select

         Return g_frmMain.eui_Strumenti_Modifica.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   ' TODO_A: Modificare.
   Private Sub RipristinaStatistiche()
      Try
         Dim sql As String
         Dim rifDoc As String

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGridView1.Item(COLONNA_ID_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE IdCategoria = '{1}'", "Statistiche", rifDoc)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

         If IsNothing(g_frmStatistiche) = False Then
            ' Aggiorna la griglia dati.
            g_frmStatistiche.AggiornaDati()

            ' Somma i valori della colonna Quantit‡.
            g_frmStatistiche.txtTotQuantit‡.Text = CFormatta.FormattaNumero(SommaColonna(g_frmStatistiche.DataGrid1, g_frmStatistiche.COLONNA_QTA, g_frmStatistiche.numRecord))

            ' Somma i valori della colonna Importo.
            g_frmStatistiche.txtTotImporto.Text = CFormatta.FormattaEuro(SommaColonna(g_frmStatistiche.DataGrid1, g_frmStatistiche.COLONNA_IMPORTO, g_frmStatistiche.numRecord))

         End If

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

   ' TODO_A: Modificare.
   Private Sub EliminaDettagliDocumento()
      Try
         Dim rifDoc As Integer

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGridView1.Item(COLONNA_ID_DOC, DataGridView1.CurrentCell.RowIndex).Value

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE RifDoc = {1}", "DettagliDoc", rifDoc)

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

   ' TODO_A: Modificare.
   Private Sub EliminaDocumento()
      Try
         Dim rifDoc As Integer

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGridView1.Item(COLONNA_ID_DOC, DataGridView1.CurrentCell.RowIndex).Value

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE Id = {1}", "Documenti", rifDoc)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

         ' Aggiorna la lista dati.
         AggiornaDati()

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

   ' TODO_A: Modificare.
   Public Sub EliminaDati()
      'Dim Data As String = Convert.ToDateTime(DataGridView1.Item(COLONNA_DATA_DOC, DataGridView1.CurrentCell.RowIndex).Value).ToShortDateString
      'Dim Documento As String = DataGridView1.Item(COLONNA_TIPO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
      'Dim Numero As String = DataGridView1.Item(COLONNA_NUMERO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
      'Dim Importo As String = DataGridView1.Item(COLONNA_IMPORTO_TOTALE, DataGridView1.CurrentCell.RowIndex).Value.ToString

      '' Chiede conferma per l'eliminazione.
      'Dim risposta As Integer
      'risposta = MessageBox.Show("Si desidera eliminare il documento """ & Documento & " n. " & Numero & " del " & Data & """? " &
      '                           "Confermando l'operazione Non sar‡ pi˘ possibile recuperare i dati.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      'If risposta = vbYes Then
      '   EliminaDettagliDocumento()
      '   EliminaDocumento()

      '   ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
      '   AttivaDisattivaSospeso()
      '   AttivaDisattivaPassaSospeso()
      '   AttivaDisattivaAnnullaSospeso()
      '   AttivaDisattivaBuoni()
      '   AttivaDisattivaAnnullaDoc()
      '   AttivaDisattivaEsportaFatturaElettronica()

      '   ' Registra loperazione effettuata dall'operatore identificato.
      '   Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & CFormatta.FormattaEuro(Importo) & ")"
      '   g_frmMain.RegistraOperazione(TipoOperazione.AnnullaDoc, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

      'End If
   End Sub

   ' TODO_A: Modificare.
   Public Sub DuplicaNoleggio()
      Try
         Dim Risposta As Short
         Dim id As String = DataGridView1.Item(COLONNA_ID_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
         'Dim numero As String = DataGridView1.Item(COLONNA_NUMERO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
         'Dim data As String = Convert.ToDateTime(DataGridView1.Item(COLONNA_DATA_DOC, DataGridView1.CurrentCell.RowIndex).Value).ToShortDateString
         'Dim tipoDoc As String = DataGridView1.Item(COLONNA_TIPO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString

         '' Chiede conferma per l'eliminazione.
         'Risposta = MessageBox.Show("Si desidera duplicare il documento """ & tipoDoc & " N. " & numero & " del " & data & """?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If Risposta = MsgBoxResult.Yes Then

            ' Dati documento.
            Dim Doc As New Documenti
            With Doc
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_NOLEGGI, id)

               .Ora = TimeOfDay.Hour.ToString & ":" & FormattaMinuti(TimeOfDay.Minute.ToString)
               .Stato = "Bozza"
               .Chiuso = "No"

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_NOLEGGI)
            End With

            ' Leggo l'ultimo id del documento duplicato.
            Dim ultimoId As Integer = LeggiUltimoRecord(TAB_NOLEGGI)

            ' Dati dettagli documento.
            Dim DettagliDoc As New DettagliNoleggi
            With DettagliDoc
               ' Dichiara un oggetto connessione.
               Dim cn As New OleDbConnection(ConnString)
               cn.Open()

               Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_NOLEGGI & " WHERE RifDoc = " & id & " ORDER BY Id ASC", cn)
               Dim dr As OleDbDataReader = cmd.ExecuteReader()

               ' Legge i dati del record selezionato nella lista.
               Do While dr.Read()
                  .RifNoleggio = ultimoId

                  ' Codice.
                  If IsDBNull(dr.Item("CodiceArticolo")) = False Then
                     .CodiceArticolo = dr.Item("CodiceArticolo")
                  Else
                     .CodiceArticolo = String.Empty
                  End If

                  ' Descrizione.
                  If IsDBNull(dr.Item("Descrizione")) = False Then
                     .Descrizione = dr.Item("Descrizione")
                  Else
                     .Descrizione = String.Empty
                  End If

                  ' Unit‡ di misura.
                  If IsDBNull(dr.Item("Unit‡Misura")) = False Then
                     .Unit‡Misura = dr.Item("Unit‡Misura")
                  Else
                     .Unit‡Misura = String.Empty
                  End If

                  ' Quantit‡.
                  If IsDBNull(dr.Item("Quantit‡")) = False Then
                     .Quantit‡ = dr.Item("Quantit‡")
                  Else
                     .Quantit‡ = VALORE_ZERO
                  End If

                  ' Valore Unitario.
                  If IsDBNull(dr.Item("ValoreUnitario")) = False Then
                     .ValoreUnitario = dr.Item("ValoreUnitario")
                  Else
                     .ValoreUnitario = VALORE_ZERO
                  End If

                  ' Importo.
                  If IsDBNull(dr.Item("ImportoNetto")) = False Then
                     .ImportoNetto = dr.Item("ImportoNetto")
                  Else
                     .ImportoNetto = VALORE_ZERO
                  End If

                  ' Aliquota Iva.
                  If IsDBNull(dr.Item("AliquotaIva")) = False Then
                     .AliquotaIva = dr.Item("AliquotaIva")
                  Else
                     .AliquotaIva = "0"
                  End If

                  ' Categoria.
                  If IsDBNull(dr.Item("Categoria")) = False Then
                     .Categoria = dr.Item("Categoria")
                  Else
                     .Categoria = String.Empty
                  End If

                  ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
                  .InserisciDati(TAB_DETTAGLI_NOLEGGI)
               Loop
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDati(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         DataGridView1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(1, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub LeggiNumPagine(ByVal tabella As String)
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("Select COUNT(*) FROM {0}", tabella)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
         If closeOnExit Then cn.Close()

         If eui_txtTestoRicerca.Text <> "" Then
            numPagine = 1
         Else
            ' Ottiene il numero di pagine.
            numPagine = (numRecord + DIM_PAGINA_GRANDE - 1) \ DIM_PAGINA_GRANDE 'dimPagina
         End If

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

         ' Abilita/disabilita i pulsanti.
         'Primo.Enabled = (n > 1)
         'Precedente.Enabled = (n > 1)
         'Successivo.Enabled = (n < numPagine)
         'Ultimo.Enabled = (n < numPagine)

      Catch ex As Exception
         '' Si verifica quando la griglia viene aperta in modalit‡ Massima o Minima.
         'If ex.Message = "Testo del comando non impostato per l'oggetto comando." Then
         '   Exit Try
         'End If

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub AggiornaDati()
      Try
         If eui_txtTestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGridView1.DataSource = dt

            FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_NOLEGGI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGridView1.DataSource = dt

            Select Case filtroDati
               Case "Tutti"
                  ' Filtra i dati in base al testo digitato.
                  FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)

               Case "Mese"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiMese()

               Case "Anno"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiAnno()

               Case "Periodo"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiPeriodo()

               Case "Sospesi"
                  ' Aggiorna la griglia dati.
                  'AggiornaDatiSospesi()
            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub AggiornaDatiPeriodo()
      Try
         ' Rimuove i dati di un'eventuale ricerca.
         eui_txtTestoRicerca.Text = String.Empty

         Dim frmFiltroPerido As New FiltroPeriodo()
         If frmFiltroPerido.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Crea la stringa di selezione dei dati.
            Dim dataDal As String = CFormatta.FormattaData(frmFiltroPerido.eui_dtpDataDal.Value.GetValueOrDefault.ToShortDateString)
            Dim dataAl As String = CFormatta.FormattaData(frmFiltroPerido.eui_dtpDataAl.Value.GetValueOrDefault.ToShortDateString)
            sql = String.Format("Select TOP {0} * FROM {1} WHERE DataInizio BETWEEN #{2}# And #{3}# ORDER BY DataInizio ASC", DIM_PAGINA_GRANDE, TAB_NOLEGGI, dataDal, dataAl)
            repSql = sql
            LeggiDati("(" & sql & ")", sql)

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

            ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
            'AttivaDisattivaAnnullaDoc()

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)

            ' Somma i valori della colonna Importo.
            SommaImporti()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub AggiornaDatiMese()
      Try
         ' Crea la stringa di selezione dei dati.
         Dim Anno As String = Year(Now)
         Dim Mese As String = Month(Now)
         Dim InizioMese As String = CFormatta.FormattaData("01/" & Mese & "/" & Anno)
         Dim UltimoGiornoMese As String = DateTime.DaysInMonth(Anno, Mese)
         Dim FineMese As String = CFormatta.FormattaData(UltimoGiornoMese & "/" & Mese & "/" & Anno)
         sql = String.Format("Select TOP {0} * FROM {1} WHERE DataInizio BETWEEN #{2}# And #{3}# ORDER BY DataInizio ASC", DIM_PAGINA_GRANDE, TAB_NOLEGGI, InizioMese, FineMese)

         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         'AttivaDisattivaAnnullaDoc()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Somma i valori della colonna Importo.
         SommaImporti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub AggiornaDatiAnno()
      Try
         ' Crea la stringa di selezione dei dati.
         Dim Anno As String = Year(Now)
         Dim InizioAnno As String = CFormatta.FormattaData("01/01/" & Anno)
         Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
         Dim FineAnno As String = CFormatta.FormattaData(UltimoGiornoAnno & "/12/" & Anno)
         sql = String.Format("Select TOP {0} * FROM {1} WHERE DataInizio BETWEEN #{2}# And #{3}# ORDER BY DataInizio ASC", DIM_PAGINA_GRANDE, TAB_NOLEGGI, InizioAnno, FineAnno)

         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         'AttivaDisattivaAnnullaDoc()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Somma i valori della colonna Importo.
         SommaImporti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SommaImporti()
      Try
         ' Somma i valori della colonna Totale.
         eui_txtTotale.Text = CFormatta.FormattaNumeroDouble(SommaColonnaDouble(DataGridView1, COLONNA_TOTALE, numRecord))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         ' Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = False
         g_frmMain.eui_Strumenti_Duplica.Enabled = False
         g_frmMain.eui_Strumenti_Elimina.Enabled = False
         g_frmMain.eui_Strumenti_Annulla.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
         g_frmMain.eui_Strumenti_Esporta.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False

         ' Sospesi.
         g_frmMain.eui_Strumenti_Sospesi_Filtra.Enabled = False
         g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = False
         g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = False
         g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = False
         g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         ' Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = True
         g_frmMain.eui_Strumenti_Duplica.Enabled = True
         g_frmMain.eui_Strumenti_Elimina.Enabled = True
         'g_frmMain.eui_Strumenti_Annulla.Enabled = True
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
         g_frmMain.eui_Strumenti_Esporta.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True

         ' Sospesi.
         g_frmMain.eui_Strumenti_Sospesi_Filtra.Enabled = True
         'g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = True
         'g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = True
         'g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = True
         'g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = True
      End If
   End Sub

   ' TODO_A: Modificare.
   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.Documenti) = True Then
         ImpostaComandi()
      End If
   End Sub

   ' TODO_A: Modificare.
   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            lblIntestazione.Text = Strings.UCase(DataGridView1.Item(COLONNA_CLIENTE, DataGridView1.CurrentCell.RowIndex).Value.ToString & " - " &
                                                 DataGridView1.Item(COLONNA_CAUSALE, DataGridView1.CurrentCell.RowIndex).Value.ToString)
         Else
            lblIntestazione.Text = String.Empty
         End If

      Catch ex As NullReferenceException
         Exit Try

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub AttivaDisattivaAnnullaDoc()
      'Try
      '   ' Attiva/disattiva il pulsante per annullare un documento.
      '   If numRecord <> 0 Then

      '      Dim tipoDoc As String = DataGridView1.Item(COLONNA_TIPO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
      '      Dim statoDoc As String = DataGridView1.Item(COLONNA_STATO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString

      '      Select Case tipoDoc
      '         Case TIPO_DOC_RF, TIPO_DOC_FF, TIPO_DOC_SF

      '            Select Case statoDoc
      '               Case STATO_DOC_EMESSO, STATO_DOC_EMESSO_STAMPATO, STATO_DOC_EMESSO_XML
      '                  g_frmMain.eui_Strumenti_Annulla.Enabled = True

      '               Case Else
      '                  g_frmMain.eui_Strumenti_Annulla.Enabled = False

      '            End Select

      '         Case Else
      '            g_frmMain.eui_Strumenti_Annulla.Enabled = False

      '      End Select
      '   End If

      'Catch ex As NullReferenceException
      '   Exit Try

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub AnnullaDocumento()
      Try
         Dim Id As String = DataGridView1.Item(COLONNA_ID_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
         'Dim Data As String = Convert.ToDateTime(DataGridView1.Item(COLONNA_DATA_DOC, DataGridView1.CurrentCell.RowIndex).Value).ToShortDateString
         'Dim Documento As String = DataGridView1.Item(COLONNA_TIPO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
         'Dim Numero As String = DataGridView1.Item(COLONNA_NUMERO_DOC, DataGridView1.CurrentCell.RowIndex).Value.ToString
         'Dim Importo As String = CFormatta.FormattaEuro(DataGridView1.Item(COLONNA_IMPORTO_TOTALE, DataGridView1.CurrentCell.RowIndex).Value)


         ' Chiede conferma per l'annullamento.
         Dim risposta As Integer
         'risposta = MessageBox.Show("Si desidera annullare il documento """ & Documento & " n. " & Numero & " del " & Data & """? " & vbCrLf & vbCrLf &
         '                           "Confermando l'operazione verranno ripristinati i valori per le " &
         '                           "giacenze di magazzino degli Articoli e le Statistiche di vendita. Eventuali Buoni pasto contenuti " &
         '                           "nel documento non ancora fatturati verranno annullati. Procedere?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         If risposta = vbYes Then
            RipristinaIngredientiScaricati()
            RipristinaStatistiche()

            ' Attiva/disattiva il pulsante per visualizzare l'elenco dei Buoni pasto.
            'If DataGridView1.Item(COLONNA_IMPORTO_BUONI_INC, DataGridView1.CurrentCell.RowIndex).Value <> 0 Then
            '   If RipristinaBuoniPasto() = True Then
            '      EliminaBuoniPasto()
            '   End If
            'End If

            ' TODO_B: Se il documento da annullare Ë uno scontrino.
            'If Documento = TIPO_DOC_SF Then
            '   CreaFileScontrinoWPOS1(Numero, Convert.ToDateTime(Data))
            'End If

         Else
            Exit Sub
         End If

         ' Chiede conferma per l'eliminazione.
         'risposta = MessageBox.Show("Il documento """ & Documento & " n. " & Numero & " del " & Data & """ Ë stato annullato! " & vbCrLf & vbCrLf &
         '                     "Si desidera mantenere il documento nell'elenco documenti per eventuali consultazioni? ", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         If risposta = vbNo Then
            EliminaDettagliDocumento()
            EliminaDocumento()

         Else
            ModificaStatoDocumento(TAB_NOLEGGI, Id, STATO_DOC_ANNULLATO)
         End If

         ' QUESTA PROCEDURA NON E' PIU' NECESSARIA. 
         ' Salva il Numero del documento annullato come prossimo numero da stampare rendendolo nuovamente disponibile.
         'RipristinaNumeroDocFiscaleConfig(TAB_DOCUMENTI, Documento, Numero)

         ' Aggiorna la lista dei documenti.
         g_frmDocumenti.AggiornaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         AttivaDisattivaAnnullaDoc()

         ' Registra loperazione effettuata dall'operatore identificato.
         'Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & CFormatta.FormattaEuro(Importo) & ")"
         'g_frmMain.RegistraOperazione(TipoOperazione.AnnullaDoc, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Function ModificaStatoDocumento(ByVal tabella As String, ByVal codice As String, ByVal stato As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET StatoDoc = @StatoDoc WHERE Id = {1}", tabella, codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@StatoDoc", stato)

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

   ' TODO_A: Modificare.
   Private Sub RipristinaNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String, ByVal numDoc As Integer)
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

         End Select

         DatiConfig.SetValue(chiaveConfig, numDoc.ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Private Function LeggiNumeroMax(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         'cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}'", tabella, tipoDoc)

         ' Ottiene i dati per l'anno corrente.
         Dim Anno As String = Year(Now)
         Dim primoGiornoAnno As String = CFormatta.FormattaData("01/01/" & Anno)
         Dim numUltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
         Dim ultimoGiornoAnno As String = CFormatta.FormattaData(numUltimoGiornoAnno & "/12/" & Anno)

         cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}' AND DataDoc BETWEEN #{2}# AND #{3}#", tabella, tipoDoc, primoGiornoAnno, ultimoGiornoAnno)

         If IsDBNull(cmd.ExecuteScalar()) = False Then
            numRec = CInt(cmd.ExecuteScalar())
         Else
            numRec = 0
         End If

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n∞ totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         DataGridView1.AutoGenerateColumns = False
         DataGridView1.DataMember = tabella

         ' 0 Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .Visible = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codiceStyle)

         ' 1 Cliente
         Dim clienteStyle As New DataGridViewTextBoxColumn()
         With clienteStyle
            .DataPropertyName = "Cliente"
            .HeaderText = "Cliente"
            .Name = "Cliente"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, clienteStyle)

         ' 2 Causale
         Dim causaleStyle As New DataGridViewTextBoxColumn()
         With causaleStyle
            .DataPropertyName = "Causale"
            .HeaderText = "Causale"
            .Name = "Causale"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, causaleStyle)

         ' 3 Data inizio
         Dim dataInizioStyle As New DataGridViewTextBoxColumn()
         With dataInizioStyle
            .DataPropertyName = "DataInizio"
                .HeaderText = "Data/Ore inizio"
                .Name = "DataInizio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Green
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, dataInizioStyle)

         ' 4 Data fine
         Dim dataFineStyle As New DataGridViewTextBoxColumn()
         With dataFineStyle
            .DataPropertyName = "DataFine"
                .HeaderText = "Data/Ore fine"
                .Name = "DataFine"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Green
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, dataFineStyle)

         ' 5 Totale Giorni 
         Dim totaleGiorniStyle As New DataGridViewTextBoxColumn()
         With totaleGiorniStyle
            .DataPropertyName = "TotaleGiorni"
                .HeaderText = "Totale ore/giorni"
                .Name = "TotaleGiorni"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, totaleGiorniStyle)

         ' 6 Totale
         Dim totaleStyle As New DataGridViewTextBoxColumn()
         With totaleStyle
            .DataPropertyName = "Totale"
            .HeaderText = "Totale"
            .Name = "Totale"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Blue
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, totaleStyle)

         ' 7 Codice a barre
         Dim codBarreStyle As New DataGridViewTextBoxColumn()
         With codBarreStyle
            .DataPropertyName = "CodiceBarre"
            .HeaderText = "Codice a barre"
            .Name = "CodiceBarre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, codBarreStyle)

         ' 8 Chiuso.
         Dim chiusoStyle As New DataGridViewTextBoxColumn()
         With chiusoStyle
            .DataPropertyName = "Chiuso"
            .HeaderText = "Contabilizzato"
            .Name = "Chiuso"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, chiusoStyle)

         ' 9 Stato
         Dim statoStyle As New DataGridViewTextBoxColumn()
         With statoStyle
            .DataPropertyName = "Stato"
            .HeaderText = "Stato noleggio"
            .Name = "Stato"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, statoStyle)

         ' Colore
         Dim coloreStyle As New DataGridViewTextBoxColumn
         With coloreStyle
            .DataPropertyName = "Colore"
            .HeaderText = "Colore"
            .Name = "ColoreSfondo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, coloreStyle)

         ' 11 Id Cliente.
         Dim idClienteStyle As New DataGridViewTextBoxColumn()
         With idClienteStyle
            .DataPropertyName = "idCliente"
            .HeaderText = "idCliente"
            .Name = "idCliente"
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, idClienteStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaColonneArticoli(ByVal tabella As String)
      Try
         DataGridView2.AutoGenerateColumns = False
         DataGridView2.DataMember = tabella

         ' 0 Id - Codice
         Dim codiceStyle As New DataGridViewTextBoxColumn
         With codiceStyle
            .DataPropertyName = "Id"
            .HeaderText = "Codice"
            .Name = "Id"
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView2.Columns.Insert(DataGridView2.ColumnCount, codiceStyle)

         ' 1 Codice Articolo
         Dim codiceArticoloStyle As New DataGridViewTextBoxColumn
         With codiceArticoloStyle
            .DataPropertyName = "CodiceArticolo"
            .HeaderText = "Codice"
            .Name = "CodiceArticolo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_ROSA)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView2.Columns.Insert(DataGridView2.ColumnCount, codiceArticoloStyle)

         ' 2 Descrizione
         Dim descrizioneStyle As New DataGridViewTextBoxColumn()
         With descrizioneStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView2.Columns.Insert(DataGridView2.ColumnCount, descrizioneStyle)

         ' 3 Quantit‡
         Dim quantit‡Style As New DataGridViewTextBoxColumn()
         With quantit‡Style
            .DataPropertyName = "Quantit‡"
            .HeaderText = "Quantit‡"
            .Name = "Quantit‡"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView2.Columns.Insert(DataGridView2.ColumnCount, quantit‡Style)

         ' 4 Rif. Noleggio
         Dim rifNoleggioStyle As New DataGridViewTextBoxColumn()
         With rifNoleggioStyle
            .DataPropertyName = "RifNoleggio"
            .HeaderText = "RifNoleggio"
            .Name = "RifNoleggio"
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView2.Columns.Insert(DataGridView2.ColumnCount, rifNoleggioStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

    ' TODO_A: Modificare.
    Public Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
      Try
         Dim sql As String

         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Codice"
               campoRicerca = "Id"
            Case "Cliente"
               campoRicerca = "Cliente"
            Case "Causale"
               campoRicerca = "Causale"
            Case "Data inizio"
               campoRicerca = "DataInizio"
            Case "Data fine"
               campoRicerca = "DataFine"
            Case "Totale giorni"
               campoRicerca = "TotaleGiorni"
            Case "Stato noleggio"
               campoRicerca = "Stato"
            Case "Totale"
               campoRicerca = "Totale"
            Case "Codice a barre"
               campoRicerca = "CodiceBarre"
            Case "Contabilizzato"
               campoRicerca = "Chiuso"
         End Select

         If testoRicerca <> String.Empty Then
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_NOLEGGI, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_NOLEGGI, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id ASC", DIM_PAGINA_GRANDE, TAB_NOLEGGI)
            repSql = String.Format("SELECT * FROM {0} ORDER BY Id ASC", TAB_NOLEGGI)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_NOLEGGI, sql)
         End If

         ' Somma i valori della colonna Importo.
         SommaImporti()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         'AttivaDisattivaSospeso()
         'AttivaDisattivaPassaSospeso()
         'AttivaDisattivaAnnullaSospeso()
         'AttivaDisattivaBuoni()
         'AttivaDisattivaAnnullaDoc()
         'AttivaDisattivaEsportaFatturaElettronica()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDatiArticoli(ByVal rif_noleggio As Integer)
      Try
         Dim sqlArticoli As String = String.Format("SELECT * FROM {0} WHERE RifNoleggio = {1} ORDER BY Id ASC", TAB_DETTAGLI_NOLEGGI, rif_noleggio)

         DataGridView2.DataSource = dtArticoli

         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sqlArticoli, cn)

         ' Pulisce la tabella da precedenti dati.
         dtArticoli.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dtArticoli)

         numRecordArticoli = LeggiNumRecordIngredienti(TAB_DETTAGLI_NOLEGGI, rif_noleggio)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaCampiRic()
      Try
         eui_cmbCampoRicerca.Items.Add("Codice")
         eui_cmbCampoRicerca.Items.Add("Cliente")
         eui_cmbCampoRicerca.Items.Add("Causale")
         eui_cmbCampoRicerca.Items.Add("Data inizio")
         eui_cmbCampoRicerca.Items.Add("Data fine")
         eui_cmbCampoRicerca.Items.Add("Totale giorni")
         eui_cmbCampoRicerca.Items.Add("Stato noleggio")
         eui_cmbCampoRicerca.Items.Add("Totale")
         eui_cmbCampoRicerca.Items.Add("Codice a barre")
         eui_cmbCampoRicerca.Items.Add("Contabilizzato")

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

   Private Function LeggiNumRecordIngredienti(ByVal tabella As String, ByVal rif_noleggio As Integer) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE RifNoleggio = {1}", tabella, rif_noleggio)
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


   Public Sub AnteprimaDiStampa(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

         Dim ds As New DocumentiDataSet
         ds.Clear()
         oleAdapter.Fill(ds, tabella)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepElencoDocumenti(ds, nomeDoc, String.Empty)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaElenco(ByVal sqlRep As String, ByVal nomeDoc As String, ByVal nomeStampante As String, ByVal numCopie As Short)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New DocumentiDataSet
         ds.Clear()

         ' Carica i dati della tabella in un DataAdapter.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sqlRep, cn)
         oleAdapter1.Fill(ds, TAB_NOLEGGI)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   ' TODO_A: Modificare.
   Private Sub ElencoNoleggi_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

#Region "Strumenti di Modifica - (Condivisa) "
      ' Visualizza i comandi Strumenti di modifica sul Ribbon.
      g_frmMain.rtgStrumentiModifica.Visible = True

#Region "Modifica - (Condivisa) "
      ' TabPage.
      g_frmMain.eui_StrumentiModifica.Visible = True

      ' Dati.
      g_frmMain.eui_Strumenti_Nuovo.Visible = True
      g_frmMain.eui_Strumenti_Modifica.Visible = True
      g_frmMain.eui_Strumenti_Duplica.Visible = True
      g_frmMain.eui_Strumenti_Elimina.Visible = True
      g_frmMain.eui_Strumenti_Annulla.Visible = True
      g_frmMain.eui_Strumenti_Aggiorna.Visible = True

      ' Esporta.
      g_frmMain.eui_Strumenti_Esporta.Visible = True
      g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = True
      g_frmMain.eui_Strumenti_Esporta_XML.Visible = moduloAttivo.FattElettronica
      g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

      ' Magazzino.
      g_frmMain.eui_Strumenti_Magazzino.Visible = False

      ' Stampa.
      g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
      g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
      ' TabPage.
      g_frmMain.eui_StrumentiPeriodo.Visible = True

      ' Periodo.
      g_frmMain.eui_Strumenti_Periodo_Tutte.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Anno.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Mese.Visible = True
      g_frmMain.eui_Strumenti_Periodo_DalAl.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Sep1.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Arrivo.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Partenza.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Sep2.Visible = False
      g_frmMain.eui_Strumenti_Periodo_NonAssegnate.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Terminate.Visible = False

      ' Visualizza.
      g_frmMain.eui_Strumenti_Visualizza_Presenze.Visible = False
      g_frmMain.eui_rib_Visualizza.Visible = False

#End Region

#Region "Documenti "
      ' TabPage.
      g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
      ' TabPage.
      g_frmMain.eui_StrumentiSospesiBuoni.Visible = True

#End Region

      ' Serve ad attivare/disattivare i vari comandi in base ai dati visualizzati.
      AggiornaDati()

#End Region

   End Sub

   ' TODO_A: Modificare.
   Private Sub ElencoNoleggi_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Strumenti di Modifica - (Condivisa) "
      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgStrumentiModifica.Visible = False

#End Region

   End Sub

   ' TODO_A: Modificare.
   Private Sub ElencoNoleggi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_NOLEGGI)
         CreaColonneArticoli(TAB_DETTAGLI_NOLEGGI)

         ' Imposta le dimensioni del form.
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         LeggiDatiConfig()

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         If eui_cmbCampoRicerca.Items.Count <> 0 Then
            eui_cmbCampoRicerca.SelectedIndex = 0
         End If

         Select Case filtroDati
            Case "Tutti"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

               ' Filtra i dati in base al testo digitato.
               FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)

            Case "Mese"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = True
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

               ' Aggiorna la griglia dati.
               AggiornaDatiMese()

            Case "Anno"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = True
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()

            Case "Periodo"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = True
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               ' DA_FARE_A: Salvare stringa di ricerca date.
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

               ' Aggiorna la griglia dati.
               AggiornaDatiPeriodo()

         End Select

         ' Visualizza i dati di dettaglio.
         If numRecord <> 0 Then
            FiltraDatiArticoli(Convert.ToInt32(DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value))
         Else
            FiltraDatiArticoli(0)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         'If g_frmMain.eui_Strumenti_Modifica.Enabled = True Then
         '   ' Attiva/disattiva il pulsante per annullare un documento.
         '   AttivaDisattivaAnnullaDoc()

         'End If

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Private Sub ElencoNoleggi_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmNoleggi)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmNoleggi.Dispose()
         g_frmNoleggi = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_txtTestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmbCampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse. 6666
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se Ë un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_NOLEGGI)) = True Then
                  Exit Sub
               End If
            End If
         End If

         g_frmSchedaNoleggi = New frmNoleggi
         g_frmSchedaNoleggi.Tag = val
         g_frmSchedaNoleggi.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub Nuovo()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, strDescrizione, strModulo)

         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati("")

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Sub Modifica()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, strDescrizione, strModulo)

         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati(DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value.ToString)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_A: Modificare.
   Public Function CreaFileScontrinoWPOS1(ByVal numeroDoc As String, ByVal dataDoc As Date) As Boolean
      Try
         Dim SR_DATI As String = "SR_DATI."
         Dim SR_START As String = "SR_START."
         Dim sw As StreamWriter

         If PercorsoLavoroWpos1 = String.Empty Then
            Return False
         End If

         If EstensioneFileWpos1 = String.Empty Then
            Return False
         Else
            SR_DATI = SR_DATI & EstensioneFileWpos1
            SR_START = SR_START & EstensioneFileWpos1
         End If

         ' Crea il file Start con la password.
         sw = File.CreateText(PercorsoLavoroWpos1 & "\" & SR_START)
         sw.WriteLine(PwdDriverWpos1)
         sw.Close()

         ' Crea il file Dati con le righe di vendita.
         sw = File.CreateText(PercorsoLavoroWpos1 & "\" & SR_DATI)

         ' Righe di annullo scontrino
         Dim numeroSF As String = InserisciZero123(numeroDoc)
         Dim dataSF As String = InserisciZero1(dataDoc.Day.ToString) & InserisciZero1(dataDoc.Month.ToString) & dataDoc.Year.ToString.Substring(2, 2)

         Dim rigaScontrino As String = "DELD,N0001" & numeroSF & ",D" & dataSF & ",>96MEY012345;"
         sw.WriteLine(rigaScontrino)

         sw.Close()

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   ' TODO_A: Modificare.
   Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
      Try
         ' Imposta il colore per la cella in base al valore del campo ColoreSfondo.
         If DataGridView1.Columns(e.ColumnIndex).Name = "ColoreSfondo" AndAlso Not (TypeOf e.Value Is System.DBNull) Then
            ' Colore di sfondo.
            e.CellStyle.BackColor = Color.FromArgb(e.Value)

            ' Colore testo.
            e.CellStyle.ForeColor = Color.FromArgb(e.Value)

            ' Non visualizza il valore del campo.
            e.Value = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged
      Try

         ' Visualizza un'intestazione per la griglia dati.
         AggIntGriglia()

         ' Visualizza i dati di dettaglio.
         If numRecord <> 0 Then
            FiltraDatiArticoli(Convert.ToInt32(DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value))
         Else
            FiltraDatiArticoli(0)
         End If

         ' Attiva/disattiva il pulsante per annullare un documento.
         'AttivaDisattivaAnnullaDoc()

      Catch ex As NullReferenceException
         Exit Try

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
      ' Apre la finestra Documento per la modifica dei dati.
      Modifica()
   End Sub

End Class
