Imports System.Runtime.InteropServices

Public Class WebCommunication
   <DllImport("wininet.dll")> _
   Private Shared Function InternetGetConnectedState(ByRef Description As Integer, ByVal ReservedValue As Integer) As Boolean

   End Function

   Public Sub New()

   End Sub

   Public Shared Function VerificaConnessione() As Boolean
      Dim Desc As Integer
      Return InternetGetConnectedState(Desc, 0)
   End Function

   Public Shared Sub ScriviFile(ByVal ftp As String, ByVal login As String, ByVal pwd As String, ByVal percorsoRemoto As String, ByVal percorsoLocale As String)
      Dim client As New Net.WebClient
      Dim valRitorno As Byte()

      client.Credentials = New Net.NetworkCredential(login, pwd, ftp)

      valRitorno = client.UploadFile(percorsoRemoto, percorsoLocale)

   End Sub

   Public Shared Sub LeggiFile(ByVal percorsoRemoto As String, ByVal percorsoLocale As String)
      Dim client As New Net.WebClient

      client.DownloadFile(percorsoRemoto, percorsoLocale)

   End Sub

End Class
