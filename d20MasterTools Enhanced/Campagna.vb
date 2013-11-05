Public Class Campagna
    Private _id As Long
    Private _nomeCampagna As String
    Private _nomeMaster As String
    Private _numeroPG As Integer
    Private _inizio As Date
    Private _fine As Date
    Private _numeroSessioni As Integer
    Private _versioneDND As Single
    Private _ambientazione As String
    Private _trama As String
    Private _mappa As String

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
            Return _nomeCampagna
        End Get
        Set(ByVal value As String)
            _nomeCampagna = value
        End Set
    End Property

    Public Property Master() As String
        Get
            Return _nomeMaster
        End Get
        Set(ByVal value As String)
            _nomeMaster = value
        End Set
    End Property

    Public Property NumeroPG() As Integer
        Get
            Return _numeroPG
        End Get
        Set(ByVal value As Integer)
            _numeroPG = value
        End Set
    End Property

    Public Property Inizio() As Date
        Get
            Return _inizio
        End Get
        Set(ByVal value As Date)
            _inizio = value
        End Set
    End Property

    Public Property Fine() As Date
        Get
            If Not _fine = Nothing Then
                Return _fine
            Else
                Return My.Computer.Clock.LocalTime
            End If
        End Get
        Set(ByVal value As Date)
            _fine = value
        End Set
    End Property

    Public Property Sessioni() As Integer
        Get
            Return _numeroSessioni
        End Get
        Set(ByVal value As Integer)
            _numeroSessioni = value
        End Set
    End Property

    Public Property VersioneDND() As Single
        Get
            Return _versioneDND
        End Get
        Set(ByVal value As Single)
            _versioneDND = value
        End Set
    End Property

    Public Property Ambientazione() As String
        Get
            Return _ambientazione
        End Get
        Set(ByVal value As String)
            _ambientazione = value
        End Set
    End Property

    Public Property Trama() As String
        Get
            Return _trama
        End Get
        Set(ByVal value As String)
            _trama = value
        End Set
    End Property

    Public Property Mappa() As String
        Get
            Return _mappa
        End Get
        Set(ByVal value As String)
            _mappa = value
        End Set
    End Property
End Class