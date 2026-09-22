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
        dgvStock = New DataGridView()
        txtNombre = New TextBox()
        txtPrecio = New TextBox()
        txtStock = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        cmbCategoria = New ComboBox()
        CType(dgvStock, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvStock
        ' 
        dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgvStock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        dgvStock.BackgroundColor = SystemColors.ActiveCaptionText
        dgvStock.BorderStyle = BorderStyle.Fixed3D
        dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStock.Cursor = Cursors.Hand
        dgvStock.GridColor = Color.Gold
        dgvStock.Location = New Point(12, 256)
        dgvStock.MultiSelect = False
        dgvStock.Name = "dgvStock"
        dgvStock.ReadOnly = True
        dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStock.Size = New Size(440, 180)
        dgvStock.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(142, 62)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(139, 23)
        txtNombre.TabIndex = 1
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Location = New Point(142, 105)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(139, 23)
        txtPrecio.TabIndex = 2
        ' 
        ' txtStock
        ' 
        txtStock.Location = New Point(142, 148)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(139, 23)
        txtStock.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(52, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 15)
        Label1.TabIndex = 5
        Label1.Text = "Nombre"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(52, 108)
        Label2.Name = "Label2"
        Label2.Size = New Size(40, 15)
        Label2.TabIndex = 6
        Label2.Text = "Precio"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(52, 151)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 15)
        Label3.TabIndex = 7
        Label3.Text = "Stock Actual"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(52, 194)
        Label4.Name = "Label4"
        Label4.Size = New Size(58, 15)
        Label4.TabIndex = 8
        Label4.Text = "Categoría"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(52, 21)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 15)
        Label5.TabIndex = 9
        Label5.Text = "Codigo"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(207, 21)
        Label6.Name = "Label6"
        Label6.Size = New Size(12, 15)
        Label6.TabIndex = 10
        Label6.Text = "-"
        ' 
        ' cmbCategoria
        ' 
        cmbCategoria.FormattingEnabled = True
        cmbCategoria.Location = New Point(142, 191)
        cmbCategoria.Name = "cmbCategoria"
        cmbCategoria.Size = New Size(139, 23)
        cmbCategoria.TabIndex = 11
        ' 
        ' stock
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 448)
        Controls.Add(cmbCategoria)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtStock)
        Controls.Add(txtPrecio)
        Controls.Add(txtNombre)
        Controls.Add(dgvStock)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "stock"
        Text = "Stock"
        CType(dgvStock, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCategoria As ComboBox
End Class
