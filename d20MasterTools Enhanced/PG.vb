Public Class PG
    Private _id As Long
    Private _campagna As Long
    Private _png As Boolean
    Private _nomePG As String
    Private _razza As String
    Private _classePartenza As String
    Private _livello As Integer
    Private _multiclasse As String
    Private _cdp As String
    Private _dataCreazione As Date
    Private _background As String
    Private _PE As Integer

    Public Property ID() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property

    Public Property IDCampagna() As Long
        Get
            Return _campagna
        End Get
        Set(ByVal value As Long)
            _campagna = value
        End Set
    End Property

    Public Property isPng() As Boolean
        Get
            Return _png
        End Get
        Set(ByVal value As Boolean)
            _png = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _nomePG
        End Get
        Set(ByVal value As String)
            _nomePG = value
        End Set
    End Property

    Public Property Razza() As String
        Get
            Return _razza
        End Get
        Set(ByVal value As String)
            _razza = value
        End Set
    End Property

    Public Property Classe() As String
        Get
            Return _classePartenza
        End Get
        Set(ByVal value As String)
            _classePartenza = value
        End Set
    End Property

    Public Property Livello() As Integer
        Get
            Return _livello
        End Get
        Set(ByVal value As Integer)
            _livello = value
        End Set
    End Property

    Public Property Multiclasse() As String
        Get
            Return _multiclasse
        End Get
        Set(ByVal value As String)
            _multiclasse = value
        End Set
    End Property

    Public Property CDP() As String
        Get
            Return _cdp
        End Get
        Set(ByVal value As String)
            _cdp = value
        End Set
    End Property

    Public Property DataCreazione() As Date
        Get
            Return _dataCreazione
        End Get
        Set(ByVal value As Date)
            _dataCreazione = value
        End Set
    End Property

    Public Property Background() As String
        Get
            Return _background
        End Get
        Set(ByVal value As String)
            _background = value
        End Set
    End Property

    Public Property PE() As Integer
        Get
            Return _PE
        End Get
        Set(ByVal value As Integer)
            _PE = value
        End Set
    End Property
End Class