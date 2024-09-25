<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmlFechaEstFactura
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
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.CalendarBox2 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.CalendarBox1 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.BtCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.CalendarBox2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.CalendarBox1)
        Me.Frame1.Location = New System.Drawing.Point(15, 13)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(442, 182)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Fechas de Control"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(29, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha hasta:"
        '
        'CalendarBox2
        '
        Me.CalendarBox2.DisabledBackColor = System.Drawing.Color.White
        Me.CalendarBox2.Location = New System.Drawing.Point(183, 117)
        Me.CalendarBox2.Name = "CalendarBox2"
        Me.CalendarBox2.Size = New System.Drawing.Size(212, 21)
        Me.CalendarBox2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha desde:"
        '
        'CalendarBox1
        '
        Me.CalendarBox1.DisabledBackColor = System.Drawing.Color.White
        Me.CalendarBox1.Location = New System.Drawing.Point(183, 51)
        Me.CalendarBox1.Name = "CalendarBox1"
        Me.CalendarBox1.Size = New System.Drawing.Size(212, 21)
        Me.CalendarBox1.TabIndex = 0
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(34, 222)
        Me.BtCancelar.Name = "BtCancelar"
        Me.BtCancelar.Size = New System.Drawing.Size(150, 42)
        Me.BtCancelar.TabIndex = 1
        Me.BtCancelar.Text = "Cancelar"
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(286, 222)
        Me.BtAceptar.Name = "BtAceptar"
        Me.BtAceptar.Size = New System.Drawing.Size(150, 42)
        Me.BtAceptar.TabIndex = 2
        Me.BtAceptar.Text = "Aceptar"
        '
        'frmlFechaEstFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 285)
        Me.Controls.Add(Me.BtAceptar)
        Me.Controls.Add(Me.BtCancelar)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmlFechaEstFactura"
        Me.Text = "frmlFechaEstFactura"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents CalendarBox1 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents CalendarBox2 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents BtCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtAceptar As Solmicro.Expertis.Engine.UI.Button
End Class
