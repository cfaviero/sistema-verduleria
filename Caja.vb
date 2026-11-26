Imports System.Drawing.Printing
Imports MySqlConnector

Public Class Caja

    ' Carrito de un solo producto ingresadio
    Private carrito As New DataTable()
    'Empleado actual
    Private idEmpleadoActual As Integer = 0
    'Datos del comprobante que se cargan al confirmar la venta y usados para dibujar la oja
    Private comprobanteCabecera As DataTable
    Private comprobanteDetalle As DataTable
    Private indiceFila As Integer

    '# PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ## PROCEDIMIENTOS ##

    Private Sub CrearCarrito()
        'Agrego cada columna
        carrito.Columns.Add("id_producto", GetType(Integer))
        carrito.Columns.Add("Producto", GetType(String))
        carrito.Columns.Add("Unidad", GetType(String))
        carrito.Columns.Add("Cantidad", GetType(Decimal))
        carrito.Columns.Add("Precio", GetType(Decimal))
        carrito.Columns.Add("Subtotal", GetType(Decimal))
        'formatos
        dgvCarrito.DataSource = carrito
        dgvCarrito.Columns("id_producto").Visible = False
        dgvCarrito.Columns("Cantidad").DefaultCellStyle.Format = "0.###"
        dgvCarrito.Columns("Precio").DefaultCellStyle.Format = "C2"
        dgvCarrito.Columns("Subtotal").DefaultCellStyle.Format = "C2"
        'Configuraciones
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

                ' Disponiblesolo de lotes no vencidos
                Dim consulta As String = "SELECT p.id_producto, p.nombre AS Producto, p.unidad_medida AS Unidad, " &
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
                'con filtro
                If Not String.IsNullOrWhiteSpace(filtro) Then
                    consulta &= "AND p.nombre LIKE @filtro "
                End If
                'Disponibilidad mayor a cero
                consulta &= "HAVING Disponible > 0 ORDER BY p.nombre"

                Using comando As New MySqlCommand(consulta, cn)
                    'Verifica que haya filtro
                    If Not String.IsNullOrWhiteSpace(filtro) Then
                        comando.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    End If

                    Dim tabla As New DataTable()
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    'Formato
                    dgvProductos.DataSource = tabla
                    dgvProductos.Columns("id_producto").Visible = False
                    dgvProductos.Columns("Precio").DefaultCellStyle.Format = "C2"
                    dgvProductos.Columns("Disponible").DefaultCellStyle.Format = "0.###"
                End Using
            End Using
            'Configuraciones
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

                    'id 0 de venta consumidor final no registrado
                    Dim mostrador As DataRow = tabla.NewRow()
                    mostrador("id_cliente") = 0
                    mostrador("nombre") = "Consumidor final"
                    tabla.Rows.InsertAt(mostrador, 0)

                    cmbCliente.DisplayMember = "nombre"
                    cmbCliente.ValueMember = "id_cliente"
                    cmbCliente.DataSource = tabla
                End Using
            End Using
            'Por defecto consumidor final
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
        btnAgregar.Enabled = dgvProductos.SelectedRows.Count > 0 AndAlso Not String.IsNullOrWhiteSpace(txtCantidad.Text)
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

    ' Reparte la cantidad pedida entre los lotes del producto primero los que vencen antes.
    Private Sub AsignarLotes(cn As MySqlConnection, tx As MySqlTransaction, idProducto As Integer, cantidad As Decimal, precio As Decimal, lineas As DataTable, ByRef faltante As Decimal)

        'Bloqueo los lotes del producto: otra venta del mismo producto espera a que termine esta
        Using cmdBloqueo As New MySqlCommand("SELECT id_prod_lote FROM productos_lote " & "WHERE id_producto = @id_producto FOR UPDATE;", cn, tx)
            cmdBloqueo.Parameters.AddWithValue("@id_producto", idProducto)
            cmdBloqueo.ExecuteNonQuery()
        End Using

        'Lotes con stock no vencidos ordenados por vencimiento (los que no vencen van ordenados apra el final)
        Dim consulta As String = "SELECT pl.id_prod_lote, " &
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

        'Agarro de cada lote lo que haga falta hasta completar la cantidad
        Dim pendiente As Decimal = cantidad

        For Each lote As DataRow In lotes.Rows
            If pendiente <= 0 Then Exit For

            Dim tomar As Decimal = Math.Min(pendiente, CDec(lote("disponible")))

            Dim nueva As DataRow = lineas.NewRow()
            nueva("id_prod_lote") = CInt(lote("id_prod_lote"))
            nueva("cantidad") = tomar
            nueva("precio") = precio
            'redondero
            nueva("subtotal") = Math.Round(tomar * precio, 2, MidpointRounding.AwayFromZero)
            lineas.Rows.Add(nueva)

            pendiente -= tomar
        Next

        faltante = pendiente
    End Sub

    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^
    '# EVENTOS ## EVENTOS ## ## EVENTOS ## ## EVENTOS ## ## EVENTOS ## ## EVENTOS ## ## EVENTOS ##

    Private Sub Caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Aplico temas
        Tema.AplicarTema(Me)
        'Creo carrito
        CrearCarrito()
        'Cargo productos
        CargarProductos()
        'Cargo Clientes
        CargarClientes()
        'Cargo los metodos de pago
        cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMetodoPago.Items.AddRange(New Object() {"Efectivo", "Transferencia"})
        cmbMetodoPago.SelectedIndex = -1

        txtBuscar.PlaceholderText = "Buscar producto..."
        txtCantidad.PlaceholderText = "Ej. 1,5"
        'Desactivo botones hasta realizar accion
        btnAgregar.Enabled = False
        btnQuitar.Enabled = False
        btnConfirmar.Enabled = False

        ActualizarTotal()
    End Sub

    Private Sub Caja_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Limpieza y deseleccion
        dgvProductos.ClearSelection()
        dgvProductos.CurrentCell = Nothing
        dgvCarrito.ClearSelection()
        dgvCarrito.CurrentCell = Nothing
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        'Busqueda ylimpieza
        CargarProductos(txtBuscar.Text.Trim)
        dgvProductos.ClearSelection()
        dgvProductos.CurrentCell = Nothing
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        'Para buscar con enter sin necesidad de click
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        ValidarParaAgregar()
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        'Se limuita la agregacion de teclas
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
        'Para buscar con enter sin necesidad de click
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
            MessageBox.Show("Seleccione un producto de la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim cantidad As Decimal
        If Not Decimal.TryParse(txtCantidad.Text, cantidad) Then
            MessageBox.Show("Ingrese una cantidad valida.", "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        'Redondeo antes de validar
        cantidad = Math.Round(cantidad, 3, MidpointRounding.AwayFromZero)

        If cantidad <= 0 Then
            MessageBox.Show("La cantidad debe ser mayor a 0.", "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        Dim fila As DataGridViewRow = dgvProductos.SelectedRows(0)
        Dim idProducto As Integer = CInt(fila.Cells("id_producto").Value)
        Dim nombre As String = fila.Cells("Producto").Value.ToString()
        Dim unidad As String = fila.Cells("Unidad").Value.ToString()
        Dim precio As Decimal = CDec(fila.Cells("Precio").Value)
        Dim disponible As Decimal = CDec(fila.Cells("Disponible").Value)

        'Verificaciones de decimales para los kg unidades y atados son enteros
        If unidad.ToLower() <> "kg" AndAlso cantidad <> Math.Floor(cantidad) Then
            MessageBox.Show("Este producto se vende por " & unidad & ": ingrese una cantidad entera.", "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        'Si el producto ya esta en la venta se le suma a lo que ya hay
        Dim existentes() As DataRow = carrito.Select("id_producto = " & idProducto)
        Dim enCarrito As Decimal = 0
        If existentes.Length > 0 Then
            enCarrito = CDec(existentes(0)("Cantidad"))
        End If

        If enCarrito + cantidad > disponible Then
            MessageBox.Show("Stock insuficiente de " & nombre & "." & vbCrLf & "Disponible: " & disponible.ToString("0.###") & " " & unidad & vbCrLf &
                            "Ya en esta venta: " & enCarrito.ToString("0.###") & " " & unidad, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        If existentes.Length > 0 Then
            Dim linea As DataRow = existentes(0)
            linea("Cantidad") = enCarrito + cantidad
            linea("Subtotal") = Math.Round(CDec(linea("Cantidad")) * precio, 2, MidpointRounding.AwayFromZero)
        Else
            carrito.Rows.Add(idProducto, nombre, unidad, cantidad, precio, Math.Round(cantidad * precio, 2, MidpointRounding.AwayFromZero))
        End If

        ActualizarTotal()
        txtCantidad.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        'Verifico que se selecciono
        If dgvCarrito.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione una linea de la venta.")
            Exit Sub
        End If
        'Agrego a variable referencia a la fila a boorar
        Dim filaCarrito As DataRow = CType(dgvCarrito.SelectedRows(0).DataBoundItem, DataRowView).Row
        carrito.Rows.Remove(filaCarrito)
        'Actualizo tabla
        ActualizarTotal()
        'Deselecciono grilla
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
        'Validaciones
        If carrito.Rows.Count = 0 Then
            MessageBox.Show("Agregue al menos un producto a la venta.", "Venta vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If cmbMetodoPago.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el metodo de pago.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbMetodoPago.Focus()
            Exit Sub
        End If
        'Confirmar la venta
        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de que desea confirmar la venta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta <> DialogResult.Yes Then Exit Sub

        Dim lineas As New DataTable()
        lineas.Columns.Add("id_prod_lote", GetType(Integer))
        lineas.Columns.Add("cantidad", GetType(Decimal))
        lineas.Columns.Add("precio", GetType(Decimal))
        lineas.Columns.Add("subtotal", GetType(Decimal))

        Dim totalVenta As Decimal = 0
        Dim idVenta As Long
        'Se realiza la transaccion
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Using tx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadCommitted)

                    'Ordeno por producto para que dos ventas simultaneas bloqueen en el mismo orden
                    For Each fila As DataRow In carrito.Select("", "id_producto ASC")
                        Dim faltante As Decimal = 0

                        AsignarLotes(cn, tx, CInt(fila("id_producto")), CDec(fila("Cantidad")), CDec(fila("Precio")), lineas, faltante)
                        If faltante > 0 Then
                            tx.Rollback()
                            MessageBox.Show("Stock insuficiente de " & fila("Producto").ToString() & "." & vbCrLf & "Faltan " & faltante.ToString("0.###") & " " &
                                            fila("Unidad").ToString() & vbCrLf & "El stock cambio mientras armaba la venta. No se registro nada.", "Stock insuficiente",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            CargarProductos(txtBuscar.Text.Trim)
                            Exit Sub
                        End If
                    Next

                    'Comando para insertar trans
                    Dim insertarVenta As String = "INSERT INTO caja (id_cliente, id_empleado, metodo_pago) " &
                        "VALUES (@id_cliente, @id_empleado, @metodo_pago);"

                    Using comando As New MySqlCommand(insertarVenta, cn, tx)
                        If CInt(cmbCliente.SelectedValue) = 0 Then
                            comando.Parameters.AddWithValue("@id_cliente", DBNull.Value)
                        Else
                            comando.Parameters.AddWithValue("@id_cliente", CInt(cmbCliente.SelectedValue))
                        End If
                        comando.Parameters.AddWithValue("@id_empleado", Sesion.idEmpleado)
                        comando.Parameters.AddWithValue("@metodo_pago", cmbMetodoPago.Text)

                        comando.ExecuteNonQuery()
                        idVenta = comando.LastInsertedId
                    End Using

                    'Una fila por lote utilizado
                    Dim insertarDetalle As String = "INSERT INTO detalles_venta (id_prod_lote, cantidad, precio_unitario, subtotal, id_venta) " &
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
                    'Se guarda
                    tx.Commit()
                End Using
            End Using

            Dim imprimir As DialogResult = MessageBox.Show("Venta registrada correctamente." & vbCrLf & "Total: " & totalVenta.ToString("C2") & vbCrLf & vbCrLf &
                                                           "Desea imprimir el comprobante?", "Venta registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            LimpiarVenta()
            'Verificacion de impresion de comprobante
            If imprimir = DialogResult.Yes Then
                MostrarComprobante(idVenta)
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al registrar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^


    '# COMPROBANTE ## COMPROBANTE ## COMPROBANTE ## COMPROBANTE ## COMPROBANTE ##
    'Cargo desde la BD lo que se guardo para que el comprobante coincida con la venta actual
    Private Sub CargarComprobante(idVenta As Long)
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                Dim consultaCabecera As String = "SELECT c.id_venta, c.fecha, c.metodo_pago, " &
                    "IFNULL(cl.nombre, 'Consumidor final') AS cliente, e.nombre AS empleado " &
                    "FROM caja AS c " &
                    "INNER JOIN empleados AS e ON e.id_empleado = c.id_empleado " &
                    "LEFT JOIN clientes AS cl ON cl.id_cliente = c.id_cliente " &
                    "WHERE c.id_venta = @id_venta"

                'Un producto repartido en varios lotes sale en una sola linea
                Dim consultaDetalle As String = "SELECT p.nombre, p.unidad_medida, dv.precio_unitario, " &
                    "SUM(dv.cantidad) AS cantidad, SUM(dv.subtotal) AS subtotal " &
                    "FROM detalles_venta AS dv " &
                    "INNER JOIN productos_lote AS pl ON pl.id_prod_lote = dv.id_prod_lote " &
                    "INNER JOIN productos AS p ON p.id_producto = pl.id_producto " &
                    "WHERE dv.id_venta = @id_venta " &
                    "GROUP BY p.id_producto, p.nombre, p.unidad_medida, dv.precio_unitario " &
                    "ORDER BY p.nombre"

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

    'Abre vista previa del comprobante
    Private Sub MostrarComprobante(idVenta As Long)
        CargarComprobante(idVenta)
        If comprobanteCabecera Is Nothing OrElse comprobanteCabecera.Rows.Count = 0 Then
            MessageBox.Show("No se encontro la venta para generar el comprobante.")
            Exit Sub
        End If

        'Se carga y muestra el comprobante en pantalla completa
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        'Se verifica para que cada impresion comience desde el comienzo
        indiceFila = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Const ALTO_CABECERA As Integer = 90
        Const ALTO_TITULOS As Integer = 32
        Const ALTO_FILA As Integer = 30
        Const ALTO_TOTAL As Integer = 50

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

        Dim marco As Rectangle = e.MarginBounds
        Dim cabecera As DataRow = comprobanteCabecera.Rows(0)

        'Paleta (verde del login)
        Dim colVerde As Color = ColorTranslator.FromHtml("#50C878")
        Dim colVerdeOscuro As Color = ColorTranslator.FromHtml("#1F6B3F")
        Dim colVerdeClaro As Color = ColorTranslator.FromHtml("#EAF7EF")
        Dim colTexto As Color = ColorTranslator.FromHtml("#222222")
        Dim colGris As Color = ColorTranslator.FromHtml("#777777")
        Dim colLinea As Color = ColorTranslator.FromHtml("#DDDDDD")

        'Formatos de texto
        Dim fmtIzq As New StringFormat() With {.LineAlignment = StringAlignment.Center,
                                           .Trimming = StringTrimming.EllipsisCharacter,
                                           .FormatFlags = StringFormatFlags.NoWrap}
        Dim fmtDer As New StringFormat() With {.Alignment = StringAlignment.Far,
                                           .LineAlignment = StringAlignment.Center}

        Using fTitulo As New Font("Segoe UI", 20, FontStyle.Bold),
          fNro As New Font("Segoe UI", 14, FontStyle.Bold),
          fEtiqueta As New Font("Segoe UI", 9, FontStyle.Regular),
          fValor As New Font("Segoe UI", 11, FontStyle.Regular),
          fTitulosTabla As New Font("Segoe UI", 10, FontStyle.Bold),
          fFila As New Font("Segoe UI", 11, FontStyle.Regular),
          fTotal As New Font("Segoe UI", 18, FontStyle.Bold),
          bVerde As New SolidBrush(colVerde),
          bVerdeOscuro As New SolidBrush(colVerdeOscuro),
          bVerdeClaro As New SolidBrush(colVerdeClaro),
          bTexto As New SolidBrush(colTexto),
          bGris As New SolidBrush(colGris),
          pLinea As New Pen(colLinea, 1)

            '# ENCABEZADO
            g.FillRectangle(bVerde, marco.Left, marco.Top, marco.Width, ALTO_CABECERA)

            'Logo sobre cuadrado blanco
            Dim lado As Integer = ALTO_CABECERA - 20
            Dim rInsignia As New Rectangle(marco.Left + 15, marco.Top + 10, lado, lado)
            g.FillRectangle(Brushes.White, rInsignia)

            'Se recorta el espacio transparente que rodea al logo para que se vea mas grande
            Dim origenLogo As New Rectangle(350, 32, 710, 710)
            Dim destinoLogo As New Rectangle(rInsignia.X + 4, rInsignia.Y + 4, lado - 8, lado - 8)
            Using logo As Image = My.Resources.LogoVerduleria
                g.DrawImage(logo, destinoLogo, origenLogo, GraphicsUnit.Pixel)
            End Using

            'Titulo junto al logo y numero a la derecha
            g.DrawString("Comprobante de venta", fTitulo, Brushes.White,
                     New RectangleF(rInsignia.Right + 15, marco.Top, marco.Width \ 2 + 60, ALTO_CABECERA), fmtIzq)
            g.DrawString("Nro. " & cabecera("id_venta").ToString(), fNro, Brushes.White,
                     New RectangleF(marco.Left, marco.Top, marco.Width - 20, ALTO_CABECERA), fmtDer)

            '# DATOS (dos columnas: etiqueta gris y valor debajo)
            Dim xCol1 As Integer = marco.Left + 20
            Dim xCol2 As Integer = marco.Left + marco.Width \ 2 + 20
            Dim anchoDato As Single = marco.Width \ 2 - 40
            Dim y As Integer = marco.Top + ALTO_CABECERA + 20

            Dim dibujarDato = Sub(etiqueta As String, valor As String, x As Integer, yy As Integer)
                                  g.DrawString(etiqueta.ToUpper(), fEtiqueta, bGris, x, yy)
                                  g.DrawString(valor, fValor, bTexto, New RectangleF(x, yy + 16, anchoDato, 24), fmtIzq)
                              End Sub

            dibujarDato("Fecha", Convert.ToDateTime(cabecera("fecha")).ToString("dd/MM/yyyy HH:mm"), xCol1, y)
            dibujarDato("Cliente", cabecera("cliente").ToString(), xCol1, y + 50)
            dibujarDato("Atendió", Sesion.descripcion.ToString(), xCol2, y)
            dibujarDato("Pago", cabecera("metodo_pago").ToString(), xCol2, y + 50)
            y += 110

            '# TABLA
            Dim rProducto As New RectangleF(marco.Left + 20, 0, 230, ALTO_FILA)
            Dim xCantidad As Integer = marco.Left + 260
            Dim xPrecio As Integer = marco.Left + 380
            Dim xSubtotal As Integer = marco.Right - 130

            g.FillRectangle(bVerdeClaro, marco.Left, y, marco.Width, ALTO_TITULOS)
            g.DrawString("Producto", fTitulosTabla, bVerdeOscuro, New RectangleF(rProducto.X, y, rProducto.Width, ALTO_TITULOS), fmtIzq)
            g.DrawString("Cantidad", fTitulosTabla, bVerdeOscuro, New RectangleF(xCantidad, y, 110, ALTO_TITULOS), fmtDer)
            g.DrawString("Precio", fTitulosTabla, bVerdeOscuro, New RectangleF(xPrecio, y, 110, ALTO_TITULOS), fmtDer)
            g.DrawString("Subtotal", fTitulosTabla, bVerdeOscuro, New RectangleF(xSubtotal, y, 110, ALTO_TITULOS), fmtDer)
            y += ALTO_TITULOS

            Do While indiceFila < comprobanteDetalle.Rows.Count
                'Si no entra otra fila (dejando lugar al total) sigo en la hoja siguiente
                If y + ALTO_FILA > marco.Bottom - (ALTO_TOTAL + 30) Then Exit Do

                Dim fila As DataRow = comprobanteDetalle.Rows(indiceFila)

                g.DrawString(fila("nombre").ToString(), fFila, bTexto, New RectangleF(rProducto.X, y, rProducto.Width, ALTO_FILA), fmtIzq)
                g.DrawString(Convert.ToDecimal(fila("cantidad")).ToString("0.###") & " " & fila("unidad_medida").ToString(),
                         fFila, bTexto, New RectangleF(xCantidad, y, 110, ALTO_FILA), fmtDer)
                g.DrawString(Convert.ToDecimal(fila("precio_unitario")).ToString("C2"),
                         fFila, bTexto, New RectangleF(xPrecio, y, 110, ALTO_FILA), fmtDer)
                g.DrawString(Convert.ToDecimal(fila("subtotal")).ToString("C2"),
                         fFila, bTexto, New RectangleF(xSubtotal, y, 110, ALTO_FILA), fmtDer)

                y += ALTO_FILA
                g.DrawLine(pLinea, marco.Left + 20, y, marco.Right - 20, y)
                indiceFila += 1
            Loop

            e.HasMorePages = (indiceFila < comprobanteDetalle.Rows.Count)

            '# TOTAL (solo en la última hoja, debajo de la última fila)
            If Not e.HasMorePages Then
                Dim total As Decimal = 0
                For Each fila As DataRow In comprobanteDetalle.Rows
                    total += Convert.ToDecimal(fila("subtotal"))
                Next

                Dim rTotal As New Rectangle(marco.Right - 300, y + 20, 300, ALTO_TOTAL)
                g.FillRectangle(bVerde, rTotal)
                g.DrawString("TOTAL", fTitulosTabla, Brushes.White,
                         New RectangleF(rTotal.X + 15, rTotal.Y, 100, ALTO_TOTAL), fmtIzq)
                g.DrawString(total.ToString("C2"), fTotal, Brushes.White,
                         New RectangleF(rTotal.X, rTotal.Y, rTotal.Width - 15, ALTO_TOTAL), fmtDer)
            End If
        End Using

        fmtIzq.Dispose()
        fmtDer.Dispose()
    End Sub

    '# ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^ # ^^^
End Class