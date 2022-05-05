Public Class frmAsignarPreciosDiametro
    Inherits Solmicro.Expertis.Engine.UI.FormBase
    Public Bien As Boolean

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If IsDBNull(FDesde.Value) Then
            MsgBox("Debe indicar una fecha mínima de salida.", MsgBoxStyle.Exclamation, "Parámetro necesario.")
            FDesde.Focus()
            Exit Sub
        End If
        If IsDBNull(FHasta.Value) Then
            MsgBox("Debe indicar una fecha máxima de salida.", MsgBoxStyle.Exclamation, "Parámetro necesario.")
            FHasta.Focus()
            Exit Sub
        End If
        Bien = True
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Bien = False
        Me.Close()
    End Sub

    Private Sub FrmAsignarPreciosDiametro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        iniciar()
    End Sub

#Region " Funciones "

    Private Sub iniciar()
        FDesde.Value = "01/" & Today().Month & "/" & Today().Year
        FHasta.Value = Today()
    End Sub

#End Region
End Class