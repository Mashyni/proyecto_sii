Imports Controlador

Public Class frmClientes
    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Listar()
    End Sub

    Private Sub Listar()
        Try
            Dim neg As New NCliente()
            dgvClientes.DataSource = neg.Listar()
            dgvClientes.Columns("IdCliente").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim frm As New frmClienteAE()
        frm.Text = "Nuevo Cliente"
        If frm.ShowDialog() = DialogResult.OK Then
            Listar()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvClientes.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un cliente")
            Return
        End If

        Dim id As Integer = Convert.ToInt32(dgvClientes.CurrentRow.Cells("IdCliente").Value)
        Dim nombre As String = dgvClientes.CurrentRow.Cells("Nombre").Value.ToString()
        Dim apellido As String = dgvClientes.CurrentRow.Cells("Apellido").Value.ToString()
        Dim direccion As String = ""
        Dim telefono As String = ""
        Dim email As String = ""

        If dgvClientes.CurrentRow.Cells("Direccion").Value IsNot DBNull.Value Then
            direccion = dgvClientes.CurrentRow.Cells("Direccion").Value.ToString()
        End If

        If dgvClientes.CurrentRow.Cells("Telefono").Value IsNot DBNull.Value Then
            telefono = dgvClientes.CurrentRow.Cells("Telefono").Value.ToString()
        End If

        If dgvClientes.CurrentRow.Cells("Email").Value IsNot DBNull.Value Then
            email = dgvClientes.CurrentRow.Cells("Email").Value.ToString()
        End If

        Dim frm As New frmClienteAE()
        frm.Text = "Editar Cliente"
        frm.CargarDatos(id, nombre, apellido, direccion, telefono, email)

        If frm.ShowDialog() = DialogResult.OK Then
            Listar()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvClientes.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un cliente")
            Return
        End If

        If MsgBox("¿Está seguro de eliminar este cliente?", vbQuestion + vbYesNo, "Confirmar") = vbNo Then
            Return
        End If

        Try
            Dim id As Integer = Convert.ToInt32(dgvClientes.CurrentRow.Cells("IdCliente").Value)
            Dim neg As New NCliente()

            If neg.Eliminar(id) Then
                MsgBox("Cliente eliminado correctamente")
                Listar()
            Else
                MsgBox("No se pudo eliminar el cliente")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class