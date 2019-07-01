<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Federation_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div>

        <img src="../images/2014/MXGP-Logosmall.png" alt="MXGP" />
    </div>

 <div>
    <div style="float: right">
        <asp:LoginName id="LoginName1" runat="server" 
               FormatString ="Welcome, {0}" />
               <input type="submit" Value="SignOut" runat="server" id="cmdSignOut" 
            style="padding-left: 1px; margin-left: 15px;">
       <asp:HiddenField ID="FedID" runat="server" Value="1" />
    </div>
    </div>
    <h1>Federation tools</h1>
 <div>
     <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/Federation/EntryStatus.aspx">Entries by Championship/Event</asp:HyperLink>
 </div>
 <div>
     <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl="~/Federation/EntryStatusall.aspx">All Federation entries</asp:HyperLink>
 </div>
 <div>
     <asp:HyperLink ID="HyperLink4" runat="server" Target="_blank" NavigateUrl="~/Federation/EntryStatusRid.aspx">Entries by rider</asp:HyperLink>
 </div>
 <div>
     <asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" NavigateUrl="~/Federation/Startnumbers.aspx">Season Start Numbers</asp:HyperLink>
 </div>

    </form>
</body>
</html>
