Imports Modelo

Public Class NCliente
    Private dcliente As New DCliente()

    Public Function Listar() As DataTable
        Return dcliente.Listar()
    End Function

    Public Function Insertar(nombre As String, apellido As String, direccion As String,
                           telefono As String, email As String) As Boolean
        If String.IsNullOrEmpty(nombre) Or String.IsNullOrEmpty(apellido) Then
            Return False
        End If
        Return dcliente.Insertar(nombre, apellido, direccion, telefono, email)
    End Function

    Public Function Actualizar(id As Integer, nombre As String, apellido As String,
                             direccion As String, telefono As String, email As String) As Boolean
        If String.IsNullOrEmpty(nombre) Or String.IsNullOrEmpty(apellido) Or id <= 0 Then
            Return False
        End If
        Return dcliente.Actualizar(id, nombre, apellido, direccion, telefono, email)
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        If id <= 0 Then
            Return False
        End If
        Return dcliente.Eliminar(id)
    End Function

    Public Function BuscarPorId(id As Integer) As DataTable
        If id <= 0 Then
            Return Nothing
        End If
        Return dcliente.BuscarPorId(id)
    End Function
End Class