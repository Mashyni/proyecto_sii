Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Public Class DVenta
    Public Function Insertar(idCliente As Integer, total As Decimal, detalles As DataTable) As Integer
        Dim idVenta As Integer = 0

        ' Validar parámetros de entrada
        If idCliente <= 0 Or total <= 0 Or detalles Is Nothing Or detalles.Rows.Count = 0 Then
            Debug.WriteLine("Error: Parámetros de entrada inválidos")
            Return 0
        End If

        ' Generar XML de detalles
        Dim xmlDetalles As String = GenerarXmlDetalles(detalles)
        If String.IsNullOrEmpty(xmlDetalles) Then
            Debug.WriteLine("Error: XML de detalles inválido")
            Return 0
        End If

        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            Try
                conexion.Open()

                Using cmd As New SqlCommand("sp_InsertarVenta", conexion)
                    cmd.CommandType = CommandType.StoredProcedure

                    ' Agregar parámetros con tipos de datos explícitos
                    cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = total
                    cmd.Parameters.Add("@Detalles", SqlDbType.Xml).Value = xmlDetalles

                    ' Agregar parámetro de salida para el ID
                    Dim paramIdVenta As New SqlParameter("@IdVenta", SqlDbType.Int)
                    paramIdVenta.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(paramIdVenta)

                    ' Ejecutar y obtener resultado
                    cmd.ExecuteNonQuery()

                    ' Obtener el ID de la venta
                    If Not Integer.TryParse(paramIdVenta.Value.ToString(), idVenta) Then
                        Debug.WriteLine("Error: No se recibió un ID válido")
                        Return 0
                    End If

                    Return idVenta
                End Using

            Catch sqlEx As SqlException
                ' Manejo específico de errores SQL
                Debug.WriteLine("Error SQL:")
                Debug.WriteLine($"Número: {sqlEx.Number}")
                Debug.WriteLine($"Mensaje: {sqlEx.Message}")
                Debug.WriteLine($"Procedimiento: {sqlEx.Procedure}")
                Debug.WriteLine($"Línea: {sqlEx.LineNumber}")
                Debug.WriteLine("Detalles completos:")
                Debug.WriteLine(sqlEx.ToString())
                Return 0

            Catch ex As Exception
                ' Manejo de otros errores
                Debug.WriteLine("Error general:")
                Debug.WriteLine(ex.ToString())
                Return 0
            End Try
        End Using
    End Function

    Private Function GenerarXmlDetalles(detalles As DataTable) As String
        Try
            Dim xmlDetalles As New XmlDocument()
            Dim root As XmlElement = xmlDetalles.CreateElement("Detalles")

            For Each row As DataRow In detalles.Rows
                ' Validar y formatear valores numéricos
                Dim idPlanta As Integer = Convert.ToInt32(row("IdPlanta"))
                Dim cantidad As Integer = Convert.ToInt32(row("Cantidad"))
                Dim precioUnitario As Decimal = Convert.ToDecimal(row("PrecioUnitario"))
                Dim subtotal As Decimal = Convert.ToDecimal(row("Subtotal"))

                ' Usar formato invariante para decimales
                Dim detalle As XmlElement = xmlDetalles.CreateElement("Detalle")
                detalle.SetAttribute("IdPlanta", idPlanta.ToString())
                detalle.SetAttribute("Cantidad", cantidad.ToString())
                detalle.SetAttribute("PrecioUnitario", precioUnitario.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))
                detalle.SetAttribute("Subtotal", subtotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))
                root.AppendChild(detalle)
            Next

            xmlDetalles.AppendChild(root)
            Return xmlDetalles.OuterXml

        Catch ex As Exception
            Debug.WriteLine($"Error al generar XML: {ex.ToString()}")
            Return String.Empty
        End Try
    End Function

    Public Function Listar() As DataTable
        Dim dt As New DataTable
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            conexion.Open()
            Using cmd As New SqlCommand("sp_ListarVentas", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function ObtenerDetalle(idVenta As Integer) As DataTable
        Dim dt As New DataTable
        Using conexion As SqlConnection = ConexionDB.ObtenerConexion()
            conexion.Open()
            Using cmd As New SqlCommand("sp_ObtenerDetalleVenta", conexion)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IdVenta", idVenta)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
End Class