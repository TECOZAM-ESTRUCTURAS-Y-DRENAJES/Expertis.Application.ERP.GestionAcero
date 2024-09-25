<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcionesAlbaran
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
        Me.bAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.bCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.lblObra = New Solmicro.Expertis.Engine.UI.Label
        Me.lblEstructura = New Solmicro.Expertis.Engine.UI.Label
        Me.lblLocalizacion1 = New Solmicro.Expertis.Engine.UI.Label
        Me.lblLocalizacion2 = New Solmicro.Expertis.Engine.UI.Label
        Me.Fecha = New Solmicro.Expertis.Engine.UI.Label
        Me.Label6 = New Solmicro.Expertis.Engine.UI.Label
        Me.lblMallazo = New Solmicro.Expertis.Engine.UI.Label
        Me.txtObra = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtLocalizacion2 = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtnumAlbaran = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtnumPedido = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtMallazo = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtLocalizacion1 = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtEstructura = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Frame1 = New Solmicro.Expertis.Engine.UI.Frame
        Me.txtPesoBascula = New Solmicro.Expertis.Engine.UI.TextBox
        Me.lblPesoBascula = New Solmicro.Expertis.Engine.UI.Label
        Me.lblTransporte = New Solmicro.Expertis.Engine.UI.Label
        Me.txtAlambre = New Solmicro.Expertis.Engine.UI.TextBox
        Me.txtTransporte = New Solmicro.Expertis.Engine.UI.TextBox
        Me.lblAlambre = New Solmicro.Expertis.Engine.UI.Label
        Me.lblFecha = New Solmicro.Expertis.Engine.UI.Label
        Me.txtFecha = New Solmicro.Expertis.Engine.UI.TextBox
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bAceptar
        '
        Me.bAceptar.Location = New System.Drawing.Point(355, 324)
        Me.bAceptar.Name = "bAceptar"
        Me.bAceptar.Size = New System.Drawing.Size(87, 23)
        Me.bAceptar.TabIndex = 12
        Me.bAceptar.Text = "Aceptar"
        '
        'bCancelar
        '
        Me.bCancelar.Location = New System.Drawing.Point(476, 324)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(87, 23)
        Me.bCancelar.TabIndex = 13
        Me.bCancelar.Text = "Cancelar"
        '
        'lblObra
        '
        Me.lblObra.Location = New System.Drawing.Point(25, 26)
        Me.lblObra.Name = "lblObra"
        Me.lblObra.Size = New System.Drawing.Size(35, 13)
        Me.lblObra.TabIndex = 23
        Me.lblObra.Text = "Obra"
        '
        'lblEstructura
        '
        Me.lblEstructura.Location = New System.Drawing.Point(25, 65)
        Me.lblEstructura.Name = "lblEstructura"
        Me.lblEstructura.Size = New System.Drawing.Size(65, 13)
        Me.lblEstructura.TabIndex = 24
        Me.lblEstructura.Text = "Estructura"
        '
        'lblLocalizacion1
        '
        Me.lblLocalizacion1.Location = New System.Drawing.Point(25, 102)
        Me.lblLocalizacion1.Name = "lblLocalizacion1"
        Me.lblLocalizacion1.Size = New System.Drawing.Size(82, 13)
        Me.lblLocalizacion1.TabIndex = 14
        Me.lblLocalizacion1.Text = "Localizacion1"
        '
        'lblLocalizacion2
        '
        Me.lblLocalizacion2.Location = New System.Drawing.Point(25, 140)
        Me.lblLocalizacion2.Name = "lblLocalizacion2"
        Me.lblLocalizacion2.Size = New System.Drawing.Size(82, 13)
        Me.lblLocalizacion2.TabIndex = 15
        Me.lblLocalizacion2.Text = "Localizacion2"
        '
        'Fecha
        '
        Me.Fecha.Location = New System.Drawing.Point(25, 179)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(76, 13)
        Me.Fecha.TabIndex = 16
        Me.Fecha.Text = "numAlbaran"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(25, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "numPedido"
        '
        'lblMallazo
        '
        Me.lblMallazo.Location = New System.Drawing.Point(313, 30)
        Me.lblMallazo.Name = "lblMallazo"
        Me.lblMallazo.Size = New System.Drawing.Size(49, 13)
        Me.lblMallazo.TabIndex = 19
        Me.lblMallazo.Text = "Mallazo"
        '
        'txtObra
        '
        Me.txtObra.DisabledBackColor = System.Drawing.Color.White
        Me.txtObra.Location = New System.Drawing.Point(147, 26)
        Me.txtObra.Name = "txtObra"
        Me.txtObra.Size = New System.Drawing.Size(117, 21)
        Me.txtObra.TabIndex = 1
        '
        'txtLocalizacion2
        '
        Me.txtLocalizacion2.DisabledBackColor = System.Drawing.Color.White
        Me.txtLocalizacion2.Location = New System.Drawing.Point(147, 137)
        Me.txtLocalizacion2.Name = "txtLocalizacion2"
        Me.txtLocalizacion2.Size = New System.Drawing.Size(117, 21)
        Me.txtLocalizacion2.TabIndex = 4
        '
        'txtnumAlbaran
        '
        Me.txtnumAlbaran.DisabledBackColor = System.Drawing.Color.White
        Me.txtnumAlbaran.Location = New System.Drawing.Point(147, 175)
        Me.txtnumAlbaran.Name = "txtnumAlbaran"
        Me.txtnumAlbaran.Size = New System.Drawing.Size(117, 21)
        Me.txtnumAlbaran.TabIndex = 5
        '
        'txtnumPedido
        '
        Me.txtnumPedido.DisabledBackColor = System.Drawing.Color.White
        Me.txtnumPedido.Location = New System.Drawing.Point(147, 210)
        Me.txtnumPedido.Name = "txtnumPedido"
        Me.txtnumPedido.Size = New System.Drawing.Size(117, 21)
        Me.txtnumPedido.TabIndex = 6
        '
        'txtMallazo
        '
        Me.txtMallazo.DisabledBackColor = System.Drawing.Color.White
        Me.txtMallazo.Location = New System.Drawing.Point(401, 26)
        Me.txtMallazo.Name = "txtMallazo"
        Me.txtMallazo.Size = New System.Drawing.Size(117, 21)
        Me.txtMallazo.TabIndex = 8
        '
        'txtLocalizacion1
        '
        Me.txtLocalizacion1.DisabledBackColor = System.Drawing.Color.White
        Me.txtLocalizacion1.Location = New System.Drawing.Point(147, 98)
        Me.txtLocalizacion1.Name = "txtLocalizacion1"
        Me.txtLocalizacion1.Size = New System.Drawing.Size(117, 21)
        Me.txtLocalizacion1.TabIndex = 3
        '
        'txtEstructura
        '
        Me.txtEstructura.DisabledBackColor = System.Drawing.Color.White
        Me.txtEstructura.Location = New System.Drawing.Point(147, 65)
        Me.txtEstructura.Name = "txtEstructura"
        Me.txtEstructura.Size = New System.Drawing.Size(117, 21)
        Me.txtEstructura.TabIndex = 2
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.txtFecha)
        Me.Frame1.Controls.Add(Me.lblFecha)
        Me.Frame1.Controls.Add(Me.txtPesoBascula)
        Me.Frame1.Controls.Add(Me.lblPesoBascula)
        Me.Frame1.Controls.Add(Me.lblTransporte)
        Me.Frame1.Controls.Add(Me.txtAlambre)
        Me.Frame1.Controls.Add(Me.txtTransporte)
        Me.Frame1.Controls.Add(Me.lblAlambre)
        Me.Frame1.Controls.Add(Me.lblObra)
        Me.Frame1.Controls.Add(Me.txtEstructura)
        Me.Frame1.Controls.Add(Me.lblEstructura)
        Me.Frame1.Controls.Add(Me.txtLocalizacion1)
        Me.Frame1.Controls.Add(Me.lblLocalizacion1)
        Me.Frame1.Controls.Add(Me.txtMallazo)
        Me.Frame1.Controls.Add(Me.lblLocalizacion2)
        Me.Frame1.Controls.Add(Me.txtnumPedido)
        Me.Frame1.Controls.Add(Me.Fecha)
        Me.Frame1.Controls.Add(Me.txtnumAlbaran)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.txtLocalizacion2)
        Me.Frame1.Controls.Add(Me.lblMallazo)
        Me.Frame1.Controls.Add(Me.txtObra)
        Me.Frame1.Location = New System.Drawing.Point(25, 29)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(538, 275)
        Me.Frame1.TabIndex = 16
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Datos"
        '
        'txtPesoBascula
        '
        Me.txtPesoBascula.DisabledBackColor = System.Drawing.Color.White
        Me.txtPesoBascula.Location = New System.Drawing.Point(401, 245)
        Me.txtPesoBascula.Name = "txtPesoBascula"
        Me.txtPesoBascula.Size = New System.Drawing.Size(117, 21)
        Me.txtPesoBascula.TabIndex = 11
        '
        'lblPesoBascula
        '
        Me.lblPesoBascula.Location = New System.Drawing.Point(313, 249)
        Me.lblPesoBascula.Name = "lblPesoBascula"
        Me.lblPesoBascula.Size = New System.Drawing.Size(82, 13)
        Me.lblPesoBascula.TabIndex = 22
        Me.lblPesoBascula.Text = "Peso Bascula"
        '
        'lblTransporte
        '
        Me.lblTransporte.Location = New System.Drawing.Point(313, 214)
        Me.lblTransporte.Name = "lblTransporte"
        Me.lblTransporte.Size = New System.Drawing.Size(68, 13)
        Me.lblTransporte.TabIndex = 21
        Me.lblTransporte.Text = "Transporte"
        '
        'txtAlambre
        '
        Me.txtAlambre.DisabledBackColor = System.Drawing.Color.White
        Me.txtAlambre.Location = New System.Drawing.Point(401, 94)
        Me.txtAlambre.Name = "txtAlambre"
        Me.txtAlambre.Size = New System.Drawing.Size(117, 21)
        Me.txtAlambre.TabIndex = 9
        '
        'txtTransporte
        '
        Me.txtTransporte.DisabledBackColor = System.Drawing.Color.White
        Me.txtTransporte.Location = New System.Drawing.Point(401, 210)
        Me.txtTransporte.Name = "txtTransporte"
        Me.txtTransporte.Size = New System.Drawing.Size(117, 21)
        Me.txtTransporte.TabIndex = 10
        '
        'lblAlambre
        '
        Me.lblAlambre.Location = New System.Drawing.Point(313, 98)
        Me.lblAlambre.Name = "lblAlambre"
        Me.lblAlambre.Size = New System.Drawing.Size(55, 13)
        Me.lblAlambre.TabIndex = 20
        Me.lblAlambre.Text = "Alambre"
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(25, 250)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 18
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.DisabledBackColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(147, 246)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(117, 21)
        Me.txtFecha.TabIndex = 7
        '
        'frmOpcionesAlbaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 359)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bAceptar)
        Me.Name = "frmOpcionesAlbaran"
        Me.Text = "frmOpcionesAlbaran"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents bCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents lblObra As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblEstructura As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblLocalizacion1 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblLocalizacion2 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Fecha As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents Label6 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblMallazo As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtObra As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtLocalizacion2 As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtnumAlbaran As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtnumPedido As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtMallazo As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtLocalizacion1 As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtEstructura As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents Frame1 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents lblAlambre As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtAlambre As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtTransporte As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents lblTransporte As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtPesoBascula As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents lblPesoBascula As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtFecha As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents lblFecha As Solmicro.Expertis.Engine.UI.Label
End Class
