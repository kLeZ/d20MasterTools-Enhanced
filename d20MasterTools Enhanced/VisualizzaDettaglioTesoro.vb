Public Class VisualizzaDettaglioTesoro
    Public tesoro As Tesoro

    Private Sub VisualizzaDettaglioTesoro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Me.Label2.Text = tesoro.Nome
        Me.Label6.Text = tesoro.TipoOggetto
        Me.Label8.Text = tesoro.Manuale
        Me.Label10.Text = tesoro.Pagina
        Me.Label12.Text = tesoro.Prezzo
        Me.TextBox1.Text = tesoro.Descrizione
    End Sub
End Class