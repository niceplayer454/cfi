<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyIdeaNew.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.MyIdeaNew" %>

<%@ Register src="../../UserControls/AsyncFileUpload.ascx" tagname="AsyncFileUpload" tagprefix="afu" %>
<%@ Register src="../../UserControls/MultiAsyncFileUpload.ascx" tagname="MultiAsyncFileUpload" tagprefix="mafu" %>

<script type="text/javascript">
    function FileUploadComplete(sender, args) {
        setTimeout("__doPostBack('<%= AfuFileEdit.UpdateUniqueID %>','')", 0);

        alert(args.get_fileName() + " upload successfully!");
    }

    function MFileUploadComplete(sender, args) {
        setTimeout("__doPostBack('<%= MafuFileEdit.UpdateUniqueID %>','')", 0);

        alert(args.get_fileName() + " upload successfully!");
    }

</script>

<style type="text/css">

.wrapper 
{
    margin:16px 16px 16px 16px;
    border:#ddd 1px solid;
    background-color:#fff;
    color:#444;
    width:1206px;
}


fieldset {margin:16px 16px 16px 16px;padding:16px 0px 16px 0px;border: medium none;border: solid 1px #ccc;background-color:#fafafa;position:relative;}
fieldset legend {margin: 0px 0px 0px 20px;padding:0px;color: #036;background: transparent;font-size: 16px; font-weight:bold;position:absolute;top:-8px;}
fieldset div {display: block;padding: 0px;}
fieldset select  {vertical-align:top;}


span.readvalue {display:inline-block;padding-top:3px;vertical-align:top;vertical-align:top;width:10em;}
span.readvaluel {display:inline-block;margin-top:0px;padding-bottom:2px;vertical-align:top;width:60em;white-space: pre-wrap; *white-space: pre; *word-wrap: break-word;}


div.line
{
    padding: 4px 0px 4px 44px;
    /*border-bottom:1px solid #cccccc;*/
}

label.title 
{
    display:inline-block;width:13em; padding-top:3px;vertical-align:top;font-size:12px;font-weight:bold;
}
label.titlesecond
{
    display:inline-block;width:10em; padding-top:3px;vertical-align:top;font-size:14px;margin-left:2.5em;
}

.afu input {height:21px;}

.mafu {display:inline-block; width:900px;}
.mafu span {display:inline-block;vertical-align:middle;}
.mafu ul {display:inline-block;}
.mafu li {display:inline-block;float: left;list-style-type: none;}


</style>

<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" CombineScripts="false" ID="ScriptManager1" >
    <Scripts>
        <asp:ScriptReference Path="~/js/jquery-1.4.2.js" />
        <asp:ScriptReference Path="~/js/jquery.autocomplete.js" />
    </Scripts>
</ajaxToolkit:ToolkitScriptManager>


<div class="wrapper">

    <tbwc:Fieldset ID="FsRollCall" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Idea Content">

        <div class="line"><asp:Label ID="Lbl1" runat="server" AssociatedControlID="TextBox1" Text="Name:" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox1" runat="server" Width="44.5em"></asp:TextBox></div>

        <div class="line"><asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownList1" Text="Type:" CssClass="title"></asp:Label><asp:DropDownList
                ID="DropDownList1" runat="server" Width="10em">
                <asp:ListItem Text="Green"></asp:ListItem>
                <asp:ListItem Text="Productivity"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="line"><asp:Label ID="Label2" runat="server" AssociatedControlID="CheckBoxList1" Text="Related Type:" CssClass="title"></asp:Label><asp:CheckBoxList
                ID="CheckBoxList1" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" style="display:inline-block">
            <asp:ListItem Text="xxx"></asp:ListItem>
            <asp:ListItem Text="xxx"></asp:ListItem>
            </asp:CheckBoxList>
        </div>

        <div class="line"><asp:Label ID="Label4" runat="server" AssociatedControlID="DropDownList1" Text="Keywords:" CssClass="title"></asp:Label><asp:DropDownList
                ID="DropDownList3" runat="server" Width="10em">
                <asp:ListItem Text="Select..."></asp:ListItem>
                <asp:ListItem Text="xxx"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList
                ID="DropDownList4" runat="server" Width="10em">
                <asp:ListItem Text="Select..."></asp:ListItem>
                <asp:ListItem Text="xxx"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList
                ID="DropDownList5" runat="server" Width="10em">
                <asp:ListItem Text="Select..."></asp:ListItem>
                <asp:ListItem Text="xxx"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox5" runat="server" Width="6em"></asp:TextBox>
        </div>

        <div class="line"><asp:Label ID="Label3" runat="server" AssociatedControlID="TextBox2" Text="Background:" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox2" runat="server" TextMode="MultiLine" Rows="3" Width="40em"></asp:TextBox></div>

        <div class="line"><asp:Label ID="Label5" runat="server" AssociatedControlID="TextBox3" Text="Description:" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox3" runat="server" TextMode="MultiLine" Rows="3" Width="40em"></asp:TextBox></div>

        <div class="line"><asp:Label ID="Label7" runat="server" AssociatedControlID="TextBox4" Text="Value:" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox4" runat="server" TextMode="MultiLine" Rows="3" Width="40em"></asp:TextBox></div>

        <div class="line"><asp:Label ID="Label13" runat="server" AssociatedControlID="AfuFileEdit" Text="PPT:" CssClass="title"></asp:Label><afu:AsyncFileUpload 
                ID="AfuFileEdit" runat="server" CssClass="afu" Width="25em" ShowFileLink="true" RenderMode="Inline" HintVisible="false"
                OnClientUploadComplete="FileUploadComplete" /></div>

        <div class="line"><asp:Label ID="Label15" runat="server" AssociatedControlID="MafuFileEdit" Text="Pictures:" CssClass="title"></asp:Label><mafu:MultiAsyncFileUpload 
            ID="MafuFileEdit" runat="server" CssClass="mafu" AfuCssClass ="afu" Width="25em" RenderMode="Inline"
                OnClientUploadComplete="MFileUploadComplete" /></div>

        <div class="line"><asp:Label ID="Label11" runat="server" AssociatedControlID="Label12" Text="Owner:" CssClass="title"></asp:Label><asp:Label 
            ID="Label12" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label9" runat="server" AssociatedControlID="DropDownList2" Text="Approver:" CssClass="title"></asp:Label><asp:DropDownList
                ID="DropDownList2" runat="server" Width="20em">
                <asp:ListItem Text="Select..."></asp:ListItem>
                <asp:ListItem Text="xxxx"></asp:ListItem>
            </asp:DropDownList></div>



    </tbwc:Fieldset>

    <div class="operation" style="padding:8px 0px 8px 16em"><asp:Button ID="BtnSave" runat="server" CssClass="primary" 
        Text="Submit"/><asp:LinkButton ID="BtnCancel" runat="server" Text="Cancel" 
        SkinID="EditSecondary"></asp:LinkButton></div>


</div>
