<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DcList.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.DcList" %>
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
    <asp:DropDownList ID="DdlType" runat="server" Width="50em">
        <asp:ListItem Text="Topic 1" Value=""></asp:ListItem>
        <asp:ListItem Text="Topic 2" Value=""></asp:ListItem>
    </asp:DropDownList>评审按钮</div>



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
        <asp:TemplateField HeaderText="Time">
            <itemtemplate><%# Eval("Time")%></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Type">
            <itemtemplate><%# Eval("Type")%></itemtemplate>
            <itemstyle cssclass="type" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Operation">
            <itemtemplate><asp:LinkButton ID="LinkButton1" runat="server">Opinion</asp:LinkButton>&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server">Next Action</asp:LinkButton></itemtemplate>
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
		Opinion</asp:Panel>
    <div><asp:Label ID="LblTitleAdd" runat="server" AssociatedControlID="TxtTitleAdd" Text=" " CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTitleAdd" runat="server" Width="30em" TextMode="MultiLine" Rows="3"></asp:TextBox></div>
    <div>&nbsp;</div>
    <div><asp:Label ID="Label1" runat="server" AssociatedControlID="TxtTitleAdd" Text="Previous Suggestion:" CssClass="title"></asp:Label><asp:DropDownList
            ID="DropDownList1" runat="server" Width="10em">
        </asp:DropDownList>
    </div>

    <div><asp:Label ID="Label3" runat="server" AssociatedControlID="TxtTitleAdd" Text="Suggestion:" CssClass="title"></asp:Label><asp:DropDownList
            ID="DropDownList3" runat="server" Width="10em">
        </asp:DropDownList>
    </div>
    Send Mail check box;
    


    <div><asp:Label ID="Label2" runat="server" AssociatedControlID="TxtTitleAdd" Text="Level:" CssClass="title"></asp:Label><asp:DropDownList
            ID="DropDownList2" runat="server" Width="10em">
        </asp:DropDownList>
    </div>

    <div style="white-space: nowrap; text-align: center; margin-top:2em;">
		<asp:Button ID="BtnSaveAdd" runat="server" Text="Save" CausesValidation="true" ValidationGroup="Add"/>
		<asp:Button ID="BtnCancelAdd" runat="server" CausesValidation="false" Text="Cancel"/>
	</div>
</asp:Panel>


    </ContentTemplate>
</asp:UpdatePanel>


