Imports Solmicro.Expertis.Engine.UI
Imports Solmicro.Expertis.Engine

Public Class frmInformeAcero

    Inherits Windows.Forms.Form

    Public lngIDObraGA As Long
    Public lngIDCliente As String
    Public lngIDLineaMedicionA As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmInformeAcero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strCampos As String
        Dim strBase As String
        Dim strWhere As String

        'Obra mediciones
        strBase = ".dbo." & "tbObraMedicionAcero"
        strCampos = " IDLineaMedicionA, IdObra, FechaRef, Estructura, Localizacion1, Localizacion2, Fecha, Alambre, D8, D10, D12, D16, D20, D25, D32, PesoPlanilla, " _
                          & " PesoPedido, PesoAlbaran, CertificadoSuministro, PrecioCertSuministro, CertificadoMontaje, CertificadoMediosE, TotalSuministro, TotalMontaje, TotalMediosE, NCertificacion, " _
                          & " Observaciones, Secuencia, IDUDMedida, numAlbaran, numPedido,Observaciones2 "

        'strWhere = "IDObra= " & lngIDObra
        strWhere = "IDObra = " & lngIDObraGA
        Dim sql As String
        sql = "SELECT " & strCampos & "FROM " & strBase & " WHERE " & strWhere
        Dim acero As New Business.ClasesTecozam.Acero
        Dim dt As DataTable

        dt = acero.DevuelveTabla(sql)
        Grid1.DataSource = dt
        'Grid1.DataSource = Engine.DAL.AdminData.GetData("SELECT " & strCampos & "FROM " & strBase & " WHERE " & strWhere)
        Grid1.Refresh()
    End Sub

    'BOTON ACEPTAR
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim resultado As Boolean
        Dim i As Integer
        Dim consulta As String = ""

        'Dim f As New Filter
        'IBIS. David 14-03-08 
        'Dim obj As New AlbaranGrafogestCabecera

        'Dim obj As New AlbaranVentaCabecera
        'Dim intAbrir As Integer

        Try

            For i = 0 To Grid1.RowCount - 1
                'Posicion donde esta el indice de la fila
                Grid1.Row = i
                If Grid1.GetValue("Selector") Then
                    consulta &= "'" & Grid1.GetValue("IdLineaMedicionA") & "'" & ","
                    'consulta &= Grid1.GetValue("IdLineaMedicionA") & ","
                End If
            Next

            consulta = "(" & Mid(consulta, 1, consulta.Length - 1) & ")"
            'consulta = Mid(consulta, 1, consulta.Length - 1)

            If consulta = "()" Then 'Usease q no tiene lineas
                Dim z As Windows.Forms.DialogResult
                z = Windows.Forms.MessageBox.Show("Si no selecciona ninguna línea, se procederá a crear un Albarán de Venta - Grafogest sin líneas de Medición." & Chr(13) & _
                "¿Desea Continuar?", "Crear Albarán de Venta - Grafogest", Windows.Forms.MessageBoxButtons.OKCancel, Windows.Forms.MessageBoxIcon.Information)
                If z = Windows.Forms.DialogResult.OK Then

                    'intAbrir = obj.CrearAlbaranGrafogest(lngIDObraGA, lngIDCliente, consulta)
                    'AbrirAlbaran(intAbrir)
                    'AbrirAlbaran(consulta)
                Else
                    Windows.Forms.MessageBox.Show("Proceso Cancelado", "Crear Albarán de Venta - Grafogest", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                End If
            Else
                'intAbrir = obj.CrearAlbaranGrafogest(lngIDObraGA, lngIDCliente, consulta)
                'AbrirAlbaran(intAbrir)
                ' AbrirAlbaran(consulta)
                ' f.Add("IdlineamedicionA", consulta)
                ' ExpertisApp.OpenReport("INFMEDACERO", f) 'Informe Mediciones Acero

                'Funcion para abrir el informe Mediciones Acero
                ' Rango de fechas
                Dim rp As New Report("INFMEDACERO")
                'Dim filtro As New Filter
                'filtro.Add("IDLineaMedicionA", FilterOperator.Equal, consulta)
                'filtro.Add("Mes", FilterOperator.Equal, sMes)
                'rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro)
                rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", "*", "IdlineamedicionA IN " & consulta)
                Dim frmFechas As New frmlFechaEstFactura
                frmFechas.iIdObra = lngIDObraGA
                frmFechas.ShowDialog()
                ' Añadir filtros de fechas
                If Not IsDBNull(frmFechas.Fdesde) Then
                    rp.Filter.Add("fecha", FilterOperator.GreaterThanOrEqual, frmFechas.Fdesde)
                End If
                If Not IsDBNull(frmFechas.fhasta) Then
                    rp.Filter.Add("fecha", FilterOperator.LessThanOrEqual, frmFechas.fhasta)
                End If
                ExpertisApp.OpenReport(rp)
                frmFechas.Dispose()
                frmFechas = Nothing
            End If

            Me.Close()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class