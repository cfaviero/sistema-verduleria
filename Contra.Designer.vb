<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contra
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
        Label2 = New Label()
        txtRepContra = New TextBox()
        Label7 = New Label()
        txtContra = New TextBox()
        lblContra = New Label()
        btnCrear = New Button()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 195)
        Label2.Name = "Label2"
        Label2.Size = New Size(113, 15)
        Label2.TabIndex = 42
        Label2.Text = "Repita la contraseña"
        ' 
        ' txtRepContra
        ' 
        txtRepContra.BorderStyle = BorderStyle.FixedSingle
        txtRepContra.Location = New Point(151, 193)
        txtRepContra.Name = "txtRepContra"
        txtRepContra.Size = New Size(224, 23)
        txtRepContra.TabIndex = 2
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(70, 166)
        Label7.Name = "Label7"
        Label7.Size = New Size(67, 15)
        Label7.TabIndex = 41
        Label7.Text = "Contraseña"
        ' 
        ' txtContra
        ' 
        txtContra.BorderStyle = BorderStyle.FixedSingle
        txtContra.Location = New Point(151, 164)
        txtContra.Name = "txtContra"
        txtContra.Size = New Size(224, 23)
        txtContra.TabIndex = 1
        ' 
        ' lblContra
        ' 
        lblContra.AutoSize = True
        lblContra.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblContra.Location = New Point(90, 59)
        lblContra.Name = "lblContra"
        lblContra.Size = New Size(201, 25)
        lblContra.TabIndex = 43
        lblContra.Text = "Ingrese la contraseña"
        ' 
        ' btnCrear
        ' 
        btnCrear.Location = New Point(268, 236)
        btnCrear.Name = "btnCrear"
        btnCrear.Size = New Size(75, 23)
        btnCrear.TabIndex = 44
        btnCrear.Text = "Crear"
        btnCrear.UseVisualStyleBackColor = True
        ' 
        ' Contra
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(407, 285)
        Controls.Add(btnCrear)
        Controls.Add(lblContra)
        Controls.Add(Label2)
        Controls.Add(txtRepContra)
        Controls.Add(Label7)
        Controls.Add(txtContra)
        Name = "Contra"
        Text = "Contra"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents txtRepContra As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtContra As TextBox
    Friend WithEvents lblContra As Label
    Friend WithEvents btnCrear As Button
End Class
