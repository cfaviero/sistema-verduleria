Module Sesion
    Public idusuario As Integer = 0
    Public idEmpleado As Integer = 0
    Public nombreusuario As String = ""
    Public rolusuario As String = ""
    Public descripcion As String = ""

    Public Sub CerrarSession()
        idusuario = 0
        nombreusuario = ""
        rolusuario = ""
        descripcion = ""
    End Sub

    Public Function EsAdministrador() As Boolean
        Return String.Equals(rolusuario, "administrador", StringComparison.OrdinalIgnoreCase)
    End Function
End Module