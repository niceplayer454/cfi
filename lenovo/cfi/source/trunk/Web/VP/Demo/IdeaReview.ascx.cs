using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.Web.VP.Demo
{
    public partial class IdeaReview : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<object> ds = new List<object>();

            ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            });
            ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            }); ds.Add(new
            {
                ID = 1,
                No = "1",
                Start = "10:00",
                Title = @"<a href=""Default.aspx?vp=myideadetail"">电源适配器卷伸设计</a>",
                Owner = "xxx",
                Type = "HMI",
            });


            this.GvList.DataSource = ds;
            this.GvList.DataBind();
        }

        protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0) e.Row.CssClass = "completed";
            if (e.Row.RowIndex == 2) e.Row.CssClass = "running";
        }
    }
}