<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proveedores
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
        lblProducto = New Label()
        cklProveedores = New CheckedListBox()
        btnGuardar = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' lblProducto
        ' 
        lblProducto.AutoSize = True
        lblProducto.Font = New Font("Segoe UI", 27F, FontStyle.Bold)
        lblProducto.Location = New Point(24, 25)
        lblProducto.Name = "lblProducto"
        lblProducto.Size = New Size(175, 48)
        lblProducto.TabIndex = 0
        lblProducto.Text = "Producto"
        ' 
        ' cklProveedores
        ' 
        cklProveedores.BorderStyle = BorderStyle.None
        cklProveedores.CheckOnClick = True
        cklProveedores.FormattingEnabled = True
        cklProveedores.Location = New Point(24, 105)
        cklProveedores.Name = "cklProveedores"
        cklProveedores.Size = New Size(209, 234)
        cklProveedores.TabIndex = 1
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnGuardar.Location = New Point(24, 360)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(209, 43)
        btnGuardar.TabIndex = 2
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Popup
        Label1.Font = New Font("Segoe UI", 27F)
        Label1.Location = New Point(335, 355)
        Label1.Name = "Label1"
        Label1.Size = New Size(453, 48)
        Label1.TabIndex = 4
        Label1.Text = "Seleccione los proveedores"
        ' 
        ' Proveedores
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(btnGuardar)
        Controls.Add(cklProveedores)
        Controls.Add(lblProducto)
        Name = "Proveedores"
        Text = "Proveedores"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblProducto As Label
    Friend WithEvents cklProveedores As CheckedListBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label1 As Label
End Class
