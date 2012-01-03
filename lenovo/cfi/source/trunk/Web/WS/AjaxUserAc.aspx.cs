using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lenovo.CFI.Web.Helper;
using System.Text;

namespace Lenovo.CFI.Web.WS
{
    public partial class AjaxUserAc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Charset = "utf-8";
            Response.Buffer = true;
            this.EnableViewState = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "text/plain";

            Response.Write(GetUsers(UrlHelper.GetQueryString("q")));

            Response.Flush();
            Response.End();
        }



        private string GetUsers(string query)
        {
            //List<User> users = UserCache.GetAllUser();

            //query = query.ToLower();
            //string[] qs = query.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //if (qs.Length > 0)
            //{
            //    users = users.FindAll(delegate(User u)
            //    {
            //        foreach (string q in qs)
            //        {
            //            if (u.ItCode.IndexOf(q) < 0) return false;
            //        }

            //        return true;
            //    });
            //}
            StringBuilder sbstr = new StringBuilder();
            sbstr.Append("[");
            bool first = true;
            //foreach (User user in users)
            foreach (String user in new string[] { query + "a", query + "b", query + "c", query + "d", query + "e", })
            {
                if (!first)
                    sbstr.Append(",");
                else
                    first = false;
                sbstr.Append("'" + user + "'");
            }
            sbstr.Append("]");

            return sbstr.ToString();
        }
    }
}