Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.ControlCollection
Imports Telerik.Web.UI
Imports System.Net.Mail
Imports System.Net
Imports FIMEntries.CommonFunctionsLogin
Imports System.Web.Security
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls.WebControl
Public Class FederationLoginRequests
    Inherits System.Web.UI.Page

    Dim mail As New MailMessage()
    Dim requid As String
    Dim fromaddress As String
    Dim AspWeb1 As SqlConnection = New System.Data.SqlClient.SqlConnection
    Dim AspWeb2 As SqlConnection = New System.Data.SqlClient.SqlConnection
    Dim sqlsaveriderdata As SqlCommand = New System.Data.SqlClient.SqlCommand
    Dim authok As Boolean
    Dim dataok As Boolean







    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        'txtName.Value = RadBirthDate.DbSelectedDate.ToString
        'txtFName.Value = RadBirthDate.SelectedDate.ToString

        SaveFederationdata()
        If dataok Then
            ridermain.Attributes.Add("style", "visibility:hidden")
            ridermain.Attributes.Add("style", "display:none")
            Button1.Text = "Request login"
            Button1.Visible = False
            lblConfirm.Text = "Thank you for your request. We will assign your data to the correct record in our database, after that you will receive a confirmation by mail."
            lblConfirm.Visible = True
        Else

            lblConfirm.Text = "Please verify your data"
            lblConfirm.Visible = True


        End If
        'Response.Write("Thank you for your request. We will assign your data to the correct record in our database and then we will send you the link to the entry form.")


    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    End Sub


    Sub SaveFederationdata()
        Dim FuncCls As New CommonFunctionsLogin()

        '
        'AspWeb
        '
        Dim lname As String = Request.Form("txtName")
        AspWeb2.ConnectionString = ConfigurationManager.ConnectionStrings("SQLConnection1W").ConnectionString

        sqlsaveriderdata.Connection = AspWeb2
        sqlsaveriderdata.CommandType = CommandType.StoredProcedure
        sqlsaveriderdata.CommandText = "dbo.Federationsaveloginrequest"
        sqlsaveriderdata.Parameters.Add("@fed", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@ln", SqlDbType.VarChar, 20)
        sqlsaveriderdata.Parameters.Add("@fn", SqlDbType.VarChar, 20)
        sqlsaveriderdata.Parameters.Add("@phone", SqlDbType.VarChar, 50)
        sqlsaveriderdata.Parameters.Add("@mobile", SqlDbType.VarChar, 50)
        sqlsaveriderdata.Parameters.Add("@email", SqlDbType.VarChar, 50)
        sqlsaveriderdata.Parameters.Add("@password", SqlDbType.VarChar, 50)
        sqlsaveriderdata.Parameters("@fed").Value = ddFederation.SelectedValue
        sqlsaveriderdata.Parameters("@ln").Value = txtName.Value
        sqlsaveriderdata.Parameters("@fn").Value = txtFName.Value
        sqlsaveriderdata.Parameters("@phone").Value = OffPhone.Value
        sqlsaveriderdata.Parameters("@mobile").Value = MobPhone.Value
        sqlsaveriderdata.Parameters("@email").Value = txtREMail.Value
        sqlsaveriderdata.Parameters("@password").Value = FuncCls.EncryptPassword(txtPassword.Value.Trim)

        If Not (txtName.Value.Length < 2 And txtREMail.Value.Length < 5 And txtPassword.Value.Length < 3) Then
            AspWeb2.Open()
            sqlsaveriderdata.ExecuteNonQuery()
            dataok = True
        Else
            dataok = False
        End If

    End Sub

End Class


