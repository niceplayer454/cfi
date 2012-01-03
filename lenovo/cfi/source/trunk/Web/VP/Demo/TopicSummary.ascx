<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicSummary.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicSummary" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>

<style type="text/css">

#relatedoperation {width:1206px;line-height:20px;height:26px;text-align:left;padding:0px 16px 5px 16px;}
#relatedoperation .op {padding:0px 0px 0px 10px;}

.dataListArea {width:1206px}

.dataListArea .reviewer {width:120px;text-align:left;}
.dataListArea .submitted {width:120px;text-align:left;}
.dataListArea .notice {width:600px;text-align:left;}


.dataListArea .time {width:60px;text-align:left;}
.dataListArea .title {width:200px;text-align:left;}
.dataListArea .owner {width:80px;text-align:left;}
.dataListArea .value {width:36px;text-align:left;}
.dataListArea .summary {width:150px;text-align:left;}
.dataListArea .listOp {width:32px;text-align:left;}


.dataListArea .class {width:120px;text-align:left;}
.dataListArea .comment {width:200px;text-align:left;}
.dataListArea .suggestion {width:200px;text-align:left;}
.dataListArea .ip {width:50px;text-align:center;}


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
        DataKeyNames="ID" AllowPaging="true">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reviewer">
            <itemtemplate><%# Eval("Reviewer")%></itemtemplate>
            <itemstyle cssclass="reviewer" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submited">
            <itemtemplate><%# Eval("Submitted")%></itemtemplate>
            <itemstyle cssclass="submitted" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Notice">
            <itemtemplate><asp:LinkButton ID="BtnAction1" runat="server" Text="notice"></asp:LinkButton></itemtemplate>
            <itemstyle cssclass="notice" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>

    </ContentTemplate>
</asp:UpdatePanel>


<div class="operation" style="padding:8px 0px 8px 0em;text-align:center;">
    <asp:Button ID="BtnSave" runat="server" CssClass="primary" 
        Text="Start Summary" onclick="BtnSave_Click"/></div>


<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td valign="top">
<div class="dataListArea" style="width:350px;margin-right:8px;padding-right:0px;">
    <tbwc:GridViewEx ID="GvIdeas" runat="server" SkinID="List"
        AllowPaging="false" onrowcommand="GvIdeas_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CV">
            <itemtemplate>9.50</itemtemplate>
            <itemstyle cssclass="value" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BV">
            <itemtemplate>9.10</itemtemplate>
            <itemstyle cssclass="value" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TV">
            <itemtemplate>9.35</itemtemplate>
            <itemstyle cssclass="value" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText=" ">
            <itemtemplate><asp:ImageButton 
            ID="BtnEdit" runat="server" CausesValidation="False" CommandName="OpenEdit"
                SkinID="ListDetail" CommandArgument='<%# Eval("ID")%>' /></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>
        </td>
        <td valign="top">

    <div>&nbsp;&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xxx</div>
    <div>&nbsp;&nbsp;Type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Width="10em"></asp:DropDownList></div>
    <div>&nbsp;&nbsp;Summary:<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="3" Width="40em"></asp:TextBox></div>

 <div class="dataListArea" style="width:850px;margin-left:8px;padding-left:0px;">
    <tbwc:GridViewEx ID="GvReview" runat="server" SkinID="List"
        AllowPaging="false">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Class">
            <itemtemplate>HMI</itemtemplate>
            <itemstyle cssclass="class" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comment">
            <itemtemplate>xxx</itemtemplate>
            <itemstyle cssclass="comment" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Suggestion">
            <itemtemplate>xxx</itemtemplate>
            <itemstyle cssclass="suggestion" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IP">
            <itemtemplate>Y</itemtemplate>
            <itemstyle cssclass="ip" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IP Comment">
            <itemtemplate>xxx</itemtemplate>
            <itemstyle cssclass="comment" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>


    <div class="operation" style="padding:8px 0px 8px 4em;">
        <asp:Button ID="Button1" runat="server" CssClass="primary" 
            Text="Save"/></div>
        </td>
    </tr>
</table>
    </ContentTemplate>
</asp:UpdatePanel>
