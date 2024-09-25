Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Business.ClasesTecozam

Public Class CIPesoBasculaObra
    Dim auxiliares As New MetodosAuxiliares
    Private Sub CIPesoBasculaObra_QueryExecuting(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles MyBase.QueryExecuting

        Dim fecha1 As String = clbFechaDesde.Value.ToString
        Dim fecha2 As String = clbFechaHasta.Value.ToString

        If Len(clbFechaDesde.Value.ToString) = 0 Or Len(clbFechaHasta.Value.ToString) = 0 Then
            MsgBox("Atención: Las fechas son datos obligatorios. Por favor, verifica que has ingresado ambas fechas.", vbExclamation + vbOKOnly, "Información Importante")
        Else
            Dim obra As String
            obra = advNObra.Text
            Dim dtDatos As New DataTable
            If Len(obra) = 0 Then
                dtDatos = setDataObras(fecha1, fecha2)
            Else
                dtDatos = setDataObra(fecha1, fecha2, obra)
            End If
            Grid.DataSource = dtDatos
            Dim chatarraValue As Decimal
            If Decimal.TryParse(getChatarra(fecha1, fecha2), chatarraValue) Then
                txtChatarra.Text = chatarraValue.ToString("N2")
            End If
        End If
    End Sub
    Public Function setDataObra(ByVal fecha1 As String, ByVal fecha2 As String, ByVal obra As String) As DataTable
        Dim sql As String
        sql = "select Codigo, Obra, SUM(kg_planilla) AS kg_planilla, SUM(kg_produccion) AS kg_produccion, SUM(kg_bascula) AS kg_bascula "
        sql &= "from vBasculasAcero "
        sql &= "where Fecha >= '" & fecha1 & "' and Fecha <= '" & fecha2 & "' and Codigo = '" & obra & "' "
        sql &= "group by Codigo, Obra"

        Dim dt As DataTable
        dt = auxiliares.EjecutarSqlSelect(sql)

        Return dt
    End Function

    Public Function setDataObras(ByVal fecha1 As String, ByVal fecha2 As String) As DataTable
        Dim sql As String
        sql = "select Codigo, Obra, SUM(kg_planilla) AS kg_planilla, SUM(kg_produccion) AS kg_produccion, SUM(kg_bascula) AS kg_bascula "
        sql &= "from vBasculasAcero "
        sql &= "where Fecha >= '" & fecha1 & "' and Fecha <= '" & fecha2 & "'"
        sql &= "group by Codigo, Obra"


        Dim dt = auxiliares.EjecutarSqlSelect(sql)

        Return dt
    End Function

    Public Function getChatarra(ByVal fecha1 As String, ByVal fecha2 As String) As String
        Dim sql As String
        sql = "select SUM(Cantidad) as TotalCantidad from vFrmEstadisticaFVDetalladaA "
        sql &= "where IDArticulo = 'CHATARRA' and FechaFactura >= '" & fecha1 & "' and FechaFactura <= '" & fecha2 & "' "
        Dim dt As DataTable
        dt = auxiliares.EjecutarSqlSelect(sql)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("TotalCantidad")
        Else
            Return 0
        End If

    End Function
End Class