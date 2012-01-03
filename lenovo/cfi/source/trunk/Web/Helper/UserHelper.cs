using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lenovo.CFI.Common.Sys;

using TB.Web.Nav;
using Lenovo.CFI.BLL.Sys;
using Lenovo.CFI.Common;


namespace Lenovo.CFI.Web.Helper
{
    /// <summary>
    /// UserHelper 的摘要说明
    /// </summary>
    public class UserHelper
    {
        private UserHelper() { }

        #region user

        public static Guid UserKey
        {
            get
            {
                return User.UserKey;
                //if (IsLogin())
                //{
                //    return User.UserKey;
                //}
                //else
                //{
                //    ReLogin();
                //}
                //return Guid.Empty;
            }
        }

        public static string UserName
        {
            get
            {
                return User.UserName;
                //if (IsLogin())
                //{
                //    return User.UserName;
                //}
                //else
                //{
                //    ReLogin();
                //}
                //return null;
            }
        }

        public static string RealName
        {
            get
            {
                return User.RealName;
                //if (IsLogin())
                //{
                //    return User.RealName;
                //}
                //else
                //{
                //    ReLogin();
                //}
                //return null;
            }
        }


        #endregion

        #region Log in / out

        /// <summary>
        /// 系统内部验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string username, string password, out string message)
        {
            SessionUser sUser = LoginPrivate(username, password, out message);

            if (sUser != null)
            {
                return true;
            }
            else
                return false;
        }

        public static bool LoginDirect(string username)
        {
            UserBl userBl = new UserBl();
            User user = userBl.GetUserByItCode(username);

            SessionUser sUser = LoginPrivate(user);

            if (sUser != null)
                return true;
            else
                return false;
        }

        private static SessionUser LoginPrivate(string username, string password, out string message)
        {
            UserBl userBl = new UserBl();

            User user = userBl.Login(username, password);

            if (user != null)
            {
                message = null;
                return LoginPrivate(user);
            }
            else
            {
                message = "ItCode or Password is invalid!";
                return null;
            }
        }

        private static SessionUser LoginPrivate(User user)
        {
            if (user != null)
            {

                SessionUser sUser = new SessionUser(user.UID, user.ItCode, user.FullName);

                User = sUser;

                List<string> perms = new List<string>();
                perms.AddRange(new string[] { "0", "1", "2", "4", "8", "16", "32", "64", "128", "256"});

                sUser.NavCfg = NavCfgMgr.GetUserNavCfg(perms.ToArray());

                return sUser;
            }
            else
                return null;
        }

        public static void SetUserNav()
        {
            SessionUser sUser = User;

            List<string> perms = new List<string>();
            perms.AddRange(new string[] { "0", "1", "2", "4", "8", "16", "32", "64", "128", "256" });

            string vp = GetVPKey();
            if (vp != null) HttpContext.Current.Items[vp] = null;

            sUser.NavCfg = NavCfgMgr.GetUserNavCfg(perms.ToArray());
        }

        public static void Logout()
        {
            Identity.IdentityCookieHttpModule.RemoveAuthCookie(HttpContext.Current);

            HttpContext.Current.Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Login.aspx?r=f");
        }

        public static void ReLogin()
        {
            HttpContext.Current.Session["lastUrl"] = HttpContext.Current.Request.RawUrl;
            HttpContext.Current.Response.Redirect("Login.aspx");
        }

        public static void ReLogin(string lastUrl)
        {
            HttpContext.Current.Session["lastUrl"] = lastUrl;
            HttpContext.Current.Response.Redirect("Login.aspx");
        }

        public static bool IsLogin()
        {
            if (HttpContext.Current.Session["user"] != null) return true;
            else 
            {
                if (HttpContext.Current.Session["UID"] != null)
                {
                    // 根据Cookie创建
                    User user = new UserBl().GetUserByUID((Guid)HttpContext.Current.Session["UID"]);

                    if (user != null)
                    {
                        SessionUser sUser = LoginPrivate(user);

                        return (sUser != null);
                    }
                }
            }

            return false;
        }

        public static void CheckLogin()
        {
            if (!IsLogin())
            {
                HttpContext.Current.Session["lastUrl"] = HttpContext.Current.Request.RawUrl;
                HttpContext.Current.Response.Redirect("Login.aspx");
            }
        }

        private static SessionUser User
        {
            get { return (SessionUser)HttpContext.Current.Session["user"]; }
            set { HttpContext.Current.Session["user"] = value; }
        }

        #endregion

        #region nav

        public static string GetVPKey()
        {
            string vpKey = HttpContext.Current.Request.QueryString["vp"];
            if (String.IsNullOrEmpty(vpKey))
                vpKey = HttpContext.Current.Items["defaultVP"].ToString();

            return vpKey;
        }
        public static TB.Web.Nav.VP GetVP()
        {
            TB.Web.Nav.VP vp = null;
            HttpContext currContext = HttpContext.Current;

            string vpKey = currContext.Request.QueryString["vp"];
            if (String.IsNullOrEmpty(vpKey))
                vpKey = currContext.Items["defaultVP"].ToString();
            if (!String.IsNullOrEmpty(vpKey))
            {
                if (currContext.Items.Contains(vpKey))
                    vp = (TB.Web.Nav.VP)(currContext.Items[vpKey]);
                else
                {
                    vp = User.NavCfg.GetVP(vpKey);

                    if (vp != null)
                        currContext.Items.Add(vpKey, vp);
                }
            }

            if (vp == null)
            {
                // 不存在或没有权限，引发异常
                throw new ApplicationException("很抱歉，您试图访问的网页不存在!");
            }

            return vp;
        }

        public static bool CanAccessVP()
        {
            HttpContext currContext = HttpContext.Current;
            string vpKey = currContext.Request.QueryString["vp"];
            if (vpKey == null) return false;
            else return CanAccessVP(vpKey);
        }

        public static bool CanAccessVP(string vpKey)
        {
            return User.NavCfg.GetVP(vpKey) != null;
        }

        public static string GetVPUrl(string vpKey)
        {
            string url = User.NavCfg.GetVPUrl(vpKey);
            if (url == null)
                url = "#";
            return url;
        }


        /// <summary>
        /// 判断用户是否具有访问指定VP的权限
        /// </summary>
        /// <param name="funcTag">权限标记</param>
        /// <returns></returns>
        public static bool HasVPAccessPerm(string funcTag)
        {
            return GetVP().HasPerm(funcTag);
        }

        /// <summary>
        /// 检验用户是否具有指定的权限
        /// </summary>
        /// <param name="funcId">权限编码</param>
        /// <returns></returns>
        public static bool HasAccessPerm(string funcId)
        {
            return User.NavCfg.CheckFuncPerm(funcId);
        }

        /// <summary>
        /// 获取所有第一级节点
        /// </summary>
        /// <returns></returns>
        public static NavMenu[] GetRootMenus()
        {
            return User.NavCfg.GetRootMenus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootId">第一级节点ID</param>
        /// <returns></returns>
        public static NavMenu GetMenuTree(string rootId)
        {
            return User.NavCfg.GetMenu(rootId);
        }

        public static NavMenu GetMenu(string menuId)
        {
            return User.NavCfg.GetMenu(menuId);
        }

        #endregion

        #region SessionUser

        private class SessionUser
        {
            public SessionUser(Guid userKey, string userName, string realName)
            {
                this.userKey = userKey;
                this.userName = userName;
                this.realName = realName;
            }

            private Guid userKey;
            private string userName;
            private string realName;
            private UserNavCfg navCfg;

            public Guid UserKey
            {
                get { return this.userKey; }
            }
            public string UserName
            {
                get { return this.userName; }
            }
            public string RealName
            {
                get { return realName; }
            }

            public UserNavCfg NavCfg
            {
                get { return this.navCfg; }
                set { this.navCfg = value; }
            }
        }

        #endregion
    }
}
