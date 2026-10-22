<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proveedores_ABM
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
        btnBuscar = New Button()
        Label8 = New Label()
        txtBuscar = New TextBox()
        dgvProveedores = New DataGridView()
        btnBorrar = New Button()
        txtTelefono = New TextBox()
        lblId = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        txtEmail = New TextBox()
        txtNombre = New TextBox()
        GroupBox1 = New GroupBox()
        Label7 = New Label()
        txtDireccion = New TextBox()
        Label6 = New Label()
        btnModificar = New Button()
        btnAgregar = New Button()
        Label1 = New Label()
        CType(dgvProveedores, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = SystemColors.Control
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.Enabled = False
        btnBuscar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBuscar.Location = New Point(1018, 353)
        btnBuscar.Margin = New Padding(3, 4, 3, 4)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(47, 31)
        btnBuscar.TabIndex = 53
        btnBuscar.Text = "🔍"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(726, 360)
        Label8.Name = "Label8"
        Label8.Size = New Size(52, 20)
        Label8.TabIndex = 52
        Label8.Text = "Buscar"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(781, 355)
        txtBuscar.Margin = New Padding(3, 4, 3, 4)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(231, 27)
        txtBuscar.TabIndex = 51
        ' 
        ' dgvProveedores
        ' 
        dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgvProveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        dgvProveedores.BackgroundColor = SystemColors.Control
        dgvProveedores.BorderStyle = BorderStyle.Fixed3D
        dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProveedores.Cursor = Cursors.Hand
        dgvProveedores.GridColor = SystemColors.ControlDark
        dgvProveedores.Location = New Point(13, 394)
        dgvProveedores.Margin = New Padding(3, 4, 3, 4)
        dgvProveedores.MultiSelect = False
        dgvProveedores.Name = "dgvProveedores"
        dgvProveedores.ReadOnly = True
        dgvProveedores.RowHeadersWidth = 51
        dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProveedores.Size = New Size(1246, 120)
        dgvProveedores.TabIndex = 50
        ' 
        ' btnBorrar
        ' 
        btnBorrar.Cursor = Cursors.Hand
        btnBorrar.Enabled = False
        btnBorrar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBorrar.ForeColor = Color.Red
        btnBorrar.Location = New Point(27, 355)
        btnBorrar.Margin = New Padding(3, 4, 3, 4)
        btnBorrar.Name = "btnBorrar"
        btnBorrar.Size = New Size(103, 31)
        btnBorrar.TabIndex = 48
        btnBorrar.Text = "Dar de baja"
        btnBorrar.UseVisualStyleBackColor = True
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BorderStyle = BorderStyle.FixedSingle
        txtTelefono.Location = New Point(274, 149)
        txtTelefono.Margin = New Padding(3, 4, 3, 4)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(406, 27)
        txtTelefono.TabIndex = 41
        ' 
        ' lblId
        ' 
        lblId.AutoSize = True
        lblId.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblId.Location = New Point(298, 64)
        lblId.Name = "lblId"
        lblId.Size = New Size(0, 37)
        lblId.TabIndex = 47
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(171, 76)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 20)
        Label5.TabIndex = 46
        Label5.Text = "Codigo"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(171, 271)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 20)
        Label4.TabIndex = 45
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(171, 194)
        Label3.Name = "Label3"
        Label3.Size = New Size(0, 20)
        Label3.TabIndex = 44
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.Location = New Point(274, 228)
        txtEmail.Margin = New Padding(3, 4, 3, 4)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(0, 27)
        txtEmail.TabIndex = 42
        ' 
        ' txtNombre
        ' 
        txtNombre.BorderStyle = BorderStyle.FixedSingle
        txtNombre.Location = New Point(274, 112)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(406, 27)
        txtNombre.TabIndex = 40
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(txtDireccion)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(btnModificar)
        GroupBox1.Controls.Add(btnAgregar)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(112, 38)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(587, 265)
        GroupBox1.TabIndex = 49
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del proveedor"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(59, 157)
        Label7.Name = "Label7"
        Label7.Size = New Size(72, 20)
        Label7.TabIndex = 36
        Label7.Text = "Dirección"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.BorderStyle = BorderStyle.FixedSingle
        txtDireccion.Location = New Point(162, 147)
        txtDireccion.Margin = New Padding(3, 4, 3, 4)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(406, 27)
        txtDireccion.TabIndex = 36
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(59, 116)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 20)
        Label6.TabIndex = 33
        Label6.Text = "Teléfono"
        ' 
        ' btnModificar
        ' 
        btnModificar.Cursor = Cursors.Hand
        btnModificar.Location = New Point(98, 205)
        btnModificar.Margin = New Padding(3, 4, 3, 4)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(143, 31)
        btnModificar.TabIndex = 14
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Enabled = False
        btnAgregar.Location = New Point(256, 205)
        btnAgregar.Margin = New Padding(3, 4, 3, 4)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(143, 31)
        btnAgregar.TabIndex = 6
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(62, 77)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 20)
        Label1.TabIndex = 27
        Label1.Text = "Nombre"
        ' 
        ' Proveedores_ABM
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1272, 543)
        Controls.Add(btnBuscar)
        Controls.Add(Label8)
        Controls.Add(txtBuscar)
        Controls.Add(dgvProveedores)
        Controls.Add(btnBorrar)
        Controls.Add(txtTelefono)
        Controls.Add(lblId)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(txtEmail)
        Controls.Add(txtNombre)
        Controls.Add(GroupBox1)
        Name = "Proveedores_ABM"
        Text = "Proveedores_ABM"
        CType(dgvProveedores, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvProveedores As DataGridView
    Friend WithEvents btnBorrar As Button
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents lblId As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label1 As Label
End Class
