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
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAnio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbAño2c3_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbMes2C3_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbMes1C3_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbAño1c3_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbEstructura_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CIPesoBasculaObra))
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
        Me.Frame4 = New Solmicro.Expertis.Engine.UI.Frame
        Me.cbAño2c3 = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label10 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbMes2C3 = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label9 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbMes1C3 = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label8 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbAño1c3 = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label6 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label7 = New Solmicro.Expertis.Engine.UI.Label
        Me.cbMet3 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.cbEstructura = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label11 = New Solmicro.Expertis.Engine.UI.Label
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
        Me.Frame4.SuspendLayout()
        CType(Me.cbAño2c3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes2C3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes1C3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAño1c3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FilterPanel
        '
        Me.FilterPanel.Controls.Add(Me.Frame4)
        Me.FilterPanel.Controls.Add(Me.Frame3)
        Me.FilterPanel.Controls.Add(Me.Frame2)
        Me.FilterPanel.Controls.Add(Me.Frame1)
        Me.FilterPanel.Location = New System.Drawing.Point(0, 308)
        Me.FilterPanel.Size = New System.Drawing.Size(1190, 177)
        '
        'CIMntoGridPanel
        '
        Me.CIMntoGridPanel.Size = New System.Drawing.Size(1190, 308)
        '
        'Grid
        '
        Me.Grid.ColumnAutoResize = True
        Grid_DesignTimeLayout.LayoutString = resources.GetString("Grid_DesignTimeLayout.LayoutString")
        Me.Grid.DesignTimeLayout = Grid_DesignTimeLayout
        Me.Grid.Size = New System.Drawing.Size(1190, 308)
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
        Me.MainPanel.Size = New System.Drawing.Size(1190, 485)
        '
        'MainPanelCIMntoContainer
        '
        Me.MainPanelCIMntoContainer.Size = New System.Drawing.Size(1190, 485)
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(19, 58)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(63, 13)
        Me.lblEstado.TabIndex = 31
        Me.lblEstado.Text = "Chatarra:"
        '
        'clbFechaHasta
        '
        Me.clbFechaHasta.DisabledBackColor = System.Drawing.Color.White
        Me.clbFechaHasta.Location = New System.Drawing.Point(86, 88)
        Me.clbFechaHasta.Name = "clbFechaHasta"
        Me.clbFechaHasta.Size = New System.Drawing.Size(121, 21)
        Me.clbFechaHasta.TabIndex = 5
        '
        'lblFecha1
        '
        Me.lblFecha1.Location = New System.Drawing.Point(20, 95)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha1.TabIndex = 29
        Me.lblFecha1.Text = "Fecha <="
        '
        'clbFechaDesde
        '
        Me.clbFechaDesde.DisabledBackColor = System.Drawing.Color.White
        Me.clbFechaDesde.Location = New System.Drawing.Point(86, 60)
        Me.clbFechaDesde.Name = "clbFechaDesde"
        Me.clbFechaDesde.Size = New System.Drawing.Size(121, 21)
        Me.clbFechaDesde.TabIndex = 4
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(20, 63)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(62, 13)
        Me.lblFecha.TabIndex = 27
        Me.lblFecha.Text = "Fecha >="
        '
        'txtChatarra
        '
        Me.txtChatarra.DisabledBackColor = System.Drawing.Color.White
        Me.txtChatarra.Location = New System.Drawing.Point(115, 55)
        Me.txtChatarra.Name = "txtChatarra"
        Me.txtChatarra.Size = New System.Drawing.Size(126, 21)
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
        Me.Frame1.Location = New System.Drawing.Point(297, 29)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(233, 127)
        Me.Frame1.TabIndex = 32
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Criterio 2 - Entre fechas sin tener en cuenta dia de cierre"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Activar:"
        '
        'cbMet2
        '
        Me.cbMet2.Location = New System.Drawing.Point(86, 31)
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
        Me.Frame2.Location = New System.Drawing.Point(20, 29)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(279, 127)
        Me.Frame2.TabIndex = 33
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Criterio 1 - Teniendo en cuenta día de cierre"
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
        Me.cmbOpciones.Size = New System.Drawing.Size(112, 21)
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
        Me.cmbMes.Size = New System.Drawing.Size(113, 21)
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
        Me.cmbAnio.Size = New System.Drawing.Size(113, 21)
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
        Me.Frame3.Controls.Add(Me.cbEstructura)
        Me.Frame3.Controls.Add(Me.txtChatarra)
        Me.Frame3.Controls.Add(Me.Label11)
        Me.Frame3.Controls.Add(Me.lblEstado)
        Me.Frame3.Location = New System.Drawing.Point(884, 29)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(276, 127)
        Me.Frame3.TabIndex = 34
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Otros datos"
        '
        'Frame4
        '
        Me.Frame4.Controls.Add(Me.cbAño2c3)
        Me.Frame4.Controls.Add(Me.Label10)
        Me.Frame4.Controls.Add(Me.cbMes2C3)
        Me.Frame4.Controls.Add(Me.Label9)
        Me.Frame4.Controls.Add(Me.cbMes1C3)
        Me.Frame4.Controls.Add(Me.Label8)
        Me.Frame4.Controls.Add(Me.cbAño1c3)
        Me.Frame4.Controls.Add(Me.Label6)
        Me.Frame4.Controls.Add(Me.Label7)
        Me.Frame4.Controls.Add(Me.cbMet3)
        Me.Frame4.Location = New System.Drawing.Point(528, 29)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.Size = New System.Drawing.Size(357, 127)
        Me.Frame4.TabIndex = 35
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Criterio 3 - Entre MESES productivos teniendo en cuenta día de cierre"
        '
        'cbAño2c3
        '
        cbAño2c3_DesignTimeLayout.LayoutString = resources.GetString("cbAño2c3_DesignTimeLayout.LayoutString")
        Me.cbAño2c3.DesignTimeLayout = cbAño2c3_DesignTimeLayout
        Me.cbAño2c3.DisabledBackColor = System.Drawing.Color.White
        Me.cbAño2c3.Location = New System.Drawing.Point(253, 89)
        Me.cbAño2c3.Name = "cbAño2c3"
        Me.cbAño2c3.SelectedIndex = -1
        Me.cbAño2c3.SelectedItem = Nothing
        Me.cbAño2c3.Size = New System.Drawing.Size(81, 21)
        Me.cbAño2c3.TabIndex = 59
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(202, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Año 2:"
        '
        'cbMes2C3
        '
        cbMes2C3_DesignTimeLayout.LayoutString = resources.GetString("cbMes2C3_DesignTimeLayout.LayoutString")
        Me.cbMes2C3.DesignTimeLayout = cbMes2C3_DesignTimeLayout
        Me.cbMes2C3.DisabledBackColor = System.Drawing.Color.White
        Me.cbMes2C3.Location = New System.Drawing.Point(73, 90)
        Me.cbMes2C3.Name = "cbMes2C3"
        Me.cbMes2C3.SelectedIndex = -1
        Me.cbMes2C3.SelectedItem = Nothing
        Me.cbMes2C3.Size = New System.Drawing.Size(113, 21)
        Me.cbMes2C3.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Mes 2:"
        '
        'cbMes1C3
        '
        cbMes1C3_DesignTimeLayout.LayoutString = resources.GetString("cbMes1C3_DesignTimeLayout.LayoutString")
        Me.cbMes1C3.DesignTimeLayout = cbMes1C3_DesignTimeLayout
        Me.cbMes1C3.DisabledBackColor = System.Drawing.Color.White
        Me.cbMes1C3.Location = New System.Drawing.Point(73, 62)
        Me.cbMes1C3.Name = "cbMes1C3"
        Me.cbMes1C3.SelectedIndex = -1
        Me.cbMes1C3.SelectedItem = Nothing
        Me.cbMes1C3.Size = New System.Drawing.Size(113, 21)
        Me.cbMes1C3.TabIndex = 55
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Mes 1:"
        '
        'cbAño1c3
        '
        cbAño1c3_DesignTimeLayout.LayoutString = resources.GetString("cbAño1c3_DesignTimeLayout.LayoutString")
        Me.cbAño1c3.DesignTimeLayout = cbAño1c3_DesignTimeLayout
        Me.cbAño1c3.DisabledBackColor = System.Drawing.Color.White
        Me.cbAño1c3.Location = New System.Drawing.Point(253, 61)
        Me.cbAño1c3.Name = "cbAño1c3"
        Me.cbAño1c3.SelectedIndex = -1
        Me.cbAño1c3.SelectedItem = Nothing
        Me.cbAño1c3.Size = New System.Drawing.Size(81, 21)
        Me.cbAño1c3.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(22, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Activar:"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(202, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Año 1:"
        '
        'cbMet3
        '
        Me.cbMet3.Location = New System.Drawing.Point(88, 34)
        Me.cbMet3.Name = "cbMet3"
        Me.cbMet3.Size = New System.Drawing.Size(37, 23)
        Me.cbMet3.TabIndex = 51
        '
        'cbEstructura
        '
        cbEstructura_DesignTimeLayout.LayoutString = resources.GetString("cbEstructura_DesignTimeLayout.LayoutString")
        Me.cbEstructura.DesignTimeLayout = cbEstructura_DesignTimeLayout
        Me.cbEstructura.DisabledBackColor = System.Drawing.Color.White
        Me.cbEstructura.Location = New System.Drawing.Point(115, 26)
        Me.cbEstructura.Name = "cbEstructura"
        Me.cbEstructura.SelectedIndex = -1
        Me.cbEstructura.SelectedItem = Nothing
        Me.cbEstructura.Size = New System.Drawing.Size(126, 21)
        Me.cbEstructura.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Estructura:"
        '
        'CIPesoBasculaObra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 573)
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
        Me.Frame4.ResumeLayout(False)
        Me.Frame4.PerformLayout()
        CType(Me.cbAño2c3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes2C3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes1C3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAño1c3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbEstructura, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Frame4 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents cbMes2C3 As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label9 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbMes1C3 As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label8 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbAño1c3 As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label7 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label6 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbMet3 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents cbAño2c3 As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label10 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbEstructura As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label11 As Solmicro.Expertis.Engine.UI.Label
End Class
