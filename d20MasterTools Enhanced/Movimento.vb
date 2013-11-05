Public Class Movimento
    Private Const sepKM As String = " km"
    Private al As ArrayList

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim velOraria As Double
        Dim oreViaggio As Double
        Dim modTerreno As Double
        Dim radio As New RadioButton
        For Each item As Object In Me.TableLayoutPanel1.Controls
            If item.GetType.Name.Contains("RadioButton") Then
                radio = item
                If radio.Checked Then
                    modTerreno = Double.Parse(radio.Text.Substring(1))
                    Exit For
                End If
            End If
        Next
        velOraria = Double.Parse(Utils.TrimString(sepKM, Me.TextBox1.Text))
        oreViaggio = Double.Parse(Me.NumericUpDown1.Value)
        Me.TextBox2.Text = (velOraria * oreViaggio * modTerreno) & sepKM
    End Sub

    Private Sub Movimento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        al = DBADO.getInfoMovimento
        For Each bean As VelocitaMovimento In al
            Me.ComboBox1.Items.Add(bean.Descrizione)
        Next
        Me.ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        For Each bean As VelocitaMovimento In al
            If bean.Descrizione.Equals(Me.ComboBox1.SelectedItem) Then
                Me.TextBox1.Text = bean.Velocità & sepKM
            End If
        Next
    End Sub
End Class