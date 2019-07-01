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

        SQLUpdCmd.CommandText = "dbo.entryFedUpdate"
        SQLUpdCmd.CommandType = CommandType.StoredProcedure
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@id_event", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@id_class", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@id_rider", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@state_onsite", System.Data.SqlDbType.SmallInt, 2))
        SQLUpdCmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@comment", System.Data.SqlDbType.NVarChar, 255))
        SQLUpdCmd.Connection = SQLConn


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
    Protected Sub ToggleSelectedState(ByVal sender As Object, ByVal e As EventArgs)
        Dim headerCheckBox As CheckBox = CType(sender, CheckBox)
        For Each dataItem As GridDataItem In RadGrid1.Items
            CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = headerCheckBox.Checked
            dataItem.Selected = headerCheckBox.Checked
        Next
    End Sub

    Protected Sub ddChampship_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddChampship.SelectedIndexChanged
        If SelectionType.SelectedValue = 1 Then
            ' ddEvents.DataBind()
        End If


    End Sub

    Protected Sub ddEvents_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddEvents.SelectedIndexChanged
        If Not SelectionType.SelectedValue = 2 Then
            'ddClasses.DataBind()
            'else
            'RadGrid1.Rebind()
        End If


        'get_entries()
    End Sub


    Protected Sub RadGrid1_UpdateCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.UpdateCommand


        'Get the GridEditableItem of the RadGrid
        Dim editedItem As GridEditableItem = TryCast(e.Item, GridEditableItem)
        'Get the primary key value using the DataKeyValue.
        'Dim EmployeeID As String = editedItem.OwnerTableView.DataKeyValues(editedItem.ItemIndex)("EmployeeID").ToString()
        'Access the textbox from the edit form template and store the values in string variables.


        SQLUpdCmd.Parameters("@eventid").Value = ddEvents.SelectedValue
        SQLUpdCmd.Parameters("@championship").Value = ddChampship.SelectedValue
        SQLUpdCmd.Parameters("@ev_class").Value = ddClasses.SelectedValue
        SQLUpdCmd.Parameters("@nr").Value = (TryCast(editedItem("nr").Controls(0), TextBox)).Text
        SQLUpdCmd.Parameters("@entrystatus").Value = (TryCast(editedItem("entrystatus").Controls(0), TextBox)).Text

        SQLConn.Open()
        SQLUpdCmd.ExecuteNonQuery()
        SQLConn.Close()

    End Sub


    Protected Sub ddClasses_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddClasses.SelectedIndexChanged
        'If SelectionType.SelectedValue = 2 Then
        ' ddEvents.DataBind()
        ' Else
        'RadGrid1.Rebind()
        'End If
    End Sub

    Protected Sub SelectionType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles SelectionType.SelectedIndexChanged
        If SelectionType.SelectedValue > 1 Then
            ddChampship.Visible = False
            ddChampship.Enabled = False
            lblCship.Visible = False
        ElseIf SelectionType.SelectedValue = 1 Then
            ddChampship.Visible = True
            lblCship.Visible = True
            ddChampship.Enabled = True
        End If
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

            '         Dim dr As SqlClient.SqlDataReader
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
                If User.Identity.Name = "hmf@youthstream.org" Or User.Identity.Name = "Hans-Martin Fetzer" Then
                    FedID.Value = Request.QueryString("fid")
                End If
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
                dataItem("State_Onsite").CssClass = "RejectedRowClass"
            End If

            If (InStr(dataItem("State_Request").Text, "approved")) Then
                dataItem("State_Request").CssClass = "EntryRowClass"
            ElseIf (InStr(dataItem("State_Request").Text, "denied")) Then
                dataItem("State_Request").CssClass = "RejectedRowClass"
            End If

            If (dataItem("ageevent").Text = (dataItem("age_min").Text)) Then
                dataItem("ageevent").CssClass = "AdditionalRowClass"
            ElseIf (dataItem("ageevent").Text < (dataItem("age_min").Text)) Then
                dataItem("ageevent").CssClass = "RejectedRowClass"
            End If


            If (dataItem("ageEOY").Text = (dataItem("age_max").Text)) Then
                dataItem("ageEOY").CssClass = "ReserveRowClass"
            ElseIf (dataItem("ageEOY").Text > (dataItem("age_max").Text)) Then
                dataItem("ageEOY").CssClass = "RejectedRowClass"
            End If

        End If


    End Sub

    Protected Sub excsend_Click(sender As Object, e As System.EventArgs) Handles excsend.Click
        Dim nselect As Integer = 0
        Dim riderID As Integer = 0



        For Each item As GridDataItem In RadGrid1.SelectedItems
            nselect = nselect + 1
            '            riderID = item.GetDataKeyValue("nr").ToString
            'riderID = item("nr").Text
            SQLUpdCmd.Parameters("@id_event").Value = ddEvents.SelectedValue
            SQLUpdCmd.Parameters("@id_class").Value = ddClasses.SelectedValue
            SQLUpdCmd.Parameters("@id_rider").Value = item("id_rider").Text
            SQLUpdCmd.Parameters("@state_onsite").Value = ExcusedTypes.SelectedValue
            SQLUpdCmd.Parameters("@comment").Value = tbComment.Text
            SQLConn.Open()
            SQLUpdCmd.ExecuteNonQuery()
            SQLConn.Close()
        Next
        RadGrid1.Rebind()
    End Sub
End Class
