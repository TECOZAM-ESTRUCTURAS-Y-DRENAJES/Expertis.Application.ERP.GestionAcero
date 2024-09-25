<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarPrecios
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
        Me.txtSumA = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtSumB = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtMonB = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label4 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtMonA = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label5 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtElabB = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label6 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtElabA = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label7 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtElevB = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label8 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtElevA = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label9 = New Solmicro.Expertis.Engine.UI.Label
        Me.btnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.btnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(372, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Se actualizará el precio de las mediciones marcadas a certificar"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "€ Fac. Suministro A"
        '
        'txtSumA
        '
        Me.txtSumA.DisabledBackColor = System.Drawing.Color.White
        Me.txtSumA.Location = New System.Drawing.Point(147, 43)
        Me.txtSumA.Name = "txtSumA"
        Me.txtSumA.Size = New System.Drawing.Size(100, 21)
        Me.txtSumA.TabIndex = 2
        '
        'txtSumB
        '
        Me.txtSumB.DisabledBackColor = System.Drawing.Color.White
        Me.txtSumB.Location = New System.Drawing.Point(147, 70)
        Me.txtSumB.Name = "txtSumB"
        Me.txtSumB.Size = New System.Drawing.Size(100, 21)
        Me.txtSumB.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "€ Fac. Suministro B"
        '
        'txtMonB
        '
        Me.txtMonB.DisabledBackColor = System.Drawing.Color.White
        Me.txtMonB.Location = New System.Drawing.Point(147, 147)
        Me.txtMonB.Name = "txtMonB"
        Me.txtMonB.Size = New System.Drawing.Size(100, 21)
        Me.txtMonB.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "€ Fac. Montaje B"
        '
        'txtMonA
        '
        Me.txtMonA.DisabledBackColor = System.Drawing.Color.White
        Me.txtMonA.Location = New System.Drawing.Point(147, 120)
        Me.txtMonA.Name = "txtMonA"
        Me.txtMonA.Size = New System.Drawing.Size(100, 21)
        Me.txtMonA.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "€ Fac. Montaje A"
        '
        'txtElabB
        '
        Me.txtElabB.DisabledBackColor = System.Drawing.Color.White
        Me.txtElabB.Location = New System.Drawing.Point(468, 151)
        Me.txtElabB.Name = "txtElabB"
        Me.txtElabB.Size = New System.Drawing.Size(100, 21)
        Me.txtElabB.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(337, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "€ Fac. Elaboración B"
        '
        'txtElabA
        '
        Me.txtElabA.DisabledBackColor = System.Drawing.Color.White
        Me.txtElabA.Location = New System.Drawing.Point(468, 124)
        Me.txtElabA.Name = "txtElabA"
        Me.txtElabA.Size = New System.Drawing.Size(100, 21)
        Me.txtElabA.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(337, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "€ Fac. Elaboración A"
        '
        'txtElevB
        '
        Me.txtElevB.DisabledBackColor = System.Drawing.Color.White
        Me.txtElevB.Location = New System.Drawing.Point(468, 74)
        Me.txtElevB.Name = "txtElevB"
        Me.txtElevB.Size = New System.Drawing.Size(100, 21)
        Me.txtElevB.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(337, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "€ Fac. Medios Elev. B"
        '
        'txtElevA
        '
        Me.txtElevA.DisabledBackColor = System.Drawing.Color.White
        Me.txtElevA.Location = New System.Drawing.Point(468, 47)
        Me.txtElevA.Name = "txtElevA"
        Me.txtElevA.Size = New System.Drawing.Size(100, 21)
        Me.txtElevA.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(337, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "€ Fac. Medios Elev. A"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(373, 211)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 17
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(493, 211)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        '
        'frmAsignarPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 272)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtElabB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtElabA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtElevB)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtElevA)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtMonB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMonA)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSumB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSumA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAsignarPrecios"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtSumA As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtSumB As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtMonB As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label4 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtMonA As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label5 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtElabB As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label6 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtElabA As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label7 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtElevB As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label8 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtElevA As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label9 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents btnAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents btnCancelar As Solmicro.Expertis.Engine.UI.Button
End Class
