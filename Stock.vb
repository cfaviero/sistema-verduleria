Imports System.CodeDom
Imports MySqlConnector

Public Class Stock

    Sub CargarGrilla(Optional filtro As String = "")
        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim consulta As String
                consulta = "SELECT nombre as 'Producto', descripcion as 'Descripcion', precio_unitario as 'Precio Unitario', stock as 'Stock' FROM productos "

                Using comando As New MySqlCommand(consulta, cn)

                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        Dim tabla As New DataTable
                        tabla.Load(lector)
                        dgvStock.DataSource = tabla
                    End Using
                End Using

            End Using
        Catch ex As Exception

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
        Catch ex As Exception
            MessageBox.Show("Error al cargar las categorias: " & ex.Message)
        End Try

    End Sub

    Sub LimpiarCampos()
        txtNombre.Clear()
        txtPrecio.Clear()
        txtStock.Clear()
        cmbCategoria.SelectedIndex = -1
    End Sub

    Private Sub stock_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarGrilla()
        CargarCategorias()
        LimpiarCampos()

    End Sub
End Class