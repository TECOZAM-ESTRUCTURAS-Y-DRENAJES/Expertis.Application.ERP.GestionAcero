Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Engine.DAL

Public Class SeleccionarCertificacion

    Dim frm As New MntoGestionObrasAcero
    Dim obra As Integer
    Dim unir As Integer
    Dim IDCertificacion As Integer

    Private blnMarcoAll As Boolean
    'IBIS. David
    Public CHK1, CHK2, CHK3, CHK5, CHK6 As Integer
    Public RB1T, RB2A, RB3B As Integer


#Region " Properties "
    Public Property IDObra() As Integer
        Get
            Return obra
        End Get
        Set(ByVal Value As Integer)
            obra = Value
        End Set
    End Property

    Public Property unirCertif() As Integer
        Get
            Return unir
        End Get
        Set(ByVal Value As Integer)
            unir = Value
        End Set
    End Property

    Public Property Certificacion() As Integer
        Get
            Return IDCertificacion
        End Get
        Set(ByVal Value As Integer)
            IDCertificacion = Value
        End Set
    End Property

#End Region

#Region " Load "

    Private Sub SeleccionarCertificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim f As New Filter
        f.Add("IDObra", obra)
        GridSeleccionarCertif.DataSource = AdminData.GetData("tbObraCertificacion", f)
        'IBIS. David
        CheckBox4.Checked = True
        RB1.Checked = True
    End Sub

#End Region

#Region " Unir Certificacion "

    Private Sub BtnUnirCertif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnirCertif.Click
        unirCertif = 1
        Certificacion = GridSeleccionarCertif.GetValue("IDCertificacion")

        'IBIS. David
        If GridSeleccionarCertif.RowCount = 0 Then
            MsgBox("No tiene ninguna certificación en esta obra. Seleccione otra opción", MsgBoxStyle.Exclamation, "Unir Certificación")
            'MessageBox.Show("No tiene ninguna certificación en esta obra", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.Close()
    End Sub

#End Region

#Region " Checks & Buttons"

    Private Sub BtnNuevaCertif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevaCertif.Click
        unirCertif = 0

        'IBIS. David
        CHK1 = CheckBox1.Checked 'SUMINISTRO
        CHK2 = CheckBox2.Checked 'MONTAJE
        CHK3 = CheckBox3.Checked 'MEDIOS DE ELEVACION
        CHK5 = CheckBox5.Checked 'ALAMBRE
        CHK6 = CheckBox6.Checked 'ELABORACION

        RB1T = RB1.Checked 'TODOS PRECIOS
        RB2A = RB2.Checked 'PRECIO A
        RB3B = RB3.Checked 'PRECIO B

        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        unirCertif = 2
        Me.Close()
    End Sub

    Private Sub TodosMarcados()
        If CheckBox4.Checked Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub Conceptos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox5.CheckedChanged
        If Not blnMarcoAll Then TodosMarcados()
    End Sub

    Private Sub chkConceptosAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        blnMarcoAll = True
        CheckBox1.Checked = CheckBox4.Checked
        'chkCrearMateriales.Checked = chkConceptosAll.Checked
        CheckBox2.Checked = CheckBox4.Checked
        CheckBox3.Checked = CheckBox4.Checked
        CheckBox5.Checked = CheckBox4.Checked
        CheckBox6.Checked = CheckBox4.Checked

        blnMarcoAll = False
    End Sub

#End Region

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            TxtAñadirVarAcero.Enabled = True
            TxtAñadirVarAcero.Text = ""
        Else
            TxtAñadirVarAcero.Enabled = False
            TxtAñadirVarAcero.Text = ""
        End If
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class