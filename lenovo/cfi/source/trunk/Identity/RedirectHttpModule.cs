using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lenovo.CFI.Identity
{
    /// <summary>
    /// 根据Cookie恢复身份验证Session的HttpModule。
    /// </summary>
    public class RedirectHttpModule : IHttpModule
    {
        #region IHttpModule Members


        public void Init(HttpApplication context)
        {
            context.BeginRequest +=new EventHandler(Context_BeginRequest);
        }

        /// <summary>
        /// 处置由实现 IHttpModule 的模块使用的资源（内存除外）。
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        //
        private void Context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            if (context.Request.Form["__EVENTTARGET"] == "HeaderControl1$LogoutButton")
            {
                IdentityCookieHttpModule.RemoveAuthCookie(context);     // 清除
                context.Response.Redirect("~/");
                context.Response.End();
            }

            string url = context.Request.Url.ToString().ToLower();

            int index = url.IndexOf("tqmp/web/ewg");
            if (index >= 0)
            {
                url = url.Substring(0, index) + System.Configuration.ConfigurationManager.AppSettings["SysNew"] + "/Default.aspx?vp=ewghome";

                context.Response.Redirect(url);
                context.Response.End();
                return;
            }

            //index = url.IndexOf("tqmp/web/rc");
            //if (index >= 0)
            //{
            //    url = url.Substring(0, index) + "EWG/Default.aspx?vp=rchome";

            //    context.Response.Redirect(url);
            //    context.Response.End();
            //    return;
            //}

            index = url.IndexOf("tqmp/web/useredit");
            if (index >= 0)
            {
                url = url.Substring(0, index) + System.Configuration.ConfigurationManager.AppSettings["SysNew"] + "/Default.aspx?vp=cfguser";

                context.Response.Redirect(url);
                context.Response.End();
                return;
            }
        }
    }
}
