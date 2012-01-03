using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lenovo.CFI.Web.Helper;

namespace Lenovo.CFI.Web
{
    public partial class Open : System.Web.UI.Page
    {
        private TB.Web.Nav.VP vp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region vp
        /// <summary>
        /// 验证已登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            UserHelper.CheckLogin();
        }

        /// <summary>
        /// 动态创建控件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(HttpContext.Current.Request.QueryString["vp"]))
                    HttpContext.Current.Items["defaultVP"] =
                        System.Configuration.ConfigurationManager.AppSettings["defaultVP"];

                vp = UserHelper.GetVP();
                Control ctlVP = this.Page.LoadControl(vp.File);
                ctlVP.ID = "VP";
                this.PhVP.Controls.Add(ctlVP);

                // 设置Title
                this.Page.Title = "Smart Data System -- " + vp.Title;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().IndexOf("does not exist.") >= 0 ||
                    ex.Message.ToLower().IndexOf("不存在") >= 0)
                    this.Page.Response.Redirect("404NotFound.aspx", true);
                else
                    throw ex;
            }
        }
        #endregion

    }
}
