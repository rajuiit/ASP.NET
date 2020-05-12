<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seatplan.aspx.cs" Inherits="Online_Admission_Test.seatplan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 959px;
            height: 93px;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 271px;
        }
        .style4
        {
            width: 293px;
        }
        .style5
        {
            width: 414px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
        
            <caption>
                &nbsp;<br />
                <br />
                &nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <table class="table table-bordered">
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            <table class="style2">
                                <tr>
                                    <td class="style5">
                                        <img alt="" class="style1" src="img/ju.JPG" />
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <br />
                            <asp:Label ID="Label1" runat="server" ForeColor="#0066FF" Text="See Seat Plan"></asp:Label>
                            :<br />
                            <br />
                            UNIT<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>C</asp:ListItem>
                                <asp:ListItem>D</asp:ListItem>
                                <asp:ListItem>E</asp:ListItem>
                                <asp:ListItem>F</asp:ListItem>
                                <asp:ListItem>G</asp:ListItem>
                                <asp:ListItem>H</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <asp:GridView ID="GridView3" runat="server">
                            </asp:GridView>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:admissionConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:admissionConnectionString.ProviderName %>" 
                                SelectCommand="SELECT serialNo, mobile_no, tx_id, number_found, merit_position FROM applya">
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                Text="Save as PDF..." />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="Set Room No:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            <asp:Panel ID="Panel2" runat="server">
                                Set Room No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="roomNoDDL" runat="server" DataSourceID="SqlDataSource2" 
                                    DataTextField="room_no" DataValueField="room_no">
                                </asp:DropDownList>
                                <br />
                                <br />
                                seat Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="seatTB" runat="server"></asp:TextBox>
                                <br />
                                Intial Roll No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="intialRollNo" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="updateB" runat="server" onclick="updateB_Click" Text="update" 
                                    Width="133px" />
                            </asp:Panel>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <asp:Label ID="Label3" runat="server" ForeColor="#0033CC" 
                                Text="See Details Room Information:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                DataSourceID="SqlDataSource2">
                                <Columns>
                                    <asp:BoundField DataField="room_no" HeaderText="room_no" 
                                        SortExpression="room_no" />
                                    <asp:BoundField DataField="seat" HeaderText="seat" SortExpression="seat" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="success">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:admissionConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:admissionConnectionString.ProviderName %>" 
                                SelectCommand="SELECT * FROM roominfo"></asp:SqlDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                &nbsp;<br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </caption>
            
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
