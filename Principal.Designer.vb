<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        btnStock = New Button()
        lblHoraActual = New Label()
        btnSalir = New Button()
        btnCerrarSesion = New Button()
        lblBienvenido = New Label()
        pnlCabecera = New Panel()
        btnUsuarios = New Button()
        btnProveedores = New Button()
        btnInicio = New Button()
        btnClientes = New Button()
        pnlContenido = New Panel()
        pnlCabecera.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnStock
        ' 
        btnStock.BackColor = Color.Green
        btnStock.Cursor = Cursors.Hand
        btnStock.FlatAppearance.BorderSize = 0
        btnStock.FlatStyle = FlatStyle.Flat
        btnStock.Font = New Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStock.ForeColor = Color.White
        btnStock.Location = New Point(141, 9)
        btnStock.Name = "btnStock"
        btnStock.Size = New Size(117, 27)
        btnStock.TabIndex = 1
        btnStock.Text = "Inventario"
        btnStock.UseVisualStyleBackColor = False
        ' 
        ' lblHoraActual
        ' 
        lblHoraActual.AutoSize = True
        lblHoraActual.Font = New Font("Segoe UI", 12F)
        lblHoraActual.ForeColor = Color.Black
        lblHoraActual.Location = New Point(686, 461)
        lblHoraActual.Name = "lblHoraActual"
        lblHoraActual.Size = New Size(19, 21)
        lblHoraActual.TabIndex = 4
        lblHoraActual.Text = "..."
        lblHoraActual.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnSalir
        ' 
        btnSalir.ForeColor = Color.Black
        btnSalir.Location = New Point(1032, 14)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(75, 23)
        btnSalir.TabIndex = 5
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' btnCerrarSesion
        ' 
        btnCerrarSesion.ForeColor = Color.Black
        btnCerrarSesion.Location = New Point(927, 14)
        btnCerrarSesion.Name = "btnCerrarSesion"
        btnCerrarSesion.Size = New Size(100, 23)
        btnCerrarSesion.TabIndex = 6
        btnCerrarSesion.Text = "Cerrar Sesion"
        btnCerrarSesion.UseVisualStyleBackColor = True
        ' 
        ' lblBienvenido
        ' 
        lblBienvenido.AutoSize = True
        lblBienvenido.Location = New Point(107, 28)
        lblBienvenido.Name = "lblBienvenido"
        lblBienvenido.Size = New Size(12, 15)
        lblBienvenido.TabIndex = 7
        lblBienvenido.Text = "-"
        ' 
        ' pnlCabecera
        ' 
        pnlCabecera.BackColor = Color.DarkGreen
        pnlCabecera.Controls.Add(btnUsuarios)
        pnlCabecera.Controls.Add(btnProveedores)
        pnlCabecera.Controls.Add(btnInicio)
        pnlCabecera.Controls.Add(btnClientes)
        pnlCabecera.Controls.Add(btnCerrarSesion)
        pnlCabecera.Controls.Add(btnSalir)
        pnlCabecera.Controls.Add(btnStock)
        pnlCabecera.Dock = DockStyle.Top
        pnlCabecera.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        pnlCabecera.Location = New Point(0, 0)
        pnlCabecera.Margin = New Padding(3, 2, 3, 2)
        pnlCabecera.Name = "pnlCabecera"
        pnlCabecera.Size = New Size(1129, 49)
        pnlCabecera.TabIndex = 8
        ' 
        ' btnUsuarios
        ' 
        btnUsuarios.BackColor = Color.Green
        btnUsuarios.Cursor = Cursors.Hand
        btnUsuarios.FlatAppearance.BorderSize = 0
        btnUsuarios.FlatStyle = FlatStyle.Flat
        btnUsuarios.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUsuarios.ForeColor = Color.White
        btnUsuarios.Location = New Point(820, 10)
        btnUsuarios.Name = "btnUsuarios"
        btnUsuarios.Size = New Size(87, 29)
        btnUsuarios.TabIndex = 10
        btnUsuarios.Text = "Usuarios"
        btnUsuarios.TextAlign = ContentAlignment.TopCenter
        btnUsuarios.UseVisualStyleBackColor = False
        ' 
        ' btnProveedores
        ' 
        btnProveedores.BackColor = Color.Green
        btnProveedores.Cursor = Cursors.Hand
        btnProveedores.FlatAppearance.BorderSize = 0
        btnProveedores.FlatStyle = FlatStyle.Flat
        btnProveedores.Font = New Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnProveedores.ForeColor = Color.White
        btnProveedores.Location = New Point(408, 9)
        btnProveedores.Name = "btnProveedores"
        btnProveedores.Size = New Size(141, 27)
        btnProveedores.TabIndex = 9
        btnProveedores.Text = "Proveedores"
        btnProveedores.UseVisualStyleBackColor = False
        ' 
        ' btnInicio
        ' 
        btnInicio.BackColor = Color.Green
        btnInicio.Cursor = Cursors.Hand
        btnInicio.FlatAppearance.BorderSize = 0
        btnInicio.FlatStyle = FlatStyle.Flat
        btnInicio.Font = New Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnInicio.ForeColor = Color.White
        btnInicio.Location = New Point(10, 10)
        btnInicio.Name = "btnInicio"
        btnInicio.Size = New Size(117, 27)
        btnInicio.TabIndex = 8
        btnInicio.Text = "Inicio"
        btnInicio.UseVisualStyleBackColor = False
        ' 
        ' btnClientes
        ' 
        btnClientes.BackColor = Color.Green
        btnClientes.Cursor = Cursors.Hand
        btnClientes.FlatAppearance.BorderSize = 0
        btnClientes.FlatStyle = FlatStyle.Flat
        btnClientes.Font = New Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClientes.ForeColor = Color.White
        btnClientes.Location = New Point(275, 9)
        btnClientes.Name = "btnClientes"
        btnClientes.Size = New Size(117, 27)
        btnClientes.TabIndex = 7
        btnClientes.Text = "Clientes"
        btnClientes.UseVisualStyleBackColor = False
        ' 
        ' pnlContenido
        ' 
        pnlContenido.AutoSizeMode = AutoSizeMode.GrowAndShrink
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.Location = New Point(0, 49)
        pnlContenido.Margin = New Padding(3, 2, 3, 2)
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Size = New Size(1129, 442)
        pnlContenido.TabIndex = 9
        ' 
        ' Principal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        ClientSize = New Size(1129, 491)
        Controls.Add(pnlContenido)
        Controls.Add(pnlCabecera)
        Controls.Add(lblBienvenido)
        Controls.Add(lblHoraActual)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Principal"
        Text = "  "
        pnlCabecera.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnStock As Button
    Friend WithEvents lblHoraActual As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnCerrarSesion As Button
    Friend WithEvents lblBienvenido As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents btnClientes As Button
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents btnInicio As Button
    Friend WithEvents btnProveedores As Button
    Friend WithEvents btnUsuarios As Button

End Class
