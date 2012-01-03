<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Open.aspx.cs" Inherits="Lenovo.CFI.Web.Open" %>
<%@ Register Src="UserControls/Header.ascx" TagName="Header" TagPrefix="ucHF" %>
<%@ Register Src="UserControls/Footer.ascx" TagName="Footer" TagPrefix="ucHF" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Pragma" content="no-cache" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <ucHF:Header id="Header1" runat="server"></ucHF:Header>
    <tbwc:StyleSheetControl ID="SscCommon" runat="server" CssPath="open.css"></tbwc:StyleSheetControl>
    <div id="ws"><asp:PlaceHolder ID="PhVP" runat="server"></asp:PlaceHolder></div>
    <ucHF:Footer id="Footer1" runat="server" Visible="false"></ucHF:Footer>
    <tbwc:PopupWin ID="PWMessage" runat="server" ShowDelay="500" Offsety="50" Autoshow="False" DisplayDuration="20000" Visible="false" ShowLink="true" />
    </form>
</body>
</html>
