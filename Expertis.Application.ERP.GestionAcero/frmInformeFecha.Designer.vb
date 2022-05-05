<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformeFecha
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
        Me.TxObservaciones = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.FechaHasta = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.FechaDesde = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.TxObservaciones)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.FechaHasta)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.FechaDesde)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Location = New System.Drawing.Point(13, 13)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(259, 184)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Filtros de Fecha"
        '
        'TxObservaciones
        '
        Me.TxObservaciones.DisabledBackColor = System.Drawing.Color.White
        Me.TxObservaciones.Location = New System.Drawing.Point(69, 146)
        Me.TxObservaciones.Name = "TxObservaciones"
        Me.TxObservaciones.Size = New System.Drawing.Size(173, 21)
        Me.TxObservaciones.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Observ."
        '
        'FechaHasta
        '
        Me.FechaHasta.DisabledBackColor = System.Drawing.Color.White
        Me.FechaHasta.Location = New System.Drawing.Point(69, 87)
        Me.FechaHasta.Name = "FechaHasta"
        Me.FechaHasta.Size = New System.Drawing.Size(173, 21)
        Me.FechaHasta.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hasta"
        '
        'FechaDesde
        '
        Me.FechaDesde.DisabledBackColor = System.Drawing.Color.White
        Me.FechaDesde.Location = New System.Drawing.Point(69, 31)
        Me.FechaDesde.Name = "FechaDesde"
        Me.FechaDesde.Size = New System.Drawing.Size(173, 21)
        Me.FechaDesde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(39, 216)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Cancelar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 216)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Aceptar"
        '
        'frmInformeFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmInformeFecha"
        Me.Text = "frmInformeFecha"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents FechaHasta As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents FechaDesde As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents TxObservaciones As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
End Class
