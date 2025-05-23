Imports Modelo
Imports Controlador

Public Class FRM_Usuario
    Dim controlador As New BDUsuario()

    Private Async Sub FRM_Usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbEliminarVarios.Checked = False
        btnEliminarSeleccionados.Visible = False

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
        Invoke(Sub() cargarRoles())

        Invoke(Sub()
                   cboCampo.Items.Clear()
                   cboCampo.Items.Add("Nombre")
                   cboCampo.Items.Add("ApellidoPaterno")
                   cboCampo.Items.Add("ApellidoMaterno")
                   cboCampo.Items.Add("NombreUsuario")
                   cboCampo.SelectedIndex = 0
               End Sub)
    End Sub

    Private Sub cargarRoles()
        cboRoles.DataSource = controlador.mostrarrol()
        cboRoles.DisplayMember = "NombreRol"
        cboRoles.ValueMember = "RolID"
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not validarCampos() Then Exit Sub

        ' ✅ Validar nombre de usuario duplicado
        If controlador.existeNombreUsuario(txtNombreUsuario.Text.Trim()) Then
            MessageBox.Show("El nombre de usuario ya existe. Por favor elige otro.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim usuario As New CUsuario With {
            .Nombre = txtNombre.Text,
            .ApellidoPaterno = txtApellidoPaterno.Text,
            .ApellidoMaterno = txtApellidoMaterno.Text,
            .NombreUsuario = txtNombreUsuario.Text,
            .Contraseña = txtContraseña.Text,
            .RolID = CInt(cboRoles.SelectedValue)
        }

        If controlador.insertar(usuario) Then
            MessageBox.Show("Usuario registrado correctamente")
            mostrar()
        Else
            MessageBox.Show("No se pudo registrar el usuario")
        End If
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not validarCampos() Then Exit Sub

        Dim usuario As New CUsuario With {
            .idUsuario = CInt(txtCodigo.Text),
            .Nombre = txtNombre.Text,
            .ApellidoPaterno = txtApellidoPaterno.Text,
            .ApellidoMaterno = txtApellidoMaterno.Text,
            .NombreUsuario = txtNombreUsuario.Text,
            .Contraseña = txtContraseña.Text,
            .RolID = CInt(cboRoles.SelectedValue)
        }

        If controlador.editar(usuario) Then
            MessageBox.Show("Usuario editado correctamente")
            mostrar()
        Else
            MessageBox.Show("Error al editar el usuario")
        End If
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtCodigo.Text <> "" Then
            Dim id = CInt(txtCodigo.Text)
            If controlador.eliminar(id) Then
                MessageBox.Show("Usuario eliminado")
                mostrar()
            Else
                MessageBox.Show("Error al eliminar usuario")
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtBuscar.Text.Trim <> "" Then
            Dim campo As String = cboCampo.SelectedItem.ToString()
            dtgListaUsuarios.DataSource = controlador.buscar(campo, txtBuscar.Text.Trim)
        Else
            mostrar()
        End If
    End Sub

    Private Sub dtgListaUsuarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgListaUsuarios.CellDoubleClick
        With dtgListaUsuarios.Rows(e.RowIndex)
            txtCodigo.Text = .Cells("idUsuario").Value.ToString()
            txtNombre.Text = .Cells("Nombre").Value.ToString()
            txtApellidoPaterno.Text = .Cells("ApellidoPaterno").Value.ToString()
            txtApellidoMaterno.Text = .Cells("ApellidoMaterno").Value.ToString()
            txtNombreUsuario.Text = .Cells("NombreUsuario").Value.ToString()
            txtContraseña.Text = .Cells("Contraseña").Value.ToString()
            cboRoles.Text = .Cells("NombreRol").Value.ToString()
        End With
        btnGuardar.Enabled = False
        btnEditar.Enabled = True
    End Sub

    Private Sub mostrar()
        dtgListaUsuarios.DataSource = controlador.mostrar()

        'Metodo para ocultar el Id y si quiero que se vea el id en la tabla solo tengo que comentarlo
        dtgListaUsuarios.Columns("idUsuario").Visible = False

        'metodo para mostrar la columna checkbox
        If Not dtgListaUsuarios.Columns.Contains("Seleccionar") Then
            Dim checkCol As New DataGridViewCheckBoxColumn()
            checkCol.Name = "Seleccionar"
            checkCol.HeaderText = "✔"
            checkCol.Width = 30
            checkCol.ReadOnly = False ' ✅ esto permite que se puedan marcar
            dtgListaUsuarios.Columns.Insert(0, checkCol)
        End If


        With dtgListaUsuarios
            .Columns("idUsuario").HeaderText = "ID"
            .Columns("Nombre").HeaderText = "Nombre"
            .Columns("ApellidoPaterno").HeaderText = "Apellido Paterno"
            .Columns("ApellidoMaterno").HeaderText = "Apellido Materno"
            .Columns("NombreUsuario").HeaderText = "Usuario"
            .Columns("Contraseña").HeaderText = "Contraseña (SHA256)"
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

        ' comentar o descomentar para ver los botones de editar y eliminar en la tabla
        agregarBotones()
    End Sub

    Private Sub agregarBotones()
        If Not dtgListaUsuarios.Columns.Contains("btnEditar") Then
            Dim btnEditar As New DataGridViewButtonColumn()
            btnEditar.Name = "btnEditar"
            btnEditar.HeaderText = "Editar"
            btnEditar.Text = "Editar"
            btnEditar.UseColumnTextForButtonValue = True
            btnEditar.Width = 60
            dtgListaUsuarios.Columns.Add(btnEditar)
        End If

        If Not dtgListaUsuarios.Columns.Contains("btnEliminar") Then
            Dim btnEliminar As New DataGridViewButtonColumn()
            btnEliminar.Name = "btnEliminar"
            btnEliminar.HeaderText = "Eliminar"
            btnEliminar.Text = "Eliminar"
            btnEliminar.UseColumnTextForButtonValue = True
            btnEliminar.Width = 70
            dtgListaUsuarios.Columns.Add(btnEliminar)
        End If
    End Sub

    Private Sub limpiar()
        txtCodigo.Text = ""
        txtNombre.Text = ""
        txtApellidoPaterno.Text = ""
        txtApellidoMaterno.Text = ""
        txtNombreUsuario.Text = ""
        txtContraseña.Text = ""
        cboRoles.SelectedIndex = 0
        txtNombre.Focus()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
    End Sub

    Private Sub dtgListaUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgListaUsuarios.CellClick
        ' Verifica que se haya hecho clic en una fila válida y no en encabezados u otras áreas
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim columna As String = dtgListaUsuarios.Columns(e.ColumnIndex).Name

        If columna = "btnEditar" Then
            With dtgListaUsuarios.Rows(e.RowIndex)
                txtCodigo.Text = .Cells("idUsuario").Value.ToString()
                txtNombre.Text = .Cells("Nombre").Value.ToString()
                txtApellidoPaterno.Text = .Cells("ApellidoPaterno").Value.ToString()
                txtApellidoMaterno.Text = .Cells("ApellidoMaterno").Value.ToString()
                txtNombreUsuario.Text = .Cells("NombreUsuario").Value.ToString()
                txtContraseña.Text = .Cells("Contraseña").Value.ToString()
                cboRoles.Text = .Cells("NombreRol").Value.ToString()
            End With
            btnEditar.Enabled = True
            btnGuardar.Enabled = False

        ElseIf columna = "btnEliminar" Then
            Dim respuesta = MessageBox.Show("¿Estás seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo)
            If respuesta = DialogResult.Yes Then
                Dim id = CInt(dtgListaUsuarios.Rows(e.RowIndex).Cells("idUsuario").Value)
                If controlador.eliminar(id) Then
                    MessageBox.Show("Usuario eliminado")
                    mostrar()
                Else
                    MessageBox.Show("Error al eliminar")
                End If
            End If
        End If
    End Sub


    Private Sub cbEliminarVarios_CheckedChanged(sender As Object, e As EventArgs) Handles cbEliminarVarios.CheckedChanged
        dtgListaUsuarios.Columns("Seleccionar").Visible = cbEliminarVarios.Checked
        btnEliminarSeleccionados.Visible = cbEliminarVarios.Checked
    End Sub

    Private Sub btnEliminarSeleccionados_Click(sender As Object, e As EventArgs) Handles btnEliminarSeleccionados.Click
        Dim seleccionados As New List(Of Integer)

        For Each fila As DataGridViewRow In dtgListaUsuarios.Rows
            If Convert.ToBoolean(fila.Cells("Seleccionar").Value) = True Then
                Dim id As Integer = CInt(fila.Cells("idUsuario").Value)
                seleccionados.Add(id)
            End If
        Next

        If seleccionados.Count = 0 Then
            MessageBox.Show("Por favor, selecciona al menos un usuario para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim confirmar = MessageBox.Show("¿Estás seguro de eliminar " & seleccionados.Count & " usuario(s)?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmar <> DialogResult.Yes Then Exit Sub

        Dim eliminados As Integer = 0
        For Each id In seleccionados
            If controlador.eliminar(id) Then
                eliminados += 1
            End If
        Next

        MessageBox.Show("Se eliminaron " & eliminados & " usuario(s).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        mostrar()
    End Sub

    ' 🔒 Solo permite letras
    Private Sub SoloLetras(e As KeyPressEventArgs)
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        SoloLetras(e)
    End Sub

    Private Sub txtApellidoPaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidoPaterno.KeyPress
        SoloLetras(e)
    End Sub

    Private Sub txtApellidoMaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidoMaterno.KeyPress
        SoloLetras(e)
    End Sub

    Private Sub txtNombreUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreUsuario.KeyPress
        SoloLetras(e)
    End Sub


    Private Function validarCampos() As Boolean
        If txtNombre.Text.Trim = "" OrElse
           txtApellidoPaterno.Text.Trim = "" OrElse
           txtApellidoMaterno.Text.Trim = "" OrElse
           txtNombreUsuario.Text.Trim = "" OrElse
           txtContraseña.Text.Trim = "" Then

            MessageBox.Show("Hay campos vacíos. Por favor, llénelos todos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class