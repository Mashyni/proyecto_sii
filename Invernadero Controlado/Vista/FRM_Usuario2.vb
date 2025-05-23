Imports Modelo
Imports Controlador

Public Class FRM_Usuario2
    Dim controlador As New BDUsuario()

    Private Async Sub FRM_Usuario2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor
            Me.UseWaitCursor = True

            Await Task.Run(Sub()
                               cargarDatos()
                           End Sub)

        Catch ex As Exception
            MessageBox.Show("Error al cargar el formulario: " & ex.Message)
        Finally
            Cursor = Cursors.Default
            Me.UseWaitCursor = False
            Application.UseWaitCursor = False
        End Try
    End Sub

    Private Sub cargarDatos()
        Invoke(Sub() mostrar())
        Invoke(Sub()
                   cboCampo.Items.Clear()
                   cboCampo.Items.Add("Nombre")
                   cboCampo.Items.Add("ApellidoPaterno")
                   cboCampo.Items.Add("ApellidoMaterno")
                   cboCampo.Items.Add("NombreUsuario")
                   cboCampo.SelectedIndex = 0
               End Sub)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtBuscar.Text.Trim <> "" Then
            Dim campo As String = cboCampo.SelectedItem.ToString()
            dtgListaUsuarios.DataSource = controlador.buscar(campo, txtBuscar.Text.Trim)
        Else
            mostrar()
        End If
    End Sub

    Private Sub mostrar()
        dtgListaUsuarios.DataSource = controlador.mostrar()

        ' Ocultar columna ID si no quieres mostrarla
        dtgListaUsuarios.Columns("idUsuario").Visible = False

        With dtgListaUsuarios
            .Columns("Nombre").HeaderText = "Nombre"
            .Columns("ApellidoPaterno").HeaderText = "Apellido Paterno"
            .Columns("ApellidoMaterno").HeaderText = "Apellido Materno"
            .Columns("NombreUsuario").HeaderText = "Usuario"
            .Columns("Contraseña").HeaderText = "Contraseña"
            .Columns("NombreRol").HeaderText = "Rol"

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black

            .BorderStyle = BorderStyle.FixedSingle
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            .GridColor = Color.LightGray
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class