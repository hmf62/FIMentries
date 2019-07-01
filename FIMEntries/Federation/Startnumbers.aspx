<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Startnumbers.aspx.vb" Inherits="federation_startnumbers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="float: right">
        <asp:LoginName id="LoginName1" runat="server" 
               FormatString ="Welcome, {0}" />
                         <input type="submit" Value="SignOut" runat="server" id="cmdSignOut" 
            style="padding-left: 1px; margin-left: 15px;" visible="False">
           <asp:Button ID="btSignOut" runat="server" Text="SignOut" CausesValidation="False" />
    </div>
       <asp:HiddenField ID="FedID" runat="server" />
   </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <br />
        <asp:Label ID="lblCship" runat="server" Text="Championship"></asp:Label>
        <asp:DropDownList ID="ddChampship" runat="server" AutoPostBack="True" 
            DataSourceID="GetCship" DataTextField="champshipname" 
            DataValueField="champshipid">
        </asp:DropDownList>
        <asp:Label ID="lblClass" runat="server" Text="Select event"></asp:Label>

        <asp:Label ID="lbClasses" runat="server" Text="Select class:"></asp:Label>
        <asp:DropDownList ID="ddClasses" runat="server" AutoPostBack="True" 
            DataSourceID="GetClass" DataTextField="class" DataValueField="ev_class">
        </asp:DropDownList>
        <asp:SqlDataSource ID="GetClass" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="SeasonStartNumbersClass" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddChampship" Name="cshipid" 
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
    <div id="riderlist">
        <% 'testcreation()%>
        <telerik:RadGrid ID="rgStartNumbers" runat="server" AutoGenerateColumns="False" 
             DataSourceID="Entries" GridLines="Horizontal" 
            AllowSorting="True" AllowMultiRowSelection="True" CellSpacing="0" 
            RenderMode="Classic">

<MasterTableView DataSourceID="Entries">
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridBoundColumn DataField="snr" 
            HeaderText="snr" SortExpression="snr" UniqueName="snr" 
            FilterControlAltText="Filter snr column" DataType="System.Int16">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ln" HeaderText="ln" 
            SortExpression="ln" UniqueName="ln" 
            FilterControlAltText="Filter ln column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fn" 
            HeaderText="fn" SortExpression="fn" UniqueName="fn" 
            FilterControlAltText="Filter fn column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fshort" 
            HeaderText="fshort" SortExpression="fshort" UniqueName="fshort" 
            FilterControlAltText="Filter fshort column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="cshort" HeaderText="cshort" 
            SortExpression="cshort" UniqueName="cshort" 
            FilterControlAltText="Filter cshort column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="bike" 
            FilterControlAltText="Filter bike column" HeaderText="bike" 
            SortExpression="bike" UniqueName="bike">
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>
<ClientSettings>
  <Selecting AllowRowSelect="True" />
</ClientSettings>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="Entries" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
            SelectCommand="StartnumbersFederations" SelectCommandType="StoredProcedure" 
            UpdateCommand="entrylistupdate" UpdateCommandType="StoredProcedure">
            <SelectParameters>
                <asp:FormParameter DefaultValue="1" FormField="fedid" Name="id_fed" 
                    Type="Int16" />
                <asp:ControlParameter ControlID="ddChampship" Name="id_championship" 
                    PropertyName="SelectedValue" Type="Int16" />
                <asp:ControlParameter ControlID="ddClasses" Name="id_class" 
                    PropertyName="SelectedValue" Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        </div>
    </form>
</body>
</html>

