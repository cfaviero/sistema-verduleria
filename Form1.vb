Public Class Form1

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If (Control.ModifierKeys And (Keys.Control Or Keys.Shift)) = (Keys.Control Or Keys.Shift) Then

            Caja.Show()

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EfectoVisual.AplicarTransicionHora(lblHoraActual)
    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs)
        Proveedores.ShowDialog
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Clientes.ShowDialog()
    End Sub

    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        stock.ShowDialog()
    End Sub
End Class
