Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.ControlCollection
Imports System.Web.UI
Partial Class Federation_EntryStatus
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
    Protected Sub ToggleRowSelection(ByVal sender As Object, ByVal e As EventArgs)
        CType(CType(sender, CheckBox).NamingContainer, GridItem).Selected = CType(sender, CheckBox).Checked
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

            If Not Request.QueryString("fid") > "" Then
                Dim dr As SqlClient.SqlDataReader
                AspWeb1.Open()

                dr = getfedid.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    FedID.Value = dr("id_fed")
                Else
                    'Response.Redirect("../default.aspx", True)
                End If
            Else
                FedID.Value = Request.QueryString("fid")
            End If
        End If

    End Sub

    Protected Sub RadGrid1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If (TypeOf e.Item Is GridDataItem) Then
            Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)


            'Check the formatting condition
            If (InStr(dataItem("State_Entry").Text, "entered")) Then
                dataItem("State_Entry").CssClass = "EntryRowClass"
                '                dataBoundItem("State_Entry").ForeColor = Color.Green
                '               dataBoundItem("State_Entry").Font.Bold = True
                'Customize more...
            ElseIf (InStr(dataItem("State_Entry").Text, "additional")) Then
                dataItem("State_Entry").CssClass = "AdditionalRowClass"
            ElseIf (InStr(dataItem("State_Entry").Text, "reserve")) Then
                dataItem("State_Entry").CssClass = "ReserveRowClass"
            ElseIf (InStr(dataItem("State_Entry").Text, "candidate")) Then
                dataItem("State_Entry").CssClass = "CandidateRowClass"
            ElseIf (InStr(dataItem("State_Entry").Text, "rejected")) Then
                dataItem("State_Entry").CssClass = "RejectedRowClass"
            End If
            If (InStr(dataItem("State_Onsite").Text, "entered")) Then
                dataItem("State_Onsite").CssClass = "EntryRowClass"
            ElseIf (InStr(dataItem("State_Onsite").Text, "excused")) Then
                dataItem("State_Onsite").CssClass = "AdditionalRowClass"
            End If
            If (InStr(dataItem("State_Request").Text, "approved")) Then
                dataItem("State_Request").CssClass = "EntryRowClass"
            ElseIf (InStr(dataItem("State_Request").Text, "denied")) Then
                dataItem("State_Request").CssClass = "RejectedRowClass"
            End If


        End If


    End Sub

    Protected Sub cbRequests_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbRequests.CheckedChanged
        If cbRequests.Checked = True Then
            RadGrid1.MasterTableView.FilterExpression = "([State_Request] LIKE '%requested%')"
            Dim column As GridColumn = RadGrid1.MasterTableView.GetColumnSafe("State_Request")
            column.CurrentFilterFunction = GridKnownFunction.EqualTo
            column.CurrentFilterValue = "requested"
            RadGrid1.MasterTableView.Rebind()
            'RadGrid1.DataBind()
        Else
            RadGrid1.MasterTableView.FilterExpression = "')"
            Dim column As GridColumn = RadGrid1.MasterTableView.GetColumnSafe("State_Request")
            column.CurrentFilterValue = ""
            RadGrid1.MasterTableView.Rebind()

        End If


    End Sub
End Class
