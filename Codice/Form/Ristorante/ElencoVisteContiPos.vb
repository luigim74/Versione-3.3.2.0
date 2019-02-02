
Public Class ElencoVisteContiPos
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"
   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"
   Const ALTEZZA_RIGA_DETTAGLI As Short = 24

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents lstvViste As ListView
   Friend WithEvents Id As ColumnHeader
   Friend WithEvents VistaConto As ColumnHeader
   Friend WithEvents IdCliente As ColumnHeader
   Friend WithEvents eui_cmdVisteSu As Elegant.Ui.Button
   Friend WithEvents eui_cmdVisteGiù As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button

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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Azienda Ligure SRL", "Luigi Montana"}, -1)
      Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Montana Luigi")
      Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Rossi Fabio")
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoVisteContiPos))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.lstvViste = New System.Windows.Forms.ListView()
      Me.Id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.VistaConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.IdCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.eui_cmdVisteSu = New Elegant.Ui.Button()
      Me.eui_cmdVisteGiù = New Elegant.Ui.Button()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "731a82e5-f70c-4ddf-b28b-f1ffa872b5a8"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(463, 500)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(107, 53)
      Me.eui_cmdAnnulla.TabIndex = 4
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "81a66019-7a4d-49cb-99a0-096b15af1ba0"
      Me.eui_cmdOk.Location = New System.Drawing.Point(463, 436)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(107, 53)
      Me.eui_cmdOk.TabIndex = 3
      Me.eui_cmdOk.Text = "&OK"
      '
      'lstvViste
      '
      Me.lstvViste.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvViste.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Id, Me.VistaConto, Me.IdCliente})
      Me.lstvViste.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvViste.FullRowSelect = True
      Me.lstvViste.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
      Me.lstvViste.Location = New System.Drawing.Point(12, 12)
      Me.lstvViste.MultiSelect = False
      Me.lstvViste.Name = "lstvViste"
      Me.lstvViste.Size = New System.Drawing.Size(437, 541)
      Me.lstvViste.TabIndex = 0
      Me.lstvViste.UseCompatibleStateImageBehavior = False
      Me.lstvViste.View = System.Windows.Forms.View.Details
      '
      'Id
      '
      Me.Id.DisplayIndex = 2
      Me.Id.Text = ""
      Me.Id.Width = 0
      '
      'VistaConto
      '
      Me.VistaConto.DisplayIndex = 0
      Me.VistaConto.Text = "Vista"
      Me.VistaConto.Width = 400
      '
      'IdCliente
      '
      Me.IdCliente.DisplayIndex = 1
      Me.IdCliente.Text = ""
      Me.IdCliente.Width = 0
      '
      'eui_cmdVisteSu
      '
      Me.eui_cmdVisteSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdVisteSu.Id = "eff448d3-6869-43b2-8215-d2bfa94b3f25"
      Me.eui_cmdVisteSu.Location = New System.Drawing.Point(463, 12)
      Me.eui_cmdVisteSu.Name = "eui_cmdVisteSu"
      Me.eui_cmdVisteSu.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdVisteSu.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdVisteSu.Size = New System.Drawing.Size(107, 53)
      Me.eui_cmdVisteSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdVisteSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdVisteSu.TabIndex = 1
      '
      'eui_cmdVisteGiù
      '
      Me.eui_cmdVisteGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdVisteGiù.Id = "e60d1a07-4d2e-4ed2-8d85-8f709bff129e"
      Me.eui_cmdVisteGiù.Location = New System.Drawing.Point(463, 77)
      Me.eui_cmdVisteGiù.Name = "eui_cmdVisteGiù"
      Me.eui_cmdVisteGiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdVisteGiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdVisteGiù.Size = New System.Drawing.Size(107, 53)
      Me.eui_cmdVisteGiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdVisteGiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdVisteGiù.TabIndex = 2
      '
      'ElencoVisteContiPos
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(579, 564)
      Me.Controls.Add(Me.eui_cmdVisteSu)
      Me.Controls.Add(Me.eui_cmdVisteGiù)
      Me.Controls.Add(Me.lstvViste)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ElencoVisteContiPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "ELENCO VISTE"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Public Sub CaricaListaViste(ByVal lstv As ListView)
      Try

         lstv.Items.Clear()

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< TUTTI >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< APERTI >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< CHIUSI >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< STAMPATI >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< ANNO CORRENTE >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< MESE CORRENTE >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< OGGI >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< PERIODO >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         ' Id.
         lstv.Items.Add(lstv.Items.Count)
         ' Descrizione.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< SENZA INTESTAZIONE >")
         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaCliente(ByVal lstv As ListView, ByVal tabella As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Cognome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            ' Id.
            lstv.Items.Add(lstv.Items.Count)

            ' Cliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Cognome").ToString & " " & dr.Item("Nome").ToString)

            ' IdCliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaClienteAzienda(ByVal lstv As ListView, ByVal tabella As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY RagSociale ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            ' Id.
            lstv.Items.Add(lstv.Items.Count)

            ' Cliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("RagSociale").ToString)

            ' IdCliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ElencoVisteContiPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         CaricaListaViste(lstvViste)

         CaricaListaClienteAzienda(lstvViste, ANA_AZIENDE)

         CaricaListaCliente(lstvViste, ANA_CLIENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Descrizione.
         Me.Text = lstvViste.Items(lstvViste.FocusedItem.Index).SubItems(1).Text

         ' Id.
         Me.Tag = lstvViste.Items(lstvViste.FocusedItem.Index).SubItems(2).Text

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub eui_cmdVisteSu_Click(sender As Object, e As EventArgs) Handles eui_cmdVisteSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvViste.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvViste.TopItem.Index

         IndiceLista = PrimoElemento - 1

         If IndiceLista < 0 Then
            Exit Sub
         Else
            lstvViste.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdVisteGiù_Click(sender As Object, e As EventArgs) Handles eui_cmdVisteGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvViste.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvViste.TopItem.Index

         IndiceLista = PrimoElemento + NumElementi

         If IndiceLista > lstvViste.Items.Count - 1 Then
            Exit Sub
         Else
            lstvViste.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvViste_Resize(sender As Object, e As EventArgs) Handles lstvViste.Resize
      Try
         NumElementi = (lstvViste.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvViste_DoubleClick(sender As Object, e As EventArgs) Handles lstvViste.DoubleClick
      Try
         eui_cmdOk.PerformClick()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class
