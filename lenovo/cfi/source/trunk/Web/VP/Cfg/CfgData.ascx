<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CfgData.ascx.cs" Inherits="Lenovo.CFI.Web.VP.CfgData" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscAc" runat="server" CssPath="VP/autocomplete.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscLink" runat="server" CssPath="VP/cfg/cfgdata.css"></tbwc:StyleSheetControl>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" CombineScripts="false" ID="ScriptManager1" >
    <Services>
        <asp:ServiceReference  Path="~/WS/AjaxUser.asmx" />
    </Services>
    <Scripts>
        <asp:ScriptReference Path="~/js/jquery-1.4.2.js" />
        <asp:ScriptReference Path="~/js/jquery.autocomplete.js" />
    </Scripts>
</ajaxToolkit:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div id="relatedoperation">
    <div style="float:right" class="operation"><asp:Button ID="BtnAdd" runat="server" SkinID="EditPrimary" Text="New" ToolTip="Add Data" /></div>
    <asp:DropDownList ID="DdlType" runat="server" Width="16em"
        AutoPostBack="true" onselectedindexchanged="DdlType_SelectedIndexChanged">
        <asp:ListItem Text="QR Product Line" Value="21"></asp:ListItem>
        <asp:ListItem Text="QR Problem Description" Value="23"></asp:ListItem>
        <asp:ListItem Text="QR RootCause 1" Value="24"></asp:ListItem>
        <asp:ListItem Text="QR RootCause 2" Value="25"></asp:ListItem>
        <asp:ListItem Text="QR RootCause 3" Value="26"></asp:ListItem>
        <asp:ListItem Text="QR Attachment" Value="22"></asp:ListItem>
        <asp:ListItem Text="CloseLoop Category" Value="27"></asp:ListItem>
        <asp:ListItem Text="CloseLoop Department" Value="28"></asp:ListItem>
        <asp:ListItem Text="RC MailGroup" Value="31" Enabled="false"></asp:ListItem>
        <asp:ListItem Text="EWG Issue Status" Value="41"></asp:ListItem>
        <asp:ListItem Text="EWG Issue Phase" Value="44"></asp:ListItem>
        <asp:ListItem Text="EWG QPE Team" Value="42"></asp:ListItem>
        <asp:ListItem Text="EWG Folder" Value="43"></asp:ListItem>
        <asp:ListItem Text="LL Department" Value="51"></asp:ListItem>
        <asp:ListItem Text="LL Problem Source" Value="52"></asp:ListItem>
        <asp:ListItem Text="LL Problem Factory" Value="53"></asp:ListItem>
        <asp:ListItem Text="LL Part" Value="54"></asp:ListItem>
    </asp:DropDownList></div>
<div class="dataListArea">
    <tbwc:GridViewEx ID="GvList" runat="server" SkinID="List"
        DataKeyNames="Code" AllowPaging="false"
        OnRowDataBound="GvList_RowDataBound" 
        OnRowCommand="GvList_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="No.">
            <itemstyle cssclass="listNo" />
            <itemtemplate><asp:Literal ID="LtrNo" runat="server"></asp:Literal></itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Code">
            <itemtemplate><%# Eval("Code")%></itemtemplate>
            <itemstyle cssclass="code" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title">
            <itemtemplate><%# Eval("Title")%></itemtemplate>
            <itemstyle cssclass="title" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sort">
            <itemtemplate><%# Eval("Sort")%></itemtemplate>
            <itemstyle cssclass="sort" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Visible">
            <itemtemplate><%# Eval("Visible")%></itemtemplate>
            <itemstyle cssclass="visible" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Operation">
            <itemtemplate><%# Eval("Updator")%> <%# Eval("UpdateTime", "{0:yyyy-MM-dd HH:mm}")%></itemtemplate>
            <itemstyle cssclass="optor" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="&#160;">
            <itemtemplate><asp:ImageButton 
            ID="BtnEdit" runat="server" CausesValidation="False" CommandName="OpenEdit"
                SkinID="ListEdit" CommandArgument='<%# Eval("Code")%>' /></itemtemplate>
            <itemstyle cssclass="listOp" />
        </asp:TemplateField>
    </Columns>
    </tbwc:GridViewEx>
</div>
<asp:Button ID="BtnHiddenEdit" runat="Server" Style="display:none" />
<ajaxToolKit:ModalPopupExtender ID="MpeEdit" runat="server" TargetControlID="BtnHiddenEdit" 
    PopupControlID="PnlEdit" CancelControlID="BtnCancelEdit" 
    BackgroundCssClass="modalBackground" PopupDragHandleControlID="PnlEditCaption" Drag="false">
</ajaxToolKit:ModalPopupExtender>
<asp:Panel ID="PnlEdit" runat="server" CssClass="modalBox detail" Style="display: none;" Width="800px">
    <asp:Panel ID="PnlEditCaption" runat="server" CssClass="caption" Style="margin-bottom: 10px; cursor: hand;">
		Edit</asp:Panel>
	<div><asp:Label ID="LblCodeEdit" runat="server" AssociatedControlID="TxtCodeEdit" Text="Code:" CssClass="title"></asp:Label><asp:TextBox 
	        ID="TxtCodeEdit" runat="server" Width="10em" ReadOnly="true"></asp:TextBox></div>
    <div id="DivBuEdit" runat="server"><asp:Label ID="LblBuEdit" runat="server" AssociatedControlID="TxtBuEdit" Text="BU:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtBuEdit" runat="server" Width="10em" ReadOnly="true"></asp:TextBox></div>
    <div id="DivParentEdit" runat="server"><asp:Label ID="LblParentEdit" runat="server" AssociatedControlID="TxtParentEdit" Text="Parent:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtParentEdit" runat="server" Width="10em" ReadOnly="true"></asp:TextBox></div>
    <div><asp:Label ID="LblTitleEdit" runat="server" AssociatedControlID="TxtTitleEdit" Text="Title:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTitleEdit" runat="server" Width="20em"></asp:TextBox></div>
    <div><asp:Label ID="LblSortEdit" runat="server" AssociatedControlID="TxtSortEdit" Text="Sort:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtSortEdit" runat="server" Width="10em" MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator
            ID="RfvSortEdit" runat="server" ErrorMessage="Required" Display="Dynamic" ControlToValidate="TxtSortEdit" ValidationGroup="Edit"></asp:RequiredFieldValidator><asp:CompareValidator
            ID="CvSortEdit" runat="server" ErrorMessage="Interger" Display="Dynamic" ControlToValidate="TxtSortEdit" 
            ValidationGroup="Edit" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator></div>
    <div><asp:Label ID="LblVisibleEdit" runat="server" AssociatedControlID="CbVisibleEdit" Text="Visible:" CssClass="title"></asp:Label><asp:CheckBox
            ID="CbVisibleEdit" runat="server" /></div>
    <div id="DivMailListEdit" runat="server"><table cellpadding="0" cellspacing="0"><tr>
            <td><asp:Label ID="LblOwnerEdit" runat="server" AssociatedControlID="UacOwnerEdit" Text="MailList:" CssClass="title"></asp:Label></td>
            <td><tbwc:UserAutoComplete 
            ID="UacOwnerEdit" runat="server" CssClass="maillist" MaxCount="80" 
            AcServiceUrl="WS/AjaxUserAc.aspx" 
            CheckServiceUrl="Lenovo.CFI.Web.WS.AjaxUser.CheckItCodesOrEmail" /></td>
            </tr></table></div>
    <div style="white-space: nowrap; text-align: center;">
		<asp:Button ID="BtnSaveEdit" runat="server" Text="Save" OnClick="BtnSaveEdit_Click" CausesValidation="true" ValidationGroup="Edit"/>
		<asp:Button ID="BtnCancelEdit" runat="server" CausesValidation="false" Text="Cancel"/>
	</div>
</asp:Panel>    
<ajaxToolKit:ModalPopupExtender ID="MpeAdd" runat="server" TargetControlID="BtnAdd" 
    PopupControlID="PnlAdd" CancelControlID="BtnCancelAdd" 
    BackgroundCssClass="modalBackground" PopupDragHandleControlID="PnlAddCaption" Drag="false">
</ajaxToolKit:ModalPopupExtender>
<asp:Panel ID="PnlAdd" runat="server" CssClass="modalBox detail" Style="display: none;" Width="380px">
    <asp:Panel ID="PnlAddCaption" runat="server" CssClass="caption" Style="margin-bottom: 10px; cursor: hand;">
		Add</asp:Panel>
	<div><asp:Label ID="LblCodeAdd" runat="server" AssociatedControlID="TxtCodeAdd" Text="Code:" CssClass="title"></asp:Label><asp:TextBox 
	        ID="TxtCodeAdd" runat="server" Width="10em" MaxLength="20"></asp:TextBox><asp:Literal
            ID="LtrCodeAdd" runat="server"></asp:Literal><asp:RequiredFieldValidator
            ID="RfvCodeAdd" runat="server" ErrorMessage="Required" Display="Dynamic" ControlToValidate="TxtCodeAdd" ValidationGroup="Add"></asp:RequiredFieldValidator></div>
    <div id="DivBuAdd" runat="server"><asp:Label ID="LblBuAdd" runat="server" AssociatedControlID="DdlBuAdd" Text="BU:" CssClass="title"></asp:Label><asp:DropDownList
            ID="DdlBuAdd" runat="server" Width="10.5em"></asp:DropDownList></div>
    <div id="DivParentAdd" runat="server"><asp:Label ID="LblParentAdd" runat="server" AssociatedControlID="DdlParentAdd" Text="Parent:" CssClass="title"></asp:Label><asp:DropDownList
            ID="DdlParentAdd" runat="server" Width="10.5em"></asp:DropDownList></div>
    <div><asp:Label ID="LblTitleAdd" runat="server" AssociatedControlID="TxtTitleAdd" Text="Title:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtTitleAdd" runat="server" Width="20em"></asp:TextBox></div>
    <div><asp:Label ID="LblSortAdd" runat="server" AssociatedControlID="TxtSortAdd" Text="Sort:" CssClass="title"></asp:Label><asp:TextBox 
            ID="TxtSortAdd" runat="server" Width="10em" MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator
            ID="RfvSortAdd" runat="server" ErrorMessage="Required" Display="Dynamic" ControlToValidate="TxtSortAdd" ValidationGroup="Add"></asp:RequiredFieldValidator><asp:CompareValidator
            ID="CvSortAdd" runat="server" ErrorMessage="Interger" Display="Dynamic" ControlToValidate="TxtSortAdd" 
            ValidationGroup="Add" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator></div>
    <div style="white-space: nowrap; text-align: center; margin-top:2em;">
		<asp:Button ID="BtnSaveAdd" runat="server" Text="Save" OnClick="BtnSaveAdd_Click" CausesValidation="true" ValidationGroup="Add"/>
		<asp:Button ID="BtnCancelAdd" runat="server" CausesValidation="false" Text="Cancel"/>
	</div>
</asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>