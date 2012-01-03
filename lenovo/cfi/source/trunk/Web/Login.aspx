<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lenovo.CFI.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header"></div>
    <tbwc:StyleSheetControl ID="SscCommon" runat="server" CssPath="login.css"></tbwc:StyleSheetControl>
    <div id="ws">
        <table cellspacing="0" cellpadding="0">
        <tr>
            <td class="left" valign="top">
                <div id="login">
                    <h2>Login</h2>
                    <div class="username"><asp:Label ID="LblUserName" 
                        runat="server" Text="ItCode" AssociatedControlID="TxtUserName"></asp:Label><asp:TextBox ID="TxtUserName" 
                        runat="server" Width="120px"></asp:TextBox></div>
                    <div class="password"><asp:Label ID="LblPassword" 
                        runat="server" Text="Password" AssociatedControlID="TxtPassword"></asp:Label><asp:TextBox ID="TxtPassword" 
                        runat="server" Width="120px" TextMode="Password"></asp:TextBox></div>
                    <div class="operation"><asp:LinkButton ID="BtnLogin" runat="server" 
                            onclick="BtnLogin_Click">Login</asp:LinkButton> | <a href="Forgot.aspx" target="_blank">Forgot</a><asp:LinkButton ID="BtnReset" runat="server" Visible="false"
                            onclick="BtnReset_Click">Reset</asp:LinkButton> | <a href="Help.htm" target="_blank">Help</a>
                    </div>
                    <div class="error"><asp:Literal ID="LtrMsg" runat="server"></asp:Literal></div>
                </div>
                <div id="link">
                <h2>Related Links</h2>
                <ul>
                    <li><a href="#" target="_blank">xxxx</a></li>
                    <li><a href="#" target="_blank">xxxx</a></li>
                </ul>
                </div>
            </td>
            <td class="right" valign="top">
                <h1 id="title">XXXX XXXX XXXX XXXX XXXX</h1>
                <div id="intro">xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx xxxx </div>
                <div id="update">
                    <h2>Update News</h2>
                    <ul>
                        <li>2011-12-26 <a href="#">System Demo!</a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    </div>
    <div id="footer">Terms of use | Privacy | Technical Support</div>
    </form>
</body>
</html>