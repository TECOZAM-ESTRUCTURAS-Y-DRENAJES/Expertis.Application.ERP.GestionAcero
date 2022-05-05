Imports System.Drawing
Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Engine.DAL
Imports System.Windows.Forms
Imports Solmicro.Expertis.Engine.UI
Imports Solmicro.Expertis.Business.Negocio

Public Class frmNumeroSerie

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Private mintNumDiametro As Integer
    Private mdblCantidad As Double
    Private mstrNumMedicion As Integer

    Private mblnSoloLectura As Boolean
    Private mrcsSource As DataTable
    Private mstrIDArticulo As String
    Private mstrIDAlmacen As String
    Dim mdblCantidadReal As Double
    Private bEliminar As Boolean
    Private mstrNSerie As String

    Dim dttsource As DataTable
    Dim pos As Integer
#Region " Properties "

    Public Property soloLectura() As Boolean
        Get
            Return mblnSoloLectura
        End Get
        Set(ByVal Value As Boolean)
            mblnSoloLectura = Value
        End Set
    End Property

    Public Property NumDiametro() As Integer
        Set(ByVal Value As Integer)
            mintNumDiametro = Value
        End Set
        Get
            Return mintNumDiametro
        End Get
    End Property

    Public Property Cantidad() As Double
        Set(ByVal Value As Double)
            mdblCantidad = Value
        End Set
        Get
            Return mdblCantidad
        End Get
    End Property

    Public Property numMedicion() As Integer
        Set(ByVal Value As Integer)
            mstrNumMedicion = Value
        End Set
        Get
            Return mstrNumMedicion
        End Get
    End Property

#End Region

#Region " Eventos Formulario "

    Private Sub frmNumeroSerie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            NtbDiferencia.ForeColor = Color.Red
            NtbCantidadAsignar.ForeColor = Color.Blue
            NtbCantidadAsignada.ForeColor = Color.Blue
            NtbDiferencia.Font = New Font("Verdana", 8, FontStyle.Bold)
            NtbCantidadAsignar.Font = New Font("Verdana", 8, FontStyle.Bold)
            NtbCantidadAsignada.Font = New Font("Verdana", 8, FontStyle.Bold)

            Dim f As New Filter
            f.Add("IDLineaAlbaranVenta", mstrNumMedicion)
            f.Add("Diametro", mintNumDiametro)

            GridNSerie.DataSource = AdminData.GetData("vFrmMntoAlbaranVentaNSerie", f)

            'GridNSerie.DataSource = AdminData.GetData("tbArticuloNumeroSerie", f)

            GridNSerie.Refresh()
            GridNSerie.HoldFields()

            TxtIDArticulo.Enabled = False
            TxtIDArticulo.Text = mintNumDiametro
            NtbCantidadAsignar.Value = mdblCantidad
            'UlbDescArticulo.Text = mstrDescArticulo
            'TxtIDAlmacen.Text = Nz(mstrIDAlmacen, "")

            'mdblCantidadReal = mdblCantidad
            'mdblCantidad = Math.Abs(mdblCantidadReal)

            If Not mblnSoloLectura Then
                GridNSerie.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                GridNSerie.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                GridNSerie.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridNSerie.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                GridNSerie.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                GridNSerie.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If

            ActualizarTotales()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmNumeroSerie_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            If Not mblnSoloLectura Then
                With GridNSerie
                    If Not .DataSource Is Nothing Then
                        If .AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
                            .Row = -1
                            .Col = .Columns("NSerie").Index
                        End If
                        .Focus()
                    Else
                        .Enabled = False
                    End If
                End With
            Else
                BtnCerrar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region " Imagenes "

    Private Sub TxtFichero_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFichero.DoubleClick
        Try
            OpenDocument(TxtFichero.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarImagen(ByVal articulo As String, ByVal serie As String)
        Try
            Dim dsFoto As New DataTable
            Dim campoImagen As String = "Logo" & pos
            Dim campoTexto As String = "Fichero" & pos
            dsFoto = AdminData.GetData("Select * from tbarticulonumeroserie where NSerie =  '" & serie & "'")
            'dsFoto = AdminData.GetData("Select * from tbarticulonumeroserie where IDArticulo = '" & articulo & "' and NSerie =  '" & serie & "'")
            If dsFoto.Rows.Count > 0 Then
                If Not IsDBNull(dsFoto.Rows(0)(campoImagen)) Then
                    Dim bits As Byte() = CType(dsFoto.Rows(0)(campoImagen), Byte())
                    Dim memorybits As New System.io.MemoryStream(bits)
                    Dim bitmap As New bitmap(memorybits)
                    PcbImagen.Image = bitmap
                    Lbltitulo.Text = "Imagen " & pos
                    TxtFichero.Text = dsFoto.Rows(0)(campoTexto)
                    dsFoto = Nothing
                Else
                    PcbImagen.Image = Nothing
                    Lbltitulo.Text = "Imagen " & pos
                    TxtFichero.Text = ""
                End If
            Else
                PcbImagen.Image = Nothing
                Lbltitulo.Text = "Imagen " & pos
                TxtFichero.Text = ""
            End If
            GridNSerie.MoveTo(GridNSerie.GetRow.RowIndex)
        Catch EX As Exception
            MessageBox.Show(EX.Message, "No se puede mostrar fotografia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BtnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnterior.Click
        Try
            If pos > 1 Then
                pos = pos - 1
                CargarImagen(mstrIDArticulo, mstrNSerie)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        Try
            If pos < 8 Then
                pos = pos + 1
                CargarImagen(mstrIDArticulo, mstrNSerie)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVistaPrevia.Click
        Try
            If Not IsNothing(PcbImagen.Image) Then
                'Dim StProcess As New ProcessStartInfo(TxtFichero.Text)
                'StProcess.WindowStyle = ProcessWindowStyle.Maximized
                'Process.Start(StProcess)

                Dim ventana As New FrmVistaPrevia
                ventana.PictureBox1.Image = PcbImagen.Image
                ventana.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region " Procedimientos / Funciones GridNSerie "

    Private Sub ActualizarTotales()
        Try
            NtbCantidadAsignar.Text = mdblCantidad
            NtbCantidadAsignada.Text = Nz(GridNSerie.GetTotal(GridNSerie.Columns("Cantidad"), Janus.Windows.GridEX.AggregateFunction.Sum), 0)
            NtbDiferencia.Value = Nz(NtbCantidadAsignar.Text, 0) - Nz(NtbCantidadAsignada.Value, 0)
            If Nz(NtbCantidadAsignada.Text, 0) > 0 Then
                If NtbCantidadAsignada.Text >= mdblCantidad Then
                    'David. Quieren poder añadir +
                    'GridNSerie.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                    GridNSerie.Refresh()
                Else
                    GridNSerie.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    GridNSerie.Refresh()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function OpenDocument(ByVal DocumentWithPath As String) As Long
        Try
            If "" <> Dir(DocumentWithPath, vbDirectory) Then
                OpenDocument = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & DocumentWithPath, vbNormalFocus)
            Else
                MsgBox("El fichero no existe en la ubicación especificada: " & vbCrLf & _
                       DocumentWithPath, vbOKOnly + vbExclamation, ExpertisApp.Title)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    'IBIS. David
    Private Function ClaveDuplicada(ByVal strNSerie As String, ByVal mstrIDArticulo As String) As Boolean
        Dim strMsg As String
        Dim rcsAux As New DataTable
        Dim f As Filter
        Dim sc As Boolean
        Dim obj As New ArticuloNumeroSerie

        Try
            If Len(strNSerie) > 0 Then
                Me.Cursor = Cursors.WaitCursor
                If Not GridNSerie.DataSource Is Nothing Then
                    rcsAux = GridNSerie.DataSource.Clone
                    f.Add(New StringFilterItem("NSerie", FilterOperator.Equal, strNSerie))
                    ClaveDuplicada = (rcsAux.Rows.Count > 0)
                End If

                'Para q nos pase el articulo bien cuando lo escribimos a mano---------
                If IsNothing(mstrIDArticulo) Then
                    Dim dtartu As New DataTable
                    Dim fartu As New Filter
                    fartu.Add("NSerie", strNSerie)
                    dtartu = AdminData.GetData("tbAlbaranCompraNSerie", fartu, "IDArticulo")
                    If dtartu.Rows.Count > 0 Then
                        GridNSerie.SetValue("IDArticulo", dtartu.Rows(0)(0))
                        mstrIDArticulo = dtartu.Rows(0)(0)
                    End If
                    dtartu = Nothing
                    fartu = Nothing
                    Return False
                End If
                '---------------------------------------------------------------------

                If Not ClaveDuplicada AndAlso Not IsNothing(mstrIDArticulo) Then
                    'IBIS. David-------------------------------------------------------------
                    Dim objStock As New ArticuloNumeroSerie
                    Dim dtStock As New DataTable
                    Dim fStock As New Filter

                    fStock.Add("IDArticulo", mstrIDArticulo)
                    fStock.Add("NSerie", strNSerie)
                    dtStock = objStock.Filter(fStock)
                    mdblCantidadReal = dtStock.Rows(0)("Stock")
                    '------------------------------------------------------------------

                    sc = obj.SePuedeVenderNSerie(mstrIDArticulo, strNSerie, IIf(mdblCantidadReal > 0, False, True), strMsg)

                    If Not (sc) Then ClaveDuplicada = True
                End If
                Me.Cursor = Cursors.Default
            End If
            If ClaveDuplicada Then
                strMsg = "La referencia ingresada ya está registrada"
                MsgBox(strMsg, vbExclamation, ExpertisApp.Title)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            rcsAux = Nothing
        End Try
    End Function

    Private Function VerificarCantidadCorrecta(ByVal Cantidad As Double, ByVal idLinea As Long, ByVal serie As String, ByVal mstrIDArticulo As String) As Boolean
        Dim lngTotal As Double
        'Dim dttGrid As New DataTable
        Dim dtt As New DataTable
        Dim obj As New ArticuloNumeroSerie
        Try

            'Para q nos pase el articulo bien cuando lo escribimos a mano---------
            If mstrIDArticulo = "" Then
                Dim dtartu As New DataTable
                Dim fartu As New Filter
                fartu.Add("NSerie", serie)
                dtartu = AdminData.GetData("tbAlbaranCompraNSerie", fartu, "IDArticulo")
                If dtartu.Rows.Count > 0 Then
                    GridNSerie.SetValue("IDArticulo", dtartu.Rows(0)(0))
                    mstrIDArticulo = dtartu.Rows(0)(0)
                End If
                dtartu = Nothing
                fartu = Nothing
            End If
            '---------------------------------------------------------------------

            If Math.Abs(Cantidad) > Math.Abs(mdblCantidad) Then
                '### 22-05-08 David. Quieren poder meter + Kilos en las coladas q el peso real.
                'MsgBox("La cantidad indicada supera la cantidad total a asignar", vbExclamation, "Indique otra Cantidad")
                'IBIS. David
                'VerificarCantidadCorrecta = True
                Return True
            ElseIf (mdblCantidadReal > 0) And Cantidad < 0 Then
                MsgBox("La cantidad indicada debe ser mayor que 0", vbExclamation, "Indique otra Cantidad")
                Return False
            ElseIf (mdblCantidadReal < 0) And Cantidad > 0 Then
                MsgBox("La cantidad indicada debe ser Menor que 0", vbExclamation, "Indique otra Cantidad")
                Return False
            ElseIf Not obj.HayStock(mstrIDArticulo, serie, Cantidad) Then
                MsgBox("No hay stock para registrar la cantidad indicada", vbExclamation, "Indique otra Cantidad")
                Return False
            Else
                dtt = GridNSerie.DataSource
                If dtt.Rows.Count > 0 Then
                    'dttGrid = dtt.Clone
                    For Each fila As DataRow In dtt.Rows
                        If fila("AlbaranVentaNSerie") <> idLinea Then lngTotal = lngTotal + fila("Cantidad")
                    Next
                End If

                'If Math.Abs(Cantidad + lngTotal) > Math.Abs(mdblCantidadReal) Then
                If Math.Abs(Cantidad + lngTotal) > Math.Abs(mdblCantidad) Then
                    'David
                    'MsgBox("La cantidad indicada supera la cantidad total a asignar", vbExclamation, "Indique otra Cantidad")
                    'Else
                    'VerificarCantidadCorrecta = True
                    Return False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            dtt = Nothing
        End Try
        Return True
    End Function

#End Region

#Region " GridNSerie "

    Private Sub GridNSerie_AdvSearchSetPredefinedFilter(ByVal sender As Object, ByVal e As Engine.UI.GridAdvSearchFilterEventArgs) Handles GridNSerie.AdvSearchSetPredefinedFilter
        Try
            'David, q solo filtre por diametro.
            'e.Filter.Add("IDArticulo", mstrIDArticulo)
            e.Filter.Add("Diametro", CStr(mintNumDiametro))
            'e.Filter.Add("Stock", FilterOperator.GreaterThan, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridNSerie.Click
        Try
            dttsource = Nothing
            If GridNSerie.Row <> -1 Then
                pos = 1
                mstrNSerie = GridNSerie.Value(GridNSerie.Columns("NSerie").Index)
                CargarImagen(mstrIDArticulo, mstrNSerie)
            End If
            'IBIS. David
            GridNSerie.Columns("NSerie").DefaultValue = "(" & TxtIDArticulo.Text & ")" 'Diametro
            GridNSerie.Columns("IDLineaAlbaranVenta").DefaultValue = mstrNumMedicion
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles GridNSerie.UpdatingCell
        Try
            With GridNSerie
                Select Case e.Column.Index
                    Case .Columns("NSerie").Index

                        If Len(e.Value) = 0 Then
                            ExpertisApp.GenerateMessage("9349", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, .Columns("NSerie").Caption)
                            e.Cancel = True
                            'ElseIf Len(e.Value) = 0 Then
                            '    ExpertisApp.GenerateMessage(1215, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, ExpertisApp.Title)
                            '    e.Cancel = True

                            'IBIS. David Añadido IDArticulo para q funcione
                        ElseIf ClaveDuplicada(e.Value, .Value("IDArticulo")) Then
                            e.Cancel = True
                        End If

                        Dim dtt As DataTable
                        Dim f As New Filter
                        f.Add("NSerie", e.Value)
                        dtt = AdminData.GetData("tbAlbaranCompraNSerie", f, "Diametro")

                        If dtt.Rows.Count > 0 Then
                            .SetValue("Diametro", dtt.Rows(0)(0))
                        Else
                            MessageBox.Show("No se encuentra este Artículo en un Albarán de Compra", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    Case .Columns("Cantidad").Index
                        If Nz(e.Value, 0) = 0 Then
                            e.Cancel = True
                            MsgBox("La cantidad indicada no es correcta", vbExclamation, ExpertisApp.Title)
                        ElseIf Not VerificarCantidadCorrecta(e.Value, Nz(.Value(.Columns("AlbaranVentaNSerie").Index), 0), .Value(.Columns("NSerie").Index), .Value(.Columns("IDArticulo").Index)) Then
                            e.Cancel = True
                        End If
                End Select
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridNSerie.RecordUpdated
        Dim obj As New ArticuloNumeroSerie
        Try
            ActualizarTotales()

            'Actualizo  la tabla tbAlbaranVentaNSerie
            Dim Rs As New DataTable
            Dim Ng As New AlbaranVentaNSerie
            Rs = GridNSerie.DataSource
            Ng.Update(Rs)

            With GridNSerie
                obj.ActualizarArticuloNSerieV(.Value(.Columns("IDArticulo").Index), .Value(.Columns("NSerie").Index), .Value(.Columns("Cantidad").Index), Nz(.Value(.Columns("IDLineaAlbaranVenta").Index), 0))
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_RecordsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridNSerie.RecordsDeleted
        Dim obj As New ArticuloNumeroSerie
        With GridNSerie
            Try
                ActualizarTotales()

                'Actualizo la base de datos 
                Dim Rs As New DataTable
                Dim Ng As New AlbaranVentaNSerie
                Rs = GridNSerie.DataSource
                Ng.Update(Rs)

                obj.ActualizarStockNSerie(mstrIDArticulo, mstrNSerie)
                If bEliminar Then obj.EliminarNSerie(mstrIDArticulo, mstrNSerie)

                bEliminar = False

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End With
    End Sub

    Private Sub GridNSerie_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridNSerie.UpdatingRecord
        Dim ultimaVenta As Integer
        Dim obj As New ArticuloNumeroSerie
        Try
            With GridNSerie
                If Len(.Value(.Columns("NSerie").Index)) = 0 Then
                    ExpertisApp.GenerateMessage("9349", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, .Columns("NSerie").Caption)
                    e.Cancel = True
                    'ElseIf Nz(.Value(.Columns("Cantidad").Index), 0) = 0 Then
                    '    ExpertisApp.GenerateMessage("Indique la Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, ExpertisApp.Title, .Columns("Cantidad").Caption)
                    '    'MessageBox.Show("Indique la Cantidad", ExpertisApp.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    'MsgBox("Indique la cantidad", vbExclamation, ExpertisApp.Title)
                    '    e.Cancel = True
                    '    Exit Sub
                Else
                    If .Row = -1 Then
                        ultimaVenta = obj.UltimoDocVenta(.Value(.Columns("IDArticulo").Index), .Value(.Columns("NSerie").Index))
                        .Value(.Columns("IDLineaAnterior").Index) = ultimaVenta
                    End If
                End If

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridNSerie.RecordAdded
        'ActualizarTotales()
        'Actualizo la tabla tbAlbaranVentaNSerie
        Dim Rs As New DataTable
        Dim Ng As New AlbaranVentaNSerie
        Try
            'IBIS. David. 14/03/08
            Rs = GridNSerie.DataSource
            Ng.Update(Rs)

            Dim obj As New ArticuloNumeroSerie
            With GridNSerie
                obj.ActualizarArticuloNSerieV(.Value(.Columns("IDArticulo").Index), .Value(.Columns("NSerie").Index), .Value(.Columns("Cantidad").Index), Nz(.Value(.Columns("IDLineaAlbaranVenta").Index), 0))
            End With
            ActualizarTotales()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridNSerie.AddingRecord
        Try
            If IsDBNull(GridNSerie.Value(GridNSerie.Columns("NSerie").Index)) Then e.Cancel = True
            If e.Cancel = True Then
                BtnCerrar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridNSerie.KeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                If GridNSerie.Row <> -1 Then
                    GridNSerie.MoveToNewRecord()
                Else
                    GridNSerie_RecordAdded(sender, New System.EventArgs)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridNSerie_DeletingRecord(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles GridNSerie.DeletingRecord
        Dim UltimaCompra As Long
        Dim UltimaVenta As Long
        Dim nreg As Integer
        Dim obj As New ArticuloNumeroSerie

        Try
            With GridNSerie

                UltimaCompra = obj.UltimoDocCompra(e.Row.Cells("IDArticulo").Value, e.Row.Cells("NSerie").Value)
                UltimaVenta = obj.UltimoDocVenta(e.Row.Cells("IDArticulo").Value, e.Row.Cells("NSerie").Value)
                If UltimaCompra = 0 Then UltimaCompra = e.Row.Cells("IDLineaAlbaranVenta").Value
                If UltimaCompra <> e.Row.Cells("IDLineaAlbaranVenta").Value Or UltimaVenta <> 0 Then
                    'IBIS. David, q deje q borre
                    'e.Cancel = True
                    'MsgBox("No puede eliminar una línea que tiene un Albarán de Venta o Albaran de compra relacionado", vbExclamation, ExpertisApp.Title)
                Else
                    If e.Row.Cells("IDLineaAnterior").Value = 0 Then
                        If UltimaVenta = 0 Then
                            bEliminar = True
                        End If
                    End If
                    'Esto es para que actualize
                    obj.ActualizarUltimaVenta(e.Row.Cells("IDArticulo").Value, e.Row.Cells("NSerie").Value, e.Row.Cells("IDLineaAnterior").Value)
                    bEliminar = False
                    mstrNSerie = e.Row.Cells("NSerie").Value
                End If
            End With

            If Not e.Cancel = True Then e.Cancel = False '(FwGrid.DeleteLine() = fwmActionError)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            obj = Nothing
        End Try
    End Sub

#End Region

End Class