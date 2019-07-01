<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UnfitRiders.aspx.vb" Inherits="FIM_UnfitRiders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unfit riders</title>
    	<link href="../entries.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:HiddenField ID="minriderid" runat="server" Value="" />
        <asp:HiddenField ID="maxriderid" runat="server" Value="" />
        <div>
                <asp:DropDownList ID="ddEvents" runat="server" AutoPostBack="True" 
            DataSourceID="GetEvent" DataTextField="raccity" DataValueField="eventid">
        </asp:DropDownList>
        <asp:SqlDataSource ID="GetEvent" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="entryListSelEventNew" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="cshipid" Type="Int16" />
                <asp:Parameter DefaultValue="1" Name="type" Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
</div>
    </div>
    <div id="riderlist">
        <% 'testcreation()%>
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Culture="de-DE" DataSourceID="SqlDataSource1" ShowGroupPanel="True">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <telerik:GridBoundColumn DataField="ln" FilterControlAltText="Filter ln column" HeaderText="Last Name" SortExpression="ln" UniqueName="ln">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="fn" FilterControlAltText="Filter fn column" HeaderText="First Name" SortExpression="fn" UniqueName="fn">
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="health_checkup_required" DataType="System.Boolean" FilterControlAltText="Filter health_checkup_required column" HeaderText="health_checkup_required" SortExpression="health_checkup_required" UniqueName="health_checkup_required">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="class" FilterControlAltText="Filter class column" HeaderText="class" SortExpression="class" UniqueName="class">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" SelectCommand="event_UnfitRiders" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddEvents" Name="id_event" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>

 <div>
     <asp:Button ID="btnPublish" runat="server" Text="Publish" Visible="False" />
     <br />
     <br />
 </div>
    </form>
</body>
</html>

