<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        pnlTarjetaProductos = New Panel()
        Label1 = New Label()
        lblCantidadProductos = New Label()
        PicProductos = New PictureBox()
        lblFecha = New Label()
        tmrActualizar = New Timer(components)
        btnActualizar = New Button()
        lblValorInventario = New Label()
        pnlFranjaInventario = New Panel()
        formsPlotStock = New ScottPlot.WinForms.FormsPlot()
        formsPlotMermas = New ScottPlot.WinForms.FormsPlot()
        lblPorVencer = New Label()
        pnlFranjaPorVencer = New Panel()
        formsPlotMotivos = New ScottPlot.WinForms.FormsPlot()
        dgvPorVencer = New DataGridView()
        lblPerdidaMermas = New Label()
        pnlFranjaMermas = New Panel()
        pnlFranjaVencidos = New Panel()
        lblTituloPorVencer = New Label()
        Label2 = New Label()
        Label3 = New Label()
        lblVencidos = New Label()
        Label4 = New Label()
        pnlTarjetaProductos.SuspendLayout()
        CType(PicProductos, ComponentModel.ISupportInitialize).BeginInit()
        pnlFranjaInventario.SuspendLayout()
        pnlFranjaPorVencer.SuspendLayout()
        CType(dgvPorVencer, ComponentModel.ISupportInitialize).BeginInit()
        pnlFranjaMermas.SuspendLayout()
        pnlFranjaVencidos.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTarjetaProductos
        ' 
        pnlTarjetaProductos.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        pnlTarjetaProductos.Controls.Add(Label1)
        pnlTarjetaProductos.Controls.Add(lblCantidadProductos)
        pnlTarjetaProductos.Controls.Add(PicProductos)
        pnlTarjetaProductos.Location = New Point(914, 27)
        pnlTarjetaProductos.Margin = New Padding(3, 2, 3, 2)
        pnlTarjetaProductos.Name = "pnlTarjetaProductos"
        pnlTarjetaProductos.Size = New Size(181, 94)
        pnlTarjetaProductos.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(3, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(174, 22)
        Label1.TabIndex = 4
        Label1.Text = "Productos activos"
        ' 
        ' lblCantidadProductos
        ' 
        lblCantidadProductos.AutoSize = True
        lblCantidadProductos.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCantidadProductos.ForeColor = Color.White
        lblCantidadProductos.Location = New Point(125, 49)
        lblCantidadProductos.Name = "lblCantidadProductos"
        lblCantidadProductos.Size = New Size(38, 45)
        lblCantidadProductos.TabIndex = 2
        lblCantidadProductos.Text = "1"
        ' 
        ' PicProductos
        ' 
        PicProductos.Image = CType(resources.GetObject("PicProductos.Image"), Image)
        PicProductos.Location = New Point(84, 53)
        PicProductos.Margin = New Padding(3, 2, 3, 2)
        PicProductos.Name = "PicProductos"
        PicProductos.Size = New Size(35, 30)
        PicProductos.SizeMode = PictureBoxSizeMode.Zoom
        PicProductos.TabIndex = 0
        PicProductos.TabStop = False
        ' 
        ' lblFecha
        ' 
        lblFecha.AutoSize = True
        lblFecha.Location = New Point(796, 535)
        lblFecha.Name = "lblFecha"
        lblFecha.Size = New Size(38, 15)
        lblFecha.TabIndex = 9
        lblFecha.Text = "Fecha"
        ' 
        ' tmrActualizar
        ' 
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Location = New Point(998, 296)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(100, 38)
        btnActualizar.TabIndex = 10
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' lblValorInventario
        ' 
        lblValorInventario.AutoSize = True
        lblValorInventario.Location = New Point(114, 9)
        lblValorInventario.Name = "lblValorInventario"
        lblValorInventario.Size = New Size(89, 15)
        lblValorInventario.TabIndex = 11
        lblValorInventario.Text = "Valor Inventario"
        ' 
        ' pnlFranjaInventario
        ' 
        pnlFranjaInventario.Controls.Add(formsPlotStock)
        pnlFranjaInventario.Location = New Point(15, 27)
        pnlFranjaInventario.Name = "pnlFranjaInventario"
        pnlFranjaInventario.Size = New Size(438, 223)
        pnlFranjaInventario.TabIndex = 12
        ' 
        ' formsPlotStock
        ' 
        formsPlotStock.Location = New Point(3, 3)
        formsPlotStock.Name = "formsPlotStock"
        formsPlotStock.Size = New Size(432, 217)
        formsPlotStock.TabIndex = 22
        ' 
        ' formsPlotMermas
        ' 
        formsPlotMermas.Location = New Point(3, 3)
        formsPlotMermas.Name = "formsPlotMermas"
        formsPlotMermas.Size = New Size(432, 215)
        formsPlotMermas.TabIndex = 23
        ' 
        ' lblPorVencer
        ' 
        lblPorVencer.AutoSize = True
        lblPorVencer.Location = New Point(815, 319)
        lblPorVencer.Name = "lblPorVencer"
        lblPorVencer.Size = New Size(63, 15)
        lblPorVencer.TabIndex = 13
        lblPorVencer.Text = "Por Vencer"
        ' 
        ' pnlFranjaPorVencer
        ' 
        pnlFranjaPorVencer.Controls.Add(formsPlotMotivos)
        pnlFranjaPorVencer.Location = New Point(459, 27)
        pnlFranjaPorVencer.Name = "pnlFranjaPorVencer"
        pnlFranjaPorVencer.Size = New Size(448, 223)
        pnlFranjaPorVencer.TabIndex = 14
        ' 
        ' formsPlotMotivos
        ' 
        formsPlotMotivos.Location = New Point(3, 3)
        formsPlotMotivos.Name = "formsPlotMotivos"
        formsPlotMotivos.Size = New Size(442, 217)
        formsPlotMotivos.TabIndex = 21
        ' 
        ' dgvPorVencer
        ' 
        dgvPorVencer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPorVencer.Location = New Point(3, 3)
        dgvPorVencer.Name = "dgvPorVencer"
        dgvPorVencer.Size = New Size(633, 158)
        dgvPorVencer.TabIndex = 20
        ' 
        ' lblPerdidaMermas
        ' 
        lblPerdidaMermas.AutoSize = True
        lblPerdidaMermas.Location = New Point(139, 265)
        lblPerdidaMermas.Name = "lblPerdidaMermas"
        lblPerdidaMermas.Size = New Size(93, 15)
        lblPerdidaMermas.TabIndex = 17
        lblPerdidaMermas.Text = "Perdida Mermas"
        ' 
        ' pnlFranjaMermas
        ' 
        pnlFranjaMermas.Controls.Add(formsPlotMermas)
        pnlFranjaMermas.Location = New Point(16, 283)
        pnlFranjaMermas.Name = "pnlFranjaMermas"
        pnlFranjaMermas.Size = New Size(438, 221)
        pnlFranjaMermas.TabIndex = 18
        ' 
        ' pnlFranjaVencidos
        ' 
        pnlFranjaVencidos.Controls.Add(dgvPorVencer)
        pnlFranjaVencidos.Location = New Point(459, 340)
        pnlFranjaVencidos.Name = "pnlFranjaVencidos"
        pnlFranjaVencidos.Size = New Size(639, 164)
        pnlFranjaVencidos.TabIndex = 19
        ' 
        ' lblTituloPorVencer
        ' 
        lblTituloPorVencer.AutoSize = True
        lblTituloPorVencer.Location = New Point(462, 319)
        lblTituloPorVencer.Name = "lblTituloPorVencer"
        lblTituloPorVencer.Size = New Size(96, 15)
        lblTituloPorVencer.TabIndex = 24
        lblTituloPorVencer.Text = "Titulo Por Vencer"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 15)
        Label2.TabIndex = 25
        Label2.Text = "Valor Inventario:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 265)
        Label3.Name = "Label3"
        Label3.Size = New Size(117, 15)
        Label3.TabIndex = 26
        Label3.Text = "Perdida por mermas:"
        ' 
        ' lblVencidos
        ' 
        lblVencidos.AutoSize = True
        lblVencidos.Location = New Point(705, 283)
        lblVencidos.Name = "lblVencidos"
        lblVencidos.Size = New Size(54, 15)
        lblVencidos.TabIndex = 15
        lblVencidos.Text = "Vencidos"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(743, 319)
        Label4.Name = "Label4"
        Label4.Size = New Size(66, 15)
        Label4.TabIndex = 27
        Label4.Text = "Por Vencer:"
        ' 
        ' frmDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1113, 575)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(lblTituloPorVencer)
        Controls.Add(pnlFranjaVencidos)
        Controls.Add(pnlFranjaMermas)
        Controls.Add(lblPerdidaMermas)
        Controls.Add(lblVencidos)
        Controls.Add(pnlFranjaPorVencer)
        Controls.Add(lblPorVencer)
        Controls.Add(pnlFranjaInventario)
        Controls.Add(lblValorInventario)
        Controls.Add(btnActualizar)
        Controls.Add(lblFecha)
        Controls.Add(pnlTarjetaProductos)
        Margin = New Padding(3, 2, 3, 2)
        Name = "frmDashboard"
        Text = "frmDashboard"
        pnlTarjetaProductos.ResumeLayout(False)
        pnlTarjetaProductos.PerformLayout()
        CType(PicProductos, ComponentModel.ISupportInitialize).EndInit()
        pnlFranjaInventario.ResumeLayout(False)
        pnlFranjaPorVencer.ResumeLayout(False)
        CType(dgvPorVencer, ComponentModel.ISupportInitialize).EndInit()
        pnlFranjaMermas.ResumeLayout(False)
        pnlFranjaVencidos.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlTarjetaProductos As Panel
    Friend WithEvents PicProductos As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCantidadProductos As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents tmrActualizar As Timer
    Friend WithEvents btnActualizar As Button
    Friend WithEvents lblValorInventario As Label
    Friend WithEvents pnlFranjaInventario As Panel
    Friend WithEvents lblPorVencer As Label
    Friend WithEvents pnlFranjaPorVencer As Panel
    Friend WithEvents lblPerdidaMermas As Label
    Friend WithEvents pnlFranjaMermas As Panel
    Friend WithEvents pnlFranjaVencidos As Panel
    Friend WithEvents dgvPorVencer As DataGridView
    Friend WithEvents formsPlotMotivos As ScottPlot.WinForms.FormsPlot
    Friend WithEvents formsPlotStock As ScottPlot.WinForms.FormsPlot
    Friend WithEvents formsPlotMermas As ScottPlot.WinForms.FormsPlot
    Friend WithEvents lblTituloPorVencer As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblVencidos As Label
    Friend WithEvents Label4 As Label
End Class
