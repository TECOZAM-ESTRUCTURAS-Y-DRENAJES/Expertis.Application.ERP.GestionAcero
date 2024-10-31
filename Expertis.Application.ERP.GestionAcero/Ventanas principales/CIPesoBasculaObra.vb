Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Business.ClasesTecozam

Public Class CIPesoBasculaObra
    Dim auxiliares As New MetodosAuxiliares

#Region "Acciones ventanas"
    Private Sub CIPesoBasculaObra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaCombos()
    End Sub

    Private Sub CIPesoBasculaObra_QueryExecuting(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles MyBase.QueryExecuting

        Dim fecha1 As String = clbFechaDesde.Value.ToString
        Dim fecha2 As String = clbFechaHasta.Value.ToString
        Dim opcion As String = cmbOpciones.Value
        Dim mes As String = cmbMes.Value
        Dim año As String = cmbAnio.Value

        ' Contar cuántos checkboxes están seleccionados
        Dim checkedCount As Integer = 0
        If cbMet1.Checked Then checkedCount += 1
        If cbMet2.Checked Then checkedCount += 1
        If cbMet3.Checked Then checkedCount += 1

        ' Verificar si hay más de un checkbox seleccionado
        If checkedCount > 1 Then
            MsgBox("Atención: Solo puedes seleccionar un criterio. Por favor, selecciona solo un criterio.", vbExclamation + vbOKOnly, "Información Importante")
            Exit Sub
        ElseIf checkedCount = 0 Then
            MsgBox("Atención: Por favor, selecciona al menos un criterio.", vbExclamation + vbOKOnly, "Información Importante")
            Exit Sub
        End If

        If cbMet1.Checked Then

            If Len(opcion) <> 0 And Len(mes) <> 0 And Len(año) <> 0 Then
                CalculaCriterio1(opcion, mes, año)
            Else
                MsgBox("Selecciona los 3 valores para establecer el primer criterio.")
            End If
        ElseIf cbMet2.Checked Then
            If Len(fecha1) <> 0 And Len(fecha2) <> 0 Then
                CalculaCriterio2(fecha1, fecha2)
            Else
                MsgBox("Selecciona las dos fechas")
            End If
        ElseIf cbMet3.Checked Then
            If Len(cbMes1C3.Value) <> 0 And Len(cbMes2C3.Value) <> 0 And Len(cbAño1c3.Value) <> 0 And Len(cbAño2c3.Value) <> 0 Then
                CalculaCriterio3(cbMes1C3.Value, cbMes2C3.Value, cbAño1c3.Value, cbAño2c3.Value)
            Else
                MsgBox("Por favor, completa los cuatro valores necesarios para el tercer criterio.", vbExclamation + vbOKOnly, "Información Importante")
            End If
        End If
    End Sub
#End Region

#Region "Criterio 1"

    Public Sub CalculaCriterio1(ByVal opcion As String, ByVal mes As String, ByVal anio As String)
        Dim dtObras As New DataTable
        dtObras = getObrasMovimientos()
        Dim fecha As String = "01/01/2024"
        Dim dtNueva As DataTable = RellenaDiaFacturacion(dtObras, fecha)
        ' Filtrar filas con ambas columnas no vacías
        FiltraYNotifica(dtNueva)
        Dim dtFinal As New DataTable
        If opcion = "Mes productivo" Then
            dtFinal = OpcionMesProductivo(dtNueva, mes, anio)
        ElseIf opcion = "Fin del mes" Then
            dtFinal = OpcionFinMes(dtNueva, mes, anio)
        ElseIf opcion = "Inicio del mes" Then
            dtFinal = OpcionInicioMes(dtNueva, mes, anio)
        End If
        Grid.DataSource = dtFinal
        txtChatarra.Text = ""

    End Sub

    Public Function OpcionInicioMes(ByVal dtNueva As DataTable, ByVal mes As String, ByVal anio As String) As DataTable
        Dim fecha1 As String
        Dim fecha2 As String

        ' Crear un DataTable para almacenar los resultados finales
        Dim dtResultados As New DataTable
        dtResultados.Columns.Add("Codigo", GetType(String))
        dtResultados.Columns.Add("Obra", GetType(String))
        dtResultados.Columns.Add("kg_planilla", GetType(Double))
        dtResultados.Columns.Add("kg_bascula", GetType(Double))
        dtResultados.Columns.Add("kg_produccion", GetType(Double))
        ' Agregar nuevas columnas para DiaCierre, Fecha1 y Fecha2
        dtResultados.Columns.Add("DiaCierre", GetType(Integer))
        dtResultados.Columns.Add("Fecha1", GetType(String))
        dtResultados.Columns.Add("Fecha2", GetType(String))

        For Each dr As DataRow In dtNueva.Rows
            Dim diaCierre As Integer = Convert.ToInt32(dr("DiaCierre"))

            ' Calcular fecha1 (primer día del mes)
            fecha1 = New DateTime(anio, mes, 1).ToString("dd/MM/yyyy")

            Try
                fecha2 = New DateTime(anio, mes, diaCierre).ToString("dd/MM/yyyy")
            Catch ex As Exception
                fecha2 = New DateTime(anio, mes, diaCierre - 1).ToString("dd/MM/yyyy")
            End Try

            ' Filtrar y obtener datos de obras usando las fechas calculadas
            Dim dtObras As DataTable = setDataObras(fecha1, fecha2, dr("Codigo").ToString())

            ' Agregar los resultados al DataTable final
            For Each obraRow As DataRow In dtObras.Rows
                ' Crear una nueva fila en dtResultados y agregarle los datos de obra
                Dim newRow As DataRow = dtResultados.NewRow()

                newRow("Codigo") = obraRow("Codigo")
                newRow("Obra") = obraRow("Obra")
                newRow("kg_planilla") = obraRow("kg_planilla")
                newRow("kg_bascula") = obraRow("kg_bascula")
                newRow("kg_produccion") = obraRow("kg_produccion")

                ' Agregar los datos calculados de DiaCierre, Fecha1 y Fecha2
                newRow("DiaCierre") = diaCierre
                newRow("Fecha1") = fecha1
                newRow("Fecha2") = fecha2

                ' Añadir la fila al DataTable final
                dtResultados.Rows.Add(newRow)
            Next
        Next

        Return dtResultados
    End Function

    Public Function OpcionMesProductivo(ByVal dtNueva As DataTable, ByVal mes As String, ByVal anio As String) As DataTable
        Dim fecha1 As String
        Dim fecha2 As String

        ' Crear un DataTable para almacenar los resultados finales
        Dim dtResultados As New DataTable
        dtResultados.Columns.Add("Codigo", GetType(String))
        dtResultados.Columns.Add("Obra", GetType(String))
        dtResultados.Columns.Add("kg_planilla", GetType(Double))
        dtResultados.Columns.Add("kg_bascula", GetType(Double))
        dtResultados.Columns.Add("kg_produccion", GetType(Double))
        ' Agregar nuevas columnas para DiaCierre, Fecha1 y Fecha2
        dtResultados.Columns.Add("DiaCierre", GetType(Integer))
        dtResultados.Columns.Add("Fecha1", GetType(String))
        dtResultados.Columns.Add("Fecha2", GetType(String))

        For Each dr As DataRow In dtNueva.Rows
            Dim diaCierre As Integer = Convert.ToInt32(dr("DiaCierre"))

            ' Calcular fecha2 (día de cierre del mes actual)
            Try
                fecha2 = New DateTime(anio, mes, diaCierre).ToString("dd/MM/yyyy")
            Catch ex As Exception
                fecha2 = New DateTime(anio, mes, diaCierre - 1).ToString("dd/MM/yyyy")
            End Try


            ' Calcular fecha1 (día siguiente al día de cierre del mes anterior)
            Dim fechaBase As DateTime

            ' Obtener el mes anterior
            Dim mesAnterior As Integer = mes - 1

            ' Verificar si el mes anterior es menor a 1 (para diciembre)
            If mesAnterior < 1 Then
                mesAnterior = 12
                anio -= 1 ' Decrementar el año si pasamos de diciembre a enero
            End If

            Try
                ' Calcular fechaBase como el día siguiente al día de cierre del mes anterior
                fechaBase = New DateTime(anio, mesAnterior, diaCierre + 1)
            Catch ex As ArgumentOutOfRangeException
                ' Si el día excede el número de días en el mes, asignar el primer día del mes siguiente
                fechaBase = New DateTime(anio, mesAnterior, 1).AddMonths(1)
            End Try

            ' Formatear fechas
            fecha1 = fechaBase.ToString("dd/MM/yyyy")

            ' Filtrar y obtener datos de obras usando las fechas calculadas
            Dim dtObras As DataTable = setDataObras(fecha1, fecha2, dr("Codigo").ToString())

            ' Agregar los resultados al DataTable final
            For Each obraRow As DataRow In dtObras.Rows
                ' Crear una nueva fila en dtResultados y agregarle los datos de obra
                Dim newRow As DataRow = dtResultados.NewRow()

                newRow("Codigo") = obraRow("Codigo")
                newRow("Obra") = obraRow("Obra")
                newRow("kg_planilla") = obraRow("kg_planilla")
                newRow("kg_bascula") = obraRow("kg_bascula")
                newRow("kg_produccion") = obraRow("kg_produccion")

                ' Agregar los datos calculados de DiaCierre, Fecha1 y Fecha2
                newRow("DiaCierre") = diaCierre
                newRow("Fecha1") = fecha1
                newRow("Fecha2") = fecha2

                ' Añadir la fila al DataTable final
                dtResultados.Rows.Add(newRow)
            Next
        Next
        Return dtResultados
    End Function

    Public Function OpcionFinMes(ByVal dtNueva As DataTable, ByVal mes As String, ByVal anio As String) As DataTable
        Dim fecha1 As String
        Dim fecha2 As String

        ' Crear un DataTable para almacenar los resultados finales
        Dim dtResultados As New DataTable
        dtResultados.Columns.Add("Codigo", GetType(String))
        dtResultados.Columns.Add("Obra", GetType(String))
        dtResultados.Columns.Add("kg_planilla", GetType(Double))
        dtResultados.Columns.Add("kg_bascula", GetType(Double))
        dtResultados.Columns.Add("kg_produccion", GetType(Double))
        ' Agregar nuevas columnas para DiaCierre, Fecha1 y Fecha2
        dtResultados.Columns.Add("DiaCierre", GetType(Integer))
        dtResultados.Columns.Add("Fecha1", GetType(String))
        dtResultados.Columns.Add("Fecha2", GetType(String))

        For Each dr As DataRow In dtNueva.Rows
            Dim diaCierre As Integer = Convert.ToInt32(dr("DiaCierre"))

            ' Calcular el último día del mes actual
            Dim ultimoDiaDelMes As Integer = DateTime.DaysInMonth(anio, mes)

            ' Si el día de cierre es el último día del mes, no lo incluimos en el resultado
            If diaCierre >= ultimoDiaDelMes Then
                Continue For ' Salta a la siguiente iteración
            End If

            ' Calcular fecha1 (día siguiente al día de cierre)
            fecha1 = New DateTime(anio, mes, diaCierre).AddDays(1).ToString("dd/MM/yyyy")

            ' Calcular fecha2 (último día del mes actual)
            fecha2 = New DateTime(anio, mes, ultimoDiaDelMes).ToString("dd/MM/yyyy")

            ' Filtrar y obtener datos de obras usando las fechas calculadas
            Dim dtObras As DataTable = setDataObras(fecha1, fecha2, dr("Codigo").ToString())

            ' Agregar los resultados al DataTable final
            For Each obraRow As DataRow In dtObras.Rows
                ' Crear una nueva fila en dtResultados y agregarle los datos de obra
                Dim newRow As DataRow = dtResultados.NewRow()

                newRow("Codigo") = obraRow("Codigo")
                newRow("Obra") = obraRow("Obra")
                newRow("kg_planilla") = obraRow("kg_planilla")
                newRow("kg_bascula") = obraRow("kg_bascula")
                newRow("kg_produccion") = obraRow("kg_produccion")

                ' Agregar los datos calculados de DiaCierre, Fecha1 y Fecha2
                newRow("DiaCierre") = diaCierre
                newRow("Fecha1") = fecha1
                newRow("Fecha2") = fecha2

                ' Añadir la fila al DataTable final
                dtResultados.Rows.Add(newRow)
            Next
        Next
        Return dtResultados
    End Function

#End Region

#Region "Criterio 2"
    Public Sub CalculaCriterio2(ByVal fecha1 As String, ByVal fecha2 As String)
        Dim dtDatos As New DataTable
        dtDatos = setDataObras(fecha1, fecha2)
        Grid.DataSource = dtDatos
        Dim chatarraValue As Decimal
        If Decimal.TryParse(getChatarra(fecha1, fecha2), chatarraValue) Then
            txtChatarra.Text = chatarraValue.ToString("N2")
        End If
    End Sub
    
#End Region

#Region "Criterio 3"

    Public Sub CalculaCriterio3(ByVal mes1 As String, ByVal mes2 As String, ByVal año1 As String, ByVal año2 As String)
        Dim dtObras As New DataTable
        dtObras = getObrasMovimientos()
        Dim fecha As String = "01/" & mes1 & "/" & año1 & ""
        Dim dtNueva As DataTable = RellenaDiaFacturacion(dtObras, fecha)
        FiltraYNotifica(dtNueva)

        Dim dtFinal As New DataTable
        dtFinal = OpcionMesesProductivo(dtNueva, mes1, mes2, año1, año2)
        Grid.DataSource = dtFinal
        txtChatarra.Text = ""
    End Sub

    Public Function OpcionMesesProductivo(ByVal dtNueva As DataTable, ByVal mes1 As String, ByVal mes2 As String, ByVal año1 As String, ByVal año2 As String) As DataTable
        Dim fecha1 As String
        Dim fecha2 As String

        ' Crear un DataTable para almacenar los resultados finales
        Dim dtResultados As New DataTable
        dtResultados.Columns.Add("Codigo", GetType(String))
        dtResultados.Columns.Add("Obra", GetType(String))
        dtResultados.Columns.Add("kg_planilla", GetType(Double))
        dtResultados.Columns.Add("kg_bascula", GetType(Double))
        dtResultados.Columns.Add("kg_produccion", GetType(Double))
        ' Agregar nuevas columnas para DiaCierre, Fecha1 y Fecha2
        dtResultados.Columns.Add("DiaCierre", GetType(Integer))
        dtResultados.Columns.Add("Fecha1", GetType(String))
        dtResultados.Columns.Add("Fecha2", GetType(String))

        For Each dr As DataRow In dtNueva.Rows
            Dim diaCierre As Integer = Convert.ToInt32(dr("DiaCierre"))

            ' Calcular fecha2 (día de cierre del mes actual)
            Try
                fecha2 = New DateTime(año2, mes2, diaCierre).ToString("dd/MM/yyyy")
            Catch ex As Exception
                fecha2 = New DateTime(año2, mes2, diaCierre - 1).ToString("dd/MM/yyyy")
            End Try


            ' Calcular fecha1 (día siguiente al día de cierre del mes anterior)
            Dim fechaBase As DateTime

            Try
                ' Calcular fechaBase como el día siguiente al día de cierre del mes anterior
                fechaBase = New DateTime(año1, mes1, diaCierre + 1)
            Catch ex As ArgumentOutOfRangeException
                ' Si el día excede el número de días en el mes, asignar el primer día del mes siguiente
                fechaBase = New DateTime(año1, mes1, 1).AddMonths(1)
            End Try

            ' Formatear fechas
            fecha1 = fechaBase.ToString("dd/MM/yyyy")

            ' Filtrar y obtener datos de obras usando las fechas calculadas
            Dim dtObras As DataTable = setDataObras(fecha1, fecha2, dr("Codigo").ToString())

            ' Agregar los resultados al DataTable final
            For Each obraRow As DataRow In dtObras.Rows
                ' Crear una nueva fila en dtResultados y agregarle los datos de obra
                Dim newRow As DataRow = dtResultados.NewRow()

                newRow("Codigo") = obraRow("Codigo")
                newRow("Obra") = obraRow("Obra")
                newRow("kg_planilla") = obraRow("kg_planilla")
                newRow("kg_bascula") = obraRow("kg_bascula")
                newRow("kg_produccion") = obraRow("kg_produccion")

                ' Agregar los datos calculados de DiaCierre, Fecha1 y Fecha2
                newRow("DiaCierre") = diaCierre
                newRow("Fecha1") = fecha1
                newRow("Fecha2") = fecha2

                ' Añadir la fila al DataTable final
                dtResultados.Rows.Add(newRow)
            Next
        Next
        Return dtResultados
    End Function
#End Region

#Region "Getters"
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

    Public Function getObrasMovimientos()
        Dim dtObras As New DataTable
        Dim f As New Filter
        dtObras = New BE.DataEngine().Filter("vBasculasAcero", f, "Distinct(Codigo)")
        Return dtObras
    End Function
#End Region

#Region "Setters"

    Public Function RellenaDiaFacturacion(ByRef dtObras As DataTable, ByVal fecha As String) As DataTable
        Dim dtNueva As New DataTable
        dtNueva.Columns.Add("Codigo", GetType(String))
        dtNueva.Columns.Add("DiaCierre", GetType(String))

        Dim dt As New DataTable

        Dim obra As String
        For Each dr As DataRow In dtObras.Rows
            Dim f As New Filter
            obra = dr("Codigo").ToString
            f.Add("Codigo", FilterOperator.Equal, obra)
            f.Add("Fecha", FilterOperator.GreaterThanOrEqual, fecha)

            dt = New BE.DataEngine().Filter("vBasculasAcero", f)
            If dt.Rows.Count > 0 Then

                Dim dtObraCabecera As New DataTable
                Dim filtro As New Filter
                filtro.Add("NObra", FilterOperator.Equal, dr("Codigo").ToString)
                dtObraCabecera = New BE.DataEngine().Filter("tbObraCabecera", filtro, "DiaFacturacion")

                ' Añadir nueva fila a dtNueva
                Dim newRow As DataRow = dtNueva.NewRow()
                newRow("Codigo") = dr("Codigo").ToString
                newRow("DiaCierre") = dtObraCabecera.Rows(0)("DiaFacturacion").ToString
                dtNueva.Rows.Add(newRow)
            End If
        Next
        Return dtNueva
    End Function

    ' Modificación de setDataObras para incluir NObra
    Public Function setDataObras(ByVal fecha1 As String, ByVal fecha2 As String, ByVal NObra As String) As DataTable
        Dim sql As String
        sql = "SELECT Codigo, Obra, SUM(kg_planilla) AS kg_planilla, SUM(kg_produccion) AS kg_produccion, SUM(kg_bascula) AS kg_bascula "
        sql &= "FROM vBasculasAcero "
        sql &= "WHERE Fecha >= '" & fecha1 & "' AND Fecha <= '" & fecha2 & "' "
        sql &= "AND Codigo = '" & NObra & "' "
        sql &= "GROUP BY Codigo, Obra"

        Dim dt As DataTable = auxiliares.EjecutarSqlSelect(sql)

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
#End Region

#Region "Otros"
    ' Método que filtra las filas con valores vacíos y muestra un MessageBox
    Public Sub FiltraYNotifica(ByVal dtNueva As DataTable)
        Dim filasInvalidas As New List(Of String) ' Almacena los códigos de las filas que no tienen DiaCierre

        ' Iterar sobre cada fila y verificar si ambas columnas tienen valor
        For Each row As DataRow In dtNueva.Rows
            If String.IsNullOrEmpty(row("DiaCierre").ToString()) OrElse String.IsNullOrEmpty(row("Codigo").ToString()) Then
                ' Si el DiaCierre o Codigo están vacíos, agregarlos a la lista de notificación
                filasInvalidas.Add(row("Codigo").ToString())
            End If
        Next

        ' Si hay filas inválidas, mostrar un MessageBox con los códigos que faltan DiaCierre
        If filasInvalidas.Count > 0 Then
            Dim mensaje As String = "Los siguientes códigos no tienen día de cierre:" & vbCrLf & String.Join(vbCrLf, filasInvalidas.ToArray())
            MsgBox(mensaje, vbExclamation + vbOKOnly, "Información Importante")
        End If

        ' Eliminar filas con valores vacíos en las columnas
        For i As Integer = dtNueva.Rows.Count - 1 To 0 Step -1
            If String.IsNullOrEmpty(dtNueva.Rows(i)("DiaCierre").ToString()) OrElse String.IsNullOrEmpty(dtNueva.Rows(i)("Codigo").ToString()) Then
                dtNueva.Rows.RemoveAt(i)
            End If
        Next
    End Sub

    Public Sub cargaCombos()
        ' CMB MESES
        Dim dtMeses As New DataTable
        dtMeses.Columns.Add("Mes")
        For i As Integer = 1 To 12
            dtMeses.Rows.Add(New Object() {i})
        Next
        dtMeses.AcceptChanges()
        cmbMes.DataSource = dtMeses

        'CMB AÑOS
        Dim dtAnios As New DataTable
        dtAnios.Columns.Add("Año")
        Dim anio As Integer = Today.Year
        For i As Integer = anio To anio - 15 Step -1
            dtAnios.Rows.Add(New Object() {i})
        Next
        dtAnios.AcceptChanges()
        cmbAnio.DataSource = dtAnios

        ' CMB OPCIONES
        Dim dtOpciones As New DataTable
        dtOpciones.Columns.Add("Opcion")
        dtOpciones.Rows.Add("Mes productivo")
        dtOpciones.Rows.Add("Fin del mes")
        dtOpciones.Rows.Add("Inicio del mes")
        dtOpciones.AcceptChanges()
        cmbOpciones.DataSource = dtOpciones

        'COMBOS CRITERIO 3
        cbMes1C3.DataSource = dtMeses
        cbMes2C3.DataSource = dtMeses
        cbAño1c3.DataSource = dtAnios
        cbAño2c3.DataSource = dtAnios
    End Sub

    Private Sub cbMet1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMet1.CheckedChanged
        If cbMet1.Checked Then
            cbMet2.Checked = False
            cbMet3.Checked = False
        End If
    End Sub

    Private Sub cbMet2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMet2.CheckedChanged
        If cbMet2.Checked Then
            cbMet1.Checked = False
            cbMet3.Checked = False
        End If
    End Sub

    Private Sub cbMet3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMet3.CheckedChanged
        If cbMet3.Checked Then
            cbMet1.Checked = False
            cbMet2.Checked = False
        End If
    End Sub
#End Region
    

    
End Class