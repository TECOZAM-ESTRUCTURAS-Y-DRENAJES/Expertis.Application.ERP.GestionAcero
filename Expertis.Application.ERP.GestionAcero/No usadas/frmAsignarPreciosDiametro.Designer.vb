<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarPreciosDiametro
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
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.FHasta = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.FDesde = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Frame2 = New Solmicro.Expertis.Engine.UI.Frame
        Me.Label8 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDim32 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label9 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDim25 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label10 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDim20 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label11 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDim16 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label7 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDim12 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label6 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDim10 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label5 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtDim8 = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Label4 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtEla = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.btnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.btnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(399, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Se actualizará el precio de las mediciones entre las fechas indicadas"
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.FHasta)
        Me.Frame1.Controls.Add(Me.FDesde)
        Me.Frame1.Location = New System.Drawing.Point(16, 40)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(489, 87)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Control de fechas"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(182, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Desde"
        '
        'FHasta
        '
        Me.FHasta.DisabledBackColor = System.Drawing.Color.White
        Me.FHasta.Location = New System.Drawing.Point(185, 47)
        Me.FHasta.Name = "FHasta"
        Me.FHasta.Size = New System.Drawing.Size(133, 21)
        Me.FHasta.TabIndex = 1
        '
        'FDesde
        '
        Me.FDesde.DisabledBackColor = System.Drawing.Color.White
        Me.FDesde.Location = New System.Drawing.Point(17, 47)
        Me.FDesde.Name = "FDesde"
        Me.FDesde.Size = New System.Drawing.Size(133, 21)
        Me.FDesde.TabIndex = 0
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.Label8)
        Me.Frame2.Controls.Add(Me.txtDim32)
        Me.Frame2.Controls.Add(Me.Label9)
        Me.Frame2.Controls.Add(Me.txtDim25)
        Me.Frame2.Controls.Add(Me.Label10)
        Me.Frame2.Controls.Add(Me.txtDim20)
        Me.Frame2.Controls.Add(Me.Label11)
        Me.Frame2.Controls.Add(Me.txtDim16)
        Me.Frame2.Controls.Add(Me.Label7)
        Me.Frame2.Controls.Add(Me.txtDim12)
        Me.Frame2.Controls.Add(Me.Label6)
        Me.Frame2.Controls.Add(Me.txtDim10)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.txtDim8)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.txtEla)
        Me.Frame2.Location = New System.Drawing.Point(16, 134)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(489, 235)
        Me.Frame2.TabIndex = 2
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Precios"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(269, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Diámetro 32 Ø"
        '
        'txtDim32
        '
        Me.txtDim32.DisabledBackColor = System.Drawing.Color.White
        Me.txtDim32.Location = New System.Drawing.Point(371, 192)
        Me.txtDim32.Name = "txtDim32"
        Me.txtDim32.Size = New System.Drawing.Size(100, 21)
        Me.txtDim32.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(269, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Diámetro 25 Ø"
        '
        'txtDim25
        '
        Me.txtDim25.DisabledBackColor = System.Drawing.Color.White
        Me.txtDim25.Location = New System.Drawing.Point(371, 139)
        Me.txtDim25.Name = "txtDim25"
        Me.txtDim25.Size = New System.Drawing.Size(100, 21)
        Me.txtDim25.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(269, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Diámetro 20 Ø"
        '
        'txtDim20
        '
        Me.txtDim20.DisabledBackColor = System.Drawing.Color.White
        Me.txtDim20.Location = New System.Drawing.Point(371, 88)
        Me.txtDim20.Name = "txtDim20"
        Me.txtDim20.Size = New System.Drawing.Size(100, 21)
        Me.txtDim20.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(269, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Diámetro 16 Ø"
        '
        'txtDim16
        '
        Me.txtDim16.DisabledBackColor = System.Drawing.Color.White
        Me.txtDim16.Location = New System.Drawing.Point(371, 35)
        Me.txtDim16.Name = "txtDim16"
        Me.txtDim16.Size = New System.Drawing.Size(100, 21)
        Me.txtDim16.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Diámetro 12 Ø"
        '
        'txtDim12
        '
        Me.txtDim12.DisabledBackColor = System.Drawing.Color.White
        Me.txtDim12.Location = New System.Drawing.Point(121, 192)
        Me.txtDim12.Name = "txtDim12"
        Me.txtDim12.Size = New System.Drawing.Size(100, 21)
        Me.txtDim12.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Diámetro 10 Ø"
        '
        'txtDim10
        '
        Me.txtDim10.DisabledBackColor = System.Drawing.Color.White
        Me.txtDim10.Location = New System.Drawing.Point(121, 139)
        Me.txtDim10.Name = "txtDim10"
        Me.txtDim10.Size = New System.Drawing.Size(100, 21)
        Me.txtDim10.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Diámetro 8 Ø"
        '
        'txtDim8
        '
        Me.txtDim8.DisabledBackColor = System.Drawing.Color.White
        Me.txtDim8.Location = New System.Drawing.Point(121, 88)
        Me.txtDim8.Name = "txtDim8"
        Me.txtDim8.Size = New System.Drawing.Size(100, 21)
        Me.txtDim8.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fac. Elabora."
        '
        'txtEla
        '
        Me.txtEla.DisabledBackColor = System.Drawing.Color.White
        Me.txtEla.Location = New System.Drawing.Point(121, 35)
        Me.txtEla.Name = "txtEla"
        Me.txtEla.Size = New System.Drawing.Size(100, 21)
        Me.txtEla.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(354, 387)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(123, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(43, 387)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(123, 32)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        '
        'frmAsignarPreciosDiametro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 441)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAsignarPreciosDiametro"
        Me.Text = "Form1"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents FHasta As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents FDesde As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Frame2 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Label8 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDim32 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label9 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDim25 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label10 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDim20 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label11 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDim16 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label7 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDim12 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label6 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDim10 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label5 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtDim8 As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Label4 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtEla As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents btnAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents btnCancelar As Solmicro.Expertis.Engine.UI.Button
End Class
