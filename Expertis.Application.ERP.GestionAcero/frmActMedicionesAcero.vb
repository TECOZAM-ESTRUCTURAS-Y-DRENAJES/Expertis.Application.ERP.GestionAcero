Imports Solmicro.Expertis.Engine.UI
Imports System.Windows.Forms

Public Class frmActMedicionesAcero

    Private Sub frmActMedicionesAcero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EBAlbaColada.Text = ""
        EBAlbaColada.Focus()
    End Sub

    Private Sub EBAlbaColada_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles EBAlbaColada.Validated
        If EBAlbaColada.Text.Length > 0 Then
            ExpertisApp.GenerateMessage(EBAlbaColada.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Siguiente medición
            EBAlbaColada.Text = ""
            EBAlbaColada.Focus()
        End If
    End Sub
End Class