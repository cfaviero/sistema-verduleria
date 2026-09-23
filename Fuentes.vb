Imports System.Drawing.Text
Imports System.IO

Module Fuentes
    Private ReadOnly coleccion As New PrivateFontCollection()
    Public FamiliaRoboto As FontFamily

    Public Sub CargarFuentes()
        Dim carpeta As String = Path.Combine(AppContext.BaseDirectory, "Fonts")

        coleccion.AddFontFile(Path.Combine(carpeta, "Roboto-Regular.ttf"))
        coleccion.AddFontFile(Path.Combine(carpeta, "Roboto-Bold.ttf"))

        FamiliaRoboto = coleccion.Families(0)
    End Sub
End Module