Public Class Utils
    Const sep As Char = "|"
    Const sepGS As String = ";"
    Public Const Hbar As Char = "H"
    Public Const Vbar As Char = "V"
    Public Shared position As Integer

    Shared Function MinutesAndSecondsFromSeconds(ByVal duration As Double) As String
        Dim ret As String = ""
        ret = IIf((duration \ 60) < 10, ("0" & (duration \ 60)), (duration \ 60)) & ":" & IIf(Int(duration Mod 60) < 10, ("0" & Int(duration Mod 60)), Int(duration Mod 60))
        If ret.Equals("0:0") Then
            ret = "00:00"
        End If
        Return ret
    End Function

    Public Function GetRandomNamesFromPatternList(ByVal oRandom As MersenneTwister, ByVal al As ArrayList, ByVal numberToGenerate As Integer) As String
        Dim sep As Char() = {",", " "}
        Dim stringTo As String = ""
        Dim randomNumber As Integer
        Dim alClone As ArrayList = al.Clone
        Dim pattern As String
        For i As Integer = 1 To numberToGenerate
            If alClone.Count.Equals(0) Then
                alClone = al.Clone
            End If
            randomNumber = oRandom.Next(alClone.Count - 1)
            pattern = alClone.Item(randomNumber)
            stringTo &= GenerateRandomName(oRandom, pattern) & ", "
            alClone.Remove(pattern)
        Next i
        stringTo = stringTo.TrimEnd(sep)
        Return stringTo
    End Function

    Public Function GenerateRandomName(ByVal oRandom As MersenneTwister, ByVal pattern As String) As String
        Dim ret As String = ""
        'Dichiarazione delle costanti
        Const LNV As Char = "@" 'Consonante Minuscola
        Const UNV As Char = "$" 'Consonante Maiuscola
        Const LV As Char = "!" 'Vocale Minuscola
        Const UV As Char = "&" 'Vocale Maiuscola
        Const AL As Char = "*" 'Qualsiasi lettera minuscola
        Const AU As Char = "-" 'Qualsiasi lettera maiuscola
        Const I As Char = "#" 'Numero Intero
        Const OU As Char = "^" 'Una 'o' o una 'u'
        Const UOU As Char = ">" 'Una 'O' o una 'U'
        Const AE As Char = "%" 'Una 'a' o una 'e'
        Const UAE As Char = "_" 'Una 'A' o una 'E'
        '------------------------------------------------------------------
        'Dichiarazione array di caratteri
        Dim ArrayAlfabeto As Char() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        Dim ArrayConsonanti As Char() = {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"}
        Dim ArrayVocali As Char() = {"a", "e", "i", "o", "u"}
        '------------------------------------------------------------------
        For Each character As Char In pattern.ToCharArray
            Select Case character
                Case LNV
                    ret &= ArrayConsonanti.GetValue(oRandom.Next(20)).ToString.ToLower
                Case UNV
                    ret &= ArrayConsonanti.GetValue(oRandom.Next(20)).ToString.ToUpper
                Case LV
                    ret &= ArrayVocali.GetValue(oRandom.Next(4)).ToString.ToLower
                Case UV
                    ret &= ArrayVocali.GetValue(oRandom.Next(4)).ToString.ToUpper
                Case AL
                    ret &= ArrayAlfabeto.GetValue(oRandom.Next(25)).ToString.ToLower
                Case AU
                    ret &= ArrayAlfabeto.GetValue(oRandom.Next(25)).ToString.ToUpper
                Case I
                    ret &= oRandom.Next(9)
                Case OU
                    ret &= ArrayVocali.GetValue(oRandom.Next(3, 4)).ToString.ToLower
                Case UOU
                    ret &= ArrayVocali.GetValue(oRandom.Next(3, 4)).ToString.ToUpper
                Case AE
                    ret &= ArrayVocali.GetValue(oRandom.Next(1)).ToString.ToLower
                Case UAE
                    ret &= ArrayVocali.GetValue(oRandom.Next(1)).ToString.ToUpper
                Case Else
                    ret &= character
            End Select
        Next character
        Return ret
    End Function

    Shared Sub CopyDataGridViewElements(ByVal dataGridViewFrom As DataGridView, ByRef dataGridViewTo As DataGridView)
        For m As Integer = 0 To dataGridViewFrom.Rows.Count - 1
            Dim cellToCopy As DataGridViewCell = Nothing
            Dim row As DataGridViewRow = Nothing
            Dim cell As DataGridViewCell = Nothing
            Dim otherRow As DataGridViewRow = Nothing
            Dim otherCell As DataGridViewCell = Nothing
            For Each row In dataGridViewFrom.Rows
                dataGridViewTo.Rows.Add()
                For Each cell In row.Cells
                    cellToCopy = cell
                    For Each otherRow In dataGridViewTo.Rows
                        For Each otherCell In row.Cells
                            otherCell = cellToCopy
                            Exit For
                        Next otherCell
                        Exit For
                    Next otherRow
                Next cell
            Next row
        Next m
    End Sub

    Shared Function CalcoloGS(ByVal mostri As Integer, ByVal GS As String) As Double
        Dim strarry() As String
        Dim gss(mostri) As Double
        Dim vara As Double
        If GS.Contains(sepGS) Then
            strarry = Split(GS, sepGS)
        Else
            strarry = New String() {GS}
        End If
        If Not strarry.Length.Equals(mostri) Then
            MsgBox("Hai inserito troppi pochi GS per i mostri inseriti. Controlla il campo GS.")
            Exit Function
        End If
        Try
            For i As Integer = 0 To mostri - 1
                gss(i) = CDbl(strarry(i))
            Next
            For i As Integer = 1 To mostri - 1
                gss(0) = gss(0) + gss(i)
            Next

        Catch ex As IndexOutOfRangeException
            MessageBox.Show("Il numero di parametri per il GS è inferiore al numero dei mostri dichiarati." & vbCrLf & "Inserire tutti i gradi di sfida.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Throw ex
        End Try
        vara = gss(0) / mostri
        Return vara
    End Function

    Shared Function NormalizeReturn(ByVal originalString As String) As String
        Dim slf As String() = originalString.Split(vbLf)
        Dim scr As String() = originalString.Split(vbCr)
        Dim modifiedString As String = ""
        Dim i As Integer = 0
        If Not scr.Length = slf.Length Then
            If originalString.Contains(vbCr) Then
                For i = 0 To scr.Length - 1
                    scr(i) = scr(i).Replace(vbCr, vbCrLf)
                    modifiedString = modifiedString & scr(i) & vbCrLf
                Next i
            ElseIf originalString.Contains(vbLf) Then
                For i = 0 To slf.Length - 1
                    slf(i) = slf(i).Replace(vbLf, vbCrLf)
                    modifiedString = modifiedString & slf(i) & vbCrLf
                Next i
            Else
                modifiedString = originalString
            End If
        Else
            modifiedString = originalString
        End If
        If modifiedString.EndsWith(vbCrLf) Then
            modifiedString = modifiedString.Remove(modifiedString.LastIndexOf(vbCrLf))
        End If
        Return modifiedString
    End Function

    Shared Function shrinkPath(ByVal path As String, ByVal puntini As String, ByVal numberOfCharAfterNBefore As Integer) As String
        Dim ret As String = ""
        Dim i As Integer = path.Length
        Dim s1 As String = path.Substring(0, numberOfCharAfterNBefore)
        Dim s2 As String = path.Substring(i - numberOfCharAfterNBefore, numberOfCharAfterNBefore)
        ret = s1 & puntini & s2
        Return ret
    End Function

    Shared Function getNextImageIndex(ByVal dirPath As String, ByVal filePattern As String) As Integer
        Dim ret As Integer
        Dim array As String() = System.IO.Directory.GetFiles(dirPath, filePattern, IO.SearchOption.TopDirectoryOnly)
        ret = array.Length
        Return ret
    End Function

    Shared Function getIDFromName(ByVal s As String) As Long
        If s Is Nothing Then
            Exit Function
        End If
        Dim ret As Long
        Dim idstart As Integer = s.LastIndexOf("(") + 1
        Dim idend As Integer = s.LastIndexOf(")")
        ret = CLng(s.Trim.Substring(idstart, (idend - idstart)))
        Return ret
    End Function

    Shared Function DirSearch(ByVal sDir As String, ByVal sFile As String, ByRef result As String) As Boolean
        Dim d As String
        Dim f As String
        Try
            For Each d In System.IO.Directory.GetDirectories(sDir)
                For Each f In System.IO.Directory.GetFiles(d, sFile)
                    result = f
                    Return True
                    Exit Function
                Next
                DirSearch(d, sFile, result)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
    End Function

    Shared Function GetImageFormat(ByRef pb As PictureBox) As String
        Dim format As String
        If pb.Image.RawFormat Is Imaging.ImageFormat.Bmp Then
            format = ".bmp"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Emf Then
            format = ".emf"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Exif Then
            format = ".exif"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Gif Then
            format = ".gif"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Icon Then
            format = ".ico"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Jpeg Then
            format = ".jpeg"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.MemoryBmp Then
            format = ".bmp"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Png Then
            format = ".png"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Tiff Then
            format = ".tif"
        ElseIf pb.Image.RawFormat Is Imaging.ImageFormat.Wmf Then
            format = ".wmf"
        Else
            format = ".ukn"
        End If
        Return format
    End Function

    Shared Function getListFromString(ByVal str As String, ByVal separatore() As String) As ArrayList
        Dim lista As New ArrayList
        Dim matrix As String() = str.Split(separatore, StringSplitOptions.RemoveEmptyEntries)
        For Each token As String In matrix
            lista.Add(token)
        Next
        Return lista
    End Function

    Shared Sub SaveElementsFromListbox(ByVal listbox As System.Windows.Forms.ListBox, ByVal completePath As String, ByVal append As Boolean)
        Dim fileContent As String = ""
        For Each element As String In listbox.Items
            fileContent &= element & vbCrLf
        Next element
        My.Computer.FileSystem.WriteAllText(completePath, fileContent, append)
    End Sub

    Shared Function fillArrayListFromListBox(ByVal listbox As ListBox, ByVal selected As Boolean) As ArrayList
        Dim ret As New ArrayList
        If selected Then
            For Each element As Object In listbox.SelectedItems
                ret.Add(element)
            Next element
        Else
            For Each element As Object In listbox.Items
                ret.Add(element)
            Next element
        End If
        Return ret
    End Function

    Shared Function fillListBoxFromArrayList(ByRef listbox As ListBox, ByVal arraylist As ArrayList) As Integer
        Dim i As Integer = 0
        If arraylist IsNot Nothing Then
            For Each element As Object In arraylist
                i += listbox.Items.Add(element)
            Next
        End If
        Return i
    End Function

    Shared Sub OnlyNumbers(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim C As Char
        Dim s As String
        Dim TB As TextBox
        Dim IsValid As Boolean
        TB = CType(sender, TextBox)
        IsValid = True
        s = sender.text
        C = e.KeyChar
        Select Case C
            Case "0" To "9", Chr(8), Chr(13)
            Case ","
                If InStr(TB.Text, ",") > 0 Then
                    IsValid = False
                End If
            Case Else
                IsValid = False
        End Select
        If IsValid Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Function LancioDadi(ByVal randomLaunches As MersenneTwister, ByVal facce As Integer, ByVal nTiri As Integer, ByVal nDadi As Integer, ByVal bonus As Integer) As String
        Dim ret As String = ""
        Dim appo As Integer = 0
        Dim i As Integer = 1
        Dim j As Integer = 1
        Const sep As String = " "
        Select Case facce
            Case 0
                ret = "Dado con 0 facce. Calcolo impossibile."
                Exit Select
            Case Else
                For i = 1 To nTiri
                    For j = 1 To nDadi
                        appo += (randomLaunches.Next(1, facce) + bonus)
                    Next j
                    ret &= sep & appo & sep
                    appo = 0
                Next i
        End Select
        Return ret
    End Function

    Shared Function TrimString(ByVal separator As String, ByVal srcString As String) As String
        Dim ret As String = ""
        Dim i As Integer = 0
        Dim s As String()
        Dim sep As Char() = separator.ToCharArray
        If srcString.Contains(separator) Then
            s = srcString.Split(sep)
            ret = s(0)
        End If
        Return ret
    End Function

    Shared Sub SortNSetNotSortable(ByVal dataGridView As DataGridView, ByVal sortDirection As System.ComponentModel.ListSortDirection)
        If Not dataGridView.Columns.Count = 0 Then
            dataGridView.Sort(dataGridView.Columns.Item(0), sortDirection)
            For Each column As DataGridViewColumn In dataGridView.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next column
        End If
    End Sub

    Shared Function GetFileName(ByVal path As String) As String
        Dim ret As String
        ret = path.Substring(path.LastIndexOf("\") + 1, (path.LastIndexOf(".") - path.LastIndexOf("\")) - 1)
        Return ret
    End Function
End Class