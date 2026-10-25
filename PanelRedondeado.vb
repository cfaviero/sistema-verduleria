Imports System.ComponentModel

Public Class PanelRedondeado
    Inherits Panel

    Private _radio As Integer = 12
    Private _colorBorde As Color = Tema.Linea

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.White
    End Sub

    <DefaultValue(12)>
    Public Property Radio As Integer
        Get
            Return _radio
        End Get
        Set(value As Integer)
            _radio = value
            Invalidate()
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ColorBorde As Color
        Get
            Return _colorBorde
        End Get
        Set(value As Color)
            _colorBorde = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' Se pinta todo en OnPaint para evitar parpadeo.
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.Clear(Tema.FondoEfectivo(Me))
        Tema.DibujarRedondeado(e.Graphics, New Rectangle(0, 0, Width - 1, Height - 1), _radio, BackColor, _colorBorde)
    End Sub
End Class