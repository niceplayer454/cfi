using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Log = Dotnet.Commons.Logging.ILog;
using LogFactory = Dotnet.Commons.Logging.LogFactory;

namespace Lenovo.CFI.Web
{
    public class Global : System.Web.HttpApplication
    {
        private Log log = LogFactory.GetLogger(typeof(Global));

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["TB.Web.NavComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=83576787bd14e1f0"] = "授权北京联想台式研发中心使用TB.Web.NavComponent控件";
        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}