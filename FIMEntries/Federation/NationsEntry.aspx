<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NationsEntry.aspx.vb" Inherits="Federation_NationsEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <div>
            <telerik:RadRadioButtonList ID="selChampionship" runat="server" Direction="Horizontal">
                <Items>
                    <telerik:ButtonListItem Text="FIM Junior World Championship" Value="16" Selected="True" />
                    <telerik:ButtonListItem Text="FIM Motocross of Nations" Value="7" />
                </Items>
            </telerik:RadRadioButtonList>
        </div>
        <div>
            <telerik:RadGrid ID="AddMembers" runat="server" Culture="de-DE" DataSourceID="SqlDataSource1" ShowStatusBar="True">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CommandItemDisplay="TopAndBottom">
                    <Columns>
                        <telerik:GridBoundColumn DataField="lastname" FilterControlAltText="Filter lastname column" HeaderText="Last Name" SortExpression="lastname" UniqueName="lastname">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="firstname" FilterControlAltText="Filter firstname column" HeaderText="First Name" SortExpression="firstname" UniqueName="firstname">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fmnfunction" FilterControlAltText="Filter fmnfunction column" HeaderText="Function (i.e.Doctor)" SortExpression="fmnfunction" UniqueName="fmnfunction">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" SelectCommand="fmn_getadditionaldelegates" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="id_fmn" Type="Int16" />
                    <asp:Parameter DefaultValue="1" Name="id_event" Type="Int16" />
                    <asp:Parameter DefaultValue="1" Name="id_championship" Type="Int16" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
