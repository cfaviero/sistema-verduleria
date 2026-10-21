Module Sesion
    Public idusuario As Integer = 0

    Public nombreusuario As String = ""

    Public rolusuario As String = ""

    Public descripcion As String = ""

    Public Sub CerrarSession()
        idusuario = 0
        nombreusuario = ""
        rolusuario = ""
        descripcion = ""
    End Sub
End Module