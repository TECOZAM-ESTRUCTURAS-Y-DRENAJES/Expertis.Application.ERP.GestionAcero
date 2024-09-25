<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIMedicionAceroEstado
    Inherits Solmicro.Expertis.Engine.UI.CIMnto

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
        Dim Grid_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbAño_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIMedicionAceroEstado))
        Me.advNObra = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.lblNObra = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFecha = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFecha1 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha1 = New Solmicro.Expertis.Engine.UI.Label
        Me.cmbEstado = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.lblEstado = New Solmicro.Expertis.Engine.UI.Label
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbMes = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.cbAño = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDiaCierre = New Solmicro.Expertis.Engine.UI.TextBox
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.txtDiaCierre)
        Me.FilterPanel.Controls.Add(Me.Label3)
        Me.FilterPanel.Controls.Add(Me.cbAño)
        Me.FilterPanel.Controls.Add(Me.cbMes)
        Me.FilterPanel.Controls.Add(Me.Label2)
        Me.FilterPanel.Controls.Add(Me.Label1)
        Me.FilterPanel.Controls.Add(Me.cmbEstado)
        Me.FilterPanel.Controls.Add(Me.lblEstado)
        Me.FilterPanel.Controls.Add(Me.clbFecha1)
        Me.FilterPanel.Controls.Add(Me.lblFecha1)
        Me.FilterPanel.Controls.Add(Me.clbFecha)
        Me.FilterPanel.Controls.Add(Me.lblFecha)
        Me.FilterPanel.Controls.Add(Me.advNObra)
        Me.FilterPanel.Controls.Add(Me.lblNObra)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 133)
        Me.FilterPanel.Size = New System.Drawing.Size(638, 127)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(638, 133)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.Size = New System.Drawing.Size(638, 133)
        Me.Grid.ViewName = "vMedicionAceroEstado"
        '
        'Toolbar
        '
        Me.Toolbar.Size = New System.Drawing.Size(245, 28)
        '
        'Menubar
        '
        Me.Menubar.Location = New System.Drawing.Point(0, 28)
        '
        'MainPanel
        '
        Me.MainPanel.Size = New System.Drawing.Size(638, 260)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(638, 260)
        '
        'advNObra
        '
        Me.TryDataBinding(advNObra, New System.Windows.Forms.Binding("Text", Me, "NObra", True))
        Me.advNObra.DisabledBackColor = System.Drawing.Color.White
        Me.advNObra.DisplayField = "NObra"
        Me.advNObra.EntityName = "ObraCabecera"
        Me.advNObra.Location = New System.Drawing.Point(101, 27)
        Me.advNObra.Name = "advNObra"
        Me.advNObra.PrimaryDataFields = "IDObra"
        Me.advNObra.SecondaryDataFields = "IDObra"
        Me.advNObra.Size = New System.Drawing.Size(121, 23)
        Me.advNObra.TabIndex = 8
        Me.advNObra.ViewName = "tbObraCabecera"
        '
        'lblNObra
        '
        Me.lblNObra.Location = New System.Drawing.Point(20, 35)
        Me.lblNObra.Name = "lblNObra"
        Me.lblNObra.Size = New System.Drawing.Size(43, 13)
        Me.lblNObra.TabIndex = 9
        Me.lblNObra.Text = "NObra"
        '
        'clbFecha
        '
        Me.TryDataBinding(clbFecha, New System.Windows.Forms.Binding("BindableValue", Me, "Fecha", True))
        Me.clbFecha.DisabledBackColor = System.Drawing.Color.White
        Me.clbFecha.Location = New System.Drawing.Point(307, 29)
        Me.clbFecha.Name = "clbFecha"
        Me.clbFecha.Size = New System.Drawing.Size(121, 21)
        Me.clbFecha.TabIndex = 10
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(243, 32)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha.TabIndex = 11
        Me.lblFecha.Text = "Fecha >="
        '
        'clbFecha1
        '
        Me.TryDataBinding(clbFecha1, New System.Windows.Forms.Binding("BindableValue", Me, "Fecha", True))
        Me.clbFecha1.DisabledBackColor = System.Drawing.Color.White
        Me.clbFecha1.Location = New System.Drawing.Point(307, 57)
        Me.clbFecha1.Name = "clbFecha1"
        Me.clbFecha1.Size = New System.Drawing.Size(121, 21)
        Me.clbFecha1.TabIndex = 12
        '
        'lblFecha1
        '
        Me.lblFecha1.Location = New System.Drawing.Point(243, 64)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha1.TabIndex = 13
        Me.lblFecha1.Text = "Fecha <="
        '
        'cmbEstado
        '
        Me.TryDataBinding(cmbEstado, New System.Windows.Forms.Binding("Value", Me, "Estado", True))
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.DisabledBackColor = System.Drawing.Color.White
        Me.cmbEstado.Location = New System.Drawing.Point(101, 64)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 14
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(20, 65)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(45, 13)
        Me.lblEstado.TabIndex = 15
        Me.lblEstado.Text = "Estado"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(453, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Mes"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(453, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Año"
        '
        'cbMes
        '
        cbMes_DesignTimeLayout.LayoutString = resources.GetString("cbMes_DesignTimeLayout.LayoutString")
        Me.cbMes.DesignTimeLayout = cbMes_DesignTimeLayout
        Me.cbMes.DisabledBackColor = System.Drawing.Color.White
        Me.cbMes.Location = New System.Drawing.Point(508, 27)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.SelectedIndex = -1
        Me.cbMes.SelectedItem = Nothing
        Me.cbMes.Size = New System.Drawing.Size(100, 21)
        Me.cbMes.TabIndex = 18
        '
        'cbAño
        '
        cbAño_DesignTimeLayout.LayoutString = resources.GetString("cbAño_DesignTimeLayout.LayoutString")
        Me.cbAño.DesignTimeLayout = cbAño_DesignTimeLayout
        Me.cbAño.DisabledBackColor = System.Drawing.Color.White
        Me.cbAño.Location = New System.Drawing.Point(508, 57)
        Me.cbAño.Name = "cbAño"
        Me.cbAño.SelectedIndex = -1
        Me.cbAño.SelectedItem = Nothing
        Me.cbAño.Size = New System.Drawing.Size(100, 21)
        Me.cbAño.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Dia de Cierre"
        '
        'txtDiaCierre
        '
        Me.txtDiaCierre.DisabledBackColor = System.Drawing.Color.White
        Me.txtDiaCierre.Enabled = False
        Me.txtDiaCierre.Location = New System.Drawing.Point(122, 95)
        Me.txtDiaCierre.Name = "txtDiaCierre"
        Me.txtDiaCierre.Size = New System.Drawing.Size(100, 21)
        Me.txtDiaCierre.TabIndex = 21
        '
        'CIMedicionAceroEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 348)
        Me.Name = "CIMedicionAceroEstado"
        Me.Text = "CIMedicionAceroEstado"
        Me.ViewName = "vMedicionAceroEstado"
        Me.FilterPanel.ResumeLayout(False)
        Me.FilterPanel.PerformLayout()
        Me.CIMntoGridPanel.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanelCIMntoContainer.ResumeLayout(False)
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents clbFecha1 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents clbFecha As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents advNObra As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents lblNObra As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cmbEstado As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents lblEstado As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbAño As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cbMes As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDiaCierre As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
End Class
