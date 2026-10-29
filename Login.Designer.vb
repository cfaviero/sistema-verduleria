<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        btnEntrar = New Button()
        txtUsuario = New TextBox()
        txtContra = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        pnlCabecera = New Panel()
        btnCerrrar = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        pnlCabecera.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnEntrar
        ' 
        btnEntrar.Location = New Point(236, 185)
        btnEntrar.Name = "btnEntrar"
        btnEntrar.Size = New Size(75, 40)
        btnEntrar.TabIndex = 3
        btnEntrar.Text = "Entrar"
        btnEntrar.UseVisualStyleBackColor = True
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(186, 97)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(125, 23)
        txtUsuario.TabIndex = 1
        ' 
        ' txtContra
        ' 
        txtContra.Location = New Point(186, 139)
        txtContra.Name = "txtContra"
        txtContra.PasswordChar = "*"c
        txtContra.Size = New Size(125, 23)
        txtContra.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(106, 105)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 0
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(106, 142)
        Label2.Name = "Label2"
        Label2.Size = New Size(67, 15)
        Label2.TabIndex = 0
        Label2.Text = "Contraseña"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(-94, 170)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(613, 378)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(76, 45)
        Label3.Name = "Label3"
        Label3.Size = New Size(235, 30)
        Label3.TabIndex = 5
        Label3.Text = "Ingrese para continuar"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlCabecera
        ' 
        pnlCabecera.Controls.Add(btnCerrrar)
        pnlCabecera.Location = New Point(0, 0)
        pnlCabecera.Name = "pnlCabecera"
        pnlCabecera.Size = New Size(427, 54)
        pnlCabecera.TabIndex = 6
        ' 
        ' btnCerrrar
        ' 
        btnCerrrar.Location = New Point(392, 12)
        btnCerrrar.Name = "btnCerrrar"
        btnCerrrar.Size = New Size(22, 23)
        btnCerrrar.TabIndex = 7
        btnCerrrar.Text = "X"
        btnCerrrar.TextAlign = ContentAlignment.MiddleLeft
        btnCerrrar.UseVisualStyleBackColor = True
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(426, 339)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtContra)
        Controls.Add(txtUsuario)
        Controls.Add(btnEntrar)
        Controls.Add(PictureBox1)
        Controls.Add(pnlCabecera)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Login"
        Text = "Login"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        pnlCabecera.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnEntrar As Button
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents btnCerrrar As Button
End Class
