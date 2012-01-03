<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Lenovo.CFI.Web.VP.Home" %>
<tbwc:StyleSheetControl ID="SscList" runat="server" CssPath="list.css"></tbwc:StyleSheetControl>
<tbwc:StyleSheetControl ID="SscLink" runat="server" CssPath="VP/home.css"></tbwc:StyleSheetControl>

<script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $("#showalltopic").click(function () {
            $("#moretopiclist").toggle();
        });

    });

    </script>


<div id="topiclist">
    <h2><span class="status"><span class="item">Collection</span><span class="item">Review</span><span class="item">Execution</span></span>Topic List</h2>
    <div class="topicitem">
        <h3><span class="status"><span class="item">Finished</span><span class="item">On-going</span><span class="item">&nbsp;</span></span>
            Topic 7: Green xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx (detail link)</h3>
    </div>
    <div class="topicitem">
        <h3><span class="status"><span class="item">Finished</span><span class="item">Finished</span><span class="item">On-going</span></span>
            Topic 6: Green xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx (detail link)</h3>
    </div>
    <div id="showalltopic"><a>click here and show all topics</a></div>
    <div id="moretopiclist" style="display:none;">
        <div class="topicitem hide">
            <h3><span class="status"><span class="item">Finished</span><span class="item">Finished</span><span class="item">Finished</span></span>
                Topic 5: Green xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx (detail link)</h3>
        </div>
        <div class="topicitem hide">
            <h3><span class="status"><span class="item">Finished</span><span class="item">Finished</span><span class="item">Finished</span></span>
                Topic 6: Green xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx xxxxx (detail link)</h3>
        </div>
    </div>
</div>

<div id="summarylist">
    <h2>My Idea</h2>
    <div class="item"><em>Count:</em><a href="#">9 提交的Idea数量，点击到MyIdea页面</a></div>


    <h2>My Work</h2>
    <div class="item"><em>Approval:</em><a href="#">9 Manager需要审批的Idea数量，点击到Approval页面</a></div>
    <div class="item"><em>Review Ideas:</em><a href="Default.aspx?vp=dclist&type=1">9 DC需要Review的Idea数量，点击到DC List页面，且默认显示Review的</a></div>
    <div class="item"><em>AR:</em><a href="#">9 Executor需要执行的Idea数量，点击到Tracking页面</a></div>
    <div class="item"><em>Topic work:</em><a href="#">topic 需要上传材料的topic，点击到上传页面（如果多个topic，逐个显示）</a></div>
    <div class="item"><em>Topic review:</em><a href="#">topic 需要评审的topic，点击到评审页面（如果多个topic，逐个显示）</a></div>


    <h2>My Team</h2>
    <div class="item"><em>Idea:</em><a href="#">9 负责的Team提交的Idea的数量，点击到Search页面，默认显示这些idea</a></div>
    <div class="item"><em>AR:</em><a href="#">9 负责的Team需要执行的Idea数量，点击到Search页面，默认显示这些idea</a></div>

</div>