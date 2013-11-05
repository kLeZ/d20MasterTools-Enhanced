Public Class NuovoPG
    Private Sub NuovoPG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        AddHandler TextBox6.KeyPress, AddressOf Utils.OnlyNumbers
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim idCampagna As Integer = MDIMain.Sessione.Item("idCampagna")
        DBADO.insertPG(idCampagna, Me.CheckBox1.Checked, Me.TextBox1.Text.Replace("'", "''"), Me.TextBox2.Text.Replace("'", "''"), Me.TextBox3.Text.Replace("'", "''"), CInt(Me.NumericUpDown1.Value), Me.TextBox4.Text.Replace("'", "''"), Me.TextBox5.Text.Replace("'", "''"), Me.DateTimePicker1.Value, Me.TextBox7.Text.Replace("'", "''"), CInt(Me.TextBox6.Text))
        DBADO.updateNumeroPG(idCampagna)
        MDIMain.Sessione.Remove("campagna")
        MDIMain.Sessione.Add("campagna", DBADO.getInfoCampagna(idCampagna))
        MDIMain.Sessione.Remove("listapg")
        MDIMain.Sessione.Add("listapg", DBADO.getListaPG(idCampagna))
        Me.Close()
        VisualizzaDatiCampagna.VisualizzaDatiCampagna_Load(sender, e)
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        If Me.TextBox7.Modified Then
            Me.TextBox7.Text = Utils.NormalizeReturn(Me.TextBox7.Text)
        End If
    End Sub
End Class