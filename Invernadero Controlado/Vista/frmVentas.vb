Imports Controlador

Public Class frmVentas
    Private dtDetalle As New DataTable()
    Private total As Decimal = 0

    Private Sub frmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()
        CargarPlantas()
        ConfigurarDataGridView()
        CrearTablaDetalle()
    End Sub

    Private Sub CargarClientes()
        Try
            Dim neg As New NCliente()
            cboCliente.DataSource = neg.Listar()
            cboCliente.DisplayMember = "Nombre"
            cboCliente.ValueMember = "IdCliente"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarPlantas()
        Try
            Dim neg As New NPlanta()
            cboPlanta.DataSource = neg.Listar()
            cboPlanta.DisplayMember = "Nombre"
            cboPlanta.ValueMember = "IdPlanta"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ConfigurarDataGridView()
        dgvDetalle.AutoGenerateColumns = False
        dgvDetalle.AllowUserToAddRows = False

        ' Configurar columnas
        Dim colId As New DataGridViewTextBoxColumn()
        colId.DataPropertyName = "IdPlanta"
        colId.HeaderText = "ID"
        colId.Visible = False
        dgvDetalle.Columns.Add(colId)

        Dim colNombre As New DataGridViewTextBoxColumn()
        colNombre.DataPropertyName = "Planta"
        colNombre.HeaderText = "Planta"
        colNombre.Width = 200
        dgvDetalle.Columns.Add(colNombre)

        Dim colPrecio As New DataGridViewTextBoxColumn()
        colPrecio.DataPropertyName = "PrecioUnitario"
        colPrecio.HeaderText = "Precio Unitario"
        colPrecio.DefaultCellStyle.Format = "C2"
        dgvDetalle.Columns.Add(colPrecio)

        Dim colCantidad As New DataGridViewTextBoxColumn()
        colCantidad.DataPropertyName = "Cantidad"
        colCantidad.HeaderText = "Cantidad"
        dgvDetalle.Columns.Add(colCantidad)

        Dim colSubtotal As New DataGridViewTextBoxColumn()
        colSubtotal.DataPropertyName = "Subtotal"
        colSubtotal.HeaderText = "Subtotal"
        colSubtotal.DefaultCellStyle.Format = "C2"
        dgvDetalle.Columns.Add(colSubtotal)
    End Sub

    Private Sub CrearTablaDetalle()
        dtDetalle = New DataTable()
        dtDetalle.Columns.Add("IdPlanta", GetType(Integer))
        dtDetalle.Columns.Add("Planta", GetType(String))
        dtDetalle.Columns.Add("PrecioUnitario", GetType(Decimal))
        dtDetalle.Columns.Add("Cantidad", GetType(Integer))
        dtDetalle.Columns.Add("Subtotal", GetType(Decimal))
    End Sub

    Private Sub cboPlanta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPlanta.SelectedIndexChanged
        If cboPlanta.SelectedIndex <> -1 Then
            Dim row As DataRowView = CType(cboPlanta.SelectedItem, DataRowView)
            txtPrecio.Text = Convert.ToDecimal(row("Precio")).ToString("0.00")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cboPlanta.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una planta")
            Return
        End If

        Dim cantidad As Integer
        If Not Integer.TryParse(txtCantidad.Text, cantidad) Or cantidad <= 0 Then
            MsgBox("Debe ingresar una cantidad válida")
            Return
        End If

        Dim precio As Decimal = Convert.ToDecimal(txtPrecio.Text)
        Dim subtotal As Decimal = cantidad * precio

        Dim row As DataRowView = CType(cboPlanta.SelectedItem, DataRowView)
        Dim idPlanta As Integer = Convert.ToInt32(row("IdPlanta"))
        Dim nombrePlanta As String = row("Nombre").ToString()

        ' Verificar si ya existe en el detalle
        For Each dr As DataRow In dtDetalle.Rows
            If dr("IdPlanta") = idPlanta Then
                ' Actualizar cantidad y subtotal
                dr("Cantidad") = Convert.ToInt32(dr("Cantidad")) + cantidad
                dr("Subtotal") = Convert.ToDecimal(dr("Subtotal")) + subtotal
                ActualizarTotal()
                dgvDetalle.DataSource = dtDetalle
                LimpiarDetalle()
                Return
            End If
        Next

        ' Agregar nuevo detalle
        dtDetalle.Rows.Add(idPlanta, nombrePlanta, precio, cantidad, subtotal)
        ActualizarTotal()
        dgvDetalle.DataSource = dtDetalle
        LimpiarDetalle()
    End Sub

    Private Sub ActualizarTotal()
        total = 0
        For Each row As DataRow In dtDetalle.Rows
            total += Convert.ToDecimal(row("Subtotal"))
        Next
        txtTotal.Text = total.ToString("0.00")
    End Sub

    Private Sub LimpiarDetalle()
        txtCantidad.Text = "1"
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        If dgvDetalle.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item para quitar")
            Return
        End If

        Dim index As Integer = dgvDetalle.CurrentRow.Index
        dtDetalle.Rows.RemoveAt(index)
        ActualizarTotal()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cboCliente.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un cliente", MsgBoxStyle.Exclamation)
            Return
        End If

        If dtDetalle.Rows.Count = 0 Then
            MsgBox("Debe agregar al menos una planta a la venta", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            Dim idCliente As Integer = Convert.ToInt32(cboCliente.SelectedValue)
            Dim neg As New NVenta()

            ' Verificar stock antes de proceder
            If Not VerificarStockDisponible() Then
                MsgBox("No hay suficiente stock para algunos productos", MsgBoxStyle.Exclamation)
                Return
            End If

            Dim idVenta As Integer = neg.Insertar(idCliente, total, dtDetalle)

            If idVenta > 0 Then
                MsgBox($"Venta registrada correctamente. N° Venta: {idVenta}", MsgBoxStyle.Information)
                LimpiarFormulario()
            Else
                MsgBox("No se pudo registrar la venta. Verifique los datos e intente nuevamente.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox($"Error al registrar la venta: {ex.Message}", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function VerificarStockDisponible() As Boolean
        Try
            Dim negPlanta As New NPlanta()

            For Each row As DataRow In dtDetalle.Rows
                Dim idPlanta As Integer = Convert.ToInt32(row("IdPlanta"))
                Dim cantidad As Integer = Convert.ToInt32(row("Cantidad"))

                Dim dtPlanta As DataTable = negPlanta.BuscarPorId(idPlanta)
                If dtPlanta.Rows.Count = 0 Then
                    MsgBox($"No se encontró la planta con ID: {idPlanta}", MsgBoxStyle.Exclamation)
                    Return False
                End If

                Dim stockActual As Integer = Convert.ToInt32(dtPlanta.Rows(0)("Stock"))
                If stockActual < cantidad Then
                    MsgBox($"No hay suficiente stock para {row("Planta")}. Stock actual: {stockActual}", MsgBoxStyle.Exclamation)
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox($"Error al verificar stock: {ex.Message}", MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Private Sub LimpiarFormulario()
        dtDetalle.Rows.Clear()
        total = 0
        txtTotal.Text = "0.00"
        cboCliente.SelectedIndex = 0
        cboPlanta.SelectedIndex = 0
        txtCantidad.Text = "1"
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
    End Sub
End Class