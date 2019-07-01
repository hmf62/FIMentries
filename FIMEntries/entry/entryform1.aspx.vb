Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.ControlCollection
Imports Telerik.Web.UI
Imports System.Net.Mail
Imports System.Net
Imports System.Configuration

Partial Class entry_entryform1
    Inherits System.Web.UI.Page
    Dim mail As New MailMessage()
    Dim requid As String
    Dim fromaddress As String
    Dim AspWeb1 As SqlConnection = New System.Data.SqlClient.SqlConnection
    Dim AspWeb2 As SqlConnection = New System.Data.SqlClient.SqlConnection
    Dim sqlsaveriderdata As SqlCommand = New System.Data.SqlClient.SqlCommand
    Dim authok As Boolean
    Dim entrycount As Integer
    Dim Returnurl As String
    Dim teamid As Integer = 0
    Dim YearEntryBefore As String
    Dim YearEntryAct As String
    Dim EventMin As Integer
    Dim EventMax As Integer
    Dim EventMXoN As Integer




    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim champshipid As Integer = 0

        If RadioButtonList1.SelectedValue = 6 Or RadioButtonList1.SelectedValue = 7 Or RadioButtonList1.SelectedValue = 9 Then
            champshipid = 1
            SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class) AND (ev_races.champshipid = 1) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
        ElseIf RadioButtonList1.SelectedValue = 27 Then
            SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class)  AND (ev_races.champshipid = 19) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() })  ORDER BY events.ev_date"
        ElseIf RadioButtonList1.SelectedValue = 28 Then
            SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class)  AND (ev_races.champshipid = 11) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
            ' ElseIf RadioButtonList1.SelectedValue = 34 Then
            '    SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct &"') AND (ev_races.ev_class = @ev_class)  AND (ev_races.champshipid = 15) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
        ElseIf RadioButtonList1.SelectedValue = 58 Then
            SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE AND  (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class)  AND (ev_races.champshipid = 20) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
        ElseIf RadioButtonList1.SelectedValue = 57 Then
            SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class)  AND (ev_races.champshipid = 21) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
        ElseIf RadioButtonList1.SelectedValue = 59 Then
            SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class)  AND (ev_races.champshipid = 18) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
        Else
            SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class)  AND (ev_races.champshipid = 6) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
        End If


        'SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '2014') AND (ev_races.ev_class = @ev_class) and AND (ev_races.champshipid = 6) ORDER BY events.ev_date"
        If User.Identity.Name = "hmf@youthstream.org" Or User.Identity.Name = "Hans-Martin Fetzer" Then
            RadGrid1.DataBind()
        End If
        RadGrid1.Visible = True
        RadGrid1.AllowMultiRowSelection = True
        RadButton1.Visible = True
        RadButton1.Enabled = True
        grid1.Attributes.Add("style", "visibility:visable")

    End Sub

    Protected Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If (TypeOf e.Item Is GridHeaderItem) Then
            Dim header As GridHeaderItem = CType(e.Item, GridHeaderItem)
            Dim chkbx As CheckBox = CType(header("ClientSelectColumn").Controls(0), CheckBox)
            chkbx.Visible = False
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        'txtName.Value = RadBirthDate.DbSelectedDate.ToString
        'txtFName.Value = RadBirthDate.SelectedDate.ToString
        If Not Button1.Text = "Request entry" Then

            saveriderdata()
            ridermain.Attributes.Add("style", "visibility:hidden")
            ridermain.Attributes.Add("style", "display:none")
            mxevents.Attributes.Add("style", "display:none")
            mxevents.Attributes.Add("style", "visibility:visable")
            btnBack.Visible = False
            RadioButtonList1.Visible = True
            'Button1.Text = "Request entry"
            Button1.Enabled = False
            Button1.Visible = False
        Else
            Dim nselect As Integer = 0
            Dim riderID As Integer = 0



            'For Each item As GridDataItem In RadGrid1.SelectedItems
            'nselect = nselect + 1
            '                Response.Write("Event: " & item("eventid").Text)

            '            riderID = item.GetDataKeyValue("nr").ToString
            'Next
            ' Response.Write(nselect & " items selected")

            '            btnUpdate.Text = "Update" & " " & riderStatus.SelectedValue
            '
            saveentries()
                RadGrid1.Rebind()

                If entrycount > 0 Then
                send_message(0)
                Response.Write(entrycount & " events were selected...")
            Else
                Response.Write("No events were selected...")

            End If
            'events.Attributes.Add("style", "visibility:hidden")
            mxevents.Attributes.Add("style", "display:none")
                'grid1.Attributes.Add("style", "visibility:hidden")
                grid1.Attributes.Add("style", "display:none")
                Button1.Enabled = False
                Button1.Visible = False
            End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        hidrid.Text = Request.QueryString("rid")
        YearEntryBefore = System.Configuration.ConfigurationManager.AppSettings("YearEntryBefore")
        YearEntryAct = System.Configuration.ConfigurationManager.AppSettings("YearEntryAct")

        If Not Page.IsPostBack Then


            EventMin = System.Configuration.ConfigurationManager.AppSettings("EventMin")
            EventMax = System.Configuration.ConfigurationManager.AppSettings("EventMax")
            EventMXoN = System.Configuration.ConfigurationManager.AppSettings("EventMXoN")


            If Request.QueryString("rid") > 0 Then
                Dim AspWeb1 = New System.Data.SqlClient.SqlConnection
                Dim AspWeb2 = New System.Data.SqlClient.SqlConnection

                Dim getriderdata = New System.Data.SqlClient.SqlCommand
                '
                'AspWeb
                '
                AspWeb1.ConnectionString = ConfigurationManager.ConnectionStrings("ASPWeb").ConnectionString
                AspWeb2.ConnectionString = ConfigurationManager.ConnectionStrings("ASPWeb2").ConnectionString
                getriderdata.Connection = AspWeb1
                getriderdata.CommandType = CommandType.StoredProcedure
                getriderdata.CommandText = "dbo.entrygetriderdata1"
                getriderdata.Parameters.Add("@rid", SqlDbType.SmallInt, 2)
                getriderdata.Parameters("@rid").Value = Request.QueryString("rid")
                hidrid.Text = Request.QueryString("rid")
                Dim dr As SqlClient.SqlDataReader
                Dim dr2 As SqlClient.SqlDataReader


                AspWeb1.Open()
                dr = getriderdata.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    If User.Identity.Name = "hmf@youthstream.org" Or User.Identity.Name = "Hans-Martin Fetzer" Then
                        authok = True
                        SqlDataSource1.SelectCommand = "SELECT events.ev_date, tracks.raccity, countries.clong, events.eventid FROM events INNER JOIN tracks ON events.ev_track = tracks.tracknr INNER JOIN ev_races ON events.eventid = ev_races.ev_id INNER JOIN countries ON tracks.country = countries.cnr WHERE (events.ev_year = '" & YearEntryAct & "') AND (ev_races.ev_class = @ev_class) AND (NOT (events.eventid IN (SELECT id_event FROM riders_events WHERE (id_class = @ev_class) AND (id_rider = @id_rider)))) AND (events.ev_date > { fn NOW() }) ORDER BY events.ev_date"
                        If Request.QueryString("rt") = "tm" Then
                            Returnurl = "https://results.mxgp.com/team/seasoninfo.aspx"
                        Else
                            Returnurl = "https://results.mxgp.com/rider/default.aspx"
                        End If

                    ElseIf Not IsDBNull(dr("ridemail")) Then
                        If LCase(User.Identity.Name) = LCase(dr("ridemail")) Then authok = True
                        Returnurl = "https://results.mxgp.com/rider/default.aspx"
                    End If

                    If Not IsDBNull(dr("manager_email")) And Request.QueryString("rt") = "tm" Then
                        If LCase(User.Identity.Name) = LCase(dr("manager_email")) Then authok = True
                    End If

                    If Request.QueryString("rt") = "tm" And Not authok = True Then
                        Dim checkteamlogin = New System.Data.SqlClient.SqlCommand
                        checkteamlogin.Connection = AspWeb2
                        checkteamlogin.CommandType = CommandType.StoredProcedure
                        checkteamlogin.CommandText = "dbo.TeamQuestionaireID"
                        checkteamlogin.Parameters.Add("@teamid", SqlDbType.SmallInt, 2)
                        'Special case KTM, one ID for several teams
                        If dr("team") = 662 Then
                            checkteamlogin.Parameters("@teamid").Value = 503
                        Else
                            checkteamlogin.Parameters("@teamid").Value = dr("team")
                        End If

                        AspWeb2.Open()
                        dr2 = checkteamlogin.ExecuteReader
                        If dr2.HasRows Then
                            dr2.Read()
                            If LCase(dr2("teammail")) = LCase(User.Identity.Name) Then authok = True
                            Returnurl = "https://results.mxgp.com/team/seasoninfo.aspx"
                        End If
                        dr2.Close()
                        AspWeb2.Close()
                    End If
                    'If User.Identity.Name = "teamclsjj@gmail.com" And dr("team") = 116 Then authok = True

                    If Not authok = True Then
                        FormsAuthentication.SignOut()
                        Response.Redirect("../default.aspx", True)
                    End If

                    If authok = True Then


                        If Not IsDBNull(dr("nr")) Then
                            txtRiderID.Text = dr("nr")
                        End If
                        If Not IsDBNull(dr("ln")) Then
                            txtName.Text = dr("ln")
                        End If
                        If Not IsDBNull(dr("fn")) Then
                            txtFName.Text = dr("fn")
                        End If
                        If Not IsDBNull(dr("hometown")) Then
                            txtRCity.Text = dr("hometown")
                        End If
                        If Not IsDBNull(dr("postcode")) Then
                            txtRPCode.Text = dr("postcode")
                        End If
                        If Not IsDBNull(dr("address1")) Then
                            txtAddress1.Text = dr("address1")
                        End If
                        If Not IsDBNull(dr("address2")) Then
                            txtAddress2.Text = dr("address2")
                        End If
                        If Not IsDBNull(dr("phone")) Then
                            txtRTelephone.Text = dr("phone")
                        End If
                        If Not IsDBNull(dr("fax")) Then
                            txtRFax.Text = dr("fax")
                        End If
                        If Not IsDBNull(dr("mobile")) Then
                            txtRMobile.Text = dr("mobile")
                        End If
                        If Not IsDBNull(dr("ridemail")) Then
                            txtREMail.Text = dr("ridemail")
                        End If
                        'If Not IsDBNull(dr("tname")) Then
                        ' txt.text = dr("tname")
                        'End If
 
                        ' If Not IsDBNull(dr("bike_capacity")) Then
                        'txtbikeCapacity.Value = dr("bike_capacity")
                        'Else
                        'txtbikeCapacity.Value = 0
                        '   End If
                        If Not IsDBNull(dr("homecountry")) Then
                            ddCountry.SelectedValue = dr("homecountry")
                        End If
                        If Not IsDBNull(dr("nat")) Then
                            ddNationality.SelectedValue = dr("nat")
                        End If
                        If Not IsDBNull(dr("bike")) Then
                            ddBike.SelectedValue = dr("bike")
                        End If
                        If Not IsDBNull(dr("fed")) Then
                            ddFederation.SelectedValue = dr("fed")
                        End If
                        If Not IsDBNull(dr("id_tire")) Then
                            ddTire.SelectedValue = dr("id_tire")
                        Else
                            ddTire.SelectedValue = 0
                        End If
                        If Not IsDBNull(dr("team")) Then
                            teamid = dr("team")
                            Dim testval As New ListItem
                            testval = ddTeam.Items.FindByValue(dr("team"))
                            '                            If IsNothing(testval) Then
                            If IsNothing(ddTeam.Items.FindByValue(dr("team"))) Then

                                '                            If ddTeam.Items.Contains(testval) Then
                                ' ddTeam.SelectedValue = "8"
                            Else
                                ' ddTeam.SelectedValue = dr("team")
                                '             ddTeam.SelectedValue = 8
                            End If
                        End If
                        If Not IsDBNull(dr("birth")) Then
                            If Not dr("birth") = "01.01.2006 00:00:00" Then
                                RadBirthDate.DbSelectedDate = dr("birth")
                                If Not IsDBNull(dr("birth_proved")) Then
                                    If dr("birth_proved") = "True" Then
                                        RadBirthDate.Enabled = False
                                    End If
                                End If
                            End If
                        End If
                    Else
                        Response.Write("You are not allowed to edit the details of this rider")
                    End If


                    AspWeb1.Close()
                End If
            End If
        End If
        'ddBike.SelectedValue = 2
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        ridermain.Attributes.Add("style", "visibility:visible")
        ridermain.Attributes.Add("style", "display:relative")
        btnBack.Visible = False
        Button1.Text = "Save & Continue"
        RadioButtonList1.Visible = False
        RadGrid1.Visible = False
    End Sub

    Sub saveriderdata()
        'Response.Write("Data is saved")
        '
        'AspWeb
        '
        AspWeb2.ConnectionString = ConfigurationManager.ConnectionStrings("SQLConnection1W").ConnectionString

        sqlsaveriderdata.Connection = AspWeb2
        sqlsaveriderdata.CommandType = CommandType.StoredProcedure
        sqlsaveriderdata.CommandText = "dbo.entrysaveriderdata2"
        sqlsaveriderdata.Parameters.Add("@rid", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@nat", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@fed", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@bike", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@team", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@id_tire", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@homecountry", SqlDbType.SmallInt, 2)
        sqlsaveriderdata.Parameters.Add("@ln", SqlDbType.VarChar, 20)
        sqlsaveriderdata.Parameters.Add("@fn", SqlDbType.VarChar, 20)
        sqlsaveriderdata.Parameters.Add("@hometown", SqlDbType.VarChar, 30)
        sqlsaveriderdata.Parameters.Add("@postcode", SqlDbType.VarChar, 8)
        sqlsaveriderdata.Parameters.Add("@address1", SqlDbType.VarChar, 50)
        sqlsaveriderdata.Parameters.Add("@address2", SqlDbType.VarChar, 50)
        sqlsaveriderdata.Parameters.Add("@phone", SqlDbType.VarChar, 20)
        sqlsaveriderdata.Parameters.Add("@fax", SqlDbType.VarChar, 20)
        sqlsaveriderdata.Parameters.Add("@mobile", SqlDbType.VarChar, 20)
        sqlsaveriderdata.Parameters.Add("@ridemail", SqlDbType.VarChar, 50)
        sqlsaveriderdata.Parameters.Add("@birth", SqlDbType.DateTime)
        'sqlsaveriderdata.Parameters.Add("@bike_capacity", SqlDbType.Float)
        sqlsaveriderdata.Parameters("@rid").Value = txtRiderID.Text
        sqlsaveriderdata.Parameters("@nat").Value = ddNationality.SelectedValue
        sqlsaveriderdata.Parameters("@fed").Value = ddFederation.SelectedValue
        sqlsaveriderdata.Parameters("@bike").Value = ddBike.SelectedValue
        sqlsaveriderdata.Parameters("@team").Value = ddTeam.SelectedValue
        sqlsaveriderdata.Parameters("@id_tire").Value = ddTire.SelectedValue
        sqlsaveriderdata.Parameters("@homecountry").Value = ddCountry.SelectedValue
        sqlsaveriderdata.Parameters("@ln").Value = txtName.Text
        sqlsaveriderdata.Parameters("@fn").Value = txtFName.Text
        sqlsaveriderdata.Parameters("@birth").Value = RadBirthDate.DbSelectedDate
        sqlsaveriderdata.Parameters("@hometown").Value = txtRCity.Text
        sqlsaveriderdata.Parameters("@postcode").Value = txtRPCode.Text
        sqlsaveriderdata.Parameters("@address1").Value = txtAddress1.Text
        sqlsaveriderdata.Parameters("@address2").Value = txtAddress2.Text
        sqlsaveriderdata.Parameters("@phone").Value = txtRTelephone.Text
        sqlsaveriderdata.Parameters("@fax").Value = txtRFax.Text
        sqlsaveriderdata.Parameters("@mobile").Value = txtRMobile.Text
        sqlsaveriderdata.Parameters("@ridemail").Value = txtREMail.Text
        ' sqlsaveriderdata.Parameters("@bike_capacity").Value = txtbikeCapacity.Value

        AspWeb2.Open()
        sqlsaveriderdata.ExecuteNonQuery()
        ' Response.Write("Data is saved")
        AspWeb2.Close()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        'saveentries()
        'Dim requid As String
        requid = txtRiderID.Text & "-" & DatePart(DateInterval.Year, Now) & DatePart(DateInterval.Month, Now) & DatePart(DateInterval.Day, Now) & DatePart(DateInterval.Hour, Now) & DatePart(DateInterval.Minute, Now) & DatePart(DateInterval.Second, Now)
        Label1.Text = requid
        'send_message(0)
        '            btnUpdate.Text = "Update" & " " & riderStatus.SelectedValue
        'RadGrid1.Rebind()
    End Sub

    Sub saveentries()
        Dim AspWeb1 = New System.Data.SqlClient.SqlConnection
        Dim AspWeb2 = New System.Data.SqlClient.SqlConnection
        Dim saveriderdata = New System.Data.SqlClient.SqlCommand
        Dim saveriderdata1 = New System.Data.SqlClient.SqlCommand
        Dim saveriderdata2 = New System.Data.SqlClient.SqlCommand
        '
        'AspWeb
        '
        AspWeb2.ConnectionString = ConfigurationManager.ConnectionStrings("SQLConnection1W").ConnectionString

        saveriderdata.Connection = AspWeb2
        saveriderdata.CommandType = CommandType.StoredProcedure
        saveriderdata.CommandText = "dbo.entrysaveriderevents"
        saveriderdata.Parameters.Add("@id_rider", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_event", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_country", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_championship", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_class", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_federation", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_team", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_bike", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@id_tire", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@status_entry", SqlDbType.SmallInt, 2)
        saveriderdata.Parameters.Add("@bike_capacity", SqlDbType.Float, 8)
        saveriderdata.Parameters.Add("@id_evrequest", SqlDbType.NVarChar, 20)
        saveriderdata.Parameters.Add("@first", SqlDbType.SmallInt, 2)

        Dim nselect As Integer = 0
        Dim riderID As Integer = 0
         Dim itemtext As String
        Dim Champship As Integer = 0

        requid = txtRiderID.Text & "-" & DatePart(DateInterval.Year, Now) & DatePart(DateInterval.Month, Now) & DatePart(DateInterval.Day, Now) & DatePart(DateInterval.Hour, Now) & DatePart(DateInterval.Minute, Now) & DatePart(DateInterval.Second, Now)
        'Label1.Text = "Hallo"
        'Button2.Text = "Hallo"

        If RadioButtonList1.SelectedValue = 6 Or RadioButtonList1.SelectedValue = 9 Or RadioButtonList1.SelectedValue = 7 Then
            Champship = 1
        ElseIf RadioButtonList1.SelectedValue = 27 Then
            Champship = 19
        ElseIf RadioButtonList1.SelectedValue = 28 Then
            Champship = 11
        ElseIf RadioButtonList1.SelectedValue = 34 Then
            Champship = 15
        ElseIf RadioButtonList1.SelectedValue = 58 Then
            Champship = 20
        ElseIf RadioButtonList1.SelectedValue = 57 Then
            Champship = 21
        ElseIf RadioButtonList1.SelectedValue = 59 Then
            Champship = 18
        Else
            Champship = 6
        End If

        For Each item As GridDataItem In RadGrid1.SelectedItems


            saveriderdata.Parameters("@id_rider").Value = Request.QueryString("rid")
            saveriderdata.Parameters("@id_country").Value = ddNationality.SelectedValue
            saveriderdata.Parameters("@id_federation").Value = ddFederation.SelectedValue
            saveriderdata.Parameters("@id_bike").Value = ddBike.SelectedValue
            saveriderdata.Parameters("@id_team").Value = ddTeam.SelectedValue
            saveriderdata.Parameters("@id_tire").Value = ddTire.SelectedValue
            '  saveriderdata.Parameters("@bike_capacity").Value = Trim(txtbikeCapacity.Value)
            saveriderdata.Parameters("@bike_capacity").Value = 0
            saveriderdata.Parameters("@id_event").Value = Trim(item("eventid").Text)
            itemtext = item("eventid").Text

            saveriderdata.Parameters("@id_class").Value = RadioButtonList1.SelectedValue
            saveriderdata.Parameters("@status_entry").Value = 1





            saveriderdata.Parameters("@id_championship").Value = Champship
            saveriderdata.Parameters("@id_evrequest").Value = requid


            If entrycount = 0 Then
                saveriderdata.Parameters("@first").Value = 1
                entrycount = entrycount + 1
            Else
                saveriderdata.Parameters("@first").Value = 0
                entrycount = entrycount + 1
            End If
            AspWeb2.Open()
            Try
                saveriderdata.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            AspWeb2.Close()


        Next

        'If Len(txtTransponder1.Text) > 0 Then
        ' saveriderdata1.Connection = AspWeb2
        ' saveriderdata1.CommandType = CommandType.StoredProcedure
        ' saveriderdata1.CommandText = "dbo.entrysaveridertransponders"
        ' saveriderdata1.Parameters.Add("@id_rider", SqlDbType.SmallInt, 2)
        ' saveriderdata1.Parameters.Add("@transponder", SqlDbType.NVarChar, 20)
        ' saveriderdata1.Parameters("@id_rider").Value = Request.QueryString("rid")
        ' saveriderdata1.Parameters("@transponder").Value = txtTransponder1.Text.Replace(" ", "")
        'AspWeb2.Open()
        'saveriderdata1.ExecuteNonQuery()
        'AspWeb2.Close()
        'End If

        'If Len(txtTransponder2.Text) > 0 Then
        ' saveriderdata1.Parameters("@id_rider").Value = Request.QueryString("rid")
        ' saveriderdata1.Parameters("@transponder").Value = txtTransponder2.Text.Replace(" ", "")
        ' AspWeb2.Open()
        ' saveriderdata1.ExecuteNonQuery()
        ' AspWeb2.Close()
        'End If

        If Len(txtStart1.Text) > 0 Then
            saveriderdata2.Connection = AspWeb2
            saveriderdata2.CommandType = CommandType.StoredProcedure
            saveriderdata2.CommandText = "dbo.entrysaveridersnr"
            saveriderdata2.Parameters.Add("@id_rider", SqlDbType.SmallInt, 2)
            saveriderdata2.Parameters.Add("@id_championship", SqlDbType.SmallInt, 2)
            saveriderdata2.Parameters.Add("@id_class", SqlDbType.SmallInt, 2)
            saveriderdata2.Parameters.Add("@id_season", SqlDbType.SmallInt, 2)
            saveriderdata2.Parameters.Add("@number", SqlDbType.SmallInt, 2)
            saveriderdata2.Parameters.Add("@sort_order", SqlDbType.SmallInt, 2)
            saveriderdata2.Parameters("@id_rider").Value = Request.QueryString("rid")
            saveriderdata2.Parameters("@id_class").Value = RadioButtonList1.SelectedValue
            saveriderdata2.Parameters("@id_championship").Value = Champship
            saveriderdata2.Parameters("@id_season").Value = YearEntryAct
            saveriderdata2.Parameters("@number").Value = txtStart1.Text
            saveriderdata2.Parameters("@sort_order").Value = 1
            AspWeb2.Open()
            saveriderdata2.ExecuteNonQuery()
            AspWeb2.Close()
        End If


        If Len(txtStart2.Text) > 0 Then
            saveriderdata2.Parameters("@id_rider").Value = Request.QueryString("rid")
            saveriderdata2.Parameters("@id_class").Value = RadioButtonList1.SelectedValue
            saveriderdata2.Parameters("@id_championship").Value = Champship
            saveriderdata2.Parameters("@id_season").Value = YearEntryAct
            saveriderdata2.Parameters("@number").Value = txtStart2.Text
            saveriderdata2.Parameters("@sort_order").Value = 2
            AspWeb2.Open()
            saveriderdata2.ExecuteNonQuery()
            AspWeb2.Close()
        End If

        If Len(txtStart3.Text) > 0 Then
            saveriderdata2.Parameters("@id_rider").Value = Request.QueryString("rid")
            saveriderdata2.Parameters("@id_class").Value = RadioButtonList1.SelectedValue
            saveriderdata2.Parameters("@id_championship").Value = Champship
            saveriderdata2.Parameters("@id_season").Value = YearEntryAct
            saveriderdata2.Parameters("@number").Value = txtStart3.Text
            saveriderdata2.Parameters("@sort_order").Value = 3
            AspWeb2.Open()
            saveriderdata2.ExecuteNonQuery()
            AspWeb2.Close()
        End If


        Label1.Text = Label1.Text & itemtext & " items selected"
        Label1.Text = Label1.Text & entrycount & " items selected"
        Label1.Visible = True

    End Sub

    Sub send_message(sendtype As Integer)
    
        Dim MediaTop As String = ""
        Dim MediaFlags As String = ""
        Dim MediaLogos As String = ""
        Dim TargetLinkFull As String = ""
        Dim MainTargetLinkFull As String = ""
        Dim TargetLinkText As String = ""
        Dim UnsubscribeText As String = ""
        ' cmdreadnews.Parameters.Add(New SqlClient.SqlParameter("@newsID", System.Data.SqlDbType.Int, 4))
        'cmdreadnews.Parameters.Add(New SqlClient.SqlParameter("@startID", System.Data.SqlDbType.SmallInt, 2))
        'cmdreadnews.Parameters.Add(New SqlClient.SqlParameter("@sitetype", System.Data.SqlDbType.SmallInt, 2))
        fromaddress = "Youthstream Sportoffice <sportoffice@mxgp.com>"

        sendtype = 0
        mail.From = New MailAddress(fromaddress)

  
        Dim txtmailaddressfed As String = ""


        If sendtype = 0 Then

            mail.CC.Add("sportoffice@mxgp.com")
            '            mail.To.Add("media@youthstream.org")
            Dim getfedmail As New SqlCommand
            AspWeb1.ConnectionString = ConfigurationManager.ConnectionStrings("AspWeb").ConnectionString


            getfedmail.Connection = AspWeb1
            getfedmail.CommandType = CommandType.Text
            getfedmail.CommandText = "select email_fed from fedlogins where id_fed=" & ddFederation.SelectedValue

            Dim dr As SqlDataReader
            AspWeb1.Open()
            dr = getfedmail.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read()
                    txtmailaddressfed = Trim(dr("email_fed"))
                    If Len(txtmailaddressfed) > 1 Then
                        mail.To.Add(txtmailaddressfed)
                        'txtmailaddressfed = ""
                    End If
                Loop
            End If
            AspWeb1.Close()

        End If

        If Len(txtmailaddressfed) > 1 And Len(requid) > 1 Then
            'mail.To.Add(txtmailaddressfed)

            mail.IsBodyHtml = True
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8")
            mail.Subject = "Entry request"
            mail.Body = "<html xmlns='http://www.w3.org/1999/xhtml'>"
            mail.Body = mail.Body & "<head>"
            mail.Body = mail.Body & "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'/>"
            mail.Body = mail.Body & "<title></title>"
            mail.Body = mail.Body & "<style type='text/css'>"
            mail.Body = mail.Body & "<!--"
            mail.Body = mail.Body & ".Style4 {font-family: Arial, Helvetica, sans-serif; font-size: 12px; }"
            mail.Body = mail.Body & ".Style5 {font-family: Arial, Helvetica, sans-serif; font-size: 10px; }"
            mail.Body = mail.Body & ".Style7 {font-family: Arial, Helvetica, sans-serif}"
            mail.Body = mail.Body & "-->"
            mail.Body = mail.Body & "</style>"
            mail.Body = mail.Body & "</head>"

            mail.Body = mail.Body & "<body bgcolor='#FFFFF' topmargin='0'>"

            mail.Body = mail.Body & "<table width='800' border='0' align='left' cellpadding='0' cellspacing='0' bgcolor='#FFFFFF'><tr><td>"

            mail.Body = mail.Body & "      <table border='0' cellpadding='5' cellspacing='0'>"
            mail.Body = mail.Body & "<td width='100%' valign='top'> Dear Federation member, <br/><br/> the rider "
            mail.Body = mail.Body & txtFName.Text & " " & txtName.Text & " has requested the permission to attend one or more races at events Youthstream is promoting."
            mail.Body = mail.Body & " To answer this request please use the following link. After the login you will be automatically forwarded to the data of the request. <br/><br/>"
            mail.Body = mail.Body & "http://www.youthstream.org/entry/entrypermissions.aspx?entryid=" & requid & "</td>"
            mail.Body = mail.Body & "      </tr>"
            mail.Body = mail.Body & "      <tr>"
            mail.Body = mail.Body & "        <td width='100%'><div align='left'>Alternatively please go to http://www.youthstream.org/federation, where you have access to all entry requests of your riders.<br />"
             mail.Body = mail.Body & "</td>"
            mail.Body = mail.Body & "      </tr>"
            mail.Body = mail.Body & "      <tr>"
            mail.Body = mail.Body & "        <td width='100%' align='center'><div align='left'>Thank you for the cooperation, <br />"
            mail.Body = mail.Body & "                <br />The Youthstream Sportoffice team<br /><br />"
            'mail.Body = mail.Body & txtmailaddressfed
            mail.Body = mail.Body & "</td>"
            mail.Body = mail.Body & "      </tr>"
            mail.Body = mail.Body & "    </table></td>"
            mail.Body = mail.Body & "  </tr>"
            mail.Body = mail.Body & "</table>"
            mail.Body = mail.Body & "</body>"
            mail.Body = mail.Body & "</html>"

            ' If Not Request.QueryString("rid") = 1546 Then

            If sendtype = 0 Then
                '                    Dim smtp As New SmtpClient("pod51014.outlook.com")
                '                   smtp.Port = 587

                'smtp.EnableSsl = True
                'smtp.UseDefaultCredentials = False
                'smtp.Credentials = New System.Net.NetworkCredential("sportoffice@youthstream.org", "YsSpO-2014")
                '  Dim smtp As New SmtpClient("mail.youthstream.org")
                ' smtp.Port = 25
                ' smtp.UseDefaultCredentials = False
                ' smtp.Credentials = New System.Net.NetworkCredential("smtpsend", "ysMail@send")


                Dim smtp As New SmtpClient(ConfigurationManager.AppSettings("SMTPServerSport"), ConfigurationManager.AppSettings("SMTPServerPort"))
                smtp.EnableSsl = ConfigurationManager.AppSettings("SMTPServerSSL")
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings("SMTPUserSport"), ConfigurationManager.AppSettings("SMTPPWDSport"))
                smtp.Send(mail)









                ' Try
                'smtp.Send(mail)
                'Response.Write("Thank you for your entry request. It has been forwarded to your federation for approval, and you will be informed about the progress.")

                'Catch ex As Exception
                'Response.Write("We were not able to send your request to your federation. Please contact sportoffice@youthstream.org. If possible try to redo the entry request and add a screenshot of each page, this will help us to identify the problem.")
                'Response.Write(ex.Message)
                'End Try



            Else
                '            SendMailIndividual()
            End If
            ' Else
            'End If
        Else
        If Len(txtmailaddressfed) > 1 Then
            Response.Write("No mail address found for that federation <br />")
        End If
        If Len(requid) > 1 Then
                Response.Write("We were not able to send your request to your federation. Please contact sportoffice@ymxgp.com. If possible try to redo the entry request and add a screenshot of each page, this will help us to identify the problem.")
        End If
        End If

    End Sub

    Protected Sub cmdSignOut_ServerClick(sender As Object, e As System.EventArgs) Handles cmdSignOut.ServerClick


        FormsAuthentication.SignOut()
        Response.Redirect("../default.aspx", True)

    End Sub



    Protected Sub btSignOut_Click(sender As Object, e As System.EventArgs) Handles btSignOut.Click
        FormsAuthentication.SignOut()
        Response.Redirect("../default.aspx", True)
    End Sub

    Protected Sub ToggleRowSelection(ByVal sender As Object, ByVal e As EventArgs)
        CType(CType(sender, CheckBox).NamingContainer, GridItem).Selected = CType(sender, CheckBox).Checked
    End Sub
    Protected Sub ToggleSelectedState(ByVal sender As Object, ByVal e As EventArgs)
        Dim headerCheckBox As CheckBox = CType(sender, CheckBox)
        For Each dataItem As GridDataItem In RadGrid1.Items
            CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = headerCheckBox.Checked
            dataItem.Selected = headerCheckBox.Checked
        Next
    End Sub


    Protected Sub RadButton1_Click(sender As Object, e As System.EventArgs) Handles RadButton1.Click
        Dim nselect As Integer = 0
        Dim riderID As Integer = 0



        'For Each item As GridDataItem In RadGrid1.SelectedItems
        '    nselect = nselect + 1
        '                Response.Write("Event: " & item("eventid").Text)

        '            riderID = item.GetDataKeyValue("nr").ToString
        'Next
        ' Response.Write(nselect & " items selected")

        '            btnUpdate.Text = "Update" & " " & riderStatus.SelectedValue
        '
        saveentries()
        '            RadGrid1.Rebind()

        If entrycount > 0 Then
            send_message(0)
            Response.Write(entrycount & " events were selected...")
        Else
            Response.Write("No events were selected...")

        End If
        'events.Attributes.Add("style", "visibility:hidden")
        mxevents.Attributes.Add("style", "display:none")
        'grid1.Attributes.Add("style", "visibility:hidden")
        grid1.Attributes.Add("style", "display:none")
        RadButton1.Enabled = False
        RadButton1.Visible = False
        If Returnurl = "" Then
            If Request.QueryString("rt") = "tm" Then
                Returnurl = "https://results.mxgp.com/team/seasoninfo.aspx"
            Else
                Returnurl = "https://results.mxgp.com/rider/default.aspx"
            End If
        End If
        Response.Redirect(Returnurl, True)
        'Response.Redirect("../default.aspx", True)
    End Sub

    Protected Sub ddTeam_DataBound(sender As Object, e As System.EventArgs) Handles ddTeam.DataBound
        Dim l = New ListItem("Private Team", "8", True)
        '    l.Selected = true;

        ddTeam.Items.Add(l)

        If teamid > 0 Then
            Dim testval As New ListItem
            testval = ddTeam.Items.FindByValue(teamid)
            '                            If IsNothing(testval) Then
            If IsNothing(ddTeam.Items.FindByValue(teamid)) Then

                '                            If ddTeam.Items.Contains(testval) Then
                ddTeam.SelectedValue = "8"

            Else
                ddTeam.SelectedValue = teamid
                '             ddTeam.SelectedValue = 8
            End If
        End If



    End Sub
End Class
