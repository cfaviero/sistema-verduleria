Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Linq

Public Module Tema

    ' ---------- Paleta ----------
    Public ReadOnly Fondo As Color = Color.FromArgb(244, 248, 242)
    Public ReadOnly Cabecera As Color = Color.FromArgb(237, 240, 235)
    Public ReadOnly Linea As Color = Color.FromArgb(222, 228, 219)
    Public ReadOnly Verde As Color = Color.FromArgb(44, 95, 65)
    Public ReadOnly VerdeHover As Color = Color.FromArgb(35, 78, 53)
    Public ReadOnly VerdeSuave As Color = Color.FromArgb(230, 240, 227)
    Public ReadOnly VerdeTexto As Color = Color.FromArgb(47, 107, 69)
    Public ReadOnly TextoOscuro As Color = Color.FromArgb(31, 41, 35)
    Public ReadOnly TextoTenue As Color = Color.FromArgb(107, 114, 110)
    Public ReadOnly TextoDeshabilitado As Color = Color.FromArgb(160, 168, 162)
    Public ReadOnly GrisSuave As Color = Color.FromArgb(237, 240, 235)

    ' Usa "Inter" si está instalada; si no, Segoe UI.
    ' Si tu clase Fuentes ya carga una fuente desde la carpeta fonts, reemplaza aquí el nombre de la familia.
    Private ReadOnly Familia As String =
        If(New InstalledFontCollection().Families.Any(Function(f) f.Name = "Inter"), "Inter", "Segoe UI")

    Private ReadOnly _estilizados As New HashSet(Of Control)
    Private ReadOnly _hover As New HashSet(Of Control)
    Private _navActivo As Button

    Public Function Fuente(tamano As Single, Optional estilo As FontStyle = FontStyle.Regular) As Font
        Return New Font(Familia, tamano, estilo)
    End Function

    Private Function RolDe(c As Control) As String
        If c.Tag Is Nothing Then Return ""
        Return c.Tag.ToString().Trim().ToLower()
    End Function

    ' Color de fondo real: sube por los padres hasta encontrar uno opaco.
    Public Function FondoEfectivo(c As Control) As Color
        Dim p As Control = c.Parent
        Do While p IsNot Nothing
            If p.BackColor.A = 255 Then Return p.BackColor
            p = p.Parent
        Loop
        Return SystemColors.Control
    End Function

    ' ---------- Dibujo ----------
    Public Sub DibujarRedondeado(g As Graphics, r As Rectangle, radio As Integer, relleno As Color, borde As Color)
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim d As Integer = Math.Max(2, Math.Min(radio * 2, Math.Min(r.Width, r.Height)))
        Using ruta As New GraphicsPath()
            ruta.AddArc(r.X, r.Y, d, d, 180, 90)
            ruta.AddArc(r.Right - d, r.Y, d, d, 270, 90)
            ruta.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
            ruta.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
            ruta.CloseFigure()
            If relleno.A > 0 Then
                Using pincel As New SolidBrush(relleno)
                    g.FillPath(pincel, ruta)
                End Using
            End If
            If borde.A > 0 Then
                Using lapiz As New Pen(borde, 1)
                    g.DrawPath(lapiz, ruta)
                End Using
            End If
        End Using
    End Sub

    ' ---------- Punto de entrada ----------
    Public Sub AplicarTema(raiz As Control)
        If TypeOf raiz Is Form Then
            raiz.BackColor = Fondo
            raiz.Font = Fuente(9.5F)
        End If
        For Each c As Control In raiz.Controls.Cast(Of Control).ToList()
            AplicarControl(c)
            If c.HasChildren AndAlso Not (TypeOf c Is DataGridView) Then AplicarTema(c)
        Next
    End Sub

    Private Sub AplicarControl(c As Control)
        If TypeOf c Is PanelRedondeado Then
            If RolDe(c) = "icono" Then
                c.BackColor = VerdeSuave
                DirectCast(c, PanelRedondeado).ColorBorde = VerdeSuave
            End If
        ElseIf TypeOf c Is Panel Then   ' incluye TableLayoutPanel y FlowLayoutPanel
            c.BackColor = If(RolDe(c) = "cabecera", Cabecera, Color.Transparent)
        ElseIf TypeOf c Is PictureBox Then
            c.BackColor = Color.Transparent
        ElseIf TypeOf c Is Label Then
            EstilizarLabel(DirectCast(c, Label))
        ElseIf TypeOf c Is TextBox Then
            EnvolverTextBox(DirectCast(c, TextBox))
        ElseIf TypeOf c Is ComboBox Then
            EstilizarCombo(DirectCast(c, ComboBox))
        ElseIf TypeOf c Is Button Then
            EstilizarBoton(DirectCast(c, Button))
        ElseIf TypeOf c Is DataGridView Then
            EstilizarGrid(DirectCast(c, DataGridView))
        End If
    End Sub

    ' ---------- Labels ----------
    Private Sub EstilizarLabel(l As Label)
        l.BackColor = Color.Transparent
        Select Case RolDe(l)
            Case "titulo"
                l.Font = Fuente(22, FontStyle.Regular)
                l.ForeColor = TextoOscuro
            Case "subtitulo"
                l.Font = Fuente(9.5F)
                l.ForeColor = TextoTenue
            Case "cardtitulo"
                l.Font = Fuente(12, FontStyle.Bold)
                l.ForeColor = TextoOscuro
            Case "ayuda"
                l.Font = Fuente(8)
                l.ForeColor = TextoTenue
            Case "marca"
                l.Font = Fuente(12.5F)
                l.ForeColor = TextoOscuro
            Case Else   ' etiqueta de campo
                l.Font = Fuente(8.5F, FontStyle.Bold)
                l.ForeColor = TextoOscuro
        End Select
    End Sub

    ' ---------- TextBox: se envuelve en un panel redondeado ----------
    Private Sub EnvolverTextBox(tb As TextBox)
        If tb.Multiline OrElse tb.Parent Is Nothing OrElse Not _estilizados.Add(tb) Then Return

        Const ALTO As Integer = 38
        Dim padre As Control = tb.Parent
        Dim tlp As TableLayoutPanel = TryCast(padre, TableLayoutPanel)
        Dim col, fila, spanCol, spanFila As Integer
        If tlp IsNot Nothing Then
            col = tlp.GetColumn(tb)
            fila = tlp.GetRow(tb)
            spanCol = tlp.GetColumnSpan(tb)
            spanFila = tlp.GetRowSpan(tb)
        End If

        padre.SuspendLayout()

        tb.BorderStyle = BorderStyle.None
        tb.Font = Fuente(9.5F)
        tb.BackColor = Color.White
        tb.ForeColor = TextoOscuro

        Dim w As New PanelRedondeado()
        w.Radio = 8
        w.TabIndex = tb.TabIndex
        w.Margin = tb.Margin
        w.Size = New Size(tb.Width, ALTO)
        w.Location = tb.Location
        If tb.Dock <> DockStyle.None Then
            w.Dock = tb.Dock
        Else
            w.Anchor = tb.Anchor
        End If

        Dim indice As Integer = padre.Controls.GetChildIndex(tb)
        padre.Controls.Remove(tb)
        padre.Controls.Add(w)
        padre.Controls.SetChildIndex(w, indice)
        If tlp IsNot Nothing Then
            tlp.SetCellPosition(w, New TableLayoutPanelCellPosition(col, fila))
            tlp.SetColumnSpan(w, spanCol)
            tlp.SetRowSpan(w, spanFila)
        End If

        w.Padding = New Padding(12, (ALTO - tb.PreferredHeight) \ 2, 12, 0)
        tb.Margin = New Padding(0)
        tb.Dock = DockStyle.Fill
        w.Controls.Add(tb)

        AddHandler tb.Enter, Sub(s, e) w.ColorBorde = Verde
        AddHandler tb.Leave, Sub(s, e) w.ColorBorde = Linea
        AddHandler w.Click, Sub(s, e) tb.Focus()

        padre.ResumeLayout(True)
    End Sub

    ' ---------- ComboBox ----------
    Private Sub EstilizarCombo(cb As ComboBox)
        cb.FlatStyle = FlatStyle.Flat
        cb.BackColor = Color.White
        cb.ForeColor = TextoOscuro
        cb.Font = Fuente(10.5F)
    End Sub

    ' ---------- Botones ----------
    Private Sub EstilizarBoton(b As Button)
        If Not _estilizados.Add(b) Then Return

        Dim rol As String = RolDe(b)
        If rol = "" Then
            Dim t As String = b.Text.Trim().ToLower()
            rol = If(t = "crear" OrElse t = "+ crear" OrElse t = "guardar", "primario", "secundario")
        End If

        b.FlatStyle = FlatStyle.Flat
        b.FlatAppearance.BorderSize = 0
        b.UseVisualStyleBackColor = False
        b.Cursor = Cursors.Hand
        b.Font = Fuente(9, FontStyle.Bold)

        AddHandler b.MouseEnter, Sub(s, e) CambiarHover(b, True)
        AddHandler b.MouseLeave, Sub(s, e) CambiarHover(b, False)
        AddHandler b.EnabledChanged, Sub(s, e) b.Invalidate()

        If rol = "nav" Then
            AddHandler b.Paint, Sub(s, e) PintarNav(b, e)
        Else
            AddHandler b.Paint, Sub(s, e) PintarBoton(b, e, rol = "primario")
        End If
    End Sub

    Private Sub CambiarHover(c As Control, sobre As Boolean)
        If sobre Then _hover.Add(c) Else _hover.Remove(c)
        c.Invalidate()
    End Sub

    Private Sub PintarBoton(b As Button, e As PaintEventArgs, primario As Boolean)
        Dim g As Graphics = e.Graphics
        g.Clear(FondoEfectivo(b))

        Dim relleno, texto, borde As Color
        If Not b.Enabled Then
            relleno = GrisSuave
            texto = TextoDeshabilitado
            borde = Color.Transparent
        ElseIf primario Then
            relleno = If(_hover.Contains(b), VerdeHover, Verde)
            texto = Color.White
            borde = Color.Transparent
        Else
            relleno = If(_hover.Contains(b), VerdeSuave, Color.White)
            texto = TextoOscuro
            borde = Linea
        End If

        DibujarRedondeado(g, New Rectangle(0, 0, b.Width - 1, b.Height - 1), 8, relleno, borde)
        TextRenderer.DrawText(g, b.Text, b.Font, New Rectangle(0, 0, b.Width, b.Height), texto,
            TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis)
    End Sub

    ' ---------- Navegación de la cabecera ----------
    Public Sub MarcarActivo(b As Button)
        Dim anterior As Button = _navActivo
        _navActivo = b
        If anterior IsNot Nothing Then anterior.Invalidate()
        If b IsNot Nothing Then b.Invalidate()
    End Sub

    Private Sub PintarNav(b As Button, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(FondoEfectivo(b))

        Dim relleno As Color = Color.Transparent
        Dim texto As Color = TextoTenue
        If b Is _navActivo Then
            relleno = VerdeSuave
            texto = VerdeTexto
        ElseIf _hover.Contains(b) Then
            relleno = Color.FromArgb(226, 231, 223)
            texto = TextoOscuro
        End If

        DibujarRedondeado(g, New Rectangle(0, 0, b.Width - 1, b.Height - 1), 17, relleno, Color.Transparent)
        TextRenderer.DrawText(g, b.Text, b.Font, New Rectangle(0, 0, b.Width, b.Height), texto,
            TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis)
    End Sub

    ' ---------- Tabla ----------
    Private Sub EstilizarGrid(dgv As DataGridView)
        dgv.BorderStyle = BorderStyle.None
        dgv.BackgroundColor = Color.White
        dgv.GridColor = Color.FromArgb(238, 241, 236)
        dgv.EnableHeadersVisualStyles = False
        dgv.RowHeadersVisible = False
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToResizeRows = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgv.ColumnHeadersHeight = 40
        dgv.RowTemplate.Height = 38

        With dgv.ColumnHeadersDefaultCellStyle
            .BackColor = VerdeSuave
            .ForeColor = VerdeTexto
            .SelectionBackColor = VerdeSuave
            .SelectionForeColor = VerdeTexto
            .Font = Fuente(8.5F, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .Padding = New Padding(8, 0, 8, 0)
        End With

        With dgv.DefaultCellStyle
            .BackColor = Color.White
            .ForeColor = TextoOscuro
            .SelectionBackColor = VerdeSuave
            .SelectionForeColor = TextoOscuro
            .Font = Fuente(9.5F)
            .Padding = New Padding(8, 0, 8, 0)
        End With
    End Sub

End Module