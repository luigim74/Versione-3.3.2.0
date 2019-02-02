Public Class ColonnaColorata
   Inherits DataGridTextBoxColumn

   Dim griglia As DataGrid
   Dim colorSfondo As Color
   Dim colorTesto As Color

   Public Sub New(ByVal grigliaDati As DataGrid, ByVal coloreSfondo As Color, ByVal coloreTesto As Color)
      griglia = grigliaDati
      colorSfondo = coloreSfondo
      colorTesto = coloreTesto
   End Sub

   Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
      Try
         'Recupero il valore
         Dim o As Object = Me.GetColumnValueAtRow(source, rowNum)
         If griglia.IsSelected(rowNum) = False Then
            foreBrush = New SolidBrush(colorTesto)
            backBrush = New SolidBrush(colorSfondo)
            'Else
            '   foreBrush = New SolidBrush(griglia.SelectionBackColor)
            '   Me.TextBox.Clear()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
      End Try
   End Sub
End Class
