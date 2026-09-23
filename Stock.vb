Imports MySqlConnector

Public Class Stock
    '# PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ##

    Private Sub CargarGrilla(Optional filtro As String = "")
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim consulta As String
                consulta = "SELECT p.id_producto, p.nombre as Producto, p.descripcion as Descripcion, p.stock as Stock, p.precio_unitario as Precio, p.id_categoria, c.nombre_categoria as Categoria " &
                           "FROM categorias AS c " & "INNER JOIN productos AS p ON c.id_categoria = p.id_categoria"

                If filtro = "" Then
                    consulta = consulta & " ORDER BY nombre;"
                Else
                    consulta = consulta & " WHERE nombre Like @filtro" & " ORDER BY nombre"
                End If

                Using comando As New MySqlCommand(consulta, cn)

                    comando.Parameters.AddWithValue("@filtro", "%" & filtro & "%")

                    Dim tabla As New DataTable
                    Using lector As MySqlDataReader = comando.ExecuteReader
                        tabla.Load(lector)
                    End Using

                    dgvStock.DataSource = tabla
                    If (dgvStock.Columns.Contains("id_categoria")) Then
                        dgvStock.Columns("id_categoria").Visible = False
                    End If
                    dgvStock.Columns("id_producto").Visible = False

                End Using

            End Using
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            dgvStock.AllowUserToAddRows = False
            dgvStock.RowHeadersVisible = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar la grilla: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarCategorias()

        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()
                Dim consulta As String = "SELECT id_categoria, nombre_categoria FROM categorias ORDER BY nombre_categoria"
                Using cmd As New MySqlCommand(consulta, cn)
                    Dim tabla As New DataTable()
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cmbCategoria.DisplayMember = "nombre_categoria"
                    cmbCategoria.ValueMember = "id_categoria"
                    cmbCategoria.DataSource = tabla
                End Using
            End Using
            cmbCategoria.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar las categorias: " & ex.Message)
        End Try

    End Sub

    Sub LimpiarCampos()
        lblId.Text = ""
        txtNombre.Clear()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtStock.Clear()
        cmbCategoria.SelectedIndex = -1
        dgvStock.ClearSelection()
        dgvStock.CurrentCell = Nothing
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

    Private Sub ValidarCamposParaCrear()
        Dim camposCompletos As Boolean = Not String.IsNullOrWhiteSpace(txtNombre.Text) AndAlso
            Not String.IsNullOrWhiteSpace(txtPrecio.Text) AndAlso
            cmbCategoria.SelectedIndex <> -1 AndAlso lblId.Text = ""

        btnCrear.Enabled = camposCompletos
    End Sub
    '# PROCEDIMIENTOS ^^^ PROCEDIMIENTOS ^^^ PROCEDIMIENTOS ^^^ PROCEDIMIENTOS ^^^ PROCEDIMIENTOS ^^^

    '# EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ##
    Private Sub stock_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarGrilla()
        CargarCategorias()
        LimpiarCampos()
        ToolTip1.SetToolTip(btnProveedores, "Modificar los proveedores del producto")
        txtBuscar.PlaceholderText = "Buscar producto..."
        txtNombre.PlaceholderText = "Ej. Manzana"
        txtDescripcion.PlaceholderText = "Ej. Precio por kg.. En temporada.."
        txtPrecio.PlaceholderText = "Ej. 35,07"
        txtStock.PlaceholderText = "Ej. 35,7"
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtBuscar.Text.Trim)
        dgvStock.ClearSelection()
        dgvStock.CurrentCell = Nothing
    End Sub

    Private Sub dgvStock_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvStock.Rows(e.RowIndex)

            lblId.Text = fila.Cells("id_producto").Value.ToString
            txtNombre.Text = fila.Cells("Producto").Value.ToString
            txtDescripcion.Text = fila.Cells("Descripcion").Value.ToString
            txtPrecio.Text = fila.Cells("Precio").Value.ToString
            txtStock.Text = fila.Cells("stock").Value.ToString

            If fila.Cells("id_categoria").Value IsNot DBNull.Value Then
                cmbCategoria.SelectedValue = fila.Cells("id_categoria").Value
            Else
                cmbCategoria.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If String.IsNullOrWhiteSpace(txtNombre.Text.Trim) OrElse cmbCategoria.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(txtStock.Text) Then
            MessageBox.Show("Seleccione un registro antes de modificar.",
                            "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim respuesta As DialogResult
        respuesta = MessageBox.Show("Esta seguro de que desea guardar los cambios en este producto?",
                                    "Confirmar",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question)


        If respuesta = DialogResult.Yes Then


            Try
                Using cn As New MySqlConnection(ConnectionString)
                    cn.Open()
                    Dim consulta As String = "UPDATE productos SET " &
                                             "nombre = @nombre, " &
                                             "descripcion = @descripcion, " &
                                             "precio_unitario = @precio_unitario, " &
                                             "stock = @stock, " &
                                             "id_categoria = @id_categoria " &
                                             "WHERE id_producto = @id_producto"

                    Using comando As New MySqlCommand(consulta, cn)

                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                        comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim())
                        comando.Parameters.AddWithValue("@precio_unitario", CDbl(txtPrecio.Text))
                        comando.Parameters.AddWithValue("@stock", CInt(txtStock.Text))
                        comando.Parameters.AddWithValue("@id_categoria", CInt(cmbCategoria.SelectedValue))
                        comando.Parameters.AddWithValue("@id_producto", CInt(lblId.Text))

                        comando.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Producto modificado correctamente.",
                                "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarGrilla()
                LimpiarCampos()

            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al modificar: " & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            MessageBox.Show("Modificacion Cancelada", "Cancelada", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If dgvStock.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecciona un producto de la grilla")
            Exit Sub
        End If

        Dim idProducto As Integer = CInt(dgvStock.SelectedRows(0).Cells("id_producto").Value)

        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de que desea eliminar este producto definitivamente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If respuesta = DialogResult.No Then Exit Sub

        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim borrar As String
                borrar = "DELETE FROM productos WHERE id_producto = @id_producto"

                Using comando As New MySqlCommand(borrar, cn)
                    comando.Parameters.AddWithValue("@id_producto", idProducto)

                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()
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

    Private Sub lblId_Click(sender As Object, e As EventArgs) Handles lblId.Click
        Clipboard.SetText(lblId.Text)
        MessageBox.Show("Id copiado al portapapeles", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Controles_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged, txtPrecio.TextChanged
        ValidarCamposParaCrear()
    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
        ValidarCamposParaCrear()
    End Sub

    Private Sub Stock_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgvStock.ClearSelection()
        dgvStock.CurrentCell = Nothing
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim separador As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then
            Return
        End If

        If e.KeyChar = separador AndAlso Not txtPrecio.Text.Contains(separador) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        Dim separador As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then
            Return
        End If

        If e.KeyChar = separador AndAlso Not txtStock.Text.Contains(separador) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub dgvStock_SelectionChanged(sender As Object, e As EventArgs) Handles dgvStock.SelectionChanged
        Dim registroSeleccionado As Boolean = dgvStock.SelectedRows.Count > 0

        btnBorrar.Enabled = registroSeleccionado
        btnModificar.Enabled = registroSeleccionado
    End Sub

    Private Sub Stock_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        dgvStock.ClearSelection()
        dgvStock.CurrentCell = Nothing
        LimpiarCampos()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ValidarParaBuscar()
        txtBuscar.Focus()
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim precio As Decimal
        Dim stock As Integer

        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse cmbCategoria.SelectedIndex = -1 OrElse
            Not Decimal.TryParse(txtPrecio.Text, precio) OrElse precio <= 0 OrElse Not Integer.TryParse(txtStock.Text, stock) OrElse stock < 0 Then
            MessageBox.Show("Complete los campos requeridos.",
                            "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim respuesta As DialogResult
        respuesta = MessageBox.Show("Esta seguro de que desea guardar este producto?",
                                    "Confirmar",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question)


        If respuesta <> DialogResult.Yes Then Exit Sub


        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()
                Dim consulta As String = "INSERT INTO productos " &
                                             "(nombre, descripcion, precio_unitario, stock, id_categoria) " &
                                             "VALUES (@nombre, @descripcion, @precio_unitario, @stock, @id_categoria)"

                Using comando As New MySqlCommand(consulta, cn)

                    comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim())
                    comando.Parameters.AddWithValue("@precio_unitario", CDbl(txtPrecio.Text))
                    comando.Parameters.AddWithValue("@stock", CInt(txtStock.Text))
                    comando.Parameters.AddWithValue("@id_categoria", CInt(cmbCategoria.SelectedValue))

                    comando.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Producto creado correctamente.",
                                "Creado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarGrilla()
            LimpiarCampos()
            txtNombre.Focus()
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al crear: " & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click

        If lblId.Text = "" Then
            MessageBox.Show("Seleccione un producto.")
            Exit Sub
        End If


        Proveedores.idProductoSeleccionado = CInt(lblId.Text)
        Proveedores.nombreProductoSeleccionado = txtNombre.Text


        'llamo al form
        Proveedores.ShowDialog()
    End Sub
    '# EVENTOS ^^^ EVENTOS ^^^ EVENTOS ^^^ EVENTOS ^^^ EVENTOS ^^^ EVENTOS ^^^ EVENTOS ^^^


End Class