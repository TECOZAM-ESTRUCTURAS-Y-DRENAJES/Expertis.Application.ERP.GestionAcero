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
    End Sub

    Private Sub CIMedicionAceroEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEstado.DataSource = New EnumData("enumocEstado")
    End Sub
End Class