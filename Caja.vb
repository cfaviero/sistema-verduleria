Imports System.Drawing.Printing
Imports MySqlConnector

Public Class Caja

    ' Carrito de un solo producto ingresadio
    Private carrito As New DataTable()

    ' REEMPLAZAR: id_empleado del usuario que inicio sesion (empleados.id_empleado)
    Private idEmpleadoActual As Integer = 1

    '# PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ##

    Private Sub CrearCarrito()
        carrito.Columns.Add("id_producto", GetType(Integer))
        carrito.Columns.Add("Producto", GetType(String))
        carrito.Columns.Add("Unidad", GetType(String))
        carrito.Columns.Add("Cantidad", GetType(Decimal))
        carrito.Columns.Add("Precio", GetType(Decimal))
        carrito.Columns.Add("Subtotal", GetType(Decimal))

        dgvCarrito.DataSource = carrito
        dgvCarrito.Columns("id_producto").Visible = False
        dgvCarrito.Columns("Cantidad").DefaultCellStyle.Format = "0.###"
        dgvCarrito.Columns("Precio").DefaultCellStyle.Format = "C2"
        dgvCarrito.Columns("Subtotal").DefaultCellStyle.Format = "C2"

        dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCarrito.AllowUserToAddRows = False
        dgvCarrito.RowHeadersVisible = False
        dgvCarrito.ReadOnly = True
        dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCarrito.MultiSelect = False
    End Sub

    Private Sub CargarProductos(Optional filtro As String = "")
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                ' Disponible = lo que entro - lo vendido - las mermas, solo de lotes no vencidos
                Dim consulta As String =
                    "SELECT p.id_producto, p.nombre AS Producto, p.unidad_medida AS Unidad, " &
                    "p.precio_unitario AS Precio, " &
                    "(SELECT IFNULL(SUM(pl.cantidad_inicial), 0) FROM productos_lote AS pl " &
                    " WHERE pl.id_producto = p.id_producto " &
                    " AND (pl.fecha_vencimiento IS NULL OR pl.fecha_vencimiento >= CURDATE())) " &
                    "- (SELECT IFNULL(SUM(dv.cantidad), 0) FROM detalles_venta AS dv " &
                    " INNER JOIN productos_lote AS pl ON pl.id_prod_lote = dv.id_prod_lote " &
                    " WHERE pl.id_producto = p.id_producto " &
                    " AND (pl.fecha_vencimiento IS NULL OR pl.fecha_vencimiento >= CURDATE())) " &
                    "- (SELECT IFNULL(SUM(m.cantidad), 0) FROM mermas AS m " &
                    " INNER JOIN productos_lote AS pl ON pl.id_prod_lote = m.id_prod_lote " &
                    " WHERE pl.id_producto = p.id_producto " &
                    " AND (pl.fecha_vencimiento IS NULL OR pl.fecha_vencimiento >= CURDATE())) AS Disponible " &
                    "FROM productos AS p " &
                    "WHERE p.activo = 1 "

                If Not String.IsNullOrWhiteSpace(filtro) Then
                    consulta &= "AND p.nombre LIKE @filtro "
                End If

                consulta &= "HAVING Disponible > 0 ORDER BY p.nombre;"

                Using comando As New MySqlCommand(consulta, cn)

                    If Not String.IsNullOrWhiteSpace(filtro) Then
                        comando.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    End If

                    Dim tabla As New DataTable()
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        tabla.Load(lector)
                    End Using

                    dgvProductos.DataSource = tabla
                    dgvProductos.Columns("id_producto").Visible = False
                    dgvProductos.Columns("Precio").DefaultCellStyle.Format = "C2"
                    dgvProductos.Columns("Disponible").DefaultCellStyle.Format = "0.###"
                End Using
            End Using

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvProductos.AllowUserToAddRows = False
            dgvProductos.RowHeadersVisible = False
            dgvProductos.ReadOnly = True
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvProductos.MultiSelect = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar los productos: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarClientes()
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()
                Dim consulta As String = "SELECT id_cliente, nombre FROM clientes WHERE activo = 1 ORDER BY nombre"
                Using cmd As New MySqlCommand(consulta, cn)
                    Dim tabla As New DataTable()
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using

                    ' Fila 0 = venta de mostrador (se guarda con id_cliente NULL)
                    Dim mostrador As DataRow = tabla.NewRow()
                    mostrador("id_cliente") = 0
                    mostrador("nombre") = "Consumidor final"
                    tabla.Rows.InsertAt(mostrador, 0)

                    cmbCliente.DisplayMember = "nombre"
                    cmbCliente.ValueMember = "id_cliente"
                    cmbCliente.DataSource = tabla
                End Using
            End Using
            cmbCliente.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarTotal()
        Dim total As Decimal = 0

        For Each fila As DataRow In carrito.Rows
            total += CDec(fila("Subtotal"))
        Next

        lblTotal.Text = "Total: " & total.ToString("C2")
        ValidarParaConfirmar()
    End Sub

    Private Sub ValidarParaAgregar()
        btnAgregar.Enabled = dgvProductos.SelectedRows.Count > 0 AndAlso
            Not String.IsNullOrWhiteSpace(txtCantidad.Text)
    End Sub

    Private Sub ValidarParaConfirmar()
        btnConfirmar.Enabled = carrito.Rows.Count > 0 AndAlso cmbMetodoPago.SelectedIndex <> -1
    End Sub

    Private Sub LimpiarVenta()
        carrito.Clear()
        txtBuscar.Clear()
        txtCantidad.Clear()
        cmbCliente.SelectedIndex = 0
        cmbMetodoPago.SelectedIndex = -1
        CargarProductos()
        ActualizarTotal()

        dgvProductos.ClearSelection()
        dgvProductos.CurrentCell = Nothing
        dgvProductos.ClearSelection()
        dgvProductos.CurrentCell = Nothing
        Me.ActiveControl = Nothing
    End Sub

    ' Reparte la cantidad pedida entre los lotes del producto, primero los que vencen antes.
    ' Cada lote usado agrega una fila a "lineas". Si no alcanza, "faltante" queda mayor a 0.
    Private Sub AsignarLotes(cn As MySqlConnection, tx As MySqlTransaction, idProducto As Integer,
                             cantidad As Decimal, precio As Decimal, lineas As DataTable,
                             ByRef faltante As Decimal)

        ' 1) Bloqueo los lotes del producto: otra venta del mismo producto espera a que termine esta
        Using cmdBloqueo As New MySqlCommand("SELECT id_prod_lote FROM productos_lote " &
                                             "WHERE id_producto = @id_producto FOR UPDATE;", cn, tx)
            cmdBloqueo.Parameters.AddWithValue("@id_producto", idProducto)
            cmdBloqueo.ExecuteNonQuery()
        End Using

        ' 2) Lotes con stock, no vencidos, ordenados por vencimiento (los que no vencen van al final)
        Dim consulta As String =
            "SELECT pl.id_prod_lote, " &
            "pl.cantidad_inicial " &
            "- IFNULL((SELECT SUM(dv.cantidad) FROM detalles_venta AS dv WHERE dv.id_prod_lote = pl.id_prod_lote), 0) " &
            "- IFNULL((SELECT SUM(m.cantidad) FROM mermas AS m WHERE m.id_prod_lote = pl.id_prod_lote), 0) AS disponible " &
            "FROM productos_lote AS pl " &
            "WHERE pl.id_producto = @id_producto " &
            "AND (pl.fecha_vencimiento IS NULL OR pl.fecha_vencimiento >= CURDATE()) " &
            "HAVING disponible > 0 " &
            "ORDER BY pl.fecha_vencimiento IS NULL, pl.fecha_vencimiento, pl.id_prod_lote;"

        Dim lotes As New DataTable()
        Using comando As New MySqlCommand(consulta, cn, tx)
            comando.Parameters.AddWithValue("@id_producto", idProducto)
            Using lector As MySqlDataReader = comando.ExecuteReader()
                lotes.Load(lector)
            End Using
        End Using

        ' 3) Tomo de cada lote lo que haga falta hasta completar la cantidad
        Dim pendiente As Decimal = cantidad

        For Each lote As DataRow In lotes.Rows
            If pendiente <= 0 Then Exit For

            Dim tomar As Decimal = Math.Min(pendiente, CDec(lote("disponible")))

            Dim nueva As DataRow = lineas.NewRow()
            nueva("id_prod_lote") = CInt(lote("id_prod_lote"))
            nueva("cantidad") = tomar
            nueva("precio") = precio
            ' Mismo redondeo que el CHECK de detalles_venta (ROUND de MariaDB)
            nueva("subtotal") = Math.Round(tomar * precio, 2, MidpointRounding.AwayFromZero)
            lineas.Rows.Add(nueva)

            pendiente -= tomar
        Next

        faltante = pendiente
    End Sub
    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^
    '# EVENTOS ## EVENTOS ## ## EVENTOS ## ## EVENTOS ## ## EVENTOS ## ## EVENTOS ## ## EVENTOS ##

    Private Sub Caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tema.AplicarTema(Me)
        CrearCarrito()
        CargarProductos()
        CargarClientes()

        cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMetodoPago.Items.AddRange(New Object() {"Efectivo", "Transferencia"})
        cmbMetodoPago.SelectedIndex = -1

        txtBuscar.PlaceholderText = "Buscar producto..."
        txtCantidad.PlaceholderText = "Ej. 1,5"

        btnAgregar.Enabled = False
        btnQuitar.Enabled = False
        btnConfirmar.Enabled = False

        ActualizarTotal()
    End Sub

    Private Sub Caja_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgvProductos.ClearSelection()
        dgvProductos.CurrentCell = Nothing
        dgvCarrito.ClearSelection()
        dgvCarrito.CurrentCell = Nothing
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        CargarProductos(txtBuscar.Text.Trim)
        dgvProductos.ClearSelection()
        dgvProductos.CurrentCell = Nothing
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        ValidarParaAgregar()
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim separador As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) Then
            Return
        End If

        If e.KeyChar = separador AndAlso Not txtCantidad.Text.Contains(separador) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnAgregar.PerformClick()
        End If
    End Sub

    Private Sub dgvProductos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductos.SelectionChanged
        ValidarParaAgregar()
    End Sub

    Private Sub dgvCarrito_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductos.SelectionChanged
        btnQuitar.Enabled = dgvCarrito.SelectedRows.Count > 0
    End Sub

    Private Sub cmbMetodoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMetodoPago.SelectedIndexChanged
        ValidarParaConfirmar()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If dgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un producto de la grilla.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim cantidad As Decimal
        If Not Decimal.TryParse(txtCantidad.Text, cantidad) Then
            MessageBox.Show("Ingrese una cantidad valida.",
                            "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        ' La BD guarda 3 decimales: redondeo antes de validar
        cantidad = Math.Round(cantidad, 3, MidpointRounding.AwayFromZero)

        If cantidad <= 0 Then
            MessageBox.Show("La cantidad debe ser mayor a 0.",
                            "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        Dim fila As DataGridViewRow = dgvProductos.SelectedRows(0)
        Dim idProducto As Integer = CInt(fila.Cells("id_producto").Value)
        Dim nombre As String = fila.Cells("Producto").Value.ToString()
        Dim unidad As String = fila.Cells("Unidad").Value.ToString()
        Dim precio As Decimal = CDec(fila.Cells("Precio").Value)
        Dim disponible As Decimal = CDec(fila.Cells("Disponible").Value)

        ' Solo los kg admiten decimales; unidades y atados van enteros
        If unidad.ToLower() <> "kg" AndAlso cantidad <> Math.Floor(cantidad) Then
            MessageBox.Show("Este producto se vende por " & unidad & ": ingrese una cantidad entera.",
                            "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        ' Si el producto ya esta en la venta, se suma a lo que ya hay
        Dim existentes() As DataRow = carrito.Select("id_producto = " & idProducto)
        Dim enCarrito As Decimal = 0
        If existentes.Length > 0 Then
            enCarrito = CDec(existentes(0)("Cantidad"))
        End If

        If enCarrito + cantidad > disponible Then
            MessageBox.Show("Stock insuficiente de " & nombre & "." & vbCrLf &
                            "Disponible: " & disponible.ToString("0.###") & " " & unidad & vbCrLf &
                            "Ya en esta venta: " & enCarrito.ToString("0.###") & " " & unidad,
                            "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        If existentes.Length > 0 Then
            Dim linea As DataRow = existentes(0)
            linea("Cantidad") = enCarrito + cantidad
            linea("Subtotal") = Math.Round(CDec(linea("Cantidad")) * precio, 2, MidpointRounding.AwayFromZero)
        Else
            carrito.Rows.Add(idProducto, nombre, unidad, cantidad, precio,
                             Math.Round(cantidad * precio, 2, MidpointRounding.AwayFromZero))
        End If

        ActualizarTotal()
        txtCantidad.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        If dgvCarrito.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione una linea de la venta.")
            Exit Sub
        End If

        Dim filaCarrito As DataRow = CType(dgvCarrito.SelectedRows(0).DataBoundItem, DataRowView).Row
        carrito.Rows.Remove(filaCarrito)

        ActualizarTotal()
        dgvCarrito.ClearSelection()
        dgvCarrito.CurrentCell = Nothing
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If carrito.Rows.Count > 0 Then
            Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de que desea cancelar la venta en curso?",
                                                            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta <> DialogResult.Yes Then Exit Sub
        End If

        LimpiarVenta()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If carrito.Rows.Count = 0 Then
            MessageBox.Show("Agregue al menos un producto a la venta.",
                            "Venta vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbMetodoPago.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el metodo de pago.",
                            "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbMetodoPago.Focus()
            Exit Sub
        End If

        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de que desea confirmar la venta?",
                                                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta <> DialogResult.Yes Then Exit Sub

        ' Filas que se van a guardar en detalles_venta (un producto puede ocupar varios lotes)
        Dim lineas As New DataTable()
        lineas.Columns.Add("id_prod_lote", GetType(Integer))
        lineas.Columns.Add("cantidad", GetType(Decimal))
        lineas.Columns.Add("precio", GetType(Decimal))
        lineas.Columns.Add("subtotal", GetType(Decimal))

        Dim totalVenta As Decimal = 0
        Dim idVenta As Long
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                ' ReadCommitted: cada lectura ve lo ultimo confirmado, incluso lo que vendio otro empleado
                Using tx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadCommitted)

                    ' Ordeno por producto para que dos ventas simultaneas bloqueen en el mismo orden
                    For Each fila As DataRow In carrito.Select("", "id_producto ASC")
                        Dim faltante As Decimal = 0

                        AsignarLotes(cn, tx, CInt(fila("id_producto")), CDec(fila("Cantidad")),
                                     CDec(fila("Precio")), lineas, faltante)

                        If faltante > 0 Then
                            tx.Rollback()
                            MessageBox.Show("Stock insuficiente de " & fila("Producto").ToString() & "." & vbCrLf &
                                            "Faltan " & faltante.ToString("0.###") & " " & fila("Unidad").ToString() & vbCrLf &
                                            "El stock cambio mientras armaba la venta. No se registro nada.",
                                            "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            CargarProductos(txtBuscar.Text.Trim)
                            Exit Sub
                        End If
                    Next

                    ' Cabecera de la venta (la fecha la pone la BD)
                    Dim insertarVenta As String =
                        "INSERT INTO caja (id_cliente, id_empleado, metodo_pago) " &
                        "VALUES (@id_cliente, @id_empleado, @metodo_pago);"

                    Using comando As New MySqlCommand(insertarVenta, cn, tx)
                        If CInt(cmbCliente.SelectedValue) = 0 Then
                            comando.Parameters.AddWithValue("@id_cliente", DBNull.Value)
                        Else
                            comando.Parameters.AddWithValue("@id_cliente", CInt(cmbCliente.SelectedValue))
                        End If
                        comando.Parameters.AddWithValue("@id_empleado", idEmpleadoActual)
                        comando.Parameters.AddWithValue("@metodo_pago", cmbMetodoPago.Text)

                        comando.ExecuteNonQuery()
                        idVenta = comando.LastInsertedId
                    End Using

                    ' Detalle: una fila por lote utilizado
                    Dim insertarDetalle As String =
                        "INSERT INTO detalles_venta (id_prod_lote, cantidad, precio_unitario, subtotal, id_venta) " &
                        "VALUES (@id_prod_lote, @cantidad, @precio_unitario, @subtotal, @id_venta);"

                    For Each linea As DataRow In lineas.Rows
                        Using comando As New MySqlCommand(insertarDetalle, cn, tx)
                            comando.Parameters.AddWithValue("@id_prod_lote", CInt(linea("id_prod_lote")))
                            comando.Parameters.AddWithValue("@cantidad", CDec(linea("cantidad")))
                            comando.Parameters.AddWithValue("@precio_unitario", CDec(linea("precio")))
                            comando.Parameters.AddWithValue("@subtotal", CDec(linea("subtotal")))
                            comando.Parameters.AddWithValue("@id_venta", idVenta)

                            comando.ExecuteNonQuery()
                        End Using

                        totalVenta += CDec(linea("subtotal"))
                    Next

                    ' Recien aca se guarda todo junto; si algo fallo antes, no se guarda nada
                    tx.Commit()
                End Using
            End Using

            Dim imprimir As DialogResult = MessageBox.Show("Venta registrada correctamente." & vbCrLf &
                                               "Total: " & totalVenta.ToString("C2") & vbCrLf & vbCrLf &
                                               "Desea imprimir el comprobante?",
                                               "Venta registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            LimpiarVenta()

            If imprimir = DialogResult.Yes Then
                MostrarComprobante(idVenta)
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al registrar la venta: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^

    '# COMPROBANTE ## COMPROBANTE ## COMPROBANTE ## COMPROBANTE ## COMPROBANTE ##

    ' Datos del comprobante, cargados al confirmar la venta y usados al dibujar la hoja
    Private comprobanteCabecera As DataTable
    Private comprobanteDetalle As DataTable
    Private indiceFila As Integer

    ' Carga desde la BD lo que se guardo, asi el comprobante coincide con la venta registrada
    Private Sub CargarComprobante(idVenta As Long)
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consultaCabecera As String =
                    "SELECT c.id_venta, c.fecha, c.metodo_pago, " &
                    "IFNULL(cl.nombre, 'Consumidor final') AS cliente, e.nombre AS empleado " &
                    "FROM caja AS c " &
                    "INNER JOIN empleados AS e ON e.id_empleado = c.id_empleado " &
                    "LEFT JOIN clientes AS cl ON cl.id_cliente = c.id_cliente " &
                    "WHERE c.id_venta = @id_venta;"

                ' Agrupo por producto y precio: un producto repartido en varios lotes sale en una sola linea
                Dim consultaDetalle As String =
                    "SELECT p.nombre, p.unidad_medida, dv.precio_unitario, " &
                    "SUM(dv.cantidad) AS cantidad, SUM(dv.subtotal) AS subtotal " &
                    "FROM detalles_venta AS dv " &
                    "INNER JOIN productos_lote AS pl ON pl.id_prod_lote = dv.id_prod_lote " &
                    "INNER JOIN productos AS p ON p.id_producto = pl.id_producto " &
                    "WHERE dv.id_venta = @id_venta " &
                    "GROUP BY p.id_producto, p.nombre, p.unidad_medida, dv.precio_unitario " &
                    "ORDER BY p.nombre;"

                comprobanteCabecera = New DataTable()
                Using cmd As New MySqlCommand(consultaCabecera, cn)
                    cmd.Parameters.AddWithValue("@id_venta", idVenta)
                    Using lector As MySqlDataReader = cmd.ExecuteReader()
                        comprobanteCabecera.Load(lector)
                    End Using
                End Using

                comprobanteDetalle = New DataTable()
                Using cmd As New MySqlCommand(consultaDetalle, cn)
                    cmd.Parameters.AddWithValue("@id_venta", idVenta)
                    Using lector As MySqlDataReader = cmd.ExecuteReader()
                        comprobanteDetalle.Load(lector)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar el comprobante: " & ex.Message)
        End Try
    End Sub

    ' Abre la vista previa del comprobante de la venta indicada
    Private Sub MostrarComprobante(idVenta As Long)
        CargarComprobante(idVenta)

        If comprobanteCabecera Is Nothing OrElse comprobanteCabecera.Rows.Count = 0 Then
            MessageBox.Show("No se encontro la venta para generar el comprobante.")
            Exit Sub
        End If

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        indiceFila = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Const ALTO_FILA As Integer = 28

        Dim g As Graphics = e.Graphics
        Dim marco As Rectangle = e.MarginBounds
        Dim centrado As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim derecha As New StringFormat() With {.Alignment = StringAlignment.Far}

        Dim cabecera As DataRow = comprobanteCabecera.Rows(0)

        ' Columnas de la tabla de productos
        Dim xProducto As Integer = marco.Left + 15
        Dim xCantidad As Integer = marco.Left + 330
        Dim xPrecio As Integer = marco.Left + 460
        Dim xSubtotal As Integer = marco.Right - 15

        Using fTitulo As New Font("Arial", 18, FontStyle.Bold),
              fNormal As New Font("Arial", 12, FontStyle.Regular),
              fNegrita As New Font("Arial", 12, FontStyle.Bold),
              lapizMarco As New Pen(Color.Black, 2)

            ' Recuadro alrededor de toda la informacion
            g.DrawRectangle(lapizMarco, marco)

            ' Encabezado
            g.DrawString("Comprobante de venta", fTitulo, Brushes.Black,
                         New RectangleF(marco.Left, marco.Top + 15, marco.Width, 40), centrado)
            g.DrawString("Nro. " & cabecera("id_venta").ToString(), fNegrita, Brushes.Black,
                         marco.Left + 15, marco.Top + 60)
            g.DrawString("Fecha: " & Convert.ToDateTime(cabecera("fecha")).ToString("dd/MM/yyyy HH:mm"),
                         fNormal, Brushes.Black, marco.Left + 15, marco.Top + 85)
            g.DrawString("Cliente: " & cabecera("cliente").ToString(), fNormal, Brushes.Black,
                         marco.Left + 15, marco.Top + 110)
            g.DrawString("Atendio: " & cabecera("empleado").ToString(), fNormal, Brushes.Black,
                         marco.Left + 15, marco.Top + 135)
            g.DrawString("Pago: " & cabecera("metodo_pago").ToString(), fNormal, Brushes.Black,
                         marco.Left + 15, marco.Top + 160)
            g.DrawLine(Pens.Black, marco.Left, marco.Top + 195, marco.Right, marco.Top + 195)

            ' Titulos de la tabla
            Dim y As Integer = marco.Top + 205
            g.DrawString("Producto", fNegrita, Brushes.Black, xProducto, y)
            g.DrawString("Cantidad", fNegrita, Brushes.Black, xCantidad, y)
            g.DrawString("Precio", fNegrita, Brushes.Black, xPrecio, y)
            g.DrawString("Subtotal", fNegrita, Brushes.Black,
                         New RectangleF(xSubtotal - 120, y, 120, ALTO_FILA), derecha)
            y += ALTO_FILA
            g.DrawLine(Pens.Gray, marco.Left + 15, y, marco.Right - 15, y)
            y += 8

            ' Una fila por producto
            Do While indiceFila < comprobanteDetalle.Rows.Count

                ' Si no entra otra fila (dejo lugar para el total), sigo en la siguiente hoja
                If y + ALTO_FILA > marco.Bottom - 80 Then Exit Do

                Dim fila As DataRow = comprobanteDetalle.Rows(indiceFila)

                g.DrawString(fila("nombre").ToString(), fNormal, Brushes.Black, xProducto, y)
                g.DrawString(Convert.ToDecimal(fila("cantidad")).ToString("0.###") & " " &
                             fila("unidad_medida").ToString(), fNormal, Brushes.Black, xCantidad, y)
                g.DrawString(Convert.ToDecimal(fila("precio_unitario")).ToString("C2"),
                             fNormal, Brushes.Black, xPrecio, y)
                g.DrawString(Convert.ToDecimal(fila("subtotal")).ToString("C2"), fNormal, Brushes.Black,
                             New RectangleF(xSubtotal - 120, y, 120, ALTO_FILA), derecha)

                y += ALTO_FILA
                indiceFila += 1   ' paso al siguiente producto
            Loop

            ' Si quedan productos, la impresion genera otra hoja
            e.HasMorePages = (indiceFila < comprobanteDetalle.Rows.Count)

            ' El total va solo en la ultima hoja
            If Not e.HasMorePages Then
                Dim total As Decimal = 0
                For Each fila As DataRow In comprobanteDetalle.Rows
                    total += Convert.ToDecimal(fila("subtotal"))
                Next

                g.DrawLine(Pens.Black, marco.Left + 15, marco.Bottom - 70, marco.Right - 15, marco.Bottom - 70)
                g.DrawString("TOTAL: " & total.ToString("C2"), fTitulo, Brushes.Black,
                             New RectangleF(marco.Left, marco.Bottom - 60, marco.Width - 15, 40), derecha)
            End If
        End Using
    End Sub

    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^
End Class