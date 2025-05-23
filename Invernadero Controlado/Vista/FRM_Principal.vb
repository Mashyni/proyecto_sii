Public Class FRM_Principal

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            lbltime.Text = Format(Now, "hh:mm:ss")
            lbldate.Text = Format(Now, "dd , MMM yyyy")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub btnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
    'Dim formUsuario As New FRM_Usuario()
    '   formUsuario.StartPosition = FormStartPosition.CenterParent ' centra respecto al principal
    '  formUsuario.Show() ' No bloquea el principal
    'End Sub

    Private Sub btnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
        Dim formUsuario As New FRM_Usuario()
        formUsuario.Size = New Size(1400, 500)
        formUsuario.StartPosition = FormStartPosition.CenterParent
        formUsuario.ShowDialog(Me) ' ✅ Modal, bloquea el principal
    End Sub



    Private Sub btnPlantas_Click(sender As Object, e As EventArgs) Handles btnPlantas.Click

    End Sub

    Private Sub btnControlInvernadero_Click(sender As Object, e As EventArgs) Handles btnControlInvernadero.Click
        Dim formUsuario As New FRM_Control()
        formUsuario.Size = New Size(1400, 700)
        formUsuario.StartPosition = FormStartPosition.CenterParent
        formUsuario.ShowDialog(Me) ' ✅ Modal, bloquea el principal
    End Sub

    Private Sub btnControlAsistencia_Click(sender As Object, e As EventArgs) Handles btnControlAsistencia.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim loginForm As New FRM_Login()
        loginForm.Show()
        Me.Hide() ' Opcional: ocultar el formulario actual si es necesario
    End Sub

End Class