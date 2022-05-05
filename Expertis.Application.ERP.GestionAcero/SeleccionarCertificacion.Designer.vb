<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionarCertificacion
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
        Me.Panel1 = New Solmicro.Expertis.Engine.UI.Panel
        Me.UL2 = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.TxtAñadirVarAcero = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.CheckBox5 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.CheckBox6 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.CheckBox7 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.CheckBox3 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.CheckBox2 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.CheckBox1 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.CheckBox4 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.Frame2 = New Solmicro.Expertis.Engine.UI.Frame
        Me.RB3 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.RB2 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.RB1 = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.UL1 = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.Panel2 = New Solmicro.Expertis.Engine.UI.Panel
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnNuevaCertif = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnUnirCertif = New Solmicro.Expertis.Engine.UI.Button
        Me.Frame3 = New Solmicro.Expertis.Engine.UI.Frame
        Me.GridSeleccionarCertif = New Solmicro.Expertis.Engine.UI.Grid
        Me.Panel3 = New Solmicro.Expertis.Engine.UI.Panel
        Me.Panel1.suspendlayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Panel2.suspendlayout()
        Me.Frame3.SuspendLayout()
        CType(Me.GridSeleccionarCertif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.suspendlayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UL2)
        Me.Panel1.Controls.Add(Me.Frame1)
        Me.Panel1.Controls.Add(Me.Frame2)
        Me.Panel1.Controls.Add(Me.UL1)
        Me.Panel1.Location = New System.Drawing.Point(0, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(534, 382)
        Me.Panel1.TabIndex = 0
        '
        'UL2
        '
        Me.UL2.AutoSize = True
        Me.UL2.Location = New System.Drawing.Point(123, 27)
        Me.UL2.Name = "UL2"
        Me.UL2.Size = New System.Drawing.Size(0, 13)
        Me.UL2.TabIndex = 2
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.TxtAñadirVarAcero)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.CheckBox5)
        Me.Frame1.Controls.Add(Me.CheckBox6)
        Me.Frame1.Controls.Add(Me.CheckBox7)
        Me.Frame1.Controls.Add(Me.CheckBox3)
        Me.Frame1.Controls.Add(Me.CheckBox2)
        Me.Frame1.Controls.Add(Me.CheckBox1)
        Me.Frame1.Controls.Add(Me.CheckBox4)
        Me.Frame1.Location = New System.Drawing.Point(11, 53)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(520, 216)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Seleccione lo que desea certificar"
        '
        'TxtAñadirVarAcero
        '
        Me.TxtAñadirVarAcero.DisabledBackColor = System.Drawing.Color.White
        Me.TxtAñadirVarAcero.Location = New System.Drawing.Point(24, 179)
        Me.TxtAñadirVarAcero.Name = "TxtAñadirVarAcero"
        Me.TxtAñadirVarAcero.Size = New System.Drawing.Size(476, 21)
        Me.TxtAñadirVarAcero.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Comentario Variación Precio Acero"
        '
        'CheckBox5
        '
        Me.CheckBox5.Location = New System.Drawing.Point(275, 79)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(104, 23)
        Me.CheckBox5.TabIndex = 6
        Me.CheckBox5.Text = "Alambre"
        '
        'CheckBox6
        '
        Me.CheckBox6.Location = New System.Drawing.Point(275, 50)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(171, 23)
        Me.CheckBox6.TabIndex = 5
        Me.CheckBox6.Text = "Fac. Elaboración"
        '
        'CheckBox7
        '
        Me.CheckBox7.Location = New System.Drawing.Point(44, 137)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(169, 23)
        Me.CheckBox7.TabIndex = 4
        Me.CheckBox7.Text = "Variación Precio Acero"
        '
        'CheckBox3
        '
        Me.CheckBox3.Location = New System.Drawing.Point(44, 108)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(195, 23)
        Me.CheckBox3.TabIndex = 3
        Me.CheckBox3.Text = "Fac. Medios de Elevación"
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(44, 79)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(104, 23)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "Fac. Montaje"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(44, 50)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 23)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "Fac. Acero"
        '
        'CheckBox4
        '
        Me.CheckBox4.Location = New System.Drawing.Point(7, 21)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(104, 23)
        Me.CheckBox4.TabIndex = 0
        Me.CheckBox4.Text = "TODO"
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.RB3)
        Me.Frame2.Controls.Add(Me.RB2)
        Me.Frame2.Controls.Add(Me.RB1)
        Me.Frame2.Location = New System.Drawing.Point(11, 285)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(520, 76)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Precios"
        '
        'RB3
        '
        Me.RB3.Location = New System.Drawing.Point(381, 33)
        Me.RB3.Name = "RB3"
        Me.RB3.Size = New System.Drawing.Size(104, 23)
        Me.RB3.TabIndex = 2
        Me.RB3.Text = "Precio B"
        '
        'RB2
        '
        Me.RB2.Location = New System.Drawing.Point(200, 33)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(104, 23)
        Me.RB2.TabIndex = 1
        Me.RB2.Text = "Precio A"
        '
        'RB1
        '
        Me.RB1.Location = New System.Drawing.Point(24, 33)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(104, 23)
        Me.RB1.TabIndex = 0
        Me.RB1.Text = "Todos Precios"
        '
        'UL1
        '
        Me.UL1.AutoSize = True
        Me.UL1.Location = New System.Drawing.Point(15, 27)
        Me.UL1.Name = "UL1"
        Me.UL1.Size = New System.Drawing.Size(0, 13)
        Me.UL1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.BtnNuevaCertif)
        Me.Panel2.Controls.Add(Me.BtnUnirCertif)
        Me.Panel2.Location = New System.Drawing.Point(0, 560)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(533, 81)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(371, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cerrar"
        '
        'BtnNuevaCertif
        '
        Me.BtnNuevaCertif.Location = New System.Drawing.Point(19, 18)
        Me.BtnNuevaCertif.Name = "BtnNuevaCertif"
        Me.BtnNuevaCertif.Size = New System.Drawing.Size(140, 38)
        Me.BtnNuevaCertif.TabIndex = 0
        Me.BtnNuevaCertif.Text = "Crear nueva certificación"
        '
        'BtnUnirCertif
        '
        Me.BtnUnirCertif.Location = New System.Drawing.Point(198, 18)
        Me.BtnUnirCertif.Name = "BtnUnirCertif"
        Me.BtnUnirCertif.Size = New System.Drawing.Size(140, 38)
        Me.BtnUnirCertif.TabIndex = 1
        Me.BtnUnirCertif.Text = "Unir certificación"
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.GridSeleccionarCertif)
        Me.Frame3.Location = New System.Drawing.Point(-2, 5)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(531, 170)
        Me.Frame3.TabIndex = 0
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "A continuación se muestran las certificaciónes existentes en la obra"
        '
        'GridSeleccionarCertif
        '
        Me.GridSeleccionarCertif.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.GridSeleccionarCertif.EntityName = "ObraCertificacion"
        Me.GridSeleccionarCertif.Location = New System.Drawing.Point(0, 20)
        Me.GridSeleccionarCertif.Name = "GridSeleccionarCertif"
        Me.GridSeleccionarCertif.PrimaryDataFields = "IdCertificacion"
        Me.GridSeleccionarCertif.RelationMode = Solmicro.Expertis.Engine.RelationMode.NoRelation
        Me.GridSeleccionarCertif.SecondaryDataFields = "IdCertificacion"
        Me.GridSeleccionarCertif.Size = New System.Drawing.Size(528, 144)
        Me.GridSeleccionarCertif.TabIndex = 0
        Me.GridSeleccionarCertif.ViewName = "tbObraCertificacion"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Frame3)
        Me.Panel3.Location = New System.Drawing.Point(2, 385)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(530, 175)
        Me.Panel3.TabIndex = 2
        '
        'SeleccionarCertificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 640)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SeleccionarCertificacion"
        Me.Text = "SeleccionarCertificacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        CType(Me.GridSeleccionarCertif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents UL2 As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents UL1 As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents Frame3 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Frame2 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents RB3 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents RB2 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents RB1 As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents Panel2 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents TxtAñadirVarAcero As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents CheckBox5 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents CheckBox6 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents CheckBox7 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents CheckBox3 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents CheckBox2 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents CheckBox1 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents CheckBox4 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnUnirCertif As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnNuevaCertif As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents GridSeleccionarCertif As Solmicro.Expertis.Engine.UI.Grid
    Friend WithEvents Panel3 As Solmicro.Expertis.Engine.UI.Panel
End Class
