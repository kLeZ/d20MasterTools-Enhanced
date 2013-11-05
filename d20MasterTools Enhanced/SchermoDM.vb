Public Class SchermoDM
    Private Caller As Object = Nothing

    Public Overloads Sub Show(ByVal Caller As Object)
        Me.Caller = Caller
        Me.Show()
    End Sub

    Private Sub SchermoDM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        DBADO.GetTabellaPerSchermoDM(Caller, Me.DataGridView1, Me.DataGridView2, Me.Label1, Me.Text)
    End Sub
End Class