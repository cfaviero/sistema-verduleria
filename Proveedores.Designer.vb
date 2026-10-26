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
        cklProveedores = New CheckedListBox()
        btnGuardar = New Button()
        Label1 = New Label()
        lblDescrip = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' cklProveedores
        ' 
        cklProveedores.BackColor = SystemColors.Control
        cklProveedores.BorderStyle = BorderStyle.None
        cklProveedores.CheckOnClick = True
        cklProveedores.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cklProveedores.FormattingEnabled = True
        cklProveedores.Location = New Point(12, 106)
        cklProveedores.Name = "cklProveedores"
        cklProveedores.Size = New Size(398, 234)
        cklProveedores.TabIndex = 1
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnGuardar.Location = New Point(556, 371)
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
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(453, 48)
        Label1.TabIndex = 4
        Label1.Text = "Seleccione los proveedores"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDescrip
        ' 
        lblDescrip.AutoSize = True
        lblDescrip.Location = New Point(509, 154)
        lblDescrip.Name = "lblDescrip"
        lblDescrip.Size = New Size(12, 15)
        lblDescrip.TabIndex = 5
        lblDescrip.Text = "-"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(464, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(87, 15)
        Label2.TabIndex = 6
        Label2.Text = "Observaciones:"
        ' 
        ' Proveedores
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label2)
        Controls.Add(lblDescrip)
        Controls.Add(Label1)
        Controls.Add(btnGuardar)
        Controls.Add(cklProveedores)
        Name = "Proveedores"
        Text = "Proveedores"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents cklProveedores As CheckedListBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDescrip As Label
    Friend WithEvents Label2 As Label
End Class
