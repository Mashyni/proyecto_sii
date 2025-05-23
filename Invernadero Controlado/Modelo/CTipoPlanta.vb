Public Class CTipoPlanta
    Public Property TipoID As Integer
    Public Property NombreTipo As String
    Public Property Descripcion As String

    ' Constructor vacío
    Public Sub New()
    End Sub

    ' Constructor con parámetros
    Public Sub New(id As Integer, nombre As String, descripcion As String)
        Me.TipoID = id
        Me.NombreTipo = nombre
        Me.Descripcion = descripcion
    End Sub
End Class

