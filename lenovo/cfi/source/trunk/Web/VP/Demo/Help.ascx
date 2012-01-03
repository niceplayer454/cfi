<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Help.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Demo.Help" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscLink" runat="server" CssPath="VP/home.css"></tbwc:StyleSheetControl>

<style type="text/css">

.help {
	border:1px solid #999;
	margin:8px 16px 8px 16px;
}
.help h2 {
	background:#DDD;
	margin:0px 0px 0.25em;
	padding:2px 10px;
}


.help .item 
{
    margin:12px;
    padding:0px 0px 8px 2em;
    border-bottom:#ccc 1px dotted;
    color:#444;
}

.help .item em 
{
    display:inline-block;
    font-weight:bold;
    width:8em;
}

.help .problem
{
    margin:12px;
    padding:0px 0px 8px 2em;
    color:#444;
    font-weight:bold;
    vertical-align:top;
}

.help .answer
{
    margin:12px;
    padding:0px 0px 8px 4em;
    border-bottom:#ccc 1px dotted;
    color:#444;
}

.help .text
{
    margin:12px;
    padding:0px 0px 8px 2em;
    color:#444;
}




</style>

<div class="help">
    <h2>Help</h2>
    <div class="item"><em>Template:</em><a href="xxxxx">Download</a></div>
    <div class="item"><em>Feedback:</em><a href="mailto:xxx@lenovo.com?subject=CFI System Feedback">Send Mail</a></div>
</div>

<div class="help">
    <h2>Q&A</h2>
    <div class="problem">Problem xxxxx</div>
    <div class="answer">xxxxxxx<br/>xxxxxxx<br/>xxxxxxx<br/>xxxxxxx</div>
    <div class="problem">Problem xxxxx</div>
    <div class="answer">xxxxxxx<br/>xxxxxxx<br/>xxxxxxx<br/>xxxxxxx</div>
</div>

<div class="help">
    <h2>CFI Process</h2>
    <div class="text">xxxxxxx<br/>xxxxxxx<br/>xxxxxxx<br/>xxxxxxx</div>
</div>

<div class="help">
    <h2>Introduction</h2>
    <div class="text">xxxxxxx<br/>xxxxxxx<br/>xxxxxxx<br/>xxxxxxx</div>
</div>
