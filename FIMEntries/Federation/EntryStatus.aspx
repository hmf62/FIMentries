<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EntryStatus.aspx.vb" Inherits="Federation_EntryStatus" %>

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
    <asp:RadioButtonList ID="SelectionType" Groupname="Selecttype" runat="server" 
        Height="51px" Visible="True" RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:listitem id="bychampevent" runat="server" text="by championship" Value="1"  Selected="True" />
        <asp:listitem id="byeventclass" runat="server" Text="by event" Value="3"  />
    </asp:RadioButtonList>
       <asp:HiddenField ID="FedID" runat="server" />
               <br />
        <asp:Label ID="lblCship" runat="server" Text="Championship"></asp:Label>
        <asp:DropDownList ID="ddChampship" runat="server" AutoPostBack="True" 
            DataSourceID="GetCship" DataTextField="champshipname" 
            DataValueField="champshipid">
        </asp:DropDownList>
        <asp:Label ID="lblClass" runat="server" Text="Select event"></asp:Label>

        <asp:DropDownList ID="ddEvents" runat="server" AutoPostBack="True" 
            DataSourceID="GetEvent" DataTextField="raccity" DataValueField="eventid">
        </asp:DropDownList>
        <asp:SqlDataSource ID="GetEvent" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="entryListSelEventNew" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddChampship" Name="cshipid" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="SelectionType" Name="type" 
                    PropertyName="SelectedValue" Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:Label ID="lbClasses" runat="server" Text="Select class:"></asp:Label>
        <asp:DropDownList ID="ddClasses" runat="server" AutoPostBack="True" 
            DataSourceID="GetClass" DataTextField="class" DataValueField="ev_class">
        </asp:DropDownList>
        <asp:SqlDataSource ID="GetClass" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="entryListSelClass" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddEvents" Name="ev_id" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="ddChampship" Name="cshipid" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="SelectionType" Name="type" 
                    PropertyName="SelectedValue" Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
          <asp:SqlDataSource ID="GetCship" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="entryListSelCship" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
        <br />
 
    </div>
    <div>
        <asp:HiddenField ID="minriderid" runat="server" Value="" />
        <asp:HiddenField ID="maxriderid" runat="server" Value="" />

    </div>
    <div id="riderlist">
        <% 'testcreation()%>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
             DataSourceID="Entries" 
            AllowSorting="True" 
            ShowFooter="True" ShowGroupPanel="True" ShowStatusBar="True">

<MasterTableView DataSourceID="Entries" ShowGroupFooter="True" CommandItemDisplay="Top" CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowAddNewRecordButton="False" CommandItemStyle-Height="20">
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" />
        <telerik:GridHyperLinkColumn AllowSorting="False" 
            DataTextField="id_evrequest" 
            DataNavigateUrlFormatString="https://results.mxgp.com/entry/entrypermissions.aspx?entryid={0}" 
            FilterControlAltText="Filter column column" UniqueName="column" HeaderText="Link Entry Request" DataNavigateUrlFields="id_evrequest" Target="_blank">
        </telerik:GridHyperLinkColumn>
        <telerik:GridBoundColumn DataField="snr" 
            HeaderText="Startnr" SortExpression="snr" UniqueName="snr" 
            FilterControlAltText="Filter snr column" DataType="System.Int16">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ln" 
            HeaderText="Last Name" SortExpression="ln" UniqueName="ln" 
            FilterControlAltText="Filter ln column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fn" HeaderText="fn" 
            SortExpression="First Name" UniqueName="fn" 
            FilterControlAltText="Filter fn column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="bike" 
            HeaderText="Bike" SortExpression="bike" UniqueName="bike" 
            FilterControlAltText="Filter bike column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="cshort" 
            HeaderText="Nat." SortExpression="cshort" UniqueName="cshort" 
            FilterControlAltText="Filter cshort column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fshort" HeaderText="Federation" 
            SortExpression="fshort" UniqueName="fshort" 
            FilterControlAltText="Filter fshort column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="tname" 
            FilterControlAltText="Filter tname column" HeaderText="Team" 
            SortExpression="tname" UniqueName="tname">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="FIMlicense" 
            FilterControlAltText="Filter FIMlicense column" HeaderText="Team FIM lic." 
            SortExpression="FIMlicense" UniqueName="FIMlicense" 
            DataType="System.Boolean">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="birth" 
            FilterControlAltText="Filter birth column" HeaderText="birth" 
            SortExpression="birth" UniqueName="birth" ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="AgeEvent" 
            FilterControlAltText="Filter AgeEvent column" HeaderText="Age at Event" 
            SortExpression="AgeEvent" UniqueName="AgeEvent" DataType="System.Int32" 
            ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="AgeEOY" 
            FilterControlAltText="Filter AgeEvent column" HeaderText="Age end of year" 
            SortExpression="AgeEOY" UniqueName="AgeEOY" DataType="System.Int32" 
            ReadOnly="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="State_Request" 
            FilterControlAltText="Filter State_Request column" HeaderText="State_Request" 
            SortExpression="State_Request" UniqueName="State_Request">
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
            SortExpression="id_rider" UniqueName="id_rider" Visible="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="age_min" DataType="System.Int16" 
            FilterControlAltText="Filter age_min column" HeaderText="age_min" 
            SortExpression="age_min" UniqueName="age_min" Visible="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="age_max" DataType="System.Int16" 
            FilterControlAltText="Filter age_max column" HeaderText="age_max" 
            SortExpression="age_max" UniqueName="age_max" Visible="True">
        </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="id_federation" DataType="System.Int16" 
            FilterControlAltText="Filter id_federation column" HeaderText="id_federation" 
            SortExpression="id_federation" UniqueName="id_federation" Visible="False">
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
            SelectCommand="EntryRequestsFederations" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddEvents" Name="id_event" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="ddChampship" Name="id_championship" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="ddClasses" Name="id_class" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="SelectionType" Name="type" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="FedID" Name="id_fed" PropertyName="Value" 
                    Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>
<br />
<div>Comment: 
    <telerik:RadTextBox ID="tbComment" runat="server" Width="500px">
    </telerik:RadTextBox></div><br />
 <div>
     <asp:RadioButtonList ID="ExcusedTypes" runat="server">
       <asp:listitem id="exchealth" runat="server" text="excused-health" Value="200" />
       <asp:listitem id="excother" runat="server" text="excused-other reasons" Value="201" />
       <asp:listitem id="unexc" runat="server" text="Un-excuse / Approve" Value="0" />
     </asp:RadioButtonList><br />
     <asp:Button ID="excsend" runat="server" Text="Save excused status" />
 </div>
    </form>
</body>
</html>

