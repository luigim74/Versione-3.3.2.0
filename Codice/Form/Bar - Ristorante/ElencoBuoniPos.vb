' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 10/08/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class frmElencoBuoniPos
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni "

   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

   Dim TAB_BUONI_PASTO = "BuoniPasto"
   Private CFormatta As New ClsFormatta

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Dim totValBuoni As Decimal

#End Region

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()
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
   Friend WithEvents cmdEsci As System.Windows.Forms.Button
   Friend WithEvents cmdQuantitàMeno As System.Windows.Forms.Button
   Friend WithEvents cmdQuantitàPiù As System.Windows.Forms.Button
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdOk As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliSu As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliGiù As System.Windows.Forms.Button
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdTotBuoni As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoBuoniPos))
      Me.cmdQuantitàMeno = New System.Windows.Forms.Button()
      Me.cmdEsci = New System.Windows.Forms.Button()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.cmdQuantitàPiù = New System.Windows.Forms.Button()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cmdDettagliSu = New System.Windows.Forms.Button()
      Me.cmdDettagliGiù = New System.Windows.Forms.Button()
      Me.cmdTotBuoni = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.SuspendLayout()
      '
      'cmdQuantitàMeno
      '
      Me.cmdQuantitàMeno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdQuantitàMeno.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdQuantitàMeno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdQuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdQuantitàMeno.ForeColor = System.Drawing.Color.White
      Me.cmdQuantitàMeno.Location = New System.Drawing.Point(540, 80)
      Me.cmdQuantitàMeno.Name = "cmdQuantitàMeno"
      Me.cmdQuantitàMeno.Size = New System.Drawing.Size(160, 64)
      Me.cmdQuantitàMeno.TabIndex = 4
      Me.cmdQuantitàMeno.Text = "&-1"
      Me.cmdQuantitàMeno.UseVisualStyleBackColor = False
      '
      'cmdEsci
      '
      Me.cmdEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdEsci.BackColor = System.Drawing.Color.LightCoral
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEsci.ForeColor = System.Drawing.Color.White
      Me.cmdEsci.Location = New System.Drawing.Point(540, 224)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(160, 64)
      Me.cmdEsci.TabIndex = 6
      Me.cmdEsci.Text = "&ESCI"
      Me.cmdEsci.UseVisualStyleBackColor = False
      '
      'cmdOk
      '
      Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOk.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdOk.ForeColor = System.Drawing.Color.White
      Me.cmdOk.Location = New System.Drawing.Point(540, 152)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(160, 64)
      Me.cmdOk.TabIndex = 5
      Me.cmdOk.Text = "&OK"
      Me.cmdOk.UseVisualStyleBackColor = False
      '
      'cmdQuantitàPiù
      '
      Me.cmdQuantitàPiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdQuantitàPiù.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdQuantitàPiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdQuantitàPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdQuantitàPiù.ForeColor = System.Drawing.Color.White
      Me.cmdQuantitàPiù.Location = New System.Drawing.Point(540, 8)
      Me.cmdQuantitàPiù.Name = "cmdQuantitàPiù"
      Me.cmdQuantitàPiù.Size = New System.Drawing.Size(160, 64)
      Me.cmdQuantitàPiù.TabIndex = 3
      Me.cmdQuantitàPiù.Text = "&+1"
      Me.cmdQuantitàPiù.UseVisualStyleBackColor = False
      '
      'lstvDettagli
      '
      Me.lstvDettagli.BackColor = System.Drawing.Color.White
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagli.Location = New System.Drawing.Point(8, 47)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(520, 457)
      Me.lstvDettagli.TabIndex = 0
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Width = 0
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Quantità"
      Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader1.Width = 40
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Descrizione"
      Me.ColumnHeader2.Width = 360
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Valore"
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 100
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "IdBuono"
      Me.ColumnHeader5.Width = 0
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Text = "IdAzienda"
      Me.ColumnHeader6.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "QuantitàTot"
      Me.ColumnHeader7.Width = 0
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "ValoreTotale"
      Me.ColumnHeader8.Width = 0
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "QuantitàFatt"
      Me.ColumnHeader9.Width = 0
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "ValoreFatt"
      Me.ColumnHeader10.Width = 0
      '
      'Label10
      '
      Me.Label10.BackColor = System.Drawing.Color.White
      Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(8, 8)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(520, 40)
      Me.Label10.TabIndex = 7
      Me.Label10.Text = "Q.tà   Descrizione                                                               " & _
    "           Valore in Euro"
      Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cmdDettagliSu
      '
      Me.cmdDettagliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliSu.Image = CType(resources.GetObject("cmdDettagliSu.Image"), System.Drawing.Image)
      Me.cmdDettagliSu.Location = New System.Drawing.Point(272, 516)
      Me.cmdDettagliSu.Name = "cmdDettagliSu"
      Me.cmdDettagliSu.Size = New System.Drawing.Size(256, 40)
      Me.cmdDettagliSu.TabIndex = 2
      Me.cmdDettagliSu.UseVisualStyleBackColor = False
      '
      'cmdDettagliGiù
      '
      Me.cmdDettagliGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliGiù.Image = CType(resources.GetObject("cmdDettagliGiù.Image"), System.Drawing.Image)
      Me.cmdDettagliGiù.Location = New System.Drawing.Point(8, 516)
      Me.cmdDettagliGiù.Name = "cmdDettagliGiù"
      Me.cmdDettagliGiù.Size = New System.Drawing.Size(256, 40)
      Me.cmdDettagliGiù.TabIndex = 1
      Me.cmdDettagliGiù.UseVisualStyleBackColor = False
      '
      'cmdTotBuoni
      '
      Me.cmdTotBuoni.BackColor = System.Drawing.Color.White
      Me.cmdTotBuoni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTotBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTotBuoni.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdTotBuoni.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdTotBuoni.Location = New System.Drawing.Point(540, 440)
      Me.cmdTotBuoni.Name = "cmdTotBuoni"
      Me.cmdTotBuoni.Size = New System.Drawing.Size(160, 64)
      Me.cmdTotBuoni.TabIndex = 230
      Me.cmdTotBuoni.Text = "0,00"
      Me.cmdTotBuoni.UseVisualStyleBackColor = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmElencoBuoniPos
      '
      Me.AcceptButton = Me.cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdEsci
      Me.ClientSize = New System.Drawing.Size(706, 568)
      Me.Controls.Add(Me.cmdTotBuoni)
      Me.Controls.Add(Me.cmdDettagliSu)
      Me.Controls.Add(Me.cmdDettagliGiù)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.cmdOk)
      Me.Controls.Add(Me.cmdQuantitàPiù)
      Me.Controls.Add(Me.cmdQuantitàMeno)
      Me.Controls.Add(Me.cmdEsci)
      Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmElencoBuoniPos"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Elenco Buoni Pasto"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Public Sub LeggiDatiBuoniPasto(ByVal tabella As String)
      Const QTA As String = "0"
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Indice
            lstvDettagli.Items.Add(lstvDettagli.Items.Count)

            ' Quantità
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Valore unitario.
            If IsDBNull(dr.Item("ValoreUnitario")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(CFormatta.FormattaEuro(dr.Item("ValoreUnitario")))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' IdBuono.
            If IsDBNull(dr.Item("Id")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Id"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' IdAzienda.
            If IsDBNull(dr.Item("IdAzienda")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("IdAzienda"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Quantità totale.
            If IsDBNull(dr.Item("Quantità")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Quantità"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Valore totale.
            If IsDBNull(dr.Item("ValoreTotale")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("ValoreTotale"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Quantità fatturazione.
            If IsDBNull(dr.Item("QuantitàFatt")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("QuantitàFatt"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Valore fatturazione.
            If IsDBNull(dr.Item("ValoreFatt")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("ValoreFatt"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaBuoniPasto()
      Try
         With g_frmContoPos
            .lstvDatiBuoni.Items.Clear()

            Dim i As Integer
            For i = 0 To lstvDettagli.Items.Count - 1
               Dim coloreFatt As Color = lstvDettagli.Items(i).BackColor
               If coloreFatt.Equals(Color.MediumSeaGreen) = True Then
                  ' Indice
                     .lstvDatiBuoni.Items.Add(.lstvDatiBuoni.Items.Count - 1)

                     Dim quantità As Integer = 0
                     If IsNumeric(lstvDettagli.Items(i).SubItems(1).Text) = True Then
                        quantità = Convert.ToInt32(lstvDettagli.Items(i).SubItems(1).Text)
                     End If

                     Dim valoreUnitario As Double = 0
                     If IsNumeric(lstvDettagli.Items(i).SubItems(3).Text) = True Then
                        valoreUnitario = Convert.ToDouble(lstvDettagli.Items(i).SubItems(3).Text)
                     End If

                     Dim quantitàTot As Integer = 0
                     If IsNumeric(lstvDettagli.Items(i).SubItems(6).Text) = True Then
                        quantitàTot = quantità + Convert.ToInt32(lstvDettagli.Items(i).SubItems(6).Text)
                     End If

                     Dim valoreTot As Double = 0
                     If IsNumeric(lstvDettagli.Items(i).SubItems(7).Text) = True Then
                        valoreTot = quantitàTot * valoreUnitario
                     End If

                     Dim quantitàFatt As Integer = 0
                     If IsNumeric(lstvDettagli.Items(i).SubItems(8).Text) = True Then
                        quantitàFatt = quantità + Convert.ToInt32(lstvDettagli.Items(i).SubItems(8).Text)
                     End If

                     Dim valoreFatt As Double = 0
                     If IsNumeric(lstvDettagli.Items(i).SubItems(9).Text) = True Then
                        valoreFatt = quantitàFatt * valoreUnitario
                     End If

                     ' Quantità
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(quantità.ToString)

                     ' Descrizione.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(2))

                     ' Valore unitario.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(valoreUnitario.ToString)

                     ' IdBuono.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(4))

                     ' IdAzienda.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(5))

                     ' Quantità totale.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(quantitàTot.ToString)

                     ' Valore totale.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(valoreTot.ToString)

                     ' Quantità fatturazione.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(quantitàFatt.ToString)

                     ' Valore fatturazione.
                     .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(valoreFatt.ToString)
               End If
            Next
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub AumentaDiminuisciQta(ByVal val As Boolean)
      ' Vero: aumenta di 1 - Falso: diminuisce di 1.
      Try
         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()

            Dim quantità As Integer = Convert.ToInt32(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text)
            Dim prezzo As Decimal

            If val = True Then
               quantità += 1
               EvidenziaElemento(True)
            Else
               If quantità = 0 Then
                  Exit Sub
               Else
                  quantità -= 1
                  If quantità = 0 Then
                     EvidenziaElemento(False)
                  End If
               End If
            End If

            lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text = quantità

            totValBuoni = 0
            Dim i As Integer
            For i = 0 To lstvDettagli.Items.Count - 1
               quantità = lstvDettagli.Items(i).SubItems(1).Text
               prezzo = lstvDettagli.Items(i).SubItems(3).Text
               ' Calcola il prezzo totale in base alla quantità inserita.
               totValBuoni = totValBuoni + (prezzo * quantità)
            Next

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EvidenziaElemento(ByVal val As Boolean)
      Try
         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()

            Dim colore As String = Convert.ToString(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor.ToArgb)

            If val = False Then
               If colore = Convert.ToString(Color.White.ToArgb) Then
                  Exit Sub
               End If
               ' Imposta il nero.
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.White
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.Black
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
            Else
               If colore = Convert.ToString(Color.MediumSeaGreen.ToArgb) Then
                  Exit Sub
               End If
               ' Imposta il verde.
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.MediumSeaGreen
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.White
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmElencoBuoniPasto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         LeggiDatiBuoniPasto(TAB_BUONI_PASTO)

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Items(0).Focused = True
            lstvDettagli.Items(0).Selected = True
            lstvDettagli.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmElencoBuoniPasto_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Dim valDaPagare As Decimal = g_frmContoPos.txtDaPagare.Text

      If totValBuoni <= valDaPagare Then
         CaricaListaBuoniPasto()
         Me.Tag = CFormatta.FormattaEuro(totValBuoni)
         Me.Close()
      Else
         MessageBox.Show("La somma dei Buoni pagati è superiore alla somma del Conto da pagare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Me.DialogResult = DialogResult.None
      End If
   End Sub

   Private Sub cmdEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdDettagliGiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDettagliGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvDettagli.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvDettagli.TopItem.Index

         IndiceLista = PrimoElemento + NumElementi

         If IndiceLista > lstvDettagli.Items.Count - 1 Then
            Exit Sub
         Else
            lstvDettagli.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdDettagliSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDettagliSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvDettagli.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvDettagli.TopItem.Index

         IndiceLista = PrimoElemento - 1

         If IndiceLista < 0 Then
            Exit Sub
         Else
            lstvDettagli.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvDettagli_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvDettagli.Resize
      Try
         NumElementi = (lstvDettagli.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdQuantitàPiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuantitàPiù.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      AumentaDiminuisciQta(True)
      cmdTotBuoni.Text = CFormatta.FormattaEuro(totValBuoni)
   End Sub

   Private Sub cmdQuantitàMeno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuantitàMeno.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      AumentaDiminuisciQta(False)
      cmdTotBuoni.Text = CFormatta.FormattaEuro(totValBuoni)
   End Sub

End Class
