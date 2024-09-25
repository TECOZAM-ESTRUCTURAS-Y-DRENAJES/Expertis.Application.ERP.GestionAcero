<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CIPesoBasculaObra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIPesoBasculaObra))
        Me.lblEstado = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFechaHasta = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha1 = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFechaDesde = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha = New Solmicro.Expertis.Engine.UI.Label
        Me.advNObra = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.lblNObra = New Solmicro.Expertis.Engine.UI.Label
        Me.txtChatarra = New Solmicro.Expertis.Engine.UI.TextBox
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.txtChatarra)
        Me.FilterPanel.Controls.Add(Me.lblEstado)
        Me.FilterPanel.Controls.Add(Me.clbFechaHasta)
        Me.FilterPanel.Controls.Add(Me.lblFecha1)
        Me.FilterPanel.Controls.Add(Me.clbFechaDesde)
        Me.FilterPanel.Controls.Add(Me.lblFecha)
        Me.FilterPanel.Controls.Add(Me.advNObra)
        Me.FilterPanel.Controls.Add(Me.lblNObra)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 220)
        Me.FilterPanel.Size = New System.Drawing.Size(804, 102)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(804, 220)
        '
        'Grid
        '
        Me.Grid.ColumnAutoResize = True
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.Size = New System.Drawing.Size(804, 220)
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
        Me.MainPanel.Size = New System.Drawing.Size(804, 322)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(804, 322)
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(536, 24)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(63, 13)
        Me.lblEstado.TabIndex = 31
        Me.lblEstado.Text = "Chatarra:"
        '
        'clbFechaHasta
        '
        Me.clbFechaHasta.DisabledBackColor = System.Drawing.Color.White
        Me.clbFechaHasta.Location = New System.Drawing.Point(94, 52)
        Me.clbFechaHasta.Name = "clbFechaHasta"
        Me.clbFechaHasta.Size = New System.Drawing.Size(121, 21)
        Me.clbFechaHasta.TabIndex = 2
        '
        'lblFecha1
        '
        Me.lblFecha1.Location = New System.Drawing.Point(30, 59)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha1.TabIndex = 29
        Me.lblFecha1.Text = "Fecha <="
        '
        'clbFechaDesde
        '
        Me.clbFechaDesde.DisabledBackColor = System.Drawing.Color.White
        Me.clbFechaDesde.Location = New System.Drawing.Point(94, 24)
        Me.clbFechaDesde.Name = "clbFechaDesde"
        Me.clbFechaDesde.Size = New System.Drawing.Size(121, 21)
        Me.clbFechaDesde.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(30, 27)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha.TabIndex = 27
        Me.lblFecha.Text = "Fecha >="
        '
        'advNObra
        '
        Me.advNObra.DisabledBackColor = System.Drawing.Color.White
        Me.advNObra.DisplayField = "NObra"
        Me.advNObra.EntityName = "ObraCabecera"
        Me.advNObra.Location = New System.Drawing.Point(344, 19)
        Me.advNObra.Name = "advNObra"
        Me.advNObra.PrimaryDataFields = "IDObra"
        Me.advNObra.SecondaryDataFields = "IDObra"
        Me.advNObra.Size = New System.Drawing.Size(121, 23)
        Me.advNObra.TabIndex = 3
        Me.advNObra.ViewName = "tbObraCabecera"
        '
        'lblNObra
        '
        Me.lblNObra.Location = New System.Drawing.Point(263, 27)
        Me.lblNObra.Name = "lblNObra"
        Me.lblNObra.Size = New System.Drawing.Size(48, 13)
        Me.lblNObra.TabIndex = 25
        Me.lblNObra.Text = "NObra:"
        '
        'txtChatarra
        '
        Me.txtChatarra.DisabledBackColor = System.Drawing.Color.White
        Me.txtChatarra.Location = New System.Drawing.Point(619, 19)
        Me.txtChatarra.Name = "txtChatarra"
        Me.txtChatarra.Size = New System.Drawing.Size(151, 21)
        Me.txtChatarra.TabIndex = 4
        '
        'CIPesoBasculaObra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 410)
        Me.Name = "CIPesoBasculaObra"
        Me.Text = "CIPesoBasculaObra"
        Me.FilterPanel.ResumeLayout(False)
        Me.FilterPanel.PerformLayout()
        Me.CIMntoGridPanel.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanelCIMntoContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblEstado As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents clbFechaHasta As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents clbFechaDesde As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents advNObra As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents lblNObra As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtChatarra As Solmicro.Expertis.Engine.UI.TextBox
End Class
