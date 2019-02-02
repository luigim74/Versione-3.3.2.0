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
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdQuantit�Meno As Elegant.Ui.Button
   Friend WithEvents eui_cmdQuantit�Pi� As Elegant.Ui.Button
   Friend WithEvents eui_cmdDettagliSu As Elegant.Ui.Button
   Friend WithEvents eui_cmdDettagliGi� As Elegant.Ui.Button
   Friend WithEvents eui_cmdTotBuoni As Elegant.Ui.Button
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
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElencoBuoniPos))
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
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdDettagliSu = New Elegant.Ui.Button()
      Me.eui_cmdDettagliGi� = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdQuantit�Meno = New Elegant.Ui.Button()
      Me.eui_cmdQuantit�Pi� = New Elegant.Ui.Button()
      Me.eui_cmdTotBuoni = New Elegant.Ui.Button()
      Me.SuspendLayout()
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
      Me.ColumnHeader1.Text = "Quantit�"
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
      Me.ColumnHeader7.Text = "Quantit�Tot"
      Me.ColumnHeader7.Width = 0
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "ValoreTotale"
      Me.ColumnHeader8.Width = 0
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Quantit�Fatt"
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
      Me.Label10.Text = "Q.t�   Descrizione                                                               " &
    "        Valore in Euro"
      Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdDettagliSu
      '
      Me.eui_cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDettagliSu.Id = "5c947423-d5b5-4fc6-bb28-e19324373a51"
      Me.eui_cmdDettagliSu.Location = New System.Drawing.Point(186, 509)
      Me.eui_cmdDettagliSu.Name = "eui_cmdDettagliSu"
      Me.eui_cmdDettagliSu.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdDettagliSu.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdDettagliSu.Size = New System.Drawing.Size(180, 53)
      Me.eui_cmdDettagliSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdDettagliSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdDettagliSu.TabIndex = 2
      '
      'eui_cmdDettagliGi�
      '
      Me.eui_cmdDettagliGi�.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDettagliGi�.Id = "5f2815e6-29cd-4bfc-a36a-7064ac0eca0b"
      Me.eui_cmdDettagliGi�.Location = New System.Drawing.Point(9, 509)
      Me.eui_cmdDettagliGi�.Name = "eui_cmdDettagliGi�"
      Me.eui_cmdDettagliGi�.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdDettagliGi�.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdDettagliGi�.Size = New System.Drawing.Size(177, 53)
      Me.eui_cmdDettagliGi�.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdDettagliGi�.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdDettagliGi�.TabIndex = 1
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "f590b840-674e-4f13-8180-15184c3dad6e"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(540, 220)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 6
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "0ec8ec7f-78d7-4776-85f9-3dd62a48183b"
      Me.eui_cmdOk.Location = New System.Drawing.Point(540, 156)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 5
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdQuantit�Meno
      '
      Me.eui_cmdQuantit�Meno.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdQuantit�Meno.Id = "55059ea5-3980-42fb-85b7-fff54065541c"
      Me.eui_cmdQuantit�Meno.Location = New System.Drawing.Point(540, 72)
      Me.eui_cmdQuantit�Meno.Name = "eui_cmdQuantit�Meno"
      Me.eui_cmdQuantit�Meno.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdQuantit�Meno.TabIndex = 4
      Me.eui_cmdQuantit�Meno.Text = "&-1"
      '
      'eui_cmdQuantit�Pi�
      '
      Me.eui_cmdQuantit�Pi�.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdQuantit�Pi�.Id = "c2dd9208-7815-49b4-903b-5aa063652df8"
      Me.eui_cmdQuantit�Pi�.Location = New System.Drawing.Point(540, 8)
      Me.eui_cmdQuantit�Pi�.Name = "eui_cmdQuantit�Pi�"
      Me.eui_cmdQuantit�Pi�.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdQuantit�Pi�.TabIndex = 3
      Me.eui_cmdQuantit�Pi�.Text = "&+1"
      '
      'eui_cmdTotBuoni
      '
      Me.eui_cmdTotBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdTotBuoni.Id = "ae40250d-4e83-4fff-9051-fed3a387ff2b"
      Me.eui_cmdTotBuoni.Location = New System.Drawing.Point(366, 509)
      Me.eui_cmdTotBuoni.Name = "eui_cmdTotBuoni"
      Me.eui_cmdTotBuoni.Size = New System.Drawing.Size(162, 53)
      Me.eui_cmdTotBuoni.TabIndex = 7
      Me.eui_cmdTotBuoni.Text = "0,00"
      '
      'frmElencoBuoniPos
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(678, 576)
      Me.Controls.Add(Me.eui_cmdTotBuoni)
      Me.Controls.Add(Me.eui_cmdQuantit�Meno)
      Me.Controls.Add(Me.eui_cmdQuantit�Pi�)
      Me.Controls.Add(Me.eui_cmdDettagliSu)
      Me.Controls.Add(Me.eui_cmdDettagliGi�)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.Label10)
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

            ' Quantit�
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

            ' Quantit� totale.
            If IsDBNull(dr.Item("Quantit�")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Quantit�"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Valore totale.
            If IsDBNull(dr.Item("ValoreTotale")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("ValoreTotale"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Quantit� fatturazione.
            If IsDBNull(dr.Item("Quantit�Fatt")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Quantit�Fatt"))
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

                  Dim quantit� As Integer = 0
                  If IsNumeric(lstvDettagli.Items(i).SubItems(1).Text) = True Then
                     quantit� = Convert.ToInt32(lstvDettagli.Items(i).SubItems(1).Text)
                  End If

                  Dim valoreUnitario As Double = 0
                  If IsNumeric(lstvDettagli.Items(i).SubItems(3).Text) = True Then
                     valoreUnitario = Convert.ToDouble(lstvDettagli.Items(i).SubItems(3).Text)
                  End If

                  Dim quantit�Tot As Integer = 0
                  If IsNumeric(lstvDettagli.Items(i).SubItems(6).Text) = True Then
                     quantit�Tot = quantit� + Convert.ToInt32(lstvDettagli.Items(i).SubItems(6).Text)
                  End If

                  Dim valoreTot As Double = 0
                  If IsNumeric(lstvDettagli.Items(i).SubItems(7).Text) = True Then
                     valoreTot = quantit�Tot * valoreUnitario
                  End If

                  Dim quantit�Fatt As Integer = 0
                  If IsNumeric(lstvDettagli.Items(i).SubItems(8).Text) = True Then
                     quantit�Fatt = quantit� + Convert.ToInt32(lstvDettagli.Items(i).SubItems(8).Text)
                  End If

                  Dim valoreFatt As Double = 0
                  If IsNumeric(lstvDettagli.Items(i).SubItems(9).Text) = True Then
                     valoreFatt = quantit�Fatt * valoreUnitario
                  End If

                  ' Quantit�
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(quantit�.ToString)

                  ' Descrizione.
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(2))

                  ' Valore unitario.
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(valoreUnitario.ToString)

                  ' IdBuono.
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(4))

                  ' IdAzienda.
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(5))

                  ' Quantit� totale.
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(quantit�Tot.ToString)

                  ' Valore totale.
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(valoreTot.ToString)

                  ' Quantit� fatturazione.
                  .lstvDatiBuoni.Items(.lstvDatiBuoni.Items.Count - 1).SubItems.Add(quantit�Fatt.ToString)

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

            Dim quantit� As Integer = Convert.ToInt32(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text)
            Dim prezzo As Decimal

            If val = True Then
               quantit� += 1
               EvidenziaElemento(True)
            Else
               If quantit� = 0 Then
                  Exit Sub
               Else
                  quantit� -= 1
                  If quantit� = 0 Then
                     EvidenziaElemento(False)
                  End If
               End If
            End If

            lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text = quantit�

            totValBuoni = 0
            Dim i As Integer
            For i = 0 To lstvDettagli.Items.Count - 1
               quantit� = lstvDettagli.Items(i).SubItems(1).Text
               prezzo = lstvDettagli.Items(i).SubItems(3).Text
               ' Calcola il prezzo totale in base alla quantit� inserita.
               totValBuoni = totValBuoni + (prezzo * quantit�)
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

   Private Sub lstvDettagli_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvDettagli.Resize
      Try
         NumElementi = (lstvDettagli.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdDettagliGi�_Click(sender As Object, e As EventArgs) Handles eui_cmdDettagliGi�.Click
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

   Private Sub eui_cmdDettagliSu_Click(sender As Object, e As EventArgs) Handles eui_cmdDettagliSu.Click
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

   Private Sub eui_cmdQuantit�Pi�_Click(sender As Object, e As EventArgs) Handles eui_cmdQuantit�Pi�.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      AumentaDiminuisciQta(True)
      eui_cmdTotBuoni.Text = CFormatta.FormattaEuro(totValBuoni)
   End Sub

   Private Sub eui_cmdQuantit�Meno_Click(sender As Object, e As EventArgs) Handles eui_cmdQuantit�Meno.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      AumentaDiminuisciQta(False)
      eui_cmdTotBuoni.Text = CFormatta.FormattaEuro(totValBuoni)
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Dim valDaPagare As Decimal = Convert.ToDecimal(g_frmContoPos.netBtn_DaPagare.TextButton)

      If totValBuoni <= valDaPagare Then
         CaricaListaBuoniPasto()
         Me.Tag = CFormatta.FormattaEuro(totValBuoni)
         Me.Close()
      Else
         MessageBox.Show("La somma dei Buoni pagati � superiore alla somma del Conto da pagare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Me.DialogResult = DialogResult.None
      End If

   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub
End Class
