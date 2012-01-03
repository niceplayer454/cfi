using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.Web.VP.Demo
{
    public partial class Feedback : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<object> ds = new List<object>();

                ds.Add(new
                {
                    ID = 1,
                    No = "1",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "Green",
                    Status = "Submitted"
                });
                ds.Add(new
                {
                    ID = 2,
                    No = "2",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "Productivity",
                    Status = "Processed"
                });
                ds.Add(new
                {
                    ID = 3,
                    No = "3",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "HMI",
                    Status = "Rejected"
                });
                ds.Add(new
                {
                    ID = 4,
                    No = "4",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "Better together",
                    Status = "Review Schedual"
                });
                ds.Add(new
                {
                    ID = 5,
                    No = "5",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "Security",
                    Status = "Reviewing"
                });
                ds.Add(new
                {
                    ID = 6,
                    No = "6",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "Manageability",
                    Status = "Next Action"
                });
                ds.Add(new
                {
                    ID = 7,
                    No = "7",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "Reliability",
                    Status = "Feedback"
                });
                ds.Add(new
                {
                    ID = 8,
                    No = "8",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "ME",
                    Status = "Closed"
                });
                ds.Add(new
                {
                    ID = 9,
                    No = "9",
                    Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                    Time = "2011-12-01",
                    Type = "Thermal",
                    Status = "Closed"
                });

                this.GvList.DataSource = ds;
                this.GvList.DataBind();
            }
        }

        protected void GvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.MpeAdd.Show();
        }

    }
}