
Imports MySqlConnector
Imports ScottPlot

Public Class FrmDashboard

    Private Sub FrmDashboard_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load



        CargarDashboard()

    End Sub

    Private Sub CargarDashboard()

        Try
            Using conexion As New MySqlConnection(
                ConexionBD.ConnectionString
            )

                conexion.Open()

                CargarProductosActivos(conexion)
                CargarMermasDelMes(conexion)
                CargarGraficoMermas(conexion)

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cargar el dashboard." &
                Environment.NewLine & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' TARJETA 1: PRODUCTOS ACTIVOS
    Private Sub CargarProductosActivos(
        conexion As MySqlConnection
    )

        Dim consulta As String =
            "SELECT COUNT(*) " &
            "FROM productos " &
            "WHERE activo = 1;"

        Using comando As New MySqlCommand(
            consulta, conexion
        )

            Dim resultado As Object =
                comando.ExecuteScalar()

            lblCantidadProductos.Text =
                Convert.ToInt32(resultado).ToString()

        End Using

    End Sub

    ' TARJETA 2: REGISTROS DE MERMA DEL MES
    Private Sub CargarMermasDelMes(
        conexion As MySqlConnection
    )

        Dim inicioMes As New DateTime(
            DateTime.Today.Year,
            DateTime.Today.Month,
            1
        )

        Dim inicioMesSiguiente As DateTime =
            inicioMes.AddMonths(1)

        Dim consulta As String =
            "SELECT COUNT(*) " &
            "FROM mermas " &
            "WHERE fecha >= @inicio " &
            "AND fecha < @fin;"

        Using comando As New MySqlCommand(
            consulta, conexion
        )

            comando.Parameters.AddWithValue(
                "@inicio", inicioMes
            )

            comando.Parameters.AddWithValue(
                "@fin", inicioMesSiguiente
            )

            Dim resultado As Object =
                comando.ExecuteScalar()

            lblCantidadMermas.Text =
                Convert.ToInt32(resultado).ToString()

        End Using

    End Sub

    ' GRAFICO: CINCO PRODUCTOS CON MAS MERMA DEL MES
    Private Sub CargarGraficoMermas(
        conexion As MySqlConnection
    )

        Dim inicioMes As New DateTime(
            DateTime.Today.Year,
            DateTime.Today.Month,
            1
        )

        Dim inicioMesSiguiente As DateTime =
            inicioMes.AddMonths(1)

        Dim consulta As String =
            "SELECT p.nombre, p.unidad_medida, " &
            "SUM(m.cantidad) AS total_merma " &
            "FROM mermas m " &
            "INNER JOIN productos_lote pl " &
            "ON m.id_prod_lote = pl.id_prod_lote " &
            "INNER JOIN productos p " &
            "ON pl.id_producto = p.id_producto " &
            "WHERE m.fecha >= @inicio " &
            "AND m.fecha < @fin " &
            "GROUP BY p.id_producto, p.nombre, p.unidad_medida " &
            "ORDER BY total_merma DESC " &
            "LIMIT 5;"

        Dim nombres As New List(Of String)
        Dim cantidades As New List(Of Double)

        Using comando As New MySqlCommand(
            consulta, conexion
        )

            comando.Parameters.AddWithValue(
                "@inicio", inicioMes
            )

            comando.Parameters.AddWithValue(
                "@fin", inicioMesSiguiente
            )

            Using lector As MySqlDataReader =
                comando.ExecuteReader()

                While lector.Read()

                    ' Incluimos la unidad en la etiqueta.
                    Dim nombreProducto As String =
                        lector("nombre").ToString()

                    Dim unidad As String =
                        lector("unidad_medida").ToString()

                    nombres.Add(
                        nombreProducto & " (" & unidad & ")"
                    )

                    cantidades.Add(
                        Convert.ToDouble(
                            lector("total_merma")
                        )
                    )

                End While

            End Using

        End Using

        DibujarGrafico(nombres, cantidades)

    End Sub

    ' DIBUJA EL GRAFICO CON SCOTTPLOT 5
    Private Sub DibujarGrafico(
        nombres As List(Of String),
        cantidades As List(Of Double)
    )

        Dim grafico = formsPlotMermas.Plot

        grafico.Clear()

        If nombres.Count = 0 Then
            formsPlotMermas.Refresh()
            Return
        End If

        Dim barras(nombres.Count - 1) As ScottPlot.Bar
        Dim posiciones(nombres.Count - 1) As Double

        For i As Integer = 0 To nombres.Count - 1

            posiciones(i) = i

            barras(i) = New ScottPlot.Bar With {
                .Position = i,
                .Value = cantidades(i),
                .FillColor = ScottPlot.Colors.ForestGreen,
                .LineColor = ScottPlot.Colors.ForestGreen
            }

        Next

        grafico.Add.Bars(barras)

        ' Etiquetas con los nombres de los productos.


        grafico.Title(
            "Productos con más mermas del mes"
        )

        grafico.Axes.Left.Label.Text =
            "Cantidad registrada"

        ' Márgenes para que se vean bien las etiquetas.
        grafico.Axes.Margins(bottom:=0.1, top:=0.15)

        ' Fondo blanco para mejorar la legibilidad.
        grafico.FigureBackground.Color =
            ScottPlot.Colors.White

        grafico.DataBackground.Color =
            ScottPlot.Colors.White

        formsPlotMermas.Refresh()

    End Sub

End Class
