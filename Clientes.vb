
Imports MySqlConnector

Public Class Clientes

    '# PROCEDIMIENTOS

    Private Sub CargarGrilla(Optional filtro As String = "")
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consulta As String =
                    "SELECT id_cliente, nombre as Nombre, telefono as Telefono, " &
                    "direccion AS Direccion, email as Email " &
                    "FROM clientes " &
                    "WHERE activo = 1 "

                If Not String.IsNullOrWhiteSpace(filtro) Then
                    consulta &= "AND Nombre LIKE @filtro "
                End If

                consulta &= "ORDER BY Nombre;"

                Using comando As New MySqlCommand(consulta, cn)

                    If Not String.IsNullOrWhiteSpace(filtro) Then
                        comando.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    End If

                    Dim tabla As New DataTable()

                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        tabla.Load(lector)
                    End Using

                    dgvClientes.DataSource = tabla

                    If dgvClientes.Columns.Contains("id_cliente") Then
                        dgvClientes.Columns("id_cliente").Visible = False
                    End If

                End Using
            End Using

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvClientes.AllowUserToAddRows = False
            dgvClientes.RowHeadersVisible = False
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvClientes.MultiSelect = False

        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ValidarCamposParaAgregar()
        Dim camposCompletos As Boolean = Not String.IsNullOrWhiteSpace(txtNombre.Text) AndAlso
        String.IsNullOrWhiteSpace(lblId.Text)

        btnAgregar.Enabled = camposCompletos
    End Sub

    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtTelefono.Clear()
        txtDireccion.Clear()
        txtEmail.Clear()

        dgvClientes.ClearSelection()
        dgvClientes.CurrentCell = Nothing
        Me.ActiveControl = Nothing
    End Sub

    Private Sub ValidarParaBuscar()
        btnBuscar.Enabled = Not String.IsNullOrWhiteSpace(txtBuscar.Text)

        If String.IsNullOrWhiteSpace(txtBuscar.Text) Then
            CargarGrilla()
            LimpiarCampos()
        End If
    End Sub

    Private Function CamposValidos() As Boolean
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("El nombre del cliente es obligatorio.",
                            "Campo requerido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            txtNombre.Focus()
            Return False
        End If

        If txtNombre.Text.Trim().Length > 100 Then
            MessageBox.Show("El nombre no puede superar los 100 caracteres.",
                            "Dato inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            txtNombre.Focus()
            Return False
        End If

        If txtTelefono.Text.Trim().Length > 30 Then
            MessageBox.Show("El teléfono no puede superar los 30 caracteres.",
                            "Dato inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            txtTelefono.Focus()
            Return False
        End If

        If txtDireccion.Text.Trim().Length > 150 Then
            MessageBox.Show("La dirección no puede superar los 150 caracteres.",
                            "Dato inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            txtDireccion.Focus()
            Return False
        End If

        If txtEmail.Text.Trim().Length > 100 Then
            MessageBox.Show("El email no puede superar los 100 caracteres.",
                            "Dato inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return False
        End If

        Return True
    End Function

    '# EVENTOS

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrilla()
        LimpiarCampos()

        txtBuscar.PlaceholderText = "Buscar cliente..."
        txtNombre.PlaceholderText = "Nombre del cliente"
        txtTelefono.PlaceholderText = "Teléfono (opcional)"
        txtDireccion.PlaceholderText = "Dirección (opcional)"
        txtEmail.PlaceholderText = "Email (opcional)"

        btnBuscar.Enabled = False
        btnModificar.Enabled = False
        btnBorrar.Enabled = False

        ValidarCamposParaAgregar()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtBuscar.Text.Trim())

        dgvClientes.ClearSelection()
        dgvClientes.CurrentCell = Nothing
        LimpiarCampos()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ValidarParaBuscar()
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub dgvClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex < 0 Then Return

        Dim fila As DataGridViewRow = dgvClientes.Rows(e.RowIndex)

        lblId.Text = fila.Cells("id_cliente").Value.ToString()
        txtNombre.Text = fila.Cells("Nombre").Value.ToString()

        If fila.Cells("Telefono").Value Is DBNull.Value Then
            txtTelefono.Clear()
        Else
            txtTelefono.Text = fila.Cells("Telefono").Value.ToString()
        End If

        If fila.Cells("Direccion").Value Is DBNull.Value Then
            txtDireccion.Clear()
        Else
            txtDireccion.Text = fila.Cells("Direccion").Value.ToString()
        End If

        If fila.Cells("Email").Value Is DBNull.Value Then
            txtEmail.Clear()
        Else
            txtEmail.Text = fila.Cells("Email").Value.ToString()
        End If
    End Sub

    Private Sub dgvClientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged
        Dim seleccionado As Boolean = dgvClientes.SelectedRows.Count > 0

        btnModificar.Enabled = seleccionado
        btnBorrar.Enabled = seleccionado
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If Not String.IsNullOrWhiteSpace(lblId.Text) Then
            MessageBox.Show("Para agregar un cliente nuevo, primero limpie los campos o deje de seleccionar el registro actual.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not CamposValidos() Then Exit Sub

        Dim respuesta As DialogResult =
            MessageBox.Show("¿Está seguro de que desea agregar este cliente?",
                            "Confirmar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)

        If respuesta <> DialogResult.Yes Then Exit Sub

        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consulta As String =
                    "INSERT INTO clientes (nombre, telefono, direccion, email) " &
                    "VALUES (@nombre, @telefono, @direccion, @email);"

                Using comando As New MySqlCommand(consulta, cn)
                    comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    comando.Parameters.AddWithValue("@telefono",
                        If(String.IsNullOrWhiteSpace(txtTelefono.Text),
                           CType(DBNull.Value, Object), txtTelefono.Text.Trim()))
                    comando.Parameters.AddWithValue("@direccion",
                        If(String.IsNullOrWhiteSpace(txtDireccion.Text),
                           CType(DBNull.Value, Object), txtDireccion.Text.Trim()))
                    comando.Parameters.AddWithValue("@email",
                        If(String.IsNullOrWhiteSpace(txtEmail.Text),
                           CType(DBNull.Value, Object), txtEmail.Text.Trim()))

                    comando.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Cliente agregado correctamente.",
                            "Agregado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            CargarGrilla()
            LimpiarCampos()
            txtNombre.Focus()

        Catch ex As Exception
            MessageBox.Show("Error al agregar el cliente: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If String.IsNullOrWhiteSpace(lblId.Text) Then
            MessageBox.Show("Seleccione un cliente antes de modificar.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not CamposValidos() Then Exit Sub

        Dim respuesta As DialogResult =
            MessageBox.Show("¿Está seguro de que desea guardar los cambios de este cliente?",
                            "Confirmar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)

        If respuesta <> DialogResult.Yes Then Exit Sub

        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consulta As String =
                    "UPDATE clientes SET nombre = @nombre, telefono = @telefono, " &
                    "direccion = @direccion, email = @email " &
                    "WHERE id_cliente = @id_cliente AND activo = 1;"

                Using comando As New MySqlCommand(consulta, cn)
                    comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    comando.Parameters.AddWithValue("@telefono",
                        If(String.IsNullOrWhiteSpace(txtTelefono.Text),
                           CType(DBNull.Value, Object), txtTelefono.Text.Trim()))
                    comando.Parameters.AddWithValue("@direccion",
                        If(String.IsNullOrWhiteSpace(txtDireccion.Text),
                           CType(DBNull.Value, Object), txtDireccion.Text.Trim()))
                    comando.Parameters.AddWithValue("@email",
                        If(String.IsNullOrWhiteSpace(txtEmail.Text),
                           CType(DBNull.Value, Object), txtEmail.Text.Trim()))
                    comando.Parameters.AddWithValue("@id_cliente", CInt(lblId.Text))

                    comando.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Cliente modificado correctamente.",
                            "Modificado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            CargarGrilla()
            LimpiarCampos()

        Catch ex As Exception
            MessageBox.Show("Error al modificar el cliente: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        If dgvClientes.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un cliente de la grilla.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim idCliente As Integer =
            CInt(dgvClientes.SelectedRows(0).Cells("id_cliente").Value)

        Dim respuesta As DialogResult =
            MessageBox.Show("¿Está seguro de que desea dar de baja a este cliente?",
                            "Confirmar baja",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning)

        If respuesta <> DialogResult.Yes Then Exit Sub

        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consulta As String =
                    "UPDATE clientes SET activo = 0 WHERE id_cliente = @id_cliente;"

                Using comando As New MySqlCommand(consulta, cn)
                    comando.Parameters.AddWithValue("@id_cliente", idCliente)

                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        MessageBox.Show("Cliente dado de baja correctamente.",
                                        "Confirmación",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No se encontró el cliente seleccionado.",
                                        "Aviso",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                    End If
                End Using
            End Using

            CargarGrilla()
            LimpiarCampos()

        Catch ex As Exception
            MessageBox.Show("Error al dar de baja al cliente: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        ValidarCamposParaAgregar()
    End Sub

    Private Sub Clientes_Click(sender As Object, e As EventArgs) Handles Me.Click
        LimpiarCampos()
    End Sub
End Class
