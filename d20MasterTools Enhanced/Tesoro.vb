Public Class Tesoro
    Private _id As Long
    Private _nome As String
    Private _descrizione As String
    Private _pagina As Integer
    Private _manuale As String
    Private _prezzo As Integer
    Private _tipo_oggetto As String

    Public Property ID() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
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

    Public Property Pagina() As Integer
        Get
            Return _pagina
        End Get
        Set(ByVal value As Integer)
            _pagina = value
        End Set
    End Property

    Public Property Manuale() As String
        Get
            Return _manuale
        End Get
        Set(ByVal value As String)
            _manuale = value
        End Set
    End Property

    Public Property Prezzo() As Integer
        Get
            Return _prezzo
        End Get
        Set(ByVal value As Integer)
            _prezzo = value
        End Set
    End Property

    Public Property TipoOggetto() As String
        Get
            Return _tipo_oggetto
        End Get
        Set(ByVal value As String)
            _tipo_oggetto = value
        End Set
    End Property
End Class