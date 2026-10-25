Imports MySqlConnector

Public Class Login

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
                    "u.clavehash, u.salt, u.id_rol, r.nombre_rol as rol " &
                    "from usuarios as u " &
                    "join roles as r on u.id_rol = r.id_rol " &
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

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tema.AplicarTema(Me)
        Label3.Font = Tema.Fuente(18, FontStyle.Bold)
        MyBase.AcceptButton = btnEntrar
    End Sub
End Class