Imports MySqlConnector

Public Class Mermas

    'reemplazar despues id_empleado del usuario que inicio sesion (empleados.id_empleado)
    Private idEmpleadoActual As Integer = 1

    Private Const MOTIVO_VENCIMIENTO As String = "Vencimiento"

    '# PROCEDIMIENTOS

    Private Sub CargarLotes(Optional filtro As String = "")
        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                ' Lotes con stock (incluye los vencidos: ahi es donde hay que dar de baja)
                Dim consulta As String =
                    "SELECT pl.id_prod_lote, p.nombre AS Producto, p.unidad_medida AS Unidad, " &
                    "pl.id_lote AS Lote, pv.nombre AS Proveedor, pl.fecha_vencimiento AS Vencimiento, " &
                    "IF(pl.fecha_vencimiento < CURDATE(), 'Vencido', 'Vigente') AS Estado, " &
                    "pl.cantidad_inicial " &
                    "- IFNULL((SELECT SUM(dv.cantidad) FROM detalles_venta AS dv WHERE dv.id_prod_lote = pl.id_prod_lote), 0) " &
                    "- IFNULL((SELECT SUM(m.cantidad) FROM mermas AS m WHERE m.id_prod_lote = pl.id_prod_lote), 0) AS Disponible " &
                    "FROM productos_lote AS pl " &
                    "INNER JOIN productos AS p ON p.id_producto = pl.id_producto " &
                    "INNER JOIN lotes AS l ON l.id_lote = pl.id_lote " &
                    "INNER JOIN proveedores AS pv ON pv.id_proveedor = l.id_proveedor " &
                    "WHERE 1 = 1 "

                If Not String.IsNullOrWhiteSpace(filtro) Then
                    consulta &= "AND p.nombre LIKE @filtro "
                End If

                If chkSoloVencidos.Checked Then
                    consulta &= "AND pl.fecha_vencimiento < CURDATE() "
                End If

                consulta &= "HAVING Disponible > 0 ORDER BY pl.fecha_vencimiento IS NULL, pl.fecha_vencimiento, p.nombre;"

                Using comando As New MySqlCommand(consulta, cn)

                    If Not String.IsNullOrWhiteSpace(filtro) Then
                        comando.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    End If

                    Dim tabla As New DataTable()
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        tabla.Load(lector)
                    End Using

                    dgvLotes.DataSource = tabla
                    dgvLotes.Columns("id_prod_lote").Visible = False
                    dgvLotes.Columns("Vencimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
                    dgvLotes.Columns("Disponible").DefaultCellStyle.Format = "0.###"
                End Using
            End Using

            dgvLotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvLotes.AllowUserToAddRows = False
            dgvLotes.RowHeadersVisible = False
            dgvLotes.ReadOnly = True
            dgvLotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvLotes.MultiSelect = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar los lotes: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarHistorial()
        If dtpDesde.Value.Date > dtpHasta.Value.Date Then
            MessageBox.Show("La fecha Desde no puede ser mayor que la fecha Hasta.",
                            "Fechas invalidas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using cn As New MySqlConnection(ConexionBD.ConnectionString)
                cn.Open()

                ' Valor = cantidad x costo del lote
                Dim consulta As String =
                    "SELECT m.fecha AS Fecha, p.nombre AS Producto, pl.id_lote AS Lote, " &
                    "m.cantidad AS Cantidad, p.unidad_medida AS Unidad, m.motivo AS Motivo, " &
                    "e.nombre AS Empleado, m.cantidad * pl.costo AS Valor " &
                    "FROM mermas AS m " &
                    "INNER JOIN productos_lote AS pl ON pl.id_prod_lote = m.id_prod_lote " &
                    "INNER JOIN productos AS p ON p.id_producto = pl.id_producto " &
                    "INNER JOIN empleados AS e ON e.id_empleado = m.id_empleado " &
                    "WHERE m.fecha BETWEEN @desde AND @hasta " &
                    "ORDER BY m.fecha DESC, m.id_merma DESC;"

                Using comando As New MySqlCommand(consulta, cn)
                    comando.Parameters.AddWithValue("@desde", dtpDesde.Value.Date)
                    comando.Parameters.AddWithValue("@hasta", dtpHasta.Value.Date)

                    Dim tabla As New DataTable()
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        tabla.Load(lector)
                    End Using

                    dgvHistorial.DataSource = tabla
                    dgvHistorial.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
                    dgvHistorial.Columns("Cantidad").DefaultCellStyle.Format = "0.###"
                    dgvHistorial.Columns("Valor").DefaultCellStyle.Format = "C2"
                End Using
            End Using

            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvHistorial.AllowUserToAddRows = False
            dgvHistorial.RowHeadersVisible = False
            dgvHistorial.ReadOnly = True
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvHistorial.MultiSelect = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar el historial: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ValidarParaRegistrar()
        btnRegistrar.Enabled = dgvLotes.SelectedRows.Count > 0 AndAlso
            Not String.IsNullOrWhiteSpace(txtCantidad.Text) AndAlso
            cmbMotivo.SelectedIndex <> -1
    End Sub

    Private Sub ValidarParaDarDeBaja()
        btnBaja.Enabled = dgvLotes.SelectedRows.Count > 0 AndAlso
            dgvLotes.SelectedRows(0).Cells("Estado").Value.ToString() = "Vencido"
    End Sub

    Private Sub LimpiarCampos()
        txtCantidad.Clear()
        cmbMotivo.SelectedIndex = -1

        dgvLotes.ClearSelection()
        dgvLotes.CurrentCell = Nothing
        Me.ActiveControl = Nothing
    End Sub

    Private Sub RefrescarDatos()
        CargarLotes(txtBuscar.Text.Trim)
        CargarHistorial()
        LimpiarCampos()
    End Sub

    ' Registra la merma dentro de una transaccion, revalidando el stock del lote.
    ' Si bajaTotal es True, la cantidad es todo el saldo del lote.
    ' "guardada" queda en 0 si no se registro nada; "disponible" es el saldo del lote al momento de guardar.
    Private Sub GuardarMerma(idProdLote As Integer, cantidad As Decimal, motivo As String,
                             bajaTotal As Boolean, ByRef guardada As Decimal, ByRef disponible As Decimal)
        guardada = 0
        disponible = 0

        Using cn As New MySqlConnection(ConexionBD.ConnectionString)
            cn.Open()

            ' ReadCommitted: cada lectura ve lo ultimo confirmado, incluso una venta de otro empleado
            Using tx As MySqlTransaction = cn.BeginTransaction(IsolationLevel.ReadCommitted)

                ' 1) Bloqueo el lote: una venta de este lote espera a que termine esta merma
                Using cmdBloqueo As New MySqlCommand("SELECT id_prod_lote FROM productos_lote " &
                                                     "WHERE id_prod_lote = @id_prod_lote FOR UPDATE;", cn, tx)
                    cmdBloqueo.Parameters.AddWithValue("@id_prod_lote", idProdLote)
                    cmdBloqueo.ExecuteNonQuery()
                End Using

                ' 2) Saldo actual del lote: lo que entro - lo vendido - las mermas
                Dim consultaSaldo As String =
                    "SELECT pl.cantidad_inicial " &
                    "- IFNULL((SELECT SUM(dv.cantidad) FROM detalles_venta AS dv WHERE dv.id_prod_lote = pl.id_prod_lote), 0) " &
                    "- IFNULL((SELECT SUM(m.cantidad) FROM mermas AS m WHERE m.id_prod_lote = pl.id_prod_lote), 0) " &
                    "FROM productos_lote AS pl WHERE pl.id_prod_lote = @id_prod_lote;"

                Using comando As New MySqlCommand(consultaSaldo, cn, tx)
                    comando.Parameters.AddWithValue("@id_prod_lote", idProdLote)
                    disponible = Convert.ToDecimal(comando.ExecuteScalar())
                End Using

                If bajaTotal Then
                    cantidad = disponible
                End If

                ' Sin saldo o pidiendo mas de lo que hay: no se registra nada
                If cantidad <= 0 OrElse cantidad > disponible Then
                    tx.Rollback()
                    Exit Sub
                End If

                ' 3) Registro la merma (la fecha la pone la BD)
                Dim insertar As String =
                    "INSERT INTO mermas (cantidad, id_prod_lote, motivo, id_empleado) " &
                    "VALUES (@cantidad, @id_prod_lote, @motivo, @id_empleado);"

                Using comando As New MySqlCommand(insertar, cn, tx)
                    comando.Parameters.AddWithValue("@cantidad", cantidad)
                    comando.Parameters.AddWithValue("@id_prod_lote", idProdLote)
                    comando.Parameters.AddWithValue("@motivo", motivo)
                    comando.Parameters.AddWithValue("@id_empleado", idEmpleadoActual)
                    comando.ExecuteNonQuery()
                End Using

                tx.Commit()
                guardada = cantidad
            End Using
        End Using
    End Sub

    '# EVENTOS

    Private Sub Mermas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tema.AplicarTema(Me)

        cmbMotivo.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMotivo.Items.AddRange(New Object() {"Deterioro", "Marchitamiento", "Golpes",
                                               MOTIVO_VENCIMIENTO, "Diferencia de peso", "Otro"})
        cmbMotivo.SelectedIndex = -1

        txtBuscar.PlaceholderText = "Buscar producto..."
        txtCantidad.PlaceholderText = "Ej. 1,5"

        dtpDesde.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        dtpHasta.Value = Date.Today

        btnRegistrar.Enabled = False
        btnBaja.Enabled = False

        CargarLotes()
        CargarHistorial()
    End Sub

    Private Sub Mermas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dgvLotes.ClearSelection()
        dgvLotes.CurrentCell = Nothing
        dgvHistorial.ClearSelection()
        dgvHistorial.CurrentCell = Nothing
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        CargarLotes(txtBuscar.Text.Trim)
        dgvLotes.ClearSelection()
        dgvLotes.CurrentCell = Nothing
    End Sub

    Private Sub chkSoloVencidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloVencidos.CheckedChanged
        CargarLotes(txtBuscar.Text.Trim)
        dgvLotes.ClearSelection()
        dgvLotes.CurrentCell = Nothing
    End Sub

    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
        CargarHistorial()
    End Sub

    Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
        CargarHistorial()
    End Sub

    Private Sub dgvLotes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvLotes.SelectionChanged
        ValidarParaRegistrar()
        ValidarParaDarDeBaja()
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        ValidarParaRegistrar()
    End Sub

    Private Sub cmbMotivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMotivo.SelectedIndexChanged
        ValidarParaRegistrar()
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

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If dgvLotes.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un lote de la grilla.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If cmbMotivo.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el motivo de la merma.",
                            "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbMotivo.Focus()
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

        Dim fila As DataGridViewRow = dgvLotes.SelectedRows(0)
        Dim idProdLote As Integer = CInt(fila.Cells("id_prod_lote").Value)
        Dim producto As String = fila.Cells("Producto").Value.ToString()
        Dim unidad As String = fila.Cells("Unidad").Value.ToString()
        Dim disponibleGrilla As Decimal = CDec(fila.Cells("Disponible").Value)

        ' Solo los kg admiten decimales; unidades y atados van enteros
        If unidad.ToLower() <> "kg" AndAlso cantidad <> Math.Floor(cantidad) Then
            MessageBox.Show("Este producto se mide por " & unidad & ": ingrese una cantidad entera.",
                            "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        If cantidad > disponibleGrilla Then
            MessageBox.Show("La merma supera el stock del lote." & vbCrLf &
                            "Disponible: " & disponibleGrilla.ToString("0.###") & " " & unidad,
                            "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de que desea registrar la merma de " &
                                                        cantidad.ToString("0.###") & " " & unidad & " de " & producto & "?",
                                                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta <> DialogResult.Yes Then Exit Sub

        Try
            Dim guardada As Decimal
            Dim disponible As Decimal

            GuardarMerma(idProdLote, cantidad, cmbMotivo.Text, False, guardada, disponible)

            If guardada = 0 Then
                MessageBox.Show("No se registro la merma: el stock del lote cambio." & vbCrLf &
                                "Disponible actual: " & disponible.ToString("0.###") & " " & unidad,
                                "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CargarLotes(txtBuscar.Text.Trim)
                Exit Sub
            End If

            MessageBox.Show("Merma registrada correctamente.",
                            "Merma registrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefrescarDatos()

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al registrar la merma: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarDeBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
        If dgvLotes.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un lote vencido de la grilla.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim fila As DataGridViewRow = dgvLotes.SelectedRows(0)

        If fila.Cells("Estado").Value.ToString() <> "Vencido" Then
            MessageBox.Show("Solo se pueden dar de baja lotes vencidos.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim idProdLote As Integer = CInt(fila.Cells("id_prod_lote").Value)
        Dim producto As String = fila.Cells("Producto").Value.ToString()
        Dim unidad As String = fila.Cells("Unidad").Value.ToString()
        Dim disponibleGrilla As Decimal = CDec(fila.Cells("Disponible").Value)

        Dim respuesta As DialogResult = MessageBox.Show("Se registrara como merma por vencimiento todo el stock del lote: " &
                                                        disponibleGrilla.ToString("0.###") & " " & unidad & " de " & producto & "." & vbCrLf &
                                                        "Desea continuar?",
                                                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta <> DialogResult.Yes Then Exit Sub

        Try
            Dim guardada As Decimal
            Dim disponible As Decimal

            GuardarMerma(idProdLote, 0, MOTIVO_VENCIMIENTO, True, guardada, disponible)

            If guardada = 0 Then
                MessageBox.Show("El lote ya no tiene stock disponible.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarLotes(txtBuscar.Text.Trim)
                Exit Sub
            End If

            MessageBox.Show("Baja registrada: " & guardada.ToString("0.###") & " " & unidad & " de " & producto & ".",
                            "Baja registrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefrescarDatos()

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al registrar la baja: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class