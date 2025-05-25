Imports System.Data.SqlClient

Public Class ConexionDB
    Private Shared cadena As String = "Server=DESKTOP-UE0595G\MSSQLSERVER02;Database=InvernaderoControlado;Integrated Security=True"

    Public Shared Function ObtenerConexion() As SqlConnection
        Dim conexion As New SqlConnection(cadena)
        Return conexion
    End Function
End Class