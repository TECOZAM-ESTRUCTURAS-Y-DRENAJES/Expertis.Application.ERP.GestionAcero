Imports Solmicro.Expertis.Business.Negocio
Imports Solmicro.Expertis.Engine.DAL
Imports Solmicro.Expertis.Engine.UI
Imports Solmicro.Expertis.Engine

Public Class frmFactDiametro

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public sContador As String
    Friend bGenerar As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fwnEntidadCont As EntidadContador
        Dim f As New Filter
        ' Control de fechas

        If IsDBNull(Fdesde.Value) Then
            MsgBox("Debe indicar una fecha desde la que facturar.", MsgBoxStyle.Exclamation, "Dato requerido")
            Fdesde.Focus()
            Exit Sub
        End If

        If IsDBNull(Fhasta.Value) Then
            MsgBox("Debe indicar una fecha hasta la que se factura.", MsgBoxStyle.Exclamation, "Dato requerido")
            Fhasta.Focus()
            Exit Sub
        End If

        If IsDBNull(AdvContador.Value) Then
            MsgBox("Debe seleccionar un Contador", vbExclamation + vbOKOnly)
            AdvContador.Focus()
            Exit Sub
        End If

        fwnEntidadCont = New EntidadContador
        f.Add(New StringFilterItem("IDContador", AdvContador.Value))

        If AdvContador.Value = 0 Then
            MsgBox("El contador indicado es incorrecto", vbCritical, ExpertisApp.Title)
            Exit Sub
        End If

        fwnEntidadCont = Nothing
        sContador = AdvContador.Value
        bGenerar = True
        Me.Close()
    End Sub

    Private Sub FrmEntidad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Asignación de fechas
        Fdesde.Value = "01/" & Today().Month & "/" & Today.Year
        Fhasta.Value = Today
        Dim f As New Filter
        f.Add(New Engine.StringFilterItem("Entidad", Engine.FilterOperator.Equal, "FacturaVentaCabecera"))
        AdvContador.PredefinedFilter = f

    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancel.Click
        bGenerar = False
        Me.Close()
    End Sub

End Class