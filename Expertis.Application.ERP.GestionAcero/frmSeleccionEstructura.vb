Imports Solmicro.Expertis.Engine.UI

Public Class frmSeleccionEstructura

    Public Sub New()
        MyBase.New()
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbEstructura.Text.Length = 0 Then
            MsgBox("Seleccione una opcion")
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub frmSeleccionEstructura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEstructura.DataSource = New EnumData("EstructuraFerralla")
    End Sub
End Class