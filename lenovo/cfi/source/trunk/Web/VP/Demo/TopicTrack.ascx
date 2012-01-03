<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicTrack.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicTrack" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscDp" runat="server" CssPath="DatePicker/datepicker.css"></tbwc:StyleSheetControl>

<style type="text/css">

#relatedoperation {width:1206px;line-height:20px;height:26px;text-align:left;padding:0px 16px 5px 16px;}
#relatedoperation .op {padding:0px 0px 0px 10px;}

.dataListArea {width:1206px}

.dataListArea .title {width:400px;text-align:left;}
.dataListArea .owner {width:100px;text-align:left;}
.dataListArea .type {width:120px;text-align:left;}
.dataListArea .listOp {width:260px;text-align:left;padding-right:4px;}


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
        <asp:TemplateField HeaderText="Title">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Author">
            <itemtemplate><%# Eval("Owner")%></itemtemplate>
            <itemstyle cssclass="owner" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type">
            <itemtemplate><%# Eval("Type")%></itemtemplate>
            <itemstyle cssclass="type" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Award">
            <itemtemplate><asp:TextBox ID="TxtS1" runat="server" Width="10em"></asp:TextBox><asp:ImageButton 
            ID="BtnEdit1" runat="server" CausesValidation="False" CommandName="OpenEdit"
                SkinID="ListSave" CommandArgument='<%# Eval("ID")%>' /></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Track">
            <itemtemplate><asp:TextBox ID="TxtS2" runat="server" Width="10em"></asp:TextBox><asp:ImageButton 
            ID="BtnEdit2" runat="server" CausesValidation="False" CommandName="OpenEdit"
                SkinID="ListSave" CommandArgument='<%# Eval("ID")%>' /></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>

    </ContentTemplate>
</asp:UpdatePanel>