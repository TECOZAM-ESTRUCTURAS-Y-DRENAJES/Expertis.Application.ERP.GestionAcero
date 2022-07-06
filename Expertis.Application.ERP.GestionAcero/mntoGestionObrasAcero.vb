Imports Janus.Windows.GridEX
Imports Solmicro.Expertis.Engine.Global
Imports Solmicro.Expertis.Engine.DAL
Imports System.Windows.Forms
Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Business.Obra
Imports Solmicro.Expertis.Business.Negocio
Imports Solmicro.Expertis.Engine.UI
Imports Solmicro.Expertis.Business.ClasesTecozam
Imports Microsoft.Office
Imports Microsoft.Office.Interop

Public Class MntoGestionObrasAcero
    Inherits Solmicro.Expertis.Engine.UI.SimpleMnto

    Private Const cnCOPIARLINEA As String = "Copiar Linea"

    Dim lngCertLiberada As Integer
    Dim serror As String = ""
    Dim pIVA As Decimal '= 0.16
    Dim strIVA As String
    Dim pRetencion As Decimal = 0.05
    Public mstrIDCGestion As String


#Region " Load "

    Private Sub MntoGestionObrasAcero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        With GridCertificaciones
            Me.FormActions.Add("Importar Albaran por Excel - GRAPHICO - ", AddressOf ImportarAlbaran)
            Me.AddSeparator()
            Me.FormActions.Add("Abrir Factura", AddressOf AbrirFactura)
            Me.FormActions.Add("Abrir Obra", AddressOf AbrirObra)
        End With

        With GridMediciones
            Me.AddSeparator()
            Me.FormActions.Add("Bloquear Grid", AddressOf BloquearGridMediciones)
            Me.FormActions.Add("DesBloquear Grid", AddressOf DesbloquearGridMediciones)
            Me.AddSeparator()
            Me.FormActions.Add("Columna Certificar // Marcar Todos", AddressOf CertificarMarcarTodos)
            Me.FormActions.Add("Columna Certificar // Desmarcar Todos", AddressOf CertificarDesmarcarTodos)
            Me.AddSeparator()
            Me.FormActions.Add("Copiar Medición", AddressOf CopiarMedicion)
        End With

        ComboBox3.DataSource = New EnumData("enumocEstado")
        ComboBox4.DataSource = New EnumData("enumTipoRetencion")

        LoadToolbarActions()
        ComprobarMediosElev()

        'mstrIDCGestion = New UsuarioCentroGestion().CentroGestionUsuario
        'David Velasco 30/11 está mal
        Dim obj As New UsuarioCentroGestion.UsuarioCentroGestionInfo
        mstrIDCGestion = obj.IDCentroGestion
        'David Velasco
        TextBox4.Enabled = False
        With GridMediciones
            .Actions.Add(cnCOPIARLINEA, AddressOf CopiarMedicion, ExpertisApp.GetIcon("xConceptos.ico"))
        End With
        'cambiaNombreColumnasOcultas()
    End Sub

    Private Sub MntoGestionObrasAcero_RecordAdding(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.RecordAdding
        Try
            Engine.UI.ExpertisApp.GenerateMessage("No esta permitido en esta pantalla dar de alta registros", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            e.Cancel = True
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub MntoGestionObrasAcero_RecordDeleting(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.RecordDeleting
        Try
            Engine.UI.ExpertisApp.GenerateMessage("No está permitido en esta pantalla borrar registros", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            e.Cancel = True
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub LoadToolbarActions()
        Try
            With Me.FormActions
                .Add("Recalcular Importes", AddressOf AccionRecalcularObra)
                Me.AddSeparator()
                .Add("Certificar", AddressOf AccionCertificar)
                .Add("Facturar Certificación", AddressOf AccionFacturarCertificacion)
                Me.AddSeparator()
                .Add("Anular Ultima Certificación", AddressOf AccionAnularCertificar)
                .Add("Desbloquear Mediciones Certificadas", AddressOf AccionLiberarCertificacion)
                .Add("Recalcular Certificación", AddressOf AccionRecalcularCertificacion)
                Me.AddSeparator()
                .Add("Bloquear Certificación", AddressOf AccionBloquearCertificacion)
                .Add("Desbloquear Certificación", AddressOf AccionDesbloquearCertificacion)
                Me.AddSeparator()
                .Add("Asignar Precios", AddressOf AccionAsignarPrecios)
                Me.AddSeparator()
                .Add("Asignar Precios Diámetros", AddressOf AccionAsignarPreciosDiametros)
                .Add("Facturación por Diámetros", AddressOf AccionFacturaDiametros)
                Me.AddSeparator()
                .Add("Exportar Mediciones", AddressOf AccionExportarMediciones)
                Me.AddSeparator()
                .Add("Generar Albarán de Venta - Grafogest", AddressOf AccionAlbaranGrafojex)
                Me.AddSeparator()
                .Add("Informe Mediciones Acero", AddressOf AccionInformeAcero)
                .Add("Imprimir Ficha Certificación", AddressOf AccionFichaCertificacion)
                .Add("Albarán Mallazo y Alambre", AddressOf AccionInformeMallazo)
                Me.AddSeparator()
                .Add("Generar Orden de Trabajo", AddressOf AccionOrdenTrabajo)
                .Add("Introducir Medición Albaran/Colada/Paquete", AddressOf AccionAddProduccion)
                Me.AddSeparator()
                '.Add("Exportar Grid a Excel", AddressOf ExportarGridaExcel)
            End With

        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region " Calculos GridMediciones "

    Private Sub BloquearGridMediciones()
        Try
            With GridMediciones
                .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                .AllowDrop = False

                .Refresh()
            End With

            txtBloqueado.Text = 1
            txtDescObra.Focus()
            Me.UpdateData()

        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub DesbloquearGridMediciones()
        Try
            With GridMediciones
                .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                .AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                .AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                .AllowDrop = False

                .Refresh()
            End With

            txtBloqueado.Text = 0
            txtDescObra.Focus()
            Me.UpdateData()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub calculartotales()
        'Dim blnRefresh As Boolean
        'Dim dblAlambre, dblPlanilla, dblSuministrado, dblMontado, dblMedios, dblImpVencimientoA As Double
        'Dim dblPProduccion, dblBascula As Double

        Try
            With GridMediciones
                txtTotalBascula.Value = .GetTotal(.Columns("PesoBascula"), AggregateFunction.Sum)
                txtTotalAlambre.Value = .GetTotal(.Columns("Alambre"), AggregateFunction.Sum)
                txtPProduccion.Value = .GetTotal(.Columns("Planilla"), AggregateFunction.Sum)
                txtTotalPlanilla.Value = .GetTotal(.Columns("PesoPlanilla"), AggregateFunction.Sum)
                txtTotalMontado.Value = .GetTotal(.Columns("TotalMontaje"), AggregateFunction.Sum)
                txtTotalMedios.Value = .GetTotal(.Columns("TotalMediosE"), AggregateFunction.Sum)
                txtTotalSuministrado.Value = .GetTotal(.Columns("CertificadoSuministro"), AggregateFunction.Sum)
            End With


            '    TotalImporteMediciones("vFrmObraTotalMedicionesAcero", dblAlambre, dblPlanilla, dblSuministrado, dblMontado, dblMedios, dblPProduccion, dblBascula, Me.CurrentRow("IDObra"))
            '    TxtTotalAlambre.Text = Nz(dblAlambre, 0)
            '    TxtTotalPlanilla.Text = Nz(dblPlanilla, 0)
            '    TxtTotalSuministrado.Text = Nz(dblSuministrado, 0)
            '    TxtTotalMontado.Text = Nz(dblMontado, 0)
            '    txtTotalMedios.Text = Nz(dblMedios, 0)
            '    TxtTotalBascula.Text = Nz(dblBascula, 0)
            '    txtPProduccion.Text = Nz(dblPProduccion, 0) 'IBIS. David

        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Public Function TotalImporteMediciones(ByVal strVista As String, ByRef dblAlambre As Double, _
                              ByRef dblPlanilla As Double, ByRef dblSuministrado As Double, ByRef dblMontado As Double, _
                              ByRef dblMedios As Double, ByRef dblPProduccion As Double, ByRef dblBascula As Double, ByVal IdObra As Integer)
        Dim dr As DataTable
        Dim strWhere As String

        Try
            strWhere = "IdObra=" & IdObra

            'dr = AdminData.GetData(strVista, , strWhere)
            'David Velasco 30/11
            Dim obra As New ObraMedicion
            dr = obra.devuelveDatos(strVista, strWhere)

            'David Velasco
            If dr.Rows.Count > 0 Then

                dblAlambre = xRound(Nz(dr("TPesoPlanilla"), 0), 6)
                dblPlanilla = xRound(Nz(dr("TPesoPlanilla"), 0), 6)
                dblSuministrado = xRound(Nz(dr("TTotalSuministro"), 0), 6)
                dblMedios = xRound(Nz(dr("TTotalMontaje"), 0), 6)
                dblMontado = xRound(Nz(dr("TTotalMediosE"), 0), 6)
                dblBascula = xRound(Nz(dr("TPesoBascula"), 0), 6)
                dblPProduccion = xRound(Nz(dr("TPlanilla"), 0), 6) 'IBIS. David
            Else
                dblAlambre = 0
                dblPlanilla = 0
                dblSuministrado = 0
                dblMedios = 0
                dblMontado = 0
                dblPProduccion = 0 'IBIS. David
            End If

        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function

    Private Sub CargarLista(ByVal IDObra As Integer)

        Dim Strsql As String
        Dim f As Filter
        Dim dt As DataTable
        Dim jsCol As Janus.Windows.GridEX.GridEXColumn      'JSColumn
        Dim vl As Janus.Windows.GridEX.GridEXValueListItemCollection  ' JSValueList
        Dim i As Integer
        Dim n As Integer
        Dim aux As Janus.Windows.GridEX.GridEXValueListItem

        Try

            jsCol = GridMediciones.Columns("Estructura")
            If Not jsCol Is Nothing Then
                vl = jsCol.ValueList
                If Not vl Is Nothing Then
                    If vl.Count > 0 Then
                        vl.Clear()
                    End If
                End If
            End If

            Strsql = "SELECT DISTINCT(Estructura) FROM vFrmObraMedicionesAEstructura WHERE IDOBRA = " & IDObra
            'dt = AdminData.Filter(Strsql, , , , False)
            'David Velasco 30/11
            Dim obra As New ObraMedicion
            dt = obra.seleccion(Strsql)
            'David Velaco

            'FwConsulta = Nothing
            If Not dt Is Nothing Then
                If dt.Rows.Count <> 0 Then

                    jsCol = GridMediciones.Columns("Estructura")
                    jsCol.HasValueList = True
                    'jsCol.ReplaceValues = True

                    vl = jsCol.ValueList
                    For Each dr As DataRow In dt.Rows
                        aux = New Janus.Windows.GridEX.GridEXValueListItem
                        aux.Value = Nz(dr("Estructura"), DBNull.Value)
                        aux.Text = Nz(dr("Estructura"), "")
                        vl.Add(aux)  ', rcsRdo!Estructura
                    Next
                Else
                    GridMediciones.Columns("Estructura").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    GridMediciones.Columns("Estructura").EditType = Janus.Windows.GridEX.EditType.TextBox
                    GridMediciones.Columns("Estructura").HasValueList = False

                End If

            End If

        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub
    Private Sub CargarLista2(ByVal columna As String, ByVal IDObra As Integer)

        Dim Strsql As String
        Dim dt As DataTable
        Dim jsCol2 As Janus.Windows.GridEX.GridEXColumn      'JSColumn
        Dim vl2 As Janus.Windows.GridEX.GridEXValueListItemCollection  ' JSValueList
        Dim aux As Janus.Windows.GridEX.GridEXValueListItem

        Try

            jsCol2 = GridMediciones.Columns(columna)
            If Not jsCol2 Is Nothing Then
                vl2 = jsCol2.ValueList
                If Not vl2 Is Nothing Then
                    If vl2.Count > 0 Then
                        vl2.Clear()
                    End If
                End If
            End If

            Strsql = "SELECT " & columna & " FROM vFrmObraMedicionesAEstructura WHERE IDOBRA = " & IDObra
            'dt = AdminData.Filter(Strsql, , , , False)
            'David Velasco 30/11
            Dim obra As New ObraMedicion
            dt = obra.seleccion(Strsql)

            Dim strsql2 As String
            strsql2 = "SELECT DISTINCT " & columna & " FROM vFrmObraMedicionesAEstructura WHERE IDOBRA = " & IDObra
            Dim f As New Filter
            f.Add(columna, FilterOperator.NotEqual, "")
            dt = New BE.DataEngine().Filter(strsql2, f)
            'David Velaco

            'FwConsulta = Nothing
            If Not dt Is Nothing Then
                If dt.Rows.Count <> 0 Then

                    jsCol2 = GridMediciones.Columns(columna)
                    jsCol2.HasValueList = True
                    'jsCol.ReplaceValues = True

                    vl2 = jsCol2.ValueList
                    For Each dr As DataRow In dt.Rows
                        aux = New Janus.Windows.GridEX.GridEXValueListItem
                        aux.Value = Nz(dr(columna), DBNull.Value)
                        aux.Text = Nz(dr(columna), "")
                        vl2.Add(aux)  ', rcsRdo!Estructura
                    Next
                Else
                    GridMediciones.Columns(columna).ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    GridMediciones.Columns(columna).EditType = Janus.Windows.GridEX.EditType.TextBox
                    GridMediciones.Columns(columna).HasValueList = False

                End If

            End If

        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub CargarDespleColumna(ByVal sNomColumna As String, ByRef GridModif As Solmicro.Expertis.Engine.UI.Grid)
        ' La funcion recorre los valores de la columna pasada y los carga en el desplegable de la q se edita
        Try
            Dim dtValores As New DataTable
            Dim jsCol As Janus.Windows.GridEX.GridEXColumn      'JSColumn
            Dim vl As Janus.Windows.GridEX.GridEXValueListItemCollection  ' JSValueList
            Dim aux As Janus.Windows.GridEX.GridEXValueListItem
            dtValores.Columns.Add("valor", System.Type.GetType("System.String"))
            ' Recorrer los valores actuales
            ' Control de fila en lista
            Dim dfilas() As DataRow
            For iCont As Integer = 0 To GridModif.RecordCount - 1
                ' Si tiene valor
                If Not IsDBNull(CType(GridModif.DataSource, DataTable).Rows(iCont)(sNomColumna)) AndAlso CType(GridModif.DataSource, DataTable).Rows(iCont)(sNomColumna).trim <> "" Then
                    dfilas = dtValores.Select("valor='" & CType(GridModif.DataSource, DataTable).Rows(iCont)(sNomColumna).trim & "'")
                    If dfilas.Length <= 0 Then
                        Dim dfila As DataRow
                        dfila = dtValores.NewRow()
                        dfila(0) = CType(GridModif.DataSource, DataTable).Rows(iCont)(sNomColumna).trim
                        dtValores.Rows.Add(dfila)
                    End If
                End If
            Next

            If Not dtValores Is Nothing Then
                If dtValores.Rows.Count <> 0 Then
                    ' Ordenar los datos alfa.
                    dtValores.DefaultView.Sort = "valor"
                    ' Limpiar anterior
                    jsCol = GridMediciones.Columns(sNomColumna)
                    If Not jsCol Is Nothing Then
                        vl = jsCol.ValueList
                        If Not vl Is Nothing Then
                            If vl.Count > 0 Then
                                vl.Clear()
                            End If
                        End If
                    End If
                    jsCol = GridMediciones.Columns(sNomColumna)
                    jsCol.HasValueList = True
                    'jsCol.ReplaceValues = True

                    vl = jsCol.ValueList
                    For icont As Integer = 0 To dtValores.Rows.Count - 1
                        aux = New Janus.Windows.GridEX.GridEXValueListItem
                        aux = Nz(dtValores.DefaultView.Item(icont)(0), DBNull.Value)
                        aux.Text = Nz(dtValores.DefaultView.Item(icont)(0), "")
                        vl.Add(aux)  ', rcsRdo!Estructura
                    Next
                    'GridMediciones.Columns("Estructura").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.DownArrow
                    'jsCol.EditType = Janus.Windows.GridEX.EditType.DropDownList
                Else
                    GridMediciones.Columns(sNomColumna).ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    GridMediciones.Columns(sNomColumna).EditType = Janus.Windows.GridEX.EditType.TextBox
                    GridMediciones.Columns(sNomColumna).HasValueList = False
                    'GridMediciones.Columns("Estructura").ReplaceValues = False
                End If
                dtValores = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " GridMediciones "

    Private Sub CopiarMedicion()
        'IBIS. David. 22-05-08. Copiar Mediciones
        Dim IDLineaMedicionA, IdObra, Alambre, D8, D10, D12, D16, D20, D25, D32, PesoPlanilla, _
        PesoPedido, PesoAlbaran, CertificadoSuministro, CertificadoMontaje, CertificadoMediosE, TotalSuministro, TotalMontaje, TotalMediosE, _
        Secuencia, PesoPlanillaRef, DiferenciaP, _
        PesoBascula, PrecioCertSuministro, PrecioCertMontaje, PrecioCertMediosElev, FacElaboracion, Planilla, _
        MedElaboracion, PrecioCertSuministroB, PrecioCertMontajeB, PrecioCertMediosElevB, PrecioCertElebacion, _
        PrecioCertElebacionB, Marcar As Double

        Dim Estructura, Localizacion1, Localizacion2, Observaciones, Observaciones2, IDUDMedida, NObra, numAlbaran, numPedido, NCertificacion As String

        Dim FechaRef, Fecha, FechaAnifer As String
        Dim Facturable, SuministroFacturado, Certificar As Boolean

        Try

            With GridMediciones
                IDLineaMedicionA = Nz(.GetValue("idLineaMedicionA"), 0)
                IdObra = Nz(.GetValue("IdObra"), 0)
                Alambre = Nz(.GetValue("Alambre"), 0)
                D8 = Nz(.GetValue("D8"), 0)
                D10 = Nz(.GetValue("D10"), 0)
                D12 = Nz(.GetValue("D12"), 0)
                D16 = Nz(.GetValue("D16"), 0)
                D20 = Nz(.GetValue("D20"), 0)
                D25 = Nz(.GetValue("D25"), 0)
                D32 = Nz(.GetValue("D32"), 0)

                'Marcar = Nz(.GetValue("Marcar"), 0)

                PesoPlanilla = Nz(.GetValue("PesoPlanilla"), 0)
                PesoPedido = Nz(.GetValue("PesoPedido"), 0)
                PesoAlbaran = Nz(.GetValue("PesoAlbaran"), 0)
                CertificadoSuministro = Nz(.GetValue("CertificadoSuministro"), 0)
                CertificadoMontaje = Nz(.GetValue("CertificadoMontaje"), 0)
                TotalSuministro = Nz(.GetValue("TotalSuministro"), 0)
                TotalMontaje = Nz(.GetValue("TotalMontaje"), 0)
                TotalMediosE = Nz(.GetValue("TotalMediosE"), 0)
                NCertificacion = Nz(.GetValue("NCertificacion"), 0)
                CertificadoMediosE = Nz(.GetValue("CertificadoMediosE"), 0)

                Secuencia = Nz(.GetValue("Secuencia"), 0)
                IDUDMedida = Nz(.GetValue("IDUDMedida"), "")
                numAlbaran = Nz(.GetValue("numAlbaran"), "")
                numPedido = Nz(.GetValue("numPedido"), "")
                Certificar = Nz(.GetValue("Certificar"), 0)
                PesoPlanillaRef = Nz(.GetValue("PesoPlanillaRef"), 0)
                DiferenciaP = Nz(.GetValue("DiferenciaP"), 0)
                PesoBascula = Nz(.GetValue("PesoBascula"), 0)
                SuministroFacturado = Nz(.GetValue("SuministroFacturado"), 0)
                Facturable = Nz(.GetValue("Facturable"), 0)
                PrecioCertSuministro = Nz(.GetValue("PrecioCertSuministro"), 0)
                PrecioCertMontaje = Nz(.GetValue("PrecioCertMontaje"), 0)
                PrecioCertMediosElev = Nz(.GetValue("PrecioCertMediosElev"), 0)
                FacElaboracion = Nz(.GetValue("FacElaboracion"), 0)
                Planilla = Nz(.GetValue("Planilla"), 0)

                MedElaboracion = Nz(.GetValue("MedElaboracion"), 0)
                PrecioCertSuministroB = Nz(.GetValue("PrecioCertSuministroB"), 0)
                PrecioCertMontajeB = Nz(.GetValue("PrecioCertMontajeB"), 0)
                'PrecioCertMediosElevB = Nz(.GetValue("PrecioCertMediosElevB"), 0)
                'PrecioCertElebacion = Nz(.GetValue("PrecioCertElebacion"), 0)
                'PrecioCertElebacionB = Nz(.GetValue("PrecioCertElebacionB"), 0)
                NObra = Nz(.GetValue("NObra"), "")
                PesoBascula = Nz(.GetValue("PesoBascula"), 0)

                Estructura = Nz(.GetValue("Estructura"), "")
                Localizacion1 = Nz(.GetValue("Localizacion1"), "")
                Localizacion2 = Nz(.GetValue("Localizacion2"), "")
                Observaciones = Nz(.GetValue("Observaciones"), "")
                Observaciones2 = Nz(.GetValue("Observaciones2"), "")

                Fecha = Nz(.GetValue("Fecha"), )
                FechaRef = Nz(.GetValue("FechaRef"), )
                FechaAnifer = Nz(.GetValue("FechaAnifer"), )

                .Row = .newTopRowPosition
                Dim articulo As New Articulo
                .SetValue("IDLineaMedicionA", articulo.DevuelveID)
                .SetValue("IdObra", IdObra)
                .SetValue("Alambre", Alambre)
                .SetValue("D8", D8)
                .SetValue("D10", D10)
                .SetValue("D12", D12)
                .SetValue("D16", D16)
                .SetValue("D20", D20)
                .SetValue("D25", D25)
                .SetValue("D32", D32)
                .SetValue("PesoPlanilla", PesoPlanilla)

                .SetValue("PesoPedido", PesoPedido)
                .SetValue("PesoAlbaran", PesoAlbaran)
                .SetValue("CertificadoSuministro", CertificadoSuministro)
                .SetValue("CertificadoMontaje", CertificadoMontaje)
                .SetValue("CertificadoMediosE", CertificadoMediosE)
                .SetValue("TotalSuministro", TotalSuministro)
                .SetValue("TotalMontaje", TotalMontaje)
                .SetValue("TotalMediosE", TotalMediosE)
                .SetValue("NCertificacion", NCertificacion)
                .SetValue("Secuencia", Secuencia)
                .SetValue("IDUDMedida", IDUDMedida)
                .SetValue("numAlbaran", numAlbaran)
                .SetValue("numPedido", numPedido)
                .SetValue("Certificar", Certificar)
                .SetValue("PesoPlanillaRef", PesoPlanillaRef)
                .SetValue("DiferenciaP", DiferenciaP)
                .SetValue("PesoBascula", PesoBascula)
                .SetValue("SuministroFacturado", SuministroFacturado)

                '.SetValue("Marcar", Marcar)

                .SetValue("Facturable", Facturable)
                .SetValue("PrecioCertSuministro", PrecioCertSuministro)
                .SetValue("PrecioCertMontaje", PrecioCertMontaje)
                .SetValue("PrecioCertMediosElev", PrecioCertMediosElev)
                .SetValue("FacElaboracion", FacElaboracion)
                .SetValue("Planilla", Planilla)

                .SetValue("MedElaboracion", MedElaboracion)
                .SetValue("PrecioCertSuministroB", PrecioCertSuministroB)
                .SetValue("PrecioCertMontajeB", PrecioCertMontajeB)
                .SetValue("PrecioCertMediosElevB", PrecioCertMediosElevB)
                '.SetValue("PrecioCertElebacion", PrecioCertElebacion)
                .SetValue("Estructura", Estructura)
                .SetValue("Localizacion1", Localizacion1)
                .SetValue("Localizacion2", Localizacion2)
                .SetValue("Observaciones", Observaciones)
                .SetValue("Observaciones2", Observaciones2)

                '.SetValue("FechaRef", FechaRef)
                .SetValue("Fecha", Fecha)
                .SetValue("FechaAnifer", Date.Today)

            End With
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub ControlarDesplegableEstructura()
        Dim dt As New DataTable
        Try

            With GridMediciones
                dt = .DataSource

                If dt.Rows.Count <> 0 Then
                    .Columns("Estructura").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    CargarLista(Me.CurrentRow("IDObra"))
                    .Refresh()
                Else
                    .Columns("Estructura").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    .Columns("Estructura").EditType = Janus.Windows.GridEX.EditType.TextBox
                    .Columns("Estructura").HasValueList = False
                    .Refresh()
                End If
            End With
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub MntoGestionObrasAcero_Navigated(ByVal sender As Object, ByVal e As Engine.UI.NavigatedEventArgs) Handles MyBase.Navigated
        Try
            If Not IsDBNull(Me.CurrentRow("IDObra")) Then
                ComprobarMediosElev()
                BloquearTotalMedios()
                'ControlarDesplegableEstructura()
                calculartotales()

                CargarLista(Me.CurrentRow("IDObra"))
                If Not IsDBNull(Me.CurrentRow("Bloqueado")) Then
                    If Me.CurrentRow("Bloqueado") = 1 Then
                        BloquearGridMediciones()
                    Else
                        DesbloquearGridMediciones()
                    End If
                End If

                'Pone el nombre del Cliente. David Veasco 16/12

                If (advIDCliente.Text.ToString.Length.Equals(0)) Then
                    UnderLineLabel4.Text = ""
                Else
                    Dim idcliente As String
                    idcliente = advIDCliente.Text
                    Dim cli As New Cliente
                    Dim dt As DataTable = cli.SelOnPrimaryKey(idcliente)
                    UnderLineLabel4.Text = dt.Rows(0)("DescCliente")
                End If
                'David Velasco 16/12
                'cambiaNombreColumnasOcultas()
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Private Sub cambiaNombreColumnasOcultas()
    '    Try
    '        If GridMediciones.Columns("Celosia").Visible And GridMediciones.Columns("Celosia").Caption = "Celosia Ml" Then
    '        Else
    '            If GridMediciones.Columns("Celosia").Visible Then
    '                GridMediciones.Columns("Celosia").Caption = "Celosia Ml"
    '            Else
    '                GridMediciones.Columns("Celosia").Visible = True
    '                GridMediciones.Columns("Celosia").Caption = "Celosia Ml"
    '                GridMediciones.HideColumn("Celosia")
    '            End If
    '        End If
    '        If GridMediciones.Columns("Porte").Visible And GridMediciones.Columns("Porte").Caption = "Porte Ud" Then
    '        Else
    '            If GridMediciones.Columns("Porte").Visible = True Then
    '                GridMediciones.Columns("Porte").Caption = "Porte Ud"
    '            Else
    '                GridMediciones.Columns("Porte").Visible = True
    '                GridMediciones.Columns("Porte").Caption = "Porte Ud"
    '                GridMediciones.HideColumn("Porte")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub
    Private Sub GridMediciones_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridMediciones.AddingRecord
        Try
            With GridMediciones
                .Value("IDObra") = Me.CurrentRow("IDObra")
            End With
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub GridMediciones_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridMediciones.CellUpdated
        Dim objtipotrabajo As New ObraTipoTrabajo
        Dim fwnSubTipoTra As ObraSubtipoTrabajo
        Dim FwnArticulo As Articulo
        Dim FwnCGestion As CentroGestion
        Dim dt As DataTable
        Dim strTipoObra As String
        Dim strTipoTrabajo As String
        Dim strSubTipoTrabajo As String
        Dim strDescTrabajo As String
        Dim strDescSubtipo As String
        Dim strValor As String
        Dim lngPos As Long
        Dim strWhere As String
        Dim gblnAutoCalculando As Boolean

        Try
            With GridMediciones
                Select Case e.Column.Index
                    Case .Columns("D8").Index, .Columns("D10").Index, .Columns("D12").Index, .Columns("D16").Index, .Columns("D20").Index, .Columns("D25").Index, .Columns("D32").Index
                        If IsNumeric(.Columns("D8").Index) And IsNumeric(.Columns("D10").Index) And IsNumeric(.Columns("D12").Index) And IsNumeric(.Columns("D16").Index) And IsNumeric(.Columns("D20").Index) And IsNumeric(.Columns("D25").Index) And IsNumeric(.Columns("D32").Index) Then


                            ' Modificación si mete negativos en diámetros poner 0.Rober 22/03/2010..............................................................................................
                            .Value(.Columns("PesoPlanilla").Index) = IIf(xRound(CDbl(Nz((.Columns("D8").Index), 0))) < 0, 0, xRound(CDbl(Nz((.Columns("D8").Index), 0)), 2)) + _
                                                                     IIf(xRound(CDbl(Nz((.Columns("D10").Index), 0))) < 0, 0, xRound(CDbl(Nz((.Columns("D10").Index), 0)), 2)) + _
                                                                     IIf(xRound(CDbl(Nz((.Columns("D12").Index), 0))) < 0, 0, xRound(CDbl(Nz((.Columns("D12").Index), 0)), 2)) + _
                                                                     IIf(xRound(CDbl(Nz((.Columns("D16").Index), 0))) < 0, 0, xRound(CDbl(Nz((.Columns("D16").Index), 0)), 2)) + _
                                                                     IIf(xRound(CDbl(Nz((.Columns("D20").Index), 0))) < 0, 0, xRound(CDbl(Nz((.Columns("D20").Index), 0)), 2)) + _
                                                                     IIf(xRound(CDbl(Nz((.Columns("D25").Index), 0))) < 0, 0, xRound(CDbl(Nz((.Columns("D25").Index), 0)), 2)) + _
                                                                     IIf(xRound(CDbl(Nz((.Columns("D32").Index), 0))) < 0, 0, xRound(CDbl(Nz((.Columns("D32").Index), 0)), 2))
                            '.Value(.Columns("PesoPedido").Index) = (.Columns("Pesoplanilla").Index)

                            'MsgBox(.Value(.Columns("PesoPedido").Index))
                            'SUMA
                            Try
                                .Value(.Columns("PesoPlanilla").Index) = .Value(Nz((.Columns("D8").Index), 0)) + .Value(Nz((.Columns("D10").Index), 0)) + .Value(Nz((.Columns("D12").Index), 0)) + .Value(Nz((.Columns("D16").Index), 0)) + .Value(Nz((.Columns("D20").Index), 0)) + .Value(Nz((.Columns("D25").Index), 0)) + .Value(Nz((.Columns("D32").Index), 0))
                                .Value(.Columns("PesoPedido").Index) = .Value(.Columns("D8").Index) + .Value(.Columns("D10").Index) + .Value(.Columns("D12").Index) + .Value(.Columns("D16").Index) + .Value(.Columns("D20").Index) + .Value(.Columns("D25").Index) + .Value(.Columns("D32").Index)
                                .Value(.Columns("CertificadoSuministro").Index) = .Value(.Columns("D8").Index) + .Value(.Columns("D10").Index) + .Value(.Columns("D12").Index) + .Value(.Columns("D16").Index) + .Value(.Columns("D20").Index) + .Value(.Columns("D25").Index) + .Value(.Columns("D32").Index)
                                .Value(.Columns("FacElaboracion").Index) = .Value(.Columns("D8").Index) + .Value(.Columns("D10").Index) + .Value(.Columns("D12").Index) + .Value(.Columns("D16").Index) + .Value(.Columns("D20").Index) + .Value(.Columns("D25").Index) + .Value(.Columns("D32").Index)
                                '.Value(.Columns("Albaran").Index) = .Value(.Columns("D8").Index) + .Value(.Columns("D10").Index) + .Value(.Columns("D12").Index) + .Value(.Columns("D16").Index) + .Value(.Columns("D20").Index) + .Value(.Columns("D25").Index) + .Value(.Columns("D32").Index)
                                '.Value(.Columns("PesoPlanilla").Index) = .Value(Nz((.Columns("D8").Index), 0)) + .Value(Nz((.Columns("D10").Index), 0)) + .Value(Nz((.Columns("D12").Index), 0)) + .Value(Nz((.Columns("D16").Index), 0)) + .Value(Nz((.Columns("D20").Index), 0)) + .Value(Nz((.Columns("D25").Index), 0)) + .Value(Nz((.Columns("D32").Index)))
                            Catch ex As Exception

                            End Try

                            'Fac. Acero = Albaran
                            '.Value(.Columns("CertificadoSuministro").Index) = (.Columns("Pesoplanilla").Index)

                            'Fac. Elaboracion = Albaran
                            '.Value(.Columns("FacElaboracion").Index) = (.Columns("Pesoplanilla").Index)

                            ' (.Columns("DiferenciaP").Index) = xRound(CDbl(Nz((.Columns("PesoPlanilla").Index), 0)) - CDbl(Nz((.Columns("Planilla").Index), 0)), 6)
                        Else
                            MessageBox.Show("El Valor ingresado no es valido", Engine.UI.ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        'valorNuevo = Nz(.GetValue(e.Column.Index), 0)
                        '.SetValue(e.Column.Index, valorAntiguo + valorNuevo)

                        'IBIS. David
                        '(.Columns("PesoPlanilla").Index) = xRound(CDbl(Nz((.Columns("D8").Index), 0)) + CDbl(Nz((.Columns("D10").Index), 0)) + CDbl(Nz((.Columns("D12").Index), 0)) + CDbl(Nz((.Columns("D16").Index), 0)) + CDbl(Nz((.Columns("D20").Index), 0)) + CDbl(Nz((.Columns("D25").Index), 0)) + CDbl(Nz((.Columns("D32").Index), 0)), 6)

                        'Manuel
                    Case .Columns("PesoPlanilla").Index

                        'Peso Pedido= Peso Facturacion.
                        .Value(.Columns("PesoPlanilla").Index) = Nz((.Columns("PesoPlanilla").Index), 0)
                        .Value(.Columns("PesoPedido").Index) = .Value(.Columns("Pesoplanilla").Index)

                        'Fac. Acero = Albaran
                        .Value(.Columns("CertificadoSuministro").Index) = .Value(.Columns("Pesoplanilla").Index)
                        'Fac. Elaboracion = Albaran
                        .Value(.Columns("FacElaboracion").Index) = .Value(.Columns("Pesoplanilla").Index)
                        ' Eusebio, 03/08/2009. Al pintar las columnas para que realice correctamente el sumatorio hay q controlar el nulo de la columna.
                        .Value(.Columns("CertificadoMontaje").Index) = Nz(.Value(.Columns("CertificadoMontaje").Index), 0)
                        ' Recalculo de columnas
                        CalculoMedicion()

                        'Comentado por David Velasco 01/12/21
                        'Case .Columns("estructura").Index, .Columns("ncarga").Index
                        '    ' Controlar el campo ncarga q sea un contador y luego si es una fila de optimización se pone un C- delante. 12/02/2010
                        '    If Trim(.Value(.Columns("ncarga").Index)) = "" Then
                        '        Select Case MsgBox("Valor de columna NºCarga, Se trata de una medición normal(Si), para medición de optimización(No), Sin contador NºCarga (Cancelar).", MsgBoxStyle.YesNoCancel, "Clase de carga")
                        '            Case MsgBoxResult.Yes
                        '                .Value(.Columns("ncarga").Index) = ContadorNcarga()
                        '            Case MsgBoxResult.No
                        '                .Value(.Columns("ncarga").Index) = "C-" & ContadorNcarga()
                        '            Case MsgBoxResult.Cancel
                        '                .Value(.Columns("ncarga").Index) = 0
                        '        End Select

                        '    End If
                        'David Velasco 01/12/21
                    Case .Columns("PesoPedido").Index, .Columns("CertificadoSuministro").Index, .Columns("CertificadoMontaje").Index, .Columns("CertificadoMediosE").Index, .Columns("FacElaboracion").Index
                        ' Recalculo de columnas
                        CalculoMedicion()
                        'David Velasco 31/05/22
                    Case .Columns("Fecha").Index
                        Dim fecha As DateTime
                        fecha = .GetValue("Fecha")
                        'Obtengo el año
                        Dim año As String
                        año = fecha.Year
                        .SetValue("Año", año)
                        'Obtengo el mes
                        Dim mes As String
                        mes = fecha.Month
                        .SetValue("Mes", mes)
                    Case Else

                End Select
                calculartotales()
                If Not .Row = -1 Then
                    'IBIS. David
                    '.UpdateData()
                    'Me.UpdateData()
                End If
            End With
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub
    Private Sub GridMediciones_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMediciones.RecordAdded
        Try
            calculartotales()
            If Me.RecordsState = Engine.UI.RecordsState.Modified Then
                'IBIS. David
                'Me.UpdateData()
            End If
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub GridMediciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMediciones.GotFocus
        Try
            'If Me.RecordsState = RecordsState.Modified Then
            'IBIS. David
            'Me.UpdateData()
            'End If

            'IBIS. David
            With GridMediciones
                .Columns("NObra").DefaultValue = Me.CurrentRow("NObra")
                .Columns("PrecioCertSuministro").DefaultValue = 0
                .Columns("PrecioCertSuministroB").DefaultValue = 0
                .Columns("PrecioCertMontaje").DefaultValue = 0
                .Columns("PrecioCertMontajeB").DefaultValue = 0
                .Columns("PrecioCertMediosElevB").DefaultValue = 0
                .Columns("PrecioCertElaboracion").DefaultValue = 0
                .Columns("PrecioCertElaboracionB").DefaultValue = 0
                .Columns("CertificadoMediosE").DefaultValue = 0
                .Columns("PrecioCertMediosElev").DefaultValue = 0
                .Columns("TotalMediosE").DefaultValue = 0

                .Columns("FacElaboracion").DefaultValue = 0
                .Columns("CertificadoMontaje").DefaultValue = 0
                .Columns("CertificadoSuministro").DefaultValue = 0
                .Columns("TotalSuministro").DefaultValue = 0
                .Columns("TotalMontaje").DefaultValue = 0
                .Columns("MedElaboracion").DefaultValue = 0
            End With

        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub GridMediciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMediciones.DoubleClick
        Try
            With GridMediciones

                If .Columns("Estructura").EditType = Janus.Windows.GridEX.EditType.TextBox Then
                    .Columns("Estructura").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    CargarLista(Me.CurrentRow("IDObra"))
                    .Refresh()
                Else
                    .Columns("Estructura").HasValueList = False
                    .Columns("Estructura").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    .Columns("Estructura").EditType = Janus.Windows.GridEX.EditType.TextBox
                    .Columns("Estructura").HasValueList = False
                    .Refresh()
                End If
                'David Velasco 27/04
                If .Columns("Observaciones").EditType = Janus.Windows.GridEX.EditType.TextBox Then
                    .Columns("Observaciones").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    CargarLista2("Observaciones", Me.CurrentRow("IDObra"))
                    .Refresh()
                Else
                    .Columns("Observaciones").HasValueList = False
                    .Columns("Observaciones").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    .Columns("Observaciones").EditType = Janus.Windows.GridEX.EditType.TextBox
                    .Columns("Observaciones").HasValueList = False
                    .Refresh()
                End If
                If .Columns("Observaciones2").EditType = Janus.Windows.GridEX.EditType.TextBox Then
                    .Columns("Observaciones2").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    CargarLista2("Observaciones2", Me.CurrentRow("IDObra"))
                    .Refresh()
                Else
                    .Columns("Observaciones2").HasValueList = False
                    .Columns("Observaciones2").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    .Columns("Observaciones2").EditType = Janus.Windows.GridEX.EditType.TextBox
                    .Columns("Observaciones2").HasValueList = False
                    .Refresh()
                End If
                If .Columns("Localizacion1").EditType = Janus.Windows.GridEX.EditType.TextBox Then
                    .Columns("Localizacion1").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    CargarLista2("Localizacion1", Me.CurrentRow("IDObra"))
                    .Refresh()
                Else
                    .Columns("Localizacion1").HasValueList = False
                    .Columns("Localizacion1").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    .Columns("Localizacion1").EditType = Janus.Windows.GridEX.EditType.TextBox
                    .Columns("Localizacion1").HasValueList = False
                    .Refresh()
                End If
                If .Columns("Localizacion2").EditType = Janus.Windows.GridEX.EditType.TextBox Then
                    .Columns("Localizacion2").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    CargarLista2("Localizacion2", Me.CurrentRow("IDObra"))
                    .Refresh()
                Else
                    .Columns("Localizacion2").HasValueList = False
                    .Columns("Localizacion2").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    .Columns("Localizacion2").EditType = Janus.Windows.GridEX.EditType.TextBox
                    .Columns("Localizacion2").HasValueList = False
                    .Refresh()
                End If
                'David Velasco 27/04
            End With

            If Me.RecordsState = Engine.UI.RecordsState.Saved Then
                With GridMediciones
                    Dim c As GridEXColumn = .ColumnFromPoint()
                    If Not IsNothing(c) Then
                        Dim hit As GridArea
                        hit = .HitTest()
                        If hit = GridArea.Cell Or hit = GridArea.NewRowCell Then
                            Select Case c.Key
                                Case "D8"
                                    MostrarFormularioNumeroSerie(8, .Value(.Columns("D8").Index), .Value(.Columns("IDLineaMedicionA").Index))
                                Case "D10"
                                    MostrarFormularioNumeroSerie(10, .Value(.Columns("D10").Index), .Value(.Columns("IDLineaMedicionA").Index))
                                Case "D12"
                                    MostrarFormularioNumeroSerie(12, .Value(.Columns("D12").Index), .Value(.Columns("IDLineaMedicionA").Index))
                                Case "D16"
                                    MostrarFormularioNumeroSerie(16, .Value(.Columns("D16").Index), .Value(.Columns("IDLineaMedicionA").Index))
                                Case "D20"
                                    MostrarFormularioNumeroSerie(20, .Value(.Columns("D20").Index), .Value(.Columns("IDLineaMedicionA").Index))
                                Case "D25"
                                    MostrarFormularioNumeroSerie(25, .Value(.Columns("D25").Index), .Value(.Columns("IDLineaMedicionA").Index))
                                Case "D32"
                                    MostrarFormularioNumeroSerie(32, .Value(.Columns("D32").Index), .Value(.Columns("IDLineaMedicionA").Index))
                            End Select
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub GridMediciones_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridMediciones.ColumnButtonClick
        Try
            With GridMediciones
                Dim posFila As Integer = .Row
                Select Case e.Column.Index()
                    Case .Columns("Marcar").Index
                        If .GetValue("Facturable") = 0 And .GetValue("Certificar") = 0 And .GetValue("SuministroFacturado") = 0 Then
                            .SetValue("facturable", 1)
                            .SetValue("certificar", 1)
                            .SetValue("SuministroFacturado", 1)
                            'IBIS. David
                            '.UpdateData()
                            ' Me.UpdateData()
                            .Refresh()
                        Else
                            .SetValue("facturable", 0)
                            .SetValue("certificar", 0)
                            .SetValue("SuministroFacturado", 0)
                            'IBIS. David
                            '.UpdateData()
                            'Me.UpdateData()
                            'e.Column.ButtonText = "Marcar Todo"
                            .Refresh()
                        End If
                        .MoveTo(posFila)
                End Select
            End With
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub TabPage1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UiTabPage21.GotFocus
        Try
            calculartotales()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region " Acciones Toolbar "

    Private Sub CertificarMarcarTodos()
        Dim i As Integer
        Try
            With GridMediciones
                For i = 0 To .RowCount - 1
                    .Row = i
                    If IsNothing(.GetValue("Certificar")) = False Then
                        .SetValue("Certificar", True)
                    End If
                Next
            End With
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub CertificarDesmarcarTodos()
        Dim i As Integer
        Try
            With GridMediciones
                For i = 0 To .RowCount - 1
                    .Row = i
                    If IsNothing(.GetValue("Certificar")) = False Then
                        .SetValue("Certificar", False)
                    End If
                Next
            End With
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub AccionAsignarPrecios()
        Try
            Dim frm As New frmAsignarPrecios
            frm.ShowDialog()

            If frm.Bien = False Then
                Exit Sub
            Else
                Dim i As Integer

                With GridMediciones
                    For i = 0 To .RowCount - 1
                        .Row = i

                        'IBIS. David. Miramos si esta marcado Certificar, si está, se le actualizaran.
                        If Nz(.GetValue("Certificar"), False) = True Then

                            .SetValue("PrecioCertSuministro", CDbl(Nz(frm.txtSumA.Text, 0)))
                            .SetValue("PrecioCertSuministroB", CDbl(Nz(frm.txtSumB.Text, 0)))

                            .SetValue("PrecioCertMontaje", CDbl(Nz(frm.txtMonA.Text, 0)))
                            .SetValue("PrecioCertMontajeB", CDbl(Nz(frm.txtMonB.Text, 0)))

                            .SetValue("PrecioCertMediosElev", CDbl(Nz(frm.txtElevA.Text, 0)))
                            .SetValue("PrecioCertMediosElevB", CDbl(Nz(frm.txtElevB.Text, 0)))

                            .SetValue("PrecioCertElebacion", CDbl(Nz(frm.txtElabA.Text, 0)))
                            .SetValue("PrecioCertElebacionB", CDbl(Nz(frm.txtElabB.Text, 0)))

                        End If

                    Next
                End With

            End If
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub AccionAsignarPreciosDiametros()
        Try
            Dim frm As New frmAsignarPreciosDiametro
            frm.ShowDialog()

            If frm.Bien = False Then
                Exit Sub
            ElseIf MsgBox("Se aplicarán los precios marcados en el formulario para los diferentes diámetros,¿Desea continuar?", MsgBoxStyle.OkCancel, "Confirmación") = MsgBoxResult.Ok Then

                Dim i As Integer
                Dim dDesde As Date = frm.FDesde.Value
                Dim dHasta As Date = frm.FHasta.Value

                With GridMediciones
                    For i = 0 To .RowCount - 1
                        .Row = i

                        'Eusebio, control si la fila esta entre los criterios de fechas
                        If Nz(.GetValue("Fecha")) >= dDesde AndAlso Nz(.GetValue("Fecha")) <= dHasta Then

                            .SetValue("ED8", CDbl(Nz(frm.txtDim8, 0)))
                            .SetValue("ED10", CDbl(Nz(frm.txtDim10, 0)))
                            .SetValue("ED12", CDbl(Nz(frm.txtDim12, 0)))
                            .SetValue("ED16", CDbl(Nz(frm.txtDim16, 0)))
                            .SetValue("ED20", CDbl(Nz(frm.txtDim20, 0)))
                            .SetValue("ED25", CDbl(Nz(frm.txtDim25, 0)))
                            .SetValue("ED32", CDbl(Nz(frm.txtDim32, 0)))
                            .SetValue("PrecioCertElebacion", CDbl(Nz(frm.txtEla, 0)))

                        End If

                    Next
                End With

            End If
            ' Limpiar memoria
            frm.Dispose()
            frm = Nothing
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub AccionFichaCertificacion()
        Dim frm As New frmFichaCertificacion
        Try
            frm.idobra = Me.CurrentRow("IDObra")
            frm.ShowDialog()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            frm = Nothing
        End Try
    End Sub

    Private Sub AccionAlbaranGrafojex()
        Dim frm As frmAlbaranGrafojex
        Try
            frm = New frmAlbaranGrafojex 'txtDescObra
            frm.lngIDObraGA = Me.CurrentRow("IDObra")
            frm.lngIDCliente = Nz(advIDClienteFacturacion.Text, advIDCliente.Text)
            frm.ShowDialog()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            frm = Nothing
        End Try
    End Sub

    Private Sub AccionOrdenTrabajo()
        Dim frm As frmOrdenTrabajo
        Try
            frm = New frmOrdenTrabajo 'txtDescObra
            frm.lngIDObraGA = Me.CurrentRow("IDObra")
            frm.lngIDCliente = Nz(advIDClienteFacturacion.Text, advIDCliente.Text)
            frm.ShowDialog()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            frm = Nothing
        End Try
    End Sub
    Private Function borraColumnas(ByVal dt As DataTable)
        dt.Columns.Remove("IDLineaMedicionA")
        dt.Columns.Remove("IdObra")
        dt.Columns.Remove("FechaRef")
        dt.Columns.Remove("SnRecibido")
        dt.Columns.Remove("ESoldado")
        dt.Columns.Remove("Soldado")
        dt.Columns.Remove("ETransporte")
        dt.Columns.Remove("Transporte")
        dt.Columns.Remove("Mallazo")
        dt.Columns.Remove("EMallazo")
        dt.Columns.Remove("ncamion")
        dt.Columns.Remove("ED8")
        dt.Columns.Remove("ED10")
        dt.Columns.Remove("ED12")
        dt.Columns.Remove("ED16")
        dt.Columns.Remove("ED20")
        dt.Columns.Remove("ED25")
        dt.Columns.Remove("ED32")
        dt.Columns.Remove("ncarga")
        dt.Columns.Remove("fproduccion")
        dt.Columns.Remove("FechaAnifer")
        dt.Columns.Remove("PrecioCertElaboracionB")
        dt.Columns.Remove("PrecioCertElaboracion")
        dt.Columns.Remove("NCertificacion")
        dt.Columns.Remove("TotalMediosE")
        dt.Columns.Remove("CertificadoMontaje")
        dt.Columns.Remove("CertificadoMediosE")
        dt.Columns.Remove("TotalMontaje")
        dt.Columns.Remove("TotalSuministro")
        dt.Columns.Remove("CertificadoSuministro")
        dt.Columns.Remove("PrecioCertMediosElevB")
        dt.Columns.Remove("PrecioCertMontajeB")
        dt.Columns.Remove("PrecioCertSuministroB")
        dt.Columns.Remove("MedElaboracion")
        dt.Columns.Remove("Facturable")
        dt.Columns.Remove("Observaciones")
        dt.Columns.Remove("Observaciones2")
        dt.Columns.Remove("Secuencia")
        dt.Columns.Remove("IDUDMedida")
        dt.Columns.Remove("Certificar")
        dt.Columns.Remove("SuministroFacturado")
        dt.Columns.Remove("PrecioCertMediosElev")
        dt.Columns.Remove("PrecioCertSuministro")
        dt.Columns.Remove("PrecioCertMontaje")
        dt.Columns.Remove("DiferenciaP")

        Return dt
    End Function
    'David Velasco 17/05/22
    Private Sub ExportarGridaExcel()
        Dim dt As New DataTable
        dt = Me.GridMediciones.DataSource
        Dim dt2 As New DataTable

        dt2 = borraColumnas(dt)
        Dim oExcel As New Excel.Application
        Dim libro As Excel.Workbook
        Dim hoja As Excel.Worksheet

        Try

            libro = oExcel.Workbooks.Add '.Open(file)

            hoja = libro.Worksheets(1)

            hoja.Name = dt.Rows(0)("NObra")

            Dim r As Integer, c As Integer

            Dim rCount As Integer

            Dim cCount As Integer

            rCount = dt2.Rows.Count

            cCount = dt2.Columns.Count()

            For c = 1 To cCount

                hoja.Cells(1, c) = dt2.Columns(c - 1).Caption 'Set the column title

            Next

            c = 0 : r = 0

            For r = 1 To rCount

                For c = 1 To cCount

                    hoja.Cells(r + 1, c) = CStr(dt2.Rows(r - 1)(c - 1).ToString)

                Next

            Next

            oExcel.Visible = True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        oExcel = Nothing

        libro = Nothing

        hoja = Nothing
    End Sub

    Private Sub AccionAddProduccion()
        Dim Frm As New frmActMedicionesAcero
        Try
            Frm.ShowDialog()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            Frm = Nothing
        End Try
    End Sub

    Private Sub AccionInformeAcero()
        Dim frm As InformeAceroBueno
        Try
            frm = New InformeAceroBueno  'txtDescObra
            frm.lngIDObraGA = Me.CurrentRow("IDObra")
            frm.lngIDCliente = Nz(advIDClienteFacturacion.Text, advIDCliente.Text)
            frm.ShowDialog()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            frm = Nothing
        End Try
    End Sub

    Private Sub AccionInformeMallazo()
        Dim frm As frmInformeMallazo
        Try
            frm = New frmInformeMallazo  'txtDescObra
            frm.lngIDObraGA = Me.CurrentRow("IDObra")
            frm.lngIDCliente = Nz(advIDClienteFacturacion.Text, advIDCliente.Text)
            frm.ShowDialog()
        Catch ex As Exception
            Engine.UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            frm = Nothing
        End Try
    End Sub
    Private Sub ImportarAlbaran()
        '---------Leo el Excel y lo guardo como dataTable
        Dim ruta As String
        Dim hoja As String
        hoja = "Hoja1"
        Dim rango As String = "A2:M100"
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    ruta = openFD.FileName
                    Dim dt As New DataTable
                    dt = ObtenerDatosExcel(ruta, hoja, rango)
                    Dim dt2 As New DataTable
                    dt2.Columns.Add("NObra")
                    dt2.Columns.Add("Estructura")
                    dt2.Columns.Add("Localizacion1")
                    dt2.Columns.Add("Localizacion2")
                    dt2.Columns.Add("numPedido")
                    dt2.Columns.Add("numAlbaran")
                    dt2.Columns.Add("Fecha")
                    dt2.Columns.Add("D8")
                    dt2.Columns.Add("D10")
                    dt2.Columns.Add("D12")
                    dt2.Columns.Add("D16")
                    dt2.Columns.Add("D20")
                    dt2.Columns.Add("D25")
                    dt2.Columns.Add("D32")
                    dt2.Columns.Add("PesoProduccion")
                    dt2.Columns.Add("Albaran")
                    dt2.Columns.Add("PesoFacturacion")

                    Dim dr2 As DataRow
                    Dim suma As Double
                    Dim obra As String
                    Dim numAlbaran As String
                    Dim fech As Date
                    numAlbaran = ""
                    obra = ""
                    For Each dr As DataRow In dt.Rows
                        If IsDBNull(dr(0)) Then
                        Else
                            If IsDBNull(dr(12)) = False Then
                                suma = 0
                                dr2 = dt2.NewRow
                                dr2("NObra") = dr(0)
                                obra = dr2("NObra")
                                Dim descrip As String = dr(1)
                                Dim arrayDescrip() As String
                                arrayDescrip = descrip.Split("_")
                                dr2("Estructura") = arrayDescrip(0)
                                dr2("Localizacion1") = arrayDescrip(1)
                                dr2("Localizacion2") = arrayDescrip(2)
                                dr2("numPedido") = dr(2)
                                numAlbaran = dr(3)
                                dr2("numAlbaran") = dr(3)
                                fech = dr(4)
                                dr2("Fecha") = dr(4)
                                If IsEmptyValue(dr(5)) Then
                                    dr2("D8") = 0
                                    suma += 0
                                Else
                                    dr2("D8") = dr(5)
                                    suma += dr(5)
                                End If
                                If IsEmptyValue(dr(6)) Then
                                    dr2("D10") = 0
                                    suma += 0
                                Else
                                    dr2("D10") = dr(6)
                                    suma += dr(6)
                                End If
                                If IsEmptyValue(dr(7)) Then
                                    dr2("D12") = 0
                                    suma += 0
                                Else
                                    dr2("D12") = dr(7)
                                    suma += dr(7)
                                End If
                                If IsEmptyValue(dr(8)) Then
                                    dr2("D16") = 0
                                    suma += 0
                                Else
                                    dr2("D16") = dr(8)
                                    suma += dr(8)
                                End If
                                If IsEmptyValue(dr(9)) Then
                                    dr2("D20") = 0
                                    suma += 0
                                Else
                                    dr2("D20") = dr(9)
                                    suma += dr(9)
                                End If
                                If IsEmptyValue(dr(10)) Then
                                    dr2("D25") = 0
                                    suma += 0
                                Else
                                    dr2("D25") = dr(10)
                                    suma += dr(10)
                                End If
                                If IsEmptyValue(dr(11)) Then
                                    dr2("D32") = 0
                                    suma += 0
                                Else
                                    dr2("D32") = dr(11)
                                    suma += dr(11)
                                End If
                                dr2("PesoProduccion") = dr(12)
                                dr2("Albaran") = suma
                                dr2("PesoFacturacion") = suma
                                dt2.Rows.Add(dr2)


                                '-------------INSERTAR LINEAS-----------
                                Dim auto As New OperarioCalendario

                                'Obtengo el IDObra
                                Dim obraCab As New ObraCabecera
                                Dim f As New Filter
                                Dim dtobra As New DataTable
                                Dim idob As String

                                f.Add("Nobra", FilterOperator.Equal, obra)
                                dtobra = obraCab.Filter(f, , "IDObra")
                                idob = dtobra(0)("IDObra")


                                'Obtengo El IDLineaMedicionA
                                Dim IdAutonumerico As Long
                                IdAutonumerico = auto.Autonumerico()

                                Dim txtSQL As String
                                txtSQL = "Insert into tbObraMedicionAcero(IDLineaMedicionA, IDObra, Estructura, Localizacion1, Localizacion2," & _
                                "Fecha, D8, D10, D12, D16, D20, D25, D32, PesoPlanilla, PesoPedido, CertificadoSuministro, numAlbaran, numPedido, FacElaboracion, Planilla, NObra, FechaCreacionAudi, FechaModificacionAudi, UsuarioAudi)" & _
                                "Values('" & IdAutonumerico & "','" & idob & "', '" & dr2("Estructura") & "', '" & dr2("Localizacion1") & "', '" & dr2("Localizacion2") & "', '" & _
                                dr2("Fecha") & "', '" & dr2("D8") & "', '" & dr2("D10") & "', '" & dr2("D12") & "', '" & dr2("D16") & "', '" & dr2("D20") & "', '" & dr2("D25") & "', '" & dr2("D32") & "', '" & _
                                dr2("Albaran") & "', '" & dr2("Albaran") & "', '" & dr2("Albaran") & "', '" & dr2("numAlbaran") & "', '" & dr2("numPedido") & "', '" & dr2("Albaran") & "', '" & dr2("PesoProduccion") & "', '" & dr2("NObra") & "', '" & DateTime.Now & "', '" & DateTime.Now & "', '" & ExpertisApp.UserName & "')"
                                auto.Ejecutar(txtSQL)
                                'MessageBox.Show("Linea insertada")


                            End If
                        End If
                    Next
                    Me.RequeryData()
                    '-------AGREGO UNA LINEA PARA EL MALLAZO
                    Dim ask As MsgBoxResult = MsgBox("¿Desea agregar una linea para el mallazo?", MsgBoxStyle.YesNo)
                    If ask = MsgBoxResult.Yes Then
                        Dim frmDatos As New frmOpcionesAlbaran
                        '--Datos que necesito: NObra//numAlbaran//Fecha
                        frmDatos.nobra = obra
                        frmDatos.numAlbaran = numAlbaran
                        frmDatos.fech = fech

                        '--Quito la visibilidad de alambre, transportey peso bascula.
                        frmDatos.txtAlambre.Visible = False
                        frmDatos.lblAlambre.Visible = False
                        frmDatos.txtTransporte.Visible = False
                        frmDatos.lblTransporte.Visible = False
                        frmDatos.txtPesoBascula.Visible = False
                        frmDatos.lblPesoBascula.Visible = False

                        '--Cambio titulo para el cuadro(Frame)
                        frmDatos.Frame1.Text = "Datos para el MALLAZO"

                        frmDatos.ShowDialog()


                    End If
                    Me.RequeryData()
                    '-------AGREGO UNA LINEA PARA EL ALAMBRE
                    Dim ask1 As MsgBoxResult = MsgBox("¿Desea agregar una linea para el alambre?", MsgBoxStyle.YesNo)
                    If ask1 = MsgBoxResult.Yes Then
                        Dim frmDatos As New frmOpcionesAlbaran

                        '--Datos que necesito: NObra//numAlbaran//Fecha
                        frmDatos.nobra = obra
                        frmDatos.numAlbaran = numAlbaran
                        frmDatos.localizacion1 = "Alambre"
                        frmDatos.fech = fech

                        '--Quito la visibilidad de mallazo, transporte y peso bascula.
                        frmDatos.txtMallazo.Visible = False
                        frmDatos.lblMallazo.Visible = False
                        frmDatos.txtTransporte.Visible = False
                        frmDatos.lblTransporte.Visible = False
                        frmDatos.txtPesoBascula.Visible = False
                        frmDatos.lblPesoBascula.Visible = False

                        '--Cambio titulo para el cuadro(Frame)
                        frmDatos.Frame1.Text = "Datos para el ALAMBRE"
                        frmDatos.ShowDialog()

                    End If
                    Me.RequeryData()
                    '-------AGREGO UNA LINEA PARA BASCULA+TRANSPORTE
                    Dim ask2 As MsgBoxResult = MsgBox("¿Desea agregar una linea para la bascula+transporte?", MsgBoxStyle.YesNo)
                    If ask2 = MsgBoxResult.Yes Then
                        Dim frmDatos As New frmOpcionesAlbaran
                        '--Datos que necesito: NObra//numAlbaran//Fecha
                        frmDatos.nobra = obra
                        frmDatos.numAlbaran = numAlbaran
                        frmDatos.estructura = "BASCULA+TRANSPORTE"
                        frmDatos.fech = fech

                        '--Quito la visibilidad de mallazo, transporte y peso bascula.
                        frmDatos.txtMallazo.Visible = False
                        frmDatos.lblMallazo.Visible = False
                        frmDatos.txtAlambre.Visible = False
                        frmDatos.lblAlambre.Visible = False

                        '--Cambio titulo para el cuadro(Frame)
                        frmDatos.Frame1.Text = "Datos para la BASCULA+TRANSPORTE"
                        frmDatos.ShowDialog()
                    End If
                    Me.RequeryData()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)

                End Try
            End If
        End With

    End Sub
    Public Function ObtenerDatosExcel(ByVal ruta As String, ByVal hoja As String, ByVal rango As String) As DataTable
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & ruta & "';Extended Properties='Excel 8.0;HDR=NO'")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & hoja & "$" & rango & "]", MyConnection)
        'MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        Dim dt As DataTable = DtSet.Tables(0)
        MyConnection.Close()

        Return dt

    End Function

    Private Sub AbrirFactura()
        Dim lngIdFactura As Integer
        Dim f As New Filter
        Try
            lngIdFactura = GridCertificaciones.Value(GridCertificaciones.Columns("IdFactura").Index)

            f.Add("IDFactura", lngIdFactura)
            If lngIdFactura = 0 Then
                MessageBox.Show("No se puede abrir la factura. No tiene un factura asociada.", UI.ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'GenerateMessage(1555, vbExclamation, ExpertisApp.Title) 'No se puede abrir la factura. No tiene un factura asociada.
            Else
                If UI.ExpertisApp.IsFormOpen("MFACTV") = False Then
                    UI.ExpertisApp.OpenForm("MFACTV", f, , )
                Else
                    UI.ExpertisApp.CloseForm("MFACTV")
                    UI.ExpertisApp.OpenForm("MFACTV", f, , )
                End If
            End If
        Catch ex As Exception
            UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            f = Nothing
        End Try
    End Sub

    Private Sub AbrirObra()
        Dim f As New Filter
        Try
            f.Add("IDObra", Me.CurrentRow("IDObra"))
            UI.ExpertisApp.OpenForm("MGEO", f)
        Catch ex As Exception
            UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            f = Nothing
        End Try
    End Sub

    Private Sub AccionRecalcularObra()
        Dim rs As DataTable
        Dim strWhere As String
        Dim lngNumero As Long
        Dim txtSQL As String

        Try
            If Len(Me.CurrentRow("IDObra")) > 0 Then
                strWhere = "IdObra= " & Me.CurrentRow("IDObra")

                txtSQL = "sp_RecalcularMedicionesAcero " & Me.CurrentRow("IDObra")
                AdminData.Execute(txtSQL, False)
                'TabPage1_Click(TabPage1, New System.EventArgs)

                MessageBox.Show("Se han Recalculado los Importes ", UI.ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                MessageBox.Show("Debe seleccionar un Proyecto", UI.ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            rs = Nothing
        End Try
    End Sub

    Function FacturadoAnteriormente(ByRef NCertificacion As String, ByRef IdObra As Long) As Double
        'Calcula lo facturado anteriormente a una Certifiación para una obra dada.
        Dim dt As DataTable
        Dim dblNumero As Double = 0
        Dim sSQL As String

        Try
            dt = Nothing
            sSQL = "NCertificacion = " & NCertificacion & " and IdObra = " & IdObra
            'Calculo la suma de las certificaciones anteriores
            dt = AdminData.Filter("vFrmObraCertificacionAcero", , sSQL)

            For Each dr As DataRow In dt.Rows
                'IBIS. David 28Julio2008
                dblNumero = dblNumero + Nz(dt("FacturadoOrigen"), 0)
                'dblNumero = dblNumero + Nz(rs("Facturado"), 0)
            Next

            FacturadoAnteriormente = Nz(dblNumero, 0)
        Catch ex As Exception
            UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            dt = Nothing
        End Try
    End Function

    Private Sub AccionFacturarCertificacion()

        Dim dt As DataTable
        Dim dtTotal As DataTable
        Dim dtLineaCert As DataTable
        Dim dtPropuesta As DataTable
        Dim dtCLiente As DataTable

        Dim FwFVC As FacturaVentaCabecera
        Dim FwFVCLin As FacturaVentaLinea
        Dim fwnEntidadCont As EntidadContador
        Dim DatosCliente As Cliente

        Dim RsCabecera As DataTable
        Dim rsLineas As DataTable

        Dim NFactur As String
        Dim strWhere As String
        Dim lngNumero As String
        Dim txtSQL As String

        Dim dblNumero As Double
        Dim vValor As Double

        Try
            If Len(Nz(advIDClienteFacturacion, 0)) = 0 Then
                UI.ExpertisApp.GenerateMessage("Debe indicar el Cliente para Facturar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                advIDClienteFacturacion.Focus()
                Exit Sub
            End If

            Dim formulario As New frmEntidad
            formulario.ShowDialog()

            lngNumero = formulario.lNumCerti

            'Comprobamos que no este facturada
            dt = AdminData.GetData("SELECT NCertificacionA, NFactura,FechaFactura FROM tbFacturaVentaCabecera WHERE NCertificacionA='" & lngNumero & "' AND idobra='" & Me.CurrentRow("IDObra") & "'")

            If dt.Rows.Count = 0 Then
                MsgBox("La Certificación nº " & Nz(dt("NCertificacionA"), "") & " está certificada" & Chr(13) & Chr(10) _
                & "Con Fecha: " & Nz(dt("FechaFactura")) & " y Número de Factura: " & Nz(dt("Nfactura"), ""), vbExclamation + vbOKOnly, ExpertisApp.Title)
                dt = Nothing
                Exit Sub
            End If

            'Comprobamos que no este facturada
            dt = AdminData.GetData("SELECT NCertificacion FROM tbObraCertificacionesAcero WHERE NCertificacion=" & lngNumero & " and idobra= " & Me.CurrentRow("IDObra"))

            If dt.Rows.Count <> 0 Then
                MsgBox("La Certificación Nº " & lngNumero & " no existe en la Obra " & Me.CurrentRow("IDObra"), vbExclamation, ExpertisApp.Title)
                dt = Nothing
                Exit Sub
            End If

            Dim dttAcero As New DataTable : Dim obj As New ObraCertificacionesAcero : Dim f As New Filter
            f.Add("IDCertificacion", GridCertificaciones.GetValue("IDCertificacion"))
            dttAcero = obj.Filter(f)
            If Not dttAcero Is Nothing AndAlso dttAcero.Rows.Count > 0 Then
                If Not IsDBNull(dttAcero.Rows(0)("IDCertificacionObra")) Then
                    UI.ExpertisApp.GenerateMessage("Esta Certificación está unida a una Obra y no se puede facturar aquí", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            dttAcero = Nothing : obj = Nothing : f = Nothing

            'Calculamos la cantidad total certificada...............................................................
            'Modificación, no coger en facturación las contralíneas.Use 01/12/2008
            strWhere = "IdObra= " & Me.CurrentRow("IDObra") & " and NCertificacion =" & lngNumero & " and Tipo > 0"

            dtTotal = AdminData.Filter("vFrmObraCertificacionAcero", , strWhere)

            For Each dr As DataRow In dtTotal.Rows
                vValor = Nz(dtTotal("Facturado"), 0)
            Next

            'Esto es para que en las lineas de la factura aparezca los trabajos facturados..........................
            'Modificación, no coger en facturación las contralíneas.Use 01/12/2008.
            strWhere = "IdObra= " & Me.CurrentRow("IDObra") & " and  NCertificacion = " & lngNumero & " AND Tipo > 0"
            dtLineaCert = AdminData.Filter("vFrmObraCertificacionAcero", , strWhere)

            'Obtenemos los datos del cliente........................................................................
            DatosCliente = New Cliente
            If IsDBNull(Nz(advIDClienteFacturacion, "")) = True Then
                UI.ExpertisApp.GenerateMessage("Debe indicar el Cliente para poder facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            strWhere = "IdCliente = '" & advIDClienteFacturacion.Value & "'"

            dtCLiente = AdminData.GetData("tbMaestroCliente", , strWhere)
            If dt.Rows.Count = 0 Then
                UI.ExpertisApp.GenerateMessage("El Cliente no existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Pasar datos suministro empresa dyezam a la empresa ferrallas
            'IBIS. David 10/03/08 Pasar datos suministro empresa Ferrallas a la empresa DYEZAM............................
            If UI.ExpertisApp.DataBaseName = "xFerrallas4" Then

                Dim vObra As New SeleccionarObra

                Dim sql As String
                sql = "SELECT tCertificadoSuministro FROM vfrmObraTotalMedicionesacero WHERE IDObra =" & Me.CurrentRow("IDObra")

                Dim dttSuministro As New DataTable
                dttSuministro = AdminData.GetData(sql)

                If Not dttSuministro Is Nothing AndAlso dttSuministro.Rows.Count > 0 Then
                    vObra.Suministro = dttSuministro.Rows(0)(0)
                    vObra.ShowDialog()

                    If vObra.blnCerrar = True Then 'IBIS. David
                        UI.ExpertisApp.GenerateMessage("Proceso Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Else
                    UI.ExpertisApp.GenerateMessage("No existen datos de Suministro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                dttSuministro = Nothing
                vObra.Dispose()
            End If
            '.......................................................................................................

            dblNumero = FacturadoAnteriormente(lngNumero, Me.CurrentRow("IDObra"))

            'Creamos la Factura Venta Cabecera .....................................................................
            If Not dtTotal.Rows.Count <> 0 Then
                fwnEntidadCont = New EntidadContador
                dt = Nothing
                'SERGIO PRUEBA A PARTIR DE AKI
                dt = AdminData.GetData("tbEntidadContador", "IDContador", "Entidad='FacturaVentaCabecera' AND IdContador='" & Nz(formulario.sContador, "") & "'")
                fwnEntidadCont = Nothing

                Dim objFacturaVenta As New FacturaVentaCabecera
                RsCabecera = objFacturaVenta.AddNewForm

                RsCabecera.Rows(0)("Fechafactura") = Today
                RsCabecera.Rows(0)("IDContador") = dt("IDcontador")
                RsCabecera.Rows(0)("IDCliente") = advIDClienteFacturacion
                RsCabecera.Rows(0)("IDMoneda") = "EU"
                RsCabecera.Rows(0)("IDCentroGestion") = mstrIDCGestion

                RsCabecera.Rows(0)("CambioA") = 1
                RsCabecera.Rows(0)("CambioB") = 1

                RsCabecera.Rows(0)("ImpLineas") = Nz(vValor, 0)
                RsCabecera.Rows(0)("ImpLineasA") = Nz(vValor, 0)
                RsCabecera.Rows(0)("ImpLineasB") = Nz(vValor, 0)
                RsCabecera.Rows(0)("ImporteTotalCert") = Nz(vValor, 0)

                RsCabecera.Rows(0)("BaseImponible") = Nz(vValor, 0) - Nz(dblNumero, 0)
                RsCabecera.Rows(0)("BaseImponibleA") = Nz(vValor, 0) - Nz(dblNumero, 0)
                RsCabecera.Rows(0)("BaseImponibleB") = Nz(vValor, 0) - Nz(dblNumero, 0)

                RsCabecera.Rows(0)("IDFormaPago") = Nz(dtCLiente("IDFormaPago"), "")
                RsCabecera.Rows(0)("IDCondicionPago") = Nz(dtCLiente("IDCondicionPago"), "")
                RsCabecera.Rows(0)("RazonSocial") = Nz(dtCLiente("RazonSocial"), "")
                RsCabecera.Rows(0)("CifCliente") = Nz(dtCLiente("CifCliente"), "")
                RsCabecera.Rows(0)("Direccion") = Nz(dtCLiente("Direccion"), "")
                RsCabecera.Rows(0)("CodPostal") = Nz(dtCLiente("CodPostal"), "")
                RsCabecera.Rows(0)("Poblacion") = Nz(dtCLiente("Poblacion"), "")
                RsCabecera.Rows(0)("Provincia") = Nz(dtCLiente("Provincia"), "")
                RsCabecera.Rows(0)("IDPais") = Nz(dtCLiente("IDPais"), "")

                RsCabecera.Rows(0)("NCertificacionA") = lngNumero
                RsCabecera.Rows(0)("FacturadoAnteriormente") = Nz(dblNumero, 0)
                RsCabecera.Rows(0)("IDObra") = Me.CurrentRow("IDObra")

                RsCabecera.Rows(0)("TipoRetencion") = 0
                RsCabecera.Rows(0)("RetencionIRPF") = 5

                RsCabecera.Rows(0)("ImpRetencion") = ImporteRetencion(vValor - Nz(dblNumero, 0), Nz(cmbTipoRetencion, 1))
                RsCabecera.Rows(0)("ImpRetencionA") = ImporteRetencion(vValor - Nz(dblNumero, 0), Nz(cmbTipoRetencion, 1))
                RsCabecera.Rows(0)("ImpRetencionB") = ImporteRetencion(vValor - Nz(dblNumero, 0), Nz(cmbTipoRetencion, 1))

                'RsCabecera.Update()
                Me.Cursor = Cursors.WaitCursor

                objFacturaVenta.Update(RsCabecera)
                objFacturaVenta = Nothing

                'txtSQL = "UPDATE tbFacturaVentaCabecera SET NFacturaExtendida = '" & _
                'RsCabecera.Rows(0)("NFactura") & "/" & Format(Year(Today), 2) & "/" & _
                'Me.CurrentRow("IDObra") & "." & lngNumero & "' WHERE NFactura = '" & RsCabecera.Rows(0)("NFactura") & "'"
                ' Modificación Use 01/12/2008. Formato: NºFactura/Ejer.NºObra.NºCertificación

                Dim sNobra As String = TraerNobra(Me.CurrentRow("IDObra"))
                If sNobra = "-1" Then
                    UI.ExpertisApp.GenerateMessage("Error al localizar Nº de obra, asignación Id de obra.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    sNobra = Nz(Me.CurrentRow("IDObra"), "")
                End If

                txtSQL = "UPDATE tbFacturaVentaCabecera SET NFacturaExtendida = '" & _
                    RsCabecera.Rows(0)("NFactura") & "/" & Strings.Right(Year(Today), 2) & "." & _
                    sNobra & "." & lngNumero & "' WHERE NFactura = '" & RsCabecera.Rows(0)("NFactura") & "'"

                AdminData.Execute(txtSQL, False)

                'Creamos las líneas de la factura...................................................................
                Dim Texto As String
                Dim objFVLinea As New FacturaVentaLinea

                While Not dt.Rows.Count <> 0
                    For Each dr As DataRow In dt.Rows
                        rsLineas = objFVLinea.AddNewForm
                        rsLineas.Rows(0)("IDFactura") = RsCabecera.Rows(0)("IDFactura")
                        rsLineas.Rows(0)("NFactura") = Nz(RsCabecera.Rows(0)("NFactura"), "")
                        rsLineas.Rows(0)("IDCentroGestion") = mstrIDCGestion

                        rsLineas.Rows(0)("IDArticulo") = "PROY"
                        rsLineas.Rows(0)("DescArticulo") = dtLineaCert("Concepto")

                        rsLineas.Rows(0)("IDTipoIva") = strIVA
                        rsLineas.Rows(0)("Cantidad") = IIf(dtLineaCert("Total").Equals(0), 1, dtLineaCert("Total"))

                        rsLineas.Rows(0)("Precio") = Nz(dtLineaCert("Precio"), 0)
                        rsLineas.Rows(0)("PrecioA") = Nz(dtLineaCert("Precio"), 0)
                        rsLineas.Rows(0)("PrecioB") = Nz(dtLineaCert("Precio"), 0)

                        rsLineas.Rows(0)("Importe") = Nz(dtLineaCert("Facturado"), 0)
                        rsLineas.Rows(0)("ImporteA") = Nz(dtLineaCert("Facturado"), 0)
                        rsLineas.Rows(0)("ImporteB") = Nz(dtLineaCert("Facturado"), 0)

                        rsLineas.Rows(0)("IdObra") = dtLineaCert("IdObra")
                        rsLineas.Rows(0)("UdValoracion") = 1
                        rsLineas.Rows(0)("CContable") = "7000000000"

                        rsLineas.Rows(0)("IDUDMedida") = dtLineaCert("IDUdMedida")
                        rsLineas.Rows(0)("IDUdInterna") = dtLineaCert("IDUdMedida")
                    Next
                    objFVLinea.Update(rsLineas)
                End While

                'Creamos una linea con lo facturado anteriormente contra articulo ANT...............................
                rsLineas = Nothing
                rsLineas = objFVLinea.AddNewForm
                rsLineas.Rows(0)("IDFactura") = RsCabecera.Rows(0)("IDFactura")
                rsLineas.Rows(0)("NFactura") = RsCabecera.Rows(0)("NFactura")
                rsLineas.Rows(0)("IDCentroGestion") = mstrIDCGestion

                rsLineas.Rows(0)("IDArticulo") = "ANT"
                rsLineas.Rows(0)("DescArticulo") = "FACTURADO ANTERIORMENTE"

                rsLineas.Rows(0)("IDTipoIva") = strIVA
                rsLineas.Rows(0)("Cantidad") = 1

                rsLineas.Rows(0)("Precio") = Nz(dblNumero, 0) * -1
                rsLineas.Rows(0)("PrecioA") = Nz(dblNumero, 0) * -1
                rsLineas.Rows(0)("PrecioB") = Nz(dblNumero, 0) * -1

                rsLineas.Rows(0)("Importe") = Nz(dblNumero, 0) * -1
                rsLineas.Rows(0)("ImporteA") = Nz(dblNumero, 0) * -1
                rsLineas.Rows(0)("ImporteB") = Nz(dblNumero, 0) * -1

                rsLineas.Rows(0)("IdObra") = Me.CurrentRow("IDObra")
                rsLineas.Rows(0)("UdValoracion") = 1

                rsLineas.Rows(0)("CContable") = "7000000000"
                rsLineas.Rows(0)("IDUDMedida") = "UND"
                rsLineas.Rows(0)("IDUdInterna") = "UND"
                objFVLinea.Update(rsLineas)
                objFVLinea = Nothing
                '...................................................................................................
                'Actualizamos la Factura de Venta
                Dim objFVActualizar As New FacturaVentaCabecera 'IBIS. David
                objFVActualizar.Updated(RsCabecera)
                objFVActualizar = Nothing
                '...................................................................................................

                MsgBox("Factura creada con éxito Nº " & RsCabecera.Rows(0)("NFactura"), vbInformation + vbOKOnly, UI.ExpertisApp.Title)

                txtSQL = "UPDATE tbObraCertificacionesAcero SET IDFactura = " & rsLineas.Rows(0)("IDFactura") _
                & "where idobra = " & Me.CurrentRow("IDObra") & " and NCertificacion = " & Nz(lngNumero, "")

                AdminData.Execute(txtSQL, False)
                Me.Cursor = Cursors.Default
            Else
                MsgBox("La Certificación Nº " & Nz(lngNumero, "") & " no existe", vbExclamation + vbOKOnly, ExpertisApp.Title)
            End If

            dtTotal = Nothing

            Dim dtt As New DataTable
            dtt = GridCertificaciones.DataSource

            If Not dtt Is Nothing AndAlso dtt.Rows.Count > 0 Then
                For Each fila As DataRow In dtt.Rows
                    If fila("NCertificacion") = lngNumero Then
                        GridCertificaciones.SetValue("IDFactura", rsLineas.Rows(0)("IDFactura"))
                    End If
                Next
            End If
            dtt = Nothing
            rsLineas = Nothing

        Catch ex As Exception
            UI.ExpertisApp.GenerateMessage(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AccionFacturaDiametros()
        Dim dt As DataTable
        Dim dtLineaCert As DataTable
        Dim dtTotal As DataTable
        Dim dtPropuesta As DataTable
        Dim dtCLiente As DataTable

        Dim FwFVC As FacturaVentaCabecera
        Dim FwFVCLin As FacturaVentaLinea
        Dim fwnEntidadCont As EntidadContador
        Dim DatosCliente As Cliente

        Dim dDesde, dHasta As Date

        Dim RsCabecera As New DataTable
        Dim rsLineas As New DataTable

        Dim strWhere, NFactur, txtSQL As String

        Dim vValor As Double = 0

        Try
            If Len(Nz(advIDClienteFacturacion, 0)) = 0 Then
                ExpertisApp.GenerateMessage("Debe indicar el Cliente para Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                advIDClienteFacturacion.Focus()
                Exit Sub
            End If

            Dim formulario As New frmFactDiametro
            formulario.ShowDialog()

            'Control de cancelación
            If formulario.bGenerar = False Then Exit Sub

            'Coger las fechas de facturación y realizar última confirmación.......
            dDesde = formulario.Fdesde.Value
            dHasta = formulario.Fhasta.Value

            formulario.Dispose()

            If MsgBox("Se realizará una facturación por diámetros entre " & Format(dDesde, "dd/MM/yyyy") & " y " & Format(dHasta, "dd/MM/yyyy") & ", ¿Desea continuar?", MsgBoxStyle.OkCancel, "Confirmación") = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            'Calculamos la cantidad total certificada..............................
            'Modificación, no coger en facturación las contralíneas. Use 01/12/2008  
            strWhere = "IdObra= " & Me.CurrentRow("IDObra") & " AND Fecha >='" & dDesde & "' AND fecha <='" & dHasta & "'"

            'Traer la filas ordenadas por diámetros,mallazo y transporte. Filas con valor 8, 12....., por eso es DESC.
            dtTotal = AdminData.Filter("vFrmMedicionesObraAcero", , strWhere, , False, False)

            'Conseguimos los datos del cliente.
            DatosCliente = New Cliente
            If IsDBNull(Nz(advIDClienteFacturacion, "")) = True Then
                ExpertisApp.GenerateMessage("Debe indicar el Cliente para poder facturar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            strWhere = "IdCliente = '" & advIDClienteFacturacion.Value & "'"
            dtCLiente = AdminData.GetData("tbMaestroCliente", , strWhere)

            If dt.Rows.Count = 0 Then
                ExpertisApp.GenerateMessage("El Cliente no Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            If Not dt.Rows.Count = 0 Then

                fwnEntidadCont = New EntidadContador
                dt = Nothing

                dt = AdminData.GetData("tbEntidadContador", "IDContador", "Entidad='FacturaVentaCabecera' AND IdContador='" & Nz(formulario.sContador, "") & "'")
                fwnEntidadCont = Nothing

                Dim objFacturaVenta As New FacturaVentaCabecera
                RsCabecera = objFacturaVenta.AddNewForm

                With RsCabecera

                    .Rows(0)("Fechafactura") = Today

                    .Rows(0)("IDContador") = Nz(dt("IDcontador"), "")
                    .Rows(0)("IDCliente") = Nz(advIDClienteFacturacion, "")
                    .Rows(0)("IDMoneda") = "EU"
                    .Rows(0)("IDCentroGestion") = mstrIDCGestion

                    .Rows(0)("CambioA") = 1
                    .Rows(0)("CambioB") = 1

                    .Rows(0)("ImpLineas") = Nz(vValor, 0)
                    .Rows(0)("ImpLineasA") = Nz(vValor, 0)
                    .Rows(0)("ImpLineasB") = Nz(vValor, 0)
                    .Rows(0)("ImporteTotalCert") = Nz(vValor, 0)

                    .Rows(0)("BaseImponible") = Nz(vValor, 0)
                    .Rows(0)("BaseImponibleA") = Nz(vValor, 0)
                    .Rows(0)("BaseImponibleB") = Nz(vValor, 0)

                    .Rows(0)("IDFormaPago") = Nz(dtCLiente("IDFormaPago"), "")
                    .Rows(0)("IDCondicionPago") = Nz(dtCLiente("IDCondicionPago"), "")
                    .Rows(0)("RazonSocial") = Nz(dtCLiente("RazonSocial"), "")
                    .Rows(0)("CifCliente") = Nz(dtCLiente("CifCliente"), "")
                    .Rows(0)("Direccion") = Nz(dtCLiente("Direccion"), "")
                    .Rows(0)("CodPostal") = Nz(dtCLiente("CodPostal"), "")
                    .Rows(0)("Poblacion") = Nz(dtCLiente("Poblacion"), "")
                    .Rows(0)("Provincia") = Nz(dtCLiente("Provincia"), "")
                    .Rows(0)("IDPais") = Nz(dtCLiente("IDPais"), "")

                    .Rows(0)("NCertificacionA") = 0
                    .Rows(0)("FacturadoAnteriormente") = 0
                    .Rows(0)("IDObra") = Me.CurrentRow("IDObra")
                    .Rows(0)("TipoRetencion") = 0

                    'En facturas manuales no se especifica
                    .Rows(0)("RetencionIRPF") = 0

                    '.Rows(0)("ImpRetencion") = ImporteRetencion(vValor, Nz(cmbTipoRetencion, 1))
                    '.Rows(0)("ImpRetencionA") = ImporteRetencion(vValor, Nz(cmbTipoRetencion, 1))
                    '.Rows(0)("ImpRetencionB") = ImporteRetencion(vValor, Nz(cmbTipoRetencion, 1))
                    'Modificación Use 01/12/2008. Formato: NºFactura/Ejer.NºObra.NºCertificación
                    'Obtener el Nº de factura extendida

                    Dim sNobra As String = TraerNobra(Me.CurrentRow("IDObra"))
                    If sNobra = "-1" Then
                        ExpertisApp.GenerateMessage("Error al localizar Nº de obra, asignación Id de Obra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        sNobra = Me.CurrentRow("IDObra")
                    End If

                    .Rows(0)("NFacturaExtendida") = Nz(.Rows(0)("NFactura"), "") & "/" & Strings.Right(Year(Today), 2) & "." & Nz(sNobra, "")

                    ' NFactura contiene la siguiente rev. factura, 1 es la primera, 0 error.
                    NFactur = ContFacturaExtendida(Me.CurrentRow("IDObra"))

                    .Rows(0)("NFacturaExtendida") += "." & NFactur
                    'RsCabecera.Update()

                End With

                Me.Cursor = Cursors.WaitCursor

                objFacturaVenta.Update(RsCabecera)

                Dim Texto As String
                Dim objFVLinea As New FacturaVentaLinea

                rsLineas = objFVLinea.AddNewForm ' Crear el OBJ Linea

                Dim dFila, dFilas() As DataRow
                Dim sMes As String
                sMes = Format(dHasta, "MMMM")
                sMes = UCase(Strings.Left(sMes, 1)) & Strings.Right(sMes, sMes.Length - 1)

                ' 1º Facturación a Origen, Crear las filas de la antigua factura, sino crear la fila de ANT1 = 0
                If LineasFactOrigen(RsCabecera, rsLineas, NFactur) < 0 Then Exit Sub

                'Facturación por diámetros
                With dtTotal
                    While Not dtTotal.Rows.Count = 0
                        For shdim As Short = 0 To 6

                            ' Controlar el diametro
                            Dim sDim As String
                            Select Case shdim
                                Case 0
                                    sDim = "8"
                                Case 1
                                    sDim = "10"
                                Case 2
                                    sDim = "12"
                                Case 3
                                    sDim = "16"
                                Case 4
                                    sDim = "20"
                                Case 5
                                    sDim = "25"
                                Case 6
                                    sDim = "32"
                            End Select

                            ' Sólo facturar si tienen peso e importe
                            If Nz(("D" & sDim), 0) > 0 AndAlso Nz(("ED" & sDim), 0) > 0 Then

                                'Control de Lineas, = diámetro y précio
                                dFilas = rsLineas.Select("Precio= '" & CDec(Nz(("ED" & sDim), 0)) & "' and DescArticulo like('%Suministro de Acero Diámetro " & sDim & " puesto obra " & sMes & "-" & Format(dHasta, "yy") & "')")
                                If dFilas.Length > 0 Then

                                    'Diámetro encontrado
                                    dFila = dFilas(0)
                                    dFila("Cantidad") += Nz(("D" & sDim), 0)
                                    dFila("Importe") += Nz(("D" & sDim), 0) * Nz(("ED" & sDim), 0)
                                    dFila("ImporteA") += Nz(("D" & sDim), 0) * Nz(("ED" & sDim), 0)
                                    dFila("ImporteB") += Nz(("D" & sDim), 0) * Nz(("ED" & sDim), 0)

                                Else

                                    'Nuevo diámetro
                                    dFila = rsLineas.NewRow

                                    'Aplicar las reglas de tabla
                                    dFila.ItemArray = rsLineas.Rows(0).ItemArray

                                    dFila("IDLineaFactura") = AdminData.GetAutoNumeric
                                    dFila("IDFactura") = RsCabecera.Rows(0)("IDFactura")
                                    dFila("NFactura") = Nz(RsCabecera.Rows(0)("NFactura"), "")
                                    dFila("IDCentroGestion") = mstrIDCGestion
                                    dFila("idOrdenLinea") = -1

                                    dFila("IDArticulo") = "PROY"
                                    'Para la ordenación borrar en funcion de ordenar primeros 4 caracteres.
                                    dFila("DescArticulo") = Format(CInt(sDim), "00") & Format(dHasta, "MM") & Format(dHasta, "yy") & "Suministro de Acero Diámetro " & sDim & " puesto obra " & sMes & "-" & Format(dHasta, "yy")
                                    'rsLineas.Rows(0)("DescArticulo") = "Suministro de Acero Diámetro " & sDim & " Ø." & Nz(RsTotal("Estructura"), "SIN ESTRUCTURA") & ":" & Nz(RsTotal("Localizacion1"), "") & " " & Nz(RsTotal("Localizacion2"), "") & "(" & Nz(RsTotal("Fecha"), Today) & ")."
                                    dFila("IDTipoIva") = strIVA
                                    dFila("Cantidad") = Nz(("D" & sDim), 0)

                                    dFila("Precio") = Nz(("ED" & sDim), 0)
                                    dFila("PrecioA") = Nz(("ED" & sDim), 0)
                                    dFila("PrecioB") = Nz(("ED" & sDim), 0)

                                    dFila("Importe") = Nz(("D" & sDim), 0) * Nz(("ED" & sDim), 0)
                                    dFila("ImporteA") = Nz(("D" & sDim), 0) * Nz(("ED" & sDim), 0)
                                    dFila("ImporteB") = Nz(("D" & sDim), 0) * Nz(("ED" & sDim), 0)

                                    dFila("IdObra") = Me.CurrentRow("IDObra")
                                    dFila("UdValoracion") = 1
                                    dFila("CContable") = "7000000000"

                                    dFila("IDUDMedida") = Nz(("IDUdMedida"), "KG")
                                    dFila("IDUdInterna") = Nz(("IDUdMedida"), "KG")
                                    'Añadir a la tabla
                                    rsLineas.Rows.Add(dFila)
                                End If
                            End If
                        Next

                        'Siguiente línea

                    End While

                    'Papa pa tras

                    While Not .Rows.Count = 0

                        'Facturación Elaboración Acero
                        If Nz(("PesoPlanilla"), 0) > 0 AndAlso Nz(("PrecioCertElaboracion"), 0) > 0 Then

                            'Buscar elaboración
                            'Control de Lineas, = précio
                            dFilas = rsLineas.Select("Precio= '" & CDec(Nz(("PrecioCertElaboracion"), 0)) & "' and DescArticulo like('%Elaboración de Acero puesto obra " & sMes & "-" & Format(dHasta, "yy") & "')")

                            If dFilas.Length > 0 Then
                                ' Diámetro encontrado
                                dFila = dFilas(0)
                                dFila("Cantidad") += Nz(("PesoPlanilla"), 0)
                                dFila("Importe") += Nz(("PesoPlanilla"), 0) * Nz(("PrecioCertElaboracion"), 0)
                                dFila("ImporteA") += Nz(("PesoPlanilla"), 0) * Nz(("PrecioCertElaboracion"), 0)
                                dFila("ImporteB") += Nz(("PesoPlanilla"), 0) * Nz(("PrecioCertElaboracion"), 0)
                            Else
                                dFila = rsLineas.NewRow
                                ' Aplicar las reglas de tabla
                                dFila.ItemArray = rsLineas.Rows(0).ItemArray
                                dFila("IDLineaFactura") = AdminData.GetAutoNumeric
                                dFila("IDFactura") = RsCabecera.Rows(0)("IDFactura")
                                dFila("NFactura") = Nz(RsCabecera.Rows(0)("NFactura"), "")
                                dFila("IDCentroGestion") = mstrIDCGestion
                                dFila("idOrdenLinea") = -1

                                dFila("IDArticulo") = "PROY"
                                dFila("DescArticulo") = "00" & Format(dHasta, "MM") & Format(dHasta, "yy") & "Elaboración de Acero puesto obra " & sMes & "-" & Format(dHasta, "yy")

                                dFila("IDTipoIva") = strIVA
                                dFila("Cantidad") = Nz(("PesoPlanilla"), 0)

                                dFila("Precio") = Nz(("PrecioCertElaboracion"), 0)
                                dFila("PrecioA") = Nz(("PrecioCertElaboracion"), 0)
                                dFila("PrecioB") = Nz(("PrecioCertElaboracion"), 0)

                                dFila("Importe") = Nz(("PesoPlanilla"), 0) * Nz(("PrecioCertElaboracion"), 0)
                                dFila("ImporteA") = Nz(("PesoPlanilla"), 0) * Nz(("PrecioCertElaboracion"), 0)
                                dFila("ImporteB") = Nz(("PesoPlanilla"), 0) * Nz(("PrecioCertElaboracion"), 0)

                                dFila("IdObra") = Me.CurrentRow("IDObra")
                                dFila("UdValoracion") = 1
                                dFila("CContable") = "7050000000"

                                dFila("IDUDMedida") = Nz(("IDUdMedida"), "KG")
                                dFila("IDUdInterna") = Nz(("IDUdMedida"), "KG")
                                ' Añadir a la tabla
                                rsLineas.Rows.Add(dFila)
                            End If
                        End If

                        'Facturación Mallazo
                        If Nz(("Mallazo"), 0) > 0 AndAlso Nz(("EMallazo"), 0) > 0 Then

                            ' Control de Lineas, = precio
                            dFilas = rsLineas.Select("Precio= '" & CDec(Nz(("EMallazo"), 0)) & "' and DescArticulo like('%Mallazo&" & sMes & "-" & Format(dHasta, "yy") & "')")

                            If dFilas.Length > 0 Then
                                ' Diámetro encontrado
                                dFila = dFilas(0)
                                dFila("Cantidad") += Nz(("Mallazo"), 0)
                                dFila("Importe") += Nz(("Mallazo"), 0) * Nz(("EMallazo"), 0)
                                dFila("ImporteA") += Nz(("Mallazo"), 0) * Nz(("EMallazo"), 0)
                                dFila("ImporteB") += Nz(("Mallazo"), 0) * Nz(("EMallazo"), 0)
                            Else
                                dFila = rsLineas.NewRow
                                ' Aplicar las reglas de tabla
                                dFila.ItemArray = rsLineas.Rows(0).ItemArray
                                dFila("IDLineaFactura") = AdminData.GetAutoNumeric
                                dFila("IDFactura") = RsCabecera.Rows(0)("IDFactura")
                                dFila("NFactura") = RsCabecera.Rows(0)("NFactura")

                                dFila("IDCentroGestion") = mstrIDCGestion
                                dFila("idOrdenLinea") = -1

                                dFila("IDArticulo") = "PROY"
                                dFila("DescArticulo") = "00" & Format(dHasta, "MM") & Format(dHasta, "yy") & Nz(("Estructura"), "Mallazo") & " " & Nz(("Localizacion1"), "") & " " & sMes & "-" & Format(dHasta, "yy")
                                dFila("IDTipoIva") = strIVA
                                dFila("Cantidad") = Nz(("Mallazo"), 0)

                                dFila("Precio") = Nz(("EMallazo"), 0)
                                dFila("PrecioA") = Nz(("EMallazo"), 0)
                                dFila("PrecioB") = Nz(("EMallazo"), 0)

                                dFila("Importe") = Nz(("Mallazo"), 0) * Nz(("EMallazo"), 0)
                                dFila("ImporteA") = Nz(("Mallazo"), 0) * Nz(("EMallazo"), 0)
                                dFila("ImporteB") = Nz(("Mallazo"), 0) * Nz(("EMallazo"), 0)

                                dFila("IdObra") = Me.CurrentRow("IDObra")
                                dFila("UdValoracion") = 1
                                dFila("CContable") = "7050000000"

                                dFila("IDUDMedida") = Nz(("IDUdMedida"), "M2")
                                dFila("IDUdInterna") = Nz(("IDUdMedida"), "M2")
                                'Añadir a la tabla
                                rsLineas.Rows.Add(dFila)
                            End If
                        End If

                        'Facturación Transporte
                        If Nz(("Transporte"), 0) > 0 AndAlso Nz(("ETransporte"), 0) > 0 Then

                            'Buscar elaboración
                            'Control de Lineas, = précio
                            'Modificación 07/04/2010 Roberto, Facturar transporte año 4 cifras
                            dFilas = rsLineas.Select("Precio= '" & CDec(Nz(("ETransporte"), 0)) & "' and DescArticulo like('%TRANSPORTE DE ACERO A OBRA MES:" & sMes & "-" & Format(dHasta, "yyyy") & "')")

                            If dFilas.Length > 0 Then
                                'Diámetro encontrado
                                dFila = dFilas(0)
                                dFila("Cantidad") += Nz(("Transporte"), 0)
                                dFila("Importe") += Nz(("Transporte"), 0) * Nz(("ETransporte"), 0)
                                dFila("ImporteA") += Nz(("Transporte"), 0) * Nz(("ETransporte"), 0)
                                dFila("ImporteB") += Nz(("Transporte"), 0) * Nz(("ETransporte"), 0)
                            Else

                                dFila = rsLineas.NewRow
                                ' Aplicar las reglas de tabla
                                dFila.ItemArray = rsLineas.Rows(0).ItemArray
                                dFila("IDLineaFactura") = AdminData.GetAutoNumeric
                                dFila("IDFactura") = RsCabecera.Rows(0)("IDFactura")
                                dFila("NFactura") = RsCabecera.Rows(0)("NFactura")
                                dFila("IDCentroGestion") = mstrIDCGestion
                                dFila("idOrdenLinea") = -1

                                dFila("IDArticulo") = "TA"
                                dFila("DescArticulo") = "00" & Format(dHasta, "MM") & Format(dHasta, "yy") & "TRANSPORTE DE ACERO A OBRA MES:" & sMes & "-" & Format(dHasta, "yyyy")
                                dFila("IDTipoIva") = strIVA
                                dFila("Cantidad") = Nz(("Transporte"), 0)

                                dFila("Precio") = Nz(("ETransporte"), 0)
                                dFila("PrecioA") = Nz(("ETransporte"), 0)
                                dFila("PrecioB") = Nz(("ETransporte"), 0)

                                dFila("Importe") = Nz(("Transporte"), 0) * Nz(("ETransporte"), 0)
                                dFila("ImporteA") = Nz(("Transporte"), 0) * Nz(("ETransporte"), 0)
                                dFila("ImporteB") = Nz(("Transporte"), 0) * Nz(("ETransporte"), 0)

                                dFila("IdObra") = Me.CurrentRow("IDObra")
                                dFila("UdValoracion") = 1
                                dFila("CContable") = "7050000000"

                                dFila("IDUDMedida") = Nz(("IDUdMedida"), "UND")
                                dFila("IDUdInterna") = Nz(("IDUdMedida"), "UND")
                                ' Añadir a la tabla
                                rsLineas.Rows.Add(dFila)

                            End If
                        End If

                        'Facturación Soldado
                        If Nz(("Soldado"), 0) > 0 AndAlso Nz(("ESoldado"), 0) > 0 Then

                            ' Buscar elaboración
                            ' Control de Lineas, = précio
                            dFilas = rsLineas.Select("Precio= '" & CDec(Nz(("ESoldado"), 0)) & "' and DescArticulo like('%Acero soldado " & sMes & "-" & Format(dHasta, "yy") & "')")

                            If dFilas.Length > 0 Then
                                ' Diámetro encontrado
                                dFila = dFilas(0)
                                dFila("Cantidad") += Nz(("Soldado"), 0)

                                dFila("Importe") += Nz(("Soldado"), 0) * Nz(("ESoldado"), 0)
                                dFila("ImporteA") += Nz(("Soldado"), 0) * Nz(("ESoldado"), 0)
                                dFila("ImporteB") += Nz(("Soldado"), 0) * Nz(("ESoldado"), 0)
                            Else
                                dFila = rsLineas.NewRow

                                ' Aplicar las reglas de tabla
                                dFila.ItemArray = rsLineas.Rows(0).ItemArray
                                dFila("IDLineaFactura") = AdminData.GetAutoNumeric
                                dFila("IDFactura") = RsCabecera.Rows(0)("IDFactura")
                                dFila("NFactura") = RsCabecera.Rows(0)("NFactura")

                                dFila("IDCentroGestion") = mstrIDCGestion
                                dFila("idOrdenLinea") = -1

                                dFila("IDArticulo") = "PROY"
                                dFila("DescArticulo") = "00" & Format(dHasta, "MM") & Format(dHasta, "yy") & "Acero soldado " & sMes & "-" & Format(dHasta, "yy")
                                dFila("IDTipoIva") = strIVA
                                dFila("Cantidad") = Nz(("Soldado"), 0)

                                dFila("Precio") = Nz(("ESoldado"), 0)
                                dFila("PrecioA") = Nz(("ESoldado"), 0)
                                dFila("PrecioB") = Nz(("ESoldado"), 0)

                                dFila("Importe") = Nz(("Soldado"), 0) * Nz(("ESoldado"), 0)
                                dFila("ImporteA") = Nz(("Soldado"), 0) * Nz(("ESoldado"), 0)
                                dFila("ImporteB") = Nz(("Soldado"), 0) * Nz(("ESoldado"), 0)

                                dFila("IdObra") = Me.CurrentRow("IDObra")
                                dFila("UdValoracion") = 1
                                dFila("CContable") = "7050000000"

                                dFila("IDUDMedida") = Nz(("IDUdMedida"), "KG")
                                dFila("IDUdInterna") = Nz(("IDUdMedida"), "KG")
                                ' Añadir a la tabla
                                rsLineas.Rows.Add(dFila)
                            End If
                        End If

                        ' Siguiente línea
                    End While

                End With

                dtTotal = Nothing

                'Borrar la primera linea
                rsLineas.Rows(0).Delete()
                If rsLineas.Rows.Count > 0 AndAlso Not IsDBNull(rsLineas.Rows(0)("IDFactura")) Then

                    ' Función de ordenación
                    If OrdenarDet(rsLineas) < 0 Then
                        Exit Sub
                    End If

                    ' Recálculo de cabecera
                    If CalculaCab(vValor, RsCabecera, rsLineas) < 0 Then
                        Exit Sub
                    Else
                        objFacturaVenta.Update(RsCabecera)
                    End If

                    ' Por último actualizar
                    objFVLinea.Update(rsLineas)
                End If

                objFVLinea = Nothing
                objFacturaVenta = Nothing

                'IBIS. David
                Dim objFVActualizar As New FacturaVentaCabecera
                objFVActualizar.Updated(RsCabecera)
                objFVActualizar = Nothing
                '----------------------------------------------

                MsgBox("Factura creada con éxito Nº " & Nz(RsCabecera.Rows(0)("NFactura"), ""), vbInformation + vbOKOnly, ExpertisApp.Title)
            Else
                ExpertisApp.GenerateMessage("No existen lineas de medición entre esas fechas para realizar una facturación por diámetros.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        Finally
            RsCabecera = Nothing
            rsLineas = Nothing
            dtTotal = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Function ImporteRetencion(ByRef Base As Double, ByRef Tipo As Integer) As Double
        Try
            If Tipo = 1 Then 'Sobre B.I
                ImporteRetencion = Nz(Base, 0) * Nz(pRetencion, 0)
            Else 'Sobre Total
                ImporteRetencion = (Nz(Base, 0) + (Nz(Base, 0) * Nz(pIVA, 0))) * Nz(pRetencion, 0)
            End If
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function

    Private Sub AccionCertificar()
        Dim f As Filter
        Dim f2 As Filter
        Dim dt As DataTable
        Dim strWhere As String
        Dim lngNumero As Long
        Dim txtSQL As String
        Dim art As ArticuloNSerie

        Try
            If IsDBNull(Me.CurrentRow("IDObra")) = False Then

                strWhere = "IdObra= " & Me.CurrentRow("IDObra")
                f.Add("vFrmObraTotalMedicionesAceroMes", FilterOperator.Equal, strWhere)
                dt = art.Filter(f)

                If Not dt.Rows.Count = 0 Then

                    Dim frmSeleccionarCertif As New SeleccionarCertificacion
                    frmSeleccionarCertif.IDObra = Me.CurrentRow("IDObra")
                    'IBIS. David
                    frmSeleccionarCertif.UL1.Text = txtNObra.Text
                    frmSeleccionarCertif.UL2.Text = txtDescObra.Text

                    frmSeleccionarCertif.ShowDialog()

                    If frmSeleccionarCertif.unirCertif = 1 Then

                        '###################################################################################################
                        'UNIR CERTIFICACIONES ##############################################################################
                        '###################################################################################################

                        lngNumero = NumeroCertificacion()
                        ' Utilizar función V. Basic. 09/12/2008
                        'txtSQL = "sp_GenerarObraCertificacionAcero "
                        'txtSQL = txtSQL & rs("IDObra") & ","
                        'txtSQL = txtSQL & lngNumero & ", 2 ,"
                        'txtSQL = txtSQL & "1," & frmSeleccionarCertif.Certificacion
                        'AdminData.Execute(txtSQL, False)

                        Try
                            'Dejar certificación ibis para auditoria,04/02/2009
                            If Certificar(lngNumero, frmSeleccionarCertif) < 0 Then
                                Return
                            End If

                            Dim rscertificacionesAcero As New DataTable

                            f2.Add("IdObra", FilterOperator.Equal, dt("IDObra"))
                            f2.Add("NCertificacion", FilterOperator.Equal, lngNumero)
                            f2.Add("IdCertificacionObra", FilterOperator.NotEqual, DBNull.Value)

                            rscertificacionesAcero = art.Filter(f2)
                            If rscertificacionesAcero.Rows.Count > 0 Then

                                'Creamos un trabajo ACERO en donde le meteremos las mediciones ******************************
                                Dim objOT As New ObraTrabajo
                                Dim rsTrabajo As New DataTable
                                rsTrabajo = objOT.AddNewForm

                                With rsTrabajo

                                    .Rows(0)("IDTrabajo") = AdminData.GetAutoNumeric
                                    .Rows(0)("IDObra") = dt("IDObra")
                                    .Rows(0)("IDTipoTrabajo") = "ACERO"
                                    .Rows(0)("IDSubTipoTrabajo") = "ACEROSUB"
                                    .Rows(0)("CodTrabajo") = "ACERO"
                                    .Rows(0)("DescTrabajo") = "Trabajo venido de Acero"

                                    .Rows(0)("Solape") = 0
                                    .Rows(0)("Estado") = 0
                                    .Rows(0)("ImpPrevMatA") = 0
                                    .Rows(0)("ImpPrevModA") = 0
                                    .Rows(0)("ImpPrevGastosA") = 0
                                    .Rows(0)("ImpPrevVariosA") = 0
                                    .Rows(0)("ImpPrevCentrosA") = 0
                                    .Rows(0)("ImpPrevMatB") = 0
                                    .Rows(0)("ImpPrevModB") = 0
                                    .Rows(0)("ImpPrevGastosB") = 0
                                    .Rows(0)("ImpPrevVariosB") = 0
                                    .Rows(0)("ImpPrevCentrosB") = 0
                                    .Rows(0)("ImpRealMatA") = 0
                                    .Rows(0)("ImpRealModA") = 0
                                    .Rows(0)("ImpRealGastosA") = 0
                                    .Rows(0)("ImpRealVariosA") = 0
                                    .Rows(0)("ImpRealCentrosA") = 0
                                    .Rows(0)("ImpRealMatB") = 0
                                    .Rows(0)("ImpRealModB") = 0
                                    .Rows(0)("ImpRealGastosB") = 0
                                    .Rows(0)("ImpRealVariosB") = 0
                                    .Rows(0)("ImpRealCentrosB") = 0
                                    .Rows(0)("DuracionPrev") = 0
                                    .Rows(0)("EstadoFactura") = 0
                                    .Rows(0)("AvanceEstimado") = 0
                                    .Rows(0)("AvanceCalculado") = 0
                                    .Rows(0)("ImpPrevMatVentaA") = 0
                                    .Rows(0)("ImpPrevModVentaA") = 0
                                    .Rows(0)("ImpPrevCentrosVentaA") = 0
                                    .Rows(0)("ImpPrevGastosVentaA") = 0
                                    .Rows(0)("ImpPrevVariosVentaA") = 0
                                    .Rows(0)("ImpPrevMatVentaB") = 0
                                    .Rows(0)("ImpPrevModVentaB") = 0
                                    .Rows(0)("ImpPrevCentrosVentaB") = 0
                                    .Rows(0)("ImpPrevGastosVentaB") = 0
                                    .Rows(0)("ImpPrevVariosVentaB") = 0
                                    .Rows(0)("MargenPrevTrabajo") = 0
                                    .Rows(0)("ImpPrevTrabajoVentaA") = 0
                                    .Rows(0)("ImpPrevTrabajoVentaB") = 0
                                    .Rows(0)("MargenRealTrabajo") = 0
                                    .Rows(0)("Facturable") = 0
                                    .Rows(0)("ImpFactGastosB") = 0
                                    .Rows(0)("ImpFactVariosB") = 0
                                    .Rows(0)("ImpFactTrabajoB") = 0
                                    .Rows(0)("ImpFactVariosA") = 0
                                    .Rows(0)("ImpFactTrabajoA") = 0
                                    .Rows(0)("MargenRealMat") = 0
                                    .Rows(0)("MargenRealMod") = 0
                                    .Rows(0)("MargenRealCentros") = 0
                                    .Rows(0)("MargenRealGastos") = 0
                                    .Rows(0)("MargenRealVarios") = 0
                                    'IBIS. David. Tipo Facuracion : Por certificacion
                                    .Rows(0)("TipoFacturacion") = 3
                                    .Rows(0)("ImpFactMatB") = 0
                                    .Rows(0)("ImpFactModB") = 0
                                    .Rows(0)("ImpFactCentrosB") = 0
                                    .Rows(0)("MargenPrevMat") = 0
                                    .Rows(0)("MargenPrevMod") = 0
                                    .Rows(0)("MargenPrevCentros") = 0
                                    .Rows(0)("MargenPrevGastos") = 0
                                    .Rows(0)("MargenPrevVarios") = 0
                                    .Rows(0)("ImpFactMatA") = 0
                                    .Rows(0)("ImpFactCentrosA") = 0
                                    .Rows(0)("ImpFactGastosA") = 0
                                    .Rows(0)("QPrev") = 0
                                    .Rows(0)("QReal") = 0
                                    .Rows(0)("QFact") = 0
                                    .Rows(0)("ImpPrevQTrabajoA") = 0
                                    .Rows(0)("ImpPrevQTrabajoB") = 0
                                    .Rows(0)("ImpPrevQTrabajoVentaA") = 0
                                    .Rows(0)("ImpPrevQTrabajoVentaB") = 0
                                    .Rows(0)("ImpRealQTrabajoA") = 0
                                    .Rows(0)("ImpRealQTrabajoB") = 0
                                    .Rows(0)("ImpFactQTrabajoA") = 0
                                    .Rows(0)("ImpFactQTrabajoB") = 0
                                    .Rows(0)("NoAcumular") = 0
                                    .Rows(0)("ImpPrevQMatA") = 0
                                    .Rows(0)("ImpPrevQModA") = 0
                                    .Rows(0)("ImpPrevQCentrosA") = 0
                                    .Rows(0)("ImpPrevQGastosA") = 0
                                    .Rows(0)("ImpPrevQVariosA") = 0
                                    .Rows(0)("ImpPrevQMatVentaA") = 0
                                    .Rows(0)("ImpPrevQModVentaA") = 0
                                    .Rows(0)("ImpPrevQCentrosVentaA") = 0
                                    .Rows(0)("ImpPrevQGastosVentaA") = 0
                                    .Rows(0)("ImpPrevQVariosVentaA") = 0
                                    .Rows(0)("ImpPrevQMatB") = 0
                                    .Rows(0)("ImpPrevQModB") = 0
                                    .Rows(0)("ImpPrevQCentrosB") = 0
                                    .Rows(0)("ImpPrevQGastosB") = 0
                                    .Rows(0)("ImpPrevQVariosB") = 0
                                    .Rows(0)("ImpPrevQMatVentaB") = 0
                                    .Rows(0)("ImpPrevQModVentaB") = 0
                                    .Rows(0)("ImpPrevQCentrosVentaB") = 0
                                    .Rows(0)("ImpPrevQGastosVentaB") = 0
                                    .Rows(0)("ImpPrevQVariosVentaB") = 0
                                    .Rows(0)("QTotalCertificada") = 0
                                    .Rows(0)("ListaMaterial") = 0
                                    .Rows(0)("TipoFactAlquiler") = 0
                                    .Rows(0)("TipoCosteDI") = 0
                                    .Rows(0)("QPedida") = 0
                                    .Rows(0)("TipoLinea") = 0
                                    .Rows(0)("Fianza") = 0
                                    .Rows(0)("FianzaContabilizada") = 0
                                    .Rows(0)("FianzaCompensada") = 0
                                    .Rows(0)("Traspasada") = 0

                                End With

                                objOT.Update(rsTrabajo)
                                '##########################################################################################
                                'Insertamos las mediciones
                                Dim objOM As New ObraMedicion
                                Dim rsMediciones As New DataTable

                                'rscertificacionesAcero.MoveFirst()
                                For Each filaCertif As DataRow In rscertificacionesAcero.Rows
                                    'While rscertificacionesAcero.EOF = False
                                    rsMediciones = objOM.AddNewForm
                                    rsMediciones.Rows(0)("IDLineaMedicion") = AdminData.GetAutoNumeric
                                    rsMediciones.Rows(0)("IDObra") = rsTrabajo.Rows(0)("IDObra")
                                    rsMediciones.Rows(0)("IDTrabajo") = rsTrabajo.Rows(0)("IDTrabajo")
                                    rsMediciones.Rows(0)("DescMedicion") = filaCertif("Concepto")
                                    rsMediciones.Rows(0)("QPI") = filaCertif("Total")
                                    rsMediciones.Rows(0)("Largo") = 1
                                    rsMediciones.Rows(0)("Alto") = 1
                                    rsMediciones.Rows(0)("Ancho") = 1
                                    rsMediciones.Rows(0)("Certificar") = 1
                                    rsMediciones.Rows(0)("Total") = filaCertif("Total")
                                    objOM.Update(rsMediciones)
                                    'rscertificacionesAcero.MoveNext()
                                    'End While
                                Next
                                '##########################################################################################
                                'Insertamos la certificacion del trabajo
                                Dim objOCT As New ObraCertificacionTrabajo
                                Dim rsT As New DataTable
                                rsT = objOCT.AddNewForm

                                rsT.Rows(0)("IDLineaCertificacionTrabajo") = AdminData.GetAutoNumeric
                                rsT.Rows(0)("IDCertificacion") = rscertificacionesAcero.Rows(0)("IDCertificacionObra")
                                rsT.Rows(0)("IDObra") = dt("IDObra")
                                rsT.Rows(0)("IDTrabajo") = rsTrabajo.Rows(0)("IDTrabajo")
                                rsT.Rows(0)("QPI") = 0 'rscertificacionesAcero.Rows(0)("Mes")
                                rsT.Rows(0)("PIOrigen") = 0 'rscertificacionesAcero.Rows(0)("Origen")
                                rsT.Rows(0)("PIPorcOrigen") = 0 '((rscertificacionesAcero.Rows(0)("Origen") * 100) / _
                                'rscertificacionesAcero.Rows(0)("Total"))
                                rsT.Rows(0)("PIPorc") = 0 '100 - rsT.Rows(0)("PIPorcOrigen")
                                rsT.Rows(0)("Total") = 0 'rscertificacionesAcero.Rows(0)("Total")
                                rsT.Rows(0)("TipoCertificacion") = 0

                                objOCT.Update(rsT)
                                '##########################################################################################
                                'Y pa liarla deltoya lo metemos en ObraCertificacionMedicion
                                Dim objOCM As New ObraCertificacionMedicion
                                Dim rsOCM As New DataTable
                                'rscertificacionesAcero.MoveFirst()
                                For Each filaAcero As DataRow In rscertificacionesAcero.Rows
                                    'While rscertificacionesAcero.EOF = False
                                    rsOCM = objOCM.AddNewForm

                                    rsOCM.Rows(0)("IDLineaCertificacion") = AdminData.GetAutoNumeric
                                    rsOCM.Rows(0)("IDTrabajo") = rsTrabajo.Rows(0)("IDTrabajo")
                                    rsOCM.Rows(0)("IDCertificacion") = filaAcero("IDCertificacionObra")
                                    rsOCM.Rows(0)("IDLineaCertificacionTrabajo") = rsT.Rows(0)("IDLineaCertificacionTrabajo")
                                    rsOCM.Rows(0)("IDLineaMedicion") = rsMediciones.Rows(0)("IDLineaMedicion")
                                    rsOCM.Rows(0)("DescMedicion") = rsMediciones.Rows(0)("DescMedicion")
                                    rsOCM.Rows(0)("Largo") = 1
                                    rsOCM.Rows(0)("Alto") = 1
                                    rsOCM.Rows(0)("Ancho") = 1
                                    rsOCM.Rows(0)("QPI") = filaAcero("Mes")
                                    rsOCM.Rows(0)("PIOrigen") = filaAcero("Total")
                                    If filaAcero("Total") = 0 Then
                                        rsOCM.Rows(0)("PIPorcOrigen") = 0
                                        rsOCM.Rows(0)("PIPorc") = 0
                                    Else
                                        rsOCM.Rows(0)("PIPorcOrigen") = (((filaAcero("Total") - filaAcero("Mes")) * 100) / filaAcero("Total"))
                                        rsOCM.Rows(0)("PIPorc") = 100 - rsT.Rows(0)("PIPorcOrigen")
                                    End If
                                    rsOCM.Rows(0)("Total") = filaAcero("Total")
                                    rsOCM.Rows(0)("TipoCertificacion") = 0

                                    objOCM.Update(rsOCM)
                                    'rscertificacionesAcero.MoveNext()
                                    'End While
                                Next

                                rscertificacionesAcero = Nothing
                                objOCM = Nothing
                                rsT = Nothing
                                objOCT = Nothing
                                rsMediciones = Nothing
                                objOM = Nothing
                                objOT = Nothing
                                rsTrabajo = Nothing

                                MsgBox("Se ha generado la Certificación Nº " & lngNumero, vbInformation + vbOKOnly, ExpertisApp.Title)
                                Me.Requery.InvokeOnClick()
                            End If

                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try

                    ElseIf frmSeleccionarCertif.unirCertif = 0 Then

                        '###################################################################################################
                        'CREAR CERTIFICACIONES #############################################################################
                        '###################################################################################################
                        lngNumero = NumeroCertificacion()

                        'Utilizar función V. Basic para certificar. Dejar certificación IBIS para auditoria 04/02/2009
                        If Certificar(lngNumero, frmSeleccionarCertif) < 0 Then
                            Return
                        End If

                        MsgBox("Se ha generado la Certificación Nº " & lngNumero, vbInformation + vbOKOnly, ExpertisApp.Title)
                        Me.Requery.InvokeOnClick()

                    Else
                        MessageBox.Show("Proceso Cancelado", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                    GridMediciones.Refresh()
                    GridCertificaciones.Refresh()
                Else
                    MsgBox("No tiene ninguna Certificación en las Mediciones o no ha marcado la columna Certificar", vbExclamation + vbOKOnly, ExpertisApp.Title)
                End If
            Else
                MsgBox("Debe seleccionar un Proyecto", vbInformation + vbOKOnly, ExpertisApp.Title)
            End If

            dt = Nothing
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Function NumeroCertificacion() As Long
        Dim dt As DataTable
        Dim dr As DataRow
        Dim f As Filter
        Dim cont As Integer
        Try

            dt = AdminData.Filter("vMaxtbObraCertificacionesAcero", , "IdObra=" & Me.CurrentRow("IDObra"))
            If dt.Rows.Count = 0 Then
                NumeroCertificacion = IIf(IsDBNull(dt("Numero")), 1, dr("Numero").Value + 1)
            Else
                NumeroCertificacion = 1
            End If
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        Finally
            dt = Nothing
        End Try
    End Function

    Private Sub AccionRecalcularCertificacion()
        Dim dt As DataTable
        Dim strWhere As String
        Dim lngNumero As Long
        Dim txtSQL As String
        Dim strNumero As String
        Try
            strNumero = Nz(InputBox("Indique Nº de Certificación", "Nº de Certificación"), 0)
            If IsNumeric(strNumero) And IsDBNull(Me.CurrentRow("IDObra")) = False Then
                lngNumero = strNumero
                strWhere = "IdObra= " & Me.CurrentRow("IDObra") & " and idFactura = 0"
                If lngNumero >= 1 Then
                    dt = AdminData.Filter("tbObraCertificacionesAcero", , strWhere)
                    If dt.Rows.Count > 0 Then

                        txtSQL = "sp_RecalcularObraCertificacionAcero "
                        txtSQL = txtSQL & Me.CurrentRow("IDObra") & ","
                        txtSQL = txtSQL & lngNumero & ""
                        AdminData.Execute(txtSQL, False)
                        MsgBox("Se ha Recalculado la Certificación Nº " & lngNumero, vbInformation + vbOKOnly, ExpertisApp.Title)
                        GridMediciones.Refresh()
                        GridCertificaciones.Refresh()

                    Else
                        MsgBox("No existe Certificación con el Nº " & lngNumero & " o ya ha sido Facturada ", vbInformation + vbOKOnly, ExpertisApp.Title)
                    End If
                Else
                    MsgBox("No tiene ninguna Certificación con el Nº " & lngNumero & " ", vbExclamation + vbOKOnly, ExpertisApp.Title)
                End If
            Else
                MsgBox("Debe Indicar un Número de Certificación Existente", vbInformation + vbOKOnly, ExpertisApp.Title)
            End If

            dt = Nothing
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub AccionAnularCertificar()
        Dim dt As DataTable
        Dim strWhere As String
        Dim lngNumero As Long
        Dim txtSQL As String
        Try
            If IsDBNull(Me.CurrentRow("IDObra")) = False Then
                strWhere = "IdObra= " & Me.CurrentRow("IDObra") & " and idFactura = 0"

                If Nz(GridCertificaciones.GetValue("IDFactura"), 0) <> 0 Then
                    MessageBox.Show("No se puede anular una Certificación facturada", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                lngNumero = NumeroCertificacion() - 1
                If lngNumero >= 1 Then

                    dt = AdminData.Filter("tbObraCertificacionesAcero", , strWhere)
                    If dt.Rows.Count > 0 Then

                        txtSQL = "sp_AnularObraCertificacionAcero "
                        txtSQL = txtSQL & Me.CurrentRow("IDObra") & ","
                        txtSQL = txtSQL & lngNumero & ""
                        AdminData.Execute(txtSQL, False)
                        MsgBox("Se ha Anulado la Certificación Nº " & lngNumero, vbInformation + vbOKOnly, ExpertisApp.Title)

                        GridMediciones.Refresh()
                        GridCertificaciones.Refresh()
                        Me.Requery.InvokeOnClick()
                    Else
                        MsgBox("No existe Certificación para anular o la última Certificación ha sido Facturada", vbInformation + vbOKOnly, ExpertisApp.Title)
                    End If
                Else
                    MsgBox("No tiene ninguna Certificación para Anular", vbExclamation + vbOKOnly, ExpertisApp.Title)
                End If
            Else
                MsgBox("Debe seleccionar un Proyecto", vbInformation + vbOKOnly, ExpertisApp.Title)
            End If

            dt = Nothing
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub AccionBloquearCertificacion()
        Try
            GridCertificaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            GridCertificaciones.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
            GridCertificaciones.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
            MessageBox.Show("Certificación Bloqueada", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub AccionDesbloquearCertificacion()
        Try
            GridCertificaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            GridCertificaciones.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
            'IBIS. David
            GridCertificaciones.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True

            MessageBox.Show("Certificación Desbloqueada", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub AccionExportarMediciones()
        Dim strEmpresa As String

        Dim frm As FrmExportar
        Try
            frm = New FrmExportar 'txtDescObra

            frm.lngIDObraGA = Me.CurrentRow("IDObra")

            frm.sNumObra = Nz(txtNObra.Text, 0)
            frm.DescObra = Nz(txtDescObra.Text, "")

            'frm.lngIDObra = Nz(frm.AdvObra.Value, 0)
            'frm.DescObra = Nz(frm.UlbDescObra.Text, "")

            frm.ShowDialog()

        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        Finally
            frm = Nothing
        End Try
    End Sub

    Private Sub AccionLiberarCertificacion()
        Dim dt As DataTable
        Dim strWhere As String
        Dim lngNumero As Long
        Dim txtSQL As String
        Dim strNumero As String

        Try
            strNumero = Nz(InputBox("Indique Nº de Certificación", "Nº de Certificación"), 0)
            If IsNumeric(strNumero) And IsDBNull(Me.CurrentRow("IDObra")) = False Then
                lngNumero = strNumero
                strWhere = "IdObra= " & Me.CurrentRow("IDObra") & " and idFactura = 0"
                If lngNumero >= 1 Then
                    dt = AdminData.GetData("tbObraCertificacionesAcero", , strWhere)
                    If dt.Rows.Count > 0 Then
                        lngCertLiberada = lngNumero
                        MsgBox("Se ha liberado la Certificación", MsgBoxStyle.Information, ExpertisApp.Title)
                    Else
                        MsgBox("No existe Certificación con el Nº " & lngNumero & " o ya ha sido Facturada", vbInformation + vbOKOnly, ExpertisApp.Title)
                    End If
                Else
                    MsgBox("No tiene ninguna Certificación con el Nº " & lngNumero & " ", vbExclamation + vbOKOnly, ExpertisApp.Title)
                End If
            Else
                MsgBox("Debe Indicar un Número de Certificación Existente", vbInformation + vbOKOnly, ExpertisApp.Title)
            End If
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub
#End Region

#Region " GridCertificaciones "
    Private Sub GridCertificaciones_EditingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.EditingCellEventArgs) Handles GridCertificaciones.EditingCell
        Dim strValor As String
        Dim strSelect As String
        Dim strWhere As String
        Dim fwnOT As ObraTrabajo
        Dim dt As DataTable

        Try
            With GridCertificaciones
                If Nz(.Value(.Columns("IDFactura").Index), 0) > 0 Then
                    MsgBox("Linea Facturada no se puede Modificar", vbCritical, ExpertisApp.Title)
                    e.Cancel = True
                End If

                Select Case e.Column.Index

                    Case .Columns("Mes").Index
                        If Nz(.Value(.Columns("especial").Index), 0) <> 0 Then
                            If IsNumeric(.Columns("Mes").Index) Then
                                .Value(.Columns("Total").Index) = xRound(CDbl(Nz(.Value(.Columns("Mes").Index), 0)), 6)
                            Else
                                MsgBox("El valor ingresado no es válido", vbExclamation, ExpertisApp.Title)
                                .Focus()
                            End If
                        Else
                            MsgBox("Este valor no se puede modificar", vbExclamation, ExpertisApp.Title)
                            e.Cancel = True
                        End If

                End Select
            End With
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    Private Sub GridCertificaciones_DeletingRecord(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles GridCertificaciones.DeletingRecord
        Try
            If Nz(GridCertificaciones.Value(GridCertificaciones.Columns("IDFactura").Index), 0) > 0 Then
                MsgBox("Linea Facturada no se puede Eliminar", vbCritical, ExpertisApp.Title)
                e.Cancel = True
            End If

            If MsgBox("¿Estás seguro de que deseas eliminar esta linea de Certificación?", vbYesNo, ExpertisApp.Title) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub

    'Private Sub GridCertificaciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCertificaciones.Click
    '    Try
    '        If GridCertificaciones.AllowAddNew = InheritableBoolean.True Then
    '            GridCertificaciones.Columns("IDCertificacion").DefaultValue = AdminData.GetAutoNumeric
    '        End If
    '    Catch ex As Exception
    '        ExpertisApp.GenerateMessage(ex.Message)
    '    End Try
    'End Sub
#End Region

#Region " Asignación de Coladas "
    Private Sub MostrarFormularioNumeroSerie(ByVal numDiametro As Integer, ByVal pCantidad As Double, ByVal numMedicion As Double)
        Dim frmNumSerie As New FrmNumeroSerie

        Try
            With GridMediciones
                If .Row <> .newTopRowPosition And Len(numDiametro) > 0 Then
                    frmNumSerie.NumDiametro = numDiametro
                    frmNumSerie.Cantidad = pCantidad
                    frmNumSerie.numMedicion = numMedicion
                    frmNumSerie.soloLectura = False
                    frmNumSerie.ShowDialog()
                    ControlarPesoProduccion(CInt(numMedicion)) 'IBIS. David
                End If
            End With
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        Finally
            frmNumSerie = Nothing
            ' frmNumSerie.Dispose()
        End Try
    End Sub

    Private Sub ControlarPesoProduccion(ByVal NumMedicion As Integer)
        Dim TOTALPRODUCCCION As Double
        Dim dttAuxiliar As New DataTable
        Try

            dttAuxiliar = AdminData.Filter("tbAlbaranVentaNSerie", "SUM(Cantidad) AS SumCantidad", "IDLineaAlbaranVenta=" & NumMedicion)
            'dttAuxiliar = AdminData.Filter("tbColadaAcero", "SUM(Cantidad) AS SumCantidad", "IDLineaMedicionA=" & NumMedicion)

            If Not dttAuxiliar Is Nothing AndAlso dttAuxiliar.Rows.Count > 0 Then
                TOTALPRODUCCCION = Nz(dttAuxiliar.Rows(0)("SumCantidad"), 0)
                ' No poner a 0 si el valor es 0
                If TOTALPRODUCCCION > 0 Then
                    AdminData.Execute("UPDATE tbOBraMedicionAcero SET PLANILLA=" & Replace(TOTALPRODUCCCION, ",", ".") & " WHERE IDLineaMedicionA=" & NumMedicion)
                End If
            End If
            Me.Requery.InvokeOnClick()
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        Finally
            dttAuxiliar = Nothing
        End Try
    End Sub
#End Region

#Region " Medios de Elevación "

    Private Sub chbMedElev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMedElev.CheckedChanged
        ComprobarMediosElev()
        'Me.UpdateData()
    End Sub

    'IBIS. David
    Private Sub ComprobarMediosElev()
        With GridMediciones
            If chbMedElev.Checked = False Then
                .Columns("CertificadoMediosE").EditType = EditType.NoEdit
                .Columns("PrecioCertMediosElev").EditType = EditType.NoEdit
                .Columns("TotalMediosE").EditType = EditType.NoEdit
                '.Value(.Columns("CertificadoMediosE") = 0
                '.Value(.Columns("PrecioCertMediosElev").Index) = 0
                '.Value(.Columns("TotalMediosE").Index) = 0
            Else
                .Columns("CertificadoMediosE").EditType = EditType.TextBox
                .Columns("PrecioCertMediosElev").EditType = EditType.TextBox
                '.Columns("TotalMediosE").EditType = EditType.TextBox
            End If
        End With
    End Sub

    'Manuel
    Private Sub BloquearTotalMedios()
        With GridMediciones
            .Columns("TotalSuministro").EditType = EditType.NoEdit
            .Columns("TotalMontaje").EditType = EditType.NoEdit
            .Columns("TotalMediosE").EditType = EditType.NoEdit
            .Columns("MedElaboracion").EditType = EditType.NoEdit

        End With
    End Sub
#End Region

#Region " Informes "

    Private Sub MntoGestionObrasAcero_SetReportDesignObjects(ByVal sender As Object, ByVal e As Engine.UI.ReportDesignObjectsEventArgs) Handles MyBase.SetReportDesignObjects
        Try
            'Dim vMes As Integer
            Dim Fecha1 As Date
            Dim Fecha2 As Date
            Dim opcion, sObservaciones As String
            'Dim obra As String
            ' Dim vAnio As Integer
            Dim cancel As Boolean

            'Abrir Informe de Beneficio
            If e.Alias = "INFBENEFECIO" Then
                Dim frm As New frmInformeFecha
                frm.ShowDialog()
                'vMes = frm.VM
                Fecha1 = frm.FechaDesde.Value
                'vAnio = frm.VA
                Fecha2 = frm.FechaHasta.Value
                'obra = txtNObra.Text

                If frm.blEstado = True Then
                    MessageBox.Show("Proceso Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Exit Sub
                End If
                'GenerarInformeBeneficio(CInt(vMes), CInt(vAnio))
                'GenerarInformeBeneficio(CDate(Fecha1), CDate(Fecha2), CStr(obra))
                GenerarInformeBeneficio(CDate(Fecha1), CDate(Fecha2))
                e.Cancel = True
            ElseIf e.Alias = "INFMEDACERO" Then
                Dim frm As New frmInformeFecha
                frm.ShowDialog()
                'vMes = frm.VM
                Fecha1 = frm.FechaDesde.Value
                'vAnio = frm.VA
                Fecha2 = frm.FechaHasta.Value
                'obra = txtNObra.Text

                If frm.blEstado = True Then
                    MessageBox.Show("Proceso Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Exit Sub
                End If
                GenerarInformeMedicion(Fecha1, Fecha2)
                e.Cancel = True
                'frm.Dispose()
                'frm = Nothing

            ElseIf e.Alias = "ACEROCOMPARATIVA" Then
                Dim frm As New frmProveedor
                frm.ShowDialog()
                opcion = frm.opcion

                If frm.blEstado = True Then
                    MessageBox.Show("Proceso Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Exit Sub
                End If
                If opcion <> "0" Then
                    GenerarInformeproveedor(opcion)
                    e.Cancel = True
                End If

                ' Informe de estado facturación acero,Use,09/07/2009
            ElseIf e.Alias = "INFESTFACERO" Then
                GenerarInformeFactAcero(e.Alias)
                'Desactiva evento predeterminado de informe
                e.Cancel = True
                ' Informe por obra y estructura suma por diámetros, Use, 15/09/2009
            ElseIf e.Alias = "INFESTFACEROMAL" Then
                GenerarInformeFactAcero(e.Alias)
                'Desactiva evento predeterminado de informe
                e.Cancel = True
            ElseIf e.Alias = "INFPESOACERO" Then
                Dim frm As New frmInformeFecha
                frm.ShowDialog()
                Fecha1 = frm.fecha1
                Fecha2 = frm.fecha2
                sObservaciones = Nz(frm.TxObservaciones.Text, "")
                If frm.blEstado = True Then
                    MessageBox.Show("Proceso Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Exit Sub
                End If

                GenerarInformeBalancePesosAcero(CDate(Fecha1), CDate(Fecha2), Nz(sObservaciones, ""))
                e.Cancel = True
            ElseIf e.Alias = "INFACEROEST" Then
                Dim frm As New frmInformeFecha
                frm.ShowDialog()
                'vMes = frm.VM
                Fecha1 = frm.fecha1
                'vAnio = frm.VA
                Fecha2 = frm.fecha2
                'obra = txtNObra.Text
                sObservaciones = Nz(frm.TxObservaciones.Text, "")
                If frm.blEstado = True Then
                    MessageBox.Show("Proceso Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Exit Sub
                End If
                GenerarInformeAceroEstructura(CDate(Fecha1), CDate(Fecha2), Nz(sObservaciones, ""))
                e.Cancel = True
                'David Velasco 09/02
            ElseIf e.Alias = "INFCOL" Then
                Dim frm As New frmInformeFecha
                frm.ShowDialog()
                'vMes = frm.VM
                Fecha1 = frm.fecha1
                'vAnio = frm.VA
                Fecha2 = frm.fecha2
                'obra = txtNObra.Text
                sObservaciones = Nz(frm.TxObservaciones.Text, "")
                If frm.blEstado = True Then
                    MessageBox.Show("Proceso Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Exit Sub
                End If

                GenerarInformePesosDiametro(CDate(Fecha1), CDate(Fecha2), Nz(sObservaciones, ""))
                e.Cancel = True
                'David Velasco 09/02
            ElseIf e.Alias = "INFHFD" Or e.Alias = "INFHCD" Or e.Alias = "INFFABT" Then

                Dim frm As New frmInformeFecha
                frm.ShowDialog()

                If frm.blEstado = True Then
                    ExpertisApp.GenerateMessage("Proceso Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Exit Sub
                Else
                    'IBIS. David. 02/06/2010. Puesto todo esto dentro del Else, controlando el que vengan las
                    'fechas vacias.

                    'vMes = frm.VM
                    Fecha1 = frm.FechaDesde.Value
                    'vAnio = frm.VA
                    Fecha2 = frm.FechaHasta.Value
                    'obra = txtNObra.Text
                    GenerarInformeFabDia(CDate(Fecha1), CDate(Fecha2), e.Alias)
                    e.Cancel = True
                End If

                frm.Dispose()
            End If
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Sub
    Private Sub GenerarInformeMedicion(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        Dim rp1 As New Report("INFMEDACERO")
        Dim filtro1 As New Filter

        filtro1.Add("Fecha", FilterOperator.GreaterThanOrEqual, CDate(Format(Fecha1, "dd/MM/yyyy")))
        filtro1.Add("Fecha", FilterOperator.LessThanOrEqual, CDate(Format(Fecha2, "dd/MM/yyyy")))
        If MsgBox("¿Desea mostrar los datos sólo para esta obra?", MsgBoxStyle.YesNo, "Criterios de filtrado") = MsgBoxResult.Yes Then
            filtro1.Add("NObra", FilterOperator.Equal, Me.CurrentRow("NObra"))
        End If

        rp1.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro1)
        ExpertisApp.OpenReport(rp1)
    End Sub
    Private Function GenerarInformeBeneficio(ByVal Fecha1 As Date, ByVal Fecha2 As Date) ', ByVal obra As String)
        Try
            Dim rp As New Report("INFBENEFECIO")
            Dim filtro As New Filter
            'filtro.Add("Nobra", FilterOperator.Equal, obra)
            filtro.Add("fecha", FilterOperator.GreaterThanOrEqual, Fecha1)
            filtro.Add("fecha", FilterOperator.LessThanOrEqual, Fecha2)
            rp.Formulas("dDesde").Text = Format(Fecha1, "dd-MM-yyyy")
            rp.Formulas("dHasta").Text = Format(Fecha2, "dd-MM-yyyy")
            rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro)
            ExpertisApp.OpenReport(rp)
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function

    Private Function GenerarInformeFabDia(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal sAlias As String) ', ByVal obra As String)
        Try
            Dim rp As New Report(sAlias)
            Dim filtro As New Filter
            Select Case sAlias
                Case "INFHFD", "INFFABT"
                    filtro.Add("fproduccion", FilterOperator.GreaterThanOrEqual, Fecha1)
                    filtro.Add("fproduccion", FilterOperator.LessThanOrEqual, Fecha2)
                    rp.Formulas("dDesde").Text = Format(Fecha1, "dd/MM/yyyy")
                    rp.Formulas("dHasta").Text = Format(Fecha2, "dd/MM/yyyy")
                Case "INFHCD"
                    filtro.Add("fecha", FilterOperator.GreaterThanOrEqual, Fecha1)
                    filtro.Add("fecha", FilterOperator.LessThanOrEqual, Fecha2)
            End Select
            'filtro.Add("Nobra", FilterOperator.Equal, obra)
            rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro)
            ExpertisApp.OpenReport(rp)
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function

    Private Function GenerarInformeproveedor(ByVal opcion As Long) ', ByVal obra As String)
        Try
            Dim rp As New Report("ACEROCOMPARATIVA")
            Dim filtro As New Filter
            filtro.Add("idproveedor", FilterOperator.Equal, opcion)
            'filtro.Add("fecha", FilterOperator.GreaterThanOrEqual, Fecha1)
            'filtro.Add("fecha", FilterOperator.LessThanOrEqual, Fecha2)
            rp.DataSource = New BE.DataEngine().Filter("vFrmACProveedor", filtro)
            rp.Formulas("proveedor1").Text = opcion
            rp.Formulas("idobra").Text = Me.CurrentRow("IDObra")
            ExpertisApp.OpenReport(rp)
        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function

    ' Informe estado facturación acero, 09/07/2009
    Private Function GenerarInformeFactAcero(ByVal sInforme As String)
        Dim Frm As New frmlFechaEstFactura
        Dim dFechaFactur As Date
        Try
            Frm.iIdObra = Me.CurrentRow("IdObra")
            Frm.ShowDialog()
            dFechaFactur = Frm.fhasta
            '' Control de día grabado
            If Not IsNothing(dFechaFactur) AndAlso dFechaFactur.Year > 1 Then
                Dim rp As New Report(sInforme)
                Dim filtro As New Filter

                'IBIS. David. 14/06/2010.
                'filtro.UnionOperator = FilterUnionOperator.Or

                filtro.Add("idobra", FilterOperator.Equal, Me.CurrentRow("IdObra"))
                If Not IsNothing(Frm.Fdesde) Then
                    filtro.Add("fecha", FilterOperator.GreaterThanOrEqual, Frm.Fdesde)
                End If
                filtro.Add("fecha", FilterOperator.LessThanOrEqual, dFechaFactur)
                If sInforme = "INFESTFACEROMAL" Then
                    filtro.Add("ESTRUCTURA", FilterOperator.Equal, "MALLAZO")
                End If
                rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro)
                ExpertisApp.OpenReport(rp)
            Else
                MsgBox("No se ha definido un día de facturación en la obra, Indique ese dato en la solapa de seguimiento de obra y vuelva a intentarlo", MsgBoxStyle.Exclamation, "Dato para informe requerido")
            End If
        Catch ex As Exception
            MsgBox("Se produjo el siguiente error al obtener datos para el informe:" & ex.Message, MsgBoxStyle.Critical, "Error al generar informe")
        End Try
    End Function

    Private Function GenerarInformeAceroEstructura(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal sObservaciones As String) ', ByVal obra As String)
        Try
            Dim rp As New Report("INFACEROEST")
            Dim filtro As New Filter
            If MsgBox("¿Desea mostrar los datos sólo para esta obra?", MsgBoxStyle.YesNo, "Criterios de filtrado") = MsgBoxResult.Yes Then
                filtro.Add("IDobra", FilterOperator.Equal, Me.CurrentRow("IdObra"))
            End If
            filtro.Add("Fecha", FilterOperator.GreaterThanOrEqual, CDate(Format(Fecha1, "dd/MM/yyyy")))
            filtro.Add("Fecha", FilterOperator.LessThanOrEqual, CDate(Format(Fecha2, "dd/MM/yyyy")))
            If sObservaciones.Length > 0 Then
                filtro.Add("Observaciones2", FilterOperator.Equal, sObservaciones)
            End If
            'rp.Filter.Add(filtro)

            rp.DataSource = New BE.DataEngine().Filter("vTrptMedicionesAceroObraEstructura", filtro)

            'rp.DataSource = New BE.DataEngine().Filter("tbObraMedicionAcero", filtro)
            rp.Formulas("NombreObra").Text = Me.CurrentRow("DescObra")
            rp.Formulas("NObra").Text = Me.CurrentRow("NObra")
            rp.Formulas("FDesde").Text = Format(Fecha1, "dd/MM/yyyy")
            rp.Formulas("FHasta").Text = Format(Fecha2, "dd/MM/yyyy")
            ExpertisApp.OpenReport(rp)

        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function

    'David V 09/02
    Private Function GenerarInformePesosDiametro(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal sObservaciones As String) ', ByVal obra As String)
        Try
            Dim rp As New Report("INFCOL")
            Dim filtro As New Filter
            filtro.Add("Fecha", FilterOperator.GreaterThanOrEqual, CDate(Format(Fecha1, "dd/MM/yyyy")))
            filtro.Add("Fecha", FilterOperator.LessThanOrEqual, CDate(Format(Fecha2, "dd/MM/yyyy")))
            If MsgBox("¿Desea mostrar los datos sólo para esta obra?", MsgBoxStyle.YesNo, "Criterios de filtrado") = MsgBoxResult.Yes Then
                filtro.Add("NObra", FilterOperator.Equal, Me.CurrentRow("NObra"))
            End If
            rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro)
            rp.Formulas("obra").Text = Me.CurrentRow("NObra")
            rp.Formulas("fDesde").Text = Format(Fecha1, "dd/MM/yyyy")
            rp.Formulas("fHasta").Text = Format(Fecha2, "dd/MM/yyyy")
            ExpertisApp.OpenReport(rp)

        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function
    'David V 09/02
    Private Function GenerarInformeBalancePesosAcero(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal sObservaciones As String)
        Try
            Dim rp As New Report("INFPESOACERO")
            Dim filtro As New Filter
            filtro.Add("Fecha", FilterOperator.GreaterThanOrEqual, CDate(Format(Fecha1, "dd/MM/yyyy")))
            filtro.Add("Fecha", FilterOperator.LessThanOrEqual, CDate(Format(Fecha2, "dd/MM/yyyy")))
            If MsgBox("¿Desea mostrar los datos sólo para esta obra?", MsgBoxStyle.YesNo, "Criterios de filtrado") = MsgBoxResult.Yes Then
                filtro.Add("NObra", FilterOperator.Equal, Me.CurrentRow("NObra"))
            End If

            rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro)
            rp.Formulas("FechaINI").Text = Format(Fecha1, "dd/MM/yyyy")
            rp.Formulas("FechaFIN").Text = Format(Fecha2, "dd/MM/yyyy")
            ExpertisApp.OpenReport(rp)

        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        End Try
    End Function
#End Region

#Region " Funciones Use "

    Private Function Certificar(ByVal lNumcertifica As Long, ByVal frmOpciones As SeleccionarCertificacion) As Short
        ' Control de precios a certificar
        ' Facturar precios A y B
        If frmOpciones.RB1.Checked = True Then
            If certifPrecio(lNumcertifica, frmOpciones, "A") < 0 Then
                Return -1
            End If
            If certifPrecio(lNumcertifica, frmOpciones, "B") < 0 Then
                Return -1
            End If
            ' Bien
            Return 1
        End If
        ' Facturar precios A
        If frmOpciones.RB2.Checked = True Then
            If certifPrecio(lNumcertifica, frmOpciones, "A") < 0 Then
                Return -1
            End If
        End If
        ' Facturar precios B
        If frmOpciones.RB3.Checked = True Then
            If certifPrecio(lNumcertifica, frmOpciones, "B") < 0 Then
                Return -1
            End If
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '' Por último, certificar variación del acero 2 por cada Nº de certificación
        'If CertifVarAcero(lNumcertifica, frmOpciones.Certificacion) < 0 Then
        '    Return -1
        'End If
        ' Bien
        Return 1
    End Function

    Private Function certifPrecio(ByVal lNumcertifica As Long, ByVal frmOpciones As SeleccionarCertificacion, ByVal cprecio As Char) As Short
        ' Contenedores
        Dim rselaboracion As New DataTable
        Dim dContenedor As New DataTable
        ' Objeto negoción certificación Acero
        Dim clCertifAcero As New ObraCertificacionesAcero
        Dim dfila As DataRow
        ' 1º Cargar la esctructura del dt
        dContenedor = clCertifAcero.AddNewForm()
        dContenedor.Rows(0).Delete()
        Try
            ' Elaboración
            '################################################################'
            If frmOpciones.CheckBox6.Checked = True Then
                ' Coger las filas certificadas previamente o las q se estan certificado agrupadas por precio
                rselaboracion = AdminData.GetData("SELECT SUM(TElaboracion) As Peso, ISNULL(PElab" & cprecio & ", 0) As precio, SUM(PesoAlbaran) " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElab" & cprecio & ", 0) <> 0) " & _
                     " AND ((NCertificacion > 0 ) OR (certificar = 1)) GROUP BY PElab" & cprecio, False)
                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Recorrer todas las filas encontradas en la selección e irlas introduciendo en la certificación
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfila = dContenedor.NewRow()

                        dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                        dfila("NCERTIFICACION") = lNumcertifica
                        dfila("IDOBRA") = Me.CurrentRow("IDObra")
                        dfila("IDUDMEDIDA") = "M3"
                        dfila("CANTIDAD") = 0
                        dfila("CONCEPTO") = "Elaboración de Acero puesto obra " & cprecio
                        dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                        dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        dfila("TIPO") = 1
                        dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                        ' Proceso siguiente localizar los kl d este tipo para restarlos del mes
                        dfila("MES") = dfila("MES") - PesoCertifOrigen(dfila("PRECIO"), dfila("TIPO"))
                        dContenedor.Rows.Add(dfila)
                    Next

                End If
            End If
            ' Facturación acero
            '################################################################'
            If frmOpciones.CheckBox1.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoSuministro) As Peso, ISNULL(PSum" & cprecio & ", 0) As precio, SUM(PesoAlbaran) " & _
                                " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PSum" & cprecio & ", 0) <> 0) " & _
                                " AND ((NCertificacion > 0 ) OR (certificar = 1)) GROUP BY PSum" & cprecio, False)
                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Recorrer todas las filas encontradas en la selección e irlas introduciendo en la certificación
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfila = dContenedor.NewRow()

                        dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                        dfila("NCERTIFICACION") = lNumcertifica
                        dfila("IDOBRA") = Me.CurrentRow("IDObra")
                        dfila("IDUDMEDIDA") = "M3"
                        dfila("CANTIDAD") = 0
                        dfila("CONCEPTO") = "Suministro de Acero puesto obra " & cprecio
                        dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                        dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        dfila("TIPO") = 2
                        dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                        ' Proceso siguiente localizar los kl d este tipo para restarlos del mes
                        dfila("MES") = dfila("MES") - PesoCertifOrigen(dfila("PRECIO"), dfila("TIPO"))
                        dContenedor.Rows.Add(dfila)
                    Next

                End If
            End If
            ' Montaje
            '################################################################'
            If frmOpciones.CheckBox2.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMontaje) As Peso, ISNULL(PMon" & cprecio & ", 0) As precio, SUM(PesoAlbaran) " & _
                                " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PMon" & cprecio & ", 0) <> 0) " & _
                                " AND ((NCertificacion > 0 ) OR (certificar = 1)) GROUP BY PMon" & cprecio, False)
                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Recorrer todas las filas encontradas en la selección e irlas introduciendo en la certificación
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfila = dContenedor.NewRow()

                        dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                        dfila("NCERTIFICACION") = lNumcertifica
                        dfila("IDOBRA") = Me.CurrentRow("IDObra")
                        dfila("IDUDMEDIDA") = "M3"
                        dfila("CANTIDAD") = 0
                        dfila("CONCEPTO") = "Montaje de Acero puesto obra " & cprecio
                        dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                        dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        dfila("TIPO") = 3
                        dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                        ' Proceso siguiente localizar los kl d este tipo para restarlos del mes
                        dfila("MES") = dfila("MES") - PesoCertifOrigen(dfila("PRECIO"), dfila("TIPO"))
                        dContenedor.Rows.Add(dfila)
                    Next

                End If
            End If
            'MEDIOS ELEV
            '################################################################'
            If frmOpciones.CheckBox3.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMediosE) As Peso, ISNULL(PElev" & cprecio & ", 0) As precio, SUM(PesoAlbaran) " & _
                                " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElev" & cprecio & ", 0) <> 0) " & _
                                " AND ((NCertificacion > 0 ) OR (certificar = 1)) GROUP BY PElev" & cprecio, False)
                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Recorrer todas las filas encontradas en la selección e irlas introduciendo en la certificación
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfila = dContenedor.NewRow()

                        dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                        dfila("NCERTIFICACION") = lNumcertifica
                        dfila("IDOBRA") = Me.CurrentRow("IDObra")
                        dfila("IDUDMEDIDA") = "M3"
                        dfila("CANTIDAD") = 0
                        dfila("CONCEPTO") = "Medios Especiales de Acero puesto obra " & cprecio
                        dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                        dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        dfila("TIPO") = 4
                        dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                        ' Proceso siguiente localizar los kl d este tipo para restarlos del mes
                        dfila("MES") = dfila("MES") - PesoCertifOrigen(dfila("PRECIO"), dfila("TIPO"))
                        dContenedor.Rows.Add(dfila)
                    Next

                End If

            End If
            ' Control variación precio Acero
            If frmOpciones.CheckBox7.Checked = True Then
                dfila = dContenedor.NewRow()
                dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                dfila("NCERTIFICACION") = lNumcertifica
                dfila("IDOBRA") = Me.CurrentRow("IDObra")
                dfila("IDUDMEDIDA") = "M3"
                dfila("CANTIDAD") = 0
                dfila("CONCEPTO") = "Variación precio Acero." & frmOpciones.TxtAñadirVarAcero.Text
                dfila("TOTAL") = 0
                dfila("MES") = 0
                dfila("ESPECIAL") = 1
                dfila("TIPO") = 9
                dContenedor.Rows.Add(dfila)
            End If
            ' Último, lanzar el update del contenedor
            clCertifAcero.Update(dContenedor)
            dContenedor.Clear()
            ' Quitar la marca de certificar
            Dim clobra As New ObraMedicionAcero
            rselaboracion = AdminData.GetData("SELECT * " & _
                                 " FROM tbobraMedicionAcero WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND CERTIFICAR = 1", False)

            ' Recorrer las lineas certificadas
            For Shcont As Short = 0 To rselaboracion.Rows.Count - 1
                rselaboracion.Rows(shcont)("CERTIFICAR") = 0
                rselaboracion.Rows(shcont)("NCERTIFICACION") = lNumcertifica
            Next

            ' Lanzar el update
            clobra.Update(rselaboracion)
            clobra = Nothing
        Catch ex As Exception
            MsgBox("Error produjo un error al generar la certificación." & ex.Message, MsgBoxStyle.Critical, ExpertisApp.Title)
            ' Detruir objetos
            clCertifAcero = Nothing
            rselaboracion.Dispose()
            rselaboracion = Nothing
            dContenedor.Dispose()
            dContenedor = Nothing
            'Recolector de basura
            System.GC.Collect()
            Return -1
        End Try
        ' Destruir objetos
        clCertifAcero = Nothing
        rselaboracion.Dispose()
        rselaboracion = Nothing
        dContenedor.Dispose()
        dContenedor = Nothing
        ' Recolector de basura
        System.GC.Collect()
        ' Bien
        Return 1
    End Function

    ' Función que retorna el peso facturado en el mes del tipo solicitado en esa obra. 06/08/2009
    Private Function PesoCertifOrigen(ByVal dImpPrecio As Decimal, ByVal itipo As Int16) As Decimal
        Dim dPesoOrigen As Decimal
        Dim dtPesosOrigen As New DataTable
        ' Coger los pesos
        Try
            dtPesosOrigen = AdminData.GetData("SELECT SUM(Mes) AS KGOrigen FROM tbObraCertificacionesAcero " & _
            " WHERE (IdObra = " & Me.CurrentRow("IDObra") & ") AND (Tipo = " & itipo & ")", False)
            ' Control de filas
            If dtPesosOrigen.Rows.Count > 0 AndAlso Not IsDBNull(dtPesosOrigen.Rows(0)(0)) Then
                dPesoOrigen = Nz(dtPesosOrigen.Rows(0)("KGOrigen"), 0)
            Else
                dPesoOrigen = 0
            End If
        Catch ex As Exception

        End Try
        ' Bien
        Return dPesoOrigen
    End Function

    Private Function certifPrecio_Antigua(ByVal lNumcertifica As Long, ByVal frmOpciones As SeleccionarCertificacion, ByVal cprecio As Char) As Short
        ' Contenedores
        Dim rselaboracion As New DataTable
        Dim dContenedor As New DataTable
        ' Objeto negoción certificación Acero
        Dim clCertifAcero As New ObraCertificacionesAcero
        ' 1º Cargar la esctructura del dt
        dContenedor = clCertifAcero.AddNewForm()
        dContenedor.Rows(0).Delete()
        Try
            ' Elaboración
            '################################################################'
            If frmOpciones.CheckBox6.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TElaboracion) As Peso, ISNULL(PElab" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElab" & cprecio & ", 0) <> 0) " & _
                     " AND (NCertificacion > 0 ) AND (NCertificacion <> " & lNumcertifica & ") GROUP BY PElab" & cprecio & ", NCertificacion", False)
                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados, son de certificaciones anteriores. 10/12/2008
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=1")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()

                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Elaboración de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = 0
                            dfila("TIPO") = 1
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
                ' Ya tengo en el contenedor las certificaciones anteriores, ahora certifico la que está en curso
                rselaboracion = AdminData.GetData("SELECT SUM(TElaboracion) As Peso, ISNULL(PElab" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElab" & cprecio & ", 0) <> 0) " & _
                     " AND (certificar = 1) GROUP BY PElab" & cprecio & ", NCertificacion", False)
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados.
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=1")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()
                            ' Provisional, el autonumérico
                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Elaboración de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                            dfila("TIPO") = 1
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
            End If
            ' Facturación acero
            '################################################################'
            If frmOpciones.CheckBox1.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoSuministro) As Peso, ISNULL(PSum" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PSum" & cprecio & ", 0) <> 0) " & _
                     " AND (NCertificacion > 0 ) AND (NCertificacion <> " & lNumcertifica & ") GROUP BY PSum" & cprecio & ", NCertificacion", False)

                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados, son de certificaciones anteriores. 10/12/2008
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=2")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()

                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Suministro de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = 0
                            dfila("TIPO") = 2
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
                ' Ya tengo en el contenedor las certificaciones anteriores, ahora certifico la que está en curso
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoSuministro) As Peso, ISNULL(PSum" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PSum" & cprecio & ", 0) <> 0) " & _
                     " AND (certificar = 1) GROUP BY PSum" & cprecio & ", NCertificacion", False)
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados.
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=2")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()
                            ' Provisional, el autonumérico
                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Suministro de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                            dfila("TIPO") = 2
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
            End If
            ' Montaje
            '################################################################'
            If frmOpciones.CheckBox2.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMontaje) As Peso, ISNULL(PMon" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PMon" & cprecio & ", 0) <> 0) " & _
                     " AND (NCertificacion > 0 ) AND (NCertificacion <> " & lNumcertifica & ") GROUP BY PMon" & cprecio & ", NCertificacion", False)

                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados, son de certificaciones anteriores. 10/12/2008
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=3")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()

                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Montaje de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = 0
                            dfila("TIPO") = 3
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
                ' Ya tengo en el contenedor las certificaciones anteriores, ahora certifico la que está en curso
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMontaje) As Peso, ISNULL(PMon" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PMon" & cprecio & ", 0) <> 0) " & _
                     " AND (certificar = 1) GROUP BY PMon" & cprecio & ", NCertificacion", False)
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados.
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=3")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()
                            ' Provisional, el autonumérico
                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Montaje de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                            dfila("TIPO") = 3
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
            End If
            'MEDIOS ELEV
            '################################################################'
            If frmOpciones.CheckBox3.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMediosE) As Peso, ISNULL(PElev" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElev" & cprecio & ", 0) <> 0) " & _
                     " AND (NCertificacion > 0 ) AND (NCertificacion <> " & lNumcertifica & ") GROUP BY PElev" & cprecio & ", NCertificacion", False)
                ' Si tiene filas
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados, son de certificaciones anteriores. 10/12/2008
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=4")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()

                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Medios Especiales de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = 0
                            dfila("TIPO") = 4
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
                ' Ya tengo en el contenedor las certificaciones anteriores, ahora certifico la que está en curso
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMediosE) As Peso, ISNULL(PElev" & cprecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                     " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElev" & cprecio & ", 0) <> 0) " & _
                     " AND (certificar = 1) GROUP BY PElev" & cprecio & ", NCertificacion", False)
                If rselaboracion.Rows.Count > 0 Then
                    ' Modificación 10/12/2008
                    Dim dfilas(), dfila As DataRow
                    ' Recorrer los precios agrupados.
                    For shcont As Short = 0 To rselaboracion.Rows.Count - 1
                        dfilas = dContenedor.Select("PRECIO=" & Replace(CInt(rselaboracion.Rows(shcont)("PRECIO")), ".", ",").ToString & " AND TIPO=4")
                        ' Control de fila encontrada
                        If dfilas.Length > 0 Then
                            dfila = dfilas(0)
                            ' Añadir importe acumulado
                            dContenedor.Rows(0)("TOTAL") += rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                        Else
                            ' Nueva fila en update
                            dfila = dContenedor.NewRow()
                            ' Provisional, el autonumérico
                            dfila("IDCERTIFICACION") = AdminData.GetAutoNumeric
                            dfila("NCERTIFICACION") = lNumcertifica
                            dfila("IDOBRA") = Me.CurrentRow("IDObra")
                            dfila("IDUDMEDIDA") = "M3"
                            dfila("CANTIDAD") = 0
                            dfila("CONCEPTO") = "Medios Especiales de Acero puesto obra " & cprecio
                            dfila("TOTAL") = rselaboracion.Rows(shcont)("Peso")
                            dfila("MES") = rselaboracion.Rows(shcont)("Peso")
                            dfila("TIPO") = 4
                            dfila("PRECIO") = rselaboracion.Rows(shcont)("PRECIO")
                            dContenedor.Rows.Add(dfila)
                        End If
                    Next
                End If
            End If

            ' Último, lanzar el update del contenedor
            clCertifAcero.Update(dContenedor)
            dContenedor.Clear()
            ' Quitar la marca de certificar
            Dim clobra As New ObraMedicionAcero
            rselaboracion = AdminData.GetData("SELECT * " & _
                                 " FROM tbobraMedicionAcero WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND CERTIFICAR = 1", False)

            ' Recorrer las lineas certificadas
            For Shcont As Short = 0 To rselaboracion.Rows.Count - 1
                rselaboracion.Rows(shcont)("CERTIFICAR") = 0
                rselaboracion.Rows(shcont)("NCERTIFICACION") = lNumcertifica
            Next
            ' Lanzar el update
            clobra.Update(rselaboracion)
            clobra = Nothing
        Catch ex As Exception
            MsgBox("Error produjo un error al generar la certificación." & ex.Message, MsgBoxStyle.Critical, ExpertisApp.Title)
            ' Detruir objetos
            clCertifAcero = Nothing
            rselaboracion.Dispose()
            rselaboracion = Nothing
            dContenedor.Dispose()
            dContenedor = Nothing
            ' Recolector de basura
            System.GC.Collect()
            Return -1
        End Try
        ' Destruir objetos
        clCertifAcero = Nothing
        rselaboracion.Dispose()
        rselaboracion = Nothing
        dContenedor.Dispose()
        dContenedor = Nothing
        ' Recolector de basura
        System.GC.Collect()
        ' Bien
        Return 1
    End Function

    Private Function CertifVarAcero(ByVal lNumcertifica As Long, ByVal iIdCertifica As Integer) As Short
        ' Por cada certificación mete dos lineas controlando el ID de unión a otra certificación 05/12/2008
        Dim clCertifAcero As New ObraCertificacionesAcero
        Dim dtVarAcero As New DataTable
        Try
            For shcont As Short = 0 To lNumcertifica - 1
                dtVarAcero = clCertifAcero.AddNewForm()
                dtVarAcero.Rows(0)("NCERTIFICACION") = lNumcertifica
                dtVarAcero.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                dtVarAcero.Rows(0)("IDUDMEDIDA") = "M3"
                dtVarAcero.Rows(0)("CANTIDAD") = 0
                dtVarAcero.Rows(0)("CONCEPTO") = "Variación precio Acero"
                dtVarAcero.Rows(0)("TOTAL") = 0
                dtVarAcero.Rows(0)("MES") = 0
                dtVarAcero.Rows(0)("ESPECIAL") = 1
                dtVarAcero.Rows(0)("TIPO") = 9

                If iIdCertifica > 0 Then
                    dtVarAcero.Rows(0)("IDCertificacionObra") = iIdCertifica
                End If

                '' Ejecutar el Insert
                clCertifAcero.Update(dtVarAcero)
            Next
        Catch ex As Exception
            MsgBox("Error al crear variaciones de precio de acero." & ex.Message, MsgBoxStyle.Critical, ExpertisApp.Title)
            clCertifAcero = Nothing
            dtVarAcero.Dispose()
            dtVarAcero = Nothing
            ' Pasar recolector
            System.GC.Collect()
            Return -1
        End Try
        clCertifAcero = Nothing
        dtVarAcero.Dispose()
        dtVarAcero = Nothing
        ' Pasar recolector
        System.GC.Collect()
        ' Bien
        Return 1
    End Function

    ' Función descartada, certificación desde función V.Basic pasando del procedimiento almacenado
    Private Function AjusteCertifanterior(ByVal lNumcertifica As Long, ByVal frmOpciones As SeleccionarCertificacion) As Short
        ' Confirmación de inicio del proceso
        Dim lCertificaAnt As Long = lNumcertifica - 1
        'If MsgBox("¿Desea realizar el ajuste con la certificación anterior?", MsgBoxStyle.YesNo, ExpertisApp.Title) = MsgBoxResult.Yes Then
        ' Coger datos elaboración precio A 
        Dim rselaboracion As New DataTable
        Dim rselaboracionc As New DataTable
        Dim rsid As New DataTable
        Dim cPrecio As Char = "0"

        Do While cPrecio <> "B"
            ' Controlar los botonRadio
            ' Todas
            If frmOpciones.RB1.Checked = True Then
                Select Case cPrecio
                    Case "0"
                        cPrecio = "A"
                    Case "A"
                        cPrecio = "B"
                    Case Else
                        ' Salirse
                        Exit Do
                End Select
            End If

            ' Precio A
            If frmOpciones.RB2.Checked = True Then
                cPrecio = "A"
            End If
            ' Precio B
            If frmOpciones.RB3.Checked = True Then
                cPrecio = "B"
            End If

            'frmSeleccionarCertif.CHK1, 0) & " , " & Nz(frmSeleccionarCertif.CHK2, 0) & _
            '                   " , " & Nz(frmSeleccionarCertif.CHK3, 0) & ", " & Nz(frmSeleccionarCertif.CHK5, 0) & "," & Nz(frmSeleccionarCertif.CHK6, 0
            ' Elaboración
            '################################################################'
            If frmOpciones.CheckBox6.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TElaboracion), ISNULL(PElab" & cPrecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElab" & cPrecio & ", 0) <> 0) AND (Certificar = 0) " & _
                " AND (NCertificacion = " & lCertificaAnt & ") GROUP BY PElab" & cPrecio & ", NCertificacion", False)

                ' Datos certificados anteriores, busco por tipo porque si no hay de precio A o B no entra en la primera parte del IF
                rselaboracionc = AdminData.GetData("SELECT * FROM tbObraCertificacionesAcero WHERE IdObra = " & Me.CurrentRow("IDObra") & _
                                 " AND (tipo = 1) AND (NCertificacion = " & lCertificaAnt & ")", False)
                ' Controlar diferencia de precio
                If rselaboracion.Rows.Count > 0 AndAlso rselaboracionc.Rows.Count > 0 Then
                    If rselaboracion.Rows(0)("precio") <> rselaboracionc.Rows(0)("Precio") Then
                        ' Declarar objeto específico y tabla de destino
                        ' Modificación 01/12/2008 anualar 
                        Dim clCertifAcero As New ObraCertificacionesAcero
                        Dim dUpdate As New DataTable
                        Dim ddifPrecio As Decimal
                        dUpdate = clCertifAcero.AddNewForm()

                        ddifPrecio = rselaboracion.Rows(0)("precio") - rselaboracionc.Rows(0)("Precio")
                        ' Meter contralinea
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Anulación certificación Nº " & lCertificaAnt & " elaboración de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 1
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") * -1
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                        'sSentencia = "INSERT INTO tbObraCertificacionesAcero (idCertificacion,NCertificacion, IdObra, IDUdMedida,Cantidad,Concepto,Total,Mes,tipo,Precio) " & _
                        '                                             " VALUES(" & iId & ", " & lNumcertifica & "," & Me.CurrentRow("IDObra") & ",'M3', 0,'Diferencia elaboración de Acero puesto obra A', " & Replace(rselaboracionc.Rows(0)("Mes"), ",", ".") & " ," & Replace((rselaboracionc.Rows(0)("Mes")), ",", ".") & ",1," & Replace((rselaboracionc.Rows(0)("Precio") * -1), ",", ".") & ") "
                        '' Ejecutar el Insert
                        'AdminData.Execute(sSentencia, False)
                        ' Meter facturado realmente, Se suma al precio anterior la diferencia, si es negativa resta y sino suma
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Diferencia certif. Nº " & lCertificaAnt & " elaboración de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 1
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") + ddifPrecio

                        'sSentencia = "INSERT INTO tbObraCertificacionesAcero (idCertificacion,NCertificacion, IdObra, IDUdMedida,Cantidad,Concepto,Total,Mes,tipo,Precio) " & _
                        '                                             " VALUES(" & iId & ", " & lNumcertifica & "," & Me.CurrentRow("IDObra") & ",'M3', 0,'Diferencia elaboración de Acero puesto obra A', " & Replace(rselaboracionc.Rows(0)("Mes"), ",", ".") & " ," & Replace((rselaboracionc.Rows(0)("Mes")), ",", ".") & ",1," & Replace((rselaboracionc.Rows(0)("Precio") + ddifPrecio), ",", ".") & ") "
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                        'AdminData.Execute(sSentencia, False)

                    End If
                End If
            End If

            ' Facturación acero
            '################################################################'
            If frmOpciones.CheckBox1.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoSuministro), ISNULL(PSum" & cPrecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PSum" & cPrecio & ", 0) <> 0) AND (Certificar = 0) " & _
                " AND (NCertificacion = " & lCertificaAnt & ") GROUP BY PSum" & cPrecio & ", NCertificacion", False)

                ' Datos certificados anteriores
                rselaboracionc = AdminData.GetData("SELECT * FROM tbObraCertificacionesAcero WHERE IdObra = " & Me.CurrentRow("IDObra") & _
                                 " AND (tipo = 2) AND (NCertificacion = " & lCertificaAnt & ")", False)
                ' Controlar diferencia de precio
                If rselaboracion.Rows.Count > 0 AndAlso rselaboracionc.Rows.Count > 0 Then
                    If rselaboracion.Rows(0)("precio") <> rselaboracionc.Rows(0)("Precio") Then
                        ' Declarar objeto específico y tabla de destino
                        Dim clCertifAcero As New ObraCertificacionesAcero
                        Dim dUpdate As New DataTable
                        Dim ddifPrecio As Decimal
                        dUpdate = clCertifAcero.AddNewForm()

                        ddifPrecio = rselaboracion.Rows(0)("precio") - rselaboracionc.Rows(0)("Precio")
                        ' Meter contralinea
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Anulación certificación Nº " & lCertificaAnt & " suministro de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 2
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") * -1
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                        ' Meter facturado realmente, Se suma al precio anterior la diferencia, si es negativa resta y sino suma
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Diferencia certif. Nº " & lCertificaAnt & " suministro de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 2
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") + ddifPrecio
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                    End If
                End If
            End If

            ' Montaje
            '################################################################'
            If frmOpciones.CheckBox2.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMontaje), ISNULL(PMon" & cPrecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PMon" & cPrecio & ", 0) <> 0) AND (Certificar = 0) " & _
                " AND (NCertificacion = " & lCertificaAnt & ") GROUP BY PMon" & cPrecio & ", NCertificacion", False)

                ' Datos certificados anteriores
                rselaboracionc = AdminData.GetData("SELECT * FROM tbObraCertificacionesAcero WHERE IdObra = " & Me.CurrentRow("IDObra") & _
                                 " AND (tipo=3) AND (NCertificacion = " & lCertificaAnt & ")", False)
                ' Controlar diferencia de precio
                If rselaboracion.Rows.Count > 0 AndAlso rselaboracionc.Rows.Count > 0 Then
                    If rselaboracion.Rows(0)("precio") <> rselaboracionc.Rows(0)("Precio") Then
                        ' Declarar objeto específico y tabla de destino
                        Dim clCertifAcero As New ObraCertificacionesAcero
                        Dim dUpdate As New DataTable
                        Dim ddifPrecio As Decimal
                        dUpdate = clCertifAcero.AddNewForm()

                        ddifPrecio = rselaboracion.Rows(0)("precio") - rselaboracionc.Rows(0)("Precio")
                        ' Meter contralinea
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Anulación certificación Nº " & lCertificaAnt & " montaje de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 3
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") * -1
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                        ' Meter facturado realmente, Se suma al precio anterior la diferencia, si es negativa resta y sino suma
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Diferencia certif. Nº " & lCertificaAnt & " montaje de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 3
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") + ddifPrecio
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                    End If
                End If
            End If

            'MEDIOS ELEV
            '################################################################'
            If frmOpciones.CheckBox3.Checked = True Then
                rselaboracion = AdminData.GetData("SELECT SUM(TCertificadoMediosE), ISNULL(PElev" & cPrecio & ", 0) As precio, SUM(PesoAlbaran), NCertificacion " & _
                " FROM vFrmObraTotalMedicionesAceroMes WHERE IdObra = " & Me.CurrentRow("IDObra") & " AND (ISNULL(PElev" & cPrecio & ", 0) <> 0) AND (Certificar = 0) " & _
                " AND (NCertificacion = " & lCertificaAnt & ") GROUP BY PElev" & cPrecio & ", NCertificacion", False)

                ' Datos certificados anteriores
                rselaboracionc = AdminData.GetData("SELECT * FROM tbObraCertificacionesAcero WHERE IdObra = " & Me.CurrentRow("IDObra") & _
                                 " AND (tipo=4) AND (NCertificacion = " & lCertificaAnt & ")", False)

                ' Controlar diferencia de precio
                If rselaboracion.Rows.Count > 0 AndAlso rselaboracionc.Rows.Count > 0 Then
                    If rselaboracion.Rows(0)("precio") <> rselaboracionc.Rows(0)("Precio") Then

                        ' Declarar objeto específico y tabla de destino
                        Dim clCertifAcero As New ObraCertificacionesAcero
                        Dim dUpdate As New DataTable
                        Dim ddifPrecio As Decimal
                        dUpdate = clCertifAcero.AddNewForm()

                        ddifPrecio = rselaboracion.Rows(0)("precio") - rselaboracionc.Rows(0)("Precio")
                        ' Meter contralinea
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Anulación certificación Nº " & lCertificaAnt & " medios Especiales de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 4
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") * -1
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                        ' Meter facturado realmente, Se suma al precio anterior la diferencia, si es negativa resta y sino suma
                        dUpdate = clCertifAcero.AddNewForm()
                        dUpdate.Rows(0)("NCERTIFICACION") = lNumcertifica
                        dUpdate.Rows(0)("IDOBRA") = Me.CurrentRow("IDObra")
                        dUpdate.Rows(0)("IDUDMEDIDA") = "M3"
                        dUpdate.Rows(0)("CANTIDAD") = 0
                        dUpdate.Rows(0)("CONCEPTO") = "Diferencia certif. Nº " & lCertificaAnt & " medios Especiales de Acero puesto obra " & cPrecio
                        dUpdate.Rows(0)("TOTAL") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("MES") = rselaboracionc.Rows(0)("Mes")
                        dUpdate.Rows(0)("TIPO") = 4
                        dUpdate.Rows(0)("PRECIO") = rselaboracionc.Rows(0)("Precio") + ddifPrecio
                        '' Ejecutar el Insert
                        clCertifAcero.Update(dUpdate)
                        dUpdate.Clear()
                    End If
                End If
            End If
            If frmOpciones.RB2.Checked = True Then
                cPrecio = "B"
            End If
        Loop

        'End If
        ' Bien
        ' Liberar memoria
        rselaboracion.Dispose()
        rselaboracion = Nothing
        rselaboracionc.Dispose()
        rselaboracionc = Nothing
        System.GC.Collect()
        Return 1
    End Function

    Private Function TraerNobra(ByVal idObra As Integer) As String
        Dim ClObra As New ObraMedicionAcero
        Return ClObra.GetNumObra(idObra)
    End Function

    ' Calculo Columnas de Grid
    Private Sub CalculoMedicion()
        Dim gblnAutoCalculando As Boolean
        With GridMediciones
            If Not gblnAutoCalculando Then
                If IsNumeric(.Columns("PesoPedido").Index) Then 'And IsNumeric(.Columns("CertificadoSuministro").Index) Then
                    gblnAutoCalculando = True
                    ' .Value(.Columns("TotalSuministro").Index) = xRound(Nz(.Value(.Columns("PesoPedido").Index), 0) - Nz(.Value(.Columns("CertificadoSuministro").Index), 0), 6)
                    .Value(.Columns("TotalMontaje").Index) = xRound(Nz(.Value(.Columns("PesoPedido").Index), 0) - Nz(.Value(.Columns("CertificadoMontaje").Index), 0), 6)

                    'IBIS. David
                    If chbMedElev.Checked = True Then
                        .Value(.Columns("TotalMediosE").Index) = xRound(Nz(.Value(.Columns("PesoPedido").Index), 0) - Nz(.Value(.Columns("CertificadoMediosE").Index), 0), 6)
                    End If
                    '.Value(.Columns("TotalMediosE").Index) = xRound(Nz(.Value(.Columns("PesoPedido").Index), 0) - Nz(.Value(.Columns("CertificadoMediosE").Index), 0), 6)
                    gblnAutoCalculando = False

                    'IBIS. David
                    .Value(.Columns("TotalSuministro").Index) = .Value(.Columns("PesoPedido").Index) - .Value(.Columns("CertificadoSuministro").Index)
                    '.Value(.Columns("TotalSuministro").Index) = .Value(.Columns("CertificadoSuministro").Index) - .Value(.Columns("CertificadoMontaje").Index)

                    .Value(.Columns("DiferenciaP").Index) = xRound(CDbl(Nz(.Value(.Columns("PesoPlanilla").Index), 0)) - CDbl(Nz(.Value(.Columns("Planilla").Index), 0)), 6)

                    'IBIS. David. Para la elaboración
                    .Value(.Columns("MedElaboracion").Index) = Nz(.Value(.Columns("PesoPedido").Index), 0) - Nz(.Value(.Columns("FacElaboracion").Index), 0)

                Else
                    MessageBox.Show("El Valor ingresado no es valido", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If .Value(.Columns("PesoPedido").Index) < .Value(.Columns("PesoPlanilla").Index) Then
                    MessageBox.Show("El Peso a facturar no puede ser menor que el Peso planilla", "Peso Facturación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'IBIS. David
                    Me.Cancel.InvokeOnClick()
                    Exit Sub
                End If
            End If
        End With
    End Sub

    ' Obtener contador d NºCarga
    Private Function ContadorNcarga() As Short
        Dim shCont As Short
        Try
            Dim cContCarga As New Contador2
            shCont = CShort(Contador2.CounterValue("CONTNCARGA"))
            cContCarga = Nothing
        Catch ex As Exception
            MsgBox("Error al obtener contador de carga." & ex.Message, MsgBoxStyle.Exclamation, "Error en contador de Nº de carga.")
            shCont = -1
        End Try
        ' Bien
        Return shCont
    End Function

    ' Nº de factura venta extendida
    Private Function ContFacturaExtendida(ByVal idObra As Integer) As String
        Dim sSql As String
        Dim Dt As DataTable
        sSql = "SELECT NFacturaExtendida, FechaFactura " & _
               " FROM tbFacturaVentaCabecera " & _
               " WHERE IDFactura IN(SELECT idFactura " & _
               " FROM tbFacturaVentaLinea " & _
               " WHERE IDObra = " & idObra & " )  AND NFacturaExtendida NOT LIKE 'RE%' order by FechaFactura,nFacturaExtendida"
        Try
            Dt = AdminData.GetData(sSql, False)
            Dt.DefaultView.Sort = "FechaFactura"
            If Dt.Rows.Count > 0 AndAlso Not IsDBNull(Dt.Rows(0)) Then
                Dim sTroceaNum() As String
                sTroceaNum = Split(Dt.Rows(Dt.Rows.Count - 1)("NFacturaExtendida"), ".")
                If sTroceaNum.Length > 0 Then
                    ' Formato establecido, retornar la última parte del Nº de factura + 1
                    Return CStr(CInt(sTroceaNum(sTroceaNum.Length - 1)) + 1)
                Else
                    ' No es el formato establecido
                    MsgBox("El formato de la última factura no es correcto:" & Dt.Rows(Dt.Rows.Count - 1)("NFacturaExtendida") & ".Nº de factura por defecto 0.", MsgBoxStyle.Exclamation, "Error un tratamiento de datos.")
                    Return "0"
                End If
            Else
                ' No hay Facturas
                Return "1"
            End If
        Catch ex As Exception
            'Error en obtención, mostrar e indicar defecto = 0
            MsgBox("Error la localizar facturas de la obra." & ex.Message & ".Nº de factura por defecto 0.", MsgBoxStyle.Exclamation, "Error en obtención de datos.")
            Return "0"
        End Try
    End Function

    ' Obtener detalles de facturación a origen/Crear linea ANT1 = 0 para nuevas.23/03/2010
    Private Function LineasFactOrigen(ByRef dtCabecera As DataTable, ByRef dtLineas As DataTable, ByVal sNumFactExtendida As String) As Short
        Dim sSql As String
        Dim dFila, dFilaAnt As DataRow
        Dim dFactAntes As Decimal = 0
        Try

            ' Controlar si es nueva la factura o ya hay más
            If CInt(sNumFactExtendida) > 1 Then
                sSql = "SELECT tbFacturaVentaLinea.* " & _
                       " FROM tbFacturaVentaCabecera,tbFacturaVentaLinea " & _
                       " WHERE tbFacturaVentaLinea.IDObra = " & Me.CurrentRow("IDObra") & " AND NFacturaExtendida NOT LIKE 'RE%' " & _
                       " AND tbFacturaVentaCabecera.NFacturaExtendida LIKE ('%." & (CInt(sNumFactExtendida) - 1) & "%') " & _
                       " AND tbFacturaVentaCabecera.IDFactura = tbFacturaVentaLinea.IDFactura order by idOrdenLinea"

                ' Crear El dtOrigen
                Dim dtOrigen As DataTable = AdminData.GetData(sSql, False)
                For iCont As Integer = 0 To dtOrigen.Rows.Count - 1

                    dFila = dtLineas.NewRow

                    ' Aplicar las reglas de tabla
                    dFila.ItemArray = dtOrigen.Rows(iCont).ItemArray
                    dFila("IDLineaFactura") = AdminData.GetAutoNumeric
                    dFila("IDFactura") = dtCabecera.Rows(0)("IDFactura")
                    dFila("NFactura") = dtCabecera.Rows(0)("NFactura")
                    dFila("IDCentroGestion") = mstrIDCGestion

                    ' Control d importe facturado antes
                    If Strings.UCase(dFila("IDArticulo")) <> "ANT1" Then
                        ' Sumar linea en negativo siempre
                        dFactAntes -= dFila("Importe")
                    Else
                        ' Identificar la fila de facturado, lo facturado anteriormente es el sumatorio de las demás
                        ' dFilaAnt = dFila
                    End If

                    'IBIS. David. 14/06/2010. Sacado fuera del Else
                    dFilaAnt = dFila

                    ' Añadir a la tabla
                    dtLineas.Rows.Add(dFila)
                Next
                ' Ahora act. el inporte de la linea y la cabecera
                dFilaAnt("Precio") = (dFactAntes)
                dFilaAnt("PrecioA") = (dFactAntes)
                dFilaAnt("PrecioB") = (dFactAntes)
                dFilaAnt("Importe") = (dFactAntes)
                dFilaAnt("ImporteA") = (dFactAntes)
                dFilaAnt("ImporteB") = (dFactAntes)
                ' En la cabecera viene en positivo
                dtCabecera.Rows(0)("FacturadoAnteriorMente") = (dFactAntes * -1)
            Else
                dFactAntes = 0
                ' Es la primera facturación, crear fila Ant1
                dFila = dtLineas.NewRow
                ' Aplicar las reglas de tabla
                dFila.ItemArray = dtLineas.Rows(0).ItemArray
                dFila("IDLineaFactura") = AdminData.GetAutoNumeric
                dFila("IDFactura") = dtCabecera.Rows(0)("IDFactura")
                dFila("NFactura") = dtCabecera.Rows(0)("NFactura")
                dFila("IDCentroGestion") = mstrIDCGestion
                dFila("idOrdenLinea") = -1
                dFila("IDArticulo") = "ant1"
                dFila("DescArticulo") = "Facturado Anteriormente 1"
                dFila("IDTipoIva") = strIVA
                dFila("Cantidad") = 1
                dFila("Precio") = 0
                dFila("PrecioA") = 0
                dFila("PrecioB") = 0
                dFila("Importe") = 0
                dFila("ImporteA") = 0
                dFila("ImporteB") = 0
                dFila("IdObra") = Me.CurrentRow("IDObra")
                dFila("UdValoracion") = 1
                dFila("CContable") = "7000000000"
                dFila("IDUDMedida") = "UND"
                dFila("IDUdInterna") = "M2"
                ' Añadir a la tabla
                dtLineas.Rows.Add(dFila)
            End If
            ' Bien
            Return 1

        Catch ex As Exception
            MsgBox("Error al crear orígenes de facturación." & ex.Message, MsgBoxStyle.Exclamation, "Error en creación de orígenes.")
            Return -1
        End Try
    End Function

    ' Se le pasan la cabecera y los detalles para sumar
    Private Function CalculaCab(ByRef vValor As Double, ByRef dtCabecera As DataTable, ByVal dtLineas As DataTable) As Short
        Try
            vValor = 0
            For shCont As Short = 0 To dtLineas.Rows.Count - 1
                vValor += dtLineas.Rows(shCont)("Importe")
            Next

            ' Bien, Act. Lineas
            dtCabecera.Rows(0)("ImpLineas") = Nz(vValor, 0)
            dtCabecera.Rows(0)("ImpLineasA") = Nz(vValor, 0)
            dtCabecera.Rows(0)("ImpLineasB") = Nz(vValor, 0)

            dtCabecera.Rows(0)("ImporteTotalCert") = Nz(vValor, 0)
            dtCabecera.Rows(0)("BaseImponible") = Nz(vValor, 0)
            dtCabecera.Rows(0)("BaseImponibleA") = Nz(vValor, 0)
            dtCabecera.Rows(0)("BaseImponibleB") = Nz(vValor, 0)

            dtCabecera.Rows(0)("ImpIVA") = Nz(vValor, 0) * pIVA
            dtCabecera.Rows(0)("ImpIVAA") = Nz(vValor, 0) * pIVA
            dtCabecera.Rows(0)("ImpIVAB") = Nz(vValor, 0) * pIVA

            dtCabecera.Rows(0)("ImpTotal") = Nz(dtCabecera.Rows(0)("BaseImponible"), 0) + Nz(dtCabecera.Rows(0)("ImpIVA"), 0)
            dtCabecera.Rows(0)("ImpTotalA") = Nz(dtCabecera.Rows(0)("BaseImponibleA"), 0) + Nz(dtCabecera.Rows(0)("ImpIVAA"), 0)
            dtCabecera.Rows(0)("ImpTotalB") = Nz(dtCabecera.Rows(0)("BaseImponibleB"), 0) + Nz(dtCabecera.Rows(0)("ImpIVAB"), 0)

        Catch ex As Exception
            MsgBox("Error al calcular importes de factura:" & ex.Message, MsgBoxStyle.Exclamation, "Error al calcular factura.")
            Return -1
        End Try
    End Function

    ' Se le pasan los detalles 
    Private Function OrdenarDet(ByRef dtLineas As DataTable) As Short
        Dim shOrden As Short = 1
        Dim dFilas() As DataRow
        Try

            '1º Ordenar Elaboración.
            dFilas = dtLineas.Select("descArticulo LIKE '%Elaboración de Acero%' or descArticulo LIKE '%Elaboracion de Acero%'", "idOrdenLinea,DescArticulo")
            If dFilas.Length > 0 Then
                OrdenarLin(shOrden, dFilas)
            End If
            '2º Ordenar Suministro.
            dFilas = dtLineas.Select("descArticulo LIKE '%Suministro de Acero%'", "idOrdenLinea,DescArticulo")
            If dFilas.Length > 0 Then
                OrdenarLin(shOrden, dFilas)
            End If
            '3º Ordenar Transporte.
            dFilas = dtLineas.Select("descArticulo LIKE '%TRANSPORTE%'", "idOrdenLinea,DescArticulo")
            If dFilas.Length > 0 Then
                OrdenarLin(shOrden, dFilas)
            End If
            '4º Ordenar Mallazo.
            dFilas = dtLineas.Select("descArticulo LIKE '%Mallazo%'", "idOrdenLinea,DescArticulo")
            If dFilas.Length > 0 Then
                OrdenarLin(shOrden, dFilas)
            End If
            '5º Acero soldado
            dFilas = dtLineas.Select("descArticulo LIKE '%Acero soldado%'", "idOrdenLinea,DescArticulo")
            If dFilas.Length > 0 Then
                OrdenarLin(shOrden, dFilas)
            End If
            ' Poner la última la fact. antes.
            dFilas = dtLineas.Select("IDArticulo LIKE '%ant%'", "idOrdenLinea,DescArticulo")
            If dFilas.Length > 0 Then
                dFilas(0)("idOrdenLinea") = shOrden
            End If
            ' Bien
            Return 1
        Catch ex As Exception
            MsgBox("Error En ordenación." & ex.Message, MsgBoxStyle.Exclamation, "Error en ordenación.")
            Return -1
        End Try
    End Function

    Private Sub OrdenarLin(ByRef shOrden As Short, ByRef dFilas() As DataRow)
        ' Ordenar las viejas
        For Each dfila As DataRow In dFilas
            If dfila("idOrdenLinea") > 0 Then
                dfila("idOrdenLinea") = shOrden
                shOrden += 1
            End If
        Next

        ' Ordenar La nuevas y quitar los 6 caracteres de descripción (00 diámetro,00 Mes, 00 año).
        For Each dfila As DataRow In dFilas
            If dfila("idOrdenLinea") < 0 Then
                dfila("idOrdenLinea") = shOrden
                dFila("descArticulo") = Strings.Right(dFila("descArticulo"), CStr(dfila("DescArticulo")).Length - 6)
                shOrden += 1
            End If
        Next
    End Sub

#End Region

    Private Sub GridMediciones_GetNewRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.GetNewRowEventArgs) Handles GridMediciones.GetNewRow
        If GridMediciones.GetValue("D8") Is Nothing Then
            GridMediciones.SetValue("D8", 0)
        End If

        If GridMediciones.GetValue("D10") Is Nothing Then
            GridMediciones.SetValue("D10", 0)
        End If

        If GridMediciones.GetValue("D12") Is Nothing Then
            GridMediciones.SetValue("D12", 0)
        End If

        If GridMediciones.GetValue("D16") Is Nothing Then
            GridMediciones.SetValue("D16", 0)
        End If

        If GridMediciones.GetValue("D20") Is Nothing Then
            GridMediciones.SetValue("D20", 0)
        End If

        If GridMediciones.GetValue("D25") Is Nothing Then
            GridMediciones.SetValue("D25", 0)
        End If
        If GridMediciones.GetValue("D32") Is Nothing Then
            GridMediciones.SetValue("D32", 0)
        End If
        'GridMediciones.SetValue("D32", 0)
    End Sub

End Class


