Imports Modelo

Public Class NCategoria
    Private dcategoria As New DCategoria()

    Public Function Listar() As DataTable
        Return dcategoria.Listar()
    End Function

    Public Function Insertar(nombre As String, descripcion As String) As Boolean
        If String.IsNullOrEmpty(nombre) Then
            Return False
        End If
        Return dcategoria.Insertar(nombre, descripcion)
    End Function

    Public Function Actualizar(id As Integer, nombre As String, descripcion As String) As Boolean
        If String.IsNullOrEmpty(nombre) Or id <= 0 Then
            Return False
        End If
        Return dcategoria.Actualizar(id, nombre, descripcion)
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        If id <= 0 Then
            Return False
        End If
        Return dcategoria.Eliminar(id)
    End Function
End Class