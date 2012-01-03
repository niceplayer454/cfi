<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicSchedule.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicSchedule" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscDp" runat="server" CssPath="DatePicker/datepicker.css"></tbwc:StyleSheetControl>

<style type="text/css">

#relatedoperation {width:1206px;line-height:20px;height:26px;text-align:left;padding:0px 16px 5px 16px;}
#relatedoperation .op {padding:0px 0px 0px 10px;}

.dataListArea {width:1206px}

.dataListArea .title {width:400px;text-align:left;}
.dataListArea .tdc {width:100px;text-align:left;}
.dataListArea .time {width:120px;text-align:left;}
.dataListArea .status {width:150px;text-align:left;}
.dataListArea th.listOp {width:260px;text-align:left;padding-right:4px;}
.dataListArea td.listOp {width:260px;text-align:left;padding-right:4px; background-color:#fff;}


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
    <div  class="operation"><tbwc:DatePicker ID="DatePicker3" runat="server" Width="8.5em" Value="2011-12-26" />
        <asp:TextBox ID="TextBox1" runat="server" Text="10:00"></asp:TextBox>(AM)<asp:TextBox ID="TextBox2" runat="server" Text="13:30"></asp:TextBox>(PM)
        <asp:Button ID="BtnGenerate" runat="server" SkinID="EditPrimary" 
            Text="Generate" ToolTip="Generate" onclick="BtnGenerate_Click" /></div></div>
<div class="dataListArea">
    <tbwc:GridViewEx ID="GvList" runat="server" SkinID="List"
        DataKeyNames="ID" AllowPaging="true" onrowcommand="GvList_RowCommand">
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
        <asp:TemplateField HeaderText="Period">
            <itemtemplate><asp:TextBox ID="TxtM" runat="server" Text="10"></asp:TextBox>mim</itemtemplate>
            <itemstyle cssclass="period" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sort">
            <itemtemplate><asp:TextBox ID="TxtS" runat="server" Text='<%# Eval("Sort")%>'></asp:TextBox></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Operation">
            <itemtemplate><asp:LinkButton ID="BtnAction1" runat="server" Text="up"></asp:LinkButton>
            <asp:LinkButton ID="BtnAction2" runat="server" Text="down"></asp:LinkButton>
            <asp:LinkButton ID="BtnAction3" runat="server" Text="break"></asp:LinkButton></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>

<div class="operation" style="padding:8px 0px 8px 0em;text-align:center;"><asp:Button ID="BtnSave" runat="server" CssClass="primary" 
        Text="Submit"/><asp:LinkButton ID="BtnFinish" runat="server" Text="Finish" 
        SkinID="EditSecondary"></asp:LinkButton></div>

<asp:Button ID="BtnHiddenEdit" runat="Server" Style="display:none" />
<ajaxToolKit:ModalPopupExtender ID="MpeAdd" runat="server" TargetControlID="BtnHiddenEdit" 
    PopupControlID="PnlAdd" CancelControlID="BtnCancelAdd" 
    BackgroundCssClass="modalBackground" PopupDragHandleControlID="PnlAddCaption" Drag="false">
</ajaxToolKit:ModalPopupExtender>
<asp:Panel ID="PnlAdd" runat="server" CssClass="modalBox detail" Style="display: none;" Width="380px">
    <asp:Panel ID="PnlAddCaption" runat="server" CssClass="caption" Style="margin-bottom: 10px; cursor: hand;">
		New Break</asp:Panel>
    <div><asp:Label ID="LblTitleAdd" runat="server" AssociatedControlID="TxtTitleAdd" Text="Period:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTitleAdd" runat="server" Width="20em" Text="15"></asp:TextBox>min</div>
    <div>Or</div>
    <div><asp:Label ID="LblTdcAdd" runat="server" AssociatedControlID="TxtTitleAdd" Text="Until:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTdcAdd" runat="server" Width="20em" Text="13:30"></asp:TextBox></div>

    <div style="white-space: nowrap; text-align: center; margin-top:2em;">
		<asp:Button ID="BtnSaveAdd" runat="server" Text="Save" CausesValidation="true" ValidationGroup="Add"/>
		<asp:Button ID="BtnCancelAdd" runat="server" CausesValidation="false" Text="Cancel"/>
	</div>
</asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>