<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AsyncFileUpload.ascx.cs" Inherits="Lenovo.CFI.Web.UserControls.AsyncFileUpload" %>
<asp:UpdatePanel ID="UpFile" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
            <asp:HyperLink ID="HlFile" runat="server" Target="_blank">Download</asp:HyperLink><input 
                id="HiFile" type="hidden" runat="server" /><asp:Button 
                ID="BtnFileClear" runat="server" onclick="BtnFileClear_Click" Text="Remove" CausesValidation="false" /><asp:Button 
                ID="BtnFileUpdate" runat="server" Style="display:none" onclick="BtnFileUpdate_Click" CausesValidation="false" />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpFileAfu" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <ajaxToolKit:AsyncFileUpload ID="AfuFile" runat="server" style="display:inline-block;"
                onuploadedcomplete="AfuFile_UploadedComplete"
                OnClientUploadComplete="UploadComplete"></ajaxToolKit:AsyncFileUpload>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Literal ID="LtrHint" Text="(if more than 1 file, pls upload zip or rar package)" runat="server"></asp:Literal>