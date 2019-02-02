Imports System.Text
Imports System.Globalization

Public Class CalcolaIBAN
   Private err As New Varie.Errore

   Private Const L_CONTO As Integer = 12
   Private Const L_ABI As Integer = 5
   Private Const L_CAB As Integer = 5
   Private mAbi As String = String.Empty
   Private mCab As String = String.Empty
   Private mContoCorrente As String = String.Empty
   Private mCin As String = String.Empty
   Private mNormalizzaConto As Boolean = True
   Private mIBAN As String = String.Empty
   Private mBBAN As String = String.Empty
   Private mCheckDigitIBAN As String = String.Empty
   Private mPaese As String = String.Empty
   Private mDivisore As Integer = 97

   Public Property Abi() As String
      Get
         Return mAbi
      End Get
      Set(ByVal Value As String)
         mAbi = NormalizzaDati(Value, L_ABI)
      End Set
   End Property

   Public Property Cab() As String
      Get
         Return mCab
      End Get
      Set(ByVal Value As String)
         mCab = NormalizzaDati(Value, L_CAB)
      End Set
   End Property

   Public Property ContoCorrente() As String
      Get
         Return mContoCorrente
      End Get
      Set(ByVal Value As String)
         mContoCorrente = Value
      End Set
   End Property

   Public Property Cin() As String
      Get
         Return mCin
      End Get
      Set(ByVal Value As String)
         mCin = Value
      End Set
   End Property

   Public Property BBAN() As String
      Get
         Return mBBAN
      End Get
      Set(ByVal Value As String)
         mBBAN = Value
      End Set
   End Property

   Public Property IBAN() As String
      Get
         Return mIBAN
      End Get
      Set(ByVal Value As String)
         mIBAN = Value
      End Set
   End Property

   Public Property CheckDigitIBAN() As String
      Get
         Return mCheckDigitIBAN
      End Get
      Set(ByVal Value As String)
         mCheckDigitIBAN = Value
      End Set
   End Property

   Public Property Paese() As String
      Get
         Return mPaese
      End Get
      Set(ByVal Value As String)
         mPaese = Value
      End Set
   End Property

   Public Property NormalizzaConto() As Boolean
      Get
         Return mNormalizzaConto
      End Get
      Set(ByVal Value As Boolean)
         mNormalizzaConto = Value
      End Set
   End Property

   Public Property Divisore() As Integer
      Get
         Return mDivisore
      End Get
      Set(ByVal Value As Integer)
         mDivisore = Value
      End Set
   End Property

   Private Function NormalizzaDati(ByVal codice As String, ByVal lunghezza As Integer) As String
      codice = codice.Trim()
      Dim k As Integer = codice.Length

      If k < lunghezza Then
         codice = "".PadLeft(lunghezza, "0") + codice
         k += lunghezza
      End If

      k -= lunghezza
      If (k < 0) Then k = 0
      codice = codice.Substring(k)

      Return codice
   End Function

   Public Function NormalizzaContoCorrente(ByVal contoCorrenteValue As String) As String
      contoCorrenteValue = contoCorrenteValue.Trim()

      Dim k As Integer = contoCorrenteValue.IndexOf(" ")

      While k >= 0
         contoCorrenteValue = contoCorrenteValue.Remove(k, 1)
         k = contoCorrenteValue.IndexOf(" ")
      End While

      Return NormalizzaDati(contoCorrenteValue, L_CONTO)

   End Function

   Public Function VerificaCin(ByVal cinCode As String) As Boolean
      If cinCode = CalcolaCin() Then
         Return True
      Else
         Return False
      End If

   End Function

   Public Function CalcolaCin() As String
      ' Costanti e variabili per calcolo pesi.
      Const numeri As String = "0123456789"
      Const lettere As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-. "
      Const DIVISORE As Integer = 26
      Dim listaPari() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28}
      Dim listaDispari() As Integer = {1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23, 27, 28, 26}

      ' Normalizzazione dati.			
      If (Me.Abi.Length <> L_ABI) Then
         mAbi = NormalizzaDati(mAbi, L_ABI)
      End If
      If (Me.Cab.Length <> L_CAB) Then
         mCab = NormalizzaDati(mCab, L_CAB)
      End If
      If (Me.NormalizzaConto) Then
         Me.ContoCorrente = NormalizzaContoCorrente(Me.ContoCorrente)
      End If
      If (Me.ContoCorrente.Length <> L_CONTO) Then
         Me.ContoCorrente = Me.ContoCorrente.PadRight(L_CONTO)
      End If

      ' Codice normalizzato.
      Dim codice As String = Me.Abi + Me.Cab + Me.ContoCorrente

      ' calcolo valori caratteri
      Dim somma As Integer = 0
      Dim c() As Char = codice.ToUpper().ToCharArray()
      Dim k As Integer = 0

      For k = 0 To L_CONTO + L_ABI + L_CAB - 1
         Dim i As Integer = numeri.IndexOf(c(k))
         If (i < 0) Then
            i = lettere.IndexOf(c(k))
         End If

         ' se ci sono caratteri errati usciamo con un valore 
         ' impossibile da trovare sul cin
         If (i < 0) Then
            Return Environment.NewLine
         End If

         If ((k Mod 2) = 0) Then
            ' valore dispari
            somma += listaDispari(i)
         Else
            ' valore pari
            somma += listaPari(i)
         End If
      Next

      Return lettere.Substring(somma Mod DIVISORE, 1)

   End Function

   Public Function CheckIBAN() As Boolean
      Dim codice As String

      If (mIBAN <> "") Then
         codice = mIBAN
      Else
         Dim s As String = mCin
         If (s <> "") Then
            Dim b As Boolean = VerificaCin(s)
            If Not b Then Return False
         Else
            s = CalcolaCin()
         End If

         codice = s + NormalizzaDati(mAbi, L_ABI) & NormalizzaDati(mCab, L_CAB) & NormalizzaContoCorrente(mContoCorrente)
      End If

      Return CheckIBAN(codice)

   End Function

   Public Function CheckIBAN(ByVal pIBAN As String) As Boolean
      Dim codice As String = NormalizzaIBAN(pIBAN)

      If Not (CheckLength(codice)) Then Return False

      codice = codice.Substring(4) + codice.Substring(0, 4)
      Dim r() As String = DivisioneIntera(AlfaToNumber(codice), Divisore.ToString())
      Dim resto As Integer = Integer.Parse(r(1))
      Return (resto = 1)

   End Function

   Private Function CheckLength(ByVal pCodice As String) As Boolean
      Return True
   End Function

   Private Function AlfaToNumber(ByVal pCodice As String) As String
      Const alfachars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
      Dim sb As New StringBuilder

      For Each c As Char In pCodice

         Dim k As Integer = alfachars.IndexOf(c)
         If (k <> -1) Then
            sb.Append(k + 10)
         Else
            sb.Append(c)
         End If
      Next

      Return sb.ToString()
   End Function

   Public Function DivisioneIntera(ByVal pDividendo As String, ByVal pDivisore As String) As String()
      Dim Intero As New StringBuilder
      Dim Resto As New StringBuilder
      Dim divisore As Double

      If Not Double.TryParse(pDivisore, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, divisore) Then
         Throw New Exception("Divisore errato")
      End If
      Dim x As Integer = 0
      For x = 0 To pDividendo.Length

         Resto.Append(pDividendo.Substring(x, 1))
         Dim s As String = Resto.ToString()
         Dim dividendo As Double = 0
         If Not Double.TryParse(s, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, dividendo) Then
            Throw New Exception("Dividendo Errato")
         End If
         Dim volte As Integer = 0
         While (dividendo >= divisore)
            dividendo -= divisore
            volte = +1
         End While

         Intero.Append(volte)
         Dim r As String = dividendo.ToString("0")
         Resto = New StringBuilder
         Resto.Append(r)
      Next

      Dim result(2) As String
      result(1) = Resto.ToString()
      result(0) = Intero.ToString()
      While (result(0).StartsWith("0"))
         result(0) = result(0).Substring(1)
      End While

      If (result(0) = "") Then result(0) = "0"

      Return result

   End Function

   Public Function CalcolaBBAN() As String
      Dim codice As String

      If (mIBAN <> "") Then
         codice = mIBAN
      Else
         Dim s As String = mCin
         If (s = "") Then s = CalcolaCin()
         codice = s + NormalizzaDati(mAbi, L_ABI) & NormalizzaDati(mCab, L_CAB) & NormalizzaContoCorrente(mContoCorrente)
      End If

      Return codice
   End Function

   Public Function CalcolaIBAN() As String
      Dim codice As String
      If (mBBAN <> "") Then
         codice = mBBAN
      Else
         codice = CalcolaBBAN()
      End If

      Return CalcolaIBAN(mPaese, codice)

   End Function

   Public Function CalcolaIBAN(ByVal pPaese As String, ByVal pBBAN As String) As String
      pBBAN = NormalizzaIBAN(pBBAN)
      Dim codice As String = pPaese + "00" + pBBAN
      codice = codice.Substring(4) + codice.Substring(0, 4)
      Dim numcode As String = AlfaToNumber(codice)
      Dim r() = DivisioneIntera(numcode, Divisore.ToString())
      Dim resto As Integer = Integer.Parse(r(1))
      resto = (Divisore + 1) - resto

      Return pPaese + resto.ToString("00") + pBBAN
   End Function

   Public Function CalcolaCheckIBAN(ByVal pPaese As String, ByVal pBBAN As String) As String
      Return CalcolaIBAN(pPaese, pBBAN).Substring(2, 2)
   End Function

   Public Function NormalizzaIBAN(ByVal pCodice As String) As String
      Const alfanum As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
      Dim sb As New StringBuilder

      For Each c As Char In pCodice
         If (alfanum.IndexOf(c) <> -1) Then
            sb.Append(c)
         End If
      Next

      Return sb.ToString()
   End Function
End Class
