Public Class CancellaCampagna
    Private Sub CancellaCampagna_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MDIMain.Sessione.Clear()
    End Sub

    Private Sub CancellaCampagna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim al As ArrayList = DBADO.getListaCampagne
        For Each campagna As Campagna In al
            Me.ListBox1.Items.Add(campagna.Nome & "(" & campagna.ID.ToString & ")")
            Me.ListBox2.Items.Add(campagna.Inizio)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Me.ListBox2.SelectedIndex = Me.ListBox1.SelectedIndex
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        Me.ListBox1.SelectedIndex = Me.ListBox2.SelectedIndex
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("Vuoi cancellare una campagna salvata?", My.Application.Info.Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            Dim nome As String = Me.ListBox1.SelectedItem()
            DBADO.deleteCampagna(Utils.getIDFromName(nome))
            Me.ListBox1.Items.Clear()
            Me.ListBox2.Items.Clear()
            Dim al As ArrayList = DBADO.getListaCampagne
            For Each campagna As Campagna In al
                Dim s As String = campagna.Nome & "(" & campagna.ID.ToString & ")"
                Me.ListBox1.Items.Add(s)
                Me.ListBox2.Items.Add(campagna.Inizio)
            Next
        End If
    End Sub
End Class