using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.Web.VP.Demo
{
    public partial class TopicSummary : System.Web.UI.UserControl
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
                    Reviewer = "xxxxxx",
                    Submitted = "21",
                });
                ds.Add(new
                {
                    ID = 2,
                    No = "2",
                    Reviewer = "xxxxxx",
                    Submitted = "15",
                });
                ds.Add(new
                {
                    ID = 3,
                    No = "3",
                    Reviewer = "xxxxxx",
                    Submitted = "26",
                });
                ds.Add(new
                {
                    ID = 4,
                    No = "4",
                    Reviewer = "xxxxxx",
                    Submitted = "21",
                });


                this.GvList.DataSource = ds;
                this.GvList.DataBind();


                this.GvIdeas.Visible = false;
                this.GvIdeas.Visible = false;
            }
        }

        

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.GvIdeas.Visible = true;


            List<object> ds = new List<object>();

            ds.Add(new
            {
                ID = 1,
                No = "1",
                Title = @"电源适配器卷伸设计",
                Start = "10:00",
                Owner = "xxx",
                Period = "10",
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
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Sort = "3"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3",
                Title = @"电源适配器卷伸设计",
                Start = "10:20",
                Owner = "xxx",
                Period = "10",
                Sort = "3"
            });


            this.GvIdeas.DataSource = ds;
            this.GvIdeas.DataBind();
        }

        protected void GvIdeas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            this.GvReview.Visible = true;

            List<object> ds = new List<object>();

            ds.Add(new
            {
                ID = 1,
                No = "1"
            });
            ds.Add(new
            {
                ID = 2,
                No = "2"
            });
            ds.Add(new
            {
                ID = 3,
                No = "3"
            });
            ds.Add(new
            {
                ID = 4,
                No = "4"
            });



            this.GvReview.DataSource = ds;
            this.GvReview.DataBind();
        }
    }
}