<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="general.aspx.cs" Inherits="Online_Admission_Test.general" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style15
        {
            width: 211px;
            height: 23px;
        }
        .style16
        {
            width: 402px;
            height: 23px;
        }
        .style1
        {
            width: 211px;
        }
        .style14
        {
            width: 402px;
        }
        .style18
        {
            width: 959px;
            height: 93px;
        }
    </style>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="form-signin">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" style="text-align: right">
            <img alt="JU" class="style18" src="img/ju.JPG" />
            <br />
            <asp:Button ID="signOutB" runat="server" 
    Text="Sign Out" onclick="signOutB_Click" />
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="style15">
                        Mobile No:<asp:Label ID="mobileNoPanel2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="style16">
                        Transaction ID:
                        <asp:Label ID="tx_idpanel2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Please input HSC Board</td>
                    <td class="style14">
                        <asp:DropDownList ID="boardDDL" runat="server">
                            <asp:ListItem>DHAKA</asp:ListItem>
                            <asp:ListItem>RAJSHAHI</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Please input HSC Roll</td>
                    <td class="style14">
                        <asp:TextBox ID="rollTB" runat="server" Width="241px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="rollTB" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Please input HSC passing year</td>
                    <td class="style14">
                        <asp:DropDownList ID="passYearDDL" runat="server">
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2012</asp:ListItem>
                            <asp:ListItem>2011</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style14">
                        <asp:Button ID="submitB" runat="server" Text="Submit" onclick="submitB_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style14">
                        <asp:Label ID="wrongLabel" runat="server" ForeColor="#FF0066" Text="Label" 
                            Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
        <br />
        <asp:Panel ID="Panel7" runat="server">
            <asp:Panel ID="Panel6" runat="server">
                <div class="text-center">
                    Serviced By: <a href="www.juniv.edu/iit/">Institute of Information Technology, 
                    Jahangirnagar University,</a><br />
                </div>
            </asp:Panel>
            <table class="table table-condensed">
                <tr class="success">
                    <td class="style7" colspan="3">
                        <strong>ADVERTISEMENTS:</strong></td>
                </tr>
                <tr>
                    <td>
                        <asp:AdRotator ID="AdRotator1" runat="server" 
                        DataSourceID="XmlDataSource1" />
                        <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                        DataFile="~/Advertisement/Advertisement.xml"></asp:XmlDataSource>
                    </td>
                    <td>
                        <asp:AdRotator ID="AdRotator2" runat="server" 
                        DataSourceID="XmlDataSource1" />
                    </td>
                    <td>
                        <asp:AdRotator ID="AdRotator3" runat="server" 
                        DataSourceID="XmlDataSource1" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
    
    </div>
    </form>
</body>
</html>
