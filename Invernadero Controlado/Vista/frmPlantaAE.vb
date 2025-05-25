Imports Controlador

Public Class frmPlantaAE
    Private idPlanta As Integer = 0
    Private categorias As DataTable

    Public Sub CargarDatos(id As Integer, nombre As String, idCategoria As Integer,
                          categoria As String, precio As Decimal, stock As Integer,
                          descripcion As String)
        idPlanta = id
        txtNombre.Text = nombre
        txtPrecio.Text = precio.ToString("0.00")
        txtStock.Text = stock.ToString()
        txtDescripcion.Text = descripcion

        ' Seleccionar la categoría
        For i As Integer = 0 To cboCategoria.Items.Count - 1
            Dim row As DataRowView = CType(cboCategoria.Items(i), DataRowView)
            If row("IdCategoria").ToString() = idCategoria.ToString() Then
                cboCategoria.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub frmPlantaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCategorias()
    End Sub

    Private Sub CargarCategorias()
        Try
            Dim neg As New NCategoria()
            categorias = neg.Listar()
            cboCategoria.DataSource = categorias
            cboCategoria.DisplayMember = "Nombre"
            cboCategoria.ValueMember = "IdCategoria"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If String.IsNullOrEmpty(txtNombre.Text) Then
            MsgBox("Debe ingresar un nombre")
            Return
        End If

        If cboCategoria.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una categoría")
            Return
        End If

        Dim precio As Decimal
        If Not Decimal.TryParse(txtPrecio.Text, precio) Or precio <= 0 Then
            MsgBox("Debe ingresar un precio válido")
            Return
        End If

        Dim stock As Integer
        If Not Integer.TryParse(txtStock.Text, stock) Or stock < 0 Then
            MsgBox("Debe ingresar un stock válido")
            Return
        End If

        Try
            Dim neg As New NPlanta()
            Dim idCategoria As Integer = Convert.ToInt32(cboCategoria.SelectedValue)

            If idPlanta = 0 Then
                ' Nuevo
                If neg.Insertar(txtNombre.Text, idCategoria, precio, stock, txtDescripcion.Text) Then
                    MsgBox("Planta registrada correctamente")
                    DialogResult = DialogResult.OK
                Else
                    MsgBox("No se pudo registrar la planta")
                End If
            Else
                ' Editar
                If neg.Actualizar(idPlanta, txtNombre.Text, idCategoria, precio, stock, txtDescripcion.Text) Then
                    MsgBox("Planta actualizada correctamente")
                    DialogResult = DialogResult.OK
                Else
                    MsgBox("No se pudo actualizar la planta")
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