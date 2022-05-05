Imports Solmicro.Expertis.Engine.UI
Imports Solmicro.Expertis.Engine.Global
Imports Solmicro.Expertis.Engine.DAL
Imports System.Windows.Forms

Public Class SeleccionarObra

    Private CSuministro As Double
    Public blnCerrar As Boolean

    Public Property Suministro() As Double
        Get
            Return CSuministro
        End Get
        Set(ByVal Value As Double)
            CSuministro = Value
        End Set
    End Property

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Try
            Dim txtsql As String
            'IBIS. David
            Dim idobra As String

            If Nz(CmbNumObra.Text, "") = "" Then
                ExpertisApp.GenerateMessage("Debe indicar antes la Obra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim dt As New DataTable
            dt = AdminData.GetData("SELECT IDObra FROM xDrenajes4.dbo.tbObraCabecera WHERE NObra='" & CmbNumObra.Value & "'")

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                idobra = dt.Rows(0)("IDObra")
            End If

            txtsql = "sp_InsertarSuministro "
            'IBIS. David
            txtsql = txtsql & idobra & ","

            txtsql = txtsql & CmbNumObra.Value & ","
            txtsql = txtsql & Replace(CSuministro, ",", ".")

            Me.Cursor = Cursors.WaitCursor
            AdminData.Execute(txtsql)

            ExpertisApp.GenerateMessage("Líneas copiadas con exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
            Me.Close()

        Catch ex As Exception
            ExpertisApp.GenerateMessage(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        blnCerrar = True
        Me.Close()
    End Sub

    Private Sub SeleccionarObra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnCerrar = False

        'Esta es la buena
        CmbNumObra.DataSource = AdminData.GetData("SELECT NObra,DescObra FROM xDrenajes4.dbo.tbObraCabecera")
    End Sub

End Class