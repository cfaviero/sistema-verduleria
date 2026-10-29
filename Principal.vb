Imports System.Runtime.InteropServices
Public Class Principal

    Private formularioActual As Form = Nothing
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2
    '# PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ##

    'Desabilita botones dependiendo donde se este
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

        If TypeOf formularioActual Is Caja Then
            btnCaja.Enabled = False
        Else
            btnCaja.Enabled = True
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

    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^

    '# EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ##
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Verifica admin
        Dim esadmin As Boolean = Sesion.EsAdministrador
        'Agrega tema
        Tema.AplicarTema(Me)

        MostrarFormulario(New frmDashboard())
        'Validaciones
        btnInicio.Enabled = False
        btnClientes.Visible = esadmin
        btnProveedores.Visible = esadmin
        btnUsuarios.Visible = esadmin
    End Sub
    '# EVENTOS CLICK BARRA ## 
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
        'Limpio campos
        Login.txtUsuario.Clear()
        Login.txtContra.Clear()
        'Enfoco en usuario
        Login.txtUsuario.Focus()
        Me.Close()
    End Sub
    Private Sub btnClientes_Click_1(sender As Object, e As EventArgs) Handles btnClientes.Click
        'Valido usuario por las dudas
        If Not Sesion.EsAdministrador() Then
            MessageBox.Show("No tiene los permisos para acceder",
                    "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        MostrarFormulario(New Clientes)
        DeshabilitarBotones()
    End Sub
    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        MostrarFormulario(New frmDashboard())
        DeshabilitarBotones()
    End Sub
    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        'Valido usuario por las dudas
        If Not Sesion.EsAdministrador() Then
            MessageBox.Show("No tiene los permisos para acceder",
                    "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        MostrarFormulario(New Proveedores_ABM())
        DeshabilitarBotones()
    End Sub
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        'Valido usuario por las dudas
        If Not Sesion.EsAdministrador() Then
            MessageBox.Show("No tiene los permisos para acceder",
                    "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        MostrarFormulario(New Usuarios())
        DeshabilitarBotones()
    End Sub
    Private Sub btnCaja_Click(sender As Object, e As EventArgs) Handles btnCaja.Click
        MostrarFormulario(New Caja())
        DeshabilitarBotones()
    End Sub
    'Evento para manipulacion del form con click izquierdo
    Private Sub pnlCabecera_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlCabecera.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub
    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^

    'Control para manipular la ventana con libreria nativa de windos
    <DllImport("user32.dll")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.dll")>
    Private Shared Sub SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer)
    End Sub
End Class
