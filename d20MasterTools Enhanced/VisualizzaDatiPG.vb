Public Class VisualizzaDatiPG
    Private Sub VisualizzaDatiPG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim idPG As Long = MDIMain.Sessione.Item("idPG")
        Dim PG As PG = DBADO.getInfoPG(idPG)
        Dim classiECDP As String = ""
        classiECDP = PG.Classe & ", "
        If Not PG.Multiclasse.Equals("") Then
            classiECDP &= PG.Multiclasse & ", "
        End If
        If Not PG.CDP.Equals("") Then
            classiECDP &= PG.CDP
        End If
        classiECDP = classiECDP.TrimEnd(", ".ToCharArray)
        Me.Label2.Text = PG.Nome
        Me.Label4.Text = PG.Razza
        Me.TextBox2.Text = classiECDP
        Me.Label8.Text = PG.Livello
        Me.Label10.Text = PG.DataCreazione
        Me.Label12.Text = PG.PE
        Me.TextBox1.Text = PG.Background
    End Sub
End Class