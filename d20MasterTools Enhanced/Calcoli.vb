Public Class Calcoli
    Const sep As String = " - "
    Const PE As Double = 120
    Const INTERPRETAZIONE As Double = 35
    Const STRATEGIA As Double = 20
    Const INTERAZIONE As Double = 25
    Const PADRONEGGIO_PARAMETRI As Double = 20

    Function Percentage(ByVal param As Double, ByVal num As Double) As Double
        Dim percalc As Double
        percalc = (num * param) / 100
        Return percalc
    End Function

    Function CalcPE(ByVal maxpe As Double, ByVal int As Double, ByVal str As Double, ByVal it As Double, ByVal pp As Double) As String
        Dim votoint, votostr, votoit, votopp, malus, bonus, mb, totPe As Double
        Dim s As String
        malus = Percentage(maxpe, 25)
        bonus = Percentage(maxpe, 75)
        votoint = Percentage(maxpe, INTERPRETAZIONE) / 10 * int
        votostr = Percentage(maxpe, STRATEGIA) / 10 * str
        votoit = Percentage(maxpe, INTERAZIONE) / 10 * it
        votopp = Percentage(maxpe, PADRONEGGIO_PARAMETRI) / 10 * pp
        totPe = votoint + votostr + votoit + votopp
        mb = Percentage(totPe, 5)
        If (totPe <= malus) Then
            totPe = totPe - mb
            s = " Totale: " & totPe.ToString & Chr(13) & "Interpretazione: " & votoint.ToString & Chr(13) & "Strategia: " & votostr.ToString & Chr(13) & "Interazione: " & votoit.ToString & Chr(13) & "Padroneggio dei Parametri: " & votopp.ToString & Chr(13) & "Malus: " & mb
        ElseIf (totPe >= bonus) Then
            totPe = totPe + mb
            s = " Totale: " & totPe.ToString & Chr(13) & "Interpretazione: " & votoint.ToString & Chr(13) & "Strategia: " & votostr.ToString & Chr(13) & "Interazione: " & votoit.ToString & Chr(13) & "Padroneggio dei Parametri: " & votopp.ToString & Chr(13) & "Bonus: " & mb
        Else
            totPe = totPe
            s = " Totale: " & totPe.ToString & Chr(13) & "Interpretazione: " & votoint.ToString & Chr(13) & "Strategia: " & votostr.ToString & Chr(13) & "Interazione: " & votoit.ToString & Chr(13) & "Padroneggio dei Parametri: " & votopp.ToString
        End If
        Return s
    End Function

    Function PEB(ByVal pg As Integer, ByVal mostri As Integer, ByVal GS As Double) As Double
        Dim pebcalc As Double
        pebcalc = (pg * mostri * GS) * PE
        Return pebcalc
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For m As Integer = 0 To 100
            ProgressBar1.Value = m
        Next
        Dim k As Double
        Dim i, j As Integer
        Try
            i = CInt(TextBox1.Text)
            j = CInt(TextBox2.Text)
            k = CDbl(TextBox3.Text)
            MessageBox.Show("I PE totali sono " & PEB(i, j, k) & " e ad ogni PG vanno " & (PEB(i, j, k) \ i) & " PE", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As InvalidCastException
            MessageBox.Show("Il tipo inserito non � un numero.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Catch ex1 As DivideByZeroException
            MessageBox.Show("Parametri non inseriti o non corretti. Controllare i parametri.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Catch gex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For m As Integer = 0 To 100
            ProgressBar1.Value = m
        Next
        Dim a, b, c, d, f As Double
        Try
            a = CDbl(TrackBar1.Value)
            b = CDbl(TrackBar2.Value)
            c = CDbl(TrackBar3.Value)
            d = CDbl(TrackBar4.Value)
            f = CDbl(TextBox4.Text)
            MessageBox.Show("I PE da assegnare sono " & CalcPE(f, a, b, c, d), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As InvalidCastException
            MessageBox.Show("Il tipo inserito non � un numero.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Catch ex1 As DivideByZeroException
            MessageBox.Show("Parametri non inseriti o non corretti. Controllare i parametri.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Catch gex As Exception
        End Try
    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Me.Label5.Text = "Interpretazione 35%" & sep & Me.TrackBar1.Value
    End Sub

    Private Sub TrackBar2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar2.ValueChanged
        Me.Label6.Text = "Strategia 20%" & sep & Me.TrackBar2.Value
    End Sub

    Private Sub TrackBar3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar3.ValueChanged
        Me.Label7.Text = "Interazione 25%" & sep & Me.TrackBar3.Value
    End Sub

    Private Sub TrackBar4_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar4.ValueChanged
        Me.Label8.Text = "Padroneggio dei Parametri 20%" & sep & Me.TrackBar4.Value
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For m As Integer = 0 To 100
            ProgressBar1.Value = m
        Next
        Dim mostri As Integer
        Dim gs As String = Me.TextBox5.Text
        Dim midGS As Double
        If Not Integer.TryParse(TextBox6.Text, mostri) Then
            MessageBox.Show("Parametro ""Mostri"" non inserito o non corretto. Controllare il parametro.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Try
            midGS = Utils.CalcoloGS(mostri, gs)
        Catch ex As IndexOutOfRangeException
            Exit Sub
        End Try
        'MessageBox.Show(midGS, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub
End Class