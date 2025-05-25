Imports Controlador
Public Class frmCategoriaAE
    Private idCategoria As Integer = 0

    Public Sub CargarDatos(id As Integer, nombre As String, descripcion As String)
        idCategoria = id
        txtNombre.Text = nombre
        txtDescripcion.Text = descripcion
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If String.IsNullOrEmpty(txtNombre.Text) Then
            MsgBox("Debe ingresar un nombre")
            Return
        End If

        Try
            Dim neg As New NCategoria()

            If idCategoria = 0 Then
                ' Nuevo
                If neg.Insertar(txtNombre.Text, txtDescripcion.Text) Then
                    MsgBox("Categoría registrada correctamente")
                    DialogResult = DialogResult.OK
                Else
                    MsgBox("No se pudo registrar la categoría")
                End If
            Else
                ' Editar
                If neg.Actualizar(idCategoria, txtNombre.Text, txtDescripcion.Text) Then
                    MsgBox("Categoría actualizada correctamente")
                    DialogResult = DialogResult.OK
                Else
                    MsgBox("No se pudo actualizar la categoría")
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