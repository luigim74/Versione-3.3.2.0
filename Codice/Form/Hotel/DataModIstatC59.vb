#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/10/2018
' Data ultima modifica: 01/10/2018
' Descrizione:          Finestra per la selezione della data del Modello Istat C/59.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Public Class DataModIstatC59
   Dim nomeForm As String
   Dim dataGestione As Date

   Public Sub New(ByVal form As String, ByVal data As Date)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      dataGestione = data
      nomeForm = form

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub DataModIstatC59_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         eui_dtpDataGestione.Value = dataGestione

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         Me.Hide()

         ' Elabora tutti i dati per creare il report del Modello Istat C/59.
         g_frmMain.ElaboraModelloIstaC59(eui_dtpDataGestione.Value.Value.ToShortDateString)

         ' Apre il documento Modello Istat C/59.
         Select Case nomeForm
            Case "PlanningCamere"
               g_frmPlanningCamere.AnteprimaDiStampa(PERCORSO_REP_MODELLO_ISTAT_59_A4)

            Case "ElencoPrenCamere"
               g_frmPrenCamere.AnteprimaDiStampaModIstatC59(PERCORSO_REP_MODELLO_ISTAT_59_A4)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Me.Close()

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Try
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class