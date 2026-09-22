<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox1 = New PictureBox()
        btnStock = New Button()
        btnProv = New Button()
        btnClientes = New Button()
        lblHoraActual = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(417, 122)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(450, 259)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' btnStock
        ' 
        btnStock.BackColor = SystemColors.Control
        btnStock.Cursor = Cursors.Hand
        btnStock.FlatAppearance.BorderSize = 0
        btnStock.FlatStyle = FlatStyle.Flat
        btnStock.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        btnStock.Location = New Point(130, 122)
        btnStock.Name = "btnStock"
        btnStock.Size = New Size(104, 37)
        btnStock.TabIndex = 1
        btnStock.Text = "STOCK"
        btnStock.UseVisualStyleBackColor = False
        ' 
        ' btnProv
        ' 
        btnProv.BackColor = SystemColors.Control
        btnProv.Cursor = Cursors.Hand
        btnProv.FlatAppearance.BorderSize = 0
        btnProv.FlatStyle = FlatStyle.Flat
        btnProv.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        btnProv.Location = New Point(130, 232)
        btnProv.Name = "btnProv"
        btnProv.Size = New Size(104, 37)
        btnProv.TabIndex = 2
        btnProv.Text = "PROVEEDORES"
        btnProv.UseVisualStyleBackColor = False
        ' 
        ' btnClientes
        ' 
        btnClientes.BackColor = SystemColors.Control
        btnClientes.Cursor = Cursors.Hand
        btnClientes.FlatAppearance.BorderSize = 0
        btnClientes.FlatStyle = FlatStyle.Flat
        btnClientes.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        btnClientes.Location = New Point(130, 344)
        btnClientes.Name = "btnClientes"
        btnClientes.Size = New Size(104, 37)
        btnClientes.TabIndex = 3
        btnClientes.Text = "CLIENTES"
        btnClientes.UseVisualStyleBackColor = False
        ' 
        ' lblHoraActual
        ' 
        lblHoraActual.AutoSize = True
        lblHoraActual.Font = New Font("Segoe UI", 12F)
        lblHoraActual.ForeColor = Color.Black
        lblHoraActual.Location = New Point(686, 461)
        lblHoraActual.Name = "lblHoraActual"
        lblHoraActual.Size = New Size(19, 21)
        lblHoraActual.TabIndex = 4
        lblHoraActual.Text = "..."
        lblHoraActual.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(879, 491)
        Controls.Add(lblHoraActual)
        Controls.Add(btnClientes)
        Controls.Add(btnProv)
        Controls.Add(btnStock)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Verduleria ""THIAN"""
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnStock As Button
    Friend WithEvents btnProv As Button
    Friend WithEvents btnClientes As Button
    Friend WithEvents lblHoraActual As Label

End Class
