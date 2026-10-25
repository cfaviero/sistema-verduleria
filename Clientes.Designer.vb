<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clientes
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
        btnBorrar = New Button()
        Label6 = New Label()
        txtTelefono = New TextBox()
        lblId = New Label()
        Label5 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtEmail = New TextBox()
        txtNombre = New TextBox()
        GroupBox1 = New GroupBox()
        Label7 = New Label()
        txtDireccion = New TextBox()
        btnModificar = New Button()
        btnAgregar = New Button()
        dgvClientes = New DataGridView()
        btnBuscar = New Button()
        Label8 = New Label()
        txtBuscar = New TextBox()
        GroupBox1.SuspendLayout()
        CType(dgvClientes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnBorrar
        ' 
        btnBorrar.Cursor = Cursors.Hand
        btnBorrar.Enabled = False
        btnBorrar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBorrar.ForeColor = Color.Red
        btnBorrar.Location = New Point(12, 320)
        btnBorrar.Name = "btnBorrar"
        btnBorrar.Size = New Size(90, 23)
        btnBorrar.TabIndex = 34
        btnBorrar.Text = "Dar de baja"
        btnBorrar.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(28, 98)
        Label6.Name = "Label6"
        Label6.Size = New Size(52, 15)
        Label6.TabIndex = 33
        Label6.Text = "Teléfono"
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BorderStyle = BorderStyle.FixedSingle
        txtTelefono.Location = New Point(108, 90)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(356, 23)
        txtTelefono.TabIndex = 2
        ' 
        ' lblId
        ' 
        lblId.AutoSize = True
        lblId.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblId.Location = New Point(283, 17)
        lblId.Name = "lblId"
        lblId.Size = New Size(22, 30)
        lblId.TabIndex = 32
        lblId.Text = "-"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(28, 30)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 15)
        Label5.TabIndex = 31
        Label5.Text = "Codigo"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(28, 186)
        Label2.Name = "Label2"
        Label2.Size = New Size(36, 15)
        Label2.TabIndex = 28
        Label2.Text = "Email"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(28, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 15)
        Label1.TabIndex = 27
        Label1.Text = "Nombre"
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.Location = New Point(108, 178)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(356, 23)
        txtEmail.TabIndex = 4
        ' 
        ' txtNombre
        ' 
        txtNombre.BorderStyle = BorderStyle.FixedSingle
        txtNombre.Location = New Point(108, 48)
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
        GroupBox1.Controls.Add(txtEmail)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(12, 21)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(501, 260)
        GroupBox1.TabIndex = 35
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del usuario"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(28, 142)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 15)
        Label7.TabIndex = 36
        Label7.Text = "Dirección"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.BorderStyle = BorderStyle.FixedSingle
        txtDireccion.Location = New Point(108, 134)
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(356, 23)
        txtDireccion.TabIndex = 3
        ' 
        ' btnModificar
        ' 
        btnModificar.Cursor = Cursors.Hand
        btnModificar.Location = New Point(108, 228)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(167, 23)
        btnModificar.TabIndex = 14
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Enabled = False
        btnAgregar.Location = New Point(297, 228)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(167, 23)
        btnAgregar.TabIndex = 6
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' dgvClientes
        ' 
        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        dgvClientes.BackgroundColor = SystemColors.Control
        dgvClientes.BorderStyle = BorderStyle.Fixed3D
        dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClientes.Cursor = Cursors.Hand
        dgvClientes.GridColor = SystemColors.ControlDark
        dgvClientes.Location = New Point(12, 358)
        dgvClientes.MultiSelect = False
        dgvClientes.Name = "dgvClientes"
        dgvClientes.ReadOnly = True
        dgvClientes.RowHeadersWidth = 51
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvClientes.Size = New Size(1090, 205)
        dgvClientes.TabIndex = 36
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = SystemColors.Control
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.Enabled = False
        btnBuscar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBuscar.Location = New Point(1061, 311)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(41, 32)
        btnBuscar.TabIndex = 39
        btnBuscar.Text = "🔍"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(804, 323)
        Label8.Name = "Label8"
        Label8.Size = New Size(42, 15)
        Label8.TabIndex = 38
        Label8.Text = "Buscar"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(852, 311)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(203, 23)
        txtBuscar.TabIndex = 37
        ' 
        ' Clientes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1113, 575)
        Controls.Add(btnBuscar)
        Controls.Add(Label8)
        Controls.Add(txtBuscar)
        Controls.Add(dgvClientes)
        Controls.Add(btnBorrar)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "Clientes"
        Text = "Clientes"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvClientes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBorrar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents lblId As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBuscar As TextBox
End Class
