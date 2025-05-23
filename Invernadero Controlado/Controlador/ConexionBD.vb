Imports System.Data.SqlClient
Public Class ConexionBD
    Protected cn As New SqlConnection
    Public idusuario As Integer
    Public Function conectado()
        Try
            cn = New SqlConnection("Data Source=DESKTOP-UE0595G\MSSQLSERVER02;Initial Catalog=InvernaderoControlado;Integrated Security=True")
            cn.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function desconectado()
        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
                Return False
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
