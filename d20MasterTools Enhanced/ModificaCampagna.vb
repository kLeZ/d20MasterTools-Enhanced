Public Class ModificaCampagna
    Private Sub ModificaCampagna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim Campagna As Campagna = MDIMain.Sessione.Item("campagna")
        Me.Label5.Text = Campagna.ID.ToString
        Me.TextBox1.Text = Campagna.Nome
        Me.TextBox2.Text = Campagna.Master
        Me.Label4.Text = Campagna.NumeroPG
        Me.DateTimePicker1.Value = Campagna.Inizio
        Me.DateTimePicker2.Value = Campagna.Fine
        Me.NumericUpDown1.Value = Campagna.Sessioni
        Me.NumericUpDown2.Value = Campagna.VersioneDND
        Me.TextBox3.Text = Campagna.Ambientazione
        Me.TextBox4.Text = Campagna.Trama
        Me.Label6.Text = Campagna.Mappa
        If Not Campagna.Mappa.Equals("") Then
            Me.PictureBox1.Image = Image.FromFile(Campagna.Mappa)
        End If
        ' OpenFileDialog Settings
        With Me.OpenFileDialog1
            .CheckFileExists = True
            .CheckPathExists = True
            .Filter = "File immagine (*.gif, *.jpg, *.jpeg, *.bmp, *.wmf, *.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png|Tutti i file (*.*)|*.*"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Multiselect = False
            .RestoreDirectory = True
            .SupportMultiDottedExtensions = True
            .ValidateNames = True
            .FileName = ""
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not (PictureBox1.Image Is Nothing) Then
                PictureBox1.Image.Dispose()
                PictureBox1.Image = Nothing
            End If
            Me.PictureBox1.Image = Bitmap.FromFile(Me.OpenFileDialog1.FileName)
            Me.Label6.Text = Me.OpenFileDialog1.FileName
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
        Dim imagePath As String = My.Computer.FileSystem.CurrentDirectory.ToString & "\Images\" & My.Application.Info.Title & "-" & Me.TextBox1.Text.Replace(" ", "_") & "-Image_" & Me.Label5.Text & ".jpg"
        If Me.PictureBox1.Image IsNot Nothing And Not My.Computer.FileSystem.FileExists(imagePath) Then
            Me.PictureBox1.Image.Save(imagePath)
            DBADO.updateCampagna(Me.Label5.Text, TextBox1.Text.Replace("'", "''"), TextBox2.Text.Replace("'", "''"), DateTimePicker1.Value, DateTimePicker2.Value, CInt(NumericUpDown1.Value), CSng(NumericUpDown2.Value), TextBox3.Text.Replace("'", "''"), TextBox4.Text.Replace("'", "''"), imagePath.Replace("'", "''"))
        Else
            imagePath = ""
            DBADO.updateCampagna(Me.Label5.Text, TextBox1.Text.Replace("'", "''"), TextBox2.Text.Replace("'", "''"), DateTimePicker1.Value, DateTimePicker2.Value, CInt(NumericUpDown1.Value), CSng(NumericUpDown2.Value), TextBox3.Text.Replace("'", "''"), TextBox4.Text.Replace("'", "''"))
        End If
        MDIMain.Sessione.Remove("campagna")
        MDIMain.Sessione.Add("campagna", DBADO.getInfoCampagna(CInt(Me.Label5.Text)))
        Me.Close()
        VisualizzaDatiCampagna.VisualizzaDatiCampagna_Load(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.PictureBox1.Image IsNot Nothing And Me.Label6.Text IsNot "" Then
            Me.PictureBox1.Image.Dispose()
            If VisualizzaDatiCampagna.PictureBox1.Image IsNot Nothing Then
                VisualizzaDatiCampagna.PictureBox1.Image.Dispose()
                VisualizzaDatiCampagna.PictureBox1.Image = Nothing
            End If
            Me.PictureBox1.Image = Nothing
            My.Computer.FileSystem.DeleteFile(Me.Label6.Text, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
        Else
            MessageBox.Show("Il campo immagine � gi� vuoto!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub Label6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseHover
        Me.ToolTip1.Show(Me.Label6.Text, Me.Label6)
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Me.TextBox4.Text = Utils.NormalizeReturn(Me.TextBox4.Text)
    End Sub
End Class