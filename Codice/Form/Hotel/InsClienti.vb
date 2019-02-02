Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmInsClienti
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal frm As String, ByVal filtro As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      frmChiamante = frm
      filtroChiamante = filtro

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
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdInserisci As Elegant.Ui.Button
   Friend WithEvents cmdNuovo As Elegant.Ui.Button
   Friend WithEvents lvwClienti As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdEsci As Elegant.Ui.Button
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdModifica As Elegant.Ui.Button
   Friend WithEvents nudPermanenza As Elegant.Ui.NumericUpDown
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents ColumnHeader2 As ColumnHeader
   Friend WithEvents ColumnHeader3 As ColumnHeader
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsClienti))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.cmdInserisci = New Elegant.Ui.Button()
      Me.cmdNuovo = New Elegant.Ui.Button()
      Me.lvwClienti = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.cmdEsci = New Elegant.Ui.Button()
      Me.Label1 = New Elegant.Ui.Label()
      Me.nudPermanenza = New Elegant.Ui.NumericUpDown()
      Me.cmdModifica = New Elegant.Ui.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudPermanenza, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "saveHS.png")
      Me.ImageList1.Images.SetKeyName(1, "Edit_UndoHS.png")
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
      'cmdInserisci
      '
      Me.cmdInserisci.Id = "cee6b872-8fb1-4d46-a7bd-05e87b8b2052"
      Me.cmdInserisci.Location = New System.Drawing.Point(907, 60)
      Me.cmdInserisci.Name = "cmdInserisci"
      Me.cmdInserisci.Size = New System.Drawing.Size(104, 50)
      Me.cmdInserisci.TabIndex = 2
      Me.cmdInserisci.Text = "&Inserisci"
      '
      'cmdNuovo
      '
      Me.cmdNuovo.Id = "449d9c97-e7e9-4436-94bb-d3035dd05b42"
      Me.cmdNuovo.Location = New System.Drawing.Point(907, 122)
      Me.cmdNuovo.Name = "cmdNuovo"
      Me.cmdNuovo.Size = New System.Drawing.Size(104, 50)
      Me.cmdNuovo.TabIndex = 3
      Me.cmdNuovo.Text = "&Nuovo"
      '
      'lvwClienti
      '
      Me.lvwClienti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader2, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader13, Me.ColumnHeader3, Me.ColumnHeader12})
      Me.lvwClienti.Dock = System.Windows.Forms.DockStyle.Left
      Me.lvwClienti.FullRowSelect = True
      Me.lvwClienti.Location = New System.Drawing.Point(0, 0)
      Me.lvwClienti.MultiSelect = False
      Me.lvwClienti.Name = "lvwClienti"
      Me.lvwClienti.ShowGroups = False
      Me.lvwClienti.Size = New System.Drawing.Size(896, 541)
      Me.lvwClienti.TabIndex = 0
      Me.lvwClienti.UseCompatibleStateImageBehavior = False
      Me.lvwClienti.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Indice"
      Me.ColumnHeader1.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "Cognome"
      Me.ColumnHeader7.Width = 150
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "Nome"
      Me.ColumnHeader8.Width = 100
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Sesso"
      Me.ColumnHeader2.Width = 50
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Data di Nascita"
      Me.ColumnHeader9.Width = 100
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "Luogo di Nascita"
      Me.ColumnHeader10.Width = 170
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "Prov. Nascita"
      Me.ColumnHeader11.Width = 90
      '
      'ColumnHeader13
      '
      Me.ColumnHeader13.Text = "Nazione Nascita"
      Me.ColumnHeader13.Width = 100
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Tipo Cliente"
      Me.ColumnHeader3.Width = 100
      '
      'ColumnHeader12
      '
      Me.ColumnHeader12.Text = "Codice"
      Me.ColumnHeader12.Width = 0
      '
      'cmdEsci
      '
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.Id = "e6fafeb6-0b28-4aed-ac54-c230da8bcda0"
      Me.cmdEsci.Location = New System.Drawing.Point(907, 482)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(104, 50)
      Me.cmdEsci.TabIndex = 5
      Me.cmdEsci.Text = "&Esci"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(907, 11)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(92, 16)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Giorni Permanenza:"
      '
      'nudPermanenza
      '
      Me.nudPermanenza.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.nudPermanenza.Id = "995cbfb5-eb8e-436e-b831-add285dc2de0"
      Me.nudPermanenza.Location = New System.Drawing.Point(907, 27)
      Me.nudPermanenza.Name = "nudPermanenza"
      Me.nudPermanenza.Size = New System.Drawing.Size(104, 21)
      Me.nudPermanenza.TabIndex = 1
      Me.nudPermanenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudPermanenza.TextEditorWidth = 81
      '
      'cmdModifica
      '
      Me.cmdModifica.Id = "aab3f02f-946d-4c46-8a83-c8b121184f6d"
      Me.cmdModifica.Location = New System.Drawing.Point(907, 184)
      Me.cmdModifica.Name = "cmdModifica"
      Me.cmdModifica.Size = New System.Drawing.Size(104, 50)
      Me.cmdModifica.TabIndex = 4
      Me.cmdModifica.Text = "&Modifica"
      '
      'frmInsClienti
      '
      Me.AcceptButton = Me.cmdInserisci
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdEsci
      Me.ClientSize = New System.Drawing.Size(1020, 541)
      Me.Controls.Add(Me.cmdModifica)
      Me.Controls.Add(Me.nudPermanenza)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmdEsci)
      Me.Controls.Add(Me.cmdInserisci)
      Me.Controls.Add(Me.cmdNuovo)
      Me.Controls.Add(Me.lvwClienti)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmInsClienti"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Elenco Clienti"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudPermanenza, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public IPren As New PrenCamere

   Const TAB_CLIENTI As String = "Clienti"

   Dim frmChiamante As String
   Dim filtroChiamante As String

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Public Function ApriClienti(ByVal val As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_CLIENTI, cn, cmd)) = True Then
                  Exit Function
               End If
            End If
         End If

         Dim frm As New frmClienti
         frm.Tag = val

         If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub frmInsClienti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica l'elenco dei clienti.
         CaricaClienti()

         ' Imposta il numero dei giorni di permanenza al valore della prenotazione.
         If IsNumeric(Me.Tag) = True Then
            nudPermanenza.Value = Convert.ToDecimal(Me.Tag)
         Else
            nudPermanenza.Value = 0
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Public Sub CaricaClienti()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_CLIENTI & " WHERE TipoAlloggiato = '" & filtroChiamante & "' ORDER BY Cognome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lvwClienti.Items.Clear()

         Do While dr.Read()
            ' Indice
            lvwClienti.Items.Add(lvwClienti.Items.Count)

            ' Cognome.
            If IsDBNull(dr.Item("Cognome")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("Cognome"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Nome.
            If IsDBNull(dr.Item("Nome")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("Nome"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Sesso.
            If IsDBNull(dr.Item("Sesso")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("Sesso"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Data di nascita.
            If IsDBNull(dr.Item("DataNascita")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("DataNascita"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Luogo di nascita.
            If IsDBNull(dr.Item("LuogoNascita")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("LuogoNascita"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Provincia.
            If IsDBNull(dr.Item("ProvNascita")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("ProvNascita"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Nazione nascita.
            If IsDBNull(dr.Item("NazioneNascita")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("NazioneNascita"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Tipo alloggiato.
            If IsDBNull(dr.Item("TipoAlloggiato")) = False Then
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("TipoAlloggiato"))
            Else
               lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add("")
            End If

            ' Codice.
            lvwClienti.Items(lvwClienti.Items.Count - 1).SubItems.Add(dr.Item("Id"))

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub InserisciClientePren(ByVal codice As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_CLIENTI & " WHERE Id = " & codice & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            With g_frmPrenCamera

               ' Indice
               .lvwOccupanti.Items.Add(.lvwOccupanti.Items.Count)

               ' Cognome.
               If IsDBNull(dr.Item("Cognome")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Cognome"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Nome.
               If IsDBNull(dr.Item("Nome")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Nome"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Sesso.
               If IsDBNull(dr.Item("Sesso")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Sesso"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Data di nascita.
               If IsDBNull(dr.Item("DataNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("DataNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Luogo di nascita.
               If IsDBNull(dr.Item("LuogoNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("LuogoNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Provincia.
               If IsDBNull(dr.Item("ProvNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("ProvNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Stato di nascita.
               If IsDBNull(dr.Item("NazioneNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("NazioneNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Giorni di permanenza.
               .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(nudPermanenza.Value.ToString)

               ' Tipo alloggiato.
               If IsDBNull(dr.Item("TipoAlloggiato")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("TipoAlloggiato"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Codice.
               .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Id"))

               ' Cittadinanza.
               If IsDBNull(dr.Item("Nazionalità")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Nazionalità"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Data di Arrivo.
               .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(FormattaData(.mcDataArrivo.SelectionRange.Start.Date, True))

            End With

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub InserisciClienteSchedine(ByVal codice As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_CLIENTI & " WHERE Id = " & codice & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            With g_frmSchedinaPS

               ' Indice
               .lvwOccupanti.Items.Add(.lvwOccupanti.Items.Count)

               ' Cognome.
               If IsDBNull(dr.Item("Cognome")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Cognome"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Nome.
               If IsDBNull(dr.Item("Nome")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Nome"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Sesso.
               If IsDBNull(dr.Item("Sesso")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Sesso"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Data di nascita.
               If IsDBNull(dr.Item("DataNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("DataNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Luogo di nascita.
               If IsDBNull(dr.Item("LuogoNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("LuogoNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Provincia.
               If IsDBNull(dr.Item("ProvNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("ProvNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Stato di nascita.
               If IsDBNull(dr.Item("NazioneNascita")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("NazioneNascita"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Giorni di permanenza.
               .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(nudPermanenza.Value.ToString)

               ' Tipo alloggiato.
               If IsDBNull(dr.Item("TipoAlloggiato")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("TipoAlloggiato"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Codice.
               .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Id"))

               ' Cittadinanza.
               If IsDBNull(dr.Item("Nazionalità")) = False Then
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(dr.Item("Nazionalità"))
               Else
                  .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add("")
               End If

               ' Data di Arrivo.
               .lvwOccupanti.Items(.lvwOccupanti.Items.Count - 1).SubItems.Add(FormattaData(.mcDataArrivo.SelectionRange.Start.Date, True))

            End With

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub cmdInserisci_Click(sender As System.Object, e As System.EventArgs) Handles cmdInserisci.Click
      Try
         If lvwClienti.Items.Count <> 0 Then

            If nudPermanenza.Value = 0 Then
               MessageBox.Show("Inserire il numero dei giorni di permanenza!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               nudPermanenza.Focus()
               Exit Sub
            End If

            lvwClienti.Focus()

            ' Inserisce il cliente selezionato nel'elenco dei componenti.
            Select Case frmChiamante

               Case "Prenotazioni"
                  InserisciClientePren(lvwClienti.Items(lvwClienti.FocusedItem.Index).SubItems(9).Text)

               Case "Schedine"
                  InserisciClienteSchedine(lvwClienti.Items(lvwClienti.FocusedItem.Index).SubItems(9).Text)

            End Select

            lvwClienti.Focus()

            ' L'elemento inserito viene rimosso dall'elenco.
            lvwClienti.Items(lvwClienti.FocusedItem.Index).Remove()

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdNuovo_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuovo.Click
      Try
         ' Apre l'anagrafica Clienti per l'inserimento di un nuovo nominativo.
         If ApriClienti("") = True Then
            CaricaClienti()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdModifica_Click(sender As Object, e As EventArgs) Handles cmdModifica.Click
      Try
         ' Apre l'anagrafica Clienti per la modifica.
         If ApriClienti(lvwClienti.Items(lvwClienti.FocusedItem.Index).SubItems(9).Text) = True Then
            CaricaClienti()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class
