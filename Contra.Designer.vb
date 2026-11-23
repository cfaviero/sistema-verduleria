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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contra))
        Label2 = New Label()
        txtRepContra = New TextBox()
        Label1 = New Label()
        txtContra = New TextBox()
        lblContra = New Label()
        btnCrear = New Button()
        PictureBox3 = New PictureBox()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 184)
        Label2.Name = "Label2"
        Label2.Size = New Size(113, 15)
        Label2.TabIndex = 42
        Label2.Text = "Repita la contraseña"
        ' 
        ' txtRepContra
        ' 
        txtRepContra.BorderStyle = BorderStyle.FixedSingle
        txtRepContra.Location = New Point(151, 176)
        txtRepContra.Name = "txtRepContra"
        txtRepContra.PasswordChar = "*"c
        txtRepContra.Size = New Size(224, 23)
        txtRepContra.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(35, 139)
        Label1.Name = "Label1"
        Label1.Size = New Size(102, 15)
        Label1.TabIndex = 41
        Label1.Text = "Contraseña nueva"
        ' 
        ' txtContra
        ' 
        txtContra.BorderStyle = BorderStyle.FixedSingle
        txtContra.Location = New Point(151, 131)
        txtContra.Name = "txtContra"
        txtContra.PasswordChar = "*"c
        txtContra.Size = New Size(224, 23)
        txtContra.TabIndex = 1
        ' 
        ' lblContra
        ' 
        lblContra.AutoSize = True
        lblContra.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblContra.Location = New Point(90, 73)
        lblContra.Name = "lblContra"
        lblContra.Size = New Size(201, 25)
        lblContra.TabIndex = 43
        lblContra.Text = "Ingrese la contraseña"
        ' 
        ' btnCrear
        ' 
        btnCrear.Location = New Point(300, 250)
        btnCrear.Name = "btnCrear"
        btnCrear.Size = New Size(75, 23)
        btnCrear.TabIndex = 44
        btnCrear.Text = "Crear"
        btnCrear.UseVisualStyleBackColor = True
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.pass
        PictureBox3.Location = New Point(174, 35)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(35, 30)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 45
        PictureBox3.TabStop = False
        ' 
        ' Contra
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(407, 285)
        Controls.Add(PictureBox3)
        Controls.Add(btnCrear)
        Controls.Add(lblContra)
        Controls.Add(Label2)
        Controls.Add(txtRepContra)
        Controls.Add(Label1)
        Controls.Add(txtContra)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Contra"
        Text = "Contraseña"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents txtRepContra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtContra As TextBox
    Friend WithEvents lblContra As Label
    Friend WithEvents btnCrear As Button
    Friend WithEvents PictureBox3 As PictureBox
End Class
