Imports Controlador

Public Class frmCategorias
    Private Sub frmCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Listar()
    End Sub

    Private Sub Listar()
        Try
            Dim neg As New NCategoria()
            dgvCategorias.DataSource = neg.Listar()
            dgvCategorias.Columns("IdCategoria").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim frm As New frmCategoriaAE()
        frm.Text = "Nueva Categoría"
        If frm.ShowDialog() = DialogResult.OK Then
            Listar()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvCategorias.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una categoría")
            Return
        End If

        Dim id As Integer = Convert.ToInt32(dgvCategorias.CurrentRow.Cells("IdCategoria").Value)
        Dim nombre As String = dgvCategorias.CurrentRow.Cells("Nombre").Value.ToString()
        Dim descripcion As String = ""

        If dgvCategorias.CurrentRow.Cells("Descripcion").Value IsNot DBNull.Value Then
            descripcion = dgvCategorias.CurrentRow.Cells("Descripcion").Value.ToString()
        End If

        Dim frm As New frmCategoriaAE()
        frm.Text = "Editar Categoría"
        frm.CargarDatos(id, nombre, descripcion)

        If frm.ShowDialog() = DialogResult.OK Then
            Listar()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvCategorias.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una categoría")
            Return
        End If

        If MsgBox("¿Está seguro de eliminar esta categoría?", vbQuestion + vbYesNo, "Confirmar") = vbNo Then
            Return
        End If

        Try
            Dim id As Integer = Convert.ToInt32(dgvCategorias.CurrentRow.Cells("IdCategoria").Value)
            Dim neg As New NCategoria()

            If neg.Eliminar(id) Then
                MsgBox("Categoría eliminada correctamente")
                Listar()
            Else
                MsgBox("No se pudo eliminar la categoría")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class