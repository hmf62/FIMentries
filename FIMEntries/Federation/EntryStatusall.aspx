<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EntryStatusall.aspx.vb" Inherits="Federation_EntryStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
       <asp:HiddenField ID="FedID" runat="server" />

        <br />
        <br />
 
    </div>
    <div>
        <asp:HiddenField ID="minriderid" runat="server" Value="" />
        <asp:HiddenField ID="maxriderid" runat="server" Value="" />

    </div>
   
    <div>    <asp:CheckBox ID="cbRequests" runat="server" 
            Text="Show open entry requests only" AutoPostBack="True" />
    </div>
    <div></div>
    <div id="riderlist">
        <% 'testcreation()%>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
             DataSourceID="Entries" 
            AllowSorting="True"  
            ShowFooter="True" ShowGroupPanel="True" ShowStatusBar="True" 
            AllowFilteringByColumn="True" EnableLinqExpressions="False">

<MasterTableView DataSourceID="Entries" ShowGroupFooter="True" CommandItemDisplay="Top" CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowAddNewRecordButton="False">
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<CommandItemSettings ShowAddNewRecordButton="False"></CommandItemSettings>

    <Columns>
        <telerik:GridHyperLinkColumn AllowSorting="False" 
            DataTextField="id_evrequest" 
            DataNavigateUrlFormatString="https://results.mxgp.com/entry/entrypermissions.aspx?entryid={0}" 
            FilterControlAltText="Filter column column" UniqueName="column" HeaderText="Link Entry Request" DataNavigateUrlFields="id_evrequest" Target="_blank">
        </telerik:GridHyperLinkColumn>
        <telerik:GridBoundColumn DataField="class" 
            HeaderText="Class" SortExpression="class" UniqueName="class" 
            FilterControlAltText="Filter class column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ev_date" 
            HeaderText="Date" SortExpression="ev_date" UniqueName="ev_date" 
            FilterControlAltText="Filter ev_date column" DataType="System.DateTime" DataFormatString="{0:d}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="raccity" HeaderText="Venue" 
            SortExpression="raccity" UniqueName="raccity" 
            FilterControlAltText="Filter raccity column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="snr" 
            HeaderText="Start Nr" SortExpression="snr" UniqueName="snr" 
            FilterControlAltText="Filter snr column" DataType="System.Int16">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ln" 
            HeaderText="Last Name" SortExpression="ln" UniqueName="ln" 
            FilterControlAltText="Filter ln column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fn" HeaderText="First Name" 
            SortExpression="fn" UniqueName="fn" 
            FilterControlAltText="Filter fn column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="bike" 
            FilterControlAltText="Filter bike column" HeaderText="Bike" 
            SortExpression="bike" UniqueName="bike">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="cshort" 
            FilterControlAltText="Filter cshort column" HeaderText="Country" 
            SortExpression="cshort" UniqueName="cshort">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fshort" 
            FilterControlAltText="Filter fshort column" HeaderText="Federation" 
            SortExpression="fshort" UniqueName="fshort" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="tname" 
            FilterControlAltText="Filter tname column" HeaderText="Team" 
            SortExpression="tname" UniqueName="tname">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="birth" 
            FilterControlAltText="Filter birth column" HeaderText="Birth date" 
            SortExpression="birth" UniqueName="birth" ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="AgeEvent" 
            FilterControlAltText="Filter AgeEvent column" HeaderText="Age at Event" 
            SortExpression="AgeEvent" UniqueName="AgeEvent" DataType="System.Int32" 
            ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="State_Request" 
            FilterControlAltText="Filter State_Request column" HeaderText="State_Request" 
            SortExpression="State_Request" UniqueName="State_Request" FilterCheckListEnableLoadOnDemand="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="State_Entry" 
            FilterControlAltText="Filter State_Entry column" HeaderText="State_Entry" 
            SortExpression="State_Entry" UniqueName="State_Entry">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="State_Onsite" 
            FilterControlAltText="Filter State_Onsite column" HeaderText="State_Onsite" 
            SortExpression="State_Onsite" UniqueName="State_Onsite">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="id_rider" DataType="System.Int16" 
            FilterControlAltText="Filter id_rider column" HeaderText="id_rider" 
            SortExpression="id_rider" UniqueName="id_rider" Visible="False">
        </telerik:GridBoundColumn>
            </Columns>
</MasterTableView>
            <GroupingSettings RetainGroupFootersVisibility="True" CaseSensitive="False" />
<ClientSettings AllowDragToGroup="True">
  <Selecting AllowRowSelect="True" />
</ClientSettings>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="Entries" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="EntryRequestsFederationsAll" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="FedID" Name="id_fed" PropertyName="Value" 
                    Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>

 <div>
     <br />
 </div>
    </form>
</body>
</html>

