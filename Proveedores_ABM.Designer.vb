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
        btnBuscar.Location = New Point(891, 265)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(41, 23)
        btnBuscar.TabIndex = 53
        btnBuscar.Text = "🔍"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(635, 270)
        Label8.Name = "Label8"
        Label8.Size = New Size(42, 15)
        Label8.TabIndex = 52
        Label8.Text = "Buscar"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(683, 266)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(203, 23)
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
        dgvProveedores.Location = New Point(11, 296)
        dgvProveedores.MultiSelect = False
        dgvProveedores.Name = "dgvProveedores"
        dgvProveedores.ReadOnly = True
        dgvProveedores.RowHeadersWidth = 51
        dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProveedores.Size = New Size(1090, 90)
        dgvProveedores.TabIndex = 50
        ' 
        ' btnBorrar
        ' 
        btnBorrar.Cursor = Cursors.Hand
        btnBorrar.Enabled = False
        btnBorrar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBorrar.ForeColor = Color.Red
        btnBorrar.Location = New Point(24, 266)
        btnBorrar.Name = "btnBorrar"
        btnBorrar.Size = New Size(90, 23)
        btnBorrar.TabIndex = 48
        btnBorrar.Text = "Dar de baja"
        btnBorrar.UseVisualStyleBackColor = True
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BorderStyle = BorderStyle.FixedSingle
        txtTelefono.Location = New Point(142, 81)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(356, 23)
        txtTelefono.TabIndex = 2
        ' 
        ' lblId
        ' 
        lblId.AutoSize = True
        lblId.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblId.Location = New Point(327, 17)
        lblId.Name = "lblId"
        lblId.Size = New Size(22, 30)
        lblId.TabIndex = 47
        lblId.Text = "-"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(63, 29)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 15)
        Label5.TabIndex = 46
        Label5.Text = "Codigo"
        ' 
        ' txtNombre
        ' 
        txtNombre.BorderStyle = BorderStyle.FixedSingle
        txtNombre.Location = New Point(142, 52)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(356, 23)
        txtNombre.TabIndex = 1
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(txtDireccion)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(btnModificar)
        GroupBox1.Controls.Add(btnAgregar)
        GroupBox1.Controls.Add(lblId)
        GroupBox1.Controls.Add(txtTelefono)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtNombre)
        GroupBox1.Location = New Point(24, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(514, 199)
        GroupBox1.TabIndex = 49
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del proveedor"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(52, 118)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 15)
        Label7.TabIndex = 36
        Label7.Text = "Dirección"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.BorderStyle = BorderStyle.FixedSingle
        txtDireccion.Location = New Point(142, 110)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(356, 23)
        txtDireccion.TabIndex = 3
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(57, 83)
        Label6.Name = "Label6"
        Label6.Size = New Size(52, 15)
        Label6.TabIndex = 33
        Label6.Text = "Teléfono"
        ' 
        ' btnModificar
        ' 
        btnModificar.Cursor = Cursors.Hand
        btnModificar.Location = New Point(86, 154)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(125, 23)
        btnModificar.TabIndex = 14
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Enabled = False
        btnAgregar.Location = New Point(224, 154)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(125, 23)
        btnAgregar.TabIndex = 6
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(58, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 15)
        Label1.TabIndex = 27
        Label1.Text = "Nombre"
        ' 
        ' Proveedores_ABM
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1113, 407)
        Controls.Add(btnBuscar)
        Controls.Add(Label8)
        Controls.Add(txtBuscar)
        Controls.Add(dgvProveedores)
        Controls.Add(btnBorrar)
        Controls.Add(GroupBox1)
        Margin = New Padding(3, 2, 3, 2)
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
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label1 As Label
End Class
