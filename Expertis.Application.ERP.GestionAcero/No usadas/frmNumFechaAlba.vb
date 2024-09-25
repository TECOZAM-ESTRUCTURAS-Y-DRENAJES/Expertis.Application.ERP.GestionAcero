Public Class frmNumFechaAlba
    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Friend Fventana As Date

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FSalida.Value = Today
    End Sub


    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Fventana = Me.FSalida.Value
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
        Fventana = Nothing
    End Sub
End Class