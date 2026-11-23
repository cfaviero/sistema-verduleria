Imports System.Runtime.InteropServices
Imports MySqlConnector

Public Class Contra
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property UsuarioNuevo As String
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property descNuevo As String
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property rolNuevo As String
    Private ojoCerrado As Boolean = True

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        If txtContra.Text = "" OrElse txtRepContra.Text = "" OrElse txtContra.Text <> txtRepContra.Text Then
            MessageBox.Show("Por favor, completar los campos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Vuelve a enfocarse en el textbox usuarios
            txtContra.Clear()
            txtRepContra.Clear()
            txtContra.Focus()
            Exit Sub
        End If

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

    Private Sub Contra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Aplicacion del tema
        Tema.AplicarTema(Me)

        'Formato
        txtContra.Font = Tema.Fuente(12, FontStyle.Bold)
        txtRepContra.Font = Tema.Fuente(12, FontStyle.Bold)
        lblContra.Font = Tema.Fuente(15, FontStyle.Bold)
    End Sub

    Private Sub pbVer_Click(sender As Object, e As EventArgs) Handles pbVer.Click
        If ojoCerrado Then
            pbVer.Image = My.Resources.ojoabierto
            ojoCerrado = False
            txtContra.PasswordChar = ""
            txtRepContra.PasswordChar = ""
        Else
            pbVer.Image = My.Resources.ojocerrado
            ojoCerrado = True
            txtContra.PasswordChar = "*"
            txtRepContra.PasswordChar = "*"
        End If
    End Sub
End Class