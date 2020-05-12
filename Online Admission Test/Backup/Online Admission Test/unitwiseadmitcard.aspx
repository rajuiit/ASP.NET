<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unitwiseadmitcard.aspx.cs" Inherits="Online_Admission_Test.unitwiseadmitcard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            Unit:
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
                <asp:ListItem>D</asp:ListItem>
                <asp:ListItem>E</asp:ListItem>
                <asp:ListItem>F</asp:ListItem>
                <asp:ListItem>G</asp:ListItem>
                <asp:ListItem>H</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Save as PDF ..." />
            <br />
            <br />
            <br />
            <br />
            Roll:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            unit
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
                <asp:ListItem>D</asp:ListItem>
                <asp:ListItem>E</asp:ListItem>
                <asp:ListItem>F</asp:ListItem>
                <asp:ListItem>G</asp:ListItem>
                <asp:ListItem>H</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                Text="save single pdf" />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
