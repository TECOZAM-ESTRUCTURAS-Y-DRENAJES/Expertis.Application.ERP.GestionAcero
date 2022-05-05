Imports System.Windows.Forms
Imports Solmicro.Expertis.Engine.DAL
Imports Solmicro.Expertis.Engine.UI
Imports Solmicro.Expertis.Engine.Global
Imports Solmicro.Expertis.Engine.UI.SimpleMnto
Imports Solmicro.Expertis.Business.Obra
Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Business.ClasesTecozam

Public Class frmOpcionesAlbaran
    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public Const TRANSPORTE As Integer = 1

    '---COMUNES PARA LAS 3 OPCIONES
    Public nobra As String
    Public estructura As String
    Public localizacion1 As String
    Public localizacion2 As String
    Public numAlbaran As String
    Public numPedido As String
    Public fech As Date

    '---MALLAZO
    Public mallazo As String

    '---ALAMBRE
    Public alambre As String

    '---BASCULA+TRANSPORTE
    Public pesobascula As String
    Public etransporte As String


    Private Sub bAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAceptar.Click
        '---INSERTA LOS DATOS EN BBDD
        '---3 TIPOS DE INSERT. MALLAZO // ALAMBRE // BASCULA + TRANSPORTE
        If txtMallazo.Visible = True Then
            insertarLineasMallazo()
        ElseIf txtAlambre.Visible = True Then
            insertarLineasAlambre()
        ElseIf txtPesoBascula.Visible = True Then
            insertarLineasBasculaTransporte()
        End If
        Me.Close()
    End Sub

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        '---CANCELO INSERCCION
        Me.Close()
    End Sub

    Private Sub frmOpcionesAlbaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtObra.Text = nobra
        txtnumAlbaran.Text = numAlbaran
        txtFecha.Text = fech
        'ALAMBRE
        txtLocalizacion1.Text = localizacion1
        'PESO+BASCULA
        txtEstructura.Text = estructura
    End Sub
    Public Sub insertarLineasMallazo()
        Dim auto As New OperarioCalendario
        Dim obraCab As New ObraCabecera
        Dim obra As String
        obra = ""
        Dim f As New Filter
        Dim dtobra As New DataTable
        Dim idob As String

        f.Add("Nobra", FilterOperator.Equal, txtObra.Text)
        dtobra = obraCab.Filter(f, , "IDObra")
        idob = dtobra(0)("IDObra")


        'Obtengo El IDLineaMedicionA
        Dim IdAutonumerico As Long
        IdAutonumerico = auto.Autonumerico()

        Dim txtSQL As String
        txtSQL = "Insert into tbObraMedicionAcero(IDLineaMedicionA, IDObra, Estructura, Localizacion1, Localizacion2," & _
        "Fecha, numAlbaran, numPedido, NObra, Mallazo, FechaCreacionAudi, FechaModificacionAudi, UsuarioAudi)" & _
        "Values('" & IdAutonumerico & "','" & idob & "', '" & Nz(txtEstructura.Text, "") & "', '" & Nz(txtLocalizacion1.Text, "") & "', '" & Nz(txtLocalizacion2.Text, "") & "', '" & _
        txtFecha.Text & "','" & Nz(txtnumAlbaran.Text, "") & "', '" & Nz(txtnumPedido.Text, "") & "', '" & txtObra.Text & "', '" & Nz(txtMallazo.Text, 0) & "', '" & DateTime.Now & "', '" & DateTime.Now & "', '" & ExpertisApp.UserName & "')"
        auto.Ejecutar(txtSQL)
    End Sub

    Public Sub insertarLineasAlambre()
        Dim auto As New OperarioCalendario
        Dim obraCab As New ObraCabecera
        Dim obra As String
        obra = ""
        Dim f As New Filter
        Dim dtobra As New DataTable
        Dim idob As String

        f.Add("Nobra", FilterOperator.Equal, txtObra.Text)
        dtobra = obraCab.Filter(f, , "IDObra")
        idob = dtobra(0)("IDObra")


        'Obtengo El IDLineaMedicionA
        Dim IdAutonumerico As Long
        IdAutonumerico = auto.Autonumerico()

        Dim txtSQL As String
        txtSQL = "Insert into tbObraMedicionAcero(IDLineaMedicionA, IDObra, Estructura, Localizacion1, Localizacion2," & _
        "Fecha, numAlbaran, numPedido, NObra, Alambre, FechaCreacionAudi, FechaModificacionAudi, UsuarioAudi)" & _
        "Values('" & IdAutonumerico & "','" & idob & "', '" & Nz(txtEstructura.Text, "") & "', '" & Nz(txtLocalizacion1.Text, "") & "', '" & Nz(txtLocalizacion2.Text, "") & "', '" & _
        txtFecha.Text & "','" & Nz(txtnumAlbaran.Text, "") & "', '" & Nz(txtnumPedido.Text, "") & "', '" & txtObra.Text & "', '" & Nz(txtAlambre.Text, 0) & "', '" & DateTime.Now & "', '" & DateTime.Now & "', '" & ExpertisApp.UserName & "')"
        auto.Ejecutar(txtSQL)
    End Sub
    Public Sub insertarLineasBasculaTransporte()
        Dim auto As New OperarioCalendario
        Dim obraCab As New ObraCabecera
        Dim obra As String
        obra = ""
        Dim f As New Filter
        Dim dtobra As New DataTable
        Dim idob As String

        f.Add("Nobra", FilterOperator.Equal, txtObra.Text)
        dtobra = obraCab.Filter(f, , "IDObra")
        idob = dtobra(0)("IDObra")


        'Obtengo El IDLineaMedicionA
        Dim IdAutonumerico As Long
        IdAutonumerico = auto.Autonumerico()

        Dim txtSQL As String
        txtSQL = "Insert into tbObraMedicionAcero(IDLineaMedicionA, IDObra, Estructura, Localizacion1, Localizacion2," & _
        "Fecha, numAlbaran, numPedido, NObra, PesoBascula, Transporte, ETransporte, FechaCreacionAudi, FechaModificacionAudi, UsuarioAudi)" & _
        "Values('" & IdAutonumerico & "','" & idob & "', '" & Nz(txtEstructura.Text, "") & "', '" & Nz(txtLocalizacion1.Text, "") & "', '" & Nz(txtLocalizacion2.Text, "") & "', '" & _
        txtFecha.Text & "','" & Nz(txtnumAlbaran.Text, "") & "', '" & Nz(txtnumPedido.Text, "") & "', '" & txtObra.Text & "', '" & Nz(txtPesoBascula.Text, 0) & "','" & TRANSPORTE & "','" & Nz(txtTransporte.Text, 0) & "', '" & DateTime.Now & "', '" & DateTime.Now & "', '" & ExpertisApp.UserName & "')"
        auto.Ejecutar(txtSQL)
    End Sub
End Class