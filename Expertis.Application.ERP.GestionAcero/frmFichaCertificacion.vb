Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Engine.UI

Public Class frmFichaCertificacion

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public idobra As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text <> "" Then
            Dim rp As New Report("FCERTACERO")
            Dim filtro As New Filter
            'filtro.Add("Nobra", FilterOperator.Equal, obra)
            filtro.Add("IDObra", FilterOperator.Equal, idobra)
            filtro.Add("NCertificacion", FilterOperator.Equal, TextBox1.Text)
            rp.Formulas("Retencion").Text = NumericTextBox1.Text
            rp.DataSource = New BE.DataEngine().Filter("vrptFichaCertificacionAcero", filtro)
            ExpertisApp.OpenReport(rp)
        End If

        Me.Close()
    End Sub

    Private Sub FrmFichaCertificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericTextBox1.Text = 5
        TextBox1.Focus()
    End Sub

End Class