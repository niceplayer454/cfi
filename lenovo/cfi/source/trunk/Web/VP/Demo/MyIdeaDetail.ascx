<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyIdeaDetail.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.MyIdeaDetail" %>
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

    <tbwc:Fieldset ID="FsRollCall" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Idea Content">

        <div class="line"><asp:Label ID="Lbl1" runat="server" AssociatedControlID="Lbl1C" Text="Name:" CssClass="title"></asp:Label><asp:Label 
            ID="Lbl1C" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label1" runat="server" AssociatedControlID="Label2" Text="Type:" CssClass="title"></asp:Label><asp:Label 
            ID="Label2" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label43" runat="server" AssociatedControlID="Label2" Text="Related Type:" CssClass="title"></asp:Label><asp:Label 
            ID="Label44" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label45" runat="server" AssociatedControlID="Label2" Text="Keywords:" CssClass="title"></asp:Label><asp:Label 
            ID="Label46" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label3" runat="server" AssociatedControlID="Label4" Text="Background:" CssClass="title"></asp:Label><asp:Label 
            ID="Label4" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label5" runat="server" AssociatedControlID="Label6" Text="Description:" CssClass="title"></asp:Label><asp:Label 
            ID="Label6" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label7" runat="server" AssociatedControlID="Label8" Text="Value:" CssClass="title"></asp:Label><asp:Label 
            ID="Label8" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label13" runat="server" AssociatedControlID="Label8" Text="PPT:" CssClass="title"></asp:Label><asp:Label 
            ID="Label14" runat="server" CssClass="readvalue" Text="<a href='#'>xxxxxx</a>&nbsp;"></asp:Label>(1)</div>

        <div class="line"><asp:Label ID="Label15" runat="server" AssociatedControlID="Label8" Text="Pictures:" CssClass="title"></asp:Label><asp:Label 
            ID="Label16" runat="server" CssClass="readvalue" Text="<a href='#'>xxxxxx</a>&nbsp;<a href='#'>xxxxxx</a>&nbsp;<a href='#'>xxxxxx</a>&nbsp;"></asp:Label>(3)</div>

        <div class="line"><asp:Label ID="Label11" runat="server" AssociatedControlID="Label8" Text="Owner:" CssClass="title"></asp:Label><asp:Label 
            ID="Label12" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label9" runat="server" AssociatedControlID="Label8" Text="Approver:" CssClass="title"></asp:Label><asp:Label 
            ID="Label10" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label17" runat="server" AssociatedControlID="Label8" Text="Status:" CssClass="title"></asp:Label><asp:Label 
            ID="Label18" runat="server" CssClass="readvalue" Text="xxxxxx"></asp:Label></div>

    </tbwc:Fieldset>

    <tbwc:Fieldset ID="Fieldset1" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Idea Suggestion" EnableToogle="true">

        <div class="line"><asp:Label ID="Label19" runat="server" AssociatedControlID="Label20" Text="Approver:" CssClass="title"></asp:Label><asp:Label 
            ID="Label20" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>
 
         <div class="line"><asp:Label ID="Label21" runat="server" AssociatedControlID="Label20" Text="DC:" CssClass="title"></asp:Label><asp:Label 
            ID="Label22" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>
   
    </tbwc:Fieldset>

    <tbwc:Fieldset ID="Fieldset2" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Idea Review" EnableToogle="true">

        <div class="line"><asp:Label ID="Label39" runat="server" AssociatedControlID="Label24" Text="Time:" CssClass="title"></asp:Label><asp:Label 
            ID="Label40" runat="server" CssClass="readvalue" Text="xxxxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label23" runat="server" AssociatedControlID="Label24" Text="Value:" CssClass="title"></asp:Label><asp:Label 
            ID="Label24" runat="server" CssClass="readvalue" Text="9.0"></asp:Label></div>
 
        <div class="line"><asp:Label ID="Label25" runat="server" AssociatedControlID="Label24" Text="Type:" CssClass="title"></asp:Label><asp:Label 
            ID="Label26" runat="server" CssClass="readvalue" Text="xxxxxx"></asp:Label></div>
 
        <div class="line"><asp:Label ID="Label27" runat="server" AssociatedControlID="Label24" Text="Comments:" CssClass="title"></asp:Label><asp:Label 
            ID="Label28" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>
        
        <div class="line"><asp:Label ID="Label29" runat="server" AssociatedControlID="Label24" Text="Suggestion:" CssClass="title"></asp:Label><asp:Label 
            ID="Label30" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label31" runat="server" AssociatedControlID="Label24" Text="IP:" CssClass="title"></asp:Label><asp:Label 
            ID="Label32" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label33" runat="server" AssociatedControlID="Label24" Text="IP Comment:" CssClass="title"></asp:Label><asp:Label 
            ID="Label34" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>
  
    </tbwc:Fieldset>

    <tbwc:Fieldset ID="Fieldset3" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Idea Award" EnableToogle="true">

        <div class="line"><asp:Label ID="Label35" runat="server" AssociatedControlID="Label36" Text="Award:" CssClass="title"></asp:Label><asp:Label 
            ID="Label36" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>
   
    </tbwc:Fieldset>

    <tbwc:Fieldset ID="Fieldset4" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Idea Feedback" EnableToogle="true">

        <div class="line"><asp:Label ID="Label37" runat="server" AssociatedControlID="Label38" Text="Executor:" CssClass="title"></asp:Label><asp:Label 
            ID="Label38" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx"></asp:Label></div>

        <div class="line"><asp:Label ID="Label41" runat="server" AssociatedControlID="Label42" Text="Feedback:" CssClass="title"></asp:Label><asp:Label 
            ID="Label42" runat="server" CssClass="readvalue" Text="xxxxxx xxxxxx xxxxxx<br>xxxx<br>xxxx"></asp:Label></div>
   
    </tbwc:Fieldset>

</div>
