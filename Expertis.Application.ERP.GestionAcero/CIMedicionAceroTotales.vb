Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Engine.UI

Public Class CIMedicionAceroTotales
    Inherits Solmicro.Expertis.Engine.UI.CIMnto
    Public Sub New()
        MyBase.New()
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
    End Sub
    Private Sub CIMedicionAceroTotales_QueryExecuting(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles MyBase.QueryExecuting
        'e.Filter.Add("NObra", FilterOperator.Equal, advNObra.Text, FilterType.String)
        'If (cmbEstado.Text = "Proyectado") Then
        '    e.Filter.Add("Estado", FilterOperator.Equal, 0, FilterType.Numeric)
        'ElseIf (cmbEstado.Text = "Comenzado") Then
        '    e.Filter.Add("Estado", FilterOperator.Equal, 1, FilterType.Numeric)
        'ElseIf (cmbEstado.Text = "Terminado") Then
        '    e.Filter.Add("Estado", FilterOperator.Equal, 2, FilterType.Numeric)
        'End If
        'e.Filter.Add("Fecha", FilterOperator.GreaterThanOrEqual, clbFecha.Value, FilterType.DateTime)
        'e.Filter.Add("Fecha", FilterOperator.LessThanOrEqual, clbFecha1.Value, FilterType.DateTime)
    End Sub

    Private Sub CIMedicionAceroTotales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEstado.DataSource = New EnumData("enumocEstado")
        LoadToolbarActions()
    End Sub
    Public Function estructuraTabla() As DataTable
        Dim dt As New DataTable
        Dim dc As New DataColumn("Obra")
        dt.Columns.Add(dc)
        dc = New DataColumn("Fecha")
        dt.Columns.Add(dc)
        dc = New DataColumn("D8", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED8", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D10", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED10", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D12", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED12", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D16", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED16", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D20", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED20", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D25", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED25", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D32", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED32", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Transporte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ETransporte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Alambre", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("EAlambre", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Mallazo", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("EMallazo", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Porte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("EPorte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Celosia", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ECelosia", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Estado")
        dt.Columns.Add(dc)
        dc = New DataColumn("PesoPlanilla", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        Return dt
    End Function

    Public Sub rellenoTabla(ByVal dt As DataTable, ByVal obra As String, ByVal fechadesde As Date, ByVal fechahasta As Date, ByVal estado As String)
        'Dos opciones: 
        '- Para una obra especifica 
        '- Para todas las obras

        'Si es 0 = Para todas las obras
        If obra.ToString.Length = 0 Then
            Dim dtError As New DataTable
            dtError = estructuraTabla()
            Try
                Dim D8 As Double = 0.0
                Dim ED8 As Double = 0.0
                Dim D10 As Double = 0.0
                Dim ED10 As Double = 0.0
                Dim D12 As Double = 0.0
                Dim ED12 As Double = 0.0
                Dim D16 As Double = 0.0
                Dim ED16 As Double = 0.0
                Dim D20 As Double = 0.0
                Dim ED20 As Double = 0.0
                Dim D25 As Double = 0.0
                Dim ED25 As Double = 0.0
                Dim D32 As Double = 0.0
                Dim ED32 As Double = 0.0
                Dim Transporte As Double = 0.0
                Dim ETransporte As Double = 0.0
                Dim Alambre As Double = 0.0
                Dim EAlambre As Double = 0.0
                Dim Mallazo As Double = 0.0
                Dim EMallazo As Double = 0.0
                Dim Porte As Double = 0.0
                Dim EPorte As Double = 0.0
                Dim Celosia As Double = 0.0
                Dim ECelosia As Double = 0.0
                'Añadida la opcion de Albaran
                Dim PesoPlanilla As Double = 0.0

                Dim dtObra As New DataTable
                Dim filtro As New Filter

                Dim DE As New BE.DataEngine
                filtro.Add("Fecha", FilterOperator.GreaterThanOrEqual, fechadesde)
                filtro.Add("Fecha", FilterOperator.LessThanOrEqual, fechahasta)
                If estado.ToString.Length <> 0 Then
                    filtro.Add("Estado", FilterOperator.Equal, estado)
                Else

                End If

                'En esta tabla vienen todos los datos correspondiente a este NObra
                dtObra = DE.Filter("vMedicionAceroEstado", filtro, , "NObra")
                'Creo la fila que insertaré en la tabla
                Dim contador As Integer = 0
                'Recorro dtObra y si la fila siguiente es distinta a la que estoy(Por NObra) me haces el total y agrego la fila
                For Each fila As DataRow In dtObra.Rows
                    Dim dr As DataRow
                    D8 += dtObra.Rows(contador)("D8")
                    D10 += dtObra.Rows(contador)("D10")
                    D12 += dtObra.Rows(contador)("D12")
                    D16 += dtObra.Rows(contador)("D16")
                    D20 += dtObra.Rows(contador)("D20")
                    D25 += dtObra.Rows(contador)("D25")
                    D32 += dtObra.Rows(contador)("D32")
                    ED8 += dtObra.Rows(contador)("ED8")
                    ED10 += dtObra.Rows(contador)("ED10")
                    ED12 += dtObra.Rows(contador)("ED12")
                    ED16 += dtObra.Rows(contador)("ED16")
                    ED20 += dtObra.Rows(contador)("ED20")
                    ED25 += dtObra.Rows(contador)("ED25")
                    ED32 += dtObra.Rows(contador)("ED32")
                    '----
                    Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                    ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                    Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                    EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                    Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                    EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                    Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                    EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                    Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                    ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)

                    PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)
                    Try
                        If (dtObra.Rows(contador)("NObra") <> dtObra.Rows(contador + 1)("NObra")) Then
                            dr = dt.NewRow
                            dr("Obra") = dtObra.Rows(contador)("NObra")
                            dr("Fecha") = fechadesde & " - " & fechahasta
                            dr("D8") = D8
                            dr("ED8") = ED8
                            dr("D10") = D10
                            dr("ED10") = ED10
                            dr("D12") = D12
                            dr("ED12") = ED12
                            dr("D16") = D16
                            dr("ED16") = ED16
                            dr("D20") = D20
                            dr("ED20") = ED20
                            dr("D25") = D25
                            dr("ED25") = ED25
                            dr("D32") = D32
                            dr("ED32") = ED32
                            dr("Transporte") = Transporte
                            dr("ETransporte") = ETransporte
                            dr("Alambre") = Alambre
                            dr("EAlambre") = EAlambre
                            dr("Mallazo") = Mallazo
                            dr("EMallazo") = EMallazo
                            dr("Porte") = Porte
                            dr("EPorte") = EPorte
                            dr("Celosia") = Celosia
                            dr("ECelosia") = ECelosia
                            dr("Estado") = dtObra.Rows(contador)("Estado")
                            dr("PesoPlanilla") = PesoPlanilla
                            dt.Rows.Add(dr)
                            D8 = 0.0
                            ED8 = 0.0
                            D10 = 0.0
                            ED10 = 0.0
                            D12 = 0.0
                            ED12 = 0.0
                            D16 = 0.0
                            ED16 = 0.0
                            D20 = 0.0
                            ED20 = 0.0
                            D25 = 0.0
                            ED25 = 0.0
                            D32 = 0.0
                            ED32 = 0.0
                            Transporte = 0.0
                            ETransporte = 0.0
                            Alambre = 0.0
                            EAlambre = 0.0
                            Mallazo = 0.0
                            EMallazo = 0.0
                            Porte = 0.0
                            EPorte = 0.0
                            Celosia = 0.0
                            ECelosia = 0.0
                            PesoPlanilla = 0.0
                        Else

                        End If
                    Catch ex As Exception
                        dr = dt.NewRow
                        dr("Obra") = dtObra.Rows(contador)("NObra")
                        dr("Fecha") = fechadesde & " - " & fechahasta
                        dr("D8") = D8
                        dr("ED8") = ED8
                        dr("D10") = D10
                        dr("ED10") = ED10
                        dr("D12") = D12
                        dr("ED12") = ED12
                        dr("D16") = D16
                        dr("ED16") = ED16
                        dr("D20") = D20
                        dr("ED20") = ED20
                        dr("D25") = D25
                        dr("ED25") = ED25
                        dr("D32") = D32
                        dr("ED32") = ED32
                        dr("Transporte") = Transporte
                        dr("ETransporte") = ETransporte
                        dr("Alambre") = Alambre
                        dr("EAlambre") = EAlambre
                        dr("Mallazo") = Mallazo
                        dr("EMallazo") = EMallazo
                        dr("Porte") = Porte
                        dr("EPorte") = EPorte
                        dr("Celosia") = Celosia
                        dr("ECelosia") = ECelosia
                        dr("Estado") = dtObra.Rows(0)("Estado")
                        dr("PesoPlanilla") = PesoPlanilla
                        dt.Rows.Add(dr)
                    End Try
                    contador += 1
                Next
                filtro.Clear()
                Grid.DataSource = dt
                dt = Nothing
            Catch ex As Exception
                MsgBox(ex.ToString)
                Grid.DataSource = dtError
                MsgBox("No existe ningún registro con estas características")
            End Try
        Else
            'Creo todas las variables
            Dim dtError As New DataTable
            dtError = estructuraTabla()
            Try
                Dim D8 As Double = 0.0
                Dim ED8 As Double = 0.0
                Dim D10 As Double = 0.0
                Dim ED10 As Double = 0.0
                Dim D12 As Double = 0.0
                Dim ED12 As Double = 0.0
                Dim D16 As Double = 0.0
                Dim ED16 As Double = 0.0
                Dim D20 As Double = 0.0
                Dim ED20 As Double = 0.0
                Dim D25 As Double = 0.0
                Dim ED25 As Double = 0.0
                Dim D32 As Double = 0.0
                Dim ED32 As Double = 0.0
                Dim Transporte As Double = 0.0
                Dim ETransporte As Double = 0.0
                Dim Alambre As Double = 0.0
                Dim EAlambre As Double = 0.0
                Dim Mallazo As Double = 0.0
                Dim EMallazo As Double = 0.0
                Dim Porte As Double = 0.0
                Dim EPorte As Double = 0.0
                Dim Celosia As Double = 0.0
                Dim ECelosia As Double = 0.0
                Dim PesoPlanilla As Double = 0.0

                Dim dtObra As New DataTable
                Dim filtro As New Filter
                Dim DE As New BE.DataEngine
                filtro.Add("NObra", FilterOperator.Equal, obra)
                filtro.Add("Fecha", FilterOperator.GreaterThanOrEqual, fechadesde)
                filtro.Add("Fecha", FilterOperator.LessThanOrEqual, fechahasta)
                If estado.ToString.Length <> 0 Then
                    filtro.Add("Estado", FilterOperator.Equal, estado)
                Else
                End If
                'En esta tabla vienen todos los datos correspondiente a este NObra
                dtObra = DE.Filter("vMedicionAceroEstado", filtro)
                'Creo la fila que insertaré en la tabla
                Dim dr As DataRow
                dr = dt.NewRow
                'Le asigno el NObra
                dr("Obra") = dtObra.Rows(0)("NObra")
                'Le asgino la Fecha y saco la tabla con esas fechas
                dr("Fecha") = fechadesde & " - " & fechahasta
                'Obtengo todos los sumatorios de los campos
                Dim contador As Integer = 0

                For Each fila As DataRow In dtObra.Rows
                    D8 += dtObra.Rows(contador)("D8")
                    D10 += dtObra.Rows(contador)("D10")
                    D12 += dtObra.Rows(contador)("D12")
                    D16 += dtObra.Rows(contador)("D16")
                    D20 += dtObra.Rows(contador)("D20")
                    D25 += dtObra.Rows(contador)("D25")
                    D32 += dtObra.Rows(contador)("D32")
                    ED8 += dtObra.Rows(contador)("ED8")
                    ED10 += dtObra.Rows(contador)("ED10")
                    ED12 += dtObra.Rows(contador)("ED12")
                    ED16 += dtObra.Rows(contador)("ED16")
                    ED20 += dtObra.Rows(contador)("ED20")
                    ED25 += dtObra.Rows(contador)("ED25")
                    ED32 += dtObra.Rows(contador)("ED32")
                    '----
                    Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                    ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                    Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                    EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                    Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                    EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                    Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                    EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                    Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                    ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)
                    PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)
                    contador += 1
                Next
                dr("D8") = D8
                dr("ED8") = ED8
                dr("D10") = D10
                dr("ED10") = ED10
                dr("D12") = D12
                dr("ED12") = ED12
                dr("D16") = D16
                dr("ED16") = ED16
                dr("D20") = D20
                dr("ED20") = ED20
                dr("D25") = D25
                dr("ED25") = ED25
                dr("D32") = D32
                dr("ED32") = ED32

                dr("Transporte") = Transporte
                dr("ETransporte") = ETransporte
                dr("Alambre") = Alambre
                dr("EAlambre") = EAlambre
                dr("Mallazo") = Mallazo
                dr("EMallazo") = EMallazo
                dr("Porte") = Porte
                dr("EPorte") = EPorte
                dr("Celosia") = Celosia
                dr("ECelosia") = ECelosia
                dr("Estado") = dtObra.Rows(0)("Estado")
                dr("PesoPlanilla") = PesoPlanilla
                dt.Rows.Add(dr)
                filtro.Clear()

                Grid.DataSource = dt
                dt = Nothing
            Catch ex As Exception
                Grid.DataSource = dtError
                MsgBox("No existe ningún registro con estas características")
            End Try

        End If
    End Sub

    Public Sub creardt(ByVal obra As String, ByVal fechadesde As Date, ByVal fechahasta As Date, ByVal estado As String)
        'Creacion Estructura Tabla
        Dim dt As DataTable
        dt = estructuraTabla()
        'Relleno tabla
        rellenoTabla(dt, obra, fechadesde, fechahasta, estado)

    End Sub

    Private Sub CIMedicionAceroTotales_QueryExecuted(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutedEventArgs) Handles MyBase.QueryExecuted
        Dim obra As String
        Dim fechadesde As Date
        Dim fechahasta As Date
        Dim estado As String

        obra = Nz(advNObra.Text.ToString, "")
        fechadesde = Nz(clbFecha.Value.ToString, "01/01/2000")
        fechahasta = Nz(clbFecha1.Value.ToString, "31/12/2050")
        If (cmbEstado.Text = "Proyectado") Then
            estado = 0
        ElseIf (cmbEstado.Text = "Comenzado") Then
            estado = 1
        ElseIf (cmbEstado.Text = "Terminado") Then
            estado = 2
        Else
            estado = ""
        End If
        creardt(obra, fechadesde, fechahasta, estado)
    End Sub

    Private Sub LoadToolbarActions()
        Try
            With Me.FormActions
                .Add("Dividir por meses", AddressOf dividirPorMeses)
            End With
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub
    Private Sub dividirPorMeses()
        Dim obra As String
        Dim fechadesde As Date
        Dim fechahasta As Date
        Dim estado As String

        obra = Nz(advNObra.Text.ToString, "")
        fechadesde = Nz(clbFecha.Value.ToString, "01/01/2000")
        fechahasta = Nz(clbFecha1.Value.ToString, "31/12/2050")
        If (cmbEstado.Text = "Proyectado") Then
            estado = 0
        ElseIf (cmbEstado.Text = "Comenzado") Then
            estado = 1
        ElseIf (cmbEstado.Text = "Terminado") Then
            estado = 2
        Else
            estado = ""
        End If
        creardt2(obra, fechadesde, fechahasta, estado)
    End Sub
    Public Sub creardt2(ByVal obra As String, ByVal fechadesde As Date, ByVal fechahasta As Date, ByVal estado As String)
        'Creacion Estructura Tabla
        Dim dt As DataTable
        dt = estructuraTabla2()
        'Relleno tabla
        rellenoTabla2(dt, obra, fechadesde, fechahasta, estado)

    End Sub
    Public Sub rellenoTabla2(ByVal dt As DataTable, ByVal obra As String, ByVal fechadesde As Date, ByVal fechahasta As Date, ByVal estado As String)
        Dim dtError As New DataTable
        dtError = estructuraTabla2()
        Try
            Dim D8 As Double = 0.0
            Dim ED8 As Double = 0.0
            Dim D10 As Double = 0.0
            Dim ED10 As Double = 0.0
            Dim D12 As Double = 0.0
            Dim ED12 As Double = 0.0
            Dim D16 As Double = 0.0
            Dim ED16 As Double = 0.0
            Dim D20 As Double = 0.0
            Dim ED20 As Double = 0.0
            Dim D25 As Double = 0.0
            Dim ED25 As Double = 0.0
            Dim D32 As Double = 0.0
            Dim ED32 As Double = 0.0
            Dim Transporte As Double = 0.0
            Dim ETransporte As Double = 0.0
            Dim Alambre As Double = 0.0
            Dim EAlambre As Double = 0.0
            Dim Mallazo As Double = 0.0
            Dim EMallazo As Double = 0.0
            Dim Porte As Double = 0.0
            Dim EPorte As Double = 0.0
            Dim Celosia As Double = 0.0
            Dim ECelosia As Double = 0.0
            Dim PesoPlanilla As Double = 0.0


            If obra.ToString.Length = 0 Then

                Dim dtObra As New DataTable
                Dim filtro As New Filter
                Dim DE As New BE.DataEngine
                filtro.Add("Estado", FilterOperator.Equal, estado)
                filtro.Add("Fecha", FilterOperator.GreaterThanOrEqual, fechadesde)
                filtro.Add("Fecha", FilterOperator.LessThanOrEqual, fechahasta)
                'En esta tabla vienen todos los datos correspondiente a este NObra
                dtObra = DE.Filter("vMedicionAceroEstado", filtro, , "NObra, Fecha asc")
                Dim dr As DataRow
                Dim contador As Integer = 0
                For Each fila As DataRow In dtObra.Rows
                    Try
                        If dtObra.Rows(contador)("NObra").ToString <> dtObra.Rows(contador + 1)("NObra").ToString Then
                            D8 += dtObra.Rows(contador)("D8")
                            D10 += dtObra.Rows(contador)("D10")
                            D12 += dtObra.Rows(contador)("D12")
                            D16 += dtObra.Rows(contador)("D16")
                            D20 += dtObra.Rows(contador)("D20")
                            D25 += dtObra.Rows(contador)("D25")
                            D32 += dtObra.Rows(contador)("D32")
                            ED8 += dtObra.Rows(contador)("ED8")
                            ED10 += dtObra.Rows(contador)("ED10")
                            ED12 += dtObra.Rows(contador)("ED12")
                            ED16 += dtObra.Rows(contador)("ED16")
                            ED20 += dtObra.Rows(contador)("ED20")
                            ED25 += dtObra.Rows(contador)("ED25")
                            ED32 += dtObra.Rows(contador)("ED32")
                            '----
                            Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                            ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                            Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                            EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                            Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                            EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                            Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                            EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                            Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                            ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)
                            PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)

                            dr = dt.NewRow
                            dr("Obra") = dtObra.Rows(contador)("NObra")
                            If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                                dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                            Else
                                dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                            End If

                            dr("D8") = D8
                            dr("ED8") = ED8
                            dr("D10") = D10
                            dr("ED10") = ED10
                            dr("D12") = D12
                            dr("ED12") = ED12
                            dr("D16") = D16
                            dr("ED16") = ED16
                            dr("D20") = D20
                            dr("ED20") = ED20
                            dr("D25") = D25
                            dr("ED25") = ED25
                            dr("D32") = D32
                            dr("ED32") = ED32
                            dr("Transporte") = Transporte
                            dr("ETransporte") = ETransporte
                            dr("Alambre") = Alambre
                            dr("EAlambre") = EAlambre
                            dr("Mallazo") = Mallazo
                            dr("EMallazo") = EMallazo
                            dr("Porte") = Porte
                            dr("EPorte") = EPorte
                            dr("Celosia") = Celosia
                            dr("ECelosia") = ECelosia
                            dr("Estado") = estado
                            dr("PesoPlanilla") = PesoPlanilla
                            dt.Rows.Add(dr)
                            D8 = 0.0
                            ED8 = 0.0
                            D10 = 0.0
                            ED10 = 0.0
                            D12 = 0.0
                            ED12 = 0.0
                            D16 = 0.0
                            ED16 = 0.0
                            D20 = 0.0
                            ED20 = 0.0
                            D25 = 0.0
                            ED25 = 0.0
                            D32 = 0.0
                            ED32 = 0.0
                            Transporte = 0.0
                            ETransporte = 0.0
                            Alambre = 0.0
                            EAlambre = 0.0
                            Mallazo = 0.0
                            EMallazo = 0.0
                            Porte = 0.0
                            EPorte = 0.0
                            Celosia = 0.0
                            ECelosia = 0.0
                            PesoPlanilla = 0.0
                            contador += 1
                            Continue For
                            Try
                                If (dtObra.Rows(contador)("Mes") <> dtObra.Rows(contador + 1)("Mes") And dtObra.Rows(contador)("Año").ToString <> dtObra.Rows(contador + 1)("Año").ToString) Then
                                    dr("Obra") = dtObra.Rows(contador)("NObra")
                                    If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                                        dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                    Else
                                        dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                    End If

                                    dr("D8") = D8
                                    dr("ED8") = ED8
                                    dr("D10") = D10
                                    dr("ED10") = ED10
                                    dr("D12") = D12
                                    dr("ED12") = ED12
                                    dr("D16") = D16
                                    dr("ED16") = ED16
                                    dr("D20") = D20
                                    dr("ED20") = ED20
                                    dr("D25") = D25
                                    dr("ED25") = ED25
                                    dr("D32") = D32
                                    dr("ED32") = ED32
                                    dr("Transporte") = Transporte
                                    dr("ETransporte") = ETransporte
                                    dr("Alambre") = Alambre
                                    dr("EAlambre") = EAlambre
                                    dr("Mallazo") = Mallazo
                                    dr("EMallazo") = EMallazo
                                    dr("Porte") = Porte
                                    dr("EPorte") = EPorte
                                    dr("Celosia") = Celosia
                                    dr("ECelosia") = ECelosia
                                    dr("Estado") = estado
                                    dr("PesoPlanilla") = PesoPlanilla
                                    dt.Rows.Add(dr)
                                    D8 = 0.0
                                    ED8 = 0.0
                                    D10 = 0.0
                                    ED10 = 0.0
                                    D12 = 0.0
                                    ED12 = 0.0
                                    D16 = 0.0
                                    ED16 = 0.0
                                    D20 = 0.0
                                    ED20 = 0.0
                                    D25 = 0.0
                                    ED25 = 0.0
                                    D32 = 0.0
                                    ED32 = 0.0
                                    Transporte = 0.0
                                    ETransporte = 0.0
                                    Alambre = 0.0
                                    EAlambre = 0.0
                                    Mallazo = 0.0
                                    EMallazo = 0.0
                                    Porte = 0.0
                                    EPorte = 0.0
                                    Celosia = 0.0
                                    ECelosia = 0.0
                                    PesoPlanilla = 0.0
                                Else
                                    D8 += dtObra.Rows(contador)("D8")
                                    D10 += dtObra.Rows(contador)("D10")
                                    D12 += dtObra.Rows(contador)("D12")
                                    D16 += dtObra.Rows(contador)("D16")
                                    D20 += dtObra.Rows(contador)("D20")
                                    D25 += dtObra.Rows(contador)("D25")
                                    D32 += dtObra.Rows(contador)("D32")
                                    ED8 += dtObra.Rows(contador)("ED8")
                                    ED10 += dtObra.Rows(contador)("ED10")
                                    ED12 += dtObra.Rows(contador)("ED12")
                                    ED16 += dtObra.Rows(contador)("ED16")
                                    ED20 += dtObra.Rows(contador)("ED20")
                                    ED25 += dtObra.Rows(contador)("ED25")
                                    ED32 += dtObra.Rows(contador)("ED32")
                                    '----
                                    Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                                    ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                                    Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                                    EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                                    Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                                    EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                                    Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                                    EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                                    Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                                    ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)
                                    PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)
                                End If
                            Catch ex As Exception
                                dr = dt.NewRow
                                dr("Obra") = dtObra.Rows(contador)("NObra")
                                If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                                    dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                Else
                                    dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                End If
                                dr("D8") = D8
                                dr("ED8") = ED8
                                dr("D10") = D10
                                dr("ED10") = ED10
                                dr("D12") = D12
                                dr("ED12") = ED12
                                dr("D16") = D16
                                dr("ED16") = ED16
                                dr("D20") = D20
                                dr("ED20") = ED20
                                dr("D25") = D25
                                dr("ED25") = ED25
                                dr("D32") = D32
                                dr("ED32") = ED32
                                dr("Transporte") = Transporte
                                dr("ETransporte") = ETransporte
                                dr("Alambre") = Alambre
                                dr("EAlambre") = EAlambre
                                dr("Mallazo") = Mallazo
                                dr("EMallazo") = EMallazo
                                dr("Porte") = Porte
                                dr("EPorte") = EPorte
                                dr("Celosia") = Celosia
                                dr("ECelosia") = ECelosia
                                dr("Estado") = estado
                                dr("PesoPlanilla") = PesoPlanilla
                                dt.Rows.Add(dr)
                                D8 = 0.0
                                ED8 = 0.0
                                D10 = 0.0
                                ED10 = 0.0
                                D12 = 0.0
                                ED12 = 0.0
                                D16 = 0.0
                                ED16 = 0.0
                                D20 = 0.0
                                ED20 = 0.0
                                D25 = 0.0
                                ED25 = 0.0
                                D32 = 0.0
                                ED32 = 0.0
                                Transporte = 0.0
                                ETransporte = 0.0
                                Alambre = 0.0
                                EAlambre = 0.0
                                Mallazo = 0.0
                                EMallazo = 0.0
                                Porte = 0.0
                                EPorte = 0.0
                                Celosia = 0.0
                                ECelosia = 0.0
                                PesoPlanilla = 0.0
                            End Try

                        Else
                            Try
                                If (dtObra.Rows(contador)("Mes") <> dtObra.Rows(contador + 1)("Mes")) Then
                                    dr = dt.NewRow
                                    dr("Obra") = dtObra.Rows(contador)("NObra")
                                    If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                                        dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                    Else
                                        dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                    End If
                                    D8 += dtObra.Rows(contador)("D8")
                                    D10 += dtObra.Rows(contador)("D10")
                                    D12 += dtObra.Rows(contador)("D12")
                                    D16 += dtObra.Rows(contador)("D16")
                                    D20 += dtObra.Rows(contador)("D20")
                                    D25 += dtObra.Rows(contador)("D25")
                                    D32 += dtObra.Rows(contador)("D32")
                                    ED8 += dtObra.Rows(contador)("ED8")
                                    ED10 += dtObra.Rows(contador)("ED10")
                                    ED12 += dtObra.Rows(contador)("ED12")
                                    ED16 += dtObra.Rows(contador)("ED16")
                                    ED20 += dtObra.Rows(contador)("ED20")
                                    ED25 += dtObra.Rows(contador)("ED25")
                                    ED32 += dtObra.Rows(contador)("ED32")
                                    Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                                    ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                                    Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                                    EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                                    Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                                    EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                                    Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                                    EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                                    Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                                    ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)
                                    PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)

                                    dr("D8") = D8
                                    dr("ED8") = ED8
                                    dr("D10") = D10
                                    dr("ED10") = ED10
                                    dr("D12") = D12
                                    dr("ED12") = ED12
                                    dr("D16") = D16
                                    dr("ED16") = ED16
                                    dr("D20") = D20
                                    dr("ED20") = ED20
                                    dr("D25") = D25
                                    dr("ED25") = ED25
                                    dr("D32") = D32
                                    dr("ED32") = ED32
                                    dr("Transporte") = Transporte
                                    dr("ETransporte") = ETransporte
                                    dr("Alambre") = Alambre
                                    dr("EAlambre") = EAlambre
                                    dr("Mallazo") = Mallazo
                                    dr("EMallazo") = EMallazo
                                    dr("Porte") = Porte
                                    dr("EPorte") = EPorte
                                    dr("Celosia") = Celosia
                                    dr("ECelosia") = ECelosia
                                    dr("Estado") = estado
                                    dr("PesoPlanilla") = PesoPlanilla
                                    dt.Rows.Add(dr)
                                    D8 = 0.0
                                    ED8 = 0.0
                                    D10 = 0.0
                                    ED10 = 0.0
                                    D12 = 0.0
                                    ED12 = 0.0
                                    D16 = 0.0
                                    ED16 = 0.0
                                    D20 = 0.0
                                    ED20 = 0.0
                                    D25 = 0.0
                                    ED25 = 0.0
                                    D32 = 0.0
                                    ED32 = 0.0
                                    Transporte = 0.0
                                    ETransporte = 0.0
                                    Alambre = 0.0
                                    EAlambre = 0.0
                                    Mallazo = 0.0
                                    EMallazo = 0.0
                                    Porte = 0.0
                                    EPorte = 0.0
                                    Celosia = 0.0
                                    ECelosia = 0.0
                                    PesoPlanilla = 0.0
                                Else
                                    D8 += dtObra.Rows(contador)("D8")
                                    D10 += dtObra.Rows(contador)("D10")
                                    D12 += dtObra.Rows(contador)("D12")
                                    D16 += dtObra.Rows(contador)("D16")
                                    D20 += dtObra.Rows(contador)("D20")
                                    D25 += dtObra.Rows(contador)("D25")
                                    D32 += dtObra.Rows(contador)("D32")
                                    ED8 += dtObra.Rows(contador)("ED8")
                                    ED10 += dtObra.Rows(contador)("ED10")
                                    ED12 += dtObra.Rows(contador)("ED12")
                                    ED16 += dtObra.Rows(contador)("ED16")
                                    ED20 += dtObra.Rows(contador)("ED20")
                                    ED25 += dtObra.Rows(contador)("ED25")
                                    ED32 += dtObra.Rows(contador)("ED32")
                                    '----
                                    Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                                    ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                                    Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                                    EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                                    Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                                    EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                                    Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                                    EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                                    Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                                    ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)
                                    PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)

                                End If
                            Catch ex As Exception
                                dr = dt.NewRow
                                dr("Obra") = dtObra.Rows(contador)("NObra")
                                If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                                    dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                Else
                                    dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                                End If
                                dr("D8") = D8
                                dr("ED8") = ED8
                                dr("D10") = D10
                                dr("ED10") = ED10
                                dr("D12") = D12
                                dr("ED12") = ED12
                                dr("D16") = D16
                                dr("ED16") = ED16
                                dr("D20") = D20
                                dr("ED20") = ED20
                                dr("D25") = D25
                                dr("ED25") = ED25
                                dr("D32") = D32
                                dr("ED32") = ED32
                                dr("Transporte") = Transporte
                                dr("ETransporte") = ETransporte
                                dr("Alambre") = Alambre
                                dr("EAlambre") = EAlambre
                                dr("Mallazo") = Mallazo
                                dr("EMallazo") = EMallazo
                                dr("Porte") = Porte
                                dr("EPorte") = EPorte
                                dr("Celosia") = Celosia
                                dr("ECelosia") = ECelosia
                                dr("Estado") = estado
                                dr("PesoPlanilla") = PesoPlanilla
                                dt.Rows.Add(dr)
                                D8 = 0.0
                                ED8 = 0.0
                                D10 = 0.0
                                ED10 = 0.0
                                D12 = 0.0
                                ED12 = 0.0
                                D16 = 0.0
                                ED16 = 0.0
                                D20 = 0.0
                                ED20 = 0.0
                                D25 = 0.0
                                ED25 = 0.0
                                D32 = 0.0
                                ED32 = 0.0
                                Transporte = 0.0
                                ETransporte = 0.0
                                Alambre = 0.0
                                EAlambre = 0.0
                                Mallazo = 0.0
                                EMallazo = 0.0
                                Porte = 0.0
                                EPorte = 0.0
                                Celosia = 0.0
                                ECelosia = 0.0
                                PesoPlanilla = 0.0
                            End Try
                        End If
                    Catch ex As Exception
                        D8 += dtObra.Rows(contador)("D8")
                        D10 += dtObra.Rows(contador)("D10")
                        D12 += dtObra.Rows(contador)("D12")
                        D16 += dtObra.Rows(contador)("D16")
                        D20 += dtObra.Rows(contador)("D20")
                        D25 += dtObra.Rows(contador)("D25")
                        D32 += dtObra.Rows(contador)("D32")
                        ED8 += dtObra.Rows(contador)("ED8")
                        ED10 += dtObra.Rows(contador)("ED10")
                        ED12 += dtObra.Rows(contador)("ED12")
                        ED16 += dtObra.Rows(contador)("ED16")
                        ED20 += dtObra.Rows(contador)("ED20")
                        ED25 += dtObra.Rows(contador)("ED25")
                        ED32 += dtObra.Rows(contador)("ED32")
                        '----
                        Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                        ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                        Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                        EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                        Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                        EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                        Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                        EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                        Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                        ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)
                        PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)
                        dr = dt.NewRow
                        dr("Obra") = dtObra.Rows(contador)("NObra")
                        If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                            dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                        Else
                            dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                        End If
                        dr("D8") = D8
                        dr("ED8") = ED8
                        dr("D10") = D10
                        dr("ED10") = ED10
                        dr("D12") = D12
                        dr("ED12") = ED12
                        dr("D16") = D16
                        dr("ED16") = ED16
                        dr("D20") = D20
                        dr("ED20") = ED20
                        dr("D25") = D25
                        dr("ED25") = ED25
                        dr("D32") = D32
                        dr("ED32") = ED32
                        dr("Transporte") = Transporte
                        dr("ETransporte") = ETransporte
                        dr("Alambre") = Alambre
                        dr("EAlambre") = EAlambre
                        dr("Mallazo") = Mallazo
                        dr("EMallazo") = EMallazo
                        dr("Porte") = Porte
                        dr("EPorte") = EPorte
                        dr("Celosia") = Celosia
                        dr("ECelosia") = ECelosia
                        dr("Estado") = estado
                        dr("PesoPlanilla") = PesoPlanilla
                        dt.Rows.Add(dr)
                    End Try
                    contador += 1
                Next
                filtro.Clear()
                Grid.DataSource = dt
                dt = Nothing
            Else
                Dim dtObra As New DataTable
                Dim filtro As New Filter
                Dim DE As New BE.DataEngine
                filtro.Add("NObra", FilterOperator.Equal, obra)
                filtro.Add("Estado", FilterOperator.Equal, estado)
                filtro.Add("Fecha", FilterOperator.GreaterThanOrEqual, fechadesde)
                filtro.Add("Fecha", FilterOperator.LessThanOrEqual, fechahasta)
                'En esta tabla vienen todos los datos correspondiente a este NObra
                dtObra = DE.Filter("vMedicionAceroEstado", filtro, , "Fecha asc")
                'Creo la fila que insertaré en la tabla
                Dim dr As DataRow
                'Obtengo todos los sumatorios de los campos
                Dim contador As Integer = 0

                For Each fila As DataRow In dtObra.Rows
                    dr = dt.NewRow
                    dr("Obra") = dtObra.Rows(0)("NObra")

                    Try
                        If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                            dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                        Else
                            dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                        End If
                    Catch ex As Exception
                        MsgBox("ERROR EN LA OBRA " & dr("Obra") & ". Falta el mes y año en una linea.")
                        Exit Sub
                    End Try
                    
                    D8 += dtObra.Rows(contador)("D8")
                    D10 += dtObra.Rows(contador)("D10")
                    D12 += dtObra.Rows(contador)("D12")
                    D16 += dtObra.Rows(contador)("D16")
                    D20 += dtObra.Rows(contador)("D20")
                    D25 += dtObra.Rows(contador)("D25")
                    D32 += dtObra.Rows(contador)("D32")
                    ED8 += dtObra.Rows(contador)("ED8")
                    ED10 += dtObra.Rows(contador)("ED10")
                    ED12 += dtObra.Rows(contador)("ED12")
                    ED16 += dtObra.Rows(contador)("ED16")
                    ED20 += dtObra.Rows(contador)("ED20")
                    ED25 += dtObra.Rows(contador)("ED25")
                    ED32 += dtObra.Rows(contador)("ED32")
                    '----
                    Transporte += Nz(dtObra.Rows(contador)("Transporte"), 0)
                    ETransporte += Nz(dtObra.Rows(contador)("ETransporte"), 0)
                    Alambre += Nz(dtObra.Rows(contador)("Alambre"), 0)
                    EAlambre += Nz(dtObra.Rows(contador)("EAlambre"), 0)
                    Mallazo += Nz(dtObra.Rows(contador)("Mallazo"), 0)
                    EMallazo += Nz(dtObra.Rows(contador)("EMallazo"), 0)
                    Porte += Nz(dtObra.Rows(contador)("Porte"), 0)
                    EPorte += Nz(dtObra.Rows(contador)("EPorte"), 0)
                    Celosia += Nz(dtObra.Rows(contador)("Celosia"), 0)
                    ECelosia += Nz(dtObra.Rows(contador)("ECelosia"), 0)
                    PesoPlanilla += Nz(dtObra.Rows(contador)("PesoPlanilla"), 0)
                    Try
                        If (dtObra.Rows(contador)("Mes") <> dtObra.Rows(contador + 1)("Mes")) Then
                            dr("D8") = D8
                            dr("ED8") = ED8
                            dr("D10") = D10
                            dr("ED10") = ED10
                            dr("D12") = D12
                            dr("ED12") = ED12
                            dr("D16") = D16
                            dr("ED16") = ED16
                            dr("D20") = D20
                            dr("ED20") = ED20
                            dr("D25") = D25
                            dr("ED25") = ED25
                            dr("D32") = D32
                            dr("ED32") = ED32
                            dr("Transporte") = Transporte
                            dr("ETransporte") = ETransporte
                            dr("Alambre") = Alambre
                            dr("EAlambre") = EAlambre
                            dr("Mallazo") = Mallazo
                            dr("EMallazo") = EMallazo
                            dr("Porte") = Porte
                            dr("EPorte") = EPorte
                            dr("Celosia") = Celosia
                            dr("ECelosia") = ECelosia
                            dr("Estado") = estado
                            dr("PesoPlanilla") = PesoPlanilla
                            dt.Rows.Add(dr)
                            D8 = 0.0
                            ED8 = 0.0
                            D10 = 0.0
                            ED10 = 0.0
                            D12 = 0.0
                            ED12 = 0.0
                            D16 = 0.0
                            ED16 = 0.0
                            D20 = 0.0
                            ED20 = 0.0
                            D25 = 0.0
                            ED25 = 0.0
                            D32 = 0.0
                            ED32 = 0.0
                            Transporte = 0.0
                            ETransporte = 0.0
                            Alambre = 0.0
                            EAlambre = 0.0
                            Mallazo = 0.0
                            EMallazo = 0.0
                            Porte = 0.0
                            EPorte = 0.0
                            Celosia = 0.0
                            ECelosia = 0.0
                            PesoPlanilla = 0.0
                        End If

                    Catch ex As Exception
                        dr = dt.NewRow
                        dr("Obra") = dtObra.Rows(contador)("NObra")
                        If dtObra.Rows(contador)("Mes") = 1 Or dtObra.Rows(contador)("Mes") = 2 Or dtObra.Rows(contador)("Mes") = 3 Or dtObra.Rows(contador)("Mes") = 4 Or dtObra.Rows(contador)("Mes") = 5 Or dtObra.Rows(contador)("Mes") = 6 Or dtObra.Rows(contador)("Mes") = 7 Or dtObra.Rows(contador)("Mes") = 8 Or dtObra.Rows(contador)("Mes") = 9 Then
                            dr("Fecha") = "01/0" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                        Else
                            dr("Fecha") = "01/" & dtObra.Rows(contador)("Mes") & "/" & dtObra.Rows(contador)("Año")
                        End If
                        dr("D8") = D8
                        dr("ED8") = ED8
                        dr("D10") = D10
                        dr("ED10") = ED10
                        dr("D12") = D12
                        dr("ED12") = ED12
                        dr("D16") = D16
                        dr("ED16") = ED16
                        dr("D20") = D20
                        dr("ED20") = ED20
                        dr("D25") = D25
                        dr("ED25") = ED25
                        dr("D32") = D32
                        dr("ED32") = ED32
                        dr("Transporte") = Transporte
                        dr("ETransporte") = ETransporte
                        dr("Alambre") = Alambre
                        dr("EAlambre") = EAlambre
                        dr("Mallazo") = Mallazo
                        dr("EMallazo") = EMallazo
                        dr("Porte") = Porte
                        dr("EPorte") = EPorte
                        dr("Celosia") = Celosia
                        dr("ECelosia") = ECelosia
                        dr("Estado") = estado
                        dr("PesoPlanilla") = PesoPlanilla
                        dt.Rows.Add(dr)
                    End Try

                    contador += 1
                Next
                filtro.Clear()
                Grid.DataSource = dt
                dt = Nothing
            End If 
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function estructuraTabla2() As DataTable
        Dim dt As New DataTable
        Dim dc As New DataColumn("Obra")
        dt.Columns.Add(dc)
        dc = New DataColumn("Fecha", System.Type.GetType("System.DateTime"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D8", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED8", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D10", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED10", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D12", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED12", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D16", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED16", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D20", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED20", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D25", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED25", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("D32", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ED32", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Transporte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ETransporte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Alambre", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("EAlambre", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Mallazo", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("EMallazo", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Porte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("EPorte", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Celosia", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("ECelosia", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Estado")
        dt.Columns.Add(dc)
        dc = New DataColumn("PesoPlanilla", System.Type.GetType("System.Double"))
        dt.Columns.Add(dc)
        Return dt
    End Function
End Class