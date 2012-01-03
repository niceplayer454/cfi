<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.Search" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscAc" runat="server" CssPath="VP/autocomplete.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<style type="text/css">

#relatedoperation {width:1206px;line-height:20px;height:26px;text-align:left;padding:0px 16px 5px 16px;}
#relatedoperation .op {padding:0px 0px 0px 10px;}

.dataListArea {width:1206px}

.dataListArea .title {width:400px;text-align:left;}
.dataListArea .time {width:120px;text-align:left;}
.dataListArea .type {width:100px;text-align:left;}
.dataListArea .action {width:150px;text-align:left;}
.dataListArea .listOp {width:150px;text-align:right;padding-right:4px;}

</style>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" CombineScripts="false" ID="ScriptManager1" >
    <Scripts>
        <asp:ScriptReference Path="~/js/jquery-1.4.2.js" />
        <asp:ScriptReference Path="~/js/jquery.autocomplete.js" />
    </Scripts>
</ajaxToolkit:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div id="relatedoperation">
    Topic:<asp:DropDownList ID="DdlTopic" runat="server" Width="16em">
        <asp:ListItem Text="Select..." Value=""></asp:ListItem>
        <asp:ListItem Text="Topic 1" Value=""></asp:ListItem>
        <asp:ListItem Text="Topic 2" Value=""></asp:ListItem></asp:DropDownList>
    Name:<asp:TextBox runat="server"></asp:TextBox>
    Owner:<asp:TextBox runat="server"></asp:TextBox>
    Type:<asp:DropDownList ID="DdlType" runat="server">
        <asp:ListItem Text="Select..." Value=""></asp:ListItem>
        <asp:ListItem Text="xxx" Value=""></asp:ListItem>
        <asp:ListItem Text="xxx" Value=""></asp:ListItem>
    </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Find" /><asp:Button ID="Button2" runat="server" Text="Export" /></div>
<div class="dataListArea">
    <tbwc:GridViewEx ID="GvList" runat="server" SkinID="List"
        DataKeyNames="ID" AllowPaging="true">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Name">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type">
            <itemtemplate><%# Eval("Type")%></itemtemplate>
            <itemstyle cssclass="type" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Next Action">
            <itemtemplate><%# Eval("Action")%></itemtemplate>
            <itemstyle cssclass="action" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Apply">
            <itemtemplate><asp:LinkButton ID="LinkButton1" runat="server">Apply</asp:LinkButton></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>

    </ContentTemplate>
</asp:UpdatePanel>