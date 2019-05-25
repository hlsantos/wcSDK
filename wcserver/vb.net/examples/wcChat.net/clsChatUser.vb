Public Class clsChatUser

    Private mvarName As String
    Private mvarID As Integer
    Private mvarChannel As Integer
    Private mvarTopic As String

    Public Property Name() As String
        Get
            Return mvarName
        End Get
        Set(ByVal value As String)
            mvarName = value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return mvarID
        End Get
        Set(ByVal value As Integer)
            mvarID = value
        End Set
    End Property

    Public Property Channel() As Integer
        Get
            Return mvarChannel
        End Get
        Set(ByVal value As Integer)
            mvarChannel = value
        End Set
    End Property

    Public Property Topic() As String
        Get
            Return mvarTopic
        End Get
        Set(ByVal value As String)
            mvarTopic = value
        End Set
    End Property

End Class
