using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.Web.VP.Demo
{
    public partial class TopicTrack : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<object> ds = new List<object>();

            ds.Add(new
            {
                ID = 1,
                No = "1",
                Title = @"电源适配器卷伸设计",
                Start = "10:00",
                Owner = "xxx",
                Period = "10",
                Type = "HMI",
                Sort = "1"
            });
            ds.Add(new
            {
                ID = 2,
                No = "2",
                Title = @"电源适配器卷伸设计",
                Start = "10:10",
                Owner = "xxx",
                Period = "10",
                Type = "HMI",
                Sort = "2"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Type = "HMI",
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 4,
                No = "4",
                Title = @"电源适配器卷伸设计",
                Start = "10:30",
                Owner = "xxx",
                Period = "15",
                Type = "HMI",
                Sort = "4"
            });
            ds.Add(new
            {
                ID = 5,
                No = "5",
                Title = @"电源适配器卷伸设计",
                Start = "10:45",
                Owner = "xxx",
                Period = "10",
                Type = "HMI",
                Sort = "5"
            });

            this.GvList.DataSource = ds;
            this.GvList.DataBind();
        }
    }
}