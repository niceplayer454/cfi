<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CfgUserInfo.ascx.cs" Inherits="Lenovo.CFI.Web.VP.CfgUserInfo" %>
<tbwc:StyleSheetControl ID="SscLink" runat="server" CssPath="VP/cfg/cfguserinfo.css"></tbwc:StyleSheetControl>
<tbwc:Fieldset ID="FsEdit" runat="server" DesignWidth="700px" CssClass="userinfo" GroupingText="User Info" DefaultButton="BtnSave">
	<div><asp:Label ID="LblItCode" runat="server" AssociatedControlID="TxtItCode" Text="ItCode:" CssClass="title"></asp:Label><asp:TextBox
        ID="TxtItCode" runat="server" MaxLength="20" Width="20em" ReadOnly="true"></asp:TextBox></div>
	<div><asp:Label ID="LblName" runat="server" AssociatedControlID="TxtLastName" Text="Name:" CssClass="title"></asp:Label><asp:TextBox
        ID="TxtLastName" runat="server" MaxLength="10" Width="4em"></asp:TextBox><span class="hint"><asp:RequiredFieldValidator
        ID="RfvLastName" runat="server" ControlToValidate="TxtLastName" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator></span><asp:TextBox
        ID="TxtFirstName" runat="server" MaxLength="10" Width="10em"></asp:TextBox><span class="hint"><asp:RequiredFieldValidator
        ID="RfvFirstName" runat="server" ControlToValidate="TxtFirstName" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator></span></div>
	<div><asp:Label ID="LblPhone" runat="server" AssociatedControlID="TxtPhone" Text="Phone:" CssClass="title"></asp:Label><asp:TextBox
        ID="TxtPhone" runat="server" MaxLength="20" Width="20em"></asp:TextBox><span class="hint"><asp:RequiredFieldValidator
        ID="RfvPhone" runat="server" ControlToValidate="TxtPhone" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator></span></div>
    <div><asp:Label ID="LblPassword" runat="server" AssociatedControlID="TxtPassword" Text="New Password:" CssClass="title"></asp:Label><asp:TextBox
        ID="TxtPassword" runat="server" MaxLength="20" Width="20em" TextMode="Password"></asp:TextBox></div>
    <div><asp:Label ID="LblPasswordRe" runat="server" AssociatedControlID="TxtPasswordRe" Text="Password Again:" CssClass="title"></asp:Label><asp:TextBox
        ID="TxtPasswordRe" runat="server" MaxLength="20" Width="20em" TextMode="Password"></asp:TextBox><span class="hint"><asp:CompareValidator
        ID="CvPasswordRe" runat="server" ControlToValidate="TxtPasswordRe" ErrorMessage="Not match" Display="Dynamic" ControlToCompare="TxtPassword" Operator="Equal"></asp:CompareValidator></span></div>
    <div class="operation"><asp:Button ID="BtnSave" runat="server" SkinID="EditPrimary" Text="Save" ToolTip="Save" 
        OnClick="BtnSave_Click" /></div>
</tbwc:Fieldset>

<tbwc:Fieldset ID="FsDelegate" runat="server" DesignWidth="700px" CssClass="userinfo" GroupingText="Delegate(Now only for Lesson Learned)" DefaultButton="BtnDelegate" Visible="false">
    <div><asp:Label ID="LblDelegate" runat="server" AssociatedControlID="DdlDelegate" Text="Delegate:" CssClass="title"></asp:Label><asp:DropDownList
            ID="DdlDelegate" runat="server" Width="20.5em">
        </asp:DropDownList><div class="operation"><asp:Button ID="BtnDelegate" runat="server" SkinID="EditPrimary" Text="Save" ToolTip="Save" 
        OnClick="BtnDelegate_Click" /></div>
    </div>
</tbwc:Fieldset>
