<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Online_Admission_Test.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style5
        {
            width: 386px;
            text-align: right;
        }
        .style6
        {
            width: 1007px;
        }
        .style9
        {
            width: 323px;
        }
        .style12
        {
            width: 33%;
            height: 32px;
        }
        .style13
        {
            width: 34%;
            height: 32px;
        }
        .style14
        {
        }
        .style20
        {
            width: 283px;
        }
        .style21
        {
        }
        .style22
        {
            width: 231px;
        }
        .style23
        {
            width: 281px;
        }
        .style24
        {
            width: 243px;
        }
        .style25
        {
            width: 133px;
            height: 25px;
        }
        .style26
        {
            width: 243px;
            height: 25px;
        }
        .style27
        {
            width: 281px;
            height: 25px;
        }
        .style28
        {
            width: 959px;
            height: 93px;
        }
        .style29
        {
            text-decoration: underline;
        }
    </style>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body >
<div id = "wrap">
<div id ="wrap2">
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" style="text-align: right">
            <img alt="Jahangirnagar University" class="style28" 
    src="img/ju.JPG" />
            <asp:Label ID="wrongLabel" runat="server"></asp:Label>
            <asp:Button ID="signOutB" runat="server" Text="Sign Out" 
                onclick="signOutB_Click" />
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel7" runat="server">
            <table style="width:100%;" class="table table-bordered">
                <tr class="success">
                    <td colspan="3">
                        <strong>Profile Information:</strong></td>
                    <td class="success">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        Mobile No:</td>
                    <td>
                        <asp:Label ID="mobileNoPanel7" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        HSC Board:</td>
                    <td>
                        <asp:Label ID="hscboardLPanel7" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        Transaction ID:</td>
                    <td>
                        <asp:Label ID="tx_idPanel7" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        HSC Roll</td>
                    <td>
                        <asp:Label ID="hscrollLpanel7" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        HSC Pass Year</td>
                    <td>
                        <asp:Label ID="hscpassyearLpane7" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="Panel3" runat="server">
            <table style="width:100%;" class="table table-bordered">
                <tr class="success">
                    <td colspan="3">
                        <strong>Basic Information:</strong></td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Name</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="nameL" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="style5" rowspan="7" style="width: 33%">
                        <asp:Image ID="imgI" runat="server" Height="219px" style="margin-left: 20px" 
                            Width="205px" CssClass="img-polaroid" />
                    </td>
                </tr>
                <tr>
                    <td class="style12">
                        Father Name</td>
                    <td class="style13">
                        <asp:Label ID="f_nameL" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Mother Name</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="m_nameL" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Registration No</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="registrationL" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Session </td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="sessionL" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Roll No</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="rollL" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Board</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="boardL" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Passing Year</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="passYearL" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="style5" style="width: 33%">
                        <asp:FileUpload ID="imgFU" runat="server" style="text-align: right" />
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Mobile No:</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="mobileNoL" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="style5" style="width: 33%">
                        <asp:Button ID="uploadButton" runat="server" onclick="uploadButton_Click" 
                            Text="Upload" />
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 33%">
                        Total GPA</td>
                    <td class="style9" style="width: 34%">
                        <asp:Label ID="totalGPAL" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="style5" style="width: 33%">
                        <asp:Label ID="StatusLabel" runat="server" Text="No Image Selected!"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel5" runat="server">
            <asp:GridView ID="GridView1" runat="server" Caption="Transaction Information" 
                CaptionAlign="Top" CssClass="table-bordered">
            </asp:GridView>
            <br />
            <br />
            <asp:Panel ID="Panel6" runat="server">
                <table class="table table-bordered" style="width:100%;">
                    <tr class="success">
                        <td class="style29" colspan="4">
                            <strong>Applying Information:</strong></td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style24">
                            &nbsp;</td>
                        <td class="style23">
                            Taka:
                            <asp:Label ID="takaLabel" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr class="success">
                        <td class="style21">
                            Unit</td>
                        <td class="style24">
                            Qualification</td>
                        <td>
                            Are you want to apply</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style25">
                            A Unit</td>
                        <td class="style26">
                            Total GPA
                            <asp:Label ID="AunitMR" runat="server" Text="8.50"></asp:Label>
                        </td>
                        <td class="style27">
                            <asp:CheckBox ID="AunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="AunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                        <td rowspan="9">
                            <asp:Label ID="appliedSubjectL" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            B Unit</td>
                        <td class="style24">
                            Total GPA
                            <asp:Label ID="BunitMR" runat="server" Text="7.50"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:CheckBox ID="BunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="BunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            C Unit</td>
                        <td class="style24">
                            Total GPA
                            <asp:Label ID="CunitMR" runat="server" Text="7.50"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:CheckBox ID="CunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="CunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            D Unit</td>
                        <td class="style24">
                            Total GPA
                            <asp:Label ID="DunitMR" runat="server" Text="8.50"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:CheckBox ID="DunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="DunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            E Unit</td>
                        <td class="style24">
                            Total GPA
                            <asp:Label ID="EunitMR" runat="server" Text="8.50"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:CheckBox ID="EunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="EunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            F Unit</td>
                        <td class="style24">
                            Total GPA
                            <asp:Label ID="FunitMR" runat="server" Text="8.50"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:CheckBox ID="FunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="FunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            G Unit</td>
                        <td class="style24">
                            Total GPA
                            <asp:Label ID="GunitMR" runat="server" Text="8.50"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:CheckBox ID="GunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="GunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            H Unit</td>
                        <td class="style24">
                            Total GPA
                            <asp:Label ID="HunitMR" runat="server" Text="8.50"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:CheckBox ID="HunitChB" runat="server" AutoPostBack="True" 
                                oncheckedchanged="HunitChB_CheckedChanged" Text="click here for apply" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style24">
                            &nbsp;</td>
                        <td class="style23">
                            <asp:Button ID="submitApplyB" runat="server" onclick="submitApplyB_Click" 
                                Text="Submit" />
                            <asp:Label ID="submitLabel" runat="server" Text="SubmitLabel"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </asp:Panel>
            <br />
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel8" runat="server">
            <table style="width:100%;" class="table table-bordered">
                <tr class="success">
                    <td class="style29" colspan="5">
                        <strong>Download Admit Card:</strong></td>
                </tr>
                <tr>
                    <td class="style21">
                        Unit</td>
                    <td class="style20">
                        Serial No</td>
                    <td class="style22">
                        Download Admit Card</td>
                    <td class="style22">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style21">
                        A Unit</td>
                    <td class="style20">
                        Serial No:
                        <asp:Label ID="Aunitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22" >
                        <asp:Button ID="admitcardBA" runat="server" onclick="admitcardBA_Click" 
                            Text="Download Admit Card" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="AunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                    <td rowspan="9">
                        <asp:Label ID="infoL" runat="server" Font-Size="XX-Large" ForeColor="Red" 
                            Text="info Label" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        B Unit</td>
                    <td class="style20">
                        Serial No:<asp:Label ID="Bunitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Button ID="admitcardBB" runat="server" Text="Download Admit Card" 
                            onclick="admitcardBB_Click" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="BunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        C Unit</td>
                    <td class="style20">
                        Serial No:<asp:Label ID="Cunitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Button ID="admitcardBC" runat="server" Text="Download Admit Card" 
                            onclick="admitcardBC_Click" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="CunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        D Unit</td>
                    <td class="style20">
                        Serial No:<asp:Label ID="Dunitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Button ID="admitcardBD" runat="server" Text="Download Admit Card" 
                            onclick="admitcardBD_Click" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="DunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        E Unit</td>
                    <td class="style20">
                        Serial No:<asp:Label ID="Eunitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Button ID="admitcardBE" runat="server" Text="Download Admit Card" 
                            onclick="admitcardBE_Click" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="EunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        F Unit</td>
                    <td class="style20">
                        Serial No:
                        <asp:Label ID="Funitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Button ID="admitcardBF" runat="server" Text="Download Admit Card" 
                            onclick="admitcardBF_Click" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="FunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        G Unit</td>
                    <td class="style20">
                        Serial No:
                        <asp:Label ID="Gunitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Button ID="admitcardBG" runat="server" Text="Download Admit Card" 
                            onclick="admitcardBG_Click" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="GunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        H Unit</td>
                    <td class="style20">
                        Serial No:<asp:Label ID="Hunitserial" runat="server" Text="None"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:Button ID="admitcardBH" runat="server" Text="Download Admit Card" 
                            onclick="admitcardBH_Click" />
                    </td>
                    <td class="style22">
                        Exam&nbsp; Room:
                        <asp:Label ID="HunitExamRoom" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style20">
                        &nbsp;</td>
                    <td class="style22">
                        &nbsp;</td>
                    <td class="style22">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel9" runat="server">
            <asp:Panel ID="Panel10" runat="server">
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
        <br />
        <br />
        <br />
        <br />
    
    </div>

    </form>
    </div>
    </div>
</body>
</html>
