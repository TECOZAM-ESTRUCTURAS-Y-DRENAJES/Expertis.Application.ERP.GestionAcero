Imports Solmicro.Expertis.Business.Obra

Public Class frmlFechaEstFactura

    Inherits Solmicro.Expertis.Engine.UI.FormBase

    Friend Fdesde, fhasta As Date
    Friend iIdObra As Integer
    Private sDiaFact As Short

    Private Sub FfrmFechaEstFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ObtencionFechaObra()
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        If Not IsDBNull(CalendarBox1.Value) Then Fdesde = CalendarBox1.Value
        If IsDBNull(CalendarBox2.Value) Then
            MsgBox("Debe indicar una fecha máxima de informe.", MsgBoxStyle.Exclamation, "Fecha necesaria")
            CalendarBox2.Focus()
            Exit Sub
        End If
        fhasta = CalendarBox2.Value
        If sDiaFact > 0 Then
            ' Solicitado Blanca, sólo información
            'fhasta = sDiaFact & "/" & fhasta.Month & "/" & fhasta.Year
            MsgBox("Se ha puesto como día tope el " & sDiaFact & " asignado en la obra.", MsgBoxStyle.Exclamation, "Día asignado en el mantenimiento de obra.")
        End If
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Fdesde = Nothing
        fhasta = Nothing
        Me.Close()
    End Sub

#Region " Funciones "

    Private Sub ObtencionFechaObra()
        ' Utilizar la clase
        Dim cObraCab As New ObraMedicionAcero

        Try
            Dim dFechaFactur As Date = cObraCab.GetDiaFactObra(iIdObra)
            cObraCab = Nothing
            '' Controlar el valor de la obra
            If dFechaFactur.Year <= 1 Then
                MsgBox("No se ha definido día de facturación en la solapa de mantenimiento de obra,Se cogerá como fecha máxima la de hoy.", MsgBoxStyle.Exclamation, "Fecha por defecto")
                dFechaFactur = Now
            Else
                ' Día asignado en obra, guardarlo
                ' Control de día asignado
                sDiaFact = dFechaFactur.Day
            End If
            ' Indicar día en ventana
            CalendarBox2.Value = dFechaFactur
        Catch ex As Exception
            MsgBox("Se produjo el siguiente error al obtener datos para el informe:" & ex.Message, MsgBoxStyle.Critical, "Error al generar informe")
        End Try
    End Sub

#End Region

End Class