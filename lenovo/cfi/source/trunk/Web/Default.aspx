<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lenovo.CFI.Web.Default" EnableEventValidation="false" %>
<%@ Register Src="UserControls/Footer.ascx" TagName="Footer" TagPrefix="ucHF" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <tbwc:StyleSheetControl ID="SscCommon" runat="server" CssPath="common.css"></tbwc:StyleSheetControl>
    <div id="header">
        <div id="systitle">GDDL Call for Idea Management System</div>
    </div>
    <div id="menu"><tbwc:NavMenu ID="NavMenu" runat="server" CssClass="" /></div>
    <div id="tab" runat="server"><tbwc:NavTab ID="NavTab" runat="server" /></div>
    <div id="ws"><asp:PlaceHolder ID="PhVP" runat="server"></asp:PlaceHolder></div>
    <ucHF:Footer id="Footer1" runat="server"></ucHF:Footer>
    <tbwc:PopupWin ID="PWMessage" runat="server" ShowDelay="500" Offsety="50" Autoshow="False" DisplayDuration="20000" Visible="false" ShowLink="true" />
    </form>
</body>
</html>