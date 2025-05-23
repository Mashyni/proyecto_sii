Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports Modelo

Public Class BDUsuario
    Inherits ConexionBD
    Dim cmd As SqlCommand
    Public dr As SqlDataReader

    Public Function EncriptarBase64(texto As String) As String
        Dim bytesTexto As Byte() = System.Text.Encoding.UTF8.GetBytes(texto)
        Return Convert.ToBase64String(bytesTexto)
    End Function



    Public Function mostrar() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("sp_mostrar_usuarios", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(usuario As CUsuario) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("sp_insertar_usuario", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre)
            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno)
            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno)
            cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario)
            cmd.Parameters.AddWithValue("@Contraseña", EncriptarBase64(usuario.Contraseña))
            cmd.Parameters.AddWithValue("@RolID", usuario.RolID)
            Return cmd.ExecuteNonQuery() > 0
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function editar(usuario As CUsuario) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("sp_editar_usuario", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idUsuario", usuario.idUsuario)
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre)
            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno)
            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno)
            cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario)
            cmd.Parameters.AddWithValue("@Contraseña", EncriptarBase64(usuario.Contraseña))
            cmd.Parameters.AddWithValue("@RolID", usuario.RolID)
            Return cmd.ExecuteNonQuery() > 0
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function eliminar(idUsuario As Integer) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("sp_eliminar_usuario", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario)
            Return cmd.ExecuteNonQuery() > 0
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function buscar(campo As String, texto As String) As DataTable
        Try
            conectado()
            cmd = New SqlCommand("sp_buscar_usuario", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Campo", campo)
            cmd.Parameters.AddWithValue("@TextoBuscar", "%" & texto & "%")
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function mostrarrol() As DataTable
        Try
            conectado()
            cmd = New SqlCommand("SELECT * FROM Roles", cn)
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function validar_usuario(dts As CUsuario) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("validar_usuario", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", dts.NombreUsuario)
            cmd.Parameters.AddWithValue("@password_usuario", EncriptarBase64(dts.Contraseña))
            cmd.Parameters.AddWithValue("@cod_rol", dts.RolID)
            dr = cmd.ExecuteReader()
            Return dr.HasRows
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            dr.Close()
            desconectado()
        End Try
    End Function


    Public Function existeNombreUsuario(nombreUsuario As String) As Boolean
        Try
            conectado()
            Dim cmd As New SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario", cn)
            cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        Catch ex As Exception
            MsgBox("Error al verificar duplicado: " & ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function Login(usuario As CUsuario) As CUsuario
        Try
            conectado()
            cmd = New SqlCommand("validar_usuario", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", usuario.NombreUsuario)
            cmd.Parameters.AddWithValue("@password_usuario", EncriptarBase64(usuario.Contraseña))
            cmd.Parameters.AddWithValue("@cod_rol", usuario.RolID)

            dr = cmd.ExecuteReader()
            If dr.Read() Then
                Dim usuarioValidado As New CUsuario With {
                    .idUsuario = Convert.ToInt32(dr("idUsuario")),
                    .NombreUsuario = dr("NombreUsuario").ToString(),
                    .RolID = Convert.ToInt32(dr("RolID"))
                }
                Return usuarioValidado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Error al validar usuario: " & ex.Message)
            Return Nothing
        Finally
            dr.Close()
            desconectado()
        End Try
    End Function




End Class