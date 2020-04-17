#Region " DATI FILE.VB "

' **************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       17/04/2020
' Data ultima modifica: 17/04/2020
' Descrizione:          Form per la selezione dell'ordine di uscita del piatto.
' Note:
'
' Elenco Attivita:
'
' **************************************************************************************

#End Region

Imports System.IO
Imports System.Data.OleDb

Public Class NumeroUscitePOS
   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String

   Private Sub NumeroUscitePOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub netBtn_Uscita1_Click(sender As Object, e As EventArgs) Handles netBtn_Uscita1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Uscita1.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Uscita2_Click(sender As Object, e As EventArgs) Handles netBtn_Uscita2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Uscita2.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Uscita3_Click(sender As Object, e As EventArgs) Handles netBtn_Uscita3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Uscita3.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Uscita4_Click(sender As Object, e As EventArgs) Handles netBtn_Uscita4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Uscita4.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub

   Private Sub netBtn_Uscita5_Click(sender As Object, e As EventArgs) Handles netBtn_Uscita5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = netBtn_Uscita5.TextButton
      Me.DialogResult = DialogResult.OK
      Me.Close()
   End Sub
End Class