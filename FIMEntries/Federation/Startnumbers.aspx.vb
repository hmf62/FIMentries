Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.ControlCollection
Imports System.Web.UI
Partial Class federation_startnumbers
    Inherits System.Web.UI.Page
    Dim AspWeb1 As SqlConnection = New System.Data.SqlClient.SqlConnection
    Dim AspWeb2 As SqlConnection = New System.Data.SqlClient.SqlConnection
    Dim sqlsaveriderdata As SqlCommand = New System.Data.SqlClient.SqlCommand
    Dim authok As Boolean

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



        Me.cb_1 = New CheckBox
        Me.cb_2 = New CheckBox
        Me.rid_1 = New Label
        Me.rid_2 = New Label

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
    Protected Sub RadGrid1_UpdateCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles rgStartNumbers.UpdateCommand


        'Get the GridEditableItem of the RadGrid
        Dim editedItem As GridEditableItem = TryCast(e.Item, GridEditableItem)
        'Get the primary key value using the DataKeyValue.
        'Dim EmployeeID As String = editedItem.OwnerTableView.DataKeyValues(editedItem.ItemIndex)("EmployeeID").ToString()
        'Access the textbox from the edit form template and store the values in string variables.


        SQLUpdCmd.Parameters("@championship").Value = ddChampship.SelectedValue
        SQLUpdCmd.Parameters("@ev_class").Value = ddClasses.SelectedValue
        SQLUpdCmd.Parameters("@nr").Value = (TryCast(editedItem("nr").Controls(0), TextBox)).Text
        SQLUpdCmd.Parameters("@entrystatus").Value = (TryCast(editedItem("entrystatus").Controls(0), TextBox)).Text

        SQLConn.Open()
        SQLUpdCmd.ExecuteNonQuery()
        SQLConn.Close()

    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            AspWeb1.ConnectionString = ConfigurationManager.ConnectionStrings("ASPWeb").ConnectionString
            Dim getfedid As New SqlCommand
            getfedid.Connection = AspWeb1
            getfedid.CommandType = CommandType.StoredProcedure
            getfedid.CommandText = "dbo.checkloginfederation"
            getfedid.Parameters.Add("@email", SqlDbType.VarChar, 50)
            getfedid.Parameters("@email").Value = User.Identity.Name

            Dim dr As SqlClient.SqlDataReader
            AspWeb1.Open()
            dr = getfedid.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                FedID.Value = dr("id_fed")
            Else
                Response.Redirect("../default.aspx", True)
            End If
        End If

    End Sub

    Protected Sub ddClasses_DataBound(sender As Object, e As System.EventArgs) Handles ddClasses.DataBound
        rgStartNumbers.DataBind()
    End Sub

    Protected Sub ddClasses_SelectedIndexChanged1(sender As Object, e As System.EventArgs) Handles ddClasses.SelectedIndexChanged
        rgStartNumbers.DataBind()
    End Sub

    Protected Sub btSignOut_Click(sender As Object, e As System.EventArgs) Handles btSignOut.Click
        FormsAuthentication.SignOut()
        Response.Redirect("../default.aspx", True)
    End Sub
End Class
