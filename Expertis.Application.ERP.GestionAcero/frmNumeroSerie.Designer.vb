<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNumeroSerie
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
        Me.Panel1 = New Solmicro.Expertis.Engine.UI.Panel
        Me.GridNSerie = New Solmicro.Expertis.Engine.UI.Grid
        Me.NtbDiferencia = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.NtbCantidadAsignada = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.NtbCantidadAsignar = New Solmicro.Expertis.Engine.UI.NumericTextBox
        Me.Button3 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button2 = New Solmicro.Expertis.Engine.UI.Button
        Me.Button1 = New Solmicro.Expertis.Engine.UI.Button
        Me.Panel2 = New Solmicro.Expertis.Engine.UI.Panel
        Me.BtnCerrar = New Solmicro.Expertis.Engine.UI.Button
        Me.TxtFichero = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Label2 = New Solmicro.Expertis.Engine.UI.Label
        Me.PcbImagen = New System.Windows.Forms.PictureBox
        Me.BtnVistaPrevia = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnSiguiente = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnAnterior = New Solmicro.Expertis.Engine.UI.Button
        Me.Label1 = New Solmicro.Expertis.Engine.UI.Label
        Me.TxtIDArticulo = New Solmicro.Expertis.Engine.UI.TextBox
        Me.LblTitulo = New Solmicro.Expertis.Engine.UI.Label
        Me.Panel1.suspendlayout()
        CType(Me.GridNSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.suspendlayout()
        CType(Me.PcbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GridNSerie)
        Me.Panel1.Controls.Add(Me.NtbDiferencia)
        Me.Panel1.Controls.Add(Me.NtbCantidadAsignada)
        Me.Panel1.Controls.Add(Me.NtbCantidadAsignar)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(5, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(483, 385)
        Me.Panel1.TabIndex = 0
        '
        'GridNSerie
        '
        Me.GridNSerie.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.GridNSerie.EntityName = Nothing
        Me.GridNSerie.Location = New System.Drawing.Point(0, 107)
        Me.GridNSerie.Name = "GridNSerie"
        Me.GridNSerie.PrimaryDataFields = Nothing
        Me.GridNSerie.SecondaryDataFields = Nothing
        Me.GridNSerie.Size = New System.Drawing.Size(483, 278)
        Me.GridNSerie.TabIndex = 6
        Me.GridNSerie.ViewName = Nothing
        '
        'NtbDiferencia
        '
        Me.NtbDiferencia.DisabledBackColor = System.Drawing.Color.White
        Me.NtbDiferencia.Location = New System.Drawing.Point(275, 60)
        Me.NtbDiferencia.Name = "NtbDiferencia"
        Me.NtbDiferencia.Size = New System.Drawing.Size(111, 21)
        Me.NtbDiferencia.TabIndex = 5
        '
        'NtbCantidadAsignada
        '
        Me.NtbCantidadAsignada.DisabledBackColor = System.Drawing.Color.White
        Me.NtbCantidadAsignada.Location = New System.Drawing.Point(164, 60)
        Me.NtbCantidadAsignada.Name = "NtbCantidadAsignada"
        Me.NtbCantidadAsignada.Size = New System.Drawing.Size(111, 21)
        Me.NtbCantidadAsignada.TabIndex = 4
        '
        'NtbCantidadAsignar
        '
        Me.NtbCantidadAsignar.DisabledBackColor = System.Drawing.Color.White
        Me.NtbCantidadAsignar.Location = New System.Drawing.Point(54, 60)
        Me.NtbCantidadAsignar.Name = "NtbCantidadAsignar"
        Me.NtbCantidadAsignar.Size = New System.Drawing.Size(111, 21)
        Me.NtbCantidadAsignar.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(275, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Diferencia"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(164, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Peso Producción"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Peso Facturación"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BtnCerrar)
        Me.Panel2.Controls.Add(Me.TxtFichero)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.PcbImagen)
        Me.Panel2.Controls.Add(Me.BtnVistaPrevia)
        Me.Panel2.Controls.Add(Me.BtnSiguiente)
        Me.Panel2.Controls.Add(Me.BtnAnterior)
        Me.Panel2.Location = New System.Drawing.Point(489, 70)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(489, 385)
        Me.Panel2.TabIndex = 1
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Location = New System.Drawing.Point(390, 352)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(87, 23)
        Me.BtnCerrar.TabIndex = 6
        Me.BtnCerrar.Text = "Cerrar"
        '
        'TxtFichero
        '
        Me.TxtFichero.DisabledBackColor = System.Drawing.Color.White
        Me.TxtFichero.Location = New System.Drawing.Point(83, 318)
        Me.TxtFichero.Name = "TxtFichero"
        Me.TxtFichero.Size = New System.Drawing.Size(394, 21)
        Me.TxtFichero.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 322)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fichero"
        '
        'PcbImagen
        '
        Me.PcbImagen.Location = New System.Drawing.Point(20, 107)
        Me.PcbImagen.Name = "PcbImagen"
        Me.PcbImagen.Size = New System.Drawing.Size(457, 173)
        Me.PcbImagen.TabIndex = 3
        Me.PcbImagen.TabStop = False
        '
        'BtnVistaPrevia
        '
        Me.BtnVistaPrevia.Location = New System.Drawing.Point(341, 60)
        Me.BtnVistaPrevia.Name = "BtnVistaPrevia"
        Me.BtnVistaPrevia.Size = New System.Drawing.Size(87, 23)
        Me.BtnVistaPrevia.TabIndex = 2
        Me.BtnVistaPrevia.Text = "Button6"
        '
        'BtnSiguiente
        '
        Me.BtnSiguiente.Location = New System.Drawing.Point(187, 60)
        Me.BtnSiguiente.Name = "BtnSiguiente"
        Me.BtnSiguiente.Size = New System.Drawing.Size(87, 23)
        Me.BtnSiguiente.TabIndex = 1
        Me.BtnSiguiente.Text = "Button5"
        '
        'BtnAnterior
        '
        Me.BtnAnterior.Location = New System.Drawing.Point(43, 60)
        Me.BtnAnterior.Name = "BtnAnterior"
        Me.BtnAnterior.Size = New System.Drawing.Size(87, 23)
        Me.BtnAnterior.TabIndex = 0
        Me.BtnAnterior.Text = "Button4"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Diámetro"
        '
        'TxtIDArticulo
        '
        Me.TxtIDArticulo.DisabledBackColor = System.Drawing.Color.White
        Me.TxtIDArticulo.Location = New System.Drawing.Point(113, 25)
        Me.TxtIDArticulo.Name = "TxtIDArticulo"
        Me.TxtIDArticulo.Size = New System.Drawing.Size(147, 21)
        Me.TxtIDArticulo.TabIndex = 3
        '
        'LblTitulo
        '
        Me.LblTitulo.Location = New System.Drawing.Point(685, 28)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(0, 13)
        Me.LblTitulo.TabIndex = 4
        '
        'frmNumeroSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 457)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.TxtIDArticulo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmNumeroSerie"
        Me.Text = "frmNumeroSerie"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GridNSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PcbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents Panel2 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents Label1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents GridNSerie As Solmicro.Expertis.Engine.UI.Grid
    Friend WithEvents NtbDiferencia As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents NtbCantidadAsignada As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents NtbCantidadAsignar As Solmicro.Expertis.Engine.UI.NumericTextBox
    Friend WithEvents Button3 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button2 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents Button1 As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnCerrar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents TxtFichero As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Label2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents PcbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents BtnVistaPrevia As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnSiguiente As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnAnterior As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents TxtIDArticulo As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents LblTitulo As Solmicro.Expertis.Engine.UI.Label
End Class
