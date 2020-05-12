<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Online_Admission_Test.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 185px;
        }
        .style3
        {
            width: 244px;
        }
        .style4
        {
            width: 154px;
        }
        .style5
        {
            text-decoration: underline;
            font-size: x-large;
        }
        .style7
        {
            text-decoration: underline;
        }
    </style>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id = "wrap">
<div>
    <form id="form1" runat="server" class="form-signin">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            <asp:Panel ID="Panel4" runat="server">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/ju.JPG" />
            </asp:Panel>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Admin Panel</asp:LinkButton>
            <br />
            <asp:Panel ID="Panel5" runat="server" Height="58px">
                <div class="text-center">
                    <span class="style5"><strong>Transaction Process:</strong></span></div>
            </asp:Panel>
            <br />
            <br />
            <asp:Panel ID="Panel3" runat="server">
                <table style="width:100%;" align="center">
                    <tr>
                        <td class="style3">
                            By which system you paid the money</td>
                        <td>
                            <asp:DropDownList ID="systemDDL" runat="server" AutoPostBack="True" 
                                oninit="systemDDL_SelectedIndexChanged" 
                                onselectedindexchanged="systemDDL_SelectedIndexChanged">
                                <asp:ListItem>Teletalk</asp:ListItem>
                                <asp:ListItem>Dutch Bangla Mobile Banking</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:Panel ID="teletalkPanel" runat="server" Height="162px">
                <table style="width:100%;">
                    <tr>
                        <td class="style2">
                            User ID:</td>
                        <td>
                            <asp:TextBox ID="userIDTB" runat="server" placeholder="Username" Width="165px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="userIDTB" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Password</td>
                        <td>
                            <asp:TextBox ID="passwordTB" runat="server" placeholder="Password" Width="169px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="passwordTB" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="submitTeletalk" runat="server" 
                                CssClass="btn btn-primary active" onclick="submitTeletalk_Click" 
                                Text="Submit" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <asp:Panel ID="DBBLPanel" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td class="style4">
                            Mobile No:</td>
                        <td>
                            <asp:TextBox ID="mobileNoTB" runat="server" placeholder="Mobile Number" Width="192px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="mobileNoTB" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            Transanction ID:</td>
                        <td>
                            <asp:TextBox ID="txIDTB" runat="server" placeholder="Transaction ID" Width="190px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txIDTB" ErrorMessage="* Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td style="margin-left: 40px">
                            <asp:Button ID="submitDBBL" runat="server" Text="Submit" 
                                onclick="submitDBBL_Click" CssClass="btn btn-primary active" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td style="margin-left: 40px">
                            <asp:Label ID="wrongLabel" runat="server" 
                                Text="Your Mobile No. or Transaction ID or both information are wrong. Please Check Properly." 
                                ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel6" runat="server">
                <div class="text-center">
                    Serviced By: <a href="www.juniv.edu/iit/">Institute of Information Technology, 
                    Jahangirnagar University,</a><br /> </div>
            </asp:Panel>
            <br />
            <br />
            <asp:Panel ID="Panel7" runat="server">
                <table class="table table-condensed">
                    <tr class="success">
                        <td class="style7" colspan="3">
                            <strong>ADVERTISEMENTS:</strong></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:AdRotator ID="AdRotator1" runat="server" DataSourceID="XmlDataSource1" />
                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                                DataFile="~/Advertisement/Advertisement.xml"></asp:XmlDataSource>
                        </td>
                        <td>
                            <asp:AdRotator ID="AdRotator2" runat="server" DataSourceID="XmlDataSource1" />
                        </td>
                        <td>
                            <asp:AdRotator ID="AdRotator3" runat="server" DataSourceID="XmlDataSource1" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    
    </div>
    </form>
    </div>
    </div>
</body>
</html>
