Public Class Form1
    Inherits System.Windows.Forms.Form

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

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.PictureBox2 = New System.Windows.Forms.PictureBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(16, 8)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(160, 248)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox1.TabIndex = 0
      Me.PictureBox1.TabStop = False
      '
      'PictureBox2
      '
      Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
      Me.PictureBox2.Location = New System.Drawing.Point(16, 256)
      Me.PictureBox2.Name = "PictureBox2"
      Me.PictureBox2.Size = New System.Drawing.Size(160, 32)
      Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox2.TabIndex = 1
      Me.PictureBox2.TabStop = False
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(184, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(296, 64)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Benvenuti nell'installazione guidata di Chef Solution"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(184, 88)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(320, 16)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "Chef Solution verrà installato sul computer."
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(184, 120)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(320, 32)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Si consiglia di chiudere tutte le applicazioni prima di continuare."
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(184, 168)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(320, 40)
      Me.Label4.TabIndex = 5
      Me.Label4.Text = "Premere su Avanti per continuare o su Annulla per uscire dall'installazione."
      '
      'Form1
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.ClientSize = New System.Drawing.Size(536, 318)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.PictureBox2)
      Me.Controls.Add(Me.PictureBox1)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

End Class
