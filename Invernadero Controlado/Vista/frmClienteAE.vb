Imports Controlador

Public Class frmClienteAE
    Private idCliente As Integer = 0

    Public Sub CargarDatos(id As Integer, nombre As String, apellido As String,
                          direccion As String, telefono As String, email As String)
        idCliente = id
        txtNombre.Text = nombre
        txtApellido.Text = apellido
        txtDireccion.Text = direccion
        txtTelefono.Text = telefono
        txtEmail.Text = email
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If String.IsNullOrEmpty(txtNombre.Text) Or String.IsNullOrEmpty(txtApellido.Text) Then
            MsgBox("Debe ingresar nombre y apellido")
            Return
        End If

        Try
            Dim neg As New NCliente()

            If idCliente = 0 Then
                ' Nuevo cliente
                If neg.Insertar(txtNombre.Text, txtApellido.Text, txtDireccion.Text,
                               txtTelefono.Text, txtEmail.Text) Then
                    MsgBox("Cliente registrado correctamente")
                    DialogResult = DialogResult.OK
                Else
                    MsgBox("No se pudo registrar el cliente")
                End If
            Else
                ' Editar cliente
                If neg.Actualizar(idCliente, txtNombre.Text, txtApellido.Text,
                                 txtDireccion.Text, txtTelefono.Text, txtEmail.Text) Then
                    MsgBox("Cliente actualizado correctamente")
                    DialogResult = DialogResult.OK
                Else
                    MsgBox("No se pudo actualizar el cliente")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class