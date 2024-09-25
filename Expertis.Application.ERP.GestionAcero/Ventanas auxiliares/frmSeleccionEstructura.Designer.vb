<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionEstructura
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
        Dim cmbEstructura_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionEstructura))
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.cmbEstructura = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        CType(Me.cmbEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(127, 82)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 23)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Cancelar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(20, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Aceptar"
        '
        'cmbEstructura
        '
        cmbEstructura_DesignTimeLayout.LayoutString = resources.GetString("cmbEstructura_DesignTimeLayout.LayoutString")
        Me.cmbEstructura.DesignTimeLayout = cmbEstructura_DesignTimeLayout
        Me.cmbEstructura.DisabledBackColor = System.Drawing.Color.White
        Me.cmbEstructura.Location = New System.Drawing.Point(70, 37)
        Me.cmbEstructura.Name = "cmbEstructura"
        Me.cmbEstructura.SelectedIndex = -1
        Me.cmbEstructura.SelectedItem = Nothing
        Me.cmbEstructura.Size = New System.Drawing.Size(113, 21)
        Me.cmbEstructura.TabIndex = 23
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.cmbEstructura)
        Me.Frame1.Controls.Add(Me.Button2)
        Me.Frame1.Controls.Add(Me.Button1)
        Me.Frame1.Location = New System.Drawing.Point(12, 25)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(251, 130)
        Me.Frame1.TabIndex = 24
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Selecciona Estructura"
        '
        'frmSeleccionEstructura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 167)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmSeleccionEstructura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estructura"
        CType(Me.cmbEstructura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents cmbEstructura As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
End Class
