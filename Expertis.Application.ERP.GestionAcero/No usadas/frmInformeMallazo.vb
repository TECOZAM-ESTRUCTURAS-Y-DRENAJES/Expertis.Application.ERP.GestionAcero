Imports Solmicro.Expertis.Engine.DAL
Imports Solmicro.Expertis.Engine
Imports Solmicro.Expertis.Engine.UI

Public Class frmInformeMallazo

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Public lngIDObraGA As Long
    Public lngIDCliente As String
    Public lngIDLineaMedicionA As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmInformeMallazo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strCampos As String
        Dim strBase As String
        Dim strWhere As String
        'genera un numero de albaran aleatorio
        TxtAlbaran.Text = AdminData.GetAutoNumeric
        'Obra mediciones
        strBase = ".dbo." & "tbObraMedicionAcero"
        strCampos = " IDLineaMedicionA, IdObra, FechaRef, Estructura, Localizacion1, Localizacion2, Fecha, Alambre, D8, D10, D12, D16, D20, D25, D32, PesoPlanilla, " _
                          & " PesoPedido, PesoAlbaran, CertificadoSuministro, PrecioCertSuministro, CertificadoMontaje, CertificadoMediosE, TotalSuministro, TotalMontaje, TotalMediosE, NCertificacion, " _
                          & " Observaciones, Secuencia, IDUDMedida, numAlbaran, numPedido,Observaciones2 "

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
        Dim idcliente As String
        Dim opcion As String
        Dim transportista As String
        Dim matricula As String
        Dim remolque As String

        'Dim f As New Filter
        'IBIS. David 14-03-08 
        'Dim obj As New AlbaranGrafogestCabecera

        'Dim obj As New AlbaranVentaCabecera
        'Dim intAbrir As Integer

        Try

            For i = 0 To Grid1.RowCount - 1
                'Posicion donde esta el indice de la fila
                Grid1.Row = i
                If Grid1.GetValue("Selector") Then
                    consulta &= "'" & Grid1.GetValue("IdLineaMedicionA") & "'" & ","
                    'consulta &= Grid1.GetValue("IdLineaMedicionA") & ","
                End If
            Next

            consulta = "(" & Mid(consulta, 1, consulta.Length - 1) & ")"
            'consulta = Mid(consulta, 1, consulta.Length - 1)

            If consulta = "()" Then 'Usease q no tiene lineas
                Dim z As Windows.Forms.DialogResult
                z = Windows.Forms.MessageBox.Show("Si no selecciona ninguna línea, se procederá a crear un Albarán de Venta - Grafogest sin líneas de Medición." & Chr(13) & _
                "¿Desea Continuar?", "Crear Albarán de Venta - Grafogest", Windows.Forms.MessageBoxButtons.OKCancel, Windows.Forms.MessageBoxIcon.Information)
                If z = Windows.Forms.DialogResult.OK Then

                    'intAbrir = obj.CrearAlbaranGrafogest(lngIDObraGA, lngIDCliente, consulta)
                    'AbrirAlbaran(intAbrir)
                    'AbrirAlbaran(consulta)
                Else
                    Windows.Forms.MessageBox.Show("Proceso Cancelado", "Crear Albarán de Venta - Grafogest", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                End If
            Else
                'intAbrir = obj.CrearAlbaranGrafogest(lngIDObraGA, lngIDCliente, consulta)
                'AbrirAlbaran(intAbrir)
                ' AbrirAlbaran(consulta)
                ' f.Add("IdlineamedicionA", consulta)
                ' ExpertisApp.OpenReport("INFMEDACERO", f) 'Informe Mediciones Acero

                'Funcion para abrir el informe Mediciones Acero

                Dim rp As New Report("INFMEDMALLAZO")
                'Dim filtro As New Filter
                'filtro.Add("IDLineaMedicionA", FilterOperator.Equal, consulta)
                'filtro.Add("Mes", FilterOperator.Equal, sMes)
                'rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", filtro)
                rp.DataSource = New BE.DataEngine().Filter("vFrmMedicionesObraAcero", "*", "IdlineamedicionA IN " & consulta)
                rp.Formulas("idcliente").Text = lngIDCliente

                rp.Formulas("transportista").Text = Txttransportista.Text
                rp.Formulas("matricula").Text = Txtmatricula.Text
                rp.Formulas("remolque").Text = Txtremolque.Text
                rp.Formulas("fecha").Text = txtFecha.Text


                rp.Formulas("albaran").Text = TxtAlbaran.Text

                If opcion1.Checked = True Then
                    opcion = "ferrallas"
                ElseIf opcion2.Checked = True Then
                    opcion = "dyezam"
                ElseIf opcion3.Checked = True Then
                    opcion = "armozam"
                ElseIf opcion4.Checked = True Then
                    opcion = "tecozam"
                End If

                rp.Formulas("opcion").Text = opcion


                ExpertisApp.OpenReport(rp)

            End If

            Me.Close()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class