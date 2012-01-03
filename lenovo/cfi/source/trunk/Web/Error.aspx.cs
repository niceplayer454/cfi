using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Items["Exception"] != null)
            {
                Exception ex = (Exception)(HttpContext.Current.Items["Exception"]);
                this.LtrDetail.Text = ex.Message + ";" + ex.StackTrace;
            }
        }
    }
}
