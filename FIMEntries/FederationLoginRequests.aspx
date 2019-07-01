<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FederationLoginRequests.aspx.vb" Inherits="FIMEntries.FederationLoginRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Federation Login request</title>
</head>
<body>
    <form id="form1" runat="server" style="width: 1000px">
       <div>
           <img src="images/FIM-logo-entries.png" alt="FIM"  />
    </div>
    <telerik:RadAjaxManager runat="server">
        <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Button1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ValidationSummary1" />
                    <telerik:AjaxUpdatedControl ControlID="ridermain" />
                    <telerik:AjaxUpdatedControl ControlID="confirm" />
               </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButtonList1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ridermain" />
                    <telerik:AjaxUpdatedControl ControlID="grid1" />
                    <telerik:AjaxUpdatedControl ControlID="confirm" />
               </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Button2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Label1" />
                    <telerik:AjaxUpdatedControl ControlID="Button2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmdSignOut">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="LoginName2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
<div id="ridermain" style="visibility:visible" runat="server">
<table>
 <tr>
    <td colspan="3">
    Please take care to enter the correct data.<br />
    - Without entering a valid e-mail address we can't send you any information.<br />
    - In case the email address is not part of the official domain of your federation, we will need to verify with your federation before we can process the login.<br />

    </td></tr>

 <tr>
    <td colspan="3">

<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
HeaderText="There were errors on the page:" BorderColor="Red" BorderStyle="Double" />
</td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="txtName"
            ErrorMessage="Last/Family Name is required."> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Last/Family Name:</td>
    <td><input type="text" runat="server" id="txtName" /></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtFName"
            ErrorMessage="First Name is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>First Name:</td>
    <td><input type="text" runat="server" id="txtFName" /></td>
  </tr>

 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
            ControlToValidate="ddFederation"
            ErrorMessage="Selection of Federation is required" InitialValue="0"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Federation:</td>
    <td><asp:DropDownList ID="ddFederation" runat="server" DataSourceID="SelFederation" DataTextField="fshort"
            DataValueField="fnr">
        </asp:DropDownList>
            <asp:SqlDataSource ID="SelFederation" runat="server" ConnectionString="<%$ ConnectionStrings:ASPWeb %>"
            
            SelectCommand="SELECT federations.fnr, federations.fshort + ' (' + countries.clong + ')' AS fshort FROM federations INNER JOIN countries ON federations.fcountry = countries.cnr where federations.factive=1 ORDER BY fshort"></asp:SqlDataSource>
    </td>
  </tr>
 <tr>
    <td>
    </td>
    <td>Office phone incl country code:</td>
    <td><input type="text" runat="server" id="OffPhone" /></td>
  </tr>
 <tr>
    <td>
    </td>
    <td>Mobile phone incl country code:</td>
    <td><input type="text" runat="server" id="MobPhone"></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
            ControlToValidate="txtREMail"
            ErrorMessage="Email address is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Email address:</td>
    <td><input type="text" runat="server" id="txtREMail" /></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtPassword"
            ErrorMessage="Password is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Select a password for your login:</td>
    <td><input type="text" runat="server" id="txtPassword" /></td>
  </tr>
 </table>
    <asp:Button ID="Button1" runat="server" Text="Save" />
    </div>

<div id="confirm">
    <asp:label id="lblConfirm" runat="server" text="Thank you for your request. We will assign your data to the correct record in our database, after that you will receive a confirmation by mail." Visible="False">

    </asp:label>

</div>
    </form>
</body>
</html>