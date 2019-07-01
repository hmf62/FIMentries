<%@ Page Language="VB" AutoEventWireup="false" CodeFile="entryform1.aspx.vb" Inherits="entry_entryform1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width: 1000px">
    <asp:TextBox ID="hidrid" runat="server" Visible="False"></asp:TextBox>
   <asp:ScriptManager ID="ScriptManager1" runat="server" />
       <div>

        <img src="../images/2014/MXGP-Logosmall.png" alt="MXGP" />
    </div>
    <telerik:RadAjaxManager runat=server>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cmdSignOut">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="LoginName2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Button1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ridermain" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="mxevents" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButtonList1" 
                        UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Button1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="Grid1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButtonList1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ridermain" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="grid1" />
                    <telerik:AjaxUpdatedControl ControlID="RadButton1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadButton1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="mxevents" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButtonList1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="grid1" />
                    <telerik:AjaxUpdatedControl ControlID="RadButton1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
       <div style="float: right">
        <asp:LoginName id="LoginName2" runat="server" 
               FormatString ="Welcome, {0}" />
               <input type="submit" Value="SignOut" runat="server" id="cmdSignOut" 
            style="padding-left: 1px; margin-left: 15px;" visible="False">
           <asp:Button ID="btSignOut" runat="server" Text="SignOut" CausesValidation="False" />
           </div>
<div id="ridermain" style="visibility:visible" runat="server">
<table>
 <tr>
    <td colspan="2">

<asp:ValidationSummary ID="ValidationSummary1" runat=server 
HeaderText="There were errors on the page:" />
</td>
  </tr>
 <tr>
    <td>
    </td>
    <td>Rider ID:</td>
     
    <td><telerik:RadTextBox ID="txtRiderID" runat="server" ReadOnly="True">
     </telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
    </td>
    <td>Last/Family Name:</td>
    <td><telerik:RadTextBox  runat=server id=txtName readonly="true"></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
    </td>
    <td>First Name:</td>
    <td><telerik:RadTextBox runat=server id=txtFName readonly="true"></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
    </td>
    <td>Birthdate:</td>
    <td><telerik:RadDatePicker ID="RadBirthDate" runat="server" 
            Calendar-RangeMinDate="01.01.1960 00:00:00" MinDate="01.01.1960 00:00:00" 
            Calendar-CultureInfo="en-US" 
            Calendar-EnableMultiSelect="False" 
            Calendar-EnableRepeatableDaysOnClient="False" Calendar-EnableTheming="False" 
            Calendar-FastNavigationStep="6" BorderStyle="None" 
            Calendar-RangeMaxDate="01.01.2009 00:00:00" DateInput-Culture="de-DE" 
            DateInput-DisplayDateFormat="dd.MM.yyyy" DateInput-DateFormat="dd.MM.yyyy" 
            Calendar-EnableAjaxSkinRendering="True" EnableTyping="False" Skin="Default">
<Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableRepeatableDaysOnClient="False" FastNavigationStep="6" ViewSelectorText="x" EnableTheming="False" runat="server"></Calendar>

<DateInput ID="DateInput1" DisplayDateFormat="dd.MM.yyyy" DateFormat="dd.MM.yyyy" 
             LabelWidth="40%" 
             type="text" ReadOnly="True" runat="server"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
    </telerik:RadDatePicker>
</td>
</tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat=server 
            ControlToValidate=ddNationality
            ErrorMessage="Selection of Federation is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Nationality:
    <td> <asp:DropDownList ID="ddNationality" runat="server" DataSourceID="SelCountry" DataTextField="cshort"
            DataValueField="cnr">
             </asp:DropDownList>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat=server 
            ControlToValidate=ddFederation
            ErrorMessage="Selection of Federation is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Federation:</td>
    <td><asp:DropDownList ID="ddFederation" runat="server" DataSourceID="SelFederation" DataTextField="fshort"
            DataValueField="fnr">
        </asp:DropDownList>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat=server 
            ControlToValidate=ddBike
            ErrorMessage="Motorcyle make is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Motorcycle make:</td>
    <td><asp:DropDownList ID="ddBike" runat="server" DataSourceID="selBikes" DataTextField="bike"
            DataValueField="bnr">
        </asp:DropDownList>
        <asp:SqlDataSource ID="selBikes" runat="server" ConnectionString="<%$ ConnectionStrings:ASPWeb %>"
            SelectCommand="SELECT [bike], [bnr] FROM [bikes] WHERE ([activebike] = @activebike) ORDER BY [bike]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="activebike" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource></td>
  </tr>

 <tr>
    <td>
        
    </td>
    <td>Tire brand:</td>
    <td><asp:DropDownList ID="ddTire" runat="server" DataSourceID="selTires" DataTextField="name"
            DataValueField="id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="selTires" runat="server" ConnectionString="<%$ ConnectionStrings:ASPWeb %>"
            SelectCommand="SELECT [id], [name] FROM [tires] ORDER BY [id]">
        </asp:SqlDataSource></td>
  </tr>


   <tr>
    <td>
    </td>
    <td style="font-size: large">Riders Address</td>
    <td></td>
  </tr>

   <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat=server 
            ControlToValidate=txtAddress1
            ErrorMessage="Address 1 is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Address 1:</td>
    <td><telerik:RadTextBox runat=server id=txtAddress1></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
    </td>
    <td>Address 2:</td>
    <td><telerik:RadTextBox runat=server id=txtAddress2></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat=server 
            ControlToValidate=txtRPCode
            ErrorMessage="Riders Postal Code is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Postal Code:</td>
    <td><telerik:RadTextBox runat=server id=txtRPCode></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat=server 
            ControlToValidate=txtRCity
            ErrorMessage="City is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>City:</td>
    <td><telerik:RadTextBox runat=server id=txtRCity></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat=server 
            ControlToValidate=ddCountry
            ErrorMessage="Country (Address) is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Country:</td>
    <td>        <asp:DropDownList ID="ddCountry" runat="server" DataSourceID="SelCountry" DataTextField="cshort"
            DataValueField="cnr">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SelCountry" runat="server" ConnectionString="<%$ ConnectionStrings:ASPWeb %>"
            SelectCommand="SELECT [cnr], [cshort] FROM [countries] WHERE ([activecountry] = @activecountry) ORDER BY [cshort]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="activecountry" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
</td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat=server 
            ControlToValidate=txtRTelephone
            ErrorMessage="Phone number is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Telephone:</td>
    <td><telerik:RadTextBox runat=server id=txtRTelephone></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat=server 
            ControlToValidate=txtRMobile
            ErrorMessage="Mobile number is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>Mobile number:</td>
    <td><telerik:RadTextBox runat=server id=txtRMobile></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
    </td>
    <td>Telefax number:</td>
    <td><telerik:RadTextBox runat=server id=txtRFax></telerik:RadTextBox></td>
  </tr>
 <tr>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat=server 
            ControlToValidate=txtREMail
            ErrorMessage="Email address is required"> *
        </asp:RequiredFieldValidator>
    </td>
    <td>PERSONAL email address:<br />NO team mail address</td>
    <td><telerik:RadTextBox runat=server id=txtREMail></telerik:RadTextBox></td>
  </tr>
   <tr style="padding: 10px; margin: 5px">
    <td>
    </td>
    <td style="font-size: large">Team Data</td>
    <td></td>
  </tr>
   <tr style="padding: 10px; margin: 5px">
    <td>
    </td>
    <td colspan=2 style="font-size: large"><b>For all FIM classes (MXGP, MX2, WMX) all teams need to have a FIM Team license for 2019.</b></td>
    
  </tr>
   <tr>
    <td>
      
    </td>

    <td>Team name:</td>
    <td><asp:DropDownList ID="ddTeam" runat="server" DataSourceID="selTeams" DataTextField="tname"
            DataValueField="idTeam">
        </asp:DropDownList></td>
  </tr>
    
</table>

</div>

<div id="mxevents" runat="server" >
    <asp:Label ID="Label1" runat="server" 
        Text="Please select the class you want to participate. </br>PLEASE WAIT UNTIL YOU SEE A LIST OF EVENTS AFTER YOU HAVE SELECTED A CLASS" Visible="True"></asp:Label>

    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
        Visible="False">
        <asp:ListItem Value="9">MXGP</asp:ListItem>
        <asp:ListItem Value="7">MX2</asp:ListItem>
        <asp:ListItem Value="27">Women (WMX)</asp:ListItem>
        <asp:ListItem Value="33" Enabled="True">EMX125</asp:ListItem>
        <asp:ListItem Value="46" Enabled="True">EMX250</asp:ListItem>
        <asp:ListItem Value="49" Enabled="True">EMX 2t (250cc 2 Stroke)</asp:ListItem>
        <asp:ListItem Value="47" Enabled="True">EMX65 final</asp:ListItem>
        <asp:ListItem Value="48" Enabled="True">EMX85 final</asp:ListItem>
        <asp:ListItem Value="57" Enabled="False">Yamaha bLUcRU (registration will open later)</asp:ListItem>

    </asp:RadioButtonList><br />

</div>



<div id=grid1 runat=server style="visibility: hidden; display: none;" >
    <asp:Label ID="Label2" runat="server" Text="Please select the events where you want to participate. You will see only events to which you did not enter before already. The list of events will be updated later, after the final calendar is available"  Visible="True"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="For the moment no entry requests can be submitted for 2019, but you can request start numbers for the 2018 season." Visible="False"></asp:Label>
    <telerik:RadGrid ID="RadGrid1" runat="server"  
        DataSourceID="SqlDataSource1" Visible="False" 
        AllowMultiRowSelection="True" AutoGenerateColumns="False" Width="500px">
<MasterTableView 
            DataSourceID="SqlDataSource1" DataKeyNames="eventid, raccity, clong, ev_date">
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
            SortExpression="ev_date" UniqueName="ev_date" DataFormatString="{0:d}">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="raccity" 
            FilterControlAltText="Filter raccity column" HeaderText="Venue" 
            SortExpression="raccity" UniqueName="raccity">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="clong" 
            FilterControlAltText="Filter clong column" HeaderText="Country" 
            SortExpression="clong" UniqueName="clong">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="eventid" DataType="System.Int16" 
            FilterControlAltText="Filter eventid column" HeaderText="eventid" 
            SortExpression="eventid" UniqueName="eventid">
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
    </telerik:RadGrid>

    <table>
    <!----
    <tr>
    <td colspan="2">Please provice your AMB/mylaps Transponder numbers<br />(if you have them already)</td></tr>
    <tr><td>Transponder 1</td><td><asp:TextBox ID="txtTransponder1" runat="server"></asp:TextBox></td></tr>
    <tr><td>Transponder 2</td><td><asp:TextBox ID="txtTransponder2" runat="server"></asp:TextBox></td></tr>
    --->
    
    <tr>
    <td colspan="2">Please enter your favourite start numbers (Only if you did NOT request it already before)</td></tr>
    <tr><td colspan="2">To help you with your selection you can find start numbers which are already assigned here: <a href="https://results.mxgp.com/seasonstartnumbers.aspx" target="_blank">Assigned start numbers </a><br />A top 10 number in MXGP/MX2 will assigned just to riders, who did finish a season at least one time within the top 10</td></tr>
    <tr><td>Start #1</td><td><asp:TextBox ID="txtStart1" runat="server"></asp:TextBox></td></tr>
    <tr><td>Start #2</td><td><asp:TextBox ID="txtStart2" runat="server"></asp:TextBox></td></tr>
    <tr><td>Start #3</td><td><asp:TextBox ID="txtStart3" runat="server"></asp:TextBox></td></tr>
    </table><br />
    <asp:Label ID="Label3" runat="server" Text="Please note that the requested start numbers can be given just based on the availability."></asp:Label>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SQLConnection1 %>" 
        SelectCommand="SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '2018') AND events.eventid > 3300 AND (ev_races.ev_class = @ev_class) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date">
        <SelectParameters>
            <asp:ControlParameter ControlID="RadioButtonList1" Name="ev_class" 
                PropertyName="SelectedValue" />
                            <asp:QueryStringParameter Name="id_rider" QueryStringField="rid" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SelFederation" runat="server" ConnectionString="<%$ ConnectionStrings:ASPWeb %>"
            SelectCommand="SELECT [fnr], [fshort] FROM [federations] ORDER BY [fshort]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="selTeams" runat="server" ConnectionString="<%$ ConnectionStrings:ASPWeb %>"
            SelectCommand="teams_registered_and_oat" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</div>

    <asp:Button ID="btnBack" runat="server" Text="Back" Visible="False" />

    <telerik:RadButton ID="Button1" runat="server" Text="Save & Continue"></telerik:RadButton>
    <telerik:RadButton ID="RadButton1" runat="server" Text="Request Entry" 
        Visible="False">
    </telerik:RadButton>
    <asp:Button ID="Button2" runat="server" Text="Test"  Visible="False" />

    </form>
</body>
</html>
