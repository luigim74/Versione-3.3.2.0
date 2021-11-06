#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            ElencoCausaliNoleggio
' Autore:               Luigi Montana, Montana Software
' Data creazione:       27/02/2021
' Data ultima modifica: 23/10/2021
' Descrizione:          Elenco Causai Noleggio.
' Note:

' Elenco Attivita:

' ******************************************************************
#End Region

Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Data.OleDb

Public Class ElencoCausaliNoleggio
   Inherits System.Windows.Forms.Form

   Public Const TAB_CAUSALI_NOLEGGIO As String = "CausaliNoleggio"
   Const TAB_DETTAGLI_CAUSALI_NOLEGGIO As String = "DettagliCausaliNoleggio"
   Const TITOLO_FINESTRA As String = "Elenco Causali noleggio"

   Public Const COLONNA_ID As Short = 0
   Const COLONNA_DESCRIZIONE As Short = 1
   Const COLONNA_COSTO As Short = 2
   Const COLONNA_MORA As Short = 3
   Const COLONNA_ASSICURAZIONE As Short = 4
   Const COLONNA_TOTALE As Short = 5

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

   Private AArticoli As New Articoli

   Public filtroDati As String

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_txtTestoRicerca As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbCampoRicerca As Elegant.Ui.ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblIntestazione As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_CAUSALI_NOLEGGIO)
      dtArticoli = ds.Tables.Add(TAB_DETTAGLI_CAUSALI_NOLEGGIO)

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
    Friend WithEvents lblCampo As System.Windows.Forms.Label
    Friend WithEvents lblTesto As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoCausaliNoleggio))
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.eui_cmbCampoRicerca = New Elegant.Ui.ComboBox()
      Me.eui_txtTestoRicerca = New Elegant.Ui.TextBox()
      Me.lblCampo = New System.Windows.Forms.Label()
      Me.lblTesto = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.DataGridView2 = New System.Windows.Forms.DataGridView()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Panel1.SuspendLayout()
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
      Me.Panel1.Size = New System.Drawing.Size(722, 63)
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
      Me.eui_cmbCampoRicerca.Id = "9dde072f-6d08-4968-a787-3a24c5592c7f"
      Me.eui_cmbCampoRicerca.Location = New System.Drawing.Point(578, 7)
      Me.eui_cmbCampoRicerca.Name = "eui_cmbCampoRicerca"
      Me.eui_cmbCampoRicerca.Size = New System.Drawing.Size(134, 21)
      Me.eui_cmbCampoRicerca.TabIndex = 1
      Me.eui_cmbCampoRicerca.TextEditorWidth = 115
      '
      'eui_txtTestoRicerca
      '
      Me.eui_txtTestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTestoRicerca.Id = "6b3d4f0c-1c12-4168-b986-f34bd7d87385"
      Me.eui_txtTestoRicerca.Location = New System.Drawing.Point(114, 7)
      Me.eui_txtTestoRicerca.Name = "eui_txtTestoRicerca"
      Me.eui_txtTestoRicerca.Size = New System.Drawing.Size(361, 21)
      Me.eui_txtTestoRicerca.TabIndex = 0
      Me.eui_txtTestoRicerca.TextEditorWidth = 529
      '
      'lblCampo
      '
      Me.lblCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCampo.AutoSize = True
      Me.lblCampo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCampo.ForeColor = System.Drawing.Color.White
      Me.lblCampo.Location = New System.Drawing.Point(489, 8)
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
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.GridColor = System.Drawing.Color.LightGray
      Me.DataGridView1.Location = New System.Drawing.Point(0, 63)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.Size = New System.Drawing.Size(714, 152)
      Me.DataGridView1.TabIndex = 14
      '
      'DataGridView2
      '
      Me.DataGridView2.AllowUserToAddRows = False
      Me.DataGridView2.AllowUserToDeleteRows = False
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
      Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
      Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
      Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView2.GridColor = System.Drawing.Color.LightGray
      Me.DataGridView2.Location = New System.Drawing.Point(0, 245)
      Me.DataGridView2.Name = "DataGridView2"
      Me.DataGridView2.ReadOnly = True
      Me.DataGridView2.Size = New System.Drawing.Size(722, 215)
      Me.DataGridView2.TabIndex = 15
      '
      'Panel3
      '
      Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel3.BackColor = System.Drawing.Color.Gray
      Me.Panel3.Controls.Add(Me.Label1)
      Me.Panel3.Location = New System.Drawing.Point(0, 217)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(722, 26)
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
      'ElencoCausaliNoleggio
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(722, 460)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.DataGridView2)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Panel1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoCausaliNoleggio"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Causali noleggio"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("WSCausaliNoleggio") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSCausaliNoleggio") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("ACausaliNoleggio") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("ACausaliNoleggio"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LCausaliNoleggio") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LCausaliNoleggio"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("CausaliNoleggioX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("CausaliNoleggioX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("CausaliNoleggioY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("CausaliNoleggioY")))
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

         DatiConfig.SetValue("WSCausaliNoleggio", Me.WindowState)
         DatiConfig.SetValue("CausaliNoleggioX", Me.Location.X)
         DatiConfig.SetValue("CausaliNoleggioY", Me.Location.Y)
         DatiConfig.SetValue("ACausaliNoleggio", Me.Height)
         DatiConfig.SetValue("LCausaliNoleggio", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO_B: Modificare ImpostaFunzioniOperatore.
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

   Private Sub EliminaDettagliCausaleNoleggio()
      Try
         Dim rifCausale As Integer

         ' Legge il numero dell'ultimo documento creato.
         rifCausale = DataGridView1.Item(COLONNA_ID, DataGridView1.CurrentCell.RowIndex).Value

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE RifCausale = {1}", TAB_DETTAGLI_CAUSALI_NOLEGGIO, rifCausale)

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

   Private Sub EliminaCausaleNoleggio()
      Try
         Dim idCausale As Integer

         ' Legge il numero dell'ultimo documento creato.
         idCausale = DataGridView1.Item(COLONNA_ID, DataGridView1.CurrentCell.RowIndex).Value

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE Id = {1}", TAB_CAUSALI_NOLEGGIO, idCausale)

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

   Public Sub EliminaDati()
      Dim descrizione As String = DataGridView1.Item(COLONNA_DESCRIZIONE, DataGridView1.CurrentCell.RowIndex).Value.ToString

      ' Chiede conferma per l'eliminazione.
      Dim risposta As Integer
      risposta = MessageBox.Show("Si desidera eliminare la Causale di noleggio """ & descrizione & """? " &
                                 "Confermando l'operazione non sar‡ pi˘ possibile recuperare i dati.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If risposta = vbYes Then
         EliminaDettagliCausaleNoleggio()
         EliminaCausaleNoleggio()

         ' TODO_B: Sviluppare RegistraOperazione.
         ' Registra loperazione effettuata dall'operatore identificato.
         'Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & CFormatta.FormattaEuro(Importo) & ")"
         'g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

      End If
   End Sub

   Public Sub DuplicaCausaliNoleggio()
      Try
         Dim Risposta As Short
         Dim id As String = DataGridView1.Item(COLONNA_ID, DataGridView1.CurrentCell.RowIndex).Value.ToString
         Dim descrizione As String = DataGridView1.Item(COLONNA_DESCRIZIONE, DataGridView1.CurrentCell.RowIndex).Value.ToString

         ' Chiede conferma per la duplicazione.
         Risposta = MessageBox.Show("Si desidera duplicare la causale di noleggio """ & descrizione & """?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If Risposta = MsgBoxResult.Yes Then

            ' Dati documento.
            Dim CCausali As New CausaliNoleggio
            With CCausali
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_CAUSALI_NOLEGGIO, id)

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_CAUSALI_NOLEGGIO)
            End With

            ' Leggo l'ultimo id del documento duplicato.
            Dim ultimoId As Integer = LeggiUltimoRecord(TAB_CAUSALI_NOLEGGIO)

            ' Dati dettagli documento.
            Dim CDettagliCausali As New DettagliCausaliNoleggio
            With CDettagliCausali
               ' Dichiara un oggetto connessione.
               Dim cn As New OleDbConnection(ConnString)
               cn.Open()

               Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_CAUSALI_NOLEGGIO & " WHERE RifCausale = " & id & " ORDER BY Id ASC", cn)
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
                  .InserisciDati(TAB_DETTAGLI_CAUSALI_NOLEGGIO)
               Loop
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' TODO_B: Modificare RegistraOperazione.
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

   Public Sub AggiornaDati()
      Try
         If eui_txtTestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGridView1.DataSource = dt

            FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_CAUSALI_NOLEGGIO)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGridView1.DataSource = dt

            ' Filtra i dati in base al testo digitato.
            FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati. Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = False
         g_frmMain.eui_Strumenti_Duplica.Enabled = False
         g_frmMain.eui_Strumenti_Elimina.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
         g_frmMain.eui_Strumenti_Esporta.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False
      Else
         ' Attiva i pulsanti appropriati. Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = True
         g_frmMain.eui_Strumenti_Duplica.Enabled = True
         g_frmMain.eui_Strumenti_Elimina.Enabled = True
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
         g_frmMain.eui_Strumenti_Esporta.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      ' TODO_B: Modificare ImpostaFunzioniOperatore.
      'If ImpostaFunzioniOperatore(Finestra.Documenti) = True Then
      '   ImpostaComandi()
      'End If

      ImpostaComandi()
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            lblIntestazione.Text = Strings.UCase(DataGridView1.Item(COLONNA_ID, DataGridView1.CurrentCell.RowIndex).Value.ToString & " - " &
                                                 DataGridView1.Item(COLONNA_DESCRIZIONE, DataGridView1.CurrentCell.RowIndex).Value.ToString)
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

         ' 1 Descrizione
         Dim causaleStyle As New DataGridViewTextBoxColumn()
         With causaleStyle
            .DataPropertyName = "Descrizione"
            .HeaderText = "Descrizione"
            .Name = "Descrizione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.BackColor = Color.FromArgb(COLORE_AZZURRO)
            .CellTemplate.Style.NullValue = String.Empty
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, causaleStyle)

         ' 2 Costo giorno
         Dim costoGiornoStyle As New DataGridViewTextBoxColumn()
         With costoGiornoStyle
            .DataPropertyName = "CostoGiorno"
            .HeaderText = "Costo ora/giorno"
            .Name = "CostoGiorno"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Black
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, costoGiornoStyle)

         ' 3 Costo Mora giorno
         Dim costoMoraStyle As New DataGridViewTextBoxColumn()
         With costoMoraStyle
            .DataPropertyName = "CostoMora"
            .HeaderText = "Costo Mora ora/giorno"
            .Name = "CostoMora"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Red
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, costoMoraStyle)

         ' 4 Costo Assicurazione giorno
         Dim costoAssicurazioneStyle As New DataGridViewTextBoxColumn()
         With costoAssicurazioneStyle
            .DataPropertyName = "CostoAssicurazione"
            .HeaderText = "Costo Assicurazione"
            .Name = "CostoAssicurazione"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .CellTemplate = New DataGridViewTextBoxCell()
            .CellTemplate.Style.ForeColor = Color.Green
            .CellTemplate.Style.NullValue = String.Empty
            .CellTemplate.Style.Format = "##,##0.00"
            .CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
         End With
         DataGridView1.Columns.Insert(DataGridView1.ColumnCount, costoAssicurazioneStyle)

         ' 5 Totale
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
            .DataPropertyName = "RifCausale"
            .HeaderText = "RifCausale"
            .Name = "RifCausale"
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

   Public Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
      Try
         Dim sql As String

         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Codice"
               campoRicerca = "Id"
            Case "Descrizione"
               campoRicerca = "Descrizione"
         End Select

         If testoRicerca <> String.Empty Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_CAUSALI_NOLEGGIO, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_CAUSALI_NOLEGGIO, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id ASC", DIM_PAGINA_GRANDE, TAB_CAUSALI_NOLEGGIO)
            repSql = String.Format("SELECT * FROM {0} ORDER BY Id ASC", TAB_CAUSALI_NOLEGGIO)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_CAUSALI_NOLEGGIO, sql)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

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
         Dim sqlArticoli As String = String.Format("SELECT * FROM {0} WHERE RifCausale = {1} ORDER BY Id ASC", TAB_DETTAGLI_CAUSALI_NOLEGGIO, rif_noleggio)

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

         numRecordArticoli = LeggiNumRecordArticoli(TAB_DETTAGLI_CAUSALI_NOLEGGIO, rif_noleggio)

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
         eui_cmbCampoRicerca.Items.Add("Descrizione")

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

   Private Function LeggiNumRecordArticoli(ByVal tabella As String, ByVal rif_noleggio As Integer) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE RifCausale = {1}", tabella, rif_noleggio)
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
         oleAdapter1.Fill(ds, TAB_CAUSALI_NOLEGGIO)

         Dim stampa As New StampaReports(ds, nomeStampante, numCopie, FORMATO_REPORT_A4)
         stampa.Avvia(Application.StartupPath & nomeDoc)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ElencoCausaliNoleggi_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

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
      g_frmMain.eui_Strumenti_Annulla.Visible = False
      g_frmMain.eui_Strumenti_Aggiorna.Visible = True

      ' Esporta.
      g_frmMain.eui_Strumenti_Esporta.Visible = True
      g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = False
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
      g_frmMain.eui_StrumentiPeriodo.Visible = False

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
      g_frmMain.eui_StrumentiSospesiBuoni.Visible = False

#End Region

      ' Serve ad attivare/disattivare i vari comandi in base ai dati visualizzati.
      AggiornaDati()

#End Region

   End Sub

   Private Sub ElencoNoleggi_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Strumenti di Modifica - (Condivisa) "
      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgStrumentiModifica.Visible = False

#End Region

   End Sub

   Private Sub ElencoNoleggi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_CAUSALI_NOLEGGIO)
         CreaColonneArticoli(TAB_DETTAGLI_CAUSALI_NOLEGGIO)

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

         ' Visualizza i dati di dettaglio.
         If numRecord <> 0 Then
            FiltraDatiArticoli(Convert.ToInt32(DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value))
         Else
            FiltraDatiArticoli(0)
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' TODO_B: Modificare RegistraOperazione.
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ElencoCausaliNoleggio_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmCausaliNoleggio)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmCausaliNoleggio.Dispose()
         g_frmCausaliNoleggio = Nothing

         ' TODO_B: Sviluppare RegistraOperazione.
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

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
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se Ë un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_CAUSALI_NOLEGGIO)) = True Then
                  Exit Sub
               End If
            End If
         End If

         g_frmSchedaCausaliNoleggio = New frmCausaliNoleggio
         g_frmSchedaCausaliNoleggio.Tag = val
         g_frmSchedaCausaliNoleggio.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub Nuovo()
      Try
         ' TODO_B: Sviluppare RegistraOperazione.
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

   Public Sub Modifica()
      Try
         ' TODO_B: Sviluppare RegistraOperazione.
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
