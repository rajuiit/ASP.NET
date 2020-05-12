<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="attendancesheet.aspx.cs" Inherits="Online_Admission_Test.attendancesheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
    
        <asp:Panel ID="Panel1" runat="server">
            Unit:
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
                <asp:ListItem>D</asp:ListItem>
                <asp:ListItem>E</asp:ListItem>
                <asp:ListItem>F</asp:ListItem>
                <asp:ListItem>G</asp:ListItem>
                <asp:ListItem>H</asp:ListItem>
            </asp:DropDownList>
            &nbsp; room no
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                DataSourceID="SqlDataSource1" DataTextField="room_no" DataValueField="room_no" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:admissionConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:admissionConnectionString.ProviderName %>" 
                SelectCommand="SELECT room_no FROM roominfo"></asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Show Attendance sheet" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="attendanceButton" runat="server" 
                onclick="attendanceButton_Click" Text="Create Attendance Sheet" />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
