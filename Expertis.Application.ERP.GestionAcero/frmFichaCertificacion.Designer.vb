<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFichaCertificacion
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
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.TextBox1 = New Solmicro.Expertis.Engine.UI.TextBox
        Me.NumericTextBox1 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(33, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Indique la Certificación"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(33, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Retención"
        '
        'TextBox1
        '
        Me.TextBox1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(189, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(205, 21)
        Me.TextBox1.TabIndex = 2
        '
        'NumericTextBox1
        '
        Me.NumericTextBox1.DisabledBackColor = System.Drawing.Color.White
        Me.NumericTextBox1.Location = New System.Drawing.Point(189, 105)
        Me.NumericTextBox1.Name = "NumericTextBox1"
        Me.NumericTextBox1.Size = New System.Drawing.Size(205, 21)
        Me.NumericTextBox1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(53, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 31)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Cancelar"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(269, 169)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 31)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Aceptar"
        '
        'frmFichaCertificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 226)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NumericTextBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmFichaCertificacion"
        Me.Text = "frmFichaCertificacion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents TextBox1 As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents NumericTextBox1 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
End Class
