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
                cn.Open()
                Dim sql As String = "select u.idusuario, u.nombreusuario, u.nombrecompleto, " &
                    "u.clavehash, u.salt, u.idrol, rol.nombre as roles " &
                    "from usuario as u " &
                    "join rol on u.idrol = rol.idrol " &
                    "where u.nombreusuario = @usuario and u.activo = true;"


            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.AcceptButton = btnEntrar
    End Sub
End Class