
Imports MySqlConnector
Imports ScottPlot

Public Class FrmDashboard

    Private inicioMes As DateTime
    Private inicioMesSiguiente As DateTime
    Private Const SQL_DISPONIBLE As String = "(pl.cantidad_inicial " &
        "- IFNULL((SELECT SUM(dv.cantidad) FROM detalles_venta AS dv WHERE dv.id_prod_lote = pl.id_prod_lote), 0) " &
        "- IFNULL((SELECT SUM(mm.cantidad) FROM mermas AS mm WHERE mm.id_prod_lote = pl.id_prod_lote), 0))"

    Private Sub FrmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fechahoy As String = DateTime.Today.ToString("dddd d 'de' MMMM 'de' yyyy")
        lblFecha.Text = "Resumen del día - " & fechahoy.Substring(0, 1).ToUpper() & fechahoy.Substring(1)
        Tema.AplicarTema(Me)
        pnlTarjetaProductos.BackColor = System.Drawing.Color.FromArgb(43, 47, 51)
        Label1.ForeColor = System.Drawing.Color.White
        Label1.Font = Fuente(14)
        lblCantidadProductos.ForeColor = System.Drawing.Color.White
        lblCantidadProductos.Font = Fuente(16)
        tmrActualizar.Interval = 10000
        tmrActualizar.Start()

        CargarDashboard()

    End Sub

    ' TARJETA 1: PRODUCTOS ACTIVOS
    Private Sub CargarProductosActivos(conexion As MySqlConnection)

        Dim consulta As String =
            "SELECT COUNT(*) " &
            "FROM productos " &
            "WHERE activo = 1;"

        Using comando As New MySqlCommand(consulta, conexion)

            Dim resultado As Object =
                comando.ExecuteScalar()

            lblCantidadProductos.Text =
                Convert.ToInt32(resultado).ToString()

        End Using

    End Sub



    '# EVENTOS


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        CargarDashboard()

    End Sub

    Private Sub tmrActualizar_Tick(
        sender As Object,
        e As EventArgs
    ) Handles tmrActualizar.Tick

        If Me.Visible Then
            CargarDashboard(True)
        End If

    End Sub

    '# PROCEDIMIENTOS

    Private Sub CargarDashboard(Optional silencioso As Boolean = False)

        inicioMes = New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
        inicioMesSiguiente = inicioMes.AddMonths(1)

        Try
            Using conexion As New MySqlConnection(
                ConexionBD.ConnectionString
            )

                conexion.Open()
                CargarProductosActivos(conexion)
                CargarValorInventario(conexion)
                CargarLotesPorVencer(conexion)
                CargarLotesVencidos(conexion)
                CargarPerdidaMermas(conexion)

                CargarGraficoStockCategoria(conexion)
                CargarGraficoMermas(conexion)
                CargarGraficoMotivos(conexion)
                CargarProximosVencer(conexion)

            End Using

        Catch ex As Exception

            ' En la actualizacion automatica no se muestra el error para no interrumpir
            If Not silencioso Then
                MessageBox.Show(
                    "No se pudo cargar el dashboard." &
                    Environment.NewLine & ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )
            End If

        End Try

    End Sub

    ' Lee un valor numerico de una consulta (conMes agrega los parametros @inicio y @fin)
    Private Sub LeerValor(
        conexion As MySqlConnection,
        consulta As String,
        ByRef valor As Decimal,
        Optional conMes As Boolean = False
    )

        Using comando As New MySqlCommand(consulta, conexion)

            If conMes Then
                comando.Parameters.AddWithValue("@inicio", inicioMes)
                comando.Parameters.AddWithValue("@fin", inicioMesSiguiente)
            End If

            valor = Convert.ToDecimal(comando.ExecuteScalar())

        End Using

    End Sub

    ' Lee pares nombre / valor para un grafico (la consulta debe devolver las columnas "nombre" y "valor")
    Private Sub LeerDatosGrafico(
        conexion As MySqlConnection,
        consulta As String,
        nombres As List(Of String),
        valores As List(Of Double),
        Optional conMes As Boolean = False
    )

        Using comando As New MySqlCommand(consulta, conexion)

            If conMes Then
                comando.Parameters.AddWithValue("@inicio", inicioMes)
                comando.Parameters.AddWithValue("@fin", inicioMesSiguiente)
            End If

            Using lector As MySqlDataReader = comando.ExecuteReader()

                While lector.Read()
                    nombres.Add(lector("nombre").ToString())
                    valores.Add(Convert.ToDouble(lector("valor")))
                End While

            End Using

        End Using

    End Sub

    ' Pinta la franja lateral y el numero de una tarjeta
    Private Sub ColorearTarjeta(
        franja As Panel,
        valor As System.Windows.Forms.Label,
        colorTarjeta As System.Drawing.Color
    )

        franja.BackColor = colorTarjeta
        valor.ForeColor = colorTarjeta

    End Sub

    ' TARJETA 1: VALOR DEL INVENTARIO (lotes vigentes, a precio de costo)
    Private Sub CargarValorInventario(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT IFNULL(SUM(" & SQL_DISPONIBLE & " * pl.costo), 0) " &
            "FROM productos_lote AS pl " &
            "WHERE pl.fecha_vencimiento IS NULL " &
            "OR pl.fecha_vencimiento >= CURDATE();"

        Dim valor As Decimal
        LeerValor(conexion, consulta, valor)

        lblValorInventario.Text = valor.ToString("C0")
        ColorearTarjeta(pnlFranjaInventario, lblValorInventario, System.Drawing.Color.ForestGreen)

    End Sub

    ' TARJETA 2: LOTES QUE VENCEN EN LOS PROXIMOS 3 DIAS
    Private Sub CargarLotesPorVencer(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT COUNT(*) " &
            "FROM productos_lote AS pl " &
            "WHERE pl.fecha_vencimiento BETWEEN CURDATE() " &
            "AND DATE_ADD(CURDATE(), INTERVAL 3 DAY) " &
            "AND " & SQL_DISPONIBLE & " > 0;"

        Dim valor As Decimal
        LeerValor(conexion, consulta, valor)

        lblPorVencer.Text = valor.ToString("0")

        If valor > 0 Then
            ColorearTarjeta(pnlFranjaPorVencer, lblPorVencer, System.Drawing.Color.DarkOrange)
        Else
            ColorearTarjeta(pnlFranjaPorVencer, lblPorVencer, System.Drawing.Color.ForestGreen)
        End If

    End Sub

    ' TARJETA 3: LOTES VENCIDOS CON STOCK PENDIENTES DE BAJA
    Private Sub CargarLotesVencidos(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT COUNT(*) " &
            "FROM productos_lote AS pl " &
            "WHERE pl.fecha_vencimiento < CURDATE() " &
            "AND " & SQL_DISPONIBLE & " > 0;"

        Dim valor As Decimal
        LeerValor(conexion, consulta, valor)

        lblVencidos.Text = valor.ToString("0")

        If valor > 0 Then
            ColorearTarjeta(pnlFranjaVencidos, lblVencidos, System.Drawing.Color.Firebrick)
        Else
            ColorearTarjeta(pnlFranjaVencidos, lblVencidos, System.Drawing.Color.ForestGreen)
        End If

    End Sub

    ' TARJETA 4: PERDIDA POR MERMAS DEL MES (cantidad x costo del lote)
    Private Sub CargarPerdidaMermas(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT IFNULL(SUM(m.cantidad * pl.costo), 0) " &
            "FROM mermas AS m " &
            "INNER JOIN productos_lote AS pl " &
            "ON pl.id_prod_lote = m.id_prod_lote " &
            "WHERE m.fecha >= @inicio " &
            "AND m.fecha < @fin;"

        Dim valor As Decimal
        LeerValor(conexion, consulta, valor, True)

        lblPerdidaMermas.Text = valor.ToString("C0")

        If valor > 0 Then
            ColorearTarjeta(pnlFranjaMermas, lblPerdidaMermas, System.Drawing.Color.Firebrick)
        Else
            ColorearTarjeta(pnlFranjaMermas, lblPerdidaMermas, System.Drawing.Color.ForestGreen)
        End If

    End Sub

    ' GRAFICO 1: VALOR DE STOCK POR CATEGORIA
    Private Sub CargarGraficoStockCategoria(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT c.nombre_categoria AS nombre, " &
            "SUM(" & SQL_DISPONIBLE & " * pl.costo) AS valor " &
            "FROM productos_lote AS pl " &
            "INNER JOIN productos AS p ON p.id_producto = pl.id_producto " &
            "INNER JOIN categorias AS c ON c.id_categoria = p.id_categoria " &
            "WHERE pl.fecha_vencimiento IS NULL " &
            "OR pl.fecha_vencimiento >= CURDATE() " &
            "GROUP BY c.id_categoria, c.nombre_categoria " &
            "HAVING valor > 0 " &
            "ORDER BY valor DESC;"

        Dim nombres As New List(Of String)
        Dim valores As New List(Of Double)

        LeerDatosGrafico(conexion, consulta, nombres, valores)

        DibujarGrafico(
            formsPlotStock,
            "Valor del stock por categoría",
            "Valor a costo ($)",
            nombres,
            valores,
            ScottPlot.Colors.ForestGreen
        )

    End Sub

    ' GRAFICO 2: CINCO PRODUCTOS CON MAS PERDIDA DEL MES
    Private Sub CargarGraficoMermas(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT p.nombre AS nombre, " &
            "SUM(m.cantidad * pl.costo) AS valor " &
            "FROM mermas AS m " &
            "INNER JOIN productos_lote AS pl " &
            "ON pl.id_prod_lote = m.id_prod_lote " &
            "INNER JOIN productos AS p " &
            "ON p.id_producto = pl.id_producto " &
            "WHERE m.fecha >= @inicio " &
            "AND m.fecha < @fin " &
            "GROUP BY p.id_producto, p.nombre " &
            "ORDER BY valor DESC " &
            "LIMIT 5;"

        Dim nombres As New List(Of String)
        Dim valores As New List(Of Double)

        LeerDatosGrafico(conexion, consulta, nombres, valores, True)

        DibujarGrafico(
            formsPlotMermas,
            "Productos con más pérdida del mes",
            "Valor perdido ($)",
            nombres,
            valores,
            ScottPlot.Colors.IndianRed
        )

    End Sub

    ' GRAFICO 3: PERDIDA DEL MES SEGUN EL MOTIVO DE LA MERMA
    Private Sub CargarGraficoMotivos(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT m.motivo AS nombre, " &
            "SUM(m.cantidad * pl.costo) AS valor " &
            "FROM mermas AS m " &
            "INNER JOIN productos_lote AS pl " &
            "ON pl.id_prod_lote = m.id_prod_lote " &
            "WHERE m.fecha >= @inicio " &
            "AND m.fecha < @fin " &
            "GROUP BY m.motivo " &
            "ORDER BY valor DESC;"

        Dim nombres As New List(Of String)
        Dim valores As New List(Of Double)

        LeerDatosGrafico(conexion, consulta, nombres, valores, True)

        DibujarGrafico(
            formsPlotMotivos,
            "Mermas del mes por motivo",
            "Valor perdido ($)",
            nombres,
            valores,
            ScottPlot.Colors.DarkOrange
        )

    End Sub

    ' LISTA: LOTES QUE VENCEN EN LOS PROXIMOS 7 DIAS
    Private Sub CargarProximosVencer(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT p.nombre AS Producto, pl.id_lote AS Lote, " &
            "pl.fecha_vencimiento AS Vencimiento, " &
            "DATEDIFF(pl.fecha_vencimiento, CURDATE()) AS Dias, " &
            SQL_DISPONIBLE & " AS Disponible, " &
            "p.unidad_medida AS Unidad " &
            "FROM productos_lote AS pl " &
            "INNER JOIN productos AS p ON p.id_producto = pl.id_producto " &
            "WHERE pl.fecha_vencimiento BETWEEN CURDATE() " &
            "AND DATE_ADD(CURDATE(), INTERVAL 7 DAY) " &
            "AND " & SQL_DISPONIBLE & " > 0 " &
            "ORDER BY pl.fecha_vencimiento, p.nombre;"

        Dim tabla As New DataTable()

        Using comando As New MySqlCommand(consulta, conexion)
            Using lector As MySqlDataReader = comando.ExecuteReader()
                tabla.Load(lector)
            End Using
        End Using

        dgvPorVencer.DataSource = tabla
        dgvPorVencer.Columns("Vencimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
        dgvPorVencer.Columns("Dias").HeaderText = "Días"
        dgvPorVencer.Columns("Disponible").DefaultCellStyle.Format = "0.###"

        dgvPorVencer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPorVencer.AllowUserToAddRows = False
        dgvPorVencer.RowHeadersVisible = False
        dgvPorVencer.ReadOnly = True
        dgvPorVencer.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPorVencer.MultiSelect = False

        ' Rojo suave: vence hoy o manana. Amarillo suave: faltan 2 o 3 dias
        For Each fila As DataGridViewRow In dgvPorVencer.Rows

            Dim dias As Integer = CInt(fila.Cells("Dias").Value)

            If dias <= 1 Then
                fila.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose
            ElseIf dias <= 3 Then
                fila.DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon
            End If

        Next

        dgvPorVencer.ClearSelection()
        dgvPorVencer.CurrentCell = Nothing

        If tabla.Rows.Count = 0 Then
            lblTituloPorVencer.Text = "Próximos a vencer (7 días): ninguno"
        Else
            lblTituloPorVencer.Text = "Próximos a vencer (7 días)"
        End If

    End Sub

    ' DIBUJA UN GRAFICO DE BARRAS CON SCOTTPLOT 5
    Private Sub DibujarGrafico(
        formulario As ScottPlot.WinForms.FormsPlot,
        titulo As String,
        etiquetaY As String,
        nombres As List(Of String),
        valores As List(Of Double),
        colorBarras As ScottPlot.Color
    )

        Dim grafico = formulario.Plot

        grafico.Clear()

        ' Fondo blanco para mejorar la legibilidad.
        grafico.FigureBackground.Color = ScottPlot.Colors.White
        grafico.DataBackground.Color = ScottPlot.Colors.White

        grafico.Title(titulo)
        grafico.Axes.Left.Label.Text = etiquetaY

        ' Sin datos: se deja el titulo con el aviso
        If nombres.Count = 0 Then
            grafico.Title(titulo & " (sin datos)")
            formulario.Refresh()
            Return
        End If

        Dim barras(nombres.Count - 1) As ScottPlot.Bar
        Dim marcas(nombres.Count - 1) As ScottPlot.Tick

        For i As Integer = 0 To nombres.Count - 1

            ' Cada barra muestra su valor encima
            barras(i) = New ScottPlot.Bar With {
                .Position = i,
                .Value = valores(i),
                .FillColor = colorBarras,
                .LineColor = colorBarras,
                .Label = valores(i).ToString("C0")
            }

            ' Etiqueta del eje X: el nombre en lugar del numero de barra
            marcas(i) = New ScottPlot.Tick(i, nombres(i))

        Next

        grafico.Add.Bars(barras)

        grafico.Axes.Bottom.TickGenerator =
            New ScottPlot.TickGenerators.NumericManual(marcas)
        grafico.Axes.Bottom.MajorTickStyle.Length = 0

        grafico.HideGrid()

        ' Las barras arrancan en el eje y queda lugar arriba para el valor.
        grafico.Axes.Margins(bottom:=0, top:=0.2)

        formulario.Refresh()

    End Sub

End Class