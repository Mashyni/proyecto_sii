Imports System.Data
Imports System.Data.SqlClient

Public Class DCliente
    Public Function Listar() As DataTable
        Dim dt As New DataTable
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            conexion.Open()
            Using cmd As New SqlCommand("sp_ListarClientes", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function Insertar(nombre As String, apellido As String, direccion As String,
                           telefono As String, email As String) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_InsertarCliente", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@Apellido", apellido)
                    cmd.Parameters.AddWithValue("@Direccion", direccion)
                    cmd.Parameters.AddWithValue("@Telefono", telefono)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Actualizar(id As Integer, nombre As String, apellido As String,
                             direccion As String, telefono As String, email As String) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_ActualizarCliente", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdCliente", id)
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@Apellido", apellido)
                    cmd.Parameters.AddWithValue("@Direccion", direccion)
                    cmd.Parameters.AddWithValue("@Telefono", telefono)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_EliminarCliente", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdCliente", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function BuscarPorId(id As Integer) As DataTable
        Dim dt As New DataTable
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            conexion.Open()
            Using cmd As New SqlCommand("sp_BuscarCliente", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdCliente", id)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
End Class