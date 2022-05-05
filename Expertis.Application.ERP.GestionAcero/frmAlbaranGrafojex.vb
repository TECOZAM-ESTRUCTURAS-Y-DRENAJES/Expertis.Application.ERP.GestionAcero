Imports Solmicro.Expertis.Engine.DAL
Imports System.Windows.Forms
Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Business.Negocio.AlbaranVentaCabecera
Imports Solmicro.Expertis.Business.Negocio


Public Class frmAlbaranGrafojex
    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public lngIDObraGA As Long
    Public lngIDCliente As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAlbaranGrafojex_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strCampos As String
        Dim strBase As String
        Dim strWhere As String

        'Obra mediciones
        strBase = ".dbo." & "tbObraMedicionAcero"
        strCampos = " IDLineaMedicionA, IdObra, FechaRef, Estructura, Localizacion1, Localizacion2, Fecha,nCarga As 'Nº Carga', Alambre, D8, D10, D12, D16, D20, D25, D32, PesoPlanilla, " _
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
        Dim dFSalida As Date

        ' Definir la ventana
        Dim Frm As New frmNumFechaAlba
        Frm.ShowDialog()
        dFSalida = Frm.Fventana

        If dFSalida.Year <= 100 Then
            Engine.UI.ExpertisApp.GenerateMessage("Proceso cancelado por el usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        'IBIS. David 14-03-08 
        'Dim obj As New AlbaranGrafogestCabecera
        Dim obj As New AlbaranVentaCabecera
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
                Dim z As DialogResult
                z = MessageBox.Show("Si no selecciona ninguna línea, se procederá a crear un Albarán de Grafogest sin líneas de Medición." & Chr(13) & _
                "¿Desea continuar?", "Crear Albarán de Grafogest", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                If z = DialogResult.OK Then

                    'intAbrir = obj.CrearAlbaranGrafogest(lngIDObraGA, lngIDCliente, consulta, dFSalida)
                    AbrirAlbaran(intAbrir)
                Else
                    Engine.UI.ExpertisApp.GenerateMessage("Proceso Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                'intAbrir = obj.CrearAlbaranGrafogest(lngIDObraGA, lngIDCliente, consulta, dFSalida)
                AbrirAlbaran(intAbrir)
            End If

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AbrirAlbaran(ByVal intAbrir As Integer)

        If intAbrir <> 0 Then
            Dim z As DialogResult
            Dim f As New Filter
            z = MessageBox.Show("Nuevo Albarán de Grafogest creado" & Chr(13) & _
                       "¿Desea abrirlo?", "Albarán Grafogest", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If z = DialogResult.OK Then
                f.Add("IDAlbaran", intAbrir)
                UI.ExpertisApp.OpenForm("MALB", f) 'Albaran de Venta
            End If

        End If
    End Sub

End Class