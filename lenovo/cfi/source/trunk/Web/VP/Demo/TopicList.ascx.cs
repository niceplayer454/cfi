using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.Web.VP.Demo
{
    public partial class TopicList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<object> ds = new List<object>();

            ds.Add(new
            {
                ID = 1,
                No = "1",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Preparing",
                Action = ""
            });
            ds.Add(new
            {
                ID = 2,
                No = "2",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Starting",
                Action = ""
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Schedule",
                Action = ""
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Schedule",
                Action = ""
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Schedule",
                Action = ""
            });
            ds.Add(new
            {
                ID = 4,
                No = "4",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Reviewing",
                Action = ""
            });
            ds.Add(new
            {
                ID = 5,
                No = "5",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Next Action",
                Action = ""
            });
            ds.Add(new
            {
                ID = 5,
                No = "5",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Next Action",
                Action = ""
            });
            ds.Add(new
            {
                ID = 6,
                No = "6",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Feedback",
                Action = ""
            });
            ds.Add(new
            {
                ID = 7,
                No = "7",
                Title = @"<a href=""Default.aspx?vp=topicdetail"">Topic xxxxxxxxx</a>",
                Tdc = "xxxxxx",
                Start = "2011-12-01",
                Submit = "2011-12-01",
                Review = "2011-12-01",
                Status = "Closed",
                Action = ""
            });



            this.GvList.DataSource = ds;
            this.GvList.DataBind();
        }

        protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnAction1 = (LinkButton)e.Row.FindControl("BtnPhaseAction1");
                LinkButton btnAction2 = (LinkButton)e.Row.FindControl("BtnPhaseAction2");
                LinkButton btnAction3 = (LinkButton)e.Row.FindControl("BtnPhaseAction3");

                switch (e.Row.RowIndex)
                {
                    case 0:
                        btnAction1.Text = "Start";
                        btnAction2.Text = "Edit";
                        btnAction3.Text = "Delete";
                        break;
                    case 1:
                        btnAction1.Visible = false; //.Text = "Stop Submit";
                        btnAction2.Visible = false;
                        btnAction3.Visible = false;
                        break;
                    case 2:
                        btnAction1.Text = "Set Schedule";
                        btnAction1.OnClientClick = "window.open('Default.aspx?vp=topicschedule')";
                        btnAction2.Visible = false;
                        btnAction3.Visible = false;
                        break;
                    case 3:
                        btnAction1.Text = "Set Reviewer";
                        btnAction1.OnClientClick = "window.open('Default.aspx?vp=topicreviewer')";
                        btnAction2.Visible = false;
                        btnAction3.Visible = false;
                        break;
                    case 4:
                        btnAction1.Text = "Start Review";
                        btnAction2.Visible = false;
                        btnAction3.Visible = false;
                        break;
                    case 5:
                        btnAction1.Text = "Record Review";
                        btnAction1.OnClientClick = "window.open('Default.aspx?vp=topicrecord')";
                        btnAction2.Text = "Close Review";
                        btnAction3.Visible = false;
                        break;
                    case 6:
                        btnAction1.Text = "Set DC and IP";
                        btnAction1.OnClientClick = "window.open('Default.aspx?vp=topicdcip')";
                        btnAction2.Visible = false;
                        btnAction3.Visible = false;
                        break;
                    case 7:
                        btnAction1.Text = "Summary Review";
                        btnAction1.OnClientClick = "window.open('Default.aspx?vp=topicsummary')";
                        btnAction2.Visible = false;
                        btnAction3.Visible = false;
                        break;
                    case 8:
                        btnAction1.Text = "Tracking";
                        btnAction1.OnClientClick = "window.open('Default.aspx?vp=topictrack')";
                        btnAction2.Text = "Close";
                        btnAction3.Visible = false;
                        break;
                    case 9:
                        btnAction1.Visible = false;
                        btnAction2.Visible = false;
                        btnAction3.Visible = false;
                        break;
                }
            }
        }
    }
}