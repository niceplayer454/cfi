using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lenovo.CFI.Web.Helper;
using Lenovo.CFI.BLL.DicMgr;
using Lenovo.CFI.BLL.Sys;

namespace Lenovo.CFI.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private TB.Web.Nav.VP vp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
                // 处理公共导航元素
                this.NavMenu.SetMenus(UserHelper.GetRootMenus()[0].Children, vp.LeafMenu);
                if (vp.Tabs != null)
                {
                    this.NavTab.SetTabs(vp.Tabs, vp.SelectedTab);
                    //this.NavTitle.Title = vp.Title;
                }
                else
                {
                    this.tab.Visible = false;
                    this.NavTab.Visible = false;
                }

                if (!Page.IsPostBack)
                {
                    if (UserHelper.RealName.Length < 6)
                    {
                        //this.LtrUser.Text = String.Format("Hi, {0}!", UserHelper.RealName);
                        //this.LtrDate.Text = String.Format("{0:yyyy-MM-dd dddd}", DateTime.Now);
                    }
                    else
                    {
                        //this.LtrUser.Text = String.Format("Hi, {0}!", UserHelper.RealName);
                        //this.LtrDate.Text = String.Format("{0:yy-MM-dd}", DateTime.Now);
                    }

                }
        }

        #region vp
        /// <summary>
        /// 验证已登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //UserHelper.CheckLogin();
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
                this.Page.Title = "Call for Idea System -- " + vp.Title;
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
