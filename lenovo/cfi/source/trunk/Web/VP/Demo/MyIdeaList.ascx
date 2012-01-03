<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyIdeaList.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.MyIdeaList" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscAc" runat="server" CssPath="VP/autocomplete.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<style type="text/css">

#relatedoperation {width:1206px;line-height:20px;height:26px;text-align:left;padding:0px 16px 5px 16px;}
#relatedoperation .op {margin:0px 10px 0px 0px;}

.dataListArea {width:1206px}

.dataListArea .title {width:400px;text-align:left;}
.dataListArea .time {width:120px;text-align:left;}
.dataListArea .type {width:100px;text-align:left;}
.dataListArea .status {width:150px;text-align:left;}
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
    <div style="float:right" class="operation"><asp:Button ID="BtnAdd" runat="server" SkinID="EditPrimary" Text="New Idea(改成Link)" ToolTip="New Idea" 
        OnClientClick="window.open('Default.aspx?vp=myideanew');" /></div>
    <span class="op">Topic:<asp:DropDownList ID="DdlType" runat="server" Width="16em">
        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
        <asp:ListItem Text="Topic 1" Value=""></asp:ListItem>
        <asp:ListItem Text="Topic 2" Value=""></asp:ListItem>
    </asp:DropDownList></span>
    <span class="op">Type:<asp:DropDownList ID="DropDownList1" runat="server" Width="16em">
        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
    </asp:DropDownList></span>
    <span class="op">Suggestion:<asp:DropDownList ID="DropDownList2" runat="server" Width="16em">
        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
        <asp:ListItem Text="C Project" Value="1"></asp:ListItem>
    </asp:DropDownList>
    <span class="op">E-Status:<asp:DropDownList ID="DropDownList3" runat="server" Width="16em">
        <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
        <asp:ListItem Text="Null" Value="1"></asp:ListItem>
        <asp:ListItem Text="Doing" Value="1"></asp:ListItem>
        <asp:ListItem Text="Canceled" Value="1"></asp:ListItem>
        <asp:ListItem Text="Done" Value="1"></asp:ListItem>
    </asp:DropDownList></span>
    
    
    </div>
<div class="dataListArea">
    <tbwc:GridViewEx ID="GvList" runat="server" SkinID="List"
        DataKeyNames="ID" AllowPaging="true">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Topic">
            <itemtemplate>xxx</itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Idea Name">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
            <itemtemplate><%# Eval("Time")%></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type">
            <itemtemplate><%# Eval("Type")%></itemtemplate>
            <itemstyle cssclass="type" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="P-Status">
            <itemtemplate><%# Eval("Status")%></itemtemplate>
            <itemstyle cssclass="status" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Suggestion">
            <itemtemplate>*</itemtemplate>
            <itemstyle cssclass="status" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="E-Status">
            <itemtemplate>*</itemtemplate>
            <itemstyle cssclass="status" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Operation">
            <itemtemplate><asp:ImageButton 
            ID="BtnEdit" runat="server" CausesValidation="False" CommandName="OpenEdit"
                SkinID="ListEdit" CommandArgument='<%# Eval("ID")%>' /><tbwc:ConfirmImageButton 
            ID="BtnDel" runat="server" CausesValidation="False" CommandName="Remove" ConfirmText="Delete?"
                SkinID="ListDelete" CommandArgument='<%# Eval("ID")%>' /></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>
    </ContentTemplate>
</asp:UpdatePanel>