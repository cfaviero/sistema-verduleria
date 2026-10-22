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
        pnlTarjetaProductos = New Panel()
        Label1 = New Label()
        lblCantidadProductos = New Label()
        PicProductos = New PictureBox()
        Label2 = New Label()
        lblCantidadMermas = New Label()
        PicMermas = New PictureBox()
        pnlTarjetaMermas = New Panel()
        pnlGrafico = New Panel()
        Label3 = New Label()
        formsPlotMermas = New ScottPlot.WinForms.FormsPlot()
        pnlTarjetaProductos.SuspendLayout()
        CType(PicProductos, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicMermas, ComponentModel.ISupportInitialize).BeginInit()
        pnlTarjetaMermas.SuspendLayout()
        pnlGrafico.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTarjetaProductos
        ' 
        pnlTarjetaProductos.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        pnlTarjetaProductos.Controls.Add(Label1)
        pnlTarjetaProductos.Controls.Add(lblCantidadProductos)
        pnlTarjetaProductos.Controls.Add(PicProductos)
        pnlTarjetaProductos.Location = New Point(190, 39)
        pnlTarjetaProductos.Name = "pnlTarjetaProductos"
        pnlTarjetaProductos.Size = New Size(263, 125)
        pnlTarjetaProductos.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(26, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(213, 27)
        Label1.TabIndex = 4
        Label1.Text = "Productos activos"
        ' 
        ' lblCantidadProductos
        ' 
        lblCantidadProductos.AutoSize = True
        lblCantidadProductos.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCantidadProductos.ForeColor = Color.White
        lblCantidadProductos.Location = New Point(137, 47)
        lblCantidadProductos.Name = "lblCantidadProductos"
        lblCantidadProductos.Size = New Size(46, 54)
        lblCantidadProductos.TabIndex = 2
        lblCantidadProductos.Text = "1"
        ' 
        ' PicProductos
        ' 
        PicProductos.Location = New Point(91, 61)
        PicProductos.Name = "PicProductos"
        PicProductos.Size = New Size(40, 40)
        PicProductos.SizeMode = PictureBoxSizeMode.Zoom
        PicProductos.TabIndex = 0
        PicProductos.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(34, 20)
        Label2.Name = "Label2"
        Label2.Size = New Size(193, 27)
        Label2.TabIndex = 5
        Label2.Text = "Mermas del mes"
        ' 
        ' lblCantidadMermas
        ' 
        lblCantidadMermas.AutoSize = True
        lblCantidadMermas.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCantidadMermas.ForeColor = Color.White
        lblCantidadMermas.Location = New Point(154, 47)
        lblCantidadMermas.Name = "lblCantidadMermas"
        lblCantidadMermas.Size = New Size(46, 54)
        lblCantidadMermas.TabIndex = 3
        lblCantidadMermas.Text = "1"
        ' 
        ' PicMermas
        ' 
        PicMermas.Location = New Point(108, 61)
        PicMermas.Name = "PicMermas"
        PicMermas.Size = New Size(40, 40)
        PicMermas.SizeMode = PictureBoxSizeMode.Zoom
        PicMermas.TabIndex = 1
        PicMermas.TabStop = False
        ' 
        ' pnlTarjetaMermas
        ' 
        pnlTarjetaMermas.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        pnlTarjetaMermas.Controls.Add(lblCantidadMermas)
        pnlTarjetaMermas.Controls.Add(Label2)
        pnlTarjetaMermas.Controls.Add(PicMermas)
        pnlTarjetaMermas.Location = New Point(821, 39)
        pnlTarjetaMermas.Name = "pnlTarjetaMermas"
        pnlTarjetaMermas.Size = New Size(263, 125)
        pnlTarjetaMermas.TabIndex = 6
        ' 
        ' pnlGrafico
        ' 
        pnlGrafico.Controls.Add(formsPlotMermas)
        pnlGrafico.Location = New Point(12, 238)
        pnlGrafico.Name = "pnlGrafico"
        pnlGrafico.Size = New Size(1248, 295)
        pnlGrafico.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(29, 197)
        Label3.Name = "Label3"
        Label3.Size = New Size(373, 27)
        Label3.TabIndex = 8
        Label3.Text = "Productos con mayores mermas"
        ' 
        ' formsPlotMermas
        ' 
        formsPlotMermas.Location = New Point(3, 3)
        formsPlotMermas.Name = "formsPlotMermas"
        formsPlotMermas.Size = New Size(1242, 292)
        formsPlotMermas.TabIndex = 0
        ' 
        ' frmDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1272, 603)
        Controls.Add(Label3)
        Controls.Add(pnlGrafico)
        Controls.Add(pnlTarjetaMermas)
        Controls.Add(pnlTarjetaProductos)
        Name = "frmDashboard"
        Text = "frmDashboard"
        pnlTarjetaProductos.ResumeLayout(False)
        pnlTarjetaProductos.PerformLayout()
        CType(PicProductos, ComponentModel.ISupportInitialize).EndInit()
        CType(PicMermas, ComponentModel.ISupportInitialize).EndInit()
        pnlTarjetaMermas.ResumeLayout(False)
        pnlTarjetaMermas.PerformLayout()
        pnlGrafico.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlTarjetaProductos As Panel
    Friend WithEvents PicMermas As PictureBox
    Friend WithEvents PicProductos As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCantidadMermas As Label
    Friend WithEvents lblCantidadProductos As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlTarjetaMermas As Panel
    Friend WithEvents pnlGrafico As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents formsPlotMermas As ScottPlot.WinForms.FormsPlot
End Class
