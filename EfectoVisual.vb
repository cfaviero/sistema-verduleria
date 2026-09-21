Imports System.Windows.Forms
Imports System.Drawing

Public Module EfectoVisual
    Private Const FORMATO As String = "dd/MM/yyyy HH:mm:ss"

    Private targetLabel As Label
    Private colorTexto As Color
    Private colorFondo As Color
    Private nivelAlfa As Integer = 0

    Private WithEvents timerEspera As New Timer()
    Private WithEvents timerFade As New Timer()
    Private WithEvents timerReloj As New Timer()

    Public Sub AplicarTransicionHora(lbl As Label)
        ' Detiene cualquier ejecución previa
        timerEspera.Stop()
        timerFade.Stop()
        timerReloj.Stop()

        targetLabel = lbl

        ' Color final del texto (opaco) y color contra el que se "desvanece"
        colorTexto = Color.FromArgb(255, lbl.ForeColor)
        If lbl.BackColor.A = 0 AndAlso lbl.Parent IsNot Nothing Then
            colorFondo = lbl.Parent.BackColor   ' BackColor = Transparent
        Else
            colorFondo = lbl.BackColor
        End If

        nivelAlfa = 0
        targetLabel.Text = "..."

        timerEspera.Interval = 1500
        timerFade.Interval = 15
        timerReloj.Interval = 1000
        timerEspera.Start()
    End Sub

    ' Tras la espera: cambia al texto real, invisible (color = fondo)
    Private Sub timerEspera_Tick(sender As Object, e As EventArgs) Handles timerEspera.Tick
        timerEspera.Stop()
        nivelAlfa = 0
        AplicarColor()
        targetLabel.Text = DateTime.Now.ToString(FORMATO)
        timerFade.Start()
    End Sub

    ' Sube la "opacidad" mezclando el color del texto con el del fondo
    Private Sub timerFade_Tick(sender As Object, e As EventArgs) Handles timerFade.Tick
        nivelAlfa = Math.Min(nivelAlfa + 15, 255)
        AplicarColor()
        targetLabel.Text = DateTime.Now.ToString(FORMATO)

        If nivelAlfa >= 255 Then
            timerFade.Stop()
            timerReloj.Start()
        End If
    End Sub

    Private Sub timerReloj_Tick(sender As Object, e As EventArgs) Handles timerReloj.Tick
        If targetLabel IsNot Nothing Then
            targetLabel.Text = DateTime.Now.ToString(FORMATO)
        End If
    End Sub

    ' Interpolación lineal fondo -> texto según nivelAlfa (0..255)
    Private Sub AplicarColor()
        Dim r As Integer = CInt(colorFondo.R) + (CInt(colorTexto.R) - CInt(colorFondo.R)) * nivelAlfa \ 255
        Dim g As Integer = CInt(colorFondo.G) + (CInt(colorTexto.G) - CInt(colorFondo.G)) * nivelAlfa \ 255
        Dim b As Integer = CInt(colorFondo.B) + (CInt(colorTexto.B) - CInt(colorFondo.B)) * nivelAlfa \ 255

        ' Por seguridad, se limita cada componente al rango válido 0..255
        r = Math.Max(0, Math.Min(255, r))
        g = Math.Max(0, Math.Min(255, g))
        b = Math.Max(0, Math.Min(255, b))

        targetLabel.ForeColor = Color.FromArgb(r, g, b)
    End Sub
End Module