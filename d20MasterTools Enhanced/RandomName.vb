Public Class RandomName
    Private Sub RandomName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NumericUpDown1.Value = 35
        Me.NumericUpDown1.Maximum = 1000
        
        Dim currentDir As String = My.Computer.FileSystem.CurrentDirectory.ToString
        Dim fileContents As String = My.Computer.FileSystem.ReadAllText(currentDir & "\namesrc.rng")
        Dim separatore As String() = {vbCrLf}
        Dim al As ArrayList = Utils.getListFromString(fileContents, separatore)
        Utils.fillListBoxFromArrayList(Me.ListBox1, al)
        Me.Button3_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.ListBox1.Items.Add(Me.TextBox1.Text)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.ListBox1.Items.Remove(Me.ListBox1.SelectedItem)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.ListBox1.Items.Clear()
        Me.RandomName_Load(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim currentDir As String = My.Computer.FileSystem.CurrentDirectory.ToString
        Utils.SaveElementsFromListbox(Me.ListBox1, currentDir & "\namesrc.rng", False)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For i As Integer = 0 To Me.ListBox1.Items.Count - 1
            Me.ListBox1.SelectedIndex = i
        Next i
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.ListBox1.SelectedItem = Nothing
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim patternList As ArrayList = Utils.fillArrayListFromListBox(Me.ListBox1, True)
        Dim numberToGenerate As Integer = Decimal.ToInt32(Me.NumericUpDown1.Value)
        Dim oUtils As New Utils
        Try
            Me.TextBox2.Text = oUtils.GetRandomNamesFromPatternList(MDIMain.Randomizer, patternList, numberToGenerate)
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("Devi selezionare almeno una chiave per la generazione.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class