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
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        pnlCabecera = New Panel()
        btnCerrrar = New Button()
        PictureBox2 = New PictureBox()
        lblBien = New Label()
        PictureBox3 = New PictureBox()
        Panel1 = New Panel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        pnlCabecera.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnEntrar
        ' 
        btnEntrar.Location = New Point(97, 380)
        btnEntrar.Name = "btnEntrar"
        btnEntrar.Size = New Size(235, 40)
        btnEntrar.TabIndex = 3
        btnEntrar.Text = "Entrar"
        btnEntrar.UseVisualStyleBackColor = True
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(150, 292)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(177, 23)
        txtUsuario.TabIndex = 1
        ' 
        ' txtContra
        ' 
        txtContra.Location = New Point(150, 334)
        txtContra.Name = "txtContra"
        txtContra.PasswordChar = "*"c
        txtContra.Size = New Size(177, 23)
        txtContra.TabIndex = 2
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(102, 28)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(194, 124)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(102, 181)
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
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.user
        PictureBox2.Location = New Point(90, 242)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(35, 30)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 7
        PictureBox2.TabStop = False
        ' 
        ' lblBien
        ' 
        lblBien.AutoSize = True
        lblBien.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblBien.Location = New Point(143, 145)
        lblBien.Name = "lblBien"
        lblBien.Size = New Size(123, 30)
        lblBien.TabIndex = 8
        lblBien.Text = "Bienvenido"
        lblBien.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.pass
        PictureBox3.Location = New Point(90, 283)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(35, 30)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(PictureBox3)
        Panel1.Controls.Add(lblBien)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(12, 52)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(402, 440)
        Panel1.TabIndex = 10
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(426, 485)
        Controls.Add(txtContra)
        Controls.Add(txtUsuario)
        Controls.Add(btnEntrar)
        Controls.Add(pnlCabecera)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Login"
        Text = "Login"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        pnlCabecera.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnEntrar As Button
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContra As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents btnCerrrar As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblBien As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel1 As Panel
End Class
