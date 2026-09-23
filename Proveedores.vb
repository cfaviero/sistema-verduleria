Imports MySqlConnector

Public Class Proveedores
    'Declaro variables públicas (los valores vienen del form stock)
    Public idProductoSeleccionado As Integer
    Public nombreProductoSeleccionado As String

    Sub cargarCheckListProveedores()

        'Se establece el datasource en nothing para poder limpiar el checked
        cklProveedores.DataSource = Nothing
        cklProveedores.Items.Clear()

        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()


                Dim sql As String = "SELECT * FROM proveedores ORDER BY nombre;"

                Using cmd As New MySqlCommand(sql, cn)


                    Dim tabla As New DataTable

                    Using lector As MySqlDataReader = cmd.ExecuteReader
                        tabla.Load(lector)
                    End Using

                    'Paso la tabla al CheckedList
                    cklProveedores.DataSource = tabla

                    'Muestro solo el nombre y guardo el ID
                    cklProveedores.DisplayMember = "nombre"
                    cklProveedores.ValueMember = "id_proveedor"

                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try

    End Sub


    Sub MarcarProveedores()

        Try
            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()

                Dim sql As String = "SELECT * FROM productos_proveedores WHERE id_producto = @id_producto;"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue("@id_producto", idProductoSeleccionado)

                    Using rd As MySqlDataReader = cmd.ExecuteReader

                        While rd.Read()

                            Dim idProveedor As Integer = CInt(rd("id_proveedor"))

                            'Recorro el CheckedList
                            For i As Integer = 0 To cklProveedores.Items.Count - 1

                                'Obtengo los elementos de cada fila
                                Dim fila As DataRowView =
                                    DirectCast(cklProveedores.Items(i), DataRowView)


                                Dim clave As Integer = CInt(fila("id_proveedor"))

                                'Marco la fila si coincide
                                If clave = idProveedor Then
                                    cklProveedores.SetItemChecked(i, True)
                                End If

                            Next

                        End While

                    End Using

                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try

    End Sub


    Private Sub ProveedoresProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Muestro el producto seleccionado
        lblProducto.Text = "Producto: " & nombreProductoSeleccionado

        'Cargo lista de proveedores
        cargarCheckListProveedores()

        'Marco los proveedores que ya están relacionados
        MarcarProveedores()

    End Sub


    Private Sub btnGuardarProveedores_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Using cn As New MySqlConnection(ConnectionString)

                'Conecto a la BD
                cn.Open()

                'Inicio una transacción
                Using tx = cn.BeginTransaction


                    Dim sqlborrar As String =
                        "DELETE FROM productos_proveedores WHERE id_producto = @id_producto"

                    Using cmdborrar As New MySqlCommand(sqlborrar, cn, tx)

                        cmdborrar.Parameters.AddWithValue(
                            "@id_producto",
                            idProductoSeleccionado
                        )

                        cmdborrar.ExecuteNonQuery()

                    End Using




                    'Recorro los proveedores seleccionados
                    For Each item As DataRowView In cklProveedores.CheckedItems


                        Dim idProveedor As Integer =
                            CInt(item("id_proveedor"))


                        Dim sqlinsertar As String =
                            "INSERT INTO productos_proveedores " &
                            "(id_producto, id_proveedor) " &
                            "VALUES (@id_producto, @id_proveedor);"

                        Using cmdinsertar As New MySqlCommand(
                            sqlinsertar,
                            cn,
                            tx
                        )

                            cmdinsertar.Parameters.AddWithValue(
                                "@id_producto",
                                idProductoSeleccionado
                            )

                            cmdinsertar.Parameters.AddWithValue(
                                "@id_proveedor",
                                idProveedor
                            )

                            cmdinsertar.ExecuteNonQuery()

                        End Using

                    Next

                    'Confirmo la transacción
                    tx.Commit()

                End Using

            End Using

            MessageBox.Show("Proveedores guardados correctamente.")

        Catch ex As Exception

            MessageBox.Show("ERROR! " & ex.Message)

        End Try

    End Sub
    Private Sub clbProveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cklProveedores.SelectedIndexChanged
        cklProveedores.ClearSelected()
    End Sub
End Class