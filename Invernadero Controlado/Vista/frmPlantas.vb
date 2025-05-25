Imports Controlador

Public Class frmPlantas
    Private Sub frmPlantas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Listar()
    End Sub

    Private Sub Listar()
        Try
            Dim neg As New NPlanta()
            dgvPlantas.DataSource = neg.Listar()
            dgvPlantas.Columns("IdPlanta").Visible = False
            dgvPlantas.Columns("IdCategoria").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim frm As New frmPlantaAE()
        frm.Text = "Nueva Planta"
        If frm.ShowDialog() = DialogResult.OK Then
            Listar()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvPlantas.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una planta")
            Return
        End If

        Dim id As Integer = Convert.ToInt32(dgvPlantas.CurrentRow.Cells("IdPlanta").Value)
        Dim nombre As String = dgvPlantas.CurrentRow.Cells("Nombre").Value.ToString()
        Dim idCategoria As Integer = Convert.ToInt32(dgvPlantas.CurrentRow.Cells("IdCategoria").Value)
        Dim categoria As String = dgvPlantas.CurrentRow.Cells("Categoria").Value.ToString()
        Dim precio As Decimal = Convert.ToDecimal(dgvPlantas.CurrentRow.Cells("Precio").Value)
        Dim stock As Integer = Convert.ToInt32(dgvPlantas.CurrentRow.Cells("Stock").Value)
        Dim descripcion As String = ""

        If dgvPlantas.CurrentRow.Cells("Descripcion").Value IsNot DBNull.Value Then
            descripcion = dgvPlantas.CurrentRow.Cells("Descripcion").Value.ToString()
        End If

        Dim frm As New frmPlantaAE()
        frm.Text = "Editar Planta"
        frm.CargarDatos(id, nombre, idCategoria, categoria, precio, stock, descripcion)

        If frm.ShowDialog() = DialogResult.OK Then
            Listar()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvPlantas.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una planta")
            Return
        End If

        If MsgBox("¿Está seguro de eliminar esta planta?", vbQuestion + vbYesNo, "Confirmar") = vbNo Then
            Return
        End If

        Try
            Dim id As Integer = Convert.ToInt32(dgvPlantas.CurrentRow.Cells("IdPlanta").Value)
            Dim neg As New NPlanta()

            If neg.Eliminar(id) Then
                MsgBox("Planta eliminada correctamente")
                Listar()
            Else
                MsgBox("No se pudo eliminar la planta")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class