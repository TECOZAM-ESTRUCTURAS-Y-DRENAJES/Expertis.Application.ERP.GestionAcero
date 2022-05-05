<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportar
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
        Dim CmbEmpresa_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportar))
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.CmbEmpresa = New Solmicro.Expertis.Engine.UI.ComboBox
        Me.Label3 = New Solmicro.Expertis.Engine.UI.Label
        Me.TxtIDObra = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.txt1 = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.GridMedicionesExp = New Solmicro.Expertis.Engine.UI.Grid
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.UlbDescObra = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.Frame1.SuspendLayout()
        CType(Me.CmbEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridMedicionesExp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.UlbDescObra)
        Me.Frame1.Controls.Add(Me.CmbEmpresa)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.TxtIDObra)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.txt1)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Location = New System.Drawing.Point(13, 13)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(753, 126)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Se van a exportar las mediciones de esta obra a la empresa: "
        '
        'CmbEmpresa
        '
        CmbEmpresa_DesignTimeLayout.LayoutString = resources.GetString("CmbEmpresa_DesignTimeLayout.LayoutString")
        Me.CmbEmpresa.DesignTimeLayout = CmbEmpresa_DesignTimeLayout
        Me.CmbEmpresa.DisabledBackColor = System.Drawing.Color.White
        Me.CmbEmpresa.Location = New System.Drawing.Point(453, 31)
        Me.CmbEmpresa.Name = "CmbEmpresa"
        Me.CmbEmpresa.SelectedIndex = -1
        Me.CmbEmpresa.SelectedItem = Nothing
        Me.CmbEmpresa.Size = New System.Drawing.Size(204, 21)
        Me.CmbEmpresa.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(343, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Empresa Destino"
        '
        'TxtIDObra
        '
        Me.TxtIDObra.DisabledBackColor = System.Drawing.Color.White
        Me.TxtIDObra.Location = New System.Drawing.Point(123, 76)
        Me.TxtIDObra.Name = "TxtIDObra"
        Me.TxtIDObra.Size = New System.Drawing.Size(186, 21)
        Me.TxtIDObra.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Obra"
        '
        'txt1
        '
        Me.txt1.DisabledBackColor = System.Drawing.Color.White
        Me.txt1.Location = New System.Drawing.Point(123, 31)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(186, 21)
        Me.txt1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Empresa Actual"
        '
        'GridMedicionesExp
        '
        Me.GridMedicionesExp.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.GridMedicionesExp.EntityName = Nothing
        Me.GridMedicionesExp.Location = New System.Drawing.Point(13, 157)
        Me.GridMedicionesExp.Name = "GridMedicionesExp"
        Me.GridMedicionesExp.PrimaryDataFields = Nothing
        Me.GridMedicionesExp.SecondaryDataFields = Nothing
        Me.GridMedicionesExp.Size = New System.Drawing.Size(752, 272)
        Me.GridMedicionesExp.TabIndex = 1
        Me.GridMedicionesExp.ViewName = Nothing
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(37, 459)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(165, 37)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Validar Precios"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(397, 459)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(165, 37)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "Aceptar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(591, 459)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(165, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "Cancelar"
        '
        'UlbDescObra
        '
        Me.UlbDescObra.AutoSize = True
        Me.UlbDescObra.Location = New System.Drawing.Point(343, 80)
        Me.UlbDescObra.Name = "UlbDescObra"
        Me.UlbDescObra.Size = New System.Drawing.Size(101, 13)
        Me.UlbDescObra.TabIndex = 6
        Me.UlbDescObra.Text = "UnderLineLabel1"
        '
        'frmExportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 530)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GridMedicionesExp)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "frmExportar"
        Me.Text = "frmExportar"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.CmbEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridMedicionesExp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents CmbEmpresa As Solmicro.Expertis.Engine.UI.ComboBox
    Friend WithEvents Label3 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents TxtIDObra As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txt1 As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents GridMedicionesExp As Solmicro.Expertis.Engine.UI.Grid
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents UlbDescObra As Solmicro.Expertis.Engine.UI.UnderLineLabel
End Class
