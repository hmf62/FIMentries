Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.ControlCollection
Imports Telerik.Web.UI
Imports System.Net.Mail
Imports System.Net
Imports System.Web.Security

Partial Class Federation_Default
    Inherits System.Web.UI.Page
    Dim AspWeb1 As SqlConnection = New System.Data.SqlClient.SqlConnection
    Dim AspWeb2 As SqlConnection = New System.Data.SqlClient.SqlConnection


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
            If Not Request.QueryString("fid") > "" Then

                dr = getfedid.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    FedID.Value = dr("id_fed")
                Else
                    Response.Redirect("www.mxgp.com", True)
                End If
            Else
                FedID.Value = Request.QueryString("fid")
            End If


        End If
    End Sub


    Protected Sub cmdSignOut_ServerClick(sender As Object, e As System.EventArgs) Handles cmdSignOut.ServerClick
        FormsAuthentication.SignOut()
        Response.Redirect("../default.aspx", True)
    End Sub
End Class
