Public Class TimerCombattimento
    Const RoundHeader As String = "Round"
    Dim firstRound As Boolean = True

    Private Sub TimerCombattimento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Me.TextBox1.Text = (Me.DataGridView1.Columns.Count - 2)
        Me.DataGridView1.Columns.Item(0).ReadOnly = True
        Me.DataGridView1.Columns.Item(1).ReadOnly = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim max As Integer = Me.DataGridView1.Columns.Count - 1
        For i As Integer = max To 2 Step -1
            Me.DataGridView1.Columns.RemoveAt(i)
        Next i
        Me.TextBox1.Text = (Me.DataGridView1.Columns.Count - 2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oUtils As New Utils
        Dim newRound As String = RoundHeader & (Me.DataGridView1.Columns.Count - 1)
        If Me.DataGridView2.Rows.Count > 1 And firstRound Then
            Me.DataGridView1.Rows.Add(Me.DataGridView2.Rows.Count - 1)
            For i As Integer = 0 To Me.DataGridView2.Rows.Count - 2
                For j As Integer = 0 To Me.DataGridView2.Rows.Item(i).Cells.Count - 1
                    If j > 1 Then Exit For
                    Me.DataGridView1.Rows.Item(i).Cells.Item(j).Value = Me.DataGridView2.Rows.Item(i).Cells.Item(j).Value
                Next j
            Next i
            Me.DataGridView1.Sort(Me.DataGridView1.Columns.Item(1), System.ComponentModel.ListSortDirection.Descending)
            Me.DataGridView2.Sort(Me.DataGridView2.Columns.Item(1), System.ComponentModel.ListSortDirection.Descending)
            Dim newColumn As New DataGridViewColumn
            Dim newCellTemplate As New DataGridViewTextBoxCell
            newColumn.CellTemplate = newCellTemplate
            newColumn.Name = newRound
            newColumn.HeaderText = newRound
            newColumn.ReadOnly = False
            Me.DataGridView1.Columns.Insert(2, newColumn)
            Dim random As New MersenneTwister
            If Me.CheckBox1.Checked Then
                For Each row As DataGridViewRow In Me.DataGridView1.Rows
                    row.Cells.Item("IniziativaTotale").Value = CInt(oUtils.LancioDadi(MDIMain.Randomizer, 20, 1, 1, CInt(row.Cells.Item("IniziativaTotale").Value)))
                Next row
            End If
            Me.DataGridView1.Sort(Me.DataGridView1.Columns.Item("IniziativaTotale"), System.ComponentModel.ListSortDirection.Descending)
            firstRound = False
        ElseIf Not firstRound Then
            Dim newColumn As New DataGridViewColumn
            Dim newCellTemplate As New DataGridViewTextBoxCell
            newColumn.CellTemplate = newCellTemplate
            newColumn.Name = newRound
            newColumn.HeaderText = newRound
            newColumn.ReadOnly = False
            Me.DataGridView1.Columns.Insert(2, newColumn)
            Me.DataGridView1.Sort(Me.DataGridView1.Columns.Item("IniziativaTotale"), System.ComponentModel.ListSortDirection.Descending)
        Else
            MessageBox.Show("Non ci sono combattenti nella lista Combattenti.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        Me.TextBox1.Text = (Me.DataGridView1.Columns.Count - 2)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Button1_Click(sender, e)
        Me.DataGridView1.Rows.Clear()
        firstRound = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.DataGridView2.Rows.Clear()
    End Sub
End Class