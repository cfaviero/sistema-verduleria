Imports System.IO
Imports MySqlConnector
Module ConexionBD
    'declaro constante para string de conexion
    Public ConnectionString As String

    'subrutina para obtener string de conexion
    Public Sub ObtenerDatosConexion()
        Try
            'obtengo ruta del archivo de string de conexion
            Dim rutaarcvhivo As String = Path.Combine(AppContext.BaseDirectory, "conexion.ini")
            'valido que exista el archivo
            If Not File.Exists(rutaarcvhivo) Then
                MessageBox.Show("No se encontro el archivo en " & rutaarcvhivo)
                Exit Sub
            End If

            'leeemos el archivo
            ConnectionString = File.ReadAllText(rutaarcvhivo).Trim()

        Catch ex As Exception
            MessageBox.Show("No se encontro el archivo" & ex.Message)
        End Try
    End Sub


End Module