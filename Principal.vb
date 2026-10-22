Public Class Principal



    Private formularioActual As Form = Nothing

    Private Sub MostrarFormulario(formulario As Form)

        If formularioActual IsNot Nothing Then
            pnlContenido.Controls.Remove(formularioActual)
            formularioActual.Dispose()
        End If

        formularioActual = formulario

        formulario.TopLevel = False
        formulario.FormBorderStyle = FormBorderStyle.None
        formulario.Dock = DockStyle.Fill

        pnlContenido.Controls.Add(formulario)
        formulario.Show()
        formulario.BringToFront()

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
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

        MostrarFormulario(New FrmDashboard())

    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs)
        MostrarFormulario(New Proveedores())
    End Sub


    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        MostrarFormulario(New stock())
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

    Private Sub btnClientes_Click_1(sender As Object, e As EventArgs) Handles btnClientes.Click
        MostrarFormulario(New Clientes)

    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        MostrarFormulario(New FrmDashboard())
    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        MostrarFormulario(New Proveedores_ABM())
    End Sub
End Class
