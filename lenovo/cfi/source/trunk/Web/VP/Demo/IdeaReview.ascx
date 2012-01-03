<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IdeaReview.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.IdeaReview" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscDp" runat="server" CssPath="DatePicker/datepicker.css"></tbwc:StyleSheetControl>

<style type="text/css">

#relatedoperation {width:1206px;line-height:20px;height:26px;text-align:left;padding:0px 16px 5px 16px;}
#relatedoperation .op {padding:0px 0px 0px 10px;}

.dataListArea {width:1206px}

.dataListArea .time {width:120px;text-align:left;}
.dataListArea .title {width:200px;text-align:left;}
.dataListArea .type {width:100px;text-align:left;}
.dataListArea .owner {width:100px;text-align:left;}
.dataListArea .value {width:40px;text-align:left;}
.dataListArea .class {width:150px;text-align:left;}
.dataListArea .comment {width:150px;text-align:left;}
.dataListArea .suggestion {width:150px;text-align:left;}
.dataListArea .ip {width:40px;text-align:left;}

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
        DataKeyNames="ID" AllowPaging="true"
        onrowdatabound="GvList_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Time">
            <itemtemplate><%# Eval("Start")%></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type">
            <itemtemplate><%# Eval("Type")%></itemtemplate>
            <itemstyle cssclass="type" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Author">
            <itemtemplate><%# Eval("Owner")%></itemtemplate>
            <itemstyle cssclass="owner" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CV">
            <itemtemplate><asp:TextBox ID="TextBox1" runat="server" Width="2em"></asp:TextBox></itemtemplate>
            <itemstyle cssclass="value" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BV">
            <itemtemplate><asp:TextBox ID="TextBox2" runat="server" Width="2em"></asp:TextBox></itemtemplate>
            <itemstyle cssclass="value" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TV">
            <itemtemplate><asp:TextBox ID="TextBox3" runat="server" Width="2em"></asp:TextBox></itemtemplate>
            <itemstyle cssclass="value" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Class">
            <itemtemplate><asp:DropDownList ID="DropDownList1" runat="server" Width="6em"></asp:DropDownList>
            </itemtemplate>
            <itemstyle cssclass="class" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comment">
            <itemtemplate><asp:TextBox ID="TextBox4" runat="server" Width="10em"></asp:TextBox></itemtemplate>
            <itemstyle cssclass="comment" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Suggestion">
            <itemtemplate><asp:TextBox ID="TextBox5" runat="server" Width="10em"></asp:TextBox></itemtemplate>
            <itemstyle cssclass="suggestion" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IP">
            <itemtemplate><asp:CheckBox ID="CheckBox1" runat="server" /></itemtemplate>
            <itemstyle cssclass="ip" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IP Comment">
            <itemtemplate><asp:TextBox ID="TextBox6" runat="server" Width="10em"></asp:TextBox></itemtemplate>
            <itemstyle cssclass="comment" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>

    </ContentTemplate>
</asp:UpdatePanel>


<div style="clear:both;margin:16px;font-size:16px;">评审标准：</div>