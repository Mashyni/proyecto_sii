Imports System.Data
Imports System.Data.SqlClient

Public Class DCategoria
    Public Function Listar() As DataTable
        Dim dt As New DataTable
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            conexion.Open()
            Using cmd As New SqlCommand("sp_ListarCategorias", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function Insertar(nombre As String, descripcion As String) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_InsertarCategoria", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Actualizar(id As Integer, nombre As String, descripcion As String) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_ActualizarCategoria", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdCategoria", id)
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion)
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
                Using cmd As New SqlCommand("sp_EliminarCategoria", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdCategoria", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class