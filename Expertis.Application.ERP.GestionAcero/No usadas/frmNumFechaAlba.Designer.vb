<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNumFechaAlba
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
        Me.FSalida = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.BtCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.FSalida)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Location = New System.Drawing.Point(48, 12)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(287, 139)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Datos de creación"
        '
        'FSalida
        '
        Me.FSalida.DisabledBackColor = System.Drawing.Color.White
        Me.FSalida.Location = New System.Drawing.Point(120, 59)
        Me.FSalida.Name = "FSalida"
        Me.FSalida.Size = New System.Drawing.Size(152, 21)
        Me.FSalida.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha de salida"
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(48, 187)
        Me.BtCancelar.Name = "BtCancelar"
        Me.BtCancelar.Size = New System.Drawing.Size(113, 23)
        Me.BtCancelar.TabIndex = 1
        Me.BtCancelar.Text = "Cancelar"
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(222, 187)
        Me.BtAceptar.Name = "BtAceptar"
        Me.BtAceptar.Size = New System.Drawing.Size(113, 23)
        Me.BtAceptar.TabIndex = 2
        Me.BtAceptar.Text = "Aceptar"
        '
        'frmNumFechaAlba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 226)
        Me.Controls.Add(Me.BtAceptar)
        Me.Controls.Add(Me.BtCancelar)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmNumFechaAlba"
        Me.Text = "frmNumFechaAlba"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents FSalida As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents BtCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtAceptar As Solmicro.Expertis.Engine.UI.Button
End Class
