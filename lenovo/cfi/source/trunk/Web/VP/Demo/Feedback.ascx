<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Feedback.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.Feedback" %>
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
    <asp:DropDownList ID="DdlType" runat="server" Width="16em">
        <asp:ListItem Text="Topic 1" Value=""></asp:ListItem>
        <asp:ListItem Text="Topic 2" Value=""></asp:ListItem>
    </asp:DropDownList></div>
<div class="dataListArea">
    <tbwc:GridViewEx ID="GvList" runat="server" SkinID="List"
        DataKeyNames="ID" AllowPaging="true" onrowcommand="GvList_RowCommand">
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
        <asp:TemplateField HeaderText="Author">
            <itemtemplate>xxxx</itemtemplate>
            <itemstyle cssclass="type" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Feedback">
            <itemtemplate><asp:ImageButton 
            ID="BtnEdit" runat="server" CausesValidation="False" CommandName="OpenEdit"
                SkinID="ListEdit" CommandArgument='<%# Eval("ID")%>' /></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>


<asp:Button ID="BtnHiddenEdit" runat="Server" Style="display:none" />
<ajaxToolKit:ModalPopupExtender ID="MpeAdd" runat="server" TargetControlID="BtnHiddenEdit" 
    PopupControlID="PnlAdd" CancelControlID="BtnCancelAdd" 
    BackgroundCssClass="modalBackground" PopupDragHandleControlID="PnlAddCaption" Drag="false">
</ajaxToolKit:ModalPopupExtender>
<asp:Panel ID="PnlAdd" runat="server" CssClass="modalBox detail" Style="display: none;" Width="480px">
    <asp:Panel ID="PnlAddCaption" runat="server" CssClass="caption" Style="margin-bottom: 10px; cursor: hand;">
		Feedback</asp:Panel>
    <div><asp:Label ID="LblTitleAdd" runat="server" AssociatedControlID="TxtTitleAdd" Text="Project Name" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTitleAdd" runat="server" Width="30em"></asp:TextBox></div>
    <div><asp:Label ID="Label1" runat="server" AssociatedControlID="TxtTitleAdd" Text="KickOff Time" CssClass="title"></asp:Label><asp:TextBox 
            ID="TextBox1" runat="server" Width="30em"></asp:TextBox></div>
    <div style="padding-left:10em">for c, group c </div>
    <div><asp:Label ID="Label2" runat="server" AssociatedControlID="TxtTitleAdd" Text="Product Name" CssClass="title"></asp:Label><asp:TextBox 
            ID="TextBox2" runat="server" Width="30em"></asp:TextBox></div>
    <div><asp:Label ID="Label3" runat="server" AssociatedControlID="TxtTitleAdd" Text="Import Time" CssClass="title"></asp:Label><asp:TextBox 
            ID="TextBox3" runat="server" Width="30em"></asp:TextBox></div>
    <div style="padding-left:10em">for Product, JUST  DO  IT </div>
    <div><asp:Label ID="Label4" runat="server" AssociatedControlID="TxtTitleAdd" Text="IP No" CssClass="title"></asp:Label><asp:TextBox 
            ID="TextBox4" runat="server" Width="30em"></asp:TextBox></div>
    <div style="padding-left:10em">for IP </div>
    <div><asp:Label ID="Label5" runat="server" AssociatedControlID="TxtTitleAdd" Text="Suggestion" CssClass="title"></asp:Label><asp:TextBox 
            ID="TextBox5" runat="server" Width="30em"></asp:TextBox></div>
    <div style="padding-left:10em">for Other BU</div>

    <div style="white-space: nowrap; text-align: center; margin-top:2em;">
		<asp:Button ID="BtnSaveAdd" runat="server" Text="Save" CausesValidation="true" ValidationGroup="Add"/>
		<asp:Button ID="BtnCancelAdd" runat="server" CausesValidation="false" Text="Cancel"/>
	</div>
</asp:Panel>


    </ContentTemplate>
</asp:UpdatePanel>