
Imports System.Data.SqlClient
Imports System.Data
Partial Class Federation_NationsEntry
    Inherits System.Web.UI.Page


    Dim id_fmn As Integer
    Dim id_event As Integer
    Dim YearEntryAct As String


    Dim SqlConnection1 As System.Data.SqlClient.SqlConnection
    Dim FMNMembers As System.Data.SqlClient.SqlCommand
    Dim EventDetails As SqlCommand

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load



        id_fmn = 1
        YearEntryAct = System.Configuration.ConfigurationManager.AppSettings("YearEntryAct")

    End Sub

    Sub GetEventDetails()
        If selChampionship.SelectedValue = 16 Then
            id_event = 3441
        ElseIf selChampionship.SelectedValue = 7 Then
            id_event = 3421
        End If
    End Sub
    Sub GetFMNMembers()

    End Sub
End Class
