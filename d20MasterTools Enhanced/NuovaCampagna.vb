Public Class NuovaCampagna
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sngl As Single
        If Not (DBADO.insertCampagna(IIf(Me.TextBox1.Text.Contains("'"), Me.TextBox1.Text.Replace("'", ""), Me.TextBox1.Text), IIf(Me.TextBox2.Text.Contains("'"), Me.TextBox1.Text.Replace("'", ""), Me.TextBox2.Text), Me.DateTimePicker1.Value, IIf(Single.TryParse(Me.TextBox3.Text, sngl), sngl, "0,0"), Me.TextBox4.Text).Equals(0)) Then
            MessageBox.Show("Campagna inserita con successo!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show("Errore nell'inserimento dei dati." & vbCrLf & "Riprovare in un secondo momento e controllare che i dati inseriti siano corretti.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        Dim campagna As Campagna = DBADO.getInfoCampagna()
        MDIMain.Sessione.Add("campagna", campagna)
        MDIMain.Sessione.Add("listapg", DBADO.getListaPG(campagna.ID.ToString))
        Me.Close()
        VisualizzaDatiCampagna.Show()
    End Sub

    Private Sub NuovaCampagna_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler TextBox3.KeyPress, AddressOf Utils.OnlyNumbers
        
    End Sub
End Class