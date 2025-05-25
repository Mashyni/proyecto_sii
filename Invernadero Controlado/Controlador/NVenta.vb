Imports Modelo

Public Class NVenta
    Private dventa As New DVenta()

    Public Function Insertar(idCliente As Integer, total As Decimal, detalles As DataTable) As Integer
        'If idCliente <= 0 Or total <= 0 Or detalles Is Nothing Or detalles.Rows.Count = 0 Then
        '    Return 0
        'End If

        ' Validar datos antes de procesar
        If Not ValidarDatosVenta(idCliente, total, detalles) Then
            Return 0
        End If

        Try
            Return dventa.Insertar(idCliente, total, detalles)
        Catch ex As Exception
            ' Registrar el error en un log
            System.Diagnostics.Debug.WriteLine($"Error NVenta.Insertar: {ex.Message}")
            Return 0
        End Try
    End Function

    Private Function ValidarDatosVenta(idCliente As Integer, total As Decimal, detalles As DataTable) As Boolean
        Try
            ' Validar cliente
            If idCliente <= 0 Then Return False

            ' Validar total
            If total <= 0 Then Return False

            ' Validar detalles
            If detalles Is Nothing OrElse detalles.Rows.Count = 0 Then Return False

            For Each row As DataRow In detalles.Rows
                ' Verificar que todos los campos numéricos sean válidos
                If Not Integer.TryParse(row("IdPlanta").ToString(), Nothing) OrElse
               Not Integer.TryParse(row("Cantidad").ToString(), Nothing) OrElse
               Not Decimal.TryParse(row("PrecioUnitario").ToString(), Nothing) OrElse
               Not Decimal.TryParse(row("Subtotal").ToString(), Nothing) Then
                    Return False
                End If

                ' Verificar que los valores sean positivos
                If Convert.ToInt32(row("Cantidad")) <= 0 OrElse
               Convert.ToDecimal(row("PrecioUnitario")) <= 0 OrElse
               Convert.ToDecimal(row("Subtotal")) <= 0 Then
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            Debug.WriteLine("Error en validación: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function Listar() As DataTable
        Return dventa.Listar()
    End Function

    Public Function ObtenerDetalle(idVenta As Integer) As DataTable
        If idVenta <= 0 Then
            Return Nothing
        End If
        Return dventa.ObtenerDetalle(idVenta)
    End Function
End Class