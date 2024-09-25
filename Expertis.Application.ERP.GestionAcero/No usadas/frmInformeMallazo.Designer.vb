<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformeMallazo
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
        Me.components = New System.ComponentModel.Container
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.Txtremolque = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label5 = New Solmicro.Expertis.Engine.UI.Label
        Me.TxtMatricula = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label4 = New Solmicro.Expertis.Engine.UI.Label
        Me.TxtAlbaran = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.TxtTransportista = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.txtFecha = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.opcion4 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.opcion3 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.opcion2 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.opcion1 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.Frame2 = New Solmicro.Expertis.Engine.UI.Frame
        Me.Grid1 = New Solmicro.Expertis.Engine.UI.Grid
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.Txtremolque)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.TxtMatricula)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.TxtAlbaran)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.TxtTransportista)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.txtFecha)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.opcion4)
        Me.Frame1.Controls.Add(Me.opcion3)
        Me.Frame1.Controls.Add(Me.opcion2)
        Me.Frame1.Controls.Add(Me.opcion1)
        Me.Frame1.Location = New System.Drawing.Point(13, 13)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(980, 212)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Elige Cabecera"
        '
        'Txtremolque
        '
        Me.Txtremolque.DisabledBackColor = System.Drawing.Color.White
        Me.Txtremolque.Location = New System.Drawing.Point(741, 152)
        Me.Txtremolque.Name = "Txtremolque"
        Me.Txtremolque.Size = New System.Drawing.Size(164, 21)
        Me.Txtremolque.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(666, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Remolque:"
        '
        'TxtMatricula
        '
        Me.TxtMatricula.DisabledBackColor = System.Drawing.Color.White
        Me.TxtMatricula.Location = New System.Drawing.Point(438, 152)
        Me.TxtMatricula.Name = "TxtMatricula"
        Me.TxtMatricula.Size = New System.Drawing.Size(164, 21)
        Me.TxtMatricula.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(345, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Matrícula:"
        '
        'TxtAlbaran
        '
        Me.TxtAlbaran.DisabledBackColor = System.Drawing.Color.White
        Me.TxtAlbaran.Location = New System.Drawing.Point(438, 85)
        Me.TxtAlbaran.Name = "TxtAlbaran"
        Me.TxtAlbaran.Size = New System.Drawing.Size(164, 21)
        Me.TxtAlbaran.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(345, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Albaran:"
        '
        'TxtTransportista
        '
        Me.TxtTransportista.DisabledBackColor = System.Drawing.Color.White
        Me.TxtTransportista.Location = New System.Drawing.Point(98, 156)
        Me.TxtTransportista.Name = "TxtTransportista"
        Me.TxtTransportista.Size = New System.Drawing.Size(164, 21)
        Me.TxtTransportista.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Transportista:"
        '
        'txtFecha
        '
        Me.txtFecha.DisabledBackColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(98, 85)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(164, 21)
        Me.txtFecha.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha:"
        '
        'opcion4
        '
        Me.opcion4.Location = New System.Drawing.Point(616, 34)
        Me.opcion4.Name = "opcion4"
        Me.opcion4.Size = New System.Drawing.Size(104, 23)
        Me.opcion4.TabIndex = 3
        Me.opcion4.Text = "TECOZAM"
        '
        'opcion3
        '
        Me.opcion3.Location = New System.Drawing.Point(438, 34)
        Me.opcion3.Name = "opcion3"
        Me.opcion3.Size = New System.Drawing.Size(104, 23)
        Me.opcion3.TabIndex = 2
        Me.opcion3.Text = "ARMADORES"
        '
        'opcion2
        '
        Me.opcion2.Location = New System.Drawing.Point(222, 34)
        Me.opcion2.Name = "opcion2"
        Me.opcion2.Size = New System.Drawing.Size(104, 23)
        Me.opcion2.TabIndex = 1
        Me.opcion2.Text = "DRENAJES"
        '
        'opcion1
        '
        Me.opcion1.Location = New System.Drawing.Point(9, 34)
        Me.opcion1.Name = "opcion1"
        Me.opcion1.Size = New System.Drawing.Size(104, 23)
        Me.opcion1.TabIndex = 0
        Me.opcion1.Text = "FERRALLAS"
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.Grid1)
        Me.Frame2.Location = New System.Drawing.Point(13, 232)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(980, 245)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Seleccione las mediciones que desee que aparezcan en el informe"
        '
        'Grid1
        '
        Me.Grid1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.Grid1.EntityName = Nothing
        Me.Grid1.Location = New System.Drawing.Point(8, 17)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.PrimaryDataFields = Nothing
        Me.Grid1.SecondaryDataFields = Nothing
        Me.Grid1.Size = New System.Drawing.Size(966, 222)
        Me.Grid1.TabIndex = 0
        Me.Grid1.ViewName = Nothing
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(715, 494)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 33)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Aceptar"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(860, 494)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 33)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancelar"
        '
        'frmInformeMallazo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 554)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmInformeMallazo"
        Me.Text = "frmInformeMallazo"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Txtremolque As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label5 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents TxtMatricula As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label4 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents TxtAlbaran As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents TxtTransportista As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtFecha As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents opcion4 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents opcion3 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents opcion2 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents opcion1 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents Frame2 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Grid1 As Solmicro.Expertis.Engine.UI.Grid
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
End Class
