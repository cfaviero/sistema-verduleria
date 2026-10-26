Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports MySqlConnector

Public Class Stock
    '# PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ##

    Private Sub CargarGrilla(Optional filtro As String = "")
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim consulta As String
                consulta = "SELECT p.id_producto, p.nombre as Producto, p.descripcion as Descripcion, p.precio_unitario as Precio, p.id_categoria, c.nombre_categoria as Categoria, s.stock " &
           "FROM categorias AS c " & "INNER JOIN productos AS p ON c.id_categoria = p.id_categoria " &
           "INNER JOIN v_stock AS s ON s.id_producto = p.id_producto " &
           "WHERE p.activo = 1"

                If filtro = "" Then
                    consulta = consulta & " ORDER BY nombre;"
                Else
                    consulta = consulta & " AND nombre Like @filtro" & " ORDER BY nombre"
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

    Sub CargarImagen(id As Integer)
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()
                Dim sql As String = "select imagen_producto from productos where id_producto = @id;"

                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", CInt(lblId.Text))
                    Dim valor = cmd.ExecuteScalar

                    'Verifico que el valor no sea null
                    If valor Is Nothing OrElse valor Is DBNull.Value Then
                        If PictureBox1.Image Is Nothing Then
                            Dim rutaImagen As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "images (1).png")
                            PictureBox1.Image = Image.FromFile(rutaImagen)
                            btnQuitar.Enabled = False
                            btnGuardar.Enabled = False
                            btnAgregar.Enabled = True
                        End If
                        Exit Sub
                    End If

                    Dim datos() As Byte = DirectCast(valor, Byte())

                    Using memoria As New MemoryStream(datos)
                        Using temporal As Image = Image.FromStream(memoria)
                            PictureBox1.Image = New Bitmap(temporal)
                        End Using
                    End Using
                End Using
            End Using
            btnQuitar.Enabled = True
            btnGuardar.Enabled = False
            btnAgregar.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message)
        End Try
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

    Private Function ImagenaBytes(img As Image) As Byte()
        'Verifica si la imagen es null
        If img Is Nothing Then
            Return Nothing
        End If

        Using memoria As New MemoryStream()
            img.Save(memoria, ImageFormat.Jpeg)
            Return memoria.ToArray()
        End Using
    End Function
    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^

    '# EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ## EVENTOS ##
    Private Sub stock_Load(sender As Object, e As EventArgs) Handles Me.Load
        Tema.AplicarTema(Me)
        CargarGrilla()
        CargarCategorias()
        LimpiarCampos()
        ToolTip1.SetToolTip(btnProveedores, "Modificar los proveedores del producto")
        txtBuscar.PlaceholderText = "Buscar producto..."
        txtNombre.PlaceholderText = "Ej. Manzana"
        txtDescripcion.PlaceholderText = "Ej. Precio por kg.. En temporada.."
        txtPrecio.PlaceholderText = "Ej. 35,07"
        txtStock.PlaceholderText = "Ej. 35,7"
        btnAgregar.Enabled = False
        btnGuardar.Enabled = False
        btnQuitar.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtBuscar.Text.Trim)
        dgvStock.ClearSelection()
        dgvStock.CurrentCell = Nothing
    End Sub

    Private Sub dgvStock_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellClick
        If e.RowIndex >= 0 Then
            PictureBox1.Image = Nothing
            Dim fila As DataGridViewRow = dgvStock.Rows(e.RowIndex)

            lblId.Text = fila.Cells("id_producto").Value.ToString
            txtNombre.Text = fila.Cells("Producto").Value.ToString
            txtDescripcion.Text = fila.Cells("Descripcion").Value.ToString
            txtPrecio.Text = fila.Cells("Precio").Value.ToString
            txtStock.Text = fila.Cells("stock").Value.ToString
            CargarImagen(CInt(lblId.Text))

            If fila.Cells("id_categoria").Value IsNot DBNull.Value Then
                cmbCategoria.SelectedValue = fila.Cells("id_categoria").Value
            Else
                cmbCategoria.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If String.IsNullOrWhiteSpace(txtNombre.Text.Trim) OrElse cmbCategoria.SelectedIndex = -1 Then
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
                                             "id_categoria = @id_categoria " &
                                             "WHERE id_producto = @id_producto"

                    Using comando As New MySqlCommand(consulta, cn)

                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                        comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim())
                        comando.Parameters.AddWithValue("@precio_unitario", CDbl(txtPrecio.Text))
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
                borrar = "update productos set activo = 0 WHERE id_producto = @id_producto"

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

        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse cmbCategoria.SelectedIndex = -1 OrElse
            Not Decimal.TryParse(txtPrecio.Text, precio) OrElse precio <= 0 Then
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
                                             "(nombre, descripcion, precio_unitario, id_categoria) " &
                                             "VALUES (@nombre, @descripcion, @precio_unitario, @id_categoria)"

                Using comando As New MySqlCommand(consulta, cn)

                    comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim())
                    comando.Parameters.AddWithValue("@precio_unitario", CDbl(txtPrecio.Text))
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
        Proveedores.descriProd = txtDescripcion.Text

        'llamo al form
        Proveedores.ShowDialog()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Using dlg As New OpenFileDialog()
            dlg.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp"

            If dlg.ShowDialog() = DialogResult.OK Then
                Using temporal As Image = Image.FromFile(dlg.FileName)
                    PictureBox1.Image = New Bitmap(temporal)
                End Using
            End If
        End Using
        If PictureBox1.Image IsNot Nothing Then
            btnGuardar.Enabled = True
            btnQuitar.Enabled = True
            btnAgregar.Enabled = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtNombre.Text = "" Then
            Exit Sub
        End If

        Dim datos() As Byte = ImagenaBytes(PictureBox1.Image)

        If datos.Length > 1000000 Then
            MessageBox.Show("La imagen no puede superar los 1MB")
            Exit Sub
        End If

        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim sql = "update productos set imagen_producto = @imagen " &
                    "where id_producto = @id"

                Using cmd As New MySqlCommand(sql, cn)
                    'Verifica si hay imagen
                    If datos Is Nothing Then
                        cmd.Parameters.AddWithValue("@imagen", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@imagen", MySqlDbType.LongBlob).Value = datos
                    End If

                    cmd.Parameters.AddWithValue("@id", CInt(lblId.Text))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            btnGuardar.Enabled = False
            MessageBox.Show("Se guardo la imagen")
        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message)
        End Try

    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        If txtNombre.Text = "" Then
            Exit Sub
        End If
        Dim idProducto As Integer = CInt(dgvStock.SelectedRows(0).Cells("id_producto").Value)

        Dim respuesta As DialogResult = MessageBox.Show("Seguro desea eliminar la imagen de este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If respuesta = DialogResult.No Then
            Exit Sub
        End If

        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim sql = "update productos set imagen_producto = null " &
                    "where id_producto = @id"

                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", idProducto)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            PictureBox1.Image = Nothing
            MessageBox.Show("Imagen eliminada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message)
        End Try
        btnGuardar.Enabled = False
        btnQuitar.Enabled = False
        btnAgregar.Enabled = True
        CargarImagen(lblId.Text)
    End Sub


    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^



    ' Cantidad de productos que aparecen en el informe (caben hasta 6 en la hoja)
    Private Const CANTIDAD_INFORME As Integer = 5

    ' Datos del informe, cargados al hacer clic y usados al dibujar la hoja
    Private informeProductos As DataTable
    Private indiceFila As Integer

    Private Sub btnInforme_Click(sender As Object, e As EventArgs) Handles btnInforme.Click
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim consulta As String =
                    "SELECT p.nombre, c.nombre_categoria, p.precio_unitario, s.stock, p.imagen_producto " &
                    "FROM productos AS p " &
                    "INNER JOIN categorias AS c ON c.id_categoria = p.id_categoria " &
                    "INNER JOIN v_stock AS s ON s.id_producto = p.id_producto " &
                    "WHERE p.activo = 1 " &
                    "ORDER BY s.stock asc;" '&
                '"LIMIT " & CANTIDAD_INFORME

                Using cmd As New MySqlCommand(consulta, cn)
                    informeProductos = New DataTable()
                    Using lector As MySqlDataReader = cmd.ExecuteReader()
                        informeProductos.Load(lector)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al generar el informe: " & ex.Message)
            Exit Sub
        End Try

        If informeProductos.Rows.Count = 0 Then
            MessageBox.Show("No hay productos para el informe.")
            Exit Sub
        End If

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Const ALTO_FILA As Integer = 130
        Const LADO_IMG As Integer = 110

        Dim g As Graphics = e.Graphics
        Dim marco As Rectangle = e.MarginBounds
        Dim centrado As New StringFormat() With {.Alignment = StringAlignment.Center}

        Using fTitulo As New Font("Arial", 18, FontStyle.Bold),
              fNormal As New Font("Arial", 12, FontStyle.Regular),
              fNegrita As New Font("Arial", 12, FontStyle.Bold),
              lapizMarco As New Pen(Color.Black, 2)

            ' Recuadro alrededor de toda la información
            g.DrawRectangle(lapizMarco, marco)

            ' Encabezado
            g.DrawString("Informe de productos con menos stock", fTitulo, Brushes.Black,
                         New RectangleF(marco.Left, marco.Top + 15, marco.Width, 40), centrado)
            g.DrawString("Fecha: " & Now.ToString("dd/MM/yyyy HH:mm"), fNormal, Brushes.Black,
                         marco.Left + 15, marco.Top + 60)
            g.DrawLine(Pens.Black, marco.Left, marco.Top + 90, marco.Right, marco.Top + 90)

            ' Una fila por producto
            Dim y As Integer = marco.Top + 100
            Do While indiceFila < informeProductos.Rows.Count

                ' Si no entra otra fila en esta hoja, corto y sigo en la siguiente
                If y + ALTO_FILA > marco.Bottom - 40 Then Exit Do

                Dim fila As DataRow = informeProductos.Rows(indiceFila)

                ' Imagen (ajustada sin deformarla) o aviso si no tiene
                Dim rectImg As New Rectangle(marco.Left + 15, y, LADO_IMG, LADO_IMG)
                If Not IsDBNull(fila("imagen_producto")) Then
                    Using memoria As New MemoryStream(DirectCast(fila("imagen_producto"), Byte()))
                        Using img As Image = Image.FromStream(memoria)
                            Dim escala As Single = Math.Min(LADO_IMG / img.Width, LADO_IMG / img.Height)
                            Dim ancho As Integer = CInt(img.Width * escala)
                            Dim alto As Integer = CInt(img.Height * escala)
                            g.DrawImage(img, rectImg.X + (LADO_IMG - ancho) \ 2,
                                        rectImg.Y + (LADO_IMG - alto) \ 2, ancho, alto)
                        End Using
                    End Using
                Else
                    g.DrawString("Sin imagen", fNormal, Brushes.Gray, rectImg.X + 10, rectImg.Y + 45)
                End If
                g.DrawRectangle(Pens.Gray, rectImg)

                ' Datos del producto
                Dim xTexto As Integer = rectImg.Right + 20
                g.DrawString(fila("nombre").ToString(), fNegrita, Brushes.Black, xTexto, y + 5)
                g.DrawString("Categoría: " & fila("nombre_categoria").ToString(), fNormal, Brushes.Black, xTexto, y + 35)
                g.DrawString("Precio: " & Convert.ToDecimal(fila("precio_unitario")).ToString("C2"),
                             fNormal, Brushes.Black, xTexto, y + 60)
                g.DrawString("Stock: " & Convert.ToDecimal(fila("stock")).ToString("0.###"),
                             fNegrita, Brushes.Black, xTexto, y + 85)

                y += ALTO_FILA
                g.DrawLine(Pens.LightGray, marco.Left + 15, y - 10, marco.Right - 15, y - 10)

                indiceFila += 1   ' paso al siguiente producto
            Loop

            ' Si quedan productos, la impresión genera otra hoja
            e.HasMorePages = (indiceFila < informeProductos.Rows.Count)
        End Using
    End Sub
    Private Sub PrintDocument1_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        indiceFila = 0
    End Sub
End Class