Public Class VelocitaMovimento
    Private _id As Integer
    Private _velocita As Double
    Private _descrizione As String

    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Velocità() As Double
        Get
            Return _velocita
        End Get
        Set(ByVal value As Double)
            _velocita = value
        End Set
    End Property

    Public Property Descrizione() As String
        Get
            Return _descrizione
        End Get
        Set(ByVal value As String)
            _descrizione = value
        End Set
    End Property
End Class