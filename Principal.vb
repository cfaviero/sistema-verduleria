Imports System.Runtime.InteropServices
Public Class Principal

    Private formularioActual As Form = Nothing

    Sub DeshabilitarBotones()
        If TypeOf formularioActual Is frmDashboard Then
            btnInicio.Enabled = False
        Else
            btnInicio.Enabled = True
        End If

        If TypeOf formularioActual Is stock Then
            btnStock.Enabled = False
        Else
            btnStock.Enabled = True
        End If

        If TypeOf formularioActual Is Clientes Then
            btnClientes.Enabled = False
        Else
            btnClientes.Enabled = True
        End If

        If TypeOf formularioActual Is Proveedores_ABM Then
            btnProveedores.Enabled = False
        Else
            btnProveedores.Enabled = True
        End If
    End Sub

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
        Tema.AplicarTema(Me)
        Tema.MarcarActivo(btnInicio)
        EfectoVisual.AplicarTransicionHora(lblHoraActual)
        lblBienvenido.Text = "Bienvenido " + Sesion.descripcion + " - " + Sesion.rolusuario

        If Sesion.rolusuario = "administrador" Then
            btnClientes.Visible = True
        End If

        MostrarFormulario(New frmDashboard())
        btnInicio.Enabled = False
    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs)
        MostrarFormulario(New Proveedores())
        DeshabilitarBotones()
    End Sub


    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        MostrarFormulario(New stock())
        DeshabilitarBotones()
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
        DeshabilitarBotones()
    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        MostrarFormulario(New frmDashboard())
        DeshabilitarBotones()
    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        MostrarFormulario(New Proveedores_ABM())
        DeshabilitarBotones()
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        MostrarFormulario(New Usuarios())
        DeshabilitarBotones()
    End Sub

    <DllImport("user32.dll")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.dll")>
    Private Shared Sub SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2

    Private Sub pnlCabecera_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlCabecera.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub


End Class
