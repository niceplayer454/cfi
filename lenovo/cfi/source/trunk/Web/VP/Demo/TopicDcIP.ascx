<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicDcIP.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicDcIP" %>
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

    <tbwc:Fieldset ID="FsRollCall" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Topic DC and IP">

        <div class="line"><asp:Label ID="Lbl1" runat="server" AssociatedControlID="TextBox1" Text="Green :" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox1" runat="server" Width="10em" Text="xxx"></asp:TextBox></div>
        <div class="line"><asp:Label ID="Label1" runat="server" AssociatedControlID="TextBox2" Text="Productivity :" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox2" runat="server" Width="10em" Text="xxx"></asp:TextBox></div>
        <div class="line"><asp:Label ID="Label2" runat="server" AssociatedControlID="TextBox3" Text="HMI:" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox3" runat="server" Width="10em" Text="xxx"></asp:TextBox></div>
        <div class="line"><asp:Label ID="Label3" runat="server" AssociatedControlID="TextBox4" Text="IP:" CssClass="title"></asp:Label><asp:TextBox
            ID="TextBox4" runat="server" Width="10em" Text="xxx"></asp:TextBox></div>

    </tbwc:Fieldset>

    <div class="operation" style="padding:8px 0px 8px 16em"><asp:Button ID="BtnSave" runat="server" CssClass="primary" 
        Text="Submit"/></asp:LinkButton><asp:LinkButton ID="BtnFinish" runat="server" Text="Finish" 
        SkinID="EditSecondary"></asp:LinkButton></div>


</div>