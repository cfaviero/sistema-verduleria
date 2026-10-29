<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios))
        btnBuscar = New Button()
        Label8 = New Label()
        txtBuscar = New TextBox()
        dgvUsuarios = New DataGridView()
        btnBorrar = New Button()
        GroupBox1 = New GroupBox()
        rbUsuario = New RadioButton()
        rbAdmin = New RadioButton()
        txtDescripUser = New TextBox()
        Label6 = New Label()
        btnModificar = New Button()
        btnAgregar = New Button()
        Label1 = New Label()
        txtUsuario = New TextBox()
        CType(dgvUsuarios, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = SystemColors.Control
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.Enabled = False
        btnBuscar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBuscar.Location = New Point(1060, 317)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(41, 31)
        btnBuscar.TabIndex = 47
        btnBuscar.Text = "🔍"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(803, 327)
        Label8.Name = "Label8"
        Label8.Size = New Size(42, 15)
        Label8.TabIndex = 46
        Label8.Text = "Buscar"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(851, 314)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(203, 23)
        txtBuscar.TabIndex = 45
        ' 
        ' dgvUsuarios
        ' 
        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        dgvUsuarios.BackgroundColor = SystemColors.Control
        dgvUsuarios.BorderStyle = BorderStyle.Fixed3D
        dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsuarios.Cursor = Cursors.Hand
        dgvUsuarios.GridColor = SystemColors.ControlDark
        dgvUsuarios.Location = New Point(12, 354)
        dgvUsuarios.MultiSelect = False
        dgvUsuarios.Name = "dgvUsuarios"
        dgvUsuarios.ReadOnly = True
        dgvUsuarios.RowHeadersWidth = 51
        dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsuarios.Size = New Size(1089, 209)
        dgvUsuarios.TabIndex = 44
        ' 
        ' btnBorrar
        ' 
        btnBorrar.Cursor = Cursors.Hand
        btnBorrar.Enabled = False
        btnBorrar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBorrar.ForeColor = Color.Red
        btnBorrar.Location = New Point(12, 317)
        btnBorrar.Name = "btnBorrar"
        btnBorrar.Size = New Size(90, 23)
        btnBorrar.TabIndex = 42
        btnBorrar.Text = "Dar de baja"
        btnBorrar.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(rbUsuario)
        GroupBox1.Controls.Add(rbAdmin)
        GroupBox1.Controls.Add(txtDescripUser)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(btnModificar)
        GroupBox1.Controls.Add(btnAgregar)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtUsuario)
        GroupBox1.Location = New Point(12, 22)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(514, 223)
        GroupBox1.TabIndex = 43
        GroupBox1.TabStop = False
        GroupBox1.Text = "Datos del Usuario"
        ' 
        ' rbUsuario
        ' 
        rbUsuario.Appearance = Appearance.Button
        rbUsuario.AutoSize = True
        rbUsuario.Checked = True
        rbUsuario.Location = New Point(400, 27)
        rbUsuario.Name = "rbUsuario"
        rbUsuario.Size = New Size(57, 25)
        rbUsuario.TabIndex = 49
        rbUsuario.TabStop = True
        rbUsuario.Text = "Usuario"
        rbUsuario.TextAlign = ContentAlignment.MiddleCenter
        rbUsuario.UseVisualStyleBackColor = True
        ' 
        ' rbAdmin
        ' 
        rbAdmin.Appearance = Appearance.Button
        rbAdmin.AutoSize = True
        rbAdmin.Location = New Point(289, 27)
        rbAdmin.Name = "rbAdmin"
        rbAdmin.Size = New Size(93, 25)
        rbAdmin.TabIndex = 48
        rbAdmin.Text = "Administrador"
        rbAdmin.TextAlign = ContentAlignment.MiddleCenter
        rbAdmin.UseVisualStyleBackColor = True
        ' 
        ' txtDescripUser
        ' 
        txtDescripUser.BorderStyle = BorderStyle.FixedSingle
        txtDescripUser.Location = New Point(120, 105)
        txtDescripUser.Name = "txtDescripUser"
        txtDescripUser.Size = New Size(356, 23)
        txtDescripUser.TabIndex = 2
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(38, 113)
        Label6.Name = "Label6"
        Label6.Size = New Size(69, 15)
        Label6.TabIndex = 33
        Label6.Text = "Descripcion"
        ' 
        ' btnModificar
        ' 
        btnModificar.Cursor = Cursors.Hand
        btnModificar.Location = New Point(120, 180)
        btnModificar.Name = "btnModificar"
        btnModificar.Size = New Size(168, 23)
        btnModificar.TabIndex = 14
        btnModificar.Text = "Modificar"
        btnModificar.UseVisualStyleBackColor = True
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Enabled = False
        btnAgregar.Location = New Point(308, 180)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(168, 23)
        btnAgregar.TabIndex = 6
        btnAgregar.Text = "Nuevo Usuario"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 66)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 27
        Label1.Text = "Usuario"
        ' 
        ' txtUsuario
        ' 
        txtUsuario.BorderStyle = BorderStyle.FixedSingle
        txtUsuario.Location = New Point(120, 58)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(356, 23)
        txtUsuario.TabIndex = 1
        ' 
        ' Usuarios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1113, 575)
        Controls.Add(btnBuscar)
        Controls.Add(Label8)
        Controls.Add(txtBuscar)
        Controls.Add(dgvUsuarios)
        Controls.Add(btnBorrar)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Usuarios"
        Text = "Usuarios"
        CType(dgvUsuarios, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents btnBorrar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtDescripUser As TextBox
    Friend WithEvents rbUsuario As RadioButton
    Friend WithEvents rbAdmin As RadioButton
End Class
