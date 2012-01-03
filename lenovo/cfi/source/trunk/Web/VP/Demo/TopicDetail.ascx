<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicDetail.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicDetail" %>

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

</style>

<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" CombineScripts="false" ID="ScriptManager1" >
    <Services>
        <asp:ServiceReference  Path="~/WS/AjaxUser.asmx" />
    </Services>
    <Scripts>
        <asp:ScriptReference Path="~/js/jquery-1.4.2.js" />
        <asp:ScriptReference Path="~/js/jquery.autocomplete.js" />
    </Scripts>
</ajaxToolkit:ToolkitScriptManager>

<div class="wrapper">

    <tbwc:Fieldset ID="FsRollCall" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Topic Content">

        <div class="line"><asp:Label ID="Lbl1" runat="server" AssociatedControlID="Lbl1C" Text="Name:" CssClass="title"></asp:Label><asp:Label 
            ID="Lbl1C" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label1" runat="server" AssociatedControlID="Label2" Text="T-DC:" CssClass="title"></asp:Label><asp:Label 
            ID="Label2" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label13" runat="server" AssociatedControlID="Label2" Text="PPT:" CssClass="title"></asp:Label><asp:Label 
            ID="Label14" runat="server" CssClass="readvalue" Text="<a href='#'>xxxxxx</a>&nbsp;"></asp:Label>(1)</div>

        <div class="line"><asp:Label ID="Label11" runat="server" AssociatedControlID="Label2" Text="StartTime:" CssClass="title"></asp:Label><asp:Label 
            ID="Label12" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label9" runat="server" AssociatedControlID="Label2" Text="ReviewTime:" CssClass="title"></asp:Label><asp:Label 
            ID="Label10" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

    </tbwc:Fieldset>

</div>