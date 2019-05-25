Option Strict On
Option Explicit On

Public Class clsList

    Private mvarName As String = ""
    Private mvarItemData As Integer = 0

#Region "Public Properties ..."

    Public Property DisplayName() As String
        Get
            Return mvarName
        End Get
        Set(ByVal value As String)
            mvarName = value
        End Set
    End Property

    Public Property ItemData() As Integer
        Get
            Return mvarItemData
        End Get
        Set(ByVal value As Integer)
            mvarItemData = value
        End Set
    End Property

#End Region

#Region "Public Subroutines ..."

    Public Sub New()

    End Sub

    Public Sub New(ByVal DisplayName As String, ByVal ItemData As Integer)

        mvarName = DisplayName
        mvarItemData = ItemData

    End Sub

#End Region

#Region "Public Functions ..."

    Public Overrides Function ToString() As String

        Return mvarName

    End Function

#End Region

End Class
