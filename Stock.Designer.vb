<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stock
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stock))
        dgvStock = New DataGridView()
        txtNombre = New TextBox()
        txtPrecio = New TextBox()
        txtStock = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        lblId = New Label()
        cmbCategoria = New ComboBox()
        txtBuscar = New TextBox()
        Label7 = New Label()
        btnModificar = New Button()
        btnCrear = New Button()
        btnBuscar = New Button()
        Label6 = New Label()
        txtDescripcion = New TextBox()
        btnBorrar = New Button()
        btnProveedores = New Button()
        ToolTip1 = New ToolTip(components)
        GroupBox1 = New GroupBox()
        PictureBox1 = New PictureBox()
        btnAgregar = New Button()
        btnQuitar = New Button()
        btnGuardar = New Button()
        CType(dgvStock, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvStock
        ' 
        dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgvStock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        dgvStock.BackgroundColor = SystemColors.Control
        dgvStock.BorderStyle = BorderStyle.Fixed3D
        dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStock.Cursor = Cursors.Hand
        dgvStock.GridColor = SystemColors.ControlDark
        dgvStock.Location = New Point(12, 388)
        dgvStock.Margin = New Padding(3, 4, 3, 4)
        dgvStock.MultiSelect = False
        dgvStock.Name = "dgvStock"
        dgvStock.ReadOnly = True
        dgvStock.RowHeadersWidth = 51
        dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStock.Size = New Size(1246, 120)
        dgvStock.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.BorderStyle = BorderStyle.FixedSingle
        txtNombre.Location = New Point(127, 81)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(324, 27)
        txtNombre.TabIndex = 1
        ' 
        ' txtPrecio
        ' 
        txtPrecio.BorderStyle = BorderStyle.FixedSingle
        txtPrecio.Location = New Point(127, 197)
        txtPrecio.Margin = New Padding(3, 4, 3, 4)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(324, 27)
        txtPrecio.TabIndex = 4
        ' 
        ' txtStock
        ' 
        txtStock.BorderStyle = BorderStyle.FixedSingle
        txtStock.Location = New Point(127, 159)
        txtStock.Margin = New Padding(3, 4, 3, 4)
        txtStock.Name = "txtStock"
        txtStock.ReadOnly = True
        txtStock.Size = New Size(324, 27)
        txtStock.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(24, 85)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 20)
        Label1.TabIndex = 5
        Label1.Text = "Nombre"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 201)
        Label2.Name = "Label2"
        Label2.Size = New Size(50, 20)
        Label2.TabIndex = 6
        Label2.Text = "Precio"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(24, 163)
        Label3.Name = "Label3"
        Label3.Size = New Size(91, 20)
        Label3.TabIndex = 7
        Label3.Text = "Stock Actual"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(24, 240)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 20)
        Label4.TabIndex = 8
        Label4.Text = "Categoría"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(24, 45)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 20)
        Label5.TabIndex = 9
        Label5.Text = "Codigo"
        ' 
        ' lblId
        ' 
        lblId.AutoSize = True
        lblId.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblId.Location = New Point(151, 33)
        lblId.Name = "lblId"
        lblId.Size = New Size(28, 37)
        lblId.TabIndex = 10
        lblId.Text = "-"
        ' 
        ' cmbCategoria
        ' 
        cmbCategoria.FlatStyle = FlatStyle.Popup
        cmbCategoria.FormattingEnabled = True
        cmbCategoria.Location = New Point(127, 236)
        cmbCategoria.Margin = New Padding(3, 4, 3, 4)
        cmbCategoria.Name = "cmbCategoria"
        cmbCategoria.Size = New Size(324, 28)
        cmbCategoria.TabIndex = 5
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(701, 331)
        txtBuscar.Margin = New Padding(3, 4, 3, 4)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(231, 27)
        txtBuscar.TabIndex = 12
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(646, 336)
        Label7.Name = "Label7"
        Label7.Size = New Size(52, 20)
        Label7.TabIndex = 13
        Label7.Text = "Buscar"
        ' 
        ' btnModificar
        ' 
        btnModificar.Cursor = Cursors.Hand
        btnModificar.Location = New Point(95, 271)
        btnModificar.Margin = New Padding(3, 4, 3, 4)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(143, 31)
        btnModificar.TabIndex = 14
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnCrear
        ' 
        btnCrear.Cursor = Cursors.Hand
        btnCrear.Enabled = False
        btnCrear.Location = New Point(244, 271)
        btnCrear.Margin = New Padding(3, 4, 3, 4)
        btnCrear.Name = "btnCrear"
        btnCrear.Size = New Size(143, 31)
        btnCrear.TabIndex = 6
        btnCrear.Text = "Crear"
        btnCrear.UseVisualStyleBackColor = True
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = SystemColors.Control
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.Enabled = False
        btnBuscar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBuscar.Location = New Point(938, 329)
        btnBuscar.Margin = New Padding(3, 4, 3, 4)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(47, 31)
        btnBuscar.TabIndex = 16
        btnBuscar.Text = "🔍"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(24, 124)
        Label6.Name = "Label6"
        Label6.Size = New Size(87, 20)
        Label6.TabIndex = 18
        Label6.Text = "Descripcion"
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.BorderStyle = BorderStyle.FixedSingle
        txtDescripcion.Location = New Point(127, 120)
        txtDescripcion.Margin = New Padding(3, 4, 3, 4)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(324, 27)
        txtDescripcion.TabIndex = 2
        ' 
        ' btnBorrar
        ' 
        btnBorrar.Cursor = Cursors.Hand
        btnBorrar.Enabled = False
        btnBorrar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBorrar.ForeColor = Color.Red
        btnBorrar.Location = New Point(14, 331)
        btnBorrar.Margin = New Padding(3, 4, 3, 4)
        btnBorrar.Name = "btnBorrar"
        btnBorrar.Size = New Size(143, 31)
        btnBorrar.TabIndex = 19
        btnBorrar.Text = "Eliminar Producto"
        btnBorrar.UseVisualStyleBackColor = True
        ' 
        ' btnProveedores
        ' 
        btnProveedores.BackColor = Color.Transparent
        btnProveedores.Cursor = Cursors.Hand
        btnProveedores.FlatAppearance.BorderSize = 0
        btnProveedores.FlatStyle = FlatStyle.Flat
        btnProveedores.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnProveedores.Image = CType(resources.GetObject("btnProveedores.Image"), Image)
        btnProveedores.Location = New Point(1114, 9)
        btnProveedores.Margin = New Padding(3, 4, 3, 4)
        btnProveedores.Name = "btnProveedores"
        btnProveedores.Size = New Size(137, 138)
        btnProveedores.TabIndex = 20
        btnProveedores.UseVisualStyleBackColor = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnModificar)
        GroupBox1.Controls.Add(btnCrear)
        GroupBox1.Location = New Point(14, 9)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(449, 313)
        GroupBox1.TabIndex = 21
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del Producto"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(559, 22)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(373, 226)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 22
        PictureBox1.TabStop = False
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAgregar.Location = New Point(569, 256)
        btnAgregar.Margin = New Padding(3, 4, 3, 4)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(38, 31)
        btnAgregar.TabIndex = 23
        btnAgregar.Text = "+"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnQuitar
        ' 
        btnQuitar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnQuitar.Location = New Point(729, 256)
        btnQuitar.Margin = New Padding(3, 4, 3, 4)
        btnQuitar.Name = "btnQuitar"
        btnQuitar.Size = New Size(100, 31)
        btnQuitar.TabIndex = 24
        btnQuitar.Text = "Quitar"
        btnQuitar.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGuardar.Location = New Point(623, 256)
        btnGuardar.Margin = New Padding(3, 4, 3, 4)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(100, 31)
        btnGuardar.TabIndex = 25
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' stock
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1272, 608)
        Controls.Add(btnGuardar)
        Controls.Add(btnQuitar)
        Controls.Add(btnAgregar)
        Controls.Add(PictureBox1)
        Controls.Add(btnProveedores)
        Controls.Add(btnBorrar)
        Controls.Add(Label6)
        Controls.Add(txtDescripcion)
        Controls.Add(btnBuscar)
        Controls.Add(Label7)
        Controls.Add(txtBuscar)
        Controls.Add(cmbCategoria)
        Controls.Add(lblId)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtStock)
        Controls.Add(txtPrecio)
        Controls.Add(txtNombre)
        Controls.Add(dgvStock)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(3, 4, 3, 4)
        Name = "stock"
        Text = "Stock"
        CType(dgvStock, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvStock As DataGridView
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblId As Label
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnCrear As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnProveedores As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnGuardar As Button
End Class
