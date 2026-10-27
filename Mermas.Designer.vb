<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mermas
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
        txtBuscar = New TextBox()
        txtCantidad = New TextBox()
        dgvLotes = New DataGridView()
        cmbMotivo = New ComboBox()
        btnRegistrar = New Button()
        btnBaja = New Button()
        dtpDesde = New DateTimePicker()
        dgvHistorial = New DataGridView()
        dtpHasta = New DateTimePicker()
        chkSoloVencidos = New CheckBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        CType(dgvLotes, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvHistorial, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(111, 31)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(100, 23)
        txtBuscar.TabIndex = 0
        ' 
        ' txtCantidad
        ' 
        txtCantidad.Location = New Point(644, 31)
        txtCantidad.Name = "txtCantidad"
        txtCantidad.Size = New Size(100, 23)
        txtCantidad.TabIndex = 1
        ' 
        ' dgvLotes
        ' 
        dgvLotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLotes.Location = New Point(62, 80)
        dgvLotes.Name = "dgvLotes"
        dgvLotes.Size = New Size(1005, 191)
        dgvLotes.TabIndex = 2
        ' 
        ' cmbMotivo
        ' 
        cmbMotivo.FormattingEnabled = True
        cmbMotivo.Location = New Point(827, 36)
        cmbMotivo.Name = "cmbMotivo"
        cmbMotivo.Size = New Size(121, 23)
        cmbMotivo.TabIndex = 3
        ' 
        ' btnRegistrar
        ' 
        btnRegistrar.Location = New Point(992, 35)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(75, 23)
        btnRegistrar.TabIndex = 4
        btnRegistrar.Text = "Registrar"
        btnRegistrar.UseVisualStyleBackColor = True
        ' 
        ' btnBaja
        ' 
        btnBaja.Location = New Point(992, 277)
        btnBaja.Name = "btnBaja"
        btnBaja.Size = New Size(75, 23)
        btnBaja.TabIndex = 5
        btnBaja.Text = "Baja"
        btnBaja.UseVisualStyleBackColor = True
        ' 
        ' dtpDesde
        ' 
        dtpDesde.Location = New Point(445, 534)
        dtpDesde.Name = "dtpDesde"
        dtpDesde.Size = New Size(261, 23)
        dtpDesde.TabIndex = 6
        ' 
        ' dgvHistorial
        ' 
        dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHistorial.Location = New Point(62, 323)
        dgvHistorial.Name = "dgvHistorial"
        dgvHistorial.Size = New Size(1005, 191)
        dgvHistorial.TabIndex = 7
        ' 
        ' dtpHasta
        ' 
        dtpHasta.Location = New Point(806, 534)
        dtpHasta.Name = "dtpHasta"
        dtpHasta.Size = New Size(261, 23)
        dtpHasta.TabIndex = 8
        ' 
        ' chkSoloVencidos
        ' 
        chkSoloVencidos.AutoSize = True
        chkSoloVencidos.Location = New Point(913, 281)
        chkSoloVencidos.Name = "chkSoloVencidos"
        chkSoloVencidos.Size = New Size(73, 19)
        chkSoloVencidos.TabIndex = 9
        chkSoloVencidos.Text = "Vencidos"
        chkSoloVencidos.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(63, 39)
        Label1.Name = "Label1"
        Label1.Size = New Size(42, 15)
        Label1.TabIndex = 10
        Label1.Text = "Buscar"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(583, 39)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 15)
        Label2.TabIndex = 11
        Label2.Text = "Cantidad"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(776, 39)
        Label3.Name = "Label3"
        Label3.Size = New Size(45, 15)
        Label3.TabIndex = 12
        Label3.Text = "Motivo"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(400, 542)
        Label4.Name = "Label4"
        Label4.Size = New Size(39, 15)
        Label4.TabIndex = 13
        Label4.Text = "Desde"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(763, 542)
        Label5.Name = "Label5"
        Label5.Size = New Size(37, 15)
        Label5.TabIndex = 14
        Label5.Text = "Hasta"
        ' 
        ' Mermas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1113, 575)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(chkSoloVencidos)
        Controls.Add(dtpHasta)
        Controls.Add(dgvHistorial)
        Controls.Add(dtpDesde)
        Controls.Add(btnBaja)
        Controls.Add(btnRegistrar)
        Controls.Add(cmbMotivo)
        Controls.Add(dgvLotes)
        Controls.Add(txtCantidad)
        Controls.Add(txtBuscar)
        Name = "Mermas"
        Text = "Mermas"
        CType(dgvLotes, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvHistorial, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents dgvLotes As DataGridView
    Friend WithEvents cmbMotivo As ComboBox
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents btnBaja As Button
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents dgvHistorial As DataGridView
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents chkSoloVencidos As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
