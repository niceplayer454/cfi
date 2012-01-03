<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopicReviewer.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.TopicReviewer" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscAc" runat="server" CssPath="VP/autocomplete.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscDp" runat="server" CssPath="DatePicker/datepicker.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SccDialogs" runat="server" CssPath="modaldialogs.css"></tbwc:StyleSheetControl>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" CombineScripts="false" ID="ScriptManager1" >
    <Services>
        <asp:ServiceReference  Path="~/WS/AjaxUser.asmx" />
    </Services>
    <Scripts>
        <asp:ScriptReference Path="~/js/jquery-1.4.2.js" />
        <asp:ScriptReference Path="~/js/jquery.autocomplete.js" />
    </Scripts>
</ajaxToolkit:ToolkitScriptManager>


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


.maillist {display:inline-block;padding:1px;border:1px inset #5794BF;height:80px;overflow-y:auto;width:80em;background-color:white;}
.maillist .inner .value {padding:2px;margin-right:2px;border:medium none;display:inline-block;}
.maillist .inner .valuehover {padding:1px;background-color:#f0f8f0;border:1px solid #50a05b; }
.maillist .input {background-color:transparent;border:1px solid #50a05b;clear:none;width:9em;}


</style>


<div class="wrapper">

    <tbwc:Fieldset ID="Fieldset1" runat="server" DesignWidth="1240px" CssClass="rollcall" GroupingText="Reviewers">

        <div class="line"><asp:Label ID="Lbl1" runat="server" AssociatedControlID="UserAutoComplete1" Text="Name:" CssClass="title"></asp:Label><tbwc:UserAutoComplete 
                    ID="UserAutoComplete1" runat="server" CssClass="maillist" MaxCount="80"
                    AcServiceUrl="WS/AjaxUserAc.aspx"
                    CheckServiceUrl="Lenovo.CFI.Web.WS.AjaxUser.CheckItCodesOrEmail" /></div>

    </tbwc:Fieldset>


    <div class="operation" style="padding:8px 0px 8px 0em;text-align:center;"><asp:Button ID="BtnSave" runat="server" CssClass="primary" 
        Text="Submit"/><asp:LinkButton ID="BtnFinish" runat="server" Text="Finish" 
        SkinID="EditSecondary"></asp:LinkButton></div>

</div>
