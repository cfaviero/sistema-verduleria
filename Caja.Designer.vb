<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Caja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Caja))
        btnBuscar = New Button()
        Label7 = New Label()
        txtBuscar = New TextBox()
        dgvProductos = New DataGridView()
        btnAgregar = New Button()
        txtCantidad = New TextBox()
        Label2 = New Label()
        Label8 = New Label()
        cmbMetodoPago = New ComboBox()
        cmbCliente = New ComboBox()
        Label4 = New Label()
        lblTotal = New Label()
        btnQuitar = New Button()
        dgvCarrito = New DataGridView()
        btnConfirmar = New Button()
        btnCancelar = New Button()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PrintDocument1 = New Printing.PrintDocument()
        CType(dgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvCarrito, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = SystemColors.Control
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.Enabled = False
        btnBuscar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnBuscar.Location = New Point(289, 18)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(41, 39)
        btnBuscar.TabIndex = 34
        btnBuscar.Text = "🔍"
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(33, 30)
        Label7.Name = "Label7"
        Label7.Size = New Size(42, 15)
        Label7.TabIndex = 33
        Label7.Text = "Buscar"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(81, 18)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(203, 23)
        txtBuscar.TabIndex = 32
        ' 
        ' dgvProductos
        ' 
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        dgvProductos.BackgroundColor = SystemColors.Control
        dgvProductos.BorderStyle = BorderStyle.Fixed3D
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductos.Cursor = Cursors.Hand
        dgvProductos.GridColor = SystemColors.ControlDark
        dgvProductos.Location = New Point(33, 63)
        dgvProductos.MultiSelect = False
        dgvProductos.Name = "dgvProductos"
        dgvProductos.ReadOnly = True
        dgvProductos.RowHeadersWidth = 51
        dgvProductos.RowTemplate.Height = 70
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductos.Size = New Size(506, 217)
        dgvProductos.TabIndex = 27
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.Location = New Point(399, 309)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(120, 23)
        btnAgregar.TabIndex = 14
        btnAgregar.Text = "Agregar"
        btnAgregar.UseVisualStyleBackColor = True
        ' 
        ' txtCantidad
        ' 
        txtCantidad.BorderStyle = BorderStyle.FixedSingle
        txtCantidad.Location = New Point(98, 301)
        txtCantidad.Name = "txtCantidad"
        txtCantidad.Size = New Size(284, 23)
        txtCantidad.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(35, 309)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 15)
        Label2.TabIndex = 6
        Label2.Text = "Cantidad"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(840, 39)
        Label8.Name = "Label8"
        Label8.Size = New Size(79, 15)
        Label8.TabIndex = 16
        Label8.Text = "Metodo Pago"
        ' 
        ' cmbMetodoPago
        ' 
        cmbMetodoPago.FlatStyle = FlatStyle.Popup
        cmbMetodoPago.FormattingEnabled = True
        cmbMetodoPago.Location = New Point(925, 31)
        cmbMetodoPago.Name = "cmbMetodoPago"
        cmbMetodoPago.Size = New Size(176, 23)
        cmbMetodoPago.TabIndex = 15
        ' 
        ' cmbCliente
        ' 
        cmbCliente.FlatStyle = FlatStyle.Popup
        cmbCliente.FormattingEnabled = True
        cmbCliente.Location = New Point(619, 31)
        cmbCliente.Name = "cmbCliente"
        cmbCliente.Size = New Size(176, 23)
        cmbCliente.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(569, 39)
        Label4.Name = "Label4"
        Label4.Size = New Size(44, 15)
        Label4.TabIndex = 8
        Label4.Text = "Cliente"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(957, 469)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(32, 15)
        lblTotal.TabIndex = 10
        lblTotal.Text = "Total"
        ' 
        ' btnQuitar
        ' 
        btnQuitar.Cursor = Cursors.Hand
        btnQuitar.Enabled = False
        btnQuitar.Location = New Point(981, 299)
        btnQuitar.Name = "btnQuitar"
        btnQuitar.Size = New Size(120, 23)
        btnQuitar.TabIndex = 6
        btnQuitar.Text = "Quitar"
        btnQuitar.UseVisualStyleBackColor = True
        ' 
        ' dgvCarrito
        ' 
        dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgvCarrito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        dgvCarrito.BackgroundColor = SystemColors.Control
        dgvCarrito.BorderStyle = BorderStyle.Fixed3D
        dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCarrito.Cursor = Cursors.Hand
        dgvCarrito.GridColor = SystemColors.ControlDark
        dgvCarrito.Location = New Point(552, 63)
        dgvCarrito.MultiSelect = False
        dgvCarrito.Name = "dgvCarrito"
        dgvCarrito.ReadOnly = True
        dgvCarrito.RowHeadersWidth = 51
        dgvCarrito.RowTemplate.Height = 70
        dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCarrito.Size = New Size(549, 217)
        dgvCarrito.TabIndex = 44
        ' 
        ' btnConfirmar
        ' 
        btnConfirmar.Cursor = Cursors.Hand
        btnConfirmar.Enabled = False
        btnConfirmar.Location = New Point(981, 518)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Size = New Size(120, 45)
        btnConfirmar.TabIndex = 17
        btnConfirmar.Text = "Confirmar"
        btnConfirmar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.Enabled = False
        btnCancelar.Location = New Point(839, 518)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(120, 45)
        btnCancelar.TabIndex = 45
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' Caja
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1113, 575)
        Controls.Add(txtCantidad)
        Controls.Add(btnAgregar)
        Controls.Add(Label2)
        Controls.Add(cmbMetodoPago)
        Controls.Add(Label8)
        Controls.Add(btnCancelar)
        Controls.Add(btnConfirmar)
        Controls.Add(cmbCliente)
        Controls.Add(dgvCarrito)
        Controls.Add(btnQuitar)
        Controls.Add(Label4)
        Controls.Add(btnBuscar)
        Controls.Add(lblTotal)
        Controls.Add(Label7)
        Controls.Add(txtBuscar)
        Controls.Add(dgvProductos)
        Name = "Caja"
        Text = "Caja"
        CType(dgvProductos, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvCarrito, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnQuitar As Button
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvCarrito As DataGridView
    Friend WithEvents cmbMetodoPago As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
