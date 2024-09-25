<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedor
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
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.opc3 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.opc2 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.opc1 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.opc3)
        Me.Frame1.Controls.Add(Me.opc2)
        Me.Frame1.Controls.Add(Me.opc1)
        Me.Frame1.Location = New System.Drawing.Point(13, 13)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(344, 168)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Elige un proveedor"
        '
        'opc3
        '
        Me.opc3.Location = New System.Drawing.Point(50, 120)
        Me.opc3.Name = "opc3"
        Me.opc3.Size = New System.Drawing.Size(189, 23)
        Me.opc3.TabIndex = 2
        Me.opc3.Text = "FCC CONTRUCCIONES"
        '
        'opc2
        '
        Me.opc2.Location = New System.Drawing.Point(50, 76)
        Me.opc2.Name = "opc2"
        Me.opc2.Size = New System.Drawing.Size(189, 23)
        Me.opc2.TabIndex = 1
        Me.opc2.Text = "CONSTRUCTORA SAN JOSE"
        '
        'opc1
        '
        Me.opc1.Location = New System.Drawing.Point(50, 31)
        Me.opc1.Name = "opc1"
        Me.opc1.Size = New System.Drawing.Size(172, 23)
        Me.opc1.TabIndex = 0
        Me.opc1.Text = "UTE A-50 SALAMANCA"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 219)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Aceptar"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(260, 219)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancelar"
        '
        'frmProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 272)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmProveedor"
        Me.Text = "frmProveedor"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents opc3 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents opc2 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents opc1 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
End Class
