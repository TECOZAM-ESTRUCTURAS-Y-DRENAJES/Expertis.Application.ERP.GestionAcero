<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeAceroBueno
    Inherits Solmicro.Expertis.Engine.UI.FormBase

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
        Me.components = New System.ComponentModel.Container
        Dim Grid1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeAceroBueno))
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.Grid1 = New Solmicro.Expertis.Engine.UI.Grid
        Me.Frame1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(797, 344)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 34)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Cancelar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(666, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 34)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Aceptar"
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.Grid1)
        Me.Frame1.Location = New System.Drawing.Point(12, 25)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(890, 297)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Seleccione las mediciones que desee que aparezcan en el informe"
        '
        'Grid1
        '
        Me.Grid1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.Grid1.AllowChildTableGroups = True
        Me.Grid1.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[False]
        Grid1_DesignTimeLayout.LayoutString = resources.GetString("Grid1_DesignTimeLayout.LayoutString")
        Me.Grid1.DesignTimeLayout = Grid1_DesignTimeLayout
        Me.Grid1.EntityName = "ObraMedicionAcero"
        Me.Grid1.Location = New System.Drawing.Point(7, 20)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.PrimaryDataFields = Nothing
        Me.Grid1.SecondaryDataFields = Nothing
        Me.Grid1.Size = New System.Drawing.Size(877, 259)
        Me.Grid1.TabIndex = 0
        Me.Grid1.ViewName = "vFrmMedicionesObraAcero"
        '
        'InformeAceroBueno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 403)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "InformeAceroBueno"
        Me.Text = "InformeAceroBueno"
        Me.Frame1.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Grid1 As Solmicro.Expertis.Engine.UI.Grid
End Class
