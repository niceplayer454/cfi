<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Lenovo.CFI.Web.Error" %>
<%@ Register Src="UserControls/Header.ascx" TagName="Header" TagPrefix="ucHF" %>
<%@ Register Src="UserControls/Footer.ascx" TagName="Footer" TagPrefix="ucHF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sorry, there is a unhandled exception!</title>
</head>
<body>
    <form id="form1" runat="server">
    <TBWC:StyleSheetControl ID="SscCommon" runat="server" EnableTheme="true" CssPath="common.css"></TBWC:StyleSheetControl>
    <ucHF:Header id="Header1" runat="server"></ucHF:Header>
    <div id="ws">
        <div style="padding:20px;text-align:center;font-size:20px">Our apologies…</div>
        <div style="padding:20px;text-align:center">There is a unhandled exception!Please, contact system administrator!</div>
        <div style="padding:20px;text-align:center;font-size:20px"">Technical detail</div>
        <div style="padding:20px;text-align:center"><asp:Literal ID="LtrDetail" runat="server"></asp:Literal></div>
    </div>
    <ucHF:Footer id="Footer1" runat="server"></ucHF:Footer>
    </form>
</body>
</html>
