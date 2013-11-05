Public NotInheritable Class Sessione
    Inherits Hashtable
    Public Overrides Sub Add(ByVal key As Object, ByVal value As Object)
        If Not MyBase.ContainsKey(key) Then
            MyBase.Add(key, value)
        End If
    End Sub
End Class