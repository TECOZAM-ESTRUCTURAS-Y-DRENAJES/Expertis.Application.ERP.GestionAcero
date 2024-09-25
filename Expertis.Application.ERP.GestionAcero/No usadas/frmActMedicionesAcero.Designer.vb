<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActMedicionesAcero
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
        Me.components = New System.ComponentModel.Container
        Dim ComboBox1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActMedicionesAcero))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.EBAlbaColada = New Solmicro.Expertis.Engine.UI.TextBox
        Me.ComboBox1 = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.RadioButton2 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.RadioButton1 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Grid1 = New Solmicro.Expertis.Engine.UI.Grid
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.ComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EBAlbaColada)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(723, 155)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Introducción de Datos"
        '
        'EBAlbaColada
        '
        Me.EBAlbaColada.DisabledBackColor = System.Drawing.Color.White
        Me.EBAlbaColada.Location = New System.Drawing.Point(368, 70)
        Me.EBAlbaColada.Name = "EBAlbaColada"
        Me.EBAlbaColada.Size = New System.Drawing.Size(300, 21)
        Me.EBAlbaColada.TabIndex = 4
        '
        'ComboBox1
        '
        ComboBox1_DesignTimeLayout.LayoutString = resources.GetString("ComboBox1_DesignTimeLayout.LayoutString")
        Me.ComboBox1.DesignTimeLayout = ComboBox1_DesignTimeLayout
        Me.ComboBox1.DisabledBackColor = System.Drawing.Color.White
        Me.ComboBox1.Location = New System.Drawing.Point(163, 70)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.SelectedIndex = -1
        Me.ComboBox1.SelectedItem = Nothing
        Me.ComboBox1.Size = New System.Drawing.Size(198, 21)
        Me.ComboBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(30, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Seleccionar máquina"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(21, 102)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(204, 23)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Edición de pesos introducidos"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(21, 32)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(204, 23)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Introducción de Pedido/Colada"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Grid1)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 175)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(723, 316)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Modificación de pesos introducidos"
        '
        'Grid1
        '
        Me.Grid1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.Grid1.EntityName = Nothing
        Me.Grid1.Location = New System.Drawing.Point(17, 29)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.PrimaryDataFields = Nothing
        Me.Grid1.SecondaryDataFields = Nothing
        Me.Grid1.Size = New System.Drawing.Size(694, 277)
        Me.Grid1.TabIndex = 0
        Me.Grid1.ViewName = Nothing
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(426, 513)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 39)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Aceptar"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(589, 513)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 39)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancelar"
        '
        'frmActMedicionesAcero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 581)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmActMedicionesAcero"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents RadioButton1 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents EBAlbaColada As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents ComboBox1 As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Grid1 As Solmicro.Expertis.Engine.UI.Grid
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
End Class
