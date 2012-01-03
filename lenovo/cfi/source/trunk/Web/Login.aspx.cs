using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lenovo.CFI.Web.Helper;
using Lenovo.CFI.Common.Sys;
using Lenovo.CFI.BLL.Sys;
using Lenovo.CFI.Common;

namespace Lenovo.CFI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
#if DEBUG
                this.TxtUserName.Text = "test1";
                this.TxtPassword.Text = "123456";
                this.TxtPassword.TextMode = TextBoxMode.SingleLine;
#endif

                this.Page.Form.DefaultButton = this.BtnLogin.UniqueID;

            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string message = "";
            if (UserHelper.Login(this.TxtUserName.Text, this.TxtPassword.Text, out message))
            {
                Identity.IdentityCookieHttpModule.EstablishSession(UserHelper.UserKey, UserHelper.UserName, Context);

                if (HttpContext.Current.Session["lastUrl"] != null)
                {
                    string url = HttpContext.Current.Session["lastUrl"].ToString();
                    HttpContext.Current.Session["lastUrl"] = null;
                    Response.Redirect(url, true);
                }
                else
                    Response.Redirect("Default.aspx", true);
            }
            else
            {
                this.LtrMsg.Text = message;

                this.Page.Form.DefaultButton = this.BtnLogin.UniqueID;
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            UserBl userBl = new UserBl();
            User user = userBl.GetUserByItCode(this.TxtUserName.Text);

            if (user != null)
            {
                userBl.SendPassword(user.ItCode);

                this.LtrMsg.Text = "The password has been send to your lenovo mail box!";
            }
            else
            {
                this.LtrMsg.Text = "Invalid ItCode!";
            }

            this.Page.Form.DefaultButton = this.BtnLogin.UniqueID;

        }
    }
}
