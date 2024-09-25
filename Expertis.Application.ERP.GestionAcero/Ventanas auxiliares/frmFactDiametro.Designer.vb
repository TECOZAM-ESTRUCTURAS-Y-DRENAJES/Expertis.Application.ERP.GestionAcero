<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactDiametro
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
        Me.Fdesde = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Fhasta = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvContador = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Bcancel = New Solmicro.Expertis.Engine.UI.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(30, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde Fecha: "
        '
        'Fdesde
        '
        Me.Fdesde.DisabledBackColor = System.Drawing.Color.White
        Me.Fdesde.Location = New System.Drawing.Point(143, 20)
        Me.Fdesde.Name = "Fdesde"
        Me.Fdesde.Size = New System.Drawing.Size(149, 21)
        Me.Fdesde.TabIndex = 1
        '
        'Fhasta
        '
        Me.Fhasta.DisabledBackColor = System.Drawing.Color.White
        Me.Fhasta.Location = New System.Drawing.Point(143, 68)
        Me.Fhasta.Name = "Fhasta"
        Me.Fhasta.Size = New System.Drawing.Size(149, 21)
        Me.Fhasta.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(30, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hasta Fecha: "
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(30, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Contador"
        '
        'AdvContador
        '
        Me.AdvContador.DisabledBackColor = System.Drawing.Color.White
        Me.AdvContador.Location = New System.Drawing.Point(143, 125)
        Me.AdvContador.Name = "AdvContador"
        Me.AdvContador.Size = New System.Drawing.Size(149, 23)
        Me.AdvContador.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(33, 197)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 39)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Aceptar"
        '
        'Bcancel
        '
        Me.Bcancel.Location = New System.Drawing.Point(196, 197)
        Me.Bcancel.Name = "Bcancel"
        Me.Bcancel.Size = New System.Drawing.Size(112, 39)
        Me.Bcancel.TabIndex = 7
        Me.Bcancel.Text = "Cancelar"
        '
        'frmFactDiametro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 261)
        Me.Controls.Add(Me.Bcancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.AdvContador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Fhasta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Fdesde)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmFactDiametro"
        Me.Text = "frmFactDiametro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Fdesde As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Fhasta As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents AdvContador As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Bcancel As Solmicro.Expertis.Engine.UI.Button
End Class
