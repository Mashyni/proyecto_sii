
Public Class frmPrincipal
    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        Dim frm As New frmCategorias()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PlantasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlantasToolStripMenuItem.Click
        Dim frm As New frmPlantas()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim frm As New frmClientes()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        Dim frm As New frmVentas()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItem.Click
        'Dim frm As New frmReportes()
        'frm.MdiParent = Me
        'frm.Show()
    End Sub
End Class