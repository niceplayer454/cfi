<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicRecord.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicRecord" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscAc" runat="server" CssPath="VP/autocomplete.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscDp" runat="server" CssPath="DatePicker/datepicker.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<style type="text/css">


.dataListArea {width:1206px}

.dataListArea .time {width:120px;text-align:left;}
.dataListArea .title {width:300px;text-align:left;}
.dataListArea .owner {width:100px;text-align:left;}
.dataListArea .comment {width:250px;text-align:left;}
.dataListArea .listOp {width:150px;text-align:left;padding-right:4px;}

.dataListArea .alternatingRow {background-color:#fff;}

.completed {background:green; color:#000;}
.running {background-color:Orange; color:#000;}


</style>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" CombineScripts="false" ID="ScriptManager1" >
    <Scripts>
        <asp:ScriptReference Path="~/js/jquery-1.4.2.js" />
        <asp:ScriptReference Path="~/js/jquery.autocomplete.js" />
    </Scripts>
</ajaxToolkit:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div class="dataListArea">
    <tbwc:GridViewEx ID="GvList" runat="server" SkinID="List"
        DataKeyNames="ID" AllowPaging="true" onrowdatabound="GvList_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StartTime">
            <itemtemplate><%# Eval("Start")%></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Idea Title">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Author">
            <itemtemplate><%# Eval("Owner")%></itemtemplate>
            <itemstyle cssclass="owner" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comment">
            <itemtemplate><asp:TextBox ID="TextBox1" runat="server" Width="20em"></asp:TextBox></itemtemplate>
            <itemstyle cssclass="comment" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Operation">
            <itemtemplate><asp:Button ID="Button1" runat="server" Text="Start" /><asp:Button ID="Button2" runat="server" Text="Stop" /></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>

    </ContentTemplate>
</asp:UpdatePanel>