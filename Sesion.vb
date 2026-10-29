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
        Return String.Equals(rolusuario, "Admin", StringComparison.OrdinalIgnoreCase)
    End Function
    Public Function EsVendedor() As Boolean
        Return String.Equals(rolusuario, "Vendedor", StringComparison.OrdinalIgnoreCase)
    End Function
    Public Function EsRepositor() As Boolean
        Return String.Equals(rolusuario, "Repositor", StringComparison.OrdinalIgnoreCase)
    End Function
End Module