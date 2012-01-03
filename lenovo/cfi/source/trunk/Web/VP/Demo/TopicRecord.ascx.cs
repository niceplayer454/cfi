using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.Web.VP.Demo
{
    public partial class TopicRecord : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<object> ds = new List<object>();

                for (int i = 0; i < 10; i++)
                {
                    ds.Add(new
                    {
                        ID = i+1,
                        No = (i+1).ToString(),
                        Title = @"电源适配器卷伸设计",
                        Start = "10:00",
                        Owner = "xxx",
                    });
                }
                GvList.DataSource = ds;
                GvList.DataBind();
            }
        }

        protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0) e.Row.CssClass = "completed";
            if (e.Row.RowIndex == 2) e.Row.CssClass = "running";
        }
    }
}