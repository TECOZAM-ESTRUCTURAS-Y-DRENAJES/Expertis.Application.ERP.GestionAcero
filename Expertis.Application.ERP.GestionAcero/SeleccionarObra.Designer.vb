<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionarObra
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
        Dim CmbNumObra_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionarObra))
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.CmbNumObra = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.BtnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnAceptar = New Solmicro.Expertis.Engine.UI.Button
        CType(Me.CmbNumObra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione la Obra de la Empresa DYEZAM"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(52, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(229, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "a la cual queremos pasar el suministro"
        '
        'CmbNumObra
        '
        CmbNumObra_DesignTimeLayout.LayoutString = resources.GetString("CmbNumObra_DesignTimeLayout.LayoutString")
        Me.CmbNumObra.DesignTimeLayout = CmbNumObra_DesignTimeLayout
        Me.CmbNumObra.DisabledBackColor = System.Drawing.Color.White
        Me.CmbNumObra.Location = New System.Drawing.Point(55, 116)
        Me.CmbNumObra.Name = "CmbNumObra"
        Me.CmbNumObra.SelectedIndex = -1
        Me.CmbNumObra.SelectedItem = Nothing
        Me.CmbNumObra.Size = New System.Drawing.Size(226, 21)
        Me.CmbNumObra.TabIndex = 2
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(206, 183)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "Cancelar"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(55, 183)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 4
        Me.BtnAceptar.Text = "Aceptar"
        '
        'SeleccionarObra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 294)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.CmbNumObra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SeleccionarObra"
        Me.Text = "SeleccionarObra"
        CType(Me.CmbNumObra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents CmbNumObra As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents BtnCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnAceptar As Solmicro.Expertis.Engine.UI.Button
End Class
