Imports System.Runtime.InteropServices
Imports MySqlConnector

Public Class Login

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2
    '# EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ##
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Aplicacion del tema
        Tema.AplicarTema(Me)
        'Cambio el tamano del titulo del label
        Label3.Font = Tema.Fuente(18, FontStyle.Bold)
        'Click en entrar al presionar enter
        MyBase.AcceptButton = btnEntrar
    End Sub
    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        'Valido los campos completos
        If txtUsuario.Text = "" OrElse txtContra.Text = "" Then
            MessageBox.Show("Por favor, completar los campos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Vuelve a enfocarse en el textbox usuarios
            txtUsuario.Focus()
            Exit Sub
        End If

        Try
            Using cn As New MySqlConnection(ConnectionString)
                'abre la conexxion
                cn.Open()
                'query
                Dim sql As String = "select u.id_usuario, u.usuario, u.descripcion, " &
                    "u.clavehash, u.salt, u.id_rol, r.nombre_rol as rol, e.id_empleado " &
                    "from usuarios as u " &
                    "join roles as r on u.id_rol = r.id_rol " &
                    "left join empleados as e on e.id_usuario = u.id_usuario and e.activo = true " &
                    "where u.usuario = @usuario and u.activo = true;"

                Using cmd As New MySqlCommand(sql, cn)
                    'trae usuario
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim())

                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        If Not rd.Read Then
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        'lee el hash y salt en la bd
                        Dim hashBD As String = rd("clavehash").ToString()
                        Dim saltBD As String = rd("salt").ToString()

                        Dim hashIngresado As String = Seguridad.CrearHash(txtContra.Text.Trim(), saltBD)

                        If hashIngresado <> hashBD Then
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        Sesion.idusuario = Convert.ToInt32(rd("id_usuario"))
                        Sesion.idEmpleado = Convert.ToInt32(rd("id_empleado"))
                        Sesion.nombreusuario = rd("usuario").ToString()
                        Sesion.rolusuario = rd("rol").ToString()
                        Sesion.descripcion = rd("descripcion").ToString()

                        Principal.Show()
                        Me.Hide()
                    End Using
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al intentar iniciar sesión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCerrrar_Click(sender As Object, e As EventArgs) Handles btnCerrrar.Click
        'Cierra aplicacion
        Application.Exit()
    End Sub
    'Evento para manipulacion de ventana con click izquierdo
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