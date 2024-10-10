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
        Dim cmbOpciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIPesoBasculaObra))
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAnio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.lblEstado = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFechaHasta = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha1 = New Solmicro.Expertis.Engine.UI.Label
        Me.clbFechaDesde = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha = New Solmicro.Expertis.Engine.UI.Label
        Me.txtChatarra = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.Label5 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbMet2 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.Frame2 = New Solmicro.Expertis.Engine.UI.Frame
        Me.Label4 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbMet1 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.cmbOpciones = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.cmbMes = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.cmbAnio = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Frame3 = New Solmicro.Expertis.Engine.UI.Frame
        Me.FilterPanel.SuspendLayout()
        Me.CIMntoGridPanel.suspendlayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.MainPanelCIMntoContainer.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.cmbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame3.SuspendLayout()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.Frame3)
        Me.FilterPanel.Controls.Add(Me.Frame2)
        Me.FilterPanel.Controls.Add(Me.Frame1)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 330)
        Me.FilterPanel.Size = New System.Drawing.Size(936, 155)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(936, 330)
        '
        'Grid
        '
        Me.Grid.ColumnAutoResize = True
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.Size = New System.Drawing.Size(936, 330)
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
        Me.MainPanel.Size = New System.Drawing.Size(936, 485)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(936, 485)
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(19, 31)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(63, 13)
        Me.lblEstado.TabIndex = 31
        Me.lblEstado.Text = "Chatarra:"
        '
        'clbFechaHasta
        '
        Me.clbFechaHasta.DisabledBackColor = System.Drawing.Color.White
        Me.clbFechaHasta.Location = New System.Drawing.Point(86, 78)
        Me.clbFechaHasta.Name = "clbFechaHasta"
        Me.clbFechaHasta.Size = New System.Drawing.Size(121, 21)
        Me.clbFechaHasta.TabIndex = 5
        '
        'lblFecha1
        '
        Me.lblFecha1.Location = New System.Drawing.Point(20, 85)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha1.TabIndex = 29
        Me.lblFecha1.Text = "Fecha <="
        '
        'clbFechaDesde
        '
        Me.clbFechaDesde.DisabledBackColor = System.Drawing.Color.White
        Me.clbFechaDesde.Location = New System.Drawing.Point(86, 50)
        Me.clbFechaDesde.Name = "clbFechaDesde"
        Me.clbFechaDesde.Size = New System.Drawing.Size(121, 21)
        Me.clbFechaDesde.TabIndex = 4
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(20, 53)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha.TabIndex = 27
        Me.lblFecha.Text = "Fecha >="
        '
        'txtChatarra
        '
        Me.txtChatarra.DisabledBackColor = System.Drawing.Color.White
        Me.txtChatarra.Location = New System.Drawing.Point(88, 26)
        Me.txtChatarra.Name = "txtChatarra"
        Me.txtChatarra.Size = New System.Drawing.Size(151, 21)
        Me.txtChatarra.TabIndex = 6
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.cbMet2)
        Me.Frame1.Controls.Add(Me.lblFecha)
        Me.Frame1.Controls.Add(Me.clbFechaDesde)
        Me.Frame1.Controls.Add(Me.lblFecha1)
        Me.Frame1.Controls.Add(Me.clbFechaHasta)
        Me.Frame1.Location = New System.Drawing.Point(330, 27)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(233, 120)
        Me.Frame1.TabIndex = 32
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Criterio 2 - Entre fechas"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Activar:"
        '
        'cbMet2
        '
        Me.cbMet2.Location = New System.Drawing.Point(86, 21)
        Me.cbMet2.Name = "cbMet2"
        Me.cbMet2.Size = New System.Drawing.Size(37, 23)
        Me.cbMet2.TabIndex = 51
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.cbMet1)
        Me.Frame2.Controls.Add(Me.cmbOpciones)
        Me.Frame2.Controls.Add(Me.cmbMes)
        Me.Frame2.Controls.Add(Me.Label1)
        Me.Frame2.Controls.Add(Me.cmbAnio)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Location = New System.Drawing.Point(21, 20)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(280, 127)
        Me.Frame2.TabIndex = 33
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Criterio 1 - Día de cierre de obra"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Activar:"
        '
        'cbMet1
        '
        Me.cbMet1.Location = New System.Drawing.Point(82, 19)
        Me.cbMet1.Name = "cbMet1"
        Me.cbMet1.Size = New System.Drawing.Size(37, 23)
        Me.cbMet1.TabIndex = 49
        '
        'cmbOpciones
        '
        cmbOpciones_DesignTimeLayout.LayoutString = resources.GetString("cmbOpciones_DesignTimeLayout.LayoutString")
        Me.cmbOpciones.DesignTimeLayout = cmbOpciones_DesignTimeLayout
        Me.cmbOpciones.DisabledBackColor = System.Drawing.Color.White
        Me.cmbOpciones.Location = New System.Drawing.Point(82, 43)
        Me.cmbOpciones.Name = "cmbOpciones"
        Me.cmbOpciones.SelectedIndex = -1
        Me.cmbOpciones.SelectedItem = Nothing
        Me.cmbOpciones.Size = New System.Drawing.Size(174, 21)
        Me.cmbOpciones.TabIndex = 1
        '
        'cmbMes
        '
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.DisabledBackColor = System.Drawing.Color.White
        Me.cmbMes.Location = New System.Drawing.Point(81, 98)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(175, 21)
        Me.cmbMes.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Mes:"
        '
        'cmbAnio
        '
        cmbAnio_DesignTimeLayout.LayoutString = resources.GetString("cmbAnio_DesignTimeLayout.LayoutString")
        Me.cmbAnio.DesignTimeLayout = cmbAnio_DesignTimeLayout
        Me.cmbAnio.DisabledBackColor = System.Drawing.Color.White
        Me.cmbAnio.Location = New System.Drawing.Point(81, 71)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.SelectedIndex = -1
        Me.cmbAnio.SelectedItem = Nothing
        Me.cmbAnio.Size = New System.Drawing.Size(175, 21)
        Me.cmbAnio.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Opción:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Año:"
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.txtChatarra)
        Me.Frame3.Controls.Add(Me.lblEstado)
        Me.Frame3.Location = New System.Drawing.Point(586, 27)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(277, 66)
        Me.Frame3.TabIndex = 34
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Otros datos"
        '
        'CIPesoBasculaObra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 573)
        Me.Name = "CIPesoBasculaObra"
        Me.Text = "CIPesoBasculaObra"
        Me.FilterPanel.ResumeLayout(False)
        Me.CIMntoGridPanel.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Toolbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Menubar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanelCIMntoContainer.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        CType(Me.cmbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblEstado As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents clbFechaHasta As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents clbFechaDesde As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtChatarra As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Frame2 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents cmbOpciones As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cmbAnio As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents cmbMes As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Frame3 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Label4 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbMet1 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents Label5 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbMet2 As Solmicro.Expertis.Engine.UI.CheckBox
End Class
