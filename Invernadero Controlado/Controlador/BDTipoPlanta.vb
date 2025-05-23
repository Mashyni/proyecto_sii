Imports System.Data.SqlClient
Imports Modelo

Public Class BDTipoPlanta
    Inherits ConexionBD
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader

    Public Function mostrar() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("sp_ListarTiposPlanta", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox("Error al mostrar tipos de planta: " & ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(tipo As CTipoPlanta) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("sp_InsertarTipoPlanta", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@NombreTipo", tipo.NombreTipo)
            cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion)
            Return cmd.ExecuteNonQuery() > 0
        Catch ex As Exception
            MsgBox("Error al insertar tipo de planta: " & ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function editar(tipo As CTipoPlanta) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("sp_ActualizarTipoPlanta", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TipoID", tipo.TipoID)
            cmd.Parameters.AddWithValue("@NombreTipo", tipo.NombreTipo)
            cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion)
            Return cmd.ExecuteNonQuery() > 0
        Catch ex As Exception
            MsgBox("Error al editar tipo de planta: " & ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function eliminar(tipoID As Integer) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("sp_EliminarTipoPlanta", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TipoID", tipoID)
            Return cmd.ExecuteNonQuery() > 0
        Catch ex As Exception
            MsgBox("Error al eliminar tipo de planta: " & ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function
End Class
