Imports Modelo

Public Class NPlanta
    Private dplanta As New DPlanta()

    Public Function Listar() As DataTable
        Return dplanta.Listar()
    End Function

    Public Function Insertar(nombre As String, idCategoria As Integer, precio As Decimal,
                           stock As Integer, descripcion As String) As Boolean
        If String.IsNullOrEmpty(nombre) Or idCategoria <= 0 Or precio <= 0 Or stock < 0 Then
            Return False
        End If
        Return dplanta.Insertar(nombre, idCategoria, precio, stock, descripcion)
    End Function

    Public Function Actualizar(id As Integer, nombre As String, idCategoria As Integer,
                             precio As Decimal, stock As Integer, descripcion As String) As Boolean
        If String.IsNullOrEmpty(nombre) Or id <= 0 Or idCategoria <= 0 Or precio <= 0 Or stock < 0 Then
            Return False
        End If
        Return dplanta.Actualizar(id, nombre, idCategoria, precio, stock, descripcion)
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        If id <= 0 Then
            Return False
        End If
        Return dplanta.Eliminar(id)
    End Function

    Public Function BuscarPorId(id As Integer) As DataTable
        If id <= 0 Then
            Return Nothing
        End If
        Return dplanta.BuscarPorId(id)
    End Function

    Public Function ActualizarStock(idPlanta As Integer, cantidad As Integer) As Boolean
        If idPlanta <= 0 Or cantidad <= 0 Then
            Return False
        End If
        Return dplanta.ActualizarStock(idPlanta, cantidad)
    End Function
End Class