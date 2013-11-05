Public Class ApriCampagna
    Private Sub ApriCampagna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim Campagna As Campagna = DBADO.getInfoCampagna(Utils.getIDFromName(Me.ListBox1.SelectedItem()))
        MDIMain.Sessione.Add("campagna", Campagna)
        MDIMain.Sessione.Add("listapg", DBADO.getListaPG(Campagna.ID.ToString))
        Me.Close()
        VisualizzaDatiCampagna.Show()
    End Sub
End Class