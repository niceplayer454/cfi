<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicList.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicList" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscAc" runat="server" CssPath="VP/autocomplete.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscDp" runat="server" CssPath="DatePicker/datepicker.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
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


a.textbtn
 {
    text-decoration:none;
	background:#EEE;
	border: 1px solid #CCC;
	display: inline-block;
	
	height: 16px;
	line-height: 16px;
	text-align:left;
	overflow: hidden;
	padding: 0px 8px;
	margin:0px 5px 0px 5px;
	vertical-align: top;
	color:#666;
 }
 
a.textbtn:hover
{
    text-decoration:none;
	border: 1px solid #999;
	color:#000;
}

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
    <div style="float:right" class="operation"><asp:Button ID="BtnAdd" runat="server" SkinID="EditPrimary" Text="New Topic" ToolTip="New Topic"/></div>
    <asp:DropDownList ID="DdlType" runat="server" Width="16em">
        <asp:ListItem Text="Topic 1" Value=""></asp:ListItem>
        <asp:ListItem Text="Topic 2" Value=""></asp:ListItem>
    </asp:DropDownList></div>
<div class="dataListArea">
    <tbwc:GridViewEx ID="GvList" runat="server" SkinID="List"
        DataKeyNames="ID" AllowPaging="true" onrowdatabound="GvList_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><%# Eval("No")%></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="T-DC">
            <itemtemplate><%# Eval("Tdc")%></itemtemplate>
            <itemstyle cssclass="tdc" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StartTime">
            <itemtemplate><%# Eval("Start")%></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SubmitDeadline">
            <itemtemplate><%# Eval("Submit")%></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ReviewTime">
            <itemtemplate><%# Eval("Review")%></itemtemplate>
            <itemstyle cssclass="time" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
            <itemtemplate><%# Eval("Status")%></itemtemplate>
            <itemstyle cssclass="status" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Operation">
            <itemtemplate><asp:LinkButton ID="BtnPhaseAction1" runat="server" CssClass="textbtn"></asp:LinkButton>
            <asp:LinkButton ID="BtnPhaseAction2" runat="server" CssClass="textbtn"></asp:LinkButton>
            <asp:LinkButton ID="BtnPhaseAction3" runat="server" CssClass="textbtn"></asp:LinkButton></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>


<ajaxToolKit:ModalPopupExtender ID="MpeAdd" runat="server" TargetControlID="BtnAdd" 
    PopupControlID="PnlAdd" CancelControlID="BtnCancelAdd" 
    BackgroundCssClass="modalBackground" PopupDragHandleControlID="PnlAddCaption" Drag="false">
</ajaxToolKit:ModalPopupExtender>
<asp:Panel ID="PnlAdd" runat="server" CssClass="modalBox detail" Style="display: none;" Width="380px">
    <asp:Panel ID="PnlAddCaption" runat="server" CssClass="caption" Style="margin-bottom: 10px; cursor: hand;">
		New Topic</asp:Panel>
    <div><asp:Label ID="LblTitleAdd" runat="server" AssociatedControlID="TxtTitleAdd" Text="Title:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTitleAdd" runat="server" Width="20em"></asp:TextBox></div>
    <div><asp:Label ID="LblTdcAdd" runat="server" AssociatedControlID="TxtTitleAdd" Text="T-DC:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTdcAdd" runat="server" Width="20em"></asp:TextBox></div>

    <div><asp:Label ID="Label1" runat="server" AssociatedControlID="DpDataAdd" Text="Start Time:" CssClass="title"></asp:Label><tbwc:DatePicker 
            ID="DpDataAdd" runat="server" Width="8.5em" /></div>
    <div><asp:Label ID="Label2" runat="server" AssociatedControlID="DpDataAdd" Text="Submit Deadline:" CssClass="title"></asp:Label><tbwc:DatePicker 
            ID="DatePicker1" runat="server" Width="8.5em" /></div>
    <div><asp:Label ID="Label3" runat="server" AssociatedControlID="DpDataAdd" Text="Review Time:" CssClass="title"></asp:Label><tbwc:DatePicker 
            ID="DatePicker2" runat="server" Width="8.5em" /></div>

    <div style="white-space: nowrap; text-align: center; margin-top:2em;">
		<asp:Button ID="BtnSaveAdd" runat="server" Text="Save" CausesValidation="true" ValidationGroup="Add"/>
		<asp:Button ID="BtnCancelAdd" runat="server" CausesValidation="false" Text="Cancel"/>
	</div>
</asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>