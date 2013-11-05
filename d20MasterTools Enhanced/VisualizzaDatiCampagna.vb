Public Class VisualizzaDatiCampagna
    Shared Campagna As Campagna
    Protected SelectedListBox As System.Windows.Forms.ListBox

    Public Sub VisualizzaDatiCampagna_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Campagna = MDIMain.Sessione.Item("campagna")
        Dim listapg As ArrayList = MDIMain.Sessione.Item("listapg")
        MDIMain.Sessione.Clear()
        Me.Label1.Text = "Campagna: "
        Me.Label2.Text = "Master: "
        Me.Label3.Text = "Numero di PG: "
        Me.Label4.Text = "Data di inizio: "
        Me.Label5.Text = "Data di fine: "
        Me.Label6.Text = "Numero di sessioni giocate: "
        Me.Label7.Text = "Versione di D&D giocata: "
        Me.Label8.Text = "Ambientazione utilizzata: "
        Me.Label9.Text = Campagna.Nome
        Me.Label10.Text = Campagna.Master
        Me.Label11.Text = Campagna.NumeroPG
        Me.Label12.Text = Campagna.Inizio
        Me.Label13.Text = Campagna.Fine
        Me.Label14.Text = Campagna.Sessioni
        Me.Label15.Text = Campagna.VersioneDND
        Me.Label16.Text = Campagna.Ambientazione
        Me.TextBox1.Text = Campagna.Trama
        If Campagna.Mappa IsNot Nothing Then
            If Not Campagna.Mappa.Equals("") Then
                Me.PictureBox1.Image = Image.FromFile(Campagna.Mappa, True)
            End If
        End If
        If listapg IsNot Nothing Then
            Me.ListBox1.Items.Clear()
            Me.ListBox2.Items.Clear()
            For Each pg As PG In listapg
                If Not pg.isPng Then
                    Me.ListBox1.Items.Add(pg.Nome & "(" & pg.ID.ToString & ")")
                Else
                    Me.ListBox2.Items.Add(pg.Nome & "(" & pg.ID.ToString & ")")
                End If
            Next
        End If
        If Campagna.NumeroPG <= 0 Then
            Me.Button1.Enabled = False
            Me.Button2.Enabled = False
        ElseIf Campagna.NumeroPG > 0 Then
            Me.Button1.Enabled = True
            Me.Button2.Enabled = True
        End If
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If Me.PictureBox1.Image IsNot Nothing Then
            VisualizzaImmagine.Show()
            VisualizzaImmagine.PictureBox1.Image = Me.PictureBox1.Image
        End If
    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        Me.ToolTip1.Show("Doppio Click per ingrandire", Me.PictureBox1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'modifica pg
        If Not MDIMain.Sessione.ContainsKey("pg") And SelectedListBox IsNot Nothing Then
            MDIMain.Sessione.Add("pg", DBADO.getInfoPG(Utils.getIDFromName(SelectedListBox.SelectedItem)))
            MDIMain.Sessione.Add("idCampagna", Campagna.ID)
            ModificaPG.Show()
        Else
            MessageBox.Show("Non ci sono elementi selezionati. Seleziona un elemento.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'cancella pg
        If SelectedListBox IsNot Nothing Then
            If MessageBox.Show("Vuoi cancellare il PG: " & SelectedListBox.SelectedItem.ToString.Remove(SelectedListBox.SelectedItem.ToString.IndexOf("(")) & "?", My.Application.Info.Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                DBADO.deletePG(Utils.getIDFromName(SelectedListBox.SelectedItem))
                DBADO.updateNumeroPG(Campagna.ID)
                MDIMain.Sessione.Remove("campagna")
                MDIMain.Sessione.Add("campagna", DBADO.getInfoCampagna(Campagna.ID))
                MDIMain.Sessione.Remove("listapg")
                MDIMain.Sessione.Add("listapg", DBADO.getListaPG(Campagna.ID))
                If Me.ListBox1.Items.Contains(SelectedListBox.SelectedItem) Then
                    Me.ListBox1.Items.Remove(SelectedListBox.SelectedItem)
                ElseIf Me.ListBox2.Items.Contains(SelectedListBox.SelectedItem) Then
                    Me.ListBox2.Items.Remove(SelectedListBox.SelectedItem)
                End If
                Me.VisualizzaDatiCampagna_Load(sender, e)
                MessageBox.Show("Il PG � stato eliminato con successo!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("Non ci sono elementi selezionati. Seleziona un elemento.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'inserisci pg
        MDIMain.Sessione.Add("idCampagna", Campagna.ID)
        NuovoPG.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'modifica campagna
        MDIMain.Sessione.Add("campagna", VisualizzaDatiCampagna.Campagna)
        VisualizzaDatiCampagna.Campagna = Nothing
        ModificaCampagna.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.ListBox1.ClearSelected()
        Me.ListBox2.ClearSelected()
        SelectedListBox = Nothing
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        SelectedListBox = Me.ListBox1
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        SelectedListBox = Me.ListBox2
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Me.TextBox1.Text = Utils.NormalizeReturn(Me.TextBox1.Text)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'visualizza pg
        If SelectedListBox IsNot Nothing Then
            Dim idPG As Long = Utils.getIDFromName(SelectedListBox.SelectedItem)
            If Not MDIMain.Sessione.ContainsKey("idPG") Then
                MDIMain.Sessione.Add("idPG", idPG)
            Else
                MDIMain.Sessione.Remove("idPG")
                MDIMain.Sessione.Add("idPG", idPG)
            End If
            VisualizzaDatiPG.Show()
        Else
            MessageBox.Show("Non ci sono elementi selezionati. Seleziona un elemento.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub
End Class