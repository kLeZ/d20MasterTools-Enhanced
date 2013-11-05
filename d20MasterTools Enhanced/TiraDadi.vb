Public Class TiraDadi
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim facce As Integer = 0
        Dim oUtils As New Utils
        If Me.RadioButton1.Checked Then
            facce = 0
        ElseIf Me.RadioButton2.Checked Then
            facce = 2
        ElseIf Me.RadioButton3.Checked Then
            facce = 3
        ElseIf Me.RadioButton4.Checked Then
            facce = 4
        ElseIf Me.RadioButton5.Checked Then
            facce = 5
        ElseIf Me.RadioButton6.Checked Then
            facce = 6
        ElseIf Me.RadioButton7.Checked Then
            facce = 8
        ElseIf Me.RadioButton8.Checked Then
            facce = 10
        ElseIf Me.RadioButton9.Checked Then
            facce = 12
        ElseIf Me.RadioButton10.Checked Then
            facce = 20
        ElseIf Me.RadioButton11.Checked Then
            facce = 30
        ElseIf Me.RadioButton12.Checked Then
            facce = 100
        End If
        Me.TextBox1.Text = oUtils.LancioDadi(MDIMain.Randomizer, facce, Decimal.ToInt32(Me.NumericUpDown1.Value), Decimal.ToInt32(Me.NumericUpDown2.Value), Decimal.ToInt32(Me.NumericUpDown3.Value))
    End Sub

    Private Sub TiraDadi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub
End Class