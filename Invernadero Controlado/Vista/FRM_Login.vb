Imports Modelo
Imports Controlador

Imports System.Security.Cryptography
Imports System.Text


Public Class FRM_Login

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

        Dim usuarioBD As New BDUsuario()
        Dim dtRoles As DataTable = usuarioBD.mostrarrol()

        cboRoles.DataSource = dtRoles
        cboRoles.DisplayMember = "NombreRol"
        cboRoles.ValueMember = "RolID"
        cboRoles.SelectedIndex = -1
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            lbltime.Text = Format(Now, "hh:mm:ss")
            lbldate.Text = Format(Now, "dd , MMM yyyy")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        If txtNombreUsuario.Text.Trim = "" OrElse txtContraseña.Text.Trim = "" OrElse cboRoles.SelectedIndex = -1 Then
            MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim usuarioIngresado As String = txtNombreUsuario.Text.Trim()
        Dim passwordPlano As String = txtContraseña.Text.Trim()
        Dim rolID As Integer = Convert.ToInt32(cboRoles.SelectedValue)

        Dim usuarioBD As New BDUsuario()
        Dim user As New CUsuario With {
            .NombreUsuario = usuarioIngresado,
            .Contraseña = passwordPlano,
            .RolID = rolID
        }

        If usuarioBD.validar_usuario(user) Then
            Dim saludo As String = "Bienvenido "

            Select Case rolID
                Case 1
                    saludo &= "Administrador"
                    MessageBox.Show(saludo, "Acceso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim frm As New FRM_Principal()
                    frm.Show()
                Case 2
                    saludo &= "Supervisor"
                    MessageBox.Show(saludo, "Acceso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim frm As New FRM_Super()
                    frm.Show()
                Case 3
                    saludo &= "Trabajador"
                    MessageBox.Show(saludo, "Acceso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim frm As New FRM_Trabaj()
                    frm.Show()
            End Select

            Me.Hide()
        Else
            MessageBox.Show("❌ Usuario, contraseña o rol incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub




    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtNombreUsuario.Clear()
        txtContraseña.Clear()
        cboRoles.SelectedIndex = -1
        txtNombreUsuario.Focus()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub SoloLetras(e As KeyPressEventArgs)
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreUsuario.KeyPress
        SoloLetras(e)
    End Sub


End Class
