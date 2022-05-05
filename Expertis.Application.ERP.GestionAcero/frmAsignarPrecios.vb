Public Class frmAsignarPrecios
    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public Bien As Boolean

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Bien = True
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Bien = False
        Me.Close()
    End Sub
End Class