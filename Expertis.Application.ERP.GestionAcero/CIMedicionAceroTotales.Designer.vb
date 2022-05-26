<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIMedicionAceroTotales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIMedicionAceroTotales))
        Me.cmbEstado = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.lblEstado = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFecha1 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha1 = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFecha = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha = New Solmicro.Expertis.Engine.UI.Label
        Me.advNObra = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.lblNObra = New Solmicro.Expertis.Engine.UI.Label
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.cmbEstado)
        Me.FilterPanel.Controls.Add(Me.lblEstado)
        Me.FilterPanel.Controls.Add(Me.clbFecha1)
        Me.FilterPanel.Controls.Add(Me.lblFecha1)
        Me.FilterPanel.Controls.Add(Me.clbFecha)
        Me.FilterPanel.Controls.Add(Me.lblFecha)
        Me.FilterPanel.Controls.Add(Me.advNObra)
        Me.FilterPanel.Controls.Add(Me.lblNObra)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 172)
        Me.FilterPanel.Size = New System.Drawing.Size(536, 97)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(536, 172)
        '
        'Grid
        '
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Grid.Size = New System.Drawing.Size(536, 172)
        '
        'Toolbar
        '
        Me.Toolbar.Size = New System.Drawing.Size(245, 28)
        '
        'Menubar
        '
        Me.Menubar.Location = New System.Drawing.Point(0, 28)
        '
        'cmbEstado
        '
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.DisabledBackColor = System.Drawing.Color.White
        Me.cmbEstado.Location = New System.Drawing.Point(105, 56)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 22
        Me.cmbEstado.Text = "Comenzado"
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(24, 57)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(45, 13)
        Me.lblEstado.TabIndex = 23
        Me.lblEstado.Text = "Estado"
        '
        'clbFecha1
        '
        Me.clbFecha1.DisabledBackColor = System.Drawing.Color.White
        Me.clbFecha1.Location = New System.Drawing.Point(391, 49)
        Me.clbFecha1.Name = "clbFecha1"
        Me.clbFecha1.Size = New System.Drawing.Size(121, 21)
        Me.clbFecha1.TabIndex = 20
        '
        'lblFecha1
        '
        Me.lblFecha1.Location = New System.Drawing.Point(327, 56)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha1.TabIndex = 21
        Me.lblFecha1.Text = "Fecha <="
        '
        'clbFecha
        '
        Me.clbFecha.DisabledBackColor = System.Drawing.Color.White
        Me.clbFecha.Location = New System.Drawing.Point(391, 21)
        Me.clbFecha.Name = "clbFecha"
        Me.clbFecha.Size = New System.Drawing.Size(121, 21)
        Me.clbFecha.TabIndex = 18
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(327, 24)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha.TabIndex = 19
        Me.lblFecha.Text = "Fecha >="
        '
        'advNObra
        '
        Me.advNObra.DisabledBackColor = System.Drawing.Color.White
        Me.advNObra.DisplayField = "NObra"
        Me.advNObra.EntityName = "ObraCabecera"
        Me.advNObra.Location = New System.Drawing.Point(105, 19)
        Me.advNObra.Name = "advNObra"
        Me.advNObra.PrimaryDataFields = "IDObra"
        Me.advNObra.SecondaryDataFields = "IDObra"
        Me.advNObra.Size = New System.Drawing.Size(121, 23)
        Me.advNObra.TabIndex = 16
        Me.advNObra.ViewName = "tbObraCabecera"
        '
        'lblNObra
        '
        Me.lblNObra.Location = New System.Drawing.Point(24, 27)
        Me.lblNObra.Name = "lblNObra"
        Me.lblNObra.Size = New System.Drawing.Size(43, 13)
        Me.lblNObra.TabIndex = 17
        Me.lblNObra.Text = "NObra"
        '
        'CIMedicionAceroTotales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 357)
        Me.Name = "CIMedicionAceroTotales"
        Me.Text = "CIMedicionAceroTotales"
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbEstado As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents lblEstado As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents clbFecha1 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents clbFecha As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents advNObra As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents lblNObra As Solmicro.Expertis.Engine.UI.Label
End Class
