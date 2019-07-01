<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EntryStatusRid.aspx.vb" Inherits="internal_EntryStatusRider2014" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rider Entries</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>


     	<link href="../entries.css" type="text/css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <br />
               <asp:HiddenField ID="FedID" runat="server" />
               <br />

        <asp:Label ID="lblCship" runat="server" Text="Rider"></asp:Label>
        <asp:DropDownList ID="ddRiders" runat="server" AutoPostBack="True" 
            DataSourceID="GetRider" DataTextField="name" 
            DataValueField="nr">
        </asp:DropDownList>
        <br />
          <asp:SqlDataSource ID="GetRider" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="entryGetRidersFederation" SelectCommandType="StoredProcedure">
              <SelectParameters>
                  <asp:ControlParameter ControlID="FedID" Name="id_federation" 
                      PropertyName="Value" Type="Int16" />
              </SelectParameters>
        </asp:SqlDataSource>
        <br />
 
    </div>
    <div>
        <asp:HiddenField ID="minriderid" runat="server" Value="" />
        <asp:HiddenField ID="maxriderid" runat="server" Value="" />

    </div>
    <div id="riderlist" style="width: 1100px">
        <% 'testcreation()%>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
             DataSourceID="SqlDataSource1" 
            AllowSorting="True" AllowMultiRowSelection="True">

<MasterTableView DataSourceID="SqlDataSource1" 
                DataKeyNames="id_rider,id_event,id_championship,id_class">
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" />
        <telerik:GridBoundColumn DataField="ev_date" DataType="System.DateTime" 
            FilterControlAltText="Filter ev_date column" HeaderText="Date" 
            SortExpression="ev_date" UniqueName="ev_date">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="raccity" 
            FilterControlAltText="Filter raccity column" HeaderText="Venue" 
            SortExpression="raccity" UniqueName="raccity">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="class" 
            FilterControlAltText="Filter class column" HeaderText="Class" 
            SortExpression="class" UniqueName="class">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="bike" 
            FilterControlAltText="Filter bike column" 
            HeaderText="Bike" SortExpression="bike" 
            UniqueName="bike">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="tname" 
            FilterControlAltText="Filter tname column" HeaderText="Team" 
            SortExpression="tname" UniqueName="tname">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="state_participant" 
            FilterControlAltText="Filter state_participant column" HeaderText="State Participation" 
            SortExpression="state_participant" UniqueName="state_participant">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="state_entry" 
            FilterControlAltText="Filter state_entry column" HeaderText="State Entry" 
            SortExpression="state_entry" UniqueName="state_entry">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="state_onsite" 
            FilterControlAltText="Filter state_onsite column" 
            HeaderText="State Onsite" SortExpression="state_onsite" 
            UniqueName="state_onsite">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="id_rider" DataType="System.Int16" 
            FilterControlAltText="Filter id_rider column" 
            HeaderText="id_rider" ReadOnly="True" SortExpression="id_rider" 
            UniqueName="id_rider" Visible="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="id_event" DataType="System.Int16" 
            FilterControlAltText="Filter id_event column" HeaderText="id_event" 
            ReadOnly="True" SortExpression="id_event" UniqueName="id_event" 
            Visible="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="id_championship" DataType="System.Int16" 
            FilterControlAltText="Filter id_championship column" 
            HeaderText="id_championship" ReadOnly="True" SortExpression="id_championship" 
            UniqueName="id_championship" Visible="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="id_class" DataType="System.Int16" 
            FilterControlAltText="Filter id_class column" HeaderText="id_class" 
            ReadOnly="True" SortExpression="id_class" UniqueName="id_class" Visible="True">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="id_team" DataType="System.Int16" 
            FilterControlAltText="Filter id_team column" HeaderText="id_team" 
            SortExpression="id_team" UniqueName="id_team" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="id_bike" DataType="System.Int16" 
            FilterControlAltText="Filter id_bike column" HeaderText="id_bike" 
            SortExpression="id_bike" UniqueName="id_bike" Visible="False">
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>
<ClientSettings>
  <Selecting AllowRowSelect="True" />
</ClientSettings>
        </telerik:RadGrid>
        </div>

<div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
        SelectCommand="entryGetRidersEventsFederation" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddRiders" Name="id_rider" 
                PropertyName="SelectedValue" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
</div><br />
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

