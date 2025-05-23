Imports Modelo
Imports Controlador

Public Class FRM_TipoPlanta
    Dim tipoPlanta As New BDTipoPlanta()
    Dim nuevoTipo As New CTipoPlanta()

    Private Sub FRM_TipoPlanta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarTipos()
        EstiloDataGridView()
        txtBuscar.Focus()
    End Sub

    Private Sub EstiloDataGridView()
        dgvTipos.BorderStyle = BorderStyle.None
        dgvTipos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgvTipos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvTipos.DefaultCellStyle.SelectionBackColor = Color.LightSeaGreen
        dgvTipos.DefaultCellStyle.SelectionForeColor = Color.White
        dgvTipos.BackgroundColor = Color.White
        dgvTipos.EnableHeadersVisualStyles = False
        dgvTipos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvTipos.ColumnHeadersDefaultCellStyle.BackColor = Color.SeaGreen
        dgvTipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    End Sub

    Private Sub MostrarTipos()
        dgvTipos.DataSource = tipoPlanta.mostrar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtNombreTipo.Text = "" Or txtDescripcion.Text = "" Then
            MessageBox.Show("Todos los campos son obligatorios.")
            Exit Sub
        End If

        If txtID.Text = "" Then
            ' Insertar
            'txtNombreTipo.Text.Trim()
            nuevoTipo.NombreTipo = txtNombreTipo.Text.Trim()
            nuevoTipo.Descripcion = txtDescripcion.Text.Trim()
            Dim resultado = tipoPlanta.insertar(nuevoTipo)
            If resultado Then
                MessageBox.Show("Tipo de planta registrado.")
                MostrarTipos()
                Limpiar()
            End If
        Else
            ' Actualizar
            nuevoTipo.NombreTipo = txtNombreTipo.Text.Trim()
            nuevoTipo.Descripcion = txtDescripcion.Text.Trim()
            nuevoTipo.TipoID = CInt(txtID.Text)
            Dim resultado = tipoPlanta.editar(nuevoTipo)
            If resultado Then
                MessageBox.Show("Tipo de planta actualizado.")
                MostrarTipos()
                Limpiar()
            End If
        End If
    End Sub

    Private Sub dgvTipos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTipos.CellClick
        If e.RowIndex >= 0 Then
            txtID.Text = dgvTipos.Rows(e.RowIndex).Cells("TipoID").Value.ToString()
            txtNombreTipo.Text = dgvTipos.Rows(e.RowIndex).Cells("NombreTipo").Value.ToString()
            txtDescripcion.Text = dgvTipos.Rows(e.RowIndex).Cells("Descripcion").Value.ToString()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvTipos.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona al menos una fila para eliminar.")
            Exit Sub
        End If

        If MessageBox.Show("¿Eliminar tipo(s) seleccionado(s)?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            For Each fila As DataGridViewRow In dgvTipos.SelectedRows
                Dim id As Integer = CInt(fila.Cells("TipoID").Value)
                tipoPlanta.eliminar(id)
            Next
            MostrarTipos()
            Limpiar()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        'dgvTipos.DataSource = tipoPlanta.BuscarTipos(txtBuscar.Text.Trim())
    End Sub

    Private Sub Limpiar()
        txtID.Clear()
        txtNombreTipo.Clear()
        txtDescripcion.Clear()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
End Class

