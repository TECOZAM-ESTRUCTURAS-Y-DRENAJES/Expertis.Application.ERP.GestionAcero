Public Class frmProveedor

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public blEstado As Boolean
    Public opcion As String = "0"


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        blEstado = True
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If opc1.Checked = True Then
            opcion = "4000000019"
        ElseIf opc2.Checked = True Then
            opcion = "4000000029"
        ElseIf opc3.Checked = True Then
            opcion = "4000000030"
        End If
        blEstado = False
        Me.Close()
    End Sub
End Class