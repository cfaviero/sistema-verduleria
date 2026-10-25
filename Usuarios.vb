Imports MySqlConnector

Public Class Usuarios
    Private Sub CargarGrilla(Optional filtro As String = "")
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consulta As String =
                    "SELECT id_usuario, usuario as Usuario, descripcion as Descripcion " &
                    "FROM usuarios " &
                    "WHERE activo = 1 "

                If Not String.IsNullOrWhiteSpace(filtro) Then
                    consulta &= "AND Usuario LIKE @filtro "
                End If

                consulta &= "ORDER BY Usuario;"

                Using comando As New MySqlCommand(consulta, cn)

                    If Not String.IsNullOrWhiteSpace(filtro) Then
                        comando.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    End If

                    Dim tabla As New DataTable()

                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        tabla.Load(lector)
                    End Using

                    dgvUsuarios.DataSource = tabla

                End Using
            End Using

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvUsuarios.AllowUserToAddRows = False
            dgvUsuarios.RowHeadersVisible = False
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvUsuarios.MultiSelect = False

        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        txtUsuario.Clear()
        txtDescripUser.Clear()

        dgvUsuarios.ClearSelection()
        dgvUsuarios.CurrentCell = Nothing
        Me.ActiveControl = Nothing
    End Sub

    Private Sub ValidarParaBuscar()
        Dim txtUsado As Boolean = Not String.IsNullOrWhiteSpace(txtBuscar.Text)

        btnBuscar.Enabled = txtUsado
        If txtBuscar.Text = "" Then
            CargarGrilla()
            LimpiarCampos()
        End If
    End Sub

    Private Sub ValidarCamposParaAgregar()
        Dim camposCompletos As Boolean = Not String.IsNullOrWhiteSpace(txtUsuario.Text)

        btnAgregar.Enabled = camposCompletos
    End Sub

    Private Function usuarioExiste(Optional actual As String = "") As Boolean

        Dim resultado As Boolean = False
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()
                Dim sql = "select count(*) from usuarios where usuario = @usuario "

                If Not String.IsNullOrWhiteSpace(actual) Then
                    sql &= "AND usuario not LIKE @actual "
                End If

                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text)
                    cmd.Parameters.AddWithValue("@actual", actual)

                    Dim resul As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If resul > 0 Then
                        resultado = True
                    End If

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al verificar usuario: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return resultado
    End Function

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tema.AplicarTema(Me)
        CargarGrilla()

        txtBuscar.PlaceholderText = "Buscar usuario..."
        txtUsuario.PlaceholderText = "Ej. Usuario"
        txtDescripUser.PlaceholderText = "Ej. Claudio Altamirano"

        btnBuscar.Enabled = False
        btnModificar.Enabled = False
        btnBorrar.Enabled = False
        btnAgregar.Enabled = False

        LimpiarCampos()

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If String.IsNullOrWhiteSpace(txtUsuario.Text) OrElse String.IsNullOrWhiteSpace(txtDescripUser.Text) Then
            MessageBox.Show("Complete los campos requeridos.",
                            "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim existe As Boolean = usuarioExiste()
        If existe Then
            MessageBox.Show("El usuario ya existe, elija otro.")
            Exit Sub
        End If
        Dim nuevousuario As New Contra()
        nuevousuario.UsuarioNuevo = txtUsuario.Text
        nuevousuario.descNuevo = txtDescripUser.Text

        nuevousuario.ShowDialog()
        CargarGrilla()
        LimpiarCampos()


    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtBuscar.Text.Trim)
        dgvUsuarios.ClearSelection()
        dgvUsuarios.CurrentCell = Nothing
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ValidarParaBuscar()
        txtBuscar.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Dim id As Integer = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells("id_usuario").Value)

        If Not id >= 0 Then
            MessageBox.Show("Seleccione un cliente antes de modificar.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim existe As Boolean = usuarioExiste(dgvUsuarios.CurrentRow.Cells("usuario").Value)
        If existe Then
            MessageBox.Show("El usuario ya existe, elija otro.")
            txtUsuario.Focus()
            Exit Sub
        End If
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consulta As String =
                    "UPDATE usuarios SET usuario = @usuario, descripcion = @descripcion " &
                    "WHERE id_usuario = @id_usuario AND activo = 1;"

                Using comando As New MySqlCommand(consulta, cn)
                    comando.Parameters.AddWithValue("@id_usuario", id)
                    comando.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim())
                    comando.Parameters.AddWithValue("@descripcion", txtDescripUser.Text.Trim())

                    comando.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Cliente modificado correctamente.",
                            "Modificado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            CargarGrilla()
            LimpiarCampos()
            btnModificar.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error al modificar el cliente: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvUsuarios.Rows(e.RowIndex)

            txtUsuario.Text = fila.Cells("Usuario").Value.ToString
            txtDescripUser.Text = fila.Cells("Descripcion").Value.ToString
            btnBorrar.Enabled = True
            btnAgregar.Enabled = False
            btnModificar.Enabled = True
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If dgvUsuarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona un producto de la grilla")
            Exit Sub
        End If

        Dim id_usuario As Integer = dgvUsuarios.SelectedRows(0).Cells("id_usuario").Value

        Dim respuesta = MessageBox.Show("Seguro de que desea dar de baja este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If respuesta = DialogResult.No Then Exit Sub

        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim borrar As String
                borrar = "update usuarios set activo = 0 WHERE id_usuario = @id_usuario"

                Using comando As New MySqlCommand(borrar, cn)
                    comando.Parameters.AddWithValue("@id_usuario", id_usuario)

                    Dim filasAfectadas = comando.ExecuteNonQuery
                    If filasAfectadas > 0 Then
                        MessageBox.Show("Producto eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LimpiarCampos()
                        CargarGrilla()
                    Else
                        MessageBox.Show("No se encontro el producto seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End Using
            End Using
            CargarGrilla()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show("Error al borrar, no se borro ningun registro: " & ex.Message)
        End Try

    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged
        If Not dgvUsuarios.SelectedRows.Count > 0 Then
            ValidarCamposParaAgregar()
        End If
    End Sub

    Private Sub Usuarios_Click(sender As Object, e As EventArgs) Handles Me.Click
        LimpiarCampos()
        ValidarCamposParaAgregar()
        btnModificar.Enabled = False
        btnBorrar.Enabled = False
    End Sub


End Class