' Nome form:            ModificaPiattoPOS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       24/10/2015
' Data ultima modifica: 24/10/2015
' Descrizione:          Finestra di modifica piatti.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb
Imports Softgroup.NetButton

Public Class ModificaPiattoPOS
   Inherits System.Windows.Forms.Form

   Private CConvalida As New ConvalidaKeyPress

   Const ANA_PIATTI As String = "Piatti"

   Dim idPiattoSelezionato As String

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String
   Dim CFormatta As New ClsFormatta

   ' Per la moltiplicazione.
   Private moltiplica As Boolean
   Private op1 As Double = 0
   Private op2 As Double = 0

   Private NumListino As Short

   Public aliquotaIvaPiatto As String

   Public Enum Listino As Short
      Uno = 1
      Due = 2
      Tre = 3
      Quattro = 4
   End Enum


#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal idPiatto As String, ByVal quantità As String, ByVal descrizione As String, ByVal prezzo As String, ByVal totPrezzo As String, ByVal aliquotaIva As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

      idPiattoSelezionato = idPiatto
      eui_txtQuantità.Text = quantità
      eui_txtDescrizione.Text = descrizione
      eui_txtPrezzo.Text = CFormatta.FormattaEuro(prezzo)
      netBtn_Totale.TextButton = CFormatta.FormattaEuro(totPrezzo)
      aliquotaIvaPiatto = aliquotaIva

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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdIva As Elegant.Ui.Button
   Friend WithEvents eui_cmdListino As Elegant.Ui.Button
   Friend WithEvents eui_cmdQuantitàMeno As Elegant.Ui.Button
   Friend WithEvents eui_cmdQuantitàPiù As Elegant.Ui.Button
   Friend WithEvents eui_cmdIngredienti As Elegant.Ui.Button
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents Label34 As Elegant.Ui.Label
   Friend WithEvents netBtn_C As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_9 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_8 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_7 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Ok As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Percentuale As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_X As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_00 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_0 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Virgola As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_3 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_2 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_1 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_6 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_5 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_4 As Softgroup.NetButton.NetButton
   Friend WithEvents Label2 As Elegant.Ui.Label
   Friend WithEvents eui_txtPrezzo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtDescrizione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtQuantità As Elegant.Ui.TextBox
   Friend WithEvents netBtn_Totale As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton1 As Softgroup.NetButton.NetButton
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificaPiattoPOS))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdListino = New Elegant.Ui.Button()
      Me.eui_cmdIva = New Elegant.Ui.Button()
      Me.eui_cmdIngredienti = New Elegant.Ui.Button()
      Me.eui_cmdQuantitàPiù = New Elegant.Ui.Button()
      Me.eui_cmdQuantitàMeno = New Elegant.Ui.Button()
      Me.Label34 = New Elegant.Ui.Label()
      Me.Label1 = New Elegant.Ui.Label()
      Me.netBtn_C = New Softgroup.NetButton.NetButton()
      Me.netBtn_9 = New Softgroup.NetButton.NetButton()
      Me.netBtn_8 = New Softgroup.NetButton.NetButton()
      Me.netBtn_7 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Ok = New Softgroup.NetButton.NetButton()
      Me.netBtn_Percentuale = New Softgroup.NetButton.NetButton()
      Me.netBtn_X = New Softgroup.NetButton.NetButton()
      Me.netBtn_00 = New Softgroup.NetButton.NetButton()
      Me.netBtn_0 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Virgola = New Softgroup.NetButton.NetButton()
      Me.netBtn_3 = New Softgroup.NetButton.NetButton()
      Me.netBtn_2 = New Softgroup.NetButton.NetButton()
      Me.netBtn_1 = New Softgroup.NetButton.NetButton()
      Me.netBtn_6 = New Softgroup.NetButton.NetButton()
      Me.netBtn_5 = New Softgroup.NetButton.NetButton()
      Me.netBtn_4 = New Softgroup.NetButton.NetButton()
      Me.Label2 = New Elegant.Ui.Label()
      Me.eui_txtQuantità = New Elegant.Ui.TextBox()
      Me.eui_txtDescrizione = New Elegant.Ui.TextBox()
      Me.eui_txtPrezzo = New Elegant.Ui.TextBox()
      Me.netBtn_Totale = New Softgroup.NetButton.NetButton()
      Me.NetButton1 = New Softgroup.NetButton.NetButton()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
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
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "0ff03341-583e-4c63-8adc-163fd9a16474"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(9, 368)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(80, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 24
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "712effff-0d29-4d2b-9a14-29e9c9177fae"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(359, 368)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 26
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "12768304-546b-46ee-b0f7-4cace93143e4"
      Me.eui_cmdOk.Location = New System.Drawing.Point(215, 368)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 25
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdListino
      '
      Me.eui_cmdListino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdListino.Id = "5cd40801-a389-44fd-8a4a-145cef3be2d0"
      Me.eui_cmdListino.Location = New System.Drawing.Point(361, 228)
      Me.eui_cmdListino.Name = "eui_cmdListino"
      Me.eui_cmdListino.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdListino.TabIndex = 22
      Me.eui_cmdListino.Text = "&Listino 1"
      '
      'eui_cmdIva
      '
      Me.eui_cmdIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdIva.Id = "4f7025a2-09b4-4c5c-a6bc-ca41ff96dc20"
      Me.eui_cmdIva.Location = New System.Drawing.Point(361, 291)
      Me.eui_cmdIva.Name = "eui_cmdIva"
      Me.eui_cmdIva.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdIva.TabIndex = 23
      Me.eui_cmdIva.Text = "&IVA"
      '
      'eui_cmdIngredienti
      '
      Me.eui_cmdIngredienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdIngredienti.Id = "78044281-2e71-4b81-ba15-d1e704df97e7"
      Me.eui_cmdIngredienti.Location = New System.Drawing.Point(361, 137)
      Me.eui_cmdIngredienti.Name = "eui_cmdIngredienti"
      Me.eui_cmdIngredienti.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdIngredienti.TabIndex = 21
      Me.eui_cmdIngredienti.Text = "Ig&redienti"
      '
      'eui_cmdQuantitàPiù
      '
      Me.eui_cmdQuantitàPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdQuantitàPiù.Id = "41eb5ff0-333a-40f5-bda0-944f470085ee"
      Me.eui_cmdQuantitàPiù.Location = New System.Drawing.Point(361, 74)
      Me.eui_cmdQuantitàPiù.Name = "eui_cmdQuantitàPiù"
      Me.eui_cmdQuantitàPiù.Size = New System.Drawing.Size(59, 53)
      Me.eui_cmdQuantitàPiù.TabIndex = 19
      Me.eui_cmdQuantitàPiù.Text = "+"
      '
      'eui_cmdQuantitàMeno
      '
      Me.eui_cmdQuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdQuantitàMeno.Id = "e02baf77-73f9-4a7e-a963-617be5ed9eaa"
      Me.eui_cmdQuantitàMeno.Location = New System.Drawing.Point(430, 74)
      Me.eui_cmdQuantitàMeno.Name = "eui_cmdQuantitàMeno"
      Me.eui_cmdQuantitàMeno.Size = New System.Drawing.Size(59, 53)
      Me.eui_cmdQuantitàMeno.TabIndex = 20
      Me.eui_cmdQuantitàMeno.Text = "-"
      '
      'Label34
      '
      Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label34.Location = New System.Drawing.Point(7, 9)
      Me.Label34.Name = "Label34"
      Me.Label34.Size = New System.Drawing.Size(66, 20)
      Me.Label34.TabIndex = 283
      Me.Label34.Text = "Quantità:"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(359, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(109, 20)
      Me.Label1.TabIndex = 284
      Me.Label1.Tag = ""
      Me.Label1.Text = "Prezzo unitario:"
      '
      'netBtn_C
      '
      Me.netBtn_C.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.netBtn_C.ColorDisabled = System.Drawing.Color.Brown
      Me.netBtn_C.ColorLight = System.Drawing.Color.MistyRose
      Me.netBtn_C.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.netBtn_C.ColorText = System.Drawing.Color.Black
      Me.netBtn_C.ColorTop = System.Drawing.Color.White
      Me.netBtn_C.CornerRadius = 2
      Me.netBtn_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_C.Location = New System.Drawing.Point(248, 137)
      Me.netBtn_C.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_C.Name = "netBtn_C"
      Me.netBtn_C.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_C.TabIndex = 6
      Me.netBtn_C.TextButton = "C"
      '
      'netBtn_9
      '
      Me.netBtn_9.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_9.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_9.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_9.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_9.ColorText = System.Drawing.Color.Black
      Me.netBtn_9.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_9.CornerRadius = 2
      Me.netBtn_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_9.Location = New System.Drawing.Point(169, 137)
      Me.netBtn_9.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_9.Name = "netBtn_9"
      Me.netBtn_9.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_9.TabIndex = 5
      Me.netBtn_9.TextButton = "9"
      '
      'netBtn_8
      '
      Me.netBtn_8.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_8.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_8.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_8.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_8.ColorText = System.Drawing.Color.Black
      Me.netBtn_8.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_8.CornerRadius = 2
      Me.netBtn_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_8.Location = New System.Drawing.Point(88, 137)
      Me.netBtn_8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_8.Name = "netBtn_8"
      Me.netBtn_8.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_8.TabIndex = 4
      Me.netBtn_8.TextButton = "8"
      '
      'netBtn_7
      '
      Me.netBtn_7.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_7.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_7.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_7.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_7.ColorText = System.Drawing.Color.Black
      Me.netBtn_7.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_7.CornerRadius = 2
      Me.netBtn_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_7.Location = New System.Drawing.Point(7, 137)
      Me.netBtn_7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_7.Name = "netBtn_7"
      Me.netBtn_7.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_7.TabIndex = 3
      Me.netBtn_7.TextButton = "7"
      '
      'netBtn_Ok
      '
      Me.netBtn_Ok.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.netBtn_Ok.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.netBtn_Ok.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.netBtn_Ok.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.netBtn_Ok.ColorText = System.Drawing.Color.Black
      Me.netBtn_Ok.ColorTop = System.Drawing.Color.White
      Me.netBtn_Ok.CornerRadius = 2
      Me.netBtn_Ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Ok.Location = New System.Drawing.Point(248, 293)
      Me.netBtn_Ok.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Ok.Name = "netBtn_Ok"
      Me.netBtn_Ok.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_Ok.TabIndex = 18
      Me.netBtn_Ok.TextButton = "OK"
      '
      'netBtn_Percentuale
      '
      Me.netBtn_Percentuale.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_Percentuale.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_Percentuale.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Percentuale.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Percentuale.ColorText = System.Drawing.Color.Black
      Me.netBtn_Percentuale.ColorTop = System.Drawing.Color.White
      Me.netBtn_Percentuale.CornerRadius = 2
      Me.netBtn_Percentuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Percentuale.Location = New System.Drawing.Point(248, 241)
      Me.netBtn_Percentuale.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Percentuale.Name = "netBtn_Percentuale"
      Me.netBtn_Percentuale.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_Percentuale.TabIndex = 14
      Me.netBtn_Percentuale.TextButton = "%"
      '
      'netBtn_X
      '
      Me.netBtn_X.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_X.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_X.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_X.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_X.ColorText = System.Drawing.Color.Black
      Me.netBtn_X.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_X.CornerRadius = 2
      Me.netBtn_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_X.Location = New System.Drawing.Point(248, 189)
      Me.netBtn_X.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_X.Name = "netBtn_X"
      Me.netBtn_X.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_X.TabIndex = 10
      Me.netBtn_X.TextButton = "X"
      '
      'netBtn_00
      '
      Me.netBtn_00.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_00.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_00.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_00.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_00.ColorText = System.Drawing.Color.Black
      Me.netBtn_00.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_00.CornerRadius = 2
      Me.netBtn_00.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_00.Location = New System.Drawing.Point(169, 293)
      Me.netBtn_00.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_00.Name = "netBtn_00"
      Me.netBtn_00.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_00.TabIndex = 17
      Me.netBtn_00.TextButton = "00"
      '
      'netBtn_0
      '
      Me.netBtn_0.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_0.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_0.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_0.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_0.ColorText = System.Drawing.Color.Black
      Me.netBtn_0.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_0.CornerRadius = 2
      Me.netBtn_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_0.Location = New System.Drawing.Point(88, 293)
      Me.netBtn_0.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_0.Name = "netBtn_0"
      Me.netBtn_0.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_0.TabIndex = 16
      Me.netBtn_0.TextButton = "0"
      '
      'netBtn_Virgola
      '
      Me.netBtn_Virgola.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_Virgola.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_Virgola.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_Virgola.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_Virgola.ColorText = System.Drawing.Color.Black
      Me.netBtn_Virgola.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_Virgola.CornerRadius = 2
      Me.netBtn_Virgola.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Virgola.Location = New System.Drawing.Point(7, 293)
      Me.netBtn_Virgola.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Virgola.Name = "netBtn_Virgola"
      Me.netBtn_Virgola.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_Virgola.TabIndex = 15
      Me.netBtn_Virgola.TextButton = ","
      '
      'netBtn_3
      '
      Me.netBtn_3.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_3.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_3.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_3.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_3.ColorText = System.Drawing.Color.Black
      Me.netBtn_3.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_3.CornerRadius = 2
      Me.netBtn_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_3.Location = New System.Drawing.Point(169, 241)
      Me.netBtn_3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_3.Name = "netBtn_3"
      Me.netBtn_3.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_3.TabIndex = 13
      Me.netBtn_3.TextButton = "3"
      '
      'netBtn_2
      '
      Me.netBtn_2.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_2.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_2.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_2.ColorText = System.Drawing.Color.Black
      Me.netBtn_2.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_2.CornerRadius = 2
      Me.netBtn_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_2.Location = New System.Drawing.Point(88, 241)
      Me.netBtn_2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_2.Name = "netBtn_2"
      Me.netBtn_2.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_2.TabIndex = 12
      Me.netBtn_2.TextButton = "2"
      '
      'netBtn_1
      '
      Me.netBtn_1.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_1.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_1.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_1.ColorText = System.Drawing.Color.Black
      Me.netBtn_1.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_1.CornerRadius = 2
      Me.netBtn_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_1.Location = New System.Drawing.Point(7, 241)
      Me.netBtn_1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_1.Name = "netBtn_1"
      Me.netBtn_1.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_1.TabIndex = 11
      Me.netBtn_1.TextButton = "1"
      '
      'netBtn_6
      '
      Me.netBtn_6.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_6.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_6.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_6.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_6.ColorText = System.Drawing.Color.Black
      Me.netBtn_6.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_6.CornerRadius = 2
      Me.netBtn_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_6.Location = New System.Drawing.Point(169, 189)
      Me.netBtn_6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_6.Name = "netBtn_6"
      Me.netBtn_6.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_6.TabIndex = 9
      Me.netBtn_6.TextButton = "6"
      '
      'netBtn_5
      '
      Me.netBtn_5.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_5.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_5.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_5.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_5.ColorText = System.Drawing.Color.Black
      Me.netBtn_5.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_5.CornerRadius = 2
      Me.netBtn_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_5.Location = New System.Drawing.Point(88, 189)
      Me.netBtn_5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_5.Name = "netBtn_5"
      Me.netBtn_5.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_5.TabIndex = 8
      Me.netBtn_5.TextButton = "5"
      '
      'netBtn_4
      '
      Me.netBtn_4.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_4.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_4.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_4.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_4.ColorText = System.Drawing.Color.Black
      Me.netBtn_4.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_4.CornerRadius = 2
      Me.netBtn_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_4.Location = New System.Drawing.Point(7, 189)
      Me.netBtn_4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_4.Name = "netBtn_4"
      Me.netBtn_4.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_4.TabIndex = 7
      Me.netBtn_4.TextButton = "4"
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(92, 9)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(109, 20)
      Me.Label2.TabIndex = 313
      Me.Label2.Tag = ""
      Me.Label2.Text = "Descrizione:"
      '
      'eui_txtQuantità
      '
      Me.eui_txtQuantità.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtQuantità.Id = "3a394809-2ffe-4207-935b-bdbafc6ee95f"
      Me.eui_txtQuantità.Location = New System.Drawing.Point(7, 29)
      Me.eui_txtQuantità.Name = "eui_txtQuantità"
      Me.eui_txtQuantità.Size = New System.Drawing.Size(80, 28)
      Me.eui_txtQuantità.TabIndex = 0
      Me.eui_txtQuantità.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtQuantità.TextEditorWidth = 74
      '
      'eui_txtDescrizione
      '
      Me.eui_txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtDescrizione.Id = "677a909f-0c17-44a4-8ba9-e80d57f4c65d"
      Me.eui_txtDescrizione.Location = New System.Drawing.Point(92, 29)
      Me.eui_txtDescrizione.Name = "eui_txtDescrizione"
      Me.eui_txtDescrizione.Size = New System.Drawing.Size(262, 28)
      Me.eui_txtDescrizione.TabIndex = 1
      Me.eui_txtDescrizione.TextEditorWidth = 256
      '
      'eui_txtPrezzo
      '
      Me.eui_txtPrezzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtPrezzo.Id = "efe76ab0-18ad-4dea-8261-311db95589d3"
      Me.eui_txtPrezzo.Location = New System.Drawing.Point(359, 29)
      Me.eui_txtPrezzo.Name = "eui_txtPrezzo"
      Me.eui_txtPrezzo.Size = New System.Drawing.Size(130, 28)
      Me.eui_txtPrezzo.TabIndex = 2
      Me.eui_txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtPrezzo.TextEditorWidth = 124
      '
      'netBtn_Totale
      '
      Me.netBtn_Totale.ColorBottom = System.Drawing.Color.Silver
      Me.netBtn_Totale.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Totale.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Totale.ColorText = System.Drawing.Color.Black
      Me.netBtn_Totale.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Totale.CornerRadius = 2
      Me.netBtn_Totale.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Totale.Location = New System.Drawing.Point(88, 74)
      Me.netBtn_Totale.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Totale.Name = "netBtn_Totale"
      Me.netBtn_Totale.Size = New System.Drawing.Size(255, 60)
      Me.netBtn_Totale.TabIndex = 27
      Me.netBtn_Totale.TextButton = "5,00"
      Me.netBtn_Totale.TextButtonAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'NetButton1
      '
      Me.NetButton1.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton1.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton1.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton1.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton1.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton1.CornerRadius = 2
      Me.NetButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton1.Location = New System.Drawing.Point(7, 74)
      Me.NetButton1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton1.Name = "NetButton1"
      Me.NetButton1.Size = New System.Drawing.Size(80, 60)
      Me.NetButton1.TabIndex = 314
      Me.NetButton1.TextButton = "€"
      '
      'ModificaPiattoPOS
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(495, 429)
      Me.Controls.Add(Me.NetButton1)
      Me.Controls.Add(Me.netBtn_Totale)
      Me.Controls.Add(Me.eui_txtPrezzo)
      Me.Controls.Add(Me.eui_txtDescrizione)
      Me.Controls.Add(Me.eui_txtQuantità)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.netBtn_C)
      Me.Controls.Add(Me.netBtn_9)
      Me.Controls.Add(Me.netBtn_8)
      Me.Controls.Add(Me.netBtn_7)
      Me.Controls.Add(Me.netBtn_Ok)
      Me.Controls.Add(Me.netBtn_Percentuale)
      Me.Controls.Add(Me.netBtn_X)
      Me.Controls.Add(Me.netBtn_00)
      Me.Controls.Add(Me.netBtn_0)
      Me.Controls.Add(Me.netBtn_Virgola)
      Me.Controls.Add(Me.netBtn_3)
      Me.Controls.Add(Me.netBtn_2)
      Me.Controls.Add(Me.netBtn_1)
      Me.Controls.Add(Me.netBtn_6)
      Me.Controls.Add(Me.netBtn_5)
      Me.Controls.Add(Me.netBtn_4)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label34)
      Me.Controls.Add(Me.eui_cmdQuantitàMeno)
      Me.Controls.Add(Me.eui_cmdQuantitàPiù)
      Me.Controls.Add(Me.eui_cmdIngredienti)
      Me.Controls.Add(Me.eui_cmdIva)
      Me.Controls.Add(Me.eui_cmdListino)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ModificaPiattoPOS"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "MODIFICA PIATTO"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Function AumentaDiminuisciQta(ByVal val As Boolean) As Boolean
      ' Vero: aumenta di 1 - Falso: diminuisce di 1.
      Try
         If eui_txtQuantità.Text <> String.Empty Then

            Dim quantità As Decimal = Convert.ToDecimal(eui_txtQuantità.Text)
            Dim totPrezzo As Decimal = Convert.ToDecimal(netBtn_Totale.TextButton)
            Dim prezzo As Decimal

            ' Ottiene il prezzo di una singola unità.
            prezzo = totPrezzo / quantità

            If val = True Then
               quantità += 1
            Else
               If quantità = 1 Or quantità < 1 Then
                  Return False
               Else
                  quantità -= 1
               End If
            End If

            ' Calcola il prezzo totale in base alla quantità inserita.
            totPrezzo = prezzo * quantità
            netBtn_Totale.TextButton = CFormatta.FormattaEuro(totPrezzo)

            eui_txtQuantità.Text = quantità.ToString

            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Function CalcolaTotalePrezzo() As Boolean
      Try
         Dim quantità As Decimal
         Dim prezzo As Decimal
         Dim totPrezzo As Decimal

         If eui_txtQuantità.Text = String.Empty Then
            quantità = 1
         Else
            quantità = Convert.ToDecimal(eui_txtQuantità.Text)
         End If

         If eui_txtPrezzo.Text = String.Empty Then
            eui_txtPrezzo.Text = VALORE_ZERO
         Else
            prezzo = Convert.ToDecimal(eui_txtPrezzo.Text)
         End If

         ' Calcola il prezzo totale in base alla quantità inserita.
         totPrezzo = prezzo * quantità
         netBtn_Totale.TextButton = CFormatta.FormattaEuro(totPrezzo)

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Sub DigitaNumeri(ByVal ctrl As Control, ByVal net_Btn As NetButton)
      Try
         If ctrl Is Nothing = False Then
            ' Salva i dati per la moltiplicazione.
            If moltiplica = False Then
               ctrl.Text = ctrl.Text & net_Btn.TextButton
               op1 = Convert.ToDouble(ctrl.Text)
            Else
               If op2 = 0 Then
                  ctrl.Text = String.Empty
               End If

               ctrl.Text = ctrl.Text & net_Btn.TextButton
               op2 = Convert.ToDouble(ctrl.Text)
            End If

            ctrl.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub LeggiListino(ByVal tabella As String, ByVal codice As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & codice & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' Prezzo.
            Select Case NumListino
               Case Listino.Uno
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     If dr.Item("Listino1") <> "" Then
                        eui_txtPrezzo.Text = dr.Item("Listino1").ToString
                     Else
                        eui_txtPrezzo.Text = VALORE_ZERO
                     End If
                  Else
                     eui_txtPrezzo.Text = VALORE_ZERO
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2") <> "" Then
                        eui_txtPrezzo.Text = dr.Item("Listino2").ToString
                     Else
                        eui_txtPrezzo.Text = VALORE_ZERO
                     End If
                  Else
                     eui_txtPrezzo.Text = VALORE_ZERO
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3") <> "" Then
                        eui_txtPrezzo.Text = dr.Item("Listino3").ToString
                     Else
                        eui_txtPrezzo.Text = VALORE_ZERO
                     End If
                  Else
                     eui_txtPrezzo.Text = VALORE_ZERO
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4") <> "" Then
                        eui_txtPrezzo.Text = dr.Item("Listino4").ToString
                     Else
                        eui_txtPrezzo.Text = VALORE_ZERO
                     End If
                  Else
                     eui_txtPrezzo.Text = VALORE_ZERO
                  End If
            End Select
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ApplicaListino(ByVal nomeListino As String)
      Try
         eui_cmdListino.Text = nomeListino

         Select Case nomeListino
            Case "Listino 1"
               NumListino = Listino.Uno

            Case "Listino 2"
               NumListino = Listino.Due

            Case "Listino 3"
               NumListino = Listino.Tre

            Case "Listino 4"
               NumListino = Listino.Quattro

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaPiattoPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Applica il listino.
         NumListino = Listino.Uno

         ' Legge l'aliquota iva del reparto.
         If aliquotaIvaPiatto = String.Empty Then
            eui_cmdIva.Text = "&IVA (" & CFormatta.FormattaAliquotaIva(AliquotaIvaRistorante) & "%)"
         Else
            eui_cmdIva.Text = "&IVA (" & aliquotaIvaPiatto & "%)"
         End If

         eui_txtQuantità.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Aggiorna l'importo totale.
      CalcolaTotalePrezzo()

   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
      Me.Tag = "0"

      ' Chiude la finestra.
      Me.Close()

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_TAVOLI)
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub eui_txtQuantità_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtQuantità.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

         If CConvalida.KeyReturn(e.KeyChar) = True Then
            CalcolaTotalePrezzo()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtPrezzo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtPrezzo.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

         If CConvalida.KeyReturn(e.KeyChar) = True Then
            CalcolaTotalePrezzo()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdQuantitàPiù_Click(sender As Object, e As EventArgs) Handles eui_cmdQuantitàPiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim operazioneQtà As Boolean

         If eui_txtQuantità.Text <> String.Empty Then
            Dim quantità As Decimal = Convert.ToDecimal(eui_txtQuantità.Text)

            operazioneQtà = AumentaDiminuisciQta(True)

            CalcolaTotalePrezzo()

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdQuantitàMeno_Click(sender As Object, e As EventArgs) Handles eui_cmdQuantitàMeno.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim operazioneQtà As Boolean

         If eui_txtQuantità.Text <> String.Empty Then
            Dim quantità As Decimal = Convert.ToDecimal(eui_txtQuantità.Text)

            operazioneQtà = AumentaDiminuisciQta(False)

            CalcolaTotalePrezzo()

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdIngredienti_Click(sender As Object, e As EventArgs) Handles eui_cmdIngredienti.Click
      Try
         Dim frm As New ElencoIngredientiPOS(idPiattoSelezionato, eui_txtDescrizione.Text)
         If frm.ShowDialog() = DialogResult.OK Then
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_1_Click(sender As Object, e As EventArgs) Handles netBtn_1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_2_Click(sender As Object, e As EventArgs) Handles netBtn_2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_3_Click(sender As Object, e As EventArgs) Handles netBtn_3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_4_Click(sender As Object, e As EventArgs) Handles netBtn_4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_5_Click(sender As Object, e As EventArgs) Handles netBtn_5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_6_Click(sender As Object, e As EventArgs) Handles netBtn_6.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_7_Click(sender As Object, e As EventArgs) Handles netBtn_7.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_8_Click(sender As Object, e As EventArgs) Handles netBtn_8.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_9_Click(sender As Object, e As EventArgs) Handles netBtn_9.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_Virgola_Click(sender As Object, e As EventArgs) Handles netBtn_Virgola.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         ' Verifica la presenza della virgola.
         If eui_txtPrezzo.Text = String.Empty Then
            eui_txtPrezzo.Focus()
            Exit Sub
         Else
            Dim virgola As Integer = Convert.ToInt32(eui_txtPrezzo.Text.IndexOf(sender.TextButton))

            If virgola <> -1 Then
               eui_txtPrezzo.Focus()
               Exit Sub
            Else
               DigitaNumeri(eui_txtPrezzo, sender)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub netBtn_0_Click(sender As Object, e As EventArgs) Handles netBtn_0.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_00_Click(sender As Object, e As EventArgs) Handles netBtn_00.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtPrezzo, sender)
   End Sub

   Private Sub netBtn_Ok_Click(sender As Object, e As EventArgs) Handles netBtn_Ok.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If eui_txtPrezzo Is Nothing = False Then
            If eui_txtPrezzo.Text = String.Empty Then
               eui_txtPrezzo.Text = VALORE_ZERO
            End If
         End If

         ' Moltiplicazione su una TextBox.
         If moltiplica = True Then
            If op1 <> 0 And op2 <> 0 Then
               Dim valMoltiplicazione As Double = (op1 * op2)
               eui_txtPrezzo.Text = CFormatta.FormattaEuro(valMoltiplicazione)

            Else
               eui_txtPrezzo.Text = 0
            End If
         End If

         op1 = 0.0
         op2 = 0.0

         moltiplica = False

         CalcolaTotalePrezzo()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_C_Click(sender As Object, e As EventArgs) Handles netBtn_C.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         eui_txtPrezzo.Text = String.Empty
         eui_txtPrezzo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub netBtn_X_Click(sender As Object, e As EventArgs) Handles netBtn_X.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      moltiplica = True

   End Sub

   Private Sub netBtn_Percentuale_Click(sender As Object, e As EventArgs) Handles netBtn_Percentuale.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If eui_txtPrezzo Is Nothing = False Then
            If eui_txtPrezzo.Text = String.Empty Then
               eui_txtPrezzo.Text = VALORE_ZERO
            End If
         End If

         ' Moltiplicazione su una TextBox.
         If moltiplica = True Then
            If op1 <> 0 And op2 <> 0 Then
               Dim valPercentuale As Double = (op1 * op2) / 100
               eui_txtPrezzo.Text = CFormatta.FormattaEuro(valPercentuale)

            Else
               eui_txtPrezzo.Text = VALORE_ZERO
            End If
         End If

         op1 = 0.0
         op2 = 0.0

         moltiplica = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdListino_Click(sender As Object, e As EventArgs) Handles eui_cmdListino.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoListinoPos
         If frm.ShowDialog() = DialogResult.OK Then
            ApplicaListino(frm.Tag.ToString)
            LeggiListino(ANA_PIATTI, idPiattoSelezionato)
            CalcolaTotalePrezzo()
         End If

         eui_txtPrezzo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_cmdIva_Click(sender As Object, e As EventArgs) Handles eui_cmdIva.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoAliquotaIvaPos(False)
         If frm.ShowDialog() = DialogResult.OK Then
            eui_cmdIva.Text = "&IVA (" & frm.Tag.ToString & "%)"
            aliquotaIvaPiatto = frm.Tag.ToString
         End If

         eui_txtPrezzo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub
End Class
