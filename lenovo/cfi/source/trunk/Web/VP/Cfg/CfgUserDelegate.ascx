<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CfgUserDelegate.ascx.cs" Inherits="Lenovo.CFI.Web.VP.CfgUserDelegate" %>
<tbwc:StyleSheetControl ID="SscLink" runat="server" CssPath="VP/cfg/cfguserinfo.css"></tbwc:StyleSheetControl>
<tbwc:Fieldset ID="FsDelegate" runat="server" DesignWidth="700px" CssClass="userinfo" GroupingText="Delegate(Now only for Lesson Learned)" DefaultButton="BtnDelegate">
    <div><asp:Label ID="LblDelegate" runat="server" AssociatedControlID="DdlDelegate" Text="Delegate:" CssClass="title"></asp:Label><asp:DropDownList
            ID="DdlDelegate" runat="server" Width="20.5em">
        </asp:DropDownList><div class="operation"><asp:Button ID="BtnDelegate" runat="server" SkinID="EditPrimary" Text="Save" ToolTip="Save" 
        OnClick="BtnDelegate_Click" /></div>
    </div>
</tbwc:Fieldset>
