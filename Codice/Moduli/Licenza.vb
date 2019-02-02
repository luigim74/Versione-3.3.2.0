Imports System.Management

Module Licenza
   Private Function LeggiDisk() As String
      Dim Serial As String = String.Empty

      Try
         Dim disk As Management.ManagementObject = New Management.ManagementObject("win32_logicaldisk.deviceid='C:'")
         disk.Get()
         Serial = disk("VolumeSerialNumber").ToString
         Return Serial

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Serial = ""
         Return Serial.PadLeft(8, "0")
      End Try
   End Function

   Private Function LeggiMac() As String
      Dim Serial As String = String.Empty

      Try
         Dim mc As Management.ManagementClass = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
         Dim moc As Management.ManagementObjectCollection = mc.GetInstances()

         For Each mo As Management.ManagementObject In moc

            If (Serial = String.Empty) Then
               If (mo("IPEnabled") = Boolean.TrueString) Then Serial = mo("MacAddress").ToString
            End If
            mo.Dispose()
         Next

         Serial = Serial.Replace(":", "")
         Serial = Serial.PadLeft(12, "0")

         Return Serial

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Serial = ""
         Return Serial.PadLeft(12, "0")
      End Try
   End Function

   Private Function LeggiCPU() As String
      Dim Serial As String = String.Empty

      Try
         Dim mc As Management.ManagementClass = New Management.ManagementClass("Win32_Processor")
         Dim moc As Management.ManagementObjectCollection = mc.GetInstances

         For Each mo As Management.ManagementObject In moc
            If (Serial = String.Empty) Then
               Serial = mo.Properties("ProcessorId").Value.ToString()
            End If
         Next

         Return Serial

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Serial = ""
         Return Serial.PadLeft(16, "0")
      End Try
   End Function

   Public Function GeneraChiaveLicenza() As String
      Try
         'LETTURA SERIALE MAC RETE
         'Dim MacInfo As String = LeggiMac()

         'LETTURA SERIALE CPU
         Dim CpuInfo As String = LeggiCPU()

         'LETTURA SERIALE DISCO
         Dim DiskInfo As String = LeggiDisk()

         Dim cpu1 As String = CpuInfo.Substring(0, 4) & CHIAVE_ATTIVAZIONE.Substring(0, 1)
         Dim cpu2 As String = CpuInfo.Substring(4, 4) & CHIAVE_ATTIVAZIONE.Substring(1, 1)
         Dim cpu3 As String = CpuInfo.Substring(8, 4) & CHIAVE_ATTIVAZIONE.Substring(2, 1)
         Dim disk1 As String = DiskInfo.Substring(0, 4) & CHIAVE_ATTIVAZIONE.Substring(3, 1)
         Dim disk2 As String = DiskInfo.Substring(4, 4) & CHIAVE_ATTIVAZIONE.Substring(4, 1)
         Dim chiave As String = cpu1 & cpu2 & cpu3 & disk1 & disk2

         ' Creazione chiave licenza 
         Return chiave

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

    End Function

    Public Function GeneraChiaveLicenza(ByVal chiaveAttivazione As String) As String
        Try
            'LETTURA SERIALE MAC RETE
            'Dim MacInfo As String = LeggiMac()

            'LETTURA SERIALE CPU
            Dim CpuInfo As String = LeggiCPU()

            'LETTURA SERIALE DISCO
            Dim DiskInfo As String = LeggiDisk()

            Dim cpu1 As String = CpuInfo.Substring(0, 4) & chiaveAttivazione.Substring(0, 1)
            Dim cpu2 As String = CpuInfo.Substring(4, 4) & chiaveAttivazione.Substring(1, 1)
            Dim cpu3 As String = CpuInfo.Substring(8, 4) & chiaveAttivazione.Substring(2, 1)
            Dim disk1 As String = DiskInfo.Substring(0, 4) & chiaveAttivazione.Substring(3, 1)
            Dim disk2 As String = DiskInfo.Substring(4, 4) & chiaveAttivazione.Substring(4, 1)
            Dim chiave As String = cpu1 & cpu2 & cpu3 & disk1 & disk2

            ' Creazione chiave licenza 
            Return chiave

        Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

            Return String.Empty
        End Try

   End Function

   Public Function GeneraChiaveLicenza(ByVal chiaveAttivazione As String, ByVal separatore As Char) As String
      Try
         'LETTURA SERIALE MAC RETE
         'Dim MacInfo As String = LeggiMac()

         'LETTURA SERIALE CPU
         Dim CpuInfo As String = LeggiCPU()

         'LETTURA SERIALE DISCO
         Dim DiskInfo As String = LeggiDisk()

         Dim cpu1 As String = CpuInfo.Substring(0, 4) & chiaveAttivazione.Substring(0, 1)
         Dim cpu2 As String = CpuInfo.Substring(4, 4) & chiaveAttivazione.Substring(1, 1)
         Dim cpu3 As String = CpuInfo.Substring(8, 4) & chiaveAttivazione.Substring(2, 1)
         Dim disk1 As String = DiskInfo.Substring(0, 4) & chiaveAttivazione.Substring(3, 1)
         Dim disk2 As String = DiskInfo.Substring(4, 4) & chiaveAttivazione.Substring(4, 1)
         Dim chiave As String = cpu1 & separatore & cpu2 & separatore & cpu3 & separatore & disk1 & separatore & disk2

         ' Creazione chiave licenza 
         Return chiave

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function


End Module
