Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Engine.UI

Public Class CIMedicionAceroEstado
    Inherits Solmicro.Expertis.Engine.UI.CIMnto
    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
    End Sub

    Private Sub CIMedicionAceroEstado_QueryExecuting(ByVal sender As System.Object, ByRef e As Solmicro.Expertis.Engine.UI.QueryExecutingEventArgs) Handles MyBase.QueryExecuting

        e.Filter.Add("NObra", FilterOperator.Equal, advNObra.Text, FilterType.String)
        If (cmbEstado.Text = "Proyectado") Then
            e.Filter.Add("Estado", FilterOperator.Equal, 0, FilterType.Numeric)
        ElseIf (cmbEstado.Text = "Comenzado") Then
            e.Filter.Add("Estado", FilterOperator.Equal, 1, FilterType.Numeric)
        ElseIf (cmbEstado.Text = "Terminado") Then
            e.Filter.Add("Estado", FilterOperator.Equal, 2, FilterType.Numeric)
        End If
        e.Filter.Add("Fecha", FilterOperator.GreaterThanOrEqual, clbFecha.Value, FilterType.DateTime)
        e.Filter.Add("Fecha", FilterOperator.LessThanOrEqual, clbFecha1.Value, FilterType.DateTime)
        e.Filter.Add("Mes", FilterOperator.Equal, cbMes.Value)
        e.Filter.Add("Año", FilterOperator.Equal, cbAño.Value)

    End Sub

    Private Sub CIMedicionAceroEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEstado.DataSource = New EnumData("enumocEstado")
        cbMes.DataSource = New EnumData("enumcaMesAño")
        cargarComboAnio()
    End Sub
    Private Sub cargarComboAnio()
        Dim dtcombo As New DataTable
        dtcombo.Columns.Add("Anio")

        Dim dr As DataRow

        For i As Integer = 0 To 10
            Dim j As Integer = Year(Today)
            dr = dtcombo.NewRow()
            dr("Anio") = j - i
            dtcombo.Rows.Add(dr)
        Next
        cbAño.DataSource = dtcombo

    End Sub

    Private Sub advNObra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles advNObra.TextChanged
        'Try
        '    Dim idObra As String
        '    idObra = advNObra.Value
        '    Dim dt As New DataTable
        '    Dim filtro As New Filter
        '    filtro.Add("IDObra", FilterOperator.Equal, idObra)
        '    dt = New BE.DataEngine().Filter("frmMntoObras", filtro)
        '    If dt.Rows(0)("DiaFacturacion") Is DBNull.Value Then
        '        txtDiaCierre.Text = "No tiene dia asignado."
        '    Else
        '        txtDiaCierre.Text = dt.Rows(0)("DiaFacturacion")
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub advNObra_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles advNObra.Leave
        Try
            Dim NObra As String
            NObra = advNObra.Text
            Dim dt As New DataTable
            Dim filtro As New Filter
            filtro.Add("NObra", FilterOperator.Equal, NObra)
            dt = New BE.DataEngine().Filter("frmMntoObras", filtro)
            If dt.Rows(0)("DiaFacturacion") Is DBNull.Value Then
                txtDiaCierre.Text = "No tiene dia asignado."
            Else
                txtDiaCierre.Text = dt.Rows(0)("DiaFacturacion")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class