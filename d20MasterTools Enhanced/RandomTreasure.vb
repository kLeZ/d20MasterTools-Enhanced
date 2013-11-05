Public Class RandomTreasure
    Dim tesori As New ArrayList
    Dim tesoriFil As New ArrayList
    'Cambiare i nomi delle costanti
    Const OGG_ARTE As String = "Oggetto d'Arte"
    Const GEMME As String = "Gemma"
    Const OGG_MIN As String = "Oggetto minore"
    Const OGG_MED As String = "Oggetto medio"
    Const OGG_MAG As String = "Oggetto maggiore"

    Private Sub RandomTreasure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Sub Genera(ByVal tipoOggetto As String)
        For Each element As Tesoro In tesori
            If element.TipoOggetto.Equals(tipoOggetto) Then
                tesoriFil.Add(element)
            End If
        Next
        If tesoriFil.Count <> 0 Then
            Dim tesoro As Tesoro
            For i As Integer = 1 To Decimal.ToInt32(Me.NumericUpDown1.Value)
                tesoro = tesoriFil.Item(MDIMain.Randomizer.Next(0, tesoriFil.Count - 1))
                Me.ListBox1.Items.Add(tesoro.Nome & ", " & tesoro.Prezzo & "mo. " & tesoro.Manuale & ", " & tesoro.Pagina)
            Next i
        Else
            MessageBox.Show("Errore nel caricamento dei dati. I tesori non sono stati trovati." & vbCrLf & "Una reinstallazione dell'applicazione potrebbe risolvere il problema.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Sub Pulisci()
        tesori.Clear()
        tesoriFil.Clear()
        Me.ListBox1.Items.Clear()
    End Sub

    Private Sub PulisciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PulisciToolStripMenuItem.Click
        Pulisci()
    End Sub

    Private Sub OggettiMinoriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OggettiMinoriToolStripMenuItem.Click
        Genera(OGG_MIN)
    End Sub

    Private Sub OggettiMediToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OggettiMediToolStripMenuItem.Click
        Genera(OGG_MED)
    End Sub

    Private Sub OggettiMaggioriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OggettiMaggioriToolStripMenuItem.Click
        Genera(OGG_MAG)
    End Sub

    Private Sub GemmeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GemmeToolStripMenuItem.Click
        Genera(GEMME)
    End Sub

    Private Sub OggettiDarteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OggettiDarteToolStripMenuItem.Click
        Genera(OGG_ARTE)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.ListBox1.SelectedItem IsNot Nothing Then
            Dim item As New Tesoro
            Dim name As String
            With Me.ListBox1.SelectedItem.ToString()
                Name = .Substring(0, .IndexOf(",", 0))
            End With
            For Each tesoro As Tesoro In tesori
                If tesoro.Nome.Equals(Name) Then
                    item = tesoro
                    Exit For
                End If
            Next
            With VisualizzaDettaglioTesoro
                .tesoro = item
                .Show()
            End With
        End If
    End Sub
End Class