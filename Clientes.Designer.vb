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
        Label4 = New Label()
        Label3 = New Label()
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
        btnBorrar.Location = New Point(26, 349)
        btnBorrar.Margin = New Padding(3, 4, 3, 4)
        btnBorrar.Name = "btnBorrar"
        btnBorrar.Size = New Size(103, 31)
        btnBorrar.TabIndex = 34
        btnBorrar.Text = "Dar de baja"
        btnBorrar.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(59, 115)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 20)
        Label6.TabIndex = 33
        Label6.Text = "Teléfono"
        ' 
        ' txtTelefono
        ' 
        txtTelefono.BorderStyle = BorderStyle.FixedSingle
        txtTelefono.Location = New Point(278, 136)
        txtTelefono.Margin = New Padding(3, 4, 3, 4)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(406, 27)
        txtTelefono.TabIndex = 23
        ' 
        ' lblId
        ' 
        lblId.AutoSize = True
        lblId.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblId.Location = New Point(302, 49)
        lblId.Name = "lblId"
        lblId.Size = New Size(0, 37)
        lblId.TabIndex = 32
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(175, 61)
        Label5.Name = "Label5"
        Label5.Size = New Size(58, 20)
        Label5.TabIndex = 31
        Label5.Text = "Codigo"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(175, 256)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 20)
        Label4.TabIndex = 30
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(175, 179)
        Label3.Name = "Label3"
        Label3.Size = New Size(0, 20)
        Label3.TabIndex = 29
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(175, 217)
        Label2.Name = "Label2"
        Label2.Size = New Size(46, 20)
        Label2.TabIndex = 28
        Label2.Text = "Email"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(62, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 20)
        Label1.TabIndex = 27
        Label1.Text = "Nombre"
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.Location = New Point(278, 213)
        txtEmail.Margin = New Padding(3, 4, 3, 4)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(406, 27)
        txtEmail.TabIndex = 25
        ' 
        ' txtNombre
        ' 
        txtNombre.BorderStyle = BorderStyle.FixedSingle
        txtNombre.Location = New Point(278, 97)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(406, 27)
        txtNombre.TabIndex = 22
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(txtDireccion)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(btnModificar)
        GroupBox1.Controls.Add(btnAgregar)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(116, 23)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(587, 297)
        GroupBox1.TabIndex = 35
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del cliente"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(59, 156)
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
        ' btnModificar
        ' 
        btnModificar.Cursor = Cursors.Hand
        btnModificar.Location = New Point(95, 245)
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
        btnAgregar.Location = New Point(244, 245)
        btnAgregar.Margin = New Padding(3, 4, 3, 4)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(143, 31)
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
        dgvClientes.Location = New Point(12, 388)
        dgvClientes.Margin = New Padding(3, 4, 3, 4)
        dgvClientes.MultiSelect = False
        dgvClientes.Name = "dgvClientes"
        dgvClientes.ReadOnly = True
        dgvClientes.RowHeadersWidth = 51
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvClientes.Size = New Size(1246, 120)
        dgvClientes.TabIndex = 36
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = SystemColors.Control
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.Enabled = False
        btnBuscar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBuscar.Location = New Point(1017, 347)
        btnBuscar.Margin = New Padding(3, 4, 3, 4)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(47, 31)
        btnBuscar.TabIndex = 39
        btnBuscar.Text = "🔍"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(725, 354)
        Label8.Name = "Label8"
        Label8.Size = New Size(52, 20)
        Label8.TabIndex = 38
        Label8.Text = "Buscar"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(780, 349)
        txtBuscar.Margin = New Padding(3, 4, 3, 4)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(231, 27)
        txtBuscar.TabIndex = 37
        ' 
        ' Clientes
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1272, 543)
        Controls.Add(btnBuscar)
        Controls.Add(Label8)
        Controls.Add(txtBuscar)
        Controls.Add(dgvClientes)
        Controls.Add(btnBorrar)
        Controls.Add(txtTelefono)
        Controls.Add(lblId)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(txtEmail)
        Controls.Add(txtNombre)
        Controls.Add(GroupBox1)
        Margin = New Padding(3, 4, 3, 4)
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
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
