Imports MySqlConnector

Public Class Contra
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property UsuarioNuevo As String
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property descNuevo As String
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property rolNuevo As String
    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim respuesta As DialogResult
        respuesta = MessageBox.Show("Seguro que desea crear este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


        If respuesta <> DialogResult.Yes Then Exit Sub

        Try
            Dim salt As String = CrearSalt()
            Dim hash As String = CrearHash(txtContra.Text, salt)

            Using cn As New MySqlConnection(ConnectionString)
                cn.Open()
                Dim consulta As String = "INSERT INTO usuarios " &
                    "(usuario, descripcion, clavehash, salt, id_rol, activo) " &
                    "VALUES (@usuario, @descripcion, @clavehash, @salt, @rol, 1)"

                Using comando As New MySqlCommand(consulta, cn)

                    comando.Parameters.AddWithValue("@usuario", UsuarioNuevo.Trim())
                    comando.Parameters.AddWithValue("@descripcion", descNuevo.Trim())
                    comando.Parameters.AddWithValue("@clavehash", hash)
                    comando.Parameters.AddWithValue("@salt", salt)
                    comando.Parameters.AddWithValue("@rol", rolNuevo)
                    comando.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Usuario creado",
                                "Creado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al crear: " & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class