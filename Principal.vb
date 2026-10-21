Public Class Principal

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If (Control.ModifierKeys And (Keys.Control Or Keys.Shift)) = (Keys.Control Or Keys.Shift) Then

            Caja.Show()

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EfectoVisual.AplicarTransicionHora(lblHoraActual)
        lblBienvenido.Text = "Bienvenido " + Sesion.descripcion + " - " + Sesion.rolusuario

        If Sesion.rolusuario = "administrador" Then
            btnClientes.Visible = True
        End If
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim result As DialogResult = MessageBox.Show("Seguro que desea salir de la aplicación?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        Sesion.CerrarSession()
        Login.Show()
        Me.Close()
    End Sub
End Class
