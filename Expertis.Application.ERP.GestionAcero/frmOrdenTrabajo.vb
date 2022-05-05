Imports Solmicro.Expertis.Engine.DAL
Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Business.Negocio

Public Class frmOrdenTrabajo

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public lngIDObraGA As Long
    Public lngIDCliente As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strCampos As String
        Dim strBase As String
        Dim strWhere As String

        'Obra mediciones
        strBase = ".dbo." & "tbObraMedicionAcero"
        strCampos = " IDLineaMedicionA, IdObra, FechaRef, Estructura, Localizacion1, Localizacion2, Fecha, Alambre, D8, D10, D12, D16, D20, D25, D32, PesoPlanilla, " _
                          & " PesoPedido, PesoAlbaran, CertificadoSuministro, PrecioCertSuministro, CertificadoMontaje, CertificadoMediosE, TotalSuministro, TotalMontaje, TotalMediosE, NCertificacion, " _
                          & " Observaciones, Secuencia, IDUDMedida, numAlbaran, numPedido "

        'strWhere = "IDObra= " & lngIDObra
        strWhere = "IDObra = " & lngIDObraGA

        Grid1.DataSource = AdminData.GetData("SELECT " & strCampos & "FROM " & strBase & " WHERE " & strWhere)
        Grid1.Refresh()
    End Sub

    'BOTON ACEPTAR
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim resultado As Boolean
        Dim i As Integer
        Dim consulta As String = ""

        'Use 05-05-09 
        'Dim obj As New OrdenTrabajoCabecera
        Dim intAbrir As Integer

        Try

            For i = 0 To Grid1.RowCount - 1
                'Posicion donde esta el indice de la fila
                Grid1.Row = i
                If Grid1.GetValue("Selector") Then
                    consulta &= Grid1.GetValue("IdLineaMedicionA") & ","
                End If
            Next
            consulta = "(" & Mid(consulta, 1, consulta.Length - 1) & ")"

            If consulta = "()" Then 'Usease q no tiene lineas
                Dim z As Windows.Forms.DialogResult
                z = Windows.Forms.MessageBox.Show("Si no selecciona ninguna línea, se procederá a crear una orden de trabajo sin detalles." & Chr(13) & _
                "¿Desea continuar?", "Crear Orden de trabajo", Windows.Forms.MessageBoxButtons.OKCancel, Windows.Forms.MessageBoxIcon.Information)
                If z = Windows.Forms.DialogResult.OK Then

                    'intAbrir = obj.CrearOrdenMediciones(lngIDObraGA, lngIDCliente, consulta)
                    AbrirOrden(intAbrir)
                Else
                    Windows.Forms.MessageBox.Show("Proceso Cancelado", "Crear Orden de trabajo", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                End If
            Else
                'intAbrir = obj.CrearOrdenMediciones(lngIDObraGA, lngIDCliente, consulta)
                AbrirOrden(intAbrir)
            End If

            Me.Close()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AbrirOrden(ByVal intAbrir As Integer)
        If intAbrir <> 0 Then
            Dim z As Windows.Forms.DialogResult
            Dim f As New Filter
            z = Windows.Forms.MessageBox.Show("Nueva Orden de trabajo creada, " & Chr(13) & _
                       "¿Desea abrirla?", "Orden de trabajo", Windows.Forms.MessageBoxButtons.OKCancel, Windows.Forms.MessageBoxIcon.Information)
            If z = Windows.Forms.DialogResult.OK Then
                f.Add("idOrdenTrabajo", intAbrir)
                Engine.UI.ExpertisApp.OpenForm("PRTTRAB", f) 'Orden de trabajo
            End If
        End If
    End Sub
End Class