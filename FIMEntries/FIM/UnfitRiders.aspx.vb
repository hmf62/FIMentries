Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.ControlCollection
Imports System.Web.UI
Imports Telerik.Web.UI
Partial Class FIM_UnfitRiders
    Inherits System.Web.UI.Page

    Dim min_rid, max_rid As Integer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        SQLConn = New System.Data.SqlClient.SqlConnection
        SQLUpdCmd = New System.Data.SqlClient.SqlCommand
        SQLPubCmd = New System.Data.SqlClient.SqlCommand
        SQLConn.ConnectionString = ConfigurationManager.ConnectionStrings("SQLConnection1").ConnectionString

        SQLUpdCmd.CommandText = "dbo.entrylistupdate"
        SQLUpdCmd.CommandType = CommandType.StoredProcedure
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@eventid", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@championship", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ev_class", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@nr", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@entrystatus", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Connection = SQLConn

        SQLPubCmd.CommandText = "dbo.entrylistpublish"
        SQLPubCmd.CommandType = CommandType.StoredProcedure
        SQLPubCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        SQLPubCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@eventid", System.Data.SqlDbType.SmallInt, 2))
        SQLPubCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@champshipid", System.Data.SqlDbType.SmallInt, 2))
        SQLPubCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@classid", System.Data.SqlDbType.SmallInt, 2))
        SQLPubCmd.Connection = SQLConn





    End Sub
    Protected WithEvents SQLConn As System.Data.SqlClient.SqlConnection
    Protected WithEvents SQLUpdCmd As System.Data.SqlClient.SqlCommand
    Protected WithEvents SQLPubCmd As System.Data.SqlClient.SqlCommand

    Protected WithEvents cb_1 As CheckBox
    Protected WithEvents cb_2 As CheckBox
    Protected WithEvents rid_1 As Label
    Protected WithEvents rid_2 As Label



    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: Dieser Methodenaufruf ist für den Web Form-Designer erforderlich
        'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
        InitializeComponent()
    End Sub
    Protected Sub ToggleRowSelection(ByVal sender As Object, ByVal e As EventArgs)
        CType(CType(sender, CheckBox).NamingContainer, GridItem).Selected = CType(sender, CheckBox).Checked
    End Sub
    Protected Sub ToggleSelectedState(ByVal sender As Object, ByVal e As EventArgs)

    End Sub


End Class
