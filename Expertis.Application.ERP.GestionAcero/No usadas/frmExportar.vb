Imports System.Windows.Forms
Imports Solmicro.Expertis.Engine.DAL
Imports Solmicro.Expertis.Engine.UI
Imports Solmicro.Expertis.Engine.Global
Imports Solmicro.Expertis.Engine.UI.SimpleMnto



Public Class frmExportar

    Public lngIDObraGA As Long
    Public sNumObra As String
    Public DescObra As String

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If ValidarOK() Then
            EjecutarExportarMediciones()
            Me.Close()
        End If
    End Sub

    Private Function ValidarOK() As Boolean
        If Len(Nz(CmbEmpresa.Value, "")) = 0 Then
            ExpertisApp.GenerateMessage("Debe indicar la empresa Destino", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ValidarOK = True
        End If
    End Function

    Private Sub EjecutarExportarMediciones()
        Dim strEmpresa As String
        Dim strBase As String
        Dim strWhere As String
        Dim strInsert As String
        Dim strCampos As String
        Dim strSelect As String
        Dim dtLineas As DataTable

        '1 Validar que los id de articulos esten ok
        If Not (Validardatos()) Then
            Exit Sub
        End If

        '2 Insertar Mediciones
        strEmpresa = CmbEmpresa.Value
        strBase = strEmpresa & ".dbo." & "tbObraMedicionAcero"
        strCampos = "IDLineaMedicionA, IdObra, FechaRef, Estructura, Localizacion1, Localizacion2, Fecha, Alambre, D8, D10, D12, D16, D20, D25, D32, " _
            & "PesoPlanilla, PesoPedido, PesoAlbaran, CertificadoSuministro, CertificadoMontaje, CertificadoMediosE, PrecioCertSuministro, " _
            & "PrecioCertSuministroB, TotalSuministro, TotalMontaje, TotalMediosE, Observaciones , Secuencia, IDUDMedida,  " _
            & "numAlbaran, numPedido, MedElaboracion, Observaciones2, FechaAnifer, FacElaboracion, PrecioCertMontaje, PrecioCertMontajeB, " _
            & "PrecioCertMediosElev, PrecioCertMediosElevB, PrecioCertElaboracion, PrecioCertElaboracionB, PesoBascula, PesoPlanillaRef, NObra "

        strSelect = "SELECT " & strCampos & "  " _
        & "From tbObraMedicionAcero Where NObra = '" & sNumObra & "'" _
        & " and IDLineaMedicionA not in (select IDLineaMedicionA from  " & strBase & " where NObra = '" & sNumObra & "')"


        dtLineas = AdminData.Filter(strSelect, , , , False)
        'rsLineas = AdminData.Execute(strSelect)

        'IBIS. David. Exportar Mediciones----------------------------
        Dim dtEM As New DataTable
        dtEM = AdminData.Filter("SELECT IDObra FROM " & strEmpresa & ".dbo." & "tbObraCabecera WHERE NObra='" & sNumObra & "'", , , , False)

        Dim strCampos2 As String
        strCampos2 = "IDLineaMedicionA," & dtEM.Rows(0)("IDObra") & ", FechaRef, Estructura, Localizacion1, Localizacion2, Fecha, Alambre, D8, D10, D12, D16, D20, D25, D32, " _
            & "PesoPlanilla, PesoPedido, PesoAlbaran, CertificadoSuministro, CertificadoMontaje, CertificadoMediosE, PrecioCertSuministro, " _
            & "PrecioCertSuministroB, TotalSuministro, TotalMontaje, TotalMediosE, Observaciones , Secuencia, IDUDMedida,  " _
            & "numAlbaran, numPedido, MedElaboracion, Observaciones2, FechaAnifer, FacElaboracion, PrecioCertMontaje, PrecioCertMontajeB, " _
            & "PrecioCertMediosElev, PrecioCertMediosElevB, PrecioCertElaboracion, PrecioCertElaboracionB, PesoBascula, PesoPlanillaRef, NObra "
        strSelect = "SELECT " & strCampos2 & "  " _
               & "From tbObraMedicionAcero Where NObra = '" & sNumObra & "'" _
               & " and IDLineaMedicionA not in (select IDLineaMedicionA from  " & strBase & " where NObra = '" & sNumObra & "')"

        '-----------------------------------------------------

        If dtLineas.Rows.Count > 0 Then
            strInsert = "INSERT INTO " & strBase _
            & " ( " & strCampos & " ) " & strSelect
            AdminData.Execute(strInsert)
            MsgBox(dtLineas.Rows.Count & " línea exportadas ", vbInformation, "Exportación con éxito")
        Else
            ExpertisApp.GenerateMessage("No hay líneas para exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        dtLineas = Nothing

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmExportar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim rsCLiente As Recordset
        'Me.Left = 50
        'Me.Top = 50
        TxtIDObra.Text = sNumObra 'NObra
        UlbDescObra.Text = DescObra
        EstablecerOrigenDatos()
        txt1.Text = ExpertisApp.DataBaseName
        ' rsCLiente = Nothing
    End Sub

    Private Function Validardatos() As Boolean
        Dim dt As DataTable
        Dim Strsql As String

        Dim strBase As String

        '1 Verificamos que exista la obra
        strBase = CmbEmpresa.Value & ".dbo." & "tbObraCabecera"
        '        Strsql = "SELECT  idObra from  " & strBase & " WHERE   IDObra = " & lngIDObra
        'IBIS. David
        Strsql = "SELECT  idObra FROM  " & strBase & " WHERE   nObra = '" & sNumObra & "'"
        'rs = AdminData.Execute(Strsql)
        dt = AdminData.Filter(Strsql, , , , False)

        If dt.Rows.Count = 0 Then
            ExpertisApp.GenerateMessage("La Obra no existe en la Base de Datos Destino", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Validardatos = False
        Else
            Validardatos = True
        End If

    End Function

    Private Sub EstablecerOrigenDatos()
        Dim strEmpresa As String
        Dim strComboFields As String
        Dim strBase As String
        Dim strWhere As String

        'strComboFields = "IDBaseDatos,;DescEmpresa,"
        'CmbEmpresa.DataSource = AdminData.Filter("FwBaseDatos", "IDBaseDatos,DescEmpresa", , , True)
        CmbEmpresa.DataSource = AdminData.Filter("xDataBase", "BaseDatos,DescBaseDatos", , , , True)
    End Sub


    Private Sub CmbEmpresa_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEmpresa.ValueChanged
        EstablecerMediciones(CmbEmpresa.Value)
    End Sub

    Private Sub EstablecerMediciones(Optional ByVal strEmpresa As String = "")
        Dim strCampos As String
        Dim strBase As String
        Dim strWhere As String

        If Len(Nz(strEmpresa)) = 0 Then strEmpresa = Nz(CmbEmpresa.Value, "")
        GridMedicionesExp.HoldFields()
        If Len(strEmpresa) > 0 Then

            'Obra mediciones
            strBase = strEmpresa & ".dbo." & "tbObraMedicionAcero"
            strCampos = " IDLineaMedicionA, IdObra, FechaRef, Estructura, Localizacion1, Localizacion2, Fecha, Alambre, D8, D10, D12, D16, D20, D25, D32, PesoPlanilla, " _
                              & " PesoPedido, PesoAlbaran, CertificadoSuministro, PrecioCertSuministro,PrecioCertSuministroB, CertificadoMontaje, CertificadoMediosE, TotalSuministro, TotalMontaje, TotalMediosE, NCertificacion, " _
                              & " Observaciones, Secuencia, IDUDMedida, numAlbaran, numPedido,NObra "

            'strWhere = "IDObra = " & lngIDObra
            'linea que funciona
            'strWhere = "IDObra = " & lngIDObraGA
            strWhere = "NObra ='" & sNumObra & "'"


            'GridMedicionesExp.DataSource = AdminData.Filter(strBase, strCampos, strWhere, "IDLineaMedicionA", True)
            GridMedicionesExp.DataSource = AdminData.GetData("SELECT " & strCampos & "FROM " & strBase & " WHERE " & strWhere)

            GridMedicionesExp.Refresh()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim z As Windows.Forms.DialogResult
        z = MessageBox.Show("Los precios del Suministro serán modificados tanto en la empresa origen como en la empresa destino" & Chr(13) & _
        "¿Desea continuar?", "Validar Precios", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        If z = DialogResult.OK Then
            GridMedicionesExp.UpdateData()
            GridMedicionesExp.Refresh()
        Else
            GridMedicionesExp.Refresh()
        End If

    End Sub
End Class