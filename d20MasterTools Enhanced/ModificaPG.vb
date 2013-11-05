Public Class ModificaPG
    Private PG As PG

    Private Sub ModificaPG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        AddHandler TextBox6.KeyPress, AddressOf Utils.OnlyNumbers
        PG = MDIMain.Sessione.Item("pg")
        Me.CheckBox1.Checked = PG.isPng
        Me.TextBox1.Text = PG.Nome
        Me.TextBox2.Text = PG.Razza
        Me.TextBox3.Text = PG.Classe
        Me.NumericUpDown1.Value = PG.Livello
        Me.TextBox4.Text = PG.CDP
        Me.TextBox5.Text = PG.Multiclasse
        Me.DateTimePicker1.Value = PG.DataCreazione
        Me.TextBox6.Text = PG.PE
        Me.TextBox7.Text = PG.Background
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        DBADO.updatePG(PG.ID, Me.CheckBox1.Checked, Me.TextBox1.Text.Replace("'", "''"), Me.TextBox2.Text.Replace("'", "''"), Me.TextBox3.Text.Replace("'", "''"), CInt(Me.NumericUpDown1.Value), Me.TextBox4.Text.Replace("'", "''"), Me.TextBox5.Text.Replace("'", "''"), Me.DateTimePicker1.Value.Date, Me.TextBox7.Text.Replace("'", "''"), CInt(Me.TextBox6.Text))
        MDIMain.Sessione.Remove("campagna")
        MDIMain.Sessione.Add("campagna", DBADO.getInfoCampagna(PG.IDCampagna))
        MDIMain.Sessione.Remove("listapg")
        MDIMain.Sessione.Add("listapg", DBADO.getListaPG(PG.IDCampagna))
        If VisualizzaDatiCampagna.ListBox1.Items.Contains(PG.Nome & "(" & PG.ID.ToString & ")") Then
            VisualizzaDatiCampagna.ListBox1.Items.Remove(PG.Nome & "(" & PG.ID.ToString & ")")
        ElseIf VisualizzaDatiCampagna.ListBox2.Items.Contains(PG.Nome & "(" & PG.ID.ToString & ")") Then
            VisualizzaDatiCampagna.ListBox2.Items.Remove(PG.Nome & "(" & PG.ID.ToString & ")")
        End If
        Me.Close()
        VisualizzaDatiCampagna.VisualizzaDatiCampagna_Load(sender, e)
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        If Me.TextBox7.Modified Then
            Me.TextBox7.Text = Utils.NormalizeReturn(Me.TextBox7.Text)
        End If
    End Sub
End Class