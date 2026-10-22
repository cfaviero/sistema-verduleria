Imports MySqlConnector

Public Class Proveedores_ABM






    '# PROCEDIMIENTOS

    Private Sub CargarGrilla(Optional filtro As String = "")
            Try
                Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                    cn.Open()

                    Dim consulta As String =
                    "SELECT id_proveedor, nombre AS Nombre, " &
                    "telefono AS Telefono, direccion AS Direccion " &
                    "FROM proveedores " &
                    "WHERE activo = 1 "

                    If Not String.IsNullOrWhiteSpace(filtro) Then
                        consulta &= "AND nombre LIKE @filtro "
                    End If

                    consulta &= "ORDER BY nombre;"

                    Using comando As New MySqlCommand(consulta, cn)

                        If Not String.IsNullOrWhiteSpace(filtro) Then
                            comando.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                        End If

                        Dim tabla As New DataTable()

                        Using lector As MySqlDataReader = comando.ExecuteReader()
                            tabla.Load(lector)
                        End Using

                    dgvProveedores.DataSource = tabla

                    If dgvProveedores.Columns.Contains("id_proveedor") Then
                        dgvProveedores.Columns("id_proveedor").Visible = False
                    End If

                    End Using
                End Using

            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvProveedores.AllowUserToAddRows = False
            dgvProveedores.RowHeadersVisible = False
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvProveedores.MultiSelect = False

        Catch ex As Exception
                MessageBox.Show("Error al cargar los proveedores: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LimpiarCampos()
            lblId.Text = ""
            txtNombre.Clear()
            txtTelefono.Clear()
            txtDireccion.Clear()

        dgvProveedores.ClearSelection()
        dgvProveedores.CurrentCell = Nothing
        Me.ActiveControl = Nothing

            ValidarCamposParaAgregar()
        End Sub

        Private Sub ValidarParaBuscar()
            btnBuscar.Enabled = Not String.IsNullOrWhiteSpace(txtBuscar.Text)

            If String.IsNullOrWhiteSpace(txtBuscar.Text) Then
                CargarGrilla()
                LimpiarCampos()
            End If
        End Sub

        Private Sub ValidarCamposParaAgregar()
            Dim camposCompletos As Boolean =
            Not String.IsNullOrWhiteSpace(txtNombre.Text) AndAlso
            String.IsNullOrWhiteSpace(lblId.Text)

            btnAgregar.Enabled = camposCompletos
        End Sub

        Private Function CamposValidos() As Boolean

            If String.IsNullOrWhiteSpace(txtNombre.Text) Then
                MessageBox.Show("El nombre del proveedor es obligatorio.",
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

            Return True
        End Function

        '# EVENTOS

        Private Sub Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CargarGrilla()
            LimpiarCampos()

            txtBuscar.PlaceholderText = "Buscar proveedor..."
            txtNombre.PlaceholderText = "Nombre del proveedor"
            txtTelefono.PlaceholderText = "Teléfono (opcional)"
            txtDireccion.PlaceholderText = "Dirección (opcional)"

            btnBuscar.Enabled = False
            btnModificar.Enabled = False
            btnBorrar.Enabled = False

            ValidarCamposParaAgregar()
        End Sub

        Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
            CargarGrilla(txtBuscar.Text.Trim())

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

    Private Sub dgvProveedores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedores.CellClick
        If e.RowIndex < 0 Then Return

        Dim fila As DataGridViewRow = dgvProveedores.Rows(e.RowIndex)

        lblId.Text = fila.Cells("id_proveedor").Value.ToString()
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

        ValidarCamposParaAgregar()
    End Sub

    Private Sub dgvProveedores_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProveedores.SelectionChanged
        Dim seleccionado As Boolean = dgvProveedores.SelectedRows.Count > 0

        btnModificar.Enabled = seleccionado
            btnBorrar.Enabled = seleccionado
        End Sub

        Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
            ValidarCamposParaAgregar()
        End Sub

        Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

            If Not String.IsNullOrWhiteSpace(lblId.Text) Then
                MessageBox.Show("Limpie los campos antes de agregar un proveedor nuevo.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not CamposValidos() Then Exit Sub

            Dim respuesta As DialogResult =
            MessageBox.Show("¿Está seguro de que desea agregar este proveedor?",
                            "Confirmar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)

            If respuesta <> DialogResult.Yes Then Exit Sub

            Try
                Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                    cn.Open()

                    Dim consulta As String =
                    "INSERT INTO proveedores (nombre, telefono, direccion) " &
                    "VALUES (@nombre, @telefono, @direccion);"

                    Using comando As New MySqlCommand(consulta, cn)
                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())

                        comando.Parameters.AddWithValue("@telefono",
                        If(String.IsNullOrWhiteSpace(txtTelefono.Text),
                           CType(DBNull.Value, Object), txtTelefono.Text.Trim()))

                        comando.Parameters.AddWithValue("@direccion",
                        If(String.IsNullOrWhiteSpace(txtDireccion.Text),
                           CType(DBNull.Value, Object), txtDireccion.Text.Trim()))

                        comando.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Proveedor agregado correctamente.",
                            "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                CargarGrilla()
                LimpiarCampos()
                txtNombre.Focus()

            Catch ex As Exception
                MessageBox.Show("Error al agregar el proveedor: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

            If String.IsNullOrWhiteSpace(lblId.Text) Then
                MessageBox.Show("Seleccione un proveedor antes de modificar.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not CamposValidos() Then Exit Sub

            Dim respuesta As DialogResult =
            MessageBox.Show("¿Está seguro de que desea guardar los cambios de este proveedor?",
                            "Confirmar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)

            If respuesta <> DialogResult.Yes Then Exit Sub

            Try
                Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                    cn.Open()

                    Dim consulta As String =
                    "UPDATE proveedores SET nombre = @nombre, " &
                    "telefono = @telefono, direccion = @direccion " &
                    "WHERE id_proveedor = @id_proveedor AND activo = 1;"

                    Using comando As New MySqlCommand(consulta, cn)
                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())

                        comando.Parameters.AddWithValue("@telefono",
                        If(String.IsNullOrWhiteSpace(txtTelefono.Text),
                           CType(DBNull.Value, Object), txtTelefono.Text.Trim()))

                        comando.Parameters.AddWithValue("@direccion",
                        If(String.IsNullOrWhiteSpace(txtDireccion.Text),
                           CType(DBNull.Value, Object), txtDireccion.Text.Trim()))

                        comando.Parameters.AddWithValue("@id_proveedor", CInt(lblId.Text))

                        comando.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Proveedor modificado correctamente.",
                            "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                CargarGrilla()
                LimpiarCampos()

            Catch ex As Exception
                MessageBox.Show("Error al modificar el proveedor: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        If dgvProveedores.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un proveedor de la grilla.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim idProveedor As Integer =
            CInt(dgvProveedores.SelectedRows(0).Cells("id_proveedor").Value)

        Dim respuesta As DialogResult =
            MessageBox.Show("¿Está seguro de que desea dar de baja a este proveedor?",
                            "Confirmar baja",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning)

            If respuesta <> DialogResult.Yes Then Exit Sub

            Try
                Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                    cn.Open()

                    Dim consulta As String =
                    "UPDATE proveedores SET activo = 0 " &
                    "WHERE id_proveedor = @id_proveedor;"

                    Using comando As New MySqlCommand(consulta, cn)
                        comando.Parameters.AddWithValue("@id_proveedor", idProveedor)

                        Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                        If filasAfectadas > 0 Then
                            MessageBox.Show("Proveedor dado de baja correctamente.",
                                        "Confirmación",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("No se encontró el proveedor seleccionado.",
                                        "Aviso",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                        End If
                    End Using
                End Using

                CargarGrilla()
                LimpiarCampos()

            Catch ex As Exception
                MessageBox.Show("Error al dar de baja al proveedor: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub




    End Class