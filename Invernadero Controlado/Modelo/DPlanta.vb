Imports System.Data
Imports System.Data.SqlClient

Public Class DPlanta
    Public Function Listar() As DataTable
        Dim dt As New DataTable
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            conexion.Open()
            Using cmd As New SqlCommand("sp_ListarPlantas", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function Insertar(nombre As String, idCategoria As Integer, precio As Decimal,
                           stock As Integer, descripcion As String) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_InsertarPlanta", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria)
                    cmd.Parameters.AddWithValue("@Precio", precio)
                    cmd.Parameters.AddWithValue("@Stock", stock)
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Actualizar(id As Integer, nombre As String, idCategoria As Integer,
                             precio As Decimal, stock As Integer, descripcion As String) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_ActualizarPlanta", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdPlanta", id)
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria)
                    cmd.Parameters.AddWithValue("@Precio", precio)
                    cmd.Parameters.AddWithValue("@Stock", stock)
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
                Using cmd As New SqlCommand("sp_EliminarPlanta", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdPlanta", id)
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
            Using cmd As New SqlCommand("sp_BuscarPlanta", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdPlanta", id)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function ActualizarStock(idPlanta As Integer, cantidad As Integer) As Boolean
        Try
            Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
                conexion.Open()
                Using cmd As New SqlCommand("sp_ActualizarStock", conexion)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdPlanta", idPlanta)
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class