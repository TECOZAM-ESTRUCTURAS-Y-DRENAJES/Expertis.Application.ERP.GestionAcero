Imports Solmicro.Expertis.Engine.DAL
Imports Solmicro.Expertis.Engine
Imports System.Windows.Forms
Imports Solmicro.Expertis.Business.Negocio

Public Class frmEntidad

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public lNumCerti As Long
    Public sContador As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fwnEntidadCont As EntidadContador
        Dim f As Filter

        If TxtNumCertif.Text = "" Then
            UI.ExpertisApp.GenerateMessage("Debe seleccionar un Nº de certificación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If IsDBNull(AdvContador.Value) Then
            UI.ExpertisApp.GenerateMessage("Debe seleccionar un Contador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        fwnEntidadCont = New EntidadContador
        f.Add(New StringFilterItem("IDContador", FilterOperator.Equal, AdvContador.Value))
        f.Add(New StringFilterItem("Entidad", FilterOperator.Equal, "FacturaVentaCabecera"))

        If AdvContador.Value = 0 Then
            Engine.UI.ExpertisApp.GenerateMessage("El contador indicado es incorrecto", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            Exit Sub
        End If

        AdvContador.Value = 0
        fwnEntidadCont = Nothing
        lNumCerti = TxtNumCertif.Text
        sContador = AdvContador.Value
        Me.Close()
    End Sub

    Private Sub FrmEntidad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim f As New Filter
        f.Add(New StringFilterItem("Entidad", FilterOperator.Equal, "FacturaVentaCabecera"))
        AdvContador.PredefinedFilter = f
    End Sub

End Class