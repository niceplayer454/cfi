<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultiAsyncFileUpload.ascx.cs" Inherits="Lenovo.CFI.Web.UserControls.MultiAsyncFileUpload" %>
<asp:Panel ID="PnlMafu" runat="server" style="display:inline"><asp:UpdatePanel 
    ID="UpFile" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <ul>
            <asp:Repeater ID="RepFiles" runat="server" onitemcommand="RepFiles_ItemCommand" 
                onitemdatabound="RepFiles_ItemDataBound">
            <ItemTemplate>
                <li><asp:HyperLink ID="HlFile" runat="server" Target="_blank">Download</asp:HyperLink><input 
                    id="HiExistFileID" type="hidden" runat="server" /><input 
                    id="HiExistFileTitle" type="hidden" runat="server" /><input 
                    id="HiExistFileLink" type="hidden" runat="server" /><input 
                    id="HiNewFileID" type="hidden" runat="server" /><input 
                    id="HiNewFileTitle" type="hidden" runat="server" /><input 
                    id="HiNewFileLink" type="hidden" runat="server" /><tbwc:ConfirmImageButton 
                    ID="BtnRemove" runat="server" CausesValidation="False" CommandName="Reomve" ConfirmText="Delete?"
                    SkinID="ListFileRemove"/></li>
            </ItemTemplate>
            </asp:Repeater>
        </ul><asp:Button 
                ID="BtnFileUpdate" runat="server" Style="display:none" onclick="BtnFileUpdate_Click" CausesValidation="false" />
    </ContentTemplate>
</asp:UpdatePanel><asp:UpdatePanel 
    ID="UpFileAfu" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <ajaxToolKit:AsyncFileUpload ID="AfuFile" runat="server"
                onuploadedcomplete="AfuFile_UploadedComplete"></ajaxToolKit:AsyncFileUpload>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
